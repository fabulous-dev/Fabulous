namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia


module MvuRefreshVisualizer =
    let RefreshRequested =
        Attributes.Mvu.defineEvent<RefreshRequestedEventArgs> "RefreshVisualizer_RefreshRequested" (fun target ->
            (target :?> RefreshVisualizer).RefreshRequested)

type MvuRefreshVisualizerModifiers =
    /// <summary>Listens the RefreshVisualizer RefreshRequested event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the RefreshRequested event is fired.</param>
    [<Extension>]
    static member inline onRefreshRequested(this: WidgetBuilder<'msg, #IFabRefreshVisualizer>, fn: RefreshRequestedEventArgs -> 'msg) =
        this.AddScalar(MvuRefreshVisualizer.RefreshRequested.WithValue(fn))
