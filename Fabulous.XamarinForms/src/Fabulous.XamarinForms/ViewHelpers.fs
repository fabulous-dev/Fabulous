namespace Fabulous.XamarinForms

open Fabulous

[<AutoOpen>]
module ViewHelpers =
    let rec canReuseView (prevChild: IViewElement) (newChild: IViewElement) =
        match prevChild, newChild with
        | (:? DynamicViewElement as prev), (:? DynamicViewElement as curr) -> DynamicViewHelpers.canReuseView canReuseView prev curr
        | (:? IComponentViewElement as prev), (:? IComponentViewElement as curr) -> Component.canReuseView prev curr
        | _ -> false

    let tryGetKey (viewElement: IViewElement) =
        viewElement.TryKey