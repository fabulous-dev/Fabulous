namespace ComponentNavigation

open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

/// Each page is "isolated". They have their own MVU loop and own types.
/// The only dependency they receive from outside is the NavigationController, which is passed to the update function.
module PageA =
    type Model = { IsActive: bool; Count: int }

    type Msg =
        | Active
        | Inactive
        | Increment
        | Decrement
        | GoBack
        | GoToPageB
        | GoToPageC
        | BackButtonPressed

    /// Since the NavigationRoute.PageA doesn't take arguments, the init function excepts a unit parameter.
    let init () =
        { IsActive = false; Count = 0 }, Cmd.none

    let update (nav: NavigationController) msg model =
        match msg with
        | Active -> { model with IsActive = true }, Cmd.none
        | Inactive -> { model with IsActive = false }, Cmd.none
        | Increment -> { model with Count = model.Count + 1 }, Cmd.none
        | Decrement -> { model with Count = model.Count - 1 }, Cmd.none
        | GoBack -> model, Navigation.navigateBack nav
        | GoToPageB -> model, Navigation.navigateToPageB nav model.Count
        | GoToPageC -> model, Navigation.navigateToPageC nav "Hello from Page A!" model.Count
        | BackButtonPressed -> { model with Count = model.Count - 1 }, Cmd.none

    let subscribe (appMsgDispatcher: IAppMessageDispatcher) model =
        let localAppMsgSub dispatch =
            appMsgDispatcher.Dispatched.Subscribe(fun msg ->
                match msg with
                | AppMsg.BackButtonPressed -> dispatch BackButtonPressed)

        [ if model.IsActive then
              [ nameof localAppMsgSub ], localAppMsgSub ]

    let program nav appMsgDispatcher =
        Program.statefulWithCmd init (update nav)
        |> Program.withSubscription(subscribe appMsgDispatcher)

    let view nav appMsgDispatcher =
        Component(program nav appMsgDispatcher) {
            let! model = Mvu.State

            ContentPage(
                Grid(coldefs = [ Star ], rowdefs = [ Star; Auto ]) {
                    VStack() {
                        Label($"Count: {model.Count}").centerTextHorizontal()

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
            )
                .title("Page A")
                .onNavigatedTo(Active)
                .onNavigatedFrom(Inactive)
        }
