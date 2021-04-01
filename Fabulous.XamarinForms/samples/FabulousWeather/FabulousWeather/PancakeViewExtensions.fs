namespace FabulousWeather

open Fabulous
open Fabulous.XamarinForms

[<AutoOpen>]
module PancakeViewExtensions =

    // Define keys for the possible attributes
    let backgroundGradientStartPointAttribKey = AttributeKey "BackgroundGradientStartPoint"
    let backgroundGradientEndPointAttribKey = AttributeKey "BackgroundGradientEndPoint"
    let backgroundGradientStopsAttribKey = AttributeKey<Xamarin.Forms.PancakeView.GradientStopCollection> "BackgroundGradientStops"
    let pancakeContentAttribKey = AttributeKey "PancakeContent"
    let paddingAttribKey = AttributeKey "Padding"
    let cornerRadiusKey = AttributeKey "CornerRadius"
    
    // Fully-qualified name to avoid extending by mistake
    // another View class (like Xamarin.Forms.View)
    type Fabulous.XamarinForms.View with
        /// Describes a ABC in the view
        /// The inline keyword is important for performance
        static member inline PancakeView(?content, ?backgroundGradientStartPoint, ?backgroundGradientEndPoint,
                                         ?cornerRadius, ?padding, ?backgroundGradientStops,
                                         // inherited attributes common to all views
                                         ?gestureRecognizers, ?horizontalOptions, ?margin, ?verticalOptions, ?anchorX, ?anchorY, ?backgroundColor,
                                         ?behaviors, ?flowDirection, ?height, ?inputTransparent, ?isEnabled, ?isTabStop, ?isVisible, ?minimumHeight,
                                         ?minimumWidth, ?opacity, ?resources, ?rotation, ?rotationX, ?rotationY, ?scale, ?scaleX, ?scaleY, ?styles,
                                         ?styleSheets, ?tabIndex, ?translationX, ?translationY, ?visual, ?width, ?style, ?styleClasses, ?shellBackButtonBehavior,
                                         ?shellBackgroundColor, ?shellDisabledColor, ?shellForegroundColor, ?shellFlyoutBehavior, ?shellNavBarIsVisible,
                                         ?shellSearchHandler, ?shellTabBarBackgroundColor, ?shellTabBarDisabledColor, ?shellTabBarForegroundColor,
                                         ?shellTabBarIsVisible, ?shellTabBarTitleColor, ?shellTabBarUnselectedColor, ?shellTitleColor, ?shellTitleView,
                                         ?shellUnselectedColor, ?automationId, ?classId, ?effects, ?menu, ?ref, ?styleId, ?tag, ?focused, ?unfocused, ?created) =
            
            let attribs = ViewBuilders.BuildView(?gestureRecognizers=gestureRecognizers, ?horizontalOptions=horizontalOptions, ?margin=margin,
                                       ?verticalOptions=verticalOptions, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?behaviors=behaviors,
                                       ?flowDirection=flowDirection, ?height=height, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isTabStop=isTabStop,
                                       ?isVisible=isVisible, ?minimumHeight=minimumHeight, ?minimumWidth=minimumWidth, ?opacity=opacity, ?resources=resources,
                                       ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?scaleX=scaleX, ?scaleY=scaleY, ?styles=styles,
                                       ?styleSheets=styleSheets, ?tabIndex=tabIndex, ?translationX=translationX, ?translationY=translationY, ?visual=visual, ?width=width,
                                       ?style=style, ?styleClasses=styleClasses, ?shellBackButtonBehavior=shellBackButtonBehavior, ?shellBackgroundColor=shellBackgroundColor,
                                       ?shellDisabledColor=shellDisabledColor, ?shellForegroundColor=shellForegroundColor, ?shellFlyoutBehavior=shellFlyoutBehavior,
                                       ?shellNavBarIsVisible=shellNavBarIsVisible, ?shellSearchHandler=shellSearchHandler, ?shellTabBarBackgroundColor=shellTabBarBackgroundColor,
                                       ?shellTabBarDisabledColor=shellTabBarDisabledColor, ?shellTabBarForegroundColor=shellTabBarForegroundColor,
                                       ?shellTabBarIsVisible=shellTabBarIsVisible, ?shellTabBarTitleColor=shellTabBarTitleColor, ?shellTabBarUnselectedColor=shellTabBarUnselectedColor,
                                       ?shellTitleColor=shellTitleColor, ?shellTitleView=shellTitleView, ?shellUnselectedColor=shellUnselectedColor, ?automationId=automationId,
                                       ?classId=classId, ?effects=effects, ?menu=menu, ?ref=ref, ?styleId=styleId, ?tag=tag, ?focused=focused, ?unfocused=unfocused, ?created=created)

            match backgroundGradientStartPoint with None -> () | Some v -> attribs.Add(backgroundGradientStartPointAttribKey, v)
            match backgroundGradientEndPoint with None -> () | Some v -> attribs.Add(backgroundGradientEndPointAttribKey, v)
            match content with None -> () | Some v -> attribs.Add(pancakeContentAttribKey, v)
            match padding with None -> () | Some v -> attribs.Add(paddingAttribKey, v)
            match cornerRadius with None -> () | Some v -> attribs.Add(cornerRadiusKey, v)
            match backgroundGradientStops with None -> () | Some v -> attribs.Add(backgroundGradientStopsAttribKey, v)

            // The creation method
            let create _ _ = Xamarin.Forms.PancakeView.PancakeView()

            // The incremental update method
            let update (definition: ProgramDefinition) (prev: DynamicViewElement voption) (source: DynamicViewElement) (target: Xamarin.Forms.PancakeView.PancakeView) =
                ViewBuilders.UpdateView(definition, prev, source, target)
                source.UpdateElement(definition, prev, target, pancakeContentAttribKey,(fun target -> target.Content), (fun target v -> target.Content <- v))
                source.UpdatePrimitive(definition, prev, target, backgroundGradientStartPointAttribKey, (fun target v -> target.BackgroundGradientStartPoint <- v))
                source.UpdatePrimitive(definition, prev, target, backgroundGradientEndPointAttribKey, (fun target v -> target.BackgroundGradientEndPoint <- v))
                source.UpdatePrimitive(definition, prev, target, backgroundGradientStopsAttribKey, (fun target v -> target.BackgroundGradientStops <- v))
                source.UpdatePrimitive(definition, prev, target, paddingAttribKey, (fun target v -> target.Padding <- v))
                source.UpdatePrimitive(definition, prev, target, cornerRadiusKey, (fun target v -> target.CornerRadius <- v))

            let updateAttachedProperties propertyKey definition prevOpt source targetChild =
                ViewBuilders.UpdateViewAttachedProperties(propertyKey, definition, prevOpt, source, targetChild)
                
            let unmount curr target =
                ViewBuilders.UnmountView(curr, target)

            let handler =
                Registrar.Register(typeof<Xamarin.Forms.PancakeView.PancakeView>.FullName, create, update, updateAttachedProperties, unmount)

            DynamicViewElement.Create(handler, attribs)