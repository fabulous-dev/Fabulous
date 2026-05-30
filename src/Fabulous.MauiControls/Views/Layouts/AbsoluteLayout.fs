namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Layouts
open Microsoft.Maui.Graphics

type IFabAbsoluteLayout =
    inherit IFabLayoutOfView

module AbsoluteLayout =
    let WidgetKey = Widgets.register<AbsoluteLayout>()

module AbsoluteLayoutAttached =
    let LayoutBounds =
        Attributes.defineBindableWithEquality AbsoluteLayout.LayoutBoundsProperty

    let LayoutFlags = Attributes.defineBindableEnum AbsoluteLayout.LayoutFlagsProperty

[<AutoOpen>]
module AbsoluteLayoutBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create an AbsoluteLayout widget</summary>
        static member inline AbsoluteLayout<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabAbsoluteLayout, IFabView>(AbsoluteLayout.WidgetKey, LayoutOfView.Children)

[<Extension>]
type AbsoluteLayoutModifiers =
    /// <summary>Link a ViewRef to access the direct AbsoluteLayout control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabAbsoluteLayout>, value: ViewRef<AbsoluteLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type AbsoluteLayoutAttachedModifiers =
    /// <summary>Set the bounding rectangle's position and dimensions</summary>
    /// <param name="this">Current widget</param>
    /// <param name= "x">The x-coordinate of the bounding rectangle</param>
    /// <param name= "y">The y-coordinate of the bounding rectangle</param>
    /// <param name= "width">The width of the bounding rectangle</param>
    /// <param name= "height">The height of the bounding rectangle</param>
    [<Extension>]
    static member inline layoutBounds(this: WidgetBuilder<'msg, #IFabView>, x: float, y: float, width: float, height: float) =
        this.AddScalar(AbsoluteLayoutAttached.LayoutBounds.WithValue(Rect(x, y, width, height)))

    /// <summary>Set how the values in the list are interpreted to create the bounding rectangle.</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The layout flag</param>
    [<Extension>]
    static member inline layoutFlags(this: WidgetBuilder<'msg, #IFabView>, value: AbsoluteLayoutFlags) =
        this.AddScalar(AbsoluteLayoutAttached.LayoutFlags.WithValue(value))
