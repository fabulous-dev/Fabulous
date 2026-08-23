namespace ComponentNavigation

open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

/// This is the root of the app
module Sample =
    /// The Model needs only to store the current navigation stack
    type Model = { Navigation: NavigationStack }

    type Msg =
        | NavigationMsg of NavigationRoute
        | BackNavigationMsg
        | BackButtonPressed

    let notifyBackButtonPressed (appMessageDispatcher: IAppMessageDispatcher) =
        Cmd.ofEffect(fun _ -> appMessageDispatcher.Dispatch(AppMsg.BackButtonPressed))

    /// In the init function, we initialize the NavigationStack
    let init () =
        { Navigation = NavigationStack.Init(NavigationRoute.PageA) }, Cmd.none

    let update appMsgDispatcher msg model =
        match msg with
        | NavigationMsg route -> { Navigation = model.Navigation.Push(route) }, Cmd.none
        | BackNavigationMsg -> { Navigation = model.Navigation.Pop() }, Cmd.none
        | BackButtonPressed -> model, notifyBackButtonPressed appMsgDispatcher

    let subscribe (nav: NavigationController) _ =
        let navRequestedSub dispatch =
            nav.NavigationRequested.Subscribe(fun route -> dispatch(NavigationMsg route))

        let backNavRequestedSub dispatch =
            nav.BackNavigationRequested.Subscribe(fun () -> dispatch BackNavigationMsg)

        [ [ nameof navRequestedSub ], navRequestedSub
          [ nameof backNavRequestedSub ], backNavRequestedSub ]

    let program nav appMsgDispatcher =
        Program.statefulWithCmd init (update appMsgDispatcher)
        |> Program.withSubscription(subscribe nav)

    let navView nav appMsgDispatcher (path: NavigationRoute) =
        match path with
        | NavigationRoute.PageA -> AnyPage(PageA.view nav appMsgDispatcher)
        | NavigationRoute.PageB initialCount -> AnyPage(PageB.view nav appMsgDispatcher initialCount)
        | NavigationRoute.PageC(someArgs, stepCount) -> AnyPage(PageC.view nav appMsgDispatcher (someArgs, stepCount))

    let view nav appMsgDispatcher () =
        Component(program nav appMsgDispatcher) {
            let! model = Mvu.State

            Application(
                (NavigationPage() {
                    // We inject in the NavigationPage history the back stack of our navigation
                    for navPath in List.rev model.Navigation.BackStack do
                        navView nav appMsgDispatcher navPath

                    // The page currently displayed is the one on top of the stack
                    navView nav appMsgDispatcher model.Navigation.CurrentPage
                })
                    .onBackButtonPressed(BackButtonPressed)
                    .onBackNavigated(BackNavigationMsg)
            )
        }
