namespace Fabulous

open Fabulous

/// Define the logic to apply diffs and store event handlers of its target control
[<Sealed>]
type ViewNode(parent: IViewNode option, treeContext: ViewTreeContext, targetRef: System.WeakReference) =

    let mutable _isDisconnected = false

    // TODO consider combine handlers mapMsg and property bag
    // also we can probably use just Dictionary instead of Map because
    // ViewNode is supposed to be mutable, stateful and persistent object
    let mutable _handlers: Map<string, obj> = Map.empty

    member inline private this.ApplyScalarDiffs(diffs: ScalarChanges inref) : unit =
        let node = this :> IViewNode
        
        for diff in diffs do
            match diff with
            | ScalarChange.Added added ->
                let key = added.Key

                match ScalarAttributeKey.getKind key with
                | ScalarAttributeKey.Inline ->
                    let smallScalar =
                        (AttributeDefinitionStore.getSmallScalar key)

                    smallScalar.UpdateNode ValueNone (ValueSome added.NumericValue) node

                | ScalarAttributeKey.Boxed ->
                    let scalar = (AttributeDefinitionStore.getScalar key)

                    scalar.UpdateNode ValueNone (ValueSome added.Value) node

            | ScalarChange.Removed removed ->

                let key = removed.Key

                match ScalarAttributeKey.getKind key with
                | ScalarAttributeKey.Inline ->
                    let smallScalar =
                        (AttributeDefinitionStore.getSmallScalar key)

                    smallScalar.UpdateNode(ValueSome removed.NumericValue) ValueNone node

                | ScalarAttributeKey.Boxed ->
                    let scalar = (AttributeDefinitionStore.getScalar key)

                    scalar.UpdateNode(ValueSome removed.Value) ValueNone node



            | ScalarChange.Updated (oldAttr, newAttr) ->
                let key = oldAttr.Key

                match ScalarAttributeKey.getKind key with
                | ScalarAttributeKey.Inline ->
                    let smallScalar =
                        (AttributeDefinitionStore.getSmallScalar key)

                    smallScalar.UpdateNode(ValueSome oldAttr.NumericValue) (ValueSome newAttr.NumericValue) node

                | ScalarAttributeKey.Boxed ->
                    let scalar = (AttributeDefinitionStore.getScalar key)

                    scalar.UpdateNode(ValueSome oldAttr.Value) (ValueSome newAttr.Value) node

    member inline private this.ApplyWidgetDiffs(diffs: WidgetChanges inref) =
        for diff in diffs do
            match diff with
            | WidgetChange.Added newWidget
            | WidgetChange.ReplacedBy newWidget ->
                let definition =
                    (AttributeDefinitionStore.getWidget newWidget.Key)

                definition.UpdateNode ValueNone (ValueSome newWidget.Value) (this :> IViewNode)

            | WidgetChange.Removed removed ->
                let definition =
                    (AttributeDefinitionStore.getWidget removed.Key)

                definition.UpdateNode(ValueSome removed.Value) ValueNone (this :> IViewNode)

            | WidgetChange.Updated struct (newAttr, diffs) ->
                let definition =
                    (AttributeDefinitionStore.getWidget newAttr.Key)

                definition.ApplyDiff diffs (this :> IViewNode)

    member inline private this.ApplyWidgetCollectionDiffs(diffs: WidgetCollectionChanges inref) =
        for diff in diffs do
            match diff with
            | WidgetCollectionChange.Added added ->
                let definition =
                    (AttributeDefinitionStore.getWidgetCollection added.Key)

                definition.UpdateNode ValueNone (ValueSome added.Value) (this :> IViewNode)


            | WidgetCollectionChange.Removed removed ->
                let definition =
                    (AttributeDefinitionStore.getWidgetCollection removed.Key)

                definition.UpdateNode(ValueSome removed.Value) ValueNone (this :> IViewNode)


            | WidgetCollectionChange.Updated struct (oldAttr, newAttr, diffs) ->
                let definition =
                    (AttributeDefinitionStore.getWidgetCollection newAttr.Key)

                definition.ApplyDiff oldAttr.Value diffs (this :> IViewNode)

    interface IViewNode with
        member _.Target = targetRef.Target
        member _.TreeContext = treeContext
        member val MemoizedWidget: Widget option = None with get, set
        member _.Parent = parent
        member val MapMsg: (obj -> obj) option = None with get, set
        member _.IsDisconnected = _isDisconnected

        member _.TryGetHandler<'T>(key: string) =
            match Map.tryFind key _handlers with
            | None -> ValueNone
            | Some v -> ValueSome(unbox<'T> v)

        member _.SetHandler<'T>(key: string, handlerOpt: 'T voption) =
            _handlers <-
                _handlers
                |> Map.change
                    key
                    (fun _ ->
                        match handlerOpt with
                        | ValueNone -> None
                        | ValueSome h -> Some(box h))

        member _.Disconnect() = _isDisconnected <- true

        member x.ApplyDiff(diff) =
            if not targetRef.IsAlive then
                ()
            else
                x.ApplyWidgetDiffs(&diff.WidgetChanges)
                x.ApplyWidgetCollectionDiffs(&diff.WidgetCollectionChanges)
                x.ApplyScalarDiffs(&diff.ScalarChanges)
