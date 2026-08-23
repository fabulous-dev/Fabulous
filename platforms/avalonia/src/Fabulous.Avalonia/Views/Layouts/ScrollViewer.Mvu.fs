namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuScrollViewer =
    let ScrollChanged =
        Attributes.Mvu.defineEvent "ScrollViewer_ScrollChangedEvent" (fun target -> (target :?> ScrollViewer).ScrollChanged)

type MvuScrollViewerModifiers =
    /// <summary>Listens to the ScrollViewer ScrollChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ScrollChanged event fires.</param>
    [<Extension>]
    static member inline onScrollChanged(this: WidgetBuilder<'msg, #IFabScrollViewer>, fn: ScrollChangedEventArgs -> 'msg) =
        this.AddScalar(MvuScrollViewer.ScrollChanged.WithValue(fn))
