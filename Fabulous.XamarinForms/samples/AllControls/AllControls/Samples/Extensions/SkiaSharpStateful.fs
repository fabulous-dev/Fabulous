namespace AllControls.Samples.Extensions

open SkiaSharp
open SkiaSharp.Views.Forms
open Xamarin.Forms
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.SkiaSharp

module SkiaSharpStateful =
    type State = 
        { mutable touches: int
          mutable paints: int }

    let view () =
        View.ContentPage(
            View.Stateful(
                (fun () -> { touches = 0; paints = 0 }), 
                (fun state -> 
                    View.SKCanvasView(enableTouchEvents = true, 
                        paintSurface = (fun args -> 
                            let info = args.Info
                            let surface = args.Surface
                            let canvas = surface.Canvas
                            state.paints <- state.paints + 1
                            printfn "paint event, total paints on this control = %d" state.paints

                            let (x, y) = float32 (info.Width / 2), float32 (info.Height / 2)

                            canvas.Clear() 
                            use paint = new SKPaint(Style = SKPaintStyle.Stroke, Color = Color.Red.ToSKColor(), StrokeWidth = 25.0f)
                            canvas.DrawCircle(x, y, 100.0f, paint)
                        ),
                        touch = (fun args -> 
                            state.touches <- state.touches + 1
                            printfn "touch event at (%f, %f), total touches on this control = %d" args.Location.X args.Location.Y state.touches
                        )
                ))
            )
        )