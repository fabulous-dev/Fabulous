namespace Gallery

open System.Diagnostics
open Avalonia.Interactivity
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous
open Avalonia.Controls

open type Fabulous.Avalonia.View

module SelectableTextBlockPage =
    type Model = { Text: string }

    type Msg = CopyingToClipboard of RoutedEventArgs

    let init () = { Text = "" }, Cmd.none

    let update msg model =
        match msg with
        | CopyingToClipboard args ->
            let control = args.Source :?> SelectableTextBlock
            let s = control.SelectedText
            { Text = s }, Cmd.none

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
        Component("SelectableTextBlockPage") {
            let! model = Context.Mvu program

            VStack(spacing = 15.) {

                TextBlock($"Copied to clipboard {model.Text}")

                SelectableTextBlock("Select some text. You can use the cursor to change the selection.", CopyingToClipboard)
                    .selectionBrush(SolidColorBrush(Colors.LightBlue))
                    .selectionStart(7)
                    .selectionEnd(11)

                Border(
                    SelectableTextBlock(CopyingToClipboard) {
                        Run("This ")

                        Span() { Run("is").fontWeight(FontWeight.Bold) }

                        Run(" a ")

                        Span() {
                            Run("TextBlock")
                                .background(SolidColorBrush(Colors.Silver))
                                .foreground(SolidColorBrush(Colors.Maroon))
                        }

                        Run(" with ")

                        Span() {
                            Run("several")
                                .textDecoration(TextDecoration(TextDecorationLocation.Underline))
                        }

                        Span() { Run("Span").fontStyle(FontStyle.Italic) }

                        Run(" elements, ")

                        Span() {
                            Run("using a ")
                            Bold("variety")
                            Run(" of ")
                            Italic("styles")
                        }
                    }
                )
            }
        }
