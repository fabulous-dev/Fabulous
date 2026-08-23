namespace Gallery

open System
open System.Diagnostics
open System.Threading
open Avalonia
open System.Collections.Generic
open Avalonia.Controls
open Avalonia.Input
open Avalonia.Media
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia

open type Fabulous.Avalonia.View

[<AllowNullLiteral>]
type CanvasPoint(brush, point, radius, pressure) =
    member val Brush: IBrush option = brush with get, set
    member val Point = point with get, set
    member val Radius = radius with get, set
    member val Pressure: float option = pressure with get, set

and PointerPoints() =
    let _points = Array.zeroCreate<CanvasPoint> 1000
    let mutable _index = 0

    member this.Render (context: DrawingContext) (drawPoints: bool) =
        let mutable prev: CanvasPoint option = None

        for c in 0 .. _points.Length - 1 do
            let i = (c + _index) % _points.Length
            let pt = _points[i]

            if pt <> null then
                let pressure =
                    match pt.Pressure, prev with
                    | None, Some v when v <> null && v.Pressure.IsSome -> v.Pressure.Value
                    | Some p, None -> p
                    | _, _ -> 0.5

                let thickness = pressure * 10.
                let radius = pressure * pt.Radius

                match pt.Brush with
                | Some brush when drawPoints -> context.DrawEllipse(brush, null, pt.Point, radius, radius)
                | _ ->
                    match prev with
                    | Some prev when prev <> null ->
                        if
                            prev.Brush.IsSome
                            && pt.Brush.Value <> null
                            && prev.Pressure.IsSome
                            && pt.Pressure.IsSome
                            && pt.Pressure.Value <> Unchecked.defaultof<_>
                        then
                            let linePen =
                                new Pen(Brushes.Black, thickness, null, PenLineCap.Round, PenLineJoin.Round)

                            context.DrawLine(linePen, prev.Point, pt.Point)
                    | _ -> ()

            prev <- Some pt


    member this.AddPoint(pt: Point, brush: IBrush, radius: float, pressure) =
        _points[_index] <- CanvasPoint(Some brush, pt, radius, pressure)
        _index <- (_index + 1) % _points.Length

    member this.HandleEvent(e: PointerEventArgs, v: Visual) =
        e.Handled <- true
        let currentPoint = e.GetCurrentPoint(v)

        if e.RoutedEvent = InputElement.PointerPressedEvent then
            this.AddPoint(currentPoint.Position, Brushes.Green, 10., None)
        elif e.RoutedEvent = InputElement.PointerReleasedEvent then
            this.AddPoint(currentPoint.Position, Brushes.Red, 10., None)
        else
            let pts = e.GetIntermediatePoints(v)

            for c in 0 .. pts.Count - 1 do
                let pt = pts[c]
                let color1 = if c = (pts.Count - 1) then Brushes.Blue else Brushes.Black
                let res = if c = (pts.Count - 1) then 5. else 2.

                this.AddPoint(pt.Position, color1, res, Some(float(pt.Properties.Pressure)))

type PointerCanvas() =
    inherit Control()
    let _stopwatch = Stopwatch.StartNew()
    let mutable _events: int = 0
    let mutable _statusUpdated: IDisposable = null
    let _pointers = Dictionary<int, PointerPoints>()
    let mutable _lastProperties: PointerPointProperties = Unchecked.defaultof<_>
    let mutable _lastNonOtherUpdateKind: PointerUpdateKind = Unchecked.defaultof<_>
    let statusChanged = Event<EventHandler<string>, string>()

    [<CLIEvent>]
    member this.StatusChanged = statusChanged.Publish

    member val ThreadSleep = 0 with get, set

    static member ThreadSleepProperty: DirectProperty<PointerCanvas, int> =
        AvaloniaProperty.RegisterDirect<PointerCanvas, int>("ThreadSleep", (fun o -> o.ThreadSleep), (fun o v -> o.ThreadSleep <- v))

    member val DrawOnlyPoints = false with get, set

    static member DrawOnlyPointsProperty: DirectProperty<PointerCanvas, bool> =
        AvaloniaProperty.RegisterDirect<PointerCanvas, bool>("DrawOnlyPoints", (fun o -> o.DrawOnlyPoints), (fun o v -> o.DrawOnlyPoints <- v))

    override this.OnAttachedToVisualTree(e: VisualTreeAttachmentEventArgs) =
        base.OnAttachedToVisualTree(e)

        _statusUpdated <-
            DispatcherTimer.Run(
                fun () ->
                    if _stopwatch.Elapsed.TotalMilliseconds > 250. then
                        let status =
                            $"
Events per second: {float _events / _stopwatch.Elapsed.TotalSeconds}
PointerUpdateKind: {_lastProperties.PointerUpdateKind}
Last PointerUpdateKind != Other: {_lastNonOtherUpdateKind}
IsLeftButtonPressed: {_lastProperties.IsLeftButtonPressed}
IsRightButtonPressed: {_lastProperties.IsRightButtonPressed}
IsMiddleButtonPressed: {_lastProperties.IsMiddleButtonPressed}
IsXButton1Pressed: {_lastProperties.IsXButton1Pressed}
IsXButton2Pressed: {_lastProperties.IsXButton2Pressed}
IsBarrelButtonPressed: {_lastProperties.IsBarrelButtonPressed}
IsEraser: {_lastProperties.IsEraser}
IsInverted: {_lastProperties.IsInverted}
Pressure: {_lastProperties.Pressure}
XTilt: {_lastProperties.XTilt}
YTilt: {_lastProperties.YTilt}
Twist: {_lastProperties.Twist}"

                        statusChanged.Trigger(this, status)
                        _stopwatch.Restart()
                        _events <- 0

                    true
                , TimeSpan.FromMilliseconds(10)
            )

    override this.OnDetachedFromVisualTree(e: VisualTreeAttachmentEventArgs) =
        base.OnDetachedFromVisualTree(e)
        _stopwatch.Stop()

        _statusUpdated.Dispose()

    member this.HandleEvent(e: PointerEventArgs) =
        _events <- _events + 1

        if this.ThreadSleep <> 0 then
            Thread.Sleep(this.ThreadSleep)

        this.InvalidateVisual()

        let lastPointer = e.GetCurrentPoint(this)

        _lastProperties <- lastPointer.Properties

        if _lastProperties.PointerUpdateKind <> PointerUpdateKind.Other then
            _lastNonOtherUpdateKind <- _lastProperties.PointerUpdateKind

        if
            e.RoutedEvent = InputElement.PointerReleasedEvent
            && e.Pointer.Type = PointerType.Touch
        then
            _pointers.Remove(e.Pointer.Id) |> ignore

        if
            e.Pointer.Type <> PointerType.Pen
            || lastPointer.Properties.Pressure > float32 0.
        then
            let mutable pt = PointerPoints()

            if not(_pointers.TryGetValue(e.Pointer.Id, &pt)) then
                pt <- PointerPoints()
                _pointers[e.Pointer.Id] <- pt

            pt.HandleEvent(e, this)

    override this.Render(context: DrawingContext) =
        context.FillRectangle(Brushes.White, this.Bounds)

        for KeyValue(_, pt) in _pointers do
            pt.Render context this.DrawOnlyPoints

        base.Render(context)

    override this.OnPointerPressed(e: PointerPressedEventArgs) =
        if e.ClickCount = 2 then
            _pointers.Clear()
            this.InvalidateVisual()

        this.HandleEvent(e)
        base.OnPointerPressed(e)

    override this.OnPointerMoved(e: PointerEventArgs) =
        this.HandleEvent(e)
        base.OnPointerMoved(e)

    override this.OnPointerReleased(e: PointerReleasedEventArgs) =
        this.HandleEvent(e)
        base.OnPointerReleased(e)

    override this.OnPointerCaptureLost(e: PointerCaptureLostEventArgs) =
        _lastProperties <- Unchecked.defaultof<_>
        base.OnPointerCaptureLost(e)

type IFabPointerCanvas =
    inherit IFabControl

module PointerCanvas =
    let WidgetKey = Widgets.register<PointerCanvas>()

    let DrawOnlyPoints =
        Attributes.defineAvaloniaPropertyWithEquality PointerCanvas.DrawOnlyPointsProperty

    let ThreadSleep =
        Attributes.defineAvaloniaPropertyWithEquality PointerCanvas.ThreadSleepProperty

    let StatusChanged =
        Attributes.Mvu.defineEvent "PointerCanvas_StatusChanged" (fun target -> (target :?> PointerCanvas).StatusChanged)

[<AutoOpen>]
module PointerCanvasTabBuilders =
    type Fabulous.Avalonia.View with

        static member PointerCanvas(drawingPoint: bool, threadSleep: int, fn: string -> 'msg) =
            WidgetBuilder<'msg, IFabPointerCanvas>(
                PointerCanvas.WidgetKey,
                PointerCanvas.DrawOnlyPoints.WithValue(drawingPoint),
                PointerCanvas.ThreadSleep.WithValue(threadSleep),
                PointerCanvas.StatusChanged.WithValue(fn)
            )
