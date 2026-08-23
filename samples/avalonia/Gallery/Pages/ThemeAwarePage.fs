namespace Gallery

open System.Diagnostics
open Avalonia.Controls
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Styling
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module ThemeAwarePage =
    type Model =
        { ScopeTheme: ThemeVariant
          Items: ThemeVariant list
          Text: string
          Text2: string }

    type Msg =
        | OnScopeThemeSelectionChanged of SelectionChangedEventArgs
        | TextChanged of string
        | Text2Changed of string
        | DoNothing

    let init () =

        { ScopeTheme = ThemeVariant.Default
          Items = [ ThemeVariant.Default; ThemeVariant.Dark; ThemeVariant.Light ]
          Text = ""
          Text2 = "" },
        Cmd.none

    let update msg model =
        match msg with
        | OnScopeThemeSelectionChanged args ->
            let control = args.Source :?> ComboBox
            let index = control.SelectedIndex
            let variant = model.Items[index]

            { model with ScopeTheme = variant }, Cmd.none

        | TextChanged text -> { model with Text = text }, Cmd.none

        | Text2Changed text -> { model with Text2 = text }, Cmd.none

        | DoNothing -> model, Cmd.none

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
        Component("ThemeAwarePage") {
            let! model = Context.Mvu program
            let! theme = Context.Environment(EnvironmentKeys.Theme)

            VStack(spacing = 15.) {
                TextBlock($"Actual theme variant is: {theme.ToString()}")
                TextBlock($"ScopedTheme is: {model.ScopeTheme.ToString()}")

                TextBlock("I'm a text that is theme aware.")
                    .foreground(SolidColorBrush(ThemeAware.With(Colors.Red, Colors.Green)))

                ThemeVariantScope(ThemeVariant.Light, TextBlock("Im a text only visible in light mode"))

                ThemeVariantScope(ThemeVariant.Dark, TextBlock("Im a text only visible in dark mode"))

                ThemeVariantScope(
                    model.ScopeTheme,
                    Border(
                        Grid(coldefs = [ Pixel(150.); Pixel(150.) ], rowdefs = [ Auto; Pixel(4.); Auto; Pixel(4.); Auto; Pixel(4.); Auto ]) {
                            ComboBox(model.Items)
                                .gridColumn(0)
                                .gridRow(0)
                                .horizontalAlignment(HorizontalAlignment.Stretch)
                                .selectedIndex(0)
                                .onSelectionChanged(OnScopeThemeSelectionChanged)

                            TextBlock("Username:")
                                .gridColumn(0)
                                .gridRow(2)
                                .verticalAlignment(VerticalAlignment.Center)

                            TextBlock("Password:")
                                .gridColumn(0)
                                .gridRow(4)
                                .verticalAlignment(VerticalAlignment.Center)

                            TextBox(model.Text, TextChanged)
                                .watermark("Input here")
                                .gridColumn(1)
                                .gridRow(2)
                                .horizontalAlignment(HorizontalAlignment.Stretch)

                            TextBox(model.Text2, Text2Changed)
                                .watermark("Input here")
                                .gridColumn(1)
                                .gridRow(4)
                                .horizontalAlignment(HorizontalAlignment.Stretch)

                            Button("Login", DoNothing)
                                .gridColumn(1)
                                .gridRow(6)
                                .horizontalAlignment(HorizontalAlignment.Stretch)
                        }
                    )
                        .verticalAlignment(VerticalAlignment.Top)
                        .horizontalAlignment(HorizontalAlignment.Left)
                        .padding(4.)
                        .cornerRadius(4.)
                )
            }
        }
