namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Shapes
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabRectangle =
    inherit IFabShape

module Rectangle =
    let WidgetKey = Widgets.register<Rectangle>()

    let RadiusX =
        Attributes.defineAvaloniaPropertyWithEquality Rectangle.RadiusXProperty

    let RadiusY =
        Attributes.defineAvaloniaPropertyWithEquality Rectangle.RadiusYProperty

[<AutoOpen>]
module RectangleBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Rectangle widget.</summary>
        /// <param name="radiusX">The radius on the X-axis used to round the corners of the rectangle.</param>
        /// <param name="radiusY">The radius on the Y-axis used to round the corners of the rectangle.</param>
        static member Rectangle(radiusX: float, radiusY: float) =
            WidgetBuilder<'msg, IFabRectangle>(Rectangle.WidgetKey, Rectangle.RadiusX.WithValue(radiusX), Rectangle.RadiusY.WithValue(radiusY))

        /// <summary>Creates a Rectangle widget.</summary>
        static member Rectangle() =
            WidgetBuilder<'msg, IFabRectangle>(Rectangle.WidgetKey)

type RectangleModifiers =
    /// <summary>Link a ViewRef to access the direct Rectangle control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRectangle>, value: ViewRef<Rectangle>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
