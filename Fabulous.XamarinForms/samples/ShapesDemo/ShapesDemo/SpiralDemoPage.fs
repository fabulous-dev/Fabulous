namespace ShapesDemo

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open System

module SpiralDemoPage =
    type Model =
        { Points: Points.Value option
          DashOffset: float }

    type Msg =
        | SizeChanged of float * float
        | ChangeDashOffset of float

    let timerCmd =
        async {
            do! Async.Sleep 15
            let secs = DateTime.Now.TimeOfDay.TotalSeconds
            return ChangeDashOffset (6. * (secs % 1.))
        } |> Cmd.ofAsyncMsg

    let init () =
        { Points = None
          DashOffset = 0. }, Cmd.none

    let update msg model =
        match msg with
        | SizeChanged (width, height) ->
            let radius = Math.Min(width / 2., height / 2.)
            let center = Point(width / 2., height / 2.)
            let points = Points.fromList [
                for angle in 0. .. 3599. ->
                    let scaledRadius = radius * angle / 3600.
                    let radians = Math.PI * angle / 180.
                    let x = center.X + scaledRadius * Math.Cos(radians)
                    let y = center.Y + scaledRadius * Math.Sin(radians)
                    Point(x, y)
            ]
            { model with Points = Some points }, timerCmd

        | ChangeDashOffset dashOffset ->
            { model with DashOffset = dashOffset }, timerCmd

    let view model dispatch =
        View.ContentPage(
            title = "Spiral demo",
            sizeChanged = (fun (width, height) -> dispatch (SizeChanged (width, height))),
            content = View.Polyline(
                stroke = View.SolidColorBrush(Color.Blue),
                strokeThickness = 3.,
                strokeDashArray = [ 4.; 2. ],
                strokeDashOffset = model.DashOffset,
                ?points = model.Points
            )
        )
