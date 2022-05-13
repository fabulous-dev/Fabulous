namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IDropGestureRecognizer =
    inherit Fabulous.XamarinForms.IGestureRecognizer

module DropGestureRecognizer =
    let WidgetKey =
        Widgets.register<DropGestureRecognizer>()

    let AllowDrop =
        Attributes.defineBindableBool DropGestureRecognizer.AllowDropProperty

    let Drop =
        Attributes.defineEvent<DropEventArgs>
            "DropGestureRecognizer_Drop"
            (fun target -> (target :?> DropGestureRecognizer).Drop)

    let DragOver =
        Attributes.defineEvent<DragEventArgs>
            "DropGestureRecognizer_DragOver"
            (fun target -> (target :?> DropGestureRecognizer).DragOver)

    let DragLeave =
        Attributes.defineEvent<DragEventArgs>
            "DropGestureRecognizer_DragLeave"
            (fun target -> (target :?> DropGestureRecognizer).DragLeave)

[<AutoOpen>]
module DropGestureRecognizerBuilders =
    type Fabulous.XamarinForms.View with
        static member inline DropGestureRecognizer<'msg>(onDrop: DropEventArgs -> 'msg) =
            WidgetBuilder<'msg, IDropGestureRecognizer>(
                DropGestureRecognizer.WidgetKey,
                DropGestureRecognizer.Drop.WithValue(fun args -> onDrop args |> box)
            )

[<Extension>]
type DropGestureRecognizerModifiers =

    /// <summary>Sets whether users are allowed to drop</summary>
    /// <param name="value">true to allow users to drop; otherwise, false</param>
    [<Extension>]
    static member inline allowDrop(this: WidgetBuilder<'msg, #IDropGestureRecognizer>, value: bool) =
        this.AddScalar(DropGestureRecognizer.AllowDrop.WithValue(value))

    [<Extension>]
    static member inline onDragOver
        (
            this: WidgetBuilder<'msg, #IDropGestureRecognizer>,
            onDragOver: DragEventArgs -> 'msg
        ) =
        this.AddScalar(DropGestureRecognizer.DragOver.WithValue(fun args -> onDragOver args |> box))

    [<Extension>]
    static member inline onDragLeave
        (
            this: WidgetBuilder<'msg, #IDropGestureRecognizer>,
            onDragLeave: DragEventArgs -> 'msg
        ) =
        this.AddScalar(DropGestureRecognizer.DragLeave.WithValue(fun args -> onDragLeave args |> box))
