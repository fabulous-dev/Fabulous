namespace AllControls.Extensions

open AllControls.Helpers

open Fabulous.XamarinForms
open SkiaSharp
open SkiaSharp.Views.Forms
open System
open Xamarin.Forms

module SkiaSharp =
    type Circle =
        { Center: SKPoint
          Color: Color }
    
    type Msg =
        | GoBack
        | SurfaceTouched of SKPoint
        | CircleRemoved of Circle
        
    type Model =
        { Circles: Circle list }
        
    let createNewCircle point =
        let rand = Random()
        { Center = point
          Color = Color.FromRgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255)) }
        
    let init () =
        { Circles = [] }
        
    let update msg model =
        match msg with
        | GoBack ->
            init(), [], None
        | SurfaceTouched point ->
            { model with Circles = (createNewCircle point) :: model.Circles }, [], None
        | CircleRemoved circle ->
            { model with Circles = model.Circles |> List.except [circle] }, [], None
    
    let goBack dispatch () = dispatch GoBack
    
    let view model dispatch =
        View.NonScrollingContentPage("SKCanvasView", (goBack dispatch),
            View.Grid(
                rowdefs = [ Star; Star ],
                children = [
                    View.SKCanvasView(
                        enableTouchEvents = true,
                        invalidate = true,
                        paintSurface = (fun args ->
                            let canvas = args.Surface.Canvas
                            canvas.Clear()
                            
                            for circle in (List.rev model.Circles) do
                                use paint = new SKPaint(Style = SKPaintStyle.Stroke, Color = circle.Color.ToSKColor(), StrokeWidth = 25.0f)
                                canvas.DrawCircle(float32 circle.Center.X, float32 circle.Center.Y, 100.0f, paint)
                        ),
                        touch = (fun args -> 
                            if args.InContact then
                                dispatch (SurfaceTouched args.Location)
                        )
                    )
                    
                    View.ListView(
                        selectionMode = ListViewSelectionMode.None,
                        items = [
                            for circle in (List.rev model.Circles) do
                                yield View.TextCell(
                                    text = sprintf "Circle at %.0f / %.0f" circle.Center.X circle.Center.Y,
                                    textColor = circle.Color,
                                    command = fun() -> dispatch (CircleRemoved circle)
                                )
                        ]
                    ).Row(1)
                ]
            )
        )

