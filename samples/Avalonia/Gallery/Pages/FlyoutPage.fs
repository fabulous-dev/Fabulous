namespace Gallery

open System.ComponentModel
open System.Diagnostics
open Avalonia.Controls
open Avalonia.Controls.Primitives
open Avalonia.Input
open Avalonia.Interactivity
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module FlyoutPage =
    type Model = { Counter: int; IsChecked: bool }

    type Msg =
        | MenuOpening
        | MenuClosing of CancelEventArgs
        | Opened
        | Closed
        | Increment
        | Decrement
        | Reset
        | OnTapped of RoutedEventArgs

    let init () =
        { Counter = 0; IsChecked = false }, Cmd.none

    let update msg model =
        match msg with
        | OnTapped args ->
            match args.Source with
            | :? Panel as control ->
                FlyoutBase.ShowAttachedFlyout(control)
                model, Cmd.none
            | :? Border as control ->
                FlyoutBase.ShowAttachedFlyout(control)
                model, Cmd.none
            | _ -> model, Cmd.none
        | MenuOpening -> model, Cmd.none
        | MenuClosing _ -> model, Cmd.none
        | Increment ->
            { model with
                Counter = model.Counter + 1 },
            Cmd.none
        | Decrement ->
            { model with
                Counter = model.Counter - 1 },
            Cmd.none
        | Reset -> { model with Counter = 0 }, Cmd.none
        | Opened -> model, Cmd.none
        | Closed -> model, Cmd.none

    let sharedMenuFlyout openMsg closeMsg =
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
            .onOpening(openMsg)
            .onClosing(closeMsg)

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
        Component("FlyoutPage") {
            let! _ = Context.Mvu program

            VStack(spacing = 15.) {
                TextBlock("MenuFlyout")

                Button("Click me", Increment)
                    .flyout(
                        Flyout(
                            VStack() {
                                Button("Increment", Increment).width(100)
                                Button("Decrement", Decrement).width(100)
                                Button("Reset", Reset).width(100)
                            }
                        )
                            .showMode(FlyoutShowMode.Standard)
                            .placement(PlacementMode.RightEdgeAlignedTop)
                            .onOpened(Opened)
                            .onClosed(Closed)
                    )

                TextBlock("Attached Flyouts")

                Border(
                    (VWrap() {
                        TextBlock("Click panel to launch AttachedFlyout")
                            .verticalAlignment(VerticalAlignment.Center)
                            .margin(10.)
                    })
                        .attachedFlyout(
                            Flyout(
                                VWrap() {
                                    TextBlock("Attached Flyout")
                                        .verticalAlignment(VerticalAlignment.Center)
                                        .margin(10.)
                                }
                            )
                                .showMode(FlyoutShowMode.Standard)
                                .placement(PlacementMode.RightEdgeAlignedTop)
                        )
                        .background(Brushes.Blue)
                        .onTapped(OnTapped)
                )
                    .borderBrush(Brushes.Red)
                    .borderThickness(1.)
                    .padding(10.)

                TextBlock("Shared MenuFlyout")

                Border(
                    VStack() {
                        Button("Launch Flyout on this button", Increment)
                            .flyout(sharedMenuFlyout MenuOpening MenuClosing)

                        Button("Launch Flyout on this button", Increment)
                            .flyout(sharedMenuFlyout MenuOpening MenuClosing)
                    }
                )
                    .borderThickness(1.)
                    .borderBrush(Brushes.Red)
                    .padding(10.)
            }
        }
