namespace Elmish.XamarinForms.DynamicViews 

#nowarn "59" // cast always holds
#nowarn "66" // cast always holds
#nowarn "67" // cast always holds

type Xaml() =

    static member val _ClassIdAttribKey : AttributeKey<_> = AttributeKey<_>("ClassId")
    static member val _StyleIdAttribKey : AttributeKey<_> = AttributeKey<_>("StyleId")
    static member val _AnchorXAttribKey : AttributeKey<_> = AttributeKey<_>("AnchorX")
    static member val _AnchorYAttribKey : AttributeKey<_> = AttributeKey<_>("AnchorY")
    static member val _BackgroundColorAttribKey : AttributeKey<_> = AttributeKey<_>("BackgroundColor")
    static member val _HeightRequestAttribKey : AttributeKey<_> = AttributeKey<_>("HeightRequest")
    static member val _InputTransparentAttribKey : AttributeKey<_> = AttributeKey<_>("InputTransparent")
    static member val _IsEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("IsEnabled")
    static member val _IsVisibleAttribKey : AttributeKey<_> = AttributeKey<_>("IsVisible")
    static member val _MinimumHeightRequestAttribKey : AttributeKey<_> = AttributeKey<_>("MinimumHeightRequest")
    static member val _MinimumWidthRequestAttribKey : AttributeKey<_> = AttributeKey<_>("MinimumWidthRequest")
    static member val _OpacityAttribKey : AttributeKey<_> = AttributeKey<_>("Opacity")
    static member val _RotationAttribKey : AttributeKey<_> = AttributeKey<_>("Rotation")
    static member val _RotationXAttribKey : AttributeKey<_> = AttributeKey<_>("RotationX")
    static member val _RotationYAttribKey : AttributeKey<_> = AttributeKey<_>("RotationY")
    static member val _ScaleAttribKey : AttributeKey<_> = AttributeKey<_>("Scale")
    static member val _StyleAttribKey : AttributeKey<_> = AttributeKey<_>("Style")
    static member val _TranslationXAttribKey : AttributeKey<_> = AttributeKey<_>("TranslationX")
    static member val _TranslationYAttribKey : AttributeKey<_> = AttributeKey<_>("TranslationY")
    static member val _WidthRequestAttribKey : AttributeKey<_> = AttributeKey<_>("WidthRequest")
    static member val _ResourcesAttribKey : AttributeKey<_> = AttributeKey<_>("Resources")
    static member val _StylesAttribKey : AttributeKey<_> = AttributeKey<_>("Styles")
    static member val _StyleSheetsAttribKey : AttributeKey<_> = AttributeKey<_>("StyleSheets")
    static member val _HorizontalOptionsAttribKey : AttributeKey<_> = AttributeKey<_>("HorizontalOptions")
    static member val _VerticalOptionsAttribKey : AttributeKey<_> = AttributeKey<_>("VerticalOptions")
    static member val _MarginAttribKey : AttributeKey<_> = AttributeKey<_>("Margin")
    static member val _GestureRecognizersAttribKey : AttributeKey<_> = AttributeKey<_>("GestureRecognizers")
    static member val _TouchPointsAttribKey : AttributeKey<_> = AttributeKey<_>("TouchPoints")
    static member val _PanUpdatedAttribKey : AttributeKey<_> = AttributeKey<_>("PanUpdated")
    static member val _CommandAttribKey : AttributeKey<_> = AttributeKey<_>("Command")
    static member val _NumberOfTapsRequiredAttribKey : AttributeKey<_> = AttributeKey<_>("NumberOfTapsRequired")
    static member val _NumberOfClicksRequiredAttribKey : AttributeKey<_> = AttributeKey<_>("NumberOfClicksRequired")
    static member val _ButtonsAttribKey : AttributeKey<_> = AttributeKey<_>("Buttons")
    static member val _IsPinchingAttribKey : AttributeKey<_> = AttributeKey<_>("IsPinching")
    static member val _PinchUpdatedAttribKey : AttributeKey<_> = AttributeKey<_>("PinchUpdated")
    static member val _ColorAttribKey : AttributeKey<_> = AttributeKey<_>("Color")
    static member val _IsRunningAttribKey : AttributeKey<_> = AttributeKey<_>("IsRunning")
    static member val _ProgressAttribKey : AttributeKey<_> = AttributeKey<_>("Progress")
    static member val _IsClippedToBoundsAttribKey : AttributeKey<_> = AttributeKey<_>("IsClippedToBounds")
    static member val _PaddingAttribKey : AttributeKey<_> = AttributeKey<_>("Padding")
    static member val _ContentAttribKey : AttributeKey<_> = AttributeKey<_>("Content")
    static member val _ScrollOrientationAttribKey : AttributeKey<_> = AttributeKey<_>("ScrollOrientation")
    static member val _CancelButtonColorAttribKey : AttributeKey<_> = AttributeKey<_>("CancelButtonColor")
    static member val _FontFamilyAttribKey : AttributeKey<_> = AttributeKey<_>("FontFamily")
    static member val _FontAttributesAttribKey : AttributeKey<_> = AttributeKey<_>("FontAttributes")
    static member val _FontSizeAttribKey : AttributeKey<_> = AttributeKey<_>("FontSize")
    static member val _HorizontalTextAlignmentAttribKey : AttributeKey<_> = AttributeKey<_>("HorizontalTextAlignment")
    static member val _PlaceholderAttribKey : AttributeKey<_> = AttributeKey<_>("Placeholder")
    static member val _PlaceholderColorAttribKey : AttributeKey<_> = AttributeKey<_>("PlaceholderColor")
    static member val _SearchBarCommandAttribKey : AttributeKey<_> = AttributeKey<_>("SearchBarCommand")
    static member val _SearchBarCanExecuteAttribKey : AttributeKey<_> = AttributeKey<_>("SearchBarCanExecute")
    static member val _TextAttribKey : AttributeKey<_> = AttributeKey<_>("Text")
    static member val _TextColorAttribKey : AttributeKey<_> = AttributeKey<_>("TextColor")
    static member val _ButtonCommandAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonCommand")
    static member val _ButtonCanExecuteAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonCanExecute")
    static member val _BorderColorAttribKey : AttributeKey<_> = AttributeKey<_>("BorderColor")
    static member val _BorderWidthAttribKey : AttributeKey<_> = AttributeKey<_>("BorderWidth")
    static member val _CommandParameterAttribKey : AttributeKey<_> = AttributeKey<_>("CommandParameter")
    static member val _ContentLayoutAttribKey : AttributeKey<_> = AttributeKey<_>("ContentLayout")
    static member val _ButtonCornerRadiusAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonCornerRadius")
    static member val _ButtonImageSourceAttribKey : AttributeKey<_> = AttributeKey<_>("ButtonImageSource")
    static member val _MinimumAttribKey : AttributeKey<_> = AttributeKey<_>("Minimum")
    static member val _MaximumAttribKey : AttributeKey<_> = AttributeKey<_>("Maximum")
    static member val _ValueAttribKey : AttributeKey<_> = AttributeKey<_>("Value")
    static member val _ValueChangedAttribKey : AttributeKey<_> = AttributeKey<_>("ValueChanged")
    static member val _IncrementAttribKey : AttributeKey<_> = AttributeKey<_>("Increment")
    static member val _IsToggledAttribKey : AttributeKey<_> = AttributeKey<_>("IsToggled")
    static member val _ToggledAttribKey : AttributeKey<_> = AttributeKey<_>("Toggled")
    static member val _HeightAttribKey : AttributeKey<_> = AttributeKey<_>("Height")
    static member val _OnAttribKey : AttributeKey<_> = AttributeKey<_>("On")
    static member val _OnChangedAttribKey : AttributeKey<_> = AttributeKey<_>("OnChanged")
    static member val _IntentAttribKey : AttributeKey<_> = AttributeKey<_>("Intent")
    static member val _HasUnevenRowsAttribKey : AttributeKey<_> = AttributeKey<_>("HasUnevenRows")
    static member val _RowHeightAttribKey : AttributeKey<_> = AttributeKey<_>("RowHeight")
    static member val _TableRootAttribKey : AttributeKey<_> = AttributeKey<_>("TableRoot")
    static member val _RowDefinitionHeightAttribKey : AttributeKey<_> = AttributeKey<_>("RowDefinitionHeight")
    static member val _ColumnDefinitionWidthAttribKey : AttributeKey<_> = AttributeKey<_>("ColumnDefinitionWidth")
    static member val _GridRowDefinitionsAttribKey : AttributeKey<_> = AttributeKey<_>("GridRowDefinitions")
    static member val _GridColumnDefinitionsAttribKey : AttributeKey<_> = AttributeKey<_>("GridColumnDefinitions")
    static member val _RowSpacingAttribKey : AttributeKey<_> = AttributeKey<_>("RowSpacing")
    static member val _ColumnSpacingAttribKey : AttributeKey<_> = AttributeKey<_>("ColumnSpacing")
    static member val _ChildrenAttribKey : AttributeKey<_> = AttributeKey<_>("Children")
    static member val _GridRowAttribKey : AttributeKey<_> = AttributeKey<_>("GridRow")
    static member val _GridRowSpanAttribKey : AttributeKey<_> = AttributeKey<_>("GridRowSpan")
    static member val _GridColumnAttribKey : AttributeKey<_> = AttributeKey<_>("GridColumn")
    static member val _GridColumnSpanAttribKey : AttributeKey<_> = AttributeKey<_>("GridColumnSpan")
    static member val _LayoutBoundsAttribKey : AttributeKey<_> = AttributeKey<_>("LayoutBounds")
    static member val _LayoutFlagsAttribKey : AttributeKey<_> = AttributeKey<_>("LayoutFlags")
    static member val _BoundsConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("BoundsConstraint")
    static member val _HeightConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("HeightConstraint")
    static member val _WidthConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("WidthConstraint")
    static member val _XConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("XConstraint")
    static member val _YConstraintAttribKey : AttributeKey<_> = AttributeKey<_>("YConstraint")
    static member val _AlignContentAttribKey : AttributeKey<_> = AttributeKey<_>("AlignContent")
    static member val _AlignItemsAttribKey : AttributeKey<_> = AttributeKey<_>("AlignItems")
    static member val _DirectionAttribKey : AttributeKey<_> = AttributeKey<_>("Direction")
    static member val _PositionAttribKey : AttributeKey<_> = AttributeKey<_>("Position")
    static member val _WrapAttribKey : AttributeKey<_> = AttributeKey<_>("Wrap")
    static member val _JustifyContentAttribKey : AttributeKey<_> = AttributeKey<_>("JustifyContent")
    static member val _FlexAlignSelfAttribKey : AttributeKey<_> = AttributeKey<_>("FlexAlignSelf")
    static member val _FlexOrderAttribKey : AttributeKey<_> = AttributeKey<_>("FlexOrder")
    static member val _FlexBasisAttribKey : AttributeKey<_> = AttributeKey<_>("FlexBasis")
    static member val _FlexGrowAttribKey : AttributeKey<_> = AttributeKey<_>("FlexGrow")
    static member val _FlexShrinkAttribKey : AttributeKey<_> = AttributeKey<_>("FlexShrink")
    static member val _DateAttribKey : AttributeKey<_> = AttributeKey<_>("Date")
    static member val _FormatAttribKey : AttributeKey<_> = AttributeKey<_>("Format")
    static member val _MinimumDateAttribKey : AttributeKey<_> = AttributeKey<_>("MinimumDate")
    static member val _MaximumDateAttribKey : AttributeKey<_> = AttributeKey<_>("MaximumDate")
    static member val _DateSelectedAttribKey : AttributeKey<_> = AttributeKey<_>("DateSelected")
    static member val _PickerItemsSourceAttribKey : AttributeKey<_> = AttributeKey<_>("PickerItemsSource")
    static member val _SelectedIndexAttribKey : AttributeKey<_> = AttributeKey<_>("SelectedIndex")
    static member val _TitleAttribKey : AttributeKey<_> = AttributeKey<_>("Title")
    static member val _SelectedIndexChangedAttribKey : AttributeKey<_> = AttributeKey<_>("SelectedIndexChanged")
    static member val _FrameCornerRadiusAttribKey : AttributeKey<_> = AttributeKey<_>("FrameCornerRadius")
    static member val _HasShadowAttribKey : AttributeKey<_> = AttributeKey<_>("HasShadow")
    static member val _ImageSourceAttribKey : AttributeKey<_> = AttributeKey<_>("ImageSource")
    static member val _AspectAttribKey : AttributeKey<_> = AttributeKey<_>("Aspect")
    static member val _IsOpaqueAttribKey : AttributeKey<_> = AttributeKey<_>("IsOpaque")
    static member val _KeyboardAttribKey : AttributeKey<_> = AttributeKey<_>("Keyboard")
    static member val _EditorCompletedAttribKey : AttributeKey<_> = AttributeKey<_>("EditorCompleted")
    static member val _TextChangedAttribKey : AttributeKey<_> = AttributeKey<_>("TextChanged")
    static member val _IsPasswordAttribKey : AttributeKey<_> = AttributeKey<_>("IsPassword")
    static member val _EntryCompletedAttribKey : AttributeKey<_> = AttributeKey<_>("EntryCompleted")
    static member val _LabelAttribKey : AttributeKey<_> = AttributeKey<_>("Label")
    static member val _VerticalTextAlignmentAttribKey : AttributeKey<_> = AttributeKey<_>("VerticalTextAlignment")
    static member val _FormattedTextAttribKey : AttributeKey<_> = AttributeKey<_>("FormattedText")
    static member val _StackOrientationAttribKey : AttributeKey<_> = AttributeKey<_>("StackOrientation")
    static member val _SpacingAttribKey : AttributeKey<_> = AttributeKey<_>("Spacing")
    static member val _ForegroundColorAttribKey : AttributeKey<_> = AttributeKey<_>("ForegroundColor")
    static member val _PropertyChangedAttribKey : AttributeKey<_> = AttributeKey<_>("PropertyChanged")
    static member val _SpansAttribKey : AttributeKey<_> = AttributeKey<_>("Spans")
    static member val _TimeAttribKey : AttributeKey<_> = AttributeKey<_>("Time")
    static member val _WebSourceAttribKey : AttributeKey<_> = AttributeKey<_>("WebSource")
    static member val _NavigatedAttribKey : AttributeKey<_> = AttributeKey<_>("Navigated")
    static member val _NavigatingAttribKey : AttributeKey<_> = AttributeKey<_>("Navigating")
    static member val _BackgroundImageAttribKey : AttributeKey<_> = AttributeKey<_>("BackgroundImage")
    static member val _IconAttribKey : AttributeKey<_> = AttributeKey<_>("Icon")
    static member val _IsBusyAttribKey : AttributeKey<_> = AttributeKey<_>("IsBusy")
    static member val _ToolbarItemsAttribKey : AttributeKey<_> = AttributeKey<_>("ToolbarItems")
    static member val _UseSafeAreaAttribKey : AttributeKey<_> = AttributeKey<_>("UseSafeArea")
    static member val _Page_AppearingAttribKey : AttributeKey<_> = AttributeKey<_>("Page_Appearing")
    static member val _Page_DisappearingAttribKey : AttributeKey<_> = AttributeKey<_>("Page_Disappearing")
    static member val _Page_LayoutChangedAttribKey : AttributeKey<_> = AttributeKey<_>("Page_LayoutChanged")
    static member val _CarouselPage_SelectedItemAttribKey : AttributeKey<_> = AttributeKey<_>("CarouselPage_SelectedItem")
    static member val _CurrentPageAttribKey : AttributeKey<_> = AttributeKey<_>("CurrentPage")
    static member val _CurrentPageChangedAttribKey : AttributeKey<_> = AttributeKey<_>("CurrentPageChanged")
    static member val _PagesAttribKey : AttributeKey<_> = AttributeKey<_>("Pages")
    static member val _BackButtonTitleAttribKey : AttributeKey<_> = AttributeKey<_>("BackButtonTitle")
    static member val _HasBackButtonAttribKey : AttributeKey<_> = AttributeKey<_>("HasBackButton")
    static member val _HasNavigationBarAttribKey : AttributeKey<_> = AttributeKey<_>("HasNavigationBar")
    static member val _TitleIconAttribKey : AttributeKey<_> = AttributeKey<_>("TitleIcon")
    static member val _BarBackgroundColorAttribKey : AttributeKey<_> = AttributeKey<_>("BarBackgroundColor")
    static member val _BarTextColorAttribKey : AttributeKey<_> = AttributeKey<_>("BarTextColor")
    static member val _PoppedAttribKey : AttributeKey<_> = AttributeKey<_>("Popped")
    static member val _PoppedToRootAttribKey : AttributeKey<_> = AttributeKey<_>("PoppedToRoot")
    static member val _PushedAttribKey : AttributeKey<_> = AttributeKey<_>("Pushed")
    static member val _OnSizeAllocatedCallbackAttribKey : AttributeKey<_> = AttributeKey<_>("OnSizeAllocatedCallback")
    static member val _MasterAttribKey : AttributeKey<_> = AttributeKey<_>("Master")
    static member val _DetailAttribKey : AttributeKey<_> = AttributeKey<_>("Detail")
    static member val _IsGestureEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("IsGestureEnabled")
    static member val _IsPresentedAttribKey : AttributeKey<_> = AttributeKey<_>("IsPresented")
    static member val _MasterBehaviorAttribKey : AttributeKey<_> = AttributeKey<_>("MasterBehavior")
    static member val _IsPresentedChangedAttribKey : AttributeKey<_> = AttributeKey<_>("IsPresentedChanged")
    static member val _TextDetailAttribKey : AttributeKey<_> = AttributeKey<_>("TextDetail")
    static member val _TextDetailColorAttribKey : AttributeKey<_> = AttributeKey<_>("TextDetailColor")
    static member val _TextCellCommandAttribKey : AttributeKey<_> = AttributeKey<_>("TextCellCommand")
    static member val _TextCellCanExecuteAttribKey : AttributeKey<_> = AttributeKey<_>("TextCellCanExecute")
    static member val _OrderAttribKey : AttributeKey<_> = AttributeKey<_>("Order")
    static member val _PriorityAttribKey : AttributeKey<_> = AttributeKey<_>("Priority")
    static member val _ViewAttribKey : AttributeKey<_> = AttributeKey<_>("View")
    static member val _ListViewItemsAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewItems")
    static member val _FooterAttribKey : AttributeKey<_> = AttributeKey<_>("Footer")
    static member val _HeaderAttribKey : AttributeKey<_> = AttributeKey<_>("Header")
    static member val _HeaderTemplateAttribKey : AttributeKey<_> = AttributeKey<_>("HeaderTemplate")
    static member val _IsGroupingEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("IsGroupingEnabled")
    static member val _IsPullToRefreshEnabledAttribKey : AttributeKey<_> = AttributeKey<_>("IsPullToRefreshEnabled")
    static member val _IsRefreshingAttribKey : AttributeKey<_> = AttributeKey<_>("IsRefreshing")
    static member val _RefreshCommandAttribKey : AttributeKey<_> = AttributeKey<_>("RefreshCommand")
    static member val _ListView_SelectedItemAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_SelectedItem")
    static member val _ListView_SeparatorVisibilityAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_SeparatorVisibility")
    static member val _ListView_SeparatorColorAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_SeparatorColor")
    static member val _ListView_ItemAppearingAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_ItemAppearing")
    static member val _ListView_ItemDisappearingAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_ItemDisappearing")
    static member val _ListView_ItemSelectedAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_ItemSelected")
    static member val _ListView_ItemTappedAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_ItemTapped")
    static member val _ListView_RefreshingAttribKey : AttributeKey<_> = AttributeKey<_>("ListView_Refreshing")
    static member val _ListViewGrouped_ItemsSourceAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ItemsSource")
    static member val _ListViewGrouped_SelectedItemAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_SelectedItem")
    static member val _SeparatorVisibilityAttribKey : AttributeKey<_> = AttributeKey<_>("SeparatorVisibility")
    static member val _SeparatorColorAttribKey : AttributeKey<_> = AttributeKey<_>("SeparatorColor")
    static member val _ListViewGrouped_ItemAppearingAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ItemAppearing")
    static member val _ListViewGrouped_ItemDisappearingAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ItemDisappearing")
    static member val _ListViewGrouped_ItemSelectedAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ItemSelected")
    static member val _ListViewGrouped_ItemTappedAttribKey : AttributeKey<_> = AttributeKey<_>("ListViewGrouped_ItemTapped")
    static member val _RefreshingAttribKey : AttributeKey<_> = AttributeKey<_>("Refreshing")

    /// Builds the attributes for a Element in the view
    static member inline _BuildElement(attribCount: int, ?classId: string, ?styleId: string) = 

        let attribCount = match classId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleId with Some _ -> attribCount + 1 | None -> attribCount
        let attribBuilder = new AttributesBuilder(attribCount)
        match classId with None -> () | Some v -> attribBuilder.Add(Xaml._ClassIdAttribKey, (v)) 
        match styleId with None -> () | Some v -> attribBuilder.Add(Xaml._StyleIdAttribKey, (v)) 
        attribBuilder

    static member val _ProtoElement : ViewElement option = None with get, set

    static member val _CreateElement : (unit -> Xamarin.Forms.Element) = fun () -> 
        failwith "can't create Xamarin.Forms.Element"

    static member val _UpdateElement = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Element) -> 
        let mutable prevClassIdOpt = ValueNone
        let mutable currClassIdOpt = ValueNone
        let mutable prevStyleIdOpt = ValueNone
        let mutable currStyleIdOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ClassIdAttribKey.KeyValue then 
                currClassIdOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._StyleIdAttribKey.KeyValue then 
                currStyleIdOpt <- ValueSome (kvp.Value :?> string)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ClassIdAttribKey.KeyValue then 
                    prevClassIdOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._StyleIdAttribKey.KeyValue then 
                    prevStyleIdOpt <- ValueSome (kvp.Value :?> string)
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

    /// Describes a Element in the view
    static member inline Element(?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildElement(0, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Element>(Xaml._CreateElement, Xaml._UpdateElement, attribBuilder)

    /// Builds the attributes for a VisualElement in the view
    static member inline _BuildVisualElement(attribCount: int, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

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
        let attribCount = match translationX with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match translationY with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match widthRequest with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match resources with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styles with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleSheets with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match anchorX with None -> () | Some v -> attribBuilder.Add(Xaml._AnchorXAttribKey, (v)) 
        match anchorY with None -> () | Some v -> attribBuilder.Add(Xaml._AnchorYAttribKey, (v)) 
        match backgroundColor with None -> () | Some v -> attribBuilder.Add(Xaml._BackgroundColorAttribKey, (v)) 
        match heightRequest with None -> () | Some v -> attribBuilder.Add(Xaml._HeightRequestAttribKey, (v)) 
        match inputTransparent with None -> () | Some v -> attribBuilder.Add(Xaml._InputTransparentAttribKey, (v)) 
        match isEnabled with None -> () | Some v -> attribBuilder.Add(Xaml._IsEnabledAttribKey, (v)) 
        match isVisible with None -> () | Some v -> attribBuilder.Add(Xaml._IsVisibleAttribKey, (v)) 
        match minimumHeightRequest with None -> () | Some v -> attribBuilder.Add(Xaml._MinimumHeightRequestAttribKey, (v)) 
        match minimumWidthRequest with None -> () | Some v -> attribBuilder.Add(Xaml._MinimumWidthRequestAttribKey, (v)) 
        match opacity with None -> () | Some v -> attribBuilder.Add(Xaml._OpacityAttribKey, (v)) 
        match rotation with None -> () | Some v -> attribBuilder.Add(Xaml._RotationAttribKey, (v)) 
        match rotationX with None -> () | Some v -> attribBuilder.Add(Xaml._RotationXAttribKey, (v)) 
        match rotationY with None -> () | Some v -> attribBuilder.Add(Xaml._RotationYAttribKey, (v)) 
        match scale with None -> () | Some v -> attribBuilder.Add(Xaml._ScaleAttribKey, (v)) 
        match style with None -> () | Some v -> attribBuilder.Add(Xaml._StyleAttribKey, (v)) 
        match translationX with None -> () | Some v -> attribBuilder.Add(Xaml._TranslationXAttribKey, (v)) 
        match translationY with None -> () | Some v -> attribBuilder.Add(Xaml._TranslationYAttribKey, (v)) 
        match widthRequest with None -> () | Some v -> attribBuilder.Add(Xaml._WidthRequestAttribKey, (v)) 
        match resources with None -> () | Some v -> attribBuilder.Add(Xaml._ResourcesAttribKey, (v)) 
        match styles with None -> () | Some v -> attribBuilder.Add(Xaml._StylesAttribKey, (v)) 
        match styleSheets with None -> () | Some v -> attribBuilder.Add(Xaml._StyleSheetsAttribKey, (v)) 
        attribBuilder

    static member val _ProtoVisualElement : ViewElement option = None with get, set

    static member val _CreateVisualElement : (unit -> Xamarin.Forms.VisualElement) = fun () -> 
        failwith "can't create Xamarin.Forms.VisualElement"

    static member val _UpdateVisualElement = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.VisualElement) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._AnchorXAttribKey.KeyValue then 
                currAnchorXOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._AnchorYAttribKey.KeyValue then 
                currAnchorYOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._BackgroundColorAttribKey.KeyValue then 
                currBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._HeightRequestAttribKey.KeyValue then 
                currHeightRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._InputTransparentAttribKey.KeyValue then 
                currInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsEnabledAttribKey.KeyValue then 
                currIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsVisibleAttribKey.KeyValue then 
                currIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._MinimumHeightRequestAttribKey.KeyValue then 
                currMinimumHeightRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._MinimumWidthRequestAttribKey.KeyValue then 
                currMinimumWidthRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._OpacityAttribKey.KeyValue then 
                currOpacityOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._RotationAttribKey.KeyValue then 
                currRotationOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._RotationXAttribKey.KeyValue then 
                currRotationXOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._RotationYAttribKey.KeyValue then 
                currRotationYOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ScaleAttribKey.KeyValue then 
                currScaleOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._StyleAttribKey.KeyValue then 
                currStyleOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style)
            if kvp.Key = Xaml._TranslationXAttribKey.KeyValue then 
                currTranslationXOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._TranslationYAttribKey.KeyValue then 
                currTranslationYOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._WidthRequestAttribKey.KeyValue then 
                currWidthRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ResourcesAttribKey.KeyValue then 
                currResourcesOpt <- ValueSome (kvp.Value :?> (string * obj) list)
            if kvp.Key = Xaml._StylesAttribKey.KeyValue then 
                currStylesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style list)
            if kvp.Key = Xaml._StyleSheetsAttribKey.KeyValue then 
                currStyleSheetsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StyleSheets.StyleSheet list)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._AnchorXAttribKey.KeyValue then 
                    prevAnchorXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._AnchorYAttribKey.KeyValue then 
                    prevAnchorYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._BackgroundColorAttribKey.KeyValue then 
                    prevBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._HeightRequestAttribKey.KeyValue then 
                    prevHeightRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._InputTransparentAttribKey.KeyValue then 
                    prevInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsEnabledAttribKey.KeyValue then 
                    prevIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsVisibleAttribKey.KeyValue then 
                    prevIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._MinimumHeightRequestAttribKey.KeyValue then 
                    prevMinimumHeightRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._MinimumWidthRequestAttribKey.KeyValue then 
                    prevMinimumWidthRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._OpacityAttribKey.KeyValue then 
                    prevOpacityOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._RotationAttribKey.KeyValue then 
                    prevRotationOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._RotationXAttribKey.KeyValue then 
                    prevRotationXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._RotationYAttribKey.KeyValue then 
                    prevRotationYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ScaleAttribKey.KeyValue then 
                    prevScaleOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._StyleAttribKey.KeyValue then 
                    prevStyleOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style)
                if kvp.Key = Xaml._TranslationXAttribKey.KeyValue then 
                    prevTranslationXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._TranslationYAttribKey.KeyValue then 
                    prevTranslationYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._WidthRequestAttribKey.KeyValue then 
                    prevWidthRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ResourcesAttribKey.KeyValue then 
                    prevResourcesOpt <- ValueSome (kvp.Value :?> (string * obj) list)
                if kvp.Key = Xaml._StylesAttribKey.KeyValue then 
                    prevStylesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style list)
                if kvp.Key = Xaml._StyleSheetsAttribKey.KeyValue then 
                    prevStyleSheetsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StyleSheets.StyleSheet list)
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

    /// Describes a VisualElement in the view
    static member inline VisualElement(?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildVisualElement(0, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.VisualElement>(Xaml._CreateVisualElement, Xaml._UpdateVisualElement, attribBuilder)

    /// Builds the attributes for a View in the view
    static member inline _BuildView(attribCount: int, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match horizontalOptions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match verticalOptions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match margin with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match gestureRecognizers with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildVisualElement(attribCount, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match horizontalOptions with None -> () | Some v -> attribBuilder.Add(Xaml._HorizontalOptionsAttribKey, (v)) 
        match verticalOptions with None -> () | Some v -> attribBuilder.Add(Xaml._VerticalOptionsAttribKey, (v)) 
        match margin with None -> () | Some v -> attribBuilder.Add(Xaml._MarginAttribKey, makeThickness(v)) 
        match gestureRecognizers with None -> () | Some v -> attribBuilder.Add(Xaml._GestureRecognizersAttribKey, Array.ofList(v)) 
        attribBuilder

    static member val _ProtoView : ViewElement option = None with get, set

    static member val _CreateView : (unit -> Xamarin.Forms.View) = fun () -> 
        failwith "can't create Xamarin.Forms.View"

    static member val _UpdateView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.View) -> 
        let baseElement = (if Xaml._ProtoVisualElement.IsNone then Xaml._ProtoVisualElement <- Some (Xaml.VisualElement())); Xaml._ProtoVisualElement.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevHorizontalOptionsOpt = ValueNone
        let mutable currHorizontalOptionsOpt = ValueNone
        let mutable prevVerticalOptionsOpt = ValueNone
        let mutable currVerticalOptionsOpt = ValueNone
        let mutable prevMarginOpt = ValueNone
        let mutable currMarginOpt = ValueNone
        let mutable prevGestureRecognizersOpt = ValueNone
        let mutable currGestureRecognizersOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._HorizontalOptionsAttribKey.KeyValue then 
                currHorizontalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
            if kvp.Key = Xaml._VerticalOptionsAttribKey.KeyValue then 
                currVerticalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
            if kvp.Key = Xaml._MarginAttribKey.KeyValue then 
                currMarginOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
            if kvp.Key = Xaml._GestureRecognizersAttribKey.KeyValue then 
                currGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._HorizontalOptionsAttribKey.KeyValue then 
                    prevHorizontalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                if kvp.Key = Xaml._VerticalOptionsAttribKey.KeyValue then 
                    prevVerticalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                if kvp.Key = Xaml._MarginAttribKey.KeyValue then 
                    prevMarginOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                if kvp.Key = Xaml._GestureRecognizersAttribKey.KeyValue then 
                    prevGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevHorizontalOptionsOpt, currHorizontalOptionsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.HorizontalOptions <-  currValue
        | ValueSome _, ValueNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
        | ValueNone, ValueNone -> ()
        match prevVerticalOptionsOpt, currVerticalOptionsOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.VerticalOptions <-  currValue
        | ValueSome _, ValueNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
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
    static member inline View(?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildView(0, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.View>(Xaml._CreateView, Xaml._UpdateView, attribBuilder)

    /// Builds the attributes for a IGestureRecognizer in the view
    static member inline _BuildIGestureRecognizer(attribCount: int) = 

        let attribBuilder = new AttributesBuilder(attribCount)
        attribBuilder

    static member val _ProtoIGestureRecognizer : ViewElement option = None with get, set

    static member val _CreateIGestureRecognizer : (unit -> Xamarin.Forms.IGestureRecognizer) = fun () -> 
        failwith "can't create Xamarin.Forms.IGestureRecognizer"

    static member val _UpdateIGestureRecognizer = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.IGestureRecognizer) -> 
        ignore prevOpt
        ignore curr
        ignore target

    /// Describes a IGestureRecognizer in the view
    static member inline IGestureRecognizer() = 

        let attribBuilder = Xaml._BuildIGestureRecognizer(0)

        ViewElement.Create<Xamarin.Forms.IGestureRecognizer>(Xaml._CreateIGestureRecognizer, Xaml._UpdateIGestureRecognizer, attribBuilder)

    /// Builds the attributes for a PanGestureRecognizer in the view
    static member inline _BuildPanGestureRecognizer(attribCount: int, ?touchPoints: int, ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 

        let attribCount = match touchPoints with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match panUpdated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match touchPoints with None -> () | Some v -> attribBuilder.Add(Xaml._TouchPointsAttribKey, (v)) 
        match panUpdated with None -> () | Some v -> attribBuilder.Add(Xaml._PanUpdatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoPanGestureRecognizer : ViewElement option = None with get, set

    static member val _CreatePanGestureRecognizer : (unit -> Xamarin.Forms.PanGestureRecognizer) = fun () -> 
            upcast (new Xamarin.Forms.PanGestureRecognizer())

    static member val _UpdatePanGestureRecognizer = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.PanGestureRecognizer) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevTouchPointsOpt = ValueNone
        let mutable currTouchPointsOpt = ValueNone
        let mutable prevPanUpdatedOpt = ValueNone
        let mutable currPanUpdatedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._TouchPointsAttribKey.KeyValue then 
                currTouchPointsOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._PanUpdatedAttribKey.KeyValue then 
                currPanUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TouchPointsAttribKey.KeyValue then 
                    prevTouchPointsOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._PanUpdatedAttribKey.KeyValue then 
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
    static member inline PanGestureRecognizer(?touchPoints: int, ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildPanGestureRecognizer(0, ?touchPoints=touchPoints, ?panUpdated=panUpdated, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.PanGestureRecognizer>(Xaml._CreatePanGestureRecognizer, Xaml._UpdatePanGestureRecognizer, attribBuilder)

    /// Builds the attributes for a TapGestureRecognizer in the view
    static member inline _BuildTapGestureRecognizer(attribCount: int, ?command: unit -> unit, ?numberOfTapsRequired: int, ?classId: string, ?styleId: string) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match numberOfTapsRequired with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match command with None -> () | Some v -> attribBuilder.Add(Xaml._CommandAttribKey, makeCommand(v)) 
        match numberOfTapsRequired with None -> () | Some v -> attribBuilder.Add(Xaml._NumberOfTapsRequiredAttribKey, (v)) 
        attribBuilder

    static member val _ProtoTapGestureRecognizer : ViewElement option = None with get, set

    static member val _CreateTapGestureRecognizer : (unit -> Xamarin.Forms.TapGestureRecognizer) = fun () -> 
            upcast (new Xamarin.Forms.TapGestureRecognizer())

    static member val _UpdateTapGestureRecognizer = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TapGestureRecognizer) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevCommandOpt = ValueNone
        let mutable currCommandOpt = ValueNone
        let mutable prevNumberOfTapsRequiredOpt = ValueNone
        let mutable currNumberOfTapsRequiredOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._CommandAttribKey.KeyValue then 
                currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = Xaml._NumberOfTapsRequiredAttribKey.KeyValue then 
                currNumberOfTapsRequiredOpt <- ValueSome (kvp.Value :?> int)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._CommandAttribKey.KeyValue then 
                    prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml._NumberOfTapsRequiredAttribKey.KeyValue then 
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
    static member inline TapGestureRecognizer(?command: unit -> unit, ?numberOfTapsRequired: int, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildTapGestureRecognizer(0, ?command=command, ?numberOfTapsRequired=numberOfTapsRequired, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.TapGestureRecognizer>(Xaml._CreateTapGestureRecognizer, Xaml._UpdateTapGestureRecognizer, attribBuilder)

    /// Builds the attributes for a ClickGestureRecognizer in the view
    static member inline _BuildClickGestureRecognizer(attribCount: int, ?command: unit -> unit, ?numberOfClicksRequired: int, ?buttons: Xamarin.Forms.ButtonsMask, ?classId: string, ?styleId: string) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match numberOfClicksRequired with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match buttons with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match command with None -> () | Some v -> attribBuilder.Add(Xaml._CommandAttribKey, makeCommand(v)) 
        match numberOfClicksRequired with None -> () | Some v -> attribBuilder.Add(Xaml._NumberOfClicksRequiredAttribKey, (v)) 
        match buttons with None -> () | Some v -> attribBuilder.Add(Xaml._ButtonsAttribKey, (v)) 
        attribBuilder

    static member val _ProtoClickGestureRecognizer : ViewElement option = None with get, set

    static member val _CreateClickGestureRecognizer : (unit -> Xamarin.Forms.ClickGestureRecognizer) = fun () -> 
            upcast (new Xamarin.Forms.ClickGestureRecognizer())

    static member val _UpdateClickGestureRecognizer = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ClickGestureRecognizer) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevCommandOpt = ValueNone
        let mutable currCommandOpt = ValueNone
        let mutable prevNumberOfClicksRequiredOpt = ValueNone
        let mutable currNumberOfClicksRequiredOpt = ValueNone
        let mutable prevButtonsOpt = ValueNone
        let mutable currButtonsOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._CommandAttribKey.KeyValue then 
                currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = Xaml._NumberOfClicksRequiredAttribKey.KeyValue then 
                currNumberOfClicksRequiredOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._ButtonsAttribKey.KeyValue then 
                currButtonsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ButtonsMask)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._CommandAttribKey.KeyValue then 
                    prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml._NumberOfClicksRequiredAttribKey.KeyValue then 
                    prevNumberOfClicksRequiredOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._ButtonsAttribKey.KeyValue then 
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
    static member inline ClickGestureRecognizer(?command: unit -> unit, ?numberOfClicksRequired: int, ?buttons: Xamarin.Forms.ButtonsMask, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildClickGestureRecognizer(0, ?command=command, ?numberOfClicksRequired=numberOfClicksRequired, ?buttons=buttons, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ClickGestureRecognizer>(Xaml._CreateClickGestureRecognizer, Xaml._UpdateClickGestureRecognizer, attribBuilder)

    /// Builds the attributes for a PinchGestureRecognizer in the view
    static member inline _BuildPinchGestureRecognizer(attribCount: int, ?isPinching: bool, ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 

        let attribCount = match isPinching with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match pinchUpdated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match isPinching with None -> () | Some v -> attribBuilder.Add(Xaml._IsPinchingAttribKey, (v)) 
        match pinchUpdated with None -> () | Some v -> attribBuilder.Add(Xaml._PinchUpdatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoPinchGestureRecognizer : ViewElement option = None with get, set

    static member val _CreatePinchGestureRecognizer : (unit -> Xamarin.Forms.PinchGestureRecognizer) = fun () -> 
            upcast (new Xamarin.Forms.PinchGestureRecognizer())

    static member val _UpdatePinchGestureRecognizer = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.PinchGestureRecognizer) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevIsPinchingOpt = ValueNone
        let mutable currIsPinchingOpt = ValueNone
        let mutable prevPinchUpdatedOpt = ValueNone
        let mutable currPinchUpdatedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._IsPinchingAttribKey.KeyValue then 
                currIsPinchingOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._PinchUpdatedAttribKey.KeyValue then 
                currPinchUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._IsPinchingAttribKey.KeyValue then 
                    prevIsPinchingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._PinchUpdatedAttribKey.KeyValue then 
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
    static member inline PinchGestureRecognizer(?isPinching: bool, ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildPinchGestureRecognizer(0, ?isPinching=isPinching, ?pinchUpdated=pinchUpdated, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.PinchGestureRecognizer>(Xaml._CreatePinchGestureRecognizer, Xaml._UpdatePinchGestureRecognizer, attribBuilder)

    /// Builds the attributes for a ActivityIndicator in the view
    static member inline _BuildActivityIndicator(attribCount: int, ?color: Xamarin.Forms.Color, ?isRunning: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isRunning with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match color with None -> () | Some v -> attribBuilder.Add(Xaml._ColorAttribKey, (v)) 
        match isRunning with None -> () | Some v -> attribBuilder.Add(Xaml._IsRunningAttribKey, (v)) 
        attribBuilder

    static member val _ProtoActivityIndicator : ViewElement option = None with get, set

    static member val _CreateActivityIndicator : (unit -> Xamarin.Forms.ActivityIndicator) = fun () -> 
            upcast (new Xamarin.Forms.ActivityIndicator())

    static member val _UpdateActivityIndicator = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ActivityIndicator) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevColorOpt = ValueNone
        let mutable currColorOpt = ValueNone
        let mutable prevIsRunningOpt = ValueNone
        let mutable currIsRunningOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ColorAttribKey.KeyValue then 
                currColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._IsRunningAttribKey.KeyValue then 
                currIsRunningOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ColorAttribKey.KeyValue then 
                    prevColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._IsRunningAttribKey.KeyValue then 
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
    static member inline ActivityIndicator(?color: Xamarin.Forms.Color, ?isRunning: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildActivityIndicator(0, ?color=color, ?isRunning=isRunning, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ActivityIndicator>(Xaml._CreateActivityIndicator, Xaml._UpdateActivityIndicator, attribBuilder)

    /// Builds the attributes for a BoxView in the view
    static member inline _BuildBoxView(attribCount: int, ?color: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match color with None -> () | Some v -> attribBuilder.Add(Xaml._ColorAttribKey, (v)) 
        attribBuilder

    static member val _ProtoBoxView : ViewElement option = None with get, set

    static member val _CreateBoxView : (unit -> Xamarin.Forms.BoxView) = fun () -> 
            upcast (new Xamarin.Forms.BoxView())

    static member val _UpdateBoxView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.BoxView) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevColorOpt = ValueNone
        let mutable currColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ColorAttribKey.KeyValue then 
                currColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ColorAttribKey.KeyValue then 
                    prevColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevColorOpt, currColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Color <-  currValue
        | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()

    /// Describes a BoxView in the view
    static member inline BoxView(?color: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildBoxView(0, ?color=color, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.BoxView>(Xaml._CreateBoxView, Xaml._UpdateBoxView, attribBuilder)

    /// Builds the attributes for a ProgressBar in the view
    static member inline _BuildProgressBar(attribCount: int, ?progress: double, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match progress with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match progress with None -> () | Some v -> attribBuilder.Add(Xaml._ProgressAttribKey, (v)) 
        attribBuilder

    static member val _ProtoProgressBar : ViewElement option = None with get, set

    static member val _CreateProgressBar : (unit -> Xamarin.Forms.ProgressBar) = fun () -> 
            upcast (new Xamarin.Forms.ProgressBar())

    static member val _UpdateProgressBar = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ProgressBar) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevProgressOpt = ValueNone
        let mutable currProgressOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ProgressAttribKey.KeyValue then 
                currProgressOpt <- ValueSome (kvp.Value :?> double)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ProgressAttribKey.KeyValue then 
                    prevProgressOpt <- ValueSome (kvp.Value :?> double)
        match prevProgressOpt, currProgressOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Progress <-  currValue
        | ValueSome _, ValueNone -> target.Progress <- 0.0
        | ValueNone, ValueNone -> ()

    /// Describes a ProgressBar in the view
    static member inline ProgressBar(?progress: double, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildProgressBar(0, ?progress=progress, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ProgressBar>(Xaml._CreateProgressBar, Xaml._UpdateProgressBar, attribBuilder)

    /// Builds the attributes for a Layout in the view
    static member inline _BuildLayout(attribCount: int, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match isClippedToBounds with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match isClippedToBounds with None -> () | Some v -> attribBuilder.Add(Xaml._IsClippedToBoundsAttribKey, (v)) 
        match padding with None -> () | Some v -> attribBuilder.Add(Xaml._PaddingAttribKey, makeThickness(v)) 
        attribBuilder

    static member val _ProtoLayout : ViewElement option = None with get, set

    static member val _CreateLayout : (unit -> Xamarin.Forms.Layout) = fun () -> 
        failwith "can't create Xamarin.Forms.Layout"

    static member val _UpdateLayout = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Layout) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevIsClippedToBoundsOpt = ValueNone
        let mutable currIsClippedToBoundsOpt = ValueNone
        let mutable prevPaddingOpt = ValueNone
        let mutable currPaddingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._IsClippedToBoundsAttribKey.KeyValue then 
                currIsClippedToBoundsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._PaddingAttribKey.KeyValue then 
                currPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._IsClippedToBoundsAttribKey.KeyValue then 
                    prevIsClippedToBoundsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._PaddingAttribKey.KeyValue then 
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
    static member inline Layout(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildLayout(0, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Layout>(Xaml._CreateLayout, Xaml._UpdateLayout, attribBuilder)

    /// Builds the attributes for a ScrollView in the view
    static member inline _BuildScrollView(attribCount: int, ?content: ViewElement, ?orientation: Xamarin.Forms.ScrollOrientation, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match orientation with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match content with None -> () | Some v -> attribBuilder.Add(Xaml._ContentAttribKey, (v)) 
        match orientation with None -> () | Some v -> attribBuilder.Add(Xaml._ScrollOrientationAttribKey, (v)) 
        attribBuilder

    static member val _ProtoScrollView : ViewElement option = None with get, set

    static member val _CreateScrollView : (unit -> Xamarin.Forms.ScrollView) = fun () -> 
            upcast (new Xamarin.Forms.ScrollView())

    static member val _UpdateScrollView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ScrollView) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevContentOpt = ValueNone
        let mutable currContentOpt = ValueNone
        let mutable prevScrollOrientationOpt = ValueNone
        let mutable currScrollOrientationOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ContentAttribKey.KeyValue then 
                currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = Xaml._ScrollOrientationAttribKey.KeyValue then 
                currScrollOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollOrientation)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ContentAttribKey.KeyValue then 
                    prevContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml._ScrollOrientationAttribKey.KeyValue then 
                    prevScrollOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollOrientation)
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

    /// Describes a ScrollView in the view
    static member inline ScrollView(?content: ViewElement, ?orientation: Xamarin.Forms.ScrollOrientation, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildScrollView(0, ?content=content, ?orientation=orientation, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ScrollView>(Xaml._CreateScrollView, Xaml._UpdateScrollView, attribBuilder)

    /// Builds the attributes for a SearchBar in the view
    static member inline _BuildSearchBar(attribCount: int, ?cancelButtonColor: Xamarin.Forms.Color, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?placeholder: string, ?placeholderColor: Xamarin.Forms.Color, ?searchCommand: string -> unit, ?canExecute: bool, ?text: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

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

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match cancelButtonColor with None -> () | Some v -> attribBuilder.Add(Xaml._CancelButtonColorAttribKey, (v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(Xaml._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(Xaml._FontAttributesAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(Xaml._FontSizeAttribKey, makeFontSize(v)) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.Add(Xaml._HorizontalTextAlignmentAttribKey, (v)) 
        match placeholder with None -> () | Some v -> attribBuilder.Add(Xaml._PlaceholderAttribKey, (v)) 
        match placeholderColor with None -> () | Some v -> attribBuilder.Add(Xaml._PlaceholderColorAttribKey, (v)) 
        match searchCommand with None -> () | Some v -> attribBuilder.Add(Xaml._SearchBarCommandAttribKey, (v)) 
        match canExecute with None -> () | Some v -> attribBuilder.Add(Xaml._SearchBarCanExecuteAttribKey, (v)) 
        match text with None -> () | Some v -> attribBuilder.Add(Xaml._TextAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(Xaml._TextColorAttribKey, (v)) 
        attribBuilder

    static member val _ProtoSearchBar : ViewElement option = None with get, set

    static member val _CreateSearchBar : (unit -> Xamarin.Forms.SearchBar) = fun () -> 
            upcast (new Xamarin.Forms.SearchBar())

    static member val _UpdateSearchBar = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.SearchBar) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._CancelButtonColorAttribKey.KeyValue then 
                currCancelButtonColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._HorizontalTextAlignmentAttribKey.KeyValue then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = Xaml._PlaceholderAttribKey.KeyValue then 
                currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._PlaceholderColorAttribKey.KeyValue then 
                currPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._SearchBarCommandAttribKey.KeyValue then 
                currSearchBarCommandOpt <- ValueSome (kvp.Value :?> string -> unit)
            if kvp.Key = Xaml._SearchBarCanExecuteAttribKey.KeyValue then 
                currSearchBarCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._CancelButtonColorAttribKey.KeyValue then 
                    prevCancelButtonColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._HorizontalTextAlignmentAttribKey.KeyValue then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml._PlaceholderAttribKey.KeyValue then 
                    prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._PlaceholderColorAttribKey.KeyValue then 
                    prevPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._SearchBarCommandAttribKey.KeyValue then 
                    prevSearchBarCommandOpt <- ValueSome (kvp.Value :?> string -> unit)
                if kvp.Key = Xaml._SearchBarCanExecuteAttribKey.KeyValue then 
                    prevSearchBarCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
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

    /// Describes a SearchBar in the view
    static member inline SearchBar(?cancelButtonColor: Xamarin.Forms.Color, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?placeholder: string, ?placeholderColor: Xamarin.Forms.Color, ?searchCommand: string -> unit, ?canExecute: bool, ?text: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildSearchBar(0, ?cancelButtonColor=cancelButtonColor, ?fontFamily=fontFamily, ?fontAttributes=fontAttributes, ?fontSize=fontSize, ?horizontalTextAlignment=horizontalTextAlignment, ?placeholder=placeholder, ?placeholderColor=placeholderColor, ?searchCommand=searchCommand, ?canExecute=canExecute, ?text=text, ?textColor=textColor, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.SearchBar>(Xaml._CreateSearchBar, Xaml._UpdateSearchBar, attribBuilder)

    /// Builds the attributes for a Button in the view
    static member inline _BuildButton(attribCount: int, ?text: string, ?command: unit -> unit, ?canExecute: bool, ?borderColor: Xamarin.Forms.Color, ?borderWidth: double, ?commandParameter: System.Object, ?contentLayout: Xamarin.Forms.Button.ButtonContentLayout, ?cornerRadius: int, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?image: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

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

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match text with None -> () | Some v -> attribBuilder.Add(Xaml._TextAttribKey, (v)) 
        match command with None -> () | Some v -> attribBuilder.Add(Xaml._ButtonCommandAttribKey, (v)) 
        match canExecute with None -> () | Some v -> attribBuilder.Add(Xaml._ButtonCanExecuteAttribKey, (v)) 
        match borderColor with None -> () | Some v -> attribBuilder.Add(Xaml._BorderColorAttribKey, (v)) 
        match borderWidth with None -> () | Some v -> attribBuilder.Add(Xaml._BorderWidthAttribKey, (v)) 
        match commandParameter with None -> () | Some v -> attribBuilder.Add(Xaml._CommandParameterAttribKey, (v)) 
        match contentLayout with None -> () | Some v -> attribBuilder.Add(Xaml._ContentLayoutAttribKey, (v)) 
        match cornerRadius with None -> () | Some v -> attribBuilder.Add(Xaml._ButtonCornerRadiusAttribKey, (v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(Xaml._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(Xaml._FontAttributesAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(Xaml._FontSizeAttribKey, makeFontSize(v)) 
        match image with None -> () | Some v -> attribBuilder.Add(Xaml._ButtonImageSourceAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(Xaml._TextColorAttribKey, (v)) 
        attribBuilder

    static member val _ProtoButton : ViewElement option = None with get, set

    static member val _CreateButton : (unit -> Xamarin.Forms.Button) = fun () -> 
            upcast (new Xamarin.Forms.Button())

    static member val _UpdateButton = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Button) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._ButtonCommandAttribKey.KeyValue then 
                currButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
            if kvp.Key = Xaml._ButtonCanExecuteAttribKey.KeyValue then 
                currButtonCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._BorderColorAttribKey.KeyValue then 
                currBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._BorderWidthAttribKey.KeyValue then 
                currBorderWidthOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._CommandParameterAttribKey.KeyValue then 
                currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._ContentLayoutAttribKey.KeyValue then 
                currContentLayoutOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Button.ButtonContentLayout)
            if kvp.Key = Xaml._ButtonCornerRadiusAttribKey.KeyValue then 
                currButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ButtonImageSourceAttribKey.KeyValue then 
                currButtonImageSourceOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._ButtonCommandAttribKey.KeyValue then 
                    prevButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = Xaml._ButtonCanExecuteAttribKey.KeyValue then 
                    prevButtonCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._BorderColorAttribKey.KeyValue then 
                    prevBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._BorderWidthAttribKey.KeyValue then 
                    prevBorderWidthOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._CommandParameterAttribKey.KeyValue then 
                    prevCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._ContentLayoutAttribKey.KeyValue then 
                    prevContentLayoutOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Button.ButtonContentLayout)
                if kvp.Key = Xaml._ButtonCornerRadiusAttribKey.KeyValue then 
                    prevButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ButtonImageSourceAttribKey.KeyValue then 
                    prevButtonImageSourceOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
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
        | _, ValueSome currValue -> target.Image <- makeFileImageSource  currValue
        | ValueSome _, ValueNone -> target.Image <- null
        | ValueNone, ValueNone -> ()
        match prevTextColorOpt, currTextColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.TextColor <-  currValue
        | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()

    /// Describes a Button in the view
    static member inline Button(?text: string, ?command: unit -> unit, ?canExecute: bool, ?borderColor: Xamarin.Forms.Color, ?borderWidth: double, ?commandParameter: System.Object, ?contentLayout: Xamarin.Forms.Button.ButtonContentLayout, ?cornerRadius: int, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?image: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildButton(0, ?text=text, ?command=command, ?canExecute=canExecute, ?borderColor=borderColor, ?borderWidth=borderWidth, ?commandParameter=commandParameter, ?contentLayout=contentLayout, ?cornerRadius=cornerRadius, ?fontFamily=fontFamily, ?fontAttributes=fontAttributes, ?fontSize=fontSize, ?image=image, ?textColor=textColor, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Button>(Xaml._CreateButton, Xaml._UpdateButton, attribBuilder)

    /// Builds the attributes for a Slider in the view
    static member inline _BuildSlider(attribCount: int, ?minimum: double, ?maximum: double, ?value: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match minimum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match maximum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match value with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match valueChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match minimum with None -> () | Some v -> attribBuilder.Add(Xaml._MinimumAttribKey, (v)) 
        match maximum with None -> () | Some v -> attribBuilder.Add(Xaml._MaximumAttribKey, (v)) 
        match value with None -> () | Some v -> attribBuilder.Add(Xaml._ValueAttribKey, (v)) 
        match valueChanged with None -> () | Some v -> attribBuilder.Add(Xaml._ValueChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoSlider : ViewElement option = None with get, set

    static member val _CreateSlider : (unit -> Xamarin.Forms.Slider) = fun () -> 
            upcast (new Xamarin.Forms.Slider())

    static member val _UpdateSlider = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Slider) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevMinimumOpt = ValueNone
        let mutable currMinimumOpt = ValueNone
        let mutable prevMaximumOpt = ValueNone
        let mutable currMaximumOpt = ValueNone
        let mutable prevValueOpt = ValueNone
        let mutable currValueOpt = ValueNone
        let mutable prevValueChangedOpt = ValueNone
        let mutable currValueChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._MinimumAttribKey.KeyValue then 
                currMinimumOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._MaximumAttribKey.KeyValue then 
                currMaximumOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ValueAttribKey.KeyValue then 
                currValueOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ValueChangedAttribKey.KeyValue then 
                currValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._MinimumAttribKey.KeyValue then 
                    prevMinimumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._MaximumAttribKey.KeyValue then 
                    prevMaximumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ValueAttribKey.KeyValue then 
                    prevValueOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ValueChangedAttribKey.KeyValue then 
                    prevValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
        match prevMinimumOpt, currMinimumOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Minimum <-  currValue
        | ValueSome _, ValueNone -> target.Minimum <- 0.0
        | ValueNone, ValueNone -> ()
        match prevMaximumOpt, currMaximumOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Maximum <-  currValue
        | ValueSome _, ValueNone -> target.Maximum <- 1.0
        | ValueNone, ValueNone -> ()
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
    static member inline Slider(?minimum: double, ?maximum: double, ?value: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildSlider(0, ?minimum=minimum, ?maximum=maximum, ?value=value, ?valueChanged=valueChanged, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Slider>(Xaml._CreateSlider, Xaml._UpdateSlider, attribBuilder)

    /// Builds the attributes for a Stepper in the view
    static member inline _BuildStepper(attribCount: int, ?minimum: double, ?maximum: double, ?value: double, ?increment: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match minimum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match maximum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match value with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match increment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match valueChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match minimum with None -> () | Some v -> attribBuilder.Add(Xaml._MinimumAttribKey, (v)) 
        match maximum with None -> () | Some v -> attribBuilder.Add(Xaml._MaximumAttribKey, (v)) 
        match value with None -> () | Some v -> attribBuilder.Add(Xaml._ValueAttribKey, (v)) 
        match increment with None -> () | Some v -> attribBuilder.Add(Xaml._IncrementAttribKey, (v)) 
        match valueChanged with None -> () | Some v -> attribBuilder.Add(Xaml._ValueChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoStepper : ViewElement option = None with get, set

    static member val _CreateStepper : (unit -> Xamarin.Forms.Stepper) = fun () -> 
            upcast (new Xamarin.Forms.Stepper())

    static member val _UpdateStepper = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Stepper) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevMinimumOpt = ValueNone
        let mutable currMinimumOpt = ValueNone
        let mutable prevMaximumOpt = ValueNone
        let mutable currMaximumOpt = ValueNone
        let mutable prevValueOpt = ValueNone
        let mutable currValueOpt = ValueNone
        let mutable prevIncrementOpt = ValueNone
        let mutable currIncrementOpt = ValueNone
        let mutable prevValueChangedOpt = ValueNone
        let mutable currValueChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._MinimumAttribKey.KeyValue then 
                currMinimumOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._MaximumAttribKey.KeyValue then 
                currMaximumOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ValueAttribKey.KeyValue then 
                currValueOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._IncrementAttribKey.KeyValue then 
                currIncrementOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ValueChangedAttribKey.KeyValue then 
                currValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._MinimumAttribKey.KeyValue then 
                    prevMinimumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._MaximumAttribKey.KeyValue then 
                    prevMaximumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ValueAttribKey.KeyValue then 
                    prevValueOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._IncrementAttribKey.KeyValue then 
                    prevIncrementOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ValueChangedAttribKey.KeyValue then 
                    prevValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
        match prevMinimumOpt, currMinimumOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Minimum <-  currValue
        | ValueSome _, ValueNone -> target.Minimum <- 0.0
        | ValueNone, ValueNone -> ()
        match prevMaximumOpt, currMaximumOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Maximum <-  currValue
        | ValueSome _, ValueNone -> target.Maximum <- 1.0
        | ValueNone, ValueNone -> ()
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
    static member inline Stepper(?minimum: double, ?maximum: double, ?value: double, ?increment: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildStepper(0, ?minimum=minimum, ?maximum=maximum, ?value=value, ?increment=increment, ?valueChanged=valueChanged, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Stepper>(Xaml._CreateStepper, Xaml._UpdateStepper, attribBuilder)

    /// Builds the attributes for a Switch in the view
    static member inline _BuildSwitch(attribCount: int, ?isToggled: bool, ?toggled: Xamarin.Forms.ToggledEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match isToggled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match toggled with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match isToggled with None -> () | Some v -> attribBuilder.Add(Xaml._IsToggledAttribKey, (v)) 
        match toggled with None -> () | Some v -> attribBuilder.Add(Xaml._ToggledAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoSwitch : ViewElement option = None with get, set

    static member val _CreateSwitch : (unit -> Xamarin.Forms.Switch) = fun () -> 
            upcast (new Xamarin.Forms.Switch())

    static member val _UpdateSwitch = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Switch) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevIsToggledOpt = ValueNone
        let mutable currIsToggledOpt = ValueNone
        let mutable prevToggledOpt = ValueNone
        let mutable currToggledOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._IsToggledAttribKey.KeyValue then 
                currIsToggledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._ToggledAttribKey.KeyValue then 
                currToggledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._IsToggledAttribKey.KeyValue then 
                    prevIsToggledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._ToggledAttribKey.KeyValue then 
                    prevToggledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
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

    /// Describes a Switch in the view
    static member inline Switch(?isToggled: bool, ?toggled: Xamarin.Forms.ToggledEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildSwitch(0, ?isToggled=isToggled, ?toggled=toggled, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Switch>(Xaml._CreateSwitch, Xaml._UpdateSwitch, attribBuilder)

    /// Builds the attributes for a Cell in the view
    static member inline _BuildCell(attribCount: int, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match height with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isEnabled with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match height with None -> () | Some v -> attribBuilder.Add(Xaml._HeightAttribKey, (v)) 
        match isEnabled with None -> () | Some v -> attribBuilder.Add(Xaml._IsEnabledAttribKey, (v)) 
        attribBuilder

    static member val _ProtoCell : ViewElement option = None with get, set

    static member val _CreateCell : (unit -> Xamarin.Forms.Cell) = fun () -> 
        failwith "can't create Xamarin.Forms.Cell"

    static member val _UpdateCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Cell) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevHeightOpt = ValueNone
        let mutable currHeightOpt = ValueNone
        let mutable prevIsEnabledOpt = ValueNone
        let mutable currIsEnabledOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._HeightAttribKey.KeyValue then 
                currHeightOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._IsEnabledAttribKey.KeyValue then 
                currIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._HeightAttribKey.KeyValue then 
                    prevHeightOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._IsEnabledAttribKey.KeyValue then 
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
    static member inline Cell(?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildCell(0, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Cell>(Xaml._CreateCell, Xaml._UpdateCell, attribBuilder)

    /// Builds the attributes for a SwitchCell in the view
    static member inline _BuildSwitchCell(attribCount: int, ?on: bool, ?text: string, ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match on with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match onChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        match on with None -> () | Some v -> attribBuilder.Add(Xaml._OnAttribKey, (v)) 
        match text with None -> () | Some v -> attribBuilder.Add(Xaml._TextAttribKey, (v)) 
        match onChanged with None -> () | Some v -> attribBuilder.Add(Xaml._OnChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoSwitchCell : ViewElement option = None with get, set

    static member val _CreateSwitchCell : (unit -> Xamarin.Forms.SwitchCell) = fun () -> 
            upcast (new Xamarin.Forms.SwitchCell())

    static member val _UpdateSwitchCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.SwitchCell) -> 
        let baseElement = (if Xaml._ProtoCell.IsNone then Xaml._ProtoCell <- Some (Xaml.Cell())); Xaml._ProtoCell.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevOnOpt = ValueNone
        let mutable currOnOpt = ValueNone
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevOnChangedOpt = ValueNone
        let mutable currOnChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._OnAttribKey.KeyValue then 
                currOnOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._OnChangedAttribKey.KeyValue then 
                currOnChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._OnAttribKey.KeyValue then 
                    prevOnOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._OnChangedAttribKey.KeyValue then 
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
    static member inline SwitchCell(?on: bool, ?text: string, ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildSwitchCell(0, ?on=on, ?text=text, ?onChanged=onChanged, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.SwitchCell>(Xaml._CreateSwitchCell, Xaml._UpdateSwitchCell, attribBuilder)

    /// Builds the attributes for a TableView in the view
    static member inline _BuildTableView(attribCount: int, ?intent: Xamarin.Forms.TableIntent, ?hasUnevenRows: bool, ?rowHeight: int, ?items: (string * ViewElement list) list, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match intent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasUnevenRows with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rowHeight with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match items with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match intent with None -> () | Some v -> attribBuilder.Add(Xaml._IntentAttribKey, (v)) 
        match hasUnevenRows with None -> () | Some v -> attribBuilder.Add(Xaml._HasUnevenRowsAttribKey, (v)) 
        match rowHeight with None -> () | Some v -> attribBuilder.Add(Xaml._RowHeightAttribKey, (v)) 
        match items with None -> () | Some v -> attribBuilder.Add(Xaml._TableRootAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(v)) 
        attribBuilder

    static member val _ProtoTableView : ViewElement option = None with get, set

    static member val _CreateTableView : (unit -> Xamarin.Forms.TableView) = fun () -> 
            upcast (new Xamarin.Forms.TableView())

    static member val _UpdateTableView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TableView) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevIntentOpt = ValueNone
        let mutable currIntentOpt = ValueNone
        let mutable prevHasUnevenRowsOpt = ValueNone
        let mutable currHasUnevenRowsOpt = ValueNone
        let mutable prevRowHeightOpt = ValueNone
        let mutable currRowHeightOpt = ValueNone
        let mutable prevTableRootOpt = ValueNone
        let mutable currTableRootOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._IntentAttribKey.KeyValue then 
                currIntentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TableIntent)
            if kvp.Key = Xaml._HasUnevenRowsAttribKey.KeyValue then 
                currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._RowHeightAttribKey.KeyValue then 
                currRowHeightOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._TableRootAttribKey.KeyValue then 
                currTableRootOpt <- ValueSome (kvp.Value :?> (string * ViewElement[])[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._IntentAttribKey.KeyValue then 
                    prevIntentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TableIntent)
                if kvp.Key = Xaml._HasUnevenRowsAttribKey.KeyValue then 
                    prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._RowHeightAttribKey.KeyValue then 
                    prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._TableRootAttribKey.KeyValue then 
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
    static member inline TableView(?intent: Xamarin.Forms.TableIntent, ?hasUnevenRows: bool, ?rowHeight: int, ?items: (string * ViewElement list) list, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildTableView(0, ?intent=intent, ?hasUnevenRows=hasUnevenRows, ?rowHeight=rowHeight, ?items=items, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.TableView>(Xaml._CreateTableView, Xaml._UpdateTableView, attribBuilder)

    /// Builds the attributes for a RowDefinition in the view
    static member inline _BuildRowDefinition(attribCount: int, ?height: obj) = 

        let attribCount = match height with Some _ -> attribCount + 1 | None -> attribCount
        let attribBuilder = new AttributesBuilder(attribCount)
        match height with None -> () | Some v -> attribBuilder.Add(Xaml._RowDefinitionHeightAttribKey, makeGridLength(v)) 
        attribBuilder

    static member val _ProtoRowDefinition : ViewElement option = None with get, set

    static member val _CreateRowDefinition : (unit -> Xamarin.Forms.RowDefinition) = fun () -> 
            upcast (new Xamarin.Forms.RowDefinition())

    static member val _UpdateRowDefinition = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.RowDefinition) -> 
        let mutable prevRowDefinitionHeightOpt = ValueNone
        let mutable currRowDefinitionHeightOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._RowDefinitionHeightAttribKey.KeyValue then 
                currRowDefinitionHeightOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._RowDefinitionHeightAttribKey.KeyValue then 
                    prevRowDefinitionHeightOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevRowDefinitionHeightOpt, currRowDefinitionHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Height <-  currValue
        | ValueSome _, ValueNone -> target.Height <- Xamarin.Forms.GridLength.Auto
        | ValueNone, ValueNone -> ()

    /// Describes a RowDefinition in the view
    static member inline RowDefinition(?height: obj) = 

        let attribBuilder = Xaml._BuildRowDefinition(0, ?height=height)

        ViewElement.Create<Xamarin.Forms.RowDefinition>(Xaml._CreateRowDefinition, Xaml._UpdateRowDefinition, attribBuilder)

    /// Builds the attributes for a ColumnDefinition in the view
    static member inline _BuildColumnDefinition(attribCount: int, ?width: obj) = 

        let attribCount = match width with Some _ -> attribCount + 1 | None -> attribCount
        let attribBuilder = new AttributesBuilder(attribCount)
        match width with None -> () | Some v -> attribBuilder.Add(Xaml._ColumnDefinitionWidthAttribKey, makeGridLength(v)) 
        attribBuilder

    static member val _ProtoColumnDefinition : ViewElement option = None with get, set

    static member val _CreateColumnDefinition : (unit -> Xamarin.Forms.ColumnDefinition) = fun () -> 
            upcast (new Xamarin.Forms.ColumnDefinition())

    static member val _UpdateColumnDefinition = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ColumnDefinition) -> 
        let mutable prevColumnDefinitionWidthOpt = ValueNone
        let mutable currColumnDefinitionWidthOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ColumnDefinitionWidthAttribKey.KeyValue then 
                currColumnDefinitionWidthOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ColumnDefinitionWidthAttribKey.KeyValue then 
                    prevColumnDefinitionWidthOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevColumnDefinitionWidthOpt, currColumnDefinitionWidthOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Width <-  currValue
        | ValueSome _, ValueNone -> target.Width <- Xamarin.Forms.GridLength.Auto
        | ValueNone, ValueNone -> ()

    /// Describes a ColumnDefinition in the view
    static member inline ColumnDefinition(?width: obj) = 

        let attribBuilder = Xaml._BuildColumnDefinition(0, ?width=width)

        ViewElement.Create<Xamarin.Forms.ColumnDefinition>(Xaml._CreateColumnDefinition, Xaml._UpdateColumnDefinition, attribBuilder)

    /// Builds the attributes for a Grid in the view
    static member inline _BuildGrid(attribCount: int, ?rowdefs: obj list, ?coldefs: obj list, ?rowSpacing: double, ?columnSpacing: double, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match rowdefs with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match coldefs with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rowSpacing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match columnSpacing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match rowdefs with None -> () | Some v -> attribBuilder.Add(Xaml._GridRowDefinitionsAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(v)) 
        match coldefs with None -> () | Some v -> attribBuilder.Add(Xaml._GridColumnDefinitionsAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(v)) 
        match rowSpacing with None -> () | Some v -> attribBuilder.Add(Xaml._RowSpacingAttribKey, (v)) 
        match columnSpacing with None -> () | Some v -> attribBuilder.Add(Xaml._ColumnSpacingAttribKey, (v)) 
        match children with None -> () | Some v -> attribBuilder.Add(Xaml._ChildrenAttribKey, Array.ofList(v)) 
        attribBuilder

    static member val _ProtoGrid : ViewElement option = None with get, set

    static member val _CreateGrid : (unit -> Xamarin.Forms.Grid) = fun () -> 
            upcast (new Xamarin.Forms.Grid())

    static member val _UpdateGrid = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Grid) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
            if kvp.Key = Xaml._GridRowDefinitionsAttribKey.KeyValue then 
                currGridRowDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._GridColumnDefinitionsAttribKey.KeyValue then 
                currGridColumnDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._RowSpacingAttribKey.KeyValue then 
                currRowSpacingOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ColumnSpacingAttribKey.KeyValue then 
                currColumnSpacingOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._GridRowDefinitionsAttribKey.KeyValue then 
                    prevGridRowDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._GridColumnDefinitionsAttribKey.KeyValue then 
                    prevGridColumnDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._RowSpacingAttribKey.KeyValue then 
                    prevRowSpacingOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ColumnSpacingAttribKey.KeyValue then 
                    prevColumnSpacingOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
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
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml._GridRowAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml._GridRowAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetRow(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRow(targetChild, 0) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml._GridRowSpanAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml._GridRowSpanAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetRowSpan(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRowSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml._GridColumnAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml._GridColumnAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetColumn(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumn(targetChild, 0) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml._GridColumnSpanAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml._GridColumnSpanAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                ())
            canReuseChild
            updateChild

    /// Describes a Grid in the view
    static member inline Grid(?rowdefs: obj list, ?coldefs: obj list, ?rowSpacing: double, ?columnSpacing: double, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildGrid(0, ?rowdefs=rowdefs, ?coldefs=coldefs, ?rowSpacing=rowSpacing, ?columnSpacing=columnSpacing, ?children=children, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Grid>(Xaml._CreateGrid, Xaml._UpdateGrid, attribBuilder)

    /// Builds the attributes for a AbsoluteLayout in the view
    static member inline _BuildAbsoluteLayout(attribCount: int, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match children with None -> () | Some v -> attribBuilder.Add(Xaml._ChildrenAttribKey, Array.ofList(v)) 
        attribBuilder

    static member val _ProtoAbsoluteLayout : ViewElement option = None with get, set

    static member val _CreateAbsoluteLayout : (unit -> Xamarin.Forms.AbsoluteLayout) = fun () -> 
            upcast (new Xamarin.Forms.AbsoluteLayout())

    static member val _UpdateAbsoluteLayout = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.AbsoluteLayout) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Rectangle>(Xaml._LayoutBoundsAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Rectangle>(Xaml._LayoutBoundsAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, Xamarin.Forms.Rectangle.Zero) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.AbsoluteLayoutFlags>(Xaml._LayoutFlagsAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.AbsoluteLayoutFlags>(Xaml._LayoutFlagsAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, Xamarin.Forms.AbsoluteLayoutFlags.None) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                ())
            canReuseChild
            updateChild

    /// Describes a AbsoluteLayout in the view
    static member inline AbsoluteLayout(?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildAbsoluteLayout(0, ?children=children, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.AbsoluteLayout>(Xaml._CreateAbsoluteLayout, Xaml._UpdateAbsoluteLayout, attribBuilder)

    /// Builds the attributes for a RelativeLayout in the view
    static member inline _BuildRelativeLayout(attribCount: int, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match children with None -> () | Some v -> attribBuilder.Add(Xaml._ChildrenAttribKey, Array.ofList(v)) 
        attribBuilder

    static member val _ProtoRelativeLayout : ViewElement option = None with get, set

    static member val _CreateRelativeLayout : (unit -> Xamarin.Forms.RelativeLayout) = fun () -> 
            upcast (new Xamarin.Forms.RelativeLayout())

    static member val _UpdateRelativeLayout = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.RelativeLayout) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.BoundsConstraint>(Xaml._BoundsConstraintAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.BoundsConstraint>(Xaml._BoundsConstraintAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._HeightConstraintAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._HeightConstraintAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._WidthConstraintAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._WidthConstraintAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._XConstraintAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._XConstraintAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._YConstraintAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._YConstraintAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                ())
            canReuseChild
            updateChild

    /// Describes a RelativeLayout in the view
    static member inline RelativeLayout(?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildRelativeLayout(0, ?children=children, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.RelativeLayout>(Xaml._CreateRelativeLayout, Xaml._UpdateRelativeLayout, attribBuilder)

    /// Builds the attributes for a FlexLayout in the view
    static member inline _BuildFlexLayout(attribCount: int, ?alignContent: Xamarin.Forms.FlexAlignContent, ?alignItems: Xamarin.Forms.FlexAlignItems, ?direction: Xamarin.Forms.FlexDirection, ?position: Xamarin.Forms.FlexPosition, ?wrap: Xamarin.Forms.FlexWrap, ?justifyContent: Xamarin.Forms.FlexJustify, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match alignContent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match alignItems with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match direction with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match position with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match wrap with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match justifyContent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match alignContent with None -> () | Some v -> attribBuilder.Add(Xaml._AlignContentAttribKey, (v)) 
        match alignItems with None -> () | Some v -> attribBuilder.Add(Xaml._AlignItemsAttribKey, (v)) 
        match direction with None -> () | Some v -> attribBuilder.Add(Xaml._DirectionAttribKey, (v)) 
        match position with None -> () | Some v -> attribBuilder.Add(Xaml._PositionAttribKey, (v)) 
        match wrap with None -> () | Some v -> attribBuilder.Add(Xaml._WrapAttribKey, (v)) 
        match justifyContent with None -> () | Some v -> attribBuilder.Add(Xaml._JustifyContentAttribKey, (v)) 
        match children with None -> () | Some v -> attribBuilder.Add(Xaml._ChildrenAttribKey, Array.ofList(v)) 
        attribBuilder

    static member val _ProtoFlexLayout : ViewElement option = None with get, set

    static member val _CreateFlexLayout : (unit -> Xamarin.Forms.FlexLayout) = fun () -> 
            upcast (new Xamarin.Forms.FlexLayout())

    static member val _UpdateFlexLayout = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.FlexLayout) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevAlignContentOpt = ValueNone
        let mutable currAlignContentOpt = ValueNone
        let mutable prevAlignItemsOpt = ValueNone
        let mutable currAlignItemsOpt = ValueNone
        let mutable prevDirectionOpt = ValueNone
        let mutable currDirectionOpt = ValueNone
        let mutable prevPositionOpt = ValueNone
        let mutable currPositionOpt = ValueNone
        let mutable prevWrapOpt = ValueNone
        let mutable currWrapOpt = ValueNone
        let mutable prevJustifyContentOpt = ValueNone
        let mutable currJustifyContentOpt = ValueNone
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._AlignContentAttribKey.KeyValue then 
                currAlignContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignContent)
            if kvp.Key = Xaml._AlignItemsAttribKey.KeyValue then 
                currAlignItemsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignItems)
            if kvp.Key = Xaml._DirectionAttribKey.KeyValue then 
                currDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexDirection)
            if kvp.Key = Xaml._PositionAttribKey.KeyValue then 
                currPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexPosition)
            if kvp.Key = Xaml._WrapAttribKey.KeyValue then 
                currWrapOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexWrap)
            if kvp.Key = Xaml._JustifyContentAttribKey.KeyValue then 
                currJustifyContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexJustify)
            if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._AlignContentAttribKey.KeyValue then 
                    prevAlignContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignContent)
                if kvp.Key = Xaml._AlignItemsAttribKey.KeyValue then 
                    prevAlignItemsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignItems)
                if kvp.Key = Xaml._DirectionAttribKey.KeyValue then 
                    prevDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexDirection)
                if kvp.Key = Xaml._PositionAttribKey.KeyValue then 
                    prevPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexPosition)
                if kvp.Key = Xaml._WrapAttribKey.KeyValue then 
                    prevWrapOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexWrap)
                if kvp.Key = Xaml._JustifyContentAttribKey.KeyValue then 
                    prevJustifyContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexJustify)
                if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
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
        match prevDirectionOpt, currDirectionOpt with
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
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignSelf>(Xaml._FlexAlignSelfAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignSelf>(Xaml._FlexAlignSelfAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetAlignSelf(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetAlignSelf(targetChild, Unchecked.defaultof<Xamarin.Forms.FlexAlignSelf>) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml._FlexOrderAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml._FlexOrderAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetOrder(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetOrder(targetChild, 0) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.FlexBasis>(Xaml._FlexBasisAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.FlexBasis>(Xaml._FlexBasisAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetBasis(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetBasis(targetChild, Unchecked.defaultof<Xamarin.Forms.FlexBasis>) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<single>(Xaml._FlexGrowAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<single>(Xaml._FlexGrowAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetGrow(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetGrow(targetChild, 0.0f) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<single>(Xaml._FlexShrinkAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<single>(Xaml._FlexShrinkAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetShrink(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetShrink(targetChild, 1.0f) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                ())
            canReuseChild
            updateChild

    /// Describes a FlexLayout in the view
    static member inline FlexLayout(?alignContent: Xamarin.Forms.FlexAlignContent, ?alignItems: Xamarin.Forms.FlexAlignItems, ?direction: Xamarin.Forms.FlexDirection, ?position: Xamarin.Forms.FlexPosition, ?wrap: Xamarin.Forms.FlexWrap, ?justifyContent: Xamarin.Forms.FlexJustify, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildFlexLayout(0, ?alignContent=alignContent, ?alignItems=alignItems, ?direction=direction, ?position=position, ?wrap=wrap, ?justifyContent=justifyContent, ?children=children, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.FlexLayout>(Xaml._CreateFlexLayout, Xaml._UpdateFlexLayout, attribBuilder)

    /// Builds the attributes for a TemplatedView in the view
    static member inline _BuildTemplatedView(attribCount: int, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 


        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        attribBuilder

    static member val _ProtoTemplatedView : ViewElement option = None with get, set

    static member val _CreateTemplatedView : (unit -> Xamarin.Forms.TemplatedView) = fun () -> 
            upcast (new Xamarin.Forms.TemplatedView())

    static member val _UpdateTemplatedView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TemplatedView) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        ignore prevOpt
        ignore curr
        ignore target

    /// Describes a TemplatedView in the view
    static member inline TemplatedView(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildTemplatedView(0, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.TemplatedView>(Xaml._CreateTemplatedView, Xaml._UpdateTemplatedView, attribBuilder)

    /// Builds the attributes for a ContentView in the view
    static member inline _BuildContentView(attribCount: int, ?content: ViewElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildTemplatedView(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match content with None -> () | Some v -> attribBuilder.Add(Xaml._ContentAttribKey, (v)) 
        attribBuilder

    static member val _ProtoContentView : ViewElement option = None with get, set

    static member val _CreateContentView : (unit -> Xamarin.Forms.ContentView) = fun () -> 
            upcast (new Xamarin.Forms.ContentView())

    static member val _UpdateContentView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ContentView) -> 
        let baseElement = (if Xaml._ProtoTemplatedView.IsNone then Xaml._ProtoTemplatedView <- Some (Xaml.TemplatedView())); Xaml._ProtoTemplatedView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevContentOpt = ValueNone
        let mutable currContentOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ContentAttribKey.KeyValue then 
                currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ContentAttribKey.KeyValue then 
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
    static member inline ContentView(?content: ViewElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildContentView(0, ?content=content, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ContentView>(Xaml._CreateContentView, Xaml._UpdateContentView, attribBuilder)

    /// Builds the attributes for a DatePicker in the view
    static member inline _BuildDatePicker(attribCount: int, ?date: System.DateTime, ?format: string, ?minimumDate: System.DateTime, ?maximumDate: System.DateTime, ?dateSelected: Xamarin.Forms.DateChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match date with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match format with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match minimumDate with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match maximumDate with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match dateSelected with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match date with None -> () | Some v -> attribBuilder.Add(Xaml._DateAttribKey, (v)) 
        match format with None -> () | Some v -> attribBuilder.Add(Xaml._FormatAttribKey, (v)) 
        match minimumDate with None -> () | Some v -> attribBuilder.Add(Xaml._MinimumDateAttribKey, (v)) 
        match maximumDate with None -> () | Some v -> attribBuilder.Add(Xaml._MaximumDateAttribKey, (v)) 
        match dateSelected with None -> () | Some v -> attribBuilder.Add(Xaml._DateSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoDatePicker : ViewElement option = None with get, set

    static member val _CreateDatePicker : (unit -> Xamarin.Forms.DatePicker) = fun () -> 
            upcast (new Xamarin.Forms.DatePicker())

    static member val _UpdateDatePicker = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.DatePicker) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
            if kvp.Key = Xaml._DateAttribKey.KeyValue then 
                currDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
            if kvp.Key = Xaml._FormatAttribKey.KeyValue then 
                currFormatOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._MinimumDateAttribKey.KeyValue then 
                currMinimumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
            if kvp.Key = Xaml._MaximumDateAttribKey.KeyValue then 
                currMaximumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
            if kvp.Key = Xaml._DateSelectedAttribKey.KeyValue then 
                currDateSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._DateAttribKey.KeyValue then 
                    prevDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = Xaml._FormatAttribKey.KeyValue then 
                    prevFormatOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._MinimumDateAttribKey.KeyValue then 
                    prevMinimumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = Xaml._MaximumDateAttribKey.KeyValue then 
                    prevMaximumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = Xaml._DateSelectedAttribKey.KeyValue then 
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
    static member inline DatePicker(?date: System.DateTime, ?format: string, ?minimumDate: System.DateTime, ?maximumDate: System.DateTime, ?dateSelected: Xamarin.Forms.DateChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildDatePicker(0, ?date=date, ?format=format, ?minimumDate=minimumDate, ?maximumDate=maximumDate, ?dateSelected=dateSelected, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.DatePicker>(Xaml._CreateDatePicker, Xaml._UpdateDatePicker, attribBuilder)

    /// Builds the attributes for a Picker in the view
    static member inline _BuildPicker(attribCount: int, ?itemsSource: seq<'T>, ?selectedIndex: int, ?title: string, ?textColor: Xamarin.Forms.Color, ?selectedIndexChanged: (int * 'T option) -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match itemsSource with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectedIndex with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match title with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectedIndexChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match itemsSource with None -> () | Some v -> attribBuilder.Add(Xaml._PickerItemsSourceAttribKey, seqToIListUntyped(v)) 
        match selectedIndex with None -> () | Some v -> attribBuilder.Add(Xaml._SelectedIndexAttribKey, (v)) 
        match title with None -> () | Some v -> attribBuilder.Add(Xaml._TitleAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(Xaml._TextColorAttribKey, (v)) 
        match selectedIndexChanged with None -> () | Some v -> attribBuilder.Add(Xaml._SelectedIndexChangedAttribKey, (fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(v)) 
        attribBuilder

    static member val _ProtoPicker : ViewElement option = None with get, set

    static member val _CreatePicker : (unit -> Xamarin.Forms.Picker) = fun () -> 
            upcast (new Xamarin.Forms.Picker())

    static member val _UpdatePicker = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Picker) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
            if kvp.Key = Xaml._PickerItemsSourceAttribKey.KeyValue then 
                currPickerItemsSourceOpt <- ValueSome (kvp.Value :?> System.Collections.IList)
            if kvp.Key = Xaml._SelectedIndexAttribKey.KeyValue then 
                currSelectedIndexOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._TitleAttribKey.KeyValue then 
                currTitleOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._SelectedIndexChangedAttribKey.KeyValue then 
                currSelectedIndexChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._PickerItemsSourceAttribKey.KeyValue then 
                    prevPickerItemsSourceOpt <- ValueSome (kvp.Value :?> System.Collections.IList)
                if kvp.Key = Xaml._SelectedIndexAttribKey.KeyValue then 
                    prevSelectedIndexOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._TitleAttribKey.KeyValue then 
                    prevTitleOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._SelectedIndexChangedAttribKey.KeyValue then 
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
    static member inline Picker(?itemsSource: seq<'T>, ?selectedIndex: int, ?title: string, ?textColor: Xamarin.Forms.Color, ?selectedIndexChanged: (int * 'T option) -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildPicker(0, ?itemsSource=itemsSource, ?selectedIndex=selectedIndex, ?title=title, ?textColor=textColor, ?selectedIndexChanged=selectedIndexChanged, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Picker>(Xaml._CreatePicker, Xaml._UpdatePicker, attribBuilder)

    /// Builds the attributes for a Frame in the view
    static member inline _BuildFrame(attribCount: int, ?borderColor: Xamarin.Forms.Color, ?cornerRadius: double, ?hasShadow: bool, ?content: ViewElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match borderColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasShadow with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildContentView(attribCount, ?content=content, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match borderColor with None -> () | Some v -> attribBuilder.Add(Xaml._BorderColorAttribKey, (v)) 
        match cornerRadius with None -> () | Some v -> attribBuilder.Add(Xaml._FrameCornerRadiusAttribKey, single(v)) 
        match hasShadow with None -> () | Some v -> attribBuilder.Add(Xaml._HasShadowAttribKey, (v)) 
        attribBuilder

    static member val _ProtoFrame : ViewElement option = None with get, set

    static member val _CreateFrame : (unit -> Xamarin.Forms.Frame) = fun () -> 
            upcast (new Xamarin.Forms.Frame())

    static member val _UpdateFrame = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Frame) -> 
        let baseElement = (if Xaml._ProtoContentView.IsNone then Xaml._ProtoContentView <- Some (Xaml.ContentView())); Xaml._ProtoContentView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevBorderColorOpt = ValueNone
        let mutable currBorderColorOpt = ValueNone
        let mutable prevFrameCornerRadiusOpt = ValueNone
        let mutable currFrameCornerRadiusOpt = ValueNone
        let mutable prevHasShadowOpt = ValueNone
        let mutable currHasShadowOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._BorderColorAttribKey.KeyValue then 
                currBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._FrameCornerRadiusAttribKey.KeyValue then 
                currFrameCornerRadiusOpt <- ValueSome (kvp.Value :?> single)
            if kvp.Key = Xaml._HasShadowAttribKey.KeyValue then 
                currHasShadowOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._BorderColorAttribKey.KeyValue then 
                    prevBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._FrameCornerRadiusAttribKey.KeyValue then 
                    prevFrameCornerRadiusOpt <- ValueSome (kvp.Value :?> single)
                if kvp.Key = Xaml._HasShadowAttribKey.KeyValue then 
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
    static member inline Frame(?borderColor: Xamarin.Forms.Color, ?cornerRadius: double, ?hasShadow: bool, ?content: ViewElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildFrame(0, ?borderColor=borderColor, ?cornerRadius=cornerRadius, ?hasShadow=hasShadow, ?content=content, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Frame>(Xaml._CreateFrame, Xaml._UpdateFrame, attribBuilder)

    /// Builds the attributes for a Image in the view
    static member inline _BuildImage(attribCount: int, ?source: string, ?aspect: Xamarin.Forms.Aspect, ?isOpaque: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match source with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match aspect with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isOpaque with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match source with None -> () | Some v -> attribBuilder.Add(Xaml._ImageSourceAttribKey, (v)) 
        match aspect with None -> () | Some v -> attribBuilder.Add(Xaml._AspectAttribKey, (v)) 
        match isOpaque with None -> () | Some v -> attribBuilder.Add(Xaml._IsOpaqueAttribKey, (v)) 
        attribBuilder

    static member val _ProtoImage : ViewElement option = None with get, set

    static member val _CreateImage : (unit -> Xamarin.Forms.Image) = fun () -> 
            upcast (new Xamarin.Forms.Image())

    static member val _UpdateImage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Image) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevImageSourceOpt = ValueNone
        let mutable currImageSourceOpt = ValueNone
        let mutable prevAspectOpt = ValueNone
        let mutable currAspectOpt = ValueNone
        let mutable prevIsOpaqueOpt = ValueNone
        let mutable currIsOpaqueOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ImageSourceAttribKey.KeyValue then 
                currImageSourceOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._AspectAttribKey.KeyValue then 
                currAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
            if kvp.Key = Xaml._IsOpaqueAttribKey.KeyValue then 
                currIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ImageSourceAttribKey.KeyValue then 
                    prevImageSourceOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._AspectAttribKey.KeyValue then 
                    prevAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
                if kvp.Key = Xaml._IsOpaqueAttribKey.KeyValue then 
                    prevIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
        match prevImageSourceOpt, currImageSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Source <- makeImageSource  currValue
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
    static member inline Image(?source: string, ?aspect: Xamarin.Forms.Aspect, ?isOpaque: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildImage(0, ?source=source, ?aspect=aspect, ?isOpaque=isOpaque, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Image>(Xaml._CreateImage, Xaml._UpdateImage, attribBuilder)

    /// Builds the attributes for a InputView in the view
    static member inline _BuildInputView(attribCount: int, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match keyboard with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match keyboard with None -> () | Some v -> attribBuilder.Add(Xaml._KeyboardAttribKey, (v)) 
        attribBuilder

    static member val _ProtoInputView : ViewElement option = None with get, set

    static member val _CreateInputView : (unit -> Xamarin.Forms.InputView) = fun () -> 
        failwith "can't create Xamarin.Forms.InputView"

    static member val _UpdateInputView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.InputView) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevKeyboardOpt = ValueNone
        let mutable currKeyboardOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._KeyboardAttribKey.KeyValue then 
                currKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._KeyboardAttribKey.KeyValue then 
                    prevKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
        match prevKeyboardOpt, currKeyboardOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Keyboard <-  currValue
        | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
        | ValueNone, ValueNone -> ()

    /// Describes a InputView in the view
    static member inline InputView(?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildInputView(0, ?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.InputView>(Xaml._CreateInputView, Xaml._UpdateInputView, attribBuilder)

    /// Builds the attributes for a Editor in the view
    static member inline _BuildEditor(attribCount: int, ?text: string, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontAttributes with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match completed with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildInputView(attribCount, ?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match text with None -> () | Some v -> attribBuilder.Add(Xaml._TextAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(Xaml._FontSizeAttribKey, makeFontSize(v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(Xaml._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(Xaml._FontAttributesAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(Xaml._TextColorAttribKey, (v)) 
        match completed with None -> () | Some v -> attribBuilder.Add(Xaml._EditorCompletedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(v)) 
        match textChanged with None -> () | Some v -> attribBuilder.Add(Xaml._TextChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoEditor : ViewElement option = None with get, set

    static member val _CreateEditor : (unit -> Xamarin.Forms.Editor) = fun () -> 
            upcast (new Xamarin.Forms.Editor())

    static member val _UpdateEditor = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Editor) -> 
        let baseElement = (if Xaml._ProtoInputView.IsNone then Xaml._ProtoInputView <- Some (Xaml.InputView())); Xaml._ProtoInputView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._EditorCompletedAttribKey.KeyValue then 
                currEditorCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = Xaml._TextChangedAttribKey.KeyValue then 
                currTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._EditorCompletedAttribKey.KeyValue then 
                    prevEditorCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml._TextChangedAttribKey.KeyValue then 
                    prevTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
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

    /// Describes a Editor in the view
    static member inline Editor(?text: string, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildEditor(0, ?text=text, ?fontSize=fontSize, ?fontFamily=fontFamily, ?fontAttributes=fontAttributes, ?textColor=textColor, ?completed=completed, ?textChanged=textChanged, ?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Editor>(Xaml._CreateEditor, Xaml._UpdateEditor, attribBuilder)

    /// Builds the attributes for a Entry in the view
    static member inline _BuildEntry(attribCount: int, ?text: string, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?placeholderColor: Xamarin.Forms.Color, ?isPassword: bool, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

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

        let attribBuilder = Xaml._BuildInputView(attribCount, ?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match text with None -> () | Some v -> attribBuilder.Add(Xaml._TextAttribKey, (v)) 
        match placeholder with None -> () | Some v -> attribBuilder.Add(Xaml._PlaceholderAttribKey, (v)) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.Add(Xaml._HorizontalTextAlignmentAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(Xaml._FontSizeAttribKey, makeFontSize(v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(Xaml._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(Xaml._FontAttributesAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(Xaml._TextColorAttribKey, (v)) 
        match placeholderColor with None -> () | Some v -> attribBuilder.Add(Xaml._PlaceholderColorAttribKey, (v)) 
        match isPassword with None -> () | Some v -> attribBuilder.Add(Xaml._IsPasswordAttribKey, (v)) 
        match completed with None -> () | Some v -> attribBuilder.Add(Xaml._EntryCompletedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(v)) 
        match textChanged with None -> () | Some v -> attribBuilder.Add(Xaml._TextChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoEntry : ViewElement option = None with get, set

    static member val _CreateEntry : (unit -> Xamarin.Forms.Entry) = fun () -> 
            upcast (new Xamarin.Forms.Entry())

    static member val _UpdateEntry = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Entry) -> 
        let baseElement = (if Xaml._ProtoInputView.IsNone then Xaml._ProtoInputView <- Some (Xaml.InputView())); Xaml._ProtoInputView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._PlaceholderAttribKey.KeyValue then 
                currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._HorizontalTextAlignmentAttribKey.KeyValue then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._PlaceholderColorAttribKey.KeyValue then 
                currPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._IsPasswordAttribKey.KeyValue then 
                currIsPasswordOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._EntryCompletedAttribKey.KeyValue then 
                currEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = Xaml._TextChangedAttribKey.KeyValue then 
                currTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._PlaceholderAttribKey.KeyValue then 
                    prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._HorizontalTextAlignmentAttribKey.KeyValue then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._PlaceholderColorAttribKey.KeyValue then 
                    prevPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._IsPasswordAttribKey.KeyValue then 
                    prevIsPasswordOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._EntryCompletedAttribKey.KeyValue then 
                    prevEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml._TextChangedAttribKey.KeyValue then 
                    prevTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
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

    /// Describes a Entry in the view
    static member inline Entry(?text: string, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?placeholderColor: Xamarin.Forms.Color, ?isPassword: bool, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildEntry(0, ?text=text, ?placeholder=placeholder, ?horizontalTextAlignment=horizontalTextAlignment, ?fontSize=fontSize, ?fontFamily=fontFamily, ?fontAttributes=fontAttributes, ?textColor=textColor, ?placeholderColor=placeholderColor, ?isPassword=isPassword, ?completed=completed, ?textChanged=textChanged, ?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Entry>(Xaml._CreateEntry, Xaml._UpdateEntry, attribBuilder)

    /// Builds the attributes for a EntryCell in the view
    static member inline _BuildEntryCell(attribCount: int, ?label: string, ?text: string, ?keyboard: Xamarin.Forms.Keyboard, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?completed: string -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match label with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match keyboard with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match placeholder with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match horizontalTextAlignment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match completed with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        match label with None -> () | Some v -> attribBuilder.Add(Xaml._LabelAttribKey, (v)) 
        match text with None -> () | Some v -> attribBuilder.Add(Xaml._TextAttribKey, (v)) 
        match keyboard with None -> () | Some v -> attribBuilder.Add(Xaml._KeyboardAttribKey, (v)) 
        match placeholder with None -> () | Some v -> attribBuilder.Add(Xaml._PlaceholderAttribKey, (v)) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.Add(Xaml._HorizontalTextAlignmentAttribKey, (v)) 
        match completed with None -> () | Some v -> attribBuilder.Add(Xaml._EntryCompletedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.EntryCell).Text))(v)) 
        attribBuilder

    static member val _ProtoEntryCell : ViewElement option = None with get, set

    static member val _CreateEntryCell : (unit -> Xamarin.Forms.EntryCell) = fun () -> 
            upcast (new Xamarin.Forms.EntryCell())

    static member val _UpdateEntryCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.EntryCell) -> 
        let baseElement = (if Xaml._ProtoCell.IsNone then Xaml._ProtoCell <- Some (Xaml.Cell())); Xaml._ProtoCell.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._LabelAttribKey.KeyValue then 
                currLabelOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._KeyboardAttribKey.KeyValue then 
                currKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
            if kvp.Key = Xaml._PlaceholderAttribKey.KeyValue then 
                currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._HorizontalTextAlignmentAttribKey.KeyValue then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = Xaml._EntryCompletedAttribKey.KeyValue then 
                currEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._LabelAttribKey.KeyValue then 
                    prevLabelOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._KeyboardAttribKey.KeyValue then 
                    prevKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
                if kvp.Key = Xaml._PlaceholderAttribKey.KeyValue then 
                    prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._HorizontalTextAlignmentAttribKey.KeyValue then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml._EntryCompletedAttribKey.KeyValue then 
                    prevEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
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

    /// Describes a EntryCell in the view
    static member inline EntryCell(?label: string, ?text: string, ?keyboard: Xamarin.Forms.Keyboard, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?completed: string -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildEntryCell(0, ?label=label, ?text=text, ?keyboard=keyboard, ?placeholder=placeholder, ?horizontalTextAlignment=horizontalTextAlignment, ?completed=completed, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.EntryCell>(Xaml._CreateEntryCell, Xaml._UpdateEntryCell, attribBuilder)

    /// Builds the attributes for a Label in the view
    static member inline _BuildLabel(attribCount: int, ?text: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?verticalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?formattedText: ViewElement, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match horizontalTextAlignment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match verticalTextAlignment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontAttributes with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match formattedText with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match text with None -> () | Some v -> attribBuilder.Add(Xaml._TextAttribKey, (v)) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.Add(Xaml._HorizontalTextAlignmentAttribKey, (v)) 
        match verticalTextAlignment with None -> () | Some v -> attribBuilder.Add(Xaml._VerticalTextAlignmentAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(Xaml._FontSizeAttribKey, makeFontSize(v)) 
        match fontFamily with None -> () | Some v -> attribBuilder.Add(Xaml._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(Xaml._FontAttributesAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(Xaml._TextColorAttribKey, (v)) 
        match formattedText with None -> () | Some v -> attribBuilder.Add(Xaml._FormattedTextAttribKey, (v)) 
        attribBuilder

    static member val _ProtoLabel : ViewElement option = None with get, set

    static member val _CreateLabel : (unit -> Xamarin.Forms.Label) = fun () -> 
            upcast (new Xamarin.Forms.Label())

    static member val _UpdateLabel = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Label) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._HorizontalTextAlignmentAttribKey.KeyValue then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = Xaml._VerticalTextAlignmentAttribKey.KeyValue then 
                currVerticalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._FormattedTextAttribKey.KeyValue then 
                currFormattedTextOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._HorizontalTextAlignmentAttribKey.KeyValue then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml._VerticalTextAlignmentAttribKey.KeyValue then 
                    prevVerticalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._FormattedTextAttribKey.KeyValue then 
                    prevFormattedTextOpt <- ValueSome (kvp.Value :?> ViewElement)
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

    /// Describes a Label in the view
    static member inline Label(?text: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?verticalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?formattedText: ViewElement, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildLabel(0, ?text=text, ?horizontalTextAlignment=horizontalTextAlignment, ?verticalTextAlignment=verticalTextAlignment, ?fontSize=fontSize, ?fontFamily=fontFamily, ?fontAttributes=fontAttributes, ?textColor=textColor, ?formattedText=formattedText, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Label>(Xaml._CreateLabel, Xaml._UpdateLabel, attribBuilder)

    /// Builds the attributes for a StackLayout in the view
    static member inline _BuildStackLayout(attribCount: int, ?children: ViewElement list, ?orientation: Xamarin.Forms.StackOrientation, ?spacing: double, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match orientation with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match spacing with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match children with None -> () | Some v -> attribBuilder.Add(Xaml._ChildrenAttribKey, Array.ofList(v)) 
        match orientation with None -> () | Some v -> attribBuilder.Add(Xaml._StackOrientationAttribKey, (v)) 
        match spacing with None -> () | Some v -> attribBuilder.Add(Xaml._SpacingAttribKey, (v)) 
        attribBuilder

    static member val _ProtoStackLayout : ViewElement option = None with get, set

    static member val _CreateStackLayout : (unit -> Xamarin.Forms.StackLayout) = fun () -> 
            upcast (new Xamarin.Forms.StackLayout())

    static member val _UpdateStackLayout = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.StackLayout) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        let mutable prevStackOrientationOpt = ValueNone
        let mutable currStackOrientationOpt = ValueNone
        let mutable prevSpacingOpt = ValueNone
        let mutable currSpacingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._StackOrientationAttribKey.KeyValue then 
                currStackOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StackOrientation)
            if kvp.Key = Xaml._SpacingAttribKey.KeyValue then 
                currSpacingOpt <- ValueSome (kvp.Value :?> double)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._StackOrientationAttribKey.KeyValue then 
                    prevStackOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StackOrientation)
                if kvp.Key = Xaml._SpacingAttribKey.KeyValue then 
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
    static member inline StackLayout(?children: ViewElement list, ?orientation: Xamarin.Forms.StackOrientation, ?spacing: double, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildStackLayout(0, ?children=children, ?orientation=orientation, ?spacing=spacing, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.StackLayout>(Xaml._CreateStackLayout, Xaml._UpdateStackLayout, attribBuilder)

    /// Builds the attributes for a Span in the view
    static member inline _BuildSpan(attribCount: int, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?backgroundColor: Xamarin.Forms.Color, ?foregroundColor: Xamarin.Forms.Color, ?text: string, ?propertyChanged: System.ComponentModel.PropertyChangedEventArgs -> unit) = 

        let attribCount = match fontFamily with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontAttributes with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match fontSize with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match backgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match foregroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match propertyChanged with Some _ -> attribCount + 1 | None -> attribCount
        let attribBuilder = new AttributesBuilder(attribCount)
        match fontFamily with None -> () | Some v -> attribBuilder.Add(Xaml._FontFamilyAttribKey, (v)) 
        match fontAttributes with None -> () | Some v -> attribBuilder.Add(Xaml._FontAttributesAttribKey, (v)) 
        match fontSize with None -> () | Some v -> attribBuilder.Add(Xaml._FontSizeAttribKey, makeFontSize(v)) 
        match backgroundColor with None -> () | Some v -> attribBuilder.Add(Xaml._BackgroundColorAttribKey, (v)) 
        match foregroundColor with None -> () | Some v -> attribBuilder.Add(Xaml._ForegroundColorAttribKey, (v)) 
        match text with None -> () | Some v -> attribBuilder.Add(Xaml._TextAttribKey, (v)) 
        match propertyChanged with None -> () | Some v -> attribBuilder.Add(Xaml._PropertyChangedAttribKey, (fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoSpan : ViewElement option = None with get, set

    static member val _CreateSpan : (unit -> Xamarin.Forms.Span) = fun () -> 
            upcast (new Xamarin.Forms.Span())

    static member val _UpdateSpan = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Span) -> 
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
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._BackgroundColorAttribKey.KeyValue then 
                currBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._ForegroundColorAttribKey.KeyValue then 
                currForegroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._PropertyChangedAttribKey.KeyValue then 
                currPropertyChangedOpt <- ValueSome (kvp.Value :?> System.ComponentModel.PropertyChangedEventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._FontFamilyAttribKey.KeyValue then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesAttribKey.KeyValue then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._FontSizeAttribKey.KeyValue then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._BackgroundColorAttribKey.KeyValue then 
                    prevBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._ForegroundColorAttribKey.KeyValue then 
                    prevForegroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._PropertyChangedAttribKey.KeyValue then 
                    prevPropertyChangedOpt <- ValueSome (kvp.Value :?> System.ComponentModel.PropertyChangedEventHandler)
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

    /// Describes a Span in the view
    static member inline Span(?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?backgroundColor: Xamarin.Forms.Color, ?foregroundColor: Xamarin.Forms.Color, ?text: string, ?propertyChanged: System.ComponentModel.PropertyChangedEventArgs -> unit) = 

        let attribBuilder = Xaml._BuildSpan(0, ?fontFamily=fontFamily, ?fontAttributes=fontAttributes, ?fontSize=fontSize, ?backgroundColor=backgroundColor, ?foregroundColor=foregroundColor, ?text=text, ?propertyChanged=propertyChanged)

        ViewElement.Create<Xamarin.Forms.Span>(Xaml._CreateSpan, Xaml._UpdateSpan, attribBuilder)

    /// Builds the attributes for a FormattedString in the view
    static member inline _BuildFormattedString(attribCount: int, ?spans: ViewElement[]) = 

        let attribCount = match spans with Some _ -> attribCount + 1 | None -> attribCount
        let attribBuilder = new AttributesBuilder(attribCount)
        match spans with None -> () | Some v -> attribBuilder.Add(Xaml._SpansAttribKey, (v)) 
        attribBuilder

    static member val _ProtoFormattedString : ViewElement option = None with get, set

    static member val _CreateFormattedString : (unit -> Xamarin.Forms.FormattedString) = fun () -> 
            upcast (new Xamarin.Forms.FormattedString())

    static member val _UpdateFormattedString = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.FormattedString) -> 
        let mutable prevSpansOpt = ValueNone
        let mutable currSpansOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._SpansAttribKey.KeyValue then 
                currSpansOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._SpansAttribKey.KeyValue then 
                    prevSpansOpt <- ValueSome (kvp.Value :?> ViewElement[])
        updateCollectionGeneric prevSpansOpt currSpansOpt target.Spans
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.Span)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild

    /// Describes a FormattedString in the view
    static member inline FormattedString(?spans: ViewElement[]) = 

        let attribBuilder = Xaml._BuildFormattedString(0, ?spans=spans)

        ViewElement.Create<Xamarin.Forms.FormattedString>(Xaml._CreateFormattedString, Xaml._UpdateFormattedString, attribBuilder)

    /// Builds the attributes for a TimePicker in the view
    static member inline _BuildTimePicker(attribCount: int, ?time: System.TimeSpan, ?format: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match time with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match format with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match time with None -> () | Some v -> attribBuilder.Add(Xaml._TimeAttribKey, (v)) 
        match format with None -> () | Some v -> attribBuilder.Add(Xaml._FormatAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(Xaml._TextColorAttribKey, (v)) 
        attribBuilder

    static member val _ProtoTimePicker : ViewElement option = None with get, set

    static member val _CreateTimePicker : (unit -> Xamarin.Forms.TimePicker) = fun () -> 
            upcast (new Xamarin.Forms.TimePicker())

    static member val _UpdateTimePicker = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TimePicker) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevTimeOpt = ValueNone
        let mutable currTimeOpt = ValueNone
        let mutable prevFormatOpt = ValueNone
        let mutable currFormatOpt = ValueNone
        let mutable prevTextColorOpt = ValueNone
        let mutable currTextColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._TimeAttribKey.KeyValue then 
                currTimeOpt <- ValueSome (kvp.Value :?> System.TimeSpan)
            if kvp.Key = Xaml._FormatAttribKey.KeyValue then 
                currFormatOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TimeAttribKey.KeyValue then 
                    prevTimeOpt <- ValueSome (kvp.Value :?> System.TimeSpan)
                if kvp.Key = Xaml._FormatAttribKey.KeyValue then 
                    prevFormatOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
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
    static member inline TimePicker(?time: System.TimeSpan, ?format: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildTimePicker(0, ?time=time, ?format=format, ?textColor=textColor, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.TimePicker>(Xaml._CreateTimePicker, Xaml._UpdateTimePicker, attribBuilder)

    /// Builds the attributes for a WebView in the view
    static member inline _BuildWebView(attribCount: int, ?source: Xamarin.Forms.WebViewSource, ?navigated: Xamarin.Forms.WebNavigatedEventArgs -> unit, ?navigating: Xamarin.Forms.WebNavigatingEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match source with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match navigated with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match navigating with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match source with None -> () | Some v -> attribBuilder.Add(Xaml._WebSourceAttribKey, (v)) 
        match navigated with None -> () | Some v -> attribBuilder.Add(Xaml._NavigatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(v)) 
        match navigating with None -> () | Some v -> attribBuilder.Add(Xaml._NavigatingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoWebView : ViewElement option = None with get, set

    static member val _CreateWebView : (unit -> Xamarin.Forms.WebView) = fun () -> 
            upcast (new Xamarin.Forms.WebView())

    static member val _UpdateWebView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.WebView) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevWebSourceOpt = ValueNone
        let mutable currWebSourceOpt = ValueNone
        let mutable prevNavigatedOpt = ValueNone
        let mutable currNavigatedOpt = ValueNone
        let mutable prevNavigatingOpt = ValueNone
        let mutable currNavigatingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._WebSourceAttribKey.KeyValue then 
                currWebSourceOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.WebViewSource)
            if kvp.Key = Xaml._NavigatedAttribKey.KeyValue then 
                currNavigatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>)
            if kvp.Key = Xaml._NavigatingAttribKey.KeyValue then 
                currNavigatingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._WebSourceAttribKey.KeyValue then 
                    prevWebSourceOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.WebViewSource)
                if kvp.Key = Xaml._NavigatedAttribKey.KeyValue then 
                    prevNavigatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>)
                if kvp.Key = Xaml._NavigatingAttribKey.KeyValue then 
                    prevNavigatingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>)
        match prevWebSourceOpt, currWebSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Source <-  currValue
        | ValueSome _, ValueNone -> target.Source <- null
        | ValueNone, ValueNone -> ()
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

    /// Describes a WebView in the view
    static member inline WebView(?source: Xamarin.Forms.WebViewSource, ?navigated: Xamarin.Forms.WebNavigatedEventArgs -> unit, ?navigating: Xamarin.Forms.WebNavigatingEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildWebView(0, ?source=source, ?navigated=navigated, ?navigating=navigating, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.WebView>(Xaml._CreateWebView, Xaml._UpdateWebView, attribBuilder)

    /// Builds the attributes for a Page in the view
    static member inline _BuildPage(attribCount: int, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

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

        let attribBuilder = Xaml._BuildVisualElement(attribCount, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match title with None -> () | Some v -> attribBuilder.Add(Xaml._TitleAttribKey, (v)) 
        match backgroundImage with None -> () | Some v -> attribBuilder.Add(Xaml._BackgroundImageAttribKey, (v)) 
        match icon with None -> () | Some v -> attribBuilder.Add(Xaml._IconAttribKey, (v)) 
        match isBusy with None -> () | Some v -> attribBuilder.Add(Xaml._IsBusyAttribKey, (v)) 
        match padding with None -> () | Some v -> attribBuilder.Add(Xaml._PaddingAttribKey, makeThickness(v)) 
        match toolbarItems with None -> () | Some v -> attribBuilder.Add(Xaml._ToolbarItemsAttribKey, Array.ofList(v)) 
        match useSafeArea with None -> () | Some v -> attribBuilder.Add(Xaml._UseSafeAreaAttribKey, (v)) 
        match appearing with None -> () | Some v -> attribBuilder.Add(Xaml._Page_AppearingAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(v)) 
        match disappearing with None -> () | Some v -> attribBuilder.Add(Xaml._Page_DisappearingAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(v)) 
        match layoutChanged with None -> () | Some v -> attribBuilder.Add(Xaml._Page_LayoutChangedAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(v)) 
        attribBuilder

    static member val _ProtoPage : ViewElement option = None with get, set

    static member val _CreatePage : (unit -> Xamarin.Forms.Page) = fun () -> 
            upcast (new Xamarin.Forms.Page())

    static member val _UpdatePage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.Page) -> 
        let baseElement = (if Xaml._ProtoVisualElement.IsNone then Xaml._ProtoVisualElement <- Some (Xaml.VisualElement())); Xaml._ProtoVisualElement.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
            if kvp.Key = Xaml._TitleAttribKey.KeyValue then 
                currTitleOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._BackgroundImageAttribKey.KeyValue then 
                currBackgroundImageOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._IconAttribKey.KeyValue then 
                currIconOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._IsBusyAttribKey.KeyValue then 
                currIsBusyOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._PaddingAttribKey.KeyValue then 
                currPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
            if kvp.Key = Xaml._ToolbarItemsAttribKey.KeyValue then 
                currToolbarItemsOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._UseSafeAreaAttribKey.KeyValue then 
                currUseSafeAreaOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._Page_AppearingAttribKey.KeyValue then 
                currPage_AppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = Xaml._Page_DisappearingAttribKey.KeyValue then 
                currPage_DisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = Xaml._Page_LayoutChangedAttribKey.KeyValue then 
                currPage_LayoutChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TitleAttribKey.KeyValue then 
                    prevTitleOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._BackgroundImageAttribKey.KeyValue then 
                    prevBackgroundImageOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._IconAttribKey.KeyValue then 
                    prevIconOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._IsBusyAttribKey.KeyValue then 
                    prevIsBusyOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._PaddingAttribKey.KeyValue then 
                    prevPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                if kvp.Key = Xaml._ToolbarItemsAttribKey.KeyValue then 
                    prevToolbarItemsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._UseSafeAreaAttribKey.KeyValue then 
                    prevUseSafeAreaOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._Page_AppearingAttribKey.KeyValue then 
                    prevPage_AppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml._Page_DisappearingAttribKey.KeyValue then 
                    prevPage_DisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml._Page_LayoutChangedAttribKey.KeyValue then 
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
        | _, ValueSome currValue -> target.Icon <- makeFileImageSource  currValue
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
        (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea(target.On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevUseSafeAreaOpt currUseSafeAreaOpt target
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
    static member inline Page(?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildPage(0, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.Page>(Xaml._CreatePage, Xaml._UpdatePage, attribBuilder)

    /// Builds the attributes for a CarouselPage in the view
    static member inline _BuildCarouselPage(attribCount: int, ?children: ViewElement list, ?selectedItem: System.Object, ?currentPage: ViewElement, ?currentPageChanged: 'T option -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectedItem with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match currentPage with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match currentPageChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match children with None -> () | Some v -> attribBuilder.Add(Xaml._ChildrenAttribKey, Array.ofList(v)) 
        match selectedItem with None -> () | Some v -> attribBuilder.Add(Xaml._CarouselPage_SelectedItemAttribKey, (v)) 
        match currentPage with None -> () | Some v -> attribBuilder.Add(Xaml._CurrentPageAttribKey, (v)) 
        match currentPageChanged with None -> () | Some v -> attribBuilder.Add(Xaml._CurrentPageChangedAttribKey, (fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(v)) 
        attribBuilder

    static member val _ProtoCarouselPage : ViewElement option = None with get, set

    static member val _CreateCarouselPage : (unit -> Xamarin.Forms.CarouselPage) = fun () -> 
            upcast (new Xamarin.Forms.CarouselPage())

    static member val _UpdateCarouselPage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.CarouselPage) -> 
        let baseElement = (if Xaml._ProtoPage.IsNone then Xaml._ProtoPage <- Some (Xaml.Page())); Xaml._ProtoPage.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        let mutable prevCarouselPage_SelectedItemOpt = ValueNone
        let mutable currCarouselPage_SelectedItemOpt = ValueNone
        let mutable prevCurrentPageOpt = ValueNone
        let mutable currCurrentPageOpt = ValueNone
        let mutable prevCurrentPageChangedOpt = ValueNone
        let mutable currCurrentPageChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._CarouselPage_SelectedItemAttribKey.KeyValue then 
                currCarouselPage_SelectedItemOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._CurrentPageAttribKey.KeyValue then 
                currCurrentPageOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = Xaml._CurrentPageChangedAttribKey.KeyValue then 
                currCurrentPageChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._CarouselPage_SelectedItemAttribKey.KeyValue then 
                    prevCarouselPage_SelectedItemOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._CurrentPageAttribKey.KeyValue then 
                    prevCurrentPageOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml._CurrentPageChangedAttribKey.KeyValue then 
                    prevCurrentPageChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.ContentPage)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild
        match prevCarouselPage_SelectedItemOpt, currCarouselPage_SelectedItemOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SelectedItem <-  currValue
        | ValueSome _, ValueNone -> target.SelectedItem <- null
        | ValueNone, ValueNone -> ()
        match prevCurrentPageOpt, currCurrentPageOpt with
        // For structured objects, dependsOn on reference equality
        | ValueSome prevValue, ValueSome newValue when identical prevValue newValue -> ()
        | ValueSome prevValue, ValueSome newValue when canReuseChild prevValue newValue ->
            newValue.UpdateIncremental(prevValue, target.CurrentPage)
        | _, ValueSome newValue ->
            target.CurrentPage <- (newValue.Create() :?> Xamarin.Forms.ContentPage)
        | ValueSome _, ValueNone ->
            target.CurrentPage <- null
        | ValueNone, ValueNone -> ()
        match prevCurrentPageChangedOpt, currCurrentPageChangedOpt with
        | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
        | ValueSome prevValue, ValueSome currValue -> target.CurrentPageChanged.RemoveHandler(prevValue); target.CurrentPageChanged.AddHandler(currValue)
        | ValueNone, ValueSome currValue -> target.CurrentPageChanged.AddHandler(currValue)
        | ValueSome prevValue, ValueNone -> target.CurrentPageChanged.RemoveHandler(prevValue)
        | ValueNone, ValueNone -> ()

    /// Describes a CarouselPage in the view
    static member inline CarouselPage(?children: ViewElement list, ?selectedItem: System.Object, ?currentPage: ViewElement, ?currentPageChanged: 'T option -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildCarouselPage(0, ?children=children, ?selectedItem=selectedItem, ?currentPage=currentPage, ?currentPageChanged=currentPageChanged, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.CarouselPage>(Xaml._CreateCarouselPage, Xaml._UpdateCarouselPage, attribBuilder)

    /// Builds the attributes for a NavigationPage in the view
    static member inline _BuildNavigationPage(attribCount: int, ?pages: ViewElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?popped: Xamarin.Forms.NavigationEventArgs -> unit, ?poppedToRoot: Xamarin.Forms.NavigationEventArgs -> unit, ?pushed: Xamarin.Forms.NavigationEventArgs -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match pages with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barBackgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barTextColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match popped with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match poppedToRoot with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match pushed with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match pages with None -> () | Some v -> attribBuilder.Add(Xaml._PagesAttribKey, Array.ofList(v)) 
        match barBackgroundColor with None -> () | Some v -> attribBuilder.Add(Xaml._BarBackgroundColorAttribKey, (v)) 
        match barTextColor with None -> () | Some v -> attribBuilder.Add(Xaml._BarTextColorAttribKey, (v)) 
        match popped with None -> () | Some v -> attribBuilder.Add(Xaml._PoppedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v)) 
        match poppedToRoot with None -> () | Some v -> attribBuilder.Add(Xaml._PoppedToRootAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v)) 
        match pushed with None -> () | Some v -> attribBuilder.Add(Xaml._PushedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoNavigationPage : ViewElement option = None with get, set

    static member val _CreateNavigationPage : (unit -> Xamarin.Forms.NavigationPage) = fun () -> 
            upcast (new Xamarin.Forms.NavigationPage())

    static member val _UpdateNavigationPage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.NavigationPage) -> 
        let baseElement = (if Xaml._ProtoPage.IsNone then Xaml._ProtoPage <- Some (Xaml.Page())); Xaml._ProtoPage.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
            if kvp.Key = Xaml._PagesAttribKey.KeyValue then 
                currPagesOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._BarBackgroundColorAttribKey.KeyValue then 
                currBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._BarTextColorAttribKey.KeyValue then 
                currBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._PoppedAttribKey.KeyValue then 
                currPoppedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
            if kvp.Key = Xaml._PoppedToRootAttribKey.KeyValue then 
                currPoppedToRootOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
            if kvp.Key = Xaml._PushedAttribKey.KeyValue then 
                currPushedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._PagesAttribKey.KeyValue then 
                    prevPagesOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._BarBackgroundColorAttribKey.KeyValue then 
                    prevBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._BarTextColorAttribKey.KeyValue then 
                    prevBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._PoppedAttribKey.KeyValue then 
                    prevPoppedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
                if kvp.Key = Xaml._PoppedToRootAttribKey.KeyValue then 
                    prevPoppedToRootOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
                if kvp.Key = Xaml._PushedAttribKey.KeyValue then 
                    prevPushedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
        updateNavigationPages prevPagesOpt currPagesOpt target
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<string>(Xaml._BackButtonTitleAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<string>(Xaml._BackButtonTitleAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<bool>(Xaml._HasBackButtonAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<bool>(Xaml._HasBackButtonAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, true) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<bool>(Xaml._HasNavigationBarAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<bool>(Xaml._HasNavigationBarAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, true) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<string>(Xaml._TitleIconAttribKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<string>(Xaml._TitleIconAttribKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, makeFileImageSource currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
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
    static member inline NavigationPage(?pages: ViewElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?popped: Xamarin.Forms.NavigationEventArgs -> unit, ?poppedToRoot: Xamarin.Forms.NavigationEventArgs -> unit, ?pushed: Xamarin.Forms.NavigationEventArgs -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildNavigationPage(0, ?pages=pages, ?barBackgroundColor=barBackgroundColor, ?barTextColor=barTextColor, ?popped=popped, ?poppedToRoot=poppedToRoot, ?pushed=pushed, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.NavigationPage>(Xaml._CreateNavigationPage, Xaml._UpdateNavigationPage, attribBuilder)

    /// Builds the attributes for a TabbedPage in the view
    static member inline _BuildTabbedPage(attribCount: int, ?children: ViewElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barBackgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barTextColor with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match children with None -> () | Some v -> attribBuilder.Add(Xaml._ChildrenAttribKey, Array.ofList(v)) 
        match barBackgroundColor with None -> () | Some v -> attribBuilder.Add(Xaml._BarBackgroundColorAttribKey, (v)) 
        match barTextColor with None -> () | Some v -> attribBuilder.Add(Xaml._BarTextColorAttribKey, (v)) 
        attribBuilder

    static member val _ProtoTabbedPage : ViewElement option = None with get, set

    static member val _CreateTabbedPage : (unit -> Xamarin.Forms.TabbedPage) = fun () -> 
            upcast (new Xamarin.Forms.TabbedPage())

    static member val _UpdateTabbedPage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TabbedPage) -> 
        let baseElement = (if Xaml._ProtoPage.IsNone then Xaml._ProtoPage <- Some (Xaml.Page())); Xaml._ProtoPage.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        let mutable prevBarBackgroundColorOpt = ValueNone
        let mutable currBarBackgroundColorOpt = ValueNone
        let mutable prevBarTextColorOpt = ValueNone
        let mutable currBarTextColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._BarBackgroundColorAttribKey.KeyValue then 
                currBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._BarTextColorAttribKey.KeyValue then 
                currBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ChildrenAttribKey.KeyValue then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._BarBackgroundColorAttribKey.KeyValue then 
                    prevBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._BarTextColorAttribKey.KeyValue then 
                    prevBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
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

    /// Describes a TabbedPage in the view
    static member inline TabbedPage(?children: ViewElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildTabbedPage(0, ?children=children, ?barBackgroundColor=barBackgroundColor, ?barTextColor=barTextColor, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.TabbedPage>(Xaml._CreateTabbedPage, Xaml._UpdateTabbedPage, attribBuilder)

    /// Builds the attributes for a ContentPage in the view
    static member inline _BuildContentPage(attribCount: int, ?content: ViewElement, ?onSizeAllocated: (double * double) -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match onSizeAllocated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match content with None -> () | Some v -> attribBuilder.Add(Xaml._ContentAttribKey, (v)) 
        match onSizeAllocated with None -> () | Some v -> attribBuilder.Add(Xaml._OnSizeAllocatedCallbackAttribKey, (fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(v)) 
        attribBuilder

    static member val _ProtoContentPage : ViewElement option = None with get, set

    static member val _CreateContentPage : (unit -> Xamarin.Forms.ContentPage) = fun () -> 
            upcast (new Elmish.XamarinForms.DynamicViews.CustomContentPage())

    static member val _UpdateContentPage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ContentPage) -> 
        let baseElement = (if Xaml._ProtoPage.IsNone then Xaml._ProtoPage <- Some (Xaml.Page())); Xaml._ProtoPage.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevContentOpt = ValueNone
        let mutable currContentOpt = ValueNone
        let mutable prevOnSizeAllocatedCallbackOpt = ValueNone
        let mutable currOnSizeAllocatedCallbackOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ContentAttribKey.KeyValue then 
                currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = Xaml._OnSizeAllocatedCallbackAttribKey.KeyValue then 
                currOnSizeAllocatedCallbackOpt <- ValueSome (kvp.Value :?> FSharp.Control.Handler<(double * double)>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ContentAttribKey.KeyValue then 
                    prevContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml._OnSizeAllocatedCallbackAttribKey.KeyValue then 
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
    static member inline ContentPage(?content: ViewElement, ?onSizeAllocated: (double * double) -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildContentPage(0, ?content=content, ?onSizeAllocated=onSizeAllocated, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ContentPage>(Xaml._CreateContentPage, Xaml._UpdateContentPage, attribBuilder)

    /// Builds the attributes for a MasterDetailPage in the view
    static member inline _BuildMasterDetailPage(attribCount: int, ?master: ViewElement, ?detail: ViewElement, ?isGestureEnabled: bool, ?isPresented: bool, ?masterBehavior: Xamarin.Forms.MasterBehavior, ?isPresentedChanged: bool -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match master with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match detail with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isGestureEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isPresented with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match masterBehavior with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isPresentedChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match master with None -> () | Some v -> attribBuilder.Add(Xaml._MasterAttribKey, (v)) 
        match detail with None -> () | Some v -> attribBuilder.Add(Xaml._DetailAttribKey, (v)) 
        match isGestureEnabled with None -> () | Some v -> attribBuilder.Add(Xaml._IsGestureEnabledAttribKey, (v)) 
        match isPresented with None -> () | Some v -> attribBuilder.Add(Xaml._IsPresentedAttribKey, (v)) 
        match masterBehavior with None -> () | Some v -> attribBuilder.Add(Xaml._MasterBehaviorAttribKey, (v)) 
        match isPresentedChanged with None -> () | Some v -> attribBuilder.Add(Xaml._IsPresentedChangedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(v)) 
        attribBuilder

    static member val _ProtoMasterDetailPage : ViewElement option = None with get, set

    static member val _CreateMasterDetailPage : (unit -> Xamarin.Forms.MasterDetailPage) = fun () -> 
            upcast (new Xamarin.Forms.MasterDetailPage())

    static member val _UpdateMasterDetailPage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.MasterDetailPage) -> 
        let baseElement = (if Xaml._ProtoPage.IsNone then Xaml._ProtoPage <- Some (Xaml.Page())); Xaml._ProtoPage.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
            if kvp.Key = Xaml._MasterAttribKey.KeyValue then 
                currMasterOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = Xaml._DetailAttribKey.KeyValue then 
                currDetailOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = Xaml._IsGestureEnabledAttribKey.KeyValue then 
                currIsGestureEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsPresentedAttribKey.KeyValue then 
                currIsPresentedOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._MasterBehaviorAttribKey.KeyValue then 
                currMasterBehaviorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.MasterBehavior)
            if kvp.Key = Xaml._IsPresentedChangedAttribKey.KeyValue then 
                currIsPresentedChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._MasterAttribKey.KeyValue then 
                    prevMasterOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml._DetailAttribKey.KeyValue then 
                    prevDetailOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml._IsGestureEnabledAttribKey.KeyValue then 
                    prevIsGestureEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsPresentedAttribKey.KeyValue then 
                    prevIsPresentedOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._MasterBehaviorAttribKey.KeyValue then 
                    prevMasterBehaviorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.MasterBehavior)
                if kvp.Key = Xaml._IsPresentedChangedAttribKey.KeyValue then 
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
    static member inline MasterDetailPage(?master: ViewElement, ?detail: ViewElement, ?isGestureEnabled: bool, ?isPresented: bool, ?masterBehavior: Xamarin.Forms.MasterBehavior, ?isPresentedChanged: bool -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildMasterDetailPage(0, ?master=master, ?detail=detail, ?isGestureEnabled=isGestureEnabled, ?isPresented=isPresented, ?masterBehavior=masterBehavior, ?isPresentedChanged=isPresentedChanged, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.MasterDetailPage>(Xaml._CreateMasterDetailPage, Xaml._UpdateMasterDetailPage, attribBuilder)

    /// Builds the attributes for a MenuItem in the view
    static member inline _BuildMenuItem(attribCount: int, ?text: string, ?command: unit -> unit, ?commandParameter: System.Object, ?icon: string, ?classId: string, ?styleId: string) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match commandParameter with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match icon with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match text with None -> () | Some v -> attribBuilder.Add(Xaml._TextAttribKey, (v)) 
        match command with None -> () | Some v -> attribBuilder.Add(Xaml._CommandAttribKey, makeCommand(v)) 
        match commandParameter with None -> () | Some v -> attribBuilder.Add(Xaml._CommandParameterAttribKey, (v)) 
        match icon with None -> () | Some v -> attribBuilder.Add(Xaml._IconAttribKey, (v)) 
        attribBuilder

    static member val _ProtoMenuItem : ViewElement option = None with get, set

    static member val _CreateMenuItem : (unit -> Xamarin.Forms.MenuItem) = fun () -> 
            upcast (new Xamarin.Forms.MenuItem())

    static member val _UpdateMenuItem = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.MenuItem) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevCommandOpt = ValueNone
        let mutable currCommandOpt = ValueNone
        let mutable prevCommandParameterOpt = ValueNone
        let mutable currCommandParameterOpt = ValueNone
        let mutable prevIconOpt = ValueNone
        let mutable currIconOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._CommandAttribKey.KeyValue then 
                currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = Xaml._CommandParameterAttribKey.KeyValue then 
                currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._IconAttribKey.KeyValue then 
                currIconOpt <- ValueSome (kvp.Value :?> string)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._CommandAttribKey.KeyValue then 
                    prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml._CommandParameterAttribKey.KeyValue then 
                    prevCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._IconAttribKey.KeyValue then 
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
        | _, ValueSome currValue -> target.Icon <- makeFileImageSource  currValue
        | ValueSome _, ValueNone -> target.Icon <- null
        | ValueNone, ValueNone -> ()

    /// Describes a MenuItem in the view
    static member inline MenuItem(?text: string, ?command: unit -> unit, ?commandParameter: System.Object, ?icon: string, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildMenuItem(0, ?text=text, ?command=command, ?commandParameter=commandParameter, ?icon=icon, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.MenuItem>(Xaml._CreateMenuItem, Xaml._UpdateMenuItem, attribBuilder)

    /// Builds the attributes for a TextCell in the view
    static member inline _BuildTextCell(attribCount: int, ?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match detail with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match detailColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match canExecute with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match commandParameter with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        match text with None -> () | Some v -> attribBuilder.Add(Xaml._TextAttribKey, (v)) 
        match detail with None -> () | Some v -> attribBuilder.Add(Xaml._TextDetailAttribKey, (v)) 
        match textColor with None -> () | Some v -> attribBuilder.Add(Xaml._TextColorAttribKey, (v)) 
        match detailColor with None -> () | Some v -> attribBuilder.Add(Xaml._TextDetailColorAttribKey, (v)) 
        match command with None -> () | Some v -> attribBuilder.Add(Xaml._TextCellCommandAttribKey, (v)) 
        match canExecute with None -> () | Some v -> attribBuilder.Add(Xaml._TextCellCanExecuteAttribKey, (v)) 
        match commandParameter with None -> () | Some v -> attribBuilder.Add(Xaml._CommandParameterAttribKey, (v)) 
        attribBuilder

    static member val _ProtoTextCell : ViewElement option = None with get, set

    static member val _CreateTextCell : (unit -> Xamarin.Forms.TextCell) = fun () -> 
            upcast (new Xamarin.Forms.TextCell())

    static member val _UpdateTextCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.TextCell) -> 
        let baseElement = (if Xaml._ProtoCell.IsNone then Xaml._ProtoCell <- Some (Xaml.Cell())); Xaml._ProtoCell.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
            if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextDetailAttribKey.KeyValue then 
                currTextDetailOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._TextDetailColorAttribKey.KeyValue then 
                currTextDetailColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._TextCellCommandAttribKey.KeyValue then 
                currTextCellCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
            if kvp.Key = Xaml._TextCellCanExecuteAttribKey.KeyValue then 
                currTextCellCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._CommandParameterAttribKey.KeyValue then 
                currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextAttribKey.KeyValue then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextDetailAttribKey.KeyValue then 
                    prevTextDetailOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextColorAttribKey.KeyValue then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._TextDetailColorAttribKey.KeyValue then 
                    prevTextDetailColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._TextCellCommandAttribKey.KeyValue then 
                    prevTextCellCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = Xaml._TextCellCanExecuteAttribKey.KeyValue then 
                    prevTextCellCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._CommandParameterAttribKey.KeyValue then 
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
    static member inline TextCell(?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildTextCell(0, ?text=text, ?detail=detail, ?textColor=textColor, ?detailColor=detailColor, ?command=command, ?canExecute=canExecute, ?commandParameter=commandParameter, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.TextCell>(Xaml._CreateTextCell, Xaml._UpdateTextCell, attribBuilder)

    /// Builds the attributes for a ToolbarItem in the view
    static member inline _BuildToolbarItem(attribCount: int, ?order: Xamarin.Forms.ToolbarItemOrder, ?priority: int, ?text: string, ?command: unit -> unit, ?commandParameter: System.Object, ?icon: string, ?classId: string, ?styleId: string) = 

        let attribCount = match order with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match priority with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildMenuItem(attribCount, ?text=text, ?command=command, ?commandParameter=commandParameter, ?icon=icon, ?classId=classId, ?styleId=styleId)
        match order with None -> () | Some v -> attribBuilder.Add(Xaml._OrderAttribKey, (v)) 
        match priority with None -> () | Some v -> attribBuilder.Add(Xaml._PriorityAttribKey, (v)) 
        attribBuilder

    static member val _ProtoToolbarItem : ViewElement option = None with get, set

    static member val _CreateToolbarItem : (unit -> Xamarin.Forms.ToolbarItem) = fun () -> 
            upcast (new Xamarin.Forms.ToolbarItem())

    static member val _UpdateToolbarItem = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ToolbarItem) -> 
        let baseElement = (if Xaml._ProtoMenuItem.IsNone then Xaml._ProtoMenuItem <- Some (Xaml.MenuItem())); Xaml._ProtoMenuItem.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevOrderOpt = ValueNone
        let mutable currOrderOpt = ValueNone
        let mutable prevPriorityOpt = ValueNone
        let mutable currPriorityOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._OrderAttribKey.KeyValue then 
                currOrderOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ToolbarItemOrder)
            if kvp.Key = Xaml._PriorityAttribKey.KeyValue then 
                currPriorityOpt <- ValueSome (kvp.Value :?> int)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._OrderAttribKey.KeyValue then 
                    prevOrderOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ToolbarItemOrder)
                if kvp.Key = Xaml._PriorityAttribKey.KeyValue then 
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
    static member inline ToolbarItem(?order: Xamarin.Forms.ToolbarItemOrder, ?priority: int, ?text: string, ?command: unit -> unit, ?commandParameter: System.Object, ?icon: string, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildToolbarItem(0, ?order=order, ?priority=priority, ?text=text, ?command=command, ?commandParameter=commandParameter, ?icon=icon, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ToolbarItem>(Xaml._CreateToolbarItem, Xaml._UpdateToolbarItem, attribBuilder)

    /// Builds the attributes for a ImageCell in the view
    static member inline _BuildImageCell(attribCount: int, ?imageSource: string, ?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match imageSource with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildTextCell(attribCount, ?text=text, ?detail=detail, ?textColor=textColor, ?detailColor=detailColor, ?command=command, ?canExecute=canExecute, ?commandParameter=commandParameter, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        match imageSource with None -> () | Some v -> attribBuilder.Add(Xaml._ImageSourceAttribKey, (v)) 
        attribBuilder

    static member val _ProtoImageCell : ViewElement option = None with get, set

    static member val _CreateImageCell : (unit -> Xamarin.Forms.ImageCell) = fun () -> 
            upcast (new Xamarin.Forms.ImageCell())

    static member val _UpdateImageCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ImageCell) -> 
        let baseElement = (if Xaml._ProtoTextCell.IsNone then Xaml._ProtoTextCell <- Some (Xaml.TextCell())); Xaml._ProtoTextCell.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevImageSourceOpt = ValueNone
        let mutable currImageSourceOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ImageSourceAttribKey.KeyValue then 
                currImageSourceOpt <- ValueSome (kvp.Value :?> string)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ImageSourceAttribKey.KeyValue then 
                    prevImageSourceOpt <- ValueSome (kvp.Value :?> string)
        match prevImageSourceOpt, currImageSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ImageSource <- makeImageSource  currValue
        | ValueSome _, ValueNone -> target.ImageSource <- null
        | ValueNone, ValueNone -> ()

    /// Describes a ImageCell in the view
    static member inline ImageCell(?imageSource: string, ?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildImageCell(0, ?imageSource=imageSource, ?text=text, ?detail=detail, ?textColor=textColor, ?detailColor=detailColor, ?command=command, ?canExecute=canExecute, ?commandParameter=commandParameter, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ImageCell>(Xaml._CreateImageCell, Xaml._UpdateImageCell, attribBuilder)

    /// Builds the attributes for a ViewCell in the view
    static member inline _BuildViewCell(attribCount: int, ?view: ViewElement, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match view with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        match view with None -> () | Some v -> attribBuilder.Add(Xaml._ViewAttribKey, (v)) 
        attribBuilder

    static member val _ProtoViewCell : ViewElement option = None with get, set

    static member val _CreateViewCell : (unit -> Xamarin.Forms.ViewCell) = fun () -> 
            upcast (new Xamarin.Forms.ViewCell())

    static member val _UpdateViewCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ViewCell) -> 
        let baseElement = (if Xaml._ProtoCell.IsNone then Xaml._ProtoCell <- Some (Xaml.Cell())); Xaml._ProtoCell.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevViewOpt = ValueNone
        let mutable currViewOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ViewAttribKey.KeyValue then 
                currViewOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ViewAttribKey.KeyValue then 
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
    static member inline ViewCell(?view: ViewElement, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildViewCell(0, ?view=view, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ViewCell>(Xaml._CreateViewCell, Xaml._UpdateViewCell, attribBuilder)

    /// Builds the attributes for a ListView in the view
    static member inline _BuildListView(attribCount: int, ?items: seq<ViewElement>, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?headerTemplate: Xamarin.Forms.DataTemplate, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: int option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: int -> unit, ?itemDisappearing: int -> unit, ?itemSelected: int option -> unit, ?itemTapped: int -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

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

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match items with None -> () | Some v -> attribBuilder.Add(Xaml._ListViewItemsAttribKey, (v)) 
        match footer with None -> () | Some v -> attribBuilder.Add(Xaml._FooterAttribKey, (v)) 
        match hasUnevenRows with None -> () | Some v -> attribBuilder.Add(Xaml._HasUnevenRowsAttribKey, (v)) 
        match header with None -> () | Some v -> attribBuilder.Add(Xaml._HeaderAttribKey, (v)) 
        match headerTemplate with None -> () | Some v -> attribBuilder.Add(Xaml._HeaderTemplateAttribKey, (v)) 
        match isGroupingEnabled with None -> () | Some v -> attribBuilder.Add(Xaml._IsGroupingEnabledAttribKey, (v)) 
        match isPullToRefreshEnabled with None -> () | Some v -> attribBuilder.Add(Xaml._IsPullToRefreshEnabledAttribKey, (v)) 
        match isRefreshing with None -> () | Some v -> attribBuilder.Add(Xaml._IsRefreshingAttribKey, (v)) 
        match refreshCommand with None -> () | Some v -> attribBuilder.Add(Xaml._RefreshCommandAttribKey, makeCommand(v)) 
        match rowHeight with None -> () | Some v -> attribBuilder.Add(Xaml._RowHeightAttribKey, (v)) 
        match selectedItem with None -> () | Some v -> attribBuilder.Add(Xaml._ListView_SelectedItemAttribKey, (v)) 
        match separatorVisibility with None -> () | Some v -> attribBuilder.Add(Xaml._ListView_SeparatorVisibilityAttribKey, (v)) 
        match separatorColor with None -> () | Some v -> attribBuilder.Add(Xaml._ListView_SeparatorColorAttribKey, (v)) 
        match itemAppearing with None -> () | Some v -> attribBuilder.Add(Xaml._ListView_ItemAppearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v)) 
        match itemDisappearing with None -> () | Some v -> attribBuilder.Add(Xaml._ListView_ItemDisappearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v)) 
        match itemSelected with None -> () | Some v -> attribBuilder.Add(Xaml._ListView_ItemSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(v)) 
        match itemTapped with None -> () | Some v -> attribBuilder.Add(Xaml._ListView_ItemTappedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v)) 
        match refreshing with None -> () | Some v -> attribBuilder.Add(Xaml._ListView_RefreshingAttribKey, (fun f -> System.EventHandler(fun sender args -> f ()))(v)) 
        attribBuilder

    static member val _ProtoListView : ViewElement option = None with get, set

    static member val _CreateListView : (unit -> Xamarin.Forms.ListView) = fun () -> 
            upcast (new Elmish.XamarinForms.DynamicViews.CustomListView())

    static member val _UpdateListView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ListView) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
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
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ListViewItemsAttribKey.KeyValue then 
                currListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
            if kvp.Key = Xaml._FooterAttribKey.KeyValue then 
                currFooterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._HasUnevenRowsAttribKey.KeyValue then 
                currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._HeaderAttribKey.KeyValue then 
                currHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._HeaderTemplateAttribKey.KeyValue then 
                currHeaderTemplateOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.DataTemplate)
            if kvp.Key = Xaml._IsGroupingEnabledAttribKey.KeyValue then 
                currIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsPullToRefreshEnabledAttribKey.KeyValue then 
                currIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsRefreshingAttribKey.KeyValue then 
                currIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._RefreshCommandAttribKey.KeyValue then 
                currRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = Xaml._RowHeightAttribKey.KeyValue then 
                currRowHeightOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._ListView_SelectedItemAttribKey.KeyValue then 
                currListView_SelectedItemOpt <- ValueSome (kvp.Value :?> int option)
            if kvp.Key = Xaml._ListView_SeparatorVisibilityAttribKey.KeyValue then 
                currListView_SeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
            if kvp.Key = Xaml._ListView_SeparatorColorAttribKey.KeyValue then 
                currListView_SeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._ListView_ItemAppearingAttribKey.KeyValue then 
                currListView_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = Xaml._ListView_ItemDisappearingAttribKey.KeyValue then 
                currListView_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = Xaml._ListView_ItemSelectedAttribKey.KeyValue then 
                currListView_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
            if kvp.Key = Xaml._ListView_ItemTappedAttribKey.KeyValue then 
                currListView_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
            if kvp.Key = Xaml._ListView_RefreshingAttribKey.KeyValue then 
                currListView_RefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ListViewItemsAttribKey.KeyValue then 
                    prevListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
                if kvp.Key = Xaml._FooterAttribKey.KeyValue then 
                    prevFooterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._HasUnevenRowsAttribKey.KeyValue then 
                    prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._HeaderAttribKey.KeyValue then 
                    prevHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._HeaderTemplateAttribKey.KeyValue then 
                    prevHeaderTemplateOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.DataTemplate)
                if kvp.Key = Xaml._IsGroupingEnabledAttribKey.KeyValue then 
                    prevIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsPullToRefreshEnabledAttribKey.KeyValue then 
                    prevIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsRefreshingAttribKey.KeyValue then 
                    prevIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._RefreshCommandAttribKey.KeyValue then 
                    prevRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml._RowHeightAttribKey.KeyValue then 
                    prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._ListView_SelectedItemAttribKey.KeyValue then 
                    prevListView_SelectedItemOpt <- ValueSome (kvp.Value :?> int option)
                if kvp.Key = Xaml._ListView_SeparatorVisibilityAttribKey.KeyValue then 
                    prevListView_SeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
                if kvp.Key = Xaml._ListView_SeparatorColorAttribKey.KeyValue then 
                    prevListView_SeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._ListView_ItemAppearingAttribKey.KeyValue then 
                    prevListView_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml._ListView_ItemDisappearingAttribKey.KeyValue then 
                    prevListView_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml._ListView_ItemSelectedAttribKey.KeyValue then 
                    prevListView_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                if kvp.Key = Xaml._ListView_ItemTappedAttribKey.KeyValue then 
                    prevListView_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
                if kvp.Key = Xaml._ListView_RefreshingAttribKey.KeyValue then 
                    prevListView_RefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
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
        | _, ValueSome currValue -> target.SelectedItem <- (function None -> null | Some i -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListElementData<ViewElement>> in if i >= 0 && i < items.Count then items.[i] else null)  currValue
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

    /// Describes a ListView in the view
    static member inline ListView(?items: seq<ViewElement>, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?headerTemplate: Xamarin.Forms.DataTemplate, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: int option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: int -> unit, ?itemDisappearing: int -> unit, ?itemSelected: int option -> unit, ?itemTapped: int -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildListView(0, ?items=items, ?footer=footer, ?hasUnevenRows=hasUnevenRows, ?header=header, ?headerTemplate=headerTemplate, ?isGroupingEnabled=isGroupingEnabled, ?isPullToRefreshEnabled=isPullToRefreshEnabled, ?isRefreshing=isRefreshing, ?refreshCommand=refreshCommand, ?rowHeight=rowHeight, ?selectedItem=selectedItem, ?separatorVisibility=separatorVisibility, ?separatorColor=separatorColor, ?itemAppearing=itemAppearing, ?itemDisappearing=itemDisappearing, ?itemSelected=itemSelected, ?itemTapped=itemTapped, ?refreshing=refreshing, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ListView>(Xaml._CreateListView, Xaml._UpdateListView, attribBuilder)

    /// Builds the attributes for a ListViewGrouped in the view
    static member inline _BuildListViewGrouped(attribCount: int, ?items: (ViewElement * ViewElement list) list, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: (int * int) option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: int * int -> unit, ?itemDisappearing: int * int -> unit, ?itemSelected: (int * int) option -> unit, ?itemTapped: int * int -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match items with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match footer with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasUnevenRows with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match header with Some _ -> attribCount + 1 | None -> attribCount
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

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match items with None -> () | Some v -> attribBuilder.Add(Xaml._ListViewGrouped_ItemsSourceAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(v)) 
        match footer with None -> () | Some v -> attribBuilder.Add(Xaml._FooterAttribKey, (v)) 
        match hasUnevenRows with None -> () | Some v -> attribBuilder.Add(Xaml._HasUnevenRowsAttribKey, (v)) 
        match header with None -> () | Some v -> attribBuilder.Add(Xaml._HeaderAttribKey, (v)) 
        match isGroupingEnabled with None -> () | Some v -> attribBuilder.Add(Xaml._IsGroupingEnabledAttribKey, (v)) 
        match isPullToRefreshEnabled with None -> () | Some v -> attribBuilder.Add(Xaml._IsPullToRefreshEnabledAttribKey, (v)) 
        match isRefreshing with None -> () | Some v -> attribBuilder.Add(Xaml._IsRefreshingAttribKey, (v)) 
        match refreshCommand with None -> () | Some v -> attribBuilder.Add(Xaml._RefreshCommandAttribKey, makeCommand(v)) 
        match rowHeight with None -> () | Some v -> attribBuilder.Add(Xaml._RowHeightAttribKey, (v)) 
        match selectedItem with None -> () | Some v -> attribBuilder.Add(Xaml._ListViewGrouped_SelectedItemAttribKey, (v)) 
        match separatorVisibility with None -> () | Some v -> attribBuilder.Add(Xaml._SeparatorVisibilityAttribKey, (v)) 
        match separatorColor with None -> () | Some v -> attribBuilder.Add(Xaml._SeparatorColorAttribKey, (v)) 
        match itemAppearing with None -> () | Some v -> attribBuilder.Add(Xaml._ListViewGrouped_ItemAppearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v)) 
        match itemDisappearing with None -> () | Some v -> attribBuilder.Add(Xaml._ListViewGrouped_ItemDisappearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v)) 
        match itemSelected with None -> () | Some v -> attribBuilder.Add(Xaml._ListViewGrouped_ItemSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(v)) 
        match itemTapped with None -> () | Some v -> attribBuilder.Add(Xaml._ListViewGrouped_ItemTappedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v)) 
        match refreshing with None -> () | Some v -> attribBuilder.Add(Xaml._RefreshingAttribKey, (fun f -> System.EventHandler(fun sender args -> f ()))(v)) 
        attribBuilder

    static member val _ProtoListViewGrouped : ViewElement option = None with get, set

    static member val _CreateListViewGrouped : (unit -> Xamarin.Forms.ListView) = fun () -> 
            upcast (new Elmish.XamarinForms.DynamicViews.CustomGroupListView())

    static member val _UpdateListViewGrouped = fun (prevOpt: ViewElement voption) (curr: ViewElement) (target: Xamarin.Forms.ListView) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr (box target)
        let mutable prevListViewGrouped_ItemsSourceOpt = ValueNone
        let mutable currListViewGrouped_ItemsSourceOpt = ValueNone
        let mutable prevFooterOpt = ValueNone
        let mutable currFooterOpt = ValueNone
        let mutable prevHasUnevenRowsOpt = ValueNone
        let mutable currHasUnevenRowsOpt = ValueNone
        let mutable prevHeaderOpt = ValueNone
        let mutable currHeaderOpt = ValueNone
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
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ListViewGrouped_ItemsSourceAttribKey.KeyValue then 
                currListViewGrouped_ItemsSourceOpt <- ValueSome (kvp.Value :?> (ViewElement * ViewElement[])[])
            if kvp.Key = Xaml._FooterAttribKey.KeyValue then 
                currFooterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._HasUnevenRowsAttribKey.KeyValue then 
                currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._HeaderAttribKey.KeyValue then 
                currHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._IsGroupingEnabledAttribKey.KeyValue then 
                currIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsPullToRefreshEnabledAttribKey.KeyValue then 
                currIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsRefreshingAttribKey.KeyValue then 
                currIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._RefreshCommandAttribKey.KeyValue then 
                currRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = Xaml._RowHeightAttribKey.KeyValue then 
                currRowHeightOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._ListViewGrouped_SelectedItemAttribKey.KeyValue then 
                currListViewGrouped_SelectedItemOpt <- ValueSome (kvp.Value :?> (int * int) option)
            if kvp.Key = Xaml._SeparatorVisibilityAttribKey.KeyValue then 
                currSeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
            if kvp.Key = Xaml._SeparatorColorAttribKey.KeyValue then 
                currSeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._ListViewGrouped_ItemAppearingAttribKey.KeyValue then 
                currListViewGrouped_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = Xaml._ListViewGrouped_ItemDisappearingAttribKey.KeyValue then 
                currListViewGrouped_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = Xaml._ListViewGrouped_ItemSelectedAttribKey.KeyValue then 
                currListViewGrouped_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
            if kvp.Key = Xaml._ListViewGrouped_ItemTappedAttribKey.KeyValue then 
                currListViewGrouped_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
            if kvp.Key = Xaml._RefreshingAttribKey.KeyValue then 
                currRefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ListViewGrouped_ItemsSourceAttribKey.KeyValue then 
                    prevListViewGrouped_ItemsSourceOpt <- ValueSome (kvp.Value :?> (ViewElement * ViewElement[])[])
                if kvp.Key = Xaml._FooterAttribKey.KeyValue then 
                    prevFooterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._HasUnevenRowsAttribKey.KeyValue then 
                    prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._HeaderAttribKey.KeyValue then 
                    prevHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._IsGroupingEnabledAttribKey.KeyValue then 
                    prevIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsPullToRefreshEnabledAttribKey.KeyValue then 
                    prevIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsRefreshingAttribKey.KeyValue then 
                    prevIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._RefreshCommandAttribKey.KeyValue then 
                    prevRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml._RowHeightAttribKey.KeyValue then 
                    prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._ListViewGrouped_SelectedItemAttribKey.KeyValue then 
                    prevListViewGrouped_SelectedItemOpt <- ValueSome (kvp.Value :?> (int * int) option)
                if kvp.Key = Xaml._SeparatorVisibilityAttribKey.KeyValue then 
                    prevSeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
                if kvp.Key = Xaml._SeparatorColorAttribKey.KeyValue then 
                    prevSeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._ListViewGrouped_ItemAppearingAttribKey.KeyValue then 
                    prevListViewGrouped_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml._ListViewGrouped_ItemDisappearingAttribKey.KeyValue then 
                    prevListViewGrouped_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml._ListViewGrouped_ItemSelectedAttribKey.KeyValue then 
                    prevListViewGrouped_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                if kvp.Key = Xaml._ListViewGrouped_ItemTappedAttribKey.KeyValue then 
                    prevListViewGrouped_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
                if kvp.Key = Xaml._RefreshingAttribKey.KeyValue then 
                    prevRefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        updateListViewGroupedItems prevListViewGrouped_ItemsSourceOpt currListViewGrouped_ItemsSourceOpt target
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
        match prevListViewGrouped_SelectedItemOpt, currListViewGrouped_SelectedItemOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.SelectedItem <- (function None -> null | Some (i,j) -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListGroupData<ViewElement>> in (if i >= 0 && i < items.Count then (let items2 = items.[i] in if j >= 0 && j < items2.Count then items2.[j] else null) else null))  currValue
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

    /// Describes a ListViewGrouped in the view
    static member inline ListViewGrouped(?items: (ViewElement * ViewElement list) list, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: (int * int) option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: int * int -> unit, ?itemDisappearing: int * int -> unit, ?itemSelected: (int * int) option -> unit, ?itemTapped: int * int -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildListViewGrouped(0, ?items=items, ?footer=footer, ?hasUnevenRows=hasUnevenRows, ?header=header, ?isGroupingEnabled=isGroupingEnabled, ?isPullToRefreshEnabled=isPullToRefreshEnabled, ?isRefreshing=isRefreshing, ?refreshCommand=refreshCommand, ?rowHeight=rowHeight, ?selectedItem=selectedItem, ?separatorVisibility=separatorVisibility, ?separatorColor=separatorColor, ?itemAppearing=itemAppearing, ?itemDisappearing=itemDisappearing, ?itemSelected=itemSelected, ?itemTapped=itemTapped, ?refreshing=refreshing, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        ViewElement.Create<Xamarin.Forms.ListView>(Xaml._CreateListViewGrouped, Xaml._UpdateListViewGrouped, attribBuilder)

[<AutoOpen>]
module ViewElementExtensions = 

    type ViewElement with

        /// Adjusts the ClassId property in the visual element
        member x.ClassId(value: string) = x.WithAttribute(Xaml._ClassIdAttribKey, (value))

        /// Adjusts the StyleId property in the visual element
        member x.StyleId(value: string) = x.WithAttribute(Xaml._StyleIdAttribKey, (value))

        /// Adjusts the AnchorX property in the visual element
        member x.AnchorX(value: double) = x.WithAttribute(Xaml._AnchorXAttribKey, (value))

        /// Adjusts the AnchorY property in the visual element
        member x.AnchorY(value: double) = x.WithAttribute(Xaml._AnchorYAttribKey, (value))

        /// Adjusts the BackgroundColor property in the visual element
        member x.BackgroundColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._BackgroundColorAttribKey, (value))

        /// Adjusts the HeightRequest property in the visual element
        member x.HeightRequest(value: double) = x.WithAttribute(Xaml._HeightRequestAttribKey, (value))

        /// Adjusts the InputTransparent property in the visual element
        member x.InputTransparent(value: bool) = x.WithAttribute(Xaml._InputTransparentAttribKey, (value))

        /// Adjusts the IsEnabled property in the visual element
        member x.IsEnabled(value: bool) = x.WithAttribute(Xaml._IsEnabledAttribKey, (value))

        /// Adjusts the IsVisible property in the visual element
        member x.IsVisible(value: bool) = x.WithAttribute(Xaml._IsVisibleAttribKey, (value))

        /// Adjusts the MinimumHeightRequest property in the visual element
        member x.MinimumHeightRequest(value: double) = x.WithAttribute(Xaml._MinimumHeightRequestAttribKey, (value))

        /// Adjusts the MinimumWidthRequest property in the visual element
        member x.MinimumWidthRequest(value: double) = x.WithAttribute(Xaml._MinimumWidthRequestAttribKey, (value))

        /// Adjusts the Opacity property in the visual element
        member x.Opacity(value: double) = x.WithAttribute(Xaml._OpacityAttribKey, (value))

        /// Adjusts the Rotation property in the visual element
        member x.Rotation(value: double) = x.WithAttribute(Xaml._RotationAttribKey, (value))

        /// Adjusts the RotationX property in the visual element
        member x.RotationX(value: double) = x.WithAttribute(Xaml._RotationXAttribKey, (value))

        /// Adjusts the RotationY property in the visual element
        member x.RotationY(value: double) = x.WithAttribute(Xaml._RotationYAttribKey, (value))

        /// Adjusts the Scale property in the visual element
        member x.Scale(value: double) = x.WithAttribute(Xaml._ScaleAttribKey, (value))

        /// Adjusts the Style property in the visual element
        member x.Style(value: Xamarin.Forms.Style) = x.WithAttribute(Xaml._StyleAttribKey, (value))

        /// Adjusts the TranslationX property in the visual element
        member x.TranslationX(value: double) = x.WithAttribute(Xaml._TranslationXAttribKey, (value))

        /// Adjusts the TranslationY property in the visual element
        member x.TranslationY(value: double) = x.WithAttribute(Xaml._TranslationYAttribKey, (value))

        /// Adjusts the WidthRequest property in the visual element
        member x.WidthRequest(value: double) = x.WithAttribute(Xaml._WidthRequestAttribKey, (value))

        /// Adjusts the Resources property in the visual element
        member x.Resources(value: (string * obj) list) = x.WithAttribute(Xaml._ResourcesAttribKey, (value))

        /// Adjusts the Styles property in the visual element
        member x.Styles(value: Xamarin.Forms.Style list) = x.WithAttribute(Xaml._StylesAttribKey, (value))

        /// Adjusts the StyleSheets property in the visual element
        member x.StyleSheets(value: Xamarin.Forms.StyleSheets.StyleSheet list) = x.WithAttribute(Xaml._StyleSheetsAttribKey, (value))

        /// Adjusts the HorizontalOptions property in the visual element
        member x.HorizontalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttribute(Xaml._HorizontalOptionsAttribKey, (value))

        /// Adjusts the VerticalOptions property in the visual element
        member x.VerticalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttribute(Xaml._VerticalOptionsAttribKey, (value))

        /// Adjusts the Margin property in the visual element
        member x.Margin(value: obj) = x.WithAttribute(Xaml._MarginAttribKey, makeThickness(value))

        /// Adjusts the GestureRecognizers property in the visual element
        member x.GestureRecognizers(value: ViewElement list) = x.WithAttribute(Xaml._GestureRecognizersAttribKey, Array.ofList(value))

        /// Adjusts the TouchPoints property in the visual element
        member x.TouchPoints(value: int) = x.WithAttribute(Xaml._TouchPointsAttribKey, (value))

        /// Adjusts the PanUpdated property in the visual element
        member x.PanUpdated(value: Xamarin.Forms.PanUpdatedEventArgs -> unit) = x.WithAttribute(Xaml._PanUpdatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Command property in the visual element
        member x.Command(value: unit -> unit) = x.WithAttribute(Xaml._CommandAttribKey, makeCommand(value))

        /// Adjusts the NumberOfTapsRequired property in the visual element
        member x.NumberOfTapsRequired(value: int) = x.WithAttribute(Xaml._NumberOfTapsRequiredAttribKey, (value))

        /// Adjusts the NumberOfClicksRequired property in the visual element
        member x.NumberOfClicksRequired(value: int) = x.WithAttribute(Xaml._NumberOfClicksRequiredAttribKey, (value))

        /// Adjusts the Buttons property in the visual element
        member x.Buttons(value: Xamarin.Forms.ButtonsMask) = x.WithAttribute(Xaml._ButtonsAttribKey, (value))

        /// Adjusts the IsPinching property in the visual element
        member x.IsPinching(value: bool) = x.WithAttribute(Xaml._IsPinchingAttribKey, (value))

        /// Adjusts the PinchUpdated property in the visual element
        member x.PinchUpdated(value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) = x.WithAttribute(Xaml._PinchUpdatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Color property in the visual element
        member x.Color(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._ColorAttribKey, (value))

        /// Adjusts the IsRunning property in the visual element
        member x.IsRunning(value: bool) = x.WithAttribute(Xaml._IsRunningAttribKey, (value))

        /// Adjusts the Progress property in the visual element
        member x.Progress(value: double) = x.WithAttribute(Xaml._ProgressAttribKey, (value))

        /// Adjusts the IsClippedToBounds property in the visual element
        member x.IsClippedToBounds(value: bool) = x.WithAttribute(Xaml._IsClippedToBoundsAttribKey, (value))

        /// Adjusts the Padding property in the visual element
        member x.Padding(value: obj) = x.WithAttribute(Xaml._PaddingAttribKey, makeThickness(value))

        /// Adjusts the Content property in the visual element
        member x.Content(value: ViewElement) = x.WithAttribute(Xaml._ContentAttribKey, (value))

        /// Adjusts the ScrollOrientation property in the visual element
        member x.ScrollOrientation(value: Xamarin.Forms.ScrollOrientation) = x.WithAttribute(Xaml._ScrollOrientationAttribKey, (value))

        /// Adjusts the CancelButtonColor property in the visual element
        member x.CancelButtonColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._CancelButtonColorAttribKey, (value))

        /// Adjusts the FontFamily property in the visual element
        member x.FontFamily(value: string) = x.WithAttribute(Xaml._FontFamilyAttribKey, (value))

        /// Adjusts the FontAttributes property in the visual element
        member x.FontAttributes(value: Xamarin.Forms.FontAttributes) = x.WithAttribute(Xaml._FontAttributesAttribKey, (value))

        /// Adjusts the FontSize property in the visual element
        member x.FontSize(value: obj) = x.WithAttribute(Xaml._FontSizeAttribKey, makeFontSize(value))

        /// Adjusts the HorizontalTextAlignment property in the visual element
        member x.HorizontalTextAlignment(value: Xamarin.Forms.TextAlignment) = x.WithAttribute(Xaml._HorizontalTextAlignmentAttribKey, (value))

        /// Adjusts the Placeholder property in the visual element
        member x.Placeholder(value: string) = x.WithAttribute(Xaml._PlaceholderAttribKey, (value))

        /// Adjusts the PlaceholderColor property in the visual element
        member x.PlaceholderColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._PlaceholderColorAttribKey, (value))

        /// Adjusts the SearchBarCommand property in the visual element
        member x.SearchBarCommand(value: string -> unit) = x.WithAttribute(Xaml._SearchBarCommandAttribKey, (value))

        /// Adjusts the SearchBarCanExecute property in the visual element
        member x.SearchBarCanExecute(value: bool) = x.WithAttribute(Xaml._SearchBarCanExecuteAttribKey, (value))

        /// Adjusts the Text property in the visual element
        member x.Text(value: string) = x.WithAttribute(Xaml._TextAttribKey, (value))

        /// Adjusts the TextColor property in the visual element
        member x.TextColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._TextColorAttribKey, (value))

        /// Adjusts the ButtonCommand property in the visual element
        member x.ButtonCommand(value: unit -> unit) = x.WithAttribute(Xaml._ButtonCommandAttribKey, (value))

        /// Adjusts the ButtonCanExecute property in the visual element
        member x.ButtonCanExecute(value: bool) = x.WithAttribute(Xaml._ButtonCanExecuteAttribKey, (value))

        /// Adjusts the BorderColor property in the visual element
        member x.BorderColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._BorderColorAttribKey, (value))

        /// Adjusts the BorderWidth property in the visual element
        member x.BorderWidth(value: double) = x.WithAttribute(Xaml._BorderWidthAttribKey, (value))

        /// Adjusts the CommandParameter property in the visual element
        member x.CommandParameter(value: System.Object) = x.WithAttribute(Xaml._CommandParameterAttribKey, (value))

        /// Adjusts the ContentLayout property in the visual element
        member x.ContentLayout(value: Xamarin.Forms.Button.ButtonContentLayout) = x.WithAttribute(Xaml._ContentLayoutAttribKey, (value))

        /// Adjusts the ButtonCornerRadius property in the visual element
        member x.ButtonCornerRadius(value: int) = x.WithAttribute(Xaml._ButtonCornerRadiusAttribKey, (value))

        /// Adjusts the ButtonImageSource property in the visual element
        member x.ButtonImageSource(value: string) = x.WithAttribute(Xaml._ButtonImageSourceAttribKey, (value))

        /// Adjusts the Minimum property in the visual element
        member x.Minimum(value: double) = x.WithAttribute(Xaml._MinimumAttribKey, (value))

        /// Adjusts the Maximum property in the visual element
        member x.Maximum(value: double) = x.WithAttribute(Xaml._MaximumAttribKey, (value))

        /// Adjusts the Value property in the visual element
        member x.Value(value: double) = x.WithAttribute(Xaml._ValueAttribKey, (value))

        /// Adjusts the ValueChanged property in the visual element
        member x.ValueChanged(value: Xamarin.Forms.ValueChangedEventArgs -> unit) = x.WithAttribute(Xaml._ValueChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Increment property in the visual element
        member x.Increment(value: double) = x.WithAttribute(Xaml._IncrementAttribKey, (value))

        /// Adjusts the IsToggled property in the visual element
        member x.IsToggled(value: bool) = x.WithAttribute(Xaml._IsToggledAttribKey, (value))

        /// Adjusts the Toggled property in the visual element
        member x.Toggled(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttribute(Xaml._ToggledAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Height property in the visual element
        member x.Height(value: double) = x.WithAttribute(Xaml._HeightAttribKey, (value))

        /// Adjusts the On property in the visual element
        member x.On(value: bool) = x.WithAttribute(Xaml._OnAttribKey, (value))

        /// Adjusts the OnChanged property in the visual element
        member x.OnChanged(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttribute(Xaml._OnChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Intent property in the visual element
        member x.Intent(value: Xamarin.Forms.TableIntent) = x.WithAttribute(Xaml._IntentAttribKey, (value))

        /// Adjusts the HasUnevenRows property in the visual element
        member x.HasUnevenRows(value: bool) = x.WithAttribute(Xaml._HasUnevenRowsAttribKey, (value))

        /// Adjusts the RowHeight property in the visual element
        member x.RowHeight(value: int) = x.WithAttribute(Xaml._RowHeightAttribKey, (value))

        /// Adjusts the TableRoot property in the visual element
        member x.TableRoot(value: (string * ViewElement list) list) = x.WithAttribute(Xaml._TableRootAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(value))

        /// Adjusts the RowDefinitionHeight property in the visual element
        member x.RowDefinitionHeight(value: obj) = x.WithAttribute(Xaml._RowDefinitionHeightAttribKey, makeGridLength(value))

        /// Adjusts the ColumnDefinitionWidth property in the visual element
        member x.ColumnDefinitionWidth(value: obj) = x.WithAttribute(Xaml._ColumnDefinitionWidthAttribKey, makeGridLength(value))

        /// Adjusts the GridRowDefinitions property in the visual element
        member x.GridRowDefinitions(value: obj list) = x.WithAttribute(Xaml._GridRowDefinitionsAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(value))

        /// Adjusts the GridColumnDefinitions property in the visual element
        member x.GridColumnDefinitions(value: obj list) = x.WithAttribute(Xaml._GridColumnDefinitionsAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(value))

        /// Adjusts the RowSpacing property in the visual element
        member x.RowSpacing(value: double) = x.WithAttribute(Xaml._RowSpacingAttribKey, (value))

        /// Adjusts the ColumnSpacing property in the visual element
        member x.ColumnSpacing(value: double) = x.WithAttribute(Xaml._ColumnSpacingAttribKey, (value))

        /// Adjusts the Children property in the visual element
        member x.Children(value: ViewElement list) = x.WithAttribute(Xaml._ChildrenAttribKey, Array.ofList(value))

        /// Adjusts the GridRow property in the visual element
        member x.GridRow(value: int) = x.WithAttribute(Xaml._GridRowAttribKey, (value))

        /// Adjusts the GridRowSpan property in the visual element
        member x.GridRowSpan(value: int) = x.WithAttribute(Xaml._GridRowSpanAttribKey, (value))

        /// Adjusts the GridColumn property in the visual element
        member x.GridColumn(value: int) = x.WithAttribute(Xaml._GridColumnAttribKey, (value))

        /// Adjusts the GridColumnSpan property in the visual element
        member x.GridColumnSpan(value: int) = x.WithAttribute(Xaml._GridColumnSpanAttribKey, (value))

        /// Adjusts the LayoutBounds property in the visual element
        member x.LayoutBounds(value: Xamarin.Forms.Rectangle) = x.WithAttribute(Xaml._LayoutBoundsAttribKey, (value))

        /// Adjusts the LayoutFlags property in the visual element
        member x.LayoutFlags(value: Xamarin.Forms.AbsoluteLayoutFlags) = x.WithAttribute(Xaml._LayoutFlagsAttribKey, (value))

        /// Adjusts the BoundsConstraint property in the visual element
        member x.BoundsConstraint(value: Xamarin.Forms.BoundsConstraint) = x.WithAttribute(Xaml._BoundsConstraintAttribKey, (value))

        /// Adjusts the HeightConstraint property in the visual element
        member x.HeightConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(Xaml._HeightConstraintAttribKey, (value))

        /// Adjusts the WidthConstraint property in the visual element
        member x.WidthConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(Xaml._WidthConstraintAttribKey, (value))

        /// Adjusts the XConstraint property in the visual element
        member x.XConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(Xaml._XConstraintAttribKey, (value))

        /// Adjusts the YConstraint property in the visual element
        member x.YConstraint(value: Xamarin.Forms.Constraint) = x.WithAttribute(Xaml._YConstraintAttribKey, (value))

        /// Adjusts the AlignContent property in the visual element
        member x.AlignContent(value: Xamarin.Forms.FlexAlignContent) = x.WithAttribute(Xaml._AlignContentAttribKey, (value))

        /// Adjusts the AlignItems property in the visual element
        member x.AlignItems(value: Xamarin.Forms.FlexAlignItems) = x.WithAttribute(Xaml._AlignItemsAttribKey, (value))

        /// Adjusts the Direction property in the visual element
        member x.Direction(value: Xamarin.Forms.FlexDirection) = x.WithAttribute(Xaml._DirectionAttribKey, (value))

        /// Adjusts the Position property in the visual element
        member x.Position(value: Xamarin.Forms.FlexPosition) = x.WithAttribute(Xaml._PositionAttribKey, (value))

        /// Adjusts the Wrap property in the visual element
        member x.Wrap(value: Xamarin.Forms.FlexWrap) = x.WithAttribute(Xaml._WrapAttribKey, (value))

        /// Adjusts the JustifyContent property in the visual element
        member x.JustifyContent(value: Xamarin.Forms.FlexJustify) = x.WithAttribute(Xaml._JustifyContentAttribKey, (value))

        /// Adjusts the FlexAlignSelf property in the visual element
        member x.FlexAlignSelf(value: Xamarin.Forms.FlexAlignSelf) = x.WithAttribute(Xaml._FlexAlignSelfAttribKey, (value))

        /// Adjusts the FlexOrder property in the visual element
        member x.FlexOrder(value: int) = x.WithAttribute(Xaml._FlexOrderAttribKey, (value))

        /// Adjusts the FlexBasis property in the visual element
        member x.FlexBasis(value: Xamarin.Forms.FlexBasis) = x.WithAttribute(Xaml._FlexBasisAttribKey, (value))

        /// Adjusts the FlexGrow property in the visual element
        member x.FlexGrow(value: double) = x.WithAttribute(Xaml._FlexGrowAttribKey, single(value))

        /// Adjusts the FlexShrink property in the visual element
        member x.FlexShrink(value: double) = x.WithAttribute(Xaml._FlexShrinkAttribKey, single(value))

        /// Adjusts the Date property in the visual element
        member x.Date(value: System.DateTime) = x.WithAttribute(Xaml._DateAttribKey, (value))

        /// Adjusts the Format property in the visual element
        member x.Format(value: string) = x.WithAttribute(Xaml._FormatAttribKey, (value))

        /// Adjusts the MinimumDate property in the visual element
        member x.MinimumDate(value: System.DateTime) = x.WithAttribute(Xaml._MinimumDateAttribKey, (value))

        /// Adjusts the MaximumDate property in the visual element
        member x.MaximumDate(value: System.DateTime) = x.WithAttribute(Xaml._MaximumDateAttribKey, (value))

        /// Adjusts the DateSelected property in the visual element
        member x.DateSelected(value: Xamarin.Forms.DateChangedEventArgs -> unit) = x.WithAttribute(Xaml._DateSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the PickerItemsSource property in the visual element
        member x.PickerItemsSource(value: seq<'T>) = x.WithAttribute(Xaml._PickerItemsSourceAttribKey, seqToIListUntyped(value))

        /// Adjusts the SelectedIndex property in the visual element
        member x.SelectedIndex(value: int) = x.WithAttribute(Xaml._SelectedIndexAttribKey, (value))

        /// Adjusts the Title property in the visual element
        member x.Title(value: string) = x.WithAttribute(Xaml._TitleAttribKey, (value))

        /// Adjusts the SelectedIndexChanged property in the visual element
        member x.SelectedIndexChanged(value: (int * 'T option) -> unit) = x.WithAttribute(Xaml._SelectedIndexChangedAttribKey, (fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(value))

        /// Adjusts the FrameCornerRadius property in the visual element
        member x.FrameCornerRadius(value: double) = x.WithAttribute(Xaml._FrameCornerRadiusAttribKey, single(value))

        /// Adjusts the HasShadow property in the visual element
        member x.HasShadow(value: bool) = x.WithAttribute(Xaml._HasShadowAttribKey, (value))

        /// Adjusts the ImageSource property in the visual element
        member x.ImageSource(value: string) = x.WithAttribute(Xaml._ImageSourceAttribKey, (value))

        /// Adjusts the Aspect property in the visual element
        member x.Aspect(value: Xamarin.Forms.Aspect) = x.WithAttribute(Xaml._AspectAttribKey, (value))

        /// Adjusts the IsOpaque property in the visual element
        member x.IsOpaque(value: bool) = x.WithAttribute(Xaml._IsOpaqueAttribKey, (value))

        /// Adjusts the Keyboard property in the visual element
        member x.Keyboard(value: Xamarin.Forms.Keyboard) = x.WithAttribute(Xaml._KeyboardAttribKey, (value))

        /// Adjusts the EditorCompleted property in the visual element
        member x.EditorCompleted(value: string -> unit) = x.WithAttribute(Xaml._EditorCompletedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(value))

        /// Adjusts the TextChanged property in the visual element
        member x.TextChanged(value: Xamarin.Forms.TextChangedEventArgs -> unit) = x.WithAttribute(Xaml._TextChangedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the IsPassword property in the visual element
        member x.IsPassword(value: bool) = x.WithAttribute(Xaml._IsPasswordAttribKey, (value))

        /// Adjusts the EntryCompleted property in the visual element
        member x.EntryCompleted(value: string -> unit) = x.WithAttribute(Xaml._EntryCompletedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(value))

        /// Adjusts the Label property in the visual element
        member x.Label(value: string) = x.WithAttribute(Xaml._LabelAttribKey, (value))

        /// Adjusts the VerticalTextAlignment property in the visual element
        member x.VerticalTextAlignment(value: Xamarin.Forms.TextAlignment) = x.WithAttribute(Xaml._VerticalTextAlignmentAttribKey, (value))

        /// Adjusts the FormattedText property in the visual element
        member x.FormattedText(value: ViewElement) = x.WithAttribute(Xaml._FormattedTextAttribKey, (value))

        /// Adjusts the StackOrientation property in the visual element
        member x.StackOrientation(value: Xamarin.Forms.StackOrientation) = x.WithAttribute(Xaml._StackOrientationAttribKey, (value))

        /// Adjusts the Spacing property in the visual element
        member x.Spacing(value: double) = x.WithAttribute(Xaml._SpacingAttribKey, (value))

        /// Adjusts the ForegroundColor property in the visual element
        member x.ForegroundColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._ForegroundColorAttribKey, (value))

        /// Adjusts the PropertyChanged property in the visual element
        member x.PropertyChanged(value: System.ComponentModel.PropertyChangedEventArgs -> unit) = x.WithAttribute(Xaml._PropertyChangedAttribKey, (fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Spans property in the visual element
        member x.Spans(value: ViewElement[]) = x.WithAttribute(Xaml._SpansAttribKey, (value))

        /// Adjusts the Time property in the visual element
        member x.Time(value: System.TimeSpan) = x.WithAttribute(Xaml._TimeAttribKey, (value))

        /// Adjusts the WebSource property in the visual element
        member x.WebSource(value: Xamarin.Forms.WebViewSource) = x.WithAttribute(Xaml._WebSourceAttribKey, (value))

        /// Adjusts the Navigated property in the visual element
        member x.Navigated(value: Xamarin.Forms.WebNavigatedEventArgs -> unit) = x.WithAttribute(Xaml._NavigatedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the Navigating property in the visual element
        member x.Navigating(value: Xamarin.Forms.WebNavigatingEventArgs -> unit) = x.WithAttribute(Xaml._NavigatingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(value))

        /// Adjusts the BackgroundImage property in the visual element
        member x.BackgroundImage(value: string) = x.WithAttribute(Xaml._BackgroundImageAttribKey, (value))

        /// Adjusts the Icon property in the visual element
        member x.Icon(value: string) = x.WithAttribute(Xaml._IconAttribKey, (value))

        /// Adjusts the IsBusy property in the visual element
        member x.IsBusy(value: bool) = x.WithAttribute(Xaml._IsBusyAttribKey, (value))

        /// Adjusts the ToolbarItems property in the visual element
        member x.ToolbarItems(value: ViewElement list) = x.WithAttribute(Xaml._ToolbarItemsAttribKey, Array.ofList(value))

        /// Adjusts the UseSafeArea property in the visual element
        member x.UseSafeArea(value: bool) = x.WithAttribute(Xaml._UseSafeAreaAttribKey, (value))

        /// Adjusts the Page_Appearing property in the visual element
        member x.Page_Appearing(value: unit -> unit) = x.WithAttribute(Xaml._Page_AppearingAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(value))

        /// Adjusts the Page_Disappearing property in the visual element
        member x.Page_Disappearing(value: unit -> unit) = x.WithAttribute(Xaml._Page_DisappearingAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(value))

        /// Adjusts the Page_LayoutChanged property in the visual element
        member x.Page_LayoutChanged(value: unit -> unit) = x.WithAttribute(Xaml._Page_LayoutChangedAttribKey, (fun f -> System.EventHandler(fun _sender _args -> f ()))(value))

        /// Adjusts the CarouselPage_SelectedItem property in the visual element
        member x.CarouselPage_SelectedItem(value: System.Object) = x.WithAttribute(Xaml._CarouselPage_SelectedItemAttribKey, (value))

        /// Adjusts the CurrentPage property in the visual element
        member x.CurrentPage(value: ViewElement) = x.WithAttribute(Xaml._CurrentPageAttribKey, (value))

        /// Adjusts the CurrentPageChanged property in the visual element
        member x.CurrentPageChanged(value: 'T option -> unit) = x.WithAttribute(Xaml._CurrentPageChangedAttribKey, (fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(value))

        /// Adjusts the Pages property in the visual element
        member x.Pages(value: ViewElement list) = x.WithAttribute(Xaml._PagesAttribKey, Array.ofList(value))

        /// Adjusts the BackButtonTitle property in the visual element
        member x.BackButtonTitle(value: string) = x.WithAttribute(Xaml._BackButtonTitleAttribKey, (value))

        /// Adjusts the HasBackButton property in the visual element
        member x.HasBackButton(value: bool) = x.WithAttribute(Xaml._HasBackButtonAttribKey, (value))

        /// Adjusts the HasNavigationBar property in the visual element
        member x.HasNavigationBar(value: bool) = x.WithAttribute(Xaml._HasNavigationBarAttribKey, (value))

        /// Adjusts the TitleIcon property in the visual element
        member x.TitleIcon(value: string) = x.WithAttribute(Xaml._TitleIconAttribKey, (value))

        /// Adjusts the BarBackgroundColor property in the visual element
        member x.BarBackgroundColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._BarBackgroundColorAttribKey, (value))

        /// Adjusts the BarTextColor property in the visual element
        member x.BarTextColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._BarTextColorAttribKey, (value))

        /// Adjusts the Popped property in the visual element
        member x.Popped(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttribute(Xaml._PoppedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value))

        /// Adjusts the PoppedToRoot property in the visual element
        member x.PoppedToRoot(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttribute(Xaml._PoppedToRootAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value))

        /// Adjusts the Pushed property in the visual element
        member x.Pushed(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttribute(Xaml._PushedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value))

        /// Adjusts the OnSizeAllocatedCallback property in the visual element
        member x.OnSizeAllocatedCallback(value: (double * double) -> unit) = x.WithAttribute(Xaml._OnSizeAllocatedCallbackAttribKey, (fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(value))

        /// Adjusts the Master property in the visual element
        member x.Master(value: ViewElement) = x.WithAttribute(Xaml._MasterAttribKey, (value))

        /// Adjusts the Detail property in the visual element
        member x.Detail(value: ViewElement) = x.WithAttribute(Xaml._DetailAttribKey, (value))

        /// Adjusts the IsGestureEnabled property in the visual element
        member x.IsGestureEnabled(value: bool) = x.WithAttribute(Xaml._IsGestureEnabledAttribKey, (value))

        /// Adjusts the IsPresented property in the visual element
        member x.IsPresented(value: bool) = x.WithAttribute(Xaml._IsPresentedAttribKey, (value))

        /// Adjusts the MasterBehavior property in the visual element
        member x.MasterBehavior(value: Xamarin.Forms.MasterBehavior) = x.WithAttribute(Xaml._MasterBehaviorAttribKey, (value))

        /// Adjusts the IsPresentedChanged property in the visual element
        member x.IsPresentedChanged(value: bool -> unit) = x.WithAttribute(Xaml._IsPresentedChangedAttribKey, (fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(value))

        /// Adjusts the TextDetail property in the visual element
        member x.TextDetail(value: string) = x.WithAttribute(Xaml._TextDetailAttribKey, (value))

        /// Adjusts the TextDetailColor property in the visual element
        member x.TextDetailColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._TextDetailColorAttribKey, (value))

        /// Adjusts the TextCellCommand property in the visual element
        member x.TextCellCommand(value: unit -> unit) = x.WithAttribute(Xaml._TextCellCommandAttribKey, (value))

        /// Adjusts the TextCellCanExecute property in the visual element
        member x.TextCellCanExecute(value: bool) = x.WithAttribute(Xaml._TextCellCanExecuteAttribKey, (value))

        /// Adjusts the Order property in the visual element
        member x.Order(value: Xamarin.Forms.ToolbarItemOrder) = x.WithAttribute(Xaml._OrderAttribKey, (value))

        /// Adjusts the Priority property in the visual element
        member x.Priority(value: int) = x.WithAttribute(Xaml._PriorityAttribKey, (value))

        /// Adjusts the View property in the visual element
        member x.View(value: ViewElement) = x.WithAttribute(Xaml._ViewAttribKey, (value))

        /// Adjusts the ListViewItems property in the visual element
        member x.ListViewItems(value: seq<ViewElement>) = x.WithAttribute(Xaml._ListViewItemsAttribKey, (value))

        /// Adjusts the Footer property in the visual element
        member x.Footer(value: System.Object) = x.WithAttribute(Xaml._FooterAttribKey, (value))

        /// Adjusts the Header property in the visual element
        member x.Header(value: System.Object) = x.WithAttribute(Xaml._HeaderAttribKey, (value))

        /// Adjusts the HeaderTemplate property in the visual element
        member x.HeaderTemplate(value: Xamarin.Forms.DataTemplate) = x.WithAttribute(Xaml._HeaderTemplateAttribKey, (value))

        /// Adjusts the IsGroupingEnabled property in the visual element
        member x.IsGroupingEnabled(value: bool) = x.WithAttribute(Xaml._IsGroupingEnabledAttribKey, (value))

        /// Adjusts the IsPullToRefreshEnabled property in the visual element
        member x.IsPullToRefreshEnabled(value: bool) = x.WithAttribute(Xaml._IsPullToRefreshEnabledAttribKey, (value))

        /// Adjusts the IsRefreshing property in the visual element
        member x.IsRefreshing(value: bool) = x.WithAttribute(Xaml._IsRefreshingAttribKey, (value))

        /// Adjusts the RefreshCommand property in the visual element
        member x.RefreshCommand(value: unit -> unit) = x.WithAttribute(Xaml._RefreshCommandAttribKey, makeCommand(value))

        /// Adjusts the ListView_SelectedItem property in the visual element
        member x.ListView_SelectedItem(value: int option) = x.WithAttribute(Xaml._ListView_SelectedItemAttribKey, (value))

        /// Adjusts the ListView_SeparatorVisibility property in the visual element
        member x.ListView_SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttribute(Xaml._ListView_SeparatorVisibilityAttribKey, (value))

        /// Adjusts the ListView_SeparatorColor property in the visual element
        member x.ListView_SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._ListView_SeparatorColorAttribKey, (value))

        /// Adjusts the ListView_ItemAppearing property in the visual element
        member x.ListView_ItemAppearing(value: int -> unit) = x.WithAttribute(Xaml._ListView_ItemAppearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value))

        /// Adjusts the ListView_ItemDisappearing property in the visual element
        member x.ListView_ItemDisappearing(value: int -> unit) = x.WithAttribute(Xaml._ListView_ItemDisappearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value))

        /// Adjusts the ListView_ItemSelected property in the visual element
        member x.ListView_ItemSelected(value: int option -> unit) = x.WithAttribute(Xaml._ListView_ItemSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(value))

        /// Adjusts the ListView_ItemTapped property in the visual element
        member x.ListView_ItemTapped(value: int -> unit) = x.WithAttribute(Xaml._ListView_ItemTappedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value))

        /// Adjusts the ListView_Refreshing property in the visual element
        member x.ListView_Refreshing(value: unit -> unit) = x.WithAttribute(Xaml._ListView_RefreshingAttribKey, (fun f -> System.EventHandler(fun sender args -> f ()))(value))

        /// Adjusts the ListViewGrouped_ItemsSource property in the visual element
        member x.ListViewGrouped_ItemsSource(value: (ViewElement * ViewElement list) list) = x.WithAttribute(Xaml._ListViewGrouped_ItemsSourceAttribKey, (fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(value))

        /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
        member x.ListViewGrouped_SelectedItem(value: (int * int) option) = x.WithAttribute(Xaml._ListViewGrouped_SelectedItemAttribKey, (value))

        /// Adjusts the SeparatorVisibility property in the visual element
        member x.SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttribute(Xaml._SeparatorVisibilityAttribKey, (value))

        /// Adjusts the SeparatorColor property in the visual element
        member x.SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttribute(Xaml._SeparatorColorAttribKey, (value))

        /// Adjusts the ListViewGrouped_ItemAppearing property in the visual element
        member x.ListViewGrouped_ItemAppearing(value: int * int -> unit) = x.WithAttribute(Xaml._ListViewGrouped_ItemAppearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value))

        /// Adjusts the ListViewGrouped_ItemDisappearing property in the visual element
        member x.ListViewGrouped_ItemDisappearing(value: int * int -> unit) = x.WithAttribute(Xaml._ListViewGrouped_ItemDisappearingAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value))

        /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
        member x.ListViewGrouped_ItemSelected(value: (int * int) option -> unit) = x.WithAttribute(Xaml._ListViewGrouped_ItemSelectedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(value))

        /// Adjusts the ListViewGrouped_ItemTapped property in the visual element
        member x.ListViewGrouped_ItemTapped(value: int * int -> unit) = x.WithAttribute(Xaml._ListViewGrouped_ItemTappedAttribKey, (fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value))

        /// Adjusts the Refreshing property in the visual element
        member x.Refreshing(value: unit -> unit) = x.WithAttribute(Xaml._RefreshingAttribKey, (fun f -> System.EventHandler(fun sender args -> f ()))(value))


    /// Adjusts the ClassId property in the visual element
    let classId (value: string) (x: ViewElement) = x.ClassId(value)

    /// Adjusts the StyleId property in the visual element
    let styleId (value: string) (x: ViewElement) = x.StyleId(value)

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

    /// Adjusts the Color property in the visual element
    let color (value: Xamarin.Forms.Color) (x: ViewElement) = x.Color(value)

    /// Adjusts the IsRunning property in the visual element
    let isRunning (value: bool) (x: ViewElement) = x.IsRunning(value)

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

    /// Adjusts the Minimum property in the visual element
    let minimum (value: double) (x: ViewElement) = x.Minimum(value)

    /// Adjusts the Maximum property in the visual element
    let maximum (value: double) (x: ViewElement) = x.Maximum(value)

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

    /// Adjusts the Direction property in the visual element
    let direction (value: Xamarin.Forms.FlexDirection) (x: ViewElement) = x.Direction(value)

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
    let imageSource (value: string) (x: ViewElement) = x.ImageSource(value)

    /// Adjusts the Aspect property in the visual element
    let aspect (value: Xamarin.Forms.Aspect) (x: ViewElement) = x.Aspect(value)

    /// Adjusts the IsOpaque property in the visual element
    let isOpaque (value: bool) (x: ViewElement) = x.IsOpaque(value)

    /// Adjusts the Keyboard property in the visual element
    let keyboard (value: Xamarin.Forms.Keyboard) (x: ViewElement) = x.Keyboard(value)

    /// Adjusts the EditorCompleted property in the visual element
    let editorCompleted (value: string -> unit) (x: ViewElement) = x.EditorCompleted(value)

    /// Adjusts the TextChanged property in the visual element
    let textChanged (value: Xamarin.Forms.TextChangedEventArgs -> unit) (x: ViewElement) = x.TextChanged(value)

    /// Adjusts the IsPassword property in the visual element
    let isPassword (value: bool) (x: ViewElement) = x.IsPassword(value)

    /// Adjusts the EntryCompleted property in the visual element
    let entryCompleted (value: string -> unit) (x: ViewElement) = x.EntryCompleted(value)

    /// Adjusts the Label property in the visual element
    let label (value: string) (x: ViewElement) = x.Label(value)

    /// Adjusts the VerticalTextAlignment property in the visual element
    let verticalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: ViewElement) = x.VerticalTextAlignment(value)

    /// Adjusts the FormattedText property in the visual element
    let formattedText (value: ViewElement) (x: ViewElement) = x.FormattedText(value)

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

    /// Adjusts the Navigated property in the visual element
    let navigated (value: Xamarin.Forms.WebNavigatedEventArgs -> unit) (x: ViewElement) = x.Navigated(value)

    /// Adjusts the Navigating property in the visual element
    let navigating (value: Xamarin.Forms.WebNavigatingEventArgs -> unit) (x: ViewElement) = x.Navigating(value)

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

    /// Adjusts the CarouselPage_SelectedItem property in the visual element
    let carouselPage_SelectedItem (value: System.Object) (x: ViewElement) = x.CarouselPage_SelectedItem(value)

    /// Adjusts the CurrentPage property in the visual element
    let currentPage (value: ViewElement) (x: ViewElement) = x.CurrentPage(value)

    /// Adjusts the CurrentPageChanged property in the visual element
    let currentPageChanged (value: 'T option -> unit) (x: ViewElement) = x.CurrentPageChanged(value)

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

    /// Adjusts the ListViewGrouped_ItemsSource property in the visual element
    let listViewGrouped_ItemsSource (value: (ViewElement * ViewElement list) list) (x: ViewElement) = x.ListViewGrouped_ItemsSource(value)

    /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
    let listViewGrouped_SelectedItem (value: (int * int) option) (x: ViewElement) = x.ListViewGrouped_SelectedItem(value)

    /// Adjusts the SeparatorVisibility property in the visual element
    let separatorVisibility (value: Xamarin.Forms.SeparatorVisibility) (x: ViewElement) = x.SeparatorVisibility(value)

    /// Adjusts the SeparatorColor property in the visual element
    let separatorColor (value: Xamarin.Forms.Color) (x: ViewElement) = x.SeparatorColor(value)

    /// Adjusts the ListViewGrouped_ItemAppearing property in the visual element
    let listViewGrouped_ItemAppearing (value: int * int -> unit) (x: ViewElement) = x.ListViewGrouped_ItemAppearing(value)

    /// Adjusts the ListViewGrouped_ItemDisappearing property in the visual element
    let listViewGrouped_ItemDisappearing (value: int * int -> unit) (x: ViewElement) = x.ListViewGrouped_ItemDisappearing(value)

    /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
    let listViewGrouped_ItemSelected (value: (int * int) option -> unit) (x: ViewElement) = x.ListViewGrouped_ItemSelected(value)

    /// Adjusts the ListViewGrouped_ItemTapped property in the visual element
    let listViewGrouped_ItemTapped (value: int * int -> unit) (x: ViewElement) = x.ListViewGrouped_ItemTapped(value)

    /// Adjusts the Refreshing property in the visual element
    let refreshing (value: unit -> unit) (x: ViewElement) = x.Refreshing(value)
