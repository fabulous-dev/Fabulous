namespace Gallery

open System
open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Primitives.PopupPositioning
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module PopupPage =
    type Model = { IsOpen: bool }

    type Msg =
        | OpenPopup
        | OnOpened
        | OnClosed

    let init () = { IsOpen = false }, Cmd.none

    let update msg model =
        match msg with
        | OpenPopup -> { IsOpen = not model.IsOpen }, Cmd.none
        | OnOpened -> model, Cmd.none
        | OnClosed -> model, Cmd.none

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
        Component("PopupPage") {
            let! model = Context.Mvu program

            (VStack(spacing = 15.) {
                Button("Click me", OpenPopup)

                Popup(
                    model.IsOpen,
                    (Grid(coldefs = [ Pixel(300) ], rowdefs = [ Auto; Pixel(200.) ]) {
                        Ellipse()
                            .size(100., 100.)
                            .fill(SolidColorBrush(Colors.Green))

                        TextBlock("This is a popup content")
                            .centerHorizontal()
                            .centerVertical()
                            .gridRow(1)
                    })
                        .background(SolidColorBrush(Colors.LightGray))
                )
                    .shouldUseOverlayLayer(true)
                    .takesFocusFromNativeControl(false)
                    .onOpened(OnOpened)
                    .onClosed(OnClosed)
                    .placement(PlacementMode.Custom)
                    .customPopupPlacementCallback(customPlacementCallback)
                    .placementGravity(PopupGravity.Bottom)
                    .placementAnchor(PopupAnchor.Bottom)
                    .placementConstraintAdjustment(PopupPositionerConstraintAdjustment.FlipY)
                    .placementRect(Rect(0., 0., 100., 100.))
            })
                .center()
        }
