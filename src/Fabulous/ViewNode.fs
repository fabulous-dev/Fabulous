namespace Fabulous

open Fabulous

/// Define the logic to apply diffs and store event handlers of its target control
[<Sealed>]
type ViewNode(parent: IViewNode option, treeContext: ViewTreeContext, targetRef: System.WeakReference) =

    let mutable _isDisconnected = false
    
    // TODO consider combine handlers mapMsg and property bag
    // also we can probably use just Dictionary instead of Map because
    // ViewNode is supposed to be mutable, stateful and persistent object
    let mutable _handlers: Map<AttributeKey, obj> = Map.empty

    member inline private this.ApplyScalarDiffs(diffs: ScalarChanges inref) =
        for diff in diffs do
            match diff with
            | ScalarChange.Added added ->
                let definition =
                    AttributeDefinitionStore.get added.Key :?> IScalarAttributeDefinition

                definition.UpdateNode ValueNone (ValueSome added.Value) this

            | ScalarChange.Removed removed ->
                let definition =
                    AttributeDefinitionStore.get removed.Key :?> IScalarAttributeDefinition

                definition.UpdateNode (ValueSome removed.Value) ValueNone this

            | ScalarChange.Updated (oldAttr, newAttr) ->
                let definition =
                    AttributeDefinitionStore.get newAttr.Key :?> IScalarAttributeDefinition

                definition.UpdateNode (ValueSome oldAttr.Value) (ValueSome newAttr.Value) this

    member inline private this.ApplyWidgetDiffs(diffs: WidgetChanges inref) =
        for diff in diffs do
            match diff with
            | WidgetChange.Added newWidget
            | WidgetChange.ReplacedBy newWidget ->
                let definition =
                    AttributeDefinitionStore.get newWidget.Key :?> WidgetAttributeDefinition

                definition.UpdateNode ValueNone (ValueSome newWidget.Value) (this :> IViewNode)

            | WidgetChange.Removed removed ->
                let definition =
                    AttributeDefinitionStore.get removed.Key :?> WidgetAttributeDefinition

                definition.UpdateNode (ValueSome removed.Value) ValueNone (this :> IViewNode)

            | WidgetChange.Updated struct (newAttr, diffs) ->
                let definition =
                    AttributeDefinitionStore.get newAttr.Key :?> WidgetAttributeDefinition

                definition.ApplyDiff diffs (this :> IViewNode)

    member inline private this.ApplyWidgetCollectionDiffs(diffs: WidgetCollectionChanges inref) =
        for diff in diffs do
            match diff with
            | WidgetCollectionChange.Added added ->
                let definition =
                    AttributeDefinitionStore.get added.Key :?> WidgetCollectionAttributeDefinition

                definition.UpdateNode ValueNone (ValueSome added.Value) (this :> IViewNode)

            | WidgetCollectionChange.Removed removed ->
                let definition =
                    AttributeDefinitionStore.get removed.Key :?> WidgetCollectionAttributeDefinition

                definition.UpdateNode (ValueSome removed.Value) ValueNone (this :> IViewNode)

            | WidgetCollectionChange.Updated struct (oldAttr, newAttr, diffs) ->
                let definition =
                    AttributeDefinitionStore.get newAttr.Key :?> WidgetCollectionAttributeDefinition

                definition.ApplyDiff oldAttr.Value diffs (this :> IViewNode)

    interface IViewNode with
        member _.Target = targetRef.Target
        member _.TreeContext = treeContext
        member val MemoizedWidget: Widget option = None with get, set
        member _.Parent = parent
        member val MapMsg: (obj -> obj) option = None with get, set
        member _.IsDisconnected = _isDisconnected
        
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
                    
        member _.Disconnect() =
            _isDisconnected <- true

        member x.ApplyDiff(diff) =
            if not targetRef.IsAlive then
                ()
            else
                x.ApplyScalarDiffs(&diff.ScalarChanges)
                x.ApplyWidgetDiffs(&diff.WidgetChanges)
                x.ApplyWidgetCollectionDiffs(&diff.WidgetCollectionChanges)
