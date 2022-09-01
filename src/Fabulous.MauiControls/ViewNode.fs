namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls

module ViewNode =
    let ViewNodeProperty =
        BindableProperty.Create("ViewNode", typeof<ViewNode>, typeof<View>, null)

    let get (target: obj) =
        (target :?> BindableObject)
            .GetValue(ViewNodeProperty)
        :?> IViewNode

    let set (node: IViewNode) (target: obj) =
        (target :?> BindableObject)
            .SetValue(ViewNodeProperty, node)
