namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabDropGestureRecognizer =
    inherit IFabGestureRecognizer

module DropGestureRecognizer =
    let WidgetKey = Widgets.register<DropGestureRecognizer>()

    let AllowDrop =
        Attributes.defineBindableBool DropGestureRecognizer.AllowDropProperty

    let Drop =
        Attributes.Mvu.defineEvent<DropEventArgs> "DropGestureRecognizer_Drop" (fun target -> (target :?> DropGestureRecognizer).Drop)

    let DragOver =
        Attributes.Mvu.defineEvent<DragEventArgs> "DropGestureRecognizer_DragOver" (fun target -> (target :?> DropGestureRecognizer).DragOver)

    let DragLeave =
        Attributes.Mvu.defineEvent<DragEventArgs> "DropGestureRecognizer_DragLeave" (fun target -> (target :?> DropGestureRecognizer).DragLeave)

[<AutoOpen>]
module DropGestureRecognizerBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a DropGestureRecognizer that listens for Drop event</summary>
        /// <param name="onDrop">Message to dispatch</param>
        static member inline DropGestureRecognizer<'msg when 'msg: equality>(onDrop: DropEventArgs -> 'msg) =
            WidgetBuilder<'msg, IFabDropGestureRecognizer>(
                DropGestureRecognizer.WidgetKey,
                DropGestureRecognizer.Drop.WithValue(fun args -> onDrop args |> box)
            )

[<Extension>]
type DropGestureRecognizerModifiers =
    /// <summary>Set whether users are allowed to drop</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">true to allow users to drop; otherwise, false</param>
    [<Extension>]
    static member inline allowDrop(this: WidgetBuilder<'msg, #IFabDropGestureRecognizer>, value: bool) =
        this.AddScalar(DropGestureRecognizer.AllowDrop.WithValue(value))

    /// <summary>Listen for the DragOver event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onDragOver(this: WidgetBuilder<'msg, #IFabDropGestureRecognizer>, fn: DragEventArgs -> 'msg) =
        this.AddScalar(DropGestureRecognizer.DragOver.WithValue(fun args -> fn args |> box))

    /// <summary>Listen for the DragLeave event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onDragLeave(this: WidgetBuilder<'msg, #IFabDropGestureRecognizer>, fn: DragEventArgs -> 'msg) =
        this.AddScalar(DropGestureRecognizer.DragLeave.WithValue(fun args -> fn args |> box))

    /// <summary>Link a ViewRef to access the direct DropGestureRecognizer control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDropGestureRecognizer>, value: ViewRef<DropGestureRecognizer>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
