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
                                      ?created: obj -> unit,
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

    /// Builds the attributes for a NavigableElement in the view
    static member inline BuildNavigableElement(attribCount: int,
                                               ?created: obj -> unit,
                                               ?style: Xamarin.Forms.Style,
                                               ?styleClass: InputTypes.StyleClass,
                                               ?automationId: string,
                                               ?classId: string,
                                               ?styleId: string,
                                               ?ref: ViewRef,
                                               ?tag: obj) = 

        let attribCount = match style with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleClass with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?created: obj -> unit, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                      ?tag: obj)
        match style with None -> () | Some v -> attribBuilder.Add(ViewAttributes.NavigableElementStyleAttribKey, (v)) 
        match styleClass with None -> () | Some v -> attribBuilder.Add(ViewAttributes.NavigableElementStyleClassAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncNavigableElement : (unit -> Xamarin.Forms.NavigableElement) = (fun () -> ViewBuilders.CreateNavigableElement()) with get, set

    static member CreateNavigableElement () : Xamarin.Forms.NavigableElement =
        new Xamarin.Forms.NavigableElement()

    static member val UpdateFuncNavigableElement =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.NavigableElement) -> ViewBuilders.UpdateNavigableElement (prevOpt, curr, target)) 

    static member UpdateNavigableElement (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.NavigableElement) = 
        // update the inherited Element element
        let baseElement = (if ViewProto.ProtoElement.IsNone then ViewProto.ProtoElement <- Some (ViewBuilders.ConstructElement())); ViewProto.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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
                                            ?created: obj -> unit,
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

        let attribBuilder = ViewBuilders.BuildNavigableElement(attribCount, ?styleId: string, ?classId: string, ?automationId: string, ?styleClass: InputTypes.StyleClass, ?style: Xamarin.Forms.Style, 
                                                               ?ref: ViewRef, ?created: obj -> unit, ?tag: obj)
        match focused with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementFocusedAttribKey, (v)) 
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
        match unfocused with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementUnfocusedAttribKey, (v)) 
        match minimumHeight with None -> () | Some v -> attribBuilder.Add(ViewAttributes.VisualElementMinimumHeightAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncVisualElement : (unit -> Xamarin.Forms.VisualElement) = (fun () -> ViewBuilders.CreateVisualElement()) with get, set

    static member CreateVisualElement () : Xamarin.Forms.VisualElement =
        new Xamarin.Forms.VisualElement()

    static member val UpdateFuncVisualElement =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.VisualElement) -> ViewBuilders.UpdateVisualElement (prevOpt, curr, target)) 

    static member UpdateVisualElement (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.VisualElement) = 
        // update the inherited NavigableElement element
        let baseElement = (if ViewProto.ProtoNavigableElement.IsNone then ViewProto.ProtoNavigableElement <- Some (ViewBuilders.ConstructNavigableElement())); ViewProto.ProtoNavigableElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevVisualElementFocusedOpt = ValueNone
        let mutable currVisualElementFocusedOpt = ValueNone
        let mutable prevVisualElementUnfocusedOpt = ValueNone
        let mutable currVisualElementUnfocusedOpt = ValueNone
        let mutable prevVisualElementAnchorXOpt = ValueNone
        let mutable currVisualElementAnchorXOpt = ValueNone
        let mutable prevVisualElementTranslationYOpt = ValueNone
        let mutable currVisualElementTranslationYOpt = ValueNone
        let mutable prevVisualElementTranslationXOpt = ValueNone
        let mutable currVisualElementTranslationXOpt = ValueNone
        let mutable prevVisualElementTabIndexOpt = ValueNone
        let mutable currVisualElementTabIndexOpt = ValueNone
        let mutable prevVisualElementScaleYOpt = ValueNone
        let mutable currVisualElementScaleYOpt = ValueNone
        let mutable prevVisualElementScaleXOpt = ValueNone
        let mutable currVisualElementScaleXOpt = ValueNone
        let mutable prevVisualElementScaleOpt = ValueNone
        let mutable currVisualElementScaleOpt = ValueNone
        let mutable prevVisualElementRotationYOpt = ValueNone
        let mutable currVisualElementRotationYOpt = ValueNone
        let mutable prevVisualElementRotationXOpt = ValueNone
        let mutable currVisualElementRotationXOpt = ValueNone
        let mutable prevVisualElementRotationOpt = ValueNone
        let mutable currVisualElementRotationOpt = ValueNone
        let mutable prevVisualElementVisualOpt = ValueNone
        let mutable currVisualElementVisualOpt = ValueNone
        let mutable prevVisualElementOpacityOpt = ValueNone
        let mutable currVisualElementOpacityOpt = ValueNone
        let mutable prevVisualElementMinimumHeightOpt = ValueNone
        let mutable currVisualElementMinimumHeightOpt = ValueNone
        let mutable prevVisualElementIsVisibleOpt = ValueNone
        let mutable currVisualElementIsVisibleOpt = ValueNone
        let mutable prevVisualElementIsTabStopOpt = ValueNone
        let mutable currVisualElementIsTabStopOpt = ValueNone
        let mutable prevVisualElementIsEnabledOpt = ValueNone
        let mutable currVisualElementIsEnabledOpt = ValueNone
        let mutable prevVisualElementInputTransparentOpt = ValueNone
        let mutable currVisualElementInputTransparentOpt = ValueNone
        let mutable prevVisualElementHeightOpt = ValueNone
        let mutable currVisualElementHeightOpt = ValueNone
        let mutable prevVisualElementFlowDirectionOpt = ValueNone
        let mutable currVisualElementFlowDirectionOpt = ValueNone
        let mutable prevVisualElementBackgroundColorOpt = ValueNone
        let mutable currVisualElementBackgroundColorOpt = ValueNone
        let mutable prevVisualElementAnchorYOpt = ValueNone
        let mutable currVisualElementAnchorYOpt = ValueNone
        let mutable prevVisualElementMinimumWidthOpt = ValueNone
        let mutable currVisualElementMinimumWidthOpt = ValueNone
        let mutable prevVisualElementWidthOpt = ValueNone
        let mutable currVisualElementWidthOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.VisualElementFocusedAttribKey.KeyValue then 
                currVisualElementFocusedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.FocusEventArgs>)
            if kvp.Key = ViewAttributes.VisualElementUnfocusedAttribKey.KeyValue then 
                currVisualElementUnfocusedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.FocusEventArgs>)
            if kvp.Key = ViewAttributes.VisualElementAnchorXAttribKey.KeyValue then 
                currVisualElementAnchorXOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementTranslationYAttribKey.KeyValue then 
                currVisualElementTranslationYOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementTranslationXAttribKey.KeyValue then 
                currVisualElementTranslationXOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementTabIndexAttribKey.KeyValue then 
                currVisualElementTabIndexOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.VisualElementScaleYAttribKey.KeyValue then 
                currVisualElementScaleYOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementScaleXAttribKey.KeyValue then 
                currVisualElementScaleXOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementScaleAttribKey.KeyValue then 
                currVisualElementScaleOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementRotationYAttribKey.KeyValue then 
                currVisualElementRotationYOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementRotationXAttribKey.KeyValue then 
                currVisualElementRotationXOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementRotationAttribKey.KeyValue then 
                currVisualElementRotationOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementVisualAttribKey.KeyValue then 
                currVisualElementVisualOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.IVisual)
            if kvp.Key = ViewAttributes.VisualElementOpacityAttribKey.KeyValue then 
                currVisualElementOpacityOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementMinimumHeightAttribKey.KeyValue then 
                currVisualElementMinimumHeightOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementIsVisibleAttribKey.KeyValue then 
                currVisualElementIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.VisualElementIsTabStopAttribKey.KeyValue then 
                currVisualElementIsTabStopOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.VisualElementIsEnabledAttribKey.KeyValue then 
                currVisualElementIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.VisualElementInputTransparentAttribKey.KeyValue then 
                currVisualElementInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.VisualElementHeightAttribKey.KeyValue then 
                currVisualElementHeightOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementFlowDirectionAttribKey.KeyValue then 
                currVisualElementFlowDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlowDirection)
            if kvp.Key = ViewAttributes.VisualElementBackgroundColorAttribKey.KeyValue then 
                currVisualElementBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = ViewAttributes.VisualElementAnchorYAttribKey.KeyValue then 
                currVisualElementAnchorYOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.VisualElementMinimumWidthAttribKey.KeyValue then 
                currVisualElementMinimumWidthOpt <- ValueSome (kvp.Value :?> float)
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
                if kvp.Key = ViewAttributes.VisualElementTranslationYAttribKey.KeyValue then 
                    prevVisualElementTranslationYOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementTranslationXAttribKey.KeyValue then 
                    prevVisualElementTranslationXOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementTabIndexAttribKey.KeyValue then 
                    prevVisualElementTabIndexOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.VisualElementScaleYAttribKey.KeyValue then 
                    prevVisualElementScaleYOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementScaleXAttribKey.KeyValue then 
                    prevVisualElementScaleXOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementScaleAttribKey.KeyValue then 
                    prevVisualElementScaleOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementRotationYAttribKey.KeyValue then 
                    prevVisualElementRotationYOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementRotationXAttribKey.KeyValue then 
                    prevVisualElementRotationXOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementRotationAttribKey.KeyValue then 
                    prevVisualElementRotationOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementVisualAttribKey.KeyValue then 
                    prevVisualElementVisualOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.IVisual)
                if kvp.Key = ViewAttributes.VisualElementOpacityAttribKey.KeyValue then 
                    prevVisualElementOpacityOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementMinimumHeightAttribKey.KeyValue then 
                    prevVisualElementMinimumHeightOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementIsVisibleAttribKey.KeyValue then 
                    prevVisualElementIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.VisualElementIsTabStopAttribKey.KeyValue then 
                    prevVisualElementIsTabStopOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.VisualElementIsEnabledAttribKey.KeyValue then 
                    prevVisualElementIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.VisualElementInputTransparentAttribKey.KeyValue then 
                    prevVisualElementInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.VisualElementHeightAttribKey.KeyValue then 
                    prevVisualElementHeightOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementFlowDirectionAttribKey.KeyValue then 
                    prevVisualElementFlowDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlowDirection)
                if kvp.Key = ViewAttributes.VisualElementBackgroundColorAttribKey.KeyValue then 
                    prevVisualElementBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = ViewAttributes.VisualElementAnchorYAttribKey.KeyValue then 
                    prevVisualElementAnchorYOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.VisualElementMinimumWidthAttribKey.KeyValue then 
                    prevVisualElementMinimumWidthOpt <- ValueSome (kvp.Value :?> float)
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
                                   ?created: obj -> unit,
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

        let attribBuilder = ViewBuilders.BuildVisualElement(attribCount, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?isVisible: bool, ?isTabStop: bool, ?isEnabled: bool, ?inputTransparent: bool, 
                                                            ?height: float, ?flowDirection: Xamarin.Forms.FlowDirection, ?backgroundColor: Xamarin.Forms.Color, ?anchorY: float, ?minimumWidth: float, 
                                                            ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, ?classId: string, 
                                                            ?styleId: string, ?minimumHeight: float, ?ref: ViewRef, ?opacity: float, ?rotation: float, 
                                                            ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit, ?anchorX: float, ?translationY: float, ?translationX: float, 
                                                            ?tabIndex: int, ?scaleY: float, ?scaleX: float, ?scale: float, ?rotationY: float, 
                                                            ?rotationX: float, ?visual: Xamarin.Forms.IVisual, ?tag: obj)
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
        // update the inherited VisualElement element
        let baseElement = (if ViewProto.ProtoVisualElement.IsNone then ViewProto.ProtoVisualElement <- Some (ViewBuilders.ConstructVisualElement())); ViewProto.ProtoVisualElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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

    /// Builds the attributes for a GestureElement in the view
    static member inline BuildGestureElement(attribCount: int,
                                             ?created: obj -> unit,
                                             ?gestureRecognizers: ViewElement list,
                                             ?automationId: string,
                                             ?classId: string,
                                             ?styleId: string,
                                             ?ref: ViewRef,
                                             ?tag: obj) = 

        let attribCount = match gestureRecognizers with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?created: obj -> unit, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                      ?tag: obj)
        match gestureRecognizers with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GestureElementGestureRecognizersAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncGestureElement : (unit -> Xamarin.Forms.GestureElement) = (fun () -> ViewBuilders.CreateGestureElement()) with get, set

    static member CreateGestureElement () : Xamarin.Forms.GestureElement =
        new Xamarin.Forms.GestureElement()

    static member val UpdateFuncGestureElement =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.GestureElement) -> ViewBuilders.UpdateGestureElement (prevOpt, curr, target)) 

    static member UpdateGestureElement (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.GestureElement) = 
        // update the inherited Element element
        let baseElement = (if ViewProto.ProtoElement.IsNone then ViewProto.ProtoElement <- Some (ViewBuilders.ConstructElement())); ViewProto.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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

    /// Builds the attributes for a PanGestureRecognizer in the view
    static member inline BuildPanGestureRecognizer(attribCount: int,
                                                   ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit,
                                                   ?created: obj -> unit,
                                                   ?touchPoints: int,
                                                   ?automationId: string,
                                                   ?classId: string,
                                                   ?styleId: string,
                                                   ?ref: ViewRef,
                                                   ?tag: obj) = 

        let attribCount = match panUpdated with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match touchPoints with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?created: obj -> unit, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                      ?tag: obj)
        match panUpdated with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PanGestureRecognizerPanUpdatedAttribKey, (v)) 
        match touchPoints with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PanGestureRecognizerTouchPointsAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncPanGestureRecognizer : (unit -> Xamarin.Forms.PanGestureRecognizer) = (fun () -> ViewBuilders.CreatePanGestureRecognizer()) with get, set

    static member CreatePanGestureRecognizer () : Xamarin.Forms.PanGestureRecognizer =
        new Xamarin.Forms.PanGestureRecognizer()

    static member val UpdateFuncPanGestureRecognizer =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.PanGestureRecognizer) -> ViewBuilders.UpdatePanGestureRecognizer (prevOpt, curr, target)) 

    static member UpdatePanGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.PanGestureRecognizer) = 
        // update the inherited Element element
        let baseElement = (if ViewProto.ProtoElement.IsNone then ViewProto.ProtoElement <- Some (ViewBuilders.ConstructElement())); ViewProto.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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

    /// Builds the attributes for a ClickGestureRecognizer in the view
    static member inline BuildClickGestureRecognizer(attribCount: int,
                                                     ?created: obj -> unit,
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

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?created: obj -> unit, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                      ?tag: obj)
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
        // update the inherited Element element
        let baseElement = (if ViewProto.ProtoElement.IsNone then ViewProto.ProtoElement <- Some (ViewBuilders.ConstructElement())); ViewProto.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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

    /// Builds the attributes for a PinchGestureRecognizer in the view
    static member inline BuildPinchGestureRecognizer(attribCount: int,
                                                     ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit,
                                                     ?created: obj -> unit,
                                                     ?automationId: string,
                                                     ?classId: string,
                                                     ?styleId: string,
                                                     ?ref: ViewRef,
                                                     ?tag: obj) = 

        let attribCount = match pinchUpdated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?created: obj -> unit, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                      ?tag: obj)
        match pinchUpdated with None -> () | Some v -> attribBuilder.Add(ViewAttributes.PinchGestureRecognizerPinchUpdatedAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncPinchGestureRecognizer : (unit -> Xamarin.Forms.PinchGestureRecognizer) = (fun () -> ViewBuilders.CreatePinchGestureRecognizer()) with get, set

    static member CreatePinchGestureRecognizer () : Xamarin.Forms.PinchGestureRecognizer =
        new Xamarin.Forms.PinchGestureRecognizer()

    static member val UpdateFuncPinchGestureRecognizer =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.PinchGestureRecognizer) -> ViewBuilders.UpdatePinchGestureRecognizer (prevOpt, curr, target)) 

    static member UpdatePinchGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.PinchGestureRecognizer) = 
        // update the inherited Element element
        let baseElement = (if ViewProto.ProtoElement.IsNone then ViewProto.ProtoElement <- Some (ViewBuilders.ConstructElement())); ViewProto.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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

    /// Builds the attributes for a SwipeGestureRecognizer in the view
    static member inline BuildSwipeGestureRecognizer(attribCount: int,
                                                     ?swiped: Xamarin.Forms.SwipedEventArgs -> unit,
                                                     ?created: obj -> unit,
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

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?created: obj -> unit, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                      ?tag: obj)
        match swiped with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerSwipedAttribKey, (v)) 
        match command with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerCommandAttribKey, (v)) 
        match direction with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerDirectionAttribKey, (v)) 
        match threshold with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwipeGestureRecognizerThresholdAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncSwipeGestureRecognizer : (unit -> Xamarin.Forms.SwipeGestureRecognizer) = (fun () -> ViewBuilders.CreateSwipeGestureRecognizer()) with get, set

    static member CreateSwipeGestureRecognizer () : Xamarin.Forms.SwipeGestureRecognizer =
        new Xamarin.Forms.SwipeGestureRecognizer()

    static member val UpdateFuncSwipeGestureRecognizer =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.SwipeGestureRecognizer) -> ViewBuilders.UpdateSwipeGestureRecognizer (prevOpt, curr, target)) 

    static member UpdateSwipeGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.SwipeGestureRecognizer) = 
        // update the inherited Element element
        let baseElement = (if ViewProto.ProtoElement.IsNone then ViewProto.ProtoElement <- Some (ViewBuilders.ConstructElement())); ViewProto.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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
                                                ?created: obj -> unit,
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

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?minimumHeight: float, ?isVisible: bool, ?isTabStop: bool, ?isEnabled: bool, 
                                                   ?inputTransparent: bool, ?height: float, ?flowDirection: Xamarin.Forms.FlowDirection, ?opacity: float, ?backgroundColor: Xamarin.Forms.Color, 
                                                   ?minimumWidth: float, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?anchorY: float, ?ref: ViewRef, ?visual: Xamarin.Forms.IVisual, 
                                                   ?rotationX: float, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, 
                                                   ?margin: InputTypes.Thickness, ?rotation: float, ?gestureRecognizers: ViewElement list, ?translationY: float, ?translationX: float, 
                                                   ?tabIndex: int, ?scaleY: float, ?scaleX: float, ?scale: float, ?rotationY: float, 
                                                   ?anchorX: float, ?tag: obj)
        match color with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ActivityIndicatorColorAttribKey, (v)) 
        match isRunning with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ActivityIndicatorIsRunningAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncActivityIndicator : (unit -> Xamarin.Forms.ActivityIndicator) = (fun () -> ViewBuilders.CreateActivityIndicator()) with get, set

    static member CreateActivityIndicator () : Xamarin.Forms.ActivityIndicator =
        new Xamarin.Forms.ActivityIndicator()

    static member val UpdateFuncActivityIndicator =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ActivityIndicator) -> ViewBuilders.UpdateActivityIndicator (prevOpt, curr, target)) 

    static member UpdateActivityIndicator (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ActivityIndicator) = 
        // update the inherited View element
        let baseElement = (if ViewProto.ProtoView.IsNone then ViewProto.ProtoView <- Some (ViewBuilders.ConstructView())); ViewProto.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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
                                      ?created: obj -> unit,
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

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?minimumHeight: float, ?isVisible: bool, ?isTabStop: bool, ?isEnabled: bool, 
                                                   ?inputTransparent: bool, ?height: float, ?flowDirection: Xamarin.Forms.FlowDirection, ?opacity: float, ?backgroundColor: Xamarin.Forms.Color, 
                                                   ?minimumWidth: float, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?anchorY: float, ?ref: ViewRef, ?visual: Xamarin.Forms.IVisual, 
                                                   ?rotationX: float, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, 
                                                   ?margin: InputTypes.Thickness, ?rotation: float, ?gestureRecognizers: ViewElement list, ?translationY: float, ?translationX: float, 
                                                   ?tabIndex: int, ?scaleY: float, ?scaleX: float, ?scale: float, ?rotationY: float, 
                                                   ?anchorX: float, ?tag: obj)
        match color with None -> () | Some v -> attribBuilder.Add(ViewAttributes.BoxViewColorAttribKey, (v)) 
        match cornerRadius with None -> () | Some v -> attribBuilder.Add(ViewAttributes.BoxViewCornerRadiusAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncBoxView : (unit -> Xamarin.Forms.BoxView) = (fun () -> ViewBuilders.CreateBoxView()) with get, set

    static member CreateBoxView () : Xamarin.Forms.BoxView =
        new Xamarin.Forms.BoxView()

    static member val UpdateFuncBoxView =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.BoxView) -> ViewBuilders.UpdateBoxView (prevOpt, curr, target)) 

    static member UpdateBoxView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.BoxView) = 
        // update the inherited View element
        let baseElement = (if ViewProto.ProtoView.IsNone then ViewProto.ProtoView <- Some (ViewBuilders.ConstructView())); ViewProto.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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
                                          ?created: obj -> unit,
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

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?isVisible: bool, ?isTabStop: bool, ?isEnabled: bool, ?inputTransparent: bool, 
                                                   ?height: float, ?flowDirection: Xamarin.Forms.FlowDirection, ?backgroundColor: Xamarin.Forms.Color, ?anchorY: float, ?minimumWidth: float, 
                                                   ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, ?classId: string, 
                                                   ?styleId: string, ?minimumHeight: float, ?opacity: float, ?visual: Xamarin.Forms.IVisual, ?rotation: float, 
                                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, 
                                                   ?gestureRecognizers: ViewElement list, ?ref: ViewRef, ?anchorX: float, ?translationX: float, ?tabIndex: int, 
                                                   ?scaleY: float, ?scaleX: float, ?scale: float, ?rotationY: float, ?rotationX: float, 
                                                   ?translationY: float, ?tag: obj)
        match progress with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ProgressBarProgressAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncProgressBar : (unit -> Xamarin.Forms.ProgressBar) = (fun () -> ViewBuilders.CreateProgressBar()) with get, set

    static member CreateProgressBar () : Xamarin.Forms.ProgressBar =
        new Xamarin.Forms.ProgressBar()

    static member val UpdateFuncProgressBar =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ProgressBar) -> ViewBuilders.UpdateProgressBar (prevOpt, curr, target)) 

    static member UpdateProgressBar (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ProgressBar) = 
        // update the inherited View element
        let baseElement = (if ViewProto.ProtoView.IsNone then ViewProto.ProtoView <- Some (ViewBuilders.ConstructView())); ViewProto.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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
                                     ?created: obj -> unit,
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

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?minimumHeight: float, ?isVisible: bool, ?isTabStop: bool, ?isEnabled: bool, 
                                                   ?inputTransparent: bool, ?height: float, ?flowDirection: Xamarin.Forms.FlowDirection, ?opacity: float, ?backgroundColor: Xamarin.Forms.Color, 
                                                   ?minimumWidth: float, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?anchorY: float, ?ref: ViewRef, ?visual: Xamarin.Forms.IVisual, 
                                                   ?rotationX: float, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, 
                                                   ?margin: InputTypes.Thickness, ?rotation: float, ?gestureRecognizers: ViewElement list, ?translationY: float, ?translationX: float, 
                                                   ?tabIndex: int, ?scaleY: float, ?scaleX: float, ?scale: float, ?rotationY: float, 
                                                   ?anchorX: float, ?tag: obj)
        match isClippedToBounds with None -> () | Some v -> attribBuilder.Add(ViewAttributes.LayoutIsClippedToBoundsAttribKey, (v)) 
        match padding with None -> () | Some v -> attribBuilder.Add(ViewAttributes.LayoutPaddingAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncLayout : (unit -> Xamarin.Forms.Layout) = (fun () -> ViewBuilders.CreateLayout()) with get, set

    static member CreateLayout () : Xamarin.Forms.Layout =
        new Xamarin.Forms.Layout()

    static member val UpdateFuncLayout =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Layout) -> ViewBuilders.UpdateLayout (prevOpt, curr, target)) 

    static member UpdateLayout (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Layout) = 
        // update the inherited View element
        let baseElement = (if ViewProto.ProtoView.IsNone then ViewProto.ProtoView <- Some (ViewBuilders.ConstructView())); ViewProto.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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
                                         ?created: obj -> unit,
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

        let attribBuilder = ViewBuilders.BuildLayout(attribCount, ?rotation: float, ?visual: Xamarin.Forms.IVisual, ?opacity: float, ?minimumHeight: float, ?isVisible: bool, 
                                                     ?isTabStop: bool, ?isEnabled: bool, ?inputTransparent: bool, ?height: float, ?flowDirection: Xamarin.Forms.FlowDirection, 
                                                     ?backgroundColor: Xamarin.Forms.Color, ?anchorY: float, ?minimumWidth: float, ?width: float, ?style: Xamarin.Forms.Style, 
                                                     ?styleClass: InputTypes.StyleClass, ?automationId: string, ?classId: string, ?styleId: string, ?rotationX: float, 
                                                     ?ref: ViewRef, ?rotationY: float, ?scaleX: float, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, 
                                                     ?created: obj -> unit, ?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, 
                                                     ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, ?translationY: float, ?translationX: float, 
                                                     ?tabIndex: int, ?scaleY: float, ?scale: float, ?tag: obj)
        match scrolled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewScrolledAttribKey, (v)) 
        match content with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewContentAttribKey, (v)) 
        match orientation with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewOrientationAttribKey, (v)) 
        match horizontalScrollBarVisibility with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewHorizontalScrollBarVisibilityAttribKey, (v)) 
        match verticalScrollBarVisibility with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewVerticalScrollBarVisibilityAttribKey, (v)) 
        match scrollTo with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ScrollViewScrollToAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncScrollView : (unit -> Xamarin.Forms.ScrollView) = (fun () -> ViewBuilders.CreateScrollView()) with get, set

    static member CreateScrollView () : Xamarin.Forms.ScrollView =
        new Xamarin.Forms.ScrollView()

    static member val UpdateFuncScrollView =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ScrollView) -> ViewBuilders.UpdateScrollView (prevOpt, curr, target)) 

    static member UpdateScrollView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ScrollView) = 
        // update the inherited Layout element
        let baseElement = (if ViewProto.ProtoLayout.IsNone then ViewProto.ProtoLayout <- Some (ViewBuilders.ConstructLayout())); ViewProto.ProtoLayout.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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
                                     ?created: obj -> unit,
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

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?rotationY: float, ?rotationX: float, ?rotation: float, ?visual: Xamarin.Forms.IVisual, 
                                                   ?opacity: float, ?minimumHeight: float, ?isVisible: bool, ?isTabStop: bool, ?isEnabled: bool, 
                                                   ?inputTransparent: bool, ?height: float, ?flowDirection: Xamarin.Forms.FlowDirection, ?backgroundColor: Xamarin.Forms.Color, ?anchorY: float, 
                                                   ?minimumWidth: float, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?scale: float, ?ref: ViewRef, ?scaleX: float, 
                                                   ?tabIndex: int, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, 
                                                   ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, ?translationY: float, ?translationX: float, 
                                                   ?scaleY: float, ?tag: obj)
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
        // update the inherited View element
        let baseElement = (if ViewProto.ProtoView.IsNone then ViewProto.ProtoView <- Some (ViewBuilders.ConstructView())); ViewProto.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
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

