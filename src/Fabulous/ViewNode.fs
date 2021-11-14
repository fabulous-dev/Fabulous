namespace Fabulous

type IScalarAttributeDefinition =
    abstract member UpdateTarget: obj voption * obj -> unit

type IWidgetAttributeDefinition =
    inherit IScalarAttributeDefinition
    abstract member ApplyDiff: AttributeChange[] * obj -> unit
    
type IWidgetCollectionAttributeDefinition =
    inherit IScalarAttributeDefinition
    abstract member ApplyDiff: WidgetCollectionChange[] * obj -> unit

type ViewNode(key, context: ViewTreeContext, targetRef: System.WeakReference) =

    let mutable _attributes = [||]

    member _.Context = context

    interface IViewNode with
        member _.Attributes = _attributes
        member _.Origin = key
        member _.ApplyDiff(changes) =
            if not targetRef.IsAlive then
                ()
            else
                for change in changes do
                    match change with
                    | AttributeChange.Added added ->
                        let definition = AttributeDefinitionStore.get added.Key :?> IScalarAttributeDefinition
                        definition.UpdateTarget(ValueSome added.Value, targetRef.Target)
                        _attributes <- Array.append _attributes [| added |]

                    | AttributeChange.Removed removed ->
                        let definition = AttributeDefinitionStore.get removed.Key :?> IScalarAttributeDefinition
                        definition.UpdateTarget(ValueNone, targetRef.Target)
                        _attributes <- Array.filter (fun a -> a.Key <> removed.Key) _attributes

                    | AttributeChange.ScalarUpdated newAttr ->
                        let definition = AttributeDefinitionStore.get newAttr.Key :?> IScalarAttributeDefinition
                        definition.UpdateTarget(ValueSome newAttr.Value, targetRef.Target)
                        _attributes <- Array.map (fun (a: Attribute) -> if a.Key = newAttr.Key then newAttr else a) _attributes

                    | AttributeChange.WidgetUpdated struct (newAttr, diffs) ->
                        let definition = AttributeDefinitionStore.get newAttr.Key :?> IWidgetAttributeDefinition
                        definition.ApplyDiff(diffs, targetRef.Target)
                        _attributes <- Array.map (fun (a: Attribute) -> if a.Key = newAttr.Key then newAttr else a) _attributes

                    | AttributeChange.WidgetCollectionUpdated struct (newAttr, diffs) ->
                        let definition = AttributeDefinitionStore.get newAttr.Key :?> IWidgetCollectionAttributeDefinition
                        definition.ApplyDiff(diffs, targetRef.Target)
                        _attributes <- Array.map (fun (a: Attribute) -> if a.Key = newAttr.Key then newAttr else a) _attributes
