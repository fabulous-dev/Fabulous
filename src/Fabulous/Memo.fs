namespace Fabulous

open Fabulous

module Memo =

    type internal MemoData =
        {
            /// Captures data that memoization depends on
            KeyData: obj

            // comparer that remembers KeyType internally
            KeyComparer: obj -> obj -> bool

            /// wrapped untyped lambda that users provide
            CreateWidget: obj -> Widget

            /// Captures type hash of data that memoization depends on
            KeyTypeHash: int

            /// Captures type hash of the marker memoized function produces
            MarkerTypeHash: int
        }

    type Memoized<'t> = { phantom: 't }

    let private MemoAttributeKey = AttributeDefinitionStore.getNextKey()
    let internal MemoWidgetKey = WidgetDefinitionStore.getNextKey()

    let inline private getMemoData (widget: Widget) : MemoData =
        (Array.find(fun (a: ScalarAttribute) -> a.Key = MemoAttributeKey) (ValueOption.get widget.ScalarAttributes))
            .Value
        :?> MemoData

    let internal canReuseMemoizedViewNode prev next =
        (getMemoData prev).MarkerTypeHash = (getMemoData next).MarkerTypeHash

    let private compareAttributes (prev: MemoData, next: MemoData) : ScalarAttributeComparison =
        match (prev.KeyTypeHash = next.KeyTypeHash, prev.MarkerTypeHash = next.MarkerTypeHash) with
        | (true, true) ->
            match next.KeyComparer next.KeyData prev.KeyData with
            | true -> ScalarAttributeComparison.Identical
            | false -> ScalarAttributeComparison.Different null
        | _ -> ScalarAttributeComparison.Different null

    let private updateNode (data: MemoData voption, node: IViewNode) : unit =
        match data with
        | ValueSome memoData ->
            let memoizedWidget = memoData.CreateWidget memoData.KeyData
            let propBag = node.PropertyBag

            let prevWidget =
                match propBag.TryGetValue MemoWidgetKey with
                | true, value -> ValueSome(unbox<Widget> value)
                | _ -> ValueNone

            propBag.[MemoWidgetKey] <- memoizedWidget

            Reconciler.update node.TreeContext.CanReuseView prevWidget memoizedWidget node

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

                    let struct (node, view) =
                        memoizedDef.CreateView(memoizedWidget, context, parentNode)

                    // store widget that was used to produce this node
                    // to pass it to reconciler later on
                    node.PropertyBag.Add(MemoWidgetKey, memoizedWidget)
                    struct (node, view)
        }

    WidgetDefinitionStore.set MemoWidgetKey widgetDefinition
