Fabulous - Guide
=======

{% include_relative contents-views.md %}

Using SkiaSharp
------

SkiaSharp is a 2D graphics system for .NET powered by the open-source Skia graphics engine that is used extensively in Google products. You can use SkiaSharp in your Xamarin.Forms applications to draw 2D vector graphics, bitmaps, and text.

The nuget [`Fabulous.SkiaSharp`](https://www.nuget.org/packages/Fabulous.SkiaSharp) implements a view component for the type [SKCanvasView](https://developer.xamarin.com/api/type/SkiaSharp.Views.Forms.SKCanvasView/).

[![SkiaSharp example from Microsoft](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/curves/arcs-images/anglearc-small.png)](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/curves/arcs-images/anglearc-small.png)

To use `Fabulous.SkiaSharp`, you must

1. Add a reference to `SkiaSharp.Views.Forms` across your whole solution.  This will add appropriate references to your platform-specific Android and iOS projects too.
2. Next add a reference to `Fabulous.SkiaSharp` across your whole solution.

After these steps you can use SkiaSharp in your view function. Here is a simple example of using SkiaSharp to
draw a circle and respond to touch events:

```fsharp
open Fabulous.DynamicViews

View.SKCanvasView(enableTouchEvents = true,
    paintSurface = (fun args ->
        let info = args.Info
        let surface = args.Surface
        let canvas = surface.Canvas

        canvas.Clear()
        use paint = new SKPaint(Style = SKPaintStyle.Stroke, Color = Color.Red.ToSKColor(), StrokeWidth = 25.0f)
        canvas.DrawCircle(float32 (info.Width / 2), float32 (info.Height / 2), 100.0f, paint)
    ),
    touch = (fun args ->
        printfn "touch event at (%f, %f)" args.Location.X args.Location.Y
    )
)
```

By default, the view will not be redrawn when the model changes. You should call `View.SKCanvasView(..., invalidate = true)` if you want the drawn content to depend on model changes.

See also:

* [Core Elements](views-elements.md).
* [Using SkiaSharp in Xamarin.Forms](https://docs.microsoft.com/en-us/xamarin/xamarin-forms/user-interface/graphics/skiasharp/).
* [Source for the SkiaSharp extension](https://github.com/fsprojects/Fabulous/tree/master/extensions/SkiaSharp)
* [Defining Extensions](views-extending.md)
