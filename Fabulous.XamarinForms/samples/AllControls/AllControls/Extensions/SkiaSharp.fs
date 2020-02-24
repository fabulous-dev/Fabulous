namespace AllControls.Extensions

open AllControls.Helpers

open System
open SkiaSharp
open SkiaSharp.Views.Forms
open Xamarin.Forms
open Fabulous
open Fabulous.XamarinForms

module SkiaSharp =
    type Circle =
        { Center: SKPoint
          Color: Color }
    
    type Msg =
        | SurfaceTouched of SKPoint
        | CircleRemoved of Circle
        
    type CmdMsg = Nothing
        
    type Model =
        { Circles: Circle list }
        
    let createNewCircle point =
        { Center = point
          Color = randomColor() }
        
    let mapToCmd (_: CmdMsg) : Cmd<Msg> =
        Cmd.none
        
    let init () =
        { Circles = [] }
        
    let update msg model : Model * CmdMsg list =
        match msg with
        | SurfaceTouched point ->
            { model with Circles = (createNewCircle point) :: model.Circles }, []
        | CircleRemoved circle ->
            { model with Circles = model.Circles |> List.except [circle] }, []
        
    let skiaSharpView model dispatch =
        View.NonScrollingContentPage("Canvas samples",
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
                            for circle in (List.rev model.Circles) ->
                                View.TextCell(
                                    text = sprintf "Circle at %.0f / %.0f" circle.Center.X circle.Center.Y,
                                    textColor = circle.Color,
                                    command = fun() -> dispatch (CircleRemoved circle)
                                )
                        ]
                    ).Row(1)
                ]
            )
        )
        
    let view model dispatch = 
        match Device.RuntimePlatform with
        | Device.GTK -> 
            View.ContentPage( 
                View.StackLayout [
                    View.Label(text="Your Platform does not support SkiaSharp")
                    View.Label(text="For GTK status see https://github.com/mono/SkiaSharp/issues/379")
                  ])
        | _ -> 
          skiaSharpView model dispatch 

