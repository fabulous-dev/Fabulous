namespace TestableApp

open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View
open type Fabulous.Context

module App =
    type Model =
        { Count: int; Step: int; TimerOn: bool }

    type Msg =
        | Increment
        | Decrement
        | Reset
        | SetStep of float
        | TimerToggled of bool
        | TimedTick

    type CmdMsg = TimerToggling of bool

    let initModel = { Count = 0; Step = 1; TimerOn = false }

    let timerCmd () =
        async {
            do! Async.Sleep 200
            return TimedTick
        }
        |> Cmd.OfAsync.msg

    let mapCmdMsgToCmd cmdMsg =
        match cmdMsg with
        | TimerToggling value -> if value then timerCmd() else Cmd.none

    let init () = initModel, []

    let update msg model =
        match msg with
        | Increment ->
            { model with
                Count = model.Count + model.Step },
            []

        | Decrement ->
            { model with
                Count = model.Count - model.Step },
            []
        | Reset -> initModel, []
        | SetStep n -> { model with Step = int(n + 0.5) }, []

        | TimerToggled on -> { model with TimerOn = on }, [ TimerToggling on ]
        | TimedTick ->
            if model.TimerOn then
                { model with
                    Count = model.Count + model.Step },
                [ TimerToggling true ]
            else
                model, []

    let program = Program.statefulWithCmdMsg init update mapCmdMsgToCmd

    let content () =
        Component("CounterApp") {
            let! model = Context.Mvu program

            (VStack() {
                TextBlock($"%d{model.Count}").centerText()

                Button("Increment", Increment).centerHorizontal()

                Button("Decrement", Decrement).centerHorizontal()

                Slider(0., 10., float model.Step, SetStep)

                TextBlock($"Step size: %d{model.Step}").centerText()

                Button("Reset", Reset).centerHorizontal()

            })
                .center()
        }

    let view () = Window(content())
