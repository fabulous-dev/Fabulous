namespace Gallery

open System.Diagnostics
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ToggleSwitchPage =
    type Model =
        { Value1: bool
          Value2: bool option
          Text2: string }

    type Msg =
        | ValueChanged of bool
        | ValueChanged1 of bool option
        | IntermediaryChanged

    let init () =
        { Value1 = false
          Value2 = Some false
          Text2 = "Toggle me" },
        Cmd.none

    let update msg model =
        match msg with
        | ValueChanged value -> { model with Value1 = value }, Cmd.none
        | ValueChanged1 value ->
            let text =
                match value with
                | Some true -> "Yessss"
                | Some false -> "Nooo"
                | None -> "Intermediary"

            { model with
                Value2 = value
                Text2 = text },
            Cmd.none
        | IntermediaryChanged -> model, Cmd.none

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
        Component("ToggleSwitchPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {
                ToggleSwitch(model.Value1, ValueChanged)
                    .offContent(TextBlock("Nooo"))
                    .onContent("Yessss")
                    .content("Toggle me")

                ThreeStateToggleSwitch(model.Value2, ValueChanged1)
                    .offContent("Nooo")
                    .onContent(TextBlock("Yessss"))
                    .content(model.Text2)
            }
        }
