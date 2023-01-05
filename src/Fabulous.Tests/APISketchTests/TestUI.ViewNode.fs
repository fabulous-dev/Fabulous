namespace Fabulous.Tests.APISketchTests

module TestUI_ViewNode =

    open Fabulous
    open Platform

    module ViewNode =
        let ViewNodeProperty = "ViewNodeProperty"

        let getViewNode (target: obj) =
            (target :?> TestViewElement).PropertyBag.Item ViewNodeProperty :?> ViewNode :> IViewNode
