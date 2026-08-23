namespace Gallery.Samples

open Gallery
open Fabulous.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Controls.Shapes
open Microsoft.Maui.Graphics
open type Fabulous.Maui.View

module Shapes =
    type Model = Id

    type Msg = Id

    let init () = Id

    let update msg model =
        match msg with
        | Id -> model

    let view _ =
        (VStack(spacing = 15.) {
            Rectangle()
                .size(100., 80.)
                .background(
                    LinearGradientBrush() {
                        GradientStop(0., Colors.Black)
                        GradientStop(1., Colors.Gray)
                    }
                )
                .fill(SolidColorBrush(Colors.Blue))

            Ellipse()
                .size(100., 80.)
                .background(
                    LinearGradientBrush() {
                        GradientStop(0., Colors.Blue)
                        GradientStop(1., Colors.Green)
                    }
                )
                .fill(SolidColorBrush(Colors.Red))

            Path("M 0,0 c 0,0 50,0 50,-50 c 0,0 50,0 50,50 h -50 v 50 l -50,-50 Z")
                .fill(SolidColorBrush(Colors.Orange))

            Path(
                PathGeometry(FillRule.Nonzero) {
                    (PathFigure(Point(0., 0.)) {
                        QuadraticBezierSegment(Point(50., 0.), Point(50., -50.))
                        QuadraticBezierSegment(Point(100., -50.), Point(100., 0.))
                        LineSegment(Point(50., 0.))
                        LineSegment(Point(50., 50.))
                    })
                        .isClosed(true)
                }
            )
                .fill(SolidColorBrush(Colors.OrangeRed))

            Line(Point(120., 185.), Point(30., 115.))
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(2.)

            Polygon(
                [ Point(75., 0.)
                  Point(120., 120.)
                  Point(0., 45.)
                  Point(150., 45.)
                  Point(30., 120.) ]
            )
                .stroke(SolidColorBrush(Colors.DarkBlue))
                .strokeThickness(1.)
                .fill(SolidColorBrush(Colors.Violet))

            Polyline("20 20,250 50,20 120")
                .strokeLineJoin(PenLineJoin.Round)
                .stroke(SolidColorBrush(Colors.DarkBlue))
                .strokeThickness(5.)

            Polyline(
                [ Point(0., 0.)
                  Point(65., 0.)
                  Point(78., -26.)
                  Point(91., 39.)
                  Point(104., -39.)
                  Point(117., 13.)
                  Point(130., 0.)
                  Point(195., 0.) ]
            )
                .stroke(Brush.Brown)
        })
            .centerHorizontal()

    let sample =
        { Name = "2D Shapes and Geometries"
          Description = "Vector-drawn 2D shapes such as Ellipse, Line, Path, Polygon, Polyline and Rectangle."
          Program = Helper.createProgram init update view }
