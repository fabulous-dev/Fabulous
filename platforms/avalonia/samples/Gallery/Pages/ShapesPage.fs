namespace Gallery

open Avalonia
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module ShapesPage =
    let view () =
        VStack(spacing = 15.) {
            Rectangle()
                .size(100., 80.)
                .opacityMask(
                    LinearGradientBrush() {
                        GradientStop(Colors.Black, 0.)
                        GradientStop(Colors.Transparent, 1.)
                    }
                )
                .fill(SolidColorBrush(Colors.Blue))

            Ellipse()
                .fill(SolidColorBrush(Colors.Red))
                .size(100., 100.)
                .opacityMask(
                    LinearGradientBrush() {
                        GradientStop(Colors.Black, 0.)
                        GradientStop(Colors.Transparent, 1.)
                    }
                )

            Path("M 0,0 c 0,0 50,0 50,-50 c 0,0 50,0 50,50 h -50 v 50 l -50,-50 Z")
                .fill(SolidColorBrush(Colors.Orange))

            Path(
                PathGeometry(FillRule.NonZero) {
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
                .stroke(SolidColorBrush(Colors.Brown))
        }
