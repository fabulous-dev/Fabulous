namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms

module BrushesDemoPage =
    [<Literal>]
    let PathData = "M13.908992,16.207977L32.000049,16.207977 32.000049,31.999985 13.908992,30.109983z M0,16.207977L11.904009,16.207977 11.904009,29.900984 0,28.657984z M11.904036,2.0979624L11.904036,14.202982 2.7656555E-05,14.202982 2.7656555E-05,3.3409645z M32.000058,0L32.000058,14.203001 13.909059,14.203001 13.909059,1.8890382z"

    let linearGradientBrushFill =
        View.LinearGradientBrush(
            startPoint = Point.Zero,
            endPoint = Point(1., 1.),
            gradientStops = [
                View.GradientStop(Color.DarkBlue, offset = 0.1f)
                View.GradientStop(Color.Red, offset = 0.6f)
                View.GradientStop(Color.LightPink, offset = 1.0f)
            ]
        )

    let linearGradientBrushStroke =
        View.LinearGradientBrush(
            startPoint = Point.Zero,
            endPoint = Point(1., 1.),
            gradientStops = [
                View.GradientStop(Color.DarkOrange, offset = 0.1f)
                View.GradientStop(Color.Orange, offset = 0.6f)
                View.GradientStop(Color.Red, offset = 1.0f)
            ]
        )

    let radialGradientBrushFill =
        View.RadialGradientBrush(
            center = Point(0.5, 0.5),
            radius = 0.75,
            gradientStops = [
                View.GradientStop(Color.DarkBlue, offset = 0.1f)
                View.GradientStop(Color.Red, offset = 0.6f)
                View.GradientStop(Color.LightPink, offset = 1.0f)
            ]
        )

    let view () =
        View.ContentPage(
            View.ScrollView(
               View.StackLayout(
                    margin = Thickness(20.),
                    children = [
                        View.Label("Ellipse with a LinearGradientBrush")
                        View.Ellipse(
                            stroke = linearGradientBrushStroke,
                            fill = linearGradientBrushFill,
                            strokeThickness = 10.,
                            height = 50.,
                            width = 150.,
                            horizontalOptions = LayoutOptions.Start
                        )
                        View.Label("Ellipse with a RadialGradientBrush")
                        View.Ellipse(
                            stroke = linearGradientBrushStroke,
                            fill = radialGradientBrushFill,
                            strokeThickness = 10.,
                            height = 50.,
                            width = 150.,
                            horizontalOptions = LayoutOptions.Start
                        )
                        View.Label("Rectangle with a LinearGradientBrush")
                        View.Rectangle(
                            stroke = linearGradientBrushStroke,
                            fill = linearGradientBrushFill,
                            strokeThickness = 10.,
                            radiusX = 10.,
                            radiusY = 10.,
                            height = 50.,
                            width = 150.,
                            horizontalOptions = LayoutOptions.Start
                        )
                        View.Label("Line with a LinearGradientBrush")
                        View.Line(
                            stroke = linearGradientBrushStroke,
                            strokeThickness = 5.,
                            x1 = 40.,
                            y1 = 0.,
                            x2 = 0.,
                            y2 = 120.
                        )
                        View.Label("Polyline with a LinearGradientBrush")
                        View.Polyline(
                            points = Points.fromString "0,0 10,30, 15,0 18,60 23,30 35,30 40,0 43,60 48,30 100,30",
                            stroke = linearGradientBrushStroke,
                            strokeThickness = 5.,
                            margin = Thickness(0., 30., 0., 0.)
                        )
                        View.Label("Polygon with a RadialGradientBrush")
                        View.Polyline(
                            points = Points.fromString "40,10 70,80 10,50",
                            stroke = linearGradientBrushStroke,
                            fill = radialGradientBrushFill,
                            strokeThickness = 10.
                        )
                        View.Label("Path with a RadialGradientBrush")
                        View.Path(
                            data = Content.fromString PathData,
                            stroke = linearGradientBrushStroke,
                            fill = radialGradientBrushFill,
                            aspect = Stretch.Uniform,
                            horizontalOptions = LayoutOptions.Start,
                            height = 100.,
                            width = 100.
                        )
                    ]
                )
            )
        )
