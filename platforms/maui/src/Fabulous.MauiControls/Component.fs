namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls

module Component =
    let ComponentProperty =
        BindableProperty.CreateAttached("Component", typeof<Component>, typeof<BindableObject>, null)

    let get (target: obj) =
        (target :?> BindableObject).GetValue(ComponentProperty)

    let set (comp: obj) (target: obj) =
        (target :?> BindableObject).SetValue(ComponentProperty, comp)

[<AutoOpen>]
module ComponentBuilders =
    type Fabulous.Maui.View with

        static member Component<'msg, 'marker when 'msg: equality>(key: string) = ComponentBuilder<'msg, 'marker>(key)
