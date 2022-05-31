namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions
open Xamarin.Forms
open System.Diagnostics

module ViewHelpers =
    let private tryGetScalarValue (widget: Widget) (def: SimpleScalarAttributeDefinition<'data>) =
        match widget.ScalarAttributes with
        | ValueNone -> ValueNone
        | ValueSome scalarAttrs ->
            match Array.tryFind(fun (attr: ScalarAttribute) -> attr.Key = def.Key) scalarAttrs with
            | None -> ValueNone
            | Some attr -> ValueSome(unbox<'data> attr.Value)

    let private tryGetWidgetCollectionValue (widget: Widget) (def: WidgetCollectionAttributeDefinition) =
        match widget.WidgetCollectionAttributes with
        | ValueNone -> ValueNone
        | ValueSome collectionAttrs ->
            match Array.tryFind(fun (attr: WidgetCollectionAttribute) -> attr.Key = def.Key) collectionAttrs with
            | None -> ValueNone
            | Some attr -> ValueSome attr.Value

    /// Extend the canReuseView function to check Xamarin.Forms specific constraints
    let rec canReuseView (prev: Widget) (curr: Widget) =
        if ViewHelpers.canReuseView prev curr
           && canReuseAutomationId prev curr then
            let def = WidgetDefinitionStore.get curr.Key

            // TargetType can be null for MemoWidget
            // but it has already been checked by Fabulous.ViewHelpers.canReuseView
            if def.TargetType <> null then
                if def.TargetType.IsAssignableFrom(typeof<NavigationPage>) then
                    canReuseNavigationPage prev curr
                else
                    true
            else
                true
        else
            false

    /// Check whether widgets have compatible automation ids.
    /// Xamarin.Forms only allows setting the automation id once so we can't reuse a control if the id is not the same.
    and private canReuseAutomationId (prev: Widget) (curr: Widget) =
        let prevIdOpt =
            tryGetScalarValue prev Element.AutomationId

        let currIdOpt =
            tryGetScalarValue curr Element.AutomationId

        match prevIdOpt with
        | ValueSome _ when prevIdOpt <> currIdOpt -> false
        | _ -> true

    /// Checks whether an underlying NavigationPage control can be reused given the previous and new view elements
    //
    // NavigationPage can be reused only if the pages don't change their type (added/removed pages don't prevent reuse)
    // E.g. If the first page switch from ContentPage to TabbedPage, the NavigationPage can't be reused.
    and private canReuseNavigationPage (prev: Widget) (curr: Widget) =
        let prevPages =
            tryGetWidgetCollectionValue prev NavigationPage.Pages

        let currPages =
            tryGetWidgetCollectionValue curr NavigationPage.Pages

        match struct (prevPages, currPages) with
        | ValueSome prevPages, ValueSome currPages ->
            let struct (prevLength, prevPages) = prevPages
            let struct (currLength, currPages) = currPages

            if prevLength = currLength then
                Array.forall2 canReuseView prevPages currPages
            else
                true

        | _ -> true

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
          SyncAction = Device.BeginInvokeOnMainThread
          Logger = ViewHelpers.defaultLogger() }

    /// Create a program for a static view
    let stateless (view: unit -> WidgetBuilder<unit, 'marker>) =
        define(fun () -> (), Cmd.none) (fun () () -> (), Cmd.none) view

    /// Create a program using an MVU loop
    let stateful
        (init: 'arg -> 'model)
        (update: 'msg -> 'model -> 'model)
        (view: 'model -> WidgetBuilder<'msg, 'marker>)
        =
        define(fun arg -> init arg, Cmd.none) (fun msg model -> update msg model, Cmd.none) view

    /// Create a program using an MVU loop. Add support for Cmd
    let statefulWithCmd
        (init: 'arg -> 'model * Cmd<'msg>)
        (update: 'msg -> 'model -> 'model * Cmd<'msg>)
        (view: 'model -> WidgetBuilder<'msg, #IApplication>)
        =
        define init update view

    /// Create a program using an MVU loop. Add support for CmdMsg
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

    /// Start the program
    let startApplicationWithArgs (arg: 'arg) (program: Program<'arg, 'model, 'msg, #IApplication>) : Application =
        let runner = Runners.create program
        runner.Start(arg)
        let adapter = ViewAdapters.create ViewNode.get runner
        adapter.CreateView() |> unbox

    /// Start the program
    let startApplication (program: Program<unit, 'model, 'msg, 'marker>) : Application =
        startApplicationWithArgs() program

    /// Subscribe to external source of events.
    /// The subscription is called once - with the initial model, but can dispatch new messages at any time.
    let withSubscription (subscribe: 'model -> Cmd<'msg>) (program: Program<'arg, 'model, 'msg, 'marker>) =
        let sub model =
            Cmd.batch [ program.Subscribe model
                        subscribe model ]

        { program with Subscribe = sub }

    /// Configure how the output messages from Fabulous will be handled
    let withLogger (logger: Logger) (program: Program<'arg, 'model, 'msg, 'marker>) = { program with Logger = logger }

    /// Trace all the updates to the debug output
    let withTrace (trace: string * string -> unit) (program: Program<'arg, 'model, 'msg, 'marker>) =
        let traceInit arg =
            try
                let initModel, cmd = program.Init(arg)
                trace("Initial model: {0}", $"%0A{initModel}")
                initModel, cmd
            with
            | e ->
                trace("Error in init function: {0}", $"%0A{e}")
                reraise()

        let traceUpdate (msg, model) =
            trace("Message: {0}", $"%0A{msg}")

            try
                let newModel, cmd = program.Update(msg, model)
                trace("Updated model: {0}", $"%0A{newModel}")
                newModel, cmd
            with
            | e ->
                trace("Error in model function: {0}", $"%0A{e}")
                reraise()

        let traceView model =
            trace("View, model = {0}", $"%0A{model}")

            try
                let info = program.View(model)
                trace("View result: {0}", $"%0A{info}")
                info
            with
            | e ->
                trace("Error in view function: {0}", $"%0A{e}")
                reraise()

        { program with
              Init = traceInit
              Update = traceUpdate
              View = traceView }

[<RequireQualifiedAccess>]
module CmdMsg =
    let batch mapCmdMsgFn mapCmdFn cmdMsgs =
        cmdMsgs
        |> List.map(mapCmdMsgFn >> Cmd.map mapCmdFn)
        |> Cmd.batch
