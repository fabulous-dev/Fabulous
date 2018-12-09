module FSharpDaemon.ProjectCracker

open System
open System.IO
open System.Collections.Concurrent
open Microsoft.FSharp.Compiler.SourceCodeServices

module MSBuildPrj = Dotnet.ProjInfo.Inspect

type NavigateProjectSM =
    | NoCrossTargeting of NoCrossTargetingData
    | CrossTargeting of string list
and NoCrossTargetingData = { FscArgs: string list; P2PRefs: MSBuildPrj.ResolvedP2PRefsInfo list; Properties: Map<string,string> }

module MSBuildKnownProperties =
    let TargetFramework = "TargetFramework"

module Option =
  let getOrElse defaultValue option =
    match option with
    | None -> defaultValue
    | Some x -> x


type FilePath = string
  [<RequireQualifiedAccess>]
type ProjectSdkType =
#if OLDFORMATS
    | Verbose of ProjectSdkTypeVerbose
    | ProjectJson
#endif
    | DotnetSdk of ProjectSdkTypeDotnetSdk
and ProjectSdkTypeVerbose =
    {
      TargetPath: string
    }
and ProjectSdkTypeDotnetSdk =
    {
      IsTestProject: bool
      Configuration: string // Debug
      IsPackable: bool // true
      TargetFramework: string // netcoreapp1.0
      TargetFrameworkIdentifier: string // .NETCoreApp
      TargetFrameworkVersion: string // v1.0

      MSBuildAllProjects: FilePath list //;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\FSharp.NET.Sdk\Sdk\Sdk.props;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\Sdk\Sdk.props;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.Sdk.props;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.Sdk.DefaultItems.props;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.SupportedTargetFrameworks.props;e:\github\DotnetNewFsprojTestingSamples\sdk1.0\sample1\c1\obj\c1.fsproj.nuget.g.props;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\FSharp.NET.Sdk\Sdk\Sdk.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\Sdk\Sdk.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.Sdk.BeforeCommon.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.DefaultAssemblyInfo.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.DefaultOutputPaths.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.TargetFrameworkInference.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.RuntimeIdentifierInference.targets;C:\Users\e.sada\.nuget\packages\fsharp.net.sdk\1.0.5\build\FSharp.NET.Core.Sdk.targets;e:\github\DotnetNewFsprojTestingSamples\sdk1.0\sample1\c1\c1.fsproj;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Microsoft.Common.CurrentVersion.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\NuGet.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\15.0\Microsoft.Common.targets\ImportAfter\Microsoft.TestPlatform.ImportAfter.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Microsoft.TestPlatform.targets;e:\github\DotnetNewFsprojTestingSamples\sdk1.0\sample1\c1\obj\c1.fsproj.nuget.g.targets;e:\github\DotnetNewFsprojTestingSamples\sdk1.0\sample1\c1\obj\c1.fsproj.proj-info.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.Sdk.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.Sdk.Common.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.PackageDependencyResolution.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.Sdk.DefaultItems.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.DisableStandardFrameworkResolution.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.GenerateAssemblyInfo.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.Publish.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\Microsoft.NET.Sdk\build\Microsoft.NET.PreserveCompilationContext.targets;C:\dotnetcli\dotnet-dev-win-x64.1.0.4\sdk\1.0.4\Sdks\NuGet.Build.Tasks.Pack\build\NuGet.Build.Tasks.Pack.targets
      MSBuildToolsVersion: string // 15.0

      ProjectAssetsFile: FilePath // e:\github\DotnetNewFsprojTestingSamples\sdk1.0\sample1\c1\obj\project.assets.json
      RestoreSuccess: bool // True

      Configurations: string list // Debug;Release
      TargetFrameworks: string list // netcoreapp1.0;netstandard1.6

      TargetPath: string

      //may not exists
      RunArguments: string option // exec "e:\github\DotnetNewFsprojTestingSamples\sdk1.0\sample1\c1\bin\Debug\netcoreapp1.0\c1.dll"
      RunCommand: string option // dotnet

      //from 2.0
      IsPublishable: bool option // true

    }
type ExtraProjectInfoData =
    {
        ProjectOutputType: ProjectOutputType
        ProjectSdkType: ProjectSdkType
    }
and ProjectOutputType =
    | Library
    | Exe
    | Custom of string


type private ProjectParsingSdk = 
    | DotnetSdk 
#if OLDFORMATS
    | VerboseSdk
#endif

type ParsedProject = string * FSharpProjectOptions * ((string * string) list)
type ParsedProjectCache = ConcurrentDictionary<string, ParsedProject>

let chooseByPrefix (prefix: string) (s: string) =
    if s.StartsWith(prefix) then Some (s.Substring(prefix.Length))
    else None
let chooseByPrefix2 prefixes (s: string) =
    prefixes
    |> List.tryPick (fun prefix -> chooseByPrefix prefix s)

let splitByPrefix (prefix: string) (s: string) =
    if s.StartsWith(prefix) then Some (prefix, s.Substring(prefix.Length))
    else None

let splitByPrefix2 prefixes (s: string) =
    prefixes
    |> List.tryPick (fun prefix -> splitByPrefix prefix s)

let outType rsp =
      match List.tryPick (chooseByPrefix "--target:") rsp with
      | Some "library" -> ProjectOutputType.Library
      | Some "exe" -> ProjectOutputType.Exe
      | Some v -> ProjectOutputType.Custom v
      | None -> ProjectOutputType.Exe // default if arg is not passed to fsc

let private outputFileArg = ["--out:"; "-o:"]

let private makeAbs projDir (f: string) =
      if Path.IsPathRooted f then f else Path.Combine(projDir, f)

let outputFile projDir rsp =
      rsp
      |> List.tryPick (chooseByPrefix2 outputFileArg)
      |> Option.map (makeAbs projDir)

let isCompileFile (s:string) =
      s.EndsWith(".fs") || s.EndsWith (".fsi")

let compileFiles =
      //TODO filter the one without initial -
      List.filter isCompileFile

let references =
      //TODO valid also --reference:
      List.choose (chooseByPrefix "-r:")

let useFullPaths projDir (s: string) =
    match s |> splitByPrefix2 outputFileArg with
    | Some (prefix, v) ->
        prefix + (v |> makeAbs projDir)
    | None ->
        if isCompileFile s then
            s |> makeAbs projDir |> Path.GetFullPath
        else
            s
let msbuildPropProjectOutputType (s: string) =
    match s.Trim() with
    | MSBuildPrj.MSBuild.ConditionEquals "Exe" -> ProjectOutputType.Exe
    | MSBuildPrj.MSBuild.ConditionEquals "Library" -> ProjectOutputType.Library
    | x -> ProjectOutputType.Custom x

let msbuildPropBool (s: string) =
    match s.Trim() with
    | "" -> None
    | Dotnet.ProjInfo.Inspect.MSBuild.ConditionEquals "True" -> Some true
    | _ -> Some false

let msbuildPropStringList (s: string) =
    match s.Trim() with
    | "" -> []
    | Dotnet.ProjInfo.Inspect.MSBuild.StringList list  -> list
    | _ -> []

let getExtraInfo targetPath props =
    let msbuildPropBool prop =
        props |> Map.tryFind prop |> Option.bind msbuildPropBool
    let msbuildPropStringList prop =
        props |> Map.tryFind prop |> Option.map msbuildPropStringList
    let msbuildPropString prop =
        props |> Map.tryFind prop

    { ProjectSdkTypeDotnetSdk.IsTestProject = msbuildPropBool "IsTestProject" |> Option.getOrElse false
      Configuration = msbuildPropString "Configuration" |> Option.getOrElse ""
      IsPackable = msbuildPropBool "IsPackable" |> Option.getOrElse false
      TargetFramework = msbuildPropString MSBuildKnownProperties.TargetFramework |> Option.getOrElse ""
      TargetFrameworkIdentifier = msbuildPropString "TargetFrameworkIdentifier" |> Option.getOrElse ""
      TargetFrameworkVersion = msbuildPropString "TargetFrameworkVersion" |> Option.getOrElse ""
      TargetPath = targetPath

      MSBuildAllProjects = msbuildPropStringList "MSBuildAllProjects" |> Option.getOrElse []
      MSBuildToolsVersion = msbuildPropString "MSBuildToolsVersion" |> Option.getOrElse ""

      ProjectAssetsFile = msbuildPropString "ProjectAssetsFile" |> Option.getOrElse ""
      RestoreSuccess = msbuildPropBool "RestoreSuccess" |> Option.getOrElse false

      Configurations = msbuildPropStringList "Configurations" |> Option.getOrElse []
      TargetFrameworks = msbuildPropStringList "TargetFrameworks" |> Option.getOrElse []

      RunArguments = msbuildPropString "RunArguments"
      RunCommand = msbuildPropString "RunCommand"

      IsPublishable = msbuildPropBool "IsPublishable" }

let (|MsbuildOk|_|) x =
    match x with
#if NETSTANDARD2_0
    | Ok x -> Some x
    | Error _ -> None
#else
    | Choice1Of2 x -> Some x
    | Choice2Of2 _ -> None
#endif

let (|MsbuildError|_|) x =
    match x with
#if NETSTANDARD2_0
    | Ok _ -> None
    | Error x -> Some x
#else
    | Choice1Of2 _ -> None
    | Choice2Of2 x -> Some x
#endif

let runProcess (log: string -> unit) (workingDir: string) (exePath: string) (args: string) =
    let psi = System.Diagnostics.ProcessStartInfo()
    psi.FileName <- exePath
    psi.WorkingDirectory <- workingDir
    psi.RedirectStandardOutput <- true
    psi.RedirectStandardError <- true
    psi.Arguments <- args
    psi.CreateNoWindow <- true
    psi.UseShellExecute <- false

    use p = new System.Diagnostics.Process()
    p.StartInfo <- psi

    p.OutputDataReceived.Add(fun ea -> log (ea.Data))

    p.ErrorDataReceived.Add(fun ea -> log (ea.Data))

    // printfn "running: %s %s" psi.FileName psi.Arguments

    p.Start() |> ignore
    p.BeginOutputReadLine()
    p.BeginErrorReadLine()
    p.WaitForExit()

    let exitCode = p.ExitCode

    exitCode, (workingDir, exePath, args)


let private getProjectOptionsFromProjectFile (cache: ParsedProjectCache) parseAsSdk (file : string) =

    let rec projInfoOf additionalMSBuildProps (file: string) : ParsedProject =
        let projDir = Path.GetDirectoryName file

        //notifyState (WorkspaceProjectState.Loading file)

        match parseAsSdk with
        | ProjectParsingSdk.DotnetSdk ->
            let projectAssetsJsonPath = Path.Combine(projDir, "obj", "project.assets.json")
            if not(File.Exists(projectAssetsJsonPath)) then
                failwithf "project '%s' not restored" file
#if OLDFORMATS
        | ProjectParsingSdk.VerboseSdk ->
            ()
#endif

        let getFscArgs =
            match parseAsSdk with
            | ProjectParsingSdk.DotnetSdk ->
                Dotnet.ProjInfo.Inspect.getFscArgs
#if OLDFORMATS
            | ProjectParsingSdk.VerboseSdk ->
                let asFscArgs props =
                    let fsc = Microsoft.FSharp.Build.Fsc()
                    Dotnet.ProjInfo.FakeMsbuildTasks.getResponseFileFromTask props fsc
                let ok =
#if NETSTANDARD2_0
                    Ok
#else
                    Choice1Of2
#endif
                Dotnet.ProjInfo.Inspect.getFscArgsOldSdk (asFscArgs >> ok)
#endif

        let getP2PRefs = Dotnet.ProjInfo.Inspect.getResolvedP2PRefs
        let additionalInfo = //needed for extra
            [ "OutputType"
              "IsTestProject"
              "Configuration"
              "IsPackable"
              MSBuildKnownProperties.TargetFramework
              "TargetFrameworkIdentifier"
              "TargetFrameworkVersion"
              "MSBuildAllProjects"
              "ProjectAssetsFile"
              "RestoreSuccess"
              "Configurations"
              "TargetFrameworks"
              "RunArguments"
              "RunCommand"
              "IsPublishable"
            ]
        let gp () = Dotnet.ProjInfo.Inspect.getProperties (["TargetPath"; "IsCrossTargetingBuild"; "TargetFrameworks"] @ additionalInfo)

        let results, log =
            let loggedMessages = System.Collections.Concurrent.ConcurrentQueue<string>()

            let runCmd exePath args = runProcess loggedMessages.Enqueue projDir exePath (args |> String.concat " ")

            let msbuildExec =
                let msbuildPath =
                    match parseAsSdk with
                    | ProjectParsingSdk.DotnetSdk ->
                        Dotnet.ProjInfo.Inspect.MSBuildExePath.DotnetMsbuild "dotnet"
#if OLDFORMATS
                    | ProjectParsingSdk.VerboseSdk ->
                        Dotnet.ProjInfo.Inspect.MSBuildExePath.Path "msbuild"
#endif
                Dotnet.ProjInfo.Inspect.msbuild msbuildPath runCmd

            let additionalArgs = additionalMSBuildProps |> List.map (Dotnet.ProjInfo.Inspect.MSBuild.MSbuildCli.Property)

            let inspect =
                match parseAsSdk with
                | ProjectParsingSdk.DotnetSdk ->
                    Dotnet.ProjInfo.Inspect.getProjectInfos
#if OLDFORMATS
                | ProjectParsingSdk.VerboseSdk ->
                    Dotnet.ProjInfo.Inspect.getProjectInfosOldSdk
#endif

            let infoResult =
                file
                |> inspect loggedMessages.Enqueue msbuildExec [getFscArgs; getP2PRefs; gp] additionalArgs

            infoResult, (loggedMessages.ToArray() |> Array.toList)

        let todo =
            match results with
            | MsbuildOk [getFscArgsResult; getP2PRefsResult; gpResult] ->
                match getFscArgsResult, getP2PRefsResult, gpResult with
                | MsbuildError(MSBuildPrj.MSBuildSkippedTarget), MsbuildError(MSBuildPrj.MSBuildSkippedTarget), MsbuildOk (MSBuildPrj.GetResult.Properties props) ->
                    // Projects with multiple target frameworks, fails if the target framework is not choosen
                    let prop key = props |> Map.ofList |> Map.tryFind key

                    match prop "IsCrossTargetingBuild", prop "TargetFrameworks" with
                    | Some (MSBuildPrj.MSBuild.ConditionEquals "true"), Some (MSBuildPrj.MSBuild.StringList tfms) ->
                        CrossTargeting tfms
                    | _ ->
                        failwithf "error getting msbuild info: some targets skipped, found props: %A" props
                | MsbuildOk (MSBuildPrj.GetResult.FscArgs fa), MsbuildOk (MSBuildPrj.GetResult.ResolvedP2PRefs p2p), MsbuildOk (MSBuildPrj.GetResult.Properties p) ->
                    NoCrossTargeting { FscArgs = fa; P2PRefs = p2p; Properties = p |> Map.ofList }
                | r ->
                    failwithf "error getting msbuild info: %A" r
            | MsbuildOk r ->
                failwithf "error getting msbuild info: internal error, more info returned than expected %A" r
            | MsbuildError r ->
                match r with
                | Dotnet.ProjInfo.Inspect.GetProjectInfoErrors.MSBuildSkippedTarget ->
                    failwithf "Unexpected MSBuild result, all targets skipped"
                | Dotnet.ProjInfo.Inspect.GetProjectInfoErrors.UnexpectedMSBuildResult(r) ->
                    failwithf "Unexpected MSBuild result %s" r
                | Dotnet.ProjInfo.Inspect.GetProjectInfoErrors.MSBuildFailed(exitCode, (workDir, exePath, args)) ->
                    let logMsg = [ yield "Log: "; yield! log ] |> String.concat (Environment.NewLine)
                    let msbuildErrorMsg =
                        [ sprintf "MSBuild failed with exitCode %i" exitCode
                          sprintf "Working Directory: '%s'" workDir
                          sprintf "Exe Path: '%s'" exePath
                          sprintf "Args: '%s'" args ]
                        |> String.concat " "

                    failwithf "%s%s%s" msbuildErrorMsg (Environment.NewLine) logMsg
            | _ ->
                failwithf "error getting msbuild info: internal error"

        match todo with
        | CrossTargeting (tfm :: _) ->
            // Atm setting a preferenece is not supported in FSAC
            // As workaround, lets choose the first of the target frameworks and use that
            file |> projInfo [MSBuildKnownProperties.TargetFramework, tfm]
        | CrossTargeting [] ->
            failwithf "Unexpected, found cross targeting but empty target frameworks list"
        | NoCrossTargeting { FscArgs = rsp; P2PRefs = p2ps; Properties = props } ->

            //TODO cache projects info of p2p ref
            let p2pProjects =
                p2ps
                // do not follow others lang project, is not supported by FCS anyway
                |> List.filter (fun p2p -> p2p.ProjectReferenceFullPath.ToLower().EndsWith(".fsproj"))
                |> List.map (fun p2p ->
                    let followP2pArgs =
                        p2p.TargetFramework
                        |> Option.map (fun tfm -> MSBuildKnownProperties.TargetFramework, tfm)
                        |> Option.toList
                    p2p.ProjectReferenceFullPath |> projInfo followP2pArgs )

            let tar =
                match props |> Map.tryFind "TargetPath" with
                | Some t -> t
                | None -> failwith "error, 'TargetPath' property not found"

            let rspNormalized =
                //workaround, arguments in rsp can use relative paths
                rsp |> List.map (useFullPaths projDir)

            let sdkTypeData, log =
                match parseAsSdk with
                | ProjectParsingSdk.DotnetSdk ->
                    let extraInfo = getExtraInfo tar props
                    ProjectSdkType.DotnetSdk(extraInfo), []
#if OLDFORMATS
                | ProjectParsingSdk.VerboseSdk ->
                    //compatibility with old behaviour, so output is exactly the same
                    let mergedLog =
                        [ yield (file, "")
                          yield! p2pProjects |> List.collect (fun (_,_,x) -> x) ]
                    ProjectSdkType.Verbose { TargetPath = tar }, mergedLog
#endif

            let po =
                {
                    ProjectId = Some file
                    ProjectFileName = file
                    SourceFiles = [||]
                    OtherOptions = rspNormalized |> Array.ofList
                    ReferencedProjects = [| |] //p2pProjects |> List.map (fun (x,y,_) -> (x,y)) |> Array.ofList
                    IsIncompleteTypeCheckEnvironment = false
                    UseScriptResolutionRules = false
                    LoadTime = DateTime.Now
                    UnresolvedReferences = None
                    OriginalLoadReferences = []
                    Stamp = None
                    ExtraProjectInfo =
                        Some (box {
                            ExtraProjectInfoData.ProjectSdkType = sdkTypeData
                            ExtraProjectInfoData.ProjectOutputType = outType rspNormalized
                        })
                }

            tar, po, log

    and projInfo additionalMSBuildProps file : ParsedProject =
        let key = sprintf "%s;%A" file additionalMSBuildProps
        match cache.TryGetValue(key) with
        | true, alreadyParsed ->
            alreadyParsed
        | false, _ ->
            let p = file |> projInfoOf additionalMSBuildProps
            cache.AddOrUpdate(key, p, fun _ _ -> p)


    let _, po, log = projInfo [] file
    po, log

let private (|ProjectExtraInfoBySdk|_|) po =
      match po.ExtraProjectInfo with
      | None -> None
      | Some x ->
          match x with
          | :? ExtraProjectInfoData as extraInfo ->
              Some extraInfo
          | _ -> None

let private loadBySdk (cache: ParsedProjectCache) parseAsSdk file =
        let po, log = getProjectOptionsFromProjectFile cache parseAsSdk file

        let compileFiles =
            let sources = compileFiles (po.OtherOptions |> List.ofArray)
            match po with
            | ProjectExtraInfoBySdk extraInfo ->
                match extraInfo.ProjectSdkType with
#if OLDFORMATS
                | ProjectSdkType.Verbose _ ->
                    //compatibility with old behaviour (projectcracker), so test output is exactly the same
                    //the temp source files (like generated assemblyinfo.fs) are not added to sources
                    let isTempFile (name: string) =
                        let tempPath = Path.GetTempPath()
                        let s = name.ToLower()
                        s.StartsWith(tempPath.ToLower())
                    sources
                    |> List.filter (not << isTempFile)
                | ProjectSdkType.ProjectJson
#endif
                | ProjectSdkType.DotnetSdk _ ->
                    sources
            | _ -> sources

        Ok (po, Seq.toList compileFiles, (log |> Map.ofList))

let load (cache: ParsedProjectCache) file =
      loadBySdk cache ProjectParsingSdk.DotnetSdk file

#if OLDFORMATS
let loadVerboseSdk (cache: ParsedProjectCache) file =
      loadBySdk cache ProjectParsingSdk.VerboseSdk file
#endif
