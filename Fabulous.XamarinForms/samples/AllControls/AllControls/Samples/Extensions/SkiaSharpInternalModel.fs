namespace AllControls.Samples.Extensions

open SkiaSharp
open SkiaSharp.Views.Forms
open Xamarin.Forms
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.SkiaSharp

module SkiaSharpInternalModel =
    type SkModel =
        { Points: (float32 * float32) list }

    type SkMsg =
        | AddPoint of x: float32 * y: float32

    let view () =
        View.ContentPage(
            View.WithInternalModel(
                init = (fun () -> { Points = [] }),
                update = (fun msg model ->
                    match msg with
                    | AddPoint (x, y) -> { model with Points = (x,y)::model.Points}
                ),
                view = (fun model dispatch ->
                    View.SKCanvasView(
                        enableTouchEvents = true, 
                        invalidate = true,
                        paintSurface = (fun args -> 
                            let info = args.Info
                            let surface = args.Surface
                            let canvas = surface.Canvas

                            canvas.Clear() 
                            use paint = new SKPaint(Style = SKPaintStyle.Stroke, Color = Color.Red.ToSKColor(), StrokeWidth = 25.0f)
                            for (x,y) in List.rev model.Points do
                                canvas.DrawCircle(x, y, 100.0f, paint)
                        ),
                        touch = (fun args -> 
                            dispatch (AddPoint (args.Location.X, args.Location.Y))
                        )
                    )
                )
            )
        )