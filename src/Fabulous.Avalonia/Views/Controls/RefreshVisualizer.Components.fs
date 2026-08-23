namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentRefreshVisualizer =
    let RefreshRequested =
        Attributes.Component.defineEvent<RefreshRequestedEventArgs> "RefreshVisualizer_RefreshRequested" (fun target ->
            (target :?> RefreshVisualizer).RefreshRequested)

type ComponentRefreshVisualizerModifiers =
    /// <summary>Listens the RefreshVisualizer RefreshRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the RefreshRequested event is fired.</param>
    [<Extension>]
    static member inline onRefreshRequested(this: WidgetBuilder<'msg, #IFabRefreshVisualizer>, fn: RefreshRequestedEventArgs -> unit) =
        this.AddScalar(ComponentRefreshVisualizer.RefreshRequested.WithValue(fn))
