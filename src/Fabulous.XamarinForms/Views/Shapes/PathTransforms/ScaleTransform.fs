namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms.Shapes

type IScaleTransform =
    inherit ITransform

module ScaleTransform =
    let WidgetKey = Widgets.register<ScaleTransform> ()

    let ScaleXY =
        Attributes.define<struct (float * float)>
            "ScaleTransform_Scale"
            (fun newValueOpt node ->
                let line = node.Target :?> ScaleTransform

                match newValueOpt with
                | ValueNone ->
                    line.ScaleX <- 0
                    line.ScaleY <- 0
                | ValueSome (x, y) ->
                    line.ScaleX <- x
                    line.ScaleY <- y)

    let CenterX =
        Attributes.defineBindable<float> ScaleTransform.CenterXProperty

    let CenterY =
        Attributes.defineBindable<float> ScaleTransform.CenterYProperty

[<AutoOpen>]
module ScaleTransformBuilders =

    type Fabulous.XamarinForms.View with
        static member inline ScaleTransform<'msg>(scaleX: float, scaleY: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IScaleTransform>(
                ScaleTransform.WidgetKey,
                ScaleTransform.ScaleXY.WithValue((scaleX, scaleY)),
                ScaleTransform.CenterX.WithValue(centerX),
                ScaleTransform.CenterY.WithValue(centerY)
            )
