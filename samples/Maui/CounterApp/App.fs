namespace CounterApp

open Fabulous
open Fabulous.Maui

module App =
    type Model = { Text: string }

    type Msg = Nope

    let init () =
        { Text = "Hello from Fabulous.Maui!" }

    let update msg model =
        match msg with
        | Nope -> model

    let view model =
        Unchecked.defaultof<WidgetBuilder<Msg, IApplication>>

    let program =
        Program.statefulApplication init update view
