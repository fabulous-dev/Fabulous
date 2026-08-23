namespace Gallery

open System
open System.Diagnostics
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module CalendarDatePickerPage =
    type Model = { Date: DateTime option }

    type Msg = SelectedDateChanged of DateTime option

    let init () = { Date = Some DateTime.Now }, Cmd.none

    let update msg model =
        match msg with
        | SelectedDateChanged dateTime -> { Date = dateTime }, Cmd.none

    let startFromYesterday = DateTime.Today.Subtract(TimeSpan.FromDays(1.0))

    let showUpToTomorrow = DateTime.Today.Add(TimeSpan.FromDays(1.0))

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

    let view () =
        Component("CalendarDatePickerPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {
                TextBlock($"Selected date: {model.Date}")

                CalendarDatePicker(model.Date, SelectedDateChanged)
                    .watermark("Select a date")
                    .displayDateStart(Some startFromYesterday)
                    .displayDateEnd(Some showUpToTomorrow)
                    .isTodayHighlighted(true)
                    .useFloatingWatermark(true)
                    .isDropDownOpen(true)
                    .centerHorizontal()
            }
        }
