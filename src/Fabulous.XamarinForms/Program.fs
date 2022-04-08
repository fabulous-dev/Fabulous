namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

module ViewHelpers =
    let private tryGetScalarValue (widget: Widget) (def: ScalarAttributeDefinition<_, 'modelType, _>) =
        match widget.ScalarAttributes with
        | ValueNone -> ValueNone
        | ValueSome scalarAttrs ->
            match Array.tryFind(fun (attr: ScalarAttribute) -> attr.Key = def.Key) scalarAttrs with
            | None -> ValueNone
            | Some attr -> ValueSome(unbox<'modelType> attr.Value)

    /// Check whether widgets have compatible automation ids.
    /// Xamarin.Forms only allows setting the automation id once so we can't reuse a control if the id is not the same.
    let private canReuseAutomationId (prev: Widget) (curr: Widget) =
        let prevIdOpt =
            tryGetScalarValue prev Element.AutomationId

        let currIdOpt =
            tryGetScalarValue curr Element.AutomationId

        match struct (prevIdOpt, currIdOpt) with
        | ValueNone, ValueNone -> true // Ids not set. Can reuse.
        | ValueNone, ValueSome _ -> true // Id was not set before. Can reuse.
        | ValueSome _, ValueNone -> false // Id was set before but not anymore. Can't reuse.
        | ValueSome prevId, ValueSome currId -> prevId = currId // Can only reuse if the ids are the same.

    /// Extend the canReuseView function to check Xamarin.Forms specific constraints
    let canReuseView (prev: Widget) (curr: Widget) =
        if ViewHelpers.canReuseView prev curr then
            canReuseAutomationId prev curr
        else
            true

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
          SyncAction = Device.BeginInvokeOnMainThread }

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

    let createApplication (program: Program<'arg, 'model, 'msg>) (arg: 'arg) : Application =
        let runner = Runners.create program
        runner.Start(arg)
        let adapter = ViewAdapters.create ViewNode.get runner
        adapter.CreateView() |> unbox
