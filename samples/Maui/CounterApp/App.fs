namespace CounterApp

open Fabulous
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics
open Microsoft.Maui.Accessibility
open Microsoft.Maui.Primitives
open type Fabulous.Maui.View
open Microsoft.Maui.Graphics
open System

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
        | Interaction of TouchEventArgs

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
        | Interaction touchEventArgs -> model, Cmd.none
        | Increment ->
            { model with
                  Count = model.Count + model.Step },
            Cmd.none
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

    let view model =
        Application(
            ContentPage(
                "CounterApp",
                (VStack(16.0) {
                    Label("Ima text")
                        .background(SolidColorBrush(Color.Parse("#FF9988")))
                        
                    Frame()
                        .borderColor(Colors.Red.ToFabColor())
                        .hasShadow(true)
                        .cornerRadius(12.)
                        .height(120.)
                        .width(120.)
                        .background(
                            LinearGradientBrush(Point(1, 0)) {
                                GradientStop(0.1, Color.Parse("#FF9988"))
                                GradientStop(1.0, Color.Parse("#FF0000"))
                            }
                        )
                 })
                    .center()
            )
        )

    let program = Program.statefulWithCmd init update view
