namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

module PolylineDemoPage =
    let [<Literal>] polylinePoints1 = "0,0 10,30, 15,0 18,60 23,30 35,30 40,0 43,60 48,30 100,30"
    let [<Literal>] polylinePoints2 = "0 48, 0 144, 96 150, 100 0, 192 0, 192 96, 50 96, 48 192, 150 200 144 48"
    let [<Literal>] polylinePoints3 = "20 20,250 50,20 120"

    let view () =
        View.ContentPage(
            title = "PolylineDemoPage",
            content = View.ScrollView(
                View.StackLayout(
                    margin = Thickness(20.),
                    children = [
                        View.Label("Polygon")
                        View.Polyline(
                            points = Points.fromString polylinePoints1,
                            stroke = View.SolidColorBrush(Color.Red),
                            strokeThickness = 1.
                        )

                        View.Label("Polyline with dashed stroke")
                        View.Polyline(
                            points = Points.fromString polylinePoints1,
                            stroke = View.SolidColorBrush(Color.Red),
                            strokeThickness = 2.,
                            strokeDashArray = [ 1.; 1. ],
                            strokeDashOffset = 6.
                        )

                        View.Label("EvenOdd polyline")
                        View.Polyline(
                            points = Points.fromString polylinePoints2,
                            fill = View.SolidColorBrush(Color.Blue),
                            fillRule = FillRule.EvenOdd,
                            stroke = View.SolidColorBrush(Color.Red),
                            strokeThickness = 3.
                        )

                        View.Label("NonZero polyline")
                        View.Polyline(
                            points = Points.fromString polylinePoints2,
                            fill = View.SolidColorBrush(Color.Black),
                            fillRule = FillRule.Nonzero,
                            stroke = View.SolidColorBrush(Color.Yellow),
                            strokeThickness = 3.
                        )

                        View.Label("LineJoin: Miter")
                        View.Polyline(
                            points = Points.fromString polylinePoints3,
                            stroke = View.SolidColorBrush(Color.DarkBlue),
                            strokeThickness = 20.,
                            strokeLineJoin = PenLineJoin.Miter
                        )

                        View.Label("LineJoin: Bevel")
                        View.Polyline(
                            points = Points.fromString polylinePoints3,
                            stroke = View.SolidColorBrush(Color.DarkBlue),
                            strokeThickness = 20.,
                            strokeLineJoin = PenLineJoin.Bevel
                        )

                        View.Label("LineJoin: Round")
                        View.Polyline(
                            points = Points.fromString polylinePoints3,
                            stroke = View.SolidColorBrush(Color.DarkBlue),
                            strokeThickness = 20.,
                            strokeLineJoin = PenLineJoin.Round
                        )
                    ]
                )
            )
        )
