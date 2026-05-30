namespace Fabulous.Maui

open Fabulous
open Fabulous.ScalarAttributeDefinitions
open Fabulous.WidgetCollectionAttributeDefinitions
open Microsoft.Maui.ApplicationModel
open Microsoft.Maui.Controls

module MauiViewHelpers =
    let private tryGetScalarValue (widget: Widget) (def: SimpleScalarAttributeDefinition<'data>) =
        match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = def.Key) widget.ScalarAttributes with
        | None -> ValueNone
        | Some attr -> ValueSome(unbox<'data> attr.Value)

    let private tryGetWidgetCollectionValue (widget: Widget) (def: WidgetCollectionAttributeDefinition) =
        match Array.tryFind (fun (attr: WidgetCollectionAttribute) -> attr.Key = def.Key) widget.WidgetCollectionAttributes with
        | None -> ValueNone
        | Some attr -> ValueSome attr.Value

    let defaultSyncAction (action: unit -> unit) =
        MainThread.BeginInvokeOnMainThread(action)

    /// Extend the canReuseView function to check Microsoft.Maui specific constraints
    let rec canReuseView (prev: Widget) (curr: Widget) =
        if ViewHelpers.canReuseView prev curr && canReuseAutomationId prev curr then
            let def = WidgetDefinitionStore.get curr.Key

            // TargetType can be null for MemoWidget
            // but it has already been checked by Fabulous.ViewHelpers.canReuseView
            if def.TargetType <> null then
                if def.TargetType.IsAssignableTo(typeof<NavigationPage>) then
                    canReuseNavigationPage prev curr
                else
                    true
            else
                true
        else
            false

    /// Check whether widgets have compatible automation ids.
    /// Microsoft.Maui only allows setting the automation id once so we can't reuse a control if the id is not the same.
    and private canReuseAutomationId (prev: Widget) (curr: Widget) =
        let prevIdOpt = tryGetScalarValue prev Element.AutomationId

        let currIdOpt = tryGetScalarValue curr Element.AutomationId

        match prevIdOpt with
        | ValueSome _ when prevIdOpt <> currIdOpt -> false
        | _ -> true

    /// Checks whether an underlying NavigationPage control can be reused given the previous and new view elements
    //
    // NavigationPage can be reused only if the pages don't change their type (added/removed pages don't prevent reuse)
    // E.g. If the first page switch from ContentPage to TabbedPage, the NavigationPage can't be reused.
    and private canReuseNavigationPage (prev: Widget) (curr: Widget) =
        let prevPages = tryGetWidgetCollectionValue prev NavigationPage.Pages

        let currPages = tryGetWidgetCollectionValue curr NavigationPage.Pages

        match struct (prevPages, currPages) with
        | ValueSome prevPages, ValueSome currPages ->
            let struct (prevLength, prevPages) = prevPages
            let struct (currLength, currPages) = currPages

            if prevLength = currLength then
                Array.forall2 (fun (a: Widget) (b: Widget) -> a.Key = b.Key) prevPages currPages
            else
                true

        | _ -> true

module Program =
    let withView (view: 'model -> WidgetBuilder<'msg, 'marker>) (state: Program<'arg, 'model, 'msg>) : Program<'arg, 'model, 'msg, 'marker> =
        { State = state
          View = view
          CanReuseView = MauiViewHelpers.canReuseView
          SyncAction = MauiViewHelpers.defaultSyncAction }

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
