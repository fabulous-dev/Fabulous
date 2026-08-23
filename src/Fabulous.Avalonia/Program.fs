namespace Fabulous.Avalonia

open System
open System.Diagnostics
open Avalonia.Controls
open Avalonia.Threading

open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions

module ViewHelpers =
    let private simpleScalarAttributeExists (widget: Widget) (def: SimpleScalarAttributeDefinition<'data>) =
        widget.ScalarAttributes |> Array.exists(fun attr -> attr.Key = def.Key)

    let private widgetCollectionAttributeExists (widget: Widget) (def: WidgetCollectionAttributeDefinition) =
        widget.WidgetCollectionAttributes
        |> Array.exists(fun attr -> attr.Key = def.Key)

    /// Extend the canReuseView function to check AvaloniaUI specific constraints
    let rec canReuseView (prev: Widget) (curr: Widget) =
        if ViewHelpers.canReuseView prev curr && canReuseAutomationId prev curr then
            let def = WidgetDefinitionStore.get curr.Key

            // TargetType can be null for MemoWidget,
            // but it has already been checked by Fabulous.ViewHelpers.canReuseView
            if isNull def.TargetType then
                true
            else if def.TargetType.IsAssignableTo(typeof<TextBlock>) then
                canReuseTextBlock prev curr
            else
                true
        else
            false

    /// Check whether widgets have compatible automation ids.
    /// Avalonia only allows setting the automation id once so we can't reuse a control if the id is not the same.
    and private canReuseAutomationId (prev: Widget) (curr: Widget) =
        match AttributeHelpers.tryFindSimpleScalarAttribute AutomationProperties.AutomationId prev with
        | ValueSome _ as prev -> prev = AttributeHelpers.tryFindSimpleScalarAttribute AutomationProperties.AutomationId curr
        | _ -> true

    /// TextBlock's text can be defined by both the Text and Inlines property
    /// Except when switching between the two, Avalonia will automatically clear out the other property
    /// Depending on the order of execution, this can lead to a de-sync between Avalonia and Fabulous
    /// So, it's better to not reuse a TextBlock when we are about to switch between Text and Inlines
    and canReuseTextBlock (prev: Widget) (curr: Widget) =
        let switchingFromTextToInlines =
            simpleScalarAttributeExists prev TextBlock.Text
            && widgetCollectionAttributeExists curr TextBlock.Inlines

        let switchingFromInlinesToText =
            widgetCollectionAttributeExists prev TextBlock.Inlines
            && simpleScalarAttributeExists curr TextBlock.Text

        not switchingFromTextToInlines && not switchingFromInlinesToText

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

    let defaultSyncAction (action: unit -> unit) = Dispatcher.UIThread.Post action

    let defaultExceptionHandler exn =
        Trace.WriteLine(String.Format("Unhandled exception: {0}", exn.ToString()), "Debug")
        false

module Program =
    let withView (view: 'model -> WidgetBuilder<'msg, 'marker>) (state: Program<'arg, 'model, 'msg>) : Program<'arg, 'model, 'msg, 'marker> =
        { State = state
          View = view
          CanReuseView = ViewHelpers.canReuseView
          SyncAction = ViewHelpers.defaultSyncAction }

    let stateless (view: unit -> WidgetBuilder<unit, 'marker>) : Program<unit, unit, unit, 'marker> =
        Program.stateful (fun _ -> ()) (fun _ _ -> ()) |> withView view

    /// Trace all the view updates to the debug output
    let withViewTrace (trace: string * string -> unit) (program: Program<'arg, 'model, 'msg, 'marker>) =
        let traceView model =
            trace("View, model = {0}", $"%0A{model}")

            try
                let info = program.View(model)
                trace("View result: {0}", $"%0A{info}")
                info
            with e ->
                trace("Error in view function: {0}", $"%0A{e}")
                reraise()

        { program with View = traceView }

[<RequireQualifiedAccess>]
module CmdMsg =
    let batch mapCmdMsgFn mapCmdFn cmdMsgs =
        cmdMsgs |> List.map(mapCmdMsgFn >> Cmd.map mapCmdFn) |> Cmd.batch
