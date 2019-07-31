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
    let VisualElementAnchorYAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementAnchorY")
    let VisualElementBackgroundColorAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementBackgroundColor")
    let VisualElementFlowDirectionAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementFlowDirection")
    let VisualElementHeightAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementHeight")
    let VisualElementInputTransparentAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementInputTransparent")
    let VisualElementIsEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementIsEnabled")
    let VisualElementIsTabStopAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementIsTabStop")
    let VisualElementIsVisibleAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementIsVisible")
    let VisualElementMinimumHeightAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementMinimumHeight")
    let VisualElementMinimumWidthAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementMinimumWidth")
    let VisualElementOpacityAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementOpacity")
    let VisualElementRotationAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementRotation")
    let VisualElementRotationXAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementRotationX")
    let VisualElementRotationYAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementRotationY")
    let VisualElementScaleAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementScale")
    let VisualElementScaleXAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementScaleX")
    let VisualElementScaleYAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementScaleY")
    let VisualElementTabIndexAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementTabIndex")
    let VisualElementTranslationXAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementTranslationX")
    let VisualElementTranslationYAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementTranslationY")
    let VisualElementVisualAttribKey : AttributeKey<_> = AttributeKey<_>("VisualElementVisual")
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
    let SliderValueChangedAttribKey : AttributeKey<_> = AttributeKey<_>("SliderValueChanged")
    let SliderDragCompletedAttribKey : AttributeKey<_> = AttributeKey<_>("SliderDragCompleted")
    let SliderDragStartedAttribKey : AttributeKey<_> = AttributeKey<_>("SliderDragStarted")
    let SliderMinimumMaximumAttribKey : AttributeKey<_> = AttributeKey<_>("SliderMinimumMaximum")
    let SliderValueAttribKey : AttributeKey<_> = AttributeKey<_>("SliderValue")
    let SliderThumbImageSourceAttribKey : AttributeKey<_> = AttributeKey<_>("SliderThumbImageSource")

type ViewBuilders() =
    /// Builds the attributes for a Element in the view
    static member inline BuildElement(attribCount: int,
                                      ?automationId: string,
                                      ?classId: string,
                                      ?styleId: string,
                                      ?ref: ViewRef,
                                      ?tag: obj,
                                      ?created: obj -> unit) = 

        let attribCount = match automationId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match classId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match ref with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match tag with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match created with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = new AttributesBuilder(attribCount)
        match automationId with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementAutomationIdAttribKey, (v)) 
        match classId with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementClassIdAttribKey, (v)) 
        match styleId with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementStyleIdAttribKey, (v)) 
        match ref with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementRefAttribKey, (v)) 
        match tag with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementTagAttribKey, (v)) 
        match created with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ElementCreatedAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncElement : (unit -> Xamarin.Forms.Element) = (fun () -> ViewBuilders.CreateElement()) with get, set

    static member CreateElement () : Xamarin.Forms.Element =
        new Xamarin.Forms.Element()

    static member val UpdateFuncElement =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Element) -> ViewBuilders.UpdateElement (prevOpt, curr, target)) 

    static member UpdateElement (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Element) = 
        let mutable prevElementCreatedOpt = ValueNone
        let mutable currElementCreatedOpt = ValueNone
        let mutable prevElementAutomationIdOpt = ValueNone
        let mutable currElementAutomationIdOpt = ValueNone
        let mutable prevElementClassIdOpt = ValueNone
        let mutable currElementClassIdOpt = ValueNone
        let mutable prevElementStyleIdOpt = ValueNone
        let mutable currElementStyleIdOpt = ValueNone
        let mutable prevElementRefOpt = ValueNone
        let mutable currElementRefOpt = ValueNone
        let mutable prevElementTagOpt = ValueNone
        let mutable currElementTagOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.ElementCreatedAttribKey.KeyValue then 
                currElementCreatedOpt <- ValueSome (kvp.Value :?> obj -> unit)
            if kvp.Key = ViewAttributes.ElementAutomationIdAttribKey.KeyValue then 
                currElementAutomationIdOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = ViewAttributes.ElementClassIdAttribKey.KeyValue then 
                currElementClassIdOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = ViewAttributes.ElementStyleIdAttribKey.KeyValue then 
                currElementStyleIdOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = ViewAttributes.ElementRefAttribKey.KeyValue then 
                currElementRefOpt <- ValueSome (kvp.Value :?> ViewRef)
            if kvp.Key = ViewAttributes.ElementTagAttribKey.KeyValue then 
                currElementTagOpt <- ValueSome (kvp.Value :?> obj)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.ElementCreatedAttribKey.KeyValue then 
                    prevElementCreatedOpt <- ValueSome (kvp.Value :?> obj -> unit)
                if kvp.Key = ViewAttributes.ElementAutomationIdAttribKey.KeyValue then 
                    prevElementAutomationIdOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = ViewAttributes.ElementClassIdAttribKey.KeyValue then 
                    prevElementClassIdOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = ViewAttributes.ElementStyleIdAttribKey.KeyValue then 
                    prevElementStyleIdOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = ViewAttributes.ElementRefAttribKey.KeyValue then 
                    prevElementRefOpt <- ValueSome (kvp.Value :?> ViewRef)
                if kvp.Key = ViewAttributes.ElementTagAttribKey.KeyValue then 
                    prevElementTagOpt <- ValueSome (kvp.Value :?> obj)
        let shouldUpdateElementCreated = not ((identical prevElementCreatedOpt currElementCreatedOpt))
        if shouldUpdateElementCreated then
            match prevElementCreatedOpt with
            | ValueSome prevValue -> target.Created.RemoveHandler(prevValue)
            | ValueNone -> ()
        if shouldUpdateElementCreated then
            match currElementCreatedOpt with
            | ValueSome currValue -> target.Created.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructElement(?automationId: string,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?ref: ViewRef<Xamarin.Forms.Element>,
                                          ?tag: obj,
                                          ?created: (Xamarin.Forms.Element -> unit)) = 

        let attribBuilder = ViewBuilders.BuildElement(0,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Element>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Element> target))))

        ViewElement.Create<Xamarin.Forms.Element>(ViewBuilders.CreateFuncElement, ViewBuilders.UpdateFuncElement, attribBuilder)

    /// Builds the attributes for a NavigableElement in the view
    static member inline BuildNavigableElement(attribCount: int,
                                               ?style: Xamarin.Forms.Style,
                                               ?styleClass: InputTypes.StyleClass,
                                               ?automationId: string,
                                               ?classId: string,
                                               ?styleId: string,
                                               ?ref: ViewRef,
                                               ?tag: obj,
                                               ?created: obj -> unit) = 

        let attribCount = match style with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleClass with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, 
                                                      ?created: obj -> unit)
        match style with None -> () | Some v -> attribBuilder.Add(ViewAttributes.NavigableElementStyleAttribKey, (v)) 
        match styleClass with None -> () | Some v -> attribBuilder.Add(ViewAttributes.NavigableElementStyleClassAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncNavigableElement : (unit -> Xamarin.Forms.NavigableElement) = (fun () -> ViewBuilders.CreateNavigableElement()) with get, set

    static member CreateNavigableElement () : Xamarin.Forms.NavigableElement =
        new Xamarin.Forms.NavigableElement()

    static member val UpdateFuncNavigableElement =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.NavigableElement) -> ViewBuilders.UpdateNavigableElement (prevOpt, curr, target)) 

    static member UpdateNavigableElement (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.NavigableElement) = 
        ViewBuilders.UpdateElement (prevOpt, curr, target)
        let mutable prevNavigableElementStyleOpt = ValueNone
        let mutable currNavigableElementStyleOpt = ValueNone
        let mutable prevNavigableElementStyleClassOpt = ValueNone
        let mutable currNavigableElementStyleClassOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.NavigableElementStyleAttribKey.KeyValue then 
                currNavigableElementStyleOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style)
            if kvp.Key = ViewAttributes.NavigableElementStyleClassAttribKey.KeyValue then 
                currNavigableElementStyleClassOpt <- ValueSome (kvp.Value :?> InputTypes.StyleClass)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.NavigableElementStyleAttribKey.KeyValue then 
                    prevNavigableElementStyleOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style)
                if kvp.Key = ViewAttributes.NavigableElementStyleClassAttribKey.KeyValue then 
                    prevNavigableElementStyleClassOpt <- ValueSome (kvp.Value :?> InputTypes.StyleClass)

    static member inline ConstructNavigableElement(?style: Xamarin.Forms.Style,
                                                   ?styleClass: InputTypes.StyleClass,
                                                   ?automationId: string,
                                                   ?classId: string,
                                                   ?styleId: string,
                                                   ?ref: ViewRef<Xamarin.Forms.NavigableElement>,
                                                   ?tag: obj,
                                                   ?created: (Xamarin.Forms.NavigableElement -> unit)) = 

        let attribBuilder = ViewBuilders.BuildNavigableElement(0,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.NavigableElement>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.NavigableElement> target))))

        ViewElement.Create<Xamarin.Forms.NavigableElement>(ViewBuilders.CreateFuncNavigableElement, ViewBuilders.UpdateFuncNavigableElement, attribBuilder)

    /// Builds the attributes for a VisualElement in the view
    static member inline BuildVisualElement(attribCount: int,
                                            ?anchorX: float,
                                            ?anchorY: float,
                                            ?backgroundColor: Xamarin.Forms.Color,
                                            ?flowDirection: Xamarin.Forms.FlowDirection,
                                            ?height: float,
                                            ?inputTransparent: bool,
                                            ?isEnabled: bool,
                                            ?isTabStop: bool,
                                            ?isVisible: bool,
                                            ?minimumHeight: float,
                                            ?minimumWidth: float,
                                            ?opacity: float,
                                            ?rotation: float,
                                            ?rotationX: float,
                                            ?rotationY: float,
                                            ?scale: float,
                                            ?scaleX: float,
                                            ?scaleY: float,
                                            ?tabIndex: int,
                                            ?translationX: float,
                                            ?translationY: float,
                                            ?visual: Xamarin.Forms.IVisual,
                                            ?width: float,
                                            ?style: Xamarin.Forms.Style,
                                            ?styleClass: InputTypes.StyleClass,
                                            ?automationId: string,
                                            ?classId: string,
                                            ?styleId: string,
                                            ?ref: ViewRef,
                                            ?tag: obj,
                                            ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                            ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                            ?created: obj -> unit) = 

        let attribCount = match anchorX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match anchorY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match backgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match flowDirection with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match height with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match inputTransparent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isTabStop with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isVisible with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match minimumHeight with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match minimumWidth with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match opacity with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rotation with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rotationX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rotationY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scale with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scaleX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scaleY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match tabIndex with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match translationX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match translationY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match visual with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match width with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match focused with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match unfocused with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildNavigableElement(attribCount, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, ?classId: string, ?styleId: string, 
                                                               ?ref: ViewRef, ?tag: obj, ?created: obj -> unit)
        match anchorX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementAnchorXAttribKey, (v)) 
        match anchorY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementAnchorYAttribKey, (v)) 
        match backgroundColor with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementBackgroundColorAttribKey, (v)) 
        match flowDirection with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementFlowDirectionAttribKey, (v)) 
        match height with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementHeightAttribKey, (v)) 
        match inputTransparent with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementInputTransparentAttribKey, (v)) 
        match isEnabled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementIsEnabledAttribKey, (v)) 
        match isTabStop with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementIsTabStopAttribKey, (v)) 
        match isVisible with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementIsVisibleAttribKey, (v)) 
        match minimumHeight with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementMinimumHeightAttribKey, (v)) 
        match minimumWidth with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementMinimumWidthAttribKey, (v)) 
        match opacity with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementOpacityAttribKey, (v)) 
        match rotation with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementRotationAttribKey, (v)) 
        match rotationX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementRotationXAttribKey, (v)) 
        match rotationY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementRotationYAttribKey, (v)) 
        match scale with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementScaleAttribKey, (v)) 
        match scaleX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementScaleXAttribKey, (v)) 
        match scaleY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementScaleYAttribKey, (v)) 
        match tabIndex with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementTabIndexAttribKey, (v)) 
        match translationX with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementTranslationXAttribKey, (v)) 
        match translationY with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementTranslationYAttribKey, (v)) 
        match visual with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementVisualAttribKey, (v)) 
        match width with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementWidthAttribKey, (v)) 
        match focused with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementFocusedAttribKey, (v)) 
        match unfocused with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementUnfocusedAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncVisualElement : (unit -> Xamarin.Forms.VisualElement) = (fun () -> ViewBuilders.CreateVisualElement()) with get, set

    static member CreateVisualElement () : Xamarin.Forms.VisualElement =
        new Xamarin.Forms.VisualElement()

    static member val UpdateFuncVisualElement =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.VisualElement) -> ViewBuilders.UpdateVisualElement (prevOpt, curr, target)) 

    static member UpdateVisualElement (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.VisualElement) = 
        ViewBuilders.UpdateNavigableElement (prevOpt, curr, target)
        let mutable prevVisualElementFocusedOpt = ValueNone
        let mutable currVisualElementFocusedOpt = ValueNone
        let mutable prevVisualElementUnfocusedOpt = ValueNone
        let mutable currVisualElementUnfocusedOpt = ValueNone
        let mutable prevVisualElementAnchorXOpt = ValueNone
        let mutable currVisualElementAnchorXOpt = ValueNone
        let mutable prevVisualElementAnchorYOpt = ValueNone
        let mutable currVisualElementAnchorYOpt = ValueNone
        let mutable prevVisualElementBackgroundColorOpt = ValueNone
        let mutable currVisualElementBackgroundColorOpt = ValueNone
        let mutable prevVisualElementFlowDirectionOpt = ValueNone
        let mutable currVisualElementFlowDirectionOpt = ValueNone
        let mutable prevVisualElementHeightOpt = ValueNone
        let mutable currVisualElementHeightOpt = ValueNone
        let mutable prevVisualElementInputTransparentOpt = ValueNone
        let mutable currVisualElementInputTransparentOpt = ValueNone
        let mutable prevVisualElementIsEnabledOpt = ValueNone
        let mutable currVisualElementIsEnabledOpt = ValueNone
        let mutable prevVisualElementIsTabStopOpt = ValueNone
        let mutable currVisualElementIsTabStopOpt = ValueNone
        let mutable prevVisualElementIsVisibleOpt = ValueNone
        let mutable currVisualElementIsVisibleOpt = ValueNone
        let mutable prevVisualElementMinimumHeightOpt = ValueNone
        let mutable currVisualElementMinimumHeightOpt = ValueNone
        let mutable prevVisualElementMinimumWidthOpt = ValueNone
        let mutable currVisualElementMinimumWidthOpt = ValueNone
        let mutable prevVisualElementOpacityOpt = ValueNone
        let mutable currVisualElementOpacityOpt = ValueNone
        let mutable prevVisualElementRotationOpt = ValueNone
        let mutable currVisualElementRotationOpt = ValueNone
        let mutable prevVisualElementRotationXOpt = ValueNone
        let mutable currVisualElementRotationXOpt = ValueNone
        let mutable prevVisualElementRotationYOpt = ValueNone
        let mutable currVisualElementRotationYOpt = ValueNone
        let mutable prevVisualElementScaleOpt = ValueNone
        let mutable currVisualElementScaleOpt = ValueNone
        let mutable prevVisualElementScaleXOpt = ValueNone
        let mutable currVisualElementScaleXOpt = ValueNone
        let mutable prevVisualElementScaleYOpt = ValueNone
        let mutable currVisualElementScaleYOpt = ValueNone
        let mutable prevVisualElementTabIndexOpt = ValueNone
        let mutable currVisualElementTabIndexOpt = ValueNone
        let mutable prevVisualElementTranslationXOpt = ValueNone
        let mutable currVisualElementTranslationXOpt = ValueNone
        let mutable prevVisualElementTranslationYOpt = ValueNone
        let mutable currVisualElementTranslationYOpt = ValueNone
        let mutable prevVisualElementVisualOpt = ValueNone
        let mutable currVisualElementVisualOpt = ValueNone
        let mutable prevVisualElementWidthOpt = ValueNone
        let mutable currVisualElementWidthOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.VisualElementFocusedAttribKey.KeyValue then 
                currVisualElementFocusedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.FocusEventArgs>)
            if kvp.Key = ViewAttributes.VisualElementUnfocusedAttribKey.KeyValue then 
                currVisualElementUnfocusedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.FocusEventArgs>)
            if kvp.Key = ViewAttributes.VisualElementAnchorXAttribKey.KeyValue then 
                currVisualElementAnchorXOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementAnchorYAttribKey.KeyValue then 
                currVisualElementAnchorYOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementBackgroundColorAttribKey.KeyValue then 
                currVisualElementBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = ViewAttributes.VisualElementFlowDirectionAttribKey.KeyValue then 
                currVisualElementFlowDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlowDirection)
            if kvp.Key = ViewAttributes.VisualElementHeightAttribKey.KeyValue then 
                currVisualElementHeightOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementInputTransparentAttribKey.KeyValue then 
                currVisualElementInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.VisualElementIsEnabledAttribKey.KeyValue then 
                currVisualElementIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.VisualElementIsTabStopAttribKey.KeyValue then 
                currVisualElementIsTabStopOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.VisualElementIsVisibleAttribKey.KeyValue then 
                currVisualElementIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.VisualElementMinimumHeightAttribKey.KeyValue then 
                currVisualElementMinimumHeightOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementMinimumWidthAttribKey.KeyValue then 
                currVisualElementMinimumWidthOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementOpacityAttribKey.KeyValue then 
                currVisualElementOpacityOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementRotationAttribKey.KeyValue then 
                currVisualElementRotationOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementRotationXAttribKey.KeyValue then 
                currVisualElementRotationXOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementRotationYAttribKey.KeyValue then 
                currVisualElementRotationYOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementScaleAttribKey.KeyValue then 
                currVisualElementScaleOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementScaleXAttribKey.KeyValue then 
                currVisualElementScaleXOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementScaleYAttribKey.KeyValue then 
                currVisualElementScaleYOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementTabIndexAttribKey.KeyValue then 
                currVisualElementTabIndexOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.VisualElementTranslationXAttribKey.KeyValue then 
                currVisualElementTranslationXOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementTranslationYAttribKey.KeyValue then 
                currVisualElementTranslationYOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementVisualAttribKey.KeyValue then 
                currVisualElementVisualOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.IVisual)
            if kvp.Key = ViewAttributes.VisualElementWidthAttribKey.KeyValue then 
                currVisualElementWidthOpt <- ValueSome (kvp.Value :?> float)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.VisualElementFocusedAttribKey.KeyValue then 
                    prevVisualElementFocusedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.FocusEventArgs>)
                if kvp.Key = ViewAttributes.VisualElementUnfocusedAttribKey.KeyValue then 
                    prevVisualElementUnfocusedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.FocusEventArgs>)
                if kvp.Key = ViewAttributes.VisualElementAnchorXAttribKey.KeyValue then 
                    prevVisualElementAnchorXOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementAnchorYAttribKey.KeyValue then 
                    prevVisualElementAnchorYOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementBackgroundColorAttribKey.KeyValue then 
                    prevVisualElementBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = ViewAttributes.VisualElementFlowDirectionAttribKey.KeyValue then 
                    prevVisualElementFlowDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlowDirection)
                if kvp.Key = ViewAttributes.VisualElementHeightAttribKey.KeyValue then 
                    prevVisualElementHeightOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementInputTransparentAttribKey.KeyValue then 
                    prevVisualElementInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.VisualElementIsEnabledAttribKey.KeyValue then 
                    prevVisualElementIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.VisualElementIsTabStopAttribKey.KeyValue then 
                    prevVisualElementIsTabStopOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.VisualElementIsVisibleAttribKey.KeyValue then 
                    prevVisualElementIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.VisualElementMinimumHeightAttribKey.KeyValue then 
                    prevVisualElementMinimumHeightOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementMinimumWidthAttribKey.KeyValue then 
                    prevVisualElementMinimumWidthOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementOpacityAttribKey.KeyValue then 
                    prevVisualElementOpacityOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementRotationAttribKey.KeyValue then 
                    prevVisualElementRotationOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementRotationXAttribKey.KeyValue then 
                    prevVisualElementRotationXOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementRotationYAttribKey.KeyValue then 
                    prevVisualElementRotationYOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementScaleAttribKey.KeyValue then 
                    prevVisualElementScaleOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementScaleXAttribKey.KeyValue then 
                    prevVisualElementScaleXOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementScaleYAttribKey.KeyValue then 
                    prevVisualElementScaleYOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementTabIndexAttribKey.KeyValue then 
                    prevVisualElementTabIndexOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.VisualElementTranslationXAttribKey.KeyValue then 
                    prevVisualElementTranslationXOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementTranslationYAttribKey.KeyValue then 
                    prevVisualElementTranslationYOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementVisualAttribKey.KeyValue then 
                    prevVisualElementVisualOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.IVisual)
                if kvp.Key = ViewAttributes.VisualElementWidthAttribKey.KeyValue then 
                    prevVisualElementWidthOpt <- ValueSome (kvp.Value :?> float)
        let shouldUpdateVisualElementFocused = not ((identical prevVisualElementFocusedOpt currVisualElementFocusedOpt))
        if shouldUpdateVisualElementFocused then
            match prevVisualElementFocusedOpt with
            | ValueSome prevValue -> target.Focused.RemoveHandler(prevValue)
            | ValueNone -> ()
        let shouldUpdateVisualElementUnfocused = not ((identical prevVisualElementUnfocusedOpt currVisualElementUnfocusedOpt))
        if shouldUpdateVisualElementUnfocused then
            match prevVisualElementUnfocusedOpt with
            | ValueSome prevValue -> target.Unfocused.RemoveHandler(prevValue)
            | ValueNone -> ()
        if shouldUpdateVisualElementFocused then
            match currVisualElementFocusedOpt with
            | ValueSome currValue -> target.Focused.AddHandler(currValue)
            | ValueNone -> ()
        if shouldUpdateVisualElementUnfocused then
            match currVisualElementUnfocusedOpt with
            | ValueSome currValue -> target.Unfocused.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructVisualElement(?anchorX: float,
                                                ?anchorY: float,
                                                ?backgroundColor: Xamarin.Forms.Color,
                                                ?flowDirection: Xamarin.Forms.FlowDirection,
                                                ?height: float,
                                                ?inputTransparent: bool,
                                                ?isEnabled: bool,
                                                ?isTabStop: bool,
                                                ?isVisible: bool,
                                                ?minimumHeight: float,
                                                ?minimumWidth: float,
                                                ?opacity: float,
                                                ?rotation: float,
                                                ?rotationX: float,
                                                ?rotationY: float,
                                                ?scale: float,
                                                ?scaleX: float,
                                                ?scaleY: float,
                                                ?tabIndex: int,
                                                ?translationX: float,
                                                ?translationY: float,
                                                ?visual: Xamarin.Forms.IVisual,
                                                ?width: float,
                                                ?style: Xamarin.Forms.Style,
                                                ?styleClass: InputTypes.StyleClass,
                                                ?automationId: string,
                                                ?classId: string,
                                                ?styleId: string,
                                                ?ref: ViewRef<Xamarin.Forms.VisualElement>,
                                                ?tag: obj,
                                                ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                                ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                                ?created: (Xamarin.Forms.VisualElement -> unit)) = 

        let attribBuilder = ViewBuilders.BuildVisualElement(0,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.VisualElement>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.VisualElement> target))))

        ViewElement.Create<Xamarin.Forms.VisualElement>(ViewBuilders.CreateFuncVisualElement, ViewBuilders.UpdateFuncVisualElement, attribBuilder)

    /// Builds the attributes for a View in the view
    static member inline BuildView(attribCount: int,
                                   ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                   ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                   ?margin: InputTypes.Thickness,
                                   ?gestureRecognizers: ViewElement list,
                                   ?anchorX: float,
                                   ?anchorY: float,
                                   ?backgroundColor: Xamarin.Forms.Color,
                                   ?flowDirection: Xamarin.Forms.FlowDirection,
                                   ?height: float,
                                   ?inputTransparent: bool,
                                   ?isEnabled: bool,
                                   ?isTabStop: bool,
                                   ?isVisible: bool,
                                   ?minimumHeight: float,
                                   ?minimumWidth: float,
                                   ?opacity: float,
                                   ?rotation: float,
                                   ?rotationX: float,
                                   ?rotationY: float,
                                   ?scale: float,
                                   ?scaleX: float,
                                   ?scaleY: float,
                                   ?tabIndex: int,
                                   ?translationX: float,
                                   ?translationY: float,
                                   ?visual: Xamarin.Forms.IVisual,
                                   ?width: float,
                                   ?style: Xamarin.Forms.Style,
                                   ?styleClass: InputTypes.StyleClass,
                                   ?automationId: string,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?ref: ViewRef,
                                   ?tag: obj,
                                   ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                   ?created: obj -> unit) = 

        let attribCount = match horizontalOptions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match verticalOptions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match margin with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match gestureRecognizers with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildVisualElement(attribCount, ?anchorX: float, ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, ?height: float, 
                                                            ?inputTransparent: bool, ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, ?minimumHeight: float, 
                                                            ?minimumWidth: float, ?opacity: float, ?rotation: float, ?rotationX: float, ?rotationY: float, 
                                                            ?scale: float, ?scaleX: float, ?scaleY: float, ?tabIndex: int, ?translationX: float, 
                                                            ?translationY: float, ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, 
                                                            ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, 
                                                            ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match horizontalOptions with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ViewHorizontalOptionsAttribKey, (v)) 
        match verticalOptions with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ViewVerticalOptionsAttribKey, (v)) 
        match margin with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ViewMarginAttribKey, (v)) 
        match gestureRecognizers with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ViewGestureRecognizersAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncView : (unit -> Xamarin.Forms.View) = (fun () -> ViewBuilders.CreateView()) with get, set

    static member CreateView () : Xamarin.Forms.View =
        new Xamarin.Forms.View()

    static member val UpdateFuncView =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.View) -> ViewBuilders.UpdateView (prevOpt, curr, target)) 

    static member UpdateView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.View) = 
        ViewBuilders.UpdateVisualElement (prevOpt, curr, target)
        let mutable prevViewHorizontalOptionsOpt = ValueNone
        let mutable currViewHorizontalOptionsOpt = ValueNone
        let mutable prevViewVerticalOptionsOpt = ValueNone
        let mutable currViewVerticalOptionsOpt = ValueNone
        let mutable prevViewMarginOpt = ValueNone
        let mutable currViewMarginOpt = ValueNone
        let mutable prevViewGestureRecognizersOpt = ValueNone
        let mutable currViewGestureRecognizersOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.ViewHorizontalOptionsAttribKey.KeyValue then 
                currViewHorizontalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
            if kvp.Key = ViewAttributes.ViewVerticalOptionsAttribKey.KeyValue then 
                currViewVerticalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
            if kvp.Key = ViewAttributes.ViewMarginAttribKey.KeyValue then 
                currViewMarginOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
            if kvp.Key = ViewAttributes.ViewGestureRecognizersAttribKey.KeyValue then 
                currViewGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement list)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.ViewHorizontalOptionsAttribKey.KeyValue then 
                    prevViewHorizontalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                if kvp.Key = ViewAttributes.ViewVerticalOptionsAttribKey.KeyValue then 
                    prevViewVerticalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                if kvp.Key = ViewAttributes.ViewMarginAttribKey.KeyValue then 
                    prevViewMarginOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                if kvp.Key = ViewAttributes.ViewGestureRecognizersAttribKey.KeyValue then 
                    prevViewGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement list)

    static member inline ConstructView(?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                       ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                       ?margin: InputTypes.Thickness,
                                       ?gestureRecognizers: ViewElement list,
                                       ?anchorX: float,
                                       ?anchorY: float,
                                       ?backgroundColor: Xamarin.Forms.Color,
                                       ?flowDirection: Xamarin.Forms.FlowDirection,
                                       ?height: float,
                                       ?inputTransparent: bool,
                                       ?isEnabled: bool,
                                       ?isTabStop: bool,
                                       ?isVisible: bool,
                                       ?minimumHeight: float,
                                       ?minimumWidth: float,
                                       ?opacity: float,
                                       ?rotation: float,
                                       ?rotationX: float,
                                       ?rotationY: float,
                                       ?scale: float,
                                       ?scaleX: float,
                                       ?scaleY: float,
                                       ?tabIndex: int,
                                       ?translationX: float,
                                       ?translationY: float,
                                       ?visual: Xamarin.Forms.IVisual,
                                       ?width: float,
                                       ?style: Xamarin.Forms.Style,
                                       ?styleClass: InputTypes.StyleClass,
                                       ?automationId: string,
                                       ?classId: string,
                                       ?styleId: string,
                                       ?ref: ViewRef<Xamarin.Forms.View>,
                                       ?tag: obj,
                                       ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                       ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                       ?created: (Xamarin.Forms.View -> unit)) = 

        let attribBuilder = ViewBuilders.BuildView(0,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.View>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.View> target))))

        ViewElement.Create<Xamarin.Forms.View>(ViewBuilders.CreateFuncView, ViewBuilders.UpdateFuncView, attribBuilder)

    /// Builds the attributes for a GestureElement in the view
    static member inline BuildGestureElement(attribCount: int,
                                             ?gestureRecognizers: ViewElement list,
                                             ?automationId: string,
                                             ?classId: string,
                                             ?styleId: string,
                                             ?ref: ViewRef,
                                             ?tag: obj,
                                             ?created: obj -> unit) = 

        let attribCount = match gestureRecognizers with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, 
                                                      ?created: obj -> unit)
        match gestureRecognizers with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GestureElementGestureRecognizersAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncGestureElement : (unit -> Xamarin.Forms.GestureElement) = (fun () -> ViewBuilders.CreateGestureElement()) with get, set

    static member CreateGestureElement () : Xamarin.Forms.GestureElement =
        new Xamarin.Forms.GestureElement()

    static member val UpdateFuncGestureElement =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.GestureElement) -> ViewBuilders.UpdateGestureElement (prevOpt, curr, target)) 

    static member UpdateGestureElement (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.GestureElement) = 
        ViewBuilders.UpdateElement (prevOpt, curr, target)
        let mutable prevGestureElementGestureRecognizersOpt = ValueNone
        let mutable currGestureElementGestureRecognizersOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.GestureElementGestureRecognizersAttribKey.KeyValue then 
                currGestureElementGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement list)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.GestureElementGestureRecognizersAttribKey.KeyValue then 
                    prevGestureElementGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement list)

    static member inline ConstructGestureElement(?gestureRecognizers: ViewElement list,
                                                 ?automationId: string,
                                                 ?classId: string,
                                                 ?styleId: string,
                                                 ?ref: ViewRef<Xamarin.Forms.GestureElement>,
                                                 ?tag: obj,
                                                 ?created: (Xamarin.Forms.GestureElement -> unit)) = 

        let attribBuilder = ViewBuilders.BuildGestureElement(0,
                               ?gestureRecognizers=gestureRecognizers,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.GestureElement>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.GestureElement> target))))

        ViewElement.Create<Xamarin.Forms.GestureElement>(ViewBuilders.CreateFuncGestureElement, ViewBuilders.UpdateFuncGestureElement, attribBuilder)

    /// Builds the attributes for a PanGestureRecognizer in the view
    static member inline BuildPanGestureRecognizer(attribCount: int,
                                                   ?touchPoints: int,
                                                   ?automationId: string,
                                                   ?classId: string,
                                                   ?styleId: string,
                                                   ?ref: ViewRef,
                                                   ?tag: obj,
                                                   ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit,
                                                   ?created: obj -> unit) = 

        let attribCount = match touchPoints with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match panUpdated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, 
                                                      ?created: obj -> unit)
        match touchPoints with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PanGestureRecognizerTouchPointsAttribKey, (v)) 
        match panUpdated with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PanGestureRecognizerPanUpdatedAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncPanGestureRecognizer : (unit -> Xamarin.Forms.PanGestureRecognizer) = (fun () -> ViewBuilders.CreatePanGestureRecognizer()) with get, set

    static member CreatePanGestureRecognizer () : Xamarin.Forms.PanGestureRecognizer =
        new Xamarin.Forms.PanGestureRecognizer()

    static member val UpdateFuncPanGestureRecognizer =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.PanGestureRecognizer) -> ViewBuilders.UpdatePanGestureRecognizer (prevOpt, curr, target)) 

    static member UpdatePanGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.PanGestureRecognizer) = 
        ViewBuilders.UpdateElement (prevOpt, curr, target)
        let mutable prevPanGestureRecognizerPanUpdatedOpt = ValueNone
        let mutable currPanGestureRecognizerPanUpdatedOpt = ValueNone
        let mutable prevPanGestureRecognizerTouchPointsOpt = ValueNone
        let mutable currPanGestureRecognizerTouchPointsOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.PanGestureRecognizerPanUpdatedAttribKey.KeyValue then 
                currPanGestureRecognizerPanUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>)
            if kvp.Key = ViewAttributes.PanGestureRecognizerTouchPointsAttribKey.KeyValue then 
                currPanGestureRecognizerTouchPointsOpt <- ValueSome (kvp.Value :?> int)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.PanGestureRecognizerPanUpdatedAttribKey.KeyValue then 
                    prevPanGestureRecognizerPanUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>)
                if kvp.Key = ViewAttributes.PanGestureRecognizerTouchPointsAttribKey.KeyValue then 
                    prevPanGestureRecognizerTouchPointsOpt <- ValueSome (kvp.Value :?> int)
        let shouldUpdatePanGestureRecognizerPanUpdated = not ((identical prevPanGestureRecognizerPanUpdatedOpt currPanGestureRecognizerPanUpdatedOpt))
        if shouldUpdatePanGestureRecognizerPanUpdated then
            match prevPanGestureRecognizerPanUpdatedOpt with
            | ValueSome prevValue -> target.PanUpdated.RemoveHandler(prevValue)
            | ValueNone -> ()
        if shouldUpdatePanGestureRecognizerPanUpdated then
            match currPanGestureRecognizerPanUpdatedOpt with
            | ValueSome currValue -> target.PanUpdated.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructPanGestureRecognizer(?touchPoints: int,
                                                       ?automationId: string,
                                                       ?classId: string,
                                                       ?styleId: string,
                                                       ?ref: ViewRef<Xamarin.Forms.PanGestureRecognizer>,
                                                       ?tag: obj,
                                                       ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit,
                                                       ?created: (Xamarin.Forms.PanGestureRecognizer -> unit)) = 

        let attribBuilder = ViewBuilders.BuildPanGestureRecognizer(0,
                               ?touchPoints=touchPoints,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.PanGestureRecognizer>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?panUpdated=panUpdated,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.PanGestureRecognizer> target))))

        ViewElement.Create<Xamarin.Forms.PanGestureRecognizer>(ViewBuilders.CreateFuncPanGestureRecognizer, ViewBuilders.UpdateFuncPanGestureRecognizer, attribBuilder)

    /// Builds the attributes for a ClickGestureRecognizer in the view
    static member inline BuildClickGestureRecognizer(attribCount: int,
                                                     ?command: unit -> unit,
                                                     ?numberOfClicksRequired: int,
                                                     ?buttons: Xamarin.Forms.ButtonsMask,
                                                     ?automationId: string,
                                                     ?classId: string,
                                                     ?styleId: string,
                                                     ?ref: ViewRef,
                                                     ?tag: obj,
                                                     ?created: obj -> unit) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match numberOfClicksRequired with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match buttons with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, 
                                                      ?created: obj -> unit)
        match command with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ClickGestureRecognizerCommandAttribKey, (v)) 
        match numberOfClicksRequired with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ClickGestureRecognizerNumberOfClicksRequiredAttribKey, (v)) 
        match buttons with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ClickGestureRecognizerButtonsAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncClickGestureRecognizer : (unit -> Xamarin.Forms.ClickGestureRecognizer) = (fun () -> ViewBuilders.CreateClickGestureRecognizer()) with get, set

    static member CreateClickGestureRecognizer () : Xamarin.Forms.ClickGestureRecognizer =
        new Xamarin.Forms.ClickGestureRecognizer()

    static member val UpdateFuncClickGestureRecognizer =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ClickGestureRecognizer) -> ViewBuilders.UpdateClickGestureRecognizer (prevOpt, curr, target)) 

    static member UpdateClickGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ClickGestureRecognizer) = 
        ViewBuilders.UpdateElement (prevOpt, curr, target)
        let mutable prevClickGestureRecognizerCommandOpt = ValueNone
        let mutable currClickGestureRecognizerCommandOpt = ValueNone
        let mutable prevClickGestureRecognizerNumberOfClicksRequiredOpt = ValueNone
        let mutable currClickGestureRecognizerNumberOfClicksRequiredOpt = ValueNone
        let mutable prevClickGestureRecognizerButtonsOpt = ValueNone
        let mutable currClickGestureRecognizerButtonsOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.ClickGestureRecognizerCommandAttribKey.KeyValue then 
                currClickGestureRecognizerCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
            if kvp.Key = ViewAttributes.ClickGestureRecognizerNumberOfClicksRequiredAttribKey.KeyValue then 
                currClickGestureRecognizerNumberOfClicksRequiredOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.ClickGestureRecognizerButtonsAttribKey.KeyValue then 
                currClickGestureRecognizerButtonsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ButtonsMask)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.ClickGestureRecognizerCommandAttribKey.KeyValue then 
                    prevClickGestureRecognizerCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = ViewAttributes.ClickGestureRecognizerNumberOfClicksRequiredAttribKey.KeyValue then 
                    prevClickGestureRecognizerNumberOfClicksRequiredOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.ClickGestureRecognizerButtonsAttribKey.KeyValue then 
                    prevClickGestureRecognizerButtonsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ButtonsMask)

    static member inline ConstructClickGestureRecognizer(?command: unit -> unit,
                                                         ?numberOfClicksRequired: int,
                                                         ?buttons: Xamarin.Forms.ButtonsMask,
                                                         ?automationId: string,
                                                         ?classId: string,
                                                         ?styleId: string,
                                                         ?ref: ViewRef<Xamarin.Forms.ClickGestureRecognizer>,
                                                         ?tag: obj,
                                                         ?created: (Xamarin.Forms.ClickGestureRecognizer -> unit)) = 

        let attribBuilder = ViewBuilders.BuildClickGestureRecognizer(0,
                               ?command=command,
                               ?numberOfClicksRequired=numberOfClicksRequired,
                               ?buttons=buttons,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ClickGestureRecognizer>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ClickGestureRecognizer> target))))

        ViewElement.Create<Xamarin.Forms.ClickGestureRecognizer>(ViewBuilders.CreateFuncClickGestureRecognizer, ViewBuilders.UpdateFuncClickGestureRecognizer, attribBuilder)

    /// Builds the attributes for a PinchGestureRecognizer in the view
    static member inline BuildPinchGestureRecognizer(attribCount: int,
                                                     ?automationId: string,
                                                     ?classId: string,
                                                     ?styleId: string,
                                                     ?ref: ViewRef,
                                                     ?tag: obj,
                                                     ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit,
                                                     ?created: obj -> unit) = 

        let attribCount = match pinchUpdated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, 
                                                      ?created: obj -> unit)
        match pinchUpdated with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PinchGestureRecognizerPinchUpdatedAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncPinchGestureRecognizer : (unit -> Xamarin.Forms.PinchGestureRecognizer) = (fun () -> ViewBuilders.CreatePinchGestureRecognizer()) with get, set

    static member CreatePinchGestureRecognizer () : Xamarin.Forms.PinchGestureRecognizer =
        new Xamarin.Forms.PinchGestureRecognizer()

    static member val UpdateFuncPinchGestureRecognizer =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.PinchGestureRecognizer) -> ViewBuilders.UpdatePinchGestureRecognizer (prevOpt, curr, target)) 

    static member UpdatePinchGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.PinchGestureRecognizer) = 
        ViewBuilders.UpdateElement (prevOpt, curr, target)
        let mutable prevPinchGestureRecognizerPinchUpdatedOpt = ValueNone
        let mutable currPinchGestureRecognizerPinchUpdatedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.PinchGestureRecognizerPinchUpdatedAttribKey.KeyValue then 
                currPinchGestureRecognizerPinchUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.PinchGestureRecognizerPinchUpdatedAttribKey.KeyValue then 
                    prevPinchGestureRecognizerPinchUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>)
        let shouldUpdatePinchGestureRecognizerPinchUpdated = not ((identical prevPinchGestureRecognizerPinchUpdatedOpt currPinchGestureRecognizerPinchUpdatedOpt))
        if shouldUpdatePinchGestureRecognizerPinchUpdated then
            match prevPinchGestureRecognizerPinchUpdatedOpt with
            | ValueSome prevValue -> target.PinchUpdated.RemoveHandler(prevValue)
            | ValueNone -> ()
        if shouldUpdatePinchGestureRecognizerPinchUpdated then
            match currPinchGestureRecognizerPinchUpdatedOpt with
            | ValueSome currValue -> target.PinchUpdated.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructPinchGestureRecognizer(?automationId: string,
                                                         ?classId: string,
                                                         ?styleId: string,
                                                         ?ref: ViewRef<Xamarin.Forms.PinchGestureRecognizer>,
                                                         ?tag: obj,
                                                         ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit,
                                                         ?created: (Xamarin.Forms.PinchGestureRecognizer -> unit)) = 

        let attribBuilder = ViewBuilders.BuildPinchGestureRecognizer(0,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.PinchGestureRecognizer>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?pinchUpdated=pinchUpdated,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.PinchGestureRecognizer> target))))

        ViewElement.Create<Xamarin.Forms.PinchGestureRecognizer>(ViewBuilders.CreateFuncPinchGestureRecognizer, ViewBuilders.UpdateFuncPinchGestureRecognizer, attribBuilder)

    /// Builds the attributes for a SwipeGestureRecognizer in the view
    static member inline BuildSwipeGestureRecognizer(attribCount: int,
                                                     ?command: unit -> unit,
                                                     ?direction: Xamarin.Forms.SwipeDirection,
                                                     ?threshold: uint32,
                                                     ?automationId: string,
                                                     ?classId: string,
                                                     ?styleId: string,
                                                     ?ref: ViewRef,
                                                     ?tag: obj,
                                                     ?swiped: Xamarin.Forms.SwipedEventArgs -> unit,
                                                     ?created: obj -> unit) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match direction with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match threshold with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match swiped with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, 
                                                      ?created: obj -> unit)
        match command with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerCommandAttribKey, (v)) 
        match direction with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerDirectionAttribKey, (v)) 
        match threshold with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerThresholdAttribKey, (v)) 
        match swiped with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerSwipedAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncSwipeGestureRecognizer : (unit -> Xamarin.Forms.SwipeGestureRecognizer) = (fun () -> ViewBuilders.CreateSwipeGestureRecognizer()) with get, set

    static member CreateSwipeGestureRecognizer () : Xamarin.Forms.SwipeGestureRecognizer =
        new Xamarin.Forms.SwipeGestureRecognizer()

    static member val UpdateFuncSwipeGestureRecognizer =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.SwipeGestureRecognizer) -> ViewBuilders.UpdateSwipeGestureRecognizer (prevOpt, curr, target)) 

    static member UpdateSwipeGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.SwipeGestureRecognizer) = 
        ViewBuilders.UpdateElement (prevOpt, curr, target)
        let mutable prevSwipeGestureRecognizerSwipedOpt = ValueNone
        let mutable currSwipeGestureRecognizerSwipedOpt = ValueNone
        let mutable prevSwipeGestureRecognizerCommandOpt = ValueNone
        let mutable currSwipeGestureRecognizerCommandOpt = ValueNone
        let mutable prevSwipeGestureRecognizerDirectionOpt = ValueNone
        let mutable currSwipeGestureRecognizerDirectionOpt = ValueNone
        let mutable prevSwipeGestureRecognizerThresholdOpt = ValueNone
        let mutable currSwipeGestureRecognizerThresholdOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.SwipeGestureRecognizerSwipedAttribKey.KeyValue then 
                currSwipeGestureRecognizerSwipedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SwipedEventArgs>)
            if kvp.Key = ViewAttributes.SwipeGestureRecognizerCommandAttribKey.KeyValue then 
                currSwipeGestureRecognizerCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
            if kvp.Key = ViewAttributes.SwipeGestureRecognizerDirectionAttribKey.KeyValue then 
                currSwipeGestureRecognizerDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SwipeDirection)
            if kvp.Key = ViewAttributes.SwipeGestureRecognizerThresholdAttribKey.KeyValue then 
                currSwipeGestureRecognizerThresholdOpt <- ValueSome (kvp.Value :?> uint32)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.SwipeGestureRecognizerSwipedAttribKey.KeyValue then 
                    prevSwipeGestureRecognizerSwipedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SwipedEventArgs>)
                if kvp.Key = ViewAttributes.SwipeGestureRecognizerCommandAttribKey.KeyValue then 
                    prevSwipeGestureRecognizerCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = ViewAttributes.SwipeGestureRecognizerDirectionAttribKey.KeyValue then 
                    prevSwipeGestureRecognizerDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SwipeDirection)
                if kvp.Key = ViewAttributes.SwipeGestureRecognizerThresholdAttribKey.KeyValue then 
                    prevSwipeGestureRecognizerThresholdOpt <- ValueSome (kvp.Value :?> uint32)
        let shouldUpdateSwipeGestureRecognizerSwiped = not ((identical prevSwipeGestureRecognizerSwipedOpt currSwipeGestureRecognizerSwipedOpt))
        if shouldUpdateSwipeGestureRecognizerSwiped then
            match prevSwipeGestureRecognizerSwipedOpt with
            | ValueSome prevValue -> target.Swiped.RemoveHandler(prevValue)
            | ValueNone -> ()
        if shouldUpdateSwipeGestureRecognizerSwiped then
            match currSwipeGestureRecognizerSwipedOpt with
            | ValueSome currValue -> target.Swiped.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructSwipeGestureRecognizer(?command: unit -> unit,
                                                         ?direction: Xamarin.Forms.SwipeDirection,
                                                         ?threshold: uint32,
                                                         ?automationId: string,
                                                         ?classId: string,
                                                         ?styleId: string,
                                                         ?ref: ViewRef<Xamarin.Forms.SwipeGestureRecognizer>,
                                                         ?tag: obj,
                                                         ?swiped: Xamarin.Forms.SwipedEventArgs -> unit,
                                                         ?created: (Xamarin.Forms.SwipeGestureRecognizer -> unit)) = 

        let attribBuilder = ViewBuilders.BuildSwipeGestureRecognizer(0,
                               ?command=command,
                               ?direction=direction,
                               ?threshold=threshold,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.SwipeGestureRecognizer>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?swiped=swiped,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.SwipeGestureRecognizer> target))))

        ViewElement.Create<Xamarin.Forms.SwipeGestureRecognizer>(ViewBuilders.CreateFuncSwipeGestureRecognizer, ViewBuilders.UpdateFuncSwipeGestureRecognizer, attribBuilder)

    /// Builds the attributes for a ActivityIndicator in the view
    static member inline BuildActivityIndicator(attribCount: int,
                                                ?color: Xamarin.Forms.Color,
                                                ?isRunning: bool,
                                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                                ?margin: InputTypes.Thickness,
                                                ?gestureRecognizers: ViewElement list,
                                                ?anchorX: float,
                                                ?anchorY: float,
                                                ?backgroundColor: Xamarin.Forms.Color,
                                                ?flowDirection: Xamarin.Forms.FlowDirection,
                                                ?height: float,
                                                ?inputTransparent: bool,
                                                ?isEnabled: bool,
                                                ?isTabStop: bool,
                                                ?isVisible: bool,
                                                ?minimumHeight: float,
                                                ?minimumWidth: float,
                                                ?opacity: float,
                                                ?rotation: float,
                                                ?rotationX: float,
                                                ?rotationY: float,
                                                ?scale: float,
                                                ?scaleX: float,
                                                ?scaleY: float,
                                                ?tabIndex: int,
                                                ?translationX: float,
                                                ?translationY: float,
                                                ?visual: Xamarin.Forms.IVisual,
                                                ?width: float,
                                                ?style: Xamarin.Forms.Style,
                                                ?styleClass: InputTypes.StyleClass,
                                                ?automationId: string,
                                                ?classId: string,
                                                ?styleId: string,
                                                ?ref: ViewRef,
                                                ?tag: obj,
                                                ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                                ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                                ?created: obj -> unit) = 

        let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isRunning with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, 
                                                   ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, ?height: float, ?inputTransparent: bool, 
                                                   ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, ?minimumHeight: float, ?minimumWidth: float, 
                                                   ?opacity: float, ?rotation: float, ?rotationX: float, ?rotationY: float, ?scale: float, 
                                                   ?scaleX: float, ?scaleY: float, ?tabIndex: int, ?translationX: float, ?translationY: float, 
                                                   ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, 
                                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match color with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ActivityIndicatorColorAttribKey, (v)) 
        match isRunning with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ActivityIndicatorIsRunningAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncActivityIndicator : (unit -> Xamarin.Forms.ActivityIndicator) = (fun () -> ViewBuilders.CreateActivityIndicator()) with get, set

    static member CreateActivityIndicator () : Xamarin.Forms.ActivityIndicator =
        new Xamarin.Forms.ActivityIndicator()

    static member val UpdateFuncActivityIndicator =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ActivityIndicator) -> ViewBuilders.UpdateActivityIndicator (prevOpt, curr, target)) 

    static member UpdateActivityIndicator (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ActivityIndicator) = 
        ViewBuilders.UpdateView (prevOpt, curr, target)
        let mutable prevActivityIndicatorColorOpt = ValueNone
        let mutable currActivityIndicatorColorOpt = ValueNone
        let mutable prevActivityIndicatorIsRunningOpt = ValueNone
        let mutable currActivityIndicatorIsRunningOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.ActivityIndicatorColorAttribKey.KeyValue then 
                currActivityIndicatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = ViewAttributes.ActivityIndicatorIsRunningAttribKey.KeyValue then 
                currActivityIndicatorIsRunningOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.ActivityIndicatorColorAttribKey.KeyValue then 
                    prevActivityIndicatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = ViewAttributes.ActivityIndicatorIsRunningAttribKey.KeyValue then 
                    prevActivityIndicatorIsRunningOpt <- ValueSome (kvp.Value :?> bool)

    static member inline ConstructActivityIndicator(?color: Xamarin.Forms.Color,
                                                    ?isRunning: bool,
                                                    ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                                    ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                                    ?margin: InputTypes.Thickness,
                                                    ?gestureRecognizers: ViewElement list,
                                                    ?anchorX: float,
                                                    ?anchorY: float,
                                                    ?backgroundColor: Xamarin.Forms.Color,
                                                    ?flowDirection: Xamarin.Forms.FlowDirection,
                                                    ?height: float,
                                                    ?inputTransparent: bool,
                                                    ?isEnabled: bool,
                                                    ?isTabStop: bool,
                                                    ?isVisible: bool,
                                                    ?minimumHeight: float,
                                                    ?minimumWidth: float,
                                                    ?opacity: float,
                                                    ?rotation: float,
                                                    ?rotationX: float,
                                                    ?rotationY: float,
                                                    ?scale: float,
                                                    ?scaleX: float,
                                                    ?scaleY: float,
                                                    ?tabIndex: int,
                                                    ?translationX: float,
                                                    ?translationY: float,
                                                    ?visual: Xamarin.Forms.IVisual,
                                                    ?width: float,
                                                    ?style: Xamarin.Forms.Style,
                                                    ?styleClass: InputTypes.StyleClass,
                                                    ?automationId: string,
                                                    ?classId: string,
                                                    ?styleId: string,
                                                    ?ref: ViewRef<Xamarin.Forms.ActivityIndicator>,
                                                    ?tag: obj,
                                                    ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                                    ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                                    ?created: (Xamarin.Forms.ActivityIndicator -> unit)) = 

        let attribBuilder = ViewBuilders.BuildActivityIndicator(0,
                               ?color=color,
                               ?isRunning=isRunning,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ActivityIndicator>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ActivityIndicator> target))))

        ViewElement.Create<Xamarin.Forms.ActivityIndicator>(ViewBuilders.CreateFuncActivityIndicator, ViewBuilders.UpdateFuncActivityIndicator, attribBuilder)

    /// Builds the attributes for a BoxView in the view
    static member inline BuildBoxView(attribCount: int,
                                      ?color: Xamarin.Forms.Color,
                                      ?cornerRadius: Xamarin.Forms.CornerRadius,
                                      ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                      ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                      ?margin: InputTypes.Thickness,
                                      ?gestureRecognizers: ViewElement list,
                                      ?anchorX: float,
                                      ?anchorY: float,
                                      ?backgroundColor: Xamarin.Forms.Color,
                                      ?flowDirection: Xamarin.Forms.FlowDirection,
                                      ?height: float,
                                      ?inputTransparent: bool,
                                      ?isEnabled: bool,
                                      ?isTabStop: bool,
                                      ?isVisible: bool,
                                      ?minimumHeight: float,
                                      ?minimumWidth: float,
                                      ?opacity: float,
                                      ?rotation: float,
                                      ?rotationX: float,
                                      ?rotationY: float,
                                      ?scale: float,
                                      ?scaleX: float,
                                      ?scaleY: float,
                                      ?tabIndex: int,
                                      ?translationX: float,
                                      ?translationY: float,
                                      ?visual: Xamarin.Forms.IVisual,
                                      ?width: float,
                                      ?style: Xamarin.Forms.Style,
                                      ?styleClass: InputTypes.StyleClass,
                                      ?automationId: string,
                                      ?classId: string,
                                      ?styleId: string,
                                      ?ref: ViewRef,
                                      ?tag: obj,
                                      ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                      ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                      ?created: obj -> unit) = 

        let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, 
                                                   ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, ?height: float, ?inputTransparent: bool, 
                                                   ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, ?minimumHeight: float, ?minimumWidth: float, 
                                                   ?opacity: float, ?rotation: float, ?rotationX: float, ?rotationY: float, ?scale: float, 
                                                   ?scaleX: float, ?scaleY: float, ?tabIndex: int, ?translationX: float, ?translationY: float, 
                                                   ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, 
                                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match color with None -> () | Some v -> attribBuilder.Add(ViewAttributes.BoxViewColorAttribKey, (v)) 
        match cornerRadius with None -> () | Some v -> attribBuilder.Add(ViewAttributes.BoxViewCornerRadiusAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncBoxView : (unit -> Xamarin.Forms.BoxView) = (fun () -> ViewBuilders.CreateBoxView()) with get, set

    static member CreateBoxView () : Xamarin.Forms.BoxView =
        new Xamarin.Forms.BoxView()

    static member val UpdateFuncBoxView =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.BoxView) -> ViewBuilders.UpdateBoxView (prevOpt, curr, target)) 

    static member UpdateBoxView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.BoxView) = 
        ViewBuilders.UpdateView (prevOpt, curr, target)
        let mutable prevBoxViewColorOpt = ValueNone
        let mutable currBoxViewColorOpt = ValueNone
        let mutable prevBoxViewCornerRadiusOpt = ValueNone
        let mutable currBoxViewCornerRadiusOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.BoxViewColorAttribKey.KeyValue then 
                currBoxViewColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = ViewAttributes.BoxViewCornerRadiusAttribKey.KeyValue then 
                currBoxViewCornerRadiusOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.CornerRadius)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.BoxViewColorAttribKey.KeyValue then 
                    prevBoxViewColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = ViewAttributes.BoxViewCornerRadiusAttribKey.KeyValue then 
                    prevBoxViewCornerRadiusOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.CornerRadius)

    static member inline ConstructBoxView(?color: Xamarin.Forms.Color,
                                          ?cornerRadius: Xamarin.Forms.CornerRadius,
                                          ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                          ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                          ?margin: InputTypes.Thickness,
                                          ?gestureRecognizers: ViewElement list,
                                          ?anchorX: float,
                                          ?anchorY: float,
                                          ?backgroundColor: Xamarin.Forms.Color,
                                          ?flowDirection: Xamarin.Forms.FlowDirection,
                                          ?height: float,
                                          ?inputTransparent: bool,
                                          ?isEnabled: bool,
                                          ?isTabStop: bool,
                                          ?isVisible: bool,
                                          ?minimumHeight: float,
                                          ?minimumWidth: float,
                                          ?opacity: float,
                                          ?rotation: float,
                                          ?rotationX: float,
                                          ?rotationY: float,
                                          ?scale: float,
                                          ?scaleX: float,
                                          ?scaleY: float,
                                          ?tabIndex: int,
                                          ?translationX: float,
                                          ?translationY: float,
                                          ?visual: Xamarin.Forms.IVisual,
                                          ?width: float,
                                          ?style: Xamarin.Forms.Style,
                                          ?styleClass: InputTypes.StyleClass,
                                          ?automationId: string,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?ref: ViewRef<Xamarin.Forms.BoxView>,
                                          ?tag: obj,
                                          ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                          ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                          ?created: (Xamarin.Forms.BoxView -> unit)) = 

        let attribBuilder = ViewBuilders.BuildBoxView(0,
                               ?color=color,
                               ?cornerRadius=cornerRadius,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.BoxView>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.BoxView> target))))

        ViewElement.Create<Xamarin.Forms.BoxView>(ViewBuilders.CreateFuncBoxView, ViewBuilders.UpdateFuncBoxView, attribBuilder)

    /// Builds the attributes for a ProgressBar in the view
    static member inline BuildProgressBar(attribCount: int,
                                          ?progress: float,
                                          ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                          ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                          ?margin: InputTypes.Thickness,
                                          ?gestureRecognizers: ViewElement list,
                                          ?anchorX: float,
                                          ?anchorY: float,
                                          ?backgroundColor: Xamarin.Forms.Color,
                                          ?flowDirection: Xamarin.Forms.FlowDirection,
                                          ?height: float,
                                          ?inputTransparent: bool,
                                          ?isEnabled: bool,
                                          ?isTabStop: bool,
                                          ?isVisible: bool,
                                          ?minimumHeight: float,
                                          ?minimumWidth: float,
                                          ?opacity: float,
                                          ?rotation: float,
                                          ?rotationX: float,
                                          ?rotationY: float,
                                          ?scale: float,
                                          ?scaleX: float,
                                          ?scaleY: float,
                                          ?tabIndex: int,
                                          ?translationX: float,
                                          ?translationY: float,
                                          ?visual: Xamarin.Forms.IVisual,
                                          ?width: float,
                                          ?style: Xamarin.Forms.Style,
                                          ?styleClass: InputTypes.StyleClass,
                                          ?automationId: string,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?ref: ViewRef,
                                          ?tag: obj,
                                          ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                          ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                          ?created: obj -> unit) = 

        let attribCount = match progress with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, 
                                                   ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, ?height: float, ?inputTransparent: bool, 
                                                   ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, ?minimumHeight: float, ?minimumWidth: float, 
                                                   ?opacity: float, ?rotation: float, ?rotationX: float, ?rotationY: float, ?scale: float, 
                                                   ?scaleX: float, ?scaleY: float, ?tabIndex: int, ?translationX: float, ?translationY: float, 
                                                   ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, 
                                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match progress with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ProgressBarProgressAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncProgressBar : (unit -> Xamarin.Forms.ProgressBar) = (fun () -> ViewBuilders.CreateProgressBar()) with get, set

    static member CreateProgressBar () : Xamarin.Forms.ProgressBar =
        new Xamarin.Forms.ProgressBar()

    static member val UpdateFuncProgressBar =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ProgressBar) -> ViewBuilders.UpdateProgressBar (prevOpt, curr, target)) 

    static member UpdateProgressBar (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ProgressBar) = 
        ViewBuilders.UpdateView (prevOpt, curr, target)
        let mutable prevProgressBarProgressOpt = ValueNone
        let mutable currProgressBarProgressOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.ProgressBarProgressAttribKey.KeyValue then 
                currProgressBarProgressOpt <- ValueSome (kvp.Value :?> float)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.ProgressBarProgressAttribKey.KeyValue then 
                    prevProgressBarProgressOpt <- ValueSome (kvp.Value :?> float)

    static member inline ConstructProgressBar(?progress: float,
                                              ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                              ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                              ?margin: InputTypes.Thickness,
                                              ?gestureRecognizers: ViewElement list,
                                              ?anchorX: float,
                                              ?anchorY: float,
                                              ?backgroundColor: Xamarin.Forms.Color,
                                              ?flowDirection: Xamarin.Forms.FlowDirection,
                                              ?height: float,
                                              ?inputTransparent: bool,
                                              ?isEnabled: bool,
                                              ?isTabStop: bool,
                                              ?isVisible: bool,
                                              ?minimumHeight: float,
                                              ?minimumWidth: float,
                                              ?opacity: float,
                                              ?rotation: float,
                                              ?rotationX: float,
                                              ?rotationY: float,
                                              ?scale: float,
                                              ?scaleX: float,
                                              ?scaleY: float,
                                              ?tabIndex: int,
                                              ?translationX: float,
                                              ?translationY: float,
                                              ?visual: Xamarin.Forms.IVisual,
                                              ?width: float,
                                              ?style: Xamarin.Forms.Style,
                                              ?styleClass: InputTypes.StyleClass,
                                              ?automationId: string,
                                              ?classId: string,
                                              ?styleId: string,
                                              ?ref: ViewRef<Xamarin.Forms.ProgressBar>,
                                              ?tag: obj,
                                              ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                              ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                              ?created: (Xamarin.Forms.ProgressBar -> unit)) = 

        let attribBuilder = ViewBuilders.BuildProgressBar(0,
                               ?progress=progress,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ProgressBar>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ProgressBar> target))))

        ViewElement.Create<Xamarin.Forms.ProgressBar>(ViewBuilders.CreateFuncProgressBar, ViewBuilders.UpdateFuncProgressBar, attribBuilder)

    /// Builds the attributes for a Layout in the view
    static member inline BuildLayout(attribCount: int,
                                     ?isClippedToBounds: bool,
                                     ?padding: Xamarin.Forms.Thickness,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: InputTypes.Thickness,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: float,
                                     ?anchorY: float,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?flowDirection: Xamarin.Forms.FlowDirection,
                                     ?height: float,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isTabStop: bool,
                                     ?isVisible: bool,
                                     ?minimumHeight: float,
                                     ?minimumWidth: float,
                                     ?opacity: float,
                                     ?rotation: float,
                                     ?rotationX: float,
                                     ?rotationY: float,
                                     ?scale: float,
                                     ?scaleX: float,
                                     ?scaleY: float,
                                     ?tabIndex: int,
                                     ?translationX: float,
                                     ?translationY: float,
                                     ?visual: Xamarin.Forms.IVisual,
                                     ?width: float,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: InputTypes.StyleClass,
                                     ?automationId: string,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?ref: ViewRef,
                                     ?tag: obj,
                                     ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?created: obj -> unit) = 

        let attribCount = match isClippedToBounds with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, 
                                                   ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, ?height: float, ?inputTransparent: bool, 
                                                   ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, ?minimumHeight: float, ?minimumWidth: float, 
                                                   ?opacity: float, ?rotation: float, ?rotationX: float, ?rotationY: float, ?scale: float, 
                                                   ?scaleX: float, ?scaleY: float, ?tabIndex: int, ?translationX: float, ?translationY: float, 
                                                   ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, 
                                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match isClippedToBounds with None -> () | Some v -> attribBuilder.Add(ViewAttributes.LayoutIsClippedToBoundsAttribKey, (v)) 
        match padding with None -> () | Some v -> attribBuilder.Add(ViewAttributes.LayoutPaddingAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncLayout : (unit -> Xamarin.Forms.Layout) = (fun () -> ViewBuilders.CreateLayout()) with get, set

    static member CreateLayout () : Xamarin.Forms.Layout =
        new Xamarin.Forms.Layout()

    static member val UpdateFuncLayout =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Layout) -> ViewBuilders.UpdateLayout (prevOpt, curr, target)) 

    static member UpdateLayout (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Layout) = 
        ViewBuilders.UpdateView (prevOpt, curr, target)
        let mutable prevLayoutIsClippedToBoundsOpt = ValueNone
        let mutable currLayoutIsClippedToBoundsOpt = ValueNone
        let mutable prevLayoutPaddingOpt = ValueNone
        let mutable currLayoutPaddingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.LayoutIsClippedToBoundsAttribKey.KeyValue then 
                currLayoutIsClippedToBoundsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.LayoutPaddingAttribKey.KeyValue then 
                currLayoutPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.LayoutIsClippedToBoundsAttribKey.KeyValue then 
                    prevLayoutIsClippedToBoundsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.LayoutPaddingAttribKey.KeyValue then 
                    prevLayoutPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)

    static member inline ConstructLayout(?isClippedToBounds: bool,
                                         ?padding: Xamarin.Forms.Thickness,
                                         ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                         ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                         ?margin: InputTypes.Thickness,
                                         ?gestureRecognizers: ViewElement list,
                                         ?anchorX: float,
                                         ?anchorY: float,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?flowDirection: Xamarin.Forms.FlowDirection,
                                         ?height: float,
                                         ?inputTransparent: bool,
                                         ?isEnabled: bool,
                                         ?isTabStop: bool,
                                         ?isVisible: bool,
                                         ?minimumHeight: float,
                                         ?minimumWidth: float,
                                         ?opacity: float,
                                         ?rotation: float,
                                         ?rotationX: float,
                                         ?rotationY: float,
                                         ?scale: float,
                                         ?scaleX: float,
                                         ?scaleY: float,
                                         ?tabIndex: int,
                                         ?translationX: float,
                                         ?translationY: float,
                                         ?visual: Xamarin.Forms.IVisual,
                                         ?width: float,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: InputTypes.StyleClass,
                                         ?automationId: string,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?ref: ViewRef<Xamarin.Forms.Layout>,
                                         ?tag: obj,
                                         ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?created: (Xamarin.Forms.Layout -> unit)) = 

        let attribBuilder = ViewBuilders.BuildLayout(0,
                               ?isClippedToBounds=isClippedToBounds,
                               ?padding=padding,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Layout>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Layout> target))))

        ViewElement.Create<Xamarin.Forms.Layout>(ViewBuilders.CreateFuncLayout, ViewBuilders.UpdateFuncLayout, attribBuilder)

    /// Builds the attributes for a ScrollView in the view
    static member inline BuildScrollView(attribCount: int,
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
                                         ?anchorY: float,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?flowDirection: Xamarin.Forms.FlowDirection,
                                         ?height: float,
                                         ?inputTransparent: bool,
                                         ?isEnabled: bool,
                                         ?isTabStop: bool,
                                         ?isVisible: bool,
                                         ?minimumHeight: float,
                                         ?minimumWidth: float,
                                         ?opacity: float,
                                         ?rotation: float,
                                         ?rotationX: float,
                                         ?rotationY: float,
                                         ?scale: float,
                                         ?scaleX: float,
                                         ?scaleY: float,
                                         ?tabIndex: int,
                                         ?translationX: float,
                                         ?translationY: float,
                                         ?visual: Xamarin.Forms.IVisual,
                                         ?width: float,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: InputTypes.StyleClass,
                                         ?automationId: string,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?ref: ViewRef,
                                         ?tag: obj,
                                         ?scrolled: Xamarin.Forms.ScrolledEventArgs -> unit,
                                         ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?created: obj -> unit) = 

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match orientation with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match horizontalScrollBarVisibility with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match verticalScrollBarVisibility with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scrollTo with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scrolled with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildLayout(attribCount, ?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, 
                                                     ?gestureRecognizers: ViewElement list, ?anchorX: float, ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, 
                                                     ?height: float, ?inputTransparent: bool, ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, 
                                                     ?minimumHeight: float, ?minimumWidth: float, ?opacity: float, ?rotation: float, ?rotationX: float, 
                                                     ?rotationY: float, ?scale: float, ?scaleX: float, ?scaleY: float, ?tabIndex: int, 
                                                     ?translationX: float, ?translationY: float, ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, 
                                                     ?styleClass: InputTypes.StyleClass, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                     ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match content with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewContentAttribKey, (v)) 
        match orientation with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewOrientationAttribKey, (v)) 
        match horizontalScrollBarVisibility with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewHorizontalScrollBarVisibilityAttribKey, (v)) 
        match verticalScrollBarVisibility with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewVerticalScrollBarVisibilityAttribKey, (v)) 
        match scrollTo with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewScrollToAttribKey, (v)) 
        match scrolled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewScrolledAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncScrollView : (unit -> Xamarin.Forms.ScrollView) = (fun () -> ViewBuilders.CreateScrollView()) with get, set

    static member CreateScrollView () : Xamarin.Forms.ScrollView =
        new Xamarin.Forms.ScrollView()

    static member val UpdateFuncScrollView =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ScrollView) -> ViewBuilders.UpdateScrollView (prevOpt, curr, target)) 

    static member UpdateScrollView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ScrollView) = 
        ViewBuilders.UpdateLayout (prevOpt, curr, target)
        let mutable prevScrollViewScrolledOpt = ValueNone
        let mutable currScrollViewScrolledOpt = ValueNone
        let mutable prevScrollViewContentOpt = ValueNone
        let mutable currScrollViewContentOpt = ValueNone
        let mutable prevScrollViewOrientationOpt = ValueNone
        let mutable currScrollViewOrientationOpt = ValueNone
        let mutable prevScrollViewHorizontalScrollBarVisibilityOpt = ValueNone
        let mutable currScrollViewHorizontalScrollBarVisibilityOpt = ValueNone
        let mutable prevScrollViewVerticalScrollBarVisibilityOpt = ValueNone
        let mutable currScrollViewVerticalScrollBarVisibilityOpt = ValueNone
        let mutable prevScrollViewScrollToOpt = ValueNone
        let mutable currScrollViewScrollToOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.ScrollViewScrolledAttribKey.KeyValue then 
                currScrollViewScrolledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ScrolledEventArgs>)
            if kvp.Key = ViewAttributes.ScrollViewContentAttribKey.KeyValue then 
                currScrollViewContentOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = ViewAttributes.ScrollViewOrientationAttribKey.KeyValue then 
                currScrollViewOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollOrientation)
            if kvp.Key = ViewAttributes.ScrollViewHorizontalScrollBarVisibilityAttribKey.KeyValue then 
                currScrollViewHorizontalScrollBarVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollBarVisibility)
            if kvp.Key = ViewAttributes.ScrollViewVerticalScrollBarVisibilityAttribKey.KeyValue then 
                currScrollViewVerticalScrollBarVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollBarVisibility)
            if kvp.Key = ViewAttributes.ScrollViewScrollToAttribKey.KeyValue then 
                currScrollViewScrollToOpt <- ValueSome (kvp.Value :?> double * double * InputTypes.AnimationKind)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.ScrollViewScrolledAttribKey.KeyValue then 
                    prevScrollViewScrolledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ScrolledEventArgs>)
                if kvp.Key = ViewAttributes.ScrollViewContentAttribKey.KeyValue then 
                    prevScrollViewContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = ViewAttributes.ScrollViewOrientationAttribKey.KeyValue then 
                    prevScrollViewOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollOrientation)
                if kvp.Key = ViewAttributes.ScrollViewHorizontalScrollBarVisibilityAttribKey.KeyValue then 
                    prevScrollViewHorizontalScrollBarVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollBarVisibility)
                if kvp.Key = ViewAttributes.ScrollViewVerticalScrollBarVisibilityAttribKey.KeyValue then 
                    prevScrollViewVerticalScrollBarVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollBarVisibility)
                if kvp.Key = ViewAttributes.ScrollViewScrollToAttribKey.KeyValue then 
                    prevScrollViewScrollToOpt <- ValueSome (kvp.Value :?> double * double * InputTypes.AnimationKind)
        let shouldUpdateScrollViewScrolled = not ((identical prevScrollViewScrolledOpt currScrollViewScrolledOpt))
        if shouldUpdateScrollViewScrolled then
            match prevScrollViewScrolledOpt with
            | ValueSome prevValue -> target.Scrolled.RemoveHandler(prevValue)
            | ValueNone -> ()
        if shouldUpdateScrollViewScrolled then
            match currScrollViewScrolledOpt with
            | ValueSome currValue -> target.Scrolled.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructScrollView(?content: ViewElement,
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
                                             ?anchorY: float,
                                             ?backgroundColor: Xamarin.Forms.Color,
                                             ?flowDirection: Xamarin.Forms.FlowDirection,
                                             ?height: float,
                                             ?inputTransparent: bool,
                                             ?isEnabled: bool,
                                             ?isTabStop: bool,
                                             ?isVisible: bool,
                                             ?minimumHeight: float,
                                             ?minimumWidth: float,
                                             ?opacity: float,
                                             ?rotation: float,
                                             ?rotationX: float,
                                             ?rotationY: float,
                                             ?scale: float,
                                             ?scaleX: float,
                                             ?scaleY: float,
                                             ?tabIndex: int,
                                             ?translationX: float,
                                             ?translationY: float,
                                             ?visual: Xamarin.Forms.IVisual,
                                             ?width: float,
                                             ?style: Xamarin.Forms.Style,
                                             ?styleClass: InputTypes.StyleClass,
                                             ?automationId: string,
                                             ?classId: string,
                                             ?styleId: string,
                                             ?ref: ViewRef<Xamarin.Forms.ScrollView>,
                                             ?tag: obj,
                                             ?scrolled: Xamarin.Forms.ScrolledEventArgs -> unit,
                                             ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                             ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                             ?created: (Xamarin.Forms.ScrollView -> unit)) = 

        let attribBuilder = ViewBuilders.BuildScrollView(0,
                               ?content=content,
                               ?orientation=orientation,
                               ?horizontalScrollBarVisibility=horizontalScrollBarVisibility,
                               ?verticalScrollBarVisibility=verticalScrollBarVisibility,
                               ?scrollTo=scrollTo,
                               ?isClippedToBounds=isClippedToBounds,
                               ?padding=padding,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ScrollView>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?scrolled=scrolled,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ScrollView> target))))

        ViewElement.Create<Xamarin.Forms.ScrollView>(ViewBuilders.CreateFuncScrollView, ViewBuilders.UpdateFuncScrollView, attribBuilder)

    /// Builds the attributes for a Button in the view
    static member inline BuildButton(attribCount: int,
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
                                     ?anchorY: float,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?flowDirection: Xamarin.Forms.FlowDirection,
                                     ?height: float,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isTabStop: bool,
                                     ?isVisible: bool,
                                     ?minimumHeight: float,
                                     ?minimumWidth: float,
                                     ?opacity: float,
                                     ?rotation: float,
                                     ?rotationX: float,
                                     ?rotationY: float,
                                     ?scale: float,
                                     ?scaleX: float,
                                     ?scaleY: float,
                                     ?tabIndex: int,
                                     ?translationX: float,
                                     ?translationY: float,
                                     ?visual: Xamarin.Forms.IVisual,
                                     ?width: float,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: InputTypes.StyleClass,
                                     ?automationId: string,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?ref: ViewRef,
                                     ?tag: obj,
                                     ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?created: obj -> unit) = 

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

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, 
                                                   ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, ?height: float, ?inputTransparent: bool, 
                                                   ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, ?minimumHeight: float, ?minimumWidth: float, 
                                                   ?opacity: float, ?rotation: float, ?rotationX: float, ?rotationY: float, ?scale: float, 
                                                   ?scaleX: float, ?scaleY: float, ?tabIndex: int, ?translationX: float, ?translationY: float, 
                                                   ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, 
                                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
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

    static member val CreateFuncButton : (unit -> Xamarin.Forms.Button) = (fun () -> ViewBuilders.CreateButton()) with get, set

    static member CreateButton () : Xamarin.Forms.Button =
        new Xamarin.Forms.Button()

    static member val UpdateFuncButton =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Button) -> ViewBuilders.UpdateButton (prevOpt, curr, target)) 

    static member UpdateButton (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Button) = 
        ViewBuilders.UpdateView (prevOpt, curr, target)
        let mutable prevButtonTextOpt = ValueNone
        let mutable currButtonTextOpt = ValueNone
        let mutable prevButtonCommandOpt = ValueNone
        let mutable currButtonCommandOpt = ValueNone
        let mutable prevButtonBorderColorOpt = ValueNone
        let mutable currButtonBorderColorOpt = ValueNone
        let mutable prevButtonBorderWidthOpt = ValueNone
        let mutable currButtonBorderWidthOpt = ValueNone
        let mutable prevButtonContentLayoutOpt = ValueNone
        let mutable currButtonContentLayoutOpt = ValueNone
        let mutable prevButtonCornerRadiusOpt = ValueNone
        let mutable currButtonCornerRadiusOpt = ValueNone
        let mutable prevButtonFontFamilyOpt = ValueNone
        let mutable currButtonFontFamilyOpt = ValueNone
        let mutable prevButtonFontAttributesOpt = ValueNone
        let mutable currButtonFontAttributesOpt = ValueNone
        let mutable prevButtonFontSizeOpt = ValueNone
        let mutable currButtonFontSizeOpt = ValueNone
        let mutable prevButtonImageOpt = ValueNone
        let mutable currButtonImageOpt = ValueNone
        let mutable prevButtonTextColorOpt = ValueNone
        let mutable currButtonTextColorOpt = ValueNone
        let mutable prevButtonPaddingOpt = ValueNone
        let mutable currButtonPaddingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.ButtonTextAttribKey.KeyValue then 
                currButtonTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = ViewAttributes.ButtonCommandAttribKey.KeyValue then 
                currButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
            if kvp.Key = ViewAttributes.ButtonBorderColorAttribKey.KeyValue then 
                currButtonBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = ViewAttributes.ButtonBorderWidthAttribKey.KeyValue then 
                currButtonBorderWidthOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.ButtonContentLayoutAttribKey.KeyValue then 
                currButtonContentLayoutOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Button.ButtonContentLayout)
            if kvp.Key = ViewAttributes.ButtonCornerRadiusAttribKey.KeyValue then 
                currButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.ButtonFontFamilyAttribKey.KeyValue then 
                currButtonFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = ViewAttributes.ButtonFontAttributesAttribKey.KeyValue then 
                currButtonFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = ViewAttributes.ButtonFontSizeAttribKey.KeyValue then 
                currButtonFontSizeOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.ButtonImageAttribKey.KeyValue then 
                currButtonImageOpt <- ValueSome (kvp.Value :?> InputTypes.Image)
            if kvp.Key = ViewAttributes.ButtonTextColorAttribKey.KeyValue then 
                currButtonTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = ViewAttributes.ButtonPaddingAttribKey.KeyValue then 
                currButtonPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.ButtonTextAttribKey.KeyValue then 
                    prevButtonTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = ViewAttributes.ButtonCommandAttribKey.KeyValue then 
                    prevButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = ViewAttributes.ButtonBorderColorAttribKey.KeyValue then 
                    prevButtonBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = ViewAttributes.ButtonBorderWidthAttribKey.KeyValue then 
                    prevButtonBorderWidthOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.ButtonContentLayoutAttribKey.KeyValue then 
                    prevButtonContentLayoutOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Button.ButtonContentLayout)
                if kvp.Key = ViewAttributes.ButtonCornerRadiusAttribKey.KeyValue then 
                    prevButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.ButtonFontFamilyAttribKey.KeyValue then 
                    prevButtonFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = ViewAttributes.ButtonFontAttributesAttribKey.KeyValue then 
                    prevButtonFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = ViewAttributes.ButtonFontSizeAttribKey.KeyValue then 
                    prevButtonFontSizeOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.ButtonImageAttribKey.KeyValue then 
                    prevButtonImageOpt <- ValueSome (kvp.Value :?> InputTypes.Image)
                if kvp.Key = ViewAttributes.ButtonTextColorAttribKey.KeyValue then 
                    prevButtonTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = ViewAttributes.ButtonPaddingAttribKey.KeyValue then 
                    prevButtonPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)

    static member inline ConstructButton(?text: string,
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
                                         ?anchorY: float,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?flowDirection: Xamarin.Forms.FlowDirection,
                                         ?height: float,
                                         ?inputTransparent: bool,
                                         ?isEnabled: bool,
                                         ?isTabStop: bool,
                                         ?isVisible: bool,
                                         ?minimumHeight: float,
                                         ?minimumWidth: float,
                                         ?opacity: float,
                                         ?rotation: float,
                                         ?rotationX: float,
                                         ?rotationY: float,
                                         ?scale: float,
                                         ?scaleX: float,
                                         ?scaleY: float,
                                         ?tabIndex: int,
                                         ?translationX: float,
                                         ?translationY: float,
                                         ?visual: Xamarin.Forms.IVisual,
                                         ?width: float,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: InputTypes.StyleClass,
                                         ?automationId: string,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?ref: ViewRef<Xamarin.Forms.Button>,
                                         ?tag: obj,
                                         ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?created: (Xamarin.Forms.Button -> unit)) = 

        let attribBuilder = ViewBuilders.BuildButton(0,
                               ?text=text,
                               ?command=command,
                               ?borderColor=borderColor,
                               ?borderWidth=borderWidth,
                               ?contentLayout=contentLayout,
                               ?cornerRadius=cornerRadius,
                               ?fontFamily=fontFamily,
                               ?fontAttributes=fontAttributes,
                               ?fontSize=fontSize,
                               ?image=image,
                               ?textColor=textColor,
                               ?padding=padding,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Button>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Button> target))))

        ViewElement.Create<Xamarin.Forms.Button>(ViewBuilders.CreateFuncButton, ViewBuilders.UpdateFuncButton, attribBuilder)

    /// Builds the attributes for a Slider in the view
    static member inline BuildSlider(attribCount: int,
                                     ?minimumMaximum: float * float,
                                     ?value: float,
                                     ?thumbImageSource: Xamarin.Forms.ImageSource,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: InputTypes.Thickness,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: float,
                                     ?anchorY: float,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?flowDirection: Xamarin.Forms.FlowDirection,
                                     ?height: float,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isTabStop: bool,
                                     ?isVisible: bool,
                                     ?minimumHeight: float,
                                     ?minimumWidth: float,
                                     ?opacity: float,
                                     ?rotation: float,
                                     ?rotationX: float,
                                     ?rotationY: float,
                                     ?scale: float,
                                     ?scaleX: float,
                                     ?scaleY: float,
                                     ?tabIndex: int,
                                     ?translationX: float,
                                     ?translationY: float,
                                     ?visual: Xamarin.Forms.IVisual,
                                     ?width: float,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: InputTypes.StyleClass,
                                     ?automationId: string,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?ref: ViewRef,
                                     ?tag: obj,
                                     ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit,
                                     ?dragCompleted: unit -> unit,
                                     ?dragStarted: unit -> unit,
                                     ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?created: obj -> unit) = 

        let attribCount = match minimumMaximum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match value with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match thumbImageSource with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match valueChanged with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match dragCompleted with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match dragStarted with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, 
                                                   ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, ?height: float, ?inputTransparent: bool, 
                                                   ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, ?minimumHeight: float, ?minimumWidth: float, 
                                                   ?opacity: float, ?rotation: float, ?rotationX: float, ?rotationY: float, ?scale: float, 
                                                   ?scaleX: float, ?scaleY: float, ?tabIndex: int, ?translationX: float, ?translationY: float, 
                                                   ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, 
                                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match minimumMaximum with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SliderMinimumMaximumAttribKey, (v)) 
        match value with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SliderValueAttribKey, (v)) 
        match thumbImageSource with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SliderThumbImageSourceAttribKey, (v)) 
        match valueChanged with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SliderValueChangedAttribKey, (v)) 
        match dragCompleted with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SliderDragCompletedAttribKey, (v)) 
        match dragStarted with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SliderDragStartedAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncSlider : (unit -> Xamarin.Forms.Slider) = (fun () -> ViewBuilders.CreateSlider()) with get, set

    static member CreateSlider () : Xamarin.Forms.Slider =
        new Xamarin.Forms.Slider()

    static member val UpdateFuncSlider =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Slider) -> ViewBuilders.UpdateSlider (prevOpt, curr, target)) 

    static member UpdateSlider (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Slider) = 
        ViewBuilders.UpdateView (prevOpt, curr, target)
        let mutable prevSliderValueChangedOpt = ValueNone
        let mutable currSliderValueChangedOpt = ValueNone
        let mutable prevSliderDragCompletedOpt = ValueNone
        let mutable currSliderDragCompletedOpt = ValueNone
        let mutable prevSliderDragStartedOpt = ValueNone
        let mutable currSliderDragStartedOpt = ValueNone
        let mutable prevSliderMinimumMaximumOpt = ValueNone
        let mutable currSliderMinimumMaximumOpt = ValueNone
        let mutable prevSliderValueOpt = ValueNone
        let mutable currSliderValueOpt = ValueNone
        let mutable prevSliderThumbImageSourceOpt = ValueNone
        let mutable currSliderThumbImageSourceOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.SliderValueChangedAttribKey.KeyValue then 
                currSliderValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
            if kvp.Key = ViewAttributes.SliderDragCompletedAttribKey.KeyValue then 
                currSliderDragCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = ViewAttributes.SliderDragStartedAttribKey.KeyValue then 
                currSliderDragStartedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = ViewAttributes.SliderMinimumMaximumAttribKey.KeyValue then 
                currSliderMinimumMaximumOpt <- ValueSome (kvp.Value :?> float * float)
            if kvp.Key = ViewAttributes.SliderValueAttribKey.KeyValue then 
                currSliderValueOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.SliderThumbImageSourceAttribKey.KeyValue then 
                currSliderThumbImageSourceOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ImageSource)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.SliderValueChangedAttribKey.KeyValue then 
                    prevSliderValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
                if kvp.Key = ViewAttributes.SliderDragCompletedAttribKey.KeyValue then 
                    prevSliderDragCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = ViewAttributes.SliderDragStartedAttribKey.KeyValue then 
                    prevSliderDragStartedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = ViewAttributes.SliderMinimumMaximumAttribKey.KeyValue then 
                    prevSliderMinimumMaximumOpt <- ValueSome (kvp.Value :?> float * float)
                if kvp.Key = ViewAttributes.SliderValueAttribKey.KeyValue then 
                    prevSliderValueOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.SliderThumbImageSourceAttribKey.KeyValue then 
                    prevSliderThumbImageSourceOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ImageSource)
        let shouldUpdateSliderValueChanged = not ((identical prevSliderValueChangedOpt currSliderValueChangedOpt) && (identical prevValueOpt currValueOpt))
        if shouldUpdateSliderValueChanged then
            match prevSliderValueChangedOpt with
            | ValueSome prevValue -> target.ValueChanged.RemoveHandler(prevValue)
            | ValueNone -> ()
        let shouldUpdateSliderDragCompleted = not ((identical prevSliderDragCompletedOpt currSliderDragCompletedOpt))
        if shouldUpdateSliderDragCompleted then
            match prevSliderDragCompletedOpt with
            | ValueSome prevValue -> target.DragCompleted.RemoveHandler(prevValue)
            | ValueNone -> ()
        let shouldUpdateSliderDragStarted = not ((identical prevSliderDragStartedOpt currSliderDragStartedOpt))
        if shouldUpdateSliderDragStarted then
            match prevSliderDragStartedOpt with
            | ValueSome prevValue -> target.DragStarted.RemoveHandler(prevValue)
            | ValueNone -> ()
        if shouldUpdateSliderValueChanged then
            match currSliderValueChangedOpt with
            | ValueSome currValue -> target.ValueChanged.AddHandler(currValue)
            | ValueNone -> ()
        if shouldUpdateSliderDragCompleted then
            match currSliderDragCompletedOpt with
            | ValueSome currValue -> target.DragCompleted.AddHandler(currValue)
            | ValueNone -> ()
        if shouldUpdateSliderDragStarted then
            match currSliderDragStartedOpt with
            | ValueSome currValue -> target.DragStarted.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructSlider(?minimumMaximum: float * float,
                                         ?value: float,
                                         ?thumbImageSource: Xamarin.Forms.ImageSource,
                                         ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                         ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                         ?margin: InputTypes.Thickness,
                                         ?gestureRecognizers: ViewElement list,
                                         ?anchorX: float,
                                         ?anchorY: float,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?flowDirection: Xamarin.Forms.FlowDirection,
                                         ?height: float,
                                         ?inputTransparent: bool,
                                         ?isEnabled: bool,
                                         ?isTabStop: bool,
                                         ?isVisible: bool,
                                         ?minimumHeight: float,
                                         ?minimumWidth: float,
                                         ?opacity: float,
                                         ?rotation: float,
                                         ?rotationX: float,
                                         ?rotationY: float,
                                         ?scale: float,
                                         ?scaleX: float,
                                         ?scaleY: float,
                                         ?tabIndex: int,
                                         ?translationX: float,
                                         ?translationY: float,
                                         ?visual: Xamarin.Forms.IVisual,
                                         ?width: float,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: InputTypes.StyleClass,
                                         ?automationId: string,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?ref: ViewRef<Xamarin.Forms.Slider>,
                                         ?tag: obj,
                                         ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit,
                                         ?dragCompleted: unit -> unit,
                                         ?dragStarted: unit -> unit,
                                         ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?created: (Xamarin.Forms.Slider -> unit)) = 

        let attribBuilder = ViewBuilders.BuildSlider(0,
                               ?minimumMaximum=minimumMaximum,
                               ?value=value,
                               ?thumbImageSource=thumbImageSource,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Slider>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?valueChanged=valueChanged,
                               ?dragCompleted=dragCompleted,
                               ?dragStarted=dragStarted,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Slider> target))))

        ViewElement.Create<Xamarin.Forms.Slider>(ViewBuilders.CreateFuncSlider, ViewBuilders.UpdateFuncSlider, attribBuilder)

/// Viewer that allows to read the properties of a ViewElement representing a Element
type ElementViewer(element: ViewElement) =
    do if not ((typeof<Xamarin.Forms.Element>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Element' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the AutomationId member
    member this.AutomationId = element.GetAttributeKeyed(ViewAttributes.ElementAutomationIdAttribKey)
    /// Get the value of the ClassId member
    member this.ClassId = element.GetAttributeKeyed(ViewAttributes.ElementClassIdAttribKey)
    /// Get the value of the StyleId member
    member this.StyleId = element.GetAttributeKeyed(ViewAttributes.ElementStyleIdAttribKey)
    /// Get the value of the Tag member
    member this.Tag = element.GetAttributeKeyed(ViewAttributes.ElementTagAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a NavigableElement
type NavigableElementViewer(element: ViewElement) =
    inherit ElementViewer(element)
    do if not ((typeof<Xamarin.Forms.NavigableElement>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.NavigableElement' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Style member
    member this.Style = element.GetAttributeKeyed(ViewAttributes.NavigableElementStyleAttribKey)
    /// Get the value of the StyleClass member
    member this.StyleClass = element.GetAttributeKeyed(ViewAttributes.NavigableElementStyleClassAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a VisualElement
type VisualElementViewer(element: ViewElement) =
    inherit NavigableElementViewer(element)
    do if not ((typeof<Xamarin.Forms.VisualElement>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.VisualElement' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the AnchorX member
    member this.AnchorX = element.GetAttributeKeyed(ViewAttributes.VisualElementAnchorXAttribKey)
    /// Get the value of the AnchorY member
    member this.AnchorY = element.GetAttributeKeyed(ViewAttributes.VisualElementAnchorYAttribKey)
    /// Get the value of the BackgroundColor member
    member this.BackgroundColor = element.GetAttributeKeyed(ViewAttributes.VisualElementBackgroundColorAttribKey)
    /// Get the value of the FlowDirection member
    member this.FlowDirection = element.GetAttributeKeyed(ViewAttributes.VisualElementFlowDirectionAttribKey)
    /// Get the value of the Height member
    member this.Height = element.GetAttributeKeyed(ViewAttributes.VisualElementHeightAttribKey)
    /// Get the value of the InputTransparent member
    member this.InputTransparent = element.GetAttributeKeyed(ViewAttributes.VisualElementInputTransparentAttribKey)
    /// Get the value of the IsEnabled member
    member this.IsEnabled = element.GetAttributeKeyed(ViewAttributes.VisualElementIsEnabledAttribKey)
    /// Get the value of the IsTabStop member
    member this.IsTabStop = element.GetAttributeKeyed(ViewAttributes.VisualElementIsTabStopAttribKey)
    /// Get the value of the IsVisible member
    member this.IsVisible = element.GetAttributeKeyed(ViewAttributes.VisualElementIsVisibleAttribKey)
    /// Get the value of the MinimumHeight member
    member this.MinimumHeight = element.GetAttributeKeyed(ViewAttributes.VisualElementMinimumHeightAttribKey)
    /// Get the value of the MinimumWidth member
    member this.MinimumWidth = element.GetAttributeKeyed(ViewAttributes.VisualElementMinimumWidthAttribKey)
    /// Get the value of the Opacity member
    member this.Opacity = element.GetAttributeKeyed(ViewAttributes.VisualElementOpacityAttribKey)
    /// Get the value of the Rotation member
    member this.Rotation = element.GetAttributeKeyed(ViewAttributes.VisualElementRotationAttribKey)
    /// Get the value of the RotationX member
    member this.RotationX = element.GetAttributeKeyed(ViewAttributes.VisualElementRotationXAttribKey)
    /// Get the value of the RotationY member
    member this.RotationY = element.GetAttributeKeyed(ViewAttributes.VisualElementRotationYAttribKey)
    /// Get the value of the Scale member
    member this.Scale = element.GetAttributeKeyed(ViewAttributes.VisualElementScaleAttribKey)
    /// Get the value of the ScaleX member
    member this.ScaleX = element.GetAttributeKeyed(ViewAttributes.VisualElementScaleXAttribKey)
    /// Get the value of the ScaleY member
    member this.ScaleY = element.GetAttributeKeyed(ViewAttributes.VisualElementScaleYAttribKey)
    /// Get the value of the TabIndex member
    member this.TabIndex = element.GetAttributeKeyed(ViewAttributes.VisualElementTabIndexAttribKey)
    /// Get the value of the TranslationX member
    member this.TranslationX = element.GetAttributeKeyed(ViewAttributes.VisualElementTranslationXAttribKey)
    /// Get the value of the TranslationY member
    member this.TranslationY = element.GetAttributeKeyed(ViewAttributes.VisualElementTranslationYAttribKey)
    /// Get the value of the Visual member
    member this.Visual = element.GetAttributeKeyed(ViewAttributes.VisualElementVisualAttribKey)
    /// Get the value of the Width member
    member this.Width = element.GetAttributeKeyed(ViewAttributes.VisualElementWidthAttribKey)
    /// Get the value of the Focused member
    member this.Focused = element.GetAttributeKeyed(ViewAttributes.VisualElementFocusedAttribKey)
    /// Get the value of the Unfocused member
    member this.Unfocused = element.GetAttributeKeyed(ViewAttributes.VisualElementUnfocusedAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a View
type ViewViewer(element: ViewElement) =
    inherit VisualElementViewer(element)
    do if not ((typeof<Xamarin.Forms.View>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.View' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the HorizontalOptions member
    member this.HorizontalOptions = element.GetAttributeKeyed(ViewAttributes.ViewHorizontalOptionsAttribKey)
    /// Get the value of the VerticalOptions member
    member this.VerticalOptions = element.GetAttributeKeyed(ViewAttributes.ViewVerticalOptionsAttribKey)
    /// Get the value of the Margin member
    member this.Margin = element.GetAttributeKeyed(ViewAttributes.ViewMarginAttribKey)
    /// Get the value of the GestureRecognizers member
    member this.GestureRecognizers = element.GetAttributeKeyed(ViewAttributes.ViewGestureRecognizersAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a GestureElement
type GestureElementViewer(element: ViewElement) =
    inherit ElementViewer(element)
    do if not ((typeof<Xamarin.Forms.GestureElement>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.GestureElement' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the GestureRecognizers member
    member this.GestureRecognizers = element.GetAttributeKeyed(ViewAttributes.GestureElementGestureRecognizersAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a PanGestureRecognizer
type PanGestureRecognizerViewer(element: ViewElement) =
    inherit ElementViewer(element)
    do if not ((typeof<Xamarin.Forms.PanGestureRecognizer>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.PanGestureRecognizer' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the TouchPoints member
    member this.TouchPoints = element.GetAttributeKeyed(ViewAttributes.PanGestureRecognizerTouchPointsAttribKey)
    /// Get the value of the PanUpdated member
    member this.PanUpdated = element.GetAttributeKeyed(ViewAttributes.PanGestureRecognizerPanUpdatedAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a ClickGestureRecognizer
type ClickGestureRecognizerViewer(element: ViewElement) =
    inherit ElementViewer(element)
    do if not ((typeof<Xamarin.Forms.ClickGestureRecognizer>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.ClickGestureRecognizer' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Command member
    member this.Command = element.GetAttributeKeyed(ViewAttributes.ClickGestureRecognizerCommandAttribKey)
    /// Get the value of the NumberOfClicksRequired member
    member this.NumberOfClicksRequired = element.GetAttributeKeyed(ViewAttributes.ClickGestureRecognizerNumberOfClicksRequiredAttribKey)
    /// Get the value of the Buttons member
    member this.Buttons = element.GetAttributeKeyed(ViewAttributes.ClickGestureRecognizerButtonsAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a PinchGestureRecognizer
type PinchGestureRecognizerViewer(element: ViewElement) =
    inherit ElementViewer(element)
    do if not ((typeof<Xamarin.Forms.PinchGestureRecognizer>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.PinchGestureRecognizer' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the PinchUpdated member
    member this.PinchUpdated = element.GetAttributeKeyed(ViewAttributes.PinchGestureRecognizerPinchUpdatedAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a SwipeGestureRecognizer
type SwipeGestureRecognizerViewer(element: ViewElement) =
    inherit ElementViewer(element)
    do if not ((typeof<Xamarin.Forms.SwipeGestureRecognizer>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.SwipeGestureRecognizer' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Command member
    member this.Command = element.GetAttributeKeyed(ViewAttributes.SwipeGestureRecognizerCommandAttribKey)
    /// Get the value of the Direction member
    member this.Direction = element.GetAttributeKeyed(ViewAttributes.SwipeGestureRecognizerDirectionAttribKey)
    /// Get the value of the Threshold member
    member this.Threshold = element.GetAttributeKeyed(ViewAttributes.SwipeGestureRecognizerThresholdAttribKey)
    /// Get the value of the Swiped member
    member this.Swiped = element.GetAttributeKeyed(ViewAttributes.SwipeGestureRecognizerSwipedAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a ActivityIndicator
type ActivityIndicatorViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<Xamarin.Forms.ActivityIndicator>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.ActivityIndicator' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Color member
    member this.Color = element.GetAttributeKeyed(ViewAttributes.ActivityIndicatorColorAttribKey)
    /// Get the value of the IsRunning member
    member this.IsRunning = element.GetAttributeKeyed(ViewAttributes.ActivityIndicatorIsRunningAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a BoxView
type BoxViewViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<Xamarin.Forms.BoxView>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.BoxView' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Color member
    member this.Color = element.GetAttributeKeyed(ViewAttributes.BoxViewColorAttribKey)
    /// Get the value of the CornerRadius member
    member this.CornerRadius = element.GetAttributeKeyed(ViewAttributes.BoxViewCornerRadiusAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a ProgressBar
type ProgressBarViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<Xamarin.Forms.ProgressBar>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.ProgressBar' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Progress member
    member this.Progress = element.GetAttributeKeyed(ViewAttributes.ProgressBarProgressAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a Layout
type LayoutViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<Xamarin.Forms.Layout>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Layout' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the IsClippedToBounds member
    member this.IsClippedToBounds = element.GetAttributeKeyed(ViewAttributes.LayoutIsClippedToBoundsAttribKey)
    /// Get the value of the Padding member
    member this.Padding = element.GetAttributeKeyed(ViewAttributes.LayoutPaddingAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a ScrollView
type ScrollViewViewer(element: ViewElement) =
    inherit LayoutViewer(element)
    do if not ((typeof<Xamarin.Forms.ScrollView>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.ScrollView' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Content member
    member this.Content = element.GetAttributeKeyed(ViewAttributes.ScrollViewContentAttribKey)
    /// Get the value of the Orientation member
    member this.Orientation = element.GetAttributeKeyed(ViewAttributes.ScrollViewOrientationAttribKey)
    /// Get the value of the HorizontalScrollBarVisibility member
    member this.HorizontalScrollBarVisibility = element.GetAttributeKeyed(ViewAttributes.ScrollViewHorizontalScrollBarVisibilityAttribKey)
    /// Get the value of the VerticalScrollBarVisibility member
    member this.VerticalScrollBarVisibility = element.GetAttributeKeyed(ViewAttributes.ScrollViewVerticalScrollBarVisibilityAttribKey)
    /// Get the value of the ScrollTo member
    member this.ScrollTo = element.GetAttributeKeyed(ViewAttributes.ScrollViewScrollToAttribKey)
    /// Get the value of the Scrolled member
    member this.Scrolled = element.GetAttributeKeyed(ViewAttributes.ScrollViewScrolledAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a Button
type ButtonViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<Xamarin.Forms.Button>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Button' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Text member
    member this.Text = element.GetAttributeKeyed(ViewAttributes.ButtonTextAttribKey)
    /// Get the value of the Command member
    member this.Command = element.GetAttributeKeyed(ViewAttributes.ButtonCommandAttribKey)
    /// Get the value of the BorderColor member
    member this.BorderColor = element.GetAttributeKeyed(ViewAttributes.ButtonBorderColorAttribKey)
    /// Get the value of the BorderWidth member
    member this.BorderWidth = element.GetAttributeKeyed(ViewAttributes.ButtonBorderWidthAttribKey)
    /// Get the value of the ContentLayout member
    member this.ContentLayout = element.GetAttributeKeyed(ViewAttributes.ButtonContentLayoutAttribKey)
    /// Get the value of the CornerRadius member
    member this.CornerRadius = element.GetAttributeKeyed(ViewAttributes.ButtonCornerRadiusAttribKey)
    /// Get the value of the FontFamily member
    member this.FontFamily = element.GetAttributeKeyed(ViewAttributes.ButtonFontFamilyAttribKey)
    /// Get the value of the FontAttributes member
    member this.FontAttributes = element.GetAttributeKeyed(ViewAttributes.ButtonFontAttributesAttribKey)
    /// Get the value of the FontSize member
    member this.FontSize = element.GetAttributeKeyed(ViewAttributes.ButtonFontSizeAttribKey)
    /// Get the value of the Image member
    member this.Image = element.GetAttributeKeyed(ViewAttributes.ButtonImageAttribKey)
    /// Get the value of the TextColor member
    member this.TextColor = element.GetAttributeKeyed(ViewAttributes.ButtonTextColorAttribKey)
    /// Get the value of the Padding member
    member this.Padding = element.GetAttributeKeyed(ViewAttributes.ButtonPaddingAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a Slider
type SliderViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<Xamarin.Forms.Slider>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Slider' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the MinimumMaximum member
    member this.MinimumMaximum = element.GetAttributeKeyed(ViewAttributes.SliderMinimumMaximumAttribKey)
    /// Get the value of the Value member
    member this.Value = element.GetAttributeKeyed(ViewAttributes.SliderValueAttribKey)
    /// Get the value of the ThumbImageSource member
    member this.ThumbImageSource = element.GetAttributeKeyed(ViewAttributes.SliderThumbImageSourceAttribKey)
    /// Get the value of the ValueChanged member
    member this.ValueChanged = element.GetAttributeKeyed(ViewAttributes.SliderValueChangedAttribKey)
    /// Get the value of the DragCompleted member
    member this.DragCompleted = element.GetAttributeKeyed(ViewAttributes.SliderDragCompletedAttribKey)
    /// Get the value of the DragStarted member
    member this.DragStarted = element.GetAttributeKeyed(ViewAttributes.SliderDragStartedAttribKey)

type View() =
    /// Describes a Element in the view
    static member inline Element(?automationId: string,
                                 ?classId: string,
                                 ?styleId: string,
                                 ?ref: ViewRef<Xamarin.Forms.Element>,
                                 ?tag: obj,
                                 ?created: (Xamarin.Forms.Element -> unit)) =

        ViewBuilders.ConstructElement(?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?created=created)

    /// Describes a NavigableElement in the view
    static member inline NavigableElement(?style: Xamarin.Forms.Style,
                                          ?styleClass: InputTypes.StyleClass,
                                          ?automationId: string,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?ref: ViewRef<Xamarin.Forms.NavigableElement>,
                                          ?tag: obj,
                                          ?created: (Xamarin.Forms.NavigableElement -> unit)) =

        ViewBuilders.ConstructNavigableElement(?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?created=created)

    /// Describes a VisualElement in the view
    static member inline VisualElement(?anchorX: float,
                                       ?anchorY: float,
                                       ?backgroundColor: Xamarin.Forms.Color,
                                       ?flowDirection: Xamarin.Forms.FlowDirection,
                                       ?height: float,
                                       ?inputTransparent: bool,
                                       ?isEnabled: bool,
                                       ?isTabStop: bool,
                                       ?isVisible: bool,
                                       ?minimumHeight: float,
                                       ?minimumWidth: float,
                                       ?opacity: float,
                                       ?rotation: float,
                                       ?rotationX: float,
                                       ?rotationY: float,
                                       ?scale: float,
                                       ?scaleX: float,
                                       ?scaleY: float,
                                       ?tabIndex: int,
                                       ?translationX: float,
                                       ?translationY: float,
                                       ?visual: Xamarin.Forms.IVisual,
                                       ?width: float,
                                       ?style: Xamarin.Forms.Style,
                                       ?styleClass: InputTypes.StyleClass,
                                       ?automationId: string,
                                       ?classId: string,
                                       ?styleId: string,
                                       ?ref: ViewRef<Xamarin.Forms.VisualElement>,
                                       ?tag: obj,
                                       ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                       ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                       ?created: (Xamarin.Forms.VisualElement -> unit)) =

        ViewBuilders.ConstructVisualElement(?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a View in the view
    static member inline View(?horizontalOptions: Xamarin.Forms.LayoutOptions,
                              ?verticalOptions: Xamarin.Forms.LayoutOptions,
                              ?margin: InputTypes.Thickness,
                              ?gestureRecognizers: ViewElement list,
                              ?anchorX: float,
                              ?anchorY: float,
                              ?backgroundColor: Xamarin.Forms.Color,
                              ?flowDirection: Xamarin.Forms.FlowDirection,
                              ?height: float,
                              ?inputTransparent: bool,
                              ?isEnabled: bool,
                              ?isTabStop: bool,
                              ?isVisible: bool,
                              ?minimumHeight: float,
                              ?minimumWidth: float,
                              ?opacity: float,
                              ?rotation: float,
                              ?rotationX: float,
                              ?rotationY: float,
                              ?scale: float,
                              ?scaleX: float,
                              ?scaleY: float,
                              ?tabIndex: int,
                              ?translationX: float,
                              ?translationY: float,
                              ?visual: Xamarin.Forms.IVisual,
                              ?width: float,
                              ?style: Xamarin.Forms.Style,
                              ?styleClass: InputTypes.StyleClass,
                              ?automationId: string,
                              ?classId: string,
                              ?styleId: string,
                              ?ref: ViewRef<Xamarin.Forms.View>,
                              ?tag: obj,
                              ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                              ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                              ?created: (Xamarin.Forms.View -> unit)) =

        ViewBuilders.ConstructView(?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a GestureElement in the view
    static member inline GestureElement(?gestureRecognizers: ViewElement list,
                                        ?automationId: string,
                                        ?classId: string,
                                        ?styleId: string,
                                        ?ref: ViewRef<Xamarin.Forms.GestureElement>,
                                        ?tag: obj,
                                        ?created: (Xamarin.Forms.GestureElement -> unit)) =

        ViewBuilders.ConstructGestureElement(?gestureRecognizers=gestureRecognizers,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?created=created)

    /// Describes a PanGestureRecognizer in the view
    static member inline PanGestureRecognizer(?touchPoints: int,
                                              ?automationId: string,
                                              ?classId: string,
                                              ?styleId: string,
                                              ?ref: ViewRef<Xamarin.Forms.PanGestureRecognizer>,
                                              ?tag: obj,
                                              ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit,
                                              ?created: (Xamarin.Forms.PanGestureRecognizer -> unit)) =

        ViewBuilders.ConstructPanGestureRecognizer(?touchPoints=touchPoints,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?panUpdated=panUpdated,
                               ?created=created)

    /// Describes a ClickGestureRecognizer in the view
    static member inline ClickGestureRecognizer(?command: unit -> unit,
                                                ?numberOfClicksRequired: int,
                                                ?buttons: Xamarin.Forms.ButtonsMask,
                                                ?automationId: string,
                                                ?classId: string,
                                                ?styleId: string,
                                                ?ref: ViewRef<Xamarin.Forms.ClickGestureRecognizer>,
                                                ?tag: obj,
                                                ?created: (Xamarin.Forms.ClickGestureRecognizer -> unit)) =

        ViewBuilders.ConstructClickGestureRecognizer(?command=command,
                               ?numberOfClicksRequired=numberOfClicksRequired,
                               ?buttons=buttons,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?created=created)

    /// Describes a PinchGestureRecognizer in the view
    static member inline PinchGestureRecognizer(?automationId: string,
                                                ?classId: string,
                                                ?styleId: string,
                                                ?ref: ViewRef<Xamarin.Forms.PinchGestureRecognizer>,
                                                ?tag: obj,
                                                ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit,
                                                ?created: (Xamarin.Forms.PinchGestureRecognizer -> unit)) =

        ViewBuilders.ConstructPinchGestureRecognizer(?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?pinchUpdated=pinchUpdated,
                               ?created=created)

    /// Describes a SwipeGestureRecognizer in the view
    static member inline SwipeGestureRecognizer(?command: unit -> unit,
                                                ?direction: Xamarin.Forms.SwipeDirection,
                                                ?threshold: uint32,
                                                ?automationId: string,
                                                ?classId: string,
                                                ?styleId: string,
                                                ?ref: ViewRef<Xamarin.Forms.SwipeGestureRecognizer>,
                                                ?tag: obj,
                                                ?swiped: Xamarin.Forms.SwipedEventArgs -> unit,
                                                ?created: (Xamarin.Forms.SwipeGestureRecognizer -> unit)) =

        ViewBuilders.ConstructSwipeGestureRecognizer(?command=command,
                               ?direction=direction,
                               ?threshold=threshold,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?swiped=swiped,
                               ?created=created)

    /// Describes a ActivityIndicator in the view
    static member inline ActivityIndicator(?color: Xamarin.Forms.Color,
                                           ?isRunning: bool,
                                           ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                           ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                           ?margin: InputTypes.Thickness,
                                           ?gestureRecognizers: ViewElement list,
                                           ?anchorX: float,
                                           ?anchorY: float,
                                           ?backgroundColor: Xamarin.Forms.Color,
                                           ?flowDirection: Xamarin.Forms.FlowDirection,
                                           ?height: float,
                                           ?inputTransparent: bool,
                                           ?isEnabled: bool,
                                           ?isTabStop: bool,
                                           ?isVisible: bool,
                                           ?minimumHeight: float,
                                           ?minimumWidth: float,
                                           ?opacity: float,
                                           ?rotation: float,
                                           ?rotationX: float,
                                           ?rotationY: float,
                                           ?scale: float,
                                           ?scaleX: float,
                                           ?scaleY: float,
                                           ?tabIndex: int,
                                           ?translationX: float,
                                           ?translationY: float,
                                           ?visual: Xamarin.Forms.IVisual,
                                           ?width: float,
                                           ?style: Xamarin.Forms.Style,
                                           ?styleClass: InputTypes.StyleClass,
                                           ?automationId: string,
                                           ?classId: string,
                                           ?styleId: string,
                                           ?ref: ViewRef<Xamarin.Forms.ActivityIndicator>,
                                           ?tag: obj,
                                           ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                           ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                           ?created: (Xamarin.Forms.ActivityIndicator -> unit)) =

        ViewBuilders.ConstructActivityIndicator(?color=color,
                               ?isRunning=isRunning,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a BoxView in the view
    static member inline BoxView(?color: Xamarin.Forms.Color,
                                 ?cornerRadius: Xamarin.Forms.CornerRadius,
                                 ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                 ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                 ?margin: InputTypes.Thickness,
                                 ?gestureRecognizers: ViewElement list,
                                 ?anchorX: float,
                                 ?anchorY: float,
                                 ?backgroundColor: Xamarin.Forms.Color,
                                 ?flowDirection: Xamarin.Forms.FlowDirection,
                                 ?height: float,
                                 ?inputTransparent: bool,
                                 ?isEnabled: bool,
                                 ?isTabStop: bool,
                                 ?isVisible: bool,
                                 ?minimumHeight: float,
                                 ?minimumWidth: float,
                                 ?opacity: float,
                                 ?rotation: float,
                                 ?rotationX: float,
                                 ?rotationY: float,
                                 ?scale: float,
                                 ?scaleX: float,
                                 ?scaleY: float,
                                 ?tabIndex: int,
                                 ?translationX: float,
                                 ?translationY: float,
                                 ?visual: Xamarin.Forms.IVisual,
                                 ?width: float,
                                 ?style: Xamarin.Forms.Style,
                                 ?styleClass: InputTypes.StyleClass,
                                 ?automationId: string,
                                 ?classId: string,
                                 ?styleId: string,
                                 ?ref: ViewRef<Xamarin.Forms.BoxView>,
                                 ?tag: obj,
                                 ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                 ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                 ?created: (Xamarin.Forms.BoxView -> unit)) =

        ViewBuilders.ConstructBoxView(?color=color,
                               ?cornerRadius=cornerRadius,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a ProgressBar in the view
    static member inline ProgressBar(?progress: float,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: InputTypes.Thickness,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: float,
                                     ?anchorY: float,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?flowDirection: Xamarin.Forms.FlowDirection,
                                     ?height: float,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isTabStop: bool,
                                     ?isVisible: bool,
                                     ?minimumHeight: float,
                                     ?minimumWidth: float,
                                     ?opacity: float,
                                     ?rotation: float,
                                     ?rotationX: float,
                                     ?rotationY: float,
                                     ?scale: float,
                                     ?scaleX: float,
                                     ?scaleY: float,
                                     ?tabIndex: int,
                                     ?translationX: float,
                                     ?translationY: float,
                                     ?visual: Xamarin.Forms.IVisual,
                                     ?width: float,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: InputTypes.StyleClass,
                                     ?automationId: string,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?ref: ViewRef<Xamarin.Forms.ProgressBar>,
                                     ?tag: obj,
                                     ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?created: (Xamarin.Forms.ProgressBar -> unit)) =

        ViewBuilders.ConstructProgressBar(?progress=progress,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a Layout in the view
    static member inline Layout(?isClippedToBounds: bool,
                                ?padding: Xamarin.Forms.Thickness,
                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                ?margin: InputTypes.Thickness,
                                ?gestureRecognizers: ViewElement list,
                                ?anchorX: float,
                                ?anchorY: float,
                                ?backgroundColor: Xamarin.Forms.Color,
                                ?flowDirection: Xamarin.Forms.FlowDirection,
                                ?height: float,
                                ?inputTransparent: bool,
                                ?isEnabled: bool,
                                ?isTabStop: bool,
                                ?isVisible: bool,
                                ?minimumHeight: float,
                                ?minimumWidth: float,
                                ?opacity: float,
                                ?rotation: float,
                                ?rotationX: float,
                                ?rotationY: float,
                                ?scale: float,
                                ?scaleX: float,
                                ?scaleY: float,
                                ?tabIndex: int,
                                ?translationX: float,
                                ?translationY: float,
                                ?visual: Xamarin.Forms.IVisual,
                                ?width: float,
                                ?style: Xamarin.Forms.Style,
                                ?styleClass: InputTypes.StyleClass,
                                ?automationId: string,
                                ?classId: string,
                                ?styleId: string,
                                ?ref: ViewRef<Xamarin.Forms.Layout>,
                                ?tag: obj,
                                ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                ?created: (Xamarin.Forms.Layout -> unit)) =

        ViewBuilders.ConstructLayout(?isClippedToBounds=isClippedToBounds,
                               ?padding=padding,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a ScrollView in the view
    static member inline ScrollView(?content: ViewElement,
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
                                    ?anchorY: float,
                                    ?backgroundColor: Xamarin.Forms.Color,
                                    ?flowDirection: Xamarin.Forms.FlowDirection,
                                    ?height: float,
                                    ?inputTransparent: bool,
                                    ?isEnabled: bool,
                                    ?isTabStop: bool,
                                    ?isVisible: bool,
                                    ?minimumHeight: float,
                                    ?minimumWidth: float,
                                    ?opacity: float,
                                    ?rotation: float,
                                    ?rotationX: float,
                                    ?rotationY: float,
                                    ?scale: float,
                                    ?scaleX: float,
                                    ?scaleY: float,
                                    ?tabIndex: int,
                                    ?translationX: float,
                                    ?translationY: float,
                                    ?visual: Xamarin.Forms.IVisual,
                                    ?width: float,
                                    ?style: Xamarin.Forms.Style,
                                    ?styleClass: InputTypes.StyleClass,
                                    ?automationId: string,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?ref: ViewRef<Xamarin.Forms.ScrollView>,
                                    ?tag: obj,
                                    ?scrolled: Xamarin.Forms.ScrolledEventArgs -> unit,
                                    ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                    ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                    ?created: (Xamarin.Forms.ScrollView -> unit)) =

        ViewBuilders.ConstructScrollView(?content=content,
                               ?orientation=orientation,
                               ?horizontalScrollBarVisibility=horizontalScrollBarVisibility,
                               ?verticalScrollBarVisibility=verticalScrollBarVisibility,
                               ?scrollTo=scrollTo,
                               ?isClippedToBounds=isClippedToBounds,
                               ?padding=padding,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?scrolled=scrolled,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a Button in the view
    static member inline Button(?text: string,
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
                                ?anchorY: float,
                                ?backgroundColor: Xamarin.Forms.Color,
                                ?flowDirection: Xamarin.Forms.FlowDirection,
                                ?height: float,
                                ?inputTransparent: bool,
                                ?isEnabled: bool,
                                ?isTabStop: bool,
                                ?isVisible: bool,
                                ?minimumHeight: float,
                                ?minimumWidth: float,
                                ?opacity: float,
                                ?rotation: float,
                                ?rotationX: float,
                                ?rotationY: float,
                                ?scale: float,
                                ?scaleX: float,
                                ?scaleY: float,
                                ?tabIndex: int,
                                ?translationX: float,
                                ?translationY: float,
                                ?visual: Xamarin.Forms.IVisual,
                                ?width: float,
                                ?style: Xamarin.Forms.Style,
                                ?styleClass: InputTypes.StyleClass,
                                ?automationId: string,
                                ?classId: string,
                                ?styleId: string,
                                ?ref: ViewRef<Xamarin.Forms.Button>,
                                ?tag: obj,
                                ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                ?created: (Xamarin.Forms.Button -> unit)) =

        ViewBuilders.ConstructButton(?text=text,
                               ?command=command,
                               ?borderColor=borderColor,
                               ?borderWidth=borderWidth,
                               ?contentLayout=contentLayout,
                               ?cornerRadius=cornerRadius,
                               ?fontFamily=fontFamily,
                               ?fontAttributes=fontAttributes,
                               ?fontSize=fontSize,
                               ?image=image,
                               ?textColor=textColor,
                               ?padding=padding,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a Slider in the view
    static member inline Slider(?minimumMaximum: float * float,
                                ?value: float,
                                ?thumbImageSource: Xamarin.Forms.ImageSource,
                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                ?margin: InputTypes.Thickness,
                                ?gestureRecognizers: ViewElement list,
                                ?anchorX: float,
                                ?anchorY: float,
                                ?backgroundColor: Xamarin.Forms.Color,
                                ?flowDirection: Xamarin.Forms.FlowDirection,
                                ?height: float,
                                ?inputTransparent: bool,
                                ?isEnabled: bool,
                                ?isTabStop: bool,
                                ?isVisible: bool,
                                ?minimumHeight: float,
                                ?minimumWidth: float,
                                ?opacity: float,
                                ?rotation: float,
                                ?rotationX: float,
                                ?rotationY: float,
                                ?scale: float,
                                ?scaleX: float,
                                ?scaleY: float,
                                ?tabIndex: int,
                                ?translationX: float,
                                ?translationY: float,
                                ?visual: Xamarin.Forms.IVisual,
                                ?width: float,
                                ?style: Xamarin.Forms.Style,
                                ?styleClass: InputTypes.StyleClass,
                                ?automationId: string,
                                ?classId: string,
                                ?styleId: string,
                                ?ref: ViewRef<Xamarin.Forms.Slider>,
                                ?tag: obj,
                                ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit,
                                ?dragCompleted: unit -> unit,
                                ?dragStarted: unit -> unit,
                                ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                ?created: (Xamarin.Forms.Slider -> unit)) =

        ViewBuilders.ConstructSlider(?minimumMaximum=minimumMaximum,
                               ?value=value,
                               ?thumbImageSource=thumbImageSource,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?flowDirection=flowDirection,
                               ?height=height,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isTabStop=isTabStop,
                               ?isVisible=isVisible,
                               ?minimumHeight=minimumHeight,
                               ?minimumWidth=minimumWidth,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?visual=visual,
                               ?width=width,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?valueChanged=valueChanged,
                               ?dragCompleted=dragCompleted,
                               ?dragStarted=dragStarted,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)


[<AutoOpen>]
module ViewElementExtensions = 

    type ViewElement with

        /// Adjusts the ElementAutomationId property in the visual element
        member x.ElementAutomationId(value: string) = x.WithAttribute(ViewAttributes.ElementAutomationIdAttribKey, (value))

        /// Adjusts the ElementClassId property in the visual element
        member x.ElementClassId(value: string) = x.WithAttribute(ViewAttributes.ElementClassIdAttribKey, (value))

        /// Adjusts the ElementStyleId property in the visual element
        member x.ElementStyleId(value: string) = x.WithAttribute(ViewAttributes.ElementStyleIdAttribKey, (value))

        /// Adjusts the ElementTag property in the visual element
        member x.ElementTag(value: obj) = x.WithAttribute(ViewAttributes.ElementTagAttribKey, (value))

        /// Adjusts the NavigableElementStyle property in the visual element
        member x.NavigableElementStyle(value: Xamarin.Forms.Style) = x.WithAttribute(ViewAttributes.NavigableElementStyleAttribKey, (value))

        /// Adjusts the NavigableElementStyleClass property in the visual element
        member x.NavigableElementStyleClass(value: InputTypes.StyleClass) = x.WithAttribute(ViewAttributes.NavigableElementStyleClassAttribKey, (value))

        /// Adjusts the VisualElementAnchorX property in the visual element
        member x.VisualElementAnchorX(value: float) = x.WithAttribute(ViewAttributes.VisualElementAnchorXAttribKey, (value))

        /// Adjusts the VisualElementAnchorY property in the visual element
        member x.VisualElementAnchorY(value: float) = x.WithAttribute(ViewAttributes.VisualElementAnchorYAttribKey, (value))

        /// Adjusts the VisualElementBackgroundColor property in the visual element
        member x.VisualElementBackgroundColor(value: Xamarin.Forms.Color) = x.WithAttribute(ViewAttributes.VisualElementBackgroundColorAttribKey, (value))

        /// Adjusts the VisualElementFlowDirection property in the visual element
        member x.VisualElementFlowDirection(value: Xamarin.Forms.FlowDirection) = x.WithAttribute(ViewAttributes.VisualElementFlowDirectionAttribKey, (value))

        /// Adjusts the VisualElementHeight property in the visual element
        member x.VisualElementHeight(value: float) = x.WithAttribute(ViewAttributes.VisualElementHeightAttribKey, (value))

        /// Adjusts the VisualElementInputTransparent property in the visual element
        member x.VisualElementInputTransparent(value: bool) = x.WithAttribute(ViewAttributes.VisualElementInputTransparentAttribKey, (value))

        /// Adjusts the VisualElementIsEnabled property in the visual element
        member x.VisualElementIsEnabled(value: bool) = x.WithAttribute(ViewAttributes.VisualElementIsEnabledAttribKey, (value))

        /// Adjusts the VisualElementIsTabStop property in the visual element
        member x.VisualElementIsTabStop(value: bool) = x.WithAttribute(ViewAttributes.VisualElementIsTabStopAttribKey, (value))

        /// Adjusts the VisualElementIsVisible property in the visual element
        member x.VisualElementIsVisible(value: bool) = x.WithAttribute(ViewAttributes.VisualElementIsVisibleAttribKey, (value))

        /// Adjusts the VisualElementMinimumHeight property in the visual element
        member x.VisualElementMinimumHeight(value: float) = x.WithAttribute(ViewAttributes.VisualElementMinimumHeightAttribKey, (value))

        /// Adjusts the VisualElementMinimumWidth property in the visual element
        member x.VisualElementMinimumWidth(value: float) = x.WithAttribute(ViewAttributes.VisualElementMinimumWidthAttribKey, (value))

        /// Adjusts the VisualElementOpacity property in the visual element
        member x.VisualElementOpacity(value: float) = x.WithAttribute(ViewAttributes.VisualElementOpacityAttribKey, (value))

        /// Adjusts the VisualElementRotation property in the visual element
        member x.VisualElementRotation(value: float) = x.WithAttribute(ViewAttributes.VisualElementRotationAttribKey, (value))

        /// Adjusts the VisualElementRotationX property in the visual element
        member x.VisualElementRotationX(value: float) = x.WithAttribute(ViewAttributes.VisualElementRotationXAttribKey, (value))

        /// Adjusts the VisualElementRotationY property in the visual element
        member x.VisualElementRotationY(value: float) = x.WithAttribute(ViewAttributes.VisualElementRotationYAttribKey, (value))

        /// Adjusts the VisualElementScale property in the visual element
        member x.VisualElementScale(value: float) = x.WithAttribute(ViewAttributes.VisualElementScaleAttribKey, (value))

        /// Adjusts the VisualElementScaleX property in the visual element
        member x.VisualElementScaleX(value: float) = x.WithAttribute(ViewAttributes.VisualElementScaleXAttribKey, (value))

        /// Adjusts the VisualElementScaleY property in the visual element
        member x.VisualElementScaleY(value: float) = x.WithAttribute(ViewAttributes.VisualElementScaleYAttribKey, (value))

        /// Adjusts the VisualElementTabIndex property in the visual element
        member x.VisualElementTabIndex(value: int) = x.WithAttribute(ViewAttributes.VisualElementTabIndexAttribKey, (value))

        /// Adjusts the VisualElementTranslationX property in the visual element
        member x.VisualElementTranslationX(value: float) = x.WithAttribute(ViewAttributes.VisualElementTranslationXAttribKey, (value))

        /// Adjusts the VisualElementTranslationY property in the visual element
        member x.VisualElementTranslationY(value: float) = x.WithAttribute(ViewAttributes.VisualElementTranslationYAttribKey, (value))

        /// Adjusts the VisualElementVisual property in the visual element
        member x.VisualElementVisual(value: Xamarin.Forms.IVisual) = x.WithAttribute(ViewAttributes.VisualElementVisualAttribKey, (value))

        /// Adjusts the VisualElementWidth property in the visual element
        member x.VisualElementWidth(value: float) = x.WithAttribute(ViewAttributes.VisualElementWidthAttribKey, (value))

        /// Adjusts the VisualElementFocused property in the visual element
        member x.VisualElementFocused(value: Xamarin.Forms.FocusEventArgs -> unit) = x.WithAttribute(ViewAttributes.VisualElementFocusedAttribKey, (value))

        /// Adjusts the VisualElementUnfocused property in the visual element
        member x.VisualElementUnfocused(value: Xamarin.Forms.FocusEventArgs -> unit) = x.WithAttribute(ViewAttributes.VisualElementUnfocusedAttribKey, (value))

        /// Adjusts the ViewHorizontalOptions property in the visual element
        member x.ViewHorizontalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttribute(ViewAttributes.ViewHorizontalOptionsAttribKey, (value))

        /// Adjusts the ViewVerticalOptions property in the visual element
        member x.ViewVerticalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttribute(ViewAttributes.ViewVerticalOptionsAttribKey, (value))

        /// Adjusts the ViewMargin property in the visual element
        member x.ViewMargin(value: InputTypes.Thickness) = x.WithAttribute(ViewAttributes.ViewMarginAttribKey, (value))

        /// Adjusts the ViewGestureRecognizers property in the visual element
        member x.ViewGestureRecognizers(value: ViewElement list) = x.WithAttribute(ViewAttributes.ViewGestureRecognizersAttribKey, (value))

        /// Adjusts the GestureElementGestureRecognizers property in the visual element
        member x.GestureElementGestureRecognizers(value: ViewElement list) = x.WithAttribute(ViewAttributes.GestureElementGestureRecognizersAttribKey, (value))

        /// Adjusts the PanGestureRecognizerTouchPoints property in the visual element
        member x.PanGestureRecognizerTouchPoints(value: int) = x.WithAttribute(ViewAttributes.PanGestureRecognizerTouchPointsAttribKey, (value))

        /// Adjusts the PanGestureRecognizerPanUpdated property in the visual element
        member x.PanGestureRecognizerPanUpdated(value: Xamarin.Forms.PanUpdatedEventArgs -> unit) = x.WithAttribute(ViewAttributes.PanGestureRecognizerPanUpdatedAttribKey, (value))

        /// Adjusts the ClickGestureRecognizerCommand property in the visual element
        member x.ClickGestureRecognizerCommand(value: unit -> unit) = x.WithAttribute(ViewAttributes.ClickGestureRecognizerCommandAttribKey, (value))

        /// Adjusts the ClickGestureRecognizerNumberOfClicksRequired property in the visual element
        member x.ClickGestureRecognizerNumberOfClicksRequired(value: int) = x.WithAttribute(ViewAttributes.ClickGestureRecognizerNumberOfClicksRequiredAttribKey, (value))

        /// Adjusts the ClickGestureRecognizerButtons property in the visual element
        member x.ClickGestureRecognizerButtons(value: Xamarin.Forms.ButtonsMask) = x.WithAttribute(ViewAttributes.ClickGestureRecognizerButtonsAttribKey, (value))

        /// Adjusts the PinchGestureRecognizerPinchUpdated property in the visual element
        member x.PinchGestureRecognizerPinchUpdated(value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) = x.WithAttribute(ViewAttributes.PinchGestureRecognizerPinchUpdatedAttribKey, (value))

        /// Adjusts the SwipeGestureRecognizerCommand property in the visual element
        member x.SwipeGestureRecognizerCommand(value: unit -> unit) = x.WithAttribute(ViewAttributes.SwipeGestureRecognizerCommandAttribKey, (value))

        /// Adjusts the SwipeGestureRecognizerDirection property in the visual element
        member x.SwipeGestureRecognizerDirection(value: Xamarin.Forms.SwipeDirection) = x.WithAttribute(ViewAttributes.SwipeGestureRecognizerDirectionAttribKey, (value))

        /// Adjusts the SwipeGestureRecognizerThreshold property in the visual element
        member x.SwipeGestureRecognizerThreshold(value: uint32) = x.WithAttribute(ViewAttributes.SwipeGestureRecognizerThresholdAttribKey, (value))

        /// Adjusts the SwipeGestureRecognizerSwiped property in the visual element
        member x.SwipeGestureRecognizerSwiped(value: Xamarin.Forms.SwipedEventArgs -> unit) = x.WithAttribute(ViewAttributes.SwipeGestureRecognizerSwipedAttribKey, (value))

        /// Adjusts the ActivityIndicatorColor property in the visual element
        member x.ActivityIndicatorColor(value: Xamarin.Forms.Color) = x.WithAttribute(ViewAttributes.ActivityIndicatorColorAttribKey, (value))

        /// Adjusts the ActivityIndicatorIsRunning property in the visual element
        member x.ActivityIndicatorIsRunning(value: bool) = x.WithAttribute(ViewAttributes.ActivityIndicatorIsRunningAttribKey, (value))

        /// Adjusts the BoxViewColor property in the visual element
        member x.BoxViewColor(value: Xamarin.Forms.Color) = x.WithAttribute(ViewAttributes.BoxViewColorAttribKey, (value))

        /// Adjusts the BoxViewCornerRadius property in the visual element
        member x.BoxViewCornerRadius(value: Xamarin.Forms.CornerRadius) = x.WithAttribute(ViewAttributes.BoxViewCornerRadiusAttribKey, (value))

        /// Adjusts the ProgressBarProgress property in the visual element
        member x.ProgressBarProgress(value: float) = x.WithAttribute(ViewAttributes.ProgressBarProgressAttribKey, (value))

        /// Adjusts the LayoutIsClippedToBounds property in the visual element
        member x.LayoutIsClippedToBounds(value: bool) = x.WithAttribute(ViewAttributes.LayoutIsClippedToBoundsAttribKey, (value))

        /// Adjusts the LayoutPadding property in the visual element
        member x.LayoutPadding(value: Xamarin.Forms.Thickness) = x.WithAttribute(ViewAttributes.LayoutPaddingAttribKey, (value))

        /// Adjusts the ScrollViewContent property in the visual element
        member x.ScrollViewContent(value: ViewElement) = x.WithAttribute(ViewAttributes.ScrollViewContentAttribKey, (value))

        /// Adjusts the ScrollViewOrientation property in the visual element
        member x.ScrollViewOrientation(value: Xamarin.Forms.ScrollOrientation) = x.WithAttribute(ViewAttributes.ScrollViewOrientationAttribKey, (value))

        /// Adjusts the ScrollViewHorizontalScrollBarVisibility property in the visual element
        member x.ScrollViewHorizontalScrollBarVisibility(value: Xamarin.Forms.ScrollBarVisibility) = x.WithAttribute(ViewAttributes.ScrollViewHorizontalScrollBarVisibilityAttribKey, (value))

        /// Adjusts the ScrollViewVerticalScrollBarVisibility property in the visual element
        member x.ScrollViewVerticalScrollBarVisibility(value: Xamarin.Forms.ScrollBarVisibility) = x.WithAttribute(ViewAttributes.ScrollViewVerticalScrollBarVisibilityAttribKey, (value))

        /// Adjusts the ScrollViewScrollTo property in the visual element
        member x.ScrollViewScrollTo(value: double * double * InputTypes.AnimationKind) = x.WithAttribute(ViewAttributes.ScrollViewScrollToAttribKey, (value))

        /// Adjusts the ScrollViewScrolled property in the visual element
        member x.ScrollViewScrolled(value: Xamarin.Forms.ScrolledEventArgs -> unit) = x.WithAttribute(ViewAttributes.ScrollViewScrolledAttribKey, (value))

        /// Adjusts the ButtonText property in the visual element
        member x.ButtonText(value: string) = x.WithAttribute(ViewAttributes.ButtonTextAttribKey, (value))

        /// Adjusts the ButtonCommand property in the visual element
        member x.ButtonCommand(value: unit -> unit) = x.WithAttribute(ViewAttributes.ButtonCommandAttribKey, (value))

        /// Adjusts the ButtonBorderColor property in the visual element
        member x.ButtonBorderColor(value: Xamarin.Forms.Color) = x.WithAttribute(ViewAttributes.ButtonBorderColorAttribKey, (value))

        /// Adjusts the ButtonBorderWidth property in the visual element
        member x.ButtonBorderWidth(value: float) = x.WithAttribute(ViewAttributes.ButtonBorderWidthAttribKey, (value))

        /// Adjusts the ButtonContentLayout property in the visual element
        member x.ButtonContentLayout(value: Xamarin.Forms.Button.ButtonContentLayout) = x.WithAttribute(ViewAttributes.ButtonContentLayoutAttribKey, (value))

        /// Adjusts the ButtonCornerRadius property in the visual element
        member x.ButtonCornerRadius(value: int) = x.WithAttribute(ViewAttributes.ButtonCornerRadiusAttribKey, (value))

        /// Adjusts the ButtonFontFamily property in the visual element
        member x.ButtonFontFamily(value: string) = x.WithAttribute(ViewAttributes.ButtonFontFamilyAttribKey, (value))

        /// Adjusts the ButtonFontAttributes property in the visual element
        member x.ButtonFontAttributes(value: Xamarin.Forms.FontAttributes) = x.WithAttribute(ViewAttributes.ButtonFontAttributesAttribKey, (value))

        /// Adjusts the ButtonFontSize property in the visual element
        member x.ButtonFontSize(value: float) = x.WithAttribute(ViewAttributes.ButtonFontSizeAttribKey, (value))

        /// Adjusts the ButtonImage property in the visual element
        member x.ButtonImage(value: InputTypes.Image) = x.WithAttribute(ViewAttributes.ButtonImageAttribKey, (value))

        /// Adjusts the ButtonTextColor property in the visual element
        member x.ButtonTextColor(value: Xamarin.Forms.Color) = x.WithAttribute(ViewAttributes.ButtonTextColorAttribKey, (value))

        /// Adjusts the ButtonPadding property in the visual element
        member x.ButtonPadding(value: Xamarin.Forms.Thickness) = x.WithAttribute(ViewAttributes.ButtonPaddingAttribKey, (value))

        /// Adjusts the SliderMinimumMaximum property in the visual element
        member x.SliderMinimumMaximum(value: float * float) = x.WithAttribute(ViewAttributes.SliderMinimumMaximumAttribKey, (value))

        /// Adjusts the SliderValue property in the visual element
        member x.SliderValue(value: float) = x.WithAttribute(ViewAttributes.SliderValueAttribKey, (value))

        /// Adjusts the SliderThumbImageSource property in the visual element
        member x.SliderThumbImageSource(value: Xamarin.Forms.ImageSource) = x.WithAttribute(ViewAttributes.SliderThumbImageSourceAttribKey, (value))

        /// Adjusts the SliderValueChanged property in the visual element
        member x.SliderValueChanged(value: Xamarin.Forms.ValueChangedEventArgs -> unit) = x.WithAttribute(ViewAttributes.SliderValueChangedAttribKey, (value))

        /// Adjusts the SliderDragCompleted property in the visual element
        member x.SliderDragCompleted(value: unit -> unit) = x.WithAttribute(ViewAttributes.SliderDragCompletedAttribKey, (value))

        /// Adjusts the SliderDragStarted property in the visual element
        member x.SliderDragStarted(value: unit -> unit) = x.WithAttribute(ViewAttributes.SliderDragStartedAttribKey, (value))

        member inline x.With(?ElementAutomationId: string, ?ElementClassId: string, ?ElementStyleId: string, ?ElementTag: obj, ?NavigableElementStyle: Xamarin.Forms.Style, 
                      ?NavigableElementStyleClass: InputTypes.StyleClass, ?VisualElementAnchorX: float, ?VisualElementAnchorY: float, ?VisualElementBackgroundColor: Xamarin.Forms.Color, ?VisualElementFlowDirection: Xamarin.Forms.FlowDirection, 
                      ?VisualElementHeight: float, ?VisualElementInputTransparent: bool, ?VisualElementIsEnabled: bool, ?VisualElementIsTabStop: bool, ?VisualElementIsVisible: bool, 
                      ?VisualElementMinimumHeight: float, ?VisualElementMinimumWidth: float, ?VisualElementOpacity: float, ?VisualElementRotation: float, ?VisualElementRotationX: float, 
                      ?VisualElementRotationY: float, ?VisualElementScale: float, ?VisualElementScaleX: float, ?VisualElementScaleY: float, ?VisualElementTabIndex: int, 
                      ?VisualElementTranslationX: float, ?VisualElementTranslationY: float, ?VisualElementVisual: Xamarin.Forms.IVisual, ?VisualElementWidth: float, ?VisualElementFocused: Xamarin.Forms.FocusEventArgs -> unit, 
                      ?VisualElementUnfocused: Xamarin.Forms.FocusEventArgs -> unit, ?ViewHorizontalOptions: Xamarin.Forms.LayoutOptions, ?ViewVerticalOptions: Xamarin.Forms.LayoutOptions, ?ViewMargin: InputTypes.Thickness, ?ViewGestureRecognizers: ViewElement list, 
                      ?GestureElementGestureRecognizers: ViewElement list, ?PanGestureRecognizerTouchPoints: int, ?PanGestureRecognizerPanUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit, ?ClickGestureRecognizerCommand: unit -> unit, ?ClickGestureRecognizerNumberOfClicksRequired: int, 
                      ?ClickGestureRecognizerButtons: Xamarin.Forms.ButtonsMask, ?PinchGestureRecognizerPinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit, ?SwipeGestureRecognizerCommand: unit -> unit, ?SwipeGestureRecognizerDirection: Xamarin.Forms.SwipeDirection, ?SwipeGestureRecognizerThreshold: uint32, 
                      ?SwipeGestureRecognizerSwiped: Xamarin.Forms.SwipedEventArgs -> unit, ?ActivityIndicatorColor: Xamarin.Forms.Color, ?ActivityIndicatorIsRunning: bool, ?BoxViewColor: Xamarin.Forms.Color, ?BoxViewCornerRadius: Xamarin.Forms.CornerRadius, 
                      ?ProgressBarProgress: float, ?LayoutIsClippedToBounds: bool, ?LayoutPadding: Xamarin.Forms.Thickness, ?ScrollViewContent: ViewElement, ?ScrollViewOrientation: Xamarin.Forms.ScrollOrientation, 
                      ?ScrollViewHorizontalScrollBarVisibility: Xamarin.Forms.ScrollBarVisibility, ?ScrollViewVerticalScrollBarVisibility: Xamarin.Forms.ScrollBarVisibility, ?ScrollViewScrollTo: double * double * InputTypes.AnimationKind, ?ScrollViewScrolled: Xamarin.Forms.ScrolledEventArgs -> unit, ?ButtonText: string, 
                      ?ButtonCommand: unit -> unit, ?ButtonBorderColor: Xamarin.Forms.Color, ?ButtonBorderWidth: float, ?ButtonContentLayout: Xamarin.Forms.Button.ButtonContentLayout, ?ButtonCornerRadius: int, 
                      ?ButtonFontFamily: string, ?ButtonFontAttributes: Xamarin.Forms.FontAttributes, ?ButtonFontSize: float, ?ButtonImage: InputTypes.Image, ?ButtonTextColor: Xamarin.Forms.Color, 
                      ?ButtonPadding: Xamarin.Forms.Thickness, ?SliderMinimumMaximum: float * float, ?SliderValue: float, ?SliderThumbImageSource: Xamarin.Forms.ImageSource, ?SliderValueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, 
                      ?SliderDragCompleted: unit -> unit, ?SliderDragStarted: unit -> unit) =
            let x = match ElementAutomationId with None -> x | Some opt -> x.ElementAutomationId(opt)
            let x = match ElementClassId with None -> x | Some opt -> x.ElementClassId(opt)
            let x = match ElementStyleId with None -> x | Some opt -> x.ElementStyleId(opt)
            let x = match ElementTag with None -> x | Some opt -> x.ElementTag(opt)
            let x = match NavigableElementStyle with None -> x | Some opt -> x.NavigableElementStyle(opt)
            let x = match NavigableElementStyleClass with None -> x | Some opt -> x.NavigableElementStyleClass(opt)
            let x = match VisualElementAnchorX with None -> x | Some opt -> x.VisualElementAnchorX(opt)
            let x = match VisualElementAnchorY with None -> x | Some opt -> x.VisualElementAnchorY(opt)
            let x = match VisualElementBackgroundColor with None -> x | Some opt -> x.VisualElementBackgroundColor(opt)
            let x = match VisualElementFlowDirection with None -> x | Some opt -> x.VisualElementFlowDirection(opt)
            let x = match VisualElementHeight with None -> x | Some opt -> x.VisualElementHeight(opt)
            let x = match VisualElementInputTransparent with None -> x | Some opt -> x.VisualElementInputTransparent(opt)
            let x = match VisualElementIsEnabled with None -> x | Some opt -> x.VisualElementIsEnabled(opt)
            let x = match VisualElementIsTabStop with None -> x | Some opt -> x.VisualElementIsTabStop(opt)
            let x = match VisualElementIsVisible with None -> x | Some opt -> x.VisualElementIsVisible(opt)
            let x = match VisualElementMinimumHeight with None -> x | Some opt -> x.VisualElementMinimumHeight(opt)
            let x = match VisualElementMinimumWidth with None -> x | Some opt -> x.VisualElementMinimumWidth(opt)
            let x = match VisualElementOpacity with None -> x | Some opt -> x.VisualElementOpacity(opt)
            let x = match VisualElementRotation with None -> x | Some opt -> x.VisualElementRotation(opt)
            let x = match VisualElementRotationX with None -> x | Some opt -> x.VisualElementRotationX(opt)
            let x = match VisualElementRotationY with None -> x | Some opt -> x.VisualElementRotationY(opt)
            let x = match VisualElementScale with None -> x | Some opt -> x.VisualElementScale(opt)
            let x = match VisualElementScaleX with None -> x | Some opt -> x.VisualElementScaleX(opt)
            let x = match VisualElementScaleY with None -> x | Some opt -> x.VisualElementScaleY(opt)
            let x = match VisualElementTabIndex with None -> x | Some opt -> x.VisualElementTabIndex(opt)
            let x = match VisualElementTranslationX with None -> x | Some opt -> x.VisualElementTranslationX(opt)
            let x = match VisualElementTranslationY with None -> x | Some opt -> x.VisualElementTranslationY(opt)
            let x = match VisualElementVisual with None -> x | Some opt -> x.VisualElementVisual(opt)
            let x = match VisualElementWidth with None -> x | Some opt -> x.VisualElementWidth(opt)
            let x = match VisualElementFocused with None -> x | Some opt -> x.VisualElementFocused(opt)
            let x = match VisualElementUnfocused with None -> x | Some opt -> x.VisualElementUnfocused(opt)
            let x = match ViewHorizontalOptions with None -> x | Some opt -> x.ViewHorizontalOptions(opt)
            let x = match ViewVerticalOptions with None -> x | Some opt -> x.ViewVerticalOptions(opt)
            let x = match ViewMargin with None -> x | Some opt -> x.ViewMargin(opt)
            let x = match ViewGestureRecognizers with None -> x | Some opt -> x.ViewGestureRecognizers(opt)
            let x = match GestureElementGestureRecognizers with None -> x | Some opt -> x.GestureElementGestureRecognizers(opt)
            let x = match PanGestureRecognizerTouchPoints with None -> x | Some opt -> x.PanGestureRecognizerTouchPoints(opt)
            let x = match PanGestureRecognizerPanUpdated with None -> x | Some opt -> x.PanGestureRecognizerPanUpdated(opt)
            let x = match ClickGestureRecognizerCommand with None -> x | Some opt -> x.ClickGestureRecognizerCommand(opt)
            let x = match ClickGestureRecognizerNumberOfClicksRequired with None -> x | Some opt -> x.ClickGestureRecognizerNumberOfClicksRequired(opt)
            let x = match ClickGestureRecognizerButtons with None -> x | Some opt -> x.ClickGestureRecognizerButtons(opt)
            let x = match PinchGestureRecognizerPinchUpdated with None -> x | Some opt -> x.PinchGestureRecognizerPinchUpdated(opt)
            let x = match SwipeGestureRecognizerCommand with None -> x | Some opt -> x.SwipeGestureRecognizerCommand(opt)
            let x = match SwipeGestureRecognizerDirection with None -> x | Some opt -> x.SwipeGestureRecognizerDirection(opt)
            let x = match SwipeGestureRecognizerThreshold with None -> x | Some opt -> x.SwipeGestureRecognizerThreshold(opt)
            let x = match SwipeGestureRecognizerSwiped with None -> x | Some opt -> x.SwipeGestureRecognizerSwiped(opt)
            let x = match ActivityIndicatorColor with None -> x | Some opt -> x.ActivityIndicatorColor(opt)
            let x = match ActivityIndicatorIsRunning with None -> x | Some opt -> x.ActivityIndicatorIsRunning(opt)
            let x = match BoxViewColor with None -> x | Some opt -> x.BoxViewColor(opt)
            let x = match BoxViewCornerRadius with None -> x | Some opt -> x.BoxViewCornerRadius(opt)
            let x = match ProgressBarProgress with None -> x | Some opt -> x.ProgressBarProgress(opt)
            let x = match LayoutIsClippedToBounds with None -> x | Some opt -> x.LayoutIsClippedToBounds(opt)
            let x = match LayoutPadding with None -> x | Some opt -> x.LayoutPadding(opt)
            let x = match ScrollViewContent with None -> x | Some opt -> x.ScrollViewContent(opt)
            let x = match ScrollViewOrientation with None -> x | Some opt -> x.ScrollViewOrientation(opt)
            let x = match ScrollViewHorizontalScrollBarVisibility with None -> x | Some opt -> x.ScrollViewHorizontalScrollBarVisibility(opt)
            let x = match ScrollViewVerticalScrollBarVisibility with None -> x | Some opt -> x.ScrollViewVerticalScrollBarVisibility(opt)
            let x = match ScrollViewScrollTo with None -> x | Some opt -> x.ScrollViewScrollTo(opt)
            let x = match ScrollViewScrolled with None -> x | Some opt -> x.ScrollViewScrolled(opt)
            let x = match ButtonText with None -> x | Some opt -> x.ButtonText(opt)
            let x = match ButtonCommand with None -> x | Some opt -> x.ButtonCommand(opt)
            let x = match ButtonBorderColor with None -> x | Some opt -> x.ButtonBorderColor(opt)
            let x = match ButtonBorderWidth with None -> x | Some opt -> x.ButtonBorderWidth(opt)
            let x = match ButtonContentLayout with None -> x | Some opt -> x.ButtonContentLayout(opt)
            let x = match ButtonCornerRadius with None -> x | Some opt -> x.ButtonCornerRadius(opt)
            let x = match ButtonFontFamily with None -> x | Some opt -> x.ButtonFontFamily(opt)
            let x = match ButtonFontAttributes with None -> x | Some opt -> x.ButtonFontAttributes(opt)
            let x = match ButtonFontSize with None -> x | Some opt -> x.ButtonFontSize(opt)
            let x = match ButtonImage with None -> x | Some opt -> x.ButtonImage(opt)
            let x = match ButtonTextColor with None -> x | Some opt -> x.ButtonTextColor(opt)
            let x = match ButtonPadding with None -> x | Some opt -> x.ButtonPadding(opt)
            let x = match SliderMinimumMaximum with None -> x | Some opt -> x.SliderMinimumMaximum(opt)
            let x = match SliderValue with None -> x | Some opt -> x.SliderValue(opt)
            let x = match SliderThumbImageSource with None -> x | Some opt -> x.SliderThumbImageSource(opt)
            let x = match SliderValueChanged with None -> x | Some opt -> x.SliderValueChanged(opt)
            let x = match SliderDragCompleted with None -> x | Some opt -> x.SliderDragCompleted(opt)
            let x = match SliderDragStarted with None -> x | Some opt -> x.SliderDragStarted(opt)
            x

    /// Adjusts the ElementAutomationId property in the visual element
    let ElementAutomationId (value: string) (x: ViewElement) = x.ElementAutomationId(value)
    /// Adjusts the ElementClassId property in the visual element
    let ElementClassId (value: string) (x: ViewElement) = x.ElementClassId(value)
    /// Adjusts the ElementStyleId property in the visual element
    let ElementStyleId (value: string) (x: ViewElement) = x.ElementStyleId(value)
    /// Adjusts the ElementTag property in the visual element
    let ElementTag (value: obj) (x: ViewElement) = x.ElementTag(value)
    /// Adjusts the NavigableElementStyle property in the visual element
    let NavigableElementStyle (value: Xamarin.Forms.Style) (x: ViewElement) = x.NavigableElementStyle(value)
    /// Adjusts the NavigableElementStyleClass property in the visual element
    let NavigableElementStyleClass (value: InputTypes.StyleClass) (x: ViewElement) = x.NavigableElementStyleClass(value)
    /// Adjusts the VisualElementAnchorX property in the visual element
    let VisualElementAnchorX (value: float) (x: ViewElement) = x.VisualElementAnchorX(value)
    /// Adjusts the VisualElementAnchorY property in the visual element
    let VisualElementAnchorY (value: float) (x: ViewElement) = x.VisualElementAnchorY(value)
    /// Adjusts the VisualElementBackgroundColor property in the visual element
    let VisualElementBackgroundColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.VisualElementBackgroundColor(value)
    /// Adjusts the VisualElementFlowDirection property in the visual element
    let VisualElementFlowDirection (value: Xamarin.Forms.FlowDirection) (x: ViewElement) = x.VisualElementFlowDirection(value)
    /// Adjusts the VisualElementHeight property in the visual element
    let VisualElementHeight (value: float) (x: ViewElement) = x.VisualElementHeight(value)
    /// Adjusts the VisualElementInputTransparent property in the visual element
    let VisualElementInputTransparent (value: bool) (x: ViewElement) = x.VisualElementInputTransparent(value)
    /// Adjusts the VisualElementIsEnabled property in the visual element
    let VisualElementIsEnabled (value: bool) (x: ViewElement) = x.VisualElementIsEnabled(value)
    /// Adjusts the VisualElementIsTabStop property in the visual element
    let VisualElementIsTabStop (value: bool) (x: ViewElement) = x.VisualElementIsTabStop(value)
    /// Adjusts the VisualElementIsVisible property in the visual element
    let VisualElementIsVisible (value: bool) (x: ViewElement) = x.VisualElementIsVisible(value)
    /// Adjusts the VisualElementMinimumHeight property in the visual element
    let VisualElementMinimumHeight (value: float) (x: ViewElement) = x.VisualElementMinimumHeight(value)
    /// Adjusts the VisualElementMinimumWidth property in the visual element
    let VisualElementMinimumWidth (value: float) (x: ViewElement) = x.VisualElementMinimumWidth(value)
    /// Adjusts the VisualElementOpacity property in the visual element
    let VisualElementOpacity (value: float) (x: ViewElement) = x.VisualElementOpacity(value)
    /// Adjusts the VisualElementRotation property in the visual element
    let VisualElementRotation (value: float) (x: ViewElement) = x.VisualElementRotation(value)
    /// Adjusts the VisualElementRotationX property in the visual element
    let VisualElementRotationX (value: float) (x: ViewElement) = x.VisualElementRotationX(value)
    /// Adjusts the VisualElementRotationY property in the visual element
    let VisualElementRotationY (value: float) (x: ViewElement) = x.VisualElementRotationY(value)
    /// Adjusts the VisualElementScale property in the visual element
    let VisualElementScale (value: float) (x: ViewElement) = x.VisualElementScale(value)
    /// Adjusts the VisualElementScaleX property in the visual element
    let VisualElementScaleX (value: float) (x: ViewElement) = x.VisualElementScaleX(value)
    /// Adjusts the VisualElementScaleY property in the visual element
    let VisualElementScaleY (value: float) (x: ViewElement) = x.VisualElementScaleY(value)
    /// Adjusts the VisualElementTabIndex property in the visual element
    let VisualElementTabIndex (value: int) (x: ViewElement) = x.VisualElementTabIndex(value)
    /// Adjusts the VisualElementTranslationX property in the visual element
    let VisualElementTranslationX (value: float) (x: ViewElement) = x.VisualElementTranslationX(value)
    /// Adjusts the VisualElementTranslationY property in the visual element
    let VisualElementTranslationY (value: float) (x: ViewElement) = x.VisualElementTranslationY(value)
    /// Adjusts the VisualElementVisual property in the visual element
    let VisualElementVisual (value: Xamarin.Forms.IVisual) (x: ViewElement) = x.VisualElementVisual(value)
    /// Adjusts the VisualElementWidth property in the visual element
    let VisualElementWidth (value: float) (x: ViewElement) = x.VisualElementWidth(value)
    /// Adjusts the VisualElementFocused property in the visual element
    let VisualElementFocused (value: Xamarin.Forms.FocusEventArgs -> unit) (x: ViewElement) = x.VisualElementFocused(value)
    /// Adjusts the VisualElementUnfocused property in the visual element
    let VisualElementUnfocused (value: Xamarin.Forms.FocusEventArgs -> unit) (x: ViewElement) = x.VisualElementUnfocused(value)
    /// Adjusts the ViewHorizontalOptions property in the visual element
    let ViewHorizontalOptions (value: Xamarin.Forms.LayoutOptions) (x: ViewElement) = x.ViewHorizontalOptions(value)
    /// Adjusts the ViewVerticalOptions property in the visual element
    let ViewVerticalOptions (value: Xamarin.Forms.LayoutOptions) (x: ViewElement) = x.ViewVerticalOptions(value)
    /// Adjusts the ViewMargin property in the visual element
    let ViewMargin (value: InputTypes.Thickness) (x: ViewElement) = x.ViewMargin(value)
    /// Adjusts the ViewGestureRecognizers property in the visual element
    let ViewGestureRecognizers (value: ViewElement list) (x: ViewElement) = x.ViewGestureRecognizers(value)
    /// Adjusts the GestureElementGestureRecognizers property in the visual element
    let GestureElementGestureRecognizers (value: ViewElement list) (x: ViewElement) = x.GestureElementGestureRecognizers(value)
    /// Adjusts the PanGestureRecognizerTouchPoints property in the visual element
    let PanGestureRecognizerTouchPoints (value: int) (x: ViewElement) = x.PanGestureRecognizerTouchPoints(value)
    /// Adjusts the PanGestureRecognizerPanUpdated property in the visual element
    let PanGestureRecognizerPanUpdated (value: Xamarin.Forms.PanUpdatedEventArgs -> unit) (x: ViewElement) = x.PanGestureRecognizerPanUpdated(value)
    /// Adjusts the ClickGestureRecognizerCommand property in the visual element
    let ClickGestureRecognizerCommand (value: unit -> unit) (x: ViewElement) = x.ClickGestureRecognizerCommand(value)
    /// Adjusts the ClickGestureRecognizerNumberOfClicksRequired property in the visual element
    let ClickGestureRecognizerNumberOfClicksRequired (value: int) (x: ViewElement) = x.ClickGestureRecognizerNumberOfClicksRequired(value)
    /// Adjusts the ClickGestureRecognizerButtons property in the visual element
    let ClickGestureRecognizerButtons (value: Xamarin.Forms.ButtonsMask) (x: ViewElement) = x.ClickGestureRecognizerButtons(value)
    /// Adjusts the PinchGestureRecognizerPinchUpdated property in the visual element
    let PinchGestureRecognizerPinchUpdated (value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) (x: ViewElement) = x.PinchGestureRecognizerPinchUpdated(value)
    /// Adjusts the SwipeGestureRecognizerCommand property in the visual element
    let SwipeGestureRecognizerCommand (value: unit -> unit) (x: ViewElement) = x.SwipeGestureRecognizerCommand(value)
    /// Adjusts the SwipeGestureRecognizerDirection property in the visual element
    let SwipeGestureRecognizerDirection (value: Xamarin.Forms.SwipeDirection) (x: ViewElement) = x.SwipeGestureRecognizerDirection(value)
    /// Adjusts the SwipeGestureRecognizerThreshold property in the visual element
    let SwipeGestureRecognizerThreshold (value: uint32) (x: ViewElement) = x.SwipeGestureRecognizerThreshold(value)
    /// Adjusts the SwipeGestureRecognizerSwiped property in the visual element
    let SwipeGestureRecognizerSwiped (value: Xamarin.Forms.SwipedEventArgs -> unit) (x: ViewElement) = x.SwipeGestureRecognizerSwiped(value)
    /// Adjusts the ActivityIndicatorColor property in the visual element
    let ActivityIndicatorColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.ActivityIndicatorColor(value)
    /// Adjusts the ActivityIndicatorIsRunning property in the visual element
    let ActivityIndicatorIsRunning (value: bool) (x: ViewElement) = x.ActivityIndicatorIsRunning(value)
    /// Adjusts the BoxViewColor property in the visual element
    let BoxViewColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.BoxViewColor(value)
    /// Adjusts the BoxViewCornerRadius property in the visual element
    let BoxViewCornerRadius (value: Xamarin.Forms.CornerRadius) (x: ViewElement) = x.BoxViewCornerRadius(value)
    /// Adjusts the ProgressBarProgress property in the visual element
    let ProgressBarProgress (value: float) (x: ViewElement) = x.ProgressBarProgress(value)
    /// Adjusts the LayoutIsClippedToBounds property in the visual element
    let LayoutIsClippedToBounds (value: bool) (x: ViewElement) = x.LayoutIsClippedToBounds(value)
    /// Adjusts the LayoutPadding property in the visual element
    let LayoutPadding (value: Xamarin.Forms.Thickness) (x: ViewElement) = x.LayoutPadding(value)
    /// Adjusts the ScrollViewContent property in the visual element
    let ScrollViewContent (value: ViewElement) (x: ViewElement) = x.ScrollViewContent(value)
    /// Adjusts the ScrollViewOrientation property in the visual element
    let ScrollViewOrientation (value: Xamarin.Forms.ScrollOrientation) (x: ViewElement) = x.ScrollViewOrientation(value)
    /// Adjusts the ScrollViewHorizontalScrollBarVisibility property in the visual element
    let ScrollViewHorizontalScrollBarVisibility (value: Xamarin.Forms.ScrollBarVisibility) (x: ViewElement) = x.ScrollViewHorizontalScrollBarVisibility(value)
    /// Adjusts the ScrollViewVerticalScrollBarVisibility property in the visual element
    let ScrollViewVerticalScrollBarVisibility (value: Xamarin.Forms.ScrollBarVisibility) (x: ViewElement) = x.ScrollViewVerticalScrollBarVisibility(value)
    /// Adjusts the ScrollViewScrollTo property in the visual element
    let ScrollViewScrollTo (value: double * double * InputTypes.AnimationKind) (x: ViewElement) = x.ScrollViewScrollTo(value)
    /// Adjusts the ScrollViewScrolled property in the visual element
    let ScrollViewScrolled (value: Xamarin.Forms.ScrolledEventArgs -> unit) (x: ViewElement) = x.ScrollViewScrolled(value)
    /// Adjusts the ButtonText property in the visual element
    let ButtonText (value: string) (x: ViewElement) = x.ButtonText(value)
    /// Adjusts the ButtonCommand property in the visual element
    let ButtonCommand (value: unit -> unit) (x: ViewElement) = x.ButtonCommand(value)
    /// Adjusts the ButtonBorderColor property in the visual element
    let ButtonBorderColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.ButtonBorderColor(value)
    /// Adjusts the ButtonBorderWidth property in the visual element
    let ButtonBorderWidth (value: float) (x: ViewElement) = x.ButtonBorderWidth(value)
    /// Adjusts the ButtonContentLayout property in the visual element
    let ButtonContentLayout (value: Xamarin.Forms.Button.ButtonContentLayout) (x: ViewElement) = x.ButtonContentLayout(value)
    /// Adjusts the ButtonCornerRadius property in the visual element
    let ButtonCornerRadius (value: int) (x: ViewElement) = x.ButtonCornerRadius(value)
    /// Adjusts the ButtonFontFamily property in the visual element
    let ButtonFontFamily (value: string) (x: ViewElement) = x.ButtonFontFamily(value)
    /// Adjusts the ButtonFontAttributes property in the visual element
    let ButtonFontAttributes (value: Xamarin.Forms.FontAttributes) (x: ViewElement) = x.ButtonFontAttributes(value)
    /// Adjusts the ButtonFontSize property in the visual element
    let ButtonFontSize (value: float) (x: ViewElement) = x.ButtonFontSize(value)
    /// Adjusts the ButtonImage property in the visual element
    let ButtonImage (value: InputTypes.Image) (x: ViewElement) = x.ButtonImage(value)
    /// Adjusts the ButtonTextColor property in the visual element
    let ButtonTextColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.ButtonTextColor(value)
    /// Adjusts the ButtonPadding property in the visual element
    let ButtonPadding (value: Xamarin.Forms.Thickness) (x: ViewElement) = x.ButtonPadding(value)
    /// Adjusts the SliderMinimumMaximum property in the visual element
    let SliderMinimumMaximum (value: float * float) (x: ViewElement) = x.SliderMinimumMaximum(value)
    /// Adjusts the SliderValue property in the visual element
    let SliderValue (value: float) (x: ViewElement) = x.SliderValue(value)
    /// Adjusts the SliderThumbImageSource property in the visual element
    let SliderThumbImageSource (value: Xamarin.Forms.ImageSource) (x: ViewElement) = x.SliderThumbImageSource(value)
    /// Adjusts the SliderValueChanged property in the visual element
    let SliderValueChanged (value: Xamarin.Forms.ValueChangedEventArgs -> unit) (x: ViewElement) = x.SliderValueChanged(value)
    /// Adjusts the SliderDragCompleted property in the visual element
    let SliderDragCompleted (value: unit -> unit) (x: ViewElement) = x.SliderDragCompleted(value)
    /// Adjusts the SliderDragStarted property in the visual element
    let SliderDragStarted (value: unit -> unit) (x: ViewElement) = x.SliderDragStarted(value)
