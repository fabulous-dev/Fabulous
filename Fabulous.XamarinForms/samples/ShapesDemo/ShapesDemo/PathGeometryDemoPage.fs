namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

module PathGeometryDemoPage =
    let view () =
        View.ContentPage(
            title = "Path geometry demos",
            content = View.ScrollView(
                View.StackLayout(
                    margin = Thickness(20.),
                    children = [
                        View.Label("EllipseGeometry")
                        View.Path(
                            fill = Color.Blue,
                            stroke = Color.Red,
                            data = Content.fromElement(
                                View.EllipseGeometry(
                                    center = Point(50., 50.),
                                    radiusX = 50.,
                                    radiusY = 50.
                                )
                            )
                        )
                        
                        View.Label("LineGeometry")
                        View.Path(
                            stroke = Color.Black,
                            data = Content.fromElement(
                                View.LineGeometry(
                                    startPoint = Point(10., 20.),
                                    endPoint = Point(100., 130.)
                                )
                            )
                        )
                        
                        View.Label("RectangleGeometry")
                        View.Path(
                            fill = Color.Blue,
                            stroke = Color.Red,
                            data = Content.fromElement(
                                View.RectangleGeometry(
                                    rect = Xamarin.Forms.Rectangle(10., 10., 150., 100.)
                                )
                            )
                        )
                        
                        View.Label("PathGeometry with an ArcSegment")
                        // This code is commented out in the original sample because of a crash
                        (*View.Path(
                            stroke = Color.Black,
                            data = Content.fromElement(
                                View.PathGeometry(
                                    figures = Figures.fromList [
                                        View.PathFigure(
                                            startPoint = Point(10., 100.),
                                            segments = [
                                                View.ArcSegment(
                                                    size = Size(100., 50.),
                                                    rotationAngle = 45.,
                                                    isLargeArc = true,
                                                    sweepDirection = SweepDirection.CounterClockwise,
                                                    point = Point(200., 100.)
                                                )
                                            ]
                                        )
                                    ]
                                )
                            )
                        )*)
                        
                        View.Label("PathGeometry with a BezierSegment")
                        View.Path(
                            stroke = Color.Black,
                            data = Content.fromElement(
                                View.PathGeometry(
                                    figures = Figures.fromList [
                                        View.PathFigure(
                                            startPoint = Point(10., 10.),
                                            segments = [
                                                View.BezierSegment(
                                                    point1 = Point(100., 0.),
                                                    point2 = Point(200., 200.),
                                                    point3 = Point(300., 10.)
                                                )
                                            ]
                                        )
                                    ]
                                )
                            )
                        )
                        
                        View.Label("PathGeometry with LineSegments")
                        View.Path(
                            stroke = Color.Black,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Start,
                            data = Content.fromElement(
                                View.PathGeometry(
                                    figures = Figures.fromList [
                                        View.PathFigure(
                                            isClosed = true,
                                            startPoint = Point(10., 100.),
                                            segments = [
                                                View.LineSegment(point = Point(100., 100.))
                                                View.LineSegment(point = Point(100., 50.))
                                            ]
                                        )
                                    ]
                                )
                            )
                        )
                        
                        View.Label("PathGeometry with LineSegments")
                        View.Path(
                            stroke = Color.Maroon,
                            strokeThickness = 3.,
                            fill = Color.Aqua,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Start,
                            data = Content.fromElement(
                                View.PathGeometry(
                                    figures = Figures.fromList [
                                        View.PathFigure(
                                            startPoint = Point(10., 100.),
                                            segments = [
                                                View.LineSegment(point = Point(144., 72.))
                                                View.LineSegment(point = Point(200., 246.))
                                                View.LineSegment(point = Point(53., 138.))
                                                View.LineSegment(point = Point(235., 138.))
                                                View.LineSegment(point = Point(88., 246.))
                                                View.LineSegment(point = Point(144., 72.))
                                            ]
                                        )
                                    ]
                                )
                            )
                        )
                        
                        View.Label("PathGeometry with a PolyBezierSegment")
                        View.Path(
                            stroke = Color.Black,
                            data = Content.fromElement(
                                View.PathGeometry(
                                    figures = Figures.fromList [
                                        View.PathFigure(
                                            startPoint = Point(10., 10.),
                                            segments = [
                                                View.PolyBezierSegment(points = Points.fromString "0,0 100,0 150,100 150,0 200,0 300,10")
                                            ]
                                        )
                                    ]
                                )
                            )
                        )
                        
                        View.Label("PathGeometry with a PolyLineSegment")
                        View.Path(
                            stroke = Color.Black,
                            data = Content.fromElement(
                                View.PathGeometry(
                                    figures = Figures.fromList [
                                        View.PathFigure(
                                            startPoint = Point(10., 10.),
                                            segments = [
                                                View.PolyLineSegment(points = Points.fromString "50,10 50,50")
                                            ]
                                        )
                                    ]
                                )
                            )
                        )
                        
                        View.Label("PathGeometry with a PolyQuadraticBezierSegment")
                        View.Path(
                            stroke = Color.Black,
                            data = Content.fromElement(
                                View.PathGeometry(
                                    figures = Figures.fromList [
                                        View.PathFigure(
                                            startPoint = Point(10., 10.),
                                            segments = [
                                                View.PolyQuadraticBezierSegment(points = Points.fromString "100,100 150,50 0,100 15,200")
                                            ]
                                        )
                                    ]
                                )
                            )
                        )
                        
                        View.Label("PathGeometry with a QuadraticBezierSegment")
                        View.Path(
                            stroke = Color.Black,
                            data = Content.fromElement(
                                View.PathGeometry(
                                    figures = Figures.fromList [
                                        View.PathFigure(
                                            startPoint = Point(10., 10.),
                                            segments = [
                                                View.QuadraticBezierSegment(point1 = Point(200., 200.), point2 = Point(300., 10.))
                                            ]
                                        )
                                    ]
                                )
                            )
                        )
                        
                        View.Label("Multiple PathFigures")
                        View.Path(
                            stroke = Color.Red,
                            strokeThickness = 12.,
                            strokeLineJoin = PenLineJoin.Round,
                            translationY = 20.,
                            data = Content.fromElement(
                                View.PathGeometry(
                                    figures = Figures.fromList [
                                        View.PathFigure(
                                            startPoint = Point(0., 0.),
                                            segments = [
                                                View.LineSegment(point = Point(0., 100.))
                                            ]
                                        )
                                        View.PathFigure(
                                            startPoint = Point(0., 50.),
                                            segments = [
                                                View.LineSegment(point = Point(50., 50.))
                                            ]
                                        )
                                        View.PathFigure(
                                            startPoint = Point(50., 0.),
                                            segments = [
                                                View.LineSegment(point = Point(50., 100.))
                                            ]
                                        )
                                        View.PathFigure(
                                            startPoint = Point(125., 0.),
                                            segments = [
                                                View.BezierSegment(point1 = Point(60., -10.), point2 = Point(60., 60.), point3 = Point(125., 50.))
                                                View.BezierSegment(point1 = Point(60., 40.), point2 = Point(60., 110.), point3 = Point(125., 100.))
                                            ]
                                        )
                                        View.PathFigure(
                                            startPoint = Point(150., 0.),
                                            segments = [
                                                View.LineSegment(point = Point(150., 100.))
                                                View.LineSegment(point = Point(200., 100.))
                                            ]
                                        )
                                        View.PathFigure(
                                            startPoint = Point(225., 0.),
                                            segments = [
                                                View.LineSegment(point = Point(225., 100.))
                                                View.LineSegment(point = Point(275., 100.))
                                            ]
                                        )
                                        View.PathFigure(
                                            startPoint = Point(300., 50.),
                                            segments = [
                                                View.ArcSegment(
                                                    size = Size(25., 50.),
                                                    point = Point(300., 49.9),
                                                    isLargeArc = true
                                                )
                                            ]
                                        )
                                    ]
                                )
                            )
                        )
                        
                        View.Label("GeometryGroup")
                        View.Path(
                            stroke = Color.Black,
                            fill = Color.FromHex("#CCCCFF"),
                            data = Content.fromElement(
                                View.GeometryGroup(
                                    children = [
                                        // FillRule doesn't need to be set, because EvenOdd is the default.
                                        View.EllipseGeometry(radiusX = 50., radiusY = 50., center = Point(75., 75.))
                                        View.EllipseGeometry(radiusX = 70., radiusY = 70., center = Point(75., 75.))
                                        View.EllipseGeometry(radiusX = 100., radiusY = 100., center = Point(75., 75.))
                                        View.EllipseGeometry(radiusX = 120., radiusY = 120., center = Point(75., 75.))
                                    ]
                                )
                            )
                        )
                        
                        View.Label("GeometryGroup")
                        View.Path(
                            stroke = Color.Black,
                            fill = Color.FromHex("#CCCCFF"),
                            translationY = -30.,
                            horizontalOptions = LayoutOptions.Start,
                            data = Content.fromElement(
                                View.GeometryGroup(
                                    fillRule = FillRule.Nonzero,
                                    children = [
                                        View.PathGeometry(
                                            figures = Figures.fromList [
                                                // Inner ring
                                                View.PathFigure(
                                                    startPoint = Point(120., 120.),
                                                    segments = [
                                                        View.ArcSegment(
                                                            size = Size(50., 50.),
                                                            isLargeArc = true,
                                                            sweepDirection = SweepDirection.CounterClockwise,
                                                            point = Point(140., 120.)
                                                        )
                                                    ]
                                                )
                                                // Second ring
                                                View.PathFigure(
                                                    startPoint = Point(120., 100.),
                                                    segments = [
                                                        View.ArcSegment(
                                                            size = Size(70., 70.),
                                                            isLargeArc = true,
                                                            sweepDirection = SweepDirection.CounterClockwise,
                                                            point = Point(140., 100.)
                                                        )
                                                    ]
                                                )
                                                // Third ring
                                                View.PathFigure(
                                                    startPoint = Point(120., 70.),
                                                    segments = [
                                                        View.ArcSegment(
                                                            size = Size(100., 100.),
                                                            isLargeArc = true,
                                                            sweepDirection = SweepDirection.CounterClockwise,
                                                            point = Point(140., 70.)
                                                        )
                                                    ]
                                                )
                                                // Outer ring
                                                View.PathFigure(
                                                    startPoint = Point(120., 300.),
                                                    segments = [
                                                        View.ArcSegment(
                                                            size = Size(130., 130.),
                                                            isLargeArc = true,
                                                            sweepDirection = SweepDirection.Clockwise,
                                                            point = Point(140., 300.)
                                                        )
                                                    ]
                                                )
                                            ]
                                        )
                                    ]
                                )                                
                            )
                        )
                        
                        View.Label("GeometryGroup")
                        View.Path(
                            stroke = Color.Green,
                            strokeThickness = 2.,
                            fill = Color.Orange,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Start,
                            data = Content.fromElement(
                                // FillRule doesn't need to be set, because EvenOdd is the default.
                                View.GeometryGroup(
                                    children = [
                                        View.EllipseGeometry(radiusX = 100., radiusY = 100., center = Point(150., 150.))
                                        View.EllipseGeometry(radiusX = 100., radiusY = 100., center = Point(250., 150.))
                                        View.EllipseGeometry(radiusX = 100., radiusY = 100., center = Point(150., 250.))
                                        View.EllipseGeometry(radiusX = 100., radiusY = 100., center = Point(250., 250.))
                                    ]
                                )
                            )
                        )
                    ]
                )
            )
        )