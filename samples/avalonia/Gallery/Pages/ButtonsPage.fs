namespace Gallery

open System.Diagnostics
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Styling
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ButtonsPage =
    type Model = { IsVisited: bool }

    type Msg =
        | Clicked
        | IsVisitedChanged of bool
        | Checked of bool

    let init () = { IsVisited = false }

    let update msg model =
        match msg with
        | Clicked -> model
        | IsVisitedChanged value ->
            printfn $"IsVisitedChanged: {value}"
            model
        | Checked value -> { model with IsVisited = value }

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
        Component("ButtonsPage") {
            let! model = Context.Mvu program

            (VStack(spacing = 15.) {
                Button("Regular button", Clicked)

                Button("Disabled button", Clicked).isEnabled(false)

                Button("White text, red background", Clicked)
                    .background(SolidColorBrush(Colors.Red))
                    .foreground(SolidColorBrush(Colors.White))
                    .width(200.)

                Button(
                    Clicked,
                    HStack() {
                        Image("avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                            .size(32., 32.)

                        TextBlock("Button with image")
                    }
                )

                Button("No Border", Clicked).borderThickness(0.)

                Button("Border Color", Clicked)
                    .borderBrush(SolidColorBrush(Color.Parse("#FF0000")))

                Button("Thick Border", Clicked)
                    .borderBrush(SolidColorBrush(Color.Parse("#FF0000")))
                    .borderThickness(4.)

                Button("Disabled", Clicked)
                    .borderBrush(SolidColorBrush(Color.Parse("#FF0000")))
                    .borderThickness(4.)
                    .isEnabled(false)

                Button("IsTabStop=False", Clicked)
                    .borderBrush(SolidColorBrush(Color.Parse("#FF0000")))
                    .isTabStop(false)

                ThemeVariantScope(ThemeVariant.Light, Button("Light Button", Clicked))

                ThemeVariantScope(ThemeVariant.Dark, Button("Dark Button", Clicked))

                HyperlinkButton("Google", "https://www.google.com")
                    .onVisitedChanged(model.IsVisited, IsVisitedChanged)

                HStack() {
                    HyperlinkButton("Google", "https://www.google.com")
                        .onVisitedChanged(model.IsVisited, IsVisitedChanged)

                    CheckBox("IsVisited", model.IsVisited, Checked)
                }

            })
                .horizontalAlignment(HorizontalAlignment.Center)
        }
