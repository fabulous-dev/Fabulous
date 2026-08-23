namespace NavigationSample

open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

/// This is the root of the app
module Sample =
    /// We instantiate a single NavigationController that will be used for the lifetime of the app
    let nav = NavigationController()

    type Model =
        { Navigation: NavigationStack<NavigationState.Model>
          NextRouteId: int }

    type Msg =
        | NavigationPushed of NavigationPath
        | BackNavigated
        | NavigationMsg of NavigationState.Msg
        | BackButtonPressed

    /// This is where we subscribe to the navigation events
    /// If a navigation forward is requested, we dispatch the NavigationPushed message
    /// If a navigation backward is requested, we dispatch the BackNavigated message
    let navSubscription () : Cmd<Msg> =
        [ fun dispatch ->
              nav.Navigated.Add(fun path -> dispatch(NavigationPushed path))
              nav.BackNavigated.Add(fun () -> dispatch BackNavigated) ]

    /// In the init function, we initialize the NavigationStack and subscribe to the navigation events
    let init () =
        let rootPage = NavigationState.init NavigationPath.PageA
        let navigation = NavigationStack.create(Route.create "page-0" rootPage)

        let model =
            { Navigation = navigation
              NextRouteId = 1 }

        model, navSubscription()

    let update msg model =
        match msg with
        | NavigationPushed path ->
            let newPage = NavigationState.init path
            let route = Route.create $"page-{model.NextRouteId}" newPage
            let navigation = NavigationStack.push route model.Navigation

            let nextModel =
                { model with
                    Navigation = navigation
                    NextRouteId = model.NextRouteId + 1 }

            nextModel, Cmd.none

        | BackNavigated ->
            { model with
                Navigation = NavigationStack.pop model.Navigation },
            Cmd.none

        | NavigationMsg navMsg ->
            let currentRoute = NavigationStack.current model.Navigation
            let m, navCmd = NavigationState.update nav navMsg currentRoute.Value

            { model with
                Navigation = NavigationStack.replaceTop (Route.create currentRoute.Id m) model.Navigation },
            Cmd.map NavigationMsg navCmd

        | BackButtonPressed ->
            let currentRoute = NavigationStack.current model.Navigation
            let m, navCmd = NavigationState.updateBackButton nav currentRoute.Value

            { model with
                Navigation = NavigationStack.replaceTop (Route.create currentRoute.Id m) model.Navigation },
            Cmd.map NavigationMsg navCmd

    /// The view function contains the NavigationPage control that will display the different pages
    /// and handle the navigation animations (push, pop) as well has displaying a back button by default
    ///
    /// Because of MVU, all the pages need to return the same Msg type but they all have their own.
    /// To be able to wrap those Msgs into the app's root Msg type, we use the View.map helper function.
    let view model =
        Application(
            (NavigationPage() {
                for route in NavigationStack.routes model.Navigation do
                    (View.map NavigationMsg (NavigationState.view route.Value)).hasBackButton(false)
            })
                .onBackButtonPressed(BackButtonPressed)
        )

    let program = Program.statefulWithCmd init update |> Program.withView view
