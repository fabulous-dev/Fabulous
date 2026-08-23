namespace Gallery

open System
open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Interactivity
open Avalonia.Input.GestureRecognizers
open Avalonia.Layout
open Avalonia.LogicalTree
open Avalonia.Media
open Avalonia.Rendering.Composition
open Avalonia.Utilities
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

#nowarn "44" // warning FS1182: The value is not used.

module GesturesPage =
    type Model = { CurrentScale: float; Angle: float }

    type Msg =
        | Reset
        | LoadedPullTouch of RoutedEventArgs
        | LoadedPinchZoom of RoutedEventArgs
        | LoadedPinchRotate of RoutedEventArgs
        | AngleChanged of float

    let init () =
        { CurrentScale = 0; Angle = 0. }, Cmd.none

    let setPullHandlers (control: Control) (isInverse: bool) =
        if control <> null then
            let ball = control.FindLogicalDescendantOfType<Border>()
            let mutable defaultOffset: Vector3D = Unchecked.defaultof<Vector3D>
            let mutable ballCompositionVisual: CompositionVisual = null

            let initComposition (ball: Border) =
                ballCompositionVisual <- ElementComposition.GetElementVisual(ball)

                if ballCompositionVisual <> null then
                    let offsetAnimation =
                        ballCompositionVisual.Compositor.CreateVector3KeyFrameAnimation()

                    offsetAnimation.Target <- "Offset"
                    offsetAnimation.InsertExpressionKeyFrame(1.0f, "this.FinalValue")
                    offsetAnimation.Duration <- TimeSpan.FromMilliseconds(100)

                    let implicitAnimations =
                        ballCompositionVisual.Compositor.CreateImplicitAnimationCollection()

                    implicitAnimations["Offset"] <- offsetAnimation

                    ballCompositionVisual.ImplicitAnimations <- implicitAnimations

            if ball <> null then
                initComposition(ball)

            control.LayoutUpdated.Add(fun _ ->
                initComposition(ball)

                if ballCompositionVisual <> null then
                    defaultOffset <- ballCompositionVisual.Offset)

            control.AddHandler(
                Gestures.PullGestureEvent,
                fun _ args ->
                    let _center =
                        Vector3D(float control.Bounds.Center.X, float control.Bounds.Center.Y, 0)

                    initComposition(ball)

                    if ballCompositionVisual <> null then
                        ballCompositionVisual.Offset <-
                            defaultOffset
                            + Vector3D(float args.Delta.X * float 0.4f, args.Delta.Y * float 0.4f, 0)
                              * float(if isInverse then -1 else 1)

                        args.Handled <- true

            )

            control.AddHandler(
                Gestures.PullGestureEndedEvent,
                fun _ args ->
                    initComposition(ball)

                    if ballCompositionVisual <> null then
                        ballCompositionVisual.Offset <- defaultOffset
            )

    let setPinchHandlers (control: Control) (currentScale: float) =
        let mutable _currentScale = currentScale

        if control <> null then
            _currentScale <- 1.
            let mutable currentOffset: Vector3D = Unchecked.defaultof<Vector3D>
            let mutable compositionVisual: CompositionVisual = null

            let initComposition (visual: Control) =
                if compositionVisual <> null then
                    ()
                else
                    compositionVisual <- ElementComposition.GetElementVisual(visual)

            control.LayoutUpdated.Add(fun _ ->
                initComposition(control)

                if compositionVisual <> null then
                    compositionVisual.Scale <- Vector3D(_currentScale, _currentScale, 1)

                    if currentOffset = Unchecked.defaultof<Vector3D> then
                        currentOffset <- compositionVisual.Offset)

            control.AddHandler(
                Gestures.PinchEvent,
                fun _ args ->
                    initComposition(control)

                    if compositionVisual <> null then
                        let mutable scale = _currentScale * float args.Scale

                        if scale <= 1. then
                            compositionVisual.Offset <- Unchecked.defaultof<Vector3D>
                            scale <- 1.

                        compositionVisual.Scale <- Vector3D(scale, scale, 1)
                        args.Handled <- true
            )

            control.AddHandler(
                Gestures.PinchEndedEvent,
                fun _ args ->
                    initComposition(control)

                    if compositionVisual <> null then
                        _currentScale <- compositionVisual.Scale.X
            )

            control.AddHandler(
                Gestures.ScrollGestureEvent,
                fun _ args ->
                    initComposition(control)

                    if compositionVisual <> null && _currentScale <> 1. then
                        currentOffset <- currentOffset + Vector3D(float args.Delta.X, float args.Delta.Y, 0)

                        let currentSize = control.Bounds.Size * _currentScale

                        currentOffset <-
                            Vector3D(
                                MathUtilities.Clamp(currentOffset.X, 0., currentSize.Width - control.Bounds.Width),
                                float(MathUtilities.Clamp(currentOffset.Y, 0., currentSize.Height - control.Bounds.Height)),
                                0.
                            )

                        compositionVisual.Offset <- currentOffset * -1.
                        args.Handled <- true
            )

        _currentScale

    let topPullZone = ViewRef<Border>()

    let bottomPullZone = ViewRef<Border>()

    let rightPullZone = ViewRef<Border>()

    let leftPullZone = ViewRef<Border>()

    let pinchImage = ViewRef<Image>()

    let rotationGesture = ViewRef<Panel>()

    let angleSlider = ViewRef<Slider>()

    let update msg model =
        match msg with
        | Reset ->
            let compositionVisual = ElementComposition.GetElementVisual(pinchImage.Value)

            if (compositionVisual <> null) then
                compositionVisual.Scale <- Vector3D(1, 1, 1)
                compositionVisual.Offset <- Unchecked.defaultof<Vector3D>
                pinchImage.Value.InvalidateMeasure()

                { model with CurrentScale = 1 }, []
            else
                model, []
        | AngleChanged angle -> { model with Angle = angle }, []
        | LoadedPullTouch _ ->
            topPullZone.Value.GestureRecognizers.Add(PullGestureRecognizer(PullDirection = PullDirection.TopToBottom))
            bottomPullZone.Value.GestureRecognizers.Add(PullGestureRecognizer(PullDirection = PullDirection.BottomToTop))
            rightPullZone.Value.GestureRecognizers.Add(PullGestureRecognizer(PullDirection = PullDirection.RightToLeft))
            leftPullZone.Value.GestureRecognizers.Add(PullGestureRecognizer(PullDirection = PullDirection.LeftToRight))

            setPullHandlers topPullZone.Value false

            setPullHandlers bottomPullZone.Value true

            setPullHandlers rightPullZone.Value true

            setPullHandlers leftPullZone.Value true

            model, []
        | LoadedPinchZoom _ ->
            pinchImage.Value.GestureRecognizers.Add(PinchGestureRecognizer())

            pinchImage.Value.GestureRecognizers.Add(ScrollGestureRecognizer(CanHorizontallyScroll = true, CanVerticallyScroll = true))
            let currentScale = setPinchHandlers pinchImage.Value model.CurrentScale

            { model with
                CurrentScale = currentScale },
            []

        | LoadedPinchRotate _ ->
            rotationGesture.Value.GestureRecognizers.Add(PinchGestureRecognizer())

            rotationGesture.Value.AddHandler(Gestures.PinchEvent, (fun sender args -> angleSlider.Value.Value <- args.Angle))

            model, []

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

    let pullGestures () =
        (VStack(spacing = 4.) {
            TextBlock("Pull from colored rectangles").margin(5.)

            Border(
                (Dock() {
                    Border(
                        Border()
                            .width(10.)
                            .height(10.)
                            .horizontalAlignment(HorizontalAlignment.Center)
                            .verticalAlignment(VerticalAlignment.Center)
                            .cornerRadius(5.)
                            .background(SolidColorBrush(Colors.Green))
                    )
                        .dock(Dock.Top)
                        .margin(2.)
                        .reference(topPullZone)
                        .background(SolidColorBrush(Colors.Transparent))
                        .borderBrush(SolidColorBrush(Colors.Red))
                        .horizontalAlignment(HorizontalAlignment.Stretch)
                        .height(50.)
                        .borderThickness(1.)


                    Border(
                        Border()
                            .width(10.)
                            .horizontalAlignment(HorizontalAlignment.Center)
                            .verticalAlignment(VerticalAlignment.Center)
                            .height(10.)
                            .cornerRadius(5.)
                            .background(SolidColorBrush(Colors.Green))
                    )
                        .dock(Dock.Bottom)
                        .borderBrush(SolidColorBrush(Colors.Green))
                        .margin(2.)
                        .background(SolidColorBrush(Colors.Transparent))
                        .reference(bottomPullZone)
                        .horizontalAlignment(HorizontalAlignment.Stretch)
                        .height(50.)
                        .borderThickness(1.)

                    Border(
                        Border()
                            .width(10.)
                            .height(10.)
                            .horizontalAlignment(HorizontalAlignment.Center)
                            .verticalAlignment(VerticalAlignment.Center)
                            .cornerRadius(5.)
                            .background(SolidColorBrush(Colors.Green))
                    )
                        .dock(Dock.Right)
                        .margin(2.)
                        .background(SolidColorBrush(Colors.Transparent))
                        .reference(rightPullZone)
                        .borderBrush(SolidColorBrush(Colors.Blue))
                        .horizontalAlignment(HorizontalAlignment.Right)
                        .verticalAlignment(VerticalAlignment.Stretch)
                        .width(50.)
                        .borderThickness(1.)

                    Border(
                        Border()
                            .width(10.)
                            .height(10.)

                            .horizontalAlignment(HorizontalAlignment.Center)
                            .verticalAlignment(VerticalAlignment.Center)
                            .cornerRadius(5.)
                            .background(SolidColorBrush(Colors.Green))
                    )
                        .dock(Dock.Left)
                        .margin(2.)
                        .reference(leftPullZone)
                        .background(SolidColorBrush(Colors.Transparent))
                        .borderBrush(SolidColorBrush(Colors.Orange))
                        .horizontalAlignment(HorizontalAlignment.Left)
                        .verticalAlignment(VerticalAlignment.Stretch)
                        .width(50.)
                        .borderThickness(1.)
                })
                    .horizontalAlignment(HorizontalAlignment.Stretch)
                    .clipToBounds(true)
                    .margin(5.)
                    .height(200.)

            )
        })
            .onLoaded(LoadedPullTouch)

    let pinchZoomGestures () =
        VStack(spacing = 4.) {
            Border(
                Image("avares://Gallery/Assets/delicate-arch.jpg", Stretch.UniformToFill)
                    .margin(5)
                    .reference(pinchImage)
            )
                .clipToBounds(true)

            Button("Reset", Reset)
                .horizontalAlignment(HorizontalAlignment.Center)
        }
        |> _.onLoaded(LoadedPinchZoom)


    let pinchRotateGestures angle =
        VStack(spacing = 4.) {
            Dock() {
                Slider(0, 360, angle, AngleChanged)
                    .dock(Dock.Bottom)
                    .reference(angleSlider)
                    .margin(5.)

                Panel() {
                    Border().borderThickness(1).borderBrush(Colors.LawnGreen)

                    Panel() {
                        Rectangle().fill(SolidColorBrush(Colors.SkyBlue))

                        Rectangle()
                            .fill(SolidColorBrush(Colors.Yellow))
                            .horizontalAlignment(HorizontalAlignment.Center)
                            .verticalAlignment(VerticalAlignment.Top)
                            .width(5.)
                            .height(35.)
                    }
                    |> _.horizontalAlignment(HorizontalAlignment.Center)
                    |> _.height(100.)
                    |> _.width(100.)
                    |> _.renderTransform(RotateTransform(angle))

                    TextBlock($"Angle: {angle}")
                        .horizontalAlignment(HorizontalAlignment.Center)
                        .verticalAlignment(VerticalAlignment.Center)
                        .fontSize(20.)
                        .fontWeight(FontWeight.DemiBold)

                }
                |> _.reference(rotationGesture)
            }
        }
        |> _.onLoaded(LoadedPinchRotate)

    let view () =
        Component("GesturesPage") {
            let! model = Context.Mvu program

            TabControl() {
                TabItem(
                    TextBlock("Pull(Touch / Pen)")
                        .fontSize(18.)
                        .fontWeight(FontWeight.Bold),
                    pullGestures()
                )

                TabItem(
                    TextBlock("Pinch/Zoom (Multi Touch)")
                        .fontSize(18.)
                        .fontWeight(FontWeight.Bold),
                    pinchZoomGestures()
                )

                TabItem(
                    TextBlock("Pinch/Rotation (Multi Touch)")
                        .fontSize(18.)
                        .fontWeight(FontWeight.Bold),
                    pinchRotateGestures(model.Angle)
                )
            }
        }
