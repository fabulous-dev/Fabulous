namespace NavigationSample

open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

/// Each page are "isolated". They have their own MVU loop and own types.
/// The only dependency they receive from outside is the NavigationController, which is passed to the update function.
module PageA =
    type Model = { Count: int }

    type Msg =
        | Increment
        | Decrement
        | GoBack
        | GoToPageB
        | GoToPageC
        | BackButtonPressed

    /// Since the NavigationPath.PageA doesn't take arguments, the init function excepts a unit parameter.
    let init () = { Count = 0 }

    let update (nav: NavigationController) msg model =
        match msg with
        | Increment -> { Count = model.Count + 1 }, Cmd.none
        | Decrement -> { Count = model.Count - 1 }, Cmd.none
        | GoBack -> model, Navigation.navigateBack nav
        | GoToPageB -> model, Navigation.navigateToPageB nav model.Count
        | GoToPageC -> model, Navigation.navigateToPageC nav "Hello from Page A!" model.Count
        | BackButtonPressed -> { Count = model.Count - 1 }, Cmd.none

    let view model =
        Grid(coldefs = [ Star ], rowdefs = [ Star; Auto ]) {
            VStack() {
                Label($"Count: {model.Count}")

                Button("Increment", Increment)
                Button("Decrement", Decrement)
            }

            (VStack() {
                Button("Go back", GoBack)
                Button("Go to Page B", GoToPageB)
                Button("Go to Page C", GoToPageC)
            })
                .gridRow(1)
        }
