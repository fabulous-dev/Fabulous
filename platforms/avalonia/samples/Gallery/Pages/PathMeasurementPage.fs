namespace Gallery

open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Media.Immutable
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList
open Avalonia.Media.Imaging
open Fabulous

open type Fabulous.Avalonia.View

type PathMeasurementControl() =
    inherit Control()

    let mutable _bitmap: RenderTargetBitmap = null

    let strokePen =
        ImmutablePen(Brushes.DarkBlue, 10., null, PenLineCap.Round, PenLineJoin.Round)

    let strokePen1 =
        ImmutablePen(Brushes.Purple, 10., null, PenLineCap.Round, PenLineJoin.Round)

    let strokePen2 =
        ImmutablePen(Brushes.Green, 10., null, PenLineCap.Round, PenLineJoin.Round)

    let strokePen3 =
        ImmutablePen(Brushes.LightBlue, 10., null, PenLineCap.Round, PenLineJoin.Round)

    let strokePen4 =
        ImmutablePen(Brushes.Red, 1., null, PenLineCap.Round, PenLineJoin.Round)

    do PathMeasurementControl.AffectsRender<PathMeasurementControl>(PathMeasurementControl.BoundsProperty)

    override this.OnAttachedToLogicalTree(e) =
        _bitmap <- new RenderTargetBitmap(PixelSize(500, 500), Vector(96, 96))
        base.OnAttachedToLogicalTree(e)

    override this.OnDetachedFromLogicalTree(e) =
        _bitmap.Dispose()
        _bitmap <- null

        base.OnDetachedFromLogicalTree(e)

    override this.Render(context) =
        use bitmapCtx = _bitmap.CreateDrawingContext()
        let basePath = new PathGeometry()

        using (basePath.Open()) (fun basePathCtx ->
            basePathCtx.BeginFigure(Point(20., 20.), false)
            basePathCtx.LineTo(Point(400., 50.))
            basePathCtx.LineTo(Point(80., 100.))
            basePathCtx.LineTo(Point(300., 150.))
            basePathCtx.EndFigure(false))

        bitmapCtx.DrawGeometry(null, strokePen, basePath)

        let length = basePath.ContourLength

        match basePath.TryGetSegment(length * 0.05, length * 0.2, true) with
        | true, dst1 -> bitmapCtx.DrawGeometry(null, strokePen1, dst1)
        | _ -> ()

        match basePath.TryGetSegment(length * 0.2, length * 0.8, true) with
        | true, dst2 -> bitmapCtx.DrawGeometry(null, strokePen2, dst2)
        | _ -> ()

        match basePath.TryGetSegment(length * 0.8, length * 0.95, true) with
        | true, dst3 -> bitmapCtx.DrawGeometry(null, strokePen3, dst3)
        | _ -> ()

        let pathBounds = basePath.GetRenderBounds(strokePen)

        bitmapCtx.DrawRectangle(null, strokePen4, pathBounds)

        context.DrawImage(_bitmap, Rect(0, 0, 500, 500), Rect(0, 0, 500, 500))

        base.Render(context)

type IFabPathMeasurement =
    inherit IFabControl

module PathMeasurement =

    let WidgetKey = Widgets.register<PathMeasurementControl>()

[<AutoOpen>]
module PathMeasurementBuilders =

    type Fabulous.Avalonia.View with

        static member PathMeasurement() =
            WidgetBuilder<'msg, IFabPathMeasurement>(PathMeasurement.WidgetKey)

module PathMeasurementPage =
    let view () = Grid() { View.PathMeasurement() }
