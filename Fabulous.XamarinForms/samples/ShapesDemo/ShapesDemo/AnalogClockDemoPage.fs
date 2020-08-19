namespace ShapesDemo

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open System
open Xamarin.Forms.Shapes

module AnalogClockDemoPage =
    let computeAngles () =
        let dateTime = DateTime.Now
        let secondHandAngle = 6. * (float dateTime.Second + float dateTime.Millisecond / 1000.0)
        let minuteHandAngle = (float (6 * dateTime.Minute + (int secondHandAngle / 60)))
        let hourHandAngle = (float (30 * (dateTime.Hour % 12) + (int minuteHandAngle) / 12))
        (hourHandAngle, minuteHandAngle, secondHandAngle)

    type Model =
        { HourHandAngle: float
          MinuteHandAngle: float
          SecondHandAngle: float }

    type Msg =
        | TimedTick

    let timerCmd =
        async { do! Async.Sleep 15
                return TimedTick }
        |> Cmd.ofAsyncMsg

    let init () =
        let hour, minute, second = computeAngles()
        { HourHandAngle = hour; MinuteHandAngle = minute; SecondHandAngle = second }, timerCmd

    let update msg model =
        match msg with
        | TimedTick ->
            let hour, minute, second = computeAngles()
            { model with HourHandAngle = hour; MinuteHandAngle = minute; SecondHandAngle = second }, timerCmd

    let view model dispatch =
        View.ContentPage(
            View.Grid(
                width = 200.,
                height = 200.,
                translationX = 100.,
                translationY = 100.,
                horizontalOptions = LayoutOptions.Center,
                verticalOptions = LayoutOptions.Center,
                children = [
                    // Small tick marks
                    View.Path(
                        strokeThickness = 3.,
                        strokeDashArray = [ 0.1; 3.04159 ],
                        data = Content.fromElement (
                            View.EllipseGeometry(
                                radiusX = 90.,
                                radiusY = 90.
                            )
                        ),
                        stroke = View.SolidColorBrush(Color.Black),
                        strokeLineCap = PenLineCap.Round,
                        strokeLineJoin = PenLineJoin.Round
                    )

                    // Long tick marks
                    View.Path(
                        strokeThickness = 6.,
                        strokeDashArray = [ 0.1; 7.754 ],
                        data = Content.fromElement (
                            View.EllipseGeometry(
                                radiusX = 90.,
                                radiusY = 90.
                            )
                        ),
                        stroke = View.SolidColorBrush(Color.Black),
                        strokeLineCap = PenLineCap.Round,
                        strokeLineJoin = PenLineJoin.Round
                    )

                    // Hour hand pointing straight up
                    View.Path(
                        data = Content.fromString "M 0 -60 C 0 -30, 20 -30, 5 -20 L 5 0 C 5 7.5, -5 7.5, -5 0 L -5 -20 C -20 -30, 0 -30, 0 -60",
                        renderTransform = Content.fromElement(
                            View.RotateTransform(
                                angle = model.HourHandAngle
                            )
                        ),
                        stroke = View.SolidColorBrush(Color.Black),
                        strokeThickness = 2.,
                        strokeLineCap = PenLineCap.Round,
                        strokeLineJoin = PenLineJoin.Round
                    )

                    // Minute hand pointing straight up
                    View.Path(
                        data = Content.fromString "M 0 -80 C 0 -75, 0 -70, 2.5 -60 L 2.5 0 C 2.5 5, -2.5 5, -2.5 0 L -2.55 -60 C 0 -70, 0 -75, 0 -80",
                        renderTransform = Content.fromElement(
                            View.RotateTransform(
                                angle = model.MinuteHandAngle
                            )
                        ),
                        stroke = View.SolidColorBrush(Color.Black),
                        strokeThickness = 2.,
                        strokeLineCap = PenLineCap.Round,
                        strokeLineJoin = PenLineJoin.Round
                    )

                    // Second hand pointing straight up
                    View.Path(
                        data = Content.fromString "M 0 10 L 0 -80",
                        renderTransform = Content.fromElement(
                            View.RotateTransform(
                                angle = model.SecondHandAngle
                            )
                        ),
                        stroke = View.SolidColorBrush(Color.Black),
                        strokeThickness = 2.,
                        strokeLineCap = PenLineCap.Round,
                        strokeLineJoin = PenLineJoin.Round
                    )
                ]
            )
        )