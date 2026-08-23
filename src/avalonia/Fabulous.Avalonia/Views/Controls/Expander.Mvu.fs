namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Interactivity
open Fabulous
open Fabulous.Avalonia

module MvuExpander =
    let Expanded =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "Expander_IsExpandedChanged" Expander.IsExpandedProperty

    let Collapsing =
        Attributes.Mvu.defineEvent "Expander_Collapsing" (fun target -> (target :?> Expander).Collapsing)

    let Expanding =
        Attributes.Mvu.defineEvent "Expander_Expanding" (fun target -> (target :?> Expander).Expanding)

type MvuExpanderModifiers =
    /// <summary>Listens to the Expander ExpandedChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="isExpanded">The IsExpanded value.</param>
    /// <param name="fn">Raised when the ExpandedChanged event fires.</param>
    [<Extension>]
    static member inline onExpandedChanged(this: WidgetBuilder<'msg, #IFabExpander>, isExpanded: bool, fn: bool -> 'msg) =
        this.AddScalar(MvuExpander.Expanded.WithValue(ValueEventData.create isExpanded fn))

    /// <summary>Listens to the Expander Collapsing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Collapsing event fires.</param>
    [<Extension>]
    static member inline onCollapsing(this: WidgetBuilder<'msg, #IFabExpander>, fn: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(MvuExpander.Collapsing.WithValue(fn))

    /// <summary>Listens to the Expander Expanding event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Expanding event fires.</param>
    [<Extension>]
    static member inline onExpanding(this: WidgetBuilder<'msg, #IFabExpander>, fn: CancelRoutedEventArgs -> 'msg) =
        this.AddScalar(MvuExpander.Expanding.WithValue(fn))
