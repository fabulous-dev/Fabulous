﻿namespace Fabulous.Maui

open Fabulous

type IMauiApplication = Microsoft.Maui.IApplication

module Program =
    let inline private define
        (init: 'arg -> 'model * Cmd<'msg>)
        (update: 'msg -> 'model -> 'model * Cmd<'msg>)
        (view: 'model -> WidgetBuilder<'msg, 'marker>)
        =
        { Init = init
          Update = (fun (msg, model) -> update msg model)
          View = fun model -> (view model).Compile()
          CanReuseView = ViewHelpers.canReuseView
          SyncAction = fun fn -> fn () }

    let statelessApplication (view: unit -> WidgetBuilder<unit, #IApplication>) =
        define(fun () -> (), Cmd.none) (fun () () -> (), Cmd.none) view

    let statefulApplication
        (init: 'arg -> 'model)
        (update: 'msg -> 'model -> 'model)
        (view: 'model -> WidgetBuilder<'msg, #IApplication>)
        =
        define(fun arg -> init arg, Cmd.none) (fun msg model -> update msg model, Cmd.none) view

    let statefulApplicationWithCmd
        (init: 'arg -> 'model * Cmd<'msg>)
        (update: 'msg -> 'model -> 'model * Cmd<'msg>)
        (view: 'model -> WidgetBuilder<'msg, #IApplication>)
        =
        define init update view

    let statefulApplicationWithCmdMsg
        (init: 'arg -> 'model * 'cmdMsg list)
        (update: 'msg -> 'model -> 'model * 'cmdMsg list)
        (view: 'model -> WidgetBuilder<'msg, #IApplication>)
        (mapCmd: 'cmdMsg -> Cmd<'msg>)
        =
        let mapCmds cmdMsgs = cmdMsgs |> List.map mapCmd |> Cmd.batch

        define
            (fun arg -> let m, c = init arg in m, mapCmds c)
            (fun msg model -> let m, c = update msg model in m, mapCmds c)
            view

    let createApplication (program: Program<'arg, 'model, 'msg>) (arg: 'arg) : Microsoft.Maui.IApplication =
        let runner = Runners.create program
        runner.Start(arg)
        let adapter = ViewAdapters.create ViewNode.get runner
        adapter.CreateView() |> unbox
