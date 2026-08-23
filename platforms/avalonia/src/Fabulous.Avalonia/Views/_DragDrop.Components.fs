namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia

module ComponentDragDrop =
    let DragEnter =
        Attributes.Component.defineRoutedEvent<DragEventArgs> "DragDrop_DragEnter" DragDrop.DragEnterEvent

    let DragLeave =
        Attributes.Component.defineRoutedEvent<DragEventArgs> "DragDrop_DragLeave" DragDrop.DragLeaveEvent

    let DragOver =
        Attributes.Component.defineRoutedEvent<DragEventArgs> "DragDrop_DragOver" DragDrop.DragOverEvent

    let Drop =
        Attributes.Component.defineRoutedEvent<DragEventArgs> "DragDrop_Drop" DragDrop.DropEvent

type ComponentDragDropModifiers =
    /// <summary>Listens to the DragDrop DragEnter event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation enters the element.</param>
    [<Extension>]
    static member inline onDragEnter(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> unit) =
        this.AddScalar(ComponentDragDrop.DragEnter.WithValue(fn))

    /// <summary>Listens to the DragDrop DragLeave event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation leaves the element.</param>
    [<Extension>]
    static member inline onDragLeave(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> unit) =
        this.AddScalar(ComponentDragDrop.DragLeave.WithValue(fn))

    /// <summary>Listens to the DragDrop DragOver event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation is in progress over the element.</param>
    [<Extension>]
    static member inline onDragOver(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> unit) =
        this.AddScalar(ComponentDragDrop.DragOver.WithValue(fn))

    /// <summary>Listens to the DragDrop Drop event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when a drag-and-drop operation is dropped on the element.</param>
    [<Extension>]
    static member inline onDrop(this: WidgetBuilder<'msg, #IFabInteractive>, fn: DragEventArgs -> unit) =
        this.AddScalar(ComponentDragDrop.Drop.WithValue(fn))
