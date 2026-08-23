namespace ComponentNavigation

open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

module PageC =
    type Model =
        { IsActive: bool
          Args: string
          StepCount: int
          Count: int }

    type Msg =
        | Active
        | Inactive
        | Increment
        | Decrement
        | GoBack
        | GoToPageA
        | GoToPageB

    let init (args, stepCount) =
        { IsActive = false
          Args = args
          StepCount = stepCount
          Count = 0 },
        Cmd.none

    let update (nav: NavigationController) msg model =
        match msg with
        | Active -> { model with IsActive = true }, Cmd.none
        | Inactive -> { model with IsActive = false }, Cmd.none
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

    let subscribe (appMsgDispatcher: IAppMessageDispatcher) model =
        let localAppMsgSub dispatch =
            appMsgDispatcher.Dispatched.Subscribe(fun msg ->
                match msg with
                | AppMsg.BackButtonPressed -> dispatch GoBack)

        [ if model.IsActive then
              [ nameof localAppMsgSub ], localAppMsgSub ]

    let program nav appMsgDispatcher =
        Program.statefulWithCmd init (update nav)
        |> Program.withSubscription(subscribe appMsgDispatcher)

    let view nav appMsgDispatcher args =
        Component(program nav appMsgDispatcher, args) {
            let! model = Mvu.State

            ContentPage(
                Grid(coldefs = [ Star ], rowdefs = [ Star; Auto ]) {
                    VStack() {
                        Label($"Args: {model.Args}")
                        Label($"StepCount from Page B: {model.StepCount}")

                        Label($"Count: {model.Count}").centerTextHorizontal()

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
            )
                .title("Page C")
                .onNavigatedTo(Active)
                .onNavigatedFrom(Inactive)
        }
