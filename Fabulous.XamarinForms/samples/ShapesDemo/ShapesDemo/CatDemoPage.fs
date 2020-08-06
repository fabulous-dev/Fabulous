namespace ShapesDemo

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module CatDemoPage =
    let view () =
        View.ContentPage(
            title = "Cat demo",
            content = View.Grid([
                View.Path(
                    stroke = Color.Black,
                    strokeThickness = 4.,
                    renderTransform = Content.fromString "0.75 0 0 0.75 0 0",
                    data = Content.fromElement(
                        View.PathGeometry(
                            figures = Figures.fromString "M 160 140 L 150 50 220 103
                                                          M 320 140 L 330 50 260 103
                                                          M 215 230 L 40 200
                                                          M 215 240 L 40 240
                                                          M 215 250 L 40 280
                                                          M 265 230 L 440 200
                                                          M 265 240 L 440 240p
                                                          M 265 250 L 440 280
                                                          M 240 100
                                                          A 100 100 0 0 1 240 300
                                                          A 100 100 0 0 1 240 100 
                                                          M 180 170
                                                          A 40 40 0 0 1 220 170
                                                          A 40 40 0 0 1 180 170
                                                          M 300 170
                                                          A 40 40 0 0 1 260 170
                                                          A 40 40 0 0 1 300 170"
                        )
                    ) 
                )
            ])
        )

