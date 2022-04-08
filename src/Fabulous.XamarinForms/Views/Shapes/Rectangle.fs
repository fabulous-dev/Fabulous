namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Xamarin.Forms
open Xamarin.Forms.Shapes

type IRectangle =
    inherit IShape

module Rectangle =

    let WidgetKey = Widgets.register<Rectangle>()

    let RadiusX =
        Attributes.defineBindable<float> Rectangle.RadiusXProperty

    let RadiusY =
        Attributes.defineBindable<float> Rectangle.RadiusYProperty

[<AutoOpen>]
module RectangleBuilders =

    type Fabulous.XamarinForms.View with
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
