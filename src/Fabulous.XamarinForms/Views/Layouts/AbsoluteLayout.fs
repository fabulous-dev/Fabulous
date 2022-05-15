namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IAbsoluteLayout =
    inherit ILayoutOfView

module AbsoluteLayout =

    let WidgetKey = Widgets.register<AbsoluteLayout>()

    let LayoutBounds =
        Attributes.defineBindable<Rectangle> AbsoluteLayout.LayoutBoundsProperty

    let LayoutFlags =
        Attributes.defineBindableEnum<AbsoluteLayoutFlags> AbsoluteLayout.LayoutFlagsProperty

[<AutoOpen>]
module AbsoluteLayoutBuilders =
    type Fabulous.XamarinForms.View with
        static member inline AbsoluteLayout<'msg>() =
            CollectionBuilder<'msg, IAbsoluteLayout, IView>(AbsoluteLayout.WidgetKey, LayoutOfView.Children)

[<Extension>]
type AbsoluteLayoutModifiers =
    /// <summary>Link a ViewRef to access the direct AbsoluteLayout control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IAbsoluteLayout>, value: ViewRef<AbsoluteLayout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type AbsoluteLayoutAttachedModifiers =
    /// <summary>Specify the bounding rectangle's position and dimensions. The first two values in the list must represent numbers. The latter two values may each either be numbers, or the value AbsoluteLayout.AutoSize</summary>
    /// <param name= "x">The x-coordinate of the bounding rectangle.</param>
    /// <param name= "y">The y-coordinate of the bounding rectangle.</param>
    /// <param name= "width">The width of the bounding rectangle.</param>
    /// <param name= "height">The height of the bounding rectangle.</param>
    [<Extension>]
    static member inline layoutBounds
        (
            this: WidgetBuilder<'msg, #IView>,
            x: float,
            y: float,
            width: float,
            height: float
        ) =
        this.AddScalar(AbsoluteLayout.LayoutBounds.WithValue(Rectangle(x, y, width, height)))

    /// <summary>Determines how the values in the list are interpreted to create the bounding rectangle.</summary>
    /// <param name= "value">AbsoluteLayoutFlags enumeration value: All, None, HeightProportional, WidthProportional, SizeProportional, XProportional, YProportional, or PositionProportional.</param>
    [<Extension>]
    static member inline layoutFlags(this: WidgetBuilder<'msg, #IView>, value: AbsoluteLayoutFlags) =
        this.AddScalar(AbsoluteLayout.LayoutFlags.WithValue(value))
