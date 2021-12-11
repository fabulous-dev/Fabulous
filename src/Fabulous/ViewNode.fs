namespace Fabulous

open Fabulous

/// Define the logic to apply diffs and store event handlers of its target control
type ViewNode(context: ViewNodeContext, targetRef: System.WeakReference) =
    let mutable _handlers: Map<AttributeKey, obj> = Map.empty
    let mutable _mapMsg: obj -> obj = id
    
    interface IViewNode with
        member x.Context = context
        
        member x.MapMsg(msg) = _mapMsg msg
        
        member x.SetMapMsg(fn) = _mapMsg <- fn

        member _.TryGetHandler<'T>(key: AttributeKey) =
            match Map.tryFind key _handlers with
            | None -> ValueNone
            | Some v -> ValueSome (unbox<'T> v)

        member _.SetHandler<'T>(key: AttributeKey, handlerOpt: 'T voption) =
            _handlers <-
                _handlers
                |> Map.change
                    key
                    (fun _ ->
                        match handlerOpt with
                        | ValueNone -> None
                        | ValueSome h -> Some(box h))

        member x.ApplyScalarDiff(diffs) =
            if not targetRef.IsAlive then
                ()
            else
                for diff in diffs do
                    match diff with
                    | ScalarChange.Added added ->
                        let definition =
                            AttributeDefinitionStore.get added.Key :?> IScalarAttributeDefinition

                        definition.UpdateTarget(ValueSome added.Value, context, targetRef.Target)

                    | ScalarChange.Removed removed ->
                        let definition =
                            AttributeDefinitionStore.get removed.Key :?> IScalarAttributeDefinition

                        definition.UpdateTarget(ValueNone, context, targetRef.Target)

                    | ScalarChange.Updated newAttr ->
                        let definition =
                            AttributeDefinitionStore.get newAttr.Key :?> IScalarAttributeDefinition

                        definition.UpdateTarget(ValueSome newAttr.Value, context, targetRef.Target)

        member x.ApplyWidgetDiff(diffs) =
            if not targetRef.IsAlive then
                ()
            else
                for diff in diffs do
                    match diff with
                    | WidgetChange.Added newWidget
                    | WidgetChange.ReplacedBy newWidget ->
                        let definition =
                            AttributeDefinitionStore.get newWidget.Key :?> WidgetAttributeDefinition

                        definition.UpdateTarget(ValueSome newWidget.Value, context, targetRef.Target)

                    | WidgetChange.Removed removed ->
                        let definition =
                            AttributeDefinitionStore.get removed.Key :?> WidgetAttributeDefinition

                        definition.UpdateTarget(ValueNone, context, targetRef.Target)

                    | WidgetChange.Updated struct (newAttr, diffs) ->
                        let definition =
                            AttributeDefinitionStore.get newAttr.Key :?> WidgetAttributeDefinition

                        definition.ApplyDiff(diffs, context, targetRef.Target)

        member x.ApplyWidgetCollectionDiff(diffs) =
            if not targetRef.IsAlive then
                ()
            else
                for diff in diffs do
                    match diff with
                    | WidgetCollectionChange.Added added ->
                        let definition =
                            AttributeDefinitionStore.get added.Key :?> WidgetCollectionAttributeDefinition

                        definition.UpdateTarget(ValueSome added.Value, context, targetRef.Target)

                    | WidgetCollectionChange.Removed removed ->
                        let definition =
                            AttributeDefinitionStore.get removed.Key :?> WidgetCollectionAttributeDefinition

                        definition.UpdateTarget(ValueNone, context, targetRef.Target)

                    | WidgetCollectionChange.Updated struct (newAttr, diffs) ->
                        let definition =
                            AttributeDefinitionStore.get newAttr.Key :?> WidgetCollectionAttributeDefinition

                        definition.ApplyDiff(diffs, context, targetRef.Target)
