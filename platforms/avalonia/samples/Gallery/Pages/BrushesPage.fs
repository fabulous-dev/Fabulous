namespace Gallery

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia


open type Fabulous.Avalonia.View

module BrushesPage =
    let view () =
        (Canvas() {
            Rectangle()
                .canvasLeft(20.0)
                .canvasTop(20.0)
                .width(440.0)
                .height(50.0)
                .fill(
                    (LinearGradientBrush(Point(0., 0.), Point(410., 0.0), RelativeUnit.Absolute) {
                        GradientStop(Colors.Blue, 0.)
                        GradientStop(Colors.Green, 0.5)
                        GradientStop(Colors.Lime, 1.0)
                    })
                        .transform(
                            TransformGroup() {
                                ScaleTransform(0.5)
                                SkewTransform()
                                RotateTransform()
                                TranslateTransform(5., 15.)
                            }
                        )
                )

            TextBlock("scale(0.5) on gradient")
                .canvasLeft(20.0)
                .canvasTop(70.0)
                .fontSize(30.0)

            Rectangle()
                .canvasLeft(20.0)
                .canvasTop(110.0)
                .width(440.0)
                .height(50.0)
                .fill(
                    (RadialGradientBrush(Point(0., 0.), Point(0., 0.), RelativeUnit.Absolute) {
                        GradientStop(Colors.Black, 0.)
                        GradientStop(Colors.Orange, 1.0)
                    })
                        .radiusX(0.13636364)
                        .transform(
                            TransformGroup() {
                                ScaleTransform()
                                SkewTransform(45.)
                                RotateTransform()
                                TranslateTransform(240., 45.)
                            }
                        )
                )

            TextBlock("skewX(45) on gradient")
                .canvasLeft(20.0)
                .canvasTop(160.0)
                .fontSize(30.0)

            Rectangle()
                .canvasLeft(20.0)
                .canvasTop(210.0)
                .width(440.0)
                .height(50.0)
                .fill(
                    ImageBrush("avares://Gallery/Assets/Icons/fabulous-icon.png")
                        .tileMode(TileMode.Tile)
                        .sourceRect(Point(0., 0.), Size(20., 20.), RelativeUnit.Absolute)
                        .destinationRect(Point(0., 0.), Size(20., 20.), RelativeUnit.Absolute)
                        .stretch(Stretch.None)
                        .transform(
                            TransformGroup() {
                                ScaleTransform(2., 2.)
                                SkewTransform(45.)
                                RotateTransform()
                                TranslateTransform(5., 5.)
                            }
                        )
                )

            Rectangle()
                .canvasLeft(20.0)
                .canvasTop(260.0)
                .width(440.0)
                .height(50.0)
                .fill(
                    ConicGradientBrush(Point(30., 30.), RelativeUnit.Absolute, 90.) {
                        GradientStop(Colors.Red, 0.)
                        GradientStop(Colors.Blue, 0.25)
                        GradientStop(Colors.Brown, 0.5)
                        GradientStop(Colors.Green, 0.75)
                        GradientStop(Colors.Purple, 0.1)
                    }
                )

            Rectangle()
                .canvasLeft(20.0)
                .canvasTop(410.0)
                .width(440.0)
                .height(50.0)
                .fill(
                    VisualBrush(
                        (Canvas() {
                            Rectangle()
                                .canvasLeft(0.0)
                                .canvasTop(0.0)
                                .width(10.0)
                                .height(10.0)
                                .fill(SolidColorBrush(Colors.Maroon))

                            Rectangle()
                                .canvasLeft(10.0)
                                .canvasTop(0.0)
                                .width(10.0)
                                .height(10.0)
                                .fill(SolidColorBrush(Colors.Green))

                            Rectangle()
                                .canvasLeft(0.0)
                                .canvasTop(10.0)
                                .width(10.0)
                                .height(10.0)
                                .fill(SolidColorBrush(Colors.Blue))

                            Rectangle()
                                .canvasLeft(10.0)
                                .canvasTop(10.0)
                                .width(10.0)
                                .height(10.0)
                                .fill(SolidColorBrush(Colors.Yellow))
                        })
                            .width(20.0)
                            .height(20.0)

                    )
                        .stretch(Stretch.None)
                        .tileMode(TileMode.Tile)
                        .sourceRect(RelativeRect(0., 0., 20., 20., RelativeUnit.Absolute))
                        .destinationRect(RelativeRect(0., 0., 20., 20., RelativeUnit.Absolute))
                        .transform(
                            TransformGroup() {
                                ScaleTransform(2., 2.)
                                SkewTransform(45.)
                                RotateTransform()
                                TranslateTransform(5., 5.)
                            }
                        )
                )

            TextBlock("scale(2), skewX(45) on pattern")
                .canvasLeft(20.0)
                .canvasTop(460.0)
                .fontSize(30.0)

        })
            .width(480.0)
            .height(360.0)
