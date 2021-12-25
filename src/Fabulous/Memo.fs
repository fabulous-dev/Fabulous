namespace Fabulous

open System

module Memo =

    type internal MemoData =
        {
            Data: obj
            Comparer: obj -> obj -> bool
            CreateWidget: obj -> Widget
            KeyType: Type
        }

    type Memoized<'t> = { phantom: 't }

    let internal MemoAttributeKey = AttributeDefinitionStore.getNextKey()

    let internal compareAttributes (prev: MemoData, next: MemoData) : ScalarAttributeComparison =
        ScalarAttributeComparison.Identical

    let internal MemoAttribute =
        {
            Key = MemoAttributeKey
            Name = "MemoAttribute"
            Convert = id
            Compare = compareAttributes
            UpdateNode = failwith "should never happen?"
        }

    AttributeDefinitionStore.set MemoAttributeKey MemoAttribute


    let MemoWidgetKey = WidgetDefinitionStore.getNextKey()

    let private widgetDefinition: WidgetDefinition =
        {
            Key = MemoWidgetKey
            Name = "Memo"
            CreateView =
                fun (widget, context, parentNode) ->
                    let memoData =
                        (widget.ScalarAttributes
                         |> Array.find(fun a -> a.Key = MemoAttributeKey))
                            .Value
                        :?> MemoData

                    let memoizedWidget = memoData.CreateWidget memoData.Data

                    let memoizedDef =
                        WidgetDefinitionStore.get memoizedWidget.Key

                    memoizedDef.CreateView(memoizedWidget, context, parentNode)
        }

    WidgetDefinitionStore.set MemoWidgetKey widgetDefinition
