namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IDragGestureRecognizer =
    inherit Fabulous.XamarinForms.IGestureRecognizer

module DragGestureRecognizer =
    let WidgetKey =
        Widgets.register<DragGestureRecognizer>()

    let CanDrag =
        Attributes.defineBindable<bool> DragGestureRecognizer.CanDragProperty

    let DragStarting =
        Attributes.defineEvent<DragStartingEventArgs>
            "DragGestureRecognizer_DragStarting"
            (fun target -> (target :?> DragGestureRecognizer).DragStarting)

    let DropCompleted =
        Attributes.defineEvent<DropCompletedEventArgs>
            "DragGestureRecognizer_DropCompleted"
            (fun target -> (target :?> DragGestureRecognizer).DropCompleted)


[<AutoOpen>]
module DragGestureRecognizerBuilders =
    type Fabulous.XamarinForms.View with
        static member inline DragGestureRecognizer<'msg>(onDragStarting: DragStartingEventArgs -> 'msg) =
            WidgetBuilder<'msg, IDragGestureRecognizer>(
                DragGestureRecognizer.WidgetKey,
                DragGestureRecognizer.DragStarting.WithValue(fun args -> onDragStarting args |> box)
            )

[<Extension>]
type DragGestureRecognizerModifiers =

    /// <summary>Sets whether users are allowed to drag</summary>
    /// <param name="value">true to allow users to drag; otherwise, false</param>
    [<Extension>]
    static member inline canDrag(this: WidgetBuilder<'msg, #IDragGestureRecognizer>, value: bool) =
        this.AddScalar(DragGestureRecognizer.CanDrag.WithValue(value))

    [<Extension>]
    static member inline onDropCompleted(this: WidgetBuilder<'msg, #IDragGestureRecognizer>, onDropCompleted: 'msg) =
        this.AddScalar(DragGestureRecognizer.DropCompleted.WithValue(fun _ -> onDropCompleted |> box))
