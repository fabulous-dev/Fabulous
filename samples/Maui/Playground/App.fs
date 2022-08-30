namespace Playground

open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Accessibility
open Microsoft.Maui.Primitives

open type Fabulous.Maui.View

module App =
    type Model =
        { HasNavigated: bool }

    type Msg =
        | GoToA
        | GoToB

    let init () =
        { HasNavigated = false }

    let update msg model =
        match msg with
        | GoToA -> { model with HasNavigated = false }
        | GoToB -> { model with HasNavigated = true }

    let view model =
        Application() {
            Window(
                Grid(coldefs = [ GridLength.Star ], rowdefs = [ GridLength.Star; GridLength.Star ]) {
                    Label("Playground")
                    
                    (NavigationView() {
                        VStack() {
                            Label("A")
                            TextButton("Go to B", GoToB)
                        }
                        
                        if model.HasNavigated then
                            VStack() {
                                Label("B")
                                TextButton("Go to A", GoToA)
                            }
                    })
                        .background(SolidPaint(Colors.Red))
                        .gridRow(1)
                }
            )
        }

    let program = Program.stateful init update view
