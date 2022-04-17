namespace Fabulous

open Fabulous

module Reconciler =

    let private compareScalars (struct (key, a, b): struct (AttributeKey * obj * obj)) : ScalarAttributeComparison =
        match AttributeDefinitionStore.get key with
        |  AttributeDefinition.Scalar data -> data.CompareBoxed a b
        | _ -> ScalarAttributeComparison.Different

    let update
        (canReuseView: Widget -> Widget -> bool)
        (prevOpt: Widget voption)
        (next: Widget)
        (node: IViewNode)
        : unit =

        let diff =
            WidgetDiff.create(prevOpt, next, canReuseView, compareScalars)

        node.ApplyDiff(&diff)
