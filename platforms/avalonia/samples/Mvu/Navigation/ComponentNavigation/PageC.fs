namespace ComponentNavigation


open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

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
        Component("PageC") {
            let! model = Context.Mvu(program nav appMsgDispatcher, args)

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
