namespace NavigationSample

open Avalonia.Controls
open Avalonia.Media
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
        Component("PageC") {
            Dock() {

                Label("Page C")
                    .foreground(Brushes.White)
                    .fontSize(32.)
                    .centerHorizontal()
                    .margin(0., 0., 0., 30.)
                    .dock(Dock.Top)

                VStack() {
                    Label($"Count: {model.Count}").centerHorizontal()

                    Button("Increment", Increment)
                    Button("Decrement", Decrement)
                }
                |> _.dock(Dock.Top)
                |> _.centerHorizontal()

                (HStack() {
                    Button("Go back", GoBack)
                    Button("Go to Page A", GoToPageA)
                    Button("Go to Page B", GoToPageB)
                })
                    .dock(Dock.Bottom)
                    .centerHorizontal()
            }
        }
