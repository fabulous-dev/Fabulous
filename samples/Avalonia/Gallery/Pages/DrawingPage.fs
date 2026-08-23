namespace Gallery

open Avalonia
open Avalonia.Layout
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module DrawingPage =
    let bulb () =
        (DrawingGroup() {
            (DrawingGroup() { GeometryDrawing(brush = "#FF7F8C8D", geometry = "F1 M24,14 A2,2,0,1,1,20,14 A2,2,0,1,1,24,14 z") })
                .transform(MatrixTransform(Matrix.Parse("1,0,0,1.25,-10,1031.4")))

            GeometryDrawing(
                brush = "#FFF39C12",
                geometry =
                    "F1 M12,1030.4 C8.134,1030.4 5,1033.6 5,1037.6 5,1040.7 8.125,1043.5 9,1045.4 9.875,1047.2 9,1050.4 9,1050.4 L12,1049.9 15,1050.4 C15,1050.4 14.125,1047.2 15,1045.4 15.875,1043.5 19,1040.7 19,1037.6 19,1033.6 15.866,1030.4 12,1030.4 z"
            )

            GeometryDrawing(
                brush = "#FFF1C40F",
                geometry =
                    "F1 M12,1030.4 C15.866,1030.4 19,1033.6 19,1037.6 19,1040.7 15.875,1043.5 15,1045.4 14.125,1047.2 15,1050.4 15,1050.4 L12,1049.9 12,1030.4 z"
            )

            GeometryDrawing(
                brush = "#FFE67E22",
                geometry =
                    "F1 M9,1036.4 L8,1037.4 12,1049.4 16,1037.4 15,1036.4 14,1037.4 13,1036.4 12,1037.4 11,1036.4 10,1037.4 9,1036.4 z M9,1037.4 L10,1038.4 10.5,1037.9 11,1037.4 11.5,1037.9 12,1038.4 12.5,1037.9 13,1037.4 13.5,1037.9 14,1038.4 15,1037.4 15.438,1037.8 12,1048.1 8.5625,1037.8 9,1037.4 z"
            )

            (DrawingGroup() { GeometryDrawing(RectangleGeometry(Rect.Parse("0,0,6,5")), "#FFBDC3C7") })
                .transform(MatrixTransform(Matrix.Parse("1,0,0,1,9,1045.4")))

            GeometryDrawing(
                brush = "#FF95A5A6",
                geometry =
                    "F1 M9,1045.4 L9,1050.4 12,1050.4 12,1049.4 15,1049.4 15,1048.4 12,1048.4 12,1047.4 15,1047.4 15,1046.4 12,1046.4 12,1045.4 9,1045.4 z"
            )

            GeometryDrawing(
                brush = "#FF7F8C8D",
                geometry = "F1 M9,1046.4 L9,1047.4 12,1047.4 12,1046.4 9,1046.4 z M9,1048.4 L9,1049.4 12,1049.4 12,1048.4 9,1048.4 z"
            )
        })
            .transform(MatrixTransform(Matrix.Parse("1,0,0,1,0,-1028.4")))

    let view () =
        (Grid(rowdefs = [ Auto; Auto; Auto ], coldefs = [ Auto; Auto; Auto; Auto; Auto ]) {
            TextBlock("None").margin(3.)

            Border(Image(Stretch.None, DrawingImage(bulb())))
                .gridColumn(0)
                .gridRow(1)
                .verticalAlignment(VerticalAlignment.Top)
                .horizontalAlignment(HorizontalAlignment.Left)
                .borderThickness(1.)
                .borderBrush(SolidColorBrush(Colors.Gray))
                .margin(5.)

            TextBlock("Fill").margin(3.).gridColumn(1)

            Border(
                Image(Stretch.Fill, DrawingImage(bulb()))
                    .width(100.)
                    .height(50.)
            )
                .gridColumn(1)
                .gridRow(1)
                .verticalAlignment(VerticalAlignment.Top)
                .horizontalAlignment(HorizontalAlignment.Left)
                .borderThickness(1.)
                .borderBrush(SolidColorBrush(Colors.Gray))
                .margin(5.)

            TextBlock("Uniform").margin(3.).gridColumn(2)

            Border(
                Image(Stretch.Uniform, DrawingImage(bulb()))
                    .width(100.)
                    .height(50.)
            )
                .gridColumn(2)
                .gridRow(1)
                .verticalAlignment(VerticalAlignment.Top)
                .horizontalAlignment(HorizontalAlignment.Left)
                .borderThickness(1.)
                .borderBrush(SolidColorBrush(Colors.Gray))
                .margin(5.)

            TextBlock("UniformToFill").margin(3.).gridColumn(3)

            Border(
                Image(Stretch.UniformToFill, DrawingImage(bulb()))
                    .width(100.)
                    .height(50.)
            )
                .gridColumn(3)
                .gridRow(1)
                .verticalAlignment(VerticalAlignment.Top)
                .horizontalAlignment(HorizontalAlignment.Left)
                .borderThickness(1.)
                .borderBrush(SolidColorBrush(Colors.Gray))
                .margin(5.)

            Ellipse()
                .gridRow(2)
                .gridColumn(0)
                .width(100.)
                .height(50.)
                .stretch(Stretch.None)
                .fill(SolidColorBrush(Colors.Blue))
                .margin(5.)

            Ellipse()
                .gridRow(2)
                .gridColumn(1)
                .width(100.)
                .height(50.)
                .stretch(Stretch.Fill)
                .fill(SolidColorBrush(Colors.Blue))
                .margin(5.)

            Ellipse()
                .gridRow(2)
                .gridColumn(2)
                .width(100.)
                .height(50.)
                .stretch(Stretch.Uniform)
                .fill(SolidColorBrush(Colors.Blue))
                .margin(5.)

            Ellipse()
                .gridRow(2)
                .gridColumn(3)
                .width(100.)
                .height(50.)
                .stretch(Stretch.UniformToFill)
                .fill(SolidColorBrush(Colors.Blue))
                .margin(5.)

            Ellipse()
                .width(100.)
                .height(50.)
                .gridColumn(4)
                .gridRow(2)
                .stroke(Brushes.White)
                .strokeThickness(0.)
                .fill(
                    DrawingBrush(
                        GeometryDrawing(
                            GeometryGroup(FillRule.NonZero) {
                                RectangleGeometry(Rect(50., 25., 25., 25.))
                                RectangleGeometry(Rect(25., 50., 25., 25.))
                            },
                            Brushes.Yellow
                        )
                            .pen(
                                Pen(
                                    LinearGradientBrush() {
                                        GradientStop(Colors.Blue, 0.)
                                        GradientStop(Colors.Black, 1.)
                                    },
                                    5.
                                )
                            )
                    )
                )
        })
            .centerHorizontal()
            .centerVertical()
