namespace Gallery

open System
open System.Diagnostics
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module TimePickerPage =
    type Model = { Time: TimeSpan }

    type Msg = TimeChanged of TimeSpan

    let init () = { Time = TimeSpan.FromHours(12.) }

    let update msg model =
        match msg with
        | TimeChanged time -> { model with Time = time }

    let program =
        Program.stateful init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("TimePickerPage") {
            let! model = Context.Mvu program

            VStack(16.) {
                TextBlock($"Selected Time: {model.Time}")

                TimePicker(model.Time, TimeChanged)

                TextBlock("TimePicker with seconds:")

                TimePicker(model.Time, TimeChanged).useSeconds(true)

                TextBlock("TimePicker with 24-hour clock:")

                TimePicker(model.Time, TimeChanged).use24HourClock(true)

                TextBlock("TimePicker with seconds and 24-hour clock:")

                TimePicker(model.Time, TimeChanged)
                    .useSeconds(true)
                    .use24HourClock(true)

                TextBlock("TimePicker with 10-second increments:")

                TimePicker(model.Time, TimeChanged).secondIncrement(10)
            }
            |> _.centerHorizontal()
        }
