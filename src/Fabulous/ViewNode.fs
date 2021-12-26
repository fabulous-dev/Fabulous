namespace Fabulous

open System.Collections.Generic
open Fabulous

/// Define the logic to apply diffs and store event handlers of its target control
type ViewNode(parentNode: IViewNode voption, treeContext: ViewTreeContext, targetRef: System.WeakReference) =

    // TODO consider combine handlers mapMsg and property bag
    // also we can probably use just Dictionary instead of Map because
    // ViewNode is supposed to be mutable, stateful and persistent object
    let mutable _handlers: Map<AttributeKey, obj> = Map.empty
    let mutable _mapMsg: (obj -> obj) voption = ValueNone

    interface IViewNode with
        member _.Target = targetRef.Target
        member _.TreeContext = treeContext
        member _.Parent = parentNode
        member val MapMsg = _mapMsg with get, set
        member val PropertyBag = Dictionary()

        member _.GetViewNodeForChild(child) = treeContext.GetViewNode(child)

        member _.TryGetHandler<'T>(key: AttributeKey) =
            match Map.tryFind key _handlers with
            | None -> ValueNone
            | Some v -> ValueSome(unbox<'T> v)

        member _.SetHandler<'T>(key: AttributeKey, handlerOpt: 'T voption) =
            _handlers <-
                _handlers
                |> Map.change
                    key
                    (fun _ ->
                        match handlerOpt with
                        | ValueNone -> None
                        | ValueSome h -> Some(box h))

        member this.ApplyScalarDiffs(diffs) =
            if not targetRef.IsAlive then
                ()
            else
                for diff in diffs do
                    match diff with
                    | ScalarChange.Added added ->
                        let definition =
                            AttributeDefinitionStore.get added.Key :?> IScalarAttributeDefinition

                        definition.UpdateNode(ValueSome added.Value, this)

                    | ScalarChange.Removed removed ->
                        let definition =
                            AttributeDefinitionStore.get removed.Key :?> IScalarAttributeDefinition

                        definition.UpdateNode(ValueNone, this)

                    | ScalarChange.Updated newAttr ->
                        let definition =
                            AttributeDefinitionStore.get newAttr.Key :?> IScalarAttributeDefinition

                        definition.UpdateNode(ValueSome newAttr.Value, this)

        member this.ApplyWidgetDiffs(diffs) =
            if not targetRef.IsAlive then
                ()
            else
                for diff in diffs do
                    match diff with
                    | WidgetChange.Added newWidget
                    | WidgetChange.ReplacedBy newWidget ->
                        let definition =
                            AttributeDefinitionStore.get newWidget.Key :?> WidgetAttributeDefinition

                        definition.UpdateNode(ValueSome newWidget.Value, this)

                    | WidgetChange.Removed removed ->
                        let definition =
                            AttributeDefinitionStore.get removed.Key :?> WidgetAttributeDefinition

                        definition.UpdateNode(ValueNone, this)

                    | WidgetChange.Updated struct (newAttr, diffs) ->
                        let definition =
                            AttributeDefinitionStore.get newAttr.Key :?> WidgetAttributeDefinition

                        definition.ApplyDiff(diffs, this)

        member this.ApplyWidgetCollectionDiffs(diffs) =
            if not targetRef.IsAlive then
                ()
            else
                for diff in diffs do
                    match diff with
                    | WidgetCollectionChange.Added added ->
                        let definition =
                            AttributeDefinitionStore.get added.Key :?> WidgetCollectionAttributeDefinition

                        definition.UpdateNode(ValueSome added.Value, this)

                    | WidgetCollectionChange.Removed removed ->
                        let definition =
                            AttributeDefinitionStore.get removed.Key :?> WidgetCollectionAttributeDefinition

                        definition.UpdateNode(ValueNone, this)

                    | WidgetCollectionChange.Updated struct (newAttr, diffs) ->
                        let definition =
                            AttributeDefinitionStore.get newAttr.Key :?> WidgetCollectionAttributeDefinition

                        definition.ApplyDiff(diffs, this)
