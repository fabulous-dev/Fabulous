namespace ComponentNavigation

open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

/// This is the root of the app
module Sample =
    type Model =
        { Navigation: NavigationStack<NavigationRoute>
          NextRouteId: int }

    type Msg =
        | NavigationMsg of NavigationRoute
        | BackNavigationMsg
        | BackButtonPressed

    let notifyBackButtonPressed (appMessageDispatcher: IAppMessageDispatcher) =
        Cmd.ofEffect(fun _ -> appMessageDispatcher.Dispatch(AppMsg.BackButtonPressed))

    /// In the init function, we initialize the NavigationStack
    let init () =
        let navigation = NavigationStack.create(Route.create "page-0" NavigationRoute.PageA)

        let model =
            { Navigation = navigation
              NextRouteId = 1 }

        model, Cmd.none

    let update appMsgDispatcher msg model =
        match msg with
        | NavigationMsg route ->
            let route = Route.create $"page-{model.NextRouteId}" route

            { Navigation = NavigationStack.push route model.Navigation
              NextRouteId = model.NextRouteId + 1 },
            Cmd.none
        | BackNavigationMsg ->
            { model with
                Navigation = NavigationStack.pop model.Navigation },
            Cmd.none
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
        Component("Navigation") {
            let! model = Context.Mvu(program nav appMsgDispatcher)

            Application(
                (NavigationPage() {
                    for route in NavigationStack.routes model.Navigation do
                        navView nav appMsgDispatcher route.Value
                })
                    .onBackButtonPressed(BackButtonPressed)
                    .onBackNavigated(BackNavigationMsg)
            )
        }
