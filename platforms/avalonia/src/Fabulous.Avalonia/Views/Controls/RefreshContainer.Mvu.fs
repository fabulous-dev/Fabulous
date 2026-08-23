namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuRefreshContainer =
    let RefreshRequested =
        Attributes.Mvu.defineEvent<RefreshRequestedEventArgs> "RefreshContainer_RefreshRequested" (fun target -> (target :?> RefreshContainer).RefreshRequested)

type MvuRefreshContainerModifiers =
    /// <summary>Listens the RefreshContainer RefreshRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the RefreshRequested event is fired.</param>
    [<Extension>]
    static member inline onRefreshRequested(this: WidgetBuilder<'msg, #IFabRefreshContainer>, fn: RefreshRequestedEventArgs -> 'msg) =
        this.AddScalar(MvuRefreshContainer.RefreshRequested.WithValue(fn))
