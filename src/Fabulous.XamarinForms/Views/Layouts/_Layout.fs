namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ILayout =
    inherit IView

module Layout =
    let Padding =
        Attributes.defineBindableWithEquality<Thickness> Layout.PaddingProperty

    let CascadeInputTransparent =
        Attributes.defineBindableBool Layout.CascadeInputTransparentProperty

    let IsClippedToBounds =
        Attributes.defineBindableBool Layout.IsClippedToBoundsProperty

    let LayoutChanged =
        Attributes.defineEventNoArg "Layout_LayoutChanged" (fun target -> (target :?> Layout).LayoutChanged)

[<Extension>]
type LayoutModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #ILayout>, value: Thickness) =
        this.AddScalar(Layout.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #ILayout>, value: float) =
        LayoutModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding
        (
            this: WidgetBuilder<'msg, #ILayout>,
            ?left: float,
            ?top: float,
            ?right: float,
            ?bottom: float
        ) =
        let left = match left with None -> 0. | Some v -> v
        let top = match top with None -> 0. | Some v -> v
        let right = match right with None -> 0. | Some v -> v
        let bottom = match bottom with None -> 0. | Some v -> v
        LayoutModifiers.padding(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline cascadeInputTransparent(this: WidgetBuilder<'msg, #ILayout>, value: bool) =
        this.AddScalar(Layout.CascadeInputTransparent.WithValue(value))

    [<Extension>]
    static member inline isClippedToBounds(this: WidgetBuilder<'msg, #ILayout>, value: bool) =
        this.AddScalar(Layout.IsClippedToBounds.WithValue(value))

    [<Extension>]
    static member inline onLayoutChanged(this: WidgetBuilder<'msg, #ILayout>, value: 'msg) =
        this.AddScalar(Layout.LayoutChanged.WithValue(value))
