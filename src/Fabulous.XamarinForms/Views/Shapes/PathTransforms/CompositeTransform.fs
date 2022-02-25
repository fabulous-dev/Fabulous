namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms.Shapes

type ICompositeTransform =
    inherit ITransform

module CompositeTransform =
    let WidgetKey = Widgets.register<CompositeTransform> ()

    let CenterXY =
        Attributes.define<struct (float * float)>
            "CompositeTransform_CenterXY"
            (fun newValueOpt node ->
                let line = node.Target :?> CompositeTransform

                match newValueOpt with
                | ValueNone ->
                    line.CenterX <- 0
                    line.CenterY <- 0
                | ValueSome (x, y) ->
                    line.CenterX <- x
                    line.CenterY <- y)

    let ScaleXY =
        Attributes.define<struct (float * float)>
            "CompositeTransform_ScaleXY"
            (fun newValueOpt node ->
                let line = node.Target :?> CompositeTransform

                match newValueOpt with
                | ValueNone ->
                    line.ScaleX <- 0
                    line.ScaleY <- 0
                | ValueSome (x, y) ->
                    line.ScaleX <- x
                    line.ScaleY <- y)

    let SkewXY =
        Attributes.define<struct (float * float)>
            "CompositeTransform_SkewXY"
            (fun newValueOpt node ->
                let line = node.Target :?> CompositeTransform

                match newValueOpt with
                | ValueNone ->
                    line.SkewX <- 0
                    line.SkewY <- 0
                | ValueSome (x, y) ->
                    line.SkewX <- x
                    line.SkewY <- y)

    let TranslateXY =
        Attributes.define<struct (float * float)>
            "CompositeTransform_TranslateXY"
            (fun newValueOpt node ->
                let line = node.Target :?> CompositeTransform

                match newValueOpt with
                | ValueNone ->
                    line.TranslateX <- 0
                    line.TranslateY <- 0
                | ValueSome (x, y) ->
                    line.TranslateX <- x
                    line.TranslateY <- y)

    let Rotation =
        Attributes.defineBindable<float> CompositeTransform.RotationProperty

[<AutoOpen>]
module CompositeTransformBuilders =

    type Fabulous.XamarinForms.View with
        static member inline CompositeTransform<'msg>
            (
                centerX: float,
                centerY: float,
                scaleX: float,
                scaleY: float,
                skewX: float,
                skewY: float
            ) =
            WidgetBuilder<'msg, ICompositeTransform>(
                CompositeTransform.WidgetKey,
                CompositeTransform.CenterXY.WithValue((centerX, centerY)),
                CompositeTransform.ScaleXY.WithValue((scaleX, scaleY)),
                CompositeTransform.SkewXY.WithValue((skewX, skewY))
            )

[<Extension>]
type CompositeTransformModifiers =

    [<Extension>]
    static member inline translate(this: WidgetBuilder<'msg, #ICompositeTransform>, x: float, y: float) =
        this.AddScalar(CompositeTransform.TranslateXY.WithValue((x, y)))

    [<Extension>]
    static member inline rotation(this: WidgetBuilder<'msg, #ICompositeTransform>, angle: float) =
        this.AddScalar(CompositeTransform.Rotation.WithValue(angle))
