namespace Fabulous.XamarinForms

open System
open Fabulous

type IXamarinFormsViewContainer =
    inherit IViewContainer
    abstract member ChildrenAttributeKey: AttributeKey

type ViewNode(key, context: ViewTreeContext, targetRef: WeakReference, viewContainerOpt: IXamarinFormsViewContainer option) =

    let mutable _attributes = [||]

    member _.Context = context

    interface IViewNode with
        member _.Attributes = _attributes
        member _.Origin = key
        member _.ApplyDiff(diffs) =
            if not targetRef.IsAlive then
                UpdateResult.Done
            else
                for change in diffs.Changes do
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

                match viewContainerOpt with
                | None -> UpdateResult.Done
                | Some viewContainer ->
                    let needsChildrenUpdate =
                        diffs.Changes
                        |> Array.choose (fun change ->
                            match change with
                            | AttributeChange.Added added  when added.Key = viewContainer.ChildrenAttributeKey -> Some (added.Value :?> Widget[])
                            | AttributeChange.Removed removed when removed.Key = viewContainer.ChildrenAttributeKey -> Some (removed.Value :?> Widget[])
                            | AttributeChange.ScalarUpdated newAttr when newAttr.Key = viewContainer.ChildrenAttributeKey -> Some (newAttr.Value :?> Widget[])
                            | _ -> None
                        )
                        |> Array.tryHead

                    match needsChildrenUpdate with
                    | None -> UpdateResult.Done
                    | Some widgets -> UpdateResult.UpdateChildren struct (viewContainer :> IViewContainer, widgets, context)

and IScalarAttributeDefinition =
    abstract member Name: string
    abstract member UpdateTarget: obj voption * obj -> unit

and IWidgetAttributeDefinition =
    inherit IScalarAttributeDefinition
    abstract member ApplyDiff: WidgetDiff * obj -> unit

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