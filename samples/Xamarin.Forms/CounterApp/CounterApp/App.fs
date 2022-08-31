namespace CounterApp

open System
open System.Collections.Generic
open Fabulous
open Fabulous.XamarinForms

open type Fabulous.XamarinForms.View

module App =
    type Model =
        { Count: int
          Step: int
          TimerOn: bool }

    type Msg =
        | Increment
        | Decrement
        | Reset
        | SetStep of float
        | TimerToggled of bool
        | TimedTick
        | LinkReceived of Uri

    let initModel = { Count = 0; Step = 1; TimerOn = false }

    let timerCmd () =
        async {
            do! Async.Sleep 200
            return TimedTick
        }
        |> Cmd.ofAsyncMsg

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
        | Increment ->
            let model =
                { model with
                      Count = model.Count + model.Step }

            model, Cmd.none
        | Decrement ->
            { model with
                  Count = model.Count - model.Step },
            Cmd.none
        | Reset -> initModel, Cmd.none
        | SetStep n -> { model with Step = int(n + 0.5) }, Cmd.none
        | TimerToggled on -> { model with TimerOn = on }, (if on then timerCmd() else Cmd.none)
        | TimedTick ->
            if model.TimerOn then
                { model with
                      Count = model.Count + model.Step },
                timerCmd()
            else
                model, Cmd.none
        | LinkReceived uri -> model, Cmd.none

    let view model =
        Application(
            ContentPage(
                "CounterApp",
                (VStack() {
                    Label($"%d{model.Count}").centerTextHorizontal()

                    Button("Increment", Increment)

                    Button("Decrement", Decrement)

                    (HStack() {
                        Label("Timer")

                        Switch(model.TimerOn, TimerToggled)
                     })
                        .padding(20.)
                        .centerHorizontal()

                    Slider(0.0, 10.0, double model.Step, SetStep)

                    Label($"Step size: %d{model.Step}")
                        .centerTextHorizontal()

                    Button("Reset", Reset)

                 })
                    .padding(30.)
                    .centerVertical()
            )
        )
            .onLinkReceived(fun args -> LinkReceived args.Uri)
            .appLinks() {
            AppLinkEntry("Im a deep link", "https://www.xamarin.com/platform")
                .description("Im a deep link")
                .thumbnail("https://www.xamarin.com/images/xamarin-logo.png")
                .keyValues(
                    [ KeyValuePair("key1", "value1")
                      KeyValuePair("key2", "value2") ]
                )
        }

    let program = Program.statefulWithCmd init update view
