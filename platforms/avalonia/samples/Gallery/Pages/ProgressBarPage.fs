namespace Gallery

open System.Diagnostics
open Fabulous.Avalonia
open Fabulous
open type Fabulous.Avalonia.View

module ProgressBarPage =
    type Model = { Progress: int; Max: int }

    type Msg =
        | Clicked
        | ProgressChanged of float

    let init () = { Progress = 5; Max = 20 }, Cmd.none

    let update msg model =
        match msg with
        | Clicked ->
            { model with
                Progress = model.Progress % model.Max + 1 },
            Cmd.none
        | ProgressChanged p -> model, Cmd.none

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
        Component("ProgressBarPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {
                TextBlock("Progress Bar")

                ProgressBar(0, model.Max, model.Progress, ProgressChanged)
                    .showProgressText(true)

                Button("Advance Progress Bar", Clicked)

                TextBlock("Indeterminate Progress Bar").margin(0, 30, 0, 0)

                ProgressBar(0, model.Max, model.Progress, ProgressChanged)
                    .isIndeterminate(true)
            }
        }
