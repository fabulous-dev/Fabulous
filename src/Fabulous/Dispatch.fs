namespace Fabulous

open Fabulous.ScalarAttributeDefinitions

module Dispatcher =
    let private getCanDispatchAndMapMsg (node: IViewNode) : struct (bool * (obj -> obj)) =
        let mutable canDispatch = true
        let mutable currentNode = Some node
        let mutable mapMsg = id

        while currentNode.IsSome && canDispatch do
            mapMsg <-
                match currentNode.Value.MapMsg with
                | None -> mapMsg
                | Some fn -> mapMsg >> fn

            // Disable dispatch if the node has been disconnected from the tree
            if currentNode.Value.IsDisconnected then
                canDispatch <- false

            currentNode <- currentNode.Value.Parent

        struct (canDispatch, mapMsg)

    /// Dispatch a msg for the current ViewNode
    let dispatch (node: IViewNode) msg =
        let struct (canDispatch, mapMsg) = getCanDispatchAndMapMsg node

        if canDispatch then
            node.TreeContext.Dispatch(mapMsg msg)

    /// Trigger an event for the node and all its descendants declaring the given event definition
    let dispatchEventForAllChildren (node: IViewNode) (rootWidget: Widget) (definition: SimpleScalarAttributeDefinition<obj>) =
        let rec dispatchAndVisitChildren skipMapMsg dispatch widget =
            // Check if the current widget has a MapMsg function and apply it before dispatch
            let dispatch =
                if skipMapMsg then
                    dispatch
                else
                    match AttributeHelpers.tryFindSimpleScalarAttribute MapMsg.MapMsg widget with
                    | ValueNone -> dispatch
                    | ValueSome fn -> fn >> dispatch

            match AttributeHelpers.tryFindSimpleScalarAttribute definition widget with
            | ValueNone -> ()
            | ValueSome msg -> dispatch msg

            match widget.WidgetAttributes with
            | [||] -> ()
            | widgetAttrs ->
                for childAttr in widgetAttrs do
                    dispatchAndVisitChildren false dispatch childAttr.Value

            match widget.WidgetCollectionAttributes with
            | [||] -> ()
            | widgetCollAttrs ->
                for widgetCollAttr in widgetCollAttrs do
                    for childWidget in ArraySlice.toSpan widgetCollAttr.Value do
                        dispatchAndVisitChildren false dispatch childWidget

        let struct (canDispatch, mapMsg) = getCanDispatchAndMapMsg node

        if canDispatch then
            dispatchAndVisitChildren true (mapMsg >> node.TreeContext.Dispatch) rootWidget
