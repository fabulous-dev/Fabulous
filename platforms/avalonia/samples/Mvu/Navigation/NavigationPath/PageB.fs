namespace NavigationSample

open Avalonia.Media
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module PageB =
    type Model = { InitialCount: int; Count: int }

    type Msg =
        | Increment
        | Decrement
        | GoBack
        | GoToPageA
        | GoToPageC

    /// Contrary to PageA, NavigationPath.PageB has a initialCount argument so the init function will receive it.
    let init initialCount =
        { InitialCount = initialCount
          Count = initialCount }

    let update (nav: NavigationController) msg model =
        match msg with
        | Increment -> { model with Count = model.Count + 1 }, Cmd.none
        | Decrement -> { model with Count = model.Count - 1 }, Cmd.none
        | GoBack -> model, Navigation.navigateBack nav
        | GoToPageA -> model, Navigation.navigateToPageA nav
        | GoToPageC -> model, Navigation.navigateToPageC nav "Hello from Page A!" model.Count

    let view model =
        Component("PageB") {
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
