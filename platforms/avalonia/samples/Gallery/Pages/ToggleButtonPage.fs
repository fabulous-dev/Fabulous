namespace Gallery

open System.Diagnostics
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous
open type Fabulous.Avalonia.View

module ToggleButtonPage =
    type Model =
        { Text1: string
          Value1: bool
          Text2: string
          Value2: bool
          Text3: string
          Value3: bool option
          Text4: string
          Value4: bool option }

    type Msg =
        | CheckedChanged of bool
        | CheckedChanged2 of bool

        | ThreeStateChanged3 of bool option
        | ThreeStateChanged4 of bool option

    let init () =
        { Text1 = "Unchecked"
          Value1 = false
          Text2 = "Unchecked"
          Value2 = false
          Text3 = "Toggle me"
          Value3 = Some false
          Text4 = "Toggle me"
          Value4 = Some false },
        []

    let update msg model =
        match msg with
        | CheckedChanged b ->
            let text =
                match b with
                | true -> "Checked"
                | false -> "Unchecked"

            { model with Value1 = b; Text1 = text }, Cmd.none

        | CheckedChanged2 b ->
            let text =
                match b with
                | true -> "Checked"
                | false -> "Unchecked"

            { model with Value2 = b; Text2 = text }, Cmd.none

        | ThreeStateChanged3 b ->
            let text =
                match b with
                | Some true -> "Checked"
                | Some false -> "Unchecked"
                | None -> "Intermediary"

            { model with Value3 = b; Text3 = text }, Cmd.none

        | ThreeStateChanged4 b ->
            let text =
                match b with
                | Some true -> "Checked"
                | Some false -> "Unchecked"
                | None -> "Intermediary"

            { model with Value4 = b; Text4 = text }, Cmd.none

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
        Component("ToggleButtonPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {
                ToggleButton(model.Text1, model.Value1, CheckedChanged)

                ToggleButton(
                    model.Value2,
                    CheckedChanged2,
                    HStack() {
                        Image("avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                            .size(16., 16.)

                        TextBlock(model.Text2)
                    }
                )

                ThreeStateToggleButton(model.Text3, model.Value3, ThreeStateChanged3)

                ThreeStateToggleButton(
                    model.Value4,
                    ThreeStateChanged4,
                    HStack() {
                        Image("avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                            .size(16., 16.)

                        TextBlock(model.Text4)
                    }
                )
            }
        }
