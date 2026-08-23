namespace NavigationSample

open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module PageC =
    type Model =
        { Args: string
          StepCount: int
          Count: int }

    type Msg =
        | Increment
        | Decrement
        | GoBack
        | GoToPageA
        | GoToPageB

    let init args stepCount =
        { Args = args
          StepCount = stepCount
          Count = 0 }

    let update (nav: NavigationController) msg model =
        match msg with
        | Increment ->
            { model with
                Count = model.Count + model.StepCount },
            Cmd.none
        | Decrement ->
            { model with
                Count = model.Count - model.StepCount },
            Cmd.none
        | GoBack -> model, Navigation.navigateBack nav
        | GoToPageA -> model, Navigation.navigateToPageA nav
        | GoToPageB -> model, Navigation.navigateToPageB nav model.Count

    let view model =
        Grid(coldefs = [ Star ], rowdefs = [ Star; Auto ]) {
            VStack() {
                Label($"Args: {model.Args}")
                Label($"StepCount from Page B: {model.StepCount}")

                Label($"Count: {model.Count}") //.centerTextHorizontal()

                Button("Increment", Increment)
                Button("Decrement", Decrement)
            }

            (VStack() {
                Button("Go back", GoBack)
                Button("Go to Page A", GoToPageA)
                Button("Go to Page B", GoToPageB)
            })
                .gridRow(1)
        }
