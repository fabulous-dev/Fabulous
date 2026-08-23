namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

module ComponentSelectingItemsControl =
    let SelectionChanged =
        Attributes.Component.defineEvent<SelectionChangedEventArgs> "SelectingItemsControl_SelectionChanged" (fun target ->
            (target :?> SelectingItemsControl).SelectionChanged)

    let SelectedIndexChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "SelectingItemsControl_SelectedIndexChanged" SelectingItemsControl.SelectedIndexProperty

    let SelectedChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "SelectingItemsControl_SelectedChanged" SelectingItemsControl.IsSelectedProperty

type ComponentSelectingItemsControlModifiers =
    /// <summary>Listens to the SelectingItemsControl SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the control's selection changes.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, fn: SelectionChangedEventArgs -> unit) =
        this.AddScalar(ComponentSelectingItemsControl.SelectionChanged.WithValue(fn))

    /// <summary>Listens to the SelectingItemsControl SelectedIndexChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="index">Selected index</param>
    /// <param name="fn">Raised when the control's selected index changes.</param>
    [<Extension>]
    static member inline onSelectedIndexChanged(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, index: int, fn: int -> unit) =
        this.AddScalar(ComponentSelectingItemsControl.SelectedIndexChanged.WithValue(ComponentValueEventData.create index fn))

type ComponentSelectingItemsControlAttachedModifiers =
    /// <summary>Listens to the SelectingItemsControl SelectedChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Selected value</param>
    /// <param name="fn">Raised when the control's selected value changes.</param>
    [<Extension>]
    static member inline onSelectedChanged(this: WidgetBuilder<'msg, #IFabControl>, value: bool, fn: bool -> unit) =
        this.AddScalar(ComponentSelectingItemsControl.SelectedChanged.WithValue(ComponentValueEventData.create value fn))
