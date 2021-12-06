namespace Fabulous

type ViewNode(key, context: ViewTreeContext, targetRef: System.WeakReference) =
    let mutable _handlers: Map<AttributeKey, obj> = Map.empty

    interface IViewNode with
        member _.Origin = key
        member _.Context = context
        member val MapMsg = ValueNone with get,set

        member _.TryGetHandler<'T>(key: AttributeKey) : 'T option =
            _handlers
            |> Map.tryFind key
            |> Option.map unbox<'T>

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

                        definition.UpdateTarget(ValueSome added.Value, x, targetRef.Target)

                    | ScalarChange.Removed removed ->
                        let definition =
                            AttributeDefinitionStore.get removed.Key :?> IScalarAttributeDefinition

                        definition.UpdateTarget(ValueNone, x, targetRef.Target)

                    | ScalarChange.Updated newAttr ->
                        let definition =
                            AttributeDefinitionStore.get newAttr.Key :?> IScalarAttributeDefinition

                        definition.UpdateTarget(ValueSome newAttr.Value, x, targetRef.Target)

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

                        definition.UpdateTarget(ValueSome newWidget.Value, x, targetRef.Target)

                    | WidgetChange.Removed removed ->
                        let definition =
                            AttributeDefinitionStore.get removed.Key :?> WidgetAttributeDefinition

                        definition.UpdateTarget(ValueNone, x, targetRef.Target)

                    | WidgetChange.Updated struct (newAttr, diffs) ->
                        let definition =
                            AttributeDefinitionStore.get newAttr.Key :?> WidgetAttributeDefinition

                        definition.ApplyDiff(diffs, targetRef.Target)

        member x.ApplyWidgetCollectionDiff(diffs) =
            if not targetRef.IsAlive then
                ()
            else
                for diff in diffs do
                    match diff with
                    | WidgetCollectionChange.Added added ->
                        let definition =
                            AttributeDefinitionStore.get added.Key :?> WidgetCollectionAttributeDefinition

                        definition.UpdateTarget(ValueSome added.Value, x, targetRef.Target)

                    | WidgetCollectionChange.Removed removed ->
                        let definition =
                            AttributeDefinitionStore.get removed.Key :?> WidgetCollectionAttributeDefinition

                        definition.UpdateTarget(ValueNone, x, targetRef.Target)

                    | WidgetCollectionChange.Updated struct (newAttr, diffs) ->
                        let definition =
                            AttributeDefinitionStore.get newAttr.Key :?> WidgetCollectionAttributeDefinition

                        definition.ApplyDiff(diffs, targetRef.Target)
