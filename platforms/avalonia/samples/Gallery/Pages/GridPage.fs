namespace Gallery

open System.Diagnostics
open Avalonia.Layout
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module GridPage =

    type Person =
        { FirstName: string
          LastName: string
          Age: int
          Occupation: string }

    type Model = { People: Person list }
    type Msg = | PressMe

    let init () =
        { People =
            [ { FirstName = "Jim"
                LastName = "Smith"
                Age = 35
                Occupation = "Printed Circuit Board Drafter" }
              { FirstName = "Charlotte"
                LastName = "O'Shaughnessy-Alejandro"
                Age = 30
                Occupation = "Librarian" }
              { FirstName = "Ryan"
                LastName = "Cullen"
                Age = 40
                Occupation = "Ceramics Instructor" }
              { FirstName = "Valentina"
                LastName = "Levine"
                Age = 38
                Occupation = "Oceanologist" } ] }

    let update msg model =
        match msg with
        | PressMe -> model

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

    let gridView1 () =
        VStack(16.) {
            (Grid() { TextBlock("By default, a Grid contains one row and one column.") })
                .margin(16.)

            Separator()

            (Grid(coldefs = [ Pixel(100); Pixel(100) ], rowdefs = [ Pixel(100); Pixel(100) ]) {
                TextBlock("Cell[0,0]")
                    .gridRow(0)
                    .gridColumn(0)
                    .background(SolidColorBrush(Colors.Aquamarine))

                TextBlock("Cell[0,1]")
                    .gridRow(0)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.Beige))

                TextBlock("Cell[1,0]")
                    .gridRow(1)
                    .gridColumn(0)
                    .background(SolidColorBrush(Colors.Lavender))

                TextBlock("Cell[1,1]")
                    .gridRow(1)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.LightBlue))
            })
                .showGridLines(true)
                .margin(16.)

            Separator()

            (Grid(coldefs = [ Auto; Pixel(100) ], rowdefs = [ Auto; Pixel(100) ]) {

                TextBlock("Cell[0,0]")
                    .gridRow(0)
                    .gridColumn(0)
                    .size(200., 300.)
                    .background(SolidColorBrush(Colors.Aquamarine))

                TextBlock("Cell[0,1]")
                    .gridRow(0)
                    .gridColumn(1)
                    .size(200., 300.)
                    .background(SolidColorBrush(Colors.Beige))

                TextBlock("Cell[1,0]")
                    .gridRow(1)
                    .gridColumn(0)
                    .size(100., 100.)
                    .background(SolidColorBrush(Colors.Lavender))

                TextBlock("Cell[1,1]")
                    .gridRow(1)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.LightBlue))

            })
                .margin(16.)

            Separator()

            Grid(coldefs = [ Auto; Star ], rowdefs = [ Auto; Star ]) {
                TextBlock("Cell[0,0]")
                    .gridRow(0)
                    .gridColumn(0)
                    .size(200., 300.)
                    .background(SolidColorBrush(Colors.Aquamarine))

                TextBlock("Cell[0,1]")
                    .gridRow(0)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.Beige))

                TextBlock("Cell[1,0]")
                    .gridRow(1)
                    .gridColumn(0)
                    .background(SolidColorBrush(Colors.Lavender))

                TextBlock("Cell[1,1]")
                    .gridRow(1)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.LightBlue))

            }

            Grid(coldefs = [ Auto; Stars(10); Stars(20) ], rowdefs = [ Auto; Star ]) {
                TextBlock("Cell[0,0]")
                    .gridRow(0)
                    .gridColumn(0)
                    .size(200., 300.)
                    .background(SolidColorBrush(Colors.Aquamarine))

                TextBlock("Cell[0,1]")
                    .gridRow(0)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.Beige))

                TextBlock("Cell[0,2]")
                    .gridRow(0)
                    .gridColumn(2)
                    .background(SolidColorBrush(Colors.Cyan))

                TextBlock("Cell[1,0]")
                    .gridRow(1)
                    .gridColumn(0)
                    .background(SolidColorBrush(Colors.Lavender))

                TextBlock("Cell[1,1]")
                    .gridRow(1)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.White))

                TextBlock("Cell[1,2]")
                    .gridRow(1)
                    .gridColumn(2)
                    .background(SolidColorBrush(Colors.Yellow))

            }

            Grid(coldefs = [ Auto; Star; Stars(4); Stars(2); Stars(3) ], rowdefs = [ Auto; Star ]) {
                TextBlock("Cell[0,0]")
                    .gridRow(0)
                    .gridColumn(0)
                    .size(200., 300.)
                    .background(SolidColorBrush(Colors.Aquamarine))

                TextBlock("Cell[0,1]")
                    .gridRow(0)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.Beige))

                TextBlock("Cell[0,2]")
                    .gridRow(0)
                    .gridColumn(2)
                    .background(SolidColorBrush(Colors.Cyan))

                TextBlock("Cell[0,3]")
                    .gridRow(0)
                    .gridColumn(3)
                    .background(SolidColorBrush(Colors.Magenta))

                TextBlock("Cell[0,4]")
                    .gridRow(0)
                    .gridColumn(4)
                    .background(SolidColorBrush(Colors.LightBlue))

                TextBlock("Cell[1,0]")
                    .gridRow(1)
                    .gridColumn(0)
                    .background(SolidColorBrush(Colors.Lavender))

                TextBlock("Cell[1,1]")
                    .gridRow(1)
                    .gridColumn(1)
                    .background(SolidColorBrush(Colors.White))

                TextBlock("Cell[1,2]")
                    .gridRow(1)
                    .gridColumn(2)
                    .background(SolidColorBrush(Colors.Yellow))

                TextBlock("Cell[1,3]")
                    .gridRow(1)
                    .gridColumn(3)
                    .background(SolidColorBrush(Colors.LightGray))

                TextBlock("Cell[1,4]")
                    .gridRow(1)
                    .gridColumn(4)
                    .background(SolidColorBrush(Colors.Coral))

            }
        }

    let gridView2 people =
        VStack() {
            ListBox(
                people,
                fun x ->
                    ListBoxItem(
                        Grid(coldefs = [ SharedSizeGroup("A"); SharedSizeGroup("B"); Star; SharedSizeGroup("C") ], rowdefs = [ Auto; Auto ]) {
                            TextBlock(x.FirstName).gridColumn(0).margin(6., 0.)

                            TextBlock(x.LastName).gridColumn(1).margin(6., 0.)

                            TextBlock(x.Age.ToString()).gridColumn(2).margin(6., 0.)

                            TextBlock(x.Occupation).gridColumn(3).margin(6., 0.)
                        }
                        |> _.showGridLines(true)
                    )
                        .padding(0.)
            )

            Separator()

            Grid(coldefs = [ SharedSizeGroup("A"); SharedSizeGroup("B"); Star; SharedSizeGroup("C") ], rowdefs = [ Auto; Auto ]) {
                Button("This is the First Name", PressMe)
                    .gridColumn(0)
                    .horizontalAlignment(HorizontalAlignment.Stretch)

                Button("Last", PressMe)
                    .gridColumn(1)
                    .horizontalAlignment(HorizontalAlignment.Stretch)

                Button("Age", PressMe)
                    .gridColumn(2)
                    .horizontalAlignment(HorizontalAlignment.Stretch)

                Button("Occupation", PressMe)
                    .gridColumn(3)
                    .horizontalAlignment(HorizontalAlignment.Stretch)
            }
            |> _.showGridLines(true)
            |> _.rowSpacing(10.)
            |> _.columnSpacing(10.)

        }
        |> _.isSharedSizeScope(true)

    let gridSpacingView () =
        VStack(spacing = 20.) {
            TextBlock("Grid with Spacing Examples")
                .fontWeight(FontWeight.Bold)
                .fontSize(18.)

            TextBlock("Basic Grid with Spacing (2x2)")
                .fontWeight(FontWeight.Bold)
                .fontSize(16.)
                .margin(0., 0., 0., 5.)

            (Grid(coldefs = [ Pixel(100); Pixel(100) ], rowdefs = [ Pixel(100); Pixel(100) ]) {
                Border()
                    .background(SolidColorBrush(Colors.LightBlue))
                    .gridRow(0)
                    .gridColumn(0)

                Border()
                    .background(SolidColorBrush(Colors.LightGreen))
                    .gridRow(0)
                    .gridColumn(1)

                Border()
                    .background(SolidColorBrush(Colors.LightPink))
                    .gridRow(1)
                    .gridColumn(0)

                Border()
                    .background(SolidColorBrush(Colors.LightYellow))
                    .gridRow(1)
                    .gridColumn(1)
            })
                .rowSpacing(10.)
                .columnSpacing(10.)
                .showGridLines(true)
                .margin(0., 0., 0., 20.)

            TextBlock("Complex Grid with Mixed Sizing")
                .fontWeight(FontWeight.Bold)
                .fontSize(16.)
                .margin(0., 0., 0., 5.)

            (Grid(coldefs = [ Pixel(50); Star; Stars(2); Auto ], rowdefs = [ Pixel(50); Star; Stars(2); Auto ]) {
                Border()
                    .background(SolidColorBrush(Colors.LightBlue))
                    .gridRow(0)
                    .gridColumn(0)

                Border()
                    .background(SolidColorBrush(Colors.LightGreen))
                    .gridRow(1)
                    .gridColumn(1)

                Border()
                    .background(SolidColorBrush(Colors.LightPink))
                    .gridRow(2)
                    .gridColumn(2)

                Border()
                    .background(SolidColorBrush(Colors.LightYellow))
                    .width(30.)
                    .height(30.)
                    .gridRow(3)
                    .gridColumn(3)
            })
                .rowSpacing(10.)
                .columnSpacing(10.)
                .width(200.)
                .height(200.)
                .showGridLines(true)
                .margin(0., 0., 0., 20.)

            TextBlock("Grid with Spacing Overflow")
                .fontWeight(FontWeight.Bold)
                .fontSize(16.)
                .margin(0., 0., 0., 5.)

            (Grid(coldefs = [ Pixel(30); Star; Star; Auto ], rowdefs = [ Pixel(30); Star; Star; Auto ]) {
                Border()
                    .background(SolidColorBrush(Colors.LightBlue))
                    .gridRow(0)
                    .gridColumn(0)

                Border()
                    .background(SolidColorBrush(Colors.LightGreen))
                    .gridRow(1)
                    .gridColumn(1)

                Border()
                    .background(SolidColorBrush(Colors.LightPink))
                    .gridRow(2)
                    .gridColumn(2)

                Border()
                    .background(SolidColorBrush(Colors.LightYellow))
                    .width(30.)
                    .height(30.)
                    .gridRow(3)
                    .gridColumn(3)
            })
                .rowSpacing(20.)
                .columnSpacing(20.)
                .width(100.)
                .height(100.)
                .showGridLines(true)
                .margin(0., 0., 0., 20.)

            TextBlock("Notice how excessive spacing can cause interior cells to have 0 width/height.")
                .textWrapping(TextWrapping.Wrap)
                .opacity(0.8)
        }

    let view () =
        Component("GridPage") {
            let! model = Context.Mvu program

            (TabControl() {
                TabItem("Grids", gridView1())

                TabItem("SharedSizeGroup", gridView2 model.People)

                TabItem("Grid Spacing", gridSpacingView())
            })
                .margin(0., 16.)

        }
