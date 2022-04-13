namespace Fabulous.Maui

open Fabulous

type Node() =
    member _.ViewNode = Unchecked.defaultof<IViewNode>

module ViewNode =
    let get (target: obj) = (target :?> Node).ViewNode