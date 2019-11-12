namespace PrettyWeather
open Fabulous
open Fabulous.XamarinForms
[<AutoOpen>]
module PancakeViewExtensions =

    open Fabulous
    open Fabulous.XamarinForms

    // Define keys for the possible attributes
    
    let backgroundGradientStartColorAttribKey = AttributeKey "backgroundGradientStartColorAttribKey"
    let backgroundGradientEndColorAttribKey = AttributeKey "backgroundGradientEndColorAttribKey"
    let contentPancakeAttribKey = AttributeKey "contentkey"
    let paddingKey = AttributeKey "paddingKey"
    let cornerRadiusKey = AttributeKey "cornerRadiusKey"
    let backgroundGradientAngleKey = AttributeKey "backgroundGradientAngleKey"
    // Fully-qualified name to avoid extending by mistake
    // another View class (like Xamarin.Forms.View)
    type Fabulous.XamarinForms.View with
        /// Describes a ABC in the view
        /// The inline keyword is important for performance
        static member inline PancakeView(?backgroundGradientStartColor,?backgroundGradientEndColor,?content,
                                            ?cornerRadius,?padding,?backgroundGradientAngle,
                                            ?horizontalOptions, ?verticalOptions, ?margin, ?gestureRecognizers, ?anchorX, ?anchorY, ?backgroundColor,
                                            ?flowDirection, ?heightRequest, ?inputTransparent, ?isEnabled, ?isTabStop, ?isVisible, ?minimumHeightRequest, 
                                            ?minimumWidthRequest, ?opacity, ?rotation, ?rotationX, ?rotationY, ?scale, ?scaleX, ?scaleY, ?tabIndex, 
                                            ?style, ?translationX, ?translationY, ?visual, ?widthRequest, ?resources, ?styles, ?styleSheets, ?focused, 
                                            ?unfocused, ?classId, ?styleId, ?automationId, ?created, ?styleClass, ?effects, ?ref, ?tag,
                                            ?shellBackgroundColor, ?shellForegroundColor, ?shellDisabledColor, ?shellTabBarBackgroundColor,
                                            ?shellTabBarForegroundColor, ?shellTitleColor, ?shellUnselectedColor, ?shellBackButtonBehavior, 
                                            ?shellFlyoutBehavior, ?shellTabBarIsVisible, ?shellTitleView) =

            let attribCount = 0
            let attribCount = match backgroundGradientStartColor with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match backgroundGradientEndColor with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount
            let attribCount = match backgroundGradientAngle with Some _ -> attribCount + 1 | None -> attribCount
            let attribs = ViewBuilders.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin,
                                                    ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, 
                                                    ?backgroundColor=backgroundColor, ?flowDirection=flowDirection, ?heightRequest=heightRequest, 
                                                    ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isTabStop=isTabStop, 
                                                    ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, 
                                                    ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, 
                                                    ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?scaleX=scaleX, ?scaleY=scaleY, 
                                                    ?tabIndex=tabIndex, ?style=style, ?translationX=translationX, ?translationY=translationY,
                                                    ?visual=visual, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, 
                                                    ?styleSheets=styleSheets, ?focused=focused, ?unfocused=unfocused, ?classId=classId, 
                                                    ?styleId=styleId, ?automationId=automationId, ?created=created, ?styleClass=styleClass, 
                                                    ?effects=effects, ?ref=ref, ?tag=tag, ?shellBackgroundColor=shellBackgroundColor, 
                                                    ?shellForegroundColor=shellForegroundColor, ?shellDisabledColor=shellDisabledColor, 
                                                    ?shellTabBarBackgroundColor=shellTabBarBackgroundColor, 
                                                    ?shellTabBarForegroundColor=shellTabBarForegroundColor, ?shellTitleColor=shellTitleColor, 
                                                    ?shellUnselectedColor=shellUnselectedColor, ?shellBackButtonBehavior=shellBackButtonBehavior, 
                                                    ?shellFlyoutBehavior=shellFlyoutBehavior, ?shellTabBarIsVisible=shellTabBarIsVisible,
                                                    ?shellTitleView=shellTitleView)

            match backgroundGradientStartColor with None -> () | Some v -> attribs.Add(backgroundGradientStartColorAttribKey, v)
            match backgroundGradientEndColor with None -> () | Some v -> attribs.Add(backgroundGradientEndColorAttribKey, v)
            match content with None -> () | Some v -> attribs.Add(contentPancakeAttribKey, v)
            match padding with None -> () | Some v -> attribs.Add(paddingKey, v)
            match cornerRadius with None -> () | Some v -> attribs.Add(cornerRadiusKey, v)
            match backgroundGradientAngle with None -> () | Some v -> attribs.Add(backgroundGradientAngleKey, v)

            // The creation method
            let create () = new Xamarin.Forms.PancakeView.PancakeView()

            // The incremental update method
            let update (prev: ViewElement voption) (source: ViewElement) (target: Xamarin.Forms.PancakeView.PancakeView) =
                ViewBuilders.UpdateView(prev,source,target)
                source.UpdateElement(prev,target, contentPancakeAttribKey,(fun target -> target.Content), (fun target v -> target.Content <- v))
                source.UpdatePrimitive(prev, target, backgroundGradientStartColorAttribKey, (fun target v -> target.BackgroundGradientStartColor <- v))
                source.UpdatePrimitive(prev, target, backgroundGradientEndColorAttribKey, (fun target v -> target.BackgroundGradientEndColor <- v))
                source.UpdatePrimitive(prev, target, paddingKey, (fun target v -> target.Padding <- v))
                source.UpdatePrimitive(prev, target, cornerRadiusKey, (fun target v -> target.CornerRadius <- v))
                source.UpdatePrimitive(prev, target, backgroundGradientAngleKey, (fun target v -> target.BackgroundGradientAngle <- v))
                

            ViewElement.Create<Xamarin.Forms.PancakeView.PancakeView>(create, update, attribs)