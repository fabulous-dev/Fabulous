namespace Gallery

open System.Diagnostics
open System.Runtime.InteropServices
open Avalonia
open Avalonia.Controls
open Avalonia.Media
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList
open Avalonia.Media.Imaging
open Avalonia.Media.Immutable
open Avalonia.Platform
open Fabulous

open type Fabulous.Avalonia.View


type WriteableBitmapControl() =
    inherit Control()

    let mutable _unpremulBitmap = null

    let mutable _premulBitmap = null

    let mutable _st = Stopwatch.StartNew()

    override this.OnAttachedToLogicalTree(e) =
        _unpremulBitmap <- new WriteableBitmap(PixelSize(256, 256), Vector(96, 96), PixelFormat.Bgra8888, AlphaFormat.Unpremul)
        _premulBitmap <- new WriteableBitmap(PixelSize(256, 256), Vector(96, 96), PixelFormat.Bgra8888, AlphaFormat.Premul)
        base.OnAttachedToLogicalTree(e)

    override this.OnDetachedFromLogicalTree(e) =
        base.OnDetachedFromLogicalTree(e)

        _unpremulBitmap.Dispose()
        _unpremulBitmap <- null

        _premulBitmap.Dispose()
        _premulBitmap <- null

    override this.Render(context) =
        let FillPixels (bitmap: WriteableBitmap) fillAlpha premul =
            use fb = bitmap.Lock()
            let data = Array.zeroCreate<int>(fb.Size.Width * fb.Size.Height)

            for y in 0 .. fb.Size.Height - 1 do
                for x in 0 .. fb.Size.Width - 1 do
                    let mutable color = Color(fillAlpha, byte 0, byte 255, byte 0)

                    if premul then
                        let r = byte(color.R * color.A / byte 255)
                        let g = byte(color.G * color.A / byte 255)
                        let b = byte(color.B * color.A / byte 255)

                        color <- Color(fillAlpha, r, g, b)

                    data[y * fb.Size.Width + x] <- int(color.ToUInt32())

            Marshal.Copy(data, 0, fb.Address, fb.Size.Width * fb.Size.Height)

        base.Render(context)

        let alpha = byte((_st.ElapsedMilliseconds / int64 10) % int64 256)

        FillPixels _unpremulBitmap alpha false
        FillPixels _premulBitmap alpha true

        context.FillRectangle(Brushes.Red, Rect(0, 0, int(256 * 3), 256))

        context.DrawImage(_unpremulBitmap, Rect(0, 0, 256, 256), Rect(0, 0, 256, 256))

        context.DrawImage(_premulBitmap, Rect(0, 0, 256, 256), Rect(256, 0, 256, 256))

        context.FillRectangle(ImmutableSolidColorBrush(Colors.Lime, float(alpha / byte 255)), Rect(512, 0, 256, 256))

        Avalonia.Threading.Dispatcher.UIThread.Post(this.InvalidateVisual, Avalonia.Threading.DispatcherPriority.Background)



type IFabWriteableBitmap =
    inherit IFabControl

module WriteableBitmap =

    let WidgetKey = Widgets.register<WriteableBitmapControl>()

[<AutoOpen>]
module WriteableBitmapBuilders =

    type Fabulous.Avalonia.View with

        static member WriteableBitmap() =
            WidgetBuilder<'msg, IFabWriteableBitmap>(WriteableBitmap.WidgetKey)

module WriteableBitmapPage =

    let view () = Grid() { View.WriteableBitmap() }
