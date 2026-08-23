namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabPinchGestureRecognizer =
    inherit IFabGestureRecognizer

module PinchGestureRecognizer =
    let WidgetKey = Widgets.register<PinchGestureRecognizer>()

    let PinchUpdated =
        Attributes.Mvu.defineEvent<PinchGestureUpdatedEventArgs> "PinchGestureRecognizer_PinchUpdated" (fun target ->
            (target :?> PinchGestureRecognizer).PinchUpdated)

[<AutoOpen>]
module PinchGestureRecognizerBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a PinchGestureRecognizer that listens for Pinch event</summary>
        /// <param name="onPinchUpdated">Message to dispatch</param>
        static member inline PinchGestureRecognizer<'msg when 'msg: equality>(onPinchUpdated: PinchGestureUpdatedEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabPinchGestureRecognizer>(
                PinchGestureRecognizer.WidgetKey,
                PinchGestureRecognizer.PinchUpdated.WithValue(fun args -> onPinchUpdated args |> box)
            )

[<Extension>]
type PinchGestureRecognizerModifiers =
    /// <summary>Link a ViewRef to access the direct PinchGestureRecognizer control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabPinchGestureRecognizer>, value: ViewRef<PinchGestureRecognizer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
