namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

module RectangleDemoPage =
    let view () =
        View.ContentPage(
            title = "Rectangle demos",
            content = View.ScrollView(
                View.StackLayout(
                    margin = Thickness(20.),
                    children = [
                        View.Label("Filled rectangle")
                        View.Rectangle(
                            fill = View.SolidColorBrush(Color.Red),
                            width = 150.,
                            height = 50.,
                            horizontalOptions = LayoutOptions.Start
                        )

                        View.Label("Square")
                        View.Rectangle(
                            stroke = View.SolidColorBrush(Color.Red),
                            strokeThickness = 4.,
                            width = 150.,
                            height = 150.,
                            horizontalOptions = LayoutOptions.Start
                        )

                        View.Label("Rectangle with stroke")
                        View.Rectangle(
                            stroke = View.SolidColorBrush(Color.Red),
                            strokeThickness = 4.,
                            width = 150.,
                            height = 50.,
                            horizontalOptions = LayoutOptions.Start
                        )

                        View.Label("Filled rectangle with stroke")
                        View.Rectangle(
                            fill = View.SolidColorBrush(Color.DarkBlue),
                            stroke = View.SolidColorBrush(Color.Red),
                            strokeThickness = 4.,
                            width = 150.,
                            height = 50.,
                            horizontalOptions = LayoutOptions.Start
                        )

                        View.Label("Filled rectangle with dashed stroke")
                        View.Rectangle(
                            fill = View.SolidColorBrush(Color.DarkBlue),
                            stroke = View.SolidColorBrush(Color.Red),
                            strokeThickness = 4.,
                            strokeDashArray = [ 1.; 1. ],
                            strokeDashOffset = 6.,
                            width = 150.,
                            height = 50.,
                            horizontalOptions = LayoutOptions.Start
                        )

                        View.Label("Rectangle with rounded corners")
                        View.Rectangle(
                            fill = View.SolidColorBrush(Color.Blue),
                            stroke = View.SolidColorBrush(Color.Black),
                            strokeThickness = 3.,
                            radiusX = 50.,
                            radiusY = 10.,
                            width = 200.,
                            height = 100.,
                            horizontalOptions = LayoutOptions.Start
                        )
                    ]
                )
            )
        )
