namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuTreeView =
    let SelectionChanged =
        Attributes.Mvu.defineEvent "TreeView_SelectionChanged" (fun target -> (target :?> TreeView).SelectionChanged)

type MvuTreeViewModifiers =
    /// <summary>Listens to the TreeView SelectionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the TreeView SelectionChanged event is fired.</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, #IFabTreeView>, fn: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(MvuTreeView.SelectionChanged.WithValue(fn))
