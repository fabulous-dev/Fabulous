// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.DynamicViews

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds

type View() =

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ClassIdAttribKey : AttributeKey<_> = AttributeKey<_>("ClassId")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _StyleIdAttribKey : AttributeKey<_> = AttributeKey<_>("StyleId")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _AutomationIdAttribKey : AttributeKey<_> = AttributeKey<_>("AutomationId")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ElementCreatedAttribKey : AttributeKey<_> = AttributeKey<_>("ElementCreated")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ElementViewRefAttribKey : AttributeKey<_> = AttributeKey<_>("ElementViewRef")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _AnchorXAttribKey : AttributeKey<_> = AttributeKey<_>("AnchorX")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _AnchorYAttribKey : AttributeKey<_> = AttributeKey<_>("AnchorY")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _BackgroundColorAttribKey : AttributeKey<_> = AttributeKey<_>("BackgroundColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HeightRequestAttribKey : AttributeKey<_> = AttributeKey<_>("HeightRequest")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _InputTransparentAttribKey : AttributeKey<_> = AttributeKey<_>("InputTransparent")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("IsEnabled")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsVisibleAttribKey : AttributeKey<_> = AttributeKey<_>("IsVisible")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _MinimumHeightRequestAttribKey : AttributeKey<_> = AttributeKey<_>("MinimumHeightRequest")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _MinimumWidthRequestAttribKey : AttributeKey<_> = AttributeKey<_>("MinimumWidthRequest")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _OpacityAttribKey : AttributeKey<_> = AttributeKey<_>("Opacity")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _RotationAttribKey : AttributeKey<_> = AttributeKey<_>("Rotation")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _RotationXAttribKey : AttributeKey<_> = AttributeKey<_>("RotationX")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _RotationYAttribKey : AttributeKey<_> = AttributeKey<_>("RotationY")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ScaleAttribKey : AttributeKey<_> = AttributeKey<_>("Scale")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _StyleAttribKey : AttributeKey<_> = AttributeKey<_>("Style")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _StyleClassAttribKey : AttributeKey<_> = AttributeKey<_>("StyleClass")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TranslationXAttribKey : AttributeKey<_> = AttributeKey<_>("TranslationX")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TranslationYAttribKey : AttributeKey<_> = AttributeKey<_>("TranslationY")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _WidthRequestAttribKey : AttributeKey<_> = AttributeKey<_>("WidthRequest")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ResourcesAttribKey : AttributeKey<_> = AttributeKey<_>("Resources")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _StylesAttribKey : AttributeKey<_> = AttributeKey<_>("Styles")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _StyleSheetsAttribKey : AttributeKey<_> = AttributeKey<_>("StyleSheets")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsTabStopAttribKey : AttributeKey<_> = AttributeKey<_>("IsTabStop")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ScaleXAttribKey : AttributeKey<_> = AttributeKey<_>("ScaleX")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ScaleYAttribKey : AttributeKey<_> = AttributeKey<_>("ScaleY")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TabIndexAttribKey : AttributeKey<_> = AttributeKey<_>("TabIndex")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HorizontalOptionsAttribKey : AttributeKey<_> = AttributeKey<_>("HorizontalOptions")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _VerticalOptionsAttribKey : AttributeKey<_> = AttributeKey<_>("VerticalOptions")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _MarginAttribKey : AttributeKey<_> = AttributeKey<_>("Margin")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _GestureRecognizersAttribKey : AttributeKey<_> = AttributeKey<_>("GestureRecognizers")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TouchPointsAttribKey : AttributeKey<_> = AttributeKey<_>("TouchPoints")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PanUpdatedAttribKey : AttributeKey<_> = AttributeKey<_>("PanUpdated")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _CommandAttribKey : AttributeKey<_> = AttributeKey<_>("Command")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _NumberOfTapsRequiredAttribKey : AttributeKey<_> = AttributeKey<_>("NumberOfTapsRequired")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _NumberOfClicksRequiredAttribKey : AttributeKey<_> = AttributeKey<_>("NumberOfClicksRequired")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ButtonsAttribKey : AttributeKey<_> = AttributeKey<_>("Buttons")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsPinchingAttribKey : AttributeKey<_> = AttributeKey<_>("IsPinching")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PinchUpdatedAttribKey : AttributeKey<_> = AttributeKey<_>("PinchUpdated")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SwipeGestureRecognizerDirectionAttribKey : AttributeKey<_> = AttributeKey<_>("SwipeGestureRecognizerDirection")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ThresholdAttribKey : AttributeKey<_> = AttributeKey<_>("Threshold")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SwipedAttribKey : AttributeKey<_> = AttributeKey<_>("Swiped")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ColorAttribKey : AttributeKey<_> = AttributeKey<_>("Color")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsRunningAttribKey : AttributeKey<_> = AttributeKey<_>("IsRunning")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _BoxViewCornerRadiusAttribKey : AttributeKey<_> = AttributeKey<_>("BoxViewCornerRadius")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ProgressAttribKey : AttributeKey<_> = AttributeKey<_>("Progress")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsClippedToBoundsAttribKey : AttributeKey<_> = AttributeKey<_>("IsClippedToBounds")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PaddingAttribKey : AttributeKey<_> = AttributeKey<_>("Padding")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ContentAttribKey : AttributeKey<_> = AttributeKey<_>("Content")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ScrollOrientationAttribKey : AttributeKey<_> = AttributeKey<_>("ScrollOrientation")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HorizontalScrollBarVisibilityAttribKey : AttributeKey<_> = AttributeKey<_>("HorizontalScrollBarVisibility")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _VerticalScrollBarVisibilityAttribKey : AttributeKey<_> = AttributeKey<_>("VerticalScrollBarVisibility")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _CancelButtonColorAttribKey : AttributeKey<_> = AttributeKey<_>("CancelButtonColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FontFamilyAttribKey : AttributeKey<_> = AttributeKey<_>("FontFamily")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FontAttributesAttribKey : AttributeKey<_> = AttributeKey<_>("FontAttributes")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FontSizeAttribKey : AttributeKey<_> = AttributeKey<_>("FontSize")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HorizontalTextAlignmentAttribKey : AttributeKey<_> = AttributeKey<_>("HorizontalTextAlignment")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PlaceholderAttribKey : AttributeKey<_> = AttributeKey<_>("Placeholder")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PlaceholderColorAttribKey : AttributeKey<_> = AttributeKey<_>("PlaceholderColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SearchBarCommandAttribKey : AttributeKey<_> = AttributeKey<_>("SearchBarCommand")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SearchBarCanExecuteAttribKey : AttributeKey<_> = AttributeKey<_>("SearchBarCanExecute")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TextAttribKey : AttributeKey<_> = AttributeKey<_>("Text")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TextColorAttribKey : AttributeKey<_> = AttributeKey<_>("TextColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SearchBarTextChangedAttribKey : AttributeKey<_> = AttributeKey<_>("SearchBarTextChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ButtonCommandAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonCommand")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ButtonCanExecuteAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonCanExecute")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _BorderColorAttribKey : AttributeKey<_> = AttributeKey<_>("BorderColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _BorderWidthAttribKey : AttributeKey<_> = AttributeKey<_>("BorderWidth")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _CommandParameterAttribKey : AttributeKey<_> = AttributeKey<_>("CommandParameter")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ContentLayoutAttribKey : AttributeKey<_> = AttributeKey<_>("ContentLayout")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ButtonCornerRadiusAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonCornerRadius")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ButtonImageSourceAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonImageSource")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _MinimumMaximumAttribKey : AttributeKey<_> = AttributeKey<_>("MinimumMaximum")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ValueAttribKey : AttributeKey<_> = AttributeKey<_>("Value")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ValueChangedAttribKey : AttributeKey<_> = AttributeKey<_>("ValueChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IncrementAttribKey : AttributeKey<_> = AttributeKey<_>("Increment")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsToggledAttribKey : AttributeKey<_> = AttributeKey<_>("IsToggled")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ToggledAttribKey : AttributeKey<_> = AttributeKey<_>("Toggled")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _OnColorAttribKey : AttributeKey<_> = AttributeKey<_>("OnColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HeightAttribKey : AttributeKey<_> = AttributeKey<_>("Height")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _OnAttribKey : AttributeKey<_> = AttributeKey<_>("On")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _OnChangedAttribKey : AttributeKey<_> = AttributeKey<_>("OnChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IntentAttribKey : AttributeKey<_> = AttributeKey<_>("Intent")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HasUnevenRowsAttribKey : AttributeKey<_> = AttributeKey<_>("HasUnevenRows")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _RowHeightAttribKey : AttributeKey<_> = AttributeKey<_>("RowHeight")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TableRootAttribKey : AttributeKey<_> = AttributeKey<_>("TableRoot")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _RowDefinitionHeightAttribKey : AttributeKey<_> = AttributeKey<_>("RowDefinitionHeight")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ColumnDefinitionWidthAttribKey : AttributeKey<_> = AttributeKey<_>("ColumnDefinitionWidth")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _GridRowDefinitionsAttribKey : AttributeKey<_> = AttributeKey<_>("GridRowDefinitions")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _GridColumnDefinitionsAttribKey : AttributeKey<_> = AttributeKey<_>("GridColumnDefinitions")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _RowSpacingAttribKey : AttributeKey<_> = AttributeKey<_>("RowSpacing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ColumnSpacingAttribKey : AttributeKey<_> = AttributeKey<_>("ColumnSpacing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ChildrenAttribKey : AttributeKey<_> = AttributeKey<_>("Children")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _GridRowAttribKey : AttributeKey<_> = AttributeKey<_>("GridRow")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _GridRowSpanAttribKey : AttributeKey<_> = AttributeKey<_>("GridRowSpan")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _GridColumnAttribKey : AttributeKey<_> = AttributeKey<_>("GridColumn")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _GridColumnSpanAttribKey : AttributeKey<_> = AttributeKey<_>("GridColumnSpan")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _LayoutBoundsAttribKey : AttributeKey<_> = AttributeKey<_>("LayoutBounds")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _LayoutFlagsAttribKey : AttributeKey<_> = AttributeKey<_>("LayoutFlags")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _BoundsConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("BoundsConstraint")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HeightConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("HeightConstraint")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _WidthConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("WidthConstraint")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _XConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("XConstraint")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _YConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("YConstraint")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _AlignContentAttribKey : AttributeKey<_> = AttributeKey<_>("AlignContent")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _AlignItemsAttribKey : AttributeKey<_> = AttributeKey<_>("AlignItems")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FlexLayoutDirectionAttribKey : AttributeKey<_> = AttributeKey<_>("FlexLayoutDirection")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PositionAttribKey : AttributeKey<_> = AttributeKey<_>("Position")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _WrapAttribKey : AttributeKey<_> = AttributeKey<_>("Wrap")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _JustifyContentAttribKey : AttributeKey<_> = AttributeKey<_>("JustifyContent")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FlexAlignSelfAttribKey : AttributeKey<_> = AttributeKey<_>("FlexAlignSelf")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FlexOrderAttribKey : AttributeKey<_> = AttributeKey<_>("FlexOrder")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FlexBasisAttribKey : AttributeKey<_> = AttributeKey<_>("FlexBasis")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FlexGrowAttribKey : AttributeKey<_> = AttributeKey<_>("FlexGrow")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FlexShrinkAttribKey : AttributeKey<_> = AttributeKey<_>("FlexShrink")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _DateAttribKey : AttributeKey<_> = AttributeKey<_>("Date")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FormatAttribKey : AttributeKey<_> = AttributeKey<_>("Format")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _MinimumDateAttribKey : AttributeKey<_> = AttributeKey<_>("MinimumDate")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _MaximumDateAttribKey : AttributeKey<_> = AttributeKey<_>("MaximumDate")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _DateSelectedAttribKey : AttributeKey<_> = AttributeKey<_>("DateSelected")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PickerItemsSourceAttribKey : AttributeKey<_> = AttributeKey<_>("PickerItemsSource")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SelectedIndexAttribKey : AttributeKey<_> = AttributeKey<_>("SelectedIndex")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TitleAttribKey : AttributeKey<_> = AttributeKey<_>("Title")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SelectedIndexChangedAttribKey : AttributeKey<_> = AttributeKey<_>("SelectedIndexChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FrameCornerRadiusAttribKey : AttributeKey<_> = AttributeKey<_>("FrameCornerRadius")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HasShadowAttribKey : AttributeKey<_> = AttributeKey<_>("HasShadow")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ImageSourceAttribKey : AttributeKey<_> = AttributeKey<_>("ImageSource")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _AspectAttribKey : AttributeKey<_> = AttributeKey<_>("Aspect")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsOpaqueAttribKey : AttributeKey<_> = AttributeKey<_>("IsOpaque")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ImageButtonCommandAttribKey : AttributeKey<_> = AttributeKey<_>("ImageButtonCommand")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ImageButtonCornerRadiusAttribKey : AttributeKey<_> = AttributeKey<_>("ImageButtonCornerRadius")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ClickedAttribKey : AttributeKey<_> = AttributeKey<_>("Clicked")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PressedAttribKey : AttributeKey<_> = AttributeKey<_>("Pressed")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ReleasedAttribKey : AttributeKey<_> = AttributeKey<_>("Released")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _KeyboardAttribKey : AttributeKey<_> = AttributeKey<_>("Keyboard")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _EditorCompletedAttribKey : AttributeKey<_> = AttributeKey<_>("EditorCompleted")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TextChangedAttribKey : AttributeKey<_> = AttributeKey<_>("TextChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _AutoSizeAttribKey : AttributeKey<_> = AttributeKey<_>("AutoSize")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsPasswordAttribKey : AttributeKey<_> = AttributeKey<_>("IsPassword")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _EntryCompletedAttribKey : AttributeKey<_> = AttributeKey<_>("EntryCompleted")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsTextPredictionEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("IsTextPredictionEnabled")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ReturnTypeAttribKey : AttributeKey<_> = AttributeKey<_>("ReturnType")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ReturnCommandAttribKey : AttributeKey<_> = AttributeKey<_>("ReturnCommand")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _CursorPositionAttribKey : AttributeKey<_> = AttributeKey<_>("CursorPosition")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SelectionLengthAttribKey : AttributeKey<_> = AttributeKey<_>("SelectionLength")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _LabelAttribKey : AttributeKey<_> = AttributeKey<_>("Label")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _EntryCellTextChangedAttribKey : AttributeKey<_> = AttributeKey<_>("EntryCellTextChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _VerticalTextAlignmentAttribKey : AttributeKey<_> = AttributeKey<_>("VerticalTextAlignment")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FormattedTextAttribKey : AttributeKey<_> = AttributeKey<_>("FormattedText")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _LineBreakModeAttribKey : AttributeKey<_> = AttributeKey<_>("LineBreakMode")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _LineHeightAttribKey : AttributeKey<_> = AttributeKey<_>("LineHeight")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _MaxLinesAttribKey : AttributeKey<_> = AttributeKey<_>("MaxLines")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TextDecorationsAttribKey : AttributeKey<_> = AttributeKey<_>("TextDecorations")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _StackOrientationAttribKey : AttributeKey<_> = AttributeKey<_>("StackOrientation")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SpacingAttribKey : AttributeKey<_> = AttributeKey<_>("Spacing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ForegroundColorAttribKey : AttributeKey<_> = AttributeKey<_>("ForegroundColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PropertyChangedAttribKey : AttributeKey<_> = AttributeKey<_>("PropertyChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SpansAttribKey : AttributeKey<_> = AttributeKey<_>("Spans")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TimeAttribKey : AttributeKey<_> = AttributeKey<_>("Time")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _WebSourceAttribKey : AttributeKey<_> = AttributeKey<_>("WebSource")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ReloadAttribKey : AttributeKey<_> = AttributeKey<_>("Reload")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _NavigatedAttribKey : AttributeKey<_> = AttributeKey<_>("Navigated")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _NavigatingAttribKey : AttributeKey<_> = AttributeKey<_>("Navigating")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ReloadRequestedAttribKey : AttributeKey<_> = AttributeKey<_>("ReloadRequested")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _BackgroundImageAttribKey : AttributeKey<_> = AttributeKey<_>("BackgroundImage")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IconAttribKey : AttributeKey<_> = AttributeKey<_>("Icon")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsBusyAttribKey : AttributeKey<_> = AttributeKey<_>("IsBusy")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ToolbarItemsAttribKey : AttributeKey<_> = AttributeKey<_>("ToolbarItems")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _UseSafeAreaAttribKey : AttributeKey<_> = AttributeKey<_>("UseSafeArea")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _Page_AppearingAttribKey : AttributeKey<_> = AttributeKey<_>("Page_Appearing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _Page_DisappearingAttribKey : AttributeKey<_> = AttributeKey<_>("Page_Disappearing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _Page_LayoutChangedAttribKey : AttributeKey<_> = AttributeKey<_>("Page_LayoutChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _CarouselPage_CurrentPageAttribKey : AttributeKey<_> = AttributeKey<_>("CarouselPage_CurrentPage")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _CarouselPage_CurrentPageChangedAttribKey : AttributeKey<_> = AttributeKey<_>("CarouselPage_CurrentPageChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PagesAttribKey : AttributeKey<_> = AttributeKey<_>("Pages")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _BackButtonTitleAttribKey : AttributeKey<_> = AttributeKey<_>("BackButtonTitle")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HasBackButtonAttribKey : AttributeKey<_> = AttributeKey<_>("HasBackButton")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HasNavigationBarAttribKey : AttributeKey<_> = AttributeKey<_>("HasNavigationBar")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TitleIconAttribKey : AttributeKey<_> = AttributeKey<_>("TitleIcon")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TitleViewAttribKey : AttributeKey<_> = AttributeKey<_>("TitleView")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _BarBackgroundColorAttribKey : AttributeKey<_> = AttributeKey<_>("BarBackgroundColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _BarTextColorAttribKey : AttributeKey<_> = AttributeKey<_>("BarTextColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PoppedAttribKey : AttributeKey<_> = AttributeKey<_>("Popped")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PoppedToRootAttribKey : AttributeKey<_> = AttributeKey<_>("PoppedToRoot")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PushedAttribKey : AttributeKey<_> = AttributeKey<_>("Pushed")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TabbedPage_CurrentPageAttribKey : AttributeKey<_> = AttributeKey<_>("TabbedPage_CurrentPage")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TabbedPage_CurrentPageChangedAttribKey : AttributeKey<_> = AttributeKey<_>("TabbedPage_CurrentPageChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _OnSizeAllocatedCallbackAttribKey : AttributeKey<_> = AttributeKey<_>("OnSizeAllocatedCallback")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _MasterAttribKey : AttributeKey<_> = AttributeKey<_>("Master")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _DetailAttribKey : AttributeKey<_> = AttributeKey<_>("Detail")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsGestureEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("IsGestureEnabled")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsPresentedAttribKey : AttributeKey<_> = AttributeKey<_>("IsPresented")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _MasterBehaviorAttribKey : AttributeKey<_> = AttributeKey<_>("MasterBehavior")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsPresentedChangedAttribKey : AttributeKey<_> = AttributeKey<_>("IsPresentedChanged")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TextDetailAttribKey : AttributeKey<_> = AttributeKey<_>("TextDetail")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TextDetailColorAttribKey : AttributeKey<_> = AttributeKey<_>("TextDetailColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TextCellCommandAttribKey : AttributeKey<_> = AttributeKey<_>("TextCellCommand")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _TextCellCanExecuteAttribKey : AttributeKey<_> = AttributeKey<_>("TextCellCanExecute")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _OrderAttribKey : AttributeKey<_> = AttributeKey<_>("Order")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _PriorityAttribKey : AttributeKey<_> = AttributeKey<_>("Priority")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ViewAttribKey : AttributeKey<_> = AttributeKey<_>("View")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListViewItemsAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewItems")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _FooterAttribKey : AttributeKey<_> = AttributeKey<_>("Footer")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HeaderAttribKey : AttributeKey<_> = AttributeKey<_>("Header")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _HeaderTemplateAttribKey : AttributeKey<_> = AttributeKey<_>("HeaderTemplate")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsGroupingEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("IsGroupingEnabled")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsPullToRefreshEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("IsPullToRefreshEnabled")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _IsRefreshingAttribKey : AttributeKey<_> = AttributeKey<_>("IsRefreshing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _RefreshCommandAttribKey : AttributeKey<_> = AttributeKey<_>("RefreshCommand")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListView_SelectedItemAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_SelectedItem")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListView_SeparatorVisibilityAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_SeparatorVisibility")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListView_SeparatorColorAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_SeparatorColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListView_ItemAppearingAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_ItemAppearing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListView_ItemDisappearingAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_ItemDisappearing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListView_ItemSelectedAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_ItemSelected")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListView_ItemTappedAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_ItemTapped")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListView_RefreshingAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_Refreshing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SelectionModeAttribKey : AttributeKey<_> = AttributeKey<_>("SelectionMode")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListViewGrouped_ItemsSourceAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ItemsSource")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListViewGrouped_ShowJumpListAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ShowJumpList")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListViewGrouped_SelectedItemAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_SelectedItem")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SeparatorVisibilityAttribKey : AttributeKey<_> = AttributeKey<_>("SeparatorVisibility")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _SeparatorColorAttribKey : AttributeKey<_> = AttributeKey<_>("SeparatorColor")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListViewGrouped_ItemAppearingAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ItemAppearing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListViewGrouped_ItemDisappearingAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ItemDisappearing")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListViewGrouped_ItemSelectedAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ItemSelected")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _ListViewGrouped_ItemTappedAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ItemTapped")
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val _RefreshingAttribKey : AttributeKey<_> = AttributeKey<_>("Refreshing")

    /// Builds the attributes for a Element in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildElement(attribCount: int,
                                      ?classId: string,
                                      ?styleId: string,
                                      ?automationId: string,
                                      ?created: obj -> unit,
                                      ?ref: ViewRef) = 

        let attribCount = match classId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match automationId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match created with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match ref with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = new AttributesBuilder(attribCount)
        match classId with None -> () | Some v -> attribBuilder.Add(View._ClassIdAttribKey, (v)) 
        match styleId with None -> () | Some v -> attribBuilder.Add(View._StyleIdAttribKey, (v)) 
        match automationId with None -> () | Some v -> attribBuilder.Add(View._AutomationIdAttribKey, (v)) 
        match created with None -> () | Some v -> attribBuilder.Add(View._ElementCreatedAttribKey, (v)) 
        match ref with None -> () | Some v -> attribBuilder.Add(View._ElementViewRefAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncElement : (unit -> Xamarin.Forms.Element) = (fun () -> View.CreateElement())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateElement () : Xamarin.Forms.Element = 
        failwith "can't create Xamarin.Forms.Element"

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncElement = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Element) -> View.UpdateElement (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateElement (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Element) = 
        let mutable prevClassIdOpt = ValueNone
        let mutable currClassIdOpt = ValueNone
        let mutable prevStyleIdOpt = ValueNone
        let mutable currStyleIdOpt = ValueNone
        let mutable prevAutomationIdOpt = ValueNone
        let mutable currAutomationIdOpt = ValueNone
        let mutable prevElementCreatedOpt = ValueNone
        let mutable currElementCreatedOpt = ValueNone
        let mutable prevElementViewRefOpt = ValueNone
        let mutable currElementViewRefOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ClassIdAttribKey.KeyValue then 
                currClassIdOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._StyleIdAttribKey.KeyValue then 
                currStyleIdOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._AutomationIdAttribKey.KeyValue then 
                currAutomationIdOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._ElementCreatedAttribKey.KeyValue then 
                currElementCreatedOpt <- ValueSome (kvp.Value :?> obj -> unit)
            if kvp.Key = View._ElementViewRefAttribKey.KeyValue then 
                currElementViewRefOpt <- ValueSome (kvp.Value :?> ViewRef)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ClassIdAttribKey.KeyValue then 
                    prevClassIdOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._StyleIdAttribKey.KeyValue then 
                    prevStyleIdOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._AutomationIdAttribKey.KeyValue then 
                    prevAutomationIdOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._ElementCreatedAttribKey.KeyValue then 
                    prevElementCreatedOpt <- ValueSome (kvp.Value :?> obj -> unit)
                if kvp.Key = View._ElementViewRefAttribKey.KeyValue then 
                    prevElementViewRefOpt <- ValueSome (kvp.Value :?> ViewRef)
        match prevClassIdOpt, currClassIdOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ClassId <-  currValue
        | ValueSome _, ValueNone -> target.ClassId <- null
        | ValueNone, ValueNone -> ()
        match prevStyleIdOpt, currStyleIdOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.StyleId <-  currValue
        | ValueSome _, ValueNone -> target.StyleId <- null
        | ValueNone, ValueNone -> ()
        match prevAutomationIdOpt, currAutomationIdOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AutomationId <-  currValue
        | ValueSome _, ValueNone -> target.AutomationId <- null
        | ValueNone, ValueNone -> ()
        (fun _ _ _ -> ()) prevElementCreatedOpt currElementCreatedOpt target
        (fun _ _ _ -> ()) prevElementViewRefOpt currElementViewRefOpt target

    /// Describes a Element in the view
    static member inline Element(?classId: string,
                                 ?styleId: string,
                                 ?automationId: string,
                                 ?created: (Xamarin.Forms.Element -> unit),
                                 ?ref: ViewRef<Xamarin.Forms.Element>) = 

        let attribBuilder = View.BuildElement(0,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Element> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Element>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Element>(View.CreateFuncElement, View.UpdateFuncElement, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoElement : ViewElement option = None with get, set

    /// Builds the attributes for a VisualElement in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildVisualElement(attribCount: int,
                                            ?anchorX: double,
                                            ?anchorY: double,
                                            ?backgroundColor: Xamarin.Forms.Color,
                                            ?heightRequest: double,
                                            ?inputTransparent: bool,
                                            ?isEnabled: bool,
                                            ?isVisible: bool,
                                            ?minimumHeightRequest: double,
                                            ?minimumWidthRequest: double,
                                            ?opacity: double,
                                            ?rotation: double,
                                            ?rotationX: double,
                                            ?rotationY: double,
                                            ?scale: double,
                                            ?style: Xamarin.Forms.Style,
                                            ?styleClass: obj,
                                            ?translationX: double,
                                            ?translationY: double,
                                            ?widthRequest: double,
                                            ?resources: (string * obj) list,
                                            ?styles: Xamarin.Forms.Style list,
                                            ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                            ?isTabStop: bool,
                                            ?scaleX: double,
                                            ?scaleY: double,
                                            ?tabIndex: int,
                                            ?classId: string,
                                            ?styleId: string,
                                            ?automationId: string,
                                            ?created: obj -> unit,
                                            ?ref: ViewRef) = 

        let attribCount = match anchorX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match anchorY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match backgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match heightRequest with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match inputTransparent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isVisible with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match minimumHeightRequest with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match minimumWidthRequest with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match opacity with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rotation with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rotationX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rotationY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scale with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match style with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleClass with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match translationX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match translationY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match widthRequest with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match resources with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styles with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleSheets with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isTabStop with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scaleX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match scaleY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match tabIndex with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildElement(attribCount, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match anchorX with None -> () | Some v -> attribBuilder.Add(View._AnchorXAttribKey, (v)) 
        match anchorY with None -> () | Some v -> attribBuilder.Add(View._AnchorYAttribKey, (v)) 
        match backgroundColor with None -> () | Some v -> attribBuilder.Add(View._BackgroundColorAttribKey, (v)) 
        match heightRequest with None -> () | Some v -> attribBuilder.Add(View._HeightRequestAttribKey, (v)) 
        match inputTransparent with None -> () | Some v -> attribBuilder.Add(View._InputTransparentAttribKey, (v)) 
        match isEnabled with None -> () | Some v -> attribBuilder.Add(View._IsEnabledAttribKey, (v)) 
        match isVisible with None -> () | Some v -> attribBuilder.Add(View._IsVisibleAttribKey, (v)) 
        match minimumHeightRequest with None -> () | Some v -> attribBuilder.Add(View._MinimumHeightRequestAttribKey, (v)) 
        match minimumWidthRequest with None -> () | Some v -> attribBuilder.Add(View._MinimumWidthRequestAttribKey, (v)) 
        match opacity with None -> () | Some v -> attribBuilder.Add(View._OpacityAttribKey, (v)) 
        match rotation with None -> () | Some v -> attribBuilder.Add(View._RotationAttribKey, (v)) 
        match rotationX with None -> () | Some v -> attribBuilder.Add(View._RotationXAttribKey, (v)) 
        match rotationY with None -> () | Some v -> attribBuilder.Add(View._RotationYAttribKey, (v)) 
        match scale with None -> () | Some v -> attribBuilder.Add(View._ScaleAttribKey, (v)) 
        match style with None -> () | Some v -> attribBuilder.Add(View._StyleAttribKey, (v)) 
        match styleClass with None -> () | Some v -> attribBuilder.Add(View._StyleClassAttribKey, makeStyleClass(v)) 
        match translationX with None -> () | Some v -> attribBuilder.Add(View._TranslationXAttribKey, (v)) 
        match translationY with None -> () | Some v -> attribBuilder.Add(View._TranslationYAttribKey, (v)) 
        match widthRequest with None -> () | Some v -> attribBuilder.Add(View._WidthRequestAttribKey, (v)) 
        match resources with None -> () | Some v -> attribBuilder.Add(View._ResourcesAttribKey, (v)) 
        match styles with None -> () | Some v -> attribBuilder.Add(View._StylesAttribKey, (v)) 
        match styleSheets with None -> () | Some v -> attribBuilder.Add(View._StyleSheetsAttribKey, (v)) 
        match isTabStop with None -> () | Some v -> attribBuilder.Add(View._IsTabStopAttribKey, (v)) 
        match scaleX with None -> () | Some v -> attribBuilder.Add(View._ScaleXAttribKey, (v)) 
        match scaleY with None -> () | Some v -> attribBuilder.Add(View._ScaleYAttribKey, (v)) 
        match tabIndex with None -> () | Some v -> attribBuilder.Add(View._TabIndexAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncVisualElement : (unit -> Xamarin.Forms.VisualElement) = (fun () -> View.CreateVisualElement())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateVisualElement () : Xamarin.Forms.VisualElement = 
        failwith "can't create Xamarin.Forms.VisualElement"

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncVisualElement = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.VisualElement) -> View.UpdateVisualElement (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateVisualElement (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.VisualElement) = 
        // update the inherited Element element
        let baseElement = (if View.ProtoElement.IsNone then View.ProtoElement <- Some (View.Element())); View.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevAnchorXOpt = ValueNone
        let mutable currAnchorXOpt = ValueNone
        let mutable prevAnchorYOpt = ValueNone
        let mutable currAnchorYOpt = ValueNone
        let mutable prevBackgroundColorOpt = ValueNone
        let mutable currBackgroundColorOpt = ValueNone
        let mutable prevHeightRequestOpt = ValueNone
        let mutable currHeightRequestOpt = ValueNone
        let mutable prevInputTransparentOpt = ValueNone
        let mutable currInputTransparentOpt = ValueNone
        let mutable prevIsEnabledOpt = ValueNone
        let mutable currIsEnabledOpt = ValueNone
        let mutable prevIsVisibleOpt = ValueNone
        let mutable currIsVisibleOpt = ValueNone
        let mutable prevMinimumHeightRequestOpt = ValueNone
        let mutable currMinimumHeightRequestOpt = ValueNone
        let mutable prevMinimumWidthRequestOpt = ValueNone
        let mutable currMinimumWidthRequestOpt = ValueNone
        let mutable prevOpacityOpt = ValueNone
        let mutable currOpacityOpt = ValueNone
        let mutable prevRotationOpt = ValueNone
        let mutable currRotationOpt = ValueNone
        let mutable prevRotationXOpt = ValueNone
        let mutable currRotationXOpt = ValueNone
        let mutable prevRotationYOpt = ValueNone
        let mutable currRotationYOpt = ValueNone
        let mutable prevScaleOpt = ValueNone
        let mutable currScaleOpt = ValueNone
        let mutable prevStyleOpt = ValueNone
        let mutable currStyleOpt = ValueNone
        let mutable prevStyleClassOpt = ValueNone
        let mutable currStyleClassOpt = ValueNone
        let mutable prevTranslationXOpt = ValueNone
        let mutable currTranslationXOpt = ValueNone
        let mutable prevTranslationYOpt = ValueNone
        let mutable currTranslationYOpt = ValueNone
        let mutable prevWidthRequestOpt = ValueNone
        let mutable currWidthRequestOpt = ValueNone
        let mutable prevResourcesOpt = ValueNone
        let mutable currResourcesOpt = ValueNone
        let mutable prevStylesOpt = ValueNone
        let mutable currStylesOpt = ValueNone
        let mutable prevStyleSheetsOpt = ValueNone
        let mutable currStyleSheetsOpt = ValueNone
        let mutable prevIsTabStopOpt = ValueNone
        let mutable currIsTabStopOpt = ValueNone
        let mutable prevScaleXOpt = ValueNone
        let mutable currScaleXOpt = ValueNone
        let mutable prevScaleYOpt = ValueNone
        let mutable currScaleYOpt = ValueNone
        let mutable prevTabIndexOpt = ValueNone
        let mutable currTabIndexOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._AnchorXAttribKey.KeyValue then 
                currAnchorXOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._AnchorYAttribKey.KeyValue then 
                currAnchorYOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._BackgroundColorAttribKey.KeyValue then 
                currBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._HeightRequestAttribKey.KeyValue then 
                currHeightRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._InputTransparentAttribKey.KeyValue then 
                currInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._IsEnabledAttribKey.KeyValue then 
                currIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._IsVisibleAttribKey.KeyValue then 
                currIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._MinimumHeightRequestAttribKey.KeyValue then 
                currMinimumHeightRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._MinimumWidthRequestAttribKey.KeyValue then 
                currMinimumWidthRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._OpacityAttribKey.KeyValue then 
                currOpacityOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._RotationAttribKey.KeyValue then 
                currRotationOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._RotationXAttribKey.KeyValue then 
                currRotationXOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._RotationYAttribKey.KeyValue then 
                currRotationYOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._ScaleAttribKey.KeyValue then 
                currScaleOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._StyleAttribKey.KeyValue then 
                currStyleOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style)
            if kvp.Key = View._StyleClassAttribKey.KeyValue then 
                currStyleClassOpt <- ValueSome (kvp.Value :?> System.Collections.Generic.IList<string>)
            if kvp.Key = View._TranslationXAttribKey.KeyValue then 
                currTranslationXOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._TranslationYAttribKey.KeyValue then 
                currTranslationYOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._WidthRequestAttribKey.KeyValue then 
                currWidthRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._ResourcesAttribKey.KeyValue then 
                currResourcesOpt <- ValueSome (kvp.Value :?> (string * obj) list)
            if kvp.Key = View._StylesAttribKey.KeyValue then 
                currStylesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style list)
            if kvp.Key = View._StyleSheetsAttribKey.KeyValue then 
                currStyleSheetsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StyleSheets.StyleSheet list)
            if kvp.Key = View._IsTabStopAttribKey.KeyValue then 
                currIsTabStopOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._ScaleXAttribKey.KeyValue then 
                currScaleXOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._ScaleYAttribKey.KeyValue then 
                currScaleYOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._TabIndexAttribKey.KeyValue then 
                currTabIndexOpt <- ValueSome (kvp.Value :?> int)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._AnchorXAttribKey.KeyValue then 
                    prevAnchorXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._AnchorYAttribKey.KeyValue then 
                    prevAnchorYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._BackgroundColorAttribKey.KeyValue then 
                    prevBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._HeightRequestAttribKey.KeyValue then 
                    prevHeightRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._InputTransparentAttribKey.KeyValue then 
                    prevInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._IsEnabledAttribKey.KeyValue then 
                    prevIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._IsVisibleAttribKey.KeyValue then 
                    prevIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._MinimumHeightRequestAttribKey.KeyValue then 
                    prevMinimumHeightRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._MinimumWidthRequestAttribKey.KeyValue then 
                    prevMinimumWidthRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._OpacityAttribKey.KeyValue then 
                    prevOpacityOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._RotationAttribKey.KeyValue then 
                    prevRotationOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._RotationXAttribKey.KeyValue then 
                    prevRotationXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._RotationYAttribKey.KeyValue then 
                    prevRotationYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._ScaleAttribKey.KeyValue then 
                    prevScaleOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._StyleAttribKey.KeyValue then 
                    prevStyleOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style)
                if kvp.Key = View._StyleClassAttribKey.KeyValue then 
                    prevStyleClassOpt <- ValueSome (kvp.Value :?> System.Collections.Generic.IList<string>)
                if kvp.Key = View._TranslationXAttribKey.KeyValue then 
                    prevTranslationXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._TranslationYAttribKey.KeyValue then 
                    prevTranslationYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._WidthRequestAttribKey.KeyValue then 
                    prevWidthRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._ResourcesAttribKey.KeyValue then 
                    prevResourcesOpt <- ValueSome (kvp.Value :?> (string * obj) list)
                if kvp.Key = View._StylesAttribKey.KeyValue then 
                    prevStylesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style list)
                if kvp.Key = View._StyleSheetsAttribKey.KeyValue then 
                    prevStyleSheetsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StyleSheets.StyleSheet list)
                if kvp.Key = View._IsTabStopAttribKey.KeyValue then 
                    prevIsTabStopOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._ScaleXAttribKey.KeyValue then 
                    prevScaleXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._ScaleYAttribKey.KeyValue then 
                    prevScaleYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._TabIndexAttribKey.KeyValue then 
                    prevTabIndexOpt <- ValueSome (kvp.Value :?> int)
        match prevAnchorXOpt, currAnchorXOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AnchorX <-  currValue
        | ValueSome _, ValueNone -> target.AnchorX <- 0.0
        | ValueNone, ValueNone -> ()
        match prevAnchorYOpt, currAnchorYOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AnchorY <-  currValue
        | ValueSome _, ValueNone -> target.AnchorY <- 0.0
        | ValueNone, ValueNone -> ()
        match prevBackgroundColorOpt, currBackgroundColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BackgroundColor <-  currValue
        | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevHeightRequestOpt, currHeightRequestOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HeightRequest <-  currValue
        | ValueSome _, ValueNone -> target.HeightRequest <- -1.0
        | ValueNone, ValueNone -> ()
        match prevInputTransparentOpt, currInputTransparentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.InputTransparent <-  currValue
        | ValueSome _, ValueNone -> target.InputTransparent <- false
        | ValueNone, ValueNone -> ()
        match prevIsEnabledOpt, currIsEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsEnabled <-  currValue
        | ValueSome _, ValueNone -> target.IsEnabled <- true
        | ValueNone, ValueNone -> ()
        match prevIsVisibleOpt, currIsVisibleOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsVisible <-  currValue
        | ValueSome _, ValueNone -> target.IsVisible <- true
        | ValueNone, ValueNone -> ()
        match prevMinimumHeightRequestOpt, currMinimumHeightRequestOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MinimumHeightRequest <-  currValue
        | ValueSome _, ValueNone -> target.MinimumHeightRequest <- -1.0
        | ValueNone, ValueNone -> ()
        match prevMinimumWidthRequestOpt, currMinimumWidthRequestOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MinimumWidthRequest <-  currValue
        | ValueSome _, ValueNone -> target.MinimumWidthRequest <- -1.0
        | ValueNone, ValueNone -> ()
        match prevOpacityOpt, currOpacityOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Opacity <-  currValue
        | ValueSome _, ValueNone -> target.Opacity <- 1.0
        | ValueNone, ValueNone -> ()
        match prevRotationOpt, currRotationOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Rotation <-  currValue
        | ValueSome _, ValueNone -> target.Rotation <- 0.0
        | ValueNone, ValueNone -> ()
        match prevRotationXOpt, currRotationXOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RotationX <-  currValue
        | ValueSome _, ValueNone -> target.RotationX <- 0.0
        | ValueNone, ValueNone -> ()
        match prevRotationYOpt, currRotationYOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RotationY <-  currValue
        | ValueSome _, ValueNone -> target.RotationY <- 0.0
        | ValueNone, ValueNone -> ()
        match prevScaleOpt, currScaleOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Scale <-  currValue
        | ValueSome _, ValueNone -> target.Scale <- 1.0
        | ValueNone, ValueNone -> ()
        match prevStyleOpt, currStyleOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Style <-  currValue
        | ValueSome _, ValueNone -> target.Style <- null
        | ValueNone, ValueNone -> ()
        updateStyleClass prevStyleClassOpt currStyleClassOpt target
        match prevTranslationXOpt, currTranslationXOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TranslationX <-  currValue
        | ValueSome _, ValueNone -> target.TranslationX <- 0.0
        | ValueNone, ValueNone -> ()
        match prevTranslationYOpt, currTranslationYOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TranslationY <-  currValue
        | ValueSome _, ValueNone -> target.TranslationY <- 0.0
        | ValueNone, ValueNone -> ()
        match prevWidthRequestOpt, currWidthRequestOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.WidthRequest <-  currValue
        | ValueSome _, ValueNone -> target.WidthRequest <- -1.0
        | ValueNone, ValueNone -> ()
        updateResources prevResourcesOpt currResourcesOpt target
        updateStyles prevStylesOpt currStylesOpt target
        updateStyleSheets prevStyleSheetsOpt currStyleSheetsOpt target
        match prevIsTabStopOpt, currIsTabStopOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsTabStop <-  currValue
        | ValueSome _, ValueNone -> target.IsTabStop <- true
        | ValueNone, ValueNone -> ()
        match prevScaleXOpt, currScaleXOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ScaleX <-  currValue
        | ValueSome _, ValueNone -> target.ScaleX <- 0.0
        | ValueNone, ValueNone -> ()
        match prevScaleYOpt, currScaleYOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ScaleY <-  currValue
        | ValueSome _, ValueNone -> target.ScaleY <- 0.0
        | ValueNone, ValueNone -> ()
        match prevTabIndexOpt, currTabIndexOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TabIndex <-  currValue
        | ValueSome _, ValueNone -> target.TabIndex <- 0
        | ValueNone, ValueNone -> ()

    /// Describes a VisualElement in the view
    static member inline VisualElement(?anchorX: double,
                                       ?anchorY: double,
                                       ?backgroundColor: Xamarin.Forms.Color,
                                       ?heightRequest: double,
                                       ?inputTransparent: bool,
                                       ?isEnabled: bool,
                                       ?isVisible: bool,
                                       ?minimumHeightRequest: double,
                                       ?minimumWidthRequest: double,
                                       ?opacity: double,
                                       ?rotation: double,
                                       ?rotationX: double,
                                       ?rotationY: double,
                                       ?scale: double,
                                       ?style: Xamarin.Forms.Style,
                                       ?styleClass: obj,
                                       ?translationX: double,
                                       ?translationY: double,
                                       ?widthRequest: double,
                                       ?resources: (string * obj) list,
                                       ?styles: Xamarin.Forms.Style list,
                                       ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                       ?isTabStop: bool,
                                       ?scaleX: double,
                                       ?scaleY: double,
                                       ?tabIndex: int,
                                       ?classId: string,
                                       ?styleId: string,
                                       ?automationId: string,
                                       ?created: (Xamarin.Forms.VisualElement -> unit),
                                       ?ref: ViewRef<Xamarin.Forms.VisualElement>) = 

        let attribBuilder = View.BuildVisualElement(0,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.VisualElement> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.VisualElement>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.VisualElement>(View.CreateFuncVisualElement, View.UpdateFuncVisualElement, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoVisualElement : ViewElement option = None with get, set

    /// Builds the attributes for a View in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildView(attribCount: int,
                                   ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                   ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                   ?margin: obj,
                                   ?gestureRecognizers: ViewElement list,
                                   ?anchorX: double,
                                   ?anchorY: double,
                                   ?backgroundColor: Xamarin.Forms.Color,
                                   ?heightRequest: double,
                                   ?inputTransparent: bool,
                                   ?isEnabled: bool,
                                   ?isVisible: bool,
                                   ?minimumHeightRequest: double,
                                   ?minimumWidthRequest: double,
                                   ?opacity: double,
                                   ?rotation: double,
                                   ?rotationX: double,
                                   ?rotationY: double,
                                   ?scale: double,
                                   ?style: Xamarin.Forms.Style,
                                   ?styleClass: obj,
                                   ?translationX: double,
                                   ?translationY: double,
                                   ?widthRequest: double,
                                   ?resources: (string * obj) list,
                                   ?styles: Xamarin.Forms.Style list,
                                   ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                   ?isTabStop: bool,
                                   ?scaleX: double,
                                   ?scaleY: double,
                                   ?tabIndex: int,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?automationId: string,
                                   ?created: obj -> unit,
                                   ?ref: ViewRef) = 

        let attribCount = match horizontalOptions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match verticalOptions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match margin with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match gestureRecognizers with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildVisualElement(attribCount, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match horizontalOptions with None -> () | Some v -> attribBuilder.Add(View._HorizontalOptionsAttribKey, (v)) 
        match verticalOptions with None -> () | Some v -> attribBuilder.Add(View._VerticalOptionsAttribKey, (v)) 
        match margin with None -> () | Some v -> attribBuilder.Add(View._MarginAttribKey, makeThickness(v)) 
        match gestureRecognizers with None -> () | Some v -> attribBuilder.Add(View._GestureRecognizersAttribKey, Array.ofList(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncView : (unit -> Xamarin.Forms.View) = (fun () -> View.CreateView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateView () : Xamarin.Forms.View = 
        failwith "can't create Xamarin.Forms.View"

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.View) -> View.UpdateView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.View) = 
        // update the inherited VisualElement element
        let baseElement = (if View.ProtoVisualElement.IsNone then View.ProtoVisualElement <- Some (View.VisualElement())); View.ProtoVisualElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevHorizontalOptionsOpt = ValueNone
        let mutable currHorizontalOptionsOpt = ValueNone
        let mutable prevVerticalOptionsOpt = ValueNone
        let mutable currVerticalOptionsOpt = ValueNone
        let mutable prevMarginOpt = ValueNone
        let mutable currMarginOpt = ValueNone
        let mutable prevGestureRecognizersOpt = ValueNone
        let mutable currGestureRecognizersOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._HorizontalOptionsAttribKey.KeyValue then 
                currHorizontalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
            if kvp.Key = View._VerticalOptionsAttribKey.KeyValue then 
                currVerticalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
            if kvp.Key = View._MarginAttribKey.KeyValue then 
                currMarginOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
            if kvp.Key = View._GestureRecognizersAttribKey.KeyValue then 
                currGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._HorizontalOptionsAttribKey.KeyValue then 
                    prevHorizontalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                if kvp.Key = View._VerticalOptionsAttribKey.KeyValue then 
                    prevVerticalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                if kvp.Key = View._MarginAttribKey.KeyValue then 
                    prevMarginOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                if kvp.Key = View._GestureRecognizersAttribKey.KeyValue then 
                    prevGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevHorizontalOptionsOpt, currHorizontalOptionsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HorizontalOptions <-  currValue
        | ValueSome _, ValueNone -> target.HorizontalOptions <- Xamarin.Forms.LayoutOptions.Fill
        | ValueNone, ValueNone -> ()
        match prevVerticalOptionsOpt, currVerticalOptionsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.VerticalOptions <-  currValue
        | ValueSome _, ValueNone -> target.VerticalOptions <- Xamarin.Forms.LayoutOptions.Fill
        | ValueNone, ValueNone -> ()
        match prevMarginOpt, currMarginOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Margin <-  currValue
        | ValueSome _, ValueNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
        | ValueNone, ValueNone -> ()
        updateCollectionGeneric prevGestureRecognizersOpt currGestureRecognizersOpt target.GestureRecognizers
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.IGestureRecognizer)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild

    /// Describes a View in the view
    static member inline View(?horizontalOptions: Xamarin.Forms.LayoutOptions,
                              ?verticalOptions: Xamarin.Forms.LayoutOptions,
                              ?margin: obj,
                              ?gestureRecognizers: ViewElement list,
                              ?anchorX: double,
                              ?anchorY: double,
                              ?backgroundColor: Xamarin.Forms.Color,
                              ?heightRequest: double,
                              ?inputTransparent: bool,
                              ?isEnabled: bool,
                              ?isVisible: bool,
                              ?minimumHeightRequest: double,
                              ?minimumWidthRequest: double,
                              ?opacity: double,
                              ?rotation: double,
                              ?rotationX: double,
                              ?rotationY: double,
                              ?scale: double,
                              ?style: Xamarin.Forms.Style,
                              ?styleClass: obj,
                              ?translationX: double,
                              ?translationY: double,
                              ?widthRequest: double,
                              ?resources: (string * obj) list,
                              ?styles: Xamarin.Forms.Style list,
                              ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                              ?isTabStop: bool,
                              ?scaleX: double,
                              ?scaleY: double,
                              ?tabIndex: int,
                              ?classId: string,
                              ?styleId: string,
                              ?automationId: string,
                              ?created: (Xamarin.Forms.View -> unit),
                              ?ref: ViewRef<Xamarin.Forms.View>) = 

        let attribBuilder = View.BuildView(0,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.View> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.View>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.View>(View.CreateFuncView, View.UpdateFuncView, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoView : ViewElement option = None with get, set

    /// Builds the attributes for a IGestureRecognizer in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildIGestureRecognizer(attribCount: int) = 
        let attribBuilder = new AttributesBuilder(attribCount)
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncIGestureRecognizer : (unit -> Xamarin.Forms.IGestureRecognizer) = (fun () -> View.CreateIGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateIGestureRecognizer () : Xamarin.Forms.IGestureRecognizer = 
        failwith "can't create Xamarin.Forms.IGestureRecognizer"

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncIGestureRecognizer = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.IGestureRecognizer) -> View.UpdateIGestureRecognizer (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateIGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.IGestureRecognizer) = 
        ignore prevOpt
        ignore curr
        ignore target

    /// Describes a IGestureRecognizer in the view
    static member inline IGestureRecognizer() = 

        let attribBuilder = View.BuildIGestureRecognizer(0)

        ViewElement.Create<Xamarin.Forms.IGestureRecognizer>(View.CreateFuncIGestureRecognizer, View.UpdateFuncIGestureRecognizer, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoIGestureRecognizer : ViewElement option = None with get, set

    /// Builds the attributes for a PanGestureRecognizer in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildPanGestureRecognizer(attribCount: int,
                                                   ?touchPoints: int,
                                                   ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit,
                                                   ?classId: string,
                                                   ?styleId: string,
                                                   ?automationId: string,
                                                   ?created: obj -> unit,
                                                   ?ref: ViewRef) = 

        let attribCount = match touchPoints with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match panUpdated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildElement(attribCount, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match touchPoints with None -> () | Some v -> attribBuilder.Add(View._TouchPointsAttribKey, (v)) 
        match panUpdated with None -> () | Some v -> attribBuilder.Add(View._PanUpdatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncPanGestureRecognizer : (unit -> Xamarin.Forms.PanGestureRecognizer) = (fun () -> View.CreatePanGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreatePanGestureRecognizer () : Xamarin.Forms.PanGestureRecognizer = 
        upcast (new Xamarin.Forms.PanGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncPanGestureRecognizer = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.PanGestureRecognizer) -> View.UpdatePanGestureRecognizer (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdatePanGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.PanGestureRecognizer) = 
        // update the inherited Element element
        let baseElement = (if View.ProtoElement.IsNone then View.ProtoElement <- Some (View.Element())); View.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevTouchPointsOpt = ValueNone
        let mutable currTouchPointsOpt = ValueNone
        let mutable prevPanUpdatedOpt = ValueNone
        let mutable currPanUpdatedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._TouchPointsAttribKey.KeyValue then 
                currTouchPointsOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._PanUpdatedAttribKey.KeyValue then 
                currPanUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._TouchPointsAttribKey.KeyValue then 
                    prevTouchPointsOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._PanUpdatedAttribKey.KeyValue then 
                    prevPanUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>)
        match prevTouchPointsOpt, currTouchPointsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TouchPoints <-  currValue
        | ValueSome _, ValueNone -> target.TouchPoints <- 1
        | ValueNone, ValueNone -> ()
        match prevPanUpdatedOpt, currPanUpdatedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.PanUpdated.RemoveHandler(prevValue); target.PanUpdated.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.PanUpdated.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.PanUpdated.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a PanGestureRecognizer in the view
    static member inline PanGestureRecognizer(?touchPoints: int,
                                              ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit,
                                              ?classId: string,
                                              ?styleId: string,
                                              ?automationId: string,
                                              ?created: (Xamarin.Forms.PanGestureRecognizer -> unit),
                                              ?ref: ViewRef<Xamarin.Forms.PanGestureRecognizer>) = 

        let attribBuilder = View.BuildPanGestureRecognizer(0,
                               ?touchPoints=touchPoints,
                               ?panUpdated=panUpdated,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.PanGestureRecognizer> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.PanGestureRecognizer>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.PanGestureRecognizer>(View.CreateFuncPanGestureRecognizer, View.UpdateFuncPanGestureRecognizer, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoPanGestureRecognizer : ViewElement option = None with get, set

    /// Builds the attributes for a TapGestureRecognizer in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildTapGestureRecognizer(attribCount: int,
                                                   ?command: unit -> unit,
                                                   ?numberOfTapsRequired: int,
                                                   ?classId: string,
                                                   ?styleId: string,
                                                   ?automationId: string,
                                                   ?created: obj -> unit,
                                                   ?ref: ViewRef) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match numberOfTapsRequired with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildElement(attribCount, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match command with None -> () | Some v -> attribBuilder.Add(View._CommandAttribKey, makeCommand(v)) 
        match numberOfTapsRequired with None -> () | Some v -> attribBuilder.Add(View._NumberOfTapsRequiredAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncTapGestureRecognizer : (unit -> Xamarin.Forms.TapGestureRecognizer) = (fun () -> View.CreateTapGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateTapGestureRecognizer () : Xamarin.Forms.TapGestureRecognizer = 
        upcast (new Xamarin.Forms.TapGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncTapGestureRecognizer = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TapGestureRecognizer) -> View.UpdateTapGestureRecognizer (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateTapGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.TapGestureRecognizer) = 
        // update the inherited Element element
        let baseElement = (if View.ProtoElement.IsNone then View.ProtoElement <- Some (View.Element())); View.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevCommandOpt = ValueNone
        let mutable currCommandOpt = ValueNone
        let mutable prevNumberOfTapsRequiredOpt = ValueNone
        let mutable currNumberOfTapsRequiredOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._CommandAttribKey.KeyValue then 
                currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = View._NumberOfTapsRequiredAttribKey.KeyValue then 
                currNumberOfTapsRequiredOpt <- ValueSome (kvp.Value :?> int)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._CommandAttribKey.KeyValue then 
                    prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = View._NumberOfTapsRequiredAttribKey.KeyValue then 
                    prevNumberOfTapsRequiredOpt <- ValueSome (kvp.Value :?> int)
        match prevCommandOpt, currCommandOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Command <-  currValue
        | ValueSome _, ValueNone -> target.Command <- null
        | ValueNone, ValueNone -> ()
        match prevNumberOfTapsRequiredOpt, currNumberOfTapsRequiredOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.NumberOfTapsRequired <-  currValue
        | ValueSome _, ValueNone -> target.NumberOfTapsRequired <- 1
        | ValueNone, ValueNone -> ()

    /// Describes a TapGestureRecognizer in the view
    static member inline TapGestureRecognizer(?command: unit -> unit,
                                              ?numberOfTapsRequired: int,
                                              ?classId: string,
                                              ?styleId: string,
                                              ?automationId: string,
                                              ?created: (Xamarin.Forms.TapGestureRecognizer -> unit),
                                              ?ref: ViewRef<Xamarin.Forms.TapGestureRecognizer>) = 

        let attribBuilder = View.BuildTapGestureRecognizer(0,
                               ?command=command,
                               ?numberOfTapsRequired=numberOfTapsRequired,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.TapGestureRecognizer> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.TapGestureRecognizer>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.TapGestureRecognizer>(View.CreateFuncTapGestureRecognizer, View.UpdateFuncTapGestureRecognizer, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoTapGestureRecognizer : ViewElement option = None with get, set

    /// Builds the attributes for a ClickGestureRecognizer in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildClickGestureRecognizer(attribCount: int,
                                                     ?command: unit -> unit,
                                                     ?numberOfClicksRequired: int,
                                                     ?buttons: Xamarin.Forms.ButtonsMask,
                                                     ?classId: string,
                                                     ?styleId: string,
                                                     ?automationId: string,
                                                     ?created: obj -> unit,
                                                     ?ref: ViewRef) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match numberOfClicksRequired with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match buttons with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildElement(attribCount, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match command with None -> () | Some v -> attribBuilder.Add(View._CommandAttribKey, makeCommand(v)) 
        match numberOfClicksRequired with None -> () | Some v -> attribBuilder.Add(View._NumberOfClicksRequiredAttribKey, (v)) 
        match buttons with None -> () | Some v -> attribBuilder.Add(View._ButtonsAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncClickGestureRecognizer : (unit -> Xamarin.Forms.ClickGestureRecognizer) = (fun () -> View.CreateClickGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateClickGestureRecognizer () : Xamarin.Forms.ClickGestureRecognizer = 
        upcast (new Xamarin.Forms.ClickGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncClickGestureRecognizer = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ClickGestureRecognizer) -> View.UpdateClickGestureRecognizer (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateClickGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ClickGestureRecognizer) = 
        // update the inherited Element element
        let baseElement = (if View.ProtoElement.IsNone then View.ProtoElement <- Some (View.Element())); View.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevCommandOpt = ValueNone
        let mutable currCommandOpt = ValueNone
        let mutable prevNumberOfClicksRequiredOpt = ValueNone
        let mutable currNumberOfClicksRequiredOpt = ValueNone
        let mutable prevButtonsOpt = ValueNone
        let mutable currButtonsOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._CommandAttribKey.KeyValue then 
                currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = View._NumberOfClicksRequiredAttribKey.KeyValue then 
                currNumberOfClicksRequiredOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._ButtonsAttribKey.KeyValue then 
                currButtonsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ButtonsMask)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._CommandAttribKey.KeyValue then 
                    prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = View._NumberOfClicksRequiredAttribKey.KeyValue then 
                    prevNumberOfClicksRequiredOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._ButtonsAttribKey.KeyValue then 
                    prevButtonsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ButtonsMask)
        match prevCommandOpt, currCommandOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Command <-  currValue
        | ValueSome _, ValueNone -> target.Command <- null
        | ValueNone, ValueNone -> ()
        match prevNumberOfClicksRequiredOpt, currNumberOfClicksRequiredOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.NumberOfClicksRequired <-  currValue
        | ValueSome _, ValueNone -> target.NumberOfClicksRequired <- 1
        | ValueNone, ValueNone -> ()
        match prevButtonsOpt, currButtonsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Buttons <-  currValue
        | ValueSome _, ValueNone -> target.Buttons <- Xamarin.Forms.ButtonsMask.Primary
        | ValueNone, ValueNone -> ()

    /// Describes a ClickGestureRecognizer in the view
    static member inline ClickGestureRecognizer(?command: unit -> unit,
                                                ?numberOfClicksRequired: int,
                                                ?buttons: Xamarin.Forms.ButtonsMask,
                                                ?classId: string,
                                                ?styleId: string,
                                                ?automationId: string,
                                                ?created: (Xamarin.Forms.ClickGestureRecognizer -> unit),
                                                ?ref: ViewRef<Xamarin.Forms.ClickGestureRecognizer>) = 

        let attribBuilder = View.BuildClickGestureRecognizer(0,
                               ?command=command,
                               ?numberOfClicksRequired=numberOfClicksRequired,
                               ?buttons=buttons,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ClickGestureRecognizer> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ClickGestureRecognizer>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ClickGestureRecognizer>(View.CreateFuncClickGestureRecognizer, View.UpdateFuncClickGestureRecognizer, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoClickGestureRecognizer : ViewElement option = None with get, set

    /// Builds the attributes for a PinchGestureRecognizer in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildPinchGestureRecognizer(attribCount: int,
                                                     ?isPinching: bool,
                                                     ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit,
                                                     ?classId: string,
                                                     ?styleId: string,
                                                     ?automationId: string,
                                                     ?created: obj -> unit,
                                                     ?ref: ViewRef) = 

        let attribCount = match isPinching with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match pinchUpdated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildElement(attribCount, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match isPinching with None -> () | Some v -> attribBuilder.Add(View._IsPinchingAttribKey, (v)) 
        match pinchUpdated with None -> () | Some v -> attribBuilder.Add(View._PinchUpdatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncPinchGestureRecognizer : (unit -> Xamarin.Forms.PinchGestureRecognizer) = (fun () -> View.CreatePinchGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreatePinchGestureRecognizer () : Xamarin.Forms.PinchGestureRecognizer = 
        upcast (new Xamarin.Forms.PinchGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncPinchGestureRecognizer = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.PinchGestureRecognizer) -> View.UpdatePinchGestureRecognizer (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdatePinchGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.PinchGestureRecognizer) = 
        // update the inherited Element element
        let baseElement = (if View.ProtoElement.IsNone then View.ProtoElement <- Some (View.Element())); View.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevIsPinchingOpt = ValueNone
        let mutable currIsPinchingOpt = ValueNone
        let mutable prevPinchUpdatedOpt = ValueNone
        let mutable currPinchUpdatedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._IsPinchingAttribKey.KeyValue then 
                currIsPinchingOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._PinchUpdatedAttribKey.KeyValue then 
                currPinchUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._IsPinchingAttribKey.KeyValue then 
                    prevIsPinchingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._PinchUpdatedAttribKey.KeyValue then 
                    prevPinchUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>)
        match prevIsPinchingOpt, currIsPinchingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsPinching <-  currValue
        | ValueSome _, ValueNone -> target.IsPinching <- false
        | ValueNone, ValueNone -> ()
        match prevPinchUpdatedOpt, currPinchUpdatedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.PinchUpdated.RemoveHandler(prevValue); target.PinchUpdated.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.PinchUpdated.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.PinchUpdated.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a PinchGestureRecognizer in the view
    static member inline PinchGestureRecognizer(?isPinching: bool,
                                                ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit,
                                                ?classId: string,
                                                ?styleId: string,
                                                ?automationId: string,
                                                ?created: (Xamarin.Forms.PinchGestureRecognizer -> unit),
                                                ?ref: ViewRef<Xamarin.Forms.PinchGestureRecognizer>) = 

        let attribBuilder = View.BuildPinchGestureRecognizer(0,
                               ?isPinching=isPinching,
                               ?pinchUpdated=pinchUpdated,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.PinchGestureRecognizer> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.PinchGestureRecognizer>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.PinchGestureRecognizer>(View.CreateFuncPinchGestureRecognizer, View.UpdateFuncPinchGestureRecognizer, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoPinchGestureRecognizer : ViewElement option = None with get, set

    /// Builds the attributes for a SwipeGestureRecognizer in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildSwipeGestureRecognizer(attribCount: int,
                                                     ?command: unit -> unit,
                                                     ?direction: Xamarin.Forms.SwipeDirection,
                                                     ?threshold: System.UInt32,
                                                     ?swiped: Xamarin.Forms.SwipedEventArgs -> unit,
                                                     ?classId: string,
                                                     ?styleId: string,
                                                     ?automationId: string,
                                                     ?created: obj -> unit,
                                                     ?ref: ViewRef) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match direction with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match threshold with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match swiped with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildElement(attribCount, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match command with None -> () | Some v -> attribBuilder.Add(View._CommandAttribKey, makeCommand(v)) 
        match direction with None -> () | Some v -> attribBuilder.Add(View._SwipeGestureRecognizerDirectionAttribKey, (v)) 
        match threshold with None -> () | Some v -> attribBuilder.Add(View._ThresholdAttribKey, (v)) 
        match swiped with None -> () | Some v -> attribBuilder.Add(View._SwipedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SwipedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncSwipeGestureRecognizer : (unit -> Xamarin.Forms.SwipeGestureRecognizer) = (fun () -> View.CreateSwipeGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateSwipeGestureRecognizer () : Xamarin.Forms.SwipeGestureRecognizer = 
        upcast (new Xamarin.Forms.SwipeGestureRecognizer())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncSwipeGestureRecognizer = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.SwipeGestureRecognizer) -> View.UpdateSwipeGestureRecognizer (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateSwipeGestureRecognizer (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.SwipeGestureRecognizer) = 
        // update the inherited Element element
        let baseElement = (if View.ProtoElement.IsNone then View.ProtoElement <- Some (View.Element())); View.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevCommandOpt = ValueNone
        let mutable currCommandOpt = ValueNone
        let mutable prevSwipeGestureRecognizerDirectionOpt = ValueNone
        let mutable currSwipeGestureRecognizerDirectionOpt = ValueNone
        let mutable prevThresholdOpt = ValueNone
        let mutable currThresholdOpt = ValueNone
        let mutable prevSwipedOpt = ValueNone
        let mutable currSwipedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._CommandAttribKey.KeyValue then 
                currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = View._SwipeGestureRecognizerDirectionAttribKey.KeyValue then 
                currSwipeGestureRecognizerDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SwipeDirection)
            if kvp.Key = View._ThresholdAttribKey.KeyValue then 
                currThresholdOpt <- ValueSome (kvp.Value :?> System.UInt32)
            if kvp.Key = View._SwipedAttribKey.KeyValue then 
                currSwipedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SwipedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._CommandAttribKey.KeyValue then 
                    prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = View._SwipeGestureRecognizerDirectionAttribKey.KeyValue then 
                    prevSwipeGestureRecognizerDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SwipeDirection)
                if kvp.Key = View._ThresholdAttribKey.KeyValue then 
                    prevThresholdOpt <- ValueSome (kvp.Value :?> System.UInt32)
                if kvp.Key = View._SwipedAttribKey.KeyValue then 
                    prevSwipedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SwipedEventArgs>)
        match prevCommandOpt, currCommandOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Command <-  currValue
        | ValueSome _, ValueNone -> target.Command <- null
        | ValueNone, ValueNone -> ()
        match prevSwipeGestureRecognizerDirectionOpt, currSwipeGestureRecognizerDirectionOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Direction <-  currValue
        | ValueSome _, ValueNone -> target.Direction <- enum<Xamarin.Forms.SwipeDirection>(0)
        | ValueNone, ValueNone -> ()
        match prevThresholdOpt, currThresholdOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Threshold <-  currValue
        | ValueSome _, ValueNone -> target.Threshold <- 100u
        | ValueNone, ValueNone -> ()
        match prevSwipedOpt, currSwipedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Swiped.RemoveHandler(prevValue); target.Swiped.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Swiped.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Swiped.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a SwipeGestureRecognizer in the view
    static member inline SwipeGestureRecognizer(?command: unit -> unit,
                                                ?direction: Xamarin.Forms.SwipeDirection,
                                                ?threshold: System.UInt32,
                                                ?swiped: Xamarin.Forms.SwipedEventArgs -> unit,
                                                ?classId: string,
                                                ?styleId: string,
                                                ?automationId: string,
                                                ?created: (Xamarin.Forms.SwipeGestureRecognizer -> unit),
                                                ?ref: ViewRef<Xamarin.Forms.SwipeGestureRecognizer>) = 

        let attribBuilder = View.BuildSwipeGestureRecognizer(0,
                               ?command=command,
                               ?direction=direction,
                               ?threshold=threshold,
                               ?swiped=swiped,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.SwipeGestureRecognizer> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.SwipeGestureRecognizer>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.SwipeGestureRecognizer>(View.CreateFuncSwipeGestureRecognizer, View.UpdateFuncSwipeGestureRecognizer, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoSwipeGestureRecognizer : ViewElement option = None with get, set

    /// Builds the attributes for a ActivityIndicator in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildActivityIndicator(attribCount: int,
                                                ?color: Xamarin.Forms.Color,
                                                ?isRunning: bool,
                                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                                ?margin: obj,
                                                ?gestureRecognizers: ViewElement list,
                                                ?anchorX: double,
                                                ?anchorY: double,
                                                ?backgroundColor: Xamarin.Forms.Color,
                                                ?heightRequest: double,
                                                ?inputTransparent: bool,
                                                ?isEnabled: bool,
                                                ?isVisible: bool,
                                                ?minimumHeightRequest: double,
                                                ?minimumWidthRequest: double,
                                                ?opacity: double,
                                                ?rotation: double,
                                                ?rotationX: double,
                                                ?rotationY: double,
                                                ?scale: double,
                                                ?style: Xamarin.Forms.Style,
                                                ?styleClass: obj,
                                                ?translationX: double,
                                                ?translationY: double,
                                                ?widthRequest: double,
                                                ?resources: (string * obj) list,
                                                ?styles: Xamarin.Forms.Style list,
                                                ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                                ?isTabStop: bool,
                                                ?scaleX: double,
                                                ?scaleY: double,
                                                ?tabIndex: int,
                                                ?classId: string,
                                                ?styleId: string,
                                                ?automationId: string,
                                                ?created: obj -> unit,
                                                ?ref: ViewRef) = 

        let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isRunning with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match color with None -> () | Some v -> attribBuilder.Add(View._ColorAttribKey, (v)) 
        match isRunning with None -> () | Some v -> attribBuilder.Add(View._IsRunningAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncActivityIndicator : (unit -> Xamarin.Forms.ActivityIndicator) = (fun () -> View.CreateActivityIndicator())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateActivityIndicator () : Xamarin.Forms.ActivityIndicator = 
        upcast (new Xamarin.Forms.ActivityIndicator())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncActivityIndicator = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ActivityIndicator) -> View.UpdateActivityIndicator (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateActivityIndicator (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ActivityIndicator) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevColorOpt = ValueNone
        let mutable currColorOpt = ValueNone
        let mutable prevIsRunningOpt = ValueNone
        let mutable currIsRunningOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ColorAttribKey.KeyValue then 
                currColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._IsRunningAttribKey.KeyValue then 
                currIsRunningOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ColorAttribKey.KeyValue then 
                    prevColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._IsRunningAttribKey.KeyValue then 
                    prevIsRunningOpt <- ValueSome (kvp.Value :?> bool)
        match prevColorOpt, currColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Color <-  currValue
        | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevIsRunningOpt, currIsRunningOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsRunning <-  currValue
        | ValueSome _, ValueNone -> target.IsRunning <- false
        | ValueNone, ValueNone -> ()

    /// Describes a ActivityIndicator in the view
    static member inline ActivityIndicator(?color: Xamarin.Forms.Color,
                                           ?isRunning: bool,
                                           ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                           ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                           ?margin: obj,
                                           ?gestureRecognizers: ViewElement list,
                                           ?anchorX: double,
                                           ?anchorY: double,
                                           ?backgroundColor: Xamarin.Forms.Color,
                                           ?heightRequest: double,
                                           ?inputTransparent: bool,
                                           ?isEnabled: bool,
                                           ?isVisible: bool,
                                           ?minimumHeightRequest: double,
                                           ?minimumWidthRequest: double,
                                           ?opacity: double,
                                           ?rotation: double,
                                           ?rotationX: double,
                                           ?rotationY: double,
                                           ?scale: double,
                                           ?style: Xamarin.Forms.Style,
                                           ?styleClass: obj,
                                           ?translationX: double,
                                           ?translationY: double,
                                           ?widthRequest: double,
                                           ?resources: (string * obj) list,
                                           ?styles: Xamarin.Forms.Style list,
                                           ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                           ?isTabStop: bool,
                                           ?scaleX: double,
                                           ?scaleY: double,
                                           ?tabIndex: int,
                                           ?classId: string,
                                           ?styleId: string,
                                           ?automationId: string,
                                           ?created: (Xamarin.Forms.ActivityIndicator -> unit),
                                           ?ref: ViewRef<Xamarin.Forms.ActivityIndicator>) = 

        let attribBuilder = View.BuildActivityIndicator(0,
                               ?color=color,
                               ?isRunning=isRunning,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ActivityIndicator> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ActivityIndicator>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ActivityIndicator>(View.CreateFuncActivityIndicator, View.UpdateFuncActivityIndicator, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoActivityIndicator : ViewElement option = None with get, set

    /// Builds the attributes for a BoxView in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildBoxView(attribCount: int,
                                      ?color: Xamarin.Forms.Color,
                                      ?cornerRadius: Xamarin.Forms.CornerRadius,
                                      ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                      ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                      ?margin: obj,
                                      ?gestureRecognizers: ViewElement list,
                                      ?anchorX: double,
                                      ?anchorY: double,
                                      ?backgroundColor: Xamarin.Forms.Color,
                                      ?heightRequest: double,
                                      ?inputTransparent: bool,
                                      ?isEnabled: bool,
                                      ?isVisible: bool,
                                      ?minimumHeightRequest: double,
                                      ?minimumWidthRequest: double,
                                      ?opacity: double,
                                      ?rotation: double,
                                      ?rotationX: double,
                                      ?rotationY: double,
                                      ?scale: double,
                                      ?style: Xamarin.Forms.Style,
                                      ?styleClass: obj,
                                      ?translationX: double,
                                      ?translationY: double,
                                      ?widthRequest: double,
                                      ?resources: (string * obj) list,
                                      ?styles: Xamarin.Forms.Style list,
                                      ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                      ?isTabStop: bool,
                                      ?scaleX: double,
                                      ?scaleY: double,
                                      ?tabIndex: int,
                                      ?classId: string,
                                      ?styleId: string,
                                      ?automationId: string,
                                      ?created: obj -> unit,
                                      ?ref: ViewRef) = 

        let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match color with None -> () | Some v -> attribBuilder.Add(View._ColorAttribKey, (v)) 
        match cornerRadius with None -> () | Some v -> attribBuilder.Add(View._BoxViewCornerRadiusAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncBoxView : (unit -> Xamarin.Forms.BoxView) = (fun () -> View.CreateBoxView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateBoxView () : Xamarin.Forms.BoxView = 
        upcast (new Xamarin.Forms.BoxView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncBoxView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.BoxView) -> View.UpdateBoxView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateBoxView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.BoxView) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevColorOpt = ValueNone
        let mutable currColorOpt = ValueNone
        let mutable prevBoxViewCornerRadiusOpt = ValueNone
        let mutable currBoxViewCornerRadiusOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ColorAttribKey.KeyValue then 
                currColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._BoxViewCornerRadiusAttribKey.KeyValue then 
                currBoxViewCornerRadiusOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.CornerRadius)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ColorAttribKey.KeyValue then 
                    prevColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._BoxViewCornerRadiusAttribKey.KeyValue then 
                    prevBoxViewCornerRadiusOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.CornerRadius)
        match prevColorOpt, currColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Color <-  currValue
        | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevBoxViewCornerRadiusOpt, currBoxViewCornerRadiusOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CornerRadius <-  currValue
        | ValueSome _, ValueNone -> target.CornerRadius <- Unchecked.defaultof<Xamarin.Forms.CornerRadius>
        | ValueNone, ValueNone -> ()

    /// Describes a BoxView in the view
    static member inline BoxView(?color: Xamarin.Forms.Color,
                                 ?cornerRadius: Xamarin.Forms.CornerRadius,
                                 ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                 ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                 ?margin: obj,
                                 ?gestureRecognizers: ViewElement list,
                                 ?anchorX: double,
                                 ?anchorY: double,
                                 ?backgroundColor: Xamarin.Forms.Color,
                                 ?heightRequest: double,
                                 ?inputTransparent: bool,
                                 ?isEnabled: bool,
                                 ?isVisible: bool,
                                 ?minimumHeightRequest: double,
                                 ?minimumWidthRequest: double,
                                 ?opacity: double,
                                 ?rotation: double,
                                 ?rotationX: double,
                                 ?rotationY: double,
                                 ?scale: double,
                                 ?style: Xamarin.Forms.Style,
                                 ?styleClass: obj,
                                 ?translationX: double,
                                 ?translationY: double,
                                 ?widthRequest: double,
                                 ?resources: (string * obj) list,
                                 ?styles: Xamarin.Forms.Style list,
                                 ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                 ?isTabStop: bool,
                                 ?scaleX: double,
                                 ?scaleY: double,
                                 ?tabIndex: int,
                                 ?classId: string,
                                 ?styleId: string,
                                 ?automationId: string,
                                 ?created: (Xamarin.Forms.BoxView -> unit),
                                 ?ref: ViewRef<Xamarin.Forms.BoxView>) = 

        let attribBuilder = View.BuildBoxView(0,
                               ?color=color,
                               ?cornerRadius=cornerRadius,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.BoxView> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.BoxView>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.BoxView>(View.CreateFuncBoxView, View.UpdateFuncBoxView, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoBoxView : ViewElement option = None with get, set

    /// Builds the attributes for a ProgressBar in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildProgressBar(attribCount: int,
                                          ?progress: double,
                                          ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                          ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                          ?margin: obj,
                                          ?gestureRecognizers: ViewElement list,
                                          ?anchorX: double,
                                          ?anchorY: double,
                                          ?backgroundColor: Xamarin.Forms.Color,
                                          ?heightRequest: double,
                                          ?inputTransparent: bool,
                                          ?isEnabled: bool,
                                          ?isVisible: bool,
                                          ?minimumHeightRequest: double,
                                          ?minimumWidthRequest: double,
                                          ?opacity: double,
                                          ?rotation: double,
                                          ?rotationX: double,
                                          ?rotationY: double,
                                          ?scale: double,
                                          ?style: Xamarin.Forms.Style,
                                          ?styleClass: obj,
                                          ?translationX: double,
                                          ?translationY: double,
                                          ?widthRequest: double,
                                          ?resources: (string * obj) list,
                                          ?styles: Xamarin.Forms.Style list,
                                          ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                          ?isTabStop: bool,
                                          ?scaleX: double,
                                          ?scaleY: double,
                                          ?tabIndex: int,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?automationId: string,
                                          ?created: obj -> unit,
                                          ?ref: ViewRef) = 

        let attribCount = match progress with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match progress with None -> () | Some v -> attribBuilder.Add(View._ProgressAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncProgressBar : (unit -> Xamarin.Forms.ProgressBar) = (fun () -> View.CreateProgressBar())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateProgressBar () : Xamarin.Forms.ProgressBar = 
        upcast (new Xamarin.Forms.ProgressBar())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncProgressBar = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ProgressBar) -> View.UpdateProgressBar (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateProgressBar (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ProgressBar) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevProgressOpt = ValueNone
        let mutable currProgressOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ProgressAttribKey.KeyValue then 
                currProgressOpt <- ValueSome (kvp.Value :?> double)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ProgressAttribKey.KeyValue then 
                    prevProgressOpt <- ValueSome (kvp.Value :?> double)
        match prevProgressOpt, currProgressOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Progress <-  currValue
        | ValueSome _, ValueNone -> target.Progress <- 0.0
        | ValueNone, ValueNone -> ()

    /// Describes a ProgressBar in the view
    static member inline ProgressBar(?progress: double,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: (Xamarin.Forms.ProgressBar -> unit),
                                     ?ref: ViewRef<Xamarin.Forms.ProgressBar>) = 

        let attribBuilder = View.BuildProgressBar(0,
                               ?progress=progress,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ProgressBar> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ProgressBar>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ProgressBar>(View.CreateFuncProgressBar, View.UpdateFuncProgressBar, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoProgressBar : ViewElement option = None with get, set

    /// Builds the attributes for a Layout in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildLayout(attribCount: int,
                                     ?isClippedToBounds: bool,
                                     ?padding: obj,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: obj -> unit,
                                     ?ref: ViewRef) = 

        let attribCount = match isClippedToBounds with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match isClippedToBounds with None -> () | Some v -> attribBuilder.Add(View._IsClippedToBoundsAttribKey, (v)) 
        match padding with None -> () | Some v -> attribBuilder.Add(View._PaddingAttribKey, makeThickness(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncLayout : (unit -> Xamarin.Forms.Layout) = (fun () -> View.CreateLayout())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateLayout () : Xamarin.Forms.Layout = 
        failwith "can't create Xamarin.Forms.Layout"

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncLayout = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Layout) -> View.UpdateLayout (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateLayout (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Layout) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevIsClippedToBoundsOpt = ValueNone
        let mutable currIsClippedToBoundsOpt = ValueNone
        let mutable prevPaddingOpt = ValueNone
        let mutable currPaddingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._IsClippedToBoundsAttribKey.KeyValue then 
                currIsClippedToBoundsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._PaddingAttribKey.KeyValue then 
                currPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._IsClippedToBoundsAttribKey.KeyValue then 
                    prevIsClippedToBoundsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._PaddingAttribKey.KeyValue then 
                    prevPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
        match prevIsClippedToBoundsOpt, currIsClippedToBoundsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsClippedToBounds <-  currValue
        | ValueSome _, ValueNone -> target.IsClippedToBounds <- false
        | ValueNone, ValueNone -> ()
        match prevPaddingOpt, currPaddingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Padding <-  currValue
        | ValueSome _, ValueNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
        | ValueNone, ValueNone -> ()

    /// Describes a Layout in the view
    static member inline Layout(?isClippedToBounds: bool,
                                ?padding: obj,
                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                ?margin: obj,
                                ?gestureRecognizers: ViewElement list,
                                ?anchorX: double,
                                ?anchorY: double,
                                ?backgroundColor: Xamarin.Forms.Color,
                                ?heightRequest: double,
                                ?inputTransparent: bool,
                                ?isEnabled: bool,
                                ?isVisible: bool,
                                ?minimumHeightRequest: double,
                                ?minimumWidthRequest: double,
                                ?opacity: double,
                                ?rotation: double,
                                ?rotationX: double,
                                ?rotationY: double,
                                ?scale: double,
                                ?style: Xamarin.Forms.Style,
                                ?styleClass: obj,
                                ?translationX: double,
                                ?translationY: double,
                                ?widthRequest: double,
                                ?resources: (string * obj) list,
                                ?styles: Xamarin.Forms.Style list,
                                ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                ?isTabStop: bool,
                                ?scaleX: double,
                                ?scaleY: double,
                                ?tabIndex: int,
                                ?classId: string,
                                ?styleId: string,
                                ?automationId: string,
                                ?created: (Xamarin.Forms.Layout -> unit),
                                ?ref: ViewRef<Xamarin.Forms.Layout>) = 

        let attribBuilder = View.BuildLayout(0,
                               ?isClippedToBounds=isClippedToBounds,
                               ?padding=padding,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Layout> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Layout>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Layout>(View.CreateFuncLayout, View.UpdateFuncLayout, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoLayout : ViewElement option = None with get, set

    /// Builds the attributes for a ScrollView in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildScrollView(attribCount: int,
                                         ?content: ViewElement,
                                         ?orientation: Xamarin.Forms.ScrollOrientation,
                                         ?horizontalScrollBarVisibility: Xamarin.Forms.ScrollBarVisibility,
                                         ?verticalScrollBarVisibility: Xamarin.Forms.ScrollBarVisibility,
                                         ?isClippedToBounds: bool,
                                         ?padding: obj,
                                         ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                         ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                         ?margin: obj,
                                         ?gestureRecognizers: ViewElement list,
                                         ?anchorX: double,
                                         ?anchorY: double,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?heightRequest: double,
                                         ?inputTransparent: bool,
                                         ?isEnabled: bool,
                                         ?isVisible: bool,
                                         ?minimumHeightRequest: double,
                                         ?minimumWidthRequest: double,
                                         ?opacity: double,
                                         ?rotation: double,
                                         ?rotationX: double,
                                         ?rotationY: double,
                                         ?scale: double,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: obj,
                                         ?translationX: double,
                                         ?translationY: double,
                                         ?widthRequest: double,
                                         ?resources: (string * obj) list,
                                         ?styles: Xamarin.Forms.Style list,
                                         ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                         ?isTabStop: bool,
                                         ?scaleX: double,
                                         ?scaleY: double,
                                         ?tabIndex: int,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?automationId: string,
                                         ?created: obj -> unit,
                                         ?ref: ViewRef) = 

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match orientation with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match horizontalScrollBarVisibility with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match verticalScrollBarVisibility with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match content with None -> () | Some v -> attribBuilder.Add(View._ContentAttribKey, (v)) 
        match orientation with None -> () | Some v -> attribBuilder.Add(View._ScrollOrientationAttribKey, (v)) 
        match horizontalScrollBarVisibility with None -> () | Some v -> attribBuilder.Add(View._HorizontalScrollBarVisibilityAttribKey, (v)) 
        match verticalScrollBarVisibility with None -> () | Some v -> attribBuilder.Add(View._VerticalScrollBarVisibilityAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncScrollView : (unit -> Xamarin.Forms.ScrollView) = (fun () -> View.CreateScrollView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateScrollView () : Xamarin.Forms.ScrollView = 
        upcast (new Xamarin.Forms.ScrollView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncScrollView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ScrollView) -> View.UpdateScrollView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateScrollView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ScrollView) = 
        // update the inherited Layout element
        let baseElement = (if View.ProtoLayout.IsNone then View.ProtoLayout <- Some (View.Layout())); View.ProtoLayout.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevContentOpt = ValueNone
        let mutable currContentOpt = ValueNone
        let mutable prevScrollOrientationOpt = ValueNone
        let mutable currScrollOrientationOpt = ValueNone
        let mutable prevHorizontalScrollBarVisibilityOpt = ValueNone
        let mutable currHorizontalScrollBarVisibilityOpt = ValueNone
        let mutable prevVerticalScrollBarVisibilityOpt = ValueNone
        let mutable currVerticalScrollBarVisibilityOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ContentAttribKey.KeyValue then 
                currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = View._ScrollOrientationAttribKey.KeyValue then 
                currScrollOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollOrientation)
            if kvp.Key = View._HorizontalScrollBarVisibilityAttribKey.KeyValue then 
                currHorizontalScrollBarVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollBarVisibility)
            if kvp.Key = View._VerticalScrollBarVisibilityAttribKey.KeyValue then 
                currVerticalScrollBarVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollBarVisibility)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ContentAttribKey.KeyValue then 
                    prevContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = View._ScrollOrientationAttribKey.KeyValue then 
                    prevScrollOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollOrientation)
                if kvp.Key = View._HorizontalScrollBarVisibilityAttribKey.KeyValue then 
                    prevHorizontalScrollBarVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollBarVisibility)
                if kvp.Key = View._VerticalScrollBarVisibilityAttribKey.KeyValue then 
                    prevVerticalScrollBarVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollBarVisibility)
        match prevContentOpt, currContentOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.Content)
        | _, ValueSome newValue ->
            target.Content <- (newValue.Create() :?> Xamarin.Forms.View)
        | ValueSome _, ValueNone ->
            target.Content <- null
        | ValueNone, ValueNone -> ()
        match prevScrollOrientationOpt, currScrollOrientationOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Orientation <-  currValue
        | ValueSome _, ValueNone -> target.Orientation <- Unchecked.defaultof<Xamarin.Forms.ScrollOrientation>
        | ValueNone, ValueNone -> ()
        match prevHorizontalScrollBarVisibilityOpt, currHorizontalScrollBarVisibilityOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HorizontalScrollBarVisibility <-  currValue
        | ValueSome _, ValueNone -> target.HorizontalScrollBarVisibility <- Xamarin.Forms.ScrollBarVisibility.Default
        | ValueNone, ValueNone -> ()
        match prevVerticalScrollBarVisibilityOpt, currVerticalScrollBarVisibilityOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.VerticalScrollBarVisibility <-  currValue
        | ValueSome _, ValueNone -> target.VerticalScrollBarVisibility <- Xamarin.Forms.ScrollBarVisibility.Default
        | ValueNone, ValueNone -> ()

    /// Describes a ScrollView in the view
    static member inline ScrollView(?content: ViewElement,
                                    ?orientation: Xamarin.Forms.ScrollOrientation,
                                    ?horizontalScrollBarVisibility: Xamarin.Forms.ScrollBarVisibility,
                                    ?verticalScrollBarVisibility: Xamarin.Forms.ScrollBarVisibility,
                                    ?isClippedToBounds: bool,
                                    ?padding: obj,
                                    ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                    ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                    ?margin: obj,
                                    ?gestureRecognizers: ViewElement list,
                                    ?anchorX: double,
                                    ?anchorY: double,
                                    ?backgroundColor: Xamarin.Forms.Color,
                                    ?heightRequest: double,
                                    ?inputTransparent: bool,
                                    ?isEnabled: bool,
                                    ?isVisible: bool,
                                    ?minimumHeightRequest: double,
                                    ?minimumWidthRequest: double,
                                    ?opacity: double,
                                    ?rotation: double,
                                    ?rotationX: double,
                                    ?rotationY: double,
                                    ?scale: double,
                                    ?style: Xamarin.Forms.Style,
                                    ?styleClass: obj,
                                    ?translationX: double,
                                    ?translationY: double,
                                    ?widthRequest: double,
                                    ?resources: (string * obj) list,
                                    ?styles: Xamarin.Forms.Style list,
                                    ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                    ?isTabStop: bool,
                                    ?scaleX: double,
                                    ?scaleY: double,
                                    ?tabIndex: int,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?automationId: string,
                                    ?created: (Xamarin.Forms.ScrollView -> unit),
                                    ?ref: ViewRef<Xamarin.Forms.ScrollView>) = 

        let attribBuilder = View.BuildScrollView(0,
                               ?content=content,
                               ?orientation=orientation,
                               ?horizontalScrollBarVisibility=horizontalScrollBarVisibility,
                               ?verticalScrollBarVisibility=verticalScrollBarVisibility,
                               ?isClippedToBounds=isClippedToBounds,
                               ?padding=padding,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ScrollView> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ScrollView>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ScrollView>(View.CreateFuncScrollView, View.UpdateFuncScrollView, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoScrollView : ViewElement option = None with get, set

    /// Builds the attributes for a SearchBar in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildSearchBar(attribCount: int,
                                        ?cancelButtonColor: Xamarin.Forms.Color,
                                        ?fontFamily: string,
                                        ?fontAttributes: Xamarin.Forms.FontAttributes,
                                        ?fontSize: obj,
                                        ?horizontalTextAlignment: Xamarin.Forms.TextAlignment,
                                        ?placeholder: string,
                                        ?placeholderColor: Xamarin.Forms.Color,
                                        ?searchCommand: string -> unit,
                                        ?canExecute: bool,
                                        ?text: string,
                                        ?textColor: Xamarin.Forms.Color,
                                        ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit,
                                        ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                        ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                        ?margin: obj,
                                        ?gestureRecognizers: ViewElement list,
                                        ?anchorX: double,
                                        ?anchorY: double,
                                        ?backgroundColor: Xamarin.Forms.Color,
                                        ?heightRequest: double,
                                        ?inputTransparent: bool,
                                        ?isEnabled: bool,
                                        ?isVisible: bool,
                                        ?minimumHeightRequest: double,
                                        ?minimumWidthRequest: double,
                                        ?opacity: double,
                                        ?rotation: double,
                                        ?rotationX: double,
                                        ?rotationY: double,
                                        ?scale: double,
                                        ?style: Xamarin.Forms.Style,
                                        ?styleClass: obj,
                                        ?translationX: double,
                                        ?translationY: double,
                                        ?widthRequest: double,
                                        ?resources: (string * obj) list,
                                        ?styles: Xamarin.Forms.Style list,
                                        ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                        ?isTabStop: bool,
                                        ?scaleX: double,
                                        ?scaleY: double,
                                        ?tabIndex: int,
                                        ?classId: string,
                                        ?styleId: string,
                                        ?automationId: string,
                                        ?created: obj -> unit,
                                        ?ref: ViewRef) = 

        let attribCount = match cancelButtonColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontAttributes with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match horizontalTextAlignment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match placeholder with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match placeholderColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match searchCommand with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match canExecute with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match cancelButtonColor with None -> () | Some v -> attribBuilder.Add(View._CancelButtonColorAttribKey, (v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(View._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(View._FontAttributesAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(View._FontSizeAttribKey, makeFontSize(v)) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.Add(View._HorizontalTextAlignmentAttribKey, (v)) 
        match placeholder with None -> () | Some v -> attribBuilder.Add(View._PlaceholderAttribKey, (v)) 
        match placeholderColor with None -> () | Some v -> attribBuilder.Add(View._PlaceholderColorAttribKey, (v)) 
        match searchCommand with None -> () | Some v -> attribBuilder.Add(View._SearchBarCommandAttribKey, (v)) 
        match canExecute with None -> () | Some v -> attribBuilder.Add(View._SearchBarCanExecuteAttribKey, (v)) 
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(View._TextColorAttribKey, (v)) 
        match textChanged with None -> () | Some v -> attribBuilder.Add(View._SearchBarTextChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncSearchBar : (unit -> Xamarin.Forms.SearchBar) = (fun () -> View.CreateSearchBar())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateSearchBar () : Xamarin.Forms.SearchBar = 
        upcast (new Xamarin.Forms.SearchBar())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncSearchBar = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.SearchBar) -> View.UpdateSearchBar (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateSearchBar (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.SearchBar) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevCancelButtonColorOpt = ValueNone
        let mutable currCancelButtonColorOpt = ValueNone
        let mutable prevFontFamilyOpt = ValueNone
        let mutable currFontFamilyOpt = ValueNone
        let mutable prevFontAttributesOpt = ValueNone
        let mutable currFontAttributesOpt = ValueNone
        let mutable prevFontSizeOpt = ValueNone
        let mutable currFontSizeOpt = ValueNone
        let mutable prevHorizontalTextAlignmentOpt = ValueNone
        let mutable currHorizontalTextAlignmentOpt = ValueNone
        let mutable prevPlaceholderOpt = ValueNone
        let mutable currPlaceholderOpt = ValueNone
        let mutable prevPlaceholderColorOpt = ValueNone
        let mutable currPlaceholderColorOpt = ValueNone
        let mutable prevSearchBarCommandOpt = ValueNone
        let mutable currSearchBarCommandOpt = ValueNone
        let mutable prevSearchBarCanExecuteOpt = ValueNone
        let mutable currSearchBarCanExecuteOpt = ValueNone
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevTextColorOpt = ValueNone
        let mutable currTextColorOpt = ValueNone
        let mutable prevSearchBarTextChangedOpt = ValueNone
        let mutable currSearchBarTextChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._CancelButtonColorAttribKey.KeyValue then 
                currCancelButtonColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._HorizontalTextAlignmentAttribKey.KeyValue then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = View._PlaceholderAttribKey.KeyValue then 
                currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._PlaceholderColorAttribKey.KeyValue then 
                currPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._SearchBarCommandAttribKey.KeyValue then 
                currSearchBarCommandOpt <- ValueSome (kvp.Value :?> string -> unit)
            if kvp.Key = View._SearchBarCanExecuteAttribKey.KeyValue then 
                currSearchBarCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._SearchBarTextChangedAttribKey.KeyValue then 
                currSearchBarTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._CancelButtonColorAttribKey.KeyValue then 
                    prevCancelButtonColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._HorizontalTextAlignmentAttribKey.KeyValue then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = View._PlaceholderAttribKey.KeyValue then 
                    prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._PlaceholderColorAttribKey.KeyValue then 
                    prevPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._SearchBarCommandAttribKey.KeyValue then 
                    prevSearchBarCommandOpt <- ValueSome (kvp.Value :?> string -> unit)
                if kvp.Key = View._SearchBarCanExecuteAttribKey.KeyValue then 
                    prevSearchBarCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._SearchBarTextChangedAttribKey.KeyValue then 
                    prevSearchBarTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
        match prevCancelButtonColorOpt, currCancelButtonColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CancelButtonColor <-  currValue
        | ValueSome _, ValueNone -> target.CancelButtonColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevFontFamilyOpt, currFontFamilyOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontFamily <-  currValue
        | ValueSome _, ValueNone -> target.FontFamily <- null
        | ValueNone, ValueNone -> ()
        match prevFontAttributesOpt, currFontAttributesOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontAttributes <-  currValue
        | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
        | ValueNone, ValueNone -> ()
        match prevFontSizeOpt, currFontSizeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontSize <-  currValue
        | ValueSome _, ValueNone -> target.FontSize <- -1.0
        | ValueNone, ValueNone -> ()
        match prevHorizontalTextAlignmentOpt, currHorizontalTextAlignmentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HorizontalTextAlignment <-  currValue
        | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
        | ValueNone, ValueNone -> ()
        match prevPlaceholderOpt, currPlaceholderOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Placeholder <-  currValue
        | ValueSome _, ValueNone -> target.Placeholder <- null
        | ValueNone, ValueNone -> ()
        match prevPlaceholderColorOpt, currPlaceholderColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.PlaceholderColor <-  currValue
        | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        (fun _ _ _ -> ()) prevSearchBarCommandOpt currSearchBarCommandOpt target
        updateCommand prevSearchBarCommandOpt currSearchBarCommandOpt (fun (target: Xamarin.Forms.SearchBar) -> target.Text) (fun (target: Xamarin.Forms.SearchBar) cmd -> target.SearchCommand <- cmd) prevSearchBarCanExecuteOpt currSearchBarCanExecuteOpt target
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevTextColorOpt, currTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextColor <-  currValue
        | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevSearchBarTextChangedOpt, currSearchBarTextChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.TextChanged.RemoveHandler(prevValue); target.TextChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.TextChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.TextChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a SearchBar in the view
    static member inline SearchBar(?cancelButtonColor: Xamarin.Forms.Color,
                                   ?fontFamily: string,
                                   ?fontAttributes: Xamarin.Forms.FontAttributes,
                                   ?fontSize: obj,
                                   ?horizontalTextAlignment: Xamarin.Forms.TextAlignment,
                                   ?placeholder: string,
                                   ?placeholderColor: Xamarin.Forms.Color,
                                   ?searchCommand: string -> unit,
                                   ?canExecute: bool,
                                   ?text: string,
                                   ?textColor: Xamarin.Forms.Color,
                                   ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit,
                                   ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                   ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                   ?margin: obj,
                                   ?gestureRecognizers: ViewElement list,
                                   ?anchorX: double,
                                   ?anchorY: double,
                                   ?backgroundColor: Xamarin.Forms.Color,
                                   ?heightRequest: double,
                                   ?inputTransparent: bool,
                                   ?isEnabled: bool,
                                   ?isVisible: bool,
                                   ?minimumHeightRequest: double,
                                   ?minimumWidthRequest: double,
                                   ?opacity: double,
                                   ?rotation: double,
                                   ?rotationX: double,
                                   ?rotationY: double,
                                   ?scale: double,
                                   ?style: Xamarin.Forms.Style,
                                   ?styleClass: obj,
                                   ?translationX: double,
                                   ?translationY: double,
                                   ?widthRequest: double,
                                   ?resources: (string * obj) list,
                                   ?styles: Xamarin.Forms.Style list,
                                   ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                   ?isTabStop: bool,
                                   ?scaleX: double,
                                   ?scaleY: double,
                                   ?tabIndex: int,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?automationId: string,
                                   ?created: (Xamarin.Forms.SearchBar -> unit),
                                   ?ref: ViewRef<Xamarin.Forms.SearchBar>) = 

        let attribBuilder = View.BuildSearchBar(0,
                               ?cancelButtonColor=cancelButtonColor,
                               ?fontFamily=fontFamily,
                               ?fontAttributes=fontAttributes,
                               ?fontSize=fontSize,
                               ?horizontalTextAlignment=horizontalTextAlignment,
                               ?placeholder=placeholder,
                               ?placeholderColor=placeholderColor,
                               ?searchCommand=searchCommand,
                               ?canExecute=canExecute,
                               ?text=text,
                               ?textColor=textColor,
                               ?textChanged=textChanged,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.SearchBar> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.SearchBar>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.SearchBar>(View.CreateFuncSearchBar, View.UpdateFuncSearchBar, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoSearchBar : ViewElement option = None with get, set

    /// Builds the attributes for a Button in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildButton(attribCount: int,
                                     ?text: string,
                                     ?command: unit -> unit,
                                     ?canExecute: bool,
                                     ?borderColor: Xamarin.Forms.Color,
                                     ?borderWidth: double,
                                     ?commandParameter: System.Object,
                                     ?contentLayout: Xamarin.Forms.Button.ButtonContentLayout,
                                     ?cornerRadius: int,
                                     ?fontFamily: string,
                                     ?fontAttributes: Xamarin.Forms.FontAttributes,
                                     ?fontSize: obj,
                                     ?image: string,
                                     ?textColor: Xamarin.Forms.Color,
                                     ?padding: Xamarin.Forms.Thickness,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: obj -> unit,
                                     ?ref: ViewRef) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match canExecute with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match borderColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match borderWidth with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match commandParameter with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match contentLayout with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontAttributes with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match image with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        match command with None -> () | Some v -> attribBuilder.Add(View._ButtonCommandAttribKey, (v)) 
        match canExecute with None -> () | Some v -> attribBuilder.Add(View._ButtonCanExecuteAttribKey, (v)) 
        match borderColor with None -> () | Some v -> attribBuilder.Add(View._BorderColorAttribKey, (v)) 
        match borderWidth with None -> () | Some v -> attribBuilder.Add(View._BorderWidthAttribKey, (v)) 
        match commandParameter with None -> () | Some v -> attribBuilder.Add(View._CommandParameterAttribKey, (v)) 
        match contentLayout with None -> () | Some v -> attribBuilder.Add(View._ContentLayoutAttribKey, (v)) 
        match cornerRadius with None -> () | Some v -> attribBuilder.Add(View._ButtonCornerRadiusAttribKey, (v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(View._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(View._FontAttributesAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(View._FontSizeAttribKey, makeFontSize(v)) 
        match image with None -> () | Some v -> attribBuilder.Add(View._ButtonImageSourceAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(View._TextColorAttribKey, (v)) 
        match padding with None -> () | Some v -> attribBuilder.Add(View._PaddingAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncButton : (unit -> Xamarin.Forms.Button) = (fun () -> View.CreateButton())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateButton () : Xamarin.Forms.Button = 
        upcast (new Xamarin.Forms.Button())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncButton = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Button) -> View.UpdateButton (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateButton (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Button) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevButtonCommandOpt = ValueNone
        let mutable currButtonCommandOpt = ValueNone
        let mutable prevButtonCanExecuteOpt = ValueNone
        let mutable currButtonCanExecuteOpt = ValueNone
        let mutable prevBorderColorOpt = ValueNone
        let mutable currBorderColorOpt = ValueNone
        let mutable prevBorderWidthOpt = ValueNone
        let mutable currBorderWidthOpt = ValueNone
        let mutable prevCommandParameterOpt = ValueNone
        let mutable currCommandParameterOpt = ValueNone
        let mutable prevContentLayoutOpt = ValueNone
        let mutable currContentLayoutOpt = ValueNone
        let mutable prevButtonCornerRadiusOpt = ValueNone
        let mutable currButtonCornerRadiusOpt = ValueNone
        let mutable prevFontFamilyOpt = ValueNone
        let mutable currFontFamilyOpt = ValueNone
        let mutable prevFontAttributesOpt = ValueNone
        let mutable currFontAttributesOpt = ValueNone
        let mutable prevFontSizeOpt = ValueNone
        let mutable currFontSizeOpt = ValueNone
        let mutable prevButtonImageSourceOpt = ValueNone
        let mutable currButtonImageSourceOpt = ValueNone
        let mutable prevTextColorOpt = ValueNone
        let mutable currTextColorOpt = ValueNone
        let mutable prevPaddingOpt = ValueNone
        let mutable currPaddingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._ButtonCommandAttribKey.KeyValue then 
                currButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
            if kvp.Key = View._ButtonCanExecuteAttribKey.KeyValue then 
                currButtonCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._BorderColorAttribKey.KeyValue then 
                currBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._BorderWidthAttribKey.KeyValue then 
                currBorderWidthOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._CommandParameterAttribKey.KeyValue then 
                currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = View._ContentLayoutAttribKey.KeyValue then 
                currContentLayoutOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Button.ButtonContentLayout)
            if kvp.Key = View._ButtonCornerRadiusAttribKey.KeyValue then 
                currButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._ButtonImageSourceAttribKey.KeyValue then 
                currButtonImageSourceOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._PaddingAttribKey.KeyValue then 
                currPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._ButtonCommandAttribKey.KeyValue then 
                    prevButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = View._ButtonCanExecuteAttribKey.KeyValue then 
                    prevButtonCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._BorderColorAttribKey.KeyValue then 
                    prevBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._BorderWidthAttribKey.KeyValue then 
                    prevBorderWidthOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._CommandParameterAttribKey.KeyValue then 
                    prevCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = View._ContentLayoutAttribKey.KeyValue then 
                    prevContentLayoutOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Button.ButtonContentLayout)
                if kvp.Key = View._ButtonCornerRadiusAttribKey.KeyValue then 
                    prevButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._ButtonImageSourceAttribKey.KeyValue then 
                    prevButtonImageSourceOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._PaddingAttribKey.KeyValue then 
                    prevPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        (fun _ _ _ -> ()) prevButtonCommandOpt currButtonCommandOpt target
        updateCommand prevButtonCommandOpt currButtonCommandOpt (fun _target -> ()) (fun (target: Xamarin.Forms.Button) cmd -> target.Command <- cmd) prevButtonCanExecuteOpt currButtonCanExecuteOpt target
        match prevBorderColorOpt, currBorderColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BorderColor <-  currValue
        | ValueSome _, ValueNone -> target.BorderColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevBorderWidthOpt, currBorderWidthOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BorderWidth <-  currValue
        | ValueSome _, ValueNone -> target.BorderWidth <- -1.0
        | ValueNone, ValueNone -> ()
        match prevCommandParameterOpt, currCommandParameterOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CommandParameter <-  currValue
        | ValueSome _, ValueNone -> target.CommandParameter <- null
        | ValueNone, ValueNone -> ()
        match prevContentLayoutOpt, currContentLayoutOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ContentLayout <-  currValue
        | ValueSome _, ValueNone -> target.ContentLayout <- null
        | ValueNone, ValueNone -> ()
        match prevButtonCornerRadiusOpt, currButtonCornerRadiusOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CornerRadius <-  currValue
        | ValueSome _, ValueNone -> target.CornerRadius <- 0
        | ValueNone, ValueNone -> ()
        match prevFontFamilyOpt, currFontFamilyOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontFamily <-  currValue
        | ValueSome _, ValueNone -> target.FontFamily <- null
        | ValueNone, ValueNone -> ()
        match prevFontAttributesOpt, currFontAttributesOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontAttributes <-  currValue
        | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
        | ValueNone, ValueNone -> ()
        match prevFontSizeOpt, currFontSizeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontSize <-  currValue
        | ValueSome _, ValueNone -> target.FontSize <- -1.0
        | ValueNone, ValueNone -> ()
        match prevButtonImageSourceOpt, currButtonImageSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Image <- makeFileImageSource currValue
        | ValueSome _, ValueNone -> target.Image <- null
        | ValueNone, ValueNone -> ()
        match prevTextColorOpt, currTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextColor <-  currValue
        | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevPaddingOpt, currPaddingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Padding <-  currValue
        | ValueSome _, ValueNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
        | ValueNone, ValueNone -> ()

    /// Describes a Button in the view
    static member inline Button(?text: string,
                                ?command: unit -> unit,
                                ?canExecute: bool,
                                ?borderColor: Xamarin.Forms.Color,
                                ?borderWidth: double,
                                ?commandParameter: System.Object,
                                ?contentLayout: Xamarin.Forms.Button.ButtonContentLayout,
                                ?cornerRadius: int,
                                ?fontFamily: string,
                                ?fontAttributes: Xamarin.Forms.FontAttributes,
                                ?fontSize: obj,
                                ?image: string,
                                ?textColor: Xamarin.Forms.Color,
                                ?padding: Xamarin.Forms.Thickness,
                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                ?margin: obj,
                                ?gestureRecognizers: ViewElement list,
                                ?anchorX: double,
                                ?anchorY: double,
                                ?backgroundColor: Xamarin.Forms.Color,
                                ?heightRequest: double,
                                ?inputTransparent: bool,
                                ?isEnabled: bool,
                                ?isVisible: bool,
                                ?minimumHeightRequest: double,
                                ?minimumWidthRequest: double,
                                ?opacity: double,
                                ?rotation: double,
                                ?rotationX: double,
                                ?rotationY: double,
                                ?scale: double,
                                ?style: Xamarin.Forms.Style,
                                ?styleClass: obj,
                                ?translationX: double,
                                ?translationY: double,
                                ?widthRequest: double,
                                ?resources: (string * obj) list,
                                ?styles: Xamarin.Forms.Style list,
                                ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                ?isTabStop: bool,
                                ?scaleX: double,
                                ?scaleY: double,
                                ?tabIndex: int,
                                ?classId: string,
                                ?styleId: string,
                                ?automationId: string,
                                ?created: (Xamarin.Forms.Button -> unit),
                                ?ref: ViewRef<Xamarin.Forms.Button>) = 

        let attribBuilder = View.BuildButton(0,
                               ?text=text,
                               ?command=command,
                               ?canExecute=canExecute,
                               ?borderColor=borderColor,
                               ?borderWidth=borderWidth,
                               ?commandParameter=commandParameter,
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
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Button> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Button>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Button>(View.CreateFuncButton, View.UpdateFuncButton, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoButton : ViewElement option = None with get, set

    /// Builds the attributes for a Slider in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildSlider(attribCount: int,
                                     ?minimumMaximum: float * float,
                                     ?value: double,
                                     ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: obj -> unit,
                                     ?ref: ViewRef) = 

        let attribCount = match minimumMaximum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match value with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match valueChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match minimumMaximum with None -> () | Some v -> attribBuilder.Add(View._MinimumMaximumAttribKey, (v)) 
        match value with None -> () | Some v -> attribBuilder.Add(View._ValueAttribKey, (v)) 
        match valueChanged with None -> () | Some v -> attribBuilder.Add(View._ValueChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncSlider : (unit -> Xamarin.Forms.Slider) = (fun () -> View.CreateSlider())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateSlider () : Xamarin.Forms.Slider = 
        upcast (new Xamarin.Forms.Slider())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncSlider = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Slider) -> View.UpdateSlider (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateSlider (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Slider) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevMinimumMaximumOpt = ValueNone
        let mutable currMinimumMaximumOpt = ValueNone
        let mutable prevValueOpt = ValueNone
        let mutable currValueOpt = ValueNone
        let mutable prevValueChangedOpt = ValueNone
        let mutable currValueChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._MinimumMaximumAttribKey.KeyValue then 
                currMinimumMaximumOpt <- ValueSome (kvp.Value :?> float * float)
            if kvp.Key = View._ValueAttribKey.KeyValue then 
                currValueOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._ValueChangedAttribKey.KeyValue then 
                currValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._MinimumMaximumAttribKey.KeyValue then 
                    prevMinimumMaximumOpt <- ValueSome (kvp.Value :?> float * float)
                if kvp.Key = View._ValueAttribKey.KeyValue then 
                    prevValueOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._ValueChangedAttribKey.KeyValue then 
                    prevValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
        updateSliderMinimumMaximum prevMinimumMaximumOpt currMinimumMaximumOpt target
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Value <-  currValue
        | ValueSome _, ValueNone -> target.Value <- 0.0
        | ValueNone, ValueNone -> ()
        match prevValueChangedOpt, currValueChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ValueChanged.RemoveHandler(prevValue); target.ValueChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ValueChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ValueChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a Slider in the view
    static member inline Slider(?minimumMaximum: float * float,
                                ?value: double,
                                ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit,
                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                ?margin: obj,
                                ?gestureRecognizers: ViewElement list,
                                ?anchorX: double,
                                ?anchorY: double,
                                ?backgroundColor: Xamarin.Forms.Color,
                                ?heightRequest: double,
                                ?inputTransparent: bool,
                                ?isEnabled: bool,
                                ?isVisible: bool,
                                ?minimumHeightRequest: double,
                                ?minimumWidthRequest: double,
                                ?opacity: double,
                                ?rotation: double,
                                ?rotationX: double,
                                ?rotationY: double,
                                ?scale: double,
                                ?style: Xamarin.Forms.Style,
                                ?styleClass: obj,
                                ?translationX: double,
                                ?translationY: double,
                                ?widthRequest: double,
                                ?resources: (string * obj) list,
                                ?styles: Xamarin.Forms.Style list,
                                ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                ?isTabStop: bool,
                                ?scaleX: double,
                                ?scaleY: double,
                                ?tabIndex: int,
                                ?classId: string,
                                ?styleId: string,
                                ?automationId: string,
                                ?created: (Xamarin.Forms.Slider -> unit),
                                ?ref: ViewRef<Xamarin.Forms.Slider>) = 

        let attribBuilder = View.BuildSlider(0,
                               ?minimumMaximum=minimumMaximum,
                               ?value=value,
                               ?valueChanged=valueChanged,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Slider> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Slider>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Slider>(View.CreateFuncSlider, View.UpdateFuncSlider, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoSlider : ViewElement option = None with get, set

    /// Builds the attributes for a Stepper in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildStepper(attribCount: int,
                                      ?minimumMaximum: float * float,
                                      ?value: double,
                                      ?increment: double,
                                      ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit,
                                      ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                      ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                      ?margin: obj,
                                      ?gestureRecognizers: ViewElement list,
                                      ?anchorX: double,
                                      ?anchorY: double,
                                      ?backgroundColor: Xamarin.Forms.Color,
                                      ?heightRequest: double,
                                      ?inputTransparent: bool,
                                      ?isEnabled: bool,
                                      ?isVisible: bool,
                                      ?minimumHeightRequest: double,
                                      ?minimumWidthRequest: double,
                                      ?opacity: double,
                                      ?rotation: double,
                                      ?rotationX: double,
                                      ?rotationY: double,
                                      ?scale: double,
                                      ?style: Xamarin.Forms.Style,
                                      ?styleClass: obj,
                                      ?translationX: double,
                                      ?translationY: double,
                                      ?widthRequest: double,
                                      ?resources: (string * obj) list,
                                      ?styles: Xamarin.Forms.Style list,
                                      ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                      ?isTabStop: bool,
                                      ?scaleX: double,
                                      ?scaleY: double,
                                      ?tabIndex: int,
                                      ?classId: string,
                                      ?styleId: string,
                                      ?automationId: string,
                                      ?created: obj -> unit,
                                      ?ref: ViewRef) = 

        let attribCount = match minimumMaximum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match value with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match increment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match valueChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match minimumMaximum with None -> () | Some v -> attribBuilder.Add(View._MinimumMaximumAttribKey, (v)) 
        match value with None -> () | Some v -> attribBuilder.Add(View._ValueAttribKey, (v)) 
        match increment with None -> () | Some v -> attribBuilder.Add(View._IncrementAttribKey, (v)) 
        match valueChanged with None -> () | Some v -> attribBuilder.Add(View._ValueChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncStepper : (unit -> Xamarin.Forms.Stepper) = (fun () -> View.CreateStepper())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateStepper () : Xamarin.Forms.Stepper = 
        upcast (new Xamarin.Forms.Stepper())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncStepper = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Stepper) -> View.UpdateStepper (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateStepper (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Stepper) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevMinimumMaximumOpt = ValueNone
        let mutable currMinimumMaximumOpt = ValueNone
        let mutable prevValueOpt = ValueNone
        let mutable currValueOpt = ValueNone
        let mutable prevIncrementOpt = ValueNone
        let mutable currIncrementOpt = ValueNone
        let mutable prevValueChangedOpt = ValueNone
        let mutable currValueChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._MinimumMaximumAttribKey.KeyValue then 
                currMinimumMaximumOpt <- ValueSome (kvp.Value :?> float * float)
            if kvp.Key = View._ValueAttribKey.KeyValue then 
                currValueOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._IncrementAttribKey.KeyValue then 
                currIncrementOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._ValueChangedAttribKey.KeyValue then 
                currValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._MinimumMaximumAttribKey.KeyValue then 
                    prevMinimumMaximumOpt <- ValueSome (kvp.Value :?> float * float)
                if kvp.Key = View._ValueAttribKey.KeyValue then 
                    prevValueOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._IncrementAttribKey.KeyValue then 
                    prevIncrementOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._ValueChangedAttribKey.KeyValue then 
                    prevValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
        updateStepperMinimumMaximum prevMinimumMaximumOpt currMinimumMaximumOpt target
        match prevValueOpt, currValueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Value <-  currValue
        | ValueSome _, ValueNone -> target.Value <- 0.0
        | ValueNone, ValueNone -> ()
        match prevIncrementOpt, currIncrementOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Increment <-  currValue
        | ValueSome _, ValueNone -> target.Increment <- 1.0
        | ValueNone, ValueNone -> ()
        match prevValueChangedOpt, currValueChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ValueChanged.RemoveHandler(prevValue); target.ValueChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ValueChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ValueChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a Stepper in the view
    static member inline Stepper(?minimumMaximum: float * float,
                                 ?value: double,
                                 ?increment: double,
                                 ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit,
                                 ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                 ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                 ?margin: obj,
                                 ?gestureRecognizers: ViewElement list,
                                 ?anchorX: double,
                                 ?anchorY: double,
                                 ?backgroundColor: Xamarin.Forms.Color,
                                 ?heightRequest: double,
                                 ?inputTransparent: bool,
                                 ?isEnabled: bool,
                                 ?isVisible: bool,
                                 ?minimumHeightRequest: double,
                                 ?minimumWidthRequest: double,
                                 ?opacity: double,
                                 ?rotation: double,
                                 ?rotationX: double,
                                 ?rotationY: double,
                                 ?scale: double,
                                 ?style: Xamarin.Forms.Style,
                                 ?styleClass: obj,
                                 ?translationX: double,
                                 ?translationY: double,
                                 ?widthRequest: double,
                                 ?resources: (string * obj) list,
                                 ?styles: Xamarin.Forms.Style list,
                                 ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                 ?isTabStop: bool,
                                 ?scaleX: double,
                                 ?scaleY: double,
                                 ?tabIndex: int,
                                 ?classId: string,
                                 ?styleId: string,
                                 ?automationId: string,
                                 ?created: (Xamarin.Forms.Stepper -> unit),
                                 ?ref: ViewRef<Xamarin.Forms.Stepper>) = 

        let attribBuilder = View.BuildStepper(0,
                               ?minimumMaximum=minimumMaximum,
                               ?value=value,
                               ?increment=increment,
                               ?valueChanged=valueChanged,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Stepper> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Stepper>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Stepper>(View.CreateFuncStepper, View.UpdateFuncStepper, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoStepper : ViewElement option = None with get, set

    /// Builds the attributes for a Switch in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildSwitch(attribCount: int,
                                     ?isToggled: bool,
                                     ?toggled: Xamarin.Forms.ToggledEventArgs -> unit,
                                     ?onColor: Xamarin.Forms.Color,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: obj -> unit,
                                     ?ref: ViewRef) = 

        let attribCount = match isToggled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match toggled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match onColor with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match isToggled with None -> () | Some v -> attribBuilder.Add(View._IsToggledAttribKey, (v)) 
        match toggled with None -> () | Some v -> attribBuilder.Add(View._ToggledAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v)) 
        match onColor with None -> () | Some v -> attribBuilder.Add(View._OnColorAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncSwitch : (unit -> Xamarin.Forms.Switch) = (fun () -> View.CreateSwitch())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateSwitch () : Xamarin.Forms.Switch = 
        upcast (new Xamarin.Forms.Switch())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncSwitch = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Switch) -> View.UpdateSwitch (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateSwitch (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Switch) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevIsToggledOpt = ValueNone
        let mutable currIsToggledOpt = ValueNone
        let mutable prevToggledOpt = ValueNone
        let mutable currToggledOpt = ValueNone
        let mutable prevOnColorOpt = ValueNone
        let mutable currOnColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._IsToggledAttribKey.KeyValue then 
                currIsToggledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._ToggledAttribKey.KeyValue then 
                currToggledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
            if kvp.Key = View._OnColorAttribKey.KeyValue then 
                currOnColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._IsToggledAttribKey.KeyValue then 
                    prevIsToggledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._ToggledAttribKey.KeyValue then 
                    prevToggledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
                if kvp.Key = View._OnColorAttribKey.KeyValue then 
                    prevOnColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevIsToggledOpt, currIsToggledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsToggled <-  currValue
        | ValueSome _, ValueNone -> target.IsToggled <- false
        | ValueNone, ValueNone -> ()
        match prevToggledOpt, currToggledOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Toggled.RemoveHandler(prevValue); target.Toggled.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Toggled.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Toggled.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevOnColorOpt, currOnColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.OnColor <-  currValue
        | ValueSome _, ValueNone -> target.OnColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()

    /// Describes a Switch in the view
    static member inline Switch(?isToggled: bool,
                                ?toggled: Xamarin.Forms.ToggledEventArgs -> unit,
                                ?onColor: Xamarin.Forms.Color,
                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                ?margin: obj,
                                ?gestureRecognizers: ViewElement list,
                                ?anchorX: double,
                                ?anchorY: double,
                                ?backgroundColor: Xamarin.Forms.Color,
                                ?heightRequest: double,
                                ?inputTransparent: bool,
                                ?isEnabled: bool,
                                ?isVisible: bool,
                                ?minimumHeightRequest: double,
                                ?minimumWidthRequest: double,
                                ?opacity: double,
                                ?rotation: double,
                                ?rotationX: double,
                                ?rotationY: double,
                                ?scale: double,
                                ?style: Xamarin.Forms.Style,
                                ?styleClass: obj,
                                ?translationX: double,
                                ?translationY: double,
                                ?widthRequest: double,
                                ?resources: (string * obj) list,
                                ?styles: Xamarin.Forms.Style list,
                                ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                ?isTabStop: bool,
                                ?scaleX: double,
                                ?scaleY: double,
                                ?tabIndex: int,
                                ?classId: string,
                                ?styleId: string,
                                ?automationId: string,
                                ?created: (Xamarin.Forms.Switch -> unit),
                                ?ref: ViewRef<Xamarin.Forms.Switch>) = 

        let attribBuilder = View.BuildSwitch(0,
                               ?isToggled=isToggled,
                               ?toggled=toggled,
                               ?onColor=onColor,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Switch> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Switch>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Switch>(View.CreateFuncSwitch, View.UpdateFuncSwitch, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoSwitch : ViewElement option = None with get, set

    /// Builds the attributes for a Cell in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildCell(attribCount: int,
                                   ?height: double,
                                   ?isEnabled: bool,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?automationId: string,
                                   ?created: obj -> unit,
                                   ?ref: ViewRef) = 

        let attribCount = match height with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isEnabled with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildElement(attribCount, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match height with None -> () | Some v -> attribBuilder.Add(View._HeightAttribKey, (v)) 
        match isEnabled with None -> () | Some v -> attribBuilder.Add(View._IsEnabledAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncCell : (unit -> Xamarin.Forms.Cell) = (fun () -> View.CreateCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateCell () : Xamarin.Forms.Cell = 
        failwith "can't create Xamarin.Forms.Cell"

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncCell = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Cell) -> View.UpdateCell (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateCell (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Cell) = 
        // update the inherited Element element
        let baseElement = (if View.ProtoElement.IsNone then View.ProtoElement <- Some (View.Element())); View.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevHeightOpt = ValueNone
        let mutable currHeightOpt = ValueNone
        let mutable prevIsEnabledOpt = ValueNone
        let mutable currIsEnabledOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._HeightAttribKey.KeyValue then 
                currHeightOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._IsEnabledAttribKey.KeyValue then 
                currIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._HeightAttribKey.KeyValue then 
                    prevHeightOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._IsEnabledAttribKey.KeyValue then 
                    prevIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
        match prevHeightOpt, currHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Height <-  currValue
        | ValueSome _, ValueNone -> target.Height <- -1.0
        | ValueNone, ValueNone -> ()
        match prevIsEnabledOpt, currIsEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsEnabled <-  currValue
        | ValueSome _, ValueNone -> target.IsEnabled <- true
        | ValueNone, ValueNone -> ()

    /// Describes a Cell in the view
    static member inline Cell(?height: double,
                              ?isEnabled: bool,
                              ?classId: string,
                              ?styleId: string,
                              ?automationId: string,
                              ?created: (Xamarin.Forms.Cell -> unit),
                              ?ref: ViewRef<Xamarin.Forms.Cell>) = 

        let attribBuilder = View.BuildCell(0,
                               ?height=height,
                               ?isEnabled=isEnabled,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Cell> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Cell>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Cell>(View.CreateFuncCell, View.UpdateFuncCell, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoCell : ViewElement option = None with get, set

    /// Builds the attributes for a SwitchCell in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildSwitchCell(attribCount: int,
                                         ?on: bool,
                                         ?text: string,
                                         ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit,
                                         ?height: double,
                                         ?isEnabled: bool,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?automationId: string,
                                         ?created: obj -> unit,
                                         ?ref: ViewRef) = 

        let attribCount = match on with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match onChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match on with None -> () | Some v -> attribBuilder.Add(View._OnAttribKey, (v)) 
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        match onChanged with None -> () | Some v -> attribBuilder.Add(View._OnChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncSwitchCell : (unit -> Xamarin.Forms.SwitchCell) = (fun () -> View.CreateSwitchCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateSwitchCell () : Xamarin.Forms.SwitchCell = 
        upcast (new Xamarin.Forms.SwitchCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncSwitchCell = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.SwitchCell) -> View.UpdateSwitchCell (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateSwitchCell (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.SwitchCell) = 
        // update the inherited Cell element
        let baseElement = (if View.ProtoCell.IsNone then View.ProtoCell <- Some (View.Cell())); View.ProtoCell.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevOnOpt = ValueNone
        let mutable currOnOpt = ValueNone
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevOnChangedOpt = ValueNone
        let mutable currOnChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._OnAttribKey.KeyValue then 
                currOnOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._OnChangedAttribKey.KeyValue then 
                currOnChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._OnAttribKey.KeyValue then 
                    prevOnOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._OnChangedAttribKey.KeyValue then 
                    prevOnChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
        match prevOnOpt, currOnOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.On <-  currValue
        | ValueSome _, ValueNone -> target.On <- false
        | ValueNone, ValueNone -> ()
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevOnChangedOpt, currOnChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.OnChanged.RemoveHandler(prevValue); target.OnChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.OnChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.OnChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a SwitchCell in the view
    static member inline SwitchCell(?on: bool,
                                    ?text: string,
                                    ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit,
                                    ?height: double,
                                    ?isEnabled: bool,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?automationId: string,
                                    ?created: (Xamarin.Forms.SwitchCell -> unit),
                                    ?ref: ViewRef<Xamarin.Forms.SwitchCell>) = 

        let attribBuilder = View.BuildSwitchCell(0,
                               ?on=on,
                               ?text=text,
                               ?onChanged=onChanged,
                               ?height=height,
                               ?isEnabled=isEnabled,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.SwitchCell> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.SwitchCell>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.SwitchCell>(View.CreateFuncSwitchCell, View.UpdateFuncSwitchCell, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoSwitchCell : ViewElement option = None with get, set

    /// Builds the attributes for a TableView in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildTableView(attribCount: int,
                                        ?intent: Xamarin.Forms.TableIntent,
                                        ?hasUnevenRows: bool,
                                        ?rowHeight: int,
                                        ?items: (string * ViewElement list) list,
                                        ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                        ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                        ?margin: obj,
                                        ?gestureRecognizers: ViewElement list,
                                        ?anchorX: double,
                                        ?anchorY: double,
                                        ?backgroundColor: Xamarin.Forms.Color,
                                        ?heightRequest: double,
                                        ?inputTransparent: bool,
                                        ?isEnabled: bool,
                                        ?isVisible: bool,
                                        ?minimumHeightRequest: double,
                                        ?minimumWidthRequest: double,
                                        ?opacity: double,
                                        ?rotation: double,
                                        ?rotationX: double,
                                        ?rotationY: double,
                                        ?scale: double,
                                        ?style: Xamarin.Forms.Style,
                                        ?styleClass: obj,
                                        ?translationX: double,
                                        ?translationY: double,
                                        ?widthRequest: double,
                                        ?resources: (string * obj) list,
                                        ?styles: Xamarin.Forms.Style list,
                                        ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                        ?isTabStop: bool,
                                        ?scaleX: double,
                                        ?scaleY: double,
                                        ?tabIndex: int,
                                        ?classId: string,
                                        ?styleId: string,
                                        ?automationId: string,
                                        ?created: obj -> unit,
                                        ?ref: ViewRef) = 

        let attribCount = match intent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasUnevenRows with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rowHeight with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match items with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match intent with None -> () | Some v -> attribBuilder.Add(View._IntentAttribKey, (v)) 
        match hasUnevenRows with None -> () | Some v -> attribBuilder.Add(View._HasUnevenRowsAttribKey, (v)) 
        match rowHeight with None -> () | Some v -> attribBuilder.Add(View._RowHeightAttribKey, (v)) 
        match items with None -> () | Some v -> attribBuilder.Add(View._TableRootAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncTableView : (unit -> Xamarin.Forms.TableView) = (fun () -> View.CreateTableView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateTableView () : Xamarin.Forms.TableView = 
        upcast (new Xamarin.Forms.TableView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncTableView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TableView) -> View.UpdateTableView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateTableView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.TableView) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevIntentOpt = ValueNone
        let mutable currIntentOpt = ValueNone
        let mutable prevHasUnevenRowsOpt = ValueNone
        let mutable currHasUnevenRowsOpt = ValueNone
        let mutable prevRowHeightOpt = ValueNone
        let mutable currRowHeightOpt = ValueNone
        let mutable prevTableRootOpt = ValueNone
        let mutable currTableRootOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._IntentAttribKey.KeyValue then 
                currIntentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TableIntent)
            if kvp.Key = View._HasUnevenRowsAttribKey.KeyValue then 
                currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._RowHeightAttribKey.KeyValue then 
                currRowHeightOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._TableRootAttribKey.KeyValue then 
                currTableRootOpt <- ValueSome (kvp.Value :?> (string * ViewElement[])[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._IntentAttribKey.KeyValue then 
                    prevIntentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TableIntent)
                if kvp.Key = View._HasUnevenRowsAttribKey.KeyValue then 
                    prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._RowHeightAttribKey.KeyValue then 
                    prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._TableRootAttribKey.KeyValue then 
                    prevTableRootOpt <- ValueSome (kvp.Value :?> (string * ViewElement[])[])
        match prevIntentOpt, currIntentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Intent <-  currValue
        | ValueSome _, ValueNone -> target.Intent <- Unchecked.defaultof<Xamarin.Forms.TableIntent>
        | ValueNone, ValueNone -> ()
        match prevHasUnevenRowsOpt, currHasUnevenRowsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HasUnevenRows <-  currValue
        | ValueSome _, ValueNone -> target.HasUnevenRows <- false
        | ValueNone, ValueNone -> ()
        match prevRowHeightOpt, currRowHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RowHeight <-  currValue
        | ValueSome _, ValueNone -> target.RowHeight <- -1
        | ValueNone, ValueNone -> ()
        updateTableViewItems prevTableRootOpt currTableRootOpt target

    /// Describes a TableView in the view
    static member inline TableView(?intent: Xamarin.Forms.TableIntent,
                                   ?hasUnevenRows: bool,
                                   ?rowHeight: int,
                                   ?items: (string * ViewElement list) list,
                                   ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                   ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                   ?margin: obj,
                                   ?gestureRecognizers: ViewElement list,
                                   ?anchorX: double,
                                   ?anchorY: double,
                                   ?backgroundColor: Xamarin.Forms.Color,
                                   ?heightRequest: double,
                                   ?inputTransparent: bool,
                                   ?isEnabled: bool,
                                   ?isVisible: bool,
                                   ?minimumHeightRequest: double,
                                   ?minimumWidthRequest: double,
                                   ?opacity: double,
                                   ?rotation: double,
                                   ?rotationX: double,
                                   ?rotationY: double,
                                   ?scale: double,
                                   ?style: Xamarin.Forms.Style,
                                   ?styleClass: obj,
                                   ?translationX: double,
                                   ?translationY: double,
                                   ?widthRequest: double,
                                   ?resources: (string * obj) list,
                                   ?styles: Xamarin.Forms.Style list,
                                   ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                   ?isTabStop: bool,
                                   ?scaleX: double,
                                   ?scaleY: double,
                                   ?tabIndex: int,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?automationId: string,
                                   ?created: (Xamarin.Forms.TableView -> unit),
                                   ?ref: ViewRef<Xamarin.Forms.TableView>) = 

        let attribBuilder = View.BuildTableView(0,
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
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.TableView> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.TableView>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.TableView>(View.CreateFuncTableView, View.UpdateFuncTableView, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoTableView : ViewElement option = None with get, set

    /// Builds the attributes for a RowDefinition in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildRowDefinition(attribCount: int,
                                            ?height: obj) = 

        let attribCount = match height with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = new AttributesBuilder(attribCount)
        match height with None -> () | Some v -> attribBuilder.Add(View._RowDefinitionHeightAttribKey, makeGridLength(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncRowDefinition : (unit -> Xamarin.Forms.RowDefinition) = (fun () -> View.CreateRowDefinition())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateRowDefinition () : Xamarin.Forms.RowDefinition = 
        upcast (new Xamarin.Forms.RowDefinition())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncRowDefinition = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.RowDefinition) -> View.UpdateRowDefinition (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateRowDefinition (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.RowDefinition) = 
        let mutable prevRowDefinitionHeightOpt = ValueNone
        let mutable currRowDefinitionHeightOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._RowDefinitionHeightAttribKey.KeyValue then 
                currRowDefinitionHeightOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._RowDefinitionHeightAttribKey.KeyValue then 
                    prevRowDefinitionHeightOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevRowDefinitionHeightOpt, currRowDefinitionHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Height <-  currValue
        | ValueSome _, ValueNone -> target.Height <- Xamarin.Forms.GridLength.Auto
        | ValueNone, ValueNone -> ()

    /// Describes a RowDefinition in the view
    static member inline RowDefinition(?height: obj) = 

        let attribBuilder = View.BuildRowDefinition(0,
                               ?height=height)

        ViewElement.Create<Xamarin.Forms.RowDefinition>(View.CreateFuncRowDefinition, View.UpdateFuncRowDefinition, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoRowDefinition : ViewElement option = None with get, set

    /// Builds the attributes for a ColumnDefinition in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildColumnDefinition(attribCount: int,
                                               ?width: obj) = 

        let attribCount = match width with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = new AttributesBuilder(attribCount)
        match width with None -> () | Some v -> attribBuilder.Add(View._ColumnDefinitionWidthAttribKey, makeGridLength(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncColumnDefinition : (unit -> Xamarin.Forms.ColumnDefinition) = (fun () -> View.CreateColumnDefinition())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateColumnDefinition () : Xamarin.Forms.ColumnDefinition = 
        upcast (new Xamarin.Forms.ColumnDefinition())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncColumnDefinition = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ColumnDefinition) -> View.UpdateColumnDefinition (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateColumnDefinition (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ColumnDefinition) = 
        let mutable prevColumnDefinitionWidthOpt = ValueNone
        let mutable currColumnDefinitionWidthOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ColumnDefinitionWidthAttribKey.KeyValue then 
                currColumnDefinitionWidthOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ColumnDefinitionWidthAttribKey.KeyValue then 
                    prevColumnDefinitionWidthOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevColumnDefinitionWidthOpt, currColumnDefinitionWidthOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Width <-  currValue
        | ValueSome _, ValueNone -> target.Width <- Xamarin.Forms.GridLength.Auto
        | ValueNone, ValueNone -> ()

    /// Describes a ColumnDefinition in the view
    static member inline ColumnDefinition(?width: obj) = 

        let attribBuilder = View.BuildColumnDefinition(0,
                               ?width=width)

        ViewElement.Create<Xamarin.Forms.ColumnDefinition>(View.CreateFuncColumnDefinition, View.UpdateFuncColumnDefinition, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoColumnDefinition : ViewElement option = None with get, set

    /// Builds the attributes for a Grid in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildGrid(attribCount: int,
                                   ?rowdefs: obj list,
                                   ?coldefs: obj list,
                                   ?rowSpacing: double,
                                   ?columnSpacing: double,
                                   ?children: ViewElement list,
                                   ?isClippedToBounds: bool,
                                   ?padding: obj,
                                   ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                   ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                   ?margin: obj,
                                   ?gestureRecognizers: ViewElement list,
                                   ?anchorX: double,
                                   ?anchorY: double,
                                   ?backgroundColor: Xamarin.Forms.Color,
                                   ?heightRequest: double,
                                   ?inputTransparent: bool,
                                   ?isEnabled: bool,
                                   ?isVisible: bool,
                                   ?minimumHeightRequest: double,
                                   ?minimumWidthRequest: double,
                                   ?opacity: double,
                                   ?rotation: double,
                                   ?rotationX: double,
                                   ?rotationY: double,
                                   ?scale: double,
                                   ?style: Xamarin.Forms.Style,
                                   ?styleClass: obj,
                                   ?translationX: double,
                                   ?translationY: double,
                                   ?widthRequest: double,
                                   ?resources: (string * obj) list,
                                   ?styles: Xamarin.Forms.Style list,
                                   ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                   ?isTabStop: bool,
                                   ?scaleX: double,
                                   ?scaleY: double,
                                   ?tabIndex: int,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?automationId: string,
                                   ?created: obj -> unit,
                                   ?ref: ViewRef) = 

        let attribCount = match rowdefs with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match coldefs with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rowSpacing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match columnSpacing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match rowdefs with None -> () | Some v -> attribBuilder.Add(View._GridRowDefinitionsAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun h -> View.RowDefinition(height=h)))(v)) 
        match coldefs with None -> () | Some v -> attribBuilder.Add(View._GridColumnDefinitionsAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun h -> View.ColumnDefinition(width=h)))(v)) 
        match rowSpacing with None -> () | Some v -> attribBuilder.Add(View._RowSpacingAttribKey, (v)) 
        match columnSpacing with None -> () | Some v -> attribBuilder.Add(View._ColumnSpacingAttribKey, (v)) 
        match children with None -> () | Some v -> attribBuilder.Add(View._ChildrenAttribKey, Array.ofList(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncGrid : (unit -> Xamarin.Forms.Grid) = (fun () -> View.CreateGrid())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateGrid () : Xamarin.Forms.Grid = 
        upcast (new Xamarin.Forms.Grid())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncGrid = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Grid) -> View.UpdateGrid (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateGrid (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Grid) = 
        // update the inherited Layout element
        let baseElement = (if View.ProtoLayout.IsNone then View.ProtoLayout <- Some (View.Layout())); View.ProtoLayout.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevGridRowDefinitionsOpt = ValueNone
        let mutable currGridRowDefinitionsOpt = ValueNone
        let mutable prevGridColumnDefinitionsOpt = ValueNone
        let mutable currGridColumnDefinitionsOpt = ValueNone
        let mutable prevRowSpacingOpt = ValueNone
        let mutable currRowSpacingOpt = ValueNone
        let mutable prevColumnSpacingOpt = ValueNone
        let mutable currColumnSpacingOpt = ValueNone
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._GridRowDefinitionsAttribKey.KeyValue then 
                currGridRowDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = View._GridColumnDefinitionsAttribKey.KeyValue then 
                currGridColumnDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = View._RowSpacingAttribKey.KeyValue then 
                currRowSpacingOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._ColumnSpacingAttribKey.KeyValue then 
                currColumnSpacingOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._GridRowDefinitionsAttribKey.KeyValue then 
                    prevGridRowDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = View._GridColumnDefinitionsAttribKey.KeyValue then 
                    prevGridColumnDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = View._RowSpacingAttribKey.KeyValue then 
                    prevRowSpacingOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._ColumnSpacingAttribKey.KeyValue then 
                    prevColumnSpacingOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        updateCollectionGeneric prevGridRowDefinitionsOpt currGridRowDefinitionsOpt target.RowDefinitions
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.RowDefinition)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild
        updateCollectionGeneric prevGridColumnDefinitionsOpt currGridColumnDefinitionsOpt target.ColumnDefinitions
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.ColumnDefinition)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild
        match prevRowSpacingOpt, currRowSpacingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RowSpacing <-  currValue
        | ValueSome _, ValueNone -> target.RowSpacing <- 0.0
        | ValueNone, ValueNone -> ()
        match prevColumnSpacingOpt, currColumnSpacingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ColumnSpacing <-  currValue
        | ValueSome _, ValueNone -> target.ColumnSpacing <- 0.0
        | ValueNone, ValueNone -> ()
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(View._GridRowAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(View._GridRowAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetRow(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRow(targetChild, 0)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(View._GridRowSpanAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(View._GridRowSpanAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetRowSpan(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRowSpan(targetChild, 0)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(View._GridColumnAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(View._GridColumnAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetColumn(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumn(targetChild, 0)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(View._GridColumnSpanAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(View._GridColumnSpanAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, 0)
                | _ -> ()
                ())
            canReuseChild
            updateChild

    /// Describes a Grid in the view
    static member inline Grid(?rowdefs: obj list,
                              ?coldefs: obj list,
                              ?rowSpacing: double,
                              ?columnSpacing: double,
                              ?children: ViewElement list,
                              ?isClippedToBounds: bool,
                              ?padding: obj,
                              ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                              ?verticalOptions: Xamarin.Forms.LayoutOptions,
                              ?margin: obj,
                              ?gestureRecognizers: ViewElement list,
                              ?anchorX: double,
                              ?anchorY: double,
                              ?backgroundColor: Xamarin.Forms.Color,
                              ?heightRequest: double,
                              ?inputTransparent: bool,
                              ?isEnabled: bool,
                              ?isVisible: bool,
                              ?minimumHeightRequest: double,
                              ?minimumWidthRequest: double,
                              ?opacity: double,
                              ?rotation: double,
                              ?rotationX: double,
                              ?rotationY: double,
                              ?scale: double,
                              ?style: Xamarin.Forms.Style,
                              ?styleClass: obj,
                              ?translationX: double,
                              ?translationY: double,
                              ?widthRequest: double,
                              ?resources: (string * obj) list,
                              ?styles: Xamarin.Forms.Style list,
                              ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                              ?isTabStop: bool,
                              ?scaleX: double,
                              ?scaleY: double,
                              ?tabIndex: int,
                              ?classId: string,
                              ?styleId: string,
                              ?automationId: string,
                              ?created: (Xamarin.Forms.Grid -> unit),
                              ?ref: ViewRef<Xamarin.Forms.Grid>) = 

        let attribBuilder = View.BuildGrid(0,
                               ?rowdefs=rowdefs,
                               ?coldefs=coldefs,
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
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Grid> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Grid>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Grid>(View.CreateFuncGrid, View.UpdateFuncGrid, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoGrid : ViewElement option = None with get, set

    /// Builds the attributes for a AbsoluteLayout in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildAbsoluteLayout(attribCount: int,
                                             ?children: ViewElement list,
                                             ?isClippedToBounds: bool,
                                             ?padding: obj,
                                             ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                             ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                             ?margin: obj,
                                             ?gestureRecognizers: ViewElement list,
                                             ?anchorX: double,
                                             ?anchorY: double,
                                             ?backgroundColor: Xamarin.Forms.Color,
                                             ?heightRequest: double,
                                             ?inputTransparent: bool,
                                             ?isEnabled: bool,
                                             ?isVisible: bool,
                                             ?minimumHeightRequest: double,
                                             ?minimumWidthRequest: double,
                                             ?opacity: double,
                                             ?rotation: double,
                                             ?rotationX: double,
                                             ?rotationY: double,
                                             ?scale: double,
                                             ?style: Xamarin.Forms.Style,
                                             ?styleClass: obj,
                                             ?translationX: double,
                                             ?translationY: double,
                                             ?widthRequest: double,
                                             ?resources: (string * obj) list,
                                             ?styles: Xamarin.Forms.Style list,
                                             ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                             ?isTabStop: bool,
                                             ?scaleX: double,
                                             ?scaleY: double,
                                             ?tabIndex: int,
                                             ?classId: string,
                                             ?styleId: string,
                                             ?automationId: string,
                                             ?created: obj -> unit,
                                             ?ref: ViewRef) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match children with None -> () | Some v -> attribBuilder.Add(View._ChildrenAttribKey, Array.ofList(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncAbsoluteLayout : (unit -> Xamarin.Forms.AbsoluteLayout) = (fun () -> View.CreateAbsoluteLayout())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateAbsoluteLayout () : Xamarin.Forms.AbsoluteLayout = 
        upcast (new Xamarin.Forms.AbsoluteLayout())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncAbsoluteLayout = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.AbsoluteLayout) -> View.UpdateAbsoluteLayout (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateAbsoluteLayout (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.AbsoluteLayout) = 
        // update the inherited Layout element
        let baseElement = (if View.ProtoLayout.IsNone then View.ProtoLayout <- Some (View.Layout())); View.ProtoLayout.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Rectangle>(View._LayoutBoundsAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Rectangle>(View._LayoutBoundsAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, Xamarin.Forms.Rectangle.Zero)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.AbsoluteLayoutFlags>(View._LayoutFlagsAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.AbsoluteLayoutFlags>(View._LayoutFlagsAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, Xamarin.Forms.AbsoluteLayoutFlags.None)
                | _ -> ()
                ())
            canReuseChild
            updateChild

    /// Describes a AbsoluteLayout in the view
    static member inline AbsoluteLayout(?children: ViewElement list,
                                        ?isClippedToBounds: bool,
                                        ?padding: obj,
                                        ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                        ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                        ?margin: obj,
                                        ?gestureRecognizers: ViewElement list,
                                        ?anchorX: double,
                                        ?anchorY: double,
                                        ?backgroundColor: Xamarin.Forms.Color,
                                        ?heightRequest: double,
                                        ?inputTransparent: bool,
                                        ?isEnabled: bool,
                                        ?isVisible: bool,
                                        ?minimumHeightRequest: double,
                                        ?minimumWidthRequest: double,
                                        ?opacity: double,
                                        ?rotation: double,
                                        ?rotationX: double,
                                        ?rotationY: double,
                                        ?scale: double,
                                        ?style: Xamarin.Forms.Style,
                                        ?styleClass: obj,
                                        ?translationX: double,
                                        ?translationY: double,
                                        ?widthRequest: double,
                                        ?resources: (string * obj) list,
                                        ?styles: Xamarin.Forms.Style list,
                                        ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                        ?isTabStop: bool,
                                        ?scaleX: double,
                                        ?scaleY: double,
                                        ?tabIndex: int,
                                        ?classId: string,
                                        ?styleId: string,
                                        ?automationId: string,
                                        ?created: (Xamarin.Forms.AbsoluteLayout -> unit),
                                        ?ref: ViewRef<Xamarin.Forms.AbsoluteLayout>) = 

        let attribBuilder = View.BuildAbsoluteLayout(0,
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
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.AbsoluteLayout> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.AbsoluteLayout>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.AbsoluteLayout>(View.CreateFuncAbsoluteLayout, View.UpdateFuncAbsoluteLayout, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoAbsoluteLayout : ViewElement option = None with get, set

    /// Builds the attributes for a RelativeLayout in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildRelativeLayout(attribCount: int,
                                             ?children: ViewElement list,
                                             ?isClippedToBounds: bool,
                                             ?padding: obj,
                                             ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                             ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                             ?margin: obj,
                                             ?gestureRecognizers: ViewElement list,
                                             ?anchorX: double,
                                             ?anchorY: double,
                                             ?backgroundColor: Xamarin.Forms.Color,
                                             ?heightRequest: double,
                                             ?inputTransparent: bool,
                                             ?isEnabled: bool,
                                             ?isVisible: bool,
                                             ?minimumHeightRequest: double,
                                             ?minimumWidthRequest: double,
                                             ?opacity: double,
                                             ?rotation: double,
                                             ?rotationX: double,
                                             ?rotationY: double,
                                             ?scale: double,
                                             ?style: Xamarin.Forms.Style,
                                             ?styleClass: obj,
                                             ?translationX: double,
                                             ?translationY: double,
                                             ?widthRequest: double,
                                             ?resources: (string * obj) list,
                                             ?styles: Xamarin.Forms.Style list,
                                             ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                             ?isTabStop: bool,
                                             ?scaleX: double,
                                             ?scaleY: double,
                                             ?tabIndex: int,
                                             ?classId: string,
                                             ?styleId: string,
                                             ?automationId: string,
                                             ?created: obj -> unit,
                                             ?ref: ViewRef) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match children with None -> () | Some v -> attribBuilder.Add(View._ChildrenAttribKey, Array.ofList(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncRelativeLayout : (unit -> Xamarin.Forms.RelativeLayout) = (fun () -> View.CreateRelativeLayout())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateRelativeLayout () : Xamarin.Forms.RelativeLayout = 
        upcast (new Xamarin.Forms.RelativeLayout())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncRelativeLayout = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.RelativeLayout) -> View.UpdateRelativeLayout (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateRelativeLayout (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.RelativeLayout) = 
        // update the inherited Layout element
        let baseElement = (if View.ProtoLayout.IsNone then View.ProtoLayout <- Some (View.Layout())); View.ProtoLayout.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.BoundsConstraint>(View._BoundsConstraintAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.BoundsConstraint>(View._BoundsConstraintAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, null)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(View._HeightConstraintAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(View._HeightConstraintAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, null)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(View._WidthConstraintAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(View._WidthConstraintAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, null)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(View._XConstraintAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(View._XConstraintAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, null)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(View._YConstraintAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(View._YConstraintAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, null)
                | _ -> ()
                ())
            canReuseChild
            updateChild

    /// Describes a RelativeLayout in the view
    static member inline RelativeLayout(?children: ViewElement list,
                                        ?isClippedToBounds: bool,
                                        ?padding: obj,
                                        ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                        ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                        ?margin: obj,
                                        ?gestureRecognizers: ViewElement list,
                                        ?anchorX: double,
                                        ?anchorY: double,
                                        ?backgroundColor: Xamarin.Forms.Color,
                                        ?heightRequest: double,
                                        ?inputTransparent: bool,
                                        ?isEnabled: bool,
                                        ?isVisible: bool,
                                        ?minimumHeightRequest: double,
                                        ?minimumWidthRequest: double,
                                        ?opacity: double,
                                        ?rotation: double,
                                        ?rotationX: double,
                                        ?rotationY: double,
                                        ?scale: double,
                                        ?style: Xamarin.Forms.Style,
                                        ?styleClass: obj,
                                        ?translationX: double,
                                        ?translationY: double,
                                        ?widthRequest: double,
                                        ?resources: (string * obj) list,
                                        ?styles: Xamarin.Forms.Style list,
                                        ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                        ?isTabStop: bool,
                                        ?scaleX: double,
                                        ?scaleY: double,
                                        ?tabIndex: int,
                                        ?classId: string,
                                        ?styleId: string,
                                        ?automationId: string,
                                        ?created: (Xamarin.Forms.RelativeLayout -> unit),
                                        ?ref: ViewRef<Xamarin.Forms.RelativeLayout>) = 

        let attribBuilder = View.BuildRelativeLayout(0,
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
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.RelativeLayout> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.RelativeLayout>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.RelativeLayout>(View.CreateFuncRelativeLayout, View.UpdateFuncRelativeLayout, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoRelativeLayout : ViewElement option = None with get, set

    /// Builds the attributes for a FlexLayout in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildFlexLayout(attribCount: int,
                                         ?alignContent: Xamarin.Forms.FlexAlignContent,
                                         ?alignItems: Xamarin.Forms.FlexAlignItems,
                                         ?direction: Xamarin.Forms.FlexDirection,
                                         ?position: Xamarin.Forms.FlexPosition,
                                         ?wrap: Xamarin.Forms.FlexWrap,
                                         ?justifyContent: Xamarin.Forms.FlexJustify,
                                         ?children: ViewElement list,
                                         ?isClippedToBounds: bool,
                                         ?padding: obj,
                                         ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                         ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                         ?margin: obj,
                                         ?gestureRecognizers: ViewElement list,
                                         ?anchorX: double,
                                         ?anchorY: double,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?heightRequest: double,
                                         ?inputTransparent: bool,
                                         ?isEnabled: bool,
                                         ?isVisible: bool,
                                         ?minimumHeightRequest: double,
                                         ?minimumWidthRequest: double,
                                         ?opacity: double,
                                         ?rotation: double,
                                         ?rotationX: double,
                                         ?rotationY: double,
                                         ?scale: double,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: obj,
                                         ?translationX: double,
                                         ?translationY: double,
                                         ?widthRequest: double,
                                         ?resources: (string * obj) list,
                                         ?styles: Xamarin.Forms.Style list,
                                         ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                         ?isTabStop: bool,
                                         ?scaleX: double,
                                         ?scaleY: double,
                                         ?tabIndex: int,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?automationId: string,
                                         ?created: obj -> unit,
                                         ?ref: ViewRef) = 

        let attribCount = match alignContent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match alignItems with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match direction with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match position with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match wrap with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match justifyContent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match alignContent with None -> () | Some v -> attribBuilder.Add(View._AlignContentAttribKey, (v)) 
        match alignItems with None -> () | Some v -> attribBuilder.Add(View._AlignItemsAttribKey, (v)) 
        match direction with None -> () | Some v -> attribBuilder.Add(View._FlexLayoutDirectionAttribKey, (v)) 
        match position with None -> () | Some v -> attribBuilder.Add(View._PositionAttribKey, (v)) 
        match wrap with None -> () | Some v -> attribBuilder.Add(View._WrapAttribKey, (v)) 
        match justifyContent with None -> () | Some v -> attribBuilder.Add(View._JustifyContentAttribKey, (v)) 
        match children with None -> () | Some v -> attribBuilder.Add(View._ChildrenAttribKey, Array.ofList(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncFlexLayout : (unit -> Xamarin.Forms.FlexLayout) = (fun () -> View.CreateFlexLayout())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateFlexLayout () : Xamarin.Forms.FlexLayout = 
        upcast (new Xamarin.Forms.FlexLayout())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncFlexLayout = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.FlexLayout) -> View.UpdateFlexLayout (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateFlexLayout (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.FlexLayout) = 
        // update the inherited Layout element
        let baseElement = (if View.ProtoLayout.IsNone then View.ProtoLayout <- Some (View.Layout())); View.ProtoLayout.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevAlignContentOpt = ValueNone
        let mutable currAlignContentOpt = ValueNone
        let mutable prevAlignItemsOpt = ValueNone
        let mutable currAlignItemsOpt = ValueNone
        let mutable prevFlexLayoutDirectionOpt = ValueNone
        let mutable currFlexLayoutDirectionOpt = ValueNone
        let mutable prevPositionOpt = ValueNone
        let mutable currPositionOpt = ValueNone
        let mutable prevWrapOpt = ValueNone
        let mutable currWrapOpt = ValueNone
        let mutable prevJustifyContentOpt = ValueNone
        let mutable currJustifyContentOpt = ValueNone
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._AlignContentAttribKey.KeyValue then 
                currAlignContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignContent)
            if kvp.Key = View._AlignItemsAttribKey.KeyValue then 
                currAlignItemsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignItems)
            if kvp.Key = View._FlexLayoutDirectionAttribKey.KeyValue then 
                currFlexLayoutDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexDirection)
            if kvp.Key = View._PositionAttribKey.KeyValue then 
                currPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexPosition)
            if kvp.Key = View._WrapAttribKey.KeyValue then 
                currWrapOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexWrap)
            if kvp.Key = View._JustifyContentAttribKey.KeyValue then 
                currJustifyContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexJustify)
            if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._AlignContentAttribKey.KeyValue then 
                    prevAlignContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignContent)
                if kvp.Key = View._AlignItemsAttribKey.KeyValue then 
                    prevAlignItemsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignItems)
                if kvp.Key = View._FlexLayoutDirectionAttribKey.KeyValue then 
                    prevFlexLayoutDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexDirection)
                if kvp.Key = View._PositionAttribKey.KeyValue then 
                    prevPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexPosition)
                if kvp.Key = View._WrapAttribKey.KeyValue then 
                    prevWrapOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexWrap)
                if kvp.Key = View._JustifyContentAttribKey.KeyValue then 
                    prevJustifyContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexJustify)
                if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevAlignContentOpt, currAlignContentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AlignContent <-  currValue
        | ValueSome _, ValueNone -> target.AlignContent <- Unchecked.defaultof<Xamarin.Forms.FlexAlignContent>
        | ValueNone, ValueNone -> ()
        match prevAlignItemsOpt, currAlignItemsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AlignItems <-  currValue
        | ValueSome _, ValueNone -> target.AlignItems <- Unchecked.defaultof<Xamarin.Forms.FlexAlignItems>
        | ValueNone, ValueNone -> ()
        match prevFlexLayoutDirectionOpt, currFlexLayoutDirectionOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Direction <-  currValue
        | ValueSome _, ValueNone -> target.Direction <- Unchecked.defaultof<Xamarin.Forms.FlexDirection>
        | ValueNone, ValueNone -> ()
        match prevPositionOpt, currPositionOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Position <-  currValue
        | ValueSome _, ValueNone -> target.Position <- Unchecked.defaultof<Xamarin.Forms.FlexPosition>
        | ValueNone, ValueNone -> ()
        match prevWrapOpt, currWrapOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Wrap <-  currValue
        | ValueSome _, ValueNone -> target.Wrap <- Unchecked.defaultof<Xamarin.Forms.FlexWrap>
        | ValueNone, ValueNone -> ()
        match prevJustifyContentOpt, currJustifyContentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.JustifyContent <-  currValue
        | ValueSome _, ValueNone -> target.JustifyContent <- Unchecked.defaultof<Xamarin.Forms.FlexJustify>
        | ValueNone, ValueNone -> ()
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignSelf>(View._FlexAlignSelfAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignSelf>(View._FlexAlignSelfAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetAlignSelf(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetAlignSelf(targetChild, Unchecked.defaultof<Xamarin.Forms.FlexAlignSelf>)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(View._FlexOrderAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(View._FlexOrderAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetOrder(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetOrder(targetChild, 0)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.FlexBasis>(View._FlexBasisAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.FlexBasis>(View._FlexBasisAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetBasis(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetBasis(targetChild, Unchecked.defaultof<Xamarin.Forms.FlexBasis>)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<single>(View._FlexGrowAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<single>(View._FlexGrowAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetGrow(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetGrow(targetChild, 0.0f)
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<single>(View._FlexShrinkAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<single>(View._FlexShrinkAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetShrink(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetShrink(targetChild, 1.0f)
                | _ -> ()
                ())
            canReuseChild
            updateChild

    /// Describes a FlexLayout in the view
    static member inline FlexLayout(?alignContent: Xamarin.Forms.FlexAlignContent,
                                    ?alignItems: Xamarin.Forms.FlexAlignItems,
                                    ?direction: Xamarin.Forms.FlexDirection,
                                    ?position: Xamarin.Forms.FlexPosition,
                                    ?wrap: Xamarin.Forms.FlexWrap,
                                    ?justifyContent: Xamarin.Forms.FlexJustify,
                                    ?children: ViewElement list,
                                    ?isClippedToBounds: bool,
                                    ?padding: obj,
                                    ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                    ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                    ?margin: obj,
                                    ?gestureRecognizers: ViewElement list,
                                    ?anchorX: double,
                                    ?anchorY: double,
                                    ?backgroundColor: Xamarin.Forms.Color,
                                    ?heightRequest: double,
                                    ?inputTransparent: bool,
                                    ?isEnabled: bool,
                                    ?isVisible: bool,
                                    ?minimumHeightRequest: double,
                                    ?minimumWidthRequest: double,
                                    ?opacity: double,
                                    ?rotation: double,
                                    ?rotationX: double,
                                    ?rotationY: double,
                                    ?scale: double,
                                    ?style: Xamarin.Forms.Style,
                                    ?styleClass: obj,
                                    ?translationX: double,
                                    ?translationY: double,
                                    ?widthRequest: double,
                                    ?resources: (string * obj) list,
                                    ?styles: Xamarin.Forms.Style list,
                                    ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                    ?isTabStop: bool,
                                    ?scaleX: double,
                                    ?scaleY: double,
                                    ?tabIndex: int,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?automationId: string,
                                    ?created: (Xamarin.Forms.FlexLayout -> unit),
                                    ?ref: ViewRef<Xamarin.Forms.FlexLayout>) = 

        let attribBuilder = View.BuildFlexLayout(0,
                               ?alignContent=alignContent,
                               ?alignItems=alignItems,
                               ?direction=direction,
                               ?position=position,
                               ?wrap=wrap,
                               ?justifyContent=justifyContent,
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
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.FlexLayout> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.FlexLayout>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.FlexLayout>(View.CreateFuncFlexLayout, View.UpdateFuncFlexLayout, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoFlexLayout : ViewElement option = None with get, set

    /// Builds the attributes for a TemplatedView in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildTemplatedView(attribCount: int,
                                            ?isClippedToBounds: bool,
                                            ?padding: obj,
                                            ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                            ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                            ?margin: obj,
                                            ?gestureRecognizers: ViewElement list,
                                            ?anchorX: double,
                                            ?anchorY: double,
                                            ?backgroundColor: Xamarin.Forms.Color,
                                            ?heightRequest: double,
                                            ?inputTransparent: bool,
                                            ?isEnabled: bool,
                                            ?isVisible: bool,
                                            ?minimumHeightRequest: double,
                                            ?minimumWidthRequest: double,
                                            ?opacity: double,
                                            ?rotation: double,
                                            ?rotationX: double,
                                            ?rotationY: double,
                                            ?scale: double,
                                            ?style: Xamarin.Forms.Style,
                                            ?styleClass: obj,
                                            ?translationX: double,
                                            ?translationY: double,
                                            ?widthRequest: double,
                                            ?resources: (string * obj) list,
                                            ?styles: Xamarin.Forms.Style list,
                                            ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                            ?isTabStop: bool,
                                            ?scaleX: double,
                                            ?scaleY: double,
                                            ?tabIndex: int,
                                            ?classId: string,
                                            ?styleId: string,
                                            ?automationId: string,
                                            ?created: obj -> unit,
                                            ?ref: ViewRef) = 
        let attribBuilder = View.BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncTemplatedView : (unit -> Xamarin.Forms.TemplatedView) = (fun () -> View.CreateTemplatedView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateTemplatedView () : Xamarin.Forms.TemplatedView = 
        upcast (new Xamarin.Forms.TemplatedView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncTemplatedView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TemplatedView) -> View.UpdateTemplatedView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateTemplatedView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.TemplatedView) = 
        // update the inherited Layout element
        let baseElement = (if View.ProtoLayout.IsNone then View.ProtoLayout <- Some (View.Layout())); View.ProtoLayout.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        ignore prevOpt
        ignore curr
        ignore target

    /// Describes a TemplatedView in the view
    static member inline TemplatedView(?isClippedToBounds: bool,
                                       ?padding: obj,
                                       ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                       ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                       ?margin: obj,
                                       ?gestureRecognizers: ViewElement list,
                                       ?anchorX: double,
                                       ?anchorY: double,
                                       ?backgroundColor: Xamarin.Forms.Color,
                                       ?heightRequest: double,
                                       ?inputTransparent: bool,
                                       ?isEnabled: bool,
                                       ?isVisible: bool,
                                       ?minimumHeightRequest: double,
                                       ?minimumWidthRequest: double,
                                       ?opacity: double,
                                       ?rotation: double,
                                       ?rotationX: double,
                                       ?rotationY: double,
                                       ?scale: double,
                                       ?style: Xamarin.Forms.Style,
                                       ?styleClass: obj,
                                       ?translationX: double,
                                       ?translationY: double,
                                       ?widthRequest: double,
                                       ?resources: (string * obj) list,
                                       ?styles: Xamarin.Forms.Style list,
                                       ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                       ?isTabStop: bool,
                                       ?scaleX: double,
                                       ?scaleY: double,
                                       ?tabIndex: int,
                                       ?classId: string,
                                       ?styleId: string,
                                       ?automationId: string,
                                       ?created: (Xamarin.Forms.TemplatedView -> unit),
                                       ?ref: ViewRef<Xamarin.Forms.TemplatedView>) = 

        let attribBuilder = View.BuildTemplatedView(0,
                               ?isClippedToBounds=isClippedToBounds,
                               ?padding=padding,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.TemplatedView> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.TemplatedView>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.TemplatedView>(View.CreateFuncTemplatedView, View.UpdateFuncTemplatedView, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoTemplatedView : ViewElement option = None with get, set

    /// Builds the attributes for a ContentView in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildContentView(attribCount: int,
                                          ?content: ViewElement,
                                          ?isClippedToBounds: bool,
                                          ?padding: obj,
                                          ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                          ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                          ?margin: obj,
                                          ?gestureRecognizers: ViewElement list,
                                          ?anchorX: double,
                                          ?anchorY: double,
                                          ?backgroundColor: Xamarin.Forms.Color,
                                          ?heightRequest: double,
                                          ?inputTransparent: bool,
                                          ?isEnabled: bool,
                                          ?isVisible: bool,
                                          ?minimumHeightRequest: double,
                                          ?minimumWidthRequest: double,
                                          ?opacity: double,
                                          ?rotation: double,
                                          ?rotationX: double,
                                          ?rotationY: double,
                                          ?scale: double,
                                          ?style: Xamarin.Forms.Style,
                                          ?styleClass: obj,
                                          ?translationX: double,
                                          ?translationY: double,
                                          ?widthRequest: double,
                                          ?resources: (string * obj) list,
                                          ?styles: Xamarin.Forms.Style list,
                                          ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                          ?isTabStop: bool,
                                          ?scaleX: double,
                                          ?scaleY: double,
                                          ?tabIndex: int,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?automationId: string,
                                          ?created: obj -> unit,
                                          ?ref: ViewRef) = 

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildTemplatedView(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match content with None -> () | Some v -> attribBuilder.Add(View._ContentAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncContentView : (unit -> Xamarin.Forms.ContentView) = (fun () -> View.CreateContentView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateContentView () : Xamarin.Forms.ContentView = 
        upcast (new Xamarin.Forms.ContentView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncContentView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ContentView) -> View.UpdateContentView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateContentView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ContentView) = 
        // update the inherited TemplatedView element
        let baseElement = (if View.ProtoTemplatedView.IsNone then View.ProtoTemplatedView <- Some (View.TemplatedView())); View.ProtoTemplatedView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevContentOpt = ValueNone
        let mutable currContentOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ContentAttribKey.KeyValue then 
                currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ContentAttribKey.KeyValue then 
                    prevContentOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevContentOpt, currContentOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.Content)
        | _, ValueSome newValue ->
            target.Content <- (newValue.Create() :?> Xamarin.Forms.View)
        | ValueSome _, ValueNone ->
            target.Content <- null
        | ValueNone, ValueNone -> ()

    /// Describes a ContentView in the view
    static member inline ContentView(?content: ViewElement,
                                     ?isClippedToBounds: bool,
                                     ?padding: obj,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: (Xamarin.Forms.ContentView -> unit),
                                     ?ref: ViewRef<Xamarin.Forms.ContentView>) = 

        let attribBuilder = View.BuildContentView(0,
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
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ContentView> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ContentView>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ContentView>(View.CreateFuncContentView, View.UpdateFuncContentView, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoContentView : ViewElement option = None with get, set

    /// Builds the attributes for a DatePicker in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildDatePicker(attribCount: int,
                                         ?date: System.DateTime,
                                         ?format: string,
                                         ?minimumDate: System.DateTime,
                                         ?maximumDate: System.DateTime,
                                         ?dateSelected: Xamarin.Forms.DateChangedEventArgs -> unit,
                                         ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                         ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                         ?margin: obj,
                                         ?gestureRecognizers: ViewElement list,
                                         ?anchorX: double,
                                         ?anchorY: double,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?heightRequest: double,
                                         ?inputTransparent: bool,
                                         ?isEnabled: bool,
                                         ?isVisible: bool,
                                         ?minimumHeightRequest: double,
                                         ?minimumWidthRequest: double,
                                         ?opacity: double,
                                         ?rotation: double,
                                         ?rotationX: double,
                                         ?rotationY: double,
                                         ?scale: double,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: obj,
                                         ?translationX: double,
                                         ?translationY: double,
                                         ?widthRequest: double,
                                         ?resources: (string * obj) list,
                                         ?styles: Xamarin.Forms.Style list,
                                         ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                         ?isTabStop: bool,
                                         ?scaleX: double,
                                         ?scaleY: double,
                                         ?tabIndex: int,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?automationId: string,
                                         ?created: obj -> unit,
                                         ?ref: ViewRef) = 

        let attribCount = match date with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match format with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match minimumDate with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match maximumDate with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match dateSelected with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match date with None -> () | Some v -> attribBuilder.Add(View._DateAttribKey, (v)) 
        match format with None -> () | Some v -> attribBuilder.Add(View._FormatAttribKey, (v)) 
        match minimumDate with None -> () | Some v -> attribBuilder.Add(View._MinimumDateAttribKey, (v)) 
        match maximumDate with None -> () | Some v -> attribBuilder.Add(View._MaximumDateAttribKey, (v)) 
        match dateSelected with None -> () | Some v -> attribBuilder.Add(View._DateSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncDatePicker : (unit -> Xamarin.Forms.DatePicker) = (fun () -> View.CreateDatePicker())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateDatePicker () : Xamarin.Forms.DatePicker = 
        upcast (new Xamarin.Forms.DatePicker())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncDatePicker = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.DatePicker) -> View.UpdateDatePicker (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateDatePicker (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.DatePicker) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevDateOpt = ValueNone
        let mutable currDateOpt = ValueNone
        let mutable prevFormatOpt = ValueNone
        let mutable currFormatOpt = ValueNone
        let mutable prevMinimumDateOpt = ValueNone
        let mutable currMinimumDateOpt = ValueNone
        let mutable prevMaximumDateOpt = ValueNone
        let mutable currMaximumDateOpt = ValueNone
        let mutable prevDateSelectedOpt = ValueNone
        let mutable currDateSelectedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._DateAttribKey.KeyValue then 
                currDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
            if kvp.Key = View._FormatAttribKey.KeyValue then 
                currFormatOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._MinimumDateAttribKey.KeyValue then 
                currMinimumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
            if kvp.Key = View._MaximumDateAttribKey.KeyValue then 
                currMaximumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
            if kvp.Key = View._DateSelectedAttribKey.KeyValue then 
                currDateSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._DateAttribKey.KeyValue then 
                    prevDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = View._FormatAttribKey.KeyValue then 
                    prevFormatOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._MinimumDateAttribKey.KeyValue then 
                    prevMinimumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = View._MaximumDateAttribKey.KeyValue then 
                    prevMaximumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = View._DateSelectedAttribKey.KeyValue then 
                    prevDateSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>)
        match prevDateOpt, currDateOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Date <-  currValue
        | ValueSome _, ValueNone -> target.Date <- Unchecked.defaultof<System.DateTime>
        | ValueNone, ValueNone -> ()
        match prevFormatOpt, currFormatOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Format <-  currValue
        | ValueSome _, ValueNone -> target.Format <- "d"
        | ValueNone, ValueNone -> ()
        match prevMinimumDateOpt, currMinimumDateOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MinimumDate <-  currValue
        | ValueSome _, ValueNone -> target.MinimumDate <- new System.DateTime(1900, 1, 1)
        | ValueNone, ValueNone -> ()
        match prevMaximumDateOpt, currMaximumDateOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MaximumDate <-  currValue
        | ValueSome _, ValueNone -> target.MaximumDate <- new System.DateTime(2100, 12, 31)
        | ValueNone, ValueNone -> ()
        match prevDateSelectedOpt, currDateSelectedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.DateSelected.RemoveHandler(prevValue); target.DateSelected.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.DateSelected.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.DateSelected.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a DatePicker in the view
    static member inline DatePicker(?date: System.DateTime,
                                    ?format: string,
                                    ?minimumDate: System.DateTime,
                                    ?maximumDate: System.DateTime,
                                    ?dateSelected: Xamarin.Forms.DateChangedEventArgs -> unit,
                                    ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                    ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                    ?margin: obj,
                                    ?gestureRecognizers: ViewElement list,
                                    ?anchorX: double,
                                    ?anchorY: double,
                                    ?backgroundColor: Xamarin.Forms.Color,
                                    ?heightRequest: double,
                                    ?inputTransparent: bool,
                                    ?isEnabled: bool,
                                    ?isVisible: bool,
                                    ?minimumHeightRequest: double,
                                    ?minimumWidthRequest: double,
                                    ?opacity: double,
                                    ?rotation: double,
                                    ?rotationX: double,
                                    ?rotationY: double,
                                    ?scale: double,
                                    ?style: Xamarin.Forms.Style,
                                    ?styleClass: obj,
                                    ?translationX: double,
                                    ?translationY: double,
                                    ?widthRequest: double,
                                    ?resources: (string * obj) list,
                                    ?styles: Xamarin.Forms.Style list,
                                    ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                    ?isTabStop: bool,
                                    ?scaleX: double,
                                    ?scaleY: double,
                                    ?tabIndex: int,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?automationId: string,
                                    ?created: (Xamarin.Forms.DatePicker -> unit),
                                    ?ref: ViewRef<Xamarin.Forms.DatePicker>) = 

        let attribBuilder = View.BuildDatePicker(0,
                               ?date=date,
                               ?format=format,
                               ?minimumDate=minimumDate,
                               ?maximumDate=maximumDate,
                               ?dateSelected=dateSelected,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.DatePicker> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.DatePicker>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.DatePicker>(View.CreateFuncDatePicker, View.UpdateFuncDatePicker, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoDatePicker : ViewElement option = None with get, set

    /// Builds the attributes for a Picker in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildPicker(attribCount: int,
                                     ?itemsSource: seq<'T>,
                                     ?selectedIndex: int,
                                     ?title: string,
                                     ?textColor: Xamarin.Forms.Color,
                                     ?selectedIndexChanged: (int * 'T option) -> unit,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: obj -> unit,
                                     ?ref: ViewRef) = 

        let attribCount = match itemsSource with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectedIndex with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match title with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectedIndexChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match itemsSource with None -> () | Some v -> attribBuilder.Add(View._PickerItemsSourceAttribKey, seqToIListUntyped(v)) 
        match selectedIndex with None -> () | Some v -> attribBuilder.Add(View._SelectedIndexAttribKey, (v)) 
        match title with None -> () | Some v -> attribBuilder.Add(View._TitleAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(View._TextColorAttribKey, (v)) 
        match selectedIndexChanged with None -> () | Some v -> attribBuilder.Add(View._SelectedIndexChangedAttribKey, (fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncPicker : (unit -> Xamarin.Forms.Picker) = (fun () -> View.CreatePicker())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreatePicker () : Xamarin.Forms.Picker = 
        upcast (new Xamarin.Forms.Picker())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncPicker = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Picker) -> View.UpdatePicker (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdatePicker (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Picker) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevPickerItemsSourceOpt = ValueNone
        let mutable currPickerItemsSourceOpt = ValueNone
        let mutable prevSelectedIndexOpt = ValueNone
        let mutable currSelectedIndexOpt = ValueNone
        let mutable prevTitleOpt = ValueNone
        let mutable currTitleOpt = ValueNone
        let mutable prevTextColorOpt = ValueNone
        let mutable currTextColorOpt = ValueNone
        let mutable prevSelectedIndexChangedOpt = ValueNone
        let mutable currSelectedIndexChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._PickerItemsSourceAttribKey.KeyValue then 
                currPickerItemsSourceOpt <- ValueSome (kvp.Value :?> System.Collections.IList)
            if kvp.Key = View._SelectedIndexAttribKey.KeyValue then 
                currSelectedIndexOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._TitleAttribKey.KeyValue then 
                currTitleOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._SelectedIndexChangedAttribKey.KeyValue then 
                currSelectedIndexChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._PickerItemsSourceAttribKey.KeyValue then 
                    prevPickerItemsSourceOpt <- ValueSome (kvp.Value :?> System.Collections.IList)
                if kvp.Key = View._SelectedIndexAttribKey.KeyValue then 
                    prevSelectedIndexOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._TitleAttribKey.KeyValue then 
                    prevTitleOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._SelectedIndexChangedAttribKey.KeyValue then 
                    prevSelectedIndexChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevPickerItemsSourceOpt, currPickerItemsSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ItemsSource <-  currValue
        | ValueSome _, ValueNone -> target.ItemsSource <- null
        | ValueNone, ValueNone -> ()
        match prevSelectedIndexOpt, currSelectedIndexOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SelectedIndex <-  currValue
        | ValueSome _, ValueNone -> target.SelectedIndex <- 0
        | ValueNone, ValueNone -> ()
        match prevTitleOpt, currTitleOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Title <-  currValue
        | ValueSome _, ValueNone -> target.Title <- null
        | ValueNone, ValueNone -> ()
        match prevTextColorOpt, currTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextColor <-  currValue
        | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevSelectedIndexChangedOpt, currSelectedIndexChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.SelectedIndexChanged.RemoveHandler(prevValue); target.SelectedIndexChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.SelectedIndexChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.SelectedIndexChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a Picker in the view
    static member inline Picker(?itemsSource: seq<'T>,
                                ?selectedIndex: int,
                                ?title: string,
                                ?textColor: Xamarin.Forms.Color,
                                ?selectedIndexChanged: (int * 'T option) -> unit,
                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                ?margin: obj,
                                ?gestureRecognizers: ViewElement list,
                                ?anchorX: double,
                                ?anchorY: double,
                                ?backgroundColor: Xamarin.Forms.Color,
                                ?heightRequest: double,
                                ?inputTransparent: bool,
                                ?isEnabled: bool,
                                ?isVisible: bool,
                                ?minimumHeightRequest: double,
                                ?minimumWidthRequest: double,
                                ?opacity: double,
                                ?rotation: double,
                                ?rotationX: double,
                                ?rotationY: double,
                                ?scale: double,
                                ?style: Xamarin.Forms.Style,
                                ?styleClass: obj,
                                ?translationX: double,
                                ?translationY: double,
                                ?widthRequest: double,
                                ?resources: (string * obj) list,
                                ?styles: Xamarin.Forms.Style list,
                                ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                ?isTabStop: bool,
                                ?scaleX: double,
                                ?scaleY: double,
                                ?tabIndex: int,
                                ?classId: string,
                                ?styleId: string,
                                ?automationId: string,
                                ?created: (Xamarin.Forms.Picker -> unit),
                                ?ref: ViewRef<Xamarin.Forms.Picker>) = 

        let attribBuilder = View.BuildPicker(0,
                               ?itemsSource=itemsSource,
                               ?selectedIndex=selectedIndex,
                               ?title=title,
                               ?textColor=textColor,
                               ?selectedIndexChanged=selectedIndexChanged,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Picker> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Picker>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Picker>(View.CreateFuncPicker, View.UpdateFuncPicker, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoPicker : ViewElement option = None with get, set

    /// Builds the attributes for a Frame in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildFrame(attribCount: int,
                                    ?borderColor: Xamarin.Forms.Color,
                                    ?cornerRadius: double,
                                    ?hasShadow: bool,
                                    ?content: ViewElement,
                                    ?isClippedToBounds: bool,
                                    ?padding: obj,
                                    ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                    ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                    ?margin: obj,
                                    ?gestureRecognizers: ViewElement list,
                                    ?anchorX: double,
                                    ?anchorY: double,
                                    ?backgroundColor: Xamarin.Forms.Color,
                                    ?heightRequest: double,
                                    ?inputTransparent: bool,
                                    ?isEnabled: bool,
                                    ?isVisible: bool,
                                    ?minimumHeightRequest: double,
                                    ?minimumWidthRequest: double,
                                    ?opacity: double,
                                    ?rotation: double,
                                    ?rotationX: double,
                                    ?rotationY: double,
                                    ?scale: double,
                                    ?style: Xamarin.Forms.Style,
                                    ?styleClass: obj,
                                    ?translationX: double,
                                    ?translationY: double,
                                    ?widthRequest: double,
                                    ?resources: (string * obj) list,
                                    ?styles: Xamarin.Forms.Style list,
                                    ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                    ?isTabStop: bool,
                                    ?scaleX: double,
                                    ?scaleY: double,
                                    ?tabIndex: int,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?automationId: string,
                                    ?created: obj -> unit,
                                    ?ref: ViewRef) = 

        let attribCount = match borderColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasShadow with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildContentView(attribCount, ?content=content, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match borderColor with None -> () | Some v -> attribBuilder.Add(View._BorderColorAttribKey, (v)) 
        match cornerRadius with None -> () | Some v -> attribBuilder.Add(View._FrameCornerRadiusAttribKey, single(v)) 
        match hasShadow with None -> () | Some v -> attribBuilder.Add(View._HasShadowAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncFrame : (unit -> Xamarin.Forms.Frame) = (fun () -> View.CreateFrame())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateFrame () : Xamarin.Forms.Frame = 
        upcast (new Xamarin.Forms.Frame())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncFrame = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Frame) -> View.UpdateFrame (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateFrame (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Frame) = 
        // update the inherited ContentView element
        let baseElement = (if View.ProtoContentView.IsNone then View.ProtoContentView <- Some (View.ContentView())); View.ProtoContentView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevBorderColorOpt = ValueNone
        let mutable currBorderColorOpt = ValueNone
        let mutable prevFrameCornerRadiusOpt = ValueNone
        let mutable currFrameCornerRadiusOpt = ValueNone
        let mutable prevHasShadowOpt = ValueNone
        let mutable currHasShadowOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._BorderColorAttribKey.KeyValue then 
                currBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._FrameCornerRadiusAttribKey.KeyValue then 
                currFrameCornerRadiusOpt <- ValueSome (kvp.Value :?> single)
            if kvp.Key = View._HasShadowAttribKey.KeyValue then 
                currHasShadowOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._BorderColorAttribKey.KeyValue then 
                    prevBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._FrameCornerRadiusAttribKey.KeyValue then 
                    prevFrameCornerRadiusOpt <- ValueSome (kvp.Value :?> single)
                if kvp.Key = View._HasShadowAttribKey.KeyValue then 
                    prevHasShadowOpt <- ValueSome (kvp.Value :?> bool)
        match prevBorderColorOpt, currBorderColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BorderColor <-  currValue
        | ValueSome _, ValueNone -> target.BorderColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevFrameCornerRadiusOpt, currFrameCornerRadiusOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CornerRadius <-  currValue
        | ValueSome _, ValueNone -> target.CornerRadius <- -1.0f
        | ValueNone, ValueNone -> ()
        match prevHasShadowOpt, currHasShadowOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HasShadow <-  currValue
        | ValueSome _, ValueNone -> target.HasShadow <- true
        | ValueNone, ValueNone -> ()

    /// Describes a Frame in the view
    static member inline Frame(?borderColor: Xamarin.Forms.Color,
                               ?cornerRadius: double,
                               ?hasShadow: bool,
                               ?content: ViewElement,
                               ?isClippedToBounds: bool,
                               ?padding: obj,
                               ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                               ?verticalOptions: Xamarin.Forms.LayoutOptions,
                               ?margin: obj,
                               ?gestureRecognizers: ViewElement list,
                               ?anchorX: double,
                               ?anchorY: double,
                               ?backgroundColor: Xamarin.Forms.Color,
                               ?heightRequest: double,
                               ?inputTransparent: bool,
                               ?isEnabled: bool,
                               ?isVisible: bool,
                               ?minimumHeightRequest: double,
                               ?minimumWidthRequest: double,
                               ?opacity: double,
                               ?rotation: double,
                               ?rotationX: double,
                               ?rotationY: double,
                               ?scale: double,
                               ?style: Xamarin.Forms.Style,
                               ?styleClass: obj,
                               ?translationX: double,
                               ?translationY: double,
                               ?widthRequest: double,
                               ?resources: (string * obj) list,
                               ?styles: Xamarin.Forms.Style list,
                               ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                               ?isTabStop: bool,
                               ?scaleX: double,
                               ?scaleY: double,
                               ?tabIndex: int,
                               ?classId: string,
                               ?styleId: string,
                               ?automationId: string,
                               ?created: (Xamarin.Forms.Frame -> unit),
                               ?ref: ViewRef<Xamarin.Forms.Frame>) = 

        let attribBuilder = View.BuildFrame(0,
                               ?borderColor=borderColor,
                               ?cornerRadius=cornerRadius,
                               ?hasShadow=hasShadow,
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
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Frame> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Frame>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Frame>(View.CreateFuncFrame, View.UpdateFuncFrame, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoFrame : ViewElement option = None with get, set

    /// Builds the attributes for a Image in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildImage(attribCount: int,
                                    ?source: obj,
                                    ?aspect: Xamarin.Forms.Aspect,
                                    ?isOpaque: bool,
                                    ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                    ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                    ?margin: obj,
                                    ?gestureRecognizers: ViewElement list,
                                    ?anchorX: double,
                                    ?anchorY: double,
                                    ?backgroundColor: Xamarin.Forms.Color,
                                    ?heightRequest: double,
                                    ?inputTransparent: bool,
                                    ?isEnabled: bool,
                                    ?isVisible: bool,
                                    ?minimumHeightRequest: double,
                                    ?minimumWidthRequest: double,
                                    ?opacity: double,
                                    ?rotation: double,
                                    ?rotationX: double,
                                    ?rotationY: double,
                                    ?scale: double,
                                    ?style: Xamarin.Forms.Style,
                                    ?styleClass: obj,
                                    ?translationX: double,
                                    ?translationY: double,
                                    ?widthRequest: double,
                                    ?resources: (string * obj) list,
                                    ?styles: Xamarin.Forms.Style list,
                                    ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                    ?isTabStop: bool,
                                    ?scaleX: double,
                                    ?scaleY: double,
                                    ?tabIndex: int,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?automationId: string,
                                    ?created: obj -> unit,
                                    ?ref: ViewRef) = 

        let attribCount = match source with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match aspect with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isOpaque with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match source with None -> () | Some v -> attribBuilder.Add(View._ImageSourceAttribKey, (v)) 
        match aspect with None -> () | Some v -> attribBuilder.Add(View._AspectAttribKey, (v)) 
        match isOpaque with None -> () | Some v -> attribBuilder.Add(View._IsOpaqueAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncImage : (unit -> Xamarin.Forms.Image) = (fun () -> View.CreateImage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateImage () : Xamarin.Forms.Image = 
        upcast (new Xamarin.Forms.Image())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncImage = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Image) -> View.UpdateImage (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateImage (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Image) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevImageSourceOpt = ValueNone
        let mutable currImageSourceOpt = ValueNone
        let mutable prevAspectOpt = ValueNone
        let mutable currAspectOpt = ValueNone
        let mutable prevIsOpaqueOpt = ValueNone
        let mutable currIsOpaqueOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ImageSourceAttribKey.KeyValue then 
                currImageSourceOpt <- ValueSome (kvp.Value :?> obj)
            if kvp.Key = View._AspectAttribKey.KeyValue then 
                currAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
            if kvp.Key = View._IsOpaqueAttribKey.KeyValue then 
                currIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ImageSourceAttribKey.KeyValue then 
                    prevImageSourceOpt <- ValueSome (kvp.Value :?> obj)
                if kvp.Key = View._AspectAttribKey.KeyValue then 
                    prevAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
                if kvp.Key = View._IsOpaqueAttribKey.KeyValue then 
                    prevIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
        match prevImageSourceOpt, currImageSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Source <- makeImageSource currValue
        | ValueSome _, ValueNone -> target.Source <- null
        | ValueNone, ValueNone -> ()
        match prevAspectOpt, currAspectOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Aspect <-  currValue
        | ValueSome _, ValueNone -> target.Aspect <- Xamarin.Forms.Aspect.AspectFit
        | ValueNone, ValueNone -> ()
        match prevIsOpaqueOpt, currIsOpaqueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsOpaque <-  currValue
        | ValueSome _, ValueNone -> target.IsOpaque <- true
        | ValueNone, ValueNone -> ()

    /// Describes a Image in the view
    static member inline Image(?source: obj,
                               ?aspect: Xamarin.Forms.Aspect,
                               ?isOpaque: bool,
                               ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                               ?verticalOptions: Xamarin.Forms.LayoutOptions,
                               ?margin: obj,
                               ?gestureRecognizers: ViewElement list,
                               ?anchorX: double,
                               ?anchorY: double,
                               ?backgroundColor: Xamarin.Forms.Color,
                               ?heightRequest: double,
                               ?inputTransparent: bool,
                               ?isEnabled: bool,
                               ?isVisible: bool,
                               ?minimumHeightRequest: double,
                               ?minimumWidthRequest: double,
                               ?opacity: double,
                               ?rotation: double,
                               ?rotationX: double,
                               ?rotationY: double,
                               ?scale: double,
                               ?style: Xamarin.Forms.Style,
                               ?styleClass: obj,
                               ?translationX: double,
                               ?translationY: double,
                               ?widthRequest: double,
                               ?resources: (string * obj) list,
                               ?styles: Xamarin.Forms.Style list,
                               ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                               ?isTabStop: bool,
                               ?scaleX: double,
                               ?scaleY: double,
                               ?tabIndex: int,
                               ?classId: string,
                               ?styleId: string,
                               ?automationId: string,
                               ?created: (Xamarin.Forms.Image -> unit),
                               ?ref: ViewRef<Xamarin.Forms.Image>) = 

        let attribBuilder = View.BuildImage(0,
                               ?source=source,
                               ?aspect=aspect,
                               ?isOpaque=isOpaque,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Image> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Image>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Image>(View.CreateFuncImage, View.UpdateFuncImage, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoImage : ViewElement option = None with get, set

    /// Builds the attributes for a ImageButton in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildImageButton(attribCount: int,
                                          ?command: unit -> unit,
                                          ?source: obj,
                                          ?aspect: Xamarin.Forms.Aspect,
                                          ?borderColor: Xamarin.Forms.Color,
                                          ?borderWidth: double,
                                          ?cornerRadius: int,
                                          ?isOpaque: bool,
                                          ?padding: Xamarin.Forms.Thickness,
                                          ?clicked: System.EventArgs -> unit,
                                          ?pressed: System.EventArgs -> unit,
                                          ?released: System.EventArgs -> unit,
                                          ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                          ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                          ?margin: obj,
                                          ?gestureRecognizers: ViewElement list,
                                          ?anchorX: double,
                                          ?anchorY: double,
                                          ?backgroundColor: Xamarin.Forms.Color,
                                          ?heightRequest: double,
                                          ?inputTransparent: bool,
                                          ?isEnabled: bool,
                                          ?isVisible: bool,
                                          ?minimumHeightRequest: double,
                                          ?minimumWidthRequest: double,
                                          ?opacity: double,
                                          ?rotation: double,
                                          ?rotationX: double,
                                          ?rotationY: double,
                                          ?scale: double,
                                          ?style: Xamarin.Forms.Style,
                                          ?styleClass: obj,
                                          ?translationX: double,
                                          ?translationY: double,
                                          ?widthRequest: double,
                                          ?resources: (string * obj) list,
                                          ?styles: Xamarin.Forms.Style list,
                                          ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                          ?isTabStop: bool,
                                          ?scaleX: double,
                                          ?scaleY: double,
                                          ?tabIndex: int,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?automationId: string,
                                          ?created: obj -> unit,
                                          ?ref: ViewRef) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match source with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match aspect with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match borderColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match borderWidth with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isOpaque with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match clicked with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match pressed with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match released with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match command with None -> () | Some v -> attribBuilder.Add(View._ImageButtonCommandAttribKey, (v)) 
        match source with None -> () | Some v -> attribBuilder.Add(View._ImageSourceAttribKey, (v)) 
        match aspect with None -> () | Some v -> attribBuilder.Add(View._AspectAttribKey, (v)) 
        match borderColor with None -> () | Some v -> attribBuilder.Add(View._BorderColorAttribKey, (v)) 
        match borderWidth with None -> () | Some v -> attribBuilder.Add(View._BorderWidthAttribKey, (v)) 
        match cornerRadius with None -> () | Some v -> attribBuilder.Add(View._ImageButtonCornerRadiusAttribKey, (v)) 
        match isOpaque with None -> () | Some v -> attribBuilder.Add(View._IsOpaqueAttribKey, (v)) 
        match padding with None -> () | Some v -> attribBuilder.Add(View._PaddingAttribKey, (v)) 
        match clicked with None -> () | Some v -> attribBuilder.Add(View._ClickedAttribKey, (fun f -> System.EventHandler(fun _sender args -> f args))(v)) 
        match pressed with None -> () | Some v -> attribBuilder.Add(View._PressedAttribKey, (fun f -> System.EventHandler(fun _sender args -> f args))(v)) 
        match released with None -> () | Some v -> attribBuilder.Add(View._ReleasedAttribKey, (fun f -> System.EventHandler(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncImageButton : (unit -> Xamarin.Forms.ImageButton) = (fun () -> View.CreateImageButton())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateImageButton () : Xamarin.Forms.ImageButton = 
        upcast (new Xamarin.Forms.ImageButton())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncImageButton = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ImageButton) -> View.UpdateImageButton (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateImageButton (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ImageButton) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevImageButtonCommandOpt = ValueNone
        let mutable currImageButtonCommandOpt = ValueNone
        let mutable prevImageSourceOpt = ValueNone
        let mutable currImageSourceOpt = ValueNone
        let mutable prevAspectOpt = ValueNone
        let mutable currAspectOpt = ValueNone
        let mutable prevBorderColorOpt = ValueNone
        let mutable currBorderColorOpt = ValueNone
        let mutable prevBorderWidthOpt = ValueNone
        let mutable currBorderWidthOpt = ValueNone
        let mutable prevImageButtonCornerRadiusOpt = ValueNone
        let mutable currImageButtonCornerRadiusOpt = ValueNone
        let mutable prevIsOpaqueOpt = ValueNone
        let mutable currIsOpaqueOpt = ValueNone
        let mutable prevPaddingOpt = ValueNone
        let mutable currPaddingOpt = ValueNone
        let mutable prevClickedOpt = ValueNone
        let mutable currClickedOpt = ValueNone
        let mutable prevPressedOpt = ValueNone
        let mutable currPressedOpt = ValueNone
        let mutable prevReleasedOpt = ValueNone
        let mutable currReleasedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ImageButtonCommandAttribKey.KeyValue then 
                currImageButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
            if kvp.Key = View._ImageSourceAttribKey.KeyValue then 
                currImageSourceOpt <- ValueSome (kvp.Value :?> obj)
            if kvp.Key = View._AspectAttribKey.KeyValue then 
                currAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
            if kvp.Key = View._BorderColorAttribKey.KeyValue then 
                currBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._BorderWidthAttribKey.KeyValue then 
                currBorderWidthOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._ImageButtonCornerRadiusAttribKey.KeyValue then 
                currImageButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._IsOpaqueAttribKey.KeyValue then 
                currIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._PaddingAttribKey.KeyValue then 
                currPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
            if kvp.Key = View._ClickedAttribKey.KeyValue then 
                currClickedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = View._PressedAttribKey.KeyValue then 
                currPressedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = View._ReleasedAttribKey.KeyValue then 
                currReleasedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ImageButtonCommandAttribKey.KeyValue then 
                    prevImageButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = View._ImageSourceAttribKey.KeyValue then 
                    prevImageSourceOpt <- ValueSome (kvp.Value :?> obj)
                if kvp.Key = View._AspectAttribKey.KeyValue then 
                    prevAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
                if kvp.Key = View._BorderColorAttribKey.KeyValue then 
                    prevBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._BorderWidthAttribKey.KeyValue then 
                    prevBorderWidthOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._ImageButtonCornerRadiusAttribKey.KeyValue then 
                    prevImageButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._IsOpaqueAttribKey.KeyValue then 
                    prevIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._PaddingAttribKey.KeyValue then 
                    prevPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                if kvp.Key = View._ClickedAttribKey.KeyValue then 
                    prevClickedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = View._PressedAttribKey.KeyValue then 
                    prevPressedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = View._ReleasedAttribKey.KeyValue then 
                    prevReleasedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        (fun _ _ _ -> ()) prevImageButtonCommandOpt currImageButtonCommandOpt target
        match prevImageSourceOpt, currImageSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Source <- makeImageSource currValue
        | ValueSome _, ValueNone -> target.Source <- null
        | ValueNone, ValueNone -> ()
        match prevAspectOpt, currAspectOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Aspect <-  currValue
        | ValueSome _, ValueNone -> target.Aspect <- Xamarin.Forms.Aspect.AspectFit
        | ValueNone, ValueNone -> ()
        match prevBorderColorOpt, currBorderColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BorderColor <-  currValue
        | ValueSome _, ValueNone -> target.BorderColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevBorderWidthOpt, currBorderWidthOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BorderWidth <-  currValue
        | ValueSome _, ValueNone -> target.BorderWidth <- -1.0
        | ValueNone, ValueNone -> ()
        match prevImageButtonCornerRadiusOpt, currImageButtonCornerRadiusOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CornerRadius <-  currValue
        | ValueSome _, ValueNone -> target.CornerRadius <- -1
        | ValueNone, ValueNone -> ()
        match prevIsOpaqueOpt, currIsOpaqueOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsOpaque <-  currValue
        | ValueSome _, ValueNone -> target.IsOpaque <- true
        | ValueNone, ValueNone -> ()
        match prevPaddingOpt, currPaddingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Padding <-  currValue
        | ValueSome _, ValueNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
        | ValueNone, ValueNone -> ()
        match prevClickedOpt, currClickedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Clicked.RemoveHandler(prevValue); target.Clicked.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Clicked.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Clicked.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevPressedOpt, currPressedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Pressed.RemoveHandler(prevValue); target.Pressed.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Pressed.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Pressed.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevReleasedOpt, currReleasedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Released.RemoveHandler(prevValue); target.Released.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Released.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Released.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a ImageButton in the view
    static member inline ImageButton(?command: unit -> unit,
                                     ?source: obj,
                                     ?aspect: Xamarin.Forms.Aspect,
                                     ?borderColor: Xamarin.Forms.Color,
                                     ?borderWidth: double,
                                     ?cornerRadius: int,
                                     ?isOpaque: bool,
                                     ?padding: Xamarin.Forms.Thickness,
                                     ?clicked: System.EventArgs -> unit,
                                     ?pressed: System.EventArgs -> unit,
                                     ?released: System.EventArgs -> unit,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: (Xamarin.Forms.ImageButton -> unit),
                                     ?ref: ViewRef<Xamarin.Forms.ImageButton>) = 

        let attribBuilder = View.BuildImageButton(0,
                               ?command=command,
                               ?source=source,
                               ?aspect=aspect,
                               ?borderColor=borderColor,
                               ?borderWidth=borderWidth,
                               ?cornerRadius=cornerRadius,
                               ?isOpaque=isOpaque,
                               ?padding=padding,
                               ?clicked=clicked,
                               ?pressed=pressed,
                               ?released=released,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ImageButton> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ImageButton>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ImageButton>(View.CreateFuncImageButton, View.UpdateFuncImageButton, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoImageButton : ViewElement option = None with get, set

    /// Builds the attributes for a InputView in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildInputView(attribCount: int,
                                        ?keyboard: Xamarin.Forms.Keyboard,
                                        ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                        ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                        ?margin: obj,
                                        ?gestureRecognizers: ViewElement list,
                                        ?anchorX: double,
                                        ?anchorY: double,
                                        ?backgroundColor: Xamarin.Forms.Color,
                                        ?heightRequest: double,
                                        ?inputTransparent: bool,
                                        ?isEnabled: bool,
                                        ?isVisible: bool,
                                        ?minimumHeightRequest: double,
                                        ?minimumWidthRequest: double,
                                        ?opacity: double,
                                        ?rotation: double,
                                        ?rotationX: double,
                                        ?rotationY: double,
                                        ?scale: double,
                                        ?style: Xamarin.Forms.Style,
                                        ?styleClass: obj,
                                        ?translationX: double,
                                        ?translationY: double,
                                        ?widthRequest: double,
                                        ?resources: (string * obj) list,
                                        ?styles: Xamarin.Forms.Style list,
                                        ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                        ?isTabStop: bool,
                                        ?scaleX: double,
                                        ?scaleY: double,
                                        ?tabIndex: int,
                                        ?classId: string,
                                        ?styleId: string,
                                        ?automationId: string,
                                        ?created: obj -> unit,
                                        ?ref: ViewRef) = 

        let attribCount = match keyboard with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match keyboard with None -> () | Some v -> attribBuilder.Add(View._KeyboardAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncInputView : (unit -> Xamarin.Forms.InputView) = (fun () -> View.CreateInputView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateInputView () : Xamarin.Forms.InputView = 
        failwith "can't create Xamarin.Forms.InputView"

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncInputView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.InputView) -> View.UpdateInputView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateInputView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.InputView) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevKeyboardOpt = ValueNone
        let mutable currKeyboardOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._KeyboardAttribKey.KeyValue then 
                currKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._KeyboardAttribKey.KeyValue then 
                    prevKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
        match prevKeyboardOpt, currKeyboardOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Keyboard <-  currValue
        | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
        | ValueNone, ValueNone -> ()

    /// Describes a InputView in the view
    static member inline InputView(?keyboard: Xamarin.Forms.Keyboard,
                                   ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                   ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                   ?margin: obj,
                                   ?gestureRecognizers: ViewElement list,
                                   ?anchorX: double,
                                   ?anchorY: double,
                                   ?backgroundColor: Xamarin.Forms.Color,
                                   ?heightRequest: double,
                                   ?inputTransparent: bool,
                                   ?isEnabled: bool,
                                   ?isVisible: bool,
                                   ?minimumHeightRequest: double,
                                   ?minimumWidthRequest: double,
                                   ?opacity: double,
                                   ?rotation: double,
                                   ?rotationX: double,
                                   ?rotationY: double,
                                   ?scale: double,
                                   ?style: Xamarin.Forms.Style,
                                   ?styleClass: obj,
                                   ?translationX: double,
                                   ?translationY: double,
                                   ?widthRequest: double,
                                   ?resources: (string * obj) list,
                                   ?styles: Xamarin.Forms.Style list,
                                   ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                   ?isTabStop: bool,
                                   ?scaleX: double,
                                   ?scaleY: double,
                                   ?tabIndex: int,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?automationId: string,
                                   ?created: (Xamarin.Forms.InputView -> unit),
                                   ?ref: ViewRef<Xamarin.Forms.InputView>) = 

        let attribBuilder = View.BuildInputView(0,
                               ?keyboard=keyboard,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.InputView> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.InputView>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.InputView>(View.CreateFuncInputView, View.UpdateFuncInputView, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoInputView : ViewElement option = None with get, set

    /// Builds the attributes for a Editor in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildEditor(attribCount: int,
                                     ?text: string,
                                     ?fontSize: obj,
                                     ?fontFamily: string,
                                     ?fontAttributes: Xamarin.Forms.FontAttributes,
                                     ?textColor: Xamarin.Forms.Color,
                                     ?completed: string -> unit,
                                     ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit,
                                     ?autoSize: Xamarin.Forms.EditorAutoSizeOption,
                                     ?placeholder: string,
                                     ?placeholderColor: Xamarin.Forms.Color,
                                     ?keyboard: Xamarin.Forms.Keyboard,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: obj -> unit,
                                     ?ref: ViewRef) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontAttributes with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match completed with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textChanged with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match autoSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match placeholder with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match placeholderColor with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildInputView(attribCount, ?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(View._FontSizeAttribKey, makeFontSize(v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(View._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(View._FontAttributesAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(View._TextColorAttribKey, (v)) 
        match completed with None -> () | Some v -> attribBuilder.Add(View._EditorCompletedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(v)) 
        match textChanged with None -> () | Some v -> attribBuilder.Add(View._TextChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v)) 
        match autoSize with None -> () | Some v -> attribBuilder.Add(View._AutoSizeAttribKey, (v)) 
        match placeholder with None -> () | Some v -> attribBuilder.Add(View._PlaceholderAttribKey, (v)) 
        match placeholderColor with None -> () | Some v -> attribBuilder.Add(View._PlaceholderColorAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncEditor : (unit -> Xamarin.Forms.Editor) = (fun () -> View.CreateEditor())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateEditor () : Xamarin.Forms.Editor = 
        upcast (new Xamarin.Forms.Editor())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncEditor = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Editor) -> View.UpdateEditor (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateEditor (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Editor) = 
        // update the inherited InputView element
        let baseElement = (if View.ProtoInputView.IsNone then View.ProtoInputView <- Some (View.InputView())); View.ProtoInputView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevFontSizeOpt = ValueNone
        let mutable currFontSizeOpt = ValueNone
        let mutable prevFontFamilyOpt = ValueNone
        let mutable currFontFamilyOpt = ValueNone
        let mutable prevFontAttributesOpt = ValueNone
        let mutable currFontAttributesOpt = ValueNone
        let mutable prevTextColorOpt = ValueNone
        let mutable currTextColorOpt = ValueNone
        let mutable prevEditorCompletedOpt = ValueNone
        let mutable currEditorCompletedOpt = ValueNone
        let mutable prevTextChangedOpt = ValueNone
        let mutable currTextChangedOpt = ValueNone
        let mutable prevAutoSizeOpt = ValueNone
        let mutable currAutoSizeOpt = ValueNone
        let mutable prevPlaceholderOpt = ValueNone
        let mutable currPlaceholderOpt = ValueNone
        let mutable prevPlaceholderColorOpt = ValueNone
        let mutable currPlaceholderColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = View._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._EditorCompletedAttribKey.KeyValue then 
                currEditorCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = View._TextChangedAttribKey.KeyValue then 
                currTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
            if kvp.Key = View._AutoSizeAttribKey.KeyValue then 
                currAutoSizeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.EditorAutoSizeOption)
            if kvp.Key = View._PlaceholderAttribKey.KeyValue then 
                currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._PlaceholderColorAttribKey.KeyValue then 
                currPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = View._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._EditorCompletedAttribKey.KeyValue then 
                    prevEditorCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = View._TextChangedAttribKey.KeyValue then 
                    prevTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
                if kvp.Key = View._AutoSizeAttribKey.KeyValue then 
                    prevAutoSizeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.EditorAutoSizeOption)
                if kvp.Key = View._PlaceholderAttribKey.KeyValue then 
                    prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._PlaceholderColorAttribKey.KeyValue then 
                    prevPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevFontSizeOpt, currFontSizeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontSize <-  currValue
        | ValueSome _, ValueNone -> target.FontSize <- -1.0
        | ValueNone, ValueNone -> ()
        match prevFontFamilyOpt, currFontFamilyOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontFamily <-  currValue
        | ValueSome _, ValueNone -> target.FontFamily <- null
        | ValueNone, ValueNone -> ()
        match prevFontAttributesOpt, currFontAttributesOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontAttributes <-  currValue
        | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
        | ValueNone, ValueNone -> ()
        match prevTextColorOpt, currTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextColor <-  currValue
        | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevEditorCompletedOpt, currEditorCompletedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Completed.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevTextChangedOpt, currTextChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.TextChanged.RemoveHandler(prevValue); target.TextChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.TextChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.TextChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevAutoSizeOpt, currAutoSizeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.AutoSize <-  currValue
        | ValueSome _, ValueNone -> target.AutoSize <- Xamarin.Forms.EditorAutoSizeOption.Disabled
        | ValueNone, ValueNone -> ()
        match prevPlaceholderOpt, currPlaceholderOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Placeholder <-  currValue
        | ValueSome _, ValueNone -> target.Placeholder <- null
        | ValueNone, ValueNone -> ()
        match prevPlaceholderColorOpt, currPlaceholderColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.PlaceholderColor <-  currValue
        | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()

    /// Describes a Editor in the view
    static member inline Editor(?text: string,
                                ?fontSize: obj,
                                ?fontFamily: string,
                                ?fontAttributes: Xamarin.Forms.FontAttributes,
                                ?textColor: Xamarin.Forms.Color,
                                ?completed: string -> unit,
                                ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit,
                                ?autoSize: Xamarin.Forms.EditorAutoSizeOption,
                                ?placeholder: string,
                                ?placeholderColor: Xamarin.Forms.Color,
                                ?keyboard: Xamarin.Forms.Keyboard,
                                ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                ?margin: obj,
                                ?gestureRecognizers: ViewElement list,
                                ?anchorX: double,
                                ?anchorY: double,
                                ?backgroundColor: Xamarin.Forms.Color,
                                ?heightRequest: double,
                                ?inputTransparent: bool,
                                ?isEnabled: bool,
                                ?isVisible: bool,
                                ?minimumHeightRequest: double,
                                ?minimumWidthRequest: double,
                                ?opacity: double,
                                ?rotation: double,
                                ?rotationX: double,
                                ?rotationY: double,
                                ?scale: double,
                                ?style: Xamarin.Forms.Style,
                                ?styleClass: obj,
                                ?translationX: double,
                                ?translationY: double,
                                ?widthRequest: double,
                                ?resources: (string * obj) list,
                                ?styles: Xamarin.Forms.Style list,
                                ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                ?isTabStop: bool,
                                ?scaleX: double,
                                ?scaleY: double,
                                ?tabIndex: int,
                                ?classId: string,
                                ?styleId: string,
                                ?automationId: string,
                                ?created: (Xamarin.Forms.Editor -> unit),
                                ?ref: ViewRef<Xamarin.Forms.Editor>) = 

        let attribBuilder = View.BuildEditor(0,
                               ?text=text,
                               ?fontSize=fontSize,
                               ?fontFamily=fontFamily,
                               ?fontAttributes=fontAttributes,
                               ?textColor=textColor,
                               ?completed=completed,
                               ?textChanged=textChanged,
                               ?autoSize=autoSize,
                               ?placeholder=placeholder,
                               ?placeholderColor=placeholderColor,
                               ?keyboard=keyboard,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Editor> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Editor>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Editor>(View.CreateFuncEditor, View.UpdateFuncEditor, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoEditor : ViewElement option = None with get, set

    /// Builds the attributes for a Entry in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildEntry(attribCount: int,
                                    ?text: string,
                                    ?placeholder: string,
                                    ?horizontalTextAlignment: Xamarin.Forms.TextAlignment,
                                    ?fontSize: obj,
                                    ?fontFamily: string,
                                    ?fontAttributes: Xamarin.Forms.FontAttributes,
                                    ?textColor: Xamarin.Forms.Color,
                                    ?placeholderColor: Xamarin.Forms.Color,
                                    ?isPassword: bool,
                                    ?completed: string -> unit,
                                    ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit,
                                    ?isTextPredictionEnabled: bool,
                                    ?returnType: Xamarin.Forms.ReturnType,
                                    ?returnCommand: unit -> unit,
                                    ?cursorPosition: int,
                                    ?selectionLength: int,
                                    ?keyboard: Xamarin.Forms.Keyboard,
                                    ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                    ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                    ?margin: obj,
                                    ?gestureRecognizers: ViewElement list,
                                    ?anchorX: double,
                                    ?anchorY: double,
                                    ?backgroundColor: Xamarin.Forms.Color,
                                    ?heightRequest: double,
                                    ?inputTransparent: bool,
                                    ?isEnabled: bool,
                                    ?isVisible: bool,
                                    ?minimumHeightRequest: double,
                                    ?minimumWidthRequest: double,
                                    ?opacity: double,
                                    ?rotation: double,
                                    ?rotationX: double,
                                    ?rotationY: double,
                                    ?scale: double,
                                    ?style: Xamarin.Forms.Style,
                                    ?styleClass: obj,
                                    ?translationX: double,
                                    ?translationY: double,
                                    ?widthRequest: double,
                                    ?resources: (string * obj) list,
                                    ?styles: Xamarin.Forms.Style list,
                                    ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                    ?isTabStop: bool,
                                    ?scaleX: double,
                                    ?scaleY: double,
                                    ?tabIndex: int,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?automationId: string,
                                    ?created: obj -> unit,
                                    ?ref: ViewRef) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match placeholder with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match horizontalTextAlignment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontAttributes with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match placeholderColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isPassword with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match completed with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textChanged with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isTextPredictionEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match returnType with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match returnCommand with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cursorPosition with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectionLength with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildInputView(attribCount, ?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        match placeholder with None -> () | Some v -> attribBuilder.Add(View._PlaceholderAttribKey, (v)) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.Add(View._HorizontalTextAlignmentAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(View._FontSizeAttribKey, makeFontSize(v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(View._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(View._FontAttributesAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(View._TextColorAttribKey, (v)) 
        match placeholderColor with None -> () | Some v -> attribBuilder.Add(View._PlaceholderColorAttribKey, (v)) 
        match isPassword with None -> () | Some v -> attribBuilder.Add(View._IsPasswordAttribKey, (v)) 
        match completed with None -> () | Some v -> attribBuilder.Add(View._EntryCompletedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(v)) 
        match textChanged with None -> () | Some v -> attribBuilder.Add(View._TextChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v)) 
        match isTextPredictionEnabled with None -> () | Some v -> attribBuilder.Add(View._IsTextPredictionEnabledAttribKey, (v)) 
        match returnType with None -> () | Some v -> attribBuilder.Add(View._ReturnTypeAttribKey, (v)) 
        match returnCommand with None -> () | Some v -> attribBuilder.Add(View._ReturnCommandAttribKey, makeCommand(v)) 
        match cursorPosition with None -> () | Some v -> attribBuilder.Add(View._CursorPositionAttribKey, (v)) 
        match selectionLength with None -> () | Some v -> attribBuilder.Add(View._SelectionLengthAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncEntry : (unit -> Xamarin.Forms.Entry) = (fun () -> View.CreateEntry())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateEntry () : Xamarin.Forms.Entry = 
        upcast (new Xamarin.Forms.Entry())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncEntry = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Entry) -> View.UpdateEntry (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateEntry (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Entry) = 
        // update the inherited InputView element
        let baseElement = (if View.ProtoInputView.IsNone then View.ProtoInputView <- Some (View.InputView())); View.ProtoInputView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevPlaceholderOpt = ValueNone
        let mutable currPlaceholderOpt = ValueNone
        let mutable prevHorizontalTextAlignmentOpt = ValueNone
        let mutable currHorizontalTextAlignmentOpt = ValueNone
        let mutable prevFontSizeOpt = ValueNone
        let mutable currFontSizeOpt = ValueNone
        let mutable prevFontFamilyOpt = ValueNone
        let mutable currFontFamilyOpt = ValueNone
        let mutable prevFontAttributesOpt = ValueNone
        let mutable currFontAttributesOpt = ValueNone
        let mutable prevTextColorOpt = ValueNone
        let mutable currTextColorOpt = ValueNone
        let mutable prevPlaceholderColorOpt = ValueNone
        let mutable currPlaceholderColorOpt = ValueNone
        let mutable prevIsPasswordOpt = ValueNone
        let mutable currIsPasswordOpt = ValueNone
        let mutable prevEntryCompletedOpt = ValueNone
        let mutable currEntryCompletedOpt = ValueNone
        let mutable prevTextChangedOpt = ValueNone
        let mutable currTextChangedOpt = ValueNone
        let mutable prevIsTextPredictionEnabledOpt = ValueNone
        let mutable currIsTextPredictionEnabledOpt = ValueNone
        let mutable prevReturnTypeOpt = ValueNone
        let mutable currReturnTypeOpt = ValueNone
        let mutable prevReturnCommandOpt = ValueNone
        let mutable currReturnCommandOpt = ValueNone
        let mutable prevCursorPositionOpt = ValueNone
        let mutable currCursorPositionOpt = ValueNone
        let mutable prevSelectionLengthOpt = ValueNone
        let mutable currSelectionLengthOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._PlaceholderAttribKey.KeyValue then 
                currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._HorizontalTextAlignmentAttribKey.KeyValue then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = View._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._PlaceholderColorAttribKey.KeyValue then 
                currPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._IsPasswordAttribKey.KeyValue then 
                currIsPasswordOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._EntryCompletedAttribKey.KeyValue then 
                currEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = View._TextChangedAttribKey.KeyValue then 
                currTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
            if kvp.Key = View._IsTextPredictionEnabledAttribKey.KeyValue then 
                currIsTextPredictionEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._ReturnTypeAttribKey.KeyValue then 
                currReturnTypeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ReturnType)
            if kvp.Key = View._ReturnCommandAttribKey.KeyValue then 
                currReturnCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = View._CursorPositionAttribKey.KeyValue then 
                currCursorPositionOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._SelectionLengthAttribKey.KeyValue then 
                currSelectionLengthOpt <- ValueSome (kvp.Value :?> int)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._PlaceholderAttribKey.KeyValue then 
                    prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._HorizontalTextAlignmentAttribKey.KeyValue then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = View._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._PlaceholderColorAttribKey.KeyValue then 
                    prevPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._IsPasswordAttribKey.KeyValue then 
                    prevIsPasswordOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._EntryCompletedAttribKey.KeyValue then 
                    prevEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = View._TextChangedAttribKey.KeyValue then 
                    prevTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
                if kvp.Key = View._IsTextPredictionEnabledAttribKey.KeyValue then 
                    prevIsTextPredictionEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._ReturnTypeAttribKey.KeyValue then 
                    prevReturnTypeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ReturnType)
                if kvp.Key = View._ReturnCommandAttribKey.KeyValue then 
                    prevReturnCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = View._CursorPositionAttribKey.KeyValue then 
                    prevCursorPositionOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._SelectionLengthAttribKey.KeyValue then 
                    prevSelectionLengthOpt <- ValueSome (kvp.Value :?> int)
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevPlaceholderOpt, currPlaceholderOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Placeholder <-  currValue
        | ValueSome _, ValueNone -> target.Placeholder <- null
        | ValueNone, ValueNone -> ()
        match prevHorizontalTextAlignmentOpt, currHorizontalTextAlignmentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HorizontalTextAlignment <-  currValue
        | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
        | ValueNone, ValueNone -> ()
        match prevFontSizeOpt, currFontSizeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontSize <-  currValue
        | ValueSome _, ValueNone -> target.FontSize <- -1.0
        | ValueNone, ValueNone -> ()
        match prevFontFamilyOpt, currFontFamilyOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontFamily <-  currValue
        | ValueSome _, ValueNone -> target.FontFamily <- null
        | ValueNone, ValueNone -> ()
        match prevFontAttributesOpt, currFontAttributesOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontAttributes <-  currValue
        | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
        | ValueNone, ValueNone -> ()
        match prevTextColorOpt, currTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextColor <-  currValue
        | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevPlaceholderColorOpt, currPlaceholderColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.PlaceholderColor <-  currValue
        | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevIsPasswordOpt, currIsPasswordOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsPassword <-  currValue
        | ValueSome _, ValueNone -> target.IsPassword <- false
        | ValueNone, ValueNone -> ()
        match prevEntryCompletedOpt, currEntryCompletedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Completed.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevTextChangedOpt, currTextChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.TextChanged.RemoveHandler(prevValue); target.TextChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.TextChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.TextChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevIsTextPredictionEnabledOpt, currIsTextPredictionEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsTextPredictionEnabled <-  currValue
        | ValueSome _, ValueNone -> target.IsTextPredictionEnabled <- true
        | ValueNone, ValueNone -> ()
        match prevReturnTypeOpt, currReturnTypeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ReturnType <-  currValue
        | ValueSome _, ValueNone -> target.ReturnType <- Xamarin.Forms.ReturnType.Default
        | ValueNone, ValueNone -> ()
        match prevReturnCommandOpt, currReturnCommandOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ReturnCommand <-  currValue
        | ValueSome _, ValueNone -> target.ReturnCommand <- null
        | ValueNone, ValueNone -> ()
        (fun _ curr (target: Xamarin.Forms.Entry) -> match curr with ValueSome value -> target.CursorPosition <- value | ValueNone -> ()) prevCursorPositionOpt currCursorPositionOpt target
        (fun _ curr (target: Xamarin.Forms.Entry) -> match curr with ValueSome value -> target.SelectionLength <- value | ValueNone -> ()) prevSelectionLengthOpt currSelectionLengthOpt target

    /// Describes a Entry in the view
    static member inline Entry(?text: string,
                               ?placeholder: string,
                               ?horizontalTextAlignment: Xamarin.Forms.TextAlignment,
                               ?fontSize: obj,
                               ?fontFamily: string,
                               ?fontAttributes: Xamarin.Forms.FontAttributes,
                               ?textColor: Xamarin.Forms.Color,
                               ?placeholderColor: Xamarin.Forms.Color,
                               ?isPassword: bool,
                               ?completed: string -> unit,
                               ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit,
                               ?isTextPredictionEnabled: bool,
                               ?returnType: Xamarin.Forms.ReturnType,
                               ?returnCommand: unit -> unit,
                               ?cursorPosition: int,
                               ?selectionLength: int,
                               ?keyboard: Xamarin.Forms.Keyboard,
                               ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                               ?verticalOptions: Xamarin.Forms.LayoutOptions,
                               ?margin: obj,
                               ?gestureRecognizers: ViewElement list,
                               ?anchorX: double,
                               ?anchorY: double,
                               ?backgroundColor: Xamarin.Forms.Color,
                               ?heightRequest: double,
                               ?inputTransparent: bool,
                               ?isEnabled: bool,
                               ?isVisible: bool,
                               ?minimumHeightRequest: double,
                               ?minimumWidthRequest: double,
                               ?opacity: double,
                               ?rotation: double,
                               ?rotationX: double,
                               ?rotationY: double,
                               ?scale: double,
                               ?style: Xamarin.Forms.Style,
                               ?styleClass: obj,
                               ?translationX: double,
                               ?translationY: double,
                               ?widthRequest: double,
                               ?resources: (string * obj) list,
                               ?styles: Xamarin.Forms.Style list,
                               ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                               ?isTabStop: bool,
                               ?scaleX: double,
                               ?scaleY: double,
                               ?tabIndex: int,
                               ?classId: string,
                               ?styleId: string,
                               ?automationId: string,
                               ?created: (Xamarin.Forms.Entry -> unit),
                               ?ref: ViewRef<Xamarin.Forms.Entry>) = 

        let attribBuilder = View.BuildEntry(0,
                               ?text=text,
                               ?placeholder=placeholder,
                               ?horizontalTextAlignment=horizontalTextAlignment,
                               ?fontSize=fontSize,
                               ?fontFamily=fontFamily,
                               ?fontAttributes=fontAttributes,
                               ?textColor=textColor,
                               ?placeholderColor=placeholderColor,
                               ?isPassword=isPassword,
                               ?completed=completed,
                               ?textChanged=textChanged,
                               ?isTextPredictionEnabled=isTextPredictionEnabled,
                               ?returnType=returnType,
                               ?returnCommand=returnCommand,
                               ?cursorPosition=cursorPosition,
                               ?selectionLength=selectionLength,
                               ?keyboard=keyboard,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Entry> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Entry>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Entry>(View.CreateFuncEntry, View.UpdateFuncEntry, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoEntry : ViewElement option = None with get, set

    /// Builds the attributes for a EntryCell in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildEntryCell(attribCount: int,
                                        ?label: string,
                                        ?text: string,
                                        ?keyboard: Xamarin.Forms.Keyboard,
                                        ?placeholder: string,
                                        ?horizontalTextAlignment: Xamarin.Forms.TextAlignment,
                                        ?completed: string -> unit,
                                        ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit,
                                        ?height: double,
                                        ?isEnabled: bool,
                                        ?classId: string,
                                        ?styleId: string,
                                        ?automationId: string,
                                        ?created: obj -> unit,
                                        ?ref: ViewRef) = 

        let attribCount = match label with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match keyboard with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match placeholder with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match horizontalTextAlignment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match completed with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match label with None -> () | Some v -> attribBuilder.Add(View._LabelAttribKey, (v)) 
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        match keyboard with None -> () | Some v -> attribBuilder.Add(View._KeyboardAttribKey, (v)) 
        match placeholder with None -> () | Some v -> attribBuilder.Add(View._PlaceholderAttribKey, (v)) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.Add(View._HorizontalTextAlignmentAttribKey, (v)) 
        match completed with None -> () | Some v -> attribBuilder.Add(View._EntryCompletedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.EntryCell).Text))(v)) 
        match textChanged with None -> () | Some v -> attribBuilder.Add(View._EntryCellTextChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncEntryCell : (unit -> Fabulous.CustomControls.CustomEntryCell) = (fun () -> View.CreateEntryCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateEntryCell () : Fabulous.CustomControls.CustomEntryCell = 
        upcast (new Fabulous.CustomControls.CustomEntryCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncEntryCell = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Fabulous.CustomControls.CustomEntryCell) -> View.UpdateEntryCell (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateEntryCell (prevOpt: ViewElement voption, curr: ViewElement, target: Fabulous.CustomControls.CustomEntryCell) = 
        // update the inherited Cell element
        let baseElement = (if View.ProtoCell.IsNone then View.ProtoCell <- Some (View.Cell())); View.ProtoCell.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevLabelOpt = ValueNone
        let mutable currLabelOpt = ValueNone
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevKeyboardOpt = ValueNone
        let mutable currKeyboardOpt = ValueNone
        let mutable prevPlaceholderOpt = ValueNone
        let mutable currPlaceholderOpt = ValueNone
        let mutable prevHorizontalTextAlignmentOpt = ValueNone
        let mutable currHorizontalTextAlignmentOpt = ValueNone
        let mutable prevEntryCompletedOpt = ValueNone
        let mutable currEntryCompletedOpt = ValueNone
        let mutable prevEntryCellTextChangedOpt = ValueNone
        let mutable currEntryCellTextChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._LabelAttribKey.KeyValue then 
                currLabelOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._KeyboardAttribKey.KeyValue then 
                currKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
            if kvp.Key = View._PlaceholderAttribKey.KeyValue then 
                currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._HorizontalTextAlignmentAttribKey.KeyValue then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = View._EntryCompletedAttribKey.KeyValue then 
                currEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = View._EntryCellTextChangedAttribKey.KeyValue then 
                currEntryCellTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._LabelAttribKey.KeyValue then 
                    prevLabelOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._KeyboardAttribKey.KeyValue then 
                    prevKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
                if kvp.Key = View._PlaceholderAttribKey.KeyValue then 
                    prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._HorizontalTextAlignmentAttribKey.KeyValue then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = View._EntryCompletedAttribKey.KeyValue then 
                    prevEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = View._EntryCellTextChangedAttribKey.KeyValue then 
                    prevEntryCellTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
        match prevLabelOpt, currLabelOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Label <-  currValue
        | ValueSome _, ValueNone -> target.Label <- null
        | ValueNone, ValueNone -> ()
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevKeyboardOpt, currKeyboardOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Keyboard <-  currValue
        | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
        | ValueNone, ValueNone -> ()
        match prevPlaceholderOpt, currPlaceholderOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Placeholder <-  currValue
        | ValueSome _, ValueNone -> target.Placeholder <- null
        | ValueNone, ValueNone -> ()
        match prevHorizontalTextAlignmentOpt, currHorizontalTextAlignmentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HorizontalTextAlignment <-  currValue
        | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
        | ValueNone, ValueNone -> ()
        match prevEntryCompletedOpt, currEntryCompletedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Completed.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevEntryCellTextChangedOpt, currEntryCellTextChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.TextChanged.RemoveHandler(prevValue); target.TextChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.TextChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.TextChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a EntryCell in the view
    static member inline EntryCell(?label: string,
                                   ?text: string,
                                   ?keyboard: Xamarin.Forms.Keyboard,
                                   ?placeholder: string,
                                   ?horizontalTextAlignment: Xamarin.Forms.TextAlignment,
                                   ?completed: string -> unit,
                                   ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit,
                                   ?height: double,
                                   ?isEnabled: bool,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?automationId: string,
                                   ?created: (Fabulous.CustomControls.CustomEntryCell -> unit),
                                   ?ref: ViewRef<Fabulous.CustomControls.CustomEntryCell>) = 

        let attribBuilder = View.BuildEntryCell(0,
                               ?label=label,
                               ?text=text,
                               ?keyboard=keyboard,
                               ?placeholder=placeholder,
                               ?horizontalTextAlignment=horizontalTextAlignment,
                               ?completed=completed,
                               ?textChanged=textChanged,
                               ?height=height,
                               ?isEnabled=isEnabled,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Fabulous.CustomControls.CustomEntryCell> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Fabulous.CustomControls.CustomEntryCell>) -> Some ref.Unbox))

        ViewElement.Create<Fabulous.CustomControls.CustomEntryCell>(View.CreateFuncEntryCell, View.UpdateFuncEntryCell, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoEntryCell : ViewElement option = None with get, set

    /// Builds the attributes for a Label in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildLabel(attribCount: int,
                                    ?text: string,
                                    ?horizontalTextAlignment: Xamarin.Forms.TextAlignment,
                                    ?verticalTextAlignment: Xamarin.Forms.TextAlignment,
                                    ?fontSize: obj,
                                    ?fontFamily: string,
                                    ?fontAttributes: Xamarin.Forms.FontAttributes,
                                    ?textColor: Xamarin.Forms.Color,
                                    ?formattedText: ViewElement,
                                    ?lineBreakMode: Xamarin.Forms.LineBreakMode,
                                    ?lineHeight: double,
                                    ?maxLines: int,
                                    ?textDecorations: Xamarin.Forms.TextDecorations,
                                    ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                    ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                    ?margin: obj,
                                    ?gestureRecognizers: ViewElement list,
                                    ?anchorX: double,
                                    ?anchorY: double,
                                    ?backgroundColor: Xamarin.Forms.Color,
                                    ?heightRequest: double,
                                    ?inputTransparent: bool,
                                    ?isEnabled: bool,
                                    ?isVisible: bool,
                                    ?minimumHeightRequest: double,
                                    ?minimumWidthRequest: double,
                                    ?opacity: double,
                                    ?rotation: double,
                                    ?rotationX: double,
                                    ?rotationY: double,
                                    ?scale: double,
                                    ?style: Xamarin.Forms.Style,
                                    ?styleClass: obj,
                                    ?translationX: double,
                                    ?translationY: double,
                                    ?widthRequest: double,
                                    ?resources: (string * obj) list,
                                    ?styles: Xamarin.Forms.Style list,
                                    ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                    ?isTabStop: bool,
                                    ?scaleX: double,
                                    ?scaleY: double,
                                    ?tabIndex: int,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?automationId: string,
                                    ?created: obj -> unit,
                                    ?ref: ViewRef) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match horizontalTextAlignment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match verticalTextAlignment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontAttributes with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match formattedText with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match lineBreakMode with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match lineHeight with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match maxLines with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textDecorations with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.Add(View._HorizontalTextAlignmentAttribKey, (v)) 
        match verticalTextAlignment with None -> () | Some v -> attribBuilder.Add(View._VerticalTextAlignmentAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(View._FontSizeAttribKey, makeFontSize(v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(View._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(View._FontAttributesAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(View._TextColorAttribKey, (v)) 
        match formattedText with None -> () | Some v -> attribBuilder.Add(View._FormattedTextAttribKey, (v)) 
        match lineBreakMode with None -> () | Some v -> attribBuilder.Add(View._LineBreakModeAttribKey, (v)) 
        match lineHeight with None -> () | Some v -> attribBuilder.Add(View._LineHeightAttribKey, (v)) 
        match maxLines with None -> () | Some v -> attribBuilder.Add(View._MaxLinesAttribKey, (v)) 
        match textDecorations with None -> () | Some v -> attribBuilder.Add(View._TextDecorationsAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncLabel : (unit -> Xamarin.Forms.Label) = (fun () -> View.CreateLabel())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateLabel () : Xamarin.Forms.Label = 
        upcast (new Xamarin.Forms.Label())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncLabel = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Label) -> View.UpdateLabel (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateLabel (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Label) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevHorizontalTextAlignmentOpt = ValueNone
        let mutable currHorizontalTextAlignmentOpt = ValueNone
        let mutable prevVerticalTextAlignmentOpt = ValueNone
        let mutable currVerticalTextAlignmentOpt = ValueNone
        let mutable prevFontSizeOpt = ValueNone
        let mutable currFontSizeOpt = ValueNone
        let mutable prevFontFamilyOpt = ValueNone
        let mutable currFontFamilyOpt = ValueNone
        let mutable prevFontAttributesOpt = ValueNone
        let mutable currFontAttributesOpt = ValueNone
        let mutable prevTextColorOpt = ValueNone
        let mutable currTextColorOpt = ValueNone
        let mutable prevFormattedTextOpt = ValueNone
        let mutable currFormattedTextOpt = ValueNone
        let mutable prevLineBreakModeOpt = ValueNone
        let mutable currLineBreakModeOpt = ValueNone
        let mutable prevLineHeightOpt = ValueNone
        let mutable currLineHeightOpt = ValueNone
        let mutable prevMaxLinesOpt = ValueNone
        let mutable currMaxLinesOpt = ValueNone
        let mutable prevTextDecorationsOpt = ValueNone
        let mutable currTextDecorationsOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._HorizontalTextAlignmentAttribKey.KeyValue then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = View._VerticalTextAlignmentAttribKey.KeyValue then 
                currVerticalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = View._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._FormattedTextAttribKey.KeyValue then 
                currFormattedTextOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = View._LineBreakModeAttribKey.KeyValue then 
                currLineBreakModeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LineBreakMode)
            if kvp.Key = View._LineHeightAttribKey.KeyValue then 
                currLineHeightOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._MaxLinesAttribKey.KeyValue then 
                currMaxLinesOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._TextDecorationsAttribKey.KeyValue then 
                currTextDecorationsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextDecorations)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._HorizontalTextAlignmentAttribKey.KeyValue then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = View._VerticalTextAlignmentAttribKey.KeyValue then 
                    prevVerticalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = View._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._FormattedTextAttribKey.KeyValue then 
                    prevFormattedTextOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = View._LineBreakModeAttribKey.KeyValue then 
                    prevLineBreakModeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LineBreakMode)
                if kvp.Key = View._LineHeightAttribKey.KeyValue then 
                    prevLineHeightOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._MaxLinesAttribKey.KeyValue then 
                    prevMaxLinesOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._TextDecorationsAttribKey.KeyValue then 
                    prevTextDecorationsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextDecorations)
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevHorizontalTextAlignmentOpt, currHorizontalTextAlignmentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HorizontalTextAlignment <-  currValue
        | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
        | ValueNone, ValueNone -> ()
        match prevVerticalTextAlignmentOpt, currVerticalTextAlignmentOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.VerticalTextAlignment <-  currValue
        | ValueSome _, ValueNone -> target.VerticalTextAlignment <- Xamarin.Forms.TextAlignment.Start
        | ValueNone, ValueNone -> ()
        match prevFontSizeOpt, currFontSizeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontSize <-  currValue
        | ValueSome _, ValueNone -> target.FontSize <- -1.0
        | ValueNone, ValueNone -> ()
        match prevFontFamilyOpt, currFontFamilyOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontFamily <-  currValue
        | ValueSome _, ValueNone -> target.FontFamily <- null
        | ValueNone, ValueNone -> ()
        match prevFontAttributesOpt, currFontAttributesOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontAttributes <-  currValue
        | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
        | ValueNone, ValueNone -> ()
        match prevTextColorOpt, currTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextColor <-  currValue
        | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevFormattedTextOpt, currFormattedTextOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.FormattedText)
        | _, ValueSome newValue ->
            target.FormattedText <- (newValue.Create() :?> Xamarin.Forms.FormattedString)
        | ValueSome _, ValueNone ->
            target.FormattedText <- null
        | ValueNone, ValueNone -> ()
        match prevLineBreakModeOpt, currLineBreakModeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.LineBreakMode <-  currValue
        | ValueSome _, ValueNone -> target.LineBreakMode <- Xamarin.Forms.LineBreakMode.WordWrap
        | ValueNone, ValueNone -> ()
        match prevLineHeightOpt, currLineHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.LineHeight <-  currValue
        | ValueSome _, ValueNone -> target.LineHeight <- -1.0
        | ValueNone, ValueNone -> ()
        match prevMaxLinesOpt, currMaxLinesOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MaxLines <-  currValue
        | ValueSome _, ValueNone -> target.MaxLines <- -1
        | ValueNone, ValueNone -> ()
        match prevTextDecorationsOpt, currTextDecorationsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextDecorations <-  currValue
        | ValueSome _, ValueNone -> target.TextDecorations <- Xamarin.Forms.TextDecorations.None
        | ValueNone, ValueNone -> ()

    /// Describes a Label in the view
    static member inline Label(?text: string,
                               ?horizontalTextAlignment: Xamarin.Forms.TextAlignment,
                               ?verticalTextAlignment: Xamarin.Forms.TextAlignment,
                               ?fontSize: obj,
                               ?fontFamily: string,
                               ?fontAttributes: Xamarin.Forms.FontAttributes,
                               ?textColor: Xamarin.Forms.Color,
                               ?formattedText: ViewElement,
                               ?lineBreakMode: Xamarin.Forms.LineBreakMode,
                               ?lineHeight: double,
                               ?maxLines: int,
                               ?textDecorations: Xamarin.Forms.TextDecorations,
                               ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                               ?verticalOptions: Xamarin.Forms.LayoutOptions,
                               ?margin: obj,
                               ?gestureRecognizers: ViewElement list,
                               ?anchorX: double,
                               ?anchorY: double,
                               ?backgroundColor: Xamarin.Forms.Color,
                               ?heightRequest: double,
                               ?inputTransparent: bool,
                               ?isEnabled: bool,
                               ?isVisible: bool,
                               ?minimumHeightRequest: double,
                               ?minimumWidthRequest: double,
                               ?opacity: double,
                               ?rotation: double,
                               ?rotationX: double,
                               ?rotationY: double,
                               ?scale: double,
                               ?style: Xamarin.Forms.Style,
                               ?styleClass: obj,
                               ?translationX: double,
                               ?translationY: double,
                               ?widthRequest: double,
                               ?resources: (string * obj) list,
                               ?styles: Xamarin.Forms.Style list,
                               ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                               ?isTabStop: bool,
                               ?scaleX: double,
                               ?scaleY: double,
                               ?tabIndex: int,
                               ?classId: string,
                               ?styleId: string,
                               ?automationId: string,
                               ?created: (Xamarin.Forms.Label -> unit),
                               ?ref: ViewRef<Xamarin.Forms.Label>) = 

        let attribBuilder = View.BuildLabel(0,
                               ?text=text,
                               ?horizontalTextAlignment=horizontalTextAlignment,
                               ?verticalTextAlignment=verticalTextAlignment,
                               ?fontSize=fontSize,
                               ?fontFamily=fontFamily,
                               ?fontAttributes=fontAttributes,
                               ?textColor=textColor,
                               ?formattedText=formattedText,
                               ?lineBreakMode=lineBreakMode,
                               ?lineHeight=lineHeight,
                               ?maxLines=maxLines,
                               ?textDecorations=textDecorations,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Label> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Label>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Label>(View.CreateFuncLabel, View.UpdateFuncLabel, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoLabel : ViewElement option = None with get, set

    /// Builds the attributes for a StackLayout in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildStackLayout(attribCount: int,
                                          ?children: ViewElement list,
                                          ?orientation: Xamarin.Forms.StackOrientation,
                                          ?spacing: double,
                                          ?isClippedToBounds: bool,
                                          ?padding: obj,
                                          ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                          ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                          ?margin: obj,
                                          ?gestureRecognizers: ViewElement list,
                                          ?anchorX: double,
                                          ?anchorY: double,
                                          ?backgroundColor: Xamarin.Forms.Color,
                                          ?heightRequest: double,
                                          ?inputTransparent: bool,
                                          ?isEnabled: bool,
                                          ?isVisible: bool,
                                          ?minimumHeightRequest: double,
                                          ?minimumWidthRequest: double,
                                          ?opacity: double,
                                          ?rotation: double,
                                          ?rotationX: double,
                                          ?rotationY: double,
                                          ?scale: double,
                                          ?style: Xamarin.Forms.Style,
                                          ?styleClass: obj,
                                          ?translationX: double,
                                          ?translationY: double,
                                          ?widthRequest: double,
                                          ?resources: (string * obj) list,
                                          ?styles: Xamarin.Forms.Style list,
                                          ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                          ?isTabStop: bool,
                                          ?scaleX: double,
                                          ?scaleY: double,
                                          ?tabIndex: int,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?automationId: string,
                                          ?created: obj -> unit,
                                          ?ref: ViewRef) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match orientation with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match spacing with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match children with None -> () | Some v -> attribBuilder.Add(View._ChildrenAttribKey, Array.ofList(v)) 
        match orientation with None -> () | Some v -> attribBuilder.Add(View._StackOrientationAttribKey, (v)) 
        match spacing with None -> () | Some v -> attribBuilder.Add(View._SpacingAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncStackLayout : (unit -> Xamarin.Forms.StackLayout) = (fun () -> View.CreateStackLayout())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateStackLayout () : Xamarin.Forms.StackLayout = 
        upcast (new Xamarin.Forms.StackLayout())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncStackLayout = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.StackLayout) -> View.UpdateStackLayout (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateStackLayout (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.StackLayout) = 
        // update the inherited Layout element
        let baseElement = (if View.ProtoLayout.IsNone then View.ProtoLayout <- Some (View.Layout())); View.ProtoLayout.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        let mutable prevStackOrientationOpt = ValueNone
        let mutable currStackOrientationOpt = ValueNone
        let mutable prevSpacingOpt = ValueNone
        let mutable currSpacingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = View._StackOrientationAttribKey.KeyValue then 
                currStackOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StackOrientation)
            if kvp.Key = View._SpacingAttribKey.KeyValue then 
                currSpacingOpt <- ValueSome (kvp.Value :?> double)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = View._StackOrientationAttribKey.KeyValue then 
                    prevStackOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StackOrientation)
                if kvp.Key = View._SpacingAttribKey.KeyValue then 
                    prevSpacingOpt <- ValueSome (kvp.Value :?> double)
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild
        match prevStackOrientationOpt, currStackOrientationOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Orientation <-  currValue
        | ValueSome _, ValueNone -> target.Orientation <- Xamarin.Forms.StackOrientation.Vertical
        | ValueNone, ValueNone -> ()
        match prevSpacingOpt, currSpacingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Spacing <-  currValue
        | ValueSome _, ValueNone -> target.Spacing <- 6.0
        | ValueNone, ValueNone -> ()

    /// Describes a StackLayout in the view
    static member inline StackLayout(?children: ViewElement list,
                                     ?orientation: Xamarin.Forms.StackOrientation,
                                     ?spacing: double,
                                     ?isClippedToBounds: bool,
                                     ?padding: obj,
                                     ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                     ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                     ?margin: obj,
                                     ?gestureRecognizers: ViewElement list,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: (Xamarin.Forms.StackLayout -> unit),
                                     ?ref: ViewRef<Xamarin.Forms.StackLayout>) = 

        let attribBuilder = View.BuildStackLayout(0,
                               ?children=children,
                               ?orientation=orientation,
                               ?spacing=spacing,
                               ?isClippedToBounds=isClippedToBounds,
                               ?padding=padding,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.StackLayout> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.StackLayout>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.StackLayout>(View.CreateFuncStackLayout, View.UpdateFuncStackLayout, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoStackLayout : ViewElement option = None with get, set

    /// Builds the attributes for a Span in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildSpan(attribCount: int,
                                   ?fontFamily: string,
                                   ?fontAttributes: Xamarin.Forms.FontAttributes,
                                   ?fontSize: obj,
                                   ?backgroundColor: Xamarin.Forms.Color,
                                   ?foregroundColor: Xamarin.Forms.Color,
                                   ?text: string,
                                   ?propertyChanged: System.ComponentModel.PropertyChangedEventArgs -> unit,
                                   ?lineHeight: double,
                                   ?textDecorations: Xamarin.Forms.TextDecorations,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?automationId: string,
                                   ?created: obj -> unit,
                                   ?ref: ViewRef) = 

        let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontAttributes with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match backgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match foregroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match propertyChanged with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match lineHeight with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textDecorations with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildElement(attribCount, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match fontFamily with None -> () | Some v -> attribBuilder.Add(View._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(View._FontAttributesAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(View._FontSizeAttribKey, makeFontSize(v)) 
        match backgroundColor with None -> () | Some v -> attribBuilder.Add(View._BackgroundColorAttribKey, (v)) 
        match foregroundColor with None -> () | Some v -> attribBuilder.Add(View._ForegroundColorAttribKey, (v)) 
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        match propertyChanged with None -> () | Some v -> attribBuilder.Add(View._PropertyChangedAttribKey, (fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(v)) 
        match lineHeight with None -> () | Some v -> attribBuilder.Add(View._LineHeightAttribKey, (v)) 
        match textDecorations with None -> () | Some v -> attribBuilder.Add(View._TextDecorationsAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncSpan : (unit -> Xamarin.Forms.Span) = (fun () -> View.CreateSpan())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateSpan () : Xamarin.Forms.Span = 
        upcast (new Xamarin.Forms.Span())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncSpan = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Span) -> View.UpdateSpan (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateSpan (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Span) = 
        // update the inherited Element element
        let baseElement = (if View.ProtoElement.IsNone then View.ProtoElement <- Some (View.Element())); View.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevFontFamilyOpt = ValueNone
        let mutable currFontFamilyOpt = ValueNone
        let mutable prevFontAttributesOpt = ValueNone
        let mutable currFontAttributesOpt = ValueNone
        let mutable prevFontSizeOpt = ValueNone
        let mutable currFontSizeOpt = ValueNone
        let mutable prevBackgroundColorOpt = ValueNone
        let mutable currBackgroundColorOpt = ValueNone
        let mutable prevForegroundColorOpt = ValueNone
        let mutable currForegroundColorOpt = ValueNone
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevPropertyChangedOpt = ValueNone
        let mutable currPropertyChangedOpt = ValueNone
        let mutable prevLineHeightOpt = ValueNone
        let mutable currLineHeightOpt = ValueNone
        let mutable prevTextDecorationsOpt = ValueNone
        let mutable currTextDecorationsOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._BackgroundColorAttribKey.KeyValue then 
                currBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._ForegroundColorAttribKey.KeyValue then 
                currForegroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._PropertyChangedAttribKey.KeyValue then 
                currPropertyChangedOpt <- ValueSome (kvp.Value :?> System.ComponentModel.PropertyChangedEventHandler)
            if kvp.Key = View._LineHeightAttribKey.KeyValue then 
                currLineHeightOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = View._TextDecorationsAttribKey.KeyValue then 
                currTextDecorationsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextDecorations)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = View._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._BackgroundColorAttribKey.KeyValue then 
                    prevBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._ForegroundColorAttribKey.KeyValue then 
                    prevForegroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._PropertyChangedAttribKey.KeyValue then 
                    prevPropertyChangedOpt <- ValueSome (kvp.Value :?> System.ComponentModel.PropertyChangedEventHandler)
                if kvp.Key = View._LineHeightAttribKey.KeyValue then 
                    prevLineHeightOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = View._TextDecorationsAttribKey.KeyValue then 
                    prevTextDecorationsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextDecorations)
        match prevFontFamilyOpt, currFontFamilyOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontFamily <-  currValue
        | ValueSome _, ValueNone -> target.FontFamily <- null
        | ValueNone, ValueNone -> ()
        match prevFontAttributesOpt, currFontAttributesOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontAttributes <-  currValue
        | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
        | ValueNone, ValueNone -> ()
        match prevFontSizeOpt, currFontSizeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.FontSize <-  currValue
        | ValueSome _, ValueNone -> target.FontSize <- -1.0
        | ValueNone, ValueNone -> ()
        match prevBackgroundColorOpt, currBackgroundColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BackgroundColor <-  currValue
        | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevForegroundColorOpt, currForegroundColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ForegroundColor <-  currValue
        | ValueSome _, ValueNone -> target.ForegroundColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevPropertyChangedOpt, currPropertyChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.PropertyChanged.RemoveHandler(prevValue); target.PropertyChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.PropertyChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.PropertyChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevLineHeightOpt, currLineHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.LineHeight <-  currValue
        | ValueSome _, ValueNone -> target.LineHeight <- -1.0
        | ValueNone, ValueNone -> ()
        match prevTextDecorationsOpt, currTextDecorationsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextDecorations <-  currValue
        | ValueSome _, ValueNone -> target.TextDecorations <- Xamarin.Forms.TextDecorations.None
        | ValueNone, ValueNone -> ()

    /// Describes a Span in the view
    static member inline Span(?fontFamily: string,
                              ?fontAttributes: Xamarin.Forms.FontAttributes,
                              ?fontSize: obj,
                              ?backgroundColor: Xamarin.Forms.Color,
                              ?foregroundColor: Xamarin.Forms.Color,
                              ?text: string,
                              ?propertyChanged: System.ComponentModel.PropertyChangedEventArgs -> unit,
                              ?lineHeight: double,
                              ?textDecorations: Xamarin.Forms.TextDecorations,
                              ?classId: string,
                              ?styleId: string,
                              ?automationId: string,
                              ?created: (Xamarin.Forms.Span -> unit),
                              ?ref: ViewRef<Xamarin.Forms.Span>) = 

        let attribBuilder = View.BuildSpan(0,
                               ?fontFamily=fontFamily,
                               ?fontAttributes=fontAttributes,
                               ?fontSize=fontSize,
                               ?backgroundColor=backgroundColor,
                               ?foregroundColor=foregroundColor,
                               ?text=text,
                               ?propertyChanged=propertyChanged,
                               ?lineHeight=lineHeight,
                               ?textDecorations=textDecorations,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Span> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Span>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Span>(View.CreateFuncSpan, View.UpdateFuncSpan, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoSpan : ViewElement option = None with get, set

    /// Builds the attributes for a FormattedString in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildFormattedString(attribCount: int,
                                              ?spans: ViewElement[],
                                              ?classId: string,
                                              ?styleId: string,
                                              ?automationId: string,
                                              ?created: obj -> unit,
                                              ?ref: ViewRef) = 

        let attribCount = match spans with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildElement(attribCount, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match spans with None -> () | Some v -> attribBuilder.Add(View._SpansAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncFormattedString : (unit -> Xamarin.Forms.FormattedString) = (fun () -> View.CreateFormattedString())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateFormattedString () : Xamarin.Forms.FormattedString = 
        upcast (new Xamarin.Forms.FormattedString())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncFormattedString = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.FormattedString) -> View.UpdateFormattedString (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateFormattedString (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.FormattedString) = 
        // update the inherited Element element
        let baseElement = (if View.ProtoElement.IsNone then View.ProtoElement <- Some (View.Element())); View.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevSpansOpt = ValueNone
        let mutable currSpansOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._SpansAttribKey.KeyValue then 
                currSpansOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._SpansAttribKey.KeyValue then 
                    prevSpansOpt <- ValueSome (kvp.Value :?> ViewElement[])
        updateCollectionGeneric prevSpansOpt currSpansOpt target.Spans
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.Span)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild

    /// Describes a FormattedString in the view
    static member inline FormattedString(?spans: ViewElement[],
                                         ?classId: string,
                                         ?styleId: string,
                                         ?automationId: string,
                                         ?created: (Xamarin.Forms.FormattedString -> unit),
                                         ?ref: ViewRef<Xamarin.Forms.FormattedString>) = 

        let attribBuilder = View.BuildFormattedString(0,
                               ?spans=spans,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.FormattedString> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.FormattedString>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.FormattedString>(View.CreateFuncFormattedString, View.UpdateFuncFormattedString, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoFormattedString : ViewElement option = None with get, set

    /// Builds the attributes for a TimePicker in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildTimePicker(attribCount: int,
                                         ?time: System.TimeSpan,
                                         ?format: string,
                                         ?textColor: Xamarin.Forms.Color,
                                         ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                         ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                         ?margin: obj,
                                         ?gestureRecognizers: ViewElement list,
                                         ?anchorX: double,
                                         ?anchorY: double,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?heightRequest: double,
                                         ?inputTransparent: bool,
                                         ?isEnabled: bool,
                                         ?isVisible: bool,
                                         ?minimumHeightRequest: double,
                                         ?minimumWidthRequest: double,
                                         ?opacity: double,
                                         ?rotation: double,
                                         ?rotationX: double,
                                         ?rotationY: double,
                                         ?scale: double,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: obj,
                                         ?translationX: double,
                                         ?translationY: double,
                                         ?widthRequest: double,
                                         ?resources: (string * obj) list,
                                         ?styles: Xamarin.Forms.Style list,
                                         ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                         ?isTabStop: bool,
                                         ?scaleX: double,
                                         ?scaleY: double,
                                         ?tabIndex: int,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?automationId: string,
                                         ?created: obj -> unit,
                                         ?ref: ViewRef) = 

        let attribCount = match time with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match format with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match time with None -> () | Some v -> attribBuilder.Add(View._TimeAttribKey, (v)) 
        match format with None -> () | Some v -> attribBuilder.Add(View._FormatAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(View._TextColorAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncTimePicker : (unit -> Xamarin.Forms.TimePicker) = (fun () -> View.CreateTimePicker())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateTimePicker () : Xamarin.Forms.TimePicker = 
        upcast (new Xamarin.Forms.TimePicker())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncTimePicker = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TimePicker) -> View.UpdateTimePicker (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateTimePicker (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.TimePicker) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevTimeOpt = ValueNone
        let mutable currTimeOpt = ValueNone
        let mutable prevFormatOpt = ValueNone
        let mutable currFormatOpt = ValueNone
        let mutable prevTextColorOpt = ValueNone
        let mutable currTextColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._TimeAttribKey.KeyValue then 
                currTimeOpt <- ValueSome (kvp.Value :?> System.TimeSpan)
            if kvp.Key = View._FormatAttribKey.KeyValue then 
                currFormatOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._TimeAttribKey.KeyValue then 
                    prevTimeOpt <- ValueSome (kvp.Value :?> System.TimeSpan)
                if kvp.Key = View._FormatAttribKey.KeyValue then 
                    prevFormatOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevTimeOpt, currTimeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Time <-  currValue
        | ValueSome _, ValueNone -> target.Time <- new System.TimeSpan()
        | ValueNone, ValueNone -> ()
        match prevFormatOpt, currFormatOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Format <-  currValue
        | ValueSome _, ValueNone -> target.Format <- "t"
        | ValueNone, ValueNone -> ()
        match prevTextColorOpt, currTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextColor <-  currValue
        | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()

    /// Describes a TimePicker in the view
    static member inline TimePicker(?time: System.TimeSpan,
                                    ?format: string,
                                    ?textColor: Xamarin.Forms.Color,
                                    ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                    ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                    ?margin: obj,
                                    ?gestureRecognizers: ViewElement list,
                                    ?anchorX: double,
                                    ?anchorY: double,
                                    ?backgroundColor: Xamarin.Forms.Color,
                                    ?heightRequest: double,
                                    ?inputTransparent: bool,
                                    ?isEnabled: bool,
                                    ?isVisible: bool,
                                    ?minimumHeightRequest: double,
                                    ?minimumWidthRequest: double,
                                    ?opacity: double,
                                    ?rotation: double,
                                    ?rotationX: double,
                                    ?rotationY: double,
                                    ?scale: double,
                                    ?style: Xamarin.Forms.Style,
                                    ?styleClass: obj,
                                    ?translationX: double,
                                    ?translationY: double,
                                    ?widthRequest: double,
                                    ?resources: (string * obj) list,
                                    ?styles: Xamarin.Forms.Style list,
                                    ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                    ?isTabStop: bool,
                                    ?scaleX: double,
                                    ?scaleY: double,
                                    ?tabIndex: int,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?automationId: string,
                                    ?created: (Xamarin.Forms.TimePicker -> unit),
                                    ?ref: ViewRef<Xamarin.Forms.TimePicker>) = 

        let attribBuilder = View.BuildTimePicker(0,
                               ?time=time,
                               ?format=format,
                               ?textColor=textColor,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.TimePicker> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.TimePicker>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.TimePicker>(View.CreateFuncTimePicker, View.UpdateFuncTimePicker, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoTimePicker : ViewElement option = None with get, set

    /// Builds the attributes for a WebView in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildWebView(attribCount: int,
                                      ?source: Xamarin.Forms.WebViewSource,
                                      ?reload: bool,
                                      ?navigated: Xamarin.Forms.WebNavigatedEventArgs -> unit,
                                      ?navigating: Xamarin.Forms.WebNavigatingEventArgs -> unit,
                                      ?reloadRequested: System.EventArgs -> unit,
                                      ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                      ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                      ?margin: obj,
                                      ?gestureRecognizers: ViewElement list,
                                      ?anchorX: double,
                                      ?anchorY: double,
                                      ?backgroundColor: Xamarin.Forms.Color,
                                      ?heightRequest: double,
                                      ?inputTransparent: bool,
                                      ?isEnabled: bool,
                                      ?isVisible: bool,
                                      ?minimumHeightRequest: double,
                                      ?minimumWidthRequest: double,
                                      ?opacity: double,
                                      ?rotation: double,
                                      ?rotationX: double,
                                      ?rotationY: double,
                                      ?scale: double,
                                      ?style: Xamarin.Forms.Style,
                                      ?styleClass: obj,
                                      ?translationX: double,
                                      ?translationY: double,
                                      ?widthRequest: double,
                                      ?resources: (string * obj) list,
                                      ?styles: Xamarin.Forms.Style list,
                                      ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                      ?isTabStop: bool,
                                      ?scaleX: double,
                                      ?scaleY: double,
                                      ?tabIndex: int,
                                      ?classId: string,
                                      ?styleId: string,
                                      ?automationId: string,
                                      ?created: obj -> unit,
                                      ?ref: ViewRef) = 

        let attribCount = match source with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match reload with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match navigated with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match navigating with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match reloadRequested with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match source with None -> () | Some v -> attribBuilder.Add(View._WebSourceAttribKey, (v)) 
        match reload with None -> () | Some v -> attribBuilder.Add(View._ReloadAttribKey, (v)) 
        match navigated with None -> () | Some v -> attribBuilder.Add(View._NavigatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(v)) 
        match navigating with None -> () | Some v -> attribBuilder.Add(View._NavigatingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(v)) 
        match reloadRequested with None -> () | Some v -> attribBuilder.Add(View._ReloadRequestedAttribKey, (fun f -> System.EventHandler(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncWebView : (unit -> Xamarin.Forms.WebView) = (fun () -> View.CreateWebView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateWebView () : Xamarin.Forms.WebView = 
        upcast (new Xamarin.Forms.WebView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncWebView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.WebView) -> View.UpdateWebView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateWebView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.WebView) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevWebSourceOpt = ValueNone
        let mutable currWebSourceOpt = ValueNone
        let mutable prevReloadOpt = ValueNone
        let mutable currReloadOpt = ValueNone
        let mutable prevNavigatedOpt = ValueNone
        let mutable currNavigatedOpt = ValueNone
        let mutable prevNavigatingOpt = ValueNone
        let mutable currNavigatingOpt = ValueNone
        let mutable prevReloadRequestedOpt = ValueNone
        let mutable currReloadRequestedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._WebSourceAttribKey.KeyValue then 
                currWebSourceOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.WebViewSource)
            if kvp.Key = View._ReloadAttribKey.KeyValue then 
                currReloadOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._NavigatedAttribKey.KeyValue then 
                currNavigatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>)
            if kvp.Key = View._NavigatingAttribKey.KeyValue then 
                currNavigatingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>)
            if kvp.Key = View._ReloadRequestedAttribKey.KeyValue then 
                currReloadRequestedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._WebSourceAttribKey.KeyValue then 
                    prevWebSourceOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.WebViewSource)
                if kvp.Key = View._ReloadAttribKey.KeyValue then 
                    prevReloadOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._NavigatedAttribKey.KeyValue then 
                    prevNavigatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>)
                if kvp.Key = View._NavigatingAttribKey.KeyValue then 
                    prevNavigatingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>)
                if kvp.Key = View._ReloadRequestedAttribKey.KeyValue then 
                    prevReloadRequestedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevWebSourceOpt, currWebSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Source <-  currValue
        | ValueSome _, ValueNone -> target.Source <- null
        | ValueNone, ValueNone -> ()
        (fun _ curr (target: Xamarin.Forms.WebView) -> if curr = ValueSome true then target.Reload()) prevReloadOpt currReloadOpt target
        match prevNavigatedOpt, currNavigatedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Navigated.RemoveHandler(prevValue); target.Navigated.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Navigated.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Navigated.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevNavigatingOpt, currNavigatingOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Navigating.RemoveHandler(prevValue); target.Navigating.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Navigating.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Navigating.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevReloadRequestedOpt, currReloadRequestedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ReloadRequested.RemoveHandler(prevValue); target.ReloadRequested.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ReloadRequested.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ReloadRequested.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a WebView in the view
    static member inline WebView(?source: Xamarin.Forms.WebViewSource,
                                 ?reload: bool,
                                 ?navigated: Xamarin.Forms.WebNavigatedEventArgs -> unit,
                                 ?navigating: Xamarin.Forms.WebNavigatingEventArgs -> unit,
                                 ?reloadRequested: System.EventArgs -> unit,
                                 ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                 ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                 ?margin: obj,
                                 ?gestureRecognizers: ViewElement list,
                                 ?anchorX: double,
                                 ?anchorY: double,
                                 ?backgroundColor: Xamarin.Forms.Color,
                                 ?heightRequest: double,
                                 ?inputTransparent: bool,
                                 ?isEnabled: bool,
                                 ?isVisible: bool,
                                 ?minimumHeightRequest: double,
                                 ?minimumWidthRequest: double,
                                 ?opacity: double,
                                 ?rotation: double,
                                 ?rotationX: double,
                                 ?rotationY: double,
                                 ?scale: double,
                                 ?style: Xamarin.Forms.Style,
                                 ?styleClass: obj,
                                 ?translationX: double,
                                 ?translationY: double,
                                 ?widthRequest: double,
                                 ?resources: (string * obj) list,
                                 ?styles: Xamarin.Forms.Style list,
                                 ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                 ?isTabStop: bool,
                                 ?scaleX: double,
                                 ?scaleY: double,
                                 ?tabIndex: int,
                                 ?classId: string,
                                 ?styleId: string,
                                 ?automationId: string,
                                 ?created: (Xamarin.Forms.WebView -> unit),
                                 ?ref: ViewRef<Xamarin.Forms.WebView>) = 

        let attribBuilder = View.BuildWebView(0,
                               ?source=source,
                               ?reload=reload,
                               ?navigated=navigated,
                               ?navigating=navigating,
                               ?reloadRequested=reloadRequested,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.WebView> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.WebView>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.WebView>(View.CreateFuncWebView, View.UpdateFuncWebView, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoWebView : ViewElement option = None with get, set

    /// Builds the attributes for a Page in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildPage(attribCount: int,
                                   ?title: string,
                                   ?backgroundImage: string,
                                   ?icon: string,
                                   ?isBusy: bool,
                                   ?padding: obj,
                                   ?toolbarItems: ViewElement list,
                                   ?useSafeArea: bool,
                                   ?appearing: unit -> unit,
                                   ?disappearing: unit -> unit,
                                   ?layoutChanged: unit -> unit,
                                   ?anchorX: double,
                                   ?anchorY: double,
                                   ?backgroundColor: Xamarin.Forms.Color,
                                   ?heightRequest: double,
                                   ?inputTransparent: bool,
                                   ?isEnabled: bool,
                                   ?isVisible: bool,
                                   ?minimumHeightRequest: double,
                                   ?minimumWidthRequest: double,
                                   ?opacity: double,
                                   ?rotation: double,
                                   ?rotationX: double,
                                   ?rotationY: double,
                                   ?scale: double,
                                   ?style: Xamarin.Forms.Style,
                                   ?styleClass: obj,
                                   ?translationX: double,
                                   ?translationY: double,
                                   ?widthRequest: double,
                                   ?resources: (string * obj) list,
                                   ?styles: Xamarin.Forms.Style list,
                                   ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                   ?isTabStop: bool,
                                   ?scaleX: double,
                                   ?scaleY: double,
                                   ?tabIndex: int,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?automationId: string,
                                   ?created: obj -> unit,
                                   ?ref: ViewRef) = 

        let attribCount = match title with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match backgroundImage with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match icon with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isBusy with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match toolbarItems with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match useSafeArea with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match appearing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match disappearing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match layoutChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildVisualElement(attribCount, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match title with None -> () | Some v -> attribBuilder.Add(View._TitleAttribKey, (v)) 
        match backgroundImage with None -> () | Some v -> attribBuilder.Add(View._BackgroundImageAttribKey, (v)) 
        match icon with None -> () | Some v -> attribBuilder.Add(View._IconAttribKey, (v)) 
        match isBusy with None -> () | Some v -> attribBuilder.Add(View._IsBusyAttribKey, (v)) 
        match padding with None -> () | Some v -> attribBuilder.Add(View._PaddingAttribKey, makeThickness(v)) 
        match toolbarItems with None -> () | Some v -> attribBuilder.Add(View._ToolbarItemsAttribKey, Array.ofList(v)) 
        match useSafeArea with None -> () | Some v -> attribBuilder.Add(View._UseSafeAreaAttribKey, (v)) 
        match appearing with None -> () | Some v -> attribBuilder.Add(View._Page_AppearingAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(v)) 
        match disappearing with None -> () | Some v -> attribBuilder.Add(View._Page_DisappearingAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(v)) 
        match layoutChanged with None -> () | Some v -> attribBuilder.Add(View._Page_LayoutChangedAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncPage : (unit -> Xamarin.Forms.Page) = (fun () -> View.CreatePage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreatePage () : Xamarin.Forms.Page = 
        upcast (new Xamarin.Forms.Page())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncPage = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Page) -> View.UpdatePage (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdatePage (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.Page) = 
        // update the inherited VisualElement element
        let baseElement = (if View.ProtoVisualElement.IsNone then View.ProtoVisualElement <- Some (View.VisualElement())); View.ProtoVisualElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevTitleOpt = ValueNone
        let mutable currTitleOpt = ValueNone
        let mutable prevBackgroundImageOpt = ValueNone
        let mutable currBackgroundImageOpt = ValueNone
        let mutable prevIconOpt = ValueNone
        let mutable currIconOpt = ValueNone
        let mutable prevIsBusyOpt = ValueNone
        let mutable currIsBusyOpt = ValueNone
        let mutable prevPaddingOpt = ValueNone
        let mutable currPaddingOpt = ValueNone
        let mutable prevToolbarItemsOpt = ValueNone
        let mutable currToolbarItemsOpt = ValueNone
        let mutable prevUseSafeAreaOpt = ValueNone
        let mutable currUseSafeAreaOpt = ValueNone
        let mutable prevPage_AppearingOpt = ValueNone
        let mutable currPage_AppearingOpt = ValueNone
        let mutable prevPage_DisappearingOpt = ValueNone
        let mutable currPage_DisappearingOpt = ValueNone
        let mutable prevPage_LayoutChangedOpt = ValueNone
        let mutable currPage_LayoutChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._TitleAttribKey.KeyValue then 
                currTitleOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._BackgroundImageAttribKey.KeyValue then 
                currBackgroundImageOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._IconAttribKey.KeyValue then 
                currIconOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._IsBusyAttribKey.KeyValue then 
                currIsBusyOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._PaddingAttribKey.KeyValue then 
                currPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
            if kvp.Key = View._ToolbarItemsAttribKey.KeyValue then 
                currToolbarItemsOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = View._UseSafeAreaAttribKey.KeyValue then 
                currUseSafeAreaOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._Page_AppearingAttribKey.KeyValue then 
                currPage_AppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = View._Page_DisappearingAttribKey.KeyValue then 
                currPage_DisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = View._Page_LayoutChangedAttribKey.KeyValue then 
                currPage_LayoutChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._TitleAttribKey.KeyValue then 
                    prevTitleOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._BackgroundImageAttribKey.KeyValue then 
                    prevBackgroundImageOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._IconAttribKey.KeyValue then 
                    prevIconOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._IsBusyAttribKey.KeyValue then 
                    prevIsBusyOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._PaddingAttribKey.KeyValue then 
                    prevPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                if kvp.Key = View._ToolbarItemsAttribKey.KeyValue then 
                    prevToolbarItemsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = View._UseSafeAreaAttribKey.KeyValue then 
                    prevUseSafeAreaOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._Page_AppearingAttribKey.KeyValue then 
                    prevPage_AppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = View._Page_DisappearingAttribKey.KeyValue then 
                    prevPage_DisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = View._Page_LayoutChangedAttribKey.KeyValue then 
                    prevPage_LayoutChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevTitleOpt, currTitleOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Title <-  currValue
        | ValueSome _, ValueNone -> target.Title <- ""
        | ValueNone, ValueNone -> ()
        match prevBackgroundImageOpt, currBackgroundImageOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BackgroundImage <-  currValue
        | ValueSome _, ValueNone -> target.BackgroundImage <- null
        | ValueNone, ValueNone -> ()
        match prevIconOpt, currIconOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Icon <- makeFileImageSource currValue
        | ValueSome _, ValueNone -> target.Icon <- null
        | ValueNone, ValueNone -> ()
        match prevIsBusyOpt, currIsBusyOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsBusy <-  currValue
        | ValueSome _, ValueNone -> target.IsBusy <- false
        | ValueNone, ValueNone -> ()
        match prevPaddingOpt, currPaddingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Padding <-  currValue
        | ValueSome _, ValueNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
        | ValueNone, ValueNone -> ()
        updateCollectionGeneric prevToolbarItemsOpt currToolbarItemsOpt target.ToolbarItems
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.ToolbarItem)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild
        (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((target : Xamarin.Forms.Page).On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevUseSafeAreaOpt currUseSafeAreaOpt target
        match prevPage_AppearingOpt, currPage_AppearingOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Appearing.RemoveHandler(prevValue); target.Appearing.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Appearing.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Appearing.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevPage_DisappearingOpt, currPage_DisappearingOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Disappearing.RemoveHandler(prevValue); target.Disappearing.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Disappearing.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Disappearing.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevPage_LayoutChangedOpt, currPage_LayoutChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.LayoutChanged.RemoveHandler(prevValue); target.LayoutChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.LayoutChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.LayoutChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a Page in the view
    static member inline Page(?title: string,
                              ?backgroundImage: string,
                              ?icon: string,
                              ?isBusy: bool,
                              ?padding: obj,
                              ?toolbarItems: ViewElement list,
                              ?useSafeArea: bool,
                              ?appearing: unit -> unit,
                              ?disappearing: unit -> unit,
                              ?layoutChanged: unit -> unit,
                              ?anchorX: double,
                              ?anchorY: double,
                              ?backgroundColor: Xamarin.Forms.Color,
                              ?heightRequest: double,
                              ?inputTransparent: bool,
                              ?isEnabled: bool,
                              ?isVisible: bool,
                              ?minimumHeightRequest: double,
                              ?minimumWidthRequest: double,
                              ?opacity: double,
                              ?rotation: double,
                              ?rotationX: double,
                              ?rotationY: double,
                              ?scale: double,
                              ?style: Xamarin.Forms.Style,
                              ?styleClass: obj,
                              ?translationX: double,
                              ?translationY: double,
                              ?widthRequest: double,
                              ?resources: (string * obj) list,
                              ?styles: Xamarin.Forms.Style list,
                              ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                              ?isTabStop: bool,
                              ?scaleX: double,
                              ?scaleY: double,
                              ?tabIndex: int,
                              ?classId: string,
                              ?styleId: string,
                              ?automationId: string,
                              ?created: (Xamarin.Forms.Page -> unit),
                              ?ref: ViewRef<Xamarin.Forms.Page>) = 

        let attribBuilder = View.BuildPage(0,
                               ?title=title,
                               ?backgroundImage=backgroundImage,
                               ?icon=icon,
                               ?isBusy=isBusy,
                               ?padding=padding,
                               ?toolbarItems=toolbarItems,
                               ?useSafeArea=useSafeArea,
                               ?appearing=appearing,
                               ?disappearing=disappearing,
                               ?layoutChanged=layoutChanged,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.Page> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.Page>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.Page>(View.CreateFuncPage, View.UpdateFuncPage, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoPage : ViewElement option = None with get, set

    /// Builds the attributes for a CarouselPage in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildCarouselPage(attribCount: int,
                                           ?children: ViewElement list,
                                           ?currentPage: int,
                                           ?currentPageChanged: int option -> unit,
                                           ?title: string,
                                           ?backgroundImage: string,
                                           ?icon: string,
                                           ?isBusy: bool,
                                           ?padding: obj,
                                           ?toolbarItems: ViewElement list,
                                           ?useSafeArea: bool,
                                           ?appearing: unit -> unit,
                                           ?disappearing: unit -> unit,
                                           ?layoutChanged: unit -> unit,
                                           ?anchorX: double,
                                           ?anchorY: double,
                                           ?backgroundColor: Xamarin.Forms.Color,
                                           ?heightRequest: double,
                                           ?inputTransparent: bool,
                                           ?isEnabled: bool,
                                           ?isVisible: bool,
                                           ?minimumHeightRequest: double,
                                           ?minimumWidthRequest: double,
                                           ?opacity: double,
                                           ?rotation: double,
                                           ?rotationX: double,
                                           ?rotationY: double,
                                           ?scale: double,
                                           ?style: Xamarin.Forms.Style,
                                           ?styleClass: obj,
                                           ?translationX: double,
                                           ?translationY: double,
                                           ?widthRequest: double,
                                           ?resources: (string * obj) list,
                                           ?styles: Xamarin.Forms.Style list,
                                           ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                           ?isTabStop: bool,
                                           ?scaleX: double,
                                           ?scaleY: double,
                                           ?tabIndex: int,
                                           ?classId: string,
                                           ?styleId: string,
                                           ?automationId: string,
                                           ?created: obj -> unit,
                                           ?ref: ViewRef) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match currentPage with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match currentPageChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match children with None -> () | Some v -> attribBuilder.Add(View._ChildrenAttribKey, Array.ofList(v)) 
        match currentPage with None -> () | Some v -> attribBuilder.Add(View._CarouselPage_CurrentPageAttribKey, (v)) 
        match currentPageChanged with None -> () | Some v -> attribBuilder.Add(View._CarouselPage_CurrentPageChangedAttribKey, makeCurrentPageChanged<Xamarin.Forms.ContentPage>(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncCarouselPage : (unit -> Xamarin.Forms.CarouselPage) = (fun () -> View.CreateCarouselPage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateCarouselPage () : Xamarin.Forms.CarouselPage = 
        upcast (new Xamarin.Forms.CarouselPage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncCarouselPage = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.CarouselPage) -> View.UpdateCarouselPage (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateCarouselPage (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.CarouselPage) = 
        // update the inherited Page element
        let baseElement = (if View.ProtoPage.IsNone then View.ProtoPage <- Some (View.Page())); View.ProtoPage.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        let mutable prevCarouselPage_CurrentPageOpt = ValueNone
        let mutable currCarouselPage_CurrentPageOpt = ValueNone
        let mutable prevCarouselPage_CurrentPageChangedOpt = ValueNone
        let mutable currCarouselPage_CurrentPageChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = View._CarouselPage_CurrentPageAttribKey.KeyValue then 
                currCarouselPage_CurrentPageOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._CarouselPage_CurrentPageChangedAttribKey.KeyValue then 
                currCarouselPage_CurrentPageChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = View._CarouselPage_CurrentPageAttribKey.KeyValue then 
                    prevCarouselPage_CurrentPageOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._CarouselPage_CurrentPageChangedAttribKey.KeyValue then 
                    prevCarouselPage_CurrentPageChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.ContentPage)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild
        updateCurrentPage<Xamarin.Forms.ContentPage> prevCarouselPage_CurrentPageOpt currCarouselPage_CurrentPageOpt target
        match prevCarouselPage_CurrentPageChangedOpt, currCarouselPage_CurrentPageChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.CurrentPageChanged.RemoveHandler(prevValue); target.CurrentPageChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.CurrentPageChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.CurrentPageChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a CarouselPage in the view
    static member inline CarouselPage(?children: ViewElement list,
                                      ?currentPage: int,
                                      ?currentPageChanged: int option -> unit,
                                      ?title: string,
                                      ?backgroundImage: string,
                                      ?icon: string,
                                      ?isBusy: bool,
                                      ?padding: obj,
                                      ?toolbarItems: ViewElement list,
                                      ?useSafeArea: bool,
                                      ?appearing: unit -> unit,
                                      ?disappearing: unit -> unit,
                                      ?layoutChanged: unit -> unit,
                                      ?anchorX: double,
                                      ?anchorY: double,
                                      ?backgroundColor: Xamarin.Forms.Color,
                                      ?heightRequest: double,
                                      ?inputTransparent: bool,
                                      ?isEnabled: bool,
                                      ?isVisible: bool,
                                      ?minimumHeightRequest: double,
                                      ?minimumWidthRequest: double,
                                      ?opacity: double,
                                      ?rotation: double,
                                      ?rotationX: double,
                                      ?rotationY: double,
                                      ?scale: double,
                                      ?style: Xamarin.Forms.Style,
                                      ?styleClass: obj,
                                      ?translationX: double,
                                      ?translationY: double,
                                      ?widthRequest: double,
                                      ?resources: (string * obj) list,
                                      ?styles: Xamarin.Forms.Style list,
                                      ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                      ?isTabStop: bool,
                                      ?scaleX: double,
                                      ?scaleY: double,
                                      ?tabIndex: int,
                                      ?classId: string,
                                      ?styleId: string,
                                      ?automationId: string,
                                      ?created: (Xamarin.Forms.CarouselPage -> unit),
                                      ?ref: ViewRef<Xamarin.Forms.CarouselPage>) = 

        let attribBuilder = View.BuildCarouselPage(0,
                               ?children=children,
                               ?currentPage=currentPage,
                               ?currentPageChanged=currentPageChanged,
                               ?title=title,
                               ?backgroundImage=backgroundImage,
                               ?icon=icon,
                               ?isBusy=isBusy,
                               ?padding=padding,
                               ?toolbarItems=toolbarItems,
                               ?useSafeArea=useSafeArea,
                               ?appearing=appearing,
                               ?disappearing=disappearing,
                               ?layoutChanged=layoutChanged,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.CarouselPage> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.CarouselPage>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.CarouselPage>(View.CreateFuncCarouselPage, View.UpdateFuncCarouselPage, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoCarouselPage : ViewElement option = None with get, set

    /// Builds the attributes for a NavigationPage in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildNavigationPage(attribCount: int,
                                             ?pages: ViewElement list,
                                             ?barBackgroundColor: Xamarin.Forms.Color,
                                             ?barTextColor: Xamarin.Forms.Color,
                                             ?popped: Xamarin.Forms.NavigationEventArgs -> unit,
                                             ?poppedToRoot: Xamarin.Forms.NavigationEventArgs -> unit,
                                             ?pushed: Xamarin.Forms.NavigationEventArgs -> unit,
                                             ?title: string,
                                             ?backgroundImage: string,
                                             ?icon: string,
                                             ?isBusy: bool,
                                             ?padding: obj,
                                             ?toolbarItems: ViewElement list,
                                             ?useSafeArea: bool,
                                             ?appearing: unit -> unit,
                                             ?disappearing: unit -> unit,
                                             ?layoutChanged: unit -> unit,
                                             ?anchorX: double,
                                             ?anchorY: double,
                                             ?backgroundColor: Xamarin.Forms.Color,
                                             ?heightRequest: double,
                                             ?inputTransparent: bool,
                                             ?isEnabled: bool,
                                             ?isVisible: bool,
                                             ?minimumHeightRequest: double,
                                             ?minimumWidthRequest: double,
                                             ?opacity: double,
                                             ?rotation: double,
                                             ?rotationX: double,
                                             ?rotationY: double,
                                             ?scale: double,
                                             ?style: Xamarin.Forms.Style,
                                             ?styleClass: obj,
                                             ?translationX: double,
                                             ?translationY: double,
                                             ?widthRequest: double,
                                             ?resources: (string * obj) list,
                                             ?styles: Xamarin.Forms.Style list,
                                             ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                             ?isTabStop: bool,
                                             ?scaleX: double,
                                             ?scaleY: double,
                                             ?tabIndex: int,
                                             ?classId: string,
                                             ?styleId: string,
                                             ?automationId: string,
                                             ?created: obj -> unit,
                                             ?ref: ViewRef) = 

        let attribCount = match pages with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barBackgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barTextColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match popped with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match poppedToRoot with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match pushed with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match pages with None -> () | Some v -> attribBuilder.Add(View._PagesAttribKey, Array.ofList(v)) 
        match barBackgroundColor with None -> () | Some v -> attribBuilder.Add(View._BarBackgroundColorAttribKey, (v)) 
        match barTextColor with None -> () | Some v -> attribBuilder.Add(View._BarTextColorAttribKey, (v)) 
        match popped with None -> () | Some v -> attribBuilder.Add(View._PoppedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v)) 
        match poppedToRoot with None -> () | Some v -> attribBuilder.Add(View._PoppedToRootAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v)) 
        match pushed with None -> () | Some v -> attribBuilder.Add(View._PushedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncNavigationPage : (unit -> Xamarin.Forms.NavigationPage) = (fun () -> View.CreateNavigationPage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateNavigationPage () : Xamarin.Forms.NavigationPage = 
        upcast (new Xamarin.Forms.NavigationPage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncNavigationPage = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.NavigationPage) -> View.UpdateNavigationPage (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateNavigationPage (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.NavigationPage) = 
        // update the inherited Page element
        let baseElement = (if View.ProtoPage.IsNone then View.ProtoPage <- Some (View.Page())); View.ProtoPage.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevPagesOpt = ValueNone
        let mutable currPagesOpt = ValueNone
        let mutable prevBarBackgroundColorOpt = ValueNone
        let mutable currBarBackgroundColorOpt = ValueNone
        let mutable prevBarTextColorOpt = ValueNone
        let mutable currBarTextColorOpt = ValueNone
        let mutable prevPoppedOpt = ValueNone
        let mutable currPoppedOpt = ValueNone
        let mutable prevPoppedToRootOpt = ValueNone
        let mutable currPoppedToRootOpt = ValueNone
        let mutable prevPushedOpt = ValueNone
        let mutable currPushedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._PagesAttribKey.KeyValue then 
                currPagesOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = View._BarBackgroundColorAttribKey.KeyValue then 
                currBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._BarTextColorAttribKey.KeyValue then 
                currBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._PoppedAttribKey.KeyValue then 
                currPoppedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
            if kvp.Key = View._PoppedToRootAttribKey.KeyValue then 
                currPoppedToRootOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
            if kvp.Key = View._PushedAttribKey.KeyValue then 
                currPushedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._PagesAttribKey.KeyValue then 
                    prevPagesOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = View._BarBackgroundColorAttribKey.KeyValue then 
                    prevBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._BarTextColorAttribKey.KeyValue then 
                    prevBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._PoppedAttribKey.KeyValue then 
                    prevPoppedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
                if kvp.Key = View._PoppedToRootAttribKey.KeyValue then 
                    prevPoppedToRootOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
                if kvp.Key = View._PushedAttribKey.KeyValue then 
                    prevPushedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
        updateNavigationPages prevPagesOpt currPagesOpt target
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<string>(View._BackButtonTitleAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<string>(View._BackButtonTitleAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<bool>(View._HasBackButtonAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<bool>(View._HasBackButtonAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, true) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<bool>(View._HasNavigationBarAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<bool>(View._HasNavigationBarAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, true) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<string>(View._TitleIconAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<string>(View._TitleIconAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, makeFileImageSource currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<ViewElement>(View._TitleViewAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<ViewElement>(View._TitleViewAttribKey)
                updatePageTitleView prevChildValueOpt childValueOpt targetChild
                ())
        match prevBarBackgroundColorOpt, currBarBackgroundColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BarBackgroundColor <-  currValue
        | ValueSome _, ValueNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevBarTextColorOpt, currBarTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BarTextColor <-  currValue
        | ValueSome _, ValueNone -> target.BarTextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevPoppedOpt, currPoppedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Popped.RemoveHandler(prevValue); target.Popped.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Popped.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Popped.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevPoppedToRootOpt, currPoppedToRootOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.PoppedToRoot.RemoveHandler(prevValue); target.PoppedToRoot.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.PoppedToRoot.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.PoppedToRoot.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevPushedOpt, currPushedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Pushed.RemoveHandler(prevValue); target.Pushed.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Pushed.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Pushed.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a NavigationPage in the view
    static member inline NavigationPage(?pages: ViewElement list,
                                        ?barBackgroundColor: Xamarin.Forms.Color,
                                        ?barTextColor: Xamarin.Forms.Color,
                                        ?popped: Xamarin.Forms.NavigationEventArgs -> unit,
                                        ?poppedToRoot: Xamarin.Forms.NavigationEventArgs -> unit,
                                        ?pushed: Xamarin.Forms.NavigationEventArgs -> unit,
                                        ?title: string,
                                        ?backgroundImage: string,
                                        ?icon: string,
                                        ?isBusy: bool,
                                        ?padding: obj,
                                        ?toolbarItems: ViewElement list,
                                        ?useSafeArea: bool,
                                        ?appearing: unit -> unit,
                                        ?disappearing: unit -> unit,
                                        ?layoutChanged: unit -> unit,
                                        ?anchorX: double,
                                        ?anchorY: double,
                                        ?backgroundColor: Xamarin.Forms.Color,
                                        ?heightRequest: double,
                                        ?inputTransparent: bool,
                                        ?isEnabled: bool,
                                        ?isVisible: bool,
                                        ?minimumHeightRequest: double,
                                        ?minimumWidthRequest: double,
                                        ?opacity: double,
                                        ?rotation: double,
                                        ?rotationX: double,
                                        ?rotationY: double,
                                        ?scale: double,
                                        ?style: Xamarin.Forms.Style,
                                        ?styleClass: obj,
                                        ?translationX: double,
                                        ?translationY: double,
                                        ?widthRequest: double,
                                        ?resources: (string * obj) list,
                                        ?styles: Xamarin.Forms.Style list,
                                        ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                        ?isTabStop: bool,
                                        ?scaleX: double,
                                        ?scaleY: double,
                                        ?tabIndex: int,
                                        ?classId: string,
                                        ?styleId: string,
                                        ?automationId: string,
                                        ?created: (Xamarin.Forms.NavigationPage -> unit),
                                        ?ref: ViewRef<Xamarin.Forms.NavigationPage>) = 

        let attribBuilder = View.BuildNavigationPage(0,
                               ?pages=pages,
                               ?barBackgroundColor=barBackgroundColor,
                               ?barTextColor=barTextColor,
                               ?popped=popped,
                               ?poppedToRoot=poppedToRoot,
                               ?pushed=pushed,
                               ?title=title,
                               ?backgroundImage=backgroundImage,
                               ?icon=icon,
                               ?isBusy=isBusy,
                               ?padding=padding,
                               ?toolbarItems=toolbarItems,
                               ?useSafeArea=useSafeArea,
                               ?appearing=appearing,
                               ?disappearing=disappearing,
                               ?layoutChanged=layoutChanged,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.NavigationPage> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.NavigationPage>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.NavigationPage>(View.CreateFuncNavigationPage, View.UpdateFuncNavigationPage, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoNavigationPage : ViewElement option = None with get, set

    /// Builds the attributes for a TabbedPage in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildTabbedPage(attribCount: int,
                                         ?children: ViewElement list,
                                         ?barBackgroundColor: Xamarin.Forms.Color,
                                         ?barTextColor: Xamarin.Forms.Color,
                                         ?currentPage: int,
                                         ?currentPageChanged: int option -> unit,
                                         ?title: string,
                                         ?backgroundImage: string,
                                         ?icon: string,
                                         ?isBusy: bool,
                                         ?padding: obj,
                                         ?toolbarItems: ViewElement list,
                                         ?useSafeArea: bool,
                                         ?appearing: unit -> unit,
                                         ?disappearing: unit -> unit,
                                         ?layoutChanged: unit -> unit,
                                         ?anchorX: double,
                                         ?anchorY: double,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?heightRequest: double,
                                         ?inputTransparent: bool,
                                         ?isEnabled: bool,
                                         ?isVisible: bool,
                                         ?minimumHeightRequest: double,
                                         ?minimumWidthRequest: double,
                                         ?opacity: double,
                                         ?rotation: double,
                                         ?rotationX: double,
                                         ?rotationY: double,
                                         ?scale: double,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: obj,
                                         ?translationX: double,
                                         ?translationY: double,
                                         ?widthRequest: double,
                                         ?resources: (string * obj) list,
                                         ?styles: Xamarin.Forms.Style list,
                                         ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                         ?isTabStop: bool,
                                         ?scaleX: double,
                                         ?scaleY: double,
                                         ?tabIndex: int,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?automationId: string,
                                         ?created: obj -> unit,
                                         ?ref: ViewRef) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barBackgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barTextColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match currentPage with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match currentPageChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match children with None -> () | Some v -> attribBuilder.Add(View._ChildrenAttribKey, Array.ofList(v)) 
        match barBackgroundColor with None -> () | Some v -> attribBuilder.Add(View._BarBackgroundColorAttribKey, (v)) 
        match barTextColor with None -> () | Some v -> attribBuilder.Add(View._BarTextColorAttribKey, (v)) 
        match currentPage with None -> () | Some v -> attribBuilder.Add(View._TabbedPage_CurrentPageAttribKey, (v)) 
        match currentPageChanged with None -> () | Some v -> attribBuilder.Add(View._TabbedPage_CurrentPageChangedAttribKey, makeCurrentPageChanged<Xamarin.Forms.Page>(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncTabbedPage : (unit -> Xamarin.Forms.TabbedPage) = (fun () -> View.CreateTabbedPage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateTabbedPage () : Xamarin.Forms.TabbedPage = 
        upcast (new Xamarin.Forms.TabbedPage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncTabbedPage = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TabbedPage) -> View.UpdateTabbedPage (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateTabbedPage (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.TabbedPage) = 
        // update the inherited Page element
        let baseElement = (if View.ProtoPage.IsNone then View.ProtoPage <- Some (View.Page())); View.ProtoPage.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        let mutable prevBarBackgroundColorOpt = ValueNone
        let mutable currBarBackgroundColorOpt = ValueNone
        let mutable prevBarTextColorOpt = ValueNone
        let mutable currBarTextColorOpt = ValueNone
        let mutable prevTabbedPage_CurrentPageOpt = ValueNone
        let mutable currTabbedPage_CurrentPageOpt = ValueNone
        let mutable prevTabbedPage_CurrentPageChangedOpt = ValueNone
        let mutable currTabbedPage_CurrentPageChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = View._BarBackgroundColorAttribKey.KeyValue then 
                currBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._BarTextColorAttribKey.KeyValue then 
                currBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._TabbedPage_CurrentPageAttribKey.KeyValue then 
                currTabbedPage_CurrentPageOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._TabbedPage_CurrentPageChangedAttribKey.KeyValue then 
                currTabbedPage_CurrentPageChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = View._BarBackgroundColorAttribKey.KeyValue then 
                    prevBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._BarTextColorAttribKey.KeyValue then 
                    prevBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._TabbedPage_CurrentPageAttribKey.KeyValue then 
                    prevTabbedPage_CurrentPageOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._TabbedPage_CurrentPageChangedAttribKey.KeyValue then 
                    prevTabbedPage_CurrentPageChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.Page)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild
        match prevBarBackgroundColorOpt, currBarBackgroundColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BarBackgroundColor <-  currValue
        | ValueSome _, ValueNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevBarTextColorOpt, currBarTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.BarTextColor <-  currValue
        | ValueSome _, ValueNone -> target.BarTextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        updateCurrentPage<Xamarin.Forms.Page> prevTabbedPage_CurrentPageOpt currTabbedPage_CurrentPageOpt target
        match prevTabbedPage_CurrentPageChangedOpt, currTabbedPage_CurrentPageChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.CurrentPageChanged.RemoveHandler(prevValue); target.CurrentPageChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.CurrentPageChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.CurrentPageChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a TabbedPage in the view
    static member inline TabbedPage(?children: ViewElement list,
                                    ?barBackgroundColor: Xamarin.Forms.Color,
                                    ?barTextColor: Xamarin.Forms.Color,
                                    ?currentPage: int,
                                    ?currentPageChanged: int option -> unit,
                                    ?title: string,
                                    ?backgroundImage: string,
                                    ?icon: string,
                                    ?isBusy: bool,
                                    ?padding: obj,
                                    ?toolbarItems: ViewElement list,
                                    ?useSafeArea: bool,
                                    ?appearing: unit -> unit,
                                    ?disappearing: unit -> unit,
                                    ?layoutChanged: unit -> unit,
                                    ?anchorX: double,
                                    ?anchorY: double,
                                    ?backgroundColor: Xamarin.Forms.Color,
                                    ?heightRequest: double,
                                    ?inputTransparent: bool,
                                    ?isEnabled: bool,
                                    ?isVisible: bool,
                                    ?minimumHeightRequest: double,
                                    ?minimumWidthRequest: double,
                                    ?opacity: double,
                                    ?rotation: double,
                                    ?rotationX: double,
                                    ?rotationY: double,
                                    ?scale: double,
                                    ?style: Xamarin.Forms.Style,
                                    ?styleClass: obj,
                                    ?translationX: double,
                                    ?translationY: double,
                                    ?widthRequest: double,
                                    ?resources: (string * obj) list,
                                    ?styles: Xamarin.Forms.Style list,
                                    ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                    ?isTabStop: bool,
                                    ?scaleX: double,
                                    ?scaleY: double,
                                    ?tabIndex: int,
                                    ?classId: string,
                                    ?styleId: string,
                                    ?automationId: string,
                                    ?created: (Xamarin.Forms.TabbedPage -> unit),
                                    ?ref: ViewRef<Xamarin.Forms.TabbedPage>) = 

        let attribBuilder = View.BuildTabbedPage(0,
                               ?children=children,
                               ?barBackgroundColor=barBackgroundColor,
                               ?barTextColor=barTextColor,
                               ?currentPage=currentPage,
                               ?currentPageChanged=currentPageChanged,
                               ?title=title,
                               ?backgroundImage=backgroundImage,
                               ?icon=icon,
                               ?isBusy=isBusy,
                               ?padding=padding,
                               ?toolbarItems=toolbarItems,
                               ?useSafeArea=useSafeArea,
                               ?appearing=appearing,
                               ?disappearing=disappearing,
                               ?layoutChanged=layoutChanged,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.TabbedPage> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.TabbedPage>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.TabbedPage>(View.CreateFuncTabbedPage, View.UpdateFuncTabbedPage, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoTabbedPage : ViewElement option = None with get, set

    /// Builds the attributes for a ContentPage in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildContentPage(attribCount: int,
                                          ?content: ViewElement,
                                          ?onSizeAllocated: (double * double) -> unit,
                                          ?title: string,
                                          ?backgroundImage: string,
                                          ?icon: string,
                                          ?isBusy: bool,
                                          ?padding: obj,
                                          ?toolbarItems: ViewElement list,
                                          ?useSafeArea: bool,
                                          ?appearing: unit -> unit,
                                          ?disappearing: unit -> unit,
                                          ?layoutChanged: unit -> unit,
                                          ?anchorX: double,
                                          ?anchorY: double,
                                          ?backgroundColor: Xamarin.Forms.Color,
                                          ?heightRequest: double,
                                          ?inputTransparent: bool,
                                          ?isEnabled: bool,
                                          ?isVisible: bool,
                                          ?minimumHeightRequest: double,
                                          ?minimumWidthRequest: double,
                                          ?opacity: double,
                                          ?rotation: double,
                                          ?rotationX: double,
                                          ?rotationY: double,
                                          ?scale: double,
                                          ?style: Xamarin.Forms.Style,
                                          ?styleClass: obj,
                                          ?translationX: double,
                                          ?translationY: double,
                                          ?widthRequest: double,
                                          ?resources: (string * obj) list,
                                          ?styles: Xamarin.Forms.Style list,
                                          ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                          ?isTabStop: bool,
                                          ?scaleX: double,
                                          ?scaleY: double,
                                          ?tabIndex: int,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?automationId: string,
                                          ?created: obj -> unit,
                                          ?ref: ViewRef) = 

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match onSizeAllocated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match content with None -> () | Some v -> attribBuilder.Add(View._ContentAttribKey, (v)) 
        match onSizeAllocated with None -> () | Some v -> attribBuilder.Add(View._OnSizeAllocatedCallbackAttribKey, (fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncContentPage : (unit -> Xamarin.Forms.ContentPage) = (fun () -> View.CreateContentPage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateContentPage () : Xamarin.Forms.ContentPage = 
        upcast (new Fabulous.DynamicViews.CustomContentPage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncContentPage = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ContentPage) -> View.UpdateContentPage (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateContentPage (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ContentPage) = 
        // update the inherited Page element
        let baseElement = (if View.ProtoPage.IsNone then View.ProtoPage <- Some (View.Page())); View.ProtoPage.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevContentOpt = ValueNone
        let mutable currContentOpt = ValueNone
        let mutable prevOnSizeAllocatedCallbackOpt = ValueNone
        let mutable currOnSizeAllocatedCallbackOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ContentAttribKey.KeyValue then 
                currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = View._OnSizeAllocatedCallbackAttribKey.KeyValue then 
                currOnSizeAllocatedCallbackOpt <- ValueSome (kvp.Value :?> FSharp.Control.Handler<(double * double)>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ContentAttribKey.KeyValue then 
                    prevContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = View._OnSizeAllocatedCallbackAttribKey.KeyValue then 
                    prevOnSizeAllocatedCallbackOpt <- ValueSome (kvp.Value :?> FSharp.Control.Handler<(double * double)>)
        match prevContentOpt, currContentOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.Content)
        | _, ValueSome newValue ->
            target.Content <- (newValue.Create() :?> Xamarin.Forms.View)
        | ValueSome _, ValueNone ->
            target.Content <- null
        | ValueNone, ValueNone -> ()
        updateOnSizeAllocated prevOnSizeAllocatedCallbackOpt currOnSizeAllocatedCallbackOpt target

    /// Describes a ContentPage in the view
    static member inline ContentPage(?content: ViewElement,
                                     ?onSizeAllocated: (double * double) -> unit,
                                     ?title: string,
                                     ?backgroundImage: string,
                                     ?icon: string,
                                     ?isBusy: bool,
                                     ?padding: obj,
                                     ?toolbarItems: ViewElement list,
                                     ?useSafeArea: bool,
                                     ?appearing: unit -> unit,
                                     ?disappearing: unit -> unit,
                                     ?layoutChanged: unit -> unit,
                                     ?anchorX: double,
                                     ?anchorY: double,
                                     ?backgroundColor: Xamarin.Forms.Color,
                                     ?heightRequest: double,
                                     ?inputTransparent: bool,
                                     ?isEnabled: bool,
                                     ?isVisible: bool,
                                     ?minimumHeightRequest: double,
                                     ?minimumWidthRequest: double,
                                     ?opacity: double,
                                     ?rotation: double,
                                     ?rotationX: double,
                                     ?rotationY: double,
                                     ?scale: double,
                                     ?style: Xamarin.Forms.Style,
                                     ?styleClass: obj,
                                     ?translationX: double,
                                     ?translationY: double,
                                     ?widthRequest: double,
                                     ?resources: (string * obj) list,
                                     ?styles: Xamarin.Forms.Style list,
                                     ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                     ?isTabStop: bool,
                                     ?scaleX: double,
                                     ?scaleY: double,
                                     ?tabIndex: int,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: (Xamarin.Forms.ContentPage -> unit),
                                     ?ref: ViewRef<Xamarin.Forms.ContentPage>) = 

        let attribBuilder = View.BuildContentPage(0,
                               ?content=content,
                               ?onSizeAllocated=onSizeAllocated,
                               ?title=title,
                               ?backgroundImage=backgroundImage,
                               ?icon=icon,
                               ?isBusy=isBusy,
                               ?padding=padding,
                               ?toolbarItems=toolbarItems,
                               ?useSafeArea=useSafeArea,
                               ?appearing=appearing,
                               ?disappearing=disappearing,
                               ?layoutChanged=layoutChanged,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ContentPage> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ContentPage>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ContentPage>(View.CreateFuncContentPage, View.UpdateFuncContentPage, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoContentPage : ViewElement option = None with get, set

    /// Builds the attributes for a MasterDetailPage in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildMasterDetailPage(attribCount: int,
                                               ?master: ViewElement,
                                               ?detail: ViewElement,
                                               ?isGestureEnabled: bool,
                                               ?isPresented: bool,
                                               ?masterBehavior: Xamarin.Forms.MasterBehavior,
                                               ?isPresentedChanged: bool -> unit,
                                               ?title: string,
                                               ?backgroundImage: string,
                                               ?icon: string,
                                               ?isBusy: bool,
                                               ?padding: obj,
                                               ?toolbarItems: ViewElement list,
                                               ?useSafeArea: bool,
                                               ?appearing: unit -> unit,
                                               ?disappearing: unit -> unit,
                                               ?layoutChanged: unit -> unit,
                                               ?anchorX: double,
                                               ?anchorY: double,
                                               ?backgroundColor: Xamarin.Forms.Color,
                                               ?heightRequest: double,
                                               ?inputTransparent: bool,
                                               ?isEnabled: bool,
                                               ?isVisible: bool,
                                               ?minimumHeightRequest: double,
                                               ?minimumWidthRequest: double,
                                               ?opacity: double,
                                               ?rotation: double,
                                               ?rotationX: double,
                                               ?rotationY: double,
                                               ?scale: double,
                                               ?style: Xamarin.Forms.Style,
                                               ?styleClass: obj,
                                               ?translationX: double,
                                               ?translationY: double,
                                               ?widthRequest: double,
                                               ?resources: (string * obj) list,
                                               ?styles: Xamarin.Forms.Style list,
                                               ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                               ?isTabStop: bool,
                                               ?scaleX: double,
                                               ?scaleY: double,
                                               ?tabIndex: int,
                                               ?classId: string,
                                               ?styleId: string,
                                               ?automationId: string,
                                               ?created: obj -> unit,
                                               ?ref: ViewRef) = 

        let attribCount = match master with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match detail with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isGestureEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isPresented with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match masterBehavior with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isPresentedChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match master with None -> () | Some v -> attribBuilder.Add(View._MasterAttribKey, (v)) 
        match detail with None -> () | Some v -> attribBuilder.Add(View._DetailAttribKey, (v)) 
        match isGestureEnabled with None -> () | Some v -> attribBuilder.Add(View._IsGestureEnabledAttribKey, (v)) 
        match isPresented with None -> () | Some v -> attribBuilder.Add(View._IsPresentedAttribKey, (v)) 
        match masterBehavior with None -> () | Some v -> attribBuilder.Add(View._MasterBehaviorAttribKey, (v)) 
        match isPresentedChanged with None -> () | Some v -> attribBuilder.Add(View._IsPresentedChangedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncMasterDetailPage : (unit -> Xamarin.Forms.MasterDetailPage) = (fun () -> View.CreateMasterDetailPage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateMasterDetailPage () : Xamarin.Forms.MasterDetailPage = 
        upcast (new Xamarin.Forms.MasterDetailPage())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncMasterDetailPage = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.MasterDetailPage) -> View.UpdateMasterDetailPage (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateMasterDetailPage (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.MasterDetailPage) = 
        // update the inherited Page element
        let baseElement = (if View.ProtoPage.IsNone then View.ProtoPage <- Some (View.Page())); View.ProtoPage.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevMasterOpt = ValueNone
        let mutable currMasterOpt = ValueNone
        let mutable prevDetailOpt = ValueNone
        let mutable currDetailOpt = ValueNone
        let mutable prevIsGestureEnabledOpt = ValueNone
        let mutable currIsGestureEnabledOpt = ValueNone
        let mutable prevIsPresentedOpt = ValueNone
        let mutable currIsPresentedOpt = ValueNone
        let mutable prevMasterBehaviorOpt = ValueNone
        let mutable currMasterBehaviorOpt = ValueNone
        let mutable prevIsPresentedChangedOpt = ValueNone
        let mutable currIsPresentedChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._MasterAttribKey.KeyValue then 
                currMasterOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = View._DetailAttribKey.KeyValue then 
                currDetailOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = View._IsGestureEnabledAttribKey.KeyValue then 
                currIsGestureEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._IsPresentedAttribKey.KeyValue then 
                currIsPresentedOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._MasterBehaviorAttribKey.KeyValue then 
                currMasterBehaviorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.MasterBehavior)
            if kvp.Key = View._IsPresentedChangedAttribKey.KeyValue then 
                currIsPresentedChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._MasterAttribKey.KeyValue then 
                    prevMasterOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = View._DetailAttribKey.KeyValue then 
                    prevDetailOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = View._IsGestureEnabledAttribKey.KeyValue then 
                    prevIsGestureEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._IsPresentedAttribKey.KeyValue then 
                    prevIsPresentedOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._MasterBehaviorAttribKey.KeyValue then 
                    prevMasterBehaviorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.MasterBehavior)
                if kvp.Key = View._IsPresentedChangedAttribKey.KeyValue then 
                    prevIsPresentedChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevMasterOpt, currMasterOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.Master)
        | _, ValueSome newValue ->
            target.Master <- (newValue.Create() :?> Xamarin.Forms.Page)
        | ValueSome _, ValueNone ->
            target.Master <- null
        | ValueNone, ValueNone -> ()
        match prevDetailOpt, currDetailOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.Detail)
        | _, ValueSome newValue ->
            target.Detail <- (newValue.Create() :?> Xamarin.Forms.Page)
        | ValueSome _, ValueNone ->
            target.Detail <- null
        | ValueNone, ValueNone -> ()
        match prevIsGestureEnabledOpt, currIsGestureEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsGestureEnabled <-  currValue
        | ValueSome _, ValueNone -> target.IsGestureEnabled <- true
        | ValueNone, ValueNone -> ()
        match prevIsPresentedOpt, currIsPresentedOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsPresented <-  currValue
        | ValueSome _, ValueNone -> target.IsPresented <- true
        | ValueNone, ValueNone -> ()
        match prevMasterBehaviorOpt, currMasterBehaviorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.MasterBehavior <-  currValue
        | ValueSome _, ValueNone -> target.MasterBehavior <- Xamarin.Forms.MasterBehavior.Default
        | ValueNone, ValueNone -> ()
        match prevIsPresentedChangedOpt, currIsPresentedChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.IsPresentedChanged.RemoveHandler(prevValue); target.IsPresentedChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.IsPresentedChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.IsPresentedChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a MasterDetailPage in the view
    static member inline MasterDetailPage(?master: ViewElement,
                                          ?detail: ViewElement,
                                          ?isGestureEnabled: bool,
                                          ?isPresented: bool,
                                          ?masterBehavior: Xamarin.Forms.MasterBehavior,
                                          ?isPresentedChanged: bool -> unit,
                                          ?title: string,
                                          ?backgroundImage: string,
                                          ?icon: string,
                                          ?isBusy: bool,
                                          ?padding: obj,
                                          ?toolbarItems: ViewElement list,
                                          ?useSafeArea: bool,
                                          ?appearing: unit -> unit,
                                          ?disappearing: unit -> unit,
                                          ?layoutChanged: unit -> unit,
                                          ?anchorX: double,
                                          ?anchorY: double,
                                          ?backgroundColor: Xamarin.Forms.Color,
                                          ?heightRequest: double,
                                          ?inputTransparent: bool,
                                          ?isEnabled: bool,
                                          ?isVisible: bool,
                                          ?minimumHeightRequest: double,
                                          ?minimumWidthRequest: double,
                                          ?opacity: double,
                                          ?rotation: double,
                                          ?rotationX: double,
                                          ?rotationY: double,
                                          ?scale: double,
                                          ?style: Xamarin.Forms.Style,
                                          ?styleClass: obj,
                                          ?translationX: double,
                                          ?translationY: double,
                                          ?widthRequest: double,
                                          ?resources: (string * obj) list,
                                          ?styles: Xamarin.Forms.Style list,
                                          ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                          ?isTabStop: bool,
                                          ?scaleX: double,
                                          ?scaleY: double,
                                          ?tabIndex: int,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?automationId: string,
                                          ?created: (Xamarin.Forms.MasterDetailPage -> unit),
                                          ?ref: ViewRef<Xamarin.Forms.MasterDetailPage>) = 

        let attribBuilder = View.BuildMasterDetailPage(0,
                               ?master=master,
                               ?detail=detail,
                               ?isGestureEnabled=isGestureEnabled,
                               ?isPresented=isPresented,
                               ?masterBehavior=masterBehavior,
                               ?isPresentedChanged=isPresentedChanged,
                               ?title=title,
                               ?backgroundImage=backgroundImage,
                               ?icon=icon,
                               ?isBusy=isBusy,
                               ?padding=padding,
                               ?toolbarItems=toolbarItems,
                               ?useSafeArea=useSafeArea,
                               ?appearing=appearing,
                               ?disappearing=disappearing,
                               ?layoutChanged=layoutChanged,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.MasterDetailPage> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.MasterDetailPage>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.MasterDetailPage>(View.CreateFuncMasterDetailPage, View.UpdateFuncMasterDetailPage, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoMasterDetailPage : ViewElement option = None with get, set

    /// Builds the attributes for a MenuItem in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildMenuItem(attribCount: int,
                                       ?text: string,
                                       ?command: unit -> unit,
                                       ?commandParameter: System.Object,
                                       ?icon: string,
                                       ?classId: string,
                                       ?styleId: string,
                                       ?automationId: string,
                                       ?created: obj -> unit,
                                       ?ref: ViewRef) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match commandParameter with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match icon with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildElement(attribCount, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        match command with None -> () | Some v -> attribBuilder.Add(View._CommandAttribKey, makeCommand(v)) 
        match commandParameter with None -> () | Some v -> attribBuilder.Add(View._CommandParameterAttribKey, (v)) 
        match icon with None -> () | Some v -> attribBuilder.Add(View._IconAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncMenuItem : (unit -> Xamarin.Forms.MenuItem) = (fun () -> View.CreateMenuItem())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateMenuItem () : Xamarin.Forms.MenuItem = 
        upcast (new Xamarin.Forms.MenuItem())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncMenuItem = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.MenuItem) -> View.UpdateMenuItem (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateMenuItem (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.MenuItem) = 
        // update the inherited Element element
        let baseElement = (if View.ProtoElement.IsNone then View.ProtoElement <- Some (View.Element())); View.ProtoElement.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevCommandOpt = ValueNone
        let mutable currCommandOpt = ValueNone
        let mutable prevCommandParameterOpt = ValueNone
        let mutable currCommandParameterOpt = ValueNone
        let mutable prevIconOpt = ValueNone
        let mutable currIconOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._CommandAttribKey.KeyValue then 
                currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = View._CommandParameterAttribKey.KeyValue then 
                currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = View._IconAttribKey.KeyValue then 
                currIconOpt <- ValueSome (kvp.Value :?> string)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._CommandAttribKey.KeyValue then 
                    prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = View._CommandParameterAttribKey.KeyValue then 
                    prevCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = View._IconAttribKey.KeyValue then 
                    prevIconOpt <- ValueSome (kvp.Value :?> string)
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevCommandOpt, currCommandOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Command <-  currValue
        | ValueSome _, ValueNone -> target.Command <- null
        | ValueNone, ValueNone -> ()
        match prevCommandParameterOpt, currCommandParameterOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CommandParameter <-  currValue
        | ValueSome _, ValueNone -> target.CommandParameter <- null
        | ValueNone, ValueNone -> ()
        match prevIconOpt, currIconOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Icon <- makeFileImageSource currValue
        | ValueSome _, ValueNone -> target.Icon <- null
        | ValueNone, ValueNone -> ()

    /// Describes a MenuItem in the view
    static member inline MenuItem(?text: string,
                                  ?command: unit -> unit,
                                  ?commandParameter: System.Object,
                                  ?icon: string,
                                  ?classId: string,
                                  ?styleId: string,
                                  ?automationId: string,
                                  ?created: (Xamarin.Forms.MenuItem -> unit),
                                  ?ref: ViewRef<Xamarin.Forms.MenuItem>) = 

        let attribBuilder = View.BuildMenuItem(0,
                               ?text=text,
                               ?command=command,
                               ?commandParameter=commandParameter,
                               ?icon=icon,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.MenuItem> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.MenuItem>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.MenuItem>(View.CreateFuncMenuItem, View.UpdateFuncMenuItem, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoMenuItem : ViewElement option = None with get, set

    /// Builds the attributes for a TextCell in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildTextCell(attribCount: int,
                                       ?text: string,
                                       ?detail: string,
                                       ?textColor: Xamarin.Forms.Color,
                                       ?detailColor: Xamarin.Forms.Color,
                                       ?command: unit -> unit,
                                       ?canExecute: bool,
                                       ?commandParameter: System.Object,
                                       ?height: double,
                                       ?isEnabled: bool,
                                       ?classId: string,
                                       ?styleId: string,
                                       ?automationId: string,
                                       ?created: obj -> unit,
                                       ?ref: ViewRef) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match detail with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match detailColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match canExecute with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match commandParameter with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match text with None -> () | Some v -> attribBuilder.Add(View._TextAttribKey, (v)) 
        match detail with None -> () | Some v -> attribBuilder.Add(View._TextDetailAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(View._TextColorAttribKey, (v)) 
        match detailColor with None -> () | Some v -> attribBuilder.Add(View._TextDetailColorAttribKey, (v)) 
        match command with None -> () | Some v -> attribBuilder.Add(View._TextCellCommandAttribKey, (v)) 
        match canExecute with None -> () | Some v -> attribBuilder.Add(View._TextCellCanExecuteAttribKey, (v)) 
        match commandParameter with None -> () | Some v -> attribBuilder.Add(View._CommandParameterAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncTextCell : (unit -> Xamarin.Forms.TextCell) = (fun () -> View.CreateTextCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateTextCell () : Xamarin.Forms.TextCell = 
        upcast (new Xamarin.Forms.TextCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncTextCell = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TextCell) -> View.UpdateTextCell (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateTextCell (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.TextCell) = 
        // update the inherited Cell element
        let baseElement = (if View.ProtoCell.IsNone then View.ProtoCell <- Some (View.Cell())); View.ProtoCell.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevTextDetailOpt = ValueNone
        let mutable currTextDetailOpt = ValueNone
        let mutable prevTextColorOpt = ValueNone
        let mutable currTextColorOpt = ValueNone
        let mutable prevTextDetailColorOpt = ValueNone
        let mutable currTextDetailColorOpt = ValueNone
        let mutable prevTextCellCommandOpt = ValueNone
        let mutable currTextCellCommandOpt = ValueNone
        let mutable prevTextCellCanExecuteOpt = ValueNone
        let mutable currTextCellCanExecuteOpt = ValueNone
        let mutable prevCommandParameterOpt = ValueNone
        let mutable currCommandParameterOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._TextDetailAttribKey.KeyValue then 
                currTextDetailOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = View._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._TextDetailColorAttribKey.KeyValue then 
                currTextDetailColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._TextCellCommandAttribKey.KeyValue then 
                currTextCellCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
            if kvp.Key = View._TextCellCanExecuteAttribKey.KeyValue then 
                currTextCellCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._CommandParameterAttribKey.KeyValue then 
                currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._TextDetailAttribKey.KeyValue then 
                    prevTextDetailOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = View._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._TextDetailColorAttribKey.KeyValue then 
                    prevTextDetailColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._TextCellCommandAttribKey.KeyValue then 
                    prevTextCellCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = View._TextCellCanExecuteAttribKey.KeyValue then 
                    prevTextCellCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._CommandParameterAttribKey.KeyValue then 
                    prevCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
        match prevTextOpt, currTextOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Text <-  currValue
        | ValueSome _, ValueNone -> target.Text <- null
        | ValueNone, ValueNone -> ()
        match prevTextDetailOpt, currTextDetailOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Detail <-  currValue
        | ValueSome _, ValueNone -> target.Detail <- null
        | ValueNone, ValueNone -> ()
        match prevTextColorOpt, currTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextColor <-  currValue
        | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevTextDetailColorOpt, currTextDetailColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.DetailColor <-  currValue
        | ValueSome _, ValueNone -> target.DetailColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        (fun _ _ _ -> ()) prevTextCellCommandOpt currTextCellCommandOpt target
        updateCommand prevTextCellCommandOpt currTextCellCommandOpt (fun _target -> ()) (fun (target: Xamarin.Forms.TextCell) cmd -> target.Command <- cmd) prevTextCellCanExecuteOpt currTextCellCanExecuteOpt target
        match prevCommandParameterOpt, currCommandParameterOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.CommandParameter <-  currValue
        | ValueSome _, ValueNone -> target.CommandParameter <- null
        | ValueNone, ValueNone -> ()

    /// Describes a TextCell in the view
    static member inline TextCell(?text: string,
                                  ?detail: string,
                                  ?textColor: Xamarin.Forms.Color,
                                  ?detailColor: Xamarin.Forms.Color,
                                  ?command: unit -> unit,
                                  ?canExecute: bool,
                                  ?commandParameter: System.Object,
                                  ?height: double,
                                  ?isEnabled: bool,
                                  ?classId: string,
                                  ?styleId: string,
                                  ?automationId: string,
                                  ?created: (Xamarin.Forms.TextCell -> unit),
                                  ?ref: ViewRef<Xamarin.Forms.TextCell>) = 

        let attribBuilder = View.BuildTextCell(0,
                               ?text=text,
                               ?detail=detail,
                               ?textColor=textColor,
                               ?detailColor=detailColor,
                               ?command=command,
                               ?canExecute=canExecute,
                               ?commandParameter=commandParameter,
                               ?height=height,
                               ?isEnabled=isEnabled,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.TextCell> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.TextCell>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.TextCell>(View.CreateFuncTextCell, View.UpdateFuncTextCell, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoTextCell : ViewElement option = None with get, set

    /// Builds the attributes for a ToolbarItem in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildToolbarItem(attribCount: int,
                                          ?order: Xamarin.Forms.ToolbarItemOrder,
                                          ?priority: int,
                                          ?text: string,
                                          ?command: unit -> unit,
                                          ?commandParameter: System.Object,
                                          ?icon: string,
                                          ?classId: string,
                                          ?styleId: string,
                                          ?automationId: string,
                                          ?created: obj -> unit,
                                          ?ref: ViewRef) = 

        let attribCount = match order with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match priority with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildMenuItem(attribCount, ?text=text, ?command=command, ?commandParameter=commandParameter, ?icon=icon, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match order with None -> () | Some v -> attribBuilder.Add(View._OrderAttribKey, (v)) 
        match priority with None -> () | Some v -> attribBuilder.Add(View._PriorityAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncToolbarItem : (unit -> Xamarin.Forms.ToolbarItem) = (fun () -> View.CreateToolbarItem())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateToolbarItem () : Xamarin.Forms.ToolbarItem = 
        upcast (new Xamarin.Forms.ToolbarItem())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncToolbarItem = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ToolbarItem) -> View.UpdateToolbarItem (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateToolbarItem (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ToolbarItem) = 
        // update the inherited MenuItem element
        let baseElement = (if View.ProtoMenuItem.IsNone then View.ProtoMenuItem <- Some (View.MenuItem())); View.ProtoMenuItem.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevOrderOpt = ValueNone
        let mutable currOrderOpt = ValueNone
        let mutable prevPriorityOpt = ValueNone
        let mutable currPriorityOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._OrderAttribKey.KeyValue then 
                currOrderOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ToolbarItemOrder)
            if kvp.Key = View._PriorityAttribKey.KeyValue then 
                currPriorityOpt <- ValueSome (kvp.Value :?> int)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._OrderAttribKey.KeyValue then 
                    prevOrderOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ToolbarItemOrder)
                if kvp.Key = View._PriorityAttribKey.KeyValue then 
                    prevPriorityOpt <- ValueSome (kvp.Value :?> int)
        match prevOrderOpt, currOrderOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Order <-  currValue
        | ValueSome _, ValueNone -> target.Order <- Xamarin.Forms.ToolbarItemOrder.Default
        | ValueNone, ValueNone -> ()
        match prevPriorityOpt, currPriorityOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Priority <-  currValue
        | ValueSome _, ValueNone -> target.Priority <- 0
        | ValueNone, ValueNone -> ()

    /// Describes a ToolbarItem in the view
    static member inline ToolbarItem(?order: Xamarin.Forms.ToolbarItemOrder,
                                     ?priority: int,
                                     ?text: string,
                                     ?command: unit -> unit,
                                     ?commandParameter: System.Object,
                                     ?icon: string,
                                     ?classId: string,
                                     ?styleId: string,
                                     ?automationId: string,
                                     ?created: (Xamarin.Forms.ToolbarItem -> unit),
                                     ?ref: ViewRef<Xamarin.Forms.ToolbarItem>) = 

        let attribBuilder = View.BuildToolbarItem(0,
                               ?order=order,
                               ?priority=priority,
                               ?text=text,
                               ?command=command,
                               ?commandParameter=commandParameter,
                               ?icon=icon,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ToolbarItem> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ToolbarItem>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ToolbarItem>(View.CreateFuncToolbarItem, View.UpdateFuncToolbarItem, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoToolbarItem : ViewElement option = None with get, set

    /// Builds the attributes for a ImageCell in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildImageCell(attribCount: int,
                                        ?imageSource: obj,
                                        ?text: string,
                                        ?detail: string,
                                        ?textColor: Xamarin.Forms.Color,
                                        ?detailColor: Xamarin.Forms.Color,
                                        ?command: unit -> unit,
                                        ?canExecute: bool,
                                        ?commandParameter: System.Object,
                                        ?height: double,
                                        ?isEnabled: bool,
                                        ?classId: string,
                                        ?styleId: string,
                                        ?automationId: string,
                                        ?created: obj -> unit,
                                        ?ref: ViewRef) = 

        let attribCount = match imageSource with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildTextCell(attribCount, ?text=text, ?detail=detail, ?textColor=textColor, ?detailColor=detailColor, ?command=command, ?canExecute=canExecute, ?commandParameter=commandParameter, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match imageSource with None -> () | Some v -> attribBuilder.Add(View._ImageSourceAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncImageCell : (unit -> Xamarin.Forms.ImageCell) = (fun () -> View.CreateImageCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateImageCell () : Xamarin.Forms.ImageCell = 
        upcast (new Xamarin.Forms.ImageCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncImageCell = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ImageCell) -> View.UpdateImageCell (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateImageCell (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ImageCell) = 
        // update the inherited TextCell element
        let baseElement = (if View.ProtoTextCell.IsNone then View.ProtoTextCell <- Some (View.TextCell())); View.ProtoTextCell.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevImageSourceOpt = ValueNone
        let mutable currImageSourceOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ImageSourceAttribKey.KeyValue then 
                currImageSourceOpt <- ValueSome (kvp.Value :?> obj)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ImageSourceAttribKey.KeyValue then 
                    prevImageSourceOpt <- ValueSome (kvp.Value :?> obj)
        match prevImageSourceOpt, currImageSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ImageSource <- makeImageSource currValue
        | ValueSome _, ValueNone -> target.ImageSource <- null
        | ValueNone, ValueNone -> ()

    /// Describes a ImageCell in the view
    static member inline ImageCell(?imageSource: obj,
                                   ?text: string,
                                   ?detail: string,
                                   ?textColor: Xamarin.Forms.Color,
                                   ?detailColor: Xamarin.Forms.Color,
                                   ?command: unit -> unit,
                                   ?canExecute: bool,
                                   ?commandParameter: System.Object,
                                   ?height: double,
                                   ?isEnabled: bool,
                                   ?classId: string,
                                   ?styleId: string,
                                   ?automationId: string,
                                   ?created: (Xamarin.Forms.ImageCell -> unit),
                                   ?ref: ViewRef<Xamarin.Forms.ImageCell>) = 

        let attribBuilder = View.BuildImageCell(0,
                               ?imageSource=imageSource,
                               ?text=text,
                               ?detail=detail,
                               ?textColor=textColor,
                               ?detailColor=detailColor,
                               ?command=command,
                               ?canExecute=canExecute,
                               ?commandParameter=commandParameter,
                               ?height=height,
                               ?isEnabled=isEnabled,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ImageCell> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ImageCell>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ImageCell>(View.CreateFuncImageCell, View.UpdateFuncImageCell, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoImageCell : ViewElement option = None with get, set

    /// Builds the attributes for a ViewCell in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildViewCell(attribCount: int,
                                       ?view: ViewElement,
                                       ?height: double,
                                       ?isEnabled: bool,
                                       ?classId: string,
                                       ?styleId: string,
                                       ?automationId: string,
                                       ?created: obj -> unit,
                                       ?ref: ViewRef) = 

        let attribCount = match view with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match view with None -> () | Some v -> attribBuilder.Add(View._ViewAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncViewCell : (unit -> Xamarin.Forms.ViewCell) = (fun () -> View.CreateViewCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateViewCell () : Xamarin.Forms.ViewCell = 
        upcast (new Xamarin.Forms.ViewCell())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncViewCell = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ViewCell) -> View.UpdateViewCell (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateViewCell (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ViewCell) = 
        // update the inherited Cell element
        let baseElement = (if View.ProtoCell.IsNone then View.ProtoCell <- Some (View.Cell())); View.ProtoCell.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevViewOpt = ValueNone
        let mutable currViewOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ViewAttribKey.KeyValue then 
                currViewOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ViewAttribKey.KeyValue then 
                    prevViewOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevViewOpt, currViewOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.View)
        | _, ValueSome newValue ->
            target.View <- (newValue.Create() :?> Xamarin.Forms.View)
        | ValueSome _, ValueNone ->
            target.View <- null
        | ValueNone, ValueNone -> ()

    /// Describes a ViewCell in the view
    static member inline ViewCell(?view: ViewElement,
                                  ?height: double,
                                  ?isEnabled: bool,
                                  ?classId: string,
                                  ?styleId: string,
                                  ?automationId: string,
                                  ?created: (Xamarin.Forms.ViewCell -> unit),
                                  ?ref: ViewRef<Xamarin.Forms.ViewCell>) = 

        let attribBuilder = View.BuildViewCell(0,
                               ?view=view,
                               ?height=height,
                               ?isEnabled=isEnabled,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ViewCell> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ViewCell>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ViewCell>(View.CreateFuncViewCell, View.UpdateFuncViewCell, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoViewCell : ViewElement option = None with get, set

    /// Builds the attributes for a ListView in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildListView(attribCount: int,
                                       ?items: seq<ViewElement>,
                                       ?footer: System.Object,
                                       ?hasUnevenRows: bool,
                                       ?header: System.Object,
                                       ?headerTemplate: Xamarin.Forms.DataTemplate,
                                       ?isGroupingEnabled: bool,
                                       ?isPullToRefreshEnabled: bool,
                                       ?isRefreshing: bool,
                                       ?refreshCommand: unit -> unit,
                                       ?rowHeight: int,
                                       ?selectedItem: int option,
                                       ?separatorVisibility: Xamarin.Forms.SeparatorVisibility,
                                       ?separatorColor: Xamarin.Forms.Color,
                                       ?itemAppearing: int -> unit,
                                       ?itemDisappearing: int -> unit,
                                       ?itemSelected: int option -> unit,
                                       ?itemTapped: int -> unit,
                                       ?refreshing: unit -> unit,
                                       ?selectionMode: Xamarin.Forms.ListViewSelectionMode,
                                       ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                       ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                       ?margin: obj,
                                       ?gestureRecognizers: ViewElement list,
                                       ?anchorX: double,
                                       ?anchorY: double,
                                       ?backgroundColor: Xamarin.Forms.Color,
                                       ?heightRequest: double,
                                       ?inputTransparent: bool,
                                       ?isEnabled: bool,
                                       ?isVisible: bool,
                                       ?minimumHeightRequest: double,
                                       ?minimumWidthRequest: double,
                                       ?opacity: double,
                                       ?rotation: double,
                                       ?rotationX: double,
                                       ?rotationY: double,
                                       ?scale: double,
                                       ?style: Xamarin.Forms.Style,
                                       ?styleClass: obj,
                                       ?translationX: double,
                                       ?translationY: double,
                                       ?widthRequest: double,
                                       ?resources: (string * obj) list,
                                       ?styles: Xamarin.Forms.Style list,
                                       ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                       ?isTabStop: bool,
                                       ?scaleX: double,
                                       ?scaleY: double,
                                       ?tabIndex: int,
                                       ?classId: string,
                                       ?styleId: string,
                                       ?automationId: string,
                                       ?created: obj -> unit,
                                       ?ref: ViewRef) = 

        let attribCount = match items with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match footer with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasUnevenRows with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match header with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match headerTemplate with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isGroupingEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isPullToRefreshEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isRefreshing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match refreshCommand with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rowHeight with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectedItem with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match separatorVisibility with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match separatorColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match itemAppearing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match itemDisappearing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match itemSelected with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match itemTapped with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match refreshing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectionMode with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match items with None -> () | Some v -> attribBuilder.Add(View._ListViewItemsAttribKey, (v)) 
        match footer with None -> () | Some v -> attribBuilder.Add(View._FooterAttribKey, (v)) 
        match hasUnevenRows with None -> () | Some v -> attribBuilder.Add(View._HasUnevenRowsAttribKey, (v)) 
        match header with None -> () | Some v -> attribBuilder.Add(View._HeaderAttribKey, (v)) 
        match headerTemplate with None -> () | Some v -> attribBuilder.Add(View._HeaderTemplateAttribKey, (v)) 
        match isGroupingEnabled with None -> () | Some v -> attribBuilder.Add(View._IsGroupingEnabledAttribKey, (v)) 
        match isPullToRefreshEnabled with None -> () | Some v -> attribBuilder.Add(View._IsPullToRefreshEnabledAttribKey, (v)) 
        match isRefreshing with None -> () | Some v -> attribBuilder.Add(View._IsRefreshingAttribKey, (v)) 
        match refreshCommand with None -> () | Some v -> attribBuilder.Add(View._RefreshCommandAttribKey, makeCommand(v)) 
        match rowHeight with None -> () | Some v -> attribBuilder.Add(View._RowHeightAttribKey, (v)) 
        match selectedItem with None -> () | Some v -> attribBuilder.Add(View._ListView_SelectedItemAttribKey, (v)) 
        match separatorVisibility with None -> () | Some v -> attribBuilder.Add(View._ListView_SeparatorVisibilityAttribKey, (v)) 
        match separatorColor with None -> () | Some v -> attribBuilder.Add(View._ListView_SeparatorColorAttribKey, (v)) 
        match itemAppearing with None -> () | Some v -> attribBuilder.Add(View._ListView_ItemAppearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v)) 
        match itemDisappearing with None -> () | Some v -> attribBuilder.Add(View._ListView_ItemDisappearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v)) 
        match itemSelected with None -> () | Some v -> attribBuilder.Add(View._ListView_ItemSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(v)) 
        match itemTapped with None -> () | Some v -> attribBuilder.Add(View._ListView_ItemTappedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v)) 
        match refreshing with None -> () | Some v -> attribBuilder.Add(View._ListView_RefreshingAttribKey, (fun f -> System.EventHandler(fun sender args -> f ()))(v)) 
        match selectionMode with None -> () | Some v -> attribBuilder.Add(View._SelectionModeAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncListView : (unit -> Xamarin.Forms.ListView) = (fun () -> View.CreateListView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateListView () : Xamarin.Forms.ListView = 
        upcast (new Fabulous.DynamicViews.CustomListView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncListView = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ListView) -> View.UpdateListView (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateListView (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ListView) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevListViewItemsOpt = ValueNone
        let mutable currListViewItemsOpt = ValueNone
        let mutable prevFooterOpt = ValueNone
        let mutable currFooterOpt = ValueNone
        let mutable prevHasUnevenRowsOpt = ValueNone
        let mutable currHasUnevenRowsOpt = ValueNone
        let mutable prevHeaderOpt = ValueNone
        let mutable currHeaderOpt = ValueNone
        let mutable prevHeaderTemplateOpt = ValueNone
        let mutable currHeaderTemplateOpt = ValueNone
        let mutable prevIsGroupingEnabledOpt = ValueNone
        let mutable currIsGroupingEnabledOpt = ValueNone
        let mutable prevIsPullToRefreshEnabledOpt = ValueNone
        let mutable currIsPullToRefreshEnabledOpt = ValueNone
        let mutable prevIsRefreshingOpt = ValueNone
        let mutable currIsRefreshingOpt = ValueNone
        let mutable prevRefreshCommandOpt = ValueNone
        let mutable currRefreshCommandOpt = ValueNone
        let mutable prevRowHeightOpt = ValueNone
        let mutable currRowHeightOpt = ValueNone
        let mutable prevListView_SelectedItemOpt = ValueNone
        let mutable currListView_SelectedItemOpt = ValueNone
        let mutable prevListView_SeparatorVisibilityOpt = ValueNone
        let mutable currListView_SeparatorVisibilityOpt = ValueNone
        let mutable prevListView_SeparatorColorOpt = ValueNone
        let mutable currListView_SeparatorColorOpt = ValueNone
        let mutable prevListView_ItemAppearingOpt = ValueNone
        let mutable currListView_ItemAppearingOpt = ValueNone
        let mutable prevListView_ItemDisappearingOpt = ValueNone
        let mutable currListView_ItemDisappearingOpt = ValueNone
        let mutable prevListView_ItemSelectedOpt = ValueNone
        let mutable currListView_ItemSelectedOpt = ValueNone
        let mutable prevListView_ItemTappedOpt = ValueNone
        let mutable currListView_ItemTappedOpt = ValueNone
        let mutable prevListView_RefreshingOpt = ValueNone
        let mutable currListView_RefreshingOpt = ValueNone
        let mutable prevSelectionModeOpt = ValueNone
        let mutable currSelectionModeOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ListViewItemsAttribKey.KeyValue then 
                currListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
            if kvp.Key = View._FooterAttribKey.KeyValue then 
                currFooterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = View._HasUnevenRowsAttribKey.KeyValue then 
                currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._HeaderAttribKey.KeyValue then 
                currHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = View._HeaderTemplateAttribKey.KeyValue then 
                currHeaderTemplateOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.DataTemplate)
            if kvp.Key = View._IsGroupingEnabledAttribKey.KeyValue then 
                currIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._IsPullToRefreshEnabledAttribKey.KeyValue then 
                currIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._IsRefreshingAttribKey.KeyValue then 
                currIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._RefreshCommandAttribKey.KeyValue then 
                currRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = View._RowHeightAttribKey.KeyValue then 
                currRowHeightOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._ListView_SelectedItemAttribKey.KeyValue then 
                currListView_SelectedItemOpt <- ValueSome (kvp.Value :?> int option)
            if kvp.Key = View._ListView_SeparatorVisibilityAttribKey.KeyValue then 
                currListView_SeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
            if kvp.Key = View._ListView_SeparatorColorAttribKey.KeyValue then 
                currListView_SeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._ListView_ItemAppearingAttribKey.KeyValue then 
                currListView_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = View._ListView_ItemDisappearingAttribKey.KeyValue then 
                currListView_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = View._ListView_ItemSelectedAttribKey.KeyValue then 
                currListView_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
            if kvp.Key = View._ListView_ItemTappedAttribKey.KeyValue then 
                currListView_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
            if kvp.Key = View._ListView_RefreshingAttribKey.KeyValue then 
                currListView_RefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = View._SelectionModeAttribKey.KeyValue then 
                currSelectionModeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ListViewSelectionMode)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ListViewItemsAttribKey.KeyValue then 
                    prevListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
                if kvp.Key = View._FooterAttribKey.KeyValue then 
                    prevFooterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = View._HasUnevenRowsAttribKey.KeyValue then 
                    prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._HeaderAttribKey.KeyValue then 
                    prevHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = View._HeaderTemplateAttribKey.KeyValue then 
                    prevHeaderTemplateOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.DataTemplate)
                if kvp.Key = View._IsGroupingEnabledAttribKey.KeyValue then 
                    prevIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._IsPullToRefreshEnabledAttribKey.KeyValue then 
                    prevIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._IsRefreshingAttribKey.KeyValue then 
                    prevIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._RefreshCommandAttribKey.KeyValue then 
                    prevRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = View._RowHeightAttribKey.KeyValue then 
                    prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._ListView_SelectedItemAttribKey.KeyValue then 
                    prevListView_SelectedItemOpt <- ValueSome (kvp.Value :?> int option)
                if kvp.Key = View._ListView_SeparatorVisibilityAttribKey.KeyValue then 
                    prevListView_SeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
                if kvp.Key = View._ListView_SeparatorColorAttribKey.KeyValue then 
                    prevListView_SeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._ListView_ItemAppearingAttribKey.KeyValue then 
                    prevListView_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = View._ListView_ItemDisappearingAttribKey.KeyValue then 
                    prevListView_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = View._ListView_ItemSelectedAttribKey.KeyValue then 
                    prevListView_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                if kvp.Key = View._ListView_ItemTappedAttribKey.KeyValue then 
                    prevListView_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
                if kvp.Key = View._ListView_RefreshingAttribKey.KeyValue then 
                    prevListView_RefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = View._SelectionModeAttribKey.KeyValue then 
                    prevSelectionModeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ListViewSelectionMode)
        updateListViewItems prevListViewItemsOpt currListViewItemsOpt target
        match prevFooterOpt, currFooterOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Footer <-  currValue
        | ValueSome _, ValueNone -> target.Footer <- null
        | ValueNone, ValueNone -> ()
        match prevHasUnevenRowsOpt, currHasUnevenRowsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HasUnevenRows <-  currValue
        | ValueSome _, ValueNone -> target.HasUnevenRows <- false
        | ValueNone, ValueNone -> ()
        match prevHeaderOpt, currHeaderOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Header <-  currValue
        | ValueSome _, ValueNone -> target.Header <- null
        | ValueNone, ValueNone -> ()
        match prevHeaderTemplateOpt, currHeaderTemplateOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HeaderTemplate <-  currValue
        | ValueSome _, ValueNone -> target.HeaderTemplate <- null
        | ValueNone, ValueNone -> ()
        match prevIsGroupingEnabledOpt, currIsGroupingEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsGroupingEnabled <-  currValue
        | ValueSome _, ValueNone -> target.IsGroupingEnabled <- false
        | ValueNone, ValueNone -> ()
        match prevIsPullToRefreshEnabledOpt, currIsPullToRefreshEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsPullToRefreshEnabled <-  currValue
        | ValueSome _, ValueNone -> target.IsPullToRefreshEnabled <- false
        | ValueNone, ValueNone -> ()
        match prevIsRefreshingOpt, currIsRefreshingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsRefreshing <-  currValue
        | ValueSome _, ValueNone -> target.IsRefreshing <- false
        | ValueNone, ValueNone -> ()
        match prevRefreshCommandOpt, currRefreshCommandOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RefreshCommand <-  currValue
        | ValueSome _, ValueNone -> target.RefreshCommand <- null
        | ValueNone, ValueNone -> ()
        match prevRowHeightOpt, currRowHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RowHeight <-  currValue
        | ValueSome _, ValueNone -> target.RowHeight <- -1
        | ValueNone, ValueNone -> ()
        match prevListView_SelectedItemOpt, currListView_SelectedItemOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SelectedItem <- (function None -> null | Some i -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListElementData<ViewElement>> in if i >= 0 && i < items.Count then items.[i] else null) currValue
        | ValueSome _, ValueNone -> target.SelectedItem <- null
        | ValueNone, ValueNone -> ()
        match prevListView_SeparatorVisibilityOpt, currListView_SeparatorVisibilityOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SeparatorVisibility <-  currValue
        | ValueSome _, ValueNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
        | ValueNone, ValueNone -> ()
        match prevListView_SeparatorColorOpt, currListView_SeparatorColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SeparatorColor <-  currValue
        | ValueSome _, ValueNone -> target.SeparatorColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevListView_ItemAppearingOpt, currListView_ItemAppearingOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ItemAppearing.RemoveHandler(prevValue); target.ItemAppearing.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ItemAppearing.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ItemAppearing.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevListView_ItemDisappearingOpt, currListView_ItemDisappearingOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ItemDisappearing.RemoveHandler(prevValue); target.ItemDisappearing.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ItemDisappearing.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ItemDisappearing.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevListView_ItemSelectedOpt, currListView_ItemSelectedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ItemSelected.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ItemSelected.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevListView_ItemTappedOpt, currListView_ItemTappedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ItemTapped.RemoveHandler(prevValue); target.ItemTapped.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ItemTapped.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ItemTapped.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevListView_RefreshingOpt, currListView_RefreshingOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Refreshing.RemoveHandler(prevValue); target.Refreshing.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Refreshing.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Refreshing.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevSelectionModeOpt, currSelectionModeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SelectionMode <-  currValue
        | ValueSome _, ValueNone -> target.SelectionMode <- Xamarin.Forms.ListViewSelectionMode.Single
        | ValueNone, ValueNone -> ()

    /// Describes a ListView in the view
    static member inline ListView(?items: seq<ViewElement>,
                                  ?footer: System.Object,
                                  ?hasUnevenRows: bool,
                                  ?header: System.Object,
                                  ?headerTemplate: Xamarin.Forms.DataTemplate,
                                  ?isGroupingEnabled: bool,
                                  ?isPullToRefreshEnabled: bool,
                                  ?isRefreshing: bool,
                                  ?refreshCommand: unit -> unit,
                                  ?rowHeight: int,
                                  ?selectedItem: int option,
                                  ?separatorVisibility: Xamarin.Forms.SeparatorVisibility,
                                  ?separatorColor: Xamarin.Forms.Color,
                                  ?itemAppearing: int -> unit,
                                  ?itemDisappearing: int -> unit,
                                  ?itemSelected: int option -> unit,
                                  ?itemTapped: int -> unit,
                                  ?refreshing: unit -> unit,
                                  ?selectionMode: Xamarin.Forms.ListViewSelectionMode,
                                  ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                  ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                  ?margin: obj,
                                  ?gestureRecognizers: ViewElement list,
                                  ?anchorX: double,
                                  ?anchorY: double,
                                  ?backgroundColor: Xamarin.Forms.Color,
                                  ?heightRequest: double,
                                  ?inputTransparent: bool,
                                  ?isEnabled: bool,
                                  ?isVisible: bool,
                                  ?minimumHeightRequest: double,
                                  ?minimumWidthRequest: double,
                                  ?opacity: double,
                                  ?rotation: double,
                                  ?rotationX: double,
                                  ?rotationY: double,
                                  ?scale: double,
                                  ?style: Xamarin.Forms.Style,
                                  ?styleClass: obj,
                                  ?translationX: double,
                                  ?translationY: double,
                                  ?widthRequest: double,
                                  ?resources: (string * obj) list,
                                  ?styles: Xamarin.Forms.Style list,
                                  ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                  ?isTabStop: bool,
                                  ?scaleX: double,
                                  ?scaleY: double,
                                  ?tabIndex: int,
                                  ?classId: string,
                                  ?styleId: string,
                                  ?automationId: string,
                                  ?created: (Xamarin.Forms.ListView -> unit),
                                  ?ref: ViewRef<Xamarin.Forms.ListView>) = 

        let attribBuilder = View.BuildListView(0,
                               ?items=items,
                               ?footer=footer,
                               ?hasUnevenRows=hasUnevenRows,
                               ?header=header,
                               ?headerTemplate=headerTemplate,
                               ?isGroupingEnabled=isGroupingEnabled,
                               ?isPullToRefreshEnabled=isPullToRefreshEnabled,
                               ?isRefreshing=isRefreshing,
                               ?refreshCommand=refreshCommand,
                               ?rowHeight=rowHeight,
                               ?selectedItem=selectedItem,
                               ?separatorVisibility=separatorVisibility,
                               ?separatorColor=separatorColor,
                               ?itemAppearing=itemAppearing,
                               ?itemDisappearing=itemDisappearing,
                               ?itemSelected=itemSelected,
                               ?itemTapped=itemTapped,
                               ?refreshing=refreshing,
                               ?selectionMode=selectionMode,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ListView> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ListView>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ListView>(View.CreateFuncListView, View.UpdateFuncListView, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoListView : ViewElement option = None with get, set

    /// Builds the attributes for a ListViewGrouped in the view
    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member inline BuildListViewGrouped(attribCount: int,
                                              ?items: (string * ViewElement * ViewElement list) list,
                                              ?showJumpList: bool,
                                              ?footer: System.Object,
                                              ?hasUnevenRows: bool,
                                              ?header: System.Object,
                                              ?isPullToRefreshEnabled: bool,
                                              ?isRefreshing: bool,
                                              ?refreshCommand: unit -> unit,
                                              ?rowHeight: int,
                                              ?selectedItem: (int * int) option,
                                              ?separatorVisibility: Xamarin.Forms.SeparatorVisibility,
                                              ?separatorColor: Xamarin.Forms.Color,
                                              ?itemAppearing: int * int option -> unit,
                                              ?itemDisappearing: int * int option -> unit,
                                              ?itemSelected: (int * int) option -> unit,
                                              ?itemTapped: int * int -> unit,
                                              ?refreshing: unit -> unit,
                                              ?selectionMode: Xamarin.Forms.ListViewSelectionMode,
                                              ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                              ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                              ?margin: obj,
                                              ?gestureRecognizers: ViewElement list,
                                              ?anchorX: double,
                                              ?anchorY: double,
                                              ?backgroundColor: Xamarin.Forms.Color,
                                              ?heightRequest: double,
                                              ?inputTransparent: bool,
                                              ?isEnabled: bool,
                                              ?isVisible: bool,
                                              ?minimumHeightRequest: double,
                                              ?minimumWidthRequest: double,
                                              ?opacity: double,
                                              ?rotation: double,
                                              ?rotationX: double,
                                              ?rotationY: double,
                                              ?scale: double,
                                              ?style: Xamarin.Forms.Style,
                                              ?styleClass: obj,
                                              ?translationX: double,
                                              ?translationY: double,
                                              ?widthRequest: double,
                                              ?resources: (string * obj) list,
                                              ?styles: Xamarin.Forms.Style list,
                                              ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                              ?isTabStop: bool,
                                              ?scaleX: double,
                                              ?scaleY: double,
                                              ?tabIndex: int,
                                              ?classId: string,
                                              ?styleId: string,
                                              ?automationId: string,
                                              ?created: obj -> unit,
                                              ?ref: ViewRef) = 

        let attribCount = match items with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match showJumpList with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match footer with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasUnevenRows with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match header with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isPullToRefreshEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isRefreshing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match refreshCommand with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rowHeight with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectedItem with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match separatorVisibility with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match separatorColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match itemAppearing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match itemDisappearing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match itemSelected with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match itemTapped with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match refreshing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectionMode with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = View.BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?styleClass=styleClass, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?isTabStop=isTabStop, ?scaleX=scaleX, ?scaleY=scaleY, ?tabIndex=tabIndex, ?classId=classId, ?styleId=styleId, ?automationId=automationId, ?created=created, ?ref=ref)
        match items with None -> () | Some v -> attribBuilder.Add(View._ListViewGrouped_ItemsSourceAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun (g, e, l) -> (g, e, Array.ofList l)))(v)) 
        match showJumpList with None -> () | Some v -> attribBuilder.Add(View._ListViewGrouped_ShowJumpListAttribKey, (v)) 
        match footer with None -> () | Some v -> attribBuilder.Add(View._FooterAttribKey, (v)) 
        match hasUnevenRows with None -> () | Some v -> attribBuilder.Add(View._HasUnevenRowsAttribKey, (v)) 
        match header with None -> () | Some v -> attribBuilder.Add(View._HeaderAttribKey, (v)) 
        match isPullToRefreshEnabled with None -> () | Some v -> attribBuilder.Add(View._IsPullToRefreshEnabledAttribKey, (v)) 
        match isRefreshing with None -> () | Some v -> attribBuilder.Add(View._IsRefreshingAttribKey, (v)) 
        match refreshCommand with None -> () | Some v -> attribBuilder.Add(View._RefreshCommandAttribKey, makeCommand(v)) 
        match rowHeight with None -> () | Some v -> attribBuilder.Add(View._RowHeightAttribKey, (v)) 
        match selectedItem with None -> () | Some v -> attribBuilder.Add(View._ListViewGrouped_SelectedItemAttribKey, (v)) 
        match separatorVisibility with None -> () | Some v -> attribBuilder.Add(View._SeparatorVisibilityAttribKey, (v)) 
        match separatorColor with None -> () | Some v -> attribBuilder.Add(View._SeparatorColorAttribKey, (v)) 
        match itemAppearing with None -> () | Some v -> attribBuilder.Add(View._ListViewGrouped_ItemAppearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItemOrGroupItem sender args.Item).Value))(v)) 
        match itemDisappearing with None -> () | Some v -> attribBuilder.Add(View._ListViewGrouped_ItemDisappearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItemOrGroupItem sender args.Item).Value))(v)) 
        match itemSelected with None -> () | Some v -> attribBuilder.Add(View._ListViewGrouped_ItemSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(v)) 
        match itemTapped with None -> () | Some v -> attribBuilder.Add(View._ListViewGrouped_ItemTappedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v)) 
        match refreshing with None -> () | Some v -> attribBuilder.Add(View._RefreshingAttribKey, (fun f -> System.EventHandler(fun sender args -> f ()))(v)) 
        match selectionMode with None -> () | Some v -> attribBuilder.Add(View._SelectionModeAttribKey, (v)) 
        attribBuilder

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val CreateFuncListViewGrouped : (unit -> Xamarin.Forms.ListView) = (fun () -> View.CreateListViewGrouped())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member CreateListViewGrouped () : Xamarin.Forms.ListView = 
        upcast (new Fabulous.DynamicViews.CustomGroupListView())

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val UpdateFuncListViewGrouped = (fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ListView) -> View.UpdateListViewGrouped (prevOpt, curr, target)) 

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member UpdateListViewGrouped (prevOpt: ViewElement voption, curr: ViewElement, target: Xamarin.Forms.ListView) = 
        // update the inherited View element
        let baseElement = (if View.ProtoView.IsNone then View.ProtoView <- Some (View.View())); View.ProtoView.Value
        baseElement.UpdateInherited (prevOpt, curr, target)
        let mutable prevListViewGrouped_ItemsSourceOpt = ValueNone
        let mutable currListViewGrouped_ItemsSourceOpt = ValueNone
        let mutable prevListViewGrouped_ShowJumpListOpt = ValueNone
        let mutable currListViewGrouped_ShowJumpListOpt = ValueNone
        let mutable prevFooterOpt = ValueNone
        let mutable currFooterOpt = ValueNone
        let mutable prevHasUnevenRowsOpt = ValueNone
        let mutable currHasUnevenRowsOpt = ValueNone
        let mutable prevHeaderOpt = ValueNone
        let mutable currHeaderOpt = ValueNone
        let mutable prevIsPullToRefreshEnabledOpt = ValueNone
        let mutable currIsPullToRefreshEnabledOpt = ValueNone
        let mutable prevIsRefreshingOpt = ValueNone
        let mutable currIsRefreshingOpt = ValueNone
        let mutable prevRefreshCommandOpt = ValueNone
        let mutable currRefreshCommandOpt = ValueNone
        let mutable prevRowHeightOpt = ValueNone
        let mutable currRowHeightOpt = ValueNone
        let mutable prevListViewGrouped_SelectedItemOpt = ValueNone
        let mutable currListViewGrouped_SelectedItemOpt = ValueNone
        let mutable prevSeparatorVisibilityOpt = ValueNone
        let mutable currSeparatorVisibilityOpt = ValueNone
        let mutable prevSeparatorColorOpt = ValueNone
        let mutable currSeparatorColorOpt = ValueNone
        let mutable prevListViewGrouped_ItemAppearingOpt = ValueNone
        let mutable currListViewGrouped_ItemAppearingOpt = ValueNone
        let mutable prevListViewGrouped_ItemDisappearingOpt = ValueNone
        let mutable currListViewGrouped_ItemDisappearingOpt = ValueNone
        let mutable prevListViewGrouped_ItemSelectedOpt = ValueNone
        let mutable currListViewGrouped_ItemSelectedOpt = ValueNone
        let mutable prevListViewGrouped_ItemTappedOpt = ValueNone
        let mutable currListViewGrouped_ItemTappedOpt = ValueNone
        let mutable prevRefreshingOpt = ValueNone
        let mutable currRefreshingOpt = ValueNone
        let mutable prevSelectionModeOpt = ValueNone
        let mutable currSelectionModeOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = View._ListViewGrouped_ItemsSourceAttribKey.KeyValue then 
                currListViewGrouped_ItemsSourceOpt <- ValueSome (kvp.Value :?> (string * ViewElement * ViewElement[])[])
            if kvp.Key = View._ListViewGrouped_ShowJumpListAttribKey.KeyValue then 
                currListViewGrouped_ShowJumpListOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._FooterAttribKey.KeyValue then 
                currFooterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = View._HasUnevenRowsAttribKey.KeyValue then 
                currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._HeaderAttribKey.KeyValue then 
                currHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = View._IsPullToRefreshEnabledAttribKey.KeyValue then 
                currIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._IsRefreshingAttribKey.KeyValue then 
                currIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = View._RefreshCommandAttribKey.KeyValue then 
                currRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = View._RowHeightAttribKey.KeyValue then 
                currRowHeightOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = View._ListViewGrouped_SelectedItemAttribKey.KeyValue then 
                currListViewGrouped_SelectedItemOpt <- ValueSome (kvp.Value :?> (int * int) option)
            if kvp.Key = View._SeparatorVisibilityAttribKey.KeyValue then 
                currSeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
            if kvp.Key = View._SeparatorColorAttribKey.KeyValue then 
                currSeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = View._ListViewGrouped_ItemAppearingAttribKey.KeyValue then 
                currListViewGrouped_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = View._ListViewGrouped_ItemDisappearingAttribKey.KeyValue then 
                currListViewGrouped_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = View._ListViewGrouped_ItemSelectedAttribKey.KeyValue then 
                currListViewGrouped_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
            if kvp.Key = View._ListViewGrouped_ItemTappedAttribKey.KeyValue then 
                currListViewGrouped_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
            if kvp.Key = View._RefreshingAttribKey.KeyValue then 
                currRefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = View._SelectionModeAttribKey.KeyValue then 
                currSelectionModeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ListViewSelectionMode)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = View._ListViewGrouped_ItemsSourceAttribKey.KeyValue then 
                    prevListViewGrouped_ItemsSourceOpt <- ValueSome (kvp.Value :?> (string * ViewElement * ViewElement[])[])
                if kvp.Key = View._ListViewGrouped_ShowJumpListAttribKey.KeyValue then 
                    prevListViewGrouped_ShowJumpListOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._FooterAttribKey.KeyValue then 
                    prevFooterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = View._HasUnevenRowsAttribKey.KeyValue then 
                    prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._HeaderAttribKey.KeyValue then 
                    prevHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = View._IsPullToRefreshEnabledAttribKey.KeyValue then 
                    prevIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._IsRefreshingAttribKey.KeyValue then 
                    prevIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = View._RefreshCommandAttribKey.KeyValue then 
                    prevRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = View._RowHeightAttribKey.KeyValue then 
                    prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = View._ListViewGrouped_SelectedItemAttribKey.KeyValue then 
                    prevListViewGrouped_SelectedItemOpt <- ValueSome (kvp.Value :?> (int * int) option)
                if kvp.Key = View._SeparatorVisibilityAttribKey.KeyValue then 
                    prevSeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
                if kvp.Key = View._SeparatorColorAttribKey.KeyValue then 
                    prevSeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = View._ListViewGrouped_ItemAppearingAttribKey.KeyValue then 
                    prevListViewGrouped_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = View._ListViewGrouped_ItemDisappearingAttribKey.KeyValue then 
                    prevListViewGrouped_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = View._ListViewGrouped_ItemSelectedAttribKey.KeyValue then 
                    prevListViewGrouped_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                if kvp.Key = View._ListViewGrouped_ItemTappedAttribKey.KeyValue then 
                    prevListViewGrouped_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
                if kvp.Key = View._RefreshingAttribKey.KeyValue then 
                    prevRefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = View._SelectionModeAttribKey.KeyValue then 
                    prevSelectionModeOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ListViewSelectionMode)
        updateListViewGroupedItems prevListViewGrouped_ItemsSourceOpt currListViewGrouped_ItemsSourceOpt target
        updateListViewGroupedShowJumpList prevListViewGrouped_ShowJumpListOpt currListViewGrouped_ShowJumpListOpt target
        match prevFooterOpt, currFooterOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Footer <-  currValue
        | ValueSome _, ValueNone -> target.Footer <- null
        | ValueNone, ValueNone -> ()
        match prevHasUnevenRowsOpt, currHasUnevenRowsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HasUnevenRows <-  currValue
        | ValueSome _, ValueNone -> target.HasUnevenRows <- false
        | ValueNone, ValueNone -> ()
        match prevHeaderOpt, currHeaderOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Header <-  currValue
        | ValueSome _, ValueNone -> target.Header <- null
        | ValueNone, ValueNone -> ()
        match prevIsPullToRefreshEnabledOpt, currIsPullToRefreshEnabledOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsPullToRefreshEnabled <-  currValue
        | ValueSome _, ValueNone -> target.IsPullToRefreshEnabled <- false
        | ValueNone, ValueNone -> ()
        match prevIsRefreshingOpt, currIsRefreshingOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.IsRefreshing <-  currValue
        | ValueSome _, ValueNone -> target.IsRefreshing <- false
        | ValueNone, ValueNone -> ()
        match prevRefreshCommandOpt, currRefreshCommandOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RefreshCommand <-  currValue
        | ValueSome _, ValueNone -> target.RefreshCommand <- null
        | ValueNone, ValueNone -> ()
        match prevRowHeightOpt, currRowHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.RowHeight <-  currValue
        | ValueSome _, ValueNone -> target.RowHeight <- -1
        | ValueNone, ValueNone -> ()
        match prevListViewGrouped_SelectedItemOpt, currListViewGrouped_SelectedItemOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SelectedItem <- (function None -> null | Some (i,j) -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListGroupData<ViewElement>> in (if i >= 0 && i < items.Count then (let items2 = items.[i] in if j >= 0 && j < items2.Count then items2.[j] else null) else null)) currValue
        | ValueSome _, ValueNone -> target.SelectedItem <- null
        | ValueNone, ValueNone -> ()
        match prevSeparatorVisibilityOpt, currSeparatorVisibilityOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SeparatorVisibility <-  currValue
        | ValueSome _, ValueNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
        | ValueNone, ValueNone -> ()
        match prevSeparatorColorOpt, currSeparatorColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SeparatorColor <-  currValue
        | ValueSome _, ValueNone -> target.SeparatorColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()
        match prevListViewGrouped_ItemAppearingOpt, currListViewGrouped_ItemAppearingOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ItemAppearing.RemoveHandler(prevValue); target.ItemAppearing.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ItemAppearing.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ItemAppearing.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevListViewGrouped_ItemDisappearingOpt, currListViewGrouped_ItemDisappearingOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ItemDisappearing.RemoveHandler(prevValue); target.ItemDisappearing.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ItemDisappearing.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ItemDisappearing.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevListViewGrouped_ItemSelectedOpt, currListViewGrouped_ItemSelectedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ItemSelected.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ItemSelected.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevListViewGrouped_ItemTappedOpt, currListViewGrouped_ItemTappedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.ItemTapped.RemoveHandler(prevValue); target.ItemTapped.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.ItemTapped.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.ItemTapped.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevRefreshingOpt, currRefreshingOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.Refreshing.RemoveHandler(prevValue); target.Refreshing.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.Refreshing.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.Refreshing.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()
        match prevSelectionModeOpt, currSelectionModeOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SelectionMode <-  currValue
        | ValueSome _, ValueNone -> target.SelectionMode <- Xamarin.Forms.ListViewSelectionMode.Single
        | ValueNone, ValueNone -> ()

    /// Describes a ListViewGrouped in the view
    static member inline ListViewGrouped(?items: (string * ViewElement * ViewElement list) list,
                                         ?showJumpList: bool,
                                         ?footer: System.Object,
                                         ?hasUnevenRows: bool,
                                         ?header: System.Object,
                                         ?isPullToRefreshEnabled: bool,
                                         ?isRefreshing: bool,
                                         ?refreshCommand: unit -> unit,
                                         ?rowHeight: int,
                                         ?selectedItem: (int * int) option,
                                         ?separatorVisibility: Xamarin.Forms.SeparatorVisibility,
                                         ?separatorColor: Xamarin.Forms.Color,
                                         ?itemAppearing: int * int option -> unit,
                                         ?itemDisappearing: int * int option -> unit,
                                         ?itemSelected: (int * int) option -> unit,
                                         ?itemTapped: int * int -> unit,
                                         ?refreshing: unit -> unit,
                                         ?selectionMode: Xamarin.Forms.ListViewSelectionMode,
                                         ?horizontalOptions: Xamarin.Forms.LayoutOptions,
                                         ?verticalOptions: Xamarin.Forms.LayoutOptions,
                                         ?margin: obj,
                                         ?gestureRecognizers: ViewElement list,
                                         ?anchorX: double,
                                         ?anchorY: double,
                                         ?backgroundColor: Xamarin.Forms.Color,
                                         ?heightRequest: double,
                                         ?inputTransparent: bool,
                                         ?isEnabled: bool,
                                         ?isVisible: bool,
                                         ?minimumHeightRequest: double,
                                         ?minimumWidthRequest: double,
                                         ?opacity: double,
                                         ?rotation: double,
                                         ?rotationX: double,
                                         ?rotationY: double,
                                         ?scale: double,
                                         ?style: Xamarin.Forms.Style,
                                         ?styleClass: obj,
                                         ?translationX: double,
                                         ?translationY: double,
                                         ?widthRequest: double,
                                         ?resources: (string * obj) list,
                                         ?styles: Xamarin.Forms.Style list,
                                         ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list,
                                         ?isTabStop: bool,
                                         ?scaleX: double,
                                         ?scaleY: double,
                                         ?tabIndex: int,
                                         ?classId: string,
                                         ?styleId: string,
                                         ?automationId: string,
                                         ?created: (Xamarin.Forms.ListView -> unit),
                                         ?ref: ViewRef<Xamarin.Forms.ListView>) = 

        let attribBuilder = View.BuildListViewGrouped(0,
                               ?items=items,
                               ?showJumpList=showJumpList,
                               ?footer=footer,
                               ?hasUnevenRows=hasUnevenRows,
                               ?header=header,
                               ?isPullToRefreshEnabled=isPullToRefreshEnabled,
                               ?isRefreshing=isRefreshing,
                               ?refreshCommand=refreshCommand,
                               ?rowHeight=rowHeight,
                               ?selectedItem=selectedItem,
                               ?separatorVisibility=separatorVisibility,
                               ?separatorColor=separatorColor,
                               ?itemAppearing=itemAppearing,
                               ?itemDisappearing=itemDisappearing,
                               ?itemSelected=itemSelected,
                               ?itemTapped=itemTapped,
                               ?refreshing=refreshing,
                               ?selectionMode=selectionMode,
                               ?horizontalOptions=horizontalOptions,
                               ?verticalOptions=verticalOptions,
                               ?margin=margin,
                               ?gestureRecognizers=gestureRecognizers,
                               ?anchorX=anchorX,
                               ?anchorY=anchorY,
                               ?backgroundColor=backgroundColor,
                               ?heightRequest=heightRequest,
                               ?inputTransparent=inputTransparent,
                               ?isEnabled=isEnabled,
                               ?isVisible=isVisible,
                               ?minimumHeightRequest=minimumHeightRequest,
                               ?minimumWidthRequest=minimumWidthRequest,
                               ?opacity=opacity,
                               ?rotation=rotation,
                               ?rotationX=rotationX,
                               ?rotationY=rotationY,
                               ?scale=scale,
                               ?style=style,
                               ?styleClass=styleClass,
                               ?translationX=translationX,
                               ?translationY=translationY,
                               ?widthRequest=widthRequest,
                               ?resources=resources,
                               ?styles=styles,
                               ?styleSheets=styleSheets,
                               ?isTabStop=isTabStop,
                               ?scaleX=scaleX,
                               ?scaleY=scaleY,
                               ?tabIndex=tabIndex,
                               ?classId=classId,
                               ?styleId=styleId,
                               ?automationId=automationId,
                               ?created=(match created with None -> None | Some createdFunc -> Some (fun (target: obj) ->  createdFunc (unbox<Xamarin.Forms.ListView> target))),
                               ?ref=(match ref with None -> None | Some (ref: ViewRef<Xamarin.Forms.ListView>) -> Some ref.Unbox))

        ViewElement.Create<Xamarin.Forms.ListView>(View.CreateFuncListViewGrouped, View.UpdateFuncListViewGrouped, attribBuilder)

    [<System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)>]
    static member val ProtoListViewGrouped : ViewElement option = None with get, set

[<AutoOpen>]
module ViewElementExtensions = 

    type ViewElement with

        /// Adjusts the ClassId property in the visual element
        member x.ClassId(value: string) = x.WithAttribute(View._ClassIdAttribKey, (value))

        /// Adjusts the StyleId property in the visual element
        member x.StyleId(value: string) = x.WithAttribute(View._StyleIdAttribKey, (value))

        /// Adjusts the AutomationId property in the visual element
        member x.AutomationId(value: string) = x.WithAttribute(View._AutomationIdAttribKey, (value))

        /// Adjusts the AnchorX property in the visual element
        member x.AnchorX(value: double) = x.WithAttribute(View._AnchorXAttribKey, (value))

        /// Adjusts the AnchorY property in the visual element
        member x.AnchorY(value: double) = x.WithAttribute(View._AnchorYAttribKey, (value))

        /// Adjusts the BackgroundColor property in the visual element
        member x.BackgroundColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._BackgroundColorAttribKey, (value))

        /// Adjusts the HeightRequest property in the visual element
        member x.HeightRequest(value: double) = x.WithAttribute(View._HeightRequestAttribKey, (value))

        /// Adjusts the InputTransparent property in the visual element
        member x.InputTransparent(value: bool) = x.WithAttribute(View._InputTransparentAttribKey, (value))

        /// Adjusts the IsEnabled property in the visual element
        member x.IsEnabled(value: bool) = x.WithAttribute(View._IsEnabledAttribKey, (value))

        /// Adjusts the IsVisible property in the visual element
        member x.IsVisible(value: bool) = x.WithAttribute(View._IsVisibleAttribKey, (value))

        /// Adjusts the MinimumHeightRequest property in the visual element
        member x.MinimumHeightRequest(value: double) = x.WithAttribute(View._MinimumHeightRequestAttribKey, (value))

        /// Adjusts the MinimumWidthRequest property in the visual element
        member x.MinimumWidthRequest(value: double) = x.WithAttribute(View._MinimumWidthRequestAttribKey, (value))

        /// Adjusts the Opacity property in the visual element
        member x.Opacity(value: double) = x.WithAttribute(View._OpacityAttribKey, (value))

        /// Adjusts the Rotation property in the visual element
        member x.Rotation(value: double) = x.WithAttribute(View._RotationAttribKey, (value))

        /// Adjusts the RotationX property in the visual element
        member x.RotationX(value: double) = x.WithAttribute(View._RotationXAttribKey, (value))

        /// Adjusts the RotationY property in the visual element
        member x.RotationY(value: double) = x.WithAttribute(View._RotationYAttribKey, (value))

        /// Adjusts the Scale property in the visual element
        member x.Scale(value: double) = x.WithAttribute(View._ScaleAttribKey, (value))

        /// Adjusts the Style property in the visual element
        member x.Style(value: Xamarin.Forms.Style) = x.WithAttribute(View._StyleAttribKey, (value))

        /// Adjusts the StyleClass property in the visual element
        member x.StyleClass(value: obj) = x.WithAttribute(View._StyleClassAttribKey, makeStyleClass(value))

        /// Adjusts the TranslationX property in the visual element
        member x.TranslationX(value: double) = x.WithAttribute(View._TranslationXAttribKey, (value))

        /// Adjusts the TranslationY property in the visual element
        member x.TranslationY(value: double) = x.WithAttribute(View._TranslationYAttribKey, (value))

        /// Adjusts the WidthRequest property in the visual element
        member x.WidthRequest(value: double) = x.WithAttribute(View._WidthRequestAttribKey, (value))

        /// Adjusts the Resources property in the visual element
        member x.Resources(value: (string * obj) list) = x.WithAttribute(View._ResourcesAttribKey, (value))

        /// Adjusts the Styles property in the visual element
        member x.Styles(value: Xamarin.Forms.Style list) = x.WithAttribute(View._StylesAttribKey, (value))

        /// Adjusts the StyleSheets property in the visual element
        member x.StyleSheets(value: Xamarin.Forms.StyleSheets.StyleSheet list) = x.WithAttribute(View._StyleSheetsAttribKey, (value))

        /// Adjusts the IsTabStop property in the visual element
        member x.IsTabStop(value: bool) = x.WithAttribute(View._IsTabStopAttribKey, (value))

        /// Adjusts the ScaleX property in the visual element
        member x.ScaleX(value: double) = x.WithAttribute(View._ScaleXAttribKey, (value))

        /// Adjusts the ScaleY property in the visual element
        member x.ScaleY(value: double) = x.WithAttribute(View._ScaleYAttribKey, (value))

        /// Adjusts the TabIndex property in the visual element
        member x.TabIndex(value: int) = x.WithAttribute(View._TabIndexAttribKey, (value))

        /// Adjusts the HorizontalOptions property in the visual element
        member x.HorizontalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttribute(View._HorizontalOptionsAttribKey, (value))

        /// Adjusts the VerticalOptions property in the visual element
        member x.VerticalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttribute(View._VerticalOptionsAttribKey, (value))

        /// Adjusts the Margin property in the visual element
        member x.Margin(value: obj) = x.WithAttribute(View._MarginAttribKey, makeThickness(value))

        /// Adjusts the GestureRecognizers property in the visual element
        member x.GestureRecognizers(value: ViewElement list) = x.WithAttribute(View._GestureRecognizersAttribKey, Array.ofList(value))

        /// Adjusts the TouchPoints property in the visual element
        member x.TouchPoints(value: int) = x.WithAttribute(View._TouchPointsAttribKey, (value))

        /// Adjusts the PanUpdated property in the visual element
        member x.PanUpdated(value: Xamarin.Forms.PanUpdatedEventArgs -> unit) = x.WithAttribute(View._PanUpdatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Command property in the visual element
        member x.Command(value: unit -> unit) = x.WithAttribute(View._CommandAttribKey, makeCommand(value))

        /// Adjusts the NumberOfTapsRequired property in the visual element
        member x.NumberOfTapsRequired(value: int) = x.WithAttribute(View._NumberOfTapsRequiredAttribKey, (value))

        /// Adjusts the NumberOfClicksRequired property in the visual element
        member x.NumberOfClicksRequired(value: int) = x.WithAttribute(View._NumberOfClicksRequiredAttribKey, (value))

        /// Adjusts the Buttons property in the visual element
        member x.Buttons(value: Xamarin.Forms.ButtonsMask) = x.WithAttribute(View._ButtonsAttribKey, (value))

        /// Adjusts the IsPinching property in the visual element
        member x.IsPinching(value: bool) = x.WithAttribute(View._IsPinchingAttribKey, (value))

        /// Adjusts the PinchUpdated property in the visual element
        member x.PinchUpdated(value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) = x.WithAttribute(View._PinchUpdatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the SwipeGestureRecognizerDirection property in the visual element
        member x.SwipeGestureRecognizerDirection(value: Xamarin.Forms.SwipeDirection) = x.WithAttribute(View._SwipeGestureRecognizerDirectionAttribKey, (value))

        /// Adjusts the Threshold property in the visual element
        member x.Threshold(value: System.UInt32) = x.WithAttribute(View._ThresholdAttribKey, (value))

        /// Adjusts the Swiped property in the visual element
        member x.Swiped(value: Xamarin.Forms.SwipedEventArgs -> unit) = x.WithAttribute(View._SwipedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SwipedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Color property in the visual element
        member x.Color(value: Xamarin.Forms.Color) = x.WithAttribute(View._ColorAttribKey, (value))

        /// Adjusts the IsRunning property in the visual element
        member x.IsRunning(value: bool) = x.WithAttribute(View._IsRunningAttribKey, (value))

        /// Adjusts the BoxViewCornerRadius property in the visual element
        member x.BoxViewCornerRadius(value: Xamarin.Forms.CornerRadius) = x.WithAttribute(View._BoxViewCornerRadiusAttribKey, (value))

        /// Adjusts the Progress property in the visual element
        member x.Progress(value: double) = x.WithAttribute(View._ProgressAttribKey, (value))

        /// Adjusts the IsClippedToBounds property in the visual element
        member x.IsClippedToBounds(value: bool) = x.WithAttribute(View._IsClippedToBoundsAttribKey, (value))

        /// Adjusts the Padding property in the visual element
        member x.Padding(value: obj) = x.WithAttribute(View._PaddingAttribKey, makeThickness(value))

        /// Adjusts the Content property in the visual element
        member x.Content(value: ViewElement) = x.WithAttribute(View._ContentAttribKey, (value))

        /// Adjusts the ScrollOrientation property in the visual element
        member x.ScrollOrientation(value: Xamarin.Forms.ScrollOrientation) = x.WithAttribute(View._ScrollOrientationAttribKey, (value))

        /// Adjusts the HorizontalScrollBarVisibility property in the visual element
        member x.HorizontalScrollBarVisibility(value: Xamarin.Forms.ScrollBarVisibility) = x.WithAttribute(View._HorizontalScrollBarVisibilityAttribKey, (value))

        /// Adjusts the VerticalScrollBarVisibility property in the visual element
        member x.VerticalScrollBarVisibility(value: Xamarin.Forms.ScrollBarVisibility) = x.WithAttribute(View._VerticalScrollBarVisibilityAttribKey, (value))

        /// Adjusts the CancelButtonColor property in the visual element
        member x.CancelButtonColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._CancelButtonColorAttribKey, (value))

        /// Adjusts the FontFamily property in the visual element
        member x.FontFamily(value: string) = x.WithAttribute(View._FontFamilyAttribKey, (value))

        /// Adjusts the FontAttributes property in the visual element
        member x.FontAttributes(value: Xamarin.Forms.FontAttributes) = x.WithAttribute(View._FontAttributesAttribKey, (value))

        /// Adjusts the FontSize property in the visual element
        member x.FontSize(value: obj) = x.WithAttribute(View._FontSizeAttribKey, makeFontSize(value))

        /// Adjusts the HorizontalTextAlignment property in the visual element
        member x.HorizontalTextAlignment(value: Xamarin.Forms.TextAlignment) = x.WithAttribute(View._HorizontalTextAlignmentAttribKey, (value))

        /// Adjusts the Placeholder property in the visual element
        member x.Placeholder(value: string) = x.WithAttribute(View._PlaceholderAttribKey, (value))

        /// Adjusts the PlaceholderColor property in the visual element
        member x.PlaceholderColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._PlaceholderColorAttribKey, (value))

        /// Adjusts the SearchBarCommand property in the visual element
        member x.SearchBarCommand(value: string -> unit) = x.WithAttribute(View._SearchBarCommandAttribKey, (value))

        /// Adjusts the SearchBarCanExecute property in the visual element
        member x.SearchBarCanExecute(value: bool) = x.WithAttribute(View._SearchBarCanExecuteAttribKey, (value))

        /// Adjusts the Text property in the visual element
        member x.Text(value: string) = x.WithAttribute(View._TextAttribKey, (value))

        /// Adjusts the TextColor property in the visual element
        member x.TextColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._TextColorAttribKey, (value))

        /// Adjusts the SearchBarTextChanged property in the visual element
        member x.SearchBarTextChanged(value: Xamarin.Forms.TextChangedEventArgs -> unit) = x.WithAttribute(View._SearchBarTextChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the ButtonCommand property in the visual element
        member x.ButtonCommand(value: unit -> unit) = x.WithAttribute(View._ButtonCommandAttribKey, (value))

        /// Adjusts the ButtonCanExecute property in the visual element
        member x.ButtonCanExecute(value: bool) = x.WithAttribute(View._ButtonCanExecuteAttribKey, (value))

        /// Adjusts the BorderColor property in the visual element
        member x.BorderColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._BorderColorAttribKey, (value))

        /// Adjusts the BorderWidth property in the visual element
        member x.BorderWidth(value: double) = x.WithAttribute(View._BorderWidthAttribKey, (value))

        /// Adjusts the CommandParameter property in the visual element
        member x.CommandParameter(value: System.Object) = x.WithAttribute(View._CommandParameterAttribKey, (value))

        /// Adjusts the ContentLayout property in the visual element
        member x.ContentLayout(value: Xamarin.Forms.Button.ButtonContentLayout) = x.WithAttribute(View._ContentLayoutAttribKey, (value))

        /// Adjusts the ButtonCornerRadius property in the visual element
        member x.ButtonCornerRadius(value: int) = x.WithAttribute(View._ButtonCornerRadiusAttribKey, (value))

        /// Adjusts the ButtonImageSource property in the visual element
        member x.ButtonImageSource(value: string) = x.WithAttribute(View._ButtonImageSourceAttribKey, (value))

        /// Adjusts the MinimumMaximum property in the visual element
        member x.MinimumMaximum(value: float * float) = x.WithAttribute(View._MinimumMaximumAttribKey, (value))

        /// Adjusts the Value property in the visual element
        member x.Value(value: double) = x.WithAttribute(View._ValueAttribKey, (value))

        /// Adjusts the ValueChanged property in the visual element
        member x.ValueChanged(value: Xamarin.Forms.ValueChangedEventArgs -> unit) = x.WithAttribute(View._ValueChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Increment property in the visual element
        member x.Increment(value: double) = x.WithAttribute(View._IncrementAttribKey, (value))

        /// Adjusts the IsToggled property in the visual element
        member x.IsToggled(value: bool) = x.WithAttribute(View._IsToggledAttribKey, (value))

        /// Adjusts the Toggled property in the visual element
        member x.Toggled(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttribute(View._ToggledAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the OnColor property in the visual element
        member x.OnColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._OnColorAttribKey, (value))

        /// Adjusts the Height property in the visual element
        member x.Height(value: double) = x.WithAttribute(View._HeightAttribKey, (value))

        /// Adjusts the On property in the visual element
        member x.On(value: bool) = x.WithAttribute(View._OnAttribKey, (value))

        /// Adjusts the OnChanged property in the visual element
        member x.OnChanged(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttribute(View._OnChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Intent property in the visual element
        member x.Intent(value: Xamarin.Forms.TableIntent) = x.WithAttribute(View._IntentAttribKey, (value))

        /// Adjusts the HasUnevenRows property in the visual element
        member x.HasUnevenRows(value: bool) = x.WithAttribute(View._HasUnevenRowsAttribKey, (value))

        /// Adjusts the RowHeight property in the visual element
        member x.RowHeight(value: int) = x.WithAttribute(View._RowHeightAttribKey, (value))

        /// Adjusts the TableRoot property in the visual element
        member x.TableRoot(value: (string * ViewElement list) list) = x.WithAttribute(View._TableRootAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(value))

        /// Adjusts the RowDefinitionHeight property in the visual element
        member x.RowDefinitionHeight(value: obj) = x.WithAttribute(View._RowDefinitionHeightAttribKey, makeGridLength(value))

        /// Adjusts the ColumnDefinitionWidth property in the visual element
        member x.ColumnDefinitionWidth(value: obj) = x.WithAttribute(View._ColumnDefinitionWidthAttribKey, makeGridLength(value))

        /// Adjusts the GridRowDefinitions property in the visual element
        member x.GridRowDefinitions(value: obj list) = x.WithAttribute(View._GridRowDefinitionsAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun h -> View.RowDefinition(height=h)))(value))

        /// Adjusts the GridColumnDefinitions property in the visual element
        member x.GridColumnDefinitions(value: obj list) = x.WithAttribute(View._GridColumnDefinitionsAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun h -> View.ColumnDefinition(width=h)))(value))

        /// Adjusts the RowSpacing property in the visual element
        member x.RowSpacing(value: double) = x.WithAttribute(View._RowSpacingAttribKey, (value))

        /// Adjusts the ColumnSpacing property in the visual element
        member x.ColumnSpacing(value: double) = x.WithAttribute(View._ColumnSpacingAttribKey, (value))

        /// Adjusts the Children property in the visual element
        member x.Children(value: ViewElement list) = x.WithAttribute(View._ChildrenAttribKey, Array.ofList(value))

        /// Adjusts the GridRow property in the visual element
        member x.GridRow(value: int) = x.WithAttribute(View._GridRowAttribKey, (value))

        /// Adjusts the GridRowSpan property in the visual element
        member x.GridRowSpan(value: int) = x.WithAttribute(View._GridRowSpanAttribKey, (value))

        /// Adjusts the GridColumn property in the visual element
        member x.GridColumn(value: int) = x.WithAttribute(View._GridColumnAttribKey, (value))

        /// Adjusts the GridColumnSpan property in the visual element
        member x.GridColumnSpan(value: int) = x.WithAttribute(View._GridColumnSpanAttribKey, (value))

        /// Adjusts the LayoutBounds property in the visual element
        member x.LayoutBounds(value: Xamarin.Forms.Rectangle) = x.WithAttribute(View._LayoutBoundsAttribKey, (value))

        /// Adjusts the LayoutFlags property in the visual element
        member x.LayoutFlags(value: Xamarin.Forms.AbsoluteLayoutFlags) = x.WithAttribute(View._LayoutFlagsAttribKey, (value))

        /// Adjusts the BoundsConstraint property in the visual element
        member x.BoundsConstraint(value: Xamarin.Forms.BoundsConstraint) = x.WithAttribute(View._BoundsConstraintAttribKey, (value))

        /// Adjusts the HeightConstraint property in the visual element
        member x.HeightConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(View._HeightConstraintAttribKey, (value))

        /// Adjusts the WidthConstraint property in the visual element
        member x.WidthConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(View._WidthConstraintAttribKey, (value))

        /// Adjusts the XConstraint property in the visual element
        member x.XConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(View._XConstraintAttribKey, (value))

        /// Adjusts the YConstraint property in the visual element
        member x.YConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(View._YConstraintAttribKey, (value))

        /// Adjusts the AlignContent property in the visual element
        member x.AlignContent(value: Xamarin.Forms.FlexAlignContent) = x.WithAttribute(View._AlignContentAttribKey, (value))

        /// Adjusts the AlignItems property in the visual element
        member x.AlignItems(value: Xamarin.Forms.FlexAlignItems) = x.WithAttribute(View._AlignItemsAttribKey, (value))

        /// Adjusts the FlexLayoutDirection property in the visual element
        member x.FlexLayoutDirection(value: Xamarin.Forms.FlexDirection) = x.WithAttribute(View._FlexLayoutDirectionAttribKey, (value))

        /// Adjusts the Position property in the visual element
        member x.Position(value: Xamarin.Forms.FlexPosition) = x.WithAttribute(View._PositionAttribKey, (value))

        /// Adjusts the Wrap property in the visual element
        member x.Wrap(value: Xamarin.Forms.FlexWrap) = x.WithAttribute(View._WrapAttribKey, (value))

        /// Adjusts the JustifyContent property in the visual element
        member x.JustifyContent(value: Xamarin.Forms.FlexJustify) = x.WithAttribute(View._JustifyContentAttribKey, (value))

        /// Adjusts the FlexAlignSelf property in the visual element
        member x.FlexAlignSelf(value: Xamarin.Forms.FlexAlignSelf) = x.WithAttribute(View._FlexAlignSelfAttribKey, (value))

        /// Adjusts the FlexOrder property in the visual element
        member x.FlexOrder(value: int) = x.WithAttribute(View._FlexOrderAttribKey, (value))

        /// Adjusts the FlexBasis property in the visual element
        member x.FlexBasis(value: Xamarin.Forms.FlexBasis) = x.WithAttribute(View._FlexBasisAttribKey, (value))

        /// Adjusts the FlexGrow property in the visual element
        member x.FlexGrow(value: double) = x.WithAttribute(View._FlexGrowAttribKey, single(value))

        /// Adjusts the FlexShrink property in the visual element
        member x.FlexShrink(value: double) = x.WithAttribute(View._FlexShrinkAttribKey, single(value))

        /// Adjusts the Date property in the visual element
        member x.Date(value: System.DateTime) = x.WithAttribute(View._DateAttribKey, (value))

        /// Adjusts the Format property in the visual element
        member x.Format(value: string) = x.WithAttribute(View._FormatAttribKey, (value))

        /// Adjusts the MinimumDate property in the visual element
        member x.MinimumDate(value: System.DateTime) = x.WithAttribute(View._MinimumDateAttribKey, (value))

        /// Adjusts the MaximumDate property in the visual element
        member x.MaximumDate(value: System.DateTime) = x.WithAttribute(View._MaximumDateAttribKey, (value))

        /// Adjusts the DateSelected property in the visual element
        member x.DateSelected(value: Xamarin.Forms.DateChangedEventArgs -> unit) = x.WithAttribute(View._DateSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the PickerItemsSource property in the visual element
        member x.PickerItemsSource(value: seq<'T>) = x.WithAttribute(View._PickerItemsSourceAttribKey, seqToIListUntyped(value))

        /// Adjusts the SelectedIndex property in the visual element
        member x.SelectedIndex(value: int) = x.WithAttribute(View._SelectedIndexAttribKey, (value))

        /// Adjusts the Title property in the visual element
        member x.Title(value: string) = x.WithAttribute(View._TitleAttribKey, (value))

        /// Adjusts the SelectedIndexChanged property in the visual element
        member x.SelectedIndexChanged(value: (int * 'T option) -> unit) = x.WithAttribute(View._SelectedIndexChangedAttribKey, (fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(value))

        /// Adjusts the FrameCornerRadius property in the visual element
        member x.FrameCornerRadius(value: double) = x.WithAttribute(View._FrameCornerRadiusAttribKey, single(value))

        /// Adjusts the HasShadow property in the visual element
        member x.HasShadow(value: bool) = x.WithAttribute(View._HasShadowAttribKey, (value))

        /// Adjusts the ImageSource property in the visual element
        member x.ImageSource(value: obj) = x.WithAttribute(View._ImageSourceAttribKey, (value))

        /// Adjusts the Aspect property in the visual element
        member x.Aspect(value: Xamarin.Forms.Aspect) = x.WithAttribute(View._AspectAttribKey, (value))

        /// Adjusts the IsOpaque property in the visual element
        member x.IsOpaque(value: bool) = x.WithAttribute(View._IsOpaqueAttribKey, (value))

        /// Adjusts the ImageButtonCommand property in the visual element
        member x.ImageButtonCommand(value: unit -> unit) = x.WithAttribute(View._ImageButtonCommandAttribKey, (value))

        /// Adjusts the ImageButtonCornerRadius property in the visual element
        member x.ImageButtonCornerRadius(value: int) = x.WithAttribute(View._ImageButtonCornerRadiusAttribKey, (value))

        /// Adjusts the Clicked property in the visual element
        member x.Clicked(value: System.EventArgs -> unit) = x.WithAttribute(View._ClickedAttribKey, (fun f -> System.EventHandler(fun _sender args -> f args))(value))

        /// Adjusts the Pressed property in the visual element
        member x.Pressed(value: System.EventArgs -> unit) = x.WithAttribute(View._PressedAttribKey, (fun f -> System.EventHandler(fun _sender args -> f args))(value))

        /// Adjusts the Released property in the visual element
        member x.Released(value: System.EventArgs -> unit) = x.WithAttribute(View._ReleasedAttribKey, (fun f -> System.EventHandler(fun _sender args -> f args))(value))

        /// Adjusts the Keyboard property in the visual element
        member x.Keyboard(value: Xamarin.Forms.Keyboard) = x.WithAttribute(View._KeyboardAttribKey, (value))

        /// Adjusts the EditorCompleted property in the visual element
        member x.EditorCompleted(value: string -> unit) = x.WithAttribute(View._EditorCompletedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(value))

        /// Adjusts the TextChanged property in the visual element
        member x.TextChanged(value: Xamarin.Forms.TextChangedEventArgs -> unit) = x.WithAttribute(View._TextChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the AutoSize property in the visual element
        member x.AutoSize(value: Xamarin.Forms.EditorAutoSizeOption) = x.WithAttribute(View._AutoSizeAttribKey, (value))

        /// Adjusts the IsPassword property in the visual element
        member x.IsPassword(value: bool) = x.WithAttribute(View._IsPasswordAttribKey, (value))

        /// Adjusts the EntryCompleted property in the visual element
        member x.EntryCompleted(value: string -> unit) = x.WithAttribute(View._EntryCompletedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(value))

        /// Adjusts the IsTextPredictionEnabled property in the visual element
        member x.IsTextPredictionEnabled(value: bool) = x.WithAttribute(View._IsTextPredictionEnabledAttribKey, (value))

        /// Adjusts the ReturnType property in the visual element
        member x.ReturnType(value: Xamarin.Forms.ReturnType) = x.WithAttribute(View._ReturnTypeAttribKey, (value))

        /// Adjusts the ReturnCommand property in the visual element
        member x.ReturnCommand(value: unit -> unit) = x.WithAttribute(View._ReturnCommandAttribKey, makeCommand(value))

        /// Adjusts the CursorPosition property in the visual element
        member x.CursorPosition(value: int) = x.WithAttribute(View._CursorPositionAttribKey, (value))

        /// Adjusts the SelectionLength property in the visual element
        member x.SelectionLength(value: int) = x.WithAttribute(View._SelectionLengthAttribKey, (value))

        /// Adjusts the Label property in the visual element
        member x.Label(value: string) = x.WithAttribute(View._LabelAttribKey, (value))

        /// Adjusts the EntryCellTextChanged property in the visual element
        member x.EntryCellTextChanged(value: Xamarin.Forms.TextChangedEventArgs -> unit) = x.WithAttribute(View._EntryCellTextChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the VerticalTextAlignment property in the visual element
        member x.VerticalTextAlignment(value: Xamarin.Forms.TextAlignment) = x.WithAttribute(View._VerticalTextAlignmentAttribKey, (value))

        /// Adjusts the FormattedText property in the visual element
        member x.FormattedText(value: ViewElement) = x.WithAttribute(View._FormattedTextAttribKey, (value))

        /// Adjusts the LineBreakMode property in the visual element
        member x.LineBreakMode(value: Xamarin.Forms.LineBreakMode) = x.WithAttribute(View._LineBreakModeAttribKey, (value))

        /// Adjusts the LineHeight property in the visual element
        member x.LineHeight(value: double) = x.WithAttribute(View._LineHeightAttribKey, (value))

        /// Adjusts the MaxLines property in the visual element
        member x.MaxLines(value: int) = x.WithAttribute(View._MaxLinesAttribKey, (value))

        /// Adjusts the TextDecorations property in the visual element
        member x.TextDecorations(value: Xamarin.Forms.TextDecorations) = x.WithAttribute(View._TextDecorationsAttribKey, (value))

        /// Adjusts the StackOrientation property in the visual element
        member x.StackOrientation(value: Xamarin.Forms.StackOrientation) = x.WithAttribute(View._StackOrientationAttribKey, (value))

        /// Adjusts the Spacing property in the visual element
        member x.Spacing(value: double) = x.WithAttribute(View._SpacingAttribKey, (value))

        /// Adjusts the ForegroundColor property in the visual element
        member x.ForegroundColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._ForegroundColorAttribKey, (value))

        /// Adjusts the PropertyChanged property in the visual element
        member x.PropertyChanged(value: System.ComponentModel.PropertyChangedEventArgs -> unit) = x.WithAttribute(View._PropertyChangedAttribKey, (fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Spans property in the visual element
        member x.Spans(value: ViewElement[]) = x.WithAttribute(View._SpansAttribKey, (value))

        /// Adjusts the Time property in the visual element
        member x.Time(value: System.TimeSpan) = x.WithAttribute(View._TimeAttribKey, (value))

        /// Adjusts the WebSource property in the visual element
        member x.WebSource(value: Xamarin.Forms.WebViewSource) = x.WithAttribute(View._WebSourceAttribKey, (value))

        /// Adjusts the Reload property in the visual element
        member x.Reload(value: bool) = x.WithAttribute(View._ReloadAttribKey, (value))

        /// Adjusts the Navigated property in the visual element
        member x.Navigated(value: Xamarin.Forms.WebNavigatedEventArgs -> unit) = x.WithAttribute(View._NavigatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Navigating property in the visual element
        member x.Navigating(value: Xamarin.Forms.WebNavigatingEventArgs -> unit) = x.WithAttribute(View._NavigatingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the ReloadRequested property in the visual element
        member x.ReloadRequested(value: System.EventArgs -> unit) = x.WithAttribute(View._ReloadRequestedAttribKey, (fun f -> System.EventHandler(fun _sender args -> f args))(value))

        /// Adjusts the BackgroundImage property in the visual element
        member x.BackgroundImage(value: string) = x.WithAttribute(View._BackgroundImageAttribKey, (value))

        /// Adjusts the Icon property in the visual element
        member x.Icon(value: string) = x.WithAttribute(View._IconAttribKey, (value))

        /// Adjusts the IsBusy property in the visual element
        member x.IsBusy(value: bool) = x.WithAttribute(View._IsBusyAttribKey, (value))

        /// Adjusts the ToolbarItems property in the visual element
        member x.ToolbarItems(value: ViewElement list) = x.WithAttribute(View._ToolbarItemsAttribKey, Array.ofList(value))

        /// Adjusts the UseSafeArea property in the visual element
        member x.UseSafeArea(value: bool) = x.WithAttribute(View._UseSafeAreaAttribKey, (value))

        /// Adjusts the Page_Appearing property in the visual element
        member x.Page_Appearing(value: unit -> unit) = x.WithAttribute(View._Page_AppearingAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(value))

        /// Adjusts the Page_Disappearing property in the visual element
        member x.Page_Disappearing(value: unit -> unit) = x.WithAttribute(View._Page_DisappearingAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(value))

        /// Adjusts the Page_LayoutChanged property in the visual element
        member x.Page_LayoutChanged(value: unit -> unit) = x.WithAttribute(View._Page_LayoutChangedAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(value))

        /// Adjusts the CarouselPage_CurrentPage property in the visual element
        member x.CarouselPage_CurrentPage(value: int) = x.WithAttribute(View._CarouselPage_CurrentPageAttribKey, (value))

        /// Adjusts the CarouselPage_CurrentPageChanged property in the visual element
        member x.CarouselPage_CurrentPageChanged(value: int option -> unit) = x.WithAttribute(View._CarouselPage_CurrentPageChangedAttribKey, makeCurrentPageChanged<Xamarin.Forms.ContentPage>(value))

        /// Adjusts the Pages property in the visual element
        member x.Pages(value: ViewElement list) = x.WithAttribute(View._PagesAttribKey, Array.ofList(value))

        /// Adjusts the BackButtonTitle property in the visual element
        member x.BackButtonTitle(value: string) = x.WithAttribute(View._BackButtonTitleAttribKey, (value))

        /// Adjusts the HasBackButton property in the visual element
        member x.HasBackButton(value: bool) = x.WithAttribute(View._HasBackButtonAttribKey, (value))

        /// Adjusts the HasNavigationBar property in the visual element
        member x.HasNavigationBar(value: bool) = x.WithAttribute(View._HasNavigationBarAttribKey, (value))

        /// Adjusts the TitleIcon property in the visual element
        member x.TitleIcon(value: string) = x.WithAttribute(View._TitleIconAttribKey, (value))

        /// Adjusts the TitleView property in the visual element
        member x.TitleView(value: ViewElement) = x.WithAttribute(View._TitleViewAttribKey, (value))

        /// Adjusts the BarBackgroundColor property in the visual element
        member x.BarBackgroundColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._BarBackgroundColorAttribKey, (value))

        /// Adjusts the BarTextColor property in the visual element
        member x.BarTextColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._BarTextColorAttribKey, (value))

        /// Adjusts the Popped property in the visual element
        member x.Popped(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttribute(View._PoppedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value))

        /// Adjusts the PoppedToRoot property in the visual element
        member x.PoppedToRoot(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttribute(View._PoppedToRootAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value))

        /// Adjusts the Pushed property in the visual element
        member x.Pushed(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttribute(View._PushedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value))

        /// Adjusts the TabbedPage_CurrentPage property in the visual element
        member x.TabbedPage_CurrentPage(value: int) = x.WithAttribute(View._TabbedPage_CurrentPageAttribKey, (value))

        /// Adjusts the TabbedPage_CurrentPageChanged property in the visual element
        member x.TabbedPage_CurrentPageChanged(value: int option -> unit) = x.WithAttribute(View._TabbedPage_CurrentPageChangedAttribKey, makeCurrentPageChanged<Xamarin.Forms.Page>(value))

        /// Adjusts the OnSizeAllocatedCallback property in the visual element
        member x.OnSizeAllocatedCallback(value: (double * double) -> unit) = x.WithAttribute(View._OnSizeAllocatedCallbackAttribKey, (fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(value))

        /// Adjusts the Master property in the visual element
        member x.Master(value: ViewElement) = x.WithAttribute(View._MasterAttribKey, (value))

        /// Adjusts the Detail property in the visual element
        member x.Detail(value: ViewElement) = x.WithAttribute(View._DetailAttribKey, (value))

        /// Adjusts the IsGestureEnabled property in the visual element
        member x.IsGestureEnabled(value: bool) = x.WithAttribute(View._IsGestureEnabledAttribKey, (value))

        /// Adjusts the IsPresented property in the visual element
        member x.IsPresented(value: bool) = x.WithAttribute(View._IsPresentedAttribKey, (value))

        /// Adjusts the MasterBehavior property in the visual element
        member x.MasterBehavior(value: Xamarin.Forms.MasterBehavior) = x.WithAttribute(View._MasterBehaviorAttribKey, (value))

        /// Adjusts the IsPresentedChanged property in the visual element
        member x.IsPresentedChanged(value: bool -> unit) = x.WithAttribute(View._IsPresentedChangedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(value))

        /// Adjusts the TextDetail property in the visual element
        member x.TextDetail(value: string) = x.WithAttribute(View._TextDetailAttribKey, (value))

        /// Adjusts the TextDetailColor property in the visual element
        member x.TextDetailColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._TextDetailColorAttribKey, (value))

        /// Adjusts the TextCellCommand property in the visual element
        member x.TextCellCommand(value: unit -> unit) = x.WithAttribute(View._TextCellCommandAttribKey, (value))

        /// Adjusts the TextCellCanExecute property in the visual element
        member x.TextCellCanExecute(value: bool) = x.WithAttribute(View._TextCellCanExecuteAttribKey, (value))

        /// Adjusts the Order property in the visual element
        member x.Order(value: Xamarin.Forms.ToolbarItemOrder) = x.WithAttribute(View._OrderAttribKey, (value))

        /// Adjusts the Priority property in the visual element
        member x.Priority(value: int) = x.WithAttribute(View._PriorityAttribKey, (value))

        /// Adjusts the View property in the visual element
        member x.View(value: ViewElement) = x.WithAttribute(View._ViewAttribKey, (value))

        /// Adjusts the ListViewItems property in the visual element
        member x.ListViewItems(value: seq<ViewElement>) = x.WithAttribute(View._ListViewItemsAttribKey, (value))

        /// Adjusts the Footer property in the visual element
        member x.Footer(value: System.Object) = x.WithAttribute(View._FooterAttribKey, (value))

        /// Adjusts the Header property in the visual element
        member x.Header(value: System.Object) = x.WithAttribute(View._HeaderAttribKey, (value))

        /// Adjusts the HeaderTemplate property in the visual element
        member x.HeaderTemplate(value: Xamarin.Forms.DataTemplate) = x.WithAttribute(View._HeaderTemplateAttribKey, (value))

        /// Adjusts the IsGroupingEnabled property in the visual element
        member x.IsGroupingEnabled(value: bool) = x.WithAttribute(View._IsGroupingEnabledAttribKey, (value))

        /// Adjusts the IsPullToRefreshEnabled property in the visual element
        member x.IsPullToRefreshEnabled(value: bool) = x.WithAttribute(View._IsPullToRefreshEnabledAttribKey, (value))

        /// Adjusts the IsRefreshing property in the visual element
        member x.IsRefreshing(value: bool) = x.WithAttribute(View._IsRefreshingAttribKey, (value))

        /// Adjusts the RefreshCommand property in the visual element
        member x.RefreshCommand(value: unit -> unit) = x.WithAttribute(View._RefreshCommandAttribKey, makeCommand(value))

        /// Adjusts the ListView_SelectedItem property in the visual element
        member x.ListView_SelectedItem(value: int option) = x.WithAttribute(View._ListView_SelectedItemAttribKey, (value))

        /// Adjusts the ListView_SeparatorVisibility property in the visual element
        member x.ListView_SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttribute(View._ListView_SeparatorVisibilityAttribKey, (value))

        /// Adjusts the ListView_SeparatorColor property in the visual element
        member x.ListView_SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._ListView_SeparatorColorAttribKey, (value))

        /// Adjusts the ListView_ItemAppearing property in the visual element
        member x.ListView_ItemAppearing(value: int -> unit) = x.WithAttribute(View._ListView_ItemAppearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value))

        /// Adjusts the ListView_ItemDisappearing property in the visual element
        member x.ListView_ItemDisappearing(value: int -> unit) = x.WithAttribute(View._ListView_ItemDisappearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value))

        /// Adjusts the ListView_ItemSelected property in the visual element
        member x.ListView_ItemSelected(value: int option -> unit) = x.WithAttribute(View._ListView_ItemSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(value))

        /// Adjusts the ListView_ItemTapped property in the visual element
        member x.ListView_ItemTapped(value: int -> unit) = x.WithAttribute(View._ListView_ItemTappedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value))

        /// Adjusts the ListView_Refreshing property in the visual element
        member x.ListView_Refreshing(value: unit -> unit) = x.WithAttribute(View._ListView_RefreshingAttribKey, (fun f -> System.EventHandler(fun sender args -> f ()))(value))

        /// Adjusts the SelectionMode property in the visual element
        member x.SelectionMode(value: Xamarin.Forms.ListViewSelectionMode) = x.WithAttribute(View._SelectionModeAttribKey, (value))

        /// Adjusts the ListViewGrouped_ItemsSource property in the visual element
        member x.ListViewGrouped_ItemsSource(value: (string * ViewElement * ViewElement list) list) = x.WithAttribute(View._ListViewGrouped_ItemsSourceAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun (g, e, l) -> (g, e, Array.ofList l)))(value))

        /// Adjusts the ListViewGrouped_ShowJumpList property in the visual element
        member x.ListViewGrouped_ShowJumpList(value: bool) = x.WithAttribute(View._ListViewGrouped_ShowJumpListAttribKey, (value))

        /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
        member x.ListViewGrouped_SelectedItem(value: (int * int) option) = x.WithAttribute(View._ListViewGrouped_SelectedItemAttribKey, (value))

        /// Adjusts the SeparatorVisibility property in the visual element
        member x.SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttribute(View._SeparatorVisibilityAttribKey, (value))

        /// Adjusts the SeparatorColor property in the visual element
        member x.SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttribute(View._SeparatorColorAttribKey, (value))

        /// Adjusts the ListViewGrouped_ItemAppearing property in the visual element
        member x.ListViewGrouped_ItemAppearing(value: int * int option -> unit) = x.WithAttribute(View._ListViewGrouped_ItemAppearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItemOrGroupItem sender args.Item).Value))(value))

        /// Adjusts the ListViewGrouped_ItemDisappearing property in the visual element
        member x.ListViewGrouped_ItemDisappearing(value: int * int option -> unit) = x.WithAttribute(View._ListViewGrouped_ItemDisappearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItemOrGroupItem sender args.Item).Value))(value))

        /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
        member x.ListViewGrouped_ItemSelected(value: (int * int) option -> unit) = x.WithAttribute(View._ListViewGrouped_ItemSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(value))

        /// Adjusts the ListViewGrouped_ItemTapped property in the visual element
        member x.ListViewGrouped_ItemTapped(value: int * int -> unit) = x.WithAttribute(View._ListViewGrouped_ItemTappedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value))

        /// Adjusts the Refreshing property in the visual element
        member x.Refreshing(value: unit -> unit) = x.WithAttribute(View._RefreshingAttribKey, (fun f -> System.EventHandler(fun sender args -> f ()))(value))


    /// Adjusts the ClassId property in the visual element
    let classId (value: string) (x: ViewElement) = x.ClassId(value)

    /// Adjusts the StyleId property in the visual element
    let styleId (value: string) (x: ViewElement) = x.StyleId(value)

    /// Adjusts the AutomationId property in the visual element
    let automationId (value: string) (x: ViewElement) = x.AutomationId(value)

    /// Adjusts the AnchorX property in the visual element
    let anchorX (value: double) (x: ViewElement) = x.AnchorX(value)

    /// Adjusts the AnchorY property in the visual element
    let anchorY (value: double) (x: ViewElement) = x.AnchorY(value)

    /// Adjusts the BackgroundColor property in the visual element
    let backgroundColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.BackgroundColor(value)

    /// Adjusts the HeightRequest property in the visual element
    let heightRequest (value: double) (x: ViewElement) = x.HeightRequest(value)

    /// Adjusts the InputTransparent property in the visual element
    let inputTransparent (value: bool) (x: ViewElement) = x.InputTransparent(value)

    /// Adjusts the IsEnabled property in the visual element
    let isEnabled (value: bool) (x: ViewElement) = x.IsEnabled(value)

    /// Adjusts the IsVisible property in the visual element
    let isVisible (value: bool) (x: ViewElement) = x.IsVisible(value)

    /// Adjusts the MinimumHeightRequest property in the visual element
    let minimumHeightRequest (value: double) (x: ViewElement) = x.MinimumHeightRequest(value)

    /// Adjusts the MinimumWidthRequest property in the visual element
    let minimumWidthRequest (value: double) (x: ViewElement) = x.MinimumWidthRequest(value)

    /// Adjusts the Opacity property in the visual element
    let opacity (value: double) (x: ViewElement) = x.Opacity(value)

    /// Adjusts the Rotation property in the visual element
    let rotation (value: double) (x: ViewElement) = x.Rotation(value)

    /// Adjusts the RotationX property in the visual element
    let rotationX (value: double) (x: ViewElement) = x.RotationX(value)

    /// Adjusts the RotationY property in the visual element
    let rotationY (value: double) (x: ViewElement) = x.RotationY(value)

    /// Adjusts the Scale property in the visual element
    let scale (value: double) (x: ViewElement) = x.Scale(value)

    /// Adjusts the Style property in the visual element
    let style (value: Xamarin.Forms.Style) (x: ViewElement) = x.Style(value)

    /// Adjusts the StyleClass property in the visual element
    let styleClass (value: obj) (x: ViewElement) = x.StyleClass(value)

    /// Adjusts the TranslationX property in the visual element
    let translationX (value: double) (x: ViewElement) = x.TranslationX(value)

    /// Adjusts the TranslationY property in the visual element
    let translationY (value: double) (x: ViewElement) = x.TranslationY(value)

    /// Adjusts the WidthRequest property in the visual element
    let widthRequest (value: double) (x: ViewElement) = x.WidthRequest(value)

    /// Adjusts the Resources property in the visual element
    let resources (value: (string * obj) list) (x: ViewElement) = x.Resources(value)

    /// Adjusts the Styles property in the visual element
    let styles (value: Xamarin.Forms.Style list) (x: ViewElement) = x.Styles(value)

    /// Adjusts the StyleSheets property in the visual element
    let styleSheets (value: Xamarin.Forms.StyleSheets.StyleSheet list) (x: ViewElement) = x.StyleSheets(value)

    /// Adjusts the IsTabStop property in the visual element
    let isTabStop (value: bool) (x: ViewElement) = x.IsTabStop(value)

    /// Adjusts the ScaleX property in the visual element
    let scaleX (value: double) (x: ViewElement) = x.ScaleX(value)

    /// Adjusts the ScaleY property in the visual element
    let scaleY (value: double) (x: ViewElement) = x.ScaleY(value)

    /// Adjusts the TabIndex property in the visual element
    let tabIndex (value: int) (x: ViewElement) = x.TabIndex(value)

    /// Adjusts the HorizontalOptions property in the visual element
    let horizontalOptions (value: Xamarin.Forms.LayoutOptions) (x: ViewElement) = x.HorizontalOptions(value)

    /// Adjusts the VerticalOptions property in the visual element
    let verticalOptions (value: Xamarin.Forms.LayoutOptions) (x: ViewElement) = x.VerticalOptions(value)

    /// Adjusts the Margin property in the visual element
    let margin (value: obj) (x: ViewElement) = x.Margin(value)

    /// Adjusts the GestureRecognizers property in the visual element
    let gestureRecognizers (value: ViewElement list) (x: ViewElement) = x.GestureRecognizers(value)

    /// Adjusts the TouchPoints property in the visual element
    let touchPoints (value: int) (x: ViewElement) = x.TouchPoints(value)

    /// Adjusts the PanUpdated property in the visual element
    let panUpdated (value: Xamarin.Forms.PanUpdatedEventArgs -> unit) (x: ViewElement) = x.PanUpdated(value)

    /// Adjusts the Command property in the visual element
    let command (value: unit -> unit) (x: ViewElement) = x.Command(value)

    /// Adjusts the NumberOfTapsRequired property in the visual element
    let numberOfTapsRequired (value: int) (x: ViewElement) = x.NumberOfTapsRequired(value)

    /// Adjusts the NumberOfClicksRequired property in the visual element
    let numberOfClicksRequired (value: int) (x: ViewElement) = x.NumberOfClicksRequired(value)

    /// Adjusts the Buttons property in the visual element
    let buttons (value: Xamarin.Forms.ButtonsMask) (x: ViewElement) = x.Buttons(value)

    /// Adjusts the IsPinching property in the visual element
    let isPinching (value: bool) (x: ViewElement) = x.IsPinching(value)

    /// Adjusts the PinchUpdated property in the visual element
    let pinchUpdated (value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) (x: ViewElement) = x.PinchUpdated(value)

    /// Adjusts the SwipeGestureRecognizerDirection property in the visual element
    let swipeGestureRecognizerDirection (value: Xamarin.Forms.SwipeDirection) (x: ViewElement) = x.SwipeGestureRecognizerDirection(value)

    /// Adjusts the Threshold property in the visual element
    let threshold (value: System.UInt32) (x: ViewElement) = x.Threshold(value)

    /// Adjusts the Swiped property in the visual element
    let swiped (value: Xamarin.Forms.SwipedEventArgs -> unit) (x: ViewElement) = x.Swiped(value)

    /// Adjusts the Color property in the visual element
    let color (value: Xamarin.Forms.Color) (x: ViewElement) = x.Color(value)

    /// Adjusts the IsRunning property in the visual element
    let isRunning (value: bool) (x: ViewElement) = x.IsRunning(value)

    /// Adjusts the BoxViewCornerRadius property in the visual element
    let boxViewCornerRadius (value: Xamarin.Forms.CornerRadius) (x: ViewElement) = x.BoxViewCornerRadius(value)

    /// Adjusts the Progress property in the visual element
    let progress (value: double) (x: ViewElement) = x.Progress(value)

    /// Adjusts the IsClippedToBounds property in the visual element
    let isClippedToBounds (value: bool) (x: ViewElement) = x.IsClippedToBounds(value)

    /// Adjusts the Padding property in the visual element
    let padding (value: obj) (x: ViewElement) = x.Padding(value)

    /// Adjusts the Content property in the visual element
    let content (value: ViewElement) (x: ViewElement) = x.Content(value)

    /// Adjusts the ScrollOrientation property in the visual element
    let scrollOrientation (value: Xamarin.Forms.ScrollOrientation) (x: ViewElement) = x.ScrollOrientation(value)

    /// Adjusts the HorizontalScrollBarVisibility property in the visual element
    let horizontalScrollBarVisibility (value: Xamarin.Forms.ScrollBarVisibility) (x: ViewElement) = x.HorizontalScrollBarVisibility(value)

    /// Adjusts the VerticalScrollBarVisibility property in the visual element
    let verticalScrollBarVisibility (value: Xamarin.Forms.ScrollBarVisibility) (x: ViewElement) = x.VerticalScrollBarVisibility(value)

    /// Adjusts the CancelButtonColor property in the visual element
    let cancelButtonColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.CancelButtonColor(value)

    /// Adjusts the FontFamily property in the visual element
    let fontFamily (value: string) (x: ViewElement) = x.FontFamily(value)

    /// Adjusts the FontAttributes property in the visual element
    let fontAttributes (value: Xamarin.Forms.FontAttributes) (x: ViewElement) = x.FontAttributes(value)

    /// Adjusts the FontSize property in the visual element
    let fontSize (value: obj) (x: ViewElement) = x.FontSize(value)

    /// Adjusts the HorizontalTextAlignment property in the visual element
    let horizontalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: ViewElement) = x.HorizontalTextAlignment(value)

    /// Adjusts the Placeholder property in the visual element
    let placeholder (value: string) (x: ViewElement) = x.Placeholder(value)

    /// Adjusts the PlaceholderColor property in the visual element
    let placeholderColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.PlaceholderColor(value)

    /// Adjusts the SearchBarCommand property in the visual element
    let searchBarCommand (value: string -> unit) (x: ViewElement) = x.SearchBarCommand(value)

    /// Adjusts the SearchBarCanExecute property in the visual element
    let searchBarCanExecute (value: bool) (x: ViewElement) = x.SearchBarCanExecute(value)

    /// Adjusts the Text property in the visual element
    let text (value: string) (x: ViewElement) = x.Text(value)

    /// Adjusts the TextColor property in the visual element
    let textColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.TextColor(value)

    /// Adjusts the SearchBarTextChanged property in the visual element
    let searchBarTextChanged (value: Xamarin.Forms.TextChangedEventArgs -> unit) (x: ViewElement) = x.SearchBarTextChanged(value)

    /// Adjusts the ButtonCommand property in the visual element
    let buttonCommand (value: unit -> unit) (x: ViewElement) = x.ButtonCommand(value)

    /// Adjusts the ButtonCanExecute property in the visual element
    let buttonCanExecute (value: bool) (x: ViewElement) = x.ButtonCanExecute(value)

    /// Adjusts the BorderColor property in the visual element
    let borderColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.BorderColor(value)

    /// Adjusts the BorderWidth property in the visual element
    let borderWidth (value: double) (x: ViewElement) = x.BorderWidth(value)

    /// Adjusts the CommandParameter property in the visual element
    let commandParameter (value: System.Object) (x: ViewElement) = x.CommandParameter(value)

    /// Adjusts the ContentLayout property in the visual element
    let contentLayout (value: Xamarin.Forms.Button.ButtonContentLayout) (x: ViewElement) = x.ContentLayout(value)

    /// Adjusts the ButtonCornerRadius property in the visual element
    let buttonCornerRadius (value: int) (x: ViewElement) = x.ButtonCornerRadius(value)

    /// Adjusts the ButtonImageSource property in the visual element
    let buttonImageSource (value: string) (x: ViewElement) = x.ButtonImageSource(value)

    /// Adjusts the MinimumMaximum property in the visual element
    let minimumMaximum (value: float * float) (x: ViewElement) = x.MinimumMaximum(value)

    /// Adjusts the Value property in the visual element
    let value (value: double) (x: ViewElement) = x.Value(value)

    /// Adjusts the ValueChanged property in the visual element
    let valueChanged (value: Xamarin.Forms.ValueChangedEventArgs -> unit) (x: ViewElement) = x.ValueChanged(value)

    /// Adjusts the Increment property in the visual element
    let increment (value: double) (x: ViewElement) = x.Increment(value)

    /// Adjusts the IsToggled property in the visual element
    let isToggled (value: bool) (x: ViewElement) = x.IsToggled(value)

    /// Adjusts the Toggled property in the visual element
    let toggled (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: ViewElement) = x.Toggled(value)

    /// Adjusts the OnColor property in the visual element
    let onColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.OnColor(value)

    /// Adjusts the Height property in the visual element
    let height (value: double) (x: ViewElement) = x.Height(value)

    /// Adjusts the On property in the visual element
    let on (value: bool) (x: ViewElement) = x.On(value)

    /// Adjusts the OnChanged property in the visual element
    let onChanged (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: ViewElement) = x.OnChanged(value)

    /// Adjusts the Intent property in the visual element
    let intent (value: Xamarin.Forms.TableIntent) (x: ViewElement) = x.Intent(value)

    /// Adjusts the HasUnevenRows property in the visual element
    let hasUnevenRows (value: bool) (x: ViewElement) = x.HasUnevenRows(value)

    /// Adjusts the RowHeight property in the visual element
    let rowHeight (value: int) (x: ViewElement) = x.RowHeight(value)

    /// Adjusts the TableRoot property in the visual element
    let tableRoot (value: (string * ViewElement list) list) (x: ViewElement) = x.TableRoot(value)

    /// Adjusts the RowDefinitionHeight property in the visual element
    let rowDefinitionHeight (value: obj) (x: ViewElement) = x.RowDefinitionHeight(value)

    /// Adjusts the ColumnDefinitionWidth property in the visual element
    let columnDefinitionWidth (value: obj) (x: ViewElement) = x.ColumnDefinitionWidth(value)

    /// Adjusts the GridRowDefinitions property in the visual element
    let gridRowDefinitions (value: obj list) (x: ViewElement) = x.GridRowDefinitions(value)

    /// Adjusts the GridColumnDefinitions property in the visual element
    let gridColumnDefinitions (value: obj list) (x: ViewElement) = x.GridColumnDefinitions(value)

    /// Adjusts the RowSpacing property in the visual element
    let rowSpacing (value: double) (x: ViewElement) = x.RowSpacing(value)

    /// Adjusts the ColumnSpacing property in the visual element
    let columnSpacing (value: double) (x: ViewElement) = x.ColumnSpacing(value)

    /// Adjusts the Children property in the visual element
    let children (value: ViewElement list) (x: ViewElement) = x.Children(value)

    /// Adjusts the GridRow property in the visual element
    let gridRow (value: int) (x: ViewElement) = x.GridRow(value)

    /// Adjusts the GridRowSpan property in the visual element
    let gridRowSpan (value: int) (x: ViewElement) = x.GridRowSpan(value)

    /// Adjusts the GridColumn property in the visual element
    let gridColumn (value: int) (x: ViewElement) = x.GridColumn(value)

    /// Adjusts the GridColumnSpan property in the visual element
    let gridColumnSpan (value: int) (x: ViewElement) = x.GridColumnSpan(value)

    /// Adjusts the LayoutBounds property in the visual element
    let layoutBounds (value: Xamarin.Forms.Rectangle) (x: ViewElement) = x.LayoutBounds(value)

    /// Adjusts the LayoutFlags property in the visual element
    let layoutFlags (value: Xamarin.Forms.AbsoluteLayoutFlags) (x: ViewElement) = x.LayoutFlags(value)

    /// Adjusts the BoundsConstraint property in the visual element
    let boundsConstraint (value: Xamarin.Forms.BoundsConstraint) (x: ViewElement) = x.BoundsConstraint(value)

    /// Adjusts the HeightConstraint property in the visual element
    let heightConstraint (value: Xamarin.Forms.Constraint) (x: ViewElement) = x.HeightConstraint(value)

    /// Adjusts the WidthConstraint property in the visual element
    let widthConstraint (value: Xamarin.Forms.Constraint) (x: ViewElement) = x.WidthConstraint(value)

    /// Adjusts the XConstraint property in the visual element
    let xConstraint (value: Xamarin.Forms.Constraint) (x: ViewElement) = x.XConstraint(value)

    /// Adjusts the YConstraint property in the visual element
    let yConstraint (value: Xamarin.Forms.Constraint) (x: ViewElement) = x.YConstraint(value)

    /// Adjusts the AlignContent property in the visual element
    let alignContent (value: Xamarin.Forms.FlexAlignContent) (x: ViewElement) = x.AlignContent(value)

    /// Adjusts the AlignItems property in the visual element
    let alignItems (value: Xamarin.Forms.FlexAlignItems) (x: ViewElement) = x.AlignItems(value)

    /// Adjusts the FlexLayoutDirection property in the visual element
    let flexLayoutDirection (value: Xamarin.Forms.FlexDirection) (x: ViewElement) = x.FlexLayoutDirection(value)

    /// Adjusts the Position property in the visual element
    let position (value: Xamarin.Forms.FlexPosition) (x: ViewElement) = x.Position(value)

    /// Adjusts the Wrap property in the visual element
    let wrap (value: Xamarin.Forms.FlexWrap) (x: ViewElement) = x.Wrap(value)

    /// Adjusts the JustifyContent property in the visual element
    let justifyContent (value: Xamarin.Forms.FlexJustify) (x: ViewElement) = x.JustifyContent(value)

    /// Adjusts the FlexAlignSelf property in the visual element
    let flexAlignSelf (value: Xamarin.Forms.FlexAlignSelf) (x: ViewElement) = x.FlexAlignSelf(value)

    /// Adjusts the FlexOrder property in the visual element
    let flexOrder (value: int) (x: ViewElement) = x.FlexOrder(value)

    /// Adjusts the FlexBasis property in the visual element
    let flexBasis (value: Xamarin.Forms.FlexBasis) (x: ViewElement) = x.FlexBasis(value)

    /// Adjusts the FlexGrow property in the visual element
    let flexGrow (value: double) (x: ViewElement) = x.FlexGrow(value)

    /// Adjusts the FlexShrink property in the visual element
    let flexShrink (value: double) (x: ViewElement) = x.FlexShrink(value)

    /// Adjusts the Date property in the visual element
    let date (value: System.DateTime) (x: ViewElement) = x.Date(value)

    /// Adjusts the Format property in the visual element
    let format (value: string) (x: ViewElement) = x.Format(value)

    /// Adjusts the MinimumDate property in the visual element
    let minimumDate (value: System.DateTime) (x: ViewElement) = x.MinimumDate(value)

    /// Adjusts the MaximumDate property in the visual element
    let maximumDate (value: System.DateTime) (x: ViewElement) = x.MaximumDate(value)

    /// Adjusts the DateSelected property in the visual element
    let dateSelected (value: Xamarin.Forms.DateChangedEventArgs -> unit) (x: ViewElement) = x.DateSelected(value)

    /// Adjusts the PickerItemsSource property in the visual element
    let pickerItemsSource (value: seq<'T>) (x: ViewElement) = x.PickerItemsSource(value)

    /// Adjusts the SelectedIndex property in the visual element
    let selectedIndex (value: int) (x: ViewElement) = x.SelectedIndex(value)

    /// Adjusts the Title property in the visual element
    let title (value: string) (x: ViewElement) = x.Title(value)

    /// Adjusts the SelectedIndexChanged property in the visual element
    let selectedIndexChanged (value: (int * 'T option) -> unit) (x: ViewElement) = x.SelectedIndexChanged(value)

    /// Adjusts the FrameCornerRadius property in the visual element
    let frameCornerRadius (value: double) (x: ViewElement) = x.FrameCornerRadius(value)

    /// Adjusts the HasShadow property in the visual element
    let hasShadow (value: bool) (x: ViewElement) = x.HasShadow(value)

    /// Adjusts the ImageSource property in the visual element
    let imageSource (value: obj) (x: ViewElement) = x.ImageSource(value)

    /// Adjusts the Aspect property in the visual element
    let aspect (value: Xamarin.Forms.Aspect) (x: ViewElement) = x.Aspect(value)

    /// Adjusts the IsOpaque property in the visual element
    let isOpaque (value: bool) (x: ViewElement) = x.IsOpaque(value)

    /// Adjusts the ImageButtonCommand property in the visual element
    let imageButtonCommand (value: unit -> unit) (x: ViewElement) = x.ImageButtonCommand(value)

    /// Adjusts the ImageButtonCornerRadius property in the visual element
    let imageButtonCornerRadius (value: int) (x: ViewElement) = x.ImageButtonCornerRadius(value)

    /// Adjusts the Clicked property in the visual element
    let clicked (value: System.EventArgs -> unit) (x: ViewElement) = x.Clicked(value)

    /// Adjusts the Pressed property in the visual element
    let pressed (value: System.EventArgs -> unit) (x: ViewElement) = x.Pressed(value)

    /// Adjusts the Released property in the visual element
    let released (value: System.EventArgs -> unit) (x: ViewElement) = x.Released(value)

    /// Adjusts the Keyboard property in the visual element
    let keyboard (value: Xamarin.Forms.Keyboard) (x: ViewElement) = x.Keyboard(value)

    /// Adjusts the EditorCompleted property in the visual element
    let editorCompleted (value: string -> unit) (x: ViewElement) = x.EditorCompleted(value)

    /// Adjusts the TextChanged property in the visual element
    let textChanged (value: Xamarin.Forms.TextChangedEventArgs -> unit) (x: ViewElement) = x.TextChanged(value)

    /// Adjusts the AutoSize property in the visual element
    let autoSize (value: Xamarin.Forms.EditorAutoSizeOption) (x: ViewElement) = x.AutoSize(value)

    /// Adjusts the IsPassword property in the visual element
    let isPassword (value: bool) (x: ViewElement) = x.IsPassword(value)

    /// Adjusts the EntryCompleted property in the visual element
    let entryCompleted (value: string -> unit) (x: ViewElement) = x.EntryCompleted(value)

    /// Adjusts the IsTextPredictionEnabled property in the visual element
    let isTextPredictionEnabled (value: bool) (x: ViewElement) = x.IsTextPredictionEnabled(value)

    /// Adjusts the ReturnType property in the visual element
    let returnType (value: Xamarin.Forms.ReturnType) (x: ViewElement) = x.ReturnType(value)

    /// Adjusts the ReturnCommand property in the visual element
    let returnCommand (value: unit -> unit) (x: ViewElement) = x.ReturnCommand(value)

    /// Adjusts the CursorPosition property in the visual element
    let cursorPosition (value: int) (x: ViewElement) = x.CursorPosition(value)

    /// Adjusts the SelectionLength property in the visual element
    let selectionLength (value: int) (x: ViewElement) = x.SelectionLength(value)

    /// Adjusts the Label property in the visual element
    let label (value: string) (x: ViewElement) = x.Label(value)

    /// Adjusts the EntryCellTextChanged property in the visual element
    let entryCellTextChanged (value: Xamarin.Forms.TextChangedEventArgs -> unit) (x: ViewElement) = x.EntryCellTextChanged(value)

    /// Adjusts the VerticalTextAlignment property in the visual element
    let verticalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: ViewElement) = x.VerticalTextAlignment(value)

    /// Adjusts the FormattedText property in the visual element
    let formattedText (value: ViewElement) (x: ViewElement) = x.FormattedText(value)

    /// Adjusts the LineBreakMode property in the visual element
    let lineBreakMode (value: Xamarin.Forms.LineBreakMode) (x: ViewElement) = x.LineBreakMode(value)

    /// Adjusts the LineHeight property in the visual element
    let lineHeight (value: double) (x: ViewElement) = x.LineHeight(value)

    /// Adjusts the MaxLines property in the visual element
    let maxLines (value: int) (x: ViewElement) = x.MaxLines(value)

    /// Adjusts the TextDecorations property in the visual element
    let textDecorations (value: Xamarin.Forms.TextDecorations) (x: ViewElement) = x.TextDecorations(value)

    /// Adjusts the StackOrientation property in the visual element
    let stackOrientation (value: Xamarin.Forms.StackOrientation) (x: ViewElement) = x.StackOrientation(value)

    /// Adjusts the Spacing property in the visual element
    let spacing (value: double) (x: ViewElement) = x.Spacing(value)

    /// Adjusts the ForegroundColor property in the visual element
    let foregroundColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.ForegroundColor(value)

    /// Adjusts the PropertyChanged property in the visual element
    let propertyChanged (value: System.ComponentModel.PropertyChangedEventArgs -> unit) (x: ViewElement) = x.PropertyChanged(value)

    /// Adjusts the Spans property in the visual element
    let spans (value: ViewElement[]) (x: ViewElement) = x.Spans(value)

    /// Adjusts the Time property in the visual element
    let time (value: System.TimeSpan) (x: ViewElement) = x.Time(value)

    /// Adjusts the WebSource property in the visual element
    let webSource (value: Xamarin.Forms.WebViewSource) (x: ViewElement) = x.WebSource(value)

    /// Adjusts the Reload property in the visual element
    let reload (value: bool) (x: ViewElement) = x.Reload(value)

    /// Adjusts the Navigated property in the visual element
    let navigated (value: Xamarin.Forms.WebNavigatedEventArgs -> unit) (x: ViewElement) = x.Navigated(value)

    /// Adjusts the Navigating property in the visual element
    let navigating (value: Xamarin.Forms.WebNavigatingEventArgs -> unit) (x: ViewElement) = x.Navigating(value)

    /// Adjusts the ReloadRequested property in the visual element
    let reloadRequested (value: System.EventArgs -> unit) (x: ViewElement) = x.ReloadRequested(value)

    /// Adjusts the BackgroundImage property in the visual element
    let backgroundImage (value: string) (x: ViewElement) = x.BackgroundImage(value)

    /// Adjusts the Icon property in the visual element
    let icon (value: string) (x: ViewElement) = x.Icon(value)

    /// Adjusts the IsBusy property in the visual element
    let isBusy (value: bool) (x: ViewElement) = x.IsBusy(value)

    /// Adjusts the ToolbarItems property in the visual element
    let toolbarItems (value: ViewElement list) (x: ViewElement) = x.ToolbarItems(value)

    /// Adjusts the UseSafeArea property in the visual element
    let useSafeArea (value: bool) (x: ViewElement) = x.UseSafeArea(value)

    /// Adjusts the Page_Appearing property in the visual element
    let page_Appearing (value: unit -> unit) (x: ViewElement) = x.Page_Appearing(value)

    /// Adjusts the Page_Disappearing property in the visual element
    let page_Disappearing (value: unit -> unit) (x: ViewElement) = x.Page_Disappearing(value)

    /// Adjusts the Page_LayoutChanged property in the visual element
    let page_LayoutChanged (value: unit -> unit) (x: ViewElement) = x.Page_LayoutChanged(value)

    /// Adjusts the CarouselPage_CurrentPage property in the visual element
    let carouselPage_CurrentPage (value: int) (x: ViewElement) = x.CarouselPage_CurrentPage(value)

    /// Adjusts the CarouselPage_CurrentPageChanged property in the visual element
    let carouselPage_CurrentPageChanged (value: int option -> unit) (x: ViewElement) = x.CarouselPage_CurrentPageChanged(value)

    /// Adjusts the Pages property in the visual element
    let pages (value: ViewElement list) (x: ViewElement) = x.Pages(value)

    /// Adjusts the BackButtonTitle property in the visual element
    let backButtonTitle (value: string) (x: ViewElement) = x.BackButtonTitle(value)

    /// Adjusts the HasBackButton property in the visual element
    let hasBackButton (value: bool) (x: ViewElement) = x.HasBackButton(value)

    /// Adjusts the HasNavigationBar property in the visual element
    let hasNavigationBar (value: bool) (x: ViewElement) = x.HasNavigationBar(value)

    /// Adjusts the TitleIcon property in the visual element
    let titleIcon (value: string) (x: ViewElement) = x.TitleIcon(value)

    /// Adjusts the TitleView property in the visual element
    let titleView (value: ViewElement) (x: ViewElement) = x.TitleView(value)

    /// Adjusts the BarBackgroundColor property in the visual element
    let barBackgroundColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.BarBackgroundColor(value)

    /// Adjusts the BarTextColor property in the visual element
    let barTextColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.BarTextColor(value)

    /// Adjusts the Popped property in the visual element
    let popped (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: ViewElement) = x.Popped(value)

    /// Adjusts the PoppedToRoot property in the visual element
    let poppedToRoot (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: ViewElement) = x.PoppedToRoot(value)

    /// Adjusts the Pushed property in the visual element
    let pushed (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: ViewElement) = x.Pushed(value)

    /// Adjusts the TabbedPage_CurrentPage property in the visual element
    let tabbedPage_CurrentPage (value: int) (x: ViewElement) = x.TabbedPage_CurrentPage(value)

    /// Adjusts the TabbedPage_CurrentPageChanged property in the visual element
    let tabbedPage_CurrentPageChanged (value: int option -> unit) (x: ViewElement) = x.TabbedPage_CurrentPageChanged(value)

    /// Adjusts the OnSizeAllocatedCallback property in the visual element
    let onSizeAllocatedCallback (value: (double * double) -> unit) (x: ViewElement) = x.OnSizeAllocatedCallback(value)

    /// Adjusts the Master property in the visual element
    let master (value: ViewElement) (x: ViewElement) = x.Master(value)

    /// Adjusts the Detail property in the visual element
    let detail (value: ViewElement) (x: ViewElement) = x.Detail(value)

    /// Adjusts the IsGestureEnabled property in the visual element
    let isGestureEnabled (value: bool) (x: ViewElement) = x.IsGestureEnabled(value)

    /// Adjusts the IsPresented property in the visual element
    let isPresented (value: bool) (x: ViewElement) = x.IsPresented(value)

    /// Adjusts the MasterBehavior property in the visual element
    let masterBehavior (value: Xamarin.Forms.MasterBehavior) (x: ViewElement) = x.MasterBehavior(value)

    /// Adjusts the IsPresentedChanged property in the visual element
    let isPresentedChanged (value: bool -> unit) (x: ViewElement) = x.IsPresentedChanged(value)

    /// Adjusts the TextDetail property in the visual element
    let textDetail (value: string) (x: ViewElement) = x.TextDetail(value)

    /// Adjusts the TextDetailColor property in the visual element
    let textDetailColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.TextDetailColor(value)

    /// Adjusts the TextCellCommand property in the visual element
    let textCellCommand (value: unit -> unit) (x: ViewElement) = x.TextCellCommand(value)

    /// Adjusts the TextCellCanExecute property in the visual element
    let textCellCanExecute (value: bool) (x: ViewElement) = x.TextCellCanExecute(value)

    /// Adjusts the Order property in the visual element
    let order (value: Xamarin.Forms.ToolbarItemOrder) (x: ViewElement) = x.Order(value)

    /// Adjusts the Priority property in the visual element
    let priority (value: int) (x: ViewElement) = x.Priority(value)

    /// Adjusts the View property in the visual element
    let view (value: ViewElement) (x: ViewElement) = x.View(value)

    /// Adjusts the ListViewItems property in the visual element
    let listViewItems (value: seq<ViewElement>) (x: ViewElement) = x.ListViewItems(value)

    /// Adjusts the Footer property in the visual element
    let footer (value: System.Object) (x: ViewElement) = x.Footer(value)

    /// Adjusts the Header property in the visual element
    let header (value: System.Object) (x: ViewElement) = x.Header(value)

    /// Adjusts the HeaderTemplate property in the visual element
    let headerTemplate (value: Xamarin.Forms.DataTemplate) (x: ViewElement) = x.HeaderTemplate(value)

    /// Adjusts the IsGroupingEnabled property in the visual element
    let isGroupingEnabled (value: bool) (x: ViewElement) = x.IsGroupingEnabled(value)

    /// Adjusts the IsPullToRefreshEnabled property in the visual element
    let isPullToRefreshEnabled (value: bool) (x: ViewElement) = x.IsPullToRefreshEnabled(value)

    /// Adjusts the IsRefreshing property in the visual element
    let isRefreshing (value: bool) (x: ViewElement) = x.IsRefreshing(value)

    /// Adjusts the RefreshCommand property in the visual element
    let refreshCommand (value: unit -> unit) (x: ViewElement) = x.RefreshCommand(value)

    /// Adjusts the ListView_SelectedItem property in the visual element
    let listView_SelectedItem (value: int option) (x: ViewElement) = x.ListView_SelectedItem(value)

    /// Adjusts the ListView_SeparatorVisibility property in the visual element
    let listView_SeparatorVisibility (value: Xamarin.Forms.SeparatorVisibility) (x: ViewElement) = x.ListView_SeparatorVisibility(value)

    /// Adjusts the ListView_SeparatorColor property in the visual element
    let listView_SeparatorColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.ListView_SeparatorColor(value)

    /// Adjusts the ListView_ItemAppearing property in the visual element
    let listView_ItemAppearing (value: int -> unit) (x: ViewElement) = x.ListView_ItemAppearing(value)

    /// Adjusts the ListView_ItemDisappearing property in the visual element
    let listView_ItemDisappearing (value: int -> unit) (x: ViewElement) = x.ListView_ItemDisappearing(value)

    /// Adjusts the ListView_ItemSelected property in the visual element
    let listView_ItemSelected (value: int option -> unit) (x: ViewElement) = x.ListView_ItemSelected(value)

    /// Adjusts the ListView_ItemTapped property in the visual element
    let listView_ItemTapped (value: int -> unit) (x: ViewElement) = x.ListView_ItemTapped(value)

    /// Adjusts the ListView_Refreshing property in the visual element
    let listView_Refreshing (value: unit -> unit) (x: ViewElement) = x.ListView_Refreshing(value)

    /// Adjusts the SelectionMode property in the visual element
    let selectionMode (value: Xamarin.Forms.ListViewSelectionMode) (x: ViewElement) = x.SelectionMode(value)

    /// Adjusts the ListViewGrouped_ItemsSource property in the visual element
    let listViewGrouped_ItemsSource (value: (string * ViewElement * ViewElement list) list) (x: ViewElement) = x.ListViewGrouped_ItemsSource(value)

    /// Adjusts the ListViewGrouped_ShowJumpList property in the visual element
    let listViewGrouped_ShowJumpList (value: bool) (x: ViewElement) = x.ListViewGrouped_ShowJumpList(value)

    /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
    let listViewGrouped_SelectedItem (value: (int * int) option) (x: ViewElement) = x.ListViewGrouped_SelectedItem(value)

    /// Adjusts the SeparatorVisibility property in the visual element
    let separatorVisibility (value: Xamarin.Forms.SeparatorVisibility) (x: ViewElement) = x.SeparatorVisibility(value)

    /// Adjusts the SeparatorColor property in the visual element
    let separatorColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.SeparatorColor(value)

    /// Adjusts the ListViewGrouped_ItemAppearing property in the visual element
    let listViewGrouped_ItemAppearing (value: int * int option -> unit) (x: ViewElement) = x.ListViewGrouped_ItemAppearing(value)

    /// Adjusts the ListViewGrouped_ItemDisappearing property in the visual element
    let listViewGrouped_ItemDisappearing (value: int * int option -> unit) (x: ViewElement) = x.ListViewGrouped_ItemDisappearing(value)

    /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
    let listViewGrouped_ItemSelected (value: (int * int) option -> unit) (x: ViewElement) = x.ListViewGrouped_ItemSelected(value)

    /// Adjusts the ListViewGrouped_ItemTapped property in the visual element
    let listViewGrouped_ItemTapped (value: int * int -> unit) (x: ViewElement) = x.ListViewGrouped_ItemTapped(value)

    /// Adjusts the Refreshing property in the visual element
    let refreshing (value: unit -> unit) (x: ViewElement) = x.Refreshing(value)
