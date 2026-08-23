namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentHyperlinkButton =
    let IsVisitedChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "HyperlinkButton_VisitedChanged" HyperlinkButton.IsVisitedProperty

type ComponentHyperlinkButtonModifiers =
    /// <summary>Listen to the HyperlinkButton IsVisitedChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsVisited value.</param>
    /// <param name="fn">Raised when the IsVisited value changes.</param>
    [<Extension>]
    static member inline onVisitedChanged(this: WidgetBuilder<'msg, #IFabHyperlinkButton>, value: bool, fn: bool -> unit) =
        this.AddScalar(ComponentHyperlinkButton.IsVisitedChanged.WithValue(ComponentValueEventData.create value fn))
