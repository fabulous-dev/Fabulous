namespace Gallery

open System
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Threading
open Fabulous.Avalonia
open Fabulous.StackAllocatedCollections.StackList
open Fabulous

#nowarn "0044"

open type Fabulous.Avalonia.View

type GlyphRunControl() =
    inherit Control()

    let mutable _glyphTypeface = Typeface.Default.GlyphTypeface

    let mutable _rand = Random()

    let mutable _glyphIndices = Array.zeroCreate<_> 1

    let mutable _characters = Array.zeroCreate<_> 1

    let mutable _fontSize = 20.0

    let mutable _direction = 10

    let mutable _timer = DispatcherTimer()

    override this.OnAttachedToVisualTree _e =
        _timer <- DispatcherTimer(Interval = TimeSpan.FromSeconds(1.0))

        _timer.Tick.Add(fun _ -> this.InvalidateVisual())

        _timer.Start()

    override this.OnDetachedFromVisualTree _e =
        _timer.Stop()

        _timer <- null

    override this.Render context =
        let c = char(_rand.Next(65, 90))

        if _fontSize + float _direction > 200.0 then
            _direction <- -10
        elif _fontSize + float _direction < 20.0 then
            _direction <- 10

        _fontSize <- _fontSize + float _direction

        _glyphIndices[0] <- _glyphTypeface.GetGlyph(uint32 c)

        _characters[0] <- c

        let glyphRun = new GlyphRun(_glyphTypeface, _fontSize, _characters, _glyphIndices)

        context.DrawGlyphRun(Brushes.Black, glyphRun)

type GlyphRunGeometryControl() =
    inherit Control()

    let mutable _glyphTypeface = Typeface.Default.GlyphTypeface

    let mutable _rand = Random()

    let mutable _glyphIndices = Array.zeroCreate<_> 1

    let mutable _characters = Array.zeroCreate<_> 1

    let mutable _fontSize = 20.0

    let mutable _direction = 10

    let mutable _timer = DispatcherTimer()

    override this.OnAttachedToVisualTree _e =
        _timer <- DispatcherTimer(Interval = TimeSpan.FromSeconds(1.0))

        _timer.Tick.Add(fun _ -> this.InvalidateVisual())

        _timer.Start()

    override this.OnDetachedFromVisualTree _e =
        _timer.Stop()

        _timer <- null

    override this.Render context =
        let c = char(_rand.Next(65, 90))

        if _fontSize + float _direction > 200.0 then
            _direction <- -10
        elif _fontSize + float _direction < 20.0 then
            _direction <- 10

        _fontSize <- _fontSize + float _direction

        _glyphIndices[0] <- _glyphTypeface.GetGlyph(uint32 c)

        _characters[0] <- c

        let glyphRun = new GlyphRun(_glyphTypeface, _fontSize, _characters, _glyphIndices)

        let geometry = glyphRun.BuildGeometry()

        context.DrawGeometry(Brushes.Green, null, geometry)


type IFabGlyphRunControl =
    inherit IFabControl

module GlyphRun =

    let WidgetKey = Widgets.register<GlyphRunControl>()

[<AutoOpen>]
module GlyphRunControlBuilders =

    type Fabulous.Avalonia.View with

        static member GlyphRun() =
            WidgetBuilder<'msg, IFabGlyphRunControl>(GlyphRun.WidgetKey)

type IFabGlyphRunGeometryControl =
    inherit IFabControl

module GlyphRunGeometry =
    let WidgetKey = Widgets.register<GlyphRunGeometryControl>()

[<AutoOpen>]
module GlyphRunGeometryControlBuilders =

    type Fabulous.Avalonia.View with

        static member GlyphRunGeometry() =
            WidgetBuilder<'msg, IFabGlyphRunGeometryControl>(GlyphRunGeometry.WidgetKey)


module GlyphRunPage =
    let view () =
        (Grid(coldefs = [ Star; Star ], rowdefs = [ Auto ]) {
            View.GlyphRun().gridColumn(0)
            View.GlyphRunGeometry().gridColumn(1)
        })
            .background(Brushes.White)
