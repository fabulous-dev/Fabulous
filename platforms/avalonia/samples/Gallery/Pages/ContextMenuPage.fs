namespace Gallery

open System.ComponentModel
open System.Diagnostics
open Avalonia.Input
open Avalonia.Interactivity
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ContextMenuPage =
    type Model = { Counter: int; IsChecked: bool }

    type Msg =
        | MenuOpened of RoutedEventArgs
        | MenuClosed of RoutedEventArgs
        | ContextMenuOpening of CancelEventArgs
        | ContextMenuClosing of CancelEventArgs
        | ValueChanged of bool

    let init () =
        { Counter = 0; IsChecked = false }, Cmd.none

    let update msg model =
        match msg with
        | ValueChanged value -> { model with IsChecked = value }, Cmd.none
        | ContextMenuOpening _ -> model, Cmd.none
        | ContextMenuClosing _ -> model, Cmd.none
        | MenuOpened _ -> model, Cmd.none
        | MenuClosed _ -> model, Cmd.none

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
        Component("ContextMenuPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {
                Border(TextBlock("A right click menu that can be applied to any control."))
                    .contextMenu(
                        (ContextMenu() {
                            MenuItem("Standard _Menu Item")
                                .inputGesture(KeyGesture(Key.A, KeyModifiers.Control))

                            MenuItem("Standard _Menu Item")
                                .inputGesture(KeyGesture(Key.A, KeyModifiers.Control))

                            MenuItem("_Disabled Menu Item")
                                .inputGesture(KeyGesture(Key.D, KeyModifiers.Control))
                                .isEnabled(false)

                            MenuItem(Separator())

                            MenuItems("Menu with _Submenu") {
                                MenuItem("Submenu _1")
                                MenuItem("Submenu _1")
                                MenuItem("Submenu _2")
                                MenuItem("Submenu _2")
                            }
                        })
                            .onOpening(ContextMenuOpening)
                            .onClosing(ContextMenuClosing)
                    )

                Border(TextBlock("A right click menu that can be applied to any control."))
                    .contextMenu(
                        (ContextMenu() {
                            MenuItem("Menu Item with _Icon")
                                .inputGesture(KeyGesture(Key.B, KeyModifiers.Control ||| KeyModifiers.Shift))
                                .icon(Image("avares://Gallery/Assets/Icons/fabulous-icon.png"))

                            MenuItem("Menu Item with _Checkbox")
                                .icon(
                                    CheckBox(model.IsChecked, ValueChanged)
                                        .borderThickness(0.)
                                        .isHitTestVisible(false)
                                )
                                .staysOpenOnClick(true)

                            MenuItem("Menu Item that won't close on click")
                                .staysOpenOnClick(true)

                            MenuItem("Menu Item that will close on click")
                        })
                            .onOpened(MenuOpened)
                            .onClosed(MenuClosed)
                    )
            }
        }
