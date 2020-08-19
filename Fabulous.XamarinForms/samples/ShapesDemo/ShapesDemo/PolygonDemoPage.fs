namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

module PolygonDemoPage =
    let [<Literal>] polygonPoints1 = "40,10 70,80 10,50"
    let [<Literal>] polygonPoints2 = "0 48, 0 144, 96 150, 100 0, 192 0, 192 96, 50 96, 48 192, 150 200 144 48"

    let view () =
        View.ContentPage(
            title = "PolygonDemoPage",
            content = View.ScrollView(
                View.StackLayout(
                    margin = Thickness(20.),
                    children = [
                        View.Label("Polygon")
                        View.Polygon(
                            points = Points.fromString polygonPoints1,
                            fill = View.SolidColorBrush(Color.AliceBlue),
                            stroke = View.SolidColorBrush(Color.Green),
                            strokeThickness = 5.
                        )

                        View.Label("Polygon with dashed stroke")
                        View.Polygon(
                            points = Points.fromString polygonPoints1,
                            fill = View.SolidColorBrush(Color.AliceBlue),
                            stroke = View.SolidColorBrush(Color.Green),
                            strokeThickness = 5.,
                            strokeDashArray = [ 1.; 1. ],
                            strokeDashOffset = 6.
                        )
                        View.Label("EvenOdd polygon")
                        View.Polygon(
                            points = Points.fromString polygonPoints2,
                            fill = View.SolidColorBrush(Color.Blue),
                            fillRule = FillRule.EvenOdd,
                            stroke = View.SolidColorBrush(Color.Red),
                            strokeThickness = 3.
                        )

                        View.Label("NonZero polygon")
                        View.Polygon(
                            points = Points.fromString polygonPoints2,
                            fill = View.SolidColorBrush(Color.Black),
                            fillRule = FillRule.Nonzero,
                            stroke = View.SolidColorBrush(Color.Yellow),
                            strokeThickness = 3.
                        )
                    ]
                )
            )
        )
