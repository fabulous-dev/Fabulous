namespace Fabulous.XamarinForms

open Fabulous

type ViewNode(key, attributes, context: ViewTreeContext) =
    member _.Context = context

    interface IViewNode with
        member _.ApplyDiff(diffs) = UpdateResult.Done
        member _.Attributes = attributes
        member _.Origin = key

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