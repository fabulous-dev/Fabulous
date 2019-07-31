// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds

open Fabulous

module ViewAttributes =
    let ElementCreatedAttribKey : AttributeKey<_> = AttributeKey<_>("ElementCreated")
    let ElementAutomationIdAttribKey : AttributeKey<_> = AttributeKey<_>("ElementAutomationId")
    let ElementClassIdAttribKey : AttributeKey<_> = AttributeKey<_>("ElementClassId")
    let ElementStyleIdAttribKey : AttributeKey<_> = AttributeKey<_>("ElementStyleId")
    let ElementRefAttribKey : AttributeKey<_> = AttributeKey<_>("ElementRef")
    let ElementTagAttribKey : AttributeKey<_> = AttributeKey<_>("ElementTag")
    let NavigableElementStyleAttribKey : AttributeKey<_> = AttributeKey<_>("NavigableElementStyle")
    let NavigableElementStyleClassAttribKey : AttributeKey<_> = AttributeKey<_>("NavigableElementStyleClass")
    let VisualElementFocusedAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementFocused")
    let VisualElementUnfocusedAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementUnfocused")
    let VisualElementAnchorXAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementAnchorX")
    let VisualElementTranslationYAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementTranslationY")
    let VisualElementTranslationXAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementTranslationX")
    let VisualElementTabIndexAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementTabIndex")
    let VisualElementScaleYAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementScaleY")
    let VisualElementScaleXAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementScaleX")
    let VisualElementScaleAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementScale")
    let VisualElementRotationYAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementRotationY")
    let VisualElementRotationXAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementRotationX")
    let VisualElementRotationAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementRotation")
    let VisualElementVisualAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementVisual")
    let VisualElementOpacityAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementOpacity")
    let VisualElementMinimumHeightAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementMinimumHeight")
    let VisualElementIsVisibleAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementIsVisible")
    let VisualElementIsTabStopAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementIsTabStop")
    let VisualElementIsEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementIsEnabled")
    let VisualElementInputTransparentAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementInputTransparent")
    let VisualElementHeightAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementHeight")
    let VisualElementFlowDirectionAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementFlowDirection")
    let VisualElementBackgroundColorAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementBackgroundColor")
    let VisualElementAnchorYAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementAnchorY")
    let VisualElementMinimumWidthAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementMinimumWidth")
    let VisualElementWidthAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementWidth")
    let ViewHorizontalOptionsAttribKey : AttributeKey<_> = AttributeKey<_>("ViewHorizontalOptions")
    let ViewVerticalOptionsAttribKey : AttributeKey<_> = AttributeKey<_>("ViewVerticalOptions")
    let ViewMarginAttribKey : AttributeKey<_> = AttributeKey<_>("ViewMargin")
    let ViewGestureRecognizersAttribKey : AttributeKey<_> = AttributeKey<_>("ViewGestureRecognizers")
    let GestureElementGestureRecognizersAttribKey : AttributeKey<_> = AttributeKey<_>("GestureElementGestureRecognizers")
    let PanGestureRecognizerPanUpdatedAttribKey : AttributeKey<_> = AttributeKey<_>("PanGestureRecognizerPanUpdated")
    let PanGestureRecognizerTouchPointsAttribKey : AttributeKey<_> = AttributeKey<_>("PanGestureRecognizerTouchPoints")
    let ClickGestureRecognizerCommandAttribKey : AttributeKey<_> = AttributeKey<_>("ClickGestureRecognizerCommand")
    let ClickGestureRecognizerNumberOfClicksRequiredAttribKey : AttributeKey<_> = AttributeKey<_>("ClickGestureRecognizerNumberOfClicksRequired")
    let ClickGestureRecognizerButtonsAttribKey : AttributeKey<_> = AttributeKey<_>("ClickGestureRecognizerButtons")
    let PinchGestureRecognizerPinchUpdatedAttribKey : AttributeKey<_> = AttributeKey<_>("PinchGestureRecognizerPinchUpdated")
    let SwipeGestureRecognizerSwipedAttribKey : AttributeKey<_> = AttributeKey<_>("SwipeGestureRecognizerSwiped")
    let SwipeGestureRecognizerCommandAttribKey : AttributeKey<_> = AttributeKey<_>("SwipeGestureRecognizerCommand")
    let SwipeGestureRecognizerDirectionAttribKey : AttributeKey<_> = AttributeKey<_>("SwipeGestureRecognizerDirection")
    let SwipeGestureRecognizerThresholdAttribKey : AttributeKey<_> = AttributeKey<_>("SwipeGestureRecognizerThreshold")
    let ActivityIndicatorColorAttribKey : AttributeKey<_> = AttributeKey<_>("ActivityIndicatorColor")
    let ActivityIndicatorIsRunningAttribKey : AttributeKey<_> = AttributeKey<_>("ActivityIndicatorIsRunning")
    let BoxViewColorAttribKey : AttributeKey<_> = AttributeKey<_>("BoxViewColor")
    let BoxViewCornerRadiusAttribKey : AttributeKey<_> = AttributeKey<_>("BoxViewCornerRadius")
    let ProgressBarProgressAttribKey : AttributeKey<_> = AttributeKey<_>("ProgressBarProgress")
    let LayoutIsClippedToBoundsAttribKey : AttributeKey<_> = AttributeKey<_>("LayoutIsClippedToBounds")
    let LayoutPaddingAttribKey : AttributeKey<_> = AttributeKey<_>("LayoutPadding")
    let ScrollViewScrolledAttribKey : AttributeKey<_> = AttributeKey<_>("ScrollViewScrolled")
    let ScrollViewContentAttribKey : AttributeKey<_> = AttributeKey<_>("ScrollViewContent")
    let ScrollViewOrientationAttribKey : AttributeKey<_> = AttributeKey<_>("ScrollViewOrientation")
    let ScrollViewHorizontalScrollBarVisibilityAttribKey : AttributeKey<_> = AttributeKey<_>("ScrollViewHorizontalScrollBarVisibility")
    let ScrollViewVerticalScrollBarVisibilityAttribKey : AttributeKey<_> = AttributeKey<_>("ScrollViewVerticalScrollBarVisibility")
    let ScrollViewScrollToAttribKey : AttributeKey<_> = AttributeKey<_>("ScrollViewScrollTo")
    let ButtonTextAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonText")
    let ButtonCommandAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonCommand")
    let ButtonBorderColorAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonBorderColor")
    let ButtonBorderWidthAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonBorderWidth")
    let ButtonContentLayoutAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonContentLayout")
    let ButtonCornerRadiusAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonCornerRadius")
    let ButtonFontFamilyAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonFontFamily")
    let ButtonFontAttributesAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonFontAttributes")
    let ButtonFontSizeAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonFontSize")
    let ButtonImageAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonImage")
    let ButtonTextColorAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonTextColor")
    let ButtonPaddingAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonPadding")

type ViewProto() =
    static member val ProtoElement : ViewElement option = None with get, set
    static member val ProtoNavigableElement : ViewElement option = None with get, set
    static member val ProtoVisualElement : ViewElement option = None with get, set
    static member val ProtoView : ViewElement option = None with get, set
    static member val ProtoGestureElement : ViewElement option = None with get, set
    static member val ProtoPanGestureRecognizer : ViewElement option = None with get, set
    static member val ProtoClickGestureRecognizer : ViewElement option = None with get, set
    static member val ProtoPinchGestureRecognizer : ViewElement option = None with get, set
    static member val ProtoSwipeGestureRecognizer : ViewElement option = None with get, set
    static member val ProtoActivityIndicator : ViewElement option = None with get, set
    static member val ProtoBoxView : ViewElement option = None with get, set
    static member val ProtoProgressBar : ViewElement option = None with get, set
    static member val ProtoLayout : ViewElement option = None with get, set
    static member val ProtoScrollView : ViewElement option = None with get, set
    static member val ProtoButton : ViewElement option = None with get, set

type ViewBuilders() =
    /// Builds the attributes for a Element in the view
    static member inline BuildElement(attribCount: int,
                                      ?created: unit -> unit,
                                      ?automationId: string,
                                      ?classId: string,
                                      ?styleId: string,
                                      ?ref: ViewRef,
                                      ?tag: obj) = 

        let attribCount = match created with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match automationId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match classId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match ref with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match tag with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = new AttributesBuilder(attribCount)
        match created with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementCreatedAttribKey, (v)) 
        match automationId with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementAutomationIdAttribKey, (v)) 
        match classId with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementClassIdAttribKey, (v)) 
        match styleId with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementStyleIdAttribKey, (v)) 
        match ref with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementRefAttribKey, (v)) 
        match tag with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementTagAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a NavigableElement in the view
    static member inline BuildNavigableElement(attribCount: int,
                                               ?created: unit -> unit,
                                               ?style: Xamarin.Forms.Style,
                                               ?styleClass: InputTypes.StyleClass,
                                               ?automationId: string,
                                               ?classId: string,
                                               ?styleId: string,
                                               ?ref: ViewRef,
                                               ?tag: obj) = 

        let attribCount = match style with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleClass with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.Element(attribCount, ?created=created, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?ref=ref, ?tag=tag)
        match style with None -> () | Some v -> attribBuilder.Add(ViewAttributes.NavigableElementStyleAttribKey, (v)) 
        match styleClass with None -> () | Some v -> attribBuilder.Add(ViewAttributes.NavigableElementStyleClassAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a VisualElement in the view
    static member inline BuildVisualElement(attribCount: int,
                                            ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                            ?styleId: string,
                                            ?classId: string,
                                            ?automationId: string,
                                            ?styleClass: InputTypes.StyleClass,
                                            ?style: Xamarin.Forms.Style,
                                            ?width: float,
                                            ?minimumWidth: float,
                                            ?anchorY: float,
                                            ?backgroundColor: Xamarin.Forms.Color,
                                            ?flowDirection: Xamarin.Forms.FlowDirection,
                                            ?height: float,
                                            ?inputTransparent: bool,
                                            ?isEnabled: bool,
                                            ?isTabStop: bool,
                                            ?ref: ViewRef,
                                            ?isVisible: bool,
                                            ?opacity: float,
                                            ?visual: Xamarin.Forms.IVisual,
                                            ?rotation: float,
                                            ?rotationX: float,
                                            ?rotationY: float,
                                            ?scale: float,
                                            ?scaleX: float,
                                            ?scaleY: float,
                                            ?tabIndex: int,
                                            ?translationX: float,
                                            ?translationY: float,
                                            ?anchorX: float,
                                            ?created: unit -> unit,
                                            ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                            ?minimumHeight: float,
                                            ?tag: obj) = 

        let attribCount = match focused with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match width with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match minimumWidth with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match anchorY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match backgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match flowDirection with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match height with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match inputTransparent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isTabStop with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isVisible with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match opacity with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match visual with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rotation with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rotationX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rotationY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scale with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scaleX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scaleY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match tabIndex with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match translationX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match translationY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match anchorX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match unfocused with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match minimumHeight with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.NavigableElement(attribCount, ?styleId=styleId, ?classId=classId, ?automationId=automationId, ?styleClass=styleClass, ?style=style, ?ref=ref, ?created=created, ?tag=tag)
        match focused with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementFocusedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.FocusEventArgs>(fun _sender _args -> f args))(v)) 
        match width with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementWidthAttribKey, (v)) 
        match minimumWidth with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementMinimumWidthAttribKey, (v)) 
        match anchorY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementAnchorYAttribKey, (v)) 
        match backgroundColor with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementBackgroundColorAttribKey, (v)) 
        match flowDirection with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementFlowDirectionAttribKey, (v)) 
        match height with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementHeightAttribKey, (v)) 
        match inputTransparent with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementInputTransparentAttribKey, (v)) 
        match isEnabled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementIsEnabledAttribKey, (v)) 
        match isTabStop with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementIsTabStopAttribKey, (v)) 
        match isVisible with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementIsVisibleAttribKey, (v)) 
        match opacity with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementOpacityAttribKey, (v)) 
        match visual with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementVisualAttribKey, (v)) 
        match rotation with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementRotationAttribKey, (v)) 
        match rotationX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementRotationXAttribKey, (v)) 
        match rotationY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementRotationYAttribKey, (v)) 
        match scale with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementScaleAttribKey, (v)) 
        match scaleX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementScaleXAttribKey, (v)) 
        match scaleY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementScaleYAttribKey, (v)) 
        match tabIndex with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementTabIndexAttribKey, (v)) 
        match translationX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementTranslationXAttribKey, (v)) 
        match translationY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementTranslationYAttribKey, (v)) 
        match anchorX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementAnchorXAttribKey, (v)) 
        match unfocused with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementUnfocusedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.FocusEventArgs>(fun _sender _args -> f args))(v)) 
        match minimumHeight with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementMinimumHeightAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a View in the view
    static member inline BuildView(attribCount: int,
                                   ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                   ?isVisible: bool,
                                   ?isTabStop: bool,
                                   ?isEnabled: bool,
                                   ?inputTransparent: bool,
                                   ?height: float,
                                   ?flowDirection: Xamarin.Forms.FlowDirection,
                                   ?backgroundColor: Xamarin.Forms.Color,
                                   ?anchorY: float,
                                   ?minimumWidth: float,
                                   ?width: float,
                                   ?style: Xamarin.Forms.Style,
                                   ?styleClass: InputTypes.StyleClass,
                                   ?automationId: string,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?minimumHeight: float,
                                   ?ref: ViewRef,
                                   ?opacity: float,
                                   ?rotation: float,
                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                   ?created: unit -> unit,
                                   ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                   ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                   ?margin: InputTypes.Thickness,
                                   ?gestureRecognizers: ViewElement list,
                                   ?anchorX: float,
                                   ?translationY: float,
                                   ?translationX: float,
                                   ?tabIndex: int,
                                   ?scaleY: float,
                                   ?scaleX: float,
                                   ?scale: float,
                                   ?rotationY: float,
                                   ?rotationX: float,
                                   ?visual: Xamarin.Forms.IVisual,
                                   ?tag: obj) = 

        let attribCount = match horizontalOptions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match verticalOptions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match margin with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match gestureRecognizers with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.VisualElement(attribCount, ?focused=focused, ?isVisible=isVisible, ?isTabStop=isTabStop, ?isEnabled=isEnabled, ?inputTransparent=inputTransparent, ?height=height, ?flowDirection=flowDirection, ?backgroundColor=backgroundColor, ?anchorY=anchorY, ?minimumWidth=minimumWidth, ?width=width, ?style=style, ?styleClass=styleClass, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?minimumHeight=minimumHeight, ?ref=ref, ?opacity=opacity, ?rotation=rotation, ?unfocused=unfocused, ?created=created, ?anchorX=anchorX, ?translationY=translationY, ?translationX=translationX, ?tabIndex=tabIndex, ?scaleY=scaleY, ?scaleX=scaleX, ?scale=scale, ?rotationY=rotationY, ?rotationX=rotationX, ?visual=visual, ?tag=tag)
        match horizontalOptions with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ViewHorizontalOptionsAttribKey, (v)) 
        match verticalOptions with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ViewVerticalOptionsAttribKey, (v)) 
        match margin with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ViewMarginAttribKey, (v)) 
        match gestureRecognizers with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ViewGestureRecognizersAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a GestureElement in the view
    static member inline BuildGestureElement(attribCount: int,
                                             ?created: unit -> unit,
                                             ?gestureRecognizers: ViewElement list,
                                             ?automationId: string,
                                             ?classId: string,
                                             ?styleId: string,
                                             ?ref: ViewRef,
                                             ?tag: obj) = 

        let attribCount = match gestureRecognizers with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.Element(attribCount, ?created=created, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?ref=ref, ?tag=tag)
        match gestureRecognizers with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GestureElementGestureRecognizersAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a PanGestureRecognizer in the view
    static member inline BuildPanGestureRecognizer(attribCount: int,
                                                   ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit,
                                                   ?created: unit -> unit,
                                                   ?touchPoints: int,
                                                   ?automationId: string,
                                                   ?classId: string,
                                                   ?styleId: string,
                                                   ?ref: ViewRef,
                                                   ?tag: obj) = 

        let attribCount = match panUpdated with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match touchPoints with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.GestureRecognizer(attribCount, ?created=created, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?ref=ref, ?tag=tag)
        match panUpdated with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PanGestureRecognizerPanUpdatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender _args -> f args))(v)) 
        match touchPoints with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PanGestureRecognizerTouchPointsAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a ClickGestureRecognizer in the view
    static member inline BuildClickGestureRecognizer(attribCount: int,
                                                     ?created: unit -> unit,
                                                     ?command: unit -> unit,
                                                     ?numberOfClicksRequired: int,
                                                     ?buttons: Xamarin.Forms.ButtonsMask,
                                                     ?automationId: string,
                                                     ?classId: string,
                                                     ?styleId: string,
                                                     ?ref: ViewRef,
                                                     ?tag: obj) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match numberOfClicksRequired with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match buttons with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.GestureRecognizer(attribCount, ?created=created, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?ref=ref, ?tag=tag)
        match command with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ClickGestureRecognizerCommandAttribKey, (v)) 
        match numberOfClicksRequired with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ClickGestureRecognizerNumberOfClicksRequiredAttribKey, (v)) 
        match buttons with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ClickGestureRecognizerButtonsAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a PinchGestureRecognizer in the view
    static member inline BuildPinchGestureRecognizer(attribCount: int,
                                                     ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit,
                                                     ?created: unit -> unit,
                                                     ?automationId: string,
                                                     ?classId: string,
                                                     ?styleId: string,
                                                     ?ref: ViewRef,
                                                     ?tag: obj) = 

        let attribCount = match pinchUpdated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.GestureRecognizer(attribCount, ?created=created, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?ref=ref, ?tag=tag)
        match pinchUpdated with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PinchGestureRecognizerPinchUpdatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender _args -> f args))(v)) 
        attribBuilder

    /// Builds the attributes for a SwipeGestureRecognizer in the view
    static member inline BuildSwipeGestureRecognizer(attribCount: int,
                                                     ?swiped: Xamarin.Forms.SwipedEventArgs -> unit,
                                                     ?created: unit -> unit,
                                                     ?command: unit -> unit,
                                                     ?direction: Xamarin.Forms.SwipeDirection,
                                                     ?threshold: uint32,
                                                     ?automationId: string,
                                                     ?classId: string,
                                                     ?styleId: string,
                                                     ?ref: ViewRef,
                                                     ?tag: obj) = 

        let attribCount = match swiped with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match direction with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match threshold with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.GestureRecognizer(attribCount, ?created=created, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?ref=ref, ?tag=tag)
        match swiped with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerSwipedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SwipedEventArgs>(fun _sender _args -> f args))(v)) 
        match command with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerCommandAttribKey, (v)) 
        match direction with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerDirectionAttribKey, (v)) 
        match threshold with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerThresholdAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a ActivityIndicator in the view
    static member inline BuildActivityIndicator(attribCount: int,
                                                ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                                ?minimumHeight: float,
                                                ?isVisible: bool,
                                                ?isTabStop: bool,
                                                ?isEnabled: bool,
                                                ?inputTransparent: bool,
                                                ?height: float,
                                                ?flowDirection: Xamarin.Forms.FlowDirection,
                                                ?opacity: float,
                                                ?backgroundColor: Xamarin.Forms.Color,
                                                ?minimumWidth: float,
                                                ?width: float,
                                                ?style: Xamarin.Forms.Style,
                                                ?styleClass: InputTypes.StyleClass,
                                                ?automationId: string,
                                                ?classId: string,
                                                ?styleId: string,
                                                ?anchorY: float,
                                                ?ref: ViewRef,
                                                ?visual: Xamarin.Forms.IVisual,
                                                ?rotationX: float,
                                                ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                                ?created: unit -> unit,
                                                ?color: Xamarin.Forms.Color,
                                                ?isRunning: bool,
                                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                                ?margin: InputTypes.Thickness,
                                                ?rotation: float,
                                                ?gestureRecognizers: ViewElement list,
                                                ?translationY: float,
                                                ?translationX: float,
                                                ?tabIndex: int,
                                                ?scaleY: float,
                                                ?scaleX: float,
                                                ?scale: float,
                                                ?rotationY: float,
                                                ?anchorX: float,
                                                ?tag: obj) = 

        let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isRunning with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.View(attribCount, ?focused=focused, ?minimumHeight=minimumHeight, ?isVisible=isVisible, ?isTabStop=isTabStop, ?isEnabled=isEnabled, ?inputTransparent=inputTransparent, ?height=height, ?flowDirection=flowDirection, ?opacity=opacity, ?backgroundColor=backgroundColor, ?minimumWidth=minimumWidth, ?width=width, ?style=style, ?styleClass=styleClass, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?anchorY=anchorY, ?ref=ref, ?visual=visual, ?rotationX=rotationX, ?unfocused=unfocused, ?created=created, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?rotation=rotation, ?gestureRecognizers=gestureRecognizers, ?translationY=translationY, ?translationX=translationX, ?tabIndex=tabIndex, ?scaleY=scaleY, ?scaleX=scaleX, ?scale=scale, ?rotationY=rotationY, ?anchorX=anchorX, ?tag=tag)
        match color with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ActivityIndicatorColorAttribKey, (v)) 
        match isRunning with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ActivityIndicatorIsRunningAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a BoxView in the view
    static member inline BuildBoxView(attribCount: int,
                                      ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                      ?minimumHeight: float,
                                      ?isVisible: bool,
                                      ?isTabStop: bool,
                                      ?isEnabled: bool,
                                      ?inputTransparent: bool,
                                      ?height: float,
                                      ?flowDirection: Xamarin.Forms.FlowDirection,
                                      ?opacity: float,
                                      ?backgroundColor: Xamarin.Forms.Color,
                                      ?minimumWidth: float,
                                      ?width: float,
                                      ?style: Xamarin.Forms.Style,
                                      ?styleClass: InputTypes.StyleClass,
                                      ?automationId: string,
                                      ?classId: string,
                                      ?styleId: string,
                                      ?anchorY: float,
                                      ?ref: ViewRef,
                                      ?visual: Xamarin.Forms.IVisual,
                                      ?rotationX: float,
                                      ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                      ?created: unit -> unit,
                                      ?color: Xamarin.Forms.Color,
                                      ?cornerRadius: Xamarin.Forms.CornerRadius,
                                      ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                      ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                      ?margin: InputTypes.Thickness,
                                      ?rotation: float,
                                      ?gestureRecognizers: ViewElement list,
                                      ?translationY: float,
                                      ?translationX: float,
                                      ?tabIndex: int,
                                      ?scaleY: float,
                                      ?scaleX: float,
                                      ?scale: float,
                                      ?rotationY: float,
                                      ?anchorX: float,
                                      ?tag: obj) = 

        let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.View(attribCount, ?focused=focused, ?minimumHeight=minimumHeight, ?isVisible=isVisible, ?isTabStop=isTabStop, ?isEnabled=isEnabled, ?inputTransparent=inputTransparent, ?height=height, ?flowDirection=flowDirection, ?opacity=opacity, ?backgroundColor=backgroundColor, ?minimumWidth=minimumWidth, ?width=width, ?style=style, ?styleClass=styleClass, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?anchorY=anchorY, ?ref=ref, ?visual=visual, ?rotationX=rotationX, ?unfocused=unfocused, ?created=created, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?rotation=rotation, ?gestureRecognizers=gestureRecognizers, ?translationY=translationY, ?translationX=translationX, ?tabIndex=tabIndex, ?scaleY=scaleY, ?scaleX=scaleX, ?scale=scale, ?rotationY=rotationY, ?anchorX=anchorX, ?tag=tag)
        match color with None -> () | Some v -> attribBuilder.Add(ViewAttributes.BoxViewColorAttribKey, (v)) 
        match cornerRadius with None -> () | Some v -> attribBuilder.Add(ViewAttributes.BoxViewCornerRadiusAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a ProgressBar in the view
    static member inline BuildProgressBar(attribCount: int,
                                          ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                          ?isVisible: bool,
                                          ?isTabStop: bool,
                                          ?isEnabled: bool,
                                          ?inputTransparent: bool,
                                          ?height: float,
                                          ?flowDirection: Xamarin.Forms.FlowDirection,
                                          ?backgroundColor: Xamarin.Forms.Color,
                                          ?anchorY: float,
                                          ?minimumWidth: float,
                                          ?width: float,
                                          ?style: Xamarin.Forms.Style,
                                          ?styleClass: InputTypes.StyleClass,
                                          ?automationId: string,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?minimumHeight: float,
                                          ?opacity: float,
                                          ?visual: Xamarin.Forms.IVisual,
                                          ?rotation: float,
                                          ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                          ?created: unit -> unit,
                                          ?progress: float,
                                          ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                          ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                          ?margin: InputTypes.Thickness,
                                          ?gestureRecognizers: ViewElement list,
                                          ?ref: ViewRef,
                                          ?anchorX: float,
                                          ?translationX: float,
                                          ?tabIndex: int,
                                          ?scaleY: float,
                                          ?scaleX: float,
                                          ?scale: float,
                                          ?rotationY: float,
                                          ?rotationX: float,
                                          ?translationY: float,
                                          ?tag: obj) = 

        let attribCount = match progress with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.View(attribCount, ?focused=focused, ?isVisible=isVisible, ?isTabStop=isTabStop, ?isEnabled=isEnabled, ?inputTransparent=inputTransparent, ?height=height, ?flowDirection=flowDirection, ?backgroundColor=backgroundColor, ?anchorY=anchorY, ?minimumWidth=minimumWidth, ?width=width, ?style=style, ?styleClass=styleClass, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?minimumHeight=minimumHeight, ?opacity=opacity, ?visual=visual, ?rotation=rotation, ?unfocused=unfocused, ?created=created, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?ref=ref, ?anchorX=anchorX, ?translationX=translationX, ?tabIndex=tabIndex, ?scaleY=scaleY, ?scaleX=scaleX, ?scale=scale, ?rotationY=rotationY, ?rotationX=rotationX, ?translationY=translationY, ?tag=tag)
        match progress with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ProgressBarProgressAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a Layout in the view
    static member inline BuildLayout(attribCount: int,
                                     ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?minimumHeight: float,
                                     ?isVisible: bool,
                                     ?isTabStop: bool,
                                     ?isEnabled: bool,
                                     ?inputTransparent: bool,
                                     ?height: float,
                                     ?flowDirection: Xamarin.Forms.FlowDirection,
                                     ?opacity: float,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?minimumWidth: float,
                                     ?width: float,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: InputTypes.StyleClass,
                                     ?automationId: string,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?anchorY: float,
                                     ?ref: ViewRef,
                                     ?visual: Xamarin.Forms.IVisual,
                                     ?rotationX: float,
                                     ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?created: unit -> unit,
                                     ?isClippedToBounds: bool,
                                     ?padding: Xamarin.Forms.Thickness,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: InputTypes.Thickness,
                                     ?rotation: float,
                                     ?gestureRecognizers: ViewElement list,
                                     ?translationY: float,
                                     ?translationX: float,
                                     ?tabIndex: int,
                                     ?scaleY: float,
                                     ?scaleX: float,
                                     ?scale: float,
                                     ?rotationY: float,
                                     ?anchorX: float,
                                     ?tag: obj) = 

        let attribCount = match isClippedToBounds with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.View(attribCount, ?focused=focused, ?minimumHeight=minimumHeight, ?isVisible=isVisible, ?isTabStop=isTabStop, ?isEnabled=isEnabled, ?inputTransparent=inputTransparent, ?height=height, ?flowDirection=flowDirection, ?opacity=opacity, ?backgroundColor=backgroundColor, ?minimumWidth=minimumWidth, ?width=width, ?style=style, ?styleClass=styleClass, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?anchorY=anchorY, ?ref=ref, ?visual=visual, ?rotationX=rotationX, ?unfocused=unfocused, ?created=created, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?rotation=rotation, ?gestureRecognizers=gestureRecognizers, ?translationY=translationY, ?translationX=translationX, ?tabIndex=tabIndex, ?scaleY=scaleY, ?scaleX=scaleX, ?scale=scale, ?rotationY=rotationY, ?anchorX=anchorX, ?tag=tag)
        match isClippedToBounds with None -> () | Some v -> attribBuilder.Add(ViewAttributes.LayoutIsClippedToBoundsAttribKey, (v)) 
        match padding with None -> () | Some v -> attribBuilder.Add(ViewAttributes.LayoutPaddingAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a ScrollView in the view
    static member inline BuildScrollView(attribCount: int,
                                         ?scrolled: Xamarin.Forms.ScrolledEventArgs -> unit,
                                         ?rotation: float,
                                         ?visual: Xamarin.Forms.IVisual,
                                         ?opacity: float,
                                         ?minimumHeight: float,
                                         ?isVisible: bool,
                                         ?isTabStop: bool,
                                         ?isEnabled: bool,
                                         ?inputTransparent: bool,
                                         ?height: float,
                                         ?flowDirection: Xamarin.Forms.FlowDirection,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?anchorY: float,
                                         ?minimumWidth: float,
                                         ?width: float,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: InputTypes.StyleClass,
                                         ?automationId: string,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?rotationX: float,
                                         ?ref: ViewRef,
                                         ?rotationY: float,
                                         ?scaleX: float,
                                         ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?created: unit -> unit,
                                         ?content: ViewElement,
                                         ?orientation: Xamarin.Forms.ScrollOrientation,
                                         ?horizontalScrollBarVisibility: Xamarin.Forms.ScrollBarVisibility,
                                         ?verticalScrollBarVisibility: Xamarin.Forms.ScrollBarVisibility,
                                         ?scrollTo: double * double * InputTypes.AnimationKind,
                                         ?isClippedToBounds: bool,
                                         ?padding: Xamarin.Forms.Thickness,
                                         ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                         ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                         ?margin: InputTypes.Thickness,
                                         ?gestureRecognizers: ViewElement list,
                                         ?anchorX: float,
                                         ?translationY: float,
                                         ?translationX: float,
                                         ?tabIndex: int,
                                         ?scaleY: float,
                                         ?scale: float,
                                         ?tag: obj) = 

        let attribCount = match scrolled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match orientation with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match horizontalScrollBarVisibility with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match verticalScrollBarVisibility with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scrollTo with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.Layout(attribCount, ?rotation=rotation, ?visual=visual, ?opacity=opacity, ?minimumHeight=minimumHeight, ?isVisible=isVisible, ?isTabStop=isTabStop, ?isEnabled=isEnabled, ?inputTransparent=inputTransparent, ?height=height, ?flowDirection=flowDirection, ?backgroundColor=backgroundColor, ?anchorY=anchorY, ?minimumWidth=minimumWidth, ?width=width, ?style=style, ?styleClass=styleClass, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?rotationX=rotationX, ?ref=ref, ?rotationY=rotationY, ?scaleX=scaleX, ?focused=focused, ?unfocused=unfocused, ?created=created, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?translationY=translationY, ?translationX=translationX, ?tabIndex=tabIndex, ?scaleY=scaleY, ?scale=scale, ?tag=tag)
        match scrolled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewScrolledAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ScrolledEventArgs>(fun _sender _args -> f args))(v)) 
        match content with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewContentAttribKey, (v)) 
        match orientation with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewOrientationAttribKey, (v)) 
        match horizontalScrollBarVisibility with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewHorizontalScrollBarVisibilityAttribKey, (v)) 
        match verticalScrollBarVisibility with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewVerticalScrollBarVisibilityAttribKey, (v)) 
        match scrollTo with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewScrollToAttribKey, (v)) 
        attribBuilder

    /// Builds the attributes for a Button in the view
    static member inline BuildButton(attribCount: int,
                                     ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?rotationY: float,
                                     ?rotationX: float,
                                     ?rotation: float,
                                     ?visual: Xamarin.Forms.IVisual,
                                     ?opacity: float,
                                     ?minimumHeight: float,
                                     ?isVisible: bool,
                                     ?isTabStop: bool,
                                     ?isEnabled: bool,
                                     ?inputTransparent: bool,
                                     ?height: float,
                                     ?flowDirection: Xamarin.Forms.FlowDirection,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?anchorY: float,
                                     ?minimumWidth: float,
                                     ?width: float,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: InputTypes.StyleClass,
                                     ?automationId: string,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?scale: float,
                                     ?ref: ViewRef,
                                     ?scaleX: float,
                                     ?tabIndex: int,
                                     ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?created: unit -> unit,
                                     ?text: string,
                                     ?command: unit -> unit,
                                     ?borderColor: Xamarin.Forms.Color,
                                     ?borderWidth: float,
                                     ?contentLayout: Xamarin.Forms.Button.ButtonContentLayout,
                                     ?cornerRadius: int,
                                     ?fontFamily: string,
                                     ?fontAttributes: Xamarin.Forms.FontAttributes,
                                     ?fontSize: float,
                                     ?image: InputTypes.Image,
                                     ?textColor: Xamarin.Forms.Color,
                                     ?padding: Xamarin.Forms.Thickness,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: InputTypes.Thickness,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: float,
                                     ?translationY: float,
                                     ?translationX: float,
                                     ?scaleY: float,
                                     ?tag: obj) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match borderColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match borderWidth with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match contentLayout with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontAttributes with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match image with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildXamarin.Forms.View(attribCount, ?focused=focused, ?rotationY=rotationY, ?rotationX=rotationX, ?rotation=rotation, ?visual=visual, ?opacity=opacity, ?minimumHeight=minimumHeight, ?isVisible=isVisible, ?isTabStop=isTabStop, ?isEnabled=isEnabled, ?inputTransparent=inputTransparent, ?height=height, ?flowDirection=flowDirection, ?backgroundColor=backgroundColor, ?anchorY=anchorY, ?minimumWidth=minimumWidth, ?width=width, ?style=style, ?styleClass=styleClass, ?automationId=automationId, ?classId=classId, ?styleId=styleId, ?scale=scale, ?ref=ref, ?scaleX=scaleX, ?tabIndex=tabIndex, ?unfocused=unfocused, ?created=created, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?translationY=translationY, ?translationX=translationX, ?scaleY=scaleY, ?tag=tag)
        match text with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonTextAttribKey, (v)) 
        match command with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonCommandAttribKey, (v)) 
        match borderColor with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonBorderColorAttribKey, (v)) 
        match borderWidth with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonBorderWidthAttribKey, (v)) 
        match contentLayout with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonContentLayoutAttribKey, (v)) 
        match cornerRadius with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonCornerRadiusAttribKey, (v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonFontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonFontAttributesAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonFontSizeAttribKey, (v)) 
        match image with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonImageAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonTextColorAttribKey, (v)) 
        match padding with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ButtonPaddingAttribKey, (v)) 
        attribBuilder

