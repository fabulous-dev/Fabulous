namespace ComponentNavigation

open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open type Fabulous.Context

/// Each page is "isolated". They have their own MVU loop and own types.
/// The only dependency they receive from outside is the NavigationController, which is passed to the update function.
module PageA =
    // type Model = { IsActive: bool; Count: int }
    //
    // type Msg =
    //     | Active
    //     | Inactive
    //     | Increment
    //     | Decrement
    //     | GoBack
    //     | GoToPageB
    //     | GoToPageC
    //     | BackButtonPressed
    //
    // /// Since the NavigationRoute.PageA doesn't take arguments, the init function excepts a unit parameter.
    // let init () =
    //     { IsActive = false; Count = 0 }, Cmd.none
    //
    // let update (nav: NavigationController) msg model =
    //     match msg with
    //     | Active -> { model with IsActive = true }, Cmd.none
    //     | Inactive -> { model with IsActive = false }, Cmd.none
    //     | Increment -> { model with Count = model.Count + 1 }, Cmd.none
    //     | Decrement -> { model with Count = model.Count - 1 }, Cmd.none
    //     | GoBack -> model, Navigation.navigateBack nav
    //     | GoToPageB -> model, Navigation.navigateToPageB nav model.Count
    //     | GoToPageC -> model, Navigation.navigateToPageC nav "Hello from Page A!" model.Count
    //     | BackButtonPressed -> { model with Count = model.Count - 1 }, Cmd.none
    //
    // let subscribe (appMsgDispatcher: IAppMessageDispatcher) model =
    //     let localAppMsgSub dispatch =
    //         appMsgDispatcher.Dispatched.Subscribe(fun msg ->
    //             match msg with
    //             | AppMsg.BackButtonPressed -> dispatch BackButtonPressed)
    //
    //     [ if model.IsActive then
    //           [ nameof localAppMsgSub ], localAppMsgSub ]
    //
    // let program nav appMsgDispatcher =
    //     Program.statefulWithCmd init (update nav)
    //     |> Program.withSubscription(subscribe appMsgDispatcher)

    let view (navState: StateValue<NavigationController>) appMsgDispatcher =
        Component("PageA") {
            let! count = State(0)
            let! nav = Binding(navState)

            Grid(coldefs = [ Star ], rowdefs = [ Star; Auto ]) {
                VStack() {
                    Label("Page A")
                        .foreground(Brushes.White)
                        .fontSize(32.)
                        .centerHorizontal()
                        .margin(0., 0., 0., 30.)

                    Label($"Count: {count.Current}").centerHorizontal()

                    Button("Increment", (fun _ -> count.Set(count.Current + 1)))
                        .centerHorizontal()

                    Button("Decrement", (fun _ -> count.Set(count.Current - 1)))
                        .centerHorizontal()
                }

                (HStack() {
                    Button("Go back", (fun _ -> nav.Current.NavigateBack()))
                    Button("Go to Page B", (fun _ -> nav.Current.NavigateTo(NavigationRoute.PageB(count.Current))))
                    Button("Go to Page C", (fun _ -> nav.Current.NavigateTo(NavigationRoute.PageC("Hello from Page A!", count.Current))))
                })
                    .gridRow(1)
                    .centerHorizontal()
            }
        }
