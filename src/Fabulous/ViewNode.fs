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

    member inline private this.ApplyScalarDiffs(diffs: ScalarChanges inref): unit =
        for diff in diffs do
            match diff with
            | ScalarChange.Added added ->
                match AttributeDefinitionStore.get added.Key with
                | AttributeDefinition.Scalar scalarAttributeData -> 
                    scalarAttributeData.UpdateNode ValueNone (ValueSome added.Value) this
                
                | AttributeDefinition.SmallScalar definition -> 
                    definition.UpdateNode ValueNone (ValueSome added.NumericValue) this
                    
                | _ -> ()

            | ScalarChange.Removed removed ->
                match AttributeDefinitionStore.get removed.Key with
                | AttributeDefinition.Scalar definition -> 
                    definition.UpdateNode(ValueSome removed.Value) ValueNone this
                    
                 | AttributeDefinition.SmallScalar definition -> 
                    definition.UpdateNode(ValueSome removed.NumericValue) ValueNone this
                    
                | _ -> ()

            | ScalarChange.Updated (oldAttr, newAttr) ->
                match AttributeDefinitionStore.get oldAttr.Key with
                | AttributeDefinition.Scalar definition -> 
                    definition.UpdateNode(ValueSome oldAttr.Value) (ValueSome newAttr.Value) this
                | AttributeDefinition.SmallScalar definition -> 
                    definition.UpdateNode(ValueSome oldAttr.NumericValue) (ValueSome newAttr.NumericValue) this
                | _ -> ()
    
    member inline private this.ApplyWidgetDiffs(diffs: WidgetChanges inref) =
        for diff in diffs do
            match diff with
            | WidgetChange.Added newWidget
            | WidgetChange.ReplacedBy newWidget ->
                match AttributeDefinitionStore.get newWidget.Key with
                | AttributeDefinition.Widget definition -> 
                    definition.UpdateNode ValueNone (ValueSome newWidget.Value) (this :> IViewNode)
                | _ -> ()

            | WidgetChange.Removed removed ->
                match AttributeDefinitionStore.get removed.Key with
                | AttributeDefinition.Widget definition -> 
                    definition.UpdateNode(ValueSome removed.Value) ValueNone (this :> IViewNode)
                | _ -> ()
                
            | WidgetChange.Updated struct (newAttr, diffs) ->
                match AttributeDefinitionStore.get newAttr.Key with
                | AttributeDefinition.Widget definition -> 
                    definition.ApplyDiff diffs (this :> IViewNode)
                | _ -> ()

    member inline private this.ApplyWidgetCollectionDiffs(diffs: WidgetCollectionChanges inref) =
        for diff in diffs do
            match diff with
            | WidgetCollectionChange.Added added ->
                 match AttributeDefinitionStore.get added.Key with
                 | AttributeDefinition.WidgetCollection definition -> 
                    definition.UpdateNode ValueNone (ValueSome added.Value) (this :> IViewNode)
                 | _ -> ()
                

            | WidgetCollectionChange.Removed removed ->
                 match AttributeDefinitionStore.get removed.Key with
                 | AttributeDefinition.WidgetCollection definition -> 
                    definition.UpdateNode(ValueSome removed.Value) ValueNone (this :> IViewNode)
                 | _ -> ()


            | WidgetCollectionChange.Updated struct (oldAttr, newAttr, diffs) ->
                match AttributeDefinitionStore.get newAttr.Key with
                 | AttributeDefinition.WidgetCollection definition -> 
                    definition.ApplyDiff oldAttr.Value diffs (this :> IViewNode)
                 | _ -> ()

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

        member _.Disconnect() = _isDisconnected <- true

        member x.ApplyDiff(diff) =
            if not targetRef.IsAlive then
                ()
            else
                x.ApplyWidgetDiffs(&diff.WidgetChanges)
                x.ApplyWidgetCollectionDiffs(&diff.WidgetCollectionChanges)
                x.ApplyScalarDiffs(&diff.ScalarChanges)
