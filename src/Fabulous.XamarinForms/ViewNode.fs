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
                        let definition = AttributeDefinitionStore.get added.Key :?> IXamarinFormsAttributeDefinition
                        definition.UpdateTarget(ValueSome added.Value, targetRef.Target)
                        _attributes <- Array.append _attributes [| added |]

                    | AttributeChange.Removed removed ->
                        let definition = AttributeDefinitionStore.get removed.Key :?> IXamarinFormsAttributeDefinition
                        definition.UpdateTarget(ValueNone, targetRef.Target)
                        _attributes <- Array.filter (fun a -> a.Key <> removed.Key) _attributes

                    | AttributeChange.Updated struct (prevAttribute, currAttribute, diff) ->
                        // TODO: What to do when prevAttribute.Origin <> currAttribute.Origin?
                        let definition = AttributeDefinitionStore.get currAttribute.Key :?> IXamarinFormsAttributeDefinition
                        definition.UpdateTarget(ValueSome currAttribute.Value, targetRef.Target)
                        _attributes <- Array.map (fun (a: Attribute) -> if a.Key = currAttribute.Key then currAttribute else a) _attributes

                match viewContainerOpt with
                | None -> UpdateResult.Done
                | Some viewContainer ->
                    let needsChildrenUpdate =
                        diffs.Changes
                        |> Array.choose (fun change ->
                            match change with
                            | AttributeChange.Added added  when added.Key = viewContainer.ChildrenAttributeKey -> Some (added.Value :?> Widget[])
                            | AttributeChange.Removed removed when removed.Key = viewContainer.ChildrenAttributeKey -> Some (removed.Value :?> Widget[])
                            | AttributeChange.Updated struct (_, currAttribute, diff) when currAttribute.Key = viewContainer.ChildrenAttributeKey -> Some (currAttribute.Value :?> Widget[])
                            | _ -> None
                        )
                        |> Array.tryHead

                    match needsChildrenUpdate with
                    | None -> UpdateResult.Done
                    | Some widgets -> UpdateResult.UpdateChildren struct (viewContainer :> IViewContainer, widgets, context)

and IXamarinFormsAttributeDefinition =
    abstract member Name: string
    abstract member UpdateTarget: obj voption * obj -> unit

and XamarinFormsAttributeDefinition<'inputType, 'modelType> =
    {
        Key: AttributeKey
        Name: string
        DefaultWith: unit -> 'modelType
        Convert: 'inputType -> 'modelType
        Compare: struct ('modelType * 'modelType) -> AttributeComparison
        UpdateTarget: struct ('modelType voption * obj) -> unit
    }

    member x.WithValue(value) =
        { Key = x.Key
#if DEBUG
          DebugName = x.Name
#endif
          Value = x.Convert(value) }

    interface IXamarinFormsAttributeDefinition with
        member x.Name = x.Name
        member x.UpdateTarget(newValueOpt, target) =
            let newValueOpt = match newValueOpt with ValueNone -> ValueNone | ValueSome v -> ValueSome (unbox<'modelType> v)
            x.UpdateTarget (struct (newValueOpt, target))

    interface IAttributeDefinition<'inputType, 'modelType> with
        member x.Key = x.Key
        member x.DefaultWith () = x.DefaultWith ()
        member x.CompareBoxed(a, b) =
            x.Compare(struct (unbox<'modelType> a, unbox<'modelType> b))

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