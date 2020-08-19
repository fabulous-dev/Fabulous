namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms

module FlowerDemoPage =

    let petal rotation =
        View.Path(
            stroke = View.SolidColorBrush(Color.Black),
            fill = View.SolidColorBrush(Color.Red),
            data = Content.fromString "M 0 0 C 12.5 12.5, 47.5 12.5, 60 0
                                       C 47.5 -12.5, 12.5 -12.5, 0 0 Z",
            anchorX = 0.,
            anchorY = 0.,
            rotation = rotation
        )

    let view () =
        View.ContentPage(
            title = "Flower demo",
            content = View.Grid(
                margin = Thickness(40., 100., 0., 0.),
                translationX = 400.,
                translationY = 500.,
                scale = 2.,
                children = [
                    View.Path(
                        stroke = View.SolidColorBrush(Color.Green),
                        strokeThickness = 5.,
                        data = Content.fromString "M -100 100 C -100 50, -50 -50, 0 0"
                    )
                    petal 0.
                    petal 45.
                    petal 90.
                    petal 135.
                    petal 180.
                    petal 225.
                    petal 270.
                    petal 315.
                    View.Path(
                        fill = View.SolidColorBrush(Color.Yellow),
                        stroke = View.SolidColorBrush(Color.Black),
                        data = Content.fromElement(
                            View.EllipseGeometry(
                                center = Point.Zero,
                                radiusX = 15.,
                                radiusY = 15.
                            )
                        )
                    )
                ]
            )
        )
