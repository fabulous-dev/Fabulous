namespace Playground

open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Accessibility
open Microsoft.Maui.Primitives

open type Fabulous.Maui.View

module App =
    type Model = { HasNavigated: bool }

    type Msg =
        | GoToA
        | GoToB

    let init () = { HasNavigated = false }

    let update msg model =
        match msg with
        | GoToA -> { model with HasNavigated = false }
        | GoToB -> { model with HasNavigated = true }

    let view model =
        Application(
            NavigationPage() {
                ContentPage(
                    "A",
                    VStack() {
                        Label("A")
                        Button("Go to B", GoToB)
                    }
                )

                if model.HasNavigated then
                    ContentPage(
                        "B",
                        VStack() {
                            Label("B")
                            Button("Go to A", GoToA)
                        }
                    )
             }
        )

    let program = Program.stateful init update view
