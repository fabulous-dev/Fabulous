namespace CounterApp

open System.Diagnostics
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View

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

    let initModel = { Count = 0; Step = 1; TimerOn = false }

    let timerCmd () =
        async {
            do! Async.Sleep 200
            return TimedTick
        }
        |> Cmd.OfAsync.msg

    let init () = initModel, Cmd.none

    let update msg model =
        match msg with
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

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let content () =
        Component("CounterApp") {
            let! model = Context.Mvu program

            (VStack() {
                TextBlock($"%d{model.Count}").centerText()

                Button("Increment", Increment).centerHorizontal()

                Button("Decrement", Decrement).centerHorizontal()

                (HStack() {
                    TextBlock("Timer").centerVertical()

                    ToggleSwitch(model.TimerOn, TimerToggled)
                })
                    .margin(20.)
                    .centerHorizontal()

                Slider(0., 10., float model.Step, SetStep)

                TextBlock($"Step size: %d{model.Step}").centerText()

                Button("Reset", Reset).centerHorizontal()

            })
                .center()
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication() { Window(content()) }
#endif
    let create () =

        FabulousAppBuilder.Configure(FluentTheme, view)
