namespace Gallery

open System
open System.Diagnostics
open System.Numerics
open Avalonia
open Avalonia.Animation
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Rendering.Composition
open Avalonia.Rendering.Composition.Animations
open Fabulous
open Fabulous.Avalonia


open type Fabulous.Avalonia.View

module Vector3KeyFrameAnimation =
    type Model = { Value: int }

    type Msg = OnAttachedToVisualTree of VisualTreeAttachmentEventArgs

    let init () = { Value = 0 }, Cmd.none

    let Apply (visual: Border) =

        let compositionVisual = ElementComposition.GetElementVisual(visual)

        if (compositionVisual <> null) then
            let compositor = compositionVisual.Compositor

            let animation = compositor.CreateVector3KeyFrameAnimation()
            animation.InsertKeyFrame(1f, Vector3(200f, 0f, 0f))
            animation.Direction <- PlaybackDirection.Alternate
            animation.Duration <- TimeSpan.FromSeconds(2)
            animation.IterationBehavior <- AnimationIterationBehavior.Count
            animation.IterationCount <- Int32.MaxValue

            compositionVisual.StartAnimation("Offset", animation)

    let borderRef = ViewRef<Border>()

    let update msg model =
        match msg with
        | OnAttachedToVisualTree _ ->
            Apply borderRef.Value
            model, Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("Vector3KeyFrameAnimation") {
            (Canvas() {
                Border()
                    .background(Brushes.Red)
                    .width(100.)
                    .height(100.)
                    .reference(borderRef)
                    .onAttachedToVisualTree(OnAttachedToVisualTree)
            })
                .background(SolidColorBrush(Colors.WhiteSmoke))
        }
