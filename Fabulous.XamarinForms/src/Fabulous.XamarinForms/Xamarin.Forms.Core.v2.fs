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

