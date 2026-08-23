namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Interactivity
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module DropDownButtonPage =
    type Model = { Count: int }

    type Msg =
        | Clicked of RoutedEventArgs
        | Clicked2 of RoutedEventArgs
        | Increment of RoutedEventArgs
        | Decrement of RoutedEventArgs
        | Reset

    let init () = { Count = 0 }, Cmd.none

    let update msg model =
        match msg with
        | Clicked _ -> model, Cmd.none
        | Clicked2 _ -> model, Cmd.none
        | Increment _ -> { Count = model.Count + 1 }, Cmd.none
        | Decrement _ -> { Count = model.Count - 1 }, Cmd.none
        | Reset -> { Count = 0 }, Cmd.none

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
        Component("DropDownButtonPage") {
            let! model = Context.Mvu program

            UniformGrid() {
                TextBlock($"Count: {model.Count}").centerVertical()

                DropDownButton("Open...", Clicked)
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

                DropDownButton(Clicked2, TextBlock("Open..."))
                    .flyout(
                        Flyout(
                            VWrap() {
                                TextBlock("Item 1")
                                Image("avares://Gallery/Assets/Icons/fabulous-icon.png")
                            }
                        )
                            .showMode(FlyoutShowMode.Standard)
                            .placement(PlacementMode.RightEdgeAlignedTop)
                    )
                    .background(Brushes.Blue)
            }
        }
