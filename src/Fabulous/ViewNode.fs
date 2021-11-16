namespace Fabulous


type ViewNode(key, context: ViewTreeContext, targetRef: System.WeakReference) =

    member _.Context = context

    interface IViewNode with
        member _.Origin = key

        member _.ApplyScalarDiff(diffs) =
            if not targetRef.IsAlive then
                ()
            else
                for diff in diffs do
                    match diff with
                    | ScalarChange.Added added ->
                        let definition = AttributeDefinitionStore.get added.Key :?> IScalarAttributeDefinition
                        definition.UpdateTarget(ValueSome added.Value, targetRef.Target)

                    | ScalarChange.Removed removed ->
                        let definition = AttributeDefinitionStore.get removed.Key :?> IScalarAttributeDefinition
                        definition.UpdateTarget(ValueNone, targetRef.Target)

                    | ScalarChange.Updated newAttr ->
                        let definition = AttributeDefinitionStore.get newAttr.Key :?> IScalarAttributeDefinition
                        definition.UpdateTarget(ValueSome newAttr.Value, targetRef.Target)

        member _.ApplyWidgetDiff(diffs) =
            if not targetRef.IsAlive then
                ()
            else
                for diff in diffs do
                    match diff with
                    | WidgetChange.Added newWidget
                    | WidgetChange.ReplacedBy newWidget ->
                        let definition = AttributeDefinitionStore.get newWidget.Key :?> WidgetAttributeDefinition
                        definition.UpdateTarget(ValueSome newWidget.Value, targetRef.Target)

                    | WidgetChange.Removed removed ->
                        let definition = AttributeDefinitionStore.get removed.Key :?> WidgetAttributeDefinition
                        definition.UpdateTarget(ValueNone, targetRef.Target)

                    | WidgetChange.Updated struct (newAttr, diffs) ->
                        let definition = AttributeDefinitionStore.get newAttr.Key :?> WidgetAttributeDefinition
                        definition.ApplyDiff(diffs, targetRef.Target)

        member _.ApplyWidgetCollectionDiff(diffs) =
            if not targetRef.IsAlive then
                ()
            else
                for diff in diffs do
                    match diff with
                    | WidgetCollectionChange.Added added ->
                        let definition = AttributeDefinitionStore.get added.Key :?> WidgetCollectionAttributeDefinition
                        definition.UpdateTarget(ValueSome added.Value, targetRef.Target)
                        
                    | WidgetCollectionChange.Removed removed ->
                        let definition = AttributeDefinitionStore.get removed.Key :?> WidgetCollectionAttributeDefinition
                        definition.UpdateTarget(ValueNone, targetRef.Target)

                    | WidgetCollectionChange.Updated struct (newAttr, diffs) ->
                        let definition = AttributeDefinitionStore.get newAttr.Key :?> WidgetCollectionAttributeDefinition
                        definition.ApplyDiff(diffs, targetRef.Target)
