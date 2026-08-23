namespace Gallery

open System.Diagnostics
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module UniformGridPage =
    type Model = { Nothing: bool }

    type Msg = DoNothing

    let init () = { Nothing = true }, Cmd.none

    let update msg model =
        match msg with
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

    let basicUniformGridView () =
        VStack() {
            (UniformGrid(rows = 1) {
                Button("No", DoNothing)
                    .gridColumn(0)
                    .fontSize(18)
                    .margin(5)
                    .padding(6, 3)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Stretch)

                Button("Yes, Absolutely", DoNothing)
                    .gridColumn(1)
                    .margin(5)
                    .padding(6, 3)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Stretch)

                Button("Maybe", DoNothing)
                    .gridColumn(2)
                    .margin(5)
                    .padding(6, 3)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .verticalAlignment(VerticalAlignment.Stretch)
            })
                .margin(10.)
                .horizontalAlignment(HorizontalAlignment.Center)
                .verticalAlignment(VerticalAlignment.Center)
                .rowSpacing(10.)
                .columnSpacing(10.)

            UniformGrid() {
                Border(TextBlock("1"))
                    .background(SolidColorBrush(Colors.AliceBlue))
                    .gridColumnSpan(2)

                Border(TextBlock("2"))
                    .background(SolidColorBrush(Colors.Cornsilk))

                Border(TextBlock("3"))
                    .background(SolidColorBrush(Colors.DarkSalmon))

                Border(TextBlock("4"))
                    .background(SolidColorBrush(Colors.Gainsboro))
                    .gridRowSpan(2)

                Border(TextBlock("5"))
                    .background(SolidColorBrush(Colors.LightBlue))

                Border(TextBlock("6"))
                    .background(SolidColorBrush(Colors.MediumAquamarine))

                Border(TextBlock("7"))
                    .background(SolidColorBrush(Colors.MistyRose))
            }
        }

    let spacingDemonstrationView () =
        VStack(spacing = 20.) {
            TextBlock("UniformGrid Spacing Examples")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)

            TextBlock("Column Spacing Only")
                .fontWeight(FontWeight.Bold)
                .fontSize(16.)
                .margin(0., 0., 0., 5.)

            Border(
                UniformGrid() {
                    Border(TextBlock("50×70"))
                        .width(50.)
                        .height(70.)
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("30×50"))
                        .width(30.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightGreen))

                    Border(TextBlock("80×90"))
                        .width(80.)
                        .height(90.)
                        .background(SolidColorBrush(Colors.LightPink))
                }
                |> _.columnSpacing(10.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)
                .margin(0., 0., 0., 20.)

            TextBlock("Row Spacing Only")
                .fontWeight(FontWeight.Bold)
                .fontSize(16.)
                .margin(0., 0., 0., 5.)

            Border(
                UniformGrid() {
                    Border(TextBlock("50×70"))
                        .width(50.)
                        .height(70.)
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("30×50"))
                        .width(30.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightGreen))

                    Border(TextBlock("80×90"))
                        .width(80.)
                        .height(90.)
                        .background(SolidColorBrush(Colors.LightPink))
                }
                |> _.rowSpacing(15.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)
                .margin(0., 0., 0., 20.)

            TextBlock("Both Row and Column Spacing (Fixed Grid)")
                .fontWeight(FontWeight.Bold)
                .fontSize(16.)
                .margin(0., 0., 0., 5.)

            Border(
                UniformGrid(rows = 2, cols = 2) {
                    Border(TextBlock("50×70"))
                        .width(50.)
                        .height(70.)
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("30×50"))
                        .width(30.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightGreen))

                    Border(TextBlock("80×90"))
                        .width(80.)
                        .height(90.)
                        .background(SolidColorBrush(Colors.LightPink))

                    Border(TextBlock("20×30"))
                        .width(20.)
                        .height(30.)
                        .background(SolidColorBrush(Colors.LightYellow))
                }
                |> _.rowSpacing(10.)
                |> _.columnSpacing(5.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)
                .margin(0., 0., 0., 20.)

            TextBlock("Spacing with Invisible Child")
                .fontWeight(FontWeight.Bold)
                .fontSize(16.)
                .margin(0., 0., 0., 5.)

            Border(
                UniformGrid() {
                    Border(TextBlock("50×70"))
                        .width(50.)
                        .height(70.)
                        .background(SolidColorBrush(Colors.LightBlue))

                    Border(TextBlock("80×90 (Invisible)"))
                        .width(80.)
                        .height(90.)
                        .background(SolidColorBrush(Colors.Gray))
                        .opacity(0.5)
                        .isVisible(false)

                    Border(TextBlock("30×50"))
                        .width(30.)
                        .height(50.)
                        .background(SolidColorBrush(Colors.LightGreen))

                    Border(TextBlock("40×60"))
                        .width(40.)
                        .height(60.)
                        .background(SolidColorBrush(Colors.LightPink))
                }
                |> _.rowSpacing(5.)
                |> _.columnSpacing(5.)
            )
                .borderBrush(SolidColorBrush(Colors.Gray))
                .borderThickness(1.)
                .margin(0., 0., 0., 20.)

            TextBlock(
                "Note: Each example matches the dimensions and spacing used in the C# unit tests. The borders show the outer boundary of each UniformGrid."
            )
                .textWrapping(TextWrapping.Wrap)
                .opacity(0.8)
        }

    let view () =
        Component("UniformGridPage") {
            let! _ = Context.Mvu program

            TabControl() {
                TabItem("Basic Examples", basicUniformGridView())
                TabItem("Spacing Examples", spacingDemonstrationView())
            }
        }
