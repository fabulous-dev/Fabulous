namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabBoxView =
    inherit IFabView

module BoxView =
    let WidgetKey = Widgets.register<BoxView>()

    let Color = Attributes.defineBindableColor BoxView.ColorProperty

    let CornerRadius = Attributes.defineBindableFloat BoxView.CornerRadiusProperty

[<AutoOpen>]
module BoxViewBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a BoxView widget with a color</summary>
        /// <param name="color">The color value</param>
        static member inline BoxView<'msg when 'msg: equality>(color: Color) =
            WidgetBuilder<'msg, IFabBoxView>(BoxView.WidgetKey, BoxView.Color.WithValue(color))

[<Extension>]
type BoxViewModifiers =
    /// <summary>Set the corner radius of the BoxView</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">corner radius value for the box view.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabBoxView>, value: float) =
        this.AddScalar(BoxView.CornerRadius.WithValue(value))

    /// <summary>Link a ViewRef to access the direct BoxView control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabBoxView>, value: ViewRef<BoxView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
