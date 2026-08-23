namespace Gallery

open System
open Avalonia
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.Interactivity
open Avalonia.Media
open Avalonia.Controls
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ToolTipPage =
    type Model = { IsOpen: bool }

    type Msg = OnLoaded of RoutedEventArgs

    let init () = { IsOpen = false }

    let targetRef = ViewRef<Border>()

    let update msg model =
        match msg with
        | OnLoaded _ ->
            ToolTip.AddToolTipOpeningHandler(targetRef.Value, (fun sender args -> printfn "Opening"))
            ToolTip.AddToolTipClosingHandler(targetRef.Value, (fun sender args -> printfn "Closing"))
            model

    let program =
        Program.stateful init update
        |> Program.withTrace(fun (format, args) -> System.Diagnostics.Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )


    let customPlacementCallback (placement: CustomPopupPlacement) =
        let r = Random().Next()

        placement.Anchor <-
            match r % 4 with
            | 1 -> PopupAnchor.Top
            | 2 -> PopupAnchor.Bottom
            | 3 -> PopupAnchor.Left
            | _ -> PopupAnchor.Right

        placement.Gravity <-
            match r % 4 with
            | 1 -> PopupGravity.Top
            | 2 -> PopupGravity.Bottom
            | 3 -> PopupGravity.Left
            | _ -> PopupGravity.Right

        placement.Offset <- Point(float(r % 20), float(r % 20))

    let view () =
        Component("ToolTipPage") {
            let! _ = Context.Mvu program

            VStack(spacing = 15.) {
                Border(TextBlock("Hover over me!"))
                    .padding(10.)
                    .background(SolidColorBrush(Colors.LightGray))
                    .tip(ToolTip("Im a tooltip!"))
                    .reference(targetRef)

                Border(TextBlock("Hover over me!"))
                    .padding(10.)
                    .background(SolidColorBrush(Colors.LightGray))
                    .tip(ToolTip("Im a tooltip!").isOpen(true))
                    .tooltipPlacement(PlacementMode.Top)


                Border(TextBlock("Hover over me!"))
                    .padding(10.)
                    .background(SolidColorBrush(Colors.LightGray))
                    .tip(
                        ToolTip(
                            VStack() {
                                TextBlock("ToolTip")
                                TextBlock("A control which pops up a hint when a control is hovered")
                            }
                        )
                    )
                    .tooltipShowDelay(1000)
                    .tooltipHorizontalOffset(50.)
                    .tooltipVerticalOffset(50.)

                Border(TextBlock("ToolTip custom placement"))
                    .padding(10.)
                    .background(SolidColorBrush(Colors.LightGray))
                    .tooltipCustomPopupPlacementCallback(customPlacementCallback)
                    .tooltipPlacement(PlacementMode.Custom)
                    .tip("Custom positioned tooltip")
            }
            |> _.onLoaded(OnLoaded)
        }
