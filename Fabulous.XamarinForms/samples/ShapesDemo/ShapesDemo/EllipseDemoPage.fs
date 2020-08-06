namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms

module EllipseDemoPage =
    
    let view () =
        View.ContentPage(
            title = "Ellipse demos",
            content = View.ScrollView(
                View.StackLayout(
                    margin = Thickness(20.),
                    children = [
                        View.Label(text = "Filled ellipse")
                        View.Ellipse(
                            fill = Color.Red,
                            width = 150.,
                            height = 50.,
                            horizontalOptions = LayoutOptions.Start
                        )
                        View.Label(text = "Circle")
                        View.Ellipse(
                            stroke = Color.Red,
                            strokeThickness = 4.,
                            width = 150.,
                            height = 150.,
                            horizontalOptions = LayoutOptions.Start
                        )
                        View.Label(text = "Ellipse with stroke")
                        View.Ellipse(
                            stroke = Color.Red,
                            strokeThickness = 4.,
                            width = 150.,
                            height = 50.,
                            horizontalOptions = LayoutOptions.Start
                        )
                        View.Label(text = "Filled ellipse with stroke")
                        View.Ellipse(
                            fill = Color.DarkBlue,
                            stroke = Color.Red,
                            strokeThickness = 4.,
                            width = 150.,
                            height = 50.,
                            horizontalOptions = LayoutOptions.Start
                        )
                        View.Label(text = "Filled ellipse with dashed stroke")
                        View.Ellipse(
                            fill = Color.DarkBlue,
                            stroke = Color.Red,
                            strokeThickness = 4.,
                            strokeDashArray = [ 1.; 1. ],
                            strokeDashOffset = 6.,
                            width = 150.,
                            height = 50.,
                            horizontalOptions = LayoutOptions.Start
                        )
                    ]
                )
            )
        )

