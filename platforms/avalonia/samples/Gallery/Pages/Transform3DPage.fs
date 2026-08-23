namespace Gallery

open System.Diagnostics
open Avalonia
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module Transform3DPage =
    type Model =
        { CenterX: float
          CenterY: float
          CenterZ: float
          AngleX: float
          AngleY: float
          AngleZ: float }

    type Msg =
        | CenterXChanged of float
        | CenterYChanged of float
        | CenterZChanged of float
        | AngleXChanged of float
        | AngleYChanged of float
        | AngleZChanged of float


    let init () =
        { CenterX = 0.
          CenterY = 0.
          CenterZ = 0.
          AngleX = 0.
          AngleY = 0.
          AngleZ = 0. },
        Cmd.none

    let update msg model =
        match msg with
        | CenterXChanged value -> { model with CenterX = value }, Cmd.none
        | CenterYChanged value -> { model with CenterY = value }, Cmd.none
        | CenterZChanged value -> { model with CenterZ = value }, Cmd.none
        | AngleXChanged value -> { model with AngleX = value }, Cmd.none
        | AngleYChanged value -> { model with AngleY = value }, Cmd.none
        | AngleZChanged value -> { model with AngleZ = value }, Cmd.none

    let borderTestStyle (this: WidgetBuilder<'msg, IFabBorder>) =
        this
            .child(
                Image("avares://Gallery/Assets/Icons/fabulous-icon.png", Stretch.UniformToFill)
                    .margin(5)
            )
            .size(200., 200.)
            .borderThickness(2.)
            .borderBrush(SolidColorBrush(Colors.Black))

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
        Component("Transform3DPage") {
            let! model = Context.Mvu program

            Grid(coldefs = [ Auto; Star ], rowdefs = [ Star; Auto; Auto; Auto; Auto; Auto; Auto ]) {
                Border()
                    .style(borderTestStyle)
                    .background(
                        LinearGradientBrush(Point(0., 0.), Point(0., 1.)) {
                            GradientStop(Colors.Red, 0.)
                            GradientStop(Colors.Blue, 1.)
                        }
                    )
                    .gridRow(0)
                    .gridColumn(2)
                    .zIndex(-2)
                    .verticalAlignment(VerticalAlignment.Center)
                    .renderTransform(Rotate3DTransform(model.AngleX, model.AngleY, model.AngleZ, model.CenterX, model.CenterY, model.CenterZ, 200.))

                TextBlock("Center X: ").gridRow(1)

                Slider(-100., 100., model.CenterX, CenterXChanged)
                    .gridRow(1)
                    .gridColumn(2)

                TextBlock("Center Y: ").gridRow(2)

                Slider(-100., 100., model.CenterY, CenterYChanged)
                    .gridRow(2)
                    .gridColumn(2)

                TextBlock("Center Z: ").gridRow(3)

                Slider(-100., 100., model.CenterZ, CenterZChanged)
                    .gridRow(3)
                    .gridColumn(2)

                TextBlock("Angle X: ").gridRow(4)

                Slider(-180., 180., model.AngleX, AngleXChanged)
                    .gridRow(4)
                    .gridColumn(2)

                TextBlock("Angle Y: ").gridRow(5)

                Slider(-180., 180., model.AngleY, AngleYChanged)
                    .gridRow(5)
                    .gridColumn(2)

                TextBlock("Angle Z: ").gridRow(6)

                Slider(-180., 180., model.AngleZ, AngleZChanged)
                    .gridRow(6)
                    .gridColumn(2)
            }
        }
