namespace Fabulous.Maui

open Fabulous

type Node() =
    member val ViewNode: IViewNode = Unchecked.defaultof<IViewNode> with get, set

module ViewNode =
    let get (target: obj) = (target :?> Node).ViewNode
    let set (value: IViewNode) (target: Node) = target.ViewNode <- value