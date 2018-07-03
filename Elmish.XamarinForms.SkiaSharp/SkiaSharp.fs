namespace Elmish.XamarinForms.DynamicViews 

[<AutoOpen>]
module MapsExtension = 

    open Elmish.XamarinForms
    open Elmish.XamarinForms.DynamicViews

    open Xamarin.Forms
    open SkiaSharp
    open SkiaSharp.Views.Forms

    let CanvasEnableTouchEventsAttribKey = AttributeKey<_> "SKCanvas_EnableTouchEvents"
    let IgnorePixelScalingAttribKey = AttributeKey<_> "SKCanvas_IgnorePixelScaling"
    let OnPaintSurfaceAttribKey = AttributeKey<_> "SKCanvas_PaintSurface"
    let OnTouchAttribKey = AttributeKey<_> "SKCanvas_Touch"

    type Xaml with
        /// Describes a Map in the view
        static member SKCanvasView(?onPaintSurface: (SKPaintSurfaceEventArgs -> unit), ?onTouch: (SKTouchEventArgs -> unit), ?enableTouchEvents: bool, ?ignorePixelScaling: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

            // Count the number of additional attributes
            let attribCount = 0
            let attribCount = match enableTouchEvents with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match ignorePixelScaling with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match onPaintSurface with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match onTouch with Some _ -> attribCount + 1 | None -> attribCount

            // Populate the attributes of the base element
            let attribs = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

            // Add our own attributes. They must have unique names which must match the names below.
            match enableTouchEvents with None -> () | Some v -> attribs.Add(CanvasEnableTouchEventsAttribKey, v) 
            match ignorePixelScaling with None -> () | Some v -> attribs.Add(IgnorePixelScalingAttribKey, v) 
            match onPaintSurface with None -> () | Some v -> attribs.Add(OnPaintSurfaceAttribKey, System.EventHandler<_>(fun _sender args -> v args))
            match onTouch with None -> () | Some v -> attribs.Add(OnTouchAttribKey, System.EventHandler<_>(fun _sender args -> v args))

            // The create method
            let create () = new SkiaSharp.Views.Forms.SKCanvasView()

            // The update method
            let update (prevOpt: ViewElement voption) (source: ViewElement) (target: SKCanvasView) = 
                Xaml._UpdateView prevOpt source (target :> View)
                source.UpdatePrimitive(prevOpt, target, CanvasEnableTouchEventsAttribKey, (fun target v -> target.EnableTouchEvents <- v))
                source.UpdatePrimitive(prevOpt, target, IgnorePixelScalingAttribKey, (fun target v -> target.IgnorePixelScaling <- v))
                source.UpdateEvent(prevOpt, OnPaintSurfaceAttribKey, target.PaintSurface)
                source.UpdateEvent(prevOpt, OnTouchAttribKey, target.Touch)

            // The element
            ViewElement.Create(create, update, attribs)

