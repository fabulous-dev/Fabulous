namespace Gallery

open System.Diagnostics
open Avalonia
open Avalonia.Controls


open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Avalonia.Rendering.Composition
open Fabulous

open type Fabulous.Avalonia.View

module ExpressionAnimation =
    type Model = { Value: int }

    type Msg = OnAttachedToVisualTree of VisualTreeAttachmentEventArgs

    let init () = { Value = 0 }, Cmd.none

    let Apply (visual: Border) (visualRoot: Visual) =
        let compositionVisual = ElementComposition.GetElementVisual(visual)
        let compositionVisualWindow = ElementComposition.GetElementVisual(visualRoot)

        if compositionVisual <> null && compositionVisualWindow <> null then
            let compositor = compositionVisual.Compositor

            let animation =
                compositor.CreateExpressionAnimation("Clamp(this.Target.Size.X / Window.Size.X, 0.0, 1.0)")

            animation.SetReferenceParameter("Window", compositionVisualWindow)
            compositionVisual.StartAnimation("Opacity", animation)

    let borderRef = ViewRef<Border>()
    let visualRootRef = ViewRef<ScrollViewer>()

    let update msg model =
        match msg with
        | OnAttachedToVisualTree _ ->
            Apply borderRef.Value visualRootRef.Value
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
        Component("ExpressionAnimation") {
            ScrollViewer(
                Dock() {
                    TextBlock("Resize window horizontally to change Border opacity.")
                        .horizontalAlignment(HorizontalAlignment.Center)
                        .dock(Dock.Top)
                        .margin(12.)

                    Border()
                        .background(SolidColorBrush(Colors.Red))
                        .width(200.)
                        .height(200.)
                        .reference(borderRef)
                        .onAttachedToVisualTree(OnAttachedToVisualTree)
                }
            )
                .reference(visualRootRef)
        }
