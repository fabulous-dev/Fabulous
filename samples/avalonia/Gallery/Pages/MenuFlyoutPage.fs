namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Interactivity
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module MenuFlyoutPage =
    type Model = { Counter: int }

    type Msg =
        | PressMe
        | Increment of RoutedEventArgs

    let init () = { Counter = 0 }, Cmd.none

    let update msg model =
        match msg with
        | PressMe -> model, Cmd.none
        | Increment _ -> { Counter = model.Counter + 1 }, Cmd.none

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
        Component("MenuFlyoutPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {

                TextBlock($"{model.Counter}")

                Button("Open Flyout", PressMe)
                    .flyout(
                        (MenuFlyout() {
                            MenuItem("Item 1")
                                .icon(Image("avares://Gallery/Assets/Icons/fabulous-icon.png"))

                            MenuItems("Item 2") {
                                MenuItem("Subitem 1")
                                MenuItem("Subitem 2")
                                MenuItem("Subitem 3")
                                MenuItem("Subitem 4")
                                MenuItem("Subitem 5")
                            }
                            |> _.onClick(Increment)

                            MenuItem("Item 4").inputGesture(KeyGesture.Parse("Ctrl+A"))
                            MenuItem("Item 5").inputGesture(KeyGesture.Parse("Ctrl+A"))
                            MenuItem(TextBlock("Item 6")).onClick(Increment)
                            MenuItem("Item 7")
                        })
                            .placement(PlacementMode.BottomEdgeAlignedRight)
                    )
            }
        }
