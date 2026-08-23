namespace Gallery

open System.ComponentModel
open System.Diagnostics
open Avalonia.Input
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ContextFlyoutPage =
    type Model = { Counter: int; IsChecked: bool }

    type Msg =
        | MenuOpened
        | MenuClosed
        | MenuOpening
        | MenuClosing of CancelEventArgs
        | ValueChanged of bool

    let init () =
        { Counter = 0; IsChecked = false }, Cmd.none

    let update msg model =
        match msg with
        | ValueChanged value -> { model with IsChecked = value }, Cmd.none
        | MenuOpened -> model, Cmd.none
        | MenuClosed -> model, Cmd.none
        | MenuOpening -> model, Cmd.none
        | MenuClosing _ -> model, Cmd.none

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
        Component("ContextFlyoutPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {
                Border(TextBlock("A right click Flyout that can be applied to any control."))
                    .contextFlyout(
                        (MenuFlyout() {
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
                            .onClosed(MenuClosed)
                            .onOpened(MenuOpened)
                    )

                Border(TextBlock("A right click Flyout that can be applied to any control."))
                    .contextFlyout(
                        (MenuFlyout() {

                            MenuItem("Menu Item with _Icon")
                                .inputGesture(KeyGesture(Key.B, KeyModifiers.Control ||| KeyModifiers.Shift))
                                .icon(Image("avares://Gallery/Assets/Icons/fabulous-icon.png"))

                            MenuItem("Menu Item with _Checkbox")
                                .icon(
                                    CheckBox(model.IsChecked, ValueChanged)
                                        .borderThickness(0.)
                                        .isHitTestVisible(false)
                                )

                            MenuItem("Menu Item that won't close on click")
                                .staysOpenOnClick(true)

                            MenuItem("Menu Item that will close on click")
                        })
                            .onClosing(MenuClosing)
                            .onOpening(MenuOpening)
                    )
            }
        }
