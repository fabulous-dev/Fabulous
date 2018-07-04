namespace Elmish.XamarinForms.DynamicViews 

[<AutoOpen>]
module MapsExtension = 

    open Elmish.XamarinForms.DynamicViews

    open Xamarin.Forms
    open SkiaSharp
    open SkiaSharp.Views.Forms

    let CanvasEnableTouchEventsAttribKey = AttributeKey<_> "SKCanvas_EnableTouchEvents"
    let IgnorePixelScalingAttribKey = AttributeKey<_> "SKCanvas_IgnorePixelScaling"
    let PaintSurfaceAttribKey = AttributeKey<_> "SKCanvas_PaintSurface"
    let TouchAttribKey = AttributeKey<_> "SKCanvas_Touch"

    type Xaml with
        /// Describes a Map in the view
        static member SKCanvasView(?paintSurface: (SKPaintSurfaceEventArgs -> unit), ?touch: (SKTouchEventArgs -> unit), ?enableTouchEvents: bool, ?ignorePixelScaling: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

            // Count the number of additional attributes
            let attribCount = 0
            let attribCount = match enableTouchEvents with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match ignorePixelScaling with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match paintSurface with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match touch with Some _ -> attribCount + 1 | None -> attribCount

            // Populate the attributes of the base element
            let attribs = Xaml.ZBuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

            // Add our own attributes. They must have unique names which must match the names below.
            match enableTouchEvents with None -> () | Some v -> attribs.Add(CanvasEnableTouchEventsAttribKey, v) 
            match ignorePixelScaling with None -> () | Some v -> attribs.Add(IgnorePixelScalingAttribKey, v) 
            match paintSurface with None -> () | Some v -> attribs.Add(PaintSurfaceAttribKey, System.EventHandler<_>(fun _sender args -> v args))
            match touch with None -> () | Some v -> attribs.Add(TouchAttribKey, System.EventHandler<_>(fun _sender args -> v args))

            // The create method
            let create () = new SkiaSharp.Views.Forms.SKCanvasView()

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: SKCanvasView) = 
                Xaml.UpdateView (prevOpt, source, target)
                source.UpdatePrimitive(prevOpt, target, CanvasEnableTouchEventsAttribKey, (fun target v -> target.EnableTouchEvents <- v))
                source.UpdatePrimitive(prevOpt, target, IgnorePixelScalingAttribKey, (fun target v -> target.IgnorePixelScaling <- v))
                source.UpdateEvent(prevOpt, PaintSurfaceAttribKey, target.PaintSurface)
                source.UpdateEvent(prevOpt, TouchAttribKey, target.Touch)

            // The element
            ViewElement.Create(create, update, attribs)

#if DEBUG 
    let sample1 = 
        Xaml.SKCanvasView(enableTouchEvents = true, 
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
#endif
