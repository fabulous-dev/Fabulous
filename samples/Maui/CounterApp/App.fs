namespace CounterApp

open Fabulous.Maui

open type Fabulous.Maui.View

module App =
    type Model = { Text: string }

    type Msg = Nope

    let init () =
        { Text = "Hello from Fabulous.Maui!" }

    let update msg model =
        match msg with
        | Nope -> model

    let view model =
        Application() {
            Window(
                Label(model.Text)
            )
        }

    let program =
        Program.stateful init update view
