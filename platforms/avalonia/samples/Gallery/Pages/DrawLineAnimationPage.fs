namespace Gallery

open System
open System.Diagnostics
open Avalonia
open Avalonia.Animation
open Avalonia.Animation.Easings
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

module DrawLineAnimationPage =

    type Model =
        { StartPosition: Point
          EndPosition: Point
          ShouldAnimate: bool
          StrokeThickness: float
          Origin: RelativePoint }

    type Msg =
        | OnPointerPressed of PointerPressedEventArgs
        | OnPointerReleased of PointerReleasedEventArgs
        | OnPointerMoved of PointerEventArgs
        | TimerTicked

    let timer () =
        async {
            do! Async.Sleep 1000
            return TimerTicked
        }
        |> Cmd.OfAsync.msg

    let init () =
        { StartPosition = Point(0., 0.)
          EndPosition = Point(0., 0.)
          ShouldAnimate = false
          StrokeThickness = 10.
          Origin = RelativePoint.Center },
        Cmd.none

    let update msg model =
        match msg with
        | OnPointerPressed args ->
            args.Handled <- true

            match args.Source with
            | :? Canvas as canvas ->
                let point = args.GetPosition(canvas)

                { model with
                    StartPosition = point
                    EndPosition = point
                    ShouldAnimate = false },
                Cmd.none
            | _ -> model, Cmd.none
        | OnPointerReleased args ->
            args.Handled <- true

            match args.Source with
            | :? Canvas as canvas ->
                let point = args.GetPosition(canvas)

                { model with
                    EndPosition = point
                    ShouldAnimate = true },
                timer()
            | _ -> model, Cmd.none
        | OnPointerMoved args ->
            args.Handled <- true

            match args.Source with
            | :? Canvas as canvas ->
                let point = args.GetPosition(canvas)
                { model with EndPosition = point }, Cmd.none
            | _ -> model, Cmd.none
        | TimerTicked ->
            let strokeThickness = model.StrokeThickness + 1.

            { model with
                StrokeThickness = strokeThickness },
            timer()

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("DrawLineAnimationPage") {
            let! model = Context.Mvu program

            (Canvas() {
                let line =
                    Line(model.StartPosition, model.EndPosition)
                        .stroke(Brushes.Red)
                        .strokeThickness(model.StrokeThickness)

                if model.ShouldAnimate then
                    line
                        .clipToBounds(false)
                        .renderTransformOrigin(model.Origin)
                        .renderTransform(RotateTransform())
                        .animation(
                            (Animation(TimeSpan.FromSeconds(5)) {
                                KeyFrame(RotateTransform.AngleProperty, 0.).cue(0.)
                                KeyFrame(RotateTransform.AngleProperty, 360.).cue(1.)
                            })
                                .repeatForever()
                                .playbackDirection(PlaybackDirection.Normal)
                                .easing(SpringEasing(1, 200, 2))
                        )
            })
                .background(Brushes.WhiteSmoke)
                .onPointerPressed(OnPointerPressed)
                .onPointerReleased(OnPointerReleased)
                .onPointerMoved(OnPointerMoved)
                .width(500)
                .height(400)
        }
