// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace Elmish.XamarinForms

open System
open System.Net
open System.Net.Sockets
open System.Net.NetworkInformation
open System.IO
open System.Text
open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open FSharp.Compiler.PortaCode.CodeModel
open FSharp.Compiler.PortaCode.Interpreter

module Ports = 
    let DefaultPort = 9867
    let BroadcasterPort = 8098
    let BroadcasterReceiverPort = 8099


[<CLIMutable>]
type UpdateResponse = 
    { Quacked: string }

[<CLIMutable>]
type BroadcasterAddress = 
    { Address: string
      Port: int
      Interface : string }

[<CLIMutable>]
type Broadcaster = 
    { DeviceName: string
      Addresses : BroadcasterAddress[] 
      DeviceModel : string }

    static member Start(?httpPort) = 
        let broadcastEndpoint = new IPEndPoint(IPAddress.Broadcast, Ports.BroadcasterReceiverPort)

        let httpPort = defaultArg httpPort Ports.DefaultPort
        let serializer = MBrace.FsPickler.Json.FsPickler.CreateJsonSerializer()
        do 
            async { 
                while true do
                    let client = new UdpClient (Ports.BroadcasterPort, EnableBroadcast = true)
                    let iips = 
                        [| for x in NetworkInterface.GetAllNetworkInterfaces () do 
                             if x.NetworkInterfaceType <> NetworkInterfaceType.Loopback &&
                                not (x.Name.StartsWith ("pdp_ip", StringComparison.Ordinal)) &&
                                x.OperationalStatus = OperationalStatus.Up then
                                 for y in x.GetIPProperties().UnicastAddresses do
                                    if y.Address.AddressFamily = AddressFamily.InterNetwork then 
                                         yield { Address = y.Address.ToString ()
                                                 Port = httpPort
                                                 Interface = x.Name } |]
                    let broadcast = 
                        {  DeviceName = "Device"
                           DeviceModel = "Model"
                           Addresses = iips }

                    for iip in iips do
                         printfn "LiveUpdate: broadcasting address %s. Access via http://localhost:%d/ if you have run 'adb -d forward  tcp:%d tcp:%d'" iip.Address httpPort httpPort httpPort 

                    let json = serializer.PickleToString (broadcast)
                    let bytes = System.Text.Encoding.UTF8.GetBytes (json)

                    try 
                        client.Send (bytes, bytes.Length, broadcastEndpoint)  |> ignore
                    with e -> 
                        printfn "LiveUpdate: error on broadcast: %A" e.Message
                    do! Async.Sleep 5000 } |> Async.Start


type HttpServer(?port) = 
    let port = defaultArg port Ports.DefaultPort
    do Broadcaster.Start()
    member x.Run (switchD) =

        let _syncCtxt = System.Threading.SynchronizationContext.Current
        async { 
            // Run this on the host machine
            (*
               adb -d forward --list
             USB: 
               adb -d forward  tcp:9867 tcp:9867 
             EMULATOR: 
              adb -e forward  tcp:9867 tcp:9867 
              *)
            // netsh http add urlacl url=http://*:9867/ user=System.Environment.UserDomainName
            let url = sprintf "http://*:%d/" port
            let serializer = MBrace.FsPickler.Json.FsPickler.CreateJsonSerializer()

            let listener = new HttpListener ()
            listener.Prefixes.Add (url)
            try 
                listener.Start ()

                while true do
                    printfn "LiveUpdate: listening on url = %s" url
                    let! c = listener.GetContextAsync () |> Async.AwaitTask
                    let path = c.Request.Url.AbsolutePath
                    printfn "LiveUpdate: got request, path = = %s" url
                    use resp = c.Response
                    try 

                        let! (resString : string) = 
                            async {
                                //if (path = "/switch") then
                                //    //let req = serializer.UnPickleOfString<UpdatePackage>(requestText)
                                //    let resp = switch ()
                                //    return serializer.PickleToString resp
                                if (path = "/update") then
                                    let reader = new StreamReader (c.Request.InputStream, Encoding.UTF8)
                                    let! requestText = reader.ReadToEndAsync () |> Async.AwaitTask
                                    let req = serializer.UnPickleOfString<DFile>(requestText)
                                    let resp = switchD req
                                    return serializer.PickleToString resp
                                else 
                                    return """
<html>
    <body>
        <p>Welcome to LiveUpdate web api. The valid API is:</p>
        <p>  - PUT '<a href="/update">/update</a>'</p>
        <br />
        <p>To set up watcher for Android use:</p>
        <pre>    adb -d forward  tcp:PORT tcp:PORT  (USB)</pre>
        <pre>    adb -e forward  tcp:PORT tcp:PORT  (Emulator)</pre>
        <p>  then</p>
        <pre>    cd MyApp\MyApp</pre>
        <pre>    %USERPROFILE%\.nuget\packages\Elmish.XamarinForms.LiveUpdate\0.13.4\tools\fscd.exe --watch --webhook:http://localhost:PORT/update</pre>
        <pre>    mono ~/.nuget/packages/Elmish.XamarinForms.LiveUpdate/0.13.4/tools/fscd.exe --watch --webhook:http://localhost:PORT/update</pre>
        <p>in your project directoty</p>
    </body>
</html>"""
                                        |> fun s -> s.Replace("PORT", string port)
                            }

                        printfn "LiveUpdate: setting response code to 200, response = %s" resString
                        let bytes = Encoding.UTF8.GetBytes (resString)
                        resp.StatusCode <- 200
                        resp.ContentLength64 <- bytes.LongLength
                        do! c.Response.OutputStream.WriteAsync (bytes, 0, bytes.Length) |> Async.AwaitTask

                    with ex -> 
                        let msg = "<html><body><pre>" + ex.ToString() + "</pre></body></html>"
                        printfn "LiveUpdate: setting response code to 500, msg = %s" msg
                        let bytes = Encoding.UTF8.GetBytes msg
                        resp.StatusCode <- 500
                        resp.ContentLength64 <- bytes.LongLength
                        do! c.Response.OutputStream.WriteAsync (bytes, 0, bytes.Length) |> Async.AwaitTask
            with :? HttpListenerException as ex -> 
                printfn "couldn't start listener %s" (ex.ToString())
        } |> Async.Start


/// Program module - functions to manipulate program instances
[<AutoOpen>]
module Extensions =


    let rec tryFindEntityByName name (decls: DDecl[]) = 
        decls |> Array.tryPick (function 
            | DDeclEntity (entityDef, subDecls) -> if entityDef.Name = name then Some (entityDef, subDecls) else tryFindEntityByName name subDecls 
            | _ -> None)

    let rec tryFindMemberByName name (decls: DDecl[]) = 
        decls |> Array.tryPick (function 
            | DDeclEntity (_, ds) -> tryFindMemberByName name ds 
            | DDeclMember (membDef, body) -> if membDef.Name = name then Some (membDef, body) else None
            | _ -> None)

    /// Trace all the updates to the console
    type ProgramRunner<'model,'msg> with

        member runner.EnableLiveUpdate() = 

            let interp = EvalContext()

            let switchD (arg: DFile) =
              lock interp (fun () -> 
                printfn "LiveUpdate: adding declarations...."
                interp.AddDecls arg.Code

                printfn "LiveUpdate: evaluating decls in code package for side effects...."
                interp.EvalDecls (envEmpty, arg.Code)

                let programOptD = 
                    match tryFindMemberByName "programLiveUpdate" arg.Code with
                    | Some d -> Some d
                    | None -> 
                    match tryFindMemberByName "program" arg.Code with
                    | None -> None
                    | Some d -> Some d

                match programOptD with 
                | None -> 
                    printfn "*** LiveUpdate failure:"
                    printfn "***   [x] got code pacakge"
                    printfn "***   FAIL: couldn't find declaration called 'program' or 'programLiveUpdate'"
                    { Quacked = "couldn't quack! No declaration called 'program' or 'programLiveUpdate'!" }

                | Some (membDef, _) -> 
                    if membDef.Parameters.Length > 0 then 
                        printfn "*** LiveUpdate failure:"
                        printfn "***   [x] got code pacakge"
                        printfn "***   [x] found declaration called 'programLiveUpdate' or 'program'"
                        printfn "***   FAIL: the declaration has parameters, it must be a single top-level value"
                        { Quacked = "couldn't quack! Found declaration called 'program' or 'programLiveUpdate' but the declaration has parameters!" }

                    else 

                        printfn "LiveUpdate: evaluating 'program'...."
                        let entity = interp.ResolveEntity(membDef.EnclosingEntity)
                        let programObj = interp.GetExprDeclResult(entity, membDef.Name) 
                        match getVal programObj with 
                    
                        | :? Program<obj, obj, obj -> (obj -> unit) -> ViewElement> as programErased -> 

                            // Stop the running program 
                            printfn "changing running program...."
                            runner.ChangeProgram(programErased)
                            printfn "*** LiveUpdate failure:"
                            printfn "***   [x] got code pacakge"
                            printfn "***   [x] found declaration called 'programLiveUpdate' or 'program'"
                            printfn "***   [x] it had no parameters (good!)"
                            printfn "***   [x] the declaration had the right type"
                            printfn "***   [x] changed the running program"
                            { Quacked = "LiveUpdate quacked!" }
                        
                        | p -> 
                            printfn "*** LiveUpdate failure:"
                            printfn "***   [x] got code pacakge"
                            printfn "***   [x] found declaration called 'programLiveUpdate' or 'program'"
                            printfn "***   [x] it had no parameters (good!)"
                            printfn "***   FAIL: the declaration had the wrong type '%A', expected 'Program<Model, Msg, Model -> (Msg-> unit) -> ViewElement>'" (p.GetType())
                            { Quacked = "LiveUpdate couldn't quack! types mismatch!" }
              )

            let server = HttpServer()
            server.Run(switchD)
