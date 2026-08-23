namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

type IFabSelectingItemsControl =
    inherit IFabItemsControl

module SelectingItemsControl =
    let AutoScrollToSelectedItem =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.AutoScrollToSelectedItemProperty

    let SelectedIndex =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.SelectedIndexProperty

    let SelectedItem =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.SelectedItemProperty

    let IsTextSearchEnabled =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.IsTextSearchEnabledProperty

    let WrapSelection =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.WrapSelectionProperty

    let IsSelected =
        Attributes.defineAvaloniaPropertyWithEquality SelectingItemsControl.IsSelectedProperty

type SelectingItemsControlModifiers =
    /// <summary>Sets the AutoScrollToSelectedItem property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AutoScrollToSelectedItem value.</param>
    [<Extension>]
    static member inline autoScrollToSelectedItem(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.AutoScrollToSelectedItem.WithValue(value))

    /// <summary>Sets the SelectedIndex property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectedIndex value.</param>
    [<Extension>]
    static member inline selectedIndex(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: int) =
        this.AddScalar(SelectingItemsControl.SelectedIndex.WithValue(value))

    /// <summary>Sets the SelectedItem property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectedItem value.</param>
    [<Extension>]
    static member inline selectedItem(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: obj) =
        this.AddScalar(SelectingItemsControl.SelectedItem.WithValue(value))

    /// <summary>Sets the IsTextSearchEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsTextSearchEnabled value.</param>
    [<Extension>]
    static member inline isTextSearchEnabled(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.IsTextSearchEnabled.WithValue(value))

    /// <summary>Sets the WrapSelection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The WrapSelection value.</param>
    [<Extension>]
    static member inline wrapSelection(this: WidgetBuilder<'msg, #IFabSelectingItemsControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.WrapSelection.WithValue(value))

    /// <summary>Sets the IsSelected property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsSelected value.</param>
    [<Extension>]
    static member inline isSelected(this: WidgetBuilder<'msg, #IFabControl>, value: bool) =
        this.AddScalar(SelectingItemsControl.IsSelected.WithValue(value))
