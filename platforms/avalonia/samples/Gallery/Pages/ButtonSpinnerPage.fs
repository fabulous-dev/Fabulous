namespace Gallery

open System
open System.Diagnostics
open Avalonia.Controls
open Fabulous

open Fabulous.Avalonia
open type Fabulous.Avalonia.View


module ButtonSpinnerPage =
    type Model = { Count: int }

    type Msg = Increment of SpinEventArgs

    let init () = { Count = 0 }, Cmd.none

    let update msg model =
        match msg with
        | Increment args ->
            let spinner = args.Source :?> ButtonSpinner
            let currentSpinValue = spinner.Content :?> string

            let mutable currentValue =
                if String.IsNullOrEmpty(currentSpinValue) then
                    0
                else
                    Convert.ToInt32(currentSpinValue)

            if (args.Direction = SpinDirection.Increase) then
                currentValue <- currentValue + 1
            else
                currentValue <- currentValue - 1

            spinner.Content <- currentValue.ToString()

            { Count = model.Count + 1 }, Cmd.none

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
        Component("ButtonSpinnerPage") {
            VStack(spacing = 15.) {
                TextBlock("Button spinner")

                ButtonSpinner("1", Increment)
            }
        }
