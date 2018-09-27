// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.DynamicViews 

[<AutoOpen>]
module SkiaSharpExtension = 

    open Fabulous.DynamicViews

    open Xamarin.Forms
    open SkiaSharp
    open SkiaSharp.Views.Forms

    let CanvasEnableTouchEventsAttribKey = AttributeKey<_> "SKCanvas_EnableTouchEvents"
    let IgnorePixelScalingAttribKey = AttributeKey<_> "SKCanvas_IgnorePixelScaling"
    let PaintSurfaceAttribKey = AttributeKey<_> "SKCanvas_PaintSurface"
    let TouchAttribKey = AttributeKey<_> "SKCanvas_Touch"
    let InvalidateAttribKey = AttributeKey<_> "SKCanvas_Invalidate"

    type Fabulous.DynamicViews.View with
        /// Describes a Map in the view
        static member SKCanvasView(?paintSurface: (SKPaintSurfaceEventArgs -> unit), ?touch: (SKTouchEventArgs -> unit), ?enableTouchEvents: bool, ?ignorePixelScaling: bool,
                                   ?invalidate: bool,
                                   // inherited attributes common to all views
                                   ?horizontalOptions, ?verticalOptions, ?margin, ?gestureRecognizers, ?anchorX, ?anchorY, ?backgroundColor,
                                   ?heightRequest, ?inputTransparent, ?isEnabled, ?isVisible, ?minimumHeightRequest, ?minimumWidthRequest,
                                   ?opacity, ?rotation, ?rotationX, ?rotationY, ?scale, ?style, ?translationX, ?translationY, ?widthRequest,
                                   ?resources, ?styles, ?styleSheets, ?classId, ?styleId, ?automationId, ?created) =

            // Count the number of additional attributes
            let attribCount = 0
            let attribCount = match enableTouchEvents with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match ignorePixelScaling with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match invalidate with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match paintSurface with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match touch with Some _ -> attribCount + 1 | None -> attribCount

            // Populate the attributes of the base element
            let attribs = 
                View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, 
                               ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, 
                               ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, 
                               ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, 
                               ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, 
                               ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, 
                              ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId,
                              ?automationId=automationId, ?created=created)

            // Add our own attributes. They must have unique names which must match the names below.
            match enableTouchEvents with None -> () | Some v -> attribs.Add(CanvasEnableTouchEventsAttribKey, v) 
            match ignorePixelScaling with None -> () | Some v -> attribs.Add(IgnorePixelScalingAttribKey, v) 
            match invalidate with None -> () | Some v -> attribs.Add(InvalidateAttribKey, v)
            match paintSurface with None -> () | Some v -> attribs.Add(PaintSurfaceAttribKey, System.EventHandler<_>(fun _sender args -> v args))
            match touch with None -> () | Some v -> attribs.Add(TouchAttribKey, System.EventHandler<_>(fun _sender args -> v args))

            // The create method
            let create () = new SkiaSharp.Views.Forms.SKCanvasView()

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: SKCanvasView) = 
                View.UpdateView (prevOpt, source, target)
                source.UpdatePrimitive(prevOpt, target, CanvasEnableTouchEventsAttribKey, (fun target v -> target.EnableTouchEvents <- v))
                source.UpdatePrimitive(prevOpt, target, IgnorePixelScalingAttribKey, (fun target v -> target.IgnorePixelScaling <- v))
                source.UpdatePrimitive(prevOpt, target, InvalidateAttribKey, (fun target v -> if v then target.InvalidateSurface()))
                source.UpdateEvent(prevOpt, PaintSurfaceAttribKey, target.PaintSurface)
                source.UpdateEvent(prevOpt, TouchAttribKey, target.Touch)

            // The element
            ViewElement.Create(create, update, attribs)

#if DEBUG 
    type State = 
        { mutable touches: int
          mutable paints: int }

    let sample1 = 
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

                        canvas.Clear() 
                        use paint = new SKPaint(Style = SKPaintStyle.Stroke, Color = Color.Red.ToSKColor(), StrokeWidth = 25.0f)
                        canvas.DrawCircle(float32 (info.Width / 2), float32 (info.Height / 2), 100.0f, paint)
                    ),
                    touch = (fun args -> 
                        state.touches <- state.touches + 1
                        printfn "touch event at (%f, %f), total touches on this control = %d" args.Location.X args.Location.Y state.touches
                    )
            )))
#endif
