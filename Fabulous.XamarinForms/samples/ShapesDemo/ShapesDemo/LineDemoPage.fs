namespace ShapesDemo

open Fabulous.XamarinForms
open Xamarin.Forms
open Xamarin.Forms.Shapes

module LineDemoPage =

    let view () =
        View.ContentPage(
            title = "Line demos",
            content = View.ScrollView(
                View.StackLayout(
                    margin = Thickness(20.),
                    children = [
                          View.Label(text = "Line")
                          View.Line(x1 = 40., y1 = 0., x2 = 0., y2 = 120., stroke = View.SolidColorBrush(Color.Red))

                          View.Label(text = "Line with stroke")
                          View.Line(x1 = 40., y1 = 0., x2 = 0., y2 = 120., stroke = View.SolidColorBrush(Color.DarkBlue), strokeThickness = 4.)

                          View.Label(text = "Dashed line")
                          View.Line(x1 = 40., y1 = 0., x2 = 0., y2 = 120., stroke = View.SolidColorBrush(Color.DarkBlue), strokeDashArray = [ 1.; 1. ], strokeDashOffset = 6.)

                          View.Label(text = "LineCap: Flat")
                          View.Line(x1 = 0., y1 = 20., x2 = 300., y2 = 20., stroke = View.SolidColorBrush(Color.Red), strokeThickness = 12., strokeLineCap = PenLineCap.Flat)

                          View.Label(text = "LineCap: Square")
                          View.Line(x1 = 0., y1 = 20., x2 = 300., y2 = 20., stroke = View.SolidColorBrush(Color.Red), strokeThickness = 12., strokeLineCap = PenLineCap.Square)

                          View.Label(text = "LineCap: Round")
                          View.Line(x1 = 0., y1 = 20., x2 = 300., y2 = 20., stroke = View.SolidColorBrush(Color.Red), strokeThickness = 12., strokeLineCap = PenLineCap.Round)
                    ]
                )
            )
        )
