namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Input
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module MenuPage =
    type Model = { IsChecked: bool }

    type Msg = ValueChanged of bool

    let init () = { IsChecked = false }, Cmd.none

    let update msg model =
        match msg with
        | ValueChanged value -> { IsChecked = value }, Cmd.none

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
        Component("MenuPage") {
            let! model = Context.Mvu program

            VStack(4.) {
                TextBlock("Exported menu fallback")
                TextBlock("Should be only visible on platforms without desktop-global menu bar")
                NativeMenuBar()

                Dock() {
                    (Menu() {
                        MenuItems(header = Image("avares://Gallery/Assets/Icons/fabulous-icon.png")) {
                            MenuItem("Standard _Menu Item")
                                .inputGesture(KeyGesture(Key.A, KeyModifiers.Control))
                                .enableMenuItemClickForwarding(true)

                            MenuItem("_Disabled Menu Item")
                                .inputGesture(KeyGesture(Key.D, KeyModifiers.Control))
                                .isEnabled(false)

                            MenuItem(Separator())

                            MenuItems("Menu with _Submenu") {
                                MenuItem("Submenu _1")

                                MenuItems("Submenu _2 with Submenu") { MenuItem("Submenu Level 2") }


                                (MenuItems("Submenu _3 with Submenu Disabled") { MenuItem("Submenu Level 2") })
                                    .isEnabled(false)
                            }

                            MenuItem("Menu Item with _Icon")
                                .inputGesture(KeyGesture(Key.B, KeyModifiers.Control ||| KeyModifiers.Shift))
                                .icon(Image("avares://Gallery/Assets/Icons/fabulous-icon.png"))

                            MenuItem("Menu Item with _Checkbox")
                                .icon(CheckBox(model.IsChecked, ValueChanged))
                                .borderThickness(0.)
                                .isHitTestVisible(false)
                        }

                        MenuItems("_Second") { MenuItem("Second _Menu Item") }
                    })
                        .dock(Dock.Top)
                }
            }
        }
