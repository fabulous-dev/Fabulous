namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes

type IRectangle =
    inherit Fabulous.Maui.IShape

module Rectangle =

    let WidgetKey = Widgets.register<Rectangle>()

    let RadiusX =
        Attributes.defineBindableFloat Rectangle.RadiusXProperty

    let RadiusY =
        Attributes.defineBindableFloat Rectangle.RadiusYProperty

[<AutoOpen>]
module RectangleBuilders =

    type Fabulous.Maui.View with
        static member inline Rectangle<'msg>(strokeThickness: float, strokeLight: Brush, ?strokeDark: Brush) =
            WidgetBuilder<'msg, IRectangle>(
                Rectangle.WidgetKey,
                Shape.StrokeThickness.WithValue(strokeThickness),
                Shape.Stroke.WithValue(AppTheme.create strokeLight strokeDark)
            )

[<Extension>]
type RectangleModifiers =

    [<Extension>]
    static member inline radius(this: WidgetBuilder<'msg, #IRectangle>, x: float, y: float) =
        this
            .AddScalar(Rectangle.RadiusX.WithValue(x))
            .AddScalar(Rectangle.RadiusY.WithValue(y))

    /// <summary>Link a ViewRef to access the direct Rectangle control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IRectangle>, value: ViewRef<Rectangle>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
