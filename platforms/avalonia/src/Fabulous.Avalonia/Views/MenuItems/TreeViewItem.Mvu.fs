namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Fabulous

module MvuTreeViewItem =
    let Expanded =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent' "TreeViewItem_Expanded" TreeViewItem.IsExpandedProperty

type MvuTreeViewItemModifiers =
    /// <summary>Listens to the TreeViewItem Expanded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Whether the TreeViewItem is expanded.</param>
    /// <param name="fn">Raised when the Expanded event is fired.</param>
    [<Extension>]
    static member inline onExpandedChanged(this: WidgetBuilder<'msg, #IFabTreeViewItem>, value: bool, fn: bool -> 'msg) =
        this.AddScalar(MvuTreeViewItem.Expanded.WithValue(ValueEventData.create value fn))
