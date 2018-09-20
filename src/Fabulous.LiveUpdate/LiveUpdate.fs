// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Core

open System
open System.Net
open System.Net.Sockets
open System.Net.NetworkInformation
open System.IO
open System.Text
open Fabulous.Core
open Fabulous.DynamicViews
open FSharp.Compiler.PortaCode.CodeModel
open FSharp.Compiler.PortaCode.Interpreter
open Xamarin.Forms

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
type BroadcastInfo = 
    { DeviceName: string
      Addresses : BroadcasterAddress[] 
      DeviceModel : string }

    static member Start(?httpPort) = 
        //let broadcastEndpoint = new IPEndPoint(IPAddress.Broadcast, Ports.BroadcasterReceiverPort)

        let httpPort = defaultArg httpPort Ports.DefaultPort
        do 
            async { 
               for i in 0 .. 3 do
                    try 
                        //let client = new UdpClient (Ports.BroadcasterPort, EnableBroadcast = true)
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
                        //let broadcast = 
                        //    {  DeviceName = "Device"
                        //       DeviceModel = "Model"
                        //       Addresses = iips }

                        if iips.Length > 0 then 
                            printfn "----------"
                            printfn "  LiveUpdate: Ready for connection. Will show this message %d more times." (3 - i)
                            printfn "  "

                            if Device.RuntimePlatform = Device.iOS then
                                printfn "  LiveUpdate: Connect using:"
                                for iip in iips do
                                    printfn "      fscd.exe --watch --webhook:http://%s:%d/update" iip.Address httpPort
                            elif Device.RuntimePlatform = Device.Android then
                                printfn "  LiveUpdate: On USB connect using:"
                                printfn "      adb -d forward  tcp:%d tcp:%d" httpPort httpPort
                                printfn "      fscd.exe --watch --webhook:http://localhost:%d/update" httpPort
                                printfn "  "
                                printfn "  LiveUpdate: On Emulator connect using:"
                                printfn "      adb -e forward  tcp:%d tcp:%d" httpPort httpPort
                                printfn "      fscd.exe --watch --webhook:http://localhost:%d/update" httpPort
                            else
                                printfn "  LiveUpdate: %s is not officially supported" Device.RuntimePlatform 
                                printfn "  LiveUpdate: You can still try to connect using:" 
                                printfn "      fscd.exe --watch --webhook:http://localhost:%d/update" httpPort

                            printfn "  "
                            printfn "  See https://fsprojects.github.io/Fabulous/tools.html for more details"
                            printfn "----------"
                        else 
                            printfn "LiveUpdate: Couldn't find a network interface to recommend."
                                
                        //let json = Newtonsoft.Json.JsonConvert.SerializeObject(broadcast)
                        //let bytes = System.Text.Encoding.UTF8.GetBytes (json)

                        //client.Send (bytes, bytes.Length, broadcastEndpoint)  |> ignore
                    with e -> 
                        printfn "LiveUpdate: error on broadcast: %A" e.Message
                    do! Async.Sleep 10000 } |> Async.Start


type HttpServer(?port) = 
    let port = defaultArg port Ports.DefaultPort
    do BroadcastInfo.Start()
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
                                    let req = Newtonsoft.Json.JsonConvert.DeserializeObject<DFile>(requestText)
                                    //let req = serializer.UnPickleOfString<DFile>(requestText)
                                    let resp = switchD req
                                    return Newtonsoft.Json.JsonConvert.SerializeObject resp
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
        <pre>    %USERPROFILE%\.nuget\packages\Fabulous.LiveUpdate\FABULOUS_VERSION\tools\fscd.exe --watch --webhook:http://localhost:PORT/update</pre>
        <pre>    mono ~/.nuget/packages/Fabulous.LiveUpdate/FABULOUS_VERSION/tools/fscd.exe --watch --webhook:http://localhost:PORT/update</pre>
        <p>in your project directory</p>
    </body>
</html>"""
                                        |> fun s -> s.Replace("FABULOUS_VERSION", ((System.Reflection.Assembly.GetExecutingAssembly()).GetName()).Version.ToString())
                                                     .Replace("PORT", string port)
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
                            printfn "*** LiveUpdate success:"
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
