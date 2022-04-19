namespace Fabulous

open Fabulous

module Reconciler =

    let private compareScalars
        (struct (key, a, b): struct (ScalarAttributeKey * obj * obj))
        : ScalarAttributeComparison =
        let data = AttributeDefinitionStore.getScalar key
        data.CompareBoxed a b

    let update
        (canReuseView: Widget -> Widget -> bool)
        (prevOpt: Widget voption)
        (next: Widget)
        (node: IViewNode)
        : unit =

        let diff =
            WidgetDiff.create(prevOpt, next, canReuseView, compareScalars)

        node.ApplyDiff(&diff)
