namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms.Shapes

type ITranslateTransform =
    inherit ITransform

module TranslateTransform =
    let WidgetKey = Widgets.register<TranslateTransform>()

    let X =
        Attributes.defineBindable<float> TranslateTransform.XProperty

    let Y =
        Attributes.defineBindable<float> TranslateTransform.YProperty

[<AutoOpen>]
module TranslateTransformBuilders =

    type Fabulous.XamarinForms.View with
        static member inline TranslateTransform<'msg>(x: float, y: float) =
            WidgetBuilder<'msg, ITranslateTransform>(
                TranslateTransform.WidgetKey,
                TranslateTransform.X.WithValue(x),
                TranslateTransform.Y.WithValue(y)
            )
