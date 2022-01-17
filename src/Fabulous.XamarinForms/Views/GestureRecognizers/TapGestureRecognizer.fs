namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type ITapGestureRecognizer =
    inherit Fabulous.XamarinForms.IGestureRecognizer

module TapGestureRecognizer =
    let WidgetKey =
        Widgets.register<TapGestureRecognizer> ()

    let Tapped =
        Attributes.defineEventNoArg
            "TapGestureRecognizer_Tapped"
            (fun target -> (target :?> TapGestureRecognizer).Tapped)

[<AutoOpen>]
module TapGestureRecognizerBuilders =
    type Fabulous.XamarinForms.View with
        static member inline TapGestureRecognizer<'msg>(onTapped: 'msg) =
            WidgetBuilder<'msg, ITapGestureRecognizer>(
                TapGestureRecognizer.WidgetKey,
                TapGestureRecognizer.Tapped.WithValue(onTapped)
            )
