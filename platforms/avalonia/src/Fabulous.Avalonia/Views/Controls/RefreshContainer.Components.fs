namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia


module ComponentRefreshContainer =
    let RefreshRequested =
        Attributes.Component.defineEvent<RefreshRequestedEventArgs> "RefreshContainer_RefreshRequested" (fun target ->
            (target :?> RefreshContainer).RefreshRequested)

type ComponentRefreshContainerModifiers =
    /// <summary>Listens the RefreshContainer RefreshRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the RefreshRequested event is fired.</param>
    [<Extension>]
    static member inline onRefreshRequested(this: WidgetBuilder<'msg, #IFabRefreshContainer>, fn: RefreshRequestedEventArgs -> unit) =
        this.AddScalar(ComponentRefreshContainer.RefreshRequested.WithValue(fn))
