namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

module ComponentControl =

    let RequestBringIntoView =
        Attributes.Component.defineRoutedEvent "Control_RequestBringIntoView" Control.RequestBringIntoViewEvent

    let ContextRequested =
        Attributes.Component.defineEvent "Control_ContextRequested" (fun target -> (target :?> Control).ContextRequested)

    let Loaded =
        Attributes.Component.defineEvent "Control_Loaded" (fun target -> (target :?> Control).Loaded)

    let UnLoaded =
        Attributes.Component.defineEvent "Control_UnLoaded" (fun target -> (target :?> Control).Unloaded)

    let SizeChanged =
        Attributes.Component.defineEvent "Control_SizeChanged" (fun target -> (target :?> Control).SizeChanged)

type ComponentControlModifiers =
    /// <summary>Listens to the Control ContextRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the user has completed a context input gesture, such as a right-click.</param>
    [<Extension>]
    static member inline onContextRequested(this: WidgetBuilder<'msg, #IFabControl>, fn: ContextRequestedEventArgs -> unit) =
        this.AddScalar(ComponentControl.ContextRequested.WithValue(fn))

    /// <summary>Listens to the Control RequestBringIntoView event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when an element wishes to be scrolled into view.</param>
    [<Extension>]
    static member inline onRequestBringIntoView(this: WidgetBuilder<'msg, #IFabControl>, fn: RequestBringIntoViewEventArgs -> unit) =
        this.AddScalar(ComponentControl.RequestBringIntoView.WithValue(fn))

    /// <summary>Listens to the Control Loaded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control has been fully constructed in the visual tree and both
    /// layout and render are complete.</param>
    [<Extension>]
    static member inline onLoaded(this: WidgetBuilder<'msg, #IFabControl>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentControl.Loaded.WithValue(fn))

    /// <summary>Listens to the Control UnLoaded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control is removed from the visual tree.</param>
    [<Extension>]
    static member inline onUnLoaded(this: WidgetBuilder<'msg, #IFabControl>, fn: RoutedEventArgs -> unit) =
        this.AddScalar(ComponentControl.UnLoaded.WithValue(fn))

    /// <summary>Listens to the Control SizeChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control's size changes.</param>
    [<Extension>]
    static member inline onSizeChanged(this: WidgetBuilder<'msg, #IFabControl>, fn: SizeChangedEventArgs -> unit) =
        this.AddScalar(ComponentControl.SizeChanged.WithValue(fn))
