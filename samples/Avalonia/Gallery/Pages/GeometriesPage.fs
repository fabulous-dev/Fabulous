namespace Gallery

open Avalonia.Layout
open Avalonia
open Avalonia.Media
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module GeometriesPage =
    let path =
        "M3 2C3.27614 2 3.5 2.22386 3.5 2.5V5.5C3.5 5.77614 3.72386 6 4 6H16C16.2761 6 16.5 5.77614 29 15.5C10.5 15.3225 10.4921 15.1549 10.4765 15H9.52346Z"

    let view () =
        VStack(spacing = 4.) {
            TextBlock("Geometries")
                .fontSize(20.)
                .fontWeight(FontWeight.Bold)
                .horizontalAlignment(HorizontalAlignment.Center)

            TextBlock("EllipseGeometry, which represents the geometry of an ellipse or circle.")

            Path(EllipseGeometry(50., 50.).center(Point(50., 50.)))
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))

            TextBlock("LineGeometry, which represents the geometry of a line.")

            Path(LineGeometry(Point(10., 20.), Point(100., 130.)))
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(2.)

            TextBlock("PathGeometry, which represents the geometry of a complex shape that can be composed of arcs, curves, ellipses, lines, and rectangles.")

            Path(PathGeometry(path, FillRule.EvenOdd))
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))
                .size(100., 100.)

            TextBlock("PolygonGeometry, which represents the geometry of a polygon.")

            Path(PolylineGeometry([ Point(0., 0.); Point(50., 50.); Point(0., 50.) ], true))
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(2.)

            TextBlock("RectangleGeometry, which represents the geometry of a rectangle.")

            Path(RectangleGeometry(Rect(10., 20., 150., 100.)))
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))


            TextBlock("LineSegment, which creates a line between two points.")

            Path(PathGeometry(FillRule.EvenOdd) { PathFigure(Point(10., 50.)) { LineSegment(Point(10., 150.)) } })
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(2.)

            TextBlock("ArcSegment, which creates an elliptical arc between two points.")

            Path(
                PathGeometry(FillRule.EvenOdd) {
                    PathFigure(Point(10., 50.)) {
                        ArcSegment(Point(200., 100.), Size(100., 50.))
                            .rotationAngle(45.)
                            .isLargeArc(true)
                            .sweepDirection(SweepDirection.Clockwise)
                    }
                }
            )
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(2.)

            TextBlock("BezierSegment, which creates a cubic Bezier curve between two points.")

            Path(PathGeometry(FillRule.EvenOdd) { PathFigure(Point(10., 50.)) { BezierSegment(Point(100., 0.), Point(200., 200.), Point(300., 100.)) } })
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(2.)

            TextBlock("PolyLineSegment, which creates a series of connected straight lines between two or more points.")

            Path(PathGeometry(FillRule.EvenOdd) { PathFigure(Point(10., 10.)) { PolyLineSegment([ Point(50., 10.); Point(50., 50.) ]) } })
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(2.)

            TextBlock("QuadraticBezierSegment, which creates a quadratic Bezier curve between two points.")

            Path(PathGeometry(FillRule.EvenOdd) { PathFigure(Point(10., 50.)) { QuadraticBezierSegment(Point(100., 0.), Point(200., 200.)) } })
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(2.)

            TextBlock("CombinedGeometry, which creates a geometry as the union, intersection, or exclusion of two geometry objects.")

            Path(
                CombinedGeometry(RectangleGeometry(Rect(10., 10., 100., 100.)), EllipseGeometry(50., 50.).center(Point(50., 50.)))
                    .geometryCombineMode(GeometryCombineMode.Union)
            )
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(2.)

            TextBlock("Complex geometries")

            Path(
                PathGeometry(FillRule.EvenOdd) {

                    // <!-- H -->
                    PathFigure(Point(0., 0.)) { LineSegment(Point(0., 100.)) }
                    PathFigure(Point(0., 50.)) { LineSegment(Point(50., 50.)) }
                    PathFigure(Point(50., 0.)) { LineSegment(Point(50., 100.)) }

                    // E
                    PathFigure(Point(125., 0.)) {
                        BezierSegment(Point(60., -10.), Point(60., 60.), Point(125., 50.))
                        BezierSegment(Point(60., 40.), Point(60., 110.), Point(125., 100.))
                    }

                    // <!-- L -->
                    PathFigure(Point(150., 0.)) {
                        LineSegment(Point(150., 100.))
                        LineSegment(Point(200., 100.))
                    }

                    //  <!-- L -->
                    PathFigure(Point(225., 0.)) {
                        LineSegment(Point(225., 100.))
                        LineSegment(Point(275., 100.))
                    }

                    // <!-- O -->
                    PathFigure(Point(300., 50.)) {
                        ArcSegment(Point(300., 49.9), Size(25., 50.))
                            .isLargeArc(true)

                    }
                }
            )
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(12.)
                .strokeLineCap(PenLineCap.Round)

            Path(
                GeometryGroup(FillRule.EvenOdd) {
                    EllipseGeometry(100., 100.).center(Point(150., 150.))
                    EllipseGeometry(100., 100.).center(Point(250., 150.))

                    EllipseGeometry(100., 100.).center(Point(150., 250.))

                    EllipseGeometry(100., 100.).center(Point(250., 250.))
                }
            )
                .stroke(SolidColorBrush(Colors.Green))
                .strokeThickness(2.)
                .fill(SolidColorBrush(Colors.Orange))

            TextBlock("PolyBezierSegment, which creates a series of connected cubic Bezier curves between two or more points.")

            Path(
                PathGeometry(FillRule.EvenOdd) { PathFigure(Point(10., 50.)) { PolyBezierSegment([ Point(100., 0.); Point(200., 200.); Point(300., 100.) ]) } }
            )
                .fill(SolidColorBrush(Colors.Blue))
                .stroke(SolidColorBrush(Colors.Red))
                .strokeThickness(2.)
        }
