namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module SplitViewPage =
    type Model = { IsOpen: bool }

    type Msg = | Open

    let init () = { IsOpen = false }, Cmd.none

    let update msg model =
        match msg with
        | Open -> { IsOpen = not model.IsOpen }, Cmd.none

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
        Component("SplitViewPage") {
            let! model = Context.Mvu program

            VStack() {
                Button("Open", Open)

                SplitView(
                    TextBlock("Pane")
                        .fontSize(24.)
                        .verticalAlignment(VerticalAlignment.Center)
                        .horizontalAlignment(HorizontalAlignment.Center),

                    Grid() {
                        TextBlock("Content")
                            .fontSize(24.)
                            .verticalAlignment(VerticalAlignment.Center)
                            .horizontalAlignment(HorizontalAlignment.Center)

                    }
                )
                    .isPaneOpen(model.IsOpen)
                    .paneBackground(SolidColorBrush(Colors.LightGray))
                    .useLightDismissOverlayMode(true)

                    .displayMode(SplitViewDisplayMode.Inline)
                    .openPaneLength(296.0)
            }
        }
