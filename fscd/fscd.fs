// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.

// F# Compiler Daemon sample
//
// Sample use, assumes app has a reference to ELmish.XamrinForms.LiveUpdate:
//
// cd Elmish.XamarinForms\Samples\CounterApp\CounterApp
//   adb -d forward  tcp:9867 tcp:9867
// dotnet run --project ..\..\..\fscd\fscd.fsproj -- --eval @out.args
// dotnet run --project ..\..\..\fscd\fscd.fsproj -- --watch --webhook:http://localhost:9867/update @out.args

module FSharpDaemon.Driver

open FSharp.Compiler.PortaCode.CodeModel
open FSharp.Compiler.PortaCode.Interpreter
open FSharp.Compiler.PortaCode.FromCompilerService
open System
open System.IO
open System.Collections.Generic
open Microsoft.FSharp.Compiler.SourceCodeServices
open System.Net
open FSharp.FSW

#if TEST
module MockForms = 
    open Xamarin.Forms
    open Xamarin.Forms.Internals
    type MockPlatformServices() = 
        interface IPlatformServices with 
            member __. GetMD5Hash(input) = raise (NotImplementedException())
            member __.GetNamedSize(size, targetElement, useOldSizes) = 10.0
            member __.OpenUriAction(uri) = raise (NotImplementedException())
            member __.IsInvokeRequired = false
            member __.get_RuntimePlatform() = Unchecked.defaultof<_> 
            member __.BeginInvokeOnMainThread(action: Action) = action.Invoke()
            member __.CreateTicker() = raise (NotImplementedException())
            member __.StartTimer(interval, callback) =  raise (NotImplementedException())
            member __.GetStreamAsync(uri, cancellationToken) = raise (NotImplementedException())
            member __.GetAssemblies() = raise (NotImplementedException())
            member __.GetUserStoreForApplication() = raise (NotImplementedException())
            member __.QuitApplication() = raise (NotImplementedException())

    type MockDeserializer() = 
        interface IDeserializer with
            member __.DeserializePropertiesAsync() = raise (NotImplementedException())
            member __.SerializePropertiesAsync(properties: IDictionary<string, obj>)  = raise (NotImplementedException())

    type MockResourcesProvider() = 
        interface ISystemResourcesProvider with 
            member __.GetSystemResources() = raise (NotImplementedException())

    type MockDeviceInfo() = 
        inherit DeviceInfo()
        override __.PixelScreenSize = raise (NotImplementedException())
        override __.ScaledScreenSize = raise (NotImplementedException())
        override __.ScalingFactor = raise (NotImplementedException())

    let Init() = 
        Device.Info <- new MockDeviceInfo()
        Device.PlatformServices <- new MockPlatformServices()
        DependencyService.Register<MockResourcesProvider>()
        DependencyService.Register<MockDeserializer>()
#endif

let checker = FSharpChecker.Create(keepAssemblyContents = true)


#if !TEST
[<EntryPoint>]
#endif
let main (argv: string[]) =
    try 
#if TEST
        MockForms.Init()
#endif
        let mutable fsproj = None
        let mutable eval = false
        let mutable watch = false
        let mutable webhook = None
        let args = 
           let mutable haveDashes = false

           [| for arg in argv do 
                 let arg = arg.Trim()
                 if arg.StartsWith("@") then 
                     for line in File.ReadAllLines(arg.[1..]) do 
                         let line = line.Trim()
                         if not (String.IsNullOrWhiteSpace(line)) then
                             yield line
                 elif arg.EndsWith(".fsproj") then 
                     fsproj <- Some arg
                 elif arg = "--" then haveDashes <- true
                 elif arg = "--watch" then watch <- true
                 elif arg = "--eval" then eval <- true
                 elif arg.StartsWith "--webhook:" then webhook  <- Some arg.["--webhook:".Length ..]
                 else yield arg  |]

        if args.Length = 0 && fsproj.IsNone then 
            match Seq.toList (Directory.EnumerateFiles(Environment.CurrentDirectory, "*.fsproj")) with 
            | [ ] -> 
                failwith "no project file found, no compilation arguments given" 
            | [ file ] -> 
                printfn "fscd: using implicit project file '%s'" file
                fsproj <- Some file
            | _ -> 
                failwith "multiple project files found" 

        let options = 
            match fsproj with 
            | Some fsprojFile -> 
                if args.Length > 1 then failwith "can't give both project file and compilation arguments"
                match FSharpDaemon.ProjectCracker.load (new System.Collections.Concurrent.ConcurrentDictionary<_,_>()) fsprojFile with 
                | Ok (options, sourceFiles, _log) -> 
                    let options = { options with SourceFiles = Array.ofList sourceFiles }
                    let sourceFilesSet = Set.ofList sourceFiles
                    let options = { options with OtherOptions = options.OtherOptions |> Array.filter (fun s -> not (sourceFilesSet.Contains(s))) }
                    options
                | Error err -> 
                   failwithf "Couldn't parse project file: %A" err
            
            | None -> 
                let sourceFiles, otherFlags = args |> Array.partition (fun arg -> arg.EndsWith(".fs") || arg.EndsWith(".fsi") || arg.EndsWith(".fsx"))
                let sourceFiles = sourceFiles |> Array.map Path.GetFullPath 
        
                printfn "CurrentDirectory = %s" Environment.CurrentDirectory
                let options = checker.GetProjectOptionsFromCommandLineArgs("tmp.fsproj", otherFlags)
                let options = { options with SourceFiles = sourceFiles }
                options

        //printfn "options = %A" options

        let rec checkFile count sourceFile =         
            try 
                let _, checkResults = checker.ParseAndCheckFileInProject(sourceFile, 0, File.ReadAllText(sourceFile), options) |> Async.RunSynchronously  
                match checkResults with 
                | FSharpCheckFileAnswer.Aborted -> 
                    printfn "aborted"
                    Result.Error ()
                | FSharpCheckFileAnswer.Succeeded res -> 
                    let mutable hasErrors = false
                    for error in res.Errors do 
                        printfn "%s" (error.ToString())
                        if error.Severity = FSharpErrorSeverity.Error then 
                            hasErrors <- true
                    if hasErrors then 
                        Result.Error ()
                    else
                        Result.Ok res.ImplementationFile 
            with 
            | :? System.IO.IOException when count = 0 -> System.Threading.Thread.Sleep 500; checkFile 1 sourceFile
            | exn -> 
                printfn "%s" (exn.ToString())
                Result.Error ()

        let convFile (i: FSharpImplementationFileContents) =         
            //(i.QualifiedName, i.FileName
            { Code = convDecls i.Declarations }
            
        let jsonFile (i: FSharpImplementationFileContents) =         
            let data = convFile  i
            let json = Newtonsoft.Json.JsonConvert.SerializeObject(data)
            json


        if watch then 
            let watchers = 
                [ for sourceFile in options.SourceFiles do
                     let path = Path.GetDirectoryName(sourceFile)
                     let fileName = Path.GetFileName(sourceFile)
                     printfn "fscd: WATCHING %s in %s" fileName path 
                     let watcher = new FileSystemWrapper(path, fileName)
                     NotifyFilters.Attributes ||| NotifyFilters.CreationTime ||| NotifyFilters.FileName ||| NotifyFilters.LastAccess ||| NotifyFilters.LastWrite ||| NotifyFilters.Size ||| NotifyFilters.Security
                     |> watcher.NotifyFilter
                     //let watcher = new FileSystemWatcher(path, fileName)
                     //watcher.NotifyFilter <- NotifyFilters.Attributes ||| NotifyFilters.CreationTime ||| NotifyFilters.FileName ||| NotifyFilters.LastAccess ||| NotifyFilters.LastWrite ||| NotifyFilters.Size ||| NotifyFilters.Security;
                     let changed = (fun (ev: FileSystemEventArgs) -> 
                         try 
                             printfn "fscd: CHANGE DETECTED for %s, COMPILING...." sourceFile
                             match checkFile 0 ev.FullPath  with 
                             | Result.Error () -> 
                                 printfn "fscd: ERRORS for %s" sourceFile
                             | Result.Ok iopt -> 
                                 printfn "fscd: COMPILED %s" sourceFile
                                 match iopt with 
                                 | None -> ()
                                 | Some i -> 
                                     printfn "fscd: GOT PortaCode for %s" sourceFile
                                     let json = jsonFile i
                                     printfn "fscd: GOT JSON for %s, length = %d" sourceFile json.Length
                                     match webhook with 
                                     | Some hook -> 
                                         try 
                                             use webClient = new WebClient()
                                             printfn "fscd: SENDING TO WEBHOOK... " // : <<<%s>>>... --> %s" json.[0 .. min (json.Length - 1) 100] hook
                                             let resp = webClient.UploadString(hook,"Put",json)
                                             printfn "fscd: RESP FROM WEBHOOK: %s" resp
                                         with err -> 
                                             printfn "fscd: ERROR SENDING TO WEBHOOK: %A" (err.ToString())

                                     | None -> 
                                         ()
                         with err -> 
                             printfn "fscd: exception: %A" (err.ToString()) )
                     //watcher.Changed.Add changed 
                     watcher.AddChangedHandler changed
                     //watcher.Created.Add changed
                     //watcher.Deleted.Add changed
                     yield watcher ]

            for watcher in watchers do
               //watcher.EnableRaisingEvents <- true
               watcher.EnableRaisingEvents true

            printfn "Waiting for changes..." 
            System.Console.ReadLine() |> ignore
            for watcher in watchers do
               //watcher.EnableRaisingEvents <- true
               watcher.EnableRaisingEvents true

        else
            printfn "compiling, options = %A" options
            for o in options.OtherOptions do 
               printfn "compiling, option %s" o
            let fileContents = 
               [| for sourceFile in options.SourceFiles do
                    match checkFile 0 sourceFile with 
                    | Result.Error _ -> failwith "errors"
                    | Result.Ok iopt -> 
                        match iopt with 
                        | None -> () // signature file
                        | Some i -> yield i |]

            printfn "#ImplementationFiles  = %d" fileContents.Length

            if eval then 
                let ctxt = EvalContext()
                let fileConvContents = [| for i in fileContents -> convFile i |]
                for ds in fileConvContents do 
                     ctxt.AddDecls(ds.Code)
                for ds in fileConvContents do 
                    //printfn "eval %A" a
                    ctxt.EvalDecls (envEmpty, ds.Code)

            else
                let fileConvContents = [| for i in fileContents -> jsonFile i |]

                printfn "%A" fileConvContents
        0

    with e -> 
        printfn "Error: %s" (e.ToString())
        1
