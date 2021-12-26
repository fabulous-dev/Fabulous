namespace Fabulous

open System
open Fabulous

module Memo =

    type internal MemoData =
        {
            /// Captures type of data that memoization depends on
            KeyData: obj

            // comparer that remembers KeyType internally
            KeyComparer: obj -> obj -> bool

            /// Lambda that users provide
            CreateWidget: obj -> Widget

            /// Captures type of data that memoization depends on
            KeyType: Type

            /// Captures position of a function that produces a widget
            MarkerType: Type
        }

    type Memoized<'t> = { phantom: 't }

    let internal MemoAttributeKey = AttributeDefinitionStore.getNextKey()

    let inline private getMemoData (widget: Widget) : MemoData =
        (widget.ScalarAttributes
         |> Array.find(fun a -> a.Key = MemoAttributeKey))
            .Value
        :?> MemoData

    let internal canReuseMemoizedViewNode prev next =
        (getMemoData prev).MarkerType = (getMemoData next).MarkerType

    let internal compareAttributes (prev: MemoData, next: MemoData) : ScalarAttributeComparison =
        match (prev.KeyType = next.KeyType, prev.MarkerType = next.MarkerType) with
        | (true, true) ->
            match next.KeyComparer next.KeyData prev.KeyData with
            | true -> ScalarAttributeComparison.Identical
            | false -> ScalarAttributeComparison.Different null
        | _ -> ScalarAttributeComparison.Different null

    let private updateNode (data: MemoData voption, node: IViewNode) : unit =
        match data with
        | ValueSome memoData ->
            let memoizedWidget = memoData.CreateWidget memoData.KeyData

            // TODO how to get prev widget?!?

            Reconciler.update node.TreeContext.CanReuseView ValueNone memoizedWidget node

        | ValueNone -> ()

    let internal MemoAttribute =
        {
            Key = MemoAttributeKey
            Name = "MemoAttribute"
            Convert = id
            Compare = compareAttributes
            UpdateNode = updateNode
        }

    AttributeDefinitionStore.set MemoAttributeKey MemoAttribute


    let MemoWidgetKey = WidgetDefinitionStore.getNextKey()

    let private widgetDefinition: WidgetDefinition =
        {
            Key = MemoWidgetKey
            Name = "Memo"
            CreateView =
                fun (widget, context, parentNode) ->

                    let memoData = getMemoData widget

                    let memoizedWidget = memoData.CreateWidget memoData.KeyData

                    let memoizedDef =
                        WidgetDefinitionStore.get memoizedWidget.Key

                    memoizedDef.CreateView(memoizedWidget, context, parentNode)
        }

    WidgetDefinitionStore.set MemoWidgetKey widgetDefinition
