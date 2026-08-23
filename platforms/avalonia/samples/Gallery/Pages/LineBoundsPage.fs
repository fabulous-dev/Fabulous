namespace Gallery

open System
open Avalonia
open Avalonia.Media
open Avalonia.Controls
open Avalonia.Threading
open Fabulous
open Fabulous.Avalonia

[<RequireQualifiedAccess>]
module LineBoundsHelper =
    let calculateAngle (p1: Point, p2: Point) =
        let xDiff = p2.X - p1.X
        let yDiff = p2.Y - p1.Y

        Math.Atan2(yDiff, xDiff)

    let calculateOppSide (angle, hyp) = Math.Sin(angle) * hyp

    let calculateAdjSide (angle, hyp) = Math.Cos(angle) * hyp

    let translatePointsAlongTangent (p1: Point, p2: Point, angle, distance) =
        let xDiff = calculateOppSide(angle, distance)
        let yDiff = calculateAdjSide(angle, distance)

        let c1 = Point(p1.X + xDiff, p1.Y - yDiff)
        let c2 = Point(p1.X - xDiff, p1.Y + yDiff)

        let c3 = Point(p2.X + xDiff, p2.Y - yDiff)
        let c4 = Point(p2.X - xDiff, p2.Y + yDiff)

        let minX = Math.Min(c1.X, Math.Min(c2.X, Math.Min(c3.X, c4.X)))
        let minY = Math.Min(c1.Y, Math.Min(c2.Y, Math.Min(c3.Y, c4.Y)))
        let maxX = Math.Max(c1.X, Math.Max(c2.X, Math.Max(c3.X, c4.X)))
        let maxY = Math.Max(c1.Y, Math.Max(c2.Y, Math.Max(c3.Y, c4.Y)))

        {| P1 = Point(minX, minY)
           P2 = Point(maxX, maxY) |}

    let calculateBounds (p1: Point, p2: Point, thickness, angleToCorner) =
        let pts = translatePointsAlongTangent(p1, p2, angleToCorner, thickness / 2.)
        Rect(pts.P1, pts.P2)

    let calculateBounds2 (p1: Point, p2: Point, p: IPen) =
        let radians = calculateAngle(p1, p2)

        if (p.LineCap <> PenLineCap.Flat) then

            let pts =
                translatePointsAlongTangent(p1, p2, radians - Math.PI / 2., p.Thickness / 2.)

            calculateBounds(pts.P1, pts.P2, p.Thickness, radians)

        else

            calculateBounds(p1, p2, p.Thickness, radians)

type LineBoundsControl() =
    inherit Control()

    let mutable _timer: DispatcherTimer = null

    override this.OnAttachedToVisualTree(_: VisualTreeAttachmentEventArgs) =
        _timer <- DispatcherTimer()
        _timer.Interval <- TimeSpan.FromSeconds(1. / 60.)

        _timer.Tick.Add(fun _ ->
            this.Angle <- this.Angle + Math.PI / 360.
            this.InvalidateVisual())

        _timer.Start()

    override this.OnDetachedFromVisualTree(_: VisualTreeAttachmentEventArgs) = _timer.Stop()

    member val Angle = 0. with get, set

    override this.Render(drawingContext: DrawingContext) =
        let lineLength = Math.Sqrt((100. * 100.) + (100. * 100.))

        let diffX = LineBoundsHelper.calculateAdjSide(this.Angle, lineLength)

        let diffY = LineBoundsHelper.calculateOppSide(this.Angle, lineLength)

        let p1 = Point(200., 200.)
        let p2 = Point(p1.X + diffX, p1.Y + diffY)

        let pen = Pen(Brushes.Green, 20., lineCap = PenLineCap.Square)
        let boundPen = Pen(Brushes.Black)

        drawingContext.DrawLine(pen, p1, p2)

        drawingContext.DrawRectangle(boundPen, LineBoundsHelper.calculateBounds2(p1, p2, pen))


type IFabLineBoundsDemoControl =
    inherit IFabControl

module LineBoundsControl =
    let WidgetKey = Widgets.register<LineBoundsControl>()

    let Angle =
        Attributes.definePropertyWithGetSet
            "LineBoundsControl_Angle"
            (fun target ->
                let target = target :?> LineBoundsControl
                target.Angle)
            (fun target value ->
                let target = target :?> LineBoundsControl
                target.Angle <- value)

[<AutoOpen>]
module LineBoundsDemoControlBuilders =
    type Fabulous.Avalonia.View with

        static member LineBoundsDemoControl(angle: float) =
            WidgetBuilder<'msg, IFabLineBoundsDemoControl>(LineBoundsControl.WidgetKey, LineBoundsControl.Angle.WithValue(angle))


open type Fabulous.Avalonia.View

module LineBoundsPage =
    let view () =
        UniformGrid() {
            LineBoundsDemoControl(15.)
            LineBoundsDemoControl(30.)
            LineBoundsDemoControl(45.)
            LineBoundsDemoControl(60.)
            LineBoundsDemoControl(75.)
            LineBoundsDemoControl(90.)
        }
