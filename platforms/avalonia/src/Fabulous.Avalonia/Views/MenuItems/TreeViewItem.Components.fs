namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls

open Avalonia.Interactivity
open Fabulous

module ComponentTreeViewItem =
    let Expanded =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent' "TreeViewItem_Expanded" TreeViewItem.IsExpandedProperty

type ComponentTreeViewItemModifiers =
    /// <summary>Listens to the TreeViewItem Expanded event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">Whether the TreeViewItem is expanded.</param>
    /// <param name="fn">Raised when the Expanded event is fired.</param>
    [<Extension>]
    static member inline onExpandedChanged(this: WidgetBuilder<'msg, #IFabTreeViewItem>, value: bool, fn: bool -> unit) =
        this.AddScalar(ComponentTreeViewItem.Expanded.WithValue(ComponentValueEventData.create value fn))
