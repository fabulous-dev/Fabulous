namespace Gallery

open System.Diagnostics
open Fabulous

open Fabulous.Avalonia
open type Fabulous.Avalonia.View

module MaskedTextBoxPage =
    type Model = { Text: string }

    type Msg = TextChanged of string

    let init () = { Text = "" }, Cmd.none

    let update msg model =
        match msg with
        | TextChanged text -> { Text = text }, Cmd.none

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
        Component("MaskedTextBoxPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15) {

                TextBlock("Enter a ten-digit number:")

                MaskedTextBox(model.Text, "(000) 000-0000", TextChanged)

                TextBlock($"You Entered: {model.Text}")
            }
        }
