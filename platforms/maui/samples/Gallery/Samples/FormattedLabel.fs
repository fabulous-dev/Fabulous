namespace Gallery.Samples

open Gallery
open Fabulous.Maui
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics
open type Fabulous.Maui.View

module FormattedLabel =
    type Model = Id

    type Msg =
        | TapCommand
        | OpenUrl of string

    let init () = Id

    let update msg model =
        match msg with
        | TapCommand -> model
        | OpenUrl _ -> model

    let view model =
        VStack(spacing = 15.) {
            (FormattedLabel() {
                Span("Red Bold, ").textColor(Colors.Red).font(attributes = FontAttributes.Bold)

                Span("default, ")
                    .font(size = 14.)
                    .gestureRecognizer(TapGestureRecognizer(TapCommand))

                Span("italic small.").font(attributes = FontAttributes.Italic, size = 12.)

            })
                .lineBreakMode(LineBreakMode.WordWrap)

            FormattedLabel() {
                Span("Alternatively, click ")

                Span("here")
                    .textColor(Colors.Blue)
                    .textDecorations(TextDecorations.Underline)
                    .gestureRecognizer(TapGestureRecognizer(OpenUrl "https://learn.microsoft.com/dotnet/maui/"))


                Span(" to view .NET MAUI documentation.")
            }
        }

    let sampleProgram = Helper.createProgram init update view

    let sample =
        { Name = "FormattedLabel"
          Description = "Control the appearance of a label with formatted text"
          Program = sampleProgram }
