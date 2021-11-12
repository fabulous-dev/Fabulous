namespace Fabulous.XamarinForms

open System
open Fabulous

type IScalarAttributeDefinition =
    abstract member Name: string
    abstract member UpdateTarget: obj voption * obj -> unit

type IWidgetAttributeDefinition =
    inherit IScalarAttributeDefinition
    abstract member ApplyDiff: AttributeChange[] * obj -> unit
    
type ICollectionAttributeDefinition =
    abstract member Name: string
    abstract member ApplyDiff: CollectionChange[] * obj -> unit

type ViewNode(key, context: ViewTreeContext, targetRef: WeakReference) =

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

                    | AttributeChange.WidgetUpdated struct (newAttr, diff) ->
                        let definition = AttributeDefinitionStore.get newAttr.Key :?> IWidgetAttributeDefinition
                        definition.ApplyDiff(diff, targetRef.Target)
                        _attributes <- Array.map (fun (a: Attribute) -> if a.Key = newAttr.Key then newAttr else a) _attributes

                    | AttributeChange.CollectionUpdated struct (newAttr, diff) ->
                        let definition = AttributeDefinitionStore.get newAttr.Key :?> ICollectionAttributeDefinition
                        definition.ApplyDiff(diff, targetRef.Target)
                        _attributes <- Array.map (fun (a: Attribute) -> if a.Key = newAttr.Key then newAttr else a) _attributes


type ViewNodeData(viewNode: ViewNode) =
    let mutable _handlers: Map<AttributeKey, obj> = Map.empty

    member _.ViewNode = viewNode

    member _.TryGetHandler<'T>(key: AttributeKey): 'T option =
        _handlers
        |> Map.tryFind key
        |> Option.map unbox<'T>

    member _.SetHandler<'T>(key: AttributeKey, handlerOpt: 'T voption) =
        _handlers <-
            _handlers
            |> Map.change key (fun _ -> match handlerOpt with ValueNone -> None | ValueSome h -> Some (box h))

module ViewNode =
    let ViewNodeProperty = Xamarin.Forms.BindableProperty.Create("ViewNode", typeof<ViewNodeData>, typeof<Xamarin.Forms.View>, null)

    let getViewNode (target: obj) =
        let viewNodeData = (target :?> Xamarin.Forms.BindableObject).GetValue(ViewNodeProperty) :?> ViewNodeData
        viewNodeData.ViewNode :> IViewNode