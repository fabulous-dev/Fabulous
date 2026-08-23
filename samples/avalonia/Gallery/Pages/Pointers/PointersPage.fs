namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module PointersPage =
    type Model =
        { ThreadSleep: int
          Status: string
          Status2: string }

    type Msg =
        | ThreadSleepSliderChanged of float
        | StatusChanged of string
        | StatusChanged2 of string
        | Border_PointerPressed of PointerPressedEventArgs
        | Border_PointerReleased of PointerReleasedEventArgs
        | Border_PointerCaptureLost of PointerCaptureLostEventArgs
        | Border_PointerUpdated of PointerEventArgs

    let init () =
        { ThreadSleep = 0
          Status = ""
          Status2 = "" },
        Cmd.none

    let update msg model =
        match msg with
        | ThreadSleepSliderChanged v -> { model with ThreadSleep = int v }, Cmd.none
        | StatusChanged v -> { model with Status = v }, Cmd.none
        | StatusChanged2 v -> { model with Status2 = v }, Cmd.none
        | Border_PointerPressed args ->
            match args.Source with
            | :? Border as border ->
                args.Pointer.Capture(border)
                args.Handled <- true
            | _ -> ()

            model, Cmd.none
        | Border_PointerReleased args ->
            match args.Source with
            | :? Border as border ->
                if (args.Pointer.Captured = border) then
                    args.Pointer.Capture(null)
                    args.Handled <- true
                elif (args.Pointer.Captured <> null) then
                    raise(System.Exception("Unexpected capture"))
            | _ -> ()

            model, Cmd.none
        | Border_PointerCaptureLost args ->
            match args.Source with
            | :? Border as border when (border.Child :? TextBlock) ->
                let textBlock = border.Child :?> TextBlock

                textBlock.Text <-
                    @$"Type: {args.Pointer.Type}
Captured: {args.Pointer.Captured = border}
PointerId: {args.Pointer.Id}
Position: ??? ???"

                args.Handled <- true
                model, Cmd.none
            | _ -> model, Cmd.none
        | Border_PointerUpdated args ->
            match args.Source with
            | :? Border as border when (border.Child :? TextBlock) ->
                let position = args.GetPosition(border)
                let textBlock = border.Child :?> TextBlock

                textBlock.Text <-
                    @$"Type: {args.Pointer.Type}
Captured: {args.Pointer.Captured = border}
PointerId: {args.Pointer.Id}
Position: {position.X} {position.Y}"

                args.Handled <- true
                model, Cmd.none
            | _ -> model, Cmd.none

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
        Component("PointersPage") {
            let! model = Context.Mvu program

            TabControl(Dock.Top) {
                TabItem("Contacts", PointerContactsTab())

                TabItem(
                    TextBlock("IntermediatePoints"),
                    (Panel() {
                        View.PointerCanvas(true, model.ThreadSleep, StatusChanged)

                        Border(
                            (VStack() {
                                TextBlock($"Thread sleep: {model.ThreadSleep} / 500")
                                Slider(0, 500, model.ThreadSleep, ThreadSleepSliderChanged)
                            })
                                .background(Brushes.LightYellow)
                        )
                            .width(300)
                            .height(60.)
                            .verticalAlignment(VerticalAlignment.Top)
                            .horizontalAlignment(HorizontalAlignment.Right)

                        TextBlock(model.Status)
                            .horizontalAlignment(HorizontalAlignment.Left)
                            .verticalAlignment(VerticalAlignment.Top)

                    })
                        .foreground(Brushes.Black)
                )

                TabItem(
                    TextBlock("Pressure"),
                    (Panel() {
                        View.PointerCanvas(false, 0, StatusChanged2)

                        TextBlock(model.Status2)
                            .horizontalAlignment(HorizontalAlignment.Left)
                            .verticalAlignment(VerticalAlignment.Top)
                    })
                        .foreground(Brushes.Black)
                )

                TabItem(
                    TextBlock("Capture"),
                    VWrap() {
                        Border(TextBlock("Capture 1"))
                            .minHeight(170.)
                            .minWidth(250.)
                            .margin(5.)
                            .padding(50.)
                            .background(Brushes.LightBlue)
                            .tooltipPlacement(PlacementMode.Bottom)
                            .onPointerPressed(Border_PointerPressed)
                            .onPointerReleased(Border_PointerReleased)
                            .onPointerCaptureLost(Border_PointerCaptureLost)
                            .onPointerMoved(Border_PointerUpdated)
                            .onPointerEntered(Border_PointerUpdated)
                            .onPointerExited(Border_PointerUpdated)

                        Border(TextBlock("Capture 2"))
                            .minHeight(170.)
                            .minWidth(250.)
                            .margin(5.)
                            .padding(50.)
                            .background(Brushes.LightBlue)
                            .tooltipPlacement(PlacementMode.Bottom)
                            .onPointerPressed(Border_PointerPressed)
                            .onPointerReleased(Border_PointerReleased)
                            .onPointerCaptureLost(Border_PointerCaptureLost)
                            .onPointerMoved(Border_PointerUpdated)
                            .onPointerEntered(Border_PointerUpdated)
                            .onPointerExited(Border_PointerUpdated)
                    }

                )
            }
        }
