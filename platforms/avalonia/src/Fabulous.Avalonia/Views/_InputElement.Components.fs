namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Avalonia.Input.TextInput
open Avalonia.Interactivity
open Fabulous

module ComponentInputElement =

    let GotFocus =
        Attributes.Component.defineEvent<GotFocusEventArgs> "InputElement_GotFocus" (fun target -> (target :?> InputElement).GotFocus)

    let LostFocus =
        Attributes.Component.defineEvent<RoutedEventArgs> "InputElement_LostFocus" (fun target -> (target :?> InputElement).LostFocus)

    let KeyDown =
        Attributes.Component.defineEvent<KeyEventArgs> "InputElement_KeyDown" (fun target -> (target :?> InputElement).KeyDown)

    let KeyUp =
        Attributes.Component.defineEvent<KeyEventArgs> "InputElement_KeyUp" (fun target -> (target :?> InputElement).KeyUp)

    let TextInput =
        Attributes.Component.defineEvent<TextInputEventArgs> "InputElement_TextInput" (fun target -> (target :?> InputElement).TextInput)

    let TextInputMethodClientRequested =
        Attributes.Component.defineEvent<TextInputMethodClientRequestedEventArgs> "InputElement_TextInputMethodClientRequested" (fun target ->
            (target :?> InputElement).TextInputMethodClientRequested)

    let PointerEntered =
        Attributes.Component.defineEvent<PointerEventArgs> "InputElement_PointerEntered" (fun target -> (target :?> InputElement).PointerEntered)

    let PointerExited =
        Attributes.Component.defineEvent<PointerEventArgs> "InputElement_PointerExited" (fun target -> (target :?> InputElement).PointerExited)

    let PointerMoved =
        Attributes.Component.defineEvent<PointerEventArgs> "InputElement_PointerMoved" (fun target -> (target :?> InputElement).PointerMoved)

    let PointerPressed =
        Attributes.Component.defineEvent<PointerPressedEventArgs> "InputElement_PointerPressed" (fun target -> (target :?> InputElement).PointerPressed)

    let PointerReleased =
        Attributes.Component.defineEvent<PointerReleasedEventArgs> "InputElement_PointerReleased" (fun target -> (target :?> InputElement).PointerReleased)

    let PointerCaptureLost =
        Attributes.Component.defineEvent<PointerCaptureLostEventArgs> "InputElement_PointerCaptureLost" (fun target ->
            (target :?> InputElement).PointerCaptureLost)

    let PointerWheelChanged =
        Attributes.Component.defineEvent<PointerWheelEventArgs> "InputElement_PointerWheelChanged" (fun target -> (target :?> InputElement).PointerWheelChanged)

    let Tapped =
        Attributes.Component.defineEvent<TappedEventArgs> "InputElement_Tapped" (fun target -> (target :?> InputElement).Tapped)

    let Holding =
        Attributes.Component.defineEvent<HoldingRoutedEventArgs> "InputElement_Holding" (fun target -> (target :?> InputElement).Holding)

    let DoubleTapped =
        Attributes.Component.defineEvent<TappedEventArgs> "InputElement_DoubleTapped" (fun target -> (target :?> InputElement).DoubleTapped)

type ComponentInputElementModifiers =
    /// <summary>Listens to the InputElement GotFocus event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when control receives focus.</param>
    [<Extension>]
    static member inline onGotFocus(this: WidgetBuilder<'msg, #IFabInputElement>, fn: GotFocusEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.GotFocus.WithValue(fn))

    /// <summary>Listens to the InputElement LostFocus event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when control loses focus.</param>
    [<Extension>]
    static member inline onLostFocus(this: WidgetBuilder<'msg, #IFabInputElement>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.LostFocus.WithValue(fn))

    /// <summary>Listens to the InputElement KeyDown event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a key is pressed while the control has focus.</param>
    [<Extension>]
    static member inline onKeyDown(this: WidgetBuilder<'msg, #IFabInputElement>, fn: KeyEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.KeyDown.WithValue(fn))

    /// <summary>Listens to the InputElement KeyUp event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a key is released while the control has focus.</param>
    [<Extension>]
    static member inline onKeyUp(this: WidgetBuilder<'msg, #IFabInputElement>, fn: KeyEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.KeyUp.WithValue(fn))

    /// <summary>Listens to the InputElement TextInput event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a user typed some text while the control has focus.</param>
    [<Extension>]
    static member inline onTextInput(this: WidgetBuilder<'msg, #IFabInputElement>, fn: TextInputEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.TextInput.WithValue(fn))

    /// <summary>Listens to the InputElement TextInputMethodClientRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when an input element gains input focus and input method is looking for the corresponding client.</param>
    [<Extension>]
    static member inline onTextInputMethodClientRequested(this: WidgetBuilder<'msg, #IFabInputElement>, fn: TextInputMethodClientRequestedEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.TextInputMethodClientRequested.WithValue(fn))

    /// <summary>Listens to the InputElement PointerEntered event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when pointer enters the control.</param>
    [<Extension>]
    static member inline onPointerEntered(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.PointerEntered.WithValue(fn))

    /// <summary>Listens to the InputElement PointerExited event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when pointer leaves the control.</param>
    [<Extension>]
    static member inline onPointerExited(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.PointerExited.WithValue(fn))

    /// <summary>Listens to the InputElement PointerMoved event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when pointer moves over the control.</param>
    [<Extension>]
    static member inline onPointerMoved(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.PointerMoved.WithValue(fn))

    /// <summary>Listens to the InputElement PointerPressed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the pointer is pressed over the control.</param>
    [<Extension>]
    static member inline onPointerPressed(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerPressedEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.PointerPressed.WithValue(fn))

    /// <summary>Listens to the InputElement PointerReleased event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the pointer is released over the control.</param>
    [<Extension>]
    static member inline onPointerReleased(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerReleasedEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.PointerReleased.WithValue(fn))

    /// <summary>Listens to the InputElement PointerCaptureLost event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control or its child control loses the pointer capture for any reason event will not be triggered for a parent control if capture was transferred to another child of that parent control.</param>
    [<Extension>]
    static member inline onPointerCaptureLost(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerCaptureLostEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.PointerCaptureLost.WithValue(fn))

    /// <summary>Listens to the InputElement PointerWheelChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the pointer wheel changes.</param>
    [<Extension>]
    static member inline onPointerWheelChanged(this: WidgetBuilder<'msg, #IFabInputElement>, fn: PointerWheelEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.PointerWheelChanged.WithValue(fn))

    /// <summary>Listens to the InputElement Tapped event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a tap gesture occurs on the control.</param>
    [<Extension>]
    static member inline onTapped(this: WidgetBuilder<'msg, #IFabInputElement>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.Tapped.WithValue(fn))

    /// <summary>Listens to the InputElement Holding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a holding gesture occurs on the control.</param>
    [<Extension>]
    static member inline onHolding(this: WidgetBuilder<'msg, #IFabInputElement>, fn: HoldingRoutedEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.Holding.WithValue(fn))

    /// <summary>Listens to the InputElement RightTapped event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a double-tap gesture occurs on the control.</param>
    [<Extension>]
    static member inline onDoubleTapped(this: WidgetBuilder<'msg, #IFabInputElement>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentInputElement.DoubleTapped.WithValue(fn))
