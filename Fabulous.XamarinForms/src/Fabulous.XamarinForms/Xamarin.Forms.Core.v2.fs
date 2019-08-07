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
    let StepperValueChangedAttribKey : AttributeKey<_> = AttributeKey<_>("StepperValueChanged")
    let StepperMinimumMaximumAttribKey : AttributeKey<_> = AttributeKey<_>("StepperMinimumMaximum")
    let StepperValueAttribKey : AttributeKey<_> = AttributeKey<_>("StepperValue")
    let StepperIncrementAttribKey : AttributeKey<_> = AttributeKey<_>("StepperIncrement")
    let SwitchToggledAttribKey : AttributeKey<_> = AttributeKey<_>("SwitchToggled")
    let SwitchIsToggledAttribKey : AttributeKey<_> = AttributeKey<_>("SwitchIsToggled")
    let SwitchOnColorAttribKey : AttributeKey<_> = AttributeKey<_>("SwitchOnColor")
    let CellHeightAttribKey : AttributeKey<_> = AttributeKey<_>("CellHeight")
    let CellIsEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("CellIsEnabled")
    let SwitchCellOnChangedAttribKey : AttributeKey<_> = AttributeKey<_>("SwitchCellOnChanged")
    let SwitchCellOnAttribKey : AttributeKey<_> = AttributeKey<_>("SwitchCellOn")
    let SwitchCellTextAttribKey : AttributeKey<_> = AttributeKey<_>("SwitchCellText")
    let SwitchCellOnColorAttribKey : AttributeKey<_> = AttributeKey<_>("SwitchCellOnColor")
    let TableViewIntentAttribKey : AttributeKey<_> = AttributeKey<_>("TableViewIntent")
    let TableViewHasUnevenRowsAttribKey : AttributeKey<_> = AttributeKey<_>("TableViewHasUnevenRows")
    let TableViewRowHeightAttribKey : AttributeKey<_> = AttributeKey<_>("TableViewRowHeight")
    let TableViewRootAttribKey : AttributeKey<_> = AttributeKey<_>("TableViewRoot")
    let GridRowAttribKey : AttributeKey<_> = AttributeKey<_>("GridRow")
    let GridRowSpanAttribKey : AttributeKey<_> = AttributeKey<_>("GridRowSpan")
    let GridColumnAttribKey : AttributeKey<_> = AttributeKey<_>("GridColumn")
    let GridColumnSpanAttribKey : AttributeKey<_> = AttributeKey<_>("GridColumnSpan")
    let GridRowDefinitionsAttribKey : AttributeKey<_> = AttributeKey<_>("GridRowDefinitions")
    let GridColumnDefinitionsAttribKey : AttributeKey<_> = AttributeKey<_>("GridColumnDefinitions")
    let GridRowSpacingAttribKey : AttributeKey<_> = AttributeKey<_>("GridRowSpacing")
    let GridColumnSpacingAttribKey : AttributeKey<_> = AttributeKey<_>("GridColumnSpacing")
    let GridChildrenAttribKey : AttributeKey<_> = AttributeKey<_>("GridChildren")
    let AbsoluteLayoutLayoutBoundsAttribKey : AttributeKey<_> = AttributeKey<_>("AbsoluteLayoutLayoutBounds")
    let AbsoluteLayoutLayoutFlagsAttribKey : AttributeKey<_> = AttributeKey<_>("AbsoluteLayoutLayoutFlags")
    let AbsoluteLayoutChildrenAttribKey : AttributeKey<_> = AttributeKey<_>("AbsoluteLayoutChildren")
    let RelativeLayoutBoundsConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("RelativeLayoutBoundsConstraint")
    let RelativeLayoutHeightConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("RelativeLayoutHeightConstraint")
    let RelativeLayoutWidthConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("RelativeLayoutWidthConstraint")
    let RelativeLayoutXConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("RelativeLayoutXConstraint")
    let RelativeLayoutYConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("RelativeLayoutYConstraint")
    let RelativeLayoutChildrenAttribKey : AttributeKey<_> = AttributeKey<_>("RelativeLayoutChildren")
    let FlexLayoutAlignSelfAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutAlignSelf")
    let FlexLayoutOrderAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutOrder")
    let FlexLayoutBasisAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutBasis")
    let FlexLayoutGrowAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutGrow")
    let FlexLayoutShrinkAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutShrink")
    let FlexLayoutAlignContentAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutAlignContent")
    let FlexLayoutAlignItemsAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutAlignItems")
    let FlexLayoutDirectionAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutDirection")
    let FlexLayoutPositionAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutPosition")
    let FlexLayoutWrapAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutWrap")
    let FlexLayoutChildrenAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutChildren")
    let ContentViewContentAttribKey : AttributeKey<_> = AttributeKey<_>("ContentViewContent")

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
        match prevElementAutomationIdOpt, currElementAutomationIdOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AutomationId <-  currValue
        | ValueSome _, ValueNone -> target.AutomationId <- null
        | ValueNone, ValueNone -> ()
        match prevElementClassIdOpt, currElementClassIdOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ClassId <-  currValue
        | ValueSome _, ValueNone -> target.ClassId <- null
        | ValueNone, ValueNone -> ()
        match prevElementStyleIdOpt, currElementStyleIdOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.StyleId <-  currValue
        | ValueSome _, ValueNone -> target.StyleId <- null
        | ValueNone, ValueNone -> ()
        match prevElementRefOpt, currElementRefOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Ref <-  currValue
        | ValueSome _, ValueNone -> target.Ref <- null
        | ValueNone, ValueNone -> ()
        match prevElementTagOpt, currElementTagOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Tag <-  currValue
        | ValueSome _, ValueNone -> target.Tag <- null
        | ValueNone, ValueNone -> ()
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
        match prevNavigableElementStyleOpt, currNavigableElementStyleOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Style <-  currValue
        | ValueSome _, ValueNone -> target.Style <- null
        | ValueNone, ValueNone -> ()
        match prevNavigableElementStyleClassOpt, currNavigableElementStyleClassOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.StyleClass <- ViewConverters.convertStyleClassToStringList currValue
        | ValueSome _, ValueNone -> target.StyleClass <- InputTypes.StyleClass.None
        | ValueNone, ValueNone -> ()

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
        match prevVisualElementAnchorXOpt, currVisualElementAnchorXOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AnchorX <-  currValue
        | ValueSome _, ValueNone -> target.AnchorX <- 0.5
        | ValueNone, ValueNone -> ()
        match prevVisualElementAnchorYOpt, currVisualElementAnchorYOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AnchorY <-  currValue
        | ValueSome _, ValueNone -> target.AnchorY <- 0.5
        | ValueNone, ValueNone -> ()
        match prevVisualElementBackgroundColorOpt, currVisualElementBackgroundColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BackgroundColor <-  currValue
        | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevVisualElementFlowDirectionOpt, currVisualElementFlowDirectionOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FlowDirection <-  currValue
        | ValueSome _, ValueNone -> target.FlowDirection <- Xamarin.Forms.FlowDirection.MatchParent
        | ValueNone, ValueNone -> ()
        match prevVisualElementHeightOpt, currVisualElementHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Height <-  currValue
        | ValueSome _, ValueNone -> target.Height <- -1
        | ValueNone, ValueNone -> ()
        match prevVisualElementInputTransparentOpt, currVisualElementInputTransparentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.InputTransparent <-  currValue
        | ValueSome _, ValueNone -> target.InputTransparent <- false
        | ValueNone, ValueNone -> ()
        match prevVisualElementIsEnabledOpt, currVisualElementIsEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsEnabled <-  currValue
        | ValueSome _, ValueNone -> target.IsEnabled <- true
        | ValueNone, ValueNone -> ()
        match prevVisualElementIsTabStopOpt, currVisualElementIsTabStopOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsTabStop <-  currValue
        | ValueSome _, ValueNone -> target.IsTabStop <- true
        | ValueNone, ValueNone -> ()
        match prevVisualElementIsVisibleOpt, currVisualElementIsVisibleOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsVisible <-  currValue
        | ValueSome _, ValueNone -> target.IsVisible <- true
        | ValueNone, ValueNone -> ()
        match prevVisualElementMinimumHeightOpt, currVisualElementMinimumHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MinimumHeight <-  currValue
        | ValueSome _, ValueNone -> target.MinimumHeight <- -1
        | ValueNone, ValueNone -> ()
        match prevVisualElementMinimumWidthOpt, currVisualElementMinimumWidthOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MinimumWidth <-  currValue
        | ValueSome _, ValueNone -> target.MinimumWidth <- -1
        | ValueNone, ValueNone -> ()
        match prevVisualElementOpacityOpt, currVisualElementOpacityOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Opacity <-  currValue
        | ValueSome _, ValueNone -> target.Opacity <- 1
        | ValueNone, ValueNone -> ()
        match prevVisualElementRotationOpt, currVisualElementRotationOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Rotation <-  currValue
        | ValueSome _, ValueNone -> target.Rotation <- 0
        | ValueNone, ValueNone -> ()
        match prevVisualElementRotationXOpt, currVisualElementRotationXOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RotationX <-  currValue
        | ValueSome _, ValueNone -> target.RotationX <- 0
        | ValueNone, ValueNone -> ()
        match prevVisualElementRotationYOpt, currVisualElementRotationYOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RotationY <-  currValue
        | ValueSome _, ValueNone -> target.RotationY <- 0
        | ValueNone, ValueNone -> ()
        match prevVisualElementScaleOpt, currVisualElementScaleOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Scale <-  currValue
        | ValueSome _, ValueNone -> target.Scale <- 1
        | ValueNone, ValueNone -> ()
        match prevVisualElementScaleXOpt, currVisualElementScaleXOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ScaleX <-  currValue
        | ValueSome _, ValueNone -> target.ScaleX <- 1
        | ValueNone, ValueNone -> ()
        match prevVisualElementScaleYOpt, currVisualElementScaleYOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ScaleY <-  currValue
        | ValueSome _, ValueNone -> target.ScaleY <- 1
        | ValueNone, ValueNone -> ()
        match prevVisualElementTabIndexOpt, currVisualElementTabIndexOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TabIndex <-  currValue
        | ValueSome _, ValueNone -> target.TabIndex <- 0
        | ValueNone, ValueNone -> ()
        match prevVisualElementTranslationXOpt, currVisualElementTranslationXOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TranslationX <-  currValue
        | ValueSome _, ValueNone -> target.TranslationX <- 0
        | ValueNone, ValueNone -> ()
        match prevVisualElementTranslationYOpt, currVisualElementTranslationYOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TranslationY <-  currValue
        | ValueSome _, ValueNone -> target.TranslationY <- 0
        | ValueNone, ValueNone -> ()
        match prevVisualElementVisualOpt, currVisualElementVisualOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Visual <-  currValue
        | ValueSome _, ValueNone -> target.Visual <- Xamarin.Forms.VisualMarker.MatchParentVisual
        | ValueNone, ValueNone -> ()
        match prevVisualElementWidthOpt, currVisualElementWidthOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Width <-  currValue
        | ValueSome _, ValueNone -> target.Width <- -1
        | ValueNone, ValueNone -> ()
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
        match gestureRecognizers with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ViewGestureRecognizersAttribKey, Array.fromList(v)) 
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
                currViewGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement array)
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
                    prevViewGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement array)
        match prevViewHorizontalOptionsOpt, currViewHorizontalOptionsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HorizontalOptions <-  currValue
        | ValueSome _, ValueNone -> target.HorizontalOptions <- Xamarin.Forms.LayoutOptions.Fill
        | ValueNone, ValueNone -> ()
        match prevViewVerticalOptionsOpt, currViewVerticalOptionsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.VerticalOptions <-  currValue
        | ValueSome _, ValueNone -> target.VerticalOptions <- Xamarin.Forms.LayoutOptions.Fill
        | ValueNone, ValueNone -> ()
        match prevViewMarginOpt, currViewMarginOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Margin <- ViewConverters.convertFabulousThicknessToXamarinFormsThickness currValue
        | ValueSome _, ValueNone -> target.Margin <- InputTypes.Thickness.Uniform 0.
        | ValueNone, ValueNone -> ()
        match prevViewGestureRecognizersOpt, currViewGestureRecognizersOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.GestureRecognizers <-  currValue
        | ValueSome _, ValueNone -> target.GestureRecognizers <- []
        | ValueNone, ValueNone -> ()

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
        match gestureRecognizers with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GestureElementGestureRecognizersAttribKey, Array.fromList(v)) 
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
                currGestureElementGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement array)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.GestureElementGestureRecognizersAttribKey.KeyValue then 
                    prevGestureElementGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement array)
        match prevGestureElementGestureRecognizersOpt, currGestureElementGestureRecognizersOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.GestureRecognizers <-  currValue
        | ValueSome _, ValueNone -> target.GestureRecognizers <- []
        | ValueNone, ValueNone -> ()

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
        match prevPanGestureRecognizerTouchPointsOpt, currPanGestureRecognizerTouchPointsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TouchPoints <-  currValue
        | ValueSome _, ValueNone -> target.TouchPoints <- 1
        | ValueNone, ValueNone -> ()
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
        match prevClickGestureRecognizerCommandOpt, currClickGestureRecognizerCommandOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Command <-  currValue
        | ValueSome _, ValueNone -> target.Command <- null
        | ValueNone, ValueNone -> ()
        match prevClickGestureRecognizerNumberOfClicksRequiredOpt, currClickGestureRecognizerNumberOfClicksRequiredOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.NumberOfClicksRequired <-  currValue
        | ValueSome _, ValueNone -> target.NumberOfClicksRequired <- 1
        | ValueNone, ValueNone -> ()
        match prevClickGestureRecognizerButtonsOpt, currClickGestureRecognizerButtonsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Buttons <-  currValue
        | ValueSome _, ValueNone -> target.Buttons <- Xamarin.Forms.ButtonsMask.Primary
        | ValueNone, ValueNone -> ()

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
        match prevSwipeGestureRecognizerCommandOpt, currSwipeGestureRecognizerCommandOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Command <-  currValue
        | ValueSome _, ValueNone -> target.Command <- null
        | ValueNone, ValueNone -> ()
        match prevSwipeGestureRecognizerDirectionOpt, currSwipeGestureRecognizerDirectionOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Direction <-  currValue
        | ValueSome _, ValueNone -> target.Direction <- Unchecked.defaultof<Xamarin.Forms.SwipeDirection>
        | ValueNone, ValueNone -> ()
        match prevSwipeGestureRecognizerThresholdOpt, currSwipeGestureRecognizerThresholdOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Threshold <-  currValue
        | ValueSome _, ValueNone -> target.Threshold <- 100u
        | ValueNone, ValueNone -> ()
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
        match prevActivityIndicatorColorOpt, currActivityIndicatorColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Color <-  currValue
        | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevActivityIndicatorIsRunningOpt, currActivityIndicatorIsRunningOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsRunning <-  currValue
        | ValueSome _, ValueNone -> target.IsRunning <- false
        | ValueNone, ValueNone -> ()

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
        match prevBoxViewColorOpt, currBoxViewColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Color <-  currValue
        | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevBoxViewCornerRadiusOpt, currBoxViewCornerRadiusOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CornerRadius <-  currValue
        | ValueSome _, ValueNone -> target.CornerRadius <- Xamarin.Forms.CornerRadius(0.)
        | ValueNone, ValueNone -> ()

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
        match prevProgressBarProgressOpt, currProgressBarProgressOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Progress <-  currValue
        | ValueSome _, ValueNone -> target.Progress <- 0
        | ValueNone, ValueNone -> ()

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
        match prevLayoutIsClippedToBoundsOpt, currLayoutIsClippedToBoundsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsClippedToBounds <-  currValue
        | ValueSome _, ValueNone -> target.IsClippedToBounds <- false
        | ValueNone, ValueNone -> ()
        match prevLayoutPaddingOpt, currLayoutPaddingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Padding <-  currValue
        | ValueSome _, ValueNone -> target.Padding <- Xamarin.Forms.Thickness(0.)
        | ValueNone, ValueNone -> ()

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
        match prevScrollViewContentOpt, currScrollViewContentOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseView prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.Content)
        | _, ValueSome newValue ->
            target.Content <- (newValue.Create() :?> ViewElement)
        | ValueSome _, ValueNone ->
            target.Content <- null
        | ValueNone, ValueNone -> ()
        match prevScrollViewOrientationOpt, currScrollViewOrientationOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Orientation <-  currValue
        | ValueSome _, ValueNone -> target.Orientation <- Xamarin.Forms.ScrollOrientation.Vertical
        | ValueNone, ValueNone -> ()
        match prevScrollViewHorizontalScrollBarVisibilityOpt, currScrollViewHorizontalScrollBarVisibilityOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HorizontalScrollBarVisibility <-  currValue
        | ValueSome _, ValueNone -> target.HorizontalScrollBarVisibility <- Xamarin.Forms.ScrollBarVisibility.Default
        | ValueNone, ValueNone -> ()
        match prevScrollViewVerticalScrollBarVisibilityOpt, currScrollViewVerticalScrollBarVisibilityOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.VerticalScrollBarVisibility <-  currValue
        | ValueSome _, ValueNone -> target.VerticalScrollBarVisibility <- Xamarin.Forms.ScrollBarVisibility.Default
        | ValueNone, ValueNone -> ()
        match prevScrollViewScrollToOpt, currScrollViewScrollToOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ScrollTo <-  currValue
        | ValueSome _, ValueNone -> target.ScrollTo <- null
        | ValueNone, ValueNone -> ()
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
        match prevButtonTextOpt, currButtonTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevButtonCommandOpt, currButtonCommandOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Command <-  currValue
        | ValueSome _, ValueNone -> target.Command <- null
        | ValueNone, ValueNone -> ()
        match prevButtonBorderColorOpt, currButtonBorderColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BorderColor <-  currValue
        | ValueSome _, ValueNone -> target.BorderColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevButtonBorderWidthOpt, currButtonBorderWidthOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BorderWidth <-  currValue
        | ValueSome _, ValueNone -> target.BorderWidth <- -1
        | ValueNone, ValueNone -> ()
        match prevButtonContentLayoutOpt, currButtonContentLayoutOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ContentLayout <-  currValue
        | ValueSome _, ValueNone -> target.ContentLayout <- Xamarin.Forms.Button.ButtonContentLayout(Xamarin.Forms.Button.ButtonContentLayout.ImagePosition.Left, 10)
        | ValueNone, ValueNone -> ()
        match prevButtonCornerRadiusOpt, currButtonCornerRadiusOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CornerRadius <-  currValue
        | ValueSome _, ValueNone -> target.CornerRadius <- -1
        | ValueNone, ValueNone -> ()
        match prevButtonFontFamilyOpt, currButtonFontFamilyOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontFamily <-  currValue
        | ValueSome _, ValueNone -> target.FontFamily <- null
        | ValueNone, ValueNone -> ()
        match prevButtonFontAttributesOpt, currButtonFontAttributesOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontAttributes <-  currValue
        | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
        | ValueNone, ValueNone -> ()
        match prevButtonFontSizeOpt, currButtonFontSizeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontSize <-  currValue
        | ValueSome _, ValueNone -> target.FontSize <- -1
        | ValueNone, ValueNone -> ()
        match prevButtonImageOpt, currButtonImageOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Image <- ViewConverters.convertFabulousImageToXamarinFormsImageSource currValue
        | ValueSome _, ValueNone -> target.Image <- InputTypes.Image.None
        | ValueNone, ValueNone -> ()
        match prevButtonTextColorOpt, currButtonTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextColor <-  currValue
        | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevButtonPaddingOpt, currButtonPaddingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Padding <-  currValue
        | ValueSome _, ValueNone -> target.Padding <- Xamarin.Forms.Thickness(0.)
        | ValueNone, ValueNone -> ()

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
        match prevSliderMinimumMaximumOpt, currSliderMinimumMaximumOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MinimumMaximum <-  currValue
        | ValueSome _, ValueNone -> target.MinimumMaximum <- (0.0, 1.0)
        | ValueNone, ValueNone -> ()
        match prevSliderValueOpt, currSliderValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Value <-  currValue
        | ValueSome _, ValueNone -> target.Value <- 0
        | ValueNone, ValueNone -> ()
        match prevSliderThumbImageSourceOpt, currSliderThumbImageSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ThumbImageSource <-  currValue
        | ValueSome _, ValueNone -> target.ThumbImageSource <- null
        | ValueNone, ValueNone -> ()
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

    /// Builds the attributes for a Stepper in the view
    static member inline BuildStepper(attribCount: int,
                                      ?minimumMaximum: float * float,
                                      ?value: float,
                                      ?increment: float,
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
                                      ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                      ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                      ?created: obj -> unit) = 

        let attribCount = match minimumMaximum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match value with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match increment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match valueChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, 
                                                   ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, ?height: float, ?inputTransparent: bool, 
                                                   ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, ?minimumHeight: float, ?minimumWidth: float, 
                                                   ?opacity: float, ?rotation: float, ?rotationX: float, ?rotationY: float, ?scale: float, 
                                                   ?scaleX: float, ?scaleY: float, ?tabIndex: int, ?translationX: float, ?translationY: float, 
                                                   ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, 
                                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match minimumMaximum with None -> () | Some v -> attribBuilder.Add(ViewAttributes.StepperMinimumMaximumAttribKey, (v)) 
        match value with None -> () | Some v -> attribBuilder.Add(ViewAttributes.StepperValueAttribKey, (v)) 
        match increment with None -> () | Some v -> attribBuilder.Add(ViewAttributes.StepperIncrementAttribKey, (v)) 
        match valueChanged with None -> () | Some v -> attribBuilder.Add(ViewAttributes.StepperValueChangedAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncStepper : (unit -> Xamarin.Forms.Stepper) = (fun () -> ViewBuilders.CreateStepper()) with get, set

    static member CreateStepper () : Xamarin.Forms.Stepper =
        new Xamarin.Forms.Stepper()

    static member val UpdateFuncStepper =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Stepper) -> ViewBuilders.UpdateStepper (prevOpt, curr, target)) 

    static member UpdateStepper (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Stepper) = 
        ViewBuilders.UpdateView (prevOpt, curr, target)
        let mutable prevStepperValueChangedOpt = ValueNone
        let mutable currStepperValueChangedOpt = ValueNone
        let mutable prevStepperMinimumMaximumOpt = ValueNone
        let mutable currStepperMinimumMaximumOpt = ValueNone
        let mutable prevStepperValueOpt = ValueNone
        let mutable currStepperValueOpt = ValueNone
        let mutable prevStepperIncrementOpt = ValueNone
        let mutable currStepperIncrementOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.StepperValueChangedAttribKey.KeyValue then 
                currStepperValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
            if kvp.Key = ViewAttributes.StepperMinimumMaximumAttribKey.KeyValue then 
                currStepperMinimumMaximumOpt <- ValueSome (kvp.Value :?> float * float)
            if kvp.Key = ViewAttributes.StepperValueAttribKey.KeyValue then 
                currStepperValueOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.StepperIncrementAttribKey.KeyValue then 
                currStepperIncrementOpt <- ValueSome (kvp.Value :?> float)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.StepperValueChangedAttribKey.KeyValue then 
                    prevStepperValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
                if kvp.Key = ViewAttributes.StepperMinimumMaximumAttribKey.KeyValue then 
                    prevStepperMinimumMaximumOpt <- ValueSome (kvp.Value :?> float * float)
                if kvp.Key = ViewAttributes.StepperValueAttribKey.KeyValue then 
                    prevStepperValueOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.StepperIncrementAttribKey.KeyValue then 
                    prevStepperIncrementOpt <- ValueSome (kvp.Value :?> float)
        let shouldUpdateStepperValueChanged = not ((identical prevStepperValueChangedOpt currStepperValueChangedOpt))
        if shouldUpdateStepperValueChanged then
            match prevStepperValueChangedOpt with
            | ValueSome prevValue -> target.ValueChanged.RemoveHandler(prevValue)
            | ValueNone -> ()
        match prevStepperMinimumMaximumOpt, currStepperMinimumMaximumOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MinimumMaximum <-  currValue
        | ValueSome _, ValueNone -> target.MinimumMaximum <- (0.0, 1.0)
        | ValueNone, ValueNone -> ()
        match prevStepperValueOpt, currStepperValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Value <-  currValue
        | ValueSome _, ValueNone -> target.Value <- 0
        | ValueNone, ValueNone -> ()
        match prevStepperIncrementOpt, currStepperIncrementOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Increment <-  currValue
        | ValueSome _, ValueNone -> target.Increment <- 1
        | ValueNone, ValueNone -> ()
        if shouldUpdateStepperValueChanged then
            match currStepperValueChangedOpt with
            | ValueSome currValue -> target.ValueChanged.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructStepper(?minimumMaximum: float * float,
                                          ?value: float,
                                          ?increment: float,
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
                                          ?ref: ViewRef<Xamarin.Forms.Stepper>,
                                          ?tag: obj,
                                          ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit,
                                          ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                          ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                          ?created: (Xamarin.Forms.Stepper -> unit)) = 

        let attribBuilder = ViewBuilders.BuildStepper(0,
                               ?minimumMaximum=minimumMaximum,
                               ?value=value,
                               ?increment=increment,
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
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Stepper>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?valueChanged=valueChanged,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Stepper> target))))

        ViewElement.Create<Xamarin.Forms.Stepper>(ViewBuilders.CreateFuncStepper, ViewBuilders.UpdateFuncStepper, attribBuilder)

    /// Builds the attributes for a Switch in the view
    static member inline BuildSwitch(attribCount: int,
                                     ?isToggled: bool,
                                     ?onColor: Xamarin.Forms.Color,
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
                                     ?toggled: Xamarin.Forms.ToggledEventArgs -> unit,
                                     ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?created: obj -> unit) = 

        let attribCount = match isToggled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match onColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match toggled with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, 
                                                   ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, ?height: float, ?inputTransparent: bool, 
                                                   ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, ?minimumHeight: float, ?minimumWidth: float, 
                                                   ?opacity: float, ?rotation: float, ?rotationX: float, ?rotationY: float, ?scale: float, 
                                                   ?scaleX: float, ?scaleY: float, ?tabIndex: int, ?translationX: float, ?translationY: float, 
                                                   ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, 
                                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match isToggled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwitchIsToggledAttribKey, (v)) 
        match onColor with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwitchOnColorAttribKey, (v)) 
        match toggled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwitchToggledAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncSwitch : (unit -> Xamarin.Forms.Switch) = (fun () -> ViewBuilders.CreateSwitch()) with get, set

    static member CreateSwitch () : Xamarin.Forms.Switch =
        new Xamarin.Forms.Switch()

    static member val UpdateFuncSwitch =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Switch) -> ViewBuilders.UpdateSwitch (prevOpt, curr, target)) 

    static member UpdateSwitch (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Switch) = 
        ViewBuilders.UpdateView (prevOpt, curr, target)
        let mutable prevSwitchToggledOpt = ValueNone
        let mutable currSwitchToggledOpt = ValueNone
        let mutable prevSwitchIsToggledOpt = ValueNone
        let mutable currSwitchIsToggledOpt = ValueNone
        let mutable prevSwitchOnColorOpt = ValueNone
        let mutable currSwitchOnColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.SwitchToggledAttribKey.KeyValue then 
                currSwitchToggledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
            if kvp.Key = ViewAttributes.SwitchIsToggledAttribKey.KeyValue then 
                currSwitchIsToggledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.SwitchOnColorAttribKey.KeyValue then 
                currSwitchOnColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.SwitchToggledAttribKey.KeyValue then 
                    prevSwitchToggledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
                if kvp.Key = ViewAttributes.SwitchIsToggledAttribKey.KeyValue then 
                    prevSwitchIsToggledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.SwitchOnColorAttribKey.KeyValue then 
                    prevSwitchOnColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        let shouldUpdateSwitchToggled = not ((identical prevSwitchToggledOpt currSwitchToggledOpt))
        if shouldUpdateSwitchToggled then
            match prevSwitchToggledOpt with
            | ValueSome prevValue -> target.Toggled.RemoveHandler(prevValue)
            | ValueNone -> ()
        match prevSwitchIsToggledOpt, currSwitchIsToggledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsToggled <-  currValue
        | ValueSome _, ValueNone -> target.IsToggled <- false
        | ValueNone, ValueNone -> ()
        match prevSwitchOnColorOpt, currSwitchOnColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.OnColor <-  currValue
        | ValueSome _, ValueNone -> target.OnColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        if shouldUpdateSwitchToggled then
            match currSwitchToggledOpt with
            | ValueSome currValue -> target.Toggled.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructSwitch(?isToggled: bool,
                                         ?onColor: Xamarin.Forms.Color,
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
                                         ?ref: ViewRef<Xamarin.Forms.Switch>,
                                         ?tag: obj,
                                         ?toggled: Xamarin.Forms.ToggledEventArgs -> unit,
                                         ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                         ?created: (Xamarin.Forms.Switch -> unit)) = 

        let attribBuilder = ViewBuilders.BuildSwitch(0,
                               ?isToggled=isToggled,
                               ?onColor=onColor,
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
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Switch>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?toggled=toggled,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Switch> target))))

        ViewElement.Create<Xamarin.Forms.Switch>(ViewBuilders.CreateFuncSwitch, ViewBuilders.UpdateFuncSwitch, attribBuilder)

    /// Builds the attributes for a Cell in the view
    static member inline BuildCell(attribCount: int,
                                   ?height: float,
                                   ?isEnabled: bool,
                                   ?automationId: string,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?ref: ViewRef,
                                   ?tag: obj,
                                   ?created: obj -> unit) = 

        let attribCount = match height with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isEnabled with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildElement(attribCount, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, 
                                                      ?created: obj -> unit)
        match height with None -> () | Some v -> attribBuilder.Add(ViewAttributes.CellHeightAttribKey, (v)) 
        match isEnabled with None -> () | Some v -> attribBuilder.Add(ViewAttributes.CellIsEnabledAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncCell : (unit -> Xamarin.Forms.Cell) = (fun () -> ViewBuilders.CreateCell()) with get, set

    static member CreateCell () : Xamarin.Forms.Cell =
        new Xamarin.Forms.Cell()

    static member val UpdateFuncCell =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Cell) -> ViewBuilders.UpdateCell (prevOpt, curr, target)) 

    static member UpdateCell (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Cell) = 
        ViewBuilders.UpdateElement (prevOpt, curr, target)
        let mutable prevCellHeightOpt = ValueNone
        let mutable currCellHeightOpt = ValueNone
        let mutable prevCellIsEnabledOpt = ValueNone
        let mutable currCellIsEnabledOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.CellHeightAttribKey.KeyValue then 
                currCellHeightOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.CellIsEnabledAttribKey.KeyValue then 
                currCellIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.CellHeightAttribKey.KeyValue then 
                    prevCellHeightOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.CellIsEnabledAttribKey.KeyValue then 
                    prevCellIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
        match prevCellHeightOpt, currCellHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Height <-  currValue
        | ValueSome _, ValueNone -> target.Height <- -1.0
        | ValueNone, ValueNone -> ()
        match prevCellIsEnabledOpt, currCellIsEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsEnabled <-  currValue
        | ValueSome _, ValueNone -> target.IsEnabled <- true
        | ValueNone, ValueNone -> ()

    static member inline ConstructCell(?height: float,
                                       ?isEnabled: bool,
                                       ?automationId: string,
                                       ?classId: string,
                                       ?styleId: string,
                                       ?ref: ViewRef<Xamarin.Forms.Cell>,
                                       ?tag: obj,
                                       ?created: (Xamarin.Forms.Cell -> unit)) = 

        let attribBuilder = ViewBuilders.BuildCell(0,
                               ?height=height,
                               ?isEnabled=isEnabled,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Cell>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Cell> target))))

        ViewElement.Create<Xamarin.Forms.Cell>(ViewBuilders.CreateFuncCell, ViewBuilders.UpdateFuncCell, attribBuilder)

    /// Builds the attributes for a SwitchCell in the view
    static member inline BuildSwitchCell(attribCount: int,
                                         ?on: bool,
                                         ?text: string,
                                         ?onColor: Xamarin.Forms.Color,
                                         ?height: float,
                                         ?isEnabled: bool,
                                         ?automationId: string,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?ref: ViewRef,
                                         ?tag: obj,
                                         ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit,
                                         ?created: obj -> unit) = 

        let attribCount = match on with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match onColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match onChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildCell(attribCount, ?height: float, ?isEnabled: bool, ?automationId: string, ?classId: string, ?styleId: string, 
                                                   ?ref: ViewRef, ?tag: obj, ?created: obj -> unit)
        match on with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwitchCellOnAttribKey, (v)) 
        match text with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwitchCellTextAttribKey, (v)) 
        match onColor with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwitchCellOnColorAttribKey, (v)) 
        match onChanged with None -> () | Some v -> attribBuilder.Add(ViewAttributes.SwitchCellOnChangedAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncSwitchCell : (unit -> Xamarin.Forms.SwitchCell) = (fun () -> ViewBuilders.CreateSwitchCell()) with get, set

    static member CreateSwitchCell () : Xamarin.Forms.SwitchCell =
        new Xamarin.Forms.SwitchCell()

    static member val UpdateFuncSwitchCell =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.SwitchCell) -> ViewBuilders.UpdateSwitchCell (prevOpt, curr, target)) 

    static member UpdateSwitchCell (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.SwitchCell) = 
        ViewBuilders.UpdateCell (prevOpt, curr, target)
        let mutable prevSwitchCellOnChangedOpt = ValueNone
        let mutable currSwitchCellOnChangedOpt = ValueNone
        let mutable prevSwitchCellOnOpt = ValueNone
        let mutable currSwitchCellOnOpt = ValueNone
        let mutable prevSwitchCellTextOpt = ValueNone
        let mutable currSwitchCellTextOpt = ValueNone
        let mutable prevSwitchCellOnColorOpt = ValueNone
        let mutable currSwitchCellOnColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.SwitchCellOnChangedAttribKey.KeyValue then 
                currSwitchCellOnChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
            if kvp.Key = ViewAttributes.SwitchCellOnAttribKey.KeyValue then 
                currSwitchCellOnOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.SwitchCellTextAttribKey.KeyValue then 
                currSwitchCellTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = ViewAttributes.SwitchCellOnColorAttribKey.KeyValue then 
                currSwitchCellOnColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.SwitchCellOnChangedAttribKey.KeyValue then 
                    prevSwitchCellOnChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
                if kvp.Key = ViewAttributes.SwitchCellOnAttribKey.KeyValue then 
                    prevSwitchCellOnOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.SwitchCellTextAttribKey.KeyValue then 
                    prevSwitchCellTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = ViewAttributes.SwitchCellOnColorAttribKey.KeyValue then 
                    prevSwitchCellOnColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        let shouldUpdateSwitchCellOnChanged = not ((identical prevSwitchCellOnChangedOpt currSwitchCellOnChangedOpt))
        if shouldUpdateSwitchCellOnChanged then
            match prevSwitchCellOnChangedOpt with
            | ValueSome prevValue -> target.OnChanged.RemoveHandler(prevValue)
            | ValueNone -> ()
        match prevSwitchCellOnOpt, currSwitchCellOnOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.On <-  currValue
        | ValueSome _, ValueNone -> target.On <- false
        | ValueNone, ValueNone -> ()
        match prevSwitchCellTextOpt, currSwitchCellTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevSwitchCellOnColorOpt, currSwitchCellOnColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.OnColor <-  currValue
        | ValueSome _, ValueNone -> target.OnColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        if shouldUpdateSwitchCellOnChanged then
            match currSwitchCellOnChangedOpt with
            | ValueSome currValue -> target.OnChanged.AddHandler(currValue)
            | ValueNone -> ()

    static member inline ConstructSwitchCell(?on: bool,
                                             ?text: string,
                                             ?onColor: Xamarin.Forms.Color,
                                             ?height: float,
                                             ?isEnabled: bool,
                                             ?automationId: string,
                                             ?classId: string,
                                             ?styleId: string,
                                             ?ref: ViewRef<Xamarin.Forms.SwitchCell>,
                                             ?tag: obj,
                                             ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit,
                                             ?created: (Xamarin.Forms.SwitchCell -> unit)) = 

        let attribBuilder = ViewBuilders.BuildSwitchCell(0,
                               ?on=on,
                               ?text=text,
                               ?onColor=onColor,
                               ?height=height,
                               ?isEnabled=isEnabled,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.SwitchCell>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?onChanged=onChanged,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.SwitchCell> target))))

        ViewElement.Create<Xamarin.Forms.SwitchCell>(ViewBuilders.CreateFuncSwitchCell, ViewBuilders.UpdateFuncSwitchCell, attribBuilder)

    /// Builds the attributes for a TableView in the view
    static member inline BuildTableView(attribCount: int,
                                        ?intent: Xamarin.Forms.TableIntent,
                                        ?hasUnevenRows: bool,
                                        ?rowHeight: int,
                                        ?items: (string * ViewElement list) list,
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

        let attribCount = match intent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasUnevenRows with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rowHeight with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match items with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildView(attribCount, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, ?gestureRecognizers: ViewElement list, ?anchorX: float, 
                                                   ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, ?height: float, ?inputTransparent: bool, 
                                                   ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, ?minimumHeight: float, ?minimumWidth: float, 
                                                   ?opacity: float, ?rotation: float, ?rotationX: float, ?rotationY: float, ?scale: float, 
                                                   ?scaleX: float, ?scaleY: float, ?tabIndex: int, ?translationX: float, ?translationY: float, 
                                                   ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, ?styleClass: InputTypes.StyleClass, ?automationId: string, 
                                                   ?classId: string, ?styleId: string, ?ref: ViewRef, ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, 
                                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match intent with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TableViewIntentAttribKey, (v)) 
        match hasUnevenRows with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TableViewHasUnevenRowsAttribKey, (v)) 
        match rowHeight with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TableViewRowHeightAttribKey, (v)) 
        match items with None -> () | Some v -> attribBuilder.Add(ViewAttributes.TableViewRootAttribKey, Array.fromList(v)) 
        attribBuilder

    static member val CreateFuncTableView : (unit -> Xamarin.Forms.TableView) = (fun () -> ViewBuilders.CreateTableView()) with get, set

    static member CreateTableView () : Xamarin.Forms.TableView =
        new Xamarin.Forms.TableView()

    static member val UpdateFuncTableView =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TableView) -> ViewBuilders.UpdateTableView (prevOpt, curr, target)) 

    static member UpdateTableView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.TableView) = 
        ViewBuilders.UpdateView (prevOpt, curr, target)
        let mutable prevTableViewIntentOpt = ValueNone
        let mutable currTableViewIntentOpt = ValueNone
        let mutable prevTableViewHasUnevenRowsOpt = ValueNone
        let mutable currTableViewHasUnevenRowsOpt = ValueNone
        let mutable prevTableViewRowHeightOpt = ValueNone
        let mutable currTableViewRowHeightOpt = ValueNone
        let mutable prevTableViewRootOpt = ValueNone
        let mutable currTableViewRootOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.TableViewIntentAttribKey.KeyValue then 
                currTableViewIntentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TableIntent)
            if kvp.Key = ViewAttributes.TableViewHasUnevenRowsAttribKey.KeyValue then 
                currTableViewHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = ViewAttributes.TableViewRowHeightAttribKey.KeyValue then 
                currTableViewRowHeightOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.TableViewRootAttribKey.KeyValue then 
                currTableViewRootOpt <- ValueSome (kvp.Value :?> (string * ViewElement array) array)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.TableViewIntentAttribKey.KeyValue then 
                    prevTableViewIntentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TableIntent)
                if kvp.Key = ViewAttributes.TableViewHasUnevenRowsAttribKey.KeyValue then 
                    prevTableViewHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = ViewAttributes.TableViewRowHeightAttribKey.KeyValue then 
                    prevTableViewRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.TableViewRootAttribKey.KeyValue then 
                    prevTableViewRootOpt <- ValueSome (kvp.Value :?> (string * ViewElement array) array)
        match prevTableViewIntentOpt, currTableViewIntentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Intent <-  currValue
        | ValueSome _, ValueNone -> target.Intent <- Xamarin.Forms.TableIntent.Data
        | ValueNone, ValueNone -> ()
        match prevTableViewHasUnevenRowsOpt, currTableViewHasUnevenRowsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HasUnevenRows <-  currValue
        | ValueSome _, ValueNone -> target.HasUnevenRows <- false
        | ValueNone, ValueNone -> ()
        match prevTableViewRowHeightOpt, currTableViewRowHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RowHeight <-  currValue
        | ValueSome _, ValueNone -> target.RowHeight <- -1
        | ValueNone, ValueNone -> ()
        match prevTableViewRootOpt, currTableViewRootOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Root <-  currValue
        | ValueSome _, ValueNone -> target.Root <- []
        | ValueNone, ValueNone -> ()

    static member inline ConstructTableView(?intent: Xamarin.Forms.TableIntent,
                                            ?hasUnevenRows: bool,
                                            ?rowHeight: int,
                                            ?items: (string * ViewElement list) list,
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
                                            ?ref: ViewRef<Xamarin.Forms.TableView>,
                                            ?tag: obj,
                                            ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                            ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                            ?created: (Xamarin.Forms.TableView -> unit)) = 

        let attribBuilder = ViewBuilders.BuildTableView(0,
                               ?intent=intent,
                               ?hasUnevenRows=hasUnevenRows,
                               ?rowHeight=rowHeight,
                               ?items=items,
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
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.TableView>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.TableView> target))))

        ViewElement.Create<Xamarin.Forms.TableView>(ViewBuilders.CreateFuncTableView, ViewBuilders.UpdateFuncTableView, attribBuilder)

    /// Builds the attributes for a Grid in the view
    static member inline BuildGrid(attribCount: int,
                                   ?rowDefinitions: Xamarin.Forms.RowDefinitionCollection,
                                   ?columnDefinitions: Xamarin.Forms.ColumnDefinitionCollection,
                                   ?rowSpacing: float,
                                   ?columnSpacing: float,
                                   ?children: ViewElement list,
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

        let attribCount = match rowDefinitions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match columnDefinitions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rowSpacing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match columnSpacing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildLayout(attribCount, ?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, 
                                                     ?gestureRecognizers: ViewElement list, ?anchorX: float, ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, 
                                                     ?height: float, ?inputTransparent: bool, ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, 
                                                     ?minimumHeight: float, ?minimumWidth: float, ?opacity: float, ?rotation: float, ?rotationX: float, 
                                                     ?rotationY: float, ?scale: float, ?scaleX: float, ?scaleY: float, ?tabIndex: int, 
                                                     ?translationX: float, ?translationY: float, ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, 
                                                     ?styleClass: InputTypes.StyleClass, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                     ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match rowDefinitions with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GridRowDefinitionsAttribKey, (v)) 
        match columnDefinitions with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GridColumnDefinitionsAttribKey, (v)) 
        match rowSpacing with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GridRowSpacingAttribKey, (v)) 
        match columnSpacing with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GridColumnSpacingAttribKey, (v)) 
        match children with None -> () | Some v -> attribBuilder.Add(ViewAttributes.GridChildrenAttribKey, Array.fromList(v)) 
        attribBuilder

    static member val CreateFuncGrid : (unit -> Xamarin.Forms.Grid) = (fun () -> ViewBuilders.CreateGrid()) with get, set

    static member CreateGrid () : Xamarin.Forms.Grid =
        new Xamarin.Forms.Grid()

    static member val UpdateFuncGrid =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Grid) -> ViewBuilders.UpdateGrid (prevOpt, curr, target)) 

    static member UpdateGrid (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Grid) = 
        ViewBuilders.UpdateLayout (prevOpt, curr, target)
        let mutable prevGridRowDefinitionsOpt = ValueNone
        let mutable currGridRowDefinitionsOpt = ValueNone
        let mutable prevGridColumnDefinitionsOpt = ValueNone
        let mutable currGridColumnDefinitionsOpt = ValueNone
        let mutable prevGridRowSpacingOpt = ValueNone
        let mutable currGridRowSpacingOpt = ValueNone
        let mutable prevGridColumnSpacingOpt = ValueNone
        let mutable currGridColumnSpacingOpt = ValueNone
        let mutable prevGridChildrenOpt = ValueNone
        let mutable currGridChildrenOpt = ValueNone
        let mutable prevGridRowOpt = ValueNone
        let mutable currGridRowOpt = ValueNone
        let mutable prevGridRowSpanOpt = ValueNone
        let mutable currGridRowSpanOpt = ValueNone
        let mutable prevGridColumnOpt = ValueNone
        let mutable currGridColumnOpt = ValueNone
        let mutable prevGridColumnSpanOpt = ValueNone
        let mutable currGridColumnSpanOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.GridRowDefinitionsAttribKey.KeyValue then 
                currGridRowDefinitionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.RowDefinitionCollection)
            if kvp.Key = ViewAttributes.GridColumnDefinitionsAttribKey.KeyValue then 
                currGridColumnDefinitionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ColumnDefinitionCollection)
            if kvp.Key = ViewAttributes.GridRowSpacingAttribKey.KeyValue then 
                currGridRowSpacingOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.GridColumnSpacingAttribKey.KeyValue then 
                currGridColumnSpacingOpt <- ValueSome (kvp.Value :?> float)
            if kvp.Key = ViewAttributes.GridChildrenAttribKey.KeyValue then 
                currGridChildrenOpt <- ValueSome (kvp.Value :?> ViewElement array)
            if kvp.Key = ViewAttributes.GridRowAttribKey.KeyValue then 
                currGridRowOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.GridRowSpanAttribKey.KeyValue then 
                currGridRowSpanOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.GridColumnAttribKey.KeyValue then 
                currGridColumnOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.GridColumnSpanAttribKey.KeyValue then 
                currGridColumnSpanOpt <- ValueSome (kvp.Value :?> int)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.GridRowDefinitionsAttribKey.KeyValue then 
                    prevGridRowDefinitionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.RowDefinitionCollection)
                if kvp.Key = ViewAttributes.GridColumnDefinitionsAttribKey.KeyValue then 
                    prevGridColumnDefinitionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ColumnDefinitionCollection)
                if kvp.Key = ViewAttributes.GridRowSpacingAttribKey.KeyValue then 
                    prevGridRowSpacingOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.GridColumnSpacingAttribKey.KeyValue then 
                    prevGridColumnSpacingOpt <- ValueSome (kvp.Value :?> float)
                if kvp.Key = ViewAttributes.GridChildrenAttribKey.KeyValue then 
                    prevGridChildrenOpt <- ValueSome (kvp.Value :?> ViewElement array)
                if kvp.Key = ViewAttributes.GridRowAttribKey.KeyValue then 
                    prevGridRowOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.GridRowSpanAttribKey.KeyValue then 
                    prevGridRowSpanOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.GridColumnAttribKey.KeyValue then 
                    prevGridColumnOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.GridColumnSpanAttribKey.KeyValue then 
                    prevGridColumnSpanOpt <- ValueSome (kvp.Value :?> int)
        match prevGridRowDefinitionsOpt, currGridRowDefinitionsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RowDefinitions <-  currValue
        | ValueSome _, ValueNone -> target.RowDefinitions <- null
        | ValueNone, ValueNone -> ()
        match prevGridColumnDefinitionsOpt, currGridColumnDefinitionsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ColumnDefinitions <-  currValue
        | ValueSome _, ValueNone -> target.ColumnDefinitions <- null
        | ValueNone, ValueNone -> ()
        match prevGridRowSpacingOpt, currGridRowSpacingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RowSpacing <-  currValue
        | ValueSome _, ValueNone -> target.RowSpacing <- 6
        | ValueNone, ValueNone -> ()
        match prevGridColumnSpacingOpt, currGridColumnSpacingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ColumnSpacing <-  currValue
        | ValueSome _, ValueNone -> target.ColumnSpacing <- 6
        | ValueNone, ValueNone -> ()
        ViewUpdaters.updateCollectionGeneric prevGridChildrenOpt currGridChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            ViewUpdaters.canReuseView
            ViewUpdaters.updateChild

    static member inline ConstructGrid(?rowDefinitions: Xamarin.Forms.RowDefinitionCollection,
                                       ?columnDefinitions: Xamarin.Forms.ColumnDefinitionCollection,
                                       ?rowSpacing: float,
                                       ?columnSpacing: float,
                                       ?children: ViewElement list,
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
                                       ?ref: ViewRef<Xamarin.Forms.Grid>,
                                       ?tag: obj,
                                       ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                       ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                       ?created: (Xamarin.Forms.Grid -> unit)) = 

        let attribBuilder = ViewBuilders.BuildGrid(0,
                               ?rowDefinitions=rowDefinitions,
                               ?columnDefinitions=columnDefinitions,
                               ?rowSpacing=rowSpacing,
                               ?columnSpacing=columnSpacing,
                               ?children=children,
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
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Grid>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Grid> target))))

        ViewElement.Create<Xamarin.Forms.Grid>(ViewBuilders.CreateFuncGrid, ViewBuilders.UpdateFuncGrid, attribBuilder)

    /// Builds the attributes for a AbsoluteLayout in the view
    static member inline BuildAbsoluteLayout(attribCount: int,
                                             ?children: ViewElement list,
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

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildLayout(attribCount, ?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, 
                                                     ?gestureRecognizers: ViewElement list, ?anchorX: float, ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, 
                                                     ?height: float, ?inputTransparent: bool, ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, 
                                                     ?minimumHeight: float, ?minimumWidth: float, ?opacity: float, ?rotation: float, ?rotationX: float, 
                                                     ?rotationY: float, ?scale: float, ?scaleX: float, ?scaleY: float, ?tabIndex: int, 
                                                     ?translationX: float, ?translationY: float, ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, 
                                                     ?styleClass: InputTypes.StyleClass, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                     ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match children with None -> () | Some v -> attribBuilder.Add(ViewAttributes.AbsoluteLayoutChildrenAttribKey, Array.fromList(v)) 
        attribBuilder

    static member val CreateFuncAbsoluteLayout : (unit -> Xamarin.Forms.AbsoluteLayout) = (fun () -> ViewBuilders.CreateAbsoluteLayout()) with get, set

    static member CreateAbsoluteLayout () : Xamarin.Forms.AbsoluteLayout =
        new Xamarin.Forms.AbsoluteLayout()

    static member val UpdateFuncAbsoluteLayout =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.AbsoluteLayout) -> ViewBuilders.UpdateAbsoluteLayout (prevOpt, curr, target)) 

    static member UpdateAbsoluteLayout (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.AbsoluteLayout) = 
        ViewBuilders.UpdateLayout (prevOpt, curr, target)
        let mutable prevAbsoluteLayoutChildrenOpt = ValueNone
        let mutable currAbsoluteLayoutChildrenOpt = ValueNone
        let mutable prevAbsoluteLayoutLayoutBoundsOpt = ValueNone
        let mutable currAbsoluteLayoutLayoutBoundsOpt = ValueNone
        let mutable prevAbsoluteLayoutLayoutFlagsOpt = ValueNone
        let mutable currAbsoluteLayoutLayoutFlagsOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.AbsoluteLayoutChildrenAttribKey.KeyValue then 
                currAbsoluteLayoutChildrenOpt <- ValueSome (kvp.Value :?> ViewElement array)
            if kvp.Key = ViewAttributes.AbsoluteLayoutLayoutBoundsAttribKey.KeyValue then 
                currAbsoluteLayoutLayoutBoundsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Rectangle)
            if kvp.Key = ViewAttributes.AbsoluteLayoutLayoutFlagsAttribKey.KeyValue then 
                currAbsoluteLayoutLayoutFlagsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.AbsoluteLayoutFlags)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.AbsoluteLayoutChildrenAttribKey.KeyValue then 
                    prevAbsoluteLayoutChildrenOpt <- ValueSome (kvp.Value :?> ViewElement array)
                if kvp.Key = ViewAttributes.AbsoluteLayoutLayoutBoundsAttribKey.KeyValue then 
                    prevAbsoluteLayoutLayoutBoundsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Rectangle)
                if kvp.Key = ViewAttributes.AbsoluteLayoutLayoutFlagsAttribKey.KeyValue then 
                    prevAbsoluteLayoutLayoutFlagsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.AbsoluteLayoutFlags)
        ViewUpdaters.updateCollectionGeneric prevAbsoluteLayoutChildrenOpt currAbsoluteLayoutChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            ViewUpdaters.canReuseView
            ViewUpdaters.updateChild

    static member inline ConstructAbsoluteLayout(?children: ViewElement list,
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
                                                 ?ref: ViewRef<Xamarin.Forms.AbsoluteLayout>,
                                                 ?tag: obj,
                                                 ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                                 ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                                 ?created: (Xamarin.Forms.AbsoluteLayout -> unit)) = 

        let attribBuilder = ViewBuilders.BuildAbsoluteLayout(0,
                               ?children=children,
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
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.AbsoluteLayout>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.AbsoluteLayout> target))))

        ViewElement.Create<Xamarin.Forms.AbsoluteLayout>(ViewBuilders.CreateFuncAbsoluteLayout, ViewBuilders.UpdateFuncAbsoluteLayout, attribBuilder)

    /// Builds the attributes for a RelativeLayout in the view
    static member inline BuildRelativeLayout(attribCount: int,
                                             ?children: ViewElement list,
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

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildLayout(attribCount, ?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, 
                                                     ?gestureRecognizers: ViewElement list, ?anchorX: float, ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, 
                                                     ?height: float, ?inputTransparent: bool, ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, 
                                                     ?minimumHeight: float, ?minimumWidth: float, ?opacity: float, ?rotation: float, ?rotationX: float, 
                                                     ?rotationY: float, ?scale: float, ?scaleX: float, ?scaleY: float, ?tabIndex: int, 
                                                     ?translationX: float, ?translationY: float, ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, 
                                                     ?styleClass: InputTypes.StyleClass, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                     ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match children with None -> () | Some v -> attribBuilder.Add(ViewAttributes.RelativeLayoutChildrenAttribKey, Array.fromList(v)) 
        attribBuilder

    static member val CreateFuncRelativeLayout : (unit -> Xamarin.Forms.RelativeLayout) = (fun () -> ViewBuilders.CreateRelativeLayout()) with get, set

    static member CreateRelativeLayout () : Xamarin.Forms.RelativeLayout =
        new Xamarin.Forms.RelativeLayout()

    static member val UpdateFuncRelativeLayout =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.RelativeLayout) -> ViewBuilders.UpdateRelativeLayout (prevOpt, curr, target)) 

    static member UpdateRelativeLayout (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.RelativeLayout) = 
        ViewBuilders.UpdateLayout (prevOpt, curr, target)
        let mutable prevRelativeLayoutChildrenOpt = ValueNone
        let mutable currRelativeLayoutChildrenOpt = ValueNone
        let mutable prevRelativeLayoutBoundsConstraintOpt = ValueNone
        let mutable currRelativeLayoutBoundsConstraintOpt = ValueNone
        let mutable prevRelativeLayoutHeightConstraintOpt = ValueNone
        let mutable currRelativeLayoutHeightConstraintOpt = ValueNone
        let mutable prevRelativeLayoutWidthConstraintOpt = ValueNone
        let mutable currRelativeLayoutWidthConstraintOpt = ValueNone
        let mutable prevRelativeLayoutXConstraintOpt = ValueNone
        let mutable currRelativeLayoutXConstraintOpt = ValueNone
        let mutable prevRelativeLayoutYConstraintOpt = ValueNone
        let mutable currRelativeLayoutYConstraintOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.RelativeLayoutChildrenAttribKey.KeyValue then 
                currRelativeLayoutChildrenOpt <- ValueSome (kvp.Value :?> ViewElement array)
            if kvp.Key = ViewAttributes.RelativeLayoutBoundsConstraintAttribKey.KeyValue then 
                currRelativeLayoutBoundsConstraintOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.BoundsConstraint)
            if kvp.Key = ViewAttributes.RelativeLayoutHeightConstraintAttribKey.KeyValue then 
                currRelativeLayoutHeightConstraintOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Constraint)
            if kvp.Key = ViewAttributes.RelativeLayoutWidthConstraintAttribKey.KeyValue then 
                currRelativeLayoutWidthConstraintOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Constraint)
            if kvp.Key = ViewAttributes.RelativeLayoutXConstraintAttribKey.KeyValue then 
                currRelativeLayoutXConstraintOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Constraint)
            if kvp.Key = ViewAttributes.RelativeLayoutYConstraintAttribKey.KeyValue then 
                currRelativeLayoutYConstraintOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Constraint)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.RelativeLayoutChildrenAttribKey.KeyValue then 
                    prevRelativeLayoutChildrenOpt <- ValueSome (kvp.Value :?> ViewElement array)
                if kvp.Key = ViewAttributes.RelativeLayoutBoundsConstraintAttribKey.KeyValue then 
                    prevRelativeLayoutBoundsConstraintOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.BoundsConstraint)
                if kvp.Key = ViewAttributes.RelativeLayoutHeightConstraintAttribKey.KeyValue then 
                    prevRelativeLayoutHeightConstraintOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Constraint)
                if kvp.Key = ViewAttributes.RelativeLayoutWidthConstraintAttribKey.KeyValue then 
                    prevRelativeLayoutWidthConstraintOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Constraint)
                if kvp.Key = ViewAttributes.RelativeLayoutXConstraintAttribKey.KeyValue then 
                    prevRelativeLayoutXConstraintOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Constraint)
                if kvp.Key = ViewAttributes.RelativeLayoutYConstraintAttribKey.KeyValue then 
                    prevRelativeLayoutYConstraintOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Constraint)
        ViewUpdaters.updateCollectionGeneric prevRelativeLayoutChildrenOpt currRelativeLayoutChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            ViewUpdaters.canReuseView
            ViewUpdaters.updateChild

    static member inline ConstructRelativeLayout(?children: ViewElement list,
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
                                                 ?ref: ViewRef<Xamarin.Forms.RelativeLayout>,
                                                 ?tag: obj,
                                                 ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                                 ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                                 ?created: (Xamarin.Forms.RelativeLayout -> unit)) = 

        let attribBuilder = ViewBuilders.BuildRelativeLayout(0,
                               ?children=children,
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
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.RelativeLayout>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.RelativeLayout> target))))

        ViewElement.Create<Xamarin.Forms.RelativeLayout>(ViewBuilders.CreateFuncRelativeLayout, ViewBuilders.UpdateFuncRelativeLayout, attribBuilder)

    /// Builds the attributes for a FlexLayout in the view
    static member inline BuildFlexLayout(attribCount: int,
                                         ?alignContent: Xamarin.Forms.FlexAlignContent,
                                         ?alignItems: Xamarin.Forms.FlexAlignItems,
                                         ?direction: Xamarin.Forms.FlexDirection,
                                         ?position: Xamarin.Forms.FlexPosition,
                                         ?wrap: Xamarin.Forms.FlexWrap,
                                         ?children: ViewElement list,
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

        let attribCount = match alignContent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match alignItems with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match direction with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match position with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match wrap with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildLayout(attribCount, ?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, 
                                                     ?gestureRecognizers: ViewElement list, ?anchorX: float, ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, 
                                                     ?height: float, ?inputTransparent: bool, ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, 
                                                     ?minimumHeight: float, ?minimumWidth: float, ?opacity: float, ?rotation: float, ?rotationX: float, 
                                                     ?rotationY: float, ?scale: float, ?scaleX: float, ?scaleY: float, ?tabIndex: int, 
                                                     ?translationX: float, ?translationY: float, ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, 
                                                     ?styleClass: InputTypes.StyleClass, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                     ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match alignContent with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FlexLayoutAlignContentAttribKey, (v)) 
        match alignItems with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FlexLayoutAlignItemsAttribKey, (v)) 
        match direction with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FlexLayoutDirectionAttribKey, (v)) 
        match position with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FlexLayoutPositionAttribKey, (v)) 
        match wrap with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FlexLayoutWrapAttribKey, (v)) 
        match children with None -> () | Some v -> attribBuilder.Add(ViewAttributes.FlexLayoutChildrenAttribKey, Array.fromList(v)) 
        attribBuilder

    static member val CreateFuncFlexLayout : (unit -> Xamarin.Forms.FlexLayout) = (fun () -> ViewBuilders.CreateFlexLayout()) with get, set

    static member CreateFlexLayout () : Xamarin.Forms.FlexLayout =
        new Xamarin.Forms.FlexLayout()

    static member val UpdateFuncFlexLayout =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.FlexLayout) -> ViewBuilders.UpdateFlexLayout (prevOpt, curr, target)) 

    static member UpdateFlexLayout (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.FlexLayout) = 
        ViewBuilders.UpdateLayout (prevOpt, curr, target)
        let mutable prevFlexLayoutAlignContentOpt = ValueNone
        let mutable currFlexLayoutAlignContentOpt = ValueNone
        let mutable prevFlexLayoutAlignItemsOpt = ValueNone
        let mutable currFlexLayoutAlignItemsOpt = ValueNone
        let mutable prevFlexLayoutDirectionOpt = ValueNone
        let mutable currFlexLayoutDirectionOpt = ValueNone
        let mutable prevFlexLayoutPositionOpt = ValueNone
        let mutable currFlexLayoutPositionOpt = ValueNone
        let mutable prevFlexLayoutWrapOpt = ValueNone
        let mutable currFlexLayoutWrapOpt = ValueNone
        let mutable prevFlexLayoutChildrenOpt = ValueNone
        let mutable currFlexLayoutChildrenOpt = ValueNone
        let mutable prevFlexLayoutAlignSelfOpt = ValueNone
        let mutable currFlexLayoutAlignSelfOpt = ValueNone
        let mutable prevFlexLayoutOrderOpt = ValueNone
        let mutable currFlexLayoutOrderOpt = ValueNone
        let mutable prevFlexLayoutBasisOpt = ValueNone
        let mutable currFlexLayoutBasisOpt = ValueNone
        let mutable prevFlexLayoutGrowOpt = ValueNone
        let mutable currFlexLayoutGrowOpt = ValueNone
        let mutable prevFlexLayoutShrinkOpt = ValueNone
        let mutable currFlexLayoutShrinkOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.FlexLayoutAlignContentAttribKey.KeyValue then 
                currFlexLayoutAlignContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignContent)
            if kvp.Key = ViewAttributes.FlexLayoutAlignItemsAttribKey.KeyValue then 
                currFlexLayoutAlignItemsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignItems)
            if kvp.Key = ViewAttributes.FlexLayoutDirectionAttribKey.KeyValue then 
                currFlexLayoutDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexDirection)
            if kvp.Key = ViewAttributes.FlexLayoutPositionAttribKey.KeyValue then 
                currFlexLayoutPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexPosition)
            if kvp.Key = ViewAttributes.FlexLayoutWrapAttribKey.KeyValue then 
                currFlexLayoutWrapOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexWrap)
            if kvp.Key = ViewAttributes.FlexLayoutChildrenAttribKey.KeyValue then 
                currFlexLayoutChildrenOpt <- ValueSome (kvp.Value :?> ViewElement array)
            if kvp.Key = ViewAttributes.FlexLayoutAlignSelfAttribKey.KeyValue then 
                currFlexLayoutAlignSelfOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignSelf)
            if kvp.Key = ViewAttributes.FlexLayoutOrderAttribKey.KeyValue then 
                currFlexLayoutOrderOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = ViewAttributes.FlexLayoutBasisAttribKey.KeyValue then 
                currFlexLayoutBasisOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexBasis)
            if kvp.Key = ViewAttributes.FlexLayoutGrowAttribKey.KeyValue then 
                currFlexLayoutGrowOpt <- ValueSome (kvp.Value :?> single)
            if kvp.Key = ViewAttributes.FlexLayoutShrinkAttribKey.KeyValue then 
                currFlexLayoutShrinkOpt <- ValueSome (kvp.Value :?> single)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.FlexLayoutAlignContentAttribKey.KeyValue then 
                    prevFlexLayoutAlignContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignContent)
                if kvp.Key = ViewAttributes.FlexLayoutAlignItemsAttribKey.KeyValue then 
                    prevFlexLayoutAlignItemsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignItems)
                if kvp.Key = ViewAttributes.FlexLayoutDirectionAttribKey.KeyValue then 
                    prevFlexLayoutDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexDirection)
                if kvp.Key = ViewAttributes.FlexLayoutPositionAttribKey.KeyValue then 
                    prevFlexLayoutPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexPosition)
                if kvp.Key = ViewAttributes.FlexLayoutWrapAttribKey.KeyValue then 
                    prevFlexLayoutWrapOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexWrap)
                if kvp.Key = ViewAttributes.FlexLayoutChildrenAttribKey.KeyValue then 
                    prevFlexLayoutChildrenOpt <- ValueSome (kvp.Value :?> ViewElement array)
                if kvp.Key = ViewAttributes.FlexLayoutAlignSelfAttribKey.KeyValue then 
                    prevFlexLayoutAlignSelfOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignSelf)
                if kvp.Key = ViewAttributes.FlexLayoutOrderAttribKey.KeyValue then 
                    prevFlexLayoutOrderOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = ViewAttributes.FlexLayoutBasisAttribKey.KeyValue then 
                    prevFlexLayoutBasisOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexBasis)
                if kvp.Key = ViewAttributes.FlexLayoutGrowAttribKey.KeyValue then 
                    prevFlexLayoutGrowOpt <- ValueSome (kvp.Value :?> single)
                if kvp.Key = ViewAttributes.FlexLayoutShrinkAttribKey.KeyValue then 
                    prevFlexLayoutShrinkOpt <- ValueSome (kvp.Value :?> single)
        match prevFlexLayoutAlignContentOpt, currFlexLayoutAlignContentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AlignContent <-  currValue
        | ValueSome _, ValueNone -> target.AlignContent <- Xamarin.Forms.FlexAlignContent.Stretch
        | ValueNone, ValueNone -> ()
        match prevFlexLayoutAlignItemsOpt, currFlexLayoutAlignItemsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AlignItems <-  currValue
        | ValueSome _, ValueNone -> target.AlignItems <- Xamarin.Forms.FlexAlignItems.Stretch
        | ValueNone, ValueNone -> ()
        match prevFlexLayoutDirectionOpt, currFlexLayoutDirectionOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Direction <-  currValue
        | ValueSome _, ValueNone -> target.Direction <- Xamarin.Forms.FlexDirection.Row
        | ValueNone, ValueNone -> ()
        match prevFlexLayoutPositionOpt, currFlexLayoutPositionOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Position <-  currValue
        | ValueSome _, ValueNone -> target.Position <- Xamarin.Forms.FlexPosition.Relative
        | ValueNone, ValueNone -> ()
        match prevFlexLayoutWrapOpt, currFlexLayoutWrapOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Wrap <-  currValue
        | ValueSome _, ValueNone -> target.Wrap <- Xamarin.Forms.FlexWrap.NoWrap
        | ValueNone, ValueNone -> ()
        ViewUpdaters.updateCollectionGeneric prevFlexLayoutChildrenOpt currFlexLayoutChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            ViewUpdaters.canReuseView
            ViewUpdaters.updateChild

    static member inline ConstructFlexLayout(?alignContent: Xamarin.Forms.FlexAlignContent,
                                             ?alignItems: Xamarin.Forms.FlexAlignItems,
                                             ?direction: Xamarin.Forms.FlexDirection,
                                             ?position: Xamarin.Forms.FlexPosition,
                                             ?wrap: Xamarin.Forms.FlexWrap,
                                             ?children: ViewElement list,
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
                                             ?ref: ViewRef<Xamarin.Forms.FlexLayout>,
                                             ?tag: obj,
                                             ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                             ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                             ?created: (Xamarin.Forms.FlexLayout -> unit)) = 

        let attribBuilder = ViewBuilders.BuildFlexLayout(0,
                               ?alignContent=alignContent,
                               ?alignItems=alignItems,
                               ?direction=direction,
                               ?position=position,
                               ?wrap=wrap,
                               ?children=children,
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
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.FlexLayout>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.FlexLayout> target))))

        ViewElement.Create<Xamarin.Forms.FlexLayout>(ViewBuilders.CreateFuncFlexLayout, ViewBuilders.UpdateFuncFlexLayout, attribBuilder)

    /// Builds the attributes for a ContentView in the view
    static member inline BuildContentView(attribCount: int,
                                          ?content: ViewElement,
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

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = ViewBuilders.BuildLayout(attribCount, ?isClippedToBounds: bool, ?padding: Xamarin.Forms.Thickness, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: InputTypes.Thickness, 
                                                     ?gestureRecognizers: ViewElement list, ?anchorX: float, ?anchorY: float, ?backgroundColor: Xamarin.Forms.Color, ?flowDirection: Xamarin.Forms.FlowDirection, 
                                                     ?height: float, ?inputTransparent: bool, ?isEnabled: bool, ?isTabStop: bool, ?isVisible: bool, 
                                                     ?minimumHeight: float, ?minimumWidth: float, ?opacity: float, ?rotation: float, ?rotationX: float, 
                                                     ?rotationY: float, ?scale: float, ?scaleX: float, ?scaleY: float, ?tabIndex: int, 
                                                     ?translationX: float, ?translationY: float, ?visual: Xamarin.Forms.IVisual, ?width: float, ?style: Xamarin.Forms.Style, 
                                                     ?styleClass: InputTypes.StyleClass, ?automationId: string, ?classId: string, ?styleId: string, ?ref: ViewRef, 
                                                     ?tag: obj, ?focused: Xamarin.Forms.FocusEventArgs -> unit, ?unfocused: Xamarin.Forms.FocusEventArgs -> unit, ?created: obj -> unit)
        match content with None -> () | Some v -> attribBuilder.Add(ViewAttributes.ContentViewContentAttribKey, (v)) 
        attribBuilder

    static member val CreateFuncContentView : (unit -> Xamarin.Forms.ContentView) = (fun () -> ViewBuilders.CreateContentView()) with get, set

    static member CreateContentView () : Xamarin.Forms.ContentView =
        new Xamarin.Forms.ContentView()

    static member val UpdateFuncContentView =
        (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ContentView) -> ViewBuilders.UpdateContentView (prevOpt, curr, target)) 

    static member UpdateContentView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ContentView) = 
        ViewBuilders.UpdateLayout (prevOpt, curr, target)
        let mutable prevContentViewContentOpt = ValueNone
        let mutable currContentViewContentOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = ViewAttributes.ContentViewContentAttribKey.KeyValue then 
                currContentViewContentOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = ViewAttributes.ContentViewContentAttribKey.KeyValue then 
                    prevContentViewContentOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevContentViewContentOpt, currContentViewContentOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseView prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.Content)
        | _, ValueSome newValue ->
            target.Content <- (newValue.Create() :?> Xamarin.Forms.View)
        | ValueSome _, ValueNone ->
            target.Content <- null
        | ValueNone, ValueNone -> ()

    static member inline ConstructContentView(?content: ViewElement,
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
                                              ?ref: ViewRef<Xamarin.Forms.ContentView>,
                                              ?tag: obj,
                                              ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                              ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                              ?created: (Xamarin.Forms.ContentView -> unit)) = 

        let attribBuilder = ViewBuilders.BuildContentView(0,
                               ?content=content,
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
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ContentView>) -> Some ref.Unbox),
                               ?tag=tag,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ContentView> target))))

        ViewElement.Create<Xamarin.Forms.ContentView>(ViewBuilders.CreateFuncContentView, ViewBuilders.UpdateFuncContentView, attribBuilder)

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

/// Viewer that allows to read the properties of a ViewElement representing a Stepper
type StepperViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<Xamarin.Forms.Stepper>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Stepper' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the MinimumMaximum member
    member this.MinimumMaximum = element.GetAttributeKeyed(ViewAttributes.StepperMinimumMaximumAttribKey)
    /// Get the value of the Value member
    member this.Value = element.GetAttributeKeyed(ViewAttributes.StepperValueAttribKey)
    /// Get the value of the Increment member
    member this.Increment = element.GetAttributeKeyed(ViewAttributes.StepperIncrementAttribKey)
    /// Get the value of the ValueChanged member
    member this.ValueChanged = element.GetAttributeKeyed(ViewAttributes.StepperValueChangedAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a Switch
type SwitchViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<Xamarin.Forms.Switch>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Switch' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the IsToggled member
    member this.IsToggled = element.GetAttributeKeyed(ViewAttributes.SwitchIsToggledAttribKey)
    /// Get the value of the OnColor member
    member this.OnColor = element.GetAttributeKeyed(ViewAttributes.SwitchOnColorAttribKey)
    /// Get the value of the Toggled member
    member this.Toggled = element.GetAttributeKeyed(ViewAttributes.SwitchToggledAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a Cell
type CellViewer(element: ViewElement) =
    inherit ElementViewer(element)
    do if not ((typeof<Xamarin.Forms.Cell>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Cell' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Height member
    member this.Height = element.GetAttributeKeyed(ViewAttributes.CellHeightAttribKey)
    /// Get the value of the IsEnabled member
    member this.IsEnabled = element.GetAttributeKeyed(ViewAttributes.CellIsEnabledAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a SwitchCell
type SwitchCellViewer(element: ViewElement) =
    inherit CellViewer(element)
    do if not ((typeof<Xamarin.Forms.SwitchCell>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.SwitchCell' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the On member
    member this.On = element.GetAttributeKeyed(ViewAttributes.SwitchCellOnAttribKey)
    /// Get the value of the Text member
    member this.Text = element.GetAttributeKeyed(ViewAttributes.SwitchCellTextAttribKey)
    /// Get the value of the OnColor member
    member this.OnColor = element.GetAttributeKeyed(ViewAttributes.SwitchCellOnColorAttribKey)
    /// Get the value of the OnChanged member
    member this.OnChanged = element.GetAttributeKeyed(ViewAttributes.SwitchCellOnChangedAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a TableView
type TableViewViewer(element: ViewElement) =
    inherit ViewViewer(element)
    do if not ((typeof<Xamarin.Forms.TableView>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.TableView' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Intent member
    member this.Intent = element.GetAttributeKeyed(ViewAttributes.TableViewIntentAttribKey)
    /// Get the value of the HasUnevenRows member
    member this.HasUnevenRows = element.GetAttributeKeyed(ViewAttributes.TableViewHasUnevenRowsAttribKey)
    /// Get the value of the RowHeight member
    member this.RowHeight = element.GetAttributeKeyed(ViewAttributes.TableViewRowHeightAttribKey)
    /// Get the value of the Root member
    member this.Root = element.GetAttributeKeyed(ViewAttributes.TableViewRootAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a Grid
type GridViewer(element: ViewElement) =
    inherit LayoutViewer(element)
    do if not ((typeof<Xamarin.Forms.Grid>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.Grid' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the RowDefinitions member
    member this.RowDefinitions = element.GetAttributeKeyed(ViewAttributes.GridRowDefinitionsAttribKey)
    /// Get the value of the ColumnDefinitions member
    member this.ColumnDefinitions = element.GetAttributeKeyed(ViewAttributes.GridColumnDefinitionsAttribKey)
    /// Get the value of the RowSpacing member
    member this.RowSpacing = element.GetAttributeKeyed(ViewAttributes.GridRowSpacingAttribKey)
    /// Get the value of the ColumnSpacing member
    member this.ColumnSpacing = element.GetAttributeKeyed(ViewAttributes.GridColumnSpacingAttribKey)
    /// Get the value of the Children member
    member this.Children = element.GetAttributeKeyed(ViewAttributes.GridChildrenAttribKey)
    /// Get the value of the Row member
    member this.Row = element.GetAttributeKeyed(ViewAttributes.GridRowAttribKey)
    /// Get the value of the RowSpan member
    member this.RowSpan = element.GetAttributeKeyed(ViewAttributes.GridRowSpanAttribKey)
    /// Get the value of the Column member
    member this.Column = element.GetAttributeKeyed(ViewAttributes.GridColumnAttribKey)
    /// Get the value of the ColumnSpan member
    member this.ColumnSpan = element.GetAttributeKeyed(ViewAttributes.GridColumnSpanAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a AbsoluteLayout
type AbsoluteLayoutViewer(element: ViewElement) =
    inherit LayoutViewer(element)
    do if not ((typeof<Xamarin.Forms.AbsoluteLayout>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.AbsoluteLayout' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Children member
    member this.Children = element.GetAttributeKeyed(ViewAttributes.AbsoluteLayoutChildrenAttribKey)
    /// Get the value of the LayoutBounds member
    member this.LayoutBounds = element.GetAttributeKeyed(ViewAttributes.AbsoluteLayoutLayoutBoundsAttribKey)
    /// Get the value of the LayoutFlags member
    member this.LayoutFlags = element.GetAttributeKeyed(ViewAttributes.AbsoluteLayoutLayoutFlagsAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a RelativeLayout
type RelativeLayoutViewer(element: ViewElement) =
    inherit LayoutViewer(element)
    do if not ((typeof<Xamarin.Forms.RelativeLayout>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.RelativeLayout' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Children member
    member this.Children = element.GetAttributeKeyed(ViewAttributes.RelativeLayoutChildrenAttribKey)
    /// Get the value of the BoundsConstraint member
    member this.BoundsConstraint = element.GetAttributeKeyed(ViewAttributes.RelativeLayoutBoundsConstraintAttribKey)
    /// Get the value of the HeightConstraint member
    member this.HeightConstraint = element.GetAttributeKeyed(ViewAttributes.RelativeLayoutHeightConstraintAttribKey)
    /// Get the value of the WidthConstraint member
    member this.WidthConstraint = element.GetAttributeKeyed(ViewAttributes.RelativeLayoutWidthConstraintAttribKey)
    /// Get the value of the XConstraint member
    member this.XConstraint = element.GetAttributeKeyed(ViewAttributes.RelativeLayoutXConstraintAttribKey)
    /// Get the value of the YConstraint member
    member this.YConstraint = element.GetAttributeKeyed(ViewAttributes.RelativeLayoutYConstraintAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a FlexLayout
type FlexLayoutViewer(element: ViewElement) =
    inherit LayoutViewer(element)
    do if not ((typeof<Xamarin.Forms.FlexLayout>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.FlexLayout' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the AlignContent member
    member this.AlignContent = element.GetAttributeKeyed(ViewAttributes.FlexLayoutAlignContentAttribKey)
    /// Get the value of the AlignItems member
    member this.AlignItems = element.GetAttributeKeyed(ViewAttributes.FlexLayoutAlignItemsAttribKey)
    /// Get the value of the Direction member
    member this.Direction = element.GetAttributeKeyed(ViewAttributes.FlexLayoutDirectionAttribKey)
    /// Get the value of the Position member
    member this.Position = element.GetAttributeKeyed(ViewAttributes.FlexLayoutPositionAttribKey)
    /// Get the value of the Wrap member
    member this.Wrap = element.GetAttributeKeyed(ViewAttributes.FlexLayoutWrapAttribKey)
    /// Get the value of the Children member
    member this.Children = element.GetAttributeKeyed(ViewAttributes.FlexLayoutChildrenAttribKey)
    /// Get the value of the AlignSelf member
    member this.AlignSelf = element.GetAttributeKeyed(ViewAttributes.FlexLayoutAlignSelfAttribKey)
    /// Get the value of the Order member
    member this.Order = element.GetAttributeKeyed(ViewAttributes.FlexLayoutOrderAttribKey)
    /// Get the value of the Basis member
    member this.Basis = element.GetAttributeKeyed(ViewAttributes.FlexLayoutBasisAttribKey)
    /// Get the value of the Grow member
    member this.Grow = element.GetAttributeKeyed(ViewAttributes.FlexLayoutGrowAttribKey)
    /// Get the value of the Shrink member
    member this.Shrink = element.GetAttributeKeyed(ViewAttributes.FlexLayoutShrinkAttribKey)

/// Viewer that allows to read the properties of a ViewElement representing a ContentView
type ContentViewViewer(element: ViewElement) =
    inherit LayoutViewer(element)
    do if not ((typeof<Xamarin.Forms.ContentView>).IsAssignableFrom(element.TargetType)) then failwithf "A ViewElement assignable to type 'Xamarin.Forms.ContentView' is expected, but '%s' was provided." element.TargetType.FullName
    /// Get the value of the Content member
    member this.Content = element.GetAttributeKeyed(ViewAttributes.ContentViewContentAttribKey)

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

    /// Describes a Stepper in the view
    static member inline Stepper(?minimumMaximum: float * float,
                                 ?value: float,
                                 ?increment: float,
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
                                 ?ref: ViewRef<Xamarin.Forms.Stepper>,
                                 ?tag: obj,
                                 ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit,
                                 ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                 ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                 ?created: (Xamarin.Forms.Stepper -> unit)) =

        ViewBuilders.ConstructStepper(?minimumMaximum=minimumMaximum,
                               ?value=value,
                               ?increment=increment,
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
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a Switch in the view
    static member inline Switch(?isToggled: bool,
                                ?onColor: Xamarin.Forms.Color,
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
                                ?ref: ViewRef<Xamarin.Forms.Switch>,
                                ?tag: obj,
                                ?toggled: Xamarin.Forms.ToggledEventArgs -> unit,
                                ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                ?created: (Xamarin.Forms.Switch -> unit)) =

        ViewBuilders.ConstructSwitch(?isToggled=isToggled,
                               ?onColor=onColor,
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
                               ?toggled=toggled,
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a Cell in the view
    static member inline Cell(?height: float,
                              ?isEnabled: bool,
                              ?automationId: string,
                              ?classId: string,
                              ?styleId: string,
                              ?ref: ViewRef<Xamarin.Forms.Cell>,
                              ?tag: obj,
                              ?created: (Xamarin.Forms.Cell -> unit)) =

        ViewBuilders.ConstructCell(?height=height,
                               ?isEnabled=isEnabled,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?created=created)

    /// Describes a SwitchCell in the view
    static member inline SwitchCell(?on: bool,
                                    ?text: string,
                                    ?onColor: Xamarin.Forms.Color,
                                    ?height: float,
                                    ?isEnabled: bool,
                                    ?automationId: string,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?ref: ViewRef<Xamarin.Forms.SwitchCell>,
                                    ?tag: obj,
                                    ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit,
                                    ?created: (Xamarin.Forms.SwitchCell -> unit)) =

        ViewBuilders.ConstructSwitchCell(?on=on,
                               ?text=text,
                               ?onColor=onColor,
                               ?height=height,
                               ?isEnabled=isEnabled,
                               ?automationId=automationId,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?ref=ref,
                               ?tag=tag,
                               ?onChanged=onChanged,
                               ?created=created)

    /// Describes a TableView in the view
    static member inline TableView(?intent: Xamarin.Forms.TableIntent,
                                   ?hasUnevenRows: bool,
                                   ?rowHeight: int,
                                   ?items: (string * ViewElement list) list,
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
                                   ?ref: ViewRef<Xamarin.Forms.TableView>,
                                   ?tag: obj,
                                   ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                   ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                   ?created: (Xamarin.Forms.TableView -> unit)) =

        ViewBuilders.ConstructTableView(?intent=intent,
                               ?hasUnevenRows=hasUnevenRows,
                               ?rowHeight=rowHeight,
                               ?items=items,
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

    /// Describes a Grid in the view
    static member inline Grid(?rowDefinitions: Xamarin.Forms.RowDefinitionCollection,
                              ?columnDefinitions: Xamarin.Forms.ColumnDefinitionCollection,
                              ?rowSpacing: float,
                              ?columnSpacing: float,
                              ?children: ViewElement list,
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
                              ?ref: ViewRef<Xamarin.Forms.Grid>,
                              ?tag: obj,
                              ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                              ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                              ?created: (Xamarin.Forms.Grid -> unit)) =

        ViewBuilders.ConstructGrid(?rowDefinitions=rowDefinitions,
                               ?columnDefinitions=columnDefinitions,
                               ?rowSpacing=rowSpacing,
                               ?columnSpacing=columnSpacing,
                               ?children=children,
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
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a AbsoluteLayout in the view
    static member inline AbsoluteLayout(?children: ViewElement list,
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
                                        ?ref: ViewRef<Xamarin.Forms.AbsoluteLayout>,
                                        ?tag: obj,
                                        ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                        ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                        ?created: (Xamarin.Forms.AbsoluteLayout -> unit)) =

        ViewBuilders.ConstructAbsoluteLayout(?children=children,
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
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a RelativeLayout in the view
    static member inline RelativeLayout(?children: ViewElement list,
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
                                        ?ref: ViewRef<Xamarin.Forms.RelativeLayout>,
                                        ?tag: obj,
                                        ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                        ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                        ?created: (Xamarin.Forms.RelativeLayout -> unit)) =

        ViewBuilders.ConstructRelativeLayout(?children=children,
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
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a FlexLayout in the view
    static member inline FlexLayout(?alignContent: Xamarin.Forms.FlexAlignContent,
                                    ?alignItems: Xamarin.Forms.FlexAlignItems,
                                    ?direction: Xamarin.Forms.FlexDirection,
                                    ?position: Xamarin.Forms.FlexPosition,
                                    ?wrap: Xamarin.Forms.FlexWrap,
                                    ?children: ViewElement list,
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
                                    ?ref: ViewRef<Xamarin.Forms.FlexLayout>,
                                    ?tag: obj,
                                    ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                    ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                    ?created: (Xamarin.Forms.FlexLayout -> unit)) =

        ViewBuilders.ConstructFlexLayout(?alignContent=alignContent,
                               ?alignItems=alignItems,
                               ?direction=direction,
                               ?position=position,
                               ?wrap=wrap,
                               ?children=children,
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
                               ?focused=focused,
                               ?unfocused=unfocused,
                               ?created=created)

    /// Describes a ContentView in the view
    static member inline ContentView(?content: ViewElement,
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
                                     ?ref: ViewRef<Xamarin.Forms.ContentView>,
                                     ?tag: obj,
                                     ?focused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?unfocused: Xamarin.Forms.FocusEventArgs -> unit,
                                     ?created: (Xamarin.Forms.ContentView -> unit)) =

        ViewBuilders.ConstructContentView(?content=content,
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
        member x.ViewGestureRecognizers(value: ViewElement list) = x.WithAttribute(ViewAttributes.ViewGestureRecognizersAttribKey, Array.fromList(value))

        /// Adjusts the GestureElementGestureRecognizers property in the visual element
        member x.GestureElementGestureRecognizers(value: ViewElement list) = x.WithAttribute(ViewAttributes.GestureElementGestureRecognizersAttribKey, Array.fromList(value))

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

        /// Adjusts the StepperMinimumMaximum property in the visual element
        member x.StepperMinimumMaximum(value: float * float) = x.WithAttribute(ViewAttributes.StepperMinimumMaximumAttribKey, (value))

        /// Adjusts the StepperValue property in the visual element
        member x.StepperValue(value: float) = x.WithAttribute(ViewAttributes.StepperValueAttribKey, (value))

        /// Adjusts the StepperIncrement property in the visual element
        member x.StepperIncrement(value: float) = x.WithAttribute(ViewAttributes.StepperIncrementAttribKey, (value))

        /// Adjusts the StepperValueChanged property in the visual element
        member x.StepperValueChanged(value: Xamarin.Forms.ValueChangedEventArgs -> unit) = x.WithAttribute(ViewAttributes.StepperValueChangedAttribKey, (value))

        /// Adjusts the SwitchIsToggled property in the visual element
        member x.SwitchIsToggled(value: bool) = x.WithAttribute(ViewAttributes.SwitchIsToggledAttribKey, (value))

        /// Adjusts the SwitchOnColor property in the visual element
        member x.SwitchOnColor(value: Xamarin.Forms.Color) = x.WithAttribute(ViewAttributes.SwitchOnColorAttribKey, (value))

        /// Adjusts the SwitchToggled property in the visual element
        member x.SwitchToggled(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttribute(ViewAttributes.SwitchToggledAttribKey, (value))

        /// Adjusts the CellHeight property in the visual element
        member x.CellHeight(value: float) = x.WithAttribute(ViewAttributes.CellHeightAttribKey, (value))

        /// Adjusts the CellIsEnabled property in the visual element
        member x.CellIsEnabled(value: bool) = x.WithAttribute(ViewAttributes.CellIsEnabledAttribKey, (value))

        /// Adjusts the SwitchCellOn property in the visual element
        member x.SwitchCellOn(value: bool) = x.WithAttribute(ViewAttributes.SwitchCellOnAttribKey, (value))

        /// Adjusts the SwitchCellText property in the visual element
        member x.SwitchCellText(value: string) = x.WithAttribute(ViewAttributes.SwitchCellTextAttribKey, (value))

        /// Adjusts the SwitchCellOnColor property in the visual element
        member x.SwitchCellOnColor(value: Xamarin.Forms.Color) = x.WithAttribute(ViewAttributes.SwitchCellOnColorAttribKey, (value))

        /// Adjusts the SwitchCellOnChanged property in the visual element
        member x.SwitchCellOnChanged(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttribute(ViewAttributes.SwitchCellOnChangedAttribKey, (value))

        /// Adjusts the TableViewIntent property in the visual element
        member x.TableViewIntent(value: Xamarin.Forms.TableIntent) = x.WithAttribute(ViewAttributes.TableViewIntentAttribKey, (value))

        /// Adjusts the TableViewHasUnevenRows property in the visual element
        member x.TableViewHasUnevenRows(value: bool) = x.WithAttribute(ViewAttributes.TableViewHasUnevenRowsAttribKey, (value))

        /// Adjusts the TableViewRowHeight property in the visual element
        member x.TableViewRowHeight(value: int) = x.WithAttribute(ViewAttributes.TableViewRowHeightAttribKey, (value))

        /// Adjusts the TableViewRoot property in the visual element
        member x.TableViewRoot(value: (string * ViewElement list) list) = x.WithAttribute(ViewAttributes.TableViewRootAttribKey, Array.fromList(value))

        /// Adjusts the GridRowDefinitions property in the visual element
        member x.GridRowDefinitions(value: Xamarin.Forms.RowDefinitionCollection) = x.WithAttribute(ViewAttributes.GridRowDefinitionsAttribKey, (value))

        /// Adjusts the GridColumnDefinitions property in the visual element
        member x.GridColumnDefinitions(value: Xamarin.Forms.ColumnDefinitionCollection) = x.WithAttribute(ViewAttributes.GridColumnDefinitionsAttribKey, (value))

        /// Adjusts the GridRowSpacing property in the visual element
        member x.GridRowSpacing(value: float) = x.WithAttribute(ViewAttributes.GridRowSpacingAttribKey, (value))

        /// Adjusts the GridColumnSpacing property in the visual element
        member x.GridColumnSpacing(value: float) = x.WithAttribute(ViewAttributes.GridColumnSpacingAttribKey, (value))

        /// Adjusts the GridChildren property in the visual element
        member x.GridChildren(value: ViewElement list) = x.WithAttribute(ViewAttributes.GridChildrenAttribKey, Array.fromList(value))

        /// Adjusts the GridRow property in the visual element
        member x.GridRow(value: int) = x.WithAttribute(ViewAttributes.GridRowAttribKey, (value))

        /// Adjusts the GridRowSpan property in the visual element
        member x.GridRowSpan(value: int) = x.WithAttribute(ViewAttributes.GridRowSpanAttribKey, (value))

        /// Adjusts the GridColumn property in the visual element
        member x.GridColumn(value: int) = x.WithAttribute(ViewAttributes.GridColumnAttribKey, (value))

        /// Adjusts the GridColumnSpan property in the visual element
        member x.GridColumnSpan(value: int) = x.WithAttribute(ViewAttributes.GridColumnSpanAttribKey, (value))

        /// Adjusts the AbsoluteLayoutChildren property in the visual element
        member x.AbsoluteLayoutChildren(value: ViewElement list) = x.WithAttribute(ViewAttributes.AbsoluteLayoutChildrenAttribKey, Array.fromList(value))

        /// Adjusts the AbsoluteLayoutLayoutBounds property in the visual element
        member x.AbsoluteLayoutLayoutBounds(value: Xamarin.Forms.Rectangle) = x.WithAttribute(ViewAttributes.AbsoluteLayoutLayoutBoundsAttribKey, (value))

        /// Adjusts the AbsoluteLayoutLayoutFlags property in the visual element
        member x.AbsoluteLayoutLayoutFlags(value: Xamarin.Forms.AbsoluteLayoutFlags) = x.WithAttribute(ViewAttributes.AbsoluteLayoutLayoutFlagsAttribKey, (value))

        /// Adjusts the RelativeLayoutChildren property in the visual element
        member x.RelativeLayoutChildren(value: ViewElement list) = x.WithAttribute(ViewAttributes.RelativeLayoutChildrenAttribKey, Array.fromList(value))

        /// Adjusts the RelativeLayoutBoundsConstraint property in the visual element
        member x.RelativeLayoutBoundsConstraint(value: Xamarin.Forms.BoundsConstraint) = x.WithAttribute(ViewAttributes.RelativeLayoutBoundsConstraintAttribKey, (value))

        /// Adjusts the RelativeLayoutHeightConstraint property in the visual element
        member x.RelativeLayoutHeightConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(ViewAttributes.RelativeLayoutHeightConstraintAttribKey, (value))

        /// Adjusts the RelativeLayoutWidthConstraint property in the visual element
        member x.RelativeLayoutWidthConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(ViewAttributes.RelativeLayoutWidthConstraintAttribKey, (value))

        /// Adjusts the RelativeLayoutXConstraint property in the visual element
        member x.RelativeLayoutXConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(ViewAttributes.RelativeLayoutXConstraintAttribKey, (value))

        /// Adjusts the RelativeLayoutYConstraint property in the visual element
        member x.RelativeLayoutYConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(ViewAttributes.RelativeLayoutYConstraintAttribKey, (value))

        /// Adjusts the FlexLayoutAlignContent property in the visual element
        member x.FlexLayoutAlignContent(value: Xamarin.Forms.FlexAlignContent) = x.WithAttribute(ViewAttributes.FlexLayoutAlignContentAttribKey, (value))

        /// Adjusts the FlexLayoutAlignItems property in the visual element
        member x.FlexLayoutAlignItems(value: Xamarin.Forms.FlexAlignItems) = x.WithAttribute(ViewAttributes.FlexLayoutAlignItemsAttribKey, (value))

        /// Adjusts the FlexLayoutDirection property in the visual element
        member x.FlexLayoutDirection(value: Xamarin.Forms.FlexDirection) = x.WithAttribute(ViewAttributes.FlexLayoutDirectionAttribKey, (value))

        /// Adjusts the FlexLayoutPosition property in the visual element
        member x.FlexLayoutPosition(value: Xamarin.Forms.FlexPosition) = x.WithAttribute(ViewAttributes.FlexLayoutPositionAttribKey, (value))

        /// Adjusts the FlexLayoutWrap property in the visual element
        member x.FlexLayoutWrap(value: Xamarin.Forms.FlexWrap) = x.WithAttribute(ViewAttributes.FlexLayoutWrapAttribKey, (value))

        /// Adjusts the FlexLayoutChildren property in the visual element
        member x.FlexLayoutChildren(value: ViewElement list) = x.WithAttribute(ViewAttributes.FlexLayoutChildrenAttribKey, Array.fromList(value))

        /// Adjusts the FlexLayoutAlignSelf property in the visual element
        member x.FlexLayoutAlignSelf(value: Xamarin.Forms.FlexAlignSelf) = x.WithAttribute(ViewAttributes.FlexLayoutAlignSelfAttribKey, (value))

        /// Adjusts the FlexLayoutOrder property in the visual element
        member x.FlexLayoutOrder(value: int) = x.WithAttribute(ViewAttributes.FlexLayoutOrderAttribKey, (value))

        /// Adjusts the FlexLayoutBasis property in the visual element
        member x.FlexLayoutBasis(value: Xamarin.Forms.FlexBasis) = x.WithAttribute(ViewAttributes.FlexLayoutBasisAttribKey, (value))

        /// Adjusts the FlexLayoutGrow property in the visual element
        member x.FlexLayoutGrow(value: single) = x.WithAttribute(ViewAttributes.FlexLayoutGrowAttribKey, (value))

        /// Adjusts the FlexLayoutShrink property in the visual element
        member x.FlexLayoutShrink(value: single) = x.WithAttribute(ViewAttributes.FlexLayoutShrinkAttribKey, (value))

        /// Adjusts the ContentViewContent property in the visual element
        member x.ContentViewContent(value: ViewElement) = x.WithAttribute(ViewAttributes.ContentViewContentAttribKey, (value))

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
                      ?SliderDragCompleted: unit -> unit, ?SliderDragStarted: unit -> unit, ?StepperMinimumMaximum: float * float, ?StepperValue: float, ?StepperIncrement: float, 
                      ?StepperValueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?SwitchIsToggled: bool, ?SwitchOnColor: Xamarin.Forms.Color, ?SwitchToggled: Xamarin.Forms.ToggledEventArgs -> unit, ?CellHeight: float, 
                      ?CellIsEnabled: bool, ?SwitchCellOn: bool, ?SwitchCellText: string, ?SwitchCellOnColor: Xamarin.Forms.Color, ?SwitchCellOnChanged: Xamarin.Forms.ToggledEventArgs -> unit, 
                      ?TableViewIntent: Xamarin.Forms.TableIntent, ?TableViewHasUnevenRows: bool, ?TableViewRowHeight: int, ?TableViewRoot: (string * ViewElement list) list, ?GridRowDefinitions: Xamarin.Forms.RowDefinitionCollection, 
                      ?GridColumnDefinitions: Xamarin.Forms.ColumnDefinitionCollection, ?GridRowSpacing: float, ?GridColumnSpacing: float, ?GridChildren: ViewElement list, ?GridRow: int, 
                      ?GridRowSpan: int, ?GridColumn: int, ?GridColumnSpan: int, ?AbsoluteLayoutChildren: ViewElement list, ?AbsoluteLayoutLayoutBounds: Xamarin.Forms.Rectangle, 
                      ?AbsoluteLayoutLayoutFlags: Xamarin.Forms.AbsoluteLayoutFlags, ?RelativeLayoutChildren: ViewElement list, ?RelativeLayoutBoundsConstraint: Xamarin.Forms.BoundsConstraint, ?RelativeLayoutHeightConstraint: Xamarin.Forms.Constraint, ?RelativeLayoutWidthConstraint: Xamarin.Forms.Constraint, 
                      ?RelativeLayoutXConstraint: Xamarin.Forms.Constraint, ?RelativeLayoutYConstraint: Xamarin.Forms.Constraint, ?FlexLayoutAlignContent: Xamarin.Forms.FlexAlignContent, ?FlexLayoutAlignItems: Xamarin.Forms.FlexAlignItems, ?FlexLayoutDirection: Xamarin.Forms.FlexDirection, 
                      ?FlexLayoutPosition: Xamarin.Forms.FlexPosition, ?FlexLayoutWrap: Xamarin.Forms.FlexWrap, ?FlexLayoutChildren: ViewElement list, ?FlexLayoutAlignSelf: Xamarin.Forms.FlexAlignSelf, ?FlexLayoutOrder: int, 
                      ?FlexLayoutBasis: Xamarin.Forms.FlexBasis, ?FlexLayoutGrow: single, ?FlexLayoutShrink: single, ?ContentViewContent: ViewElement) =
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
            let x = match StepperMinimumMaximum with None -> x | Some opt -> x.StepperMinimumMaximum(opt)
            let x = match StepperValue with None -> x | Some opt -> x.StepperValue(opt)
            let x = match StepperIncrement with None -> x | Some opt -> x.StepperIncrement(opt)
            let x = match StepperValueChanged with None -> x | Some opt -> x.StepperValueChanged(opt)
            let x = match SwitchIsToggled with None -> x | Some opt -> x.SwitchIsToggled(opt)
            let x = match SwitchOnColor with None -> x | Some opt -> x.SwitchOnColor(opt)
            let x = match SwitchToggled with None -> x | Some opt -> x.SwitchToggled(opt)
            let x = match CellHeight with None -> x | Some opt -> x.CellHeight(opt)
            let x = match CellIsEnabled with None -> x | Some opt -> x.CellIsEnabled(opt)
            let x = match SwitchCellOn with None -> x | Some opt -> x.SwitchCellOn(opt)
            let x = match SwitchCellText with None -> x | Some opt -> x.SwitchCellText(opt)
            let x = match SwitchCellOnColor with None -> x | Some opt -> x.SwitchCellOnColor(opt)
            let x = match SwitchCellOnChanged with None -> x | Some opt -> x.SwitchCellOnChanged(opt)
            let x = match TableViewIntent with None -> x | Some opt -> x.TableViewIntent(opt)
            let x = match TableViewHasUnevenRows with None -> x | Some opt -> x.TableViewHasUnevenRows(opt)
            let x = match TableViewRowHeight with None -> x | Some opt -> x.TableViewRowHeight(opt)
            let x = match TableViewRoot with None -> x | Some opt -> x.TableViewRoot(opt)
            let x = match GridRowDefinitions with None -> x | Some opt -> x.GridRowDefinitions(opt)
            let x = match GridColumnDefinitions with None -> x | Some opt -> x.GridColumnDefinitions(opt)
            let x = match GridRowSpacing with None -> x | Some opt -> x.GridRowSpacing(opt)
            let x = match GridColumnSpacing with None -> x | Some opt -> x.GridColumnSpacing(opt)
            let x = match GridChildren with None -> x | Some opt -> x.GridChildren(opt)
            let x = match GridRow with None -> x | Some opt -> x.GridRow(opt)
            let x = match GridRowSpan with None -> x | Some opt -> x.GridRowSpan(opt)
            let x = match GridColumn with None -> x | Some opt -> x.GridColumn(opt)
            let x = match GridColumnSpan with None -> x | Some opt -> x.GridColumnSpan(opt)
            let x = match AbsoluteLayoutChildren with None -> x | Some opt -> x.AbsoluteLayoutChildren(opt)
            let x = match AbsoluteLayoutLayoutBounds with None -> x | Some opt -> x.AbsoluteLayoutLayoutBounds(opt)
            let x = match AbsoluteLayoutLayoutFlags with None -> x | Some opt -> x.AbsoluteLayoutLayoutFlags(opt)
            let x = match RelativeLayoutChildren with None -> x | Some opt -> x.RelativeLayoutChildren(opt)
            let x = match RelativeLayoutBoundsConstraint with None -> x | Some opt -> x.RelativeLayoutBoundsConstraint(opt)
            let x = match RelativeLayoutHeightConstraint with None -> x | Some opt -> x.RelativeLayoutHeightConstraint(opt)
            let x = match RelativeLayoutWidthConstraint with None -> x | Some opt -> x.RelativeLayoutWidthConstraint(opt)
            let x = match RelativeLayoutXConstraint with None -> x | Some opt -> x.RelativeLayoutXConstraint(opt)
            let x = match RelativeLayoutYConstraint with None -> x | Some opt -> x.RelativeLayoutYConstraint(opt)
            let x = match FlexLayoutAlignContent with None -> x | Some opt -> x.FlexLayoutAlignContent(opt)
            let x = match FlexLayoutAlignItems with None -> x | Some opt -> x.FlexLayoutAlignItems(opt)
            let x = match FlexLayoutDirection with None -> x | Some opt -> x.FlexLayoutDirection(opt)
            let x = match FlexLayoutPosition with None -> x | Some opt -> x.FlexLayoutPosition(opt)
            let x = match FlexLayoutWrap with None -> x | Some opt -> x.FlexLayoutWrap(opt)
            let x = match FlexLayoutChildren with None -> x | Some opt -> x.FlexLayoutChildren(opt)
            let x = match FlexLayoutAlignSelf with None -> x | Some opt -> x.FlexLayoutAlignSelf(opt)
            let x = match FlexLayoutOrder with None -> x | Some opt -> x.FlexLayoutOrder(opt)
            let x = match FlexLayoutBasis with None -> x | Some opt -> x.FlexLayoutBasis(opt)
            let x = match FlexLayoutGrow with None -> x | Some opt -> x.FlexLayoutGrow(opt)
            let x = match FlexLayoutShrink with None -> x | Some opt -> x.FlexLayoutShrink(opt)
            let x = match ContentViewContent with None -> x | Some opt -> x.ContentViewContent(opt)
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
    /// Adjusts the StepperMinimumMaximum property in the visual element
    let StepperMinimumMaximum (value: float * float) (x: ViewElement) = x.StepperMinimumMaximum(value)
    /// Adjusts the StepperValue property in the visual element
    let StepperValue (value: float) (x: ViewElement) = x.StepperValue(value)
    /// Adjusts the StepperIncrement property in the visual element
    let StepperIncrement (value: float) (x: ViewElement) = x.StepperIncrement(value)
    /// Adjusts the StepperValueChanged property in the visual element
    let StepperValueChanged (value: Xamarin.Forms.ValueChangedEventArgs -> unit) (x: ViewElement) = x.StepperValueChanged(value)
    /// Adjusts the SwitchIsToggled property in the visual element
    let SwitchIsToggled (value: bool) (x: ViewElement) = x.SwitchIsToggled(value)
    /// Adjusts the SwitchOnColor property in the visual element
    let SwitchOnColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.SwitchOnColor(value)
    /// Adjusts the SwitchToggled property in the visual element
    let SwitchToggled (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: ViewElement) = x.SwitchToggled(value)
    /// Adjusts the CellHeight property in the visual element
    let CellHeight (value: float) (x: ViewElement) = x.CellHeight(value)
    /// Adjusts the CellIsEnabled property in the visual element
    let CellIsEnabled (value: bool) (x: ViewElement) = x.CellIsEnabled(value)
    /// Adjusts the SwitchCellOn property in the visual element
    let SwitchCellOn (value: bool) (x: ViewElement) = x.SwitchCellOn(value)
    /// Adjusts the SwitchCellText property in the visual element
    let SwitchCellText (value: string) (x: ViewElement) = x.SwitchCellText(value)
    /// Adjusts the SwitchCellOnColor property in the visual element
    let SwitchCellOnColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.SwitchCellOnColor(value)
    /// Adjusts the SwitchCellOnChanged property in the visual element
    let SwitchCellOnChanged (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: ViewElement) = x.SwitchCellOnChanged(value)
    /// Adjusts the TableViewIntent property in the visual element
    let TableViewIntent (value: Xamarin.Forms.TableIntent) (x: ViewElement) = x.TableViewIntent(value)
    /// Adjusts the TableViewHasUnevenRows property in the visual element
    let TableViewHasUnevenRows (value: bool) (x: ViewElement) = x.TableViewHasUnevenRows(value)
    /// Adjusts the TableViewRowHeight property in the visual element
    let TableViewRowHeight (value: int) (x: ViewElement) = x.TableViewRowHeight(value)
    /// Adjusts the TableViewRoot property in the visual element
    let TableViewRoot (value: (string * ViewElement list) list) (x: ViewElement) = x.TableViewRoot(value)
    /// Adjusts the GridRowDefinitions property in the visual element
    let GridRowDefinitions (value: Xamarin.Forms.RowDefinitionCollection) (x: ViewElement) = x.GridRowDefinitions(value)
    /// Adjusts the GridColumnDefinitions property in the visual element
    let GridColumnDefinitions (value: Xamarin.Forms.ColumnDefinitionCollection) (x: ViewElement) = x.GridColumnDefinitions(value)
    /// Adjusts the GridRowSpacing property in the visual element
    let GridRowSpacing (value: float) (x: ViewElement) = x.GridRowSpacing(value)
    /// Adjusts the GridColumnSpacing property in the visual element
    let GridColumnSpacing (value: float) (x: ViewElement) = x.GridColumnSpacing(value)
    /// Adjusts the GridChildren property in the visual element
    let GridChildren (value: ViewElement list) (x: ViewElement) = x.GridChildren(value)
    /// Adjusts the GridRow property in the visual element
    let GridRow (value: int) (x: ViewElement) = x.GridRow(value)
    /// Adjusts the GridRowSpan property in the visual element
    let GridRowSpan (value: int) (x: ViewElement) = x.GridRowSpan(value)
    /// Adjusts the GridColumn property in the visual element
    let GridColumn (value: int) (x: ViewElement) = x.GridColumn(value)
    /// Adjusts the GridColumnSpan property in the visual element
    let GridColumnSpan (value: int) (x: ViewElement) = x.GridColumnSpan(value)
    /// Adjusts the AbsoluteLayoutChildren property in the visual element
    let AbsoluteLayoutChildren (value: ViewElement list) (x: ViewElement) = x.AbsoluteLayoutChildren(value)
    /// Adjusts the AbsoluteLayoutLayoutBounds property in the visual element
    let AbsoluteLayoutLayoutBounds (value: Xamarin.Forms.Rectangle) (x: ViewElement) = x.AbsoluteLayoutLayoutBounds(value)
    /// Adjusts the AbsoluteLayoutLayoutFlags property in the visual element
    let AbsoluteLayoutLayoutFlags (value: Xamarin.Forms.AbsoluteLayoutFlags) (x: ViewElement) = x.AbsoluteLayoutLayoutFlags(value)
    /// Adjusts the RelativeLayoutChildren property in the visual element
    let RelativeLayoutChildren (value: ViewElement list) (x: ViewElement) = x.RelativeLayoutChildren(value)
    /// Adjusts the RelativeLayoutBoundsConstraint property in the visual element
    let RelativeLayoutBoundsConstraint (value: Xamarin.Forms.BoundsConstraint) (x: ViewElement) = x.RelativeLayoutBoundsConstraint(value)
    /// Adjusts the RelativeLayoutHeightConstraint property in the visual element
    let RelativeLayoutHeightConstraint (value: Xamarin.Forms.Constraint) (x: ViewElement) = x.RelativeLayoutHeightConstraint(value)
    /// Adjusts the RelativeLayoutWidthConstraint property in the visual element
    let RelativeLayoutWidthConstraint (value: Xamarin.Forms.Constraint) (x: ViewElement) = x.RelativeLayoutWidthConstraint(value)
    /// Adjusts the RelativeLayoutXConstraint property in the visual element
    let RelativeLayoutXConstraint (value: Xamarin.Forms.Constraint) (x: ViewElement) = x.RelativeLayoutXConstraint(value)
    /// Adjusts the RelativeLayoutYConstraint property in the visual element
    let RelativeLayoutYConstraint (value: Xamarin.Forms.Constraint) (x: ViewElement) = x.RelativeLayoutYConstraint(value)
    /// Adjusts the FlexLayoutAlignContent property in the visual element
    let FlexLayoutAlignContent (value: Xamarin.Forms.FlexAlignContent) (x: ViewElement) = x.FlexLayoutAlignContent(value)
    /// Adjusts the FlexLayoutAlignItems property in the visual element
    let FlexLayoutAlignItems (value: Xamarin.Forms.FlexAlignItems) (x: ViewElement) = x.FlexLayoutAlignItems(value)
    /// Adjusts the FlexLayoutDirection property in the visual element
    let FlexLayoutDirection (value: Xamarin.Forms.FlexDirection) (x: ViewElement) = x.FlexLayoutDirection(value)
    /// Adjusts the FlexLayoutPosition property in the visual element
    let FlexLayoutPosition (value: Xamarin.Forms.FlexPosition) (x: ViewElement) = x.FlexLayoutPosition(value)
    /// Adjusts the FlexLayoutWrap property in the visual element
    let FlexLayoutWrap (value: Xamarin.Forms.FlexWrap) (x: ViewElement) = x.FlexLayoutWrap(value)
    /// Adjusts the FlexLayoutChildren property in the visual element
    let FlexLayoutChildren (value: ViewElement list) (x: ViewElement) = x.FlexLayoutChildren(value)
    /// Adjusts the FlexLayoutAlignSelf property in the visual element
    let FlexLayoutAlignSelf (value: Xamarin.Forms.FlexAlignSelf) (x: ViewElement) = x.FlexLayoutAlignSelf(value)
    /// Adjusts the FlexLayoutOrder property in the visual element
    let FlexLayoutOrder (value: int) (x: ViewElement) = x.FlexLayoutOrder(value)
    /// Adjusts the FlexLayoutBasis property in the visual element
    let FlexLayoutBasis (value: Xamarin.Forms.FlexBasis) (x: ViewElement) = x.FlexLayoutBasis(value)
    /// Adjusts the FlexLayoutGrow property in the visual element
    let FlexLayoutGrow (value: single) (x: ViewElement) = x.FlexLayoutGrow(value)
    /// Adjusts the FlexLayoutShrink property in the visual element
    let FlexLayoutShrink (value: single) (x: ViewElement) = x.FlexLayoutShrink(value)
    /// Adjusts the ContentViewContent property in the visual element
    let ContentViewContent (value: ViewElement) (x: ViewElement) = x.ContentViewContent(value)
