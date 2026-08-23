namespace Gallery

open System
open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Rendering.SceneGraph
open Avalonia.Skia
open Fabulous.Avalonia
open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open SkiaSharp

#nowarn "0044"


open type Fabulous.Avalonia.View

type CustomDrawOp(bounds: Rect, noSkia: GlyphRun) =
    let mutable _noSkia = null
    static let St = Stopwatch.StartNew()

    do _noSkia <- noSkia.TryCreateImmutableGlyphRunReference()

    member this.Animate(d: int, from: int, to': int) =
        let ms = int(St.ElapsedMilliseconds) / d
        let diff = to' - from
        let range = diff * 2
        let v = ms % range
        let mutable rv = v

        if v > diff then
            rv <- range - v

        rv <- v + from

        if rv < from || rv > to' then
            printfn $"Animate: %d{d} %d{from} %d{to'} %d{ms} %d{diff} %d{range}"

        rv

    interface ICustomDrawOperation with
        member this.Dispose() = ()
        member this.Equals(_other) = false
        member this.HitTest(_p) = false

        member this.Render(context: ImmediateDrawingContext) =
            let leaseFeature =
                context.TryGetFeature(typeof<ISkiaSharpApiLeaseFeature>) :?> ISkiaSharpApiLeaseFeature

            if leaseFeature = null then
                context.DrawGlyphRun(Brushes.Black, _noSkia)
            else
                use lease = leaseFeature.Lease()
                let canvas = lease.SkCanvas
                canvas.Save() |> ignore

                let colors =
                    [| SKColor(byte 0, byte 255, byte 255)
                       SKColor(byte 255, byte 0, byte 255)
                       SKColor(byte 255, byte 255, byte 0)
                       SKColor(byte 0, byte 255, byte 255) |]

                let _sx = this.Animate(100, 2, 10)
                let _sy = this.Animate(1000, 5, 15)

                let lightPosition =
                    SKPoint(
                        float32(
                            bounds.Width / float 2
                            + Math.Cos(St.Elapsed.TotalSeconds) * bounds.Width / float 4
                        ),
                        float32(
                            bounds.Height / float 2
                            + Math.Sin(St.Elapsed.TotalSeconds) * bounds.Height / float 4
                        )
                    )

                use sweep =
                    SKShader.CreateSweepGradient(SKPoint(float32(bounds.Width / float 2), float32(bounds.Height / float 2)), colors, null)

                use turbulence = SKShader.CreatePerlinNoiseFractalNoise(0.05f, 0.05f, 4, 0f)

                use shader = SKShader.CreateCompose(sweep, turbulence, SKBlendMode.SrcATop)

                use blur =
                    SKImageFilter.CreateBlur(float32(this.Animate(100, 2, 10)), float32(this.Animate(100, 5, 15)))

                using (new SKPaint(Shader = shader, ImageFilter = blur)) (fun paint -> canvas.DrawPaint(paint))

                use pseudoLight =
                    SKShader.CreateRadialGradient(
                        lightPosition,
                        float32(bounds.Width / float 3),
                        [| SKColor(byte 255, byte 200, byte 200, byte 100)
                           SKColors.Transparent
                           SKColor(byte 40, byte 40, byte 40, byte 220)
                           SKColor(byte 20, byte 20, byte 20, byte(this.Animate(100, 200, 220))) |],
                        [| 0.3f; 0.3f; 0.8f; 1f |],
                        SKShaderTileMode.Clamp
                    )

                using (new SKPaint(Shader = pseudoLight)) (fun paint -> canvas.DrawPaint(paint))

                canvas.Restore()

        member this.Bounds = bounds


type CustomSkiaControl() as this =
    inherit Control()

    let mutable _noSkia = null

    do
        this.ClipToBounds <- true
        let text = "Current rendering API is not Skia"

        let glyphs =
            text.ToCharArray()
            |> Array.map(fun ch -> Typeface.Default.GlyphTypeface.GetGlyph(uint32 ch))

        _noSkia <- new GlyphRun(Typeface.Default.GlyphTypeface, 12., text.AsMemory(), glyphs)

    override this.Render(context: DrawingContext) =
        context.Custom(new CustomDrawOp(Rect(0, 0, this.Bounds.Width, this.Bounds.Height), _noSkia))

        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(this.InvalidateVisual, Avalonia.Threading.DispatcherPriority.Background)
        |> ignore

type IFabCustomSkiaControl =
    inherit IFabControl

module CustomSkiaControl =

    let WidgetKey = Widgets.register<CustomSkiaControl>()

[<AutoOpen>]
module CustomSkiaBuilders =

    type Fabulous.Avalonia.View with

        static member CustomSkiaControl() =
            WidgetBuilder<'msg, IFabCustomSkiaControl>(CustomSkiaControl.WidgetKey)

module CustomSkiaPage =
    let view () = Grid() { View.CustomSkiaControl() }
