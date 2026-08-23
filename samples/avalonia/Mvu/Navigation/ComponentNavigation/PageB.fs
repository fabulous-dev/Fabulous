namespace ComponentNavigation

open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module PageB =
    type Model =
        { IsActive: bool
          InitialCount: int
          Count: int }

    type Msg =
        | Active
        | Inactive
        | Increment
        | Decrement
        | GoBack
        | GoToPageA
        | GoToPageC

    /// Contrary to PageA, NavigationPath.PageB has a initialCount argument so the init function will receive it.
    let init initialCount =
        { IsActive = false
          InitialCount = initialCount
          Count = initialCount },
        Cmd.none

    let update (nav: NavigationController) msg model =
        match msg with
        | Active -> { model with IsActive = true }, Cmd.none
        | Inactive -> { model with IsActive = false }, Cmd.none
        | Increment -> { model with Count = model.Count + 1 }, Cmd.none
        | Decrement -> { model with Count = model.Count - 1 }, Cmd.none
        | GoBack -> model, Navigation.navigateBack nav
        | GoToPageA -> model, Navigation.navigateToPageA nav
        | GoToPageC -> model, Navigation.navigateToPageC nav "Hello from Page A!" model.Count

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

    let view nav appMsgDispatcher arg =
        Component("Page B") {
            let! model = Context.Mvu(program nav appMsgDispatcher, arg)

            Dock() {

                Label("Page B")
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
                    Button("Go to Page C", GoToPageC)
                })
                    .dock(Dock.Bottom)
                    .centerHorizontal()
            }
        }
