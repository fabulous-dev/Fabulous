namespace Gallery

open System.Diagnostics
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module TextBoxPage =
    type Model =
        { SingleLineText: string
          MultiLineText: string }

    type Msg =
        | SingleLineTextChanged of string
        | MultiLineTextChanged of string

    let init () =
        { SingleLineText = ""
          MultiLineText = "" },
        Cmd.none

    let update msg model =
        match msg with
        | SingleLineTextChanged text -> { model with SingleLineText = text }, Cmd.none
        | MultiLineTextChanged text -> { model with MultiLineText = text }, Cmd.none

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
        Component("TextBoxPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15) {
                TextBox(model.SingleLineText, SingleLineTextChanged)
                    .textAlignment(TextAlignment.Center)
                    .watermark("Enter some text...")
                    .useFloatingWatermark(false)
                    .caretBrush(SolidColorBrush(Colors.DarkBlue))
                    .selectionBrush(SolidColorBrush(Colors.DarkBlue))
                    .selectionForegroundBrush(SolidColorBrush(Colors.White))
                    .width(300)
                    .horizontalAlignment(HorizontalAlignment.Left)

                TextBlock($"You Entered: {model.SingleLineText}")
                    .margin(0, 0, 0, 30)

                TextBox(model.MultiLineText, MultiLineTextChanged)
                    .height(120)
                    .textAlignment(TextAlignment.Left)
                    .verticalContentAlignment(VerticalAlignment.Top)
                    .acceptsReturn(true)
                    .acceptsTab(true)
                    .maxLines(5)
                    .watermark("Enter up to 5 lines of text...")
                    .useFloatingWatermark(true)
                    .caretBrush(SolidColorBrush(Colors.DarkBlue))
                    .selectionBrush(SolidColorBrush(Colors.DarkBlue))
                    .selectionForegroundBrush(SolidColorBrush(Colors.White))

                TextBlock($"You Entered: {model.MultiLineText}")
            }
        }
