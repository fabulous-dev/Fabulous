namespace Fabulous.Maui

open System.Diagnostics
open Fabulous
open Fabulous.Maui
open Microsoft.Maui

module ViewHelpers =
    let canReuseView (prev: Widget) (curr: Widget) =
        ViewHelpers.canReuseView prev curr
    
    let defaultLogger () =
        let log (level, message) =
            let traceLevel =
                match level with
                | LogLevel.Debug -> "Debug"
                | LogLevel.Info -> "Information"
                | LogLevel.Warn -> "Warning"
                | LogLevel.Error -> "Error"
                | _ -> "Error"

            Trace.WriteLine(message, traceLevel)

        { Log = log
          MinLogLevel = LogLevel.Error }

module Program =
    let inline private define
        (init: 'arg -> 'model * Cmd<'msg>)
        (update: 'msg -> 'model -> 'model * Cmd<'msg>)
        (view: 'model -> WidgetBuilder<'msg, 'marker>)
        =
        { Init = init
          Update = (fun (msg, model) -> update msg model)
          Subscribe = fun _ -> Cmd.none
          View = view
          CanReuseView = ViewHelpers.canReuseView
          SyncAction = fun fn -> fn ()
          Logger = ViewHelpers.defaultLogger() }

    let stateless (view: unit -> WidgetBuilder<unit, 'marker>) =
        define(fun () -> (), Cmd.none) (fun () () -> (), Cmd.none) view

    let stateful
        (init: 'arg -> 'model)
        (update: 'msg -> 'model -> 'model)
        (view: 'model -> WidgetBuilder<'msg, 'marker>)
        =
        define(fun arg -> init arg, Cmd.none) (fun msg model -> update msg model, Cmd.none) view

    let statefulWithCmd
        (init: 'arg -> 'model * Cmd<'msg>)
        (update: 'msg -> 'model -> 'model * Cmd<'msg>)
        (view: 'model -> WidgetBuilder<'msg, 'marker>)
        =
        define init update view

    let statefulWithCmdMsg
        (init: 'arg -> 'model * 'cmdMsg list)
        (update: 'msg -> 'model -> 'model * 'cmdMsg list)
        (view: 'model -> WidgetBuilder<'msg, 'marker>)
        (mapCmd: 'cmdMsg -> Cmd<'msg>)
        =
        let mapCmds cmdMsgs = cmdMsgs |> List.map mapCmd |> Cmd.batch

        define
            (fun arg -> let m, c = init arg in m, mapCmds c)
            (fun msg model -> let m, c = update msg model in m, mapCmds c)
            view

    let startApplicationWithArgs (arg: 'arg) (program: Program<'arg, 'model, 'msg, #IApplication>) : IApplication =
        let runner = Runners.create program
        runner.Start(arg)
        let adapter = ViewAdapters.create ViewNode.get runner
        adapter.CreateView() |> unbox

    let startApplication (program: Program<unit, 'model, 'msg, 'marker>) : IApplication =
        startApplicationWithArgs () program