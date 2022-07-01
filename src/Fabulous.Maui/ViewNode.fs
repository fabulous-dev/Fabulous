namespace Fabulous.Maui

open System.Collections.Generic
open Fabulous
open Microsoft.Maui

type Node(handler: IElementHandler) =
    let scalarAttributes = Dictionary<int<scalarAttributeKey>, obj>()
    member val Handler = handler with get, set
    member val ViewNode: IViewNode = Unchecked.defaultof<IViewNode> with get, set
    member val Parent: IElement = null with get, set
    member this.GetScalarValue<'T>(key: int<scalarAttributeKey>) = scalarAttributes[key] :?> 'T

module ViewNode =
    let get (target: obj) = (target :?> Node).ViewNode
    let set (value: IViewNode) (target: Node) = target.ViewNode <- value