namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentScrollViewer =
    let ScrollChanged =
        Attributes.Component.defineEvent "ScrollViewer_ScrollChangedEvent" (fun target -> (target :?> ScrollViewer).ScrollChanged)

type ComponentScrollViewerModifiers =
    /// <summary>Listens to the ScrollViewer ScrollChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ScrollChanged event fires.</param>
    [<Extension>]
    static member inline onScrollChanged(this: WidgetBuilder<'msg, #IFabScrollViewer>, fn: ScrollChangedEventArgs -> unit) =
        this.AddScalar(ComponentScrollViewer.ScrollChanged.WithValue(fn))
