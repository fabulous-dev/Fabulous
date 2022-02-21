namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms.Shapes

type IRotateTransform =
    inherit ITransform

module RotateTransform =
    let WidgetKey = Widgets.register<RotateTransform> ()

    let Angle =
        Attributes.defineBindable<float> RotateTransform.AngleProperty

    let CenterX =
        Attributes.defineBindable<float> RotateTransform.CenterXProperty

    let CenterY =
        Attributes.defineBindable<float> RotateTransform.CenterYProperty

[<AutoOpen>]
module RotateTransformBuilders =

    type Fabulous.XamarinForms.View with
        static member inline RotateTransform<'msg>(angle: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IRotateTransform>(
                RotateTransform.WidgetKey,
                RotateTransform.Angle.WithValue(angle),
                RotateTransform.CenterX.WithValue(centerX),
                RotateTransform.CenterY.WithValue(centerY)
            )
