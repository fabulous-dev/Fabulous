namespace Fabulous.Tests.APISketchTests

module TestUI_Component =

    open Fabulous
    open Platform

    module Component =
        let ComponentProperty = "ComponentProperty"

        let getComponent (target: obj) =
            (target :?> TestViewElement).PropertyBag.Item ComponentProperty
