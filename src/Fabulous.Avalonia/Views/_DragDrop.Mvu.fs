namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia

module MvuDragDrop =
    let DragEnter =
        Attributes.Mvu.defineRoutedEvent<DragEventArgs> "DragDrop_DragEnter" DragDrop.DragEnterEvent

    let DragLeave =
        Attributes.Mvu.defineRoutedEvent<DragEventArgs> "DragDrop_DragLeave" DragDrop.DragLeaveEvent

    let DragOver =
        Attributes.Mvu.defineRoutedEvent<DragEventArgs> "DragDrop_DragOver" DragDrop.DragOverEvent

    let Drop =
        Attributes.Mvu.defineRoutedEvent<DragEventArgs> "DragDrop_Drop" DragDrop.DropEvent

type MvuDragDropModifiers =
    /// <summary>Listens to the DragDrop DragEnter event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation enters the element.</param>
    [<Extension>]
    static member inline onDragEnter(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> 'msg) =
        this.AddScalar(MvuDragDrop.DragEnter.WithValue(fn))

    /// <summary>Listens to the DragDrop DragLeave event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation leaves the element.</param>
    [<Extension>]
    static member inline onDragLeave(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> 'msg) =
        this.AddScalar(MvuDragDrop.DragLeave.WithValue(fn))

    /// <summary>Listens to the DragDrop DragOver event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation is in progress over the element.</param>
    [<Extension>]
    static member inline onDragOver(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> 'msg) =
        this.AddScalar(MvuDragDrop.DragOver.WithValue(fn))

    /// <summary>Listens to the DragDrop Drop event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation is dropped on the element.</param>
    [<Extension>]
    static member inline onDrop(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> 'msg) =
        this.AddScalar(MvuDragDrop.Drop.WithValue(fn))
