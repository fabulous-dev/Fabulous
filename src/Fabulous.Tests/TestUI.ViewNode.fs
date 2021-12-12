module Tests.TestUI_ViewNode

open Fabulous
open Tests.Platform

module ViewNode =
    let ViewNodeProperty = "ViewNodeProperty" 

    let getViewNode (target: obj) =
        (target :?> TestViewElement).PropertyBag.Item ViewNodeProperty :?> ViewNode :> IViewNode