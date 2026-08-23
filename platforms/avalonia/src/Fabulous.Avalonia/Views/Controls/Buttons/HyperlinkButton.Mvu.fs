namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList

module MvuHyperlinkButton =
    let IsVisitedChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "HyperlinkButton_VisitedChanged" HyperlinkButton.IsVisitedProperty

type MvuHyperlinkButtonModifiers =
    /// <summary>Listen to the HyperlinkButton IsVisitedChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsVisited value.</param>
    /// <param name="fn">Raised when the IsVisited value changes.</param>
    [<Extension>]
    static member inline onVisitedChanged(this: WidgetBuilder<'msg, #IFabHyperlinkButton>, value: bool, fn: bool -> 'msg) =
        this.AddScalar(MvuHyperlinkButton.IsVisitedChanged.WithValue(ValueEventData.create value fn))
