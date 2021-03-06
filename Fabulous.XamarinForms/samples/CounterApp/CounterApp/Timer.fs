namespace CounterApp

open Fabulous
open Fabulous.XamarinForms

module Timer =
    type TimerState =
        { IsEnabled: bool }

    type Model =
        { Ticks: int
          TimerState: TimerState }

    type Msg =
        | TimerTick
        | Reset
        | StateChanged of TimerState

    let timerCmd (isEnabled) =
        if isEnabled then
            async { do! Async.Sleep 200
                    return TimerTick }
            |> Cmd.ofAsyncMsg
        else
            Cmd.none

    let init () =
        let isEnabled = false
        { Ticks = 0; TimerState = { IsEnabled = isEnabled } }, timerCmd isEnabled

    let update msg model =
        match msg with
        | TimerTick -> { model with Ticks = model.Ticks + 1 }, Cmd.none //timerCmd model.TimerState.IsEnabled
        | StateChanged state -> { model with TimerState = state }, timerCmd state.IsEnabled
        | Reset -> { model with Ticks = 0 }, timerCmd model.TimerState.IsEnabled

    let view model dispatch =
        View.StackLayout([
            View.Label(sprintf "Timer %s" (if model.TimerState.IsEnabled then "enabled" else "disabled"))
            View.Label(sprintf "Ticks %i" model.Ticks)
            View.Button(
                text = "Reset",
                command = fun _ -> dispatch Reset
            )
            View.Label(sprintf "Component updated on %A" System.DateTime.Now.TimeOfDay)
        ])

    let program =
        XamarinFormsProgram.mkProgram init update view
        |> Program.withSubscription (fun _ dispatch ->
            let timer = new System.Timers.Timer(200.)
            timer.Elapsed.Add(fun _ ->
                dispatch TimerTick
            )
            timer.Start()
            { new System.IDisposable with
                member _.Dispose() =
                    timer.Dispose() }
        )
#if DEBUG
        |> Program.withConsoleTrace
#endif

    type Fabulous.XamarinForms.View with
        static member inline Timer(state) =
            Component.forProgram(
                program,
                state = (StateChanged, state)
            )