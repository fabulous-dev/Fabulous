namespace Fabulous.Tests.APISketchTests

module TestUI_Component =

    open Fabulous
    open Platform

    module Component =
        let ComponentProperty = "ComponentProperty"

        let getComponent (target: obj) =
            match (target :?> TestViewElement).PropertyBag.TryGetValue(ComponentProperty) with
            | true, comp -> comp
            | _ -> null

        let setComponent (comp: obj) (target: obj) =
            (target :?> TestViewElement).PropertyBag.Add(ComponentProperty, comp)
