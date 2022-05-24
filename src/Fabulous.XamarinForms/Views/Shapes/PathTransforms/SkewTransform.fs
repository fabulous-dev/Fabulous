namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms.Shapes

type ISkewTransform =
    inherit ITransform

module SkewTransform =
    let WidgetKey = Widgets.register<SkewTransform>()

    let AnglesXY =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)>
            "SkewTransform_Angles"
            (fun _ newValueOpt node ->
                let line = node.Target :?> SkewTransform

                match newValueOpt with
                | ValueNone ->
                    line.AngleX <- 0.
                    line.AngleY <- 0.
                | ValueSome (x, y) ->
                    line.AngleX <- x
                    line.AngleY <- y)

    let CenterX =
        Attributes.defineBindableFloat ScaleTransform.CenterXProperty

    let CenterY =
        Attributes.defineBindableFloat ScaleTransform.CenterYProperty

[<AutoOpen>]
module SkewTransformBuilders =

    type Fabulous.XamarinForms.View with
        static member inline SkewTransform<'msg>(angleX: float, angleY: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, ISkewTransform>(
                SkewTransform.WidgetKey,
                SkewTransform.AnglesXY.WithValue((angleX, angleY)),
                SkewTransform.CenterX.WithValue(centerX),
                SkewTransform.CenterY.WithValue(centerY)
            )
