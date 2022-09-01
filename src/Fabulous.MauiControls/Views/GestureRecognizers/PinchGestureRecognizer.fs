namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls

type IPinchGestureRecognizer =
    inherit Fabulous.Maui.IGestureRecognizer

module PinchGestureRecognizer =
    let WidgetKey =
        Widgets.register<PinchGestureRecognizer>()

    let PinchUpdated =
        Attributes.defineEvent<PinchGestureUpdatedEventArgs>
            "PinchGestureRecognizer_PinchUpdated"
            (fun target -> (target :?> PinchGestureRecognizer).PinchUpdated)

[<AutoOpen>]
module PinchGestureRecognizerBuilders =
    type Fabulous.Maui.View with
        static member inline PinchGestureRecognizer<'msg>(onPinchUpdated: PinchGestureUpdatedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IPinchGestureRecognizer>(
                PinchGestureRecognizer.WidgetKey,
                PinchGestureRecognizer.PinchUpdated.WithValue(fun args -> onPinchUpdated args |> box)
            )
