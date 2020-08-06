namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

module HelloDemoPage =
    
    let view () =
        View.ContentPage(
            title = "Hello demo",
            content = View.Grid(
                horizontalOptions = LayoutOptions.Center,
                verticalOptions = LayoutOptions.Center,
                children = [
                    View.Path(
                        stroke = Color.Red,
                        strokeThickness = 12.,
                        strokeLineJoin = PenLineJoin.Round,
                        data = Content.fromString "M 0 0 L 0 100 M 0 50 L 50 50 M 50 0 L 50 100
                                                   M 125 0 C 60 -10, 60 60, 125 50, 60 40, 60 110, 125 100
                                                   M 150 0 L 150 100, 200 100
                                                   M 225 0 L 225 100, 275 100
                                                   M 300 50 A 25 50 0 1 0 300 49.9"
                    )
                ]
            )
        )