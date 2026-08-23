namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Input
open Fabulous
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList


module ComponentThumb =
    let DragStarted =
        Attributes.Mvu.defineEvent<VectorEventArgs> "Thumb_DragStarted" (fun target -> (target :?> Thumb).DragStarted)

    let DragDelta =
        Attributes.Mvu.defineEvent<VectorEventArgs> "Thumb_DragDelta" (fun target -> (target :?> Thumb).DragDelta)

    let DragCompleted =
        Attributes.Mvu.defineEvent<VectorEventArgs> "Thumb_DragCompleted" (fun target -> (target :?> Thumb).DragCompleted)

type ComponentThumbModifiers =

    /// <summary>Listens to the Thumb DragStarted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Thumb dragged started.</param>
    [<Extension>]
    static member inline onDragStarted(this: WidgetBuilder<'msg, #IFabThumb>, fn: VectorEventArgs -> unit) =
        this.AddScalar(ComponentThumb.DragStarted.WithValue(fn))

    /// <summary>Listens to the Thumb DragDelta event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Thumb dragged.</param>
    [<Extension>]
    static member inline onDragDelta(this: WidgetBuilder<'msg, #IFabThumb>, fn: VectorEventArgs -> unit) =
        this.AddScalar(ComponentThumb.DragDelta.WithValue(fn))

    /// <summary>Listens to the Thumb DragCompleted event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Thumb dragged is completed.</param>
    [<Extension>]
    static member inline onDragCompleted(this: WidgetBuilder<'msg, #IFabThumb>, fn: VectorEventArgs -> unit) =
        this.AddScalar(ComponentThumb.DragCompleted.WithValue(fn))
