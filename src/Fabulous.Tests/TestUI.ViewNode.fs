module Tests.TestUI_ViewNode

open Fabulous
open Tests.Platform

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
    let ViewNodeProperty = "ViewNodeProperty" 

    let getViewNode (target: obj) =
        let viewNodeData = (target :?> TestViewElement).PropertyBag.Item ViewNodeProperty :?> ViewNodeData
        viewNodeData.ViewNode :> IViewNode