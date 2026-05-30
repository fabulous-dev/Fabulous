namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabDragGestureRecognizer =
    inherit IFabGestureRecognizer

module DragGestureRecognizer =
    let WidgetKey = Widgets.register<DragGestureRecognizer>()

    let CanDrag = Attributes.defineBindableBool DragGestureRecognizer.CanDragProperty

    let DragStarting =
        Attributes.Mvu.defineEvent<DragStartingEventArgs> "DragGestureRecognizer_DragStarting" (fun target -> (target :?> DragGestureRecognizer).DragStarting)

    let DropCompleted =
        Attributes.Mvu.defineEvent<DropCompletedEventArgs> "DragGestureRecognizer_DropCompleted" (fun target -> (target :?> DragGestureRecognizer).DropCompleted)

[<AutoOpen>]
module DragGestureRecognizerBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a DragGestureRecognizer that listens for DragStarting event</summary>
        /// <param name="onDragStarting">Message to dispatch</param>
        static member inline DragGestureRecognizer<'msg when 'msg: equality>(onDragStarting: DragStartingEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabDragGestureRecognizer>(
                DragGestureRecognizer.WidgetKey,
                DragGestureRecognizer.DragStarting.WithValue(fun args -> onDragStarting args |> box)
            )

[<Extension>]
type DragGestureRecognizerModifiers =
    /// <summary>Set whether users are allowed to drag</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true to allow users to drag; otherwise, false</param>
    [<Extension>]
    static member inline canDrag(this: WidgetBuilder<'msg, #IFabDragGestureRecognizer>, value: bool) =
        this.AddScalar(DragGestureRecognizer.CanDrag.WithValue(value))

    /// <summary>Listen for DropCompleted event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onDropCompleted(this: WidgetBuilder<'msg, #IFabDragGestureRecognizer>, msg: 'msg) =
        this.AddScalar(DragGestureRecognizer.DropCompleted.WithValue(fun _ -> box msg))

    /// <summary>Link a ViewRef to access the direct DragGestureRecognizer control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDragGestureRecognizer>, value: ViewRef<DragGestureRecognizer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
