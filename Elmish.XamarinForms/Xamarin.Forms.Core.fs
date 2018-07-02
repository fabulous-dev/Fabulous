namespace Elmish.XamarinForms.DynamicViews 

#nowarn "67" // cast always holds

type Xaml() =

    static member val _ClassIdPropertyKey = ViewElement.GetKey("ClassId")
    static member val _StyleIdPropertyKey = ViewElement.GetKey("StyleId")
    static member val _AnchorXPropertyKey = ViewElement.GetKey("AnchorX")
    static member val _AnchorYPropertyKey = ViewElement.GetKey("AnchorY")
    static member val _BackgroundColorPropertyKey = ViewElement.GetKey("BackgroundColor")
    static member val _HeightRequestPropertyKey = ViewElement.GetKey("HeightRequest")
    static member val _InputTransparentPropertyKey = ViewElement.GetKey("InputTransparent")
    static member val _IsEnabledPropertyKey = ViewElement.GetKey("IsEnabled")
    static member val _IsVisiblePropertyKey = ViewElement.GetKey("IsVisible")
    static member val _MinimumHeightRequestPropertyKey = ViewElement.GetKey("MinimumHeightRequest")
    static member val _MinimumWidthRequestPropertyKey = ViewElement.GetKey("MinimumWidthRequest")
    static member val _OpacityPropertyKey = ViewElement.GetKey("Opacity")
    static member val _RotationPropertyKey = ViewElement.GetKey("Rotation")
    static member val _RotationXPropertyKey = ViewElement.GetKey("RotationX")
    static member val _RotationYPropertyKey = ViewElement.GetKey("RotationY")
    static member val _ScalePropertyKey = ViewElement.GetKey("Scale")
    static member val _StylePropertyKey = ViewElement.GetKey("Style")
    static member val _TranslationXPropertyKey = ViewElement.GetKey("TranslationX")
    static member val _TranslationYPropertyKey = ViewElement.GetKey("TranslationY")
    static member val _WidthRequestPropertyKey = ViewElement.GetKey("WidthRequest")
    static member val _ResourcesPropertyKey = ViewElement.GetKey("Resources")
    static member val _StylesPropertyKey = ViewElement.GetKey("Styles")
    static member val _StyleSheetsPropertyKey = ViewElement.GetKey("StyleSheets")
    static member val _HorizontalOptionsPropertyKey = ViewElement.GetKey("HorizontalOptions")
    static member val _VerticalOptionsPropertyKey = ViewElement.GetKey("VerticalOptions")
    static member val _MarginPropertyKey = ViewElement.GetKey("Margin")
    static member val _GestureRecognizersPropertyKey = ViewElement.GetKey("GestureRecognizers")
    static member val _TouchPointsPropertyKey = ViewElement.GetKey("TouchPoints")
    static member val _PanUpdatedPropertyKey = ViewElement.GetKey("PanUpdated")
    static member val _CommandPropertyKey = ViewElement.GetKey("Command")
    static member val _NumberOfTapsRequiredPropertyKey = ViewElement.GetKey("NumberOfTapsRequired")
    static member val _NumberOfClicksRequiredPropertyKey = ViewElement.GetKey("NumberOfClicksRequired")
    static member val _ButtonsPropertyKey = ViewElement.GetKey("Buttons")
    static member val _IsPinchingPropertyKey = ViewElement.GetKey("IsPinching")
    static member val _PinchUpdatedPropertyKey = ViewElement.GetKey("PinchUpdated")
    static member val _ColorPropertyKey = ViewElement.GetKey("Color")
    static member val _IsRunningPropertyKey = ViewElement.GetKey("IsRunning")
    static member val _ProgressPropertyKey = ViewElement.GetKey("Progress")
    static member val _IsClippedToBoundsPropertyKey = ViewElement.GetKey("IsClippedToBounds")
    static member val _PaddingPropertyKey = ViewElement.GetKey("Padding")
    static member val _ContentPropertyKey = ViewElement.GetKey("Content")
    static member val _ScrollOrientationPropertyKey = ViewElement.GetKey("ScrollOrientation")
    static member val _CancelButtonColorPropertyKey = ViewElement.GetKey("CancelButtonColor")
    static member val _FontFamilyPropertyKey = ViewElement.GetKey("FontFamily")
    static member val _FontAttributesPropertyKey = ViewElement.GetKey("FontAttributes")
    static member val _FontSizePropertyKey = ViewElement.GetKey("FontSize")
    static member val _HorizontalTextAlignmentPropertyKey = ViewElement.GetKey("HorizontalTextAlignment")
    static member val _PlaceholderPropertyKey = ViewElement.GetKey("Placeholder")
    static member val _PlaceholderColorPropertyKey = ViewElement.GetKey("PlaceholderColor")
    static member val _SearchBarCommandPropertyKey = ViewElement.GetKey("SearchBarCommand")
    static member val _SearchBarCanExecutePropertyKey = ViewElement.GetKey("SearchBarCanExecute")
    static member val _TextPropertyKey = ViewElement.GetKey("Text")
    static member val _TextColorPropertyKey = ViewElement.GetKey("TextColor")
    static member val _ButtonCommandPropertyKey = ViewElement.GetKey("ButtonCommand")
    static member val _ButtonCanExecutePropertyKey = ViewElement.GetKey("ButtonCanExecute")
    static member val _BorderColorPropertyKey = ViewElement.GetKey("BorderColor")
    static member val _BorderWidthPropertyKey = ViewElement.GetKey("BorderWidth")
    static member val _CommandParameterPropertyKey = ViewElement.GetKey("CommandParameter")
    static member val _ContentLayoutPropertyKey = ViewElement.GetKey("ContentLayout")
    static member val _ButtonCornerRadiusPropertyKey = ViewElement.GetKey("ButtonCornerRadius")
    static member val _ButtonImageSourcePropertyKey = ViewElement.GetKey("ButtonImageSource")
    static member val _MinimumPropertyKey = ViewElement.GetKey("Minimum")
    static member val _MaximumPropertyKey = ViewElement.GetKey("Maximum")
    static member val _ValuePropertyKey = ViewElement.GetKey("Value")
    static member val _ValueChangedPropertyKey = ViewElement.GetKey("ValueChanged")
    static member val _IncrementPropertyKey = ViewElement.GetKey("Increment")
    static member val _IsToggledPropertyKey = ViewElement.GetKey("IsToggled")
    static member val _ToggledPropertyKey = ViewElement.GetKey("Toggled")
    static member val _HeightPropertyKey = ViewElement.GetKey("Height")
    static member val _OnPropertyKey = ViewElement.GetKey("On")
    static member val _OnChangedPropertyKey = ViewElement.GetKey("OnChanged")
    static member val _IntentPropertyKey = ViewElement.GetKey("Intent")
    static member val _HasUnevenRowsPropertyKey = ViewElement.GetKey("HasUnevenRows")
    static member val _RowHeightPropertyKey = ViewElement.GetKey("RowHeight")
    static member val _TableRootPropertyKey = ViewElement.GetKey("TableRoot")
    static member val _RowDefinitionHeightPropertyKey = ViewElement.GetKey("RowDefinitionHeight")
    static member val _ColumnDefinitionWidthPropertyKey = ViewElement.GetKey("ColumnDefinitionWidth")
    static member val _GridRowDefinitionsPropertyKey = ViewElement.GetKey("GridRowDefinitions")
    static member val _GridColumnDefinitionsPropertyKey = ViewElement.GetKey("GridColumnDefinitions")
    static member val _RowSpacingPropertyKey = ViewElement.GetKey("RowSpacing")
    static member val _ColumnSpacingPropertyKey = ViewElement.GetKey("ColumnSpacing")
    static member val _ChildrenPropertyKey = ViewElement.GetKey("Children")
    static member val _GridRowPropertyKey = ViewElement.GetKey("GridRow")
    static member val _GridRowSpanPropertyKey = ViewElement.GetKey("GridRowSpan")
    static member val _GridColumnPropertyKey = ViewElement.GetKey("GridColumn")
    static member val _GridColumnSpanPropertyKey = ViewElement.GetKey("GridColumnSpan")
    static member val _LayoutBoundsPropertyKey = ViewElement.GetKey("LayoutBounds")
    static member val _LayoutFlagsPropertyKey = ViewElement.GetKey("LayoutFlags")
    static member val _BoundsConstraintPropertyKey = ViewElement.GetKey("BoundsConstraint")
    static member val _HeightConstraintPropertyKey = ViewElement.GetKey("HeightConstraint")
    static member val _WidthConstraintPropertyKey = ViewElement.GetKey("WidthConstraint")
    static member val _XConstraintPropertyKey = ViewElement.GetKey("XConstraint")
    static member val _YConstraintPropertyKey = ViewElement.GetKey("YConstraint")
    static member val _AlignContentPropertyKey = ViewElement.GetKey("AlignContent")
    static member val _AlignItemsPropertyKey = ViewElement.GetKey("AlignItems")
    static member val _DirectionPropertyKey = ViewElement.GetKey("Direction")
    static member val _PositionPropertyKey = ViewElement.GetKey("Position")
    static member val _WrapPropertyKey = ViewElement.GetKey("Wrap")
    static member val _JustifyContentPropertyKey = ViewElement.GetKey("JustifyContent")
    static member val _FlexAlignSelfPropertyKey = ViewElement.GetKey("FlexAlignSelf")
    static member val _FlexOrderPropertyKey = ViewElement.GetKey("FlexOrder")
    static member val _FlexBasisPropertyKey = ViewElement.GetKey("FlexBasis")
    static member val _FlexGrowPropertyKey = ViewElement.GetKey("FlexGrow")
    static member val _FlexShrinkPropertyKey = ViewElement.GetKey("FlexShrink")
    static member val _DatePropertyKey = ViewElement.GetKey("Date")
    static member val _FormatPropertyKey = ViewElement.GetKey("Format")
    static member val _MinimumDatePropertyKey = ViewElement.GetKey("MinimumDate")
    static member val _MaximumDatePropertyKey = ViewElement.GetKey("MaximumDate")
    static member val _DateSelectedPropertyKey = ViewElement.GetKey("DateSelected")
    static member val _PickerItemsSourcePropertyKey = ViewElement.GetKey("PickerItemsSource")
    static member val _SelectedIndexPropertyKey = ViewElement.GetKey("SelectedIndex")
    static member val _TitlePropertyKey = ViewElement.GetKey("Title")
    static member val _SelectedIndexChangedPropertyKey = ViewElement.GetKey("SelectedIndexChanged")
    static member val _FrameCornerRadiusPropertyKey = ViewElement.GetKey("FrameCornerRadius")
    static member val _HasShadowPropertyKey = ViewElement.GetKey("HasShadow")
    static member val _ImageSourcePropertyKey = ViewElement.GetKey("ImageSource")
    static member val _AspectPropertyKey = ViewElement.GetKey("Aspect")
    static member val _IsOpaquePropertyKey = ViewElement.GetKey("IsOpaque")
    static member val _KeyboardPropertyKey = ViewElement.GetKey("Keyboard")
    static member val _EditorCompletedPropertyKey = ViewElement.GetKey("EditorCompleted")
    static member val _TextChangedPropertyKey = ViewElement.GetKey("TextChanged")
    static member val _IsPasswordPropertyKey = ViewElement.GetKey("IsPassword")
    static member val _EntryCompletedPropertyKey = ViewElement.GetKey("EntryCompleted")
    static member val _LabelPropertyKey = ViewElement.GetKey("Label")
    static member val _VerticalTextAlignmentPropertyKey = ViewElement.GetKey("VerticalTextAlignment")
    static member val _FormattedTextPropertyKey = ViewElement.GetKey("FormattedText")
    static member val _StackOrientationPropertyKey = ViewElement.GetKey("StackOrientation")
    static member val _SpacingPropertyKey = ViewElement.GetKey("Spacing")
    static member val _ForegroundColorPropertyKey = ViewElement.GetKey("ForegroundColor")
    static member val _PropertyChangedPropertyKey = ViewElement.GetKey("PropertyChanged")
    static member val _SpansPropertyKey = ViewElement.GetKey("Spans")
    static member val _TimePropertyKey = ViewElement.GetKey("Time")
    static member val _WebSourcePropertyKey = ViewElement.GetKey("WebSource")
    static member val _NavigatedPropertyKey = ViewElement.GetKey("Navigated")
    static member val _NavigatingPropertyKey = ViewElement.GetKey("Navigating")
    static member val _BackgroundImagePropertyKey = ViewElement.GetKey("BackgroundImage")
    static member val _IconPropertyKey = ViewElement.GetKey("Icon")
    static member val _IsBusyPropertyKey = ViewElement.GetKey("IsBusy")
    static member val _ToolbarItemsPropertyKey = ViewElement.GetKey("ToolbarItems")
    static member val _UseSafeAreaPropertyKey = ViewElement.GetKey("UseSafeArea")
    static member val _Page_AppearingPropertyKey = ViewElement.GetKey("Page_Appearing")
    static member val _Page_DisappearingPropertyKey = ViewElement.GetKey("Page_Disappearing")
    static member val _Page_LayoutChangedPropertyKey = ViewElement.GetKey("Page_LayoutChanged")
    static member val _CarouselPage_SelectedItemPropertyKey = ViewElement.GetKey("CarouselPage_SelectedItem")
    static member val _CurrentPagePropertyKey = ViewElement.GetKey("CurrentPage")
    static member val _CurrentPageChangedPropertyKey = ViewElement.GetKey("CurrentPageChanged")
    static member val _PagesPropertyKey = ViewElement.GetKey("Pages")
    static member val _BackButtonTitlePropertyKey = ViewElement.GetKey("BackButtonTitle")
    static member val _HasBackButtonPropertyKey = ViewElement.GetKey("HasBackButton")
    static member val _HasNavigationBarPropertyKey = ViewElement.GetKey("HasNavigationBar")
    static member val _TitleIconPropertyKey = ViewElement.GetKey("TitleIcon")
    static member val _BarBackgroundColorPropertyKey = ViewElement.GetKey("BarBackgroundColor")
    static member val _BarTextColorPropertyKey = ViewElement.GetKey("BarTextColor")
    static member val _PoppedPropertyKey = ViewElement.GetKey("Popped")
    static member val _PoppedToRootPropertyKey = ViewElement.GetKey("PoppedToRoot")
    static member val _PushedPropertyKey = ViewElement.GetKey("Pushed")
    static member val _OnSizeAllocatedCallbackPropertyKey = ViewElement.GetKey("OnSizeAllocatedCallback")
    static member val _MasterPropertyKey = ViewElement.GetKey("Master")
    static member val _DetailPropertyKey = ViewElement.GetKey("Detail")
    static member val _IsGestureEnabledPropertyKey = ViewElement.GetKey("IsGestureEnabled")
    static member val _IsPresentedPropertyKey = ViewElement.GetKey("IsPresented")
    static member val _MasterBehaviorPropertyKey = ViewElement.GetKey("MasterBehavior")
    static member val _IsPresentedChangedPropertyKey = ViewElement.GetKey("IsPresentedChanged")
    static member val _TextDetailPropertyKey = ViewElement.GetKey("TextDetail")
    static member val _TextDetailColorPropertyKey = ViewElement.GetKey("TextDetailColor")
    static member val _TextCellCommandPropertyKey = ViewElement.GetKey("TextCellCommand")
    static member val _TextCellCanExecutePropertyKey = ViewElement.GetKey("TextCellCanExecute")
    static member val _OrderPropertyKey = ViewElement.GetKey("Order")
    static member val _PriorityPropertyKey = ViewElement.GetKey("Priority")
    static member val _ViewPropertyKey = ViewElement.GetKey("View")
    static member val _ListViewItemsPropertyKey = ViewElement.GetKey("ListViewItems")
    static member val _FooterPropertyKey = ViewElement.GetKey("Footer")
    static member val _HeaderPropertyKey = ViewElement.GetKey("Header")
    static member val _HeaderTemplatePropertyKey = ViewElement.GetKey("HeaderTemplate")
    static member val _IsGroupingEnabledPropertyKey = ViewElement.GetKey("IsGroupingEnabled")
    static member val _IsPullToRefreshEnabledPropertyKey = ViewElement.GetKey("IsPullToRefreshEnabled")
    static member val _IsRefreshingPropertyKey = ViewElement.GetKey("IsRefreshing")
    static member val _RefreshCommandPropertyKey = ViewElement.GetKey("RefreshCommand")
    static member val _ListView_SelectedItemPropertyKey = ViewElement.GetKey("ListView_SelectedItem")
    static member val _ListView_SeparatorVisibilityPropertyKey = ViewElement.GetKey("ListView_SeparatorVisibility")
    static member val _ListView_SeparatorColorPropertyKey = ViewElement.GetKey("ListView_SeparatorColor")
    static member val _ListView_ItemAppearingPropertyKey = ViewElement.GetKey("ListView_ItemAppearing")
    static member val _ListView_ItemDisappearingPropertyKey = ViewElement.GetKey("ListView_ItemDisappearing")
    static member val _ListView_ItemSelectedPropertyKey = ViewElement.GetKey("ListView_ItemSelected")
    static member val _ListView_ItemTappedPropertyKey = ViewElement.GetKey("ListView_ItemTapped")
    static member val _ListView_RefreshingPropertyKey = ViewElement.GetKey("ListView_Refreshing")
    static member val _ListViewGrouped_ItemsSourcePropertyKey = ViewElement.GetKey("ListViewGrouped_ItemsSource")
    static member val _ListViewGrouped_SelectedItemPropertyKey = ViewElement.GetKey("ListViewGrouped_SelectedItem")
    static member val _SeparatorVisibilityPropertyKey = ViewElement.GetKey("SeparatorVisibility")
    static member val _SeparatorColorPropertyKey = ViewElement.GetKey("SeparatorColor")
    static member val _ListViewGrouped_ItemAppearingPropertyKey = ViewElement.GetKey("ListViewGrouped_ItemAppearing")
    static member val _ListViewGrouped_ItemDisappearingPropertyKey = ViewElement.GetKey("ListViewGrouped_ItemDisappearing")
    static member val _ListViewGrouped_ItemSelectedPropertyKey = ViewElement.GetKey("ListViewGrouped_ItemSelected")
    static member val _ListViewGrouped_ItemTappedPropertyKey = ViewElement.GetKey("ListViewGrouped_ItemTapped")
    static member val _RefreshingPropertyKey = ViewElement.GetKey("Refreshing")

    /// Builds the attributes for a Element in the view
    static member inline _BuildElement(attribCount: int, ?classId: string, ?styleId: string) = 

        let attribCount = match classId with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match styleId with Some _ -> attribCount + 1 | None -> attribCount
        let attribBuilder = new AttributesBuilder(attribCount)
        match classId with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ClassIdPropertyKey, box ((v))) 
        match styleId with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._StyleIdPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoElement : ViewElement option = None with get, set

    static member val _CreateElement = fun () -> 
        failwith "can't create Xamarin.Forms.Element"

    static member val _UpdateElement = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let target = (targetObj :?> Xamarin.Forms.Element)
        let mutable prevClassIdOpt = ValueNone
        let mutable currClassIdOpt = ValueNone
        let mutable prevStyleIdOpt = ValueNone
        let mutable currStyleIdOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ClassIdPropertyKey then 
                currClassIdOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._StyleIdPropertyKey then 
                currStyleIdOpt <- ValueSome (kvp.Value :?> string)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ClassIdPropertyKey then 
                    prevClassIdOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._StyleIdPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Element>, Xaml._CreateElement, Xaml._UpdateElement, attribBuilder)

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
        match anchorX with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._AnchorXPropertyKey, box ((v))) 
        match anchorY with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._AnchorYPropertyKey, box ((v))) 
        match backgroundColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._BackgroundColorPropertyKey, box ((v))) 
        match heightRequest with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HeightRequestPropertyKey, box ((v))) 
        match inputTransparent with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._InputTransparentPropertyKey, box ((v))) 
        match isEnabled with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsEnabledPropertyKey, box ((v))) 
        match isVisible with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsVisiblePropertyKey, box ((v))) 
        match minimumHeightRequest with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MinimumHeightRequestPropertyKey, box ((v))) 
        match minimumWidthRequest with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MinimumWidthRequestPropertyKey, box ((v))) 
        match opacity with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._OpacityPropertyKey, box ((v))) 
        match rotation with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RotationPropertyKey, box ((v))) 
        match rotationX with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RotationXPropertyKey, box ((v))) 
        match rotationY with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RotationYPropertyKey, box ((v))) 
        match scale with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ScalePropertyKey, box ((v))) 
        match style with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._StylePropertyKey, box ((v))) 
        match translationX with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TranslationXPropertyKey, box ((v))) 
        match translationY with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TranslationYPropertyKey, box ((v))) 
        match widthRequest with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._WidthRequestPropertyKey, box ((v))) 
        match resources with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ResourcesPropertyKey, box ((v))) 
        match styles with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._StylesPropertyKey, box ((v))) 
        match styleSheets with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._StyleSheetsPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoVisualElement : ViewElement option = None with get, set

    static member val _CreateVisualElement = fun () -> 
        failwith "can't create Xamarin.Forms.VisualElement"

    static member val _UpdateVisualElement = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.VisualElement)
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
            if kvp.Key = Xaml._AnchorXPropertyKey then 
                currAnchorXOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._AnchorYPropertyKey then 
                currAnchorYOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._BackgroundColorPropertyKey then 
                currBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._HeightRequestPropertyKey then 
                currHeightRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._InputTransparentPropertyKey then 
                currInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsEnabledPropertyKey then 
                currIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsVisiblePropertyKey then 
                currIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._MinimumHeightRequestPropertyKey then 
                currMinimumHeightRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._MinimumWidthRequestPropertyKey then 
                currMinimumWidthRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._OpacityPropertyKey then 
                currOpacityOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._RotationPropertyKey then 
                currRotationOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._RotationXPropertyKey then 
                currRotationXOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._RotationYPropertyKey then 
                currRotationYOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ScalePropertyKey then 
                currScaleOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._StylePropertyKey then 
                currStyleOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style)
            if kvp.Key = Xaml._TranslationXPropertyKey then 
                currTranslationXOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._TranslationYPropertyKey then 
                currTranslationYOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._WidthRequestPropertyKey then 
                currWidthRequestOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ResourcesPropertyKey then 
                currResourcesOpt <- ValueSome (kvp.Value :?> (string * obj) list)
            if kvp.Key = Xaml._StylesPropertyKey then 
                currStylesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style list)
            if kvp.Key = Xaml._StyleSheetsPropertyKey then 
                currStyleSheetsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StyleSheets.StyleSheet list)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._AnchorXPropertyKey then 
                    prevAnchorXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._AnchorYPropertyKey then 
                    prevAnchorYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._BackgroundColorPropertyKey then 
                    prevBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._HeightRequestPropertyKey then 
                    prevHeightRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._InputTransparentPropertyKey then 
                    prevInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsEnabledPropertyKey then 
                    prevIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsVisiblePropertyKey then 
                    prevIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._MinimumHeightRequestPropertyKey then 
                    prevMinimumHeightRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._MinimumWidthRequestPropertyKey then 
                    prevMinimumWidthRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._OpacityPropertyKey then 
                    prevOpacityOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._RotationPropertyKey then 
                    prevRotationOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._RotationXPropertyKey then 
                    prevRotationXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._RotationYPropertyKey then 
                    prevRotationYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ScalePropertyKey then 
                    prevScaleOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._StylePropertyKey then 
                    prevStyleOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style)
                if kvp.Key = Xaml._TranslationXPropertyKey then 
                    prevTranslationXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._TranslationYPropertyKey then 
                    prevTranslationYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._WidthRequestPropertyKey then 
                    prevWidthRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ResourcesPropertyKey then 
                    prevResourcesOpt <- ValueSome (kvp.Value :?> (string * obj) list)
                if kvp.Key = Xaml._StylesPropertyKey then 
                    prevStylesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style list)
                if kvp.Key = Xaml._StyleSheetsPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.VisualElement>, Xaml._CreateVisualElement, Xaml._UpdateVisualElement, attribBuilder)

    /// Builds the attributes for a View in the view
    static member inline _BuildView(attribCount: int, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match horizontalOptions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match verticalOptions with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match margin with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match gestureRecognizers with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildVisualElement(attribCount, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match horizontalOptions with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HorizontalOptionsPropertyKey, box ((v))) 
        match verticalOptions with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._VerticalOptionsPropertyKey, box ((v))) 
        match margin with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MarginPropertyKey, box (makeThickness(v))) 
        match gestureRecognizers with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._GestureRecognizersPropertyKey, box (Array.ofList(v))) 
        attribBuilder

    static member val _ProtoView : ViewElement option = None with get, set

    static member val _CreateView = fun () -> 
        failwith "can't create Xamarin.Forms.View"

    static member val _UpdateView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoVisualElement.IsNone then Xaml._ProtoVisualElement <- Some (Xaml.VisualElement())); Xaml._ProtoVisualElement.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.View)
        let mutable prevHorizontalOptionsOpt = ValueNone
        let mutable currHorizontalOptionsOpt = ValueNone
        let mutable prevVerticalOptionsOpt = ValueNone
        let mutable currVerticalOptionsOpt = ValueNone
        let mutable prevMarginOpt = ValueNone
        let mutable currMarginOpt = ValueNone
        let mutable prevGestureRecognizersOpt = ValueNone
        let mutable currGestureRecognizersOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._HorizontalOptionsPropertyKey then 
                currHorizontalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
            if kvp.Key = Xaml._VerticalOptionsPropertyKey then 
                currVerticalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
            if kvp.Key = Xaml._MarginPropertyKey then 
                currMarginOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
            if kvp.Key = Xaml._GestureRecognizersPropertyKey then 
                currGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._HorizontalOptionsPropertyKey then 
                    prevHorizontalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                if kvp.Key = Xaml._VerticalOptionsPropertyKey then 
                    prevVerticalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                if kvp.Key = Xaml._MarginPropertyKey then 
                    prevMarginOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                if kvp.Key = Xaml._GestureRecognizersPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.View>, Xaml._CreateView, Xaml._UpdateView, attribBuilder)

    /// Builds the attributes for a IGestureRecognizer in the view
    static member inline _BuildIGestureRecognizer(attribCount: int) = 

        let attribBuilder = new AttributesBuilder(attribCount)
        attribBuilder

    static member val _ProtoIGestureRecognizer : ViewElement option = None with get, set

    static member val _CreateIGestureRecognizer = fun () -> 
        failwith "can't create Xamarin.Forms.IGestureRecognizer"

    static member val _UpdateIGestureRecognizer = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        ignore prevOpt
        ignore curr
        ignore targetObj

    /// Describes a IGestureRecognizer in the view
    static member inline IGestureRecognizer() = 

        let attribBuilder = Xaml._BuildIGestureRecognizer(0)

        new ViewElement(typeof<Xamarin.Forms.IGestureRecognizer>, Xaml._CreateIGestureRecognizer, Xaml._UpdateIGestureRecognizer, attribBuilder)

    /// Builds the attributes for a PanGestureRecognizer in the view
    static member inline _BuildPanGestureRecognizer(attribCount: int, ?touchPoints: int, ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 

        let attribCount = match touchPoints with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match panUpdated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match touchPoints with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TouchPointsPropertyKey, box ((v))) 
        match panUpdated with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PanUpdatedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoPanGestureRecognizer : ViewElement option = None with get, set

    static member val _CreatePanGestureRecognizer = fun () -> 
            box (new Xamarin.Forms.PanGestureRecognizer())

    static member val _UpdatePanGestureRecognizer = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.PanGestureRecognizer)
        let mutable prevTouchPointsOpt = ValueNone
        let mutable currTouchPointsOpt = ValueNone
        let mutable prevPanUpdatedOpt = ValueNone
        let mutable currPanUpdatedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._TouchPointsPropertyKey then 
                currTouchPointsOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._PanUpdatedPropertyKey then 
                currPanUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TouchPointsPropertyKey then 
                    prevTouchPointsOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._PanUpdatedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.PanGestureRecognizer>, Xaml._CreatePanGestureRecognizer, Xaml._UpdatePanGestureRecognizer, attribBuilder)

    /// Builds the attributes for a TapGestureRecognizer in the view
    static member inline _BuildTapGestureRecognizer(attribCount: int, ?command: unit -> unit, ?numberOfTapsRequired: int, ?classId: string, ?styleId: string) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match numberOfTapsRequired with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match command with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._CommandPropertyKey, box (makeCommand(v))) 
        match numberOfTapsRequired with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._NumberOfTapsRequiredPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoTapGestureRecognizer : ViewElement option = None with get, set

    static member val _CreateTapGestureRecognizer = fun () -> 
            box (new Xamarin.Forms.TapGestureRecognizer())

    static member val _UpdateTapGestureRecognizer = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.TapGestureRecognizer)
        let mutable prevCommandOpt = ValueNone
        let mutable currCommandOpt = ValueNone
        let mutable prevNumberOfTapsRequiredOpt = ValueNone
        let mutable currNumberOfTapsRequiredOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._CommandPropertyKey then 
                currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = Xaml._NumberOfTapsRequiredPropertyKey then 
                currNumberOfTapsRequiredOpt <- ValueSome (kvp.Value :?> int)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._CommandPropertyKey then 
                    prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml._NumberOfTapsRequiredPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.TapGestureRecognizer>, Xaml._CreateTapGestureRecognizer, Xaml._UpdateTapGestureRecognizer, attribBuilder)

    /// Builds the attributes for a ClickGestureRecognizer in the view
    static member inline _BuildClickGestureRecognizer(attribCount: int, ?command: unit -> unit, ?numberOfClicksRequired: int, ?buttons: Xamarin.Forms.ButtonsMask, ?classId: string, ?styleId: string) = 

        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match numberOfClicksRequired with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match buttons with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match command with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._CommandPropertyKey, box (makeCommand(v))) 
        match numberOfClicksRequired with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._NumberOfClicksRequiredPropertyKey, box ((v))) 
        match buttons with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ButtonsPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoClickGestureRecognizer : ViewElement option = None with get, set

    static member val _CreateClickGestureRecognizer = fun () -> 
            box (new Xamarin.Forms.ClickGestureRecognizer())

    static member val _UpdateClickGestureRecognizer = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ClickGestureRecognizer)
        let mutable prevCommandOpt = ValueNone
        let mutable currCommandOpt = ValueNone
        let mutable prevNumberOfClicksRequiredOpt = ValueNone
        let mutable currNumberOfClicksRequiredOpt = ValueNone
        let mutable prevButtonsOpt = ValueNone
        let mutable currButtonsOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._CommandPropertyKey then 
                currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = Xaml._NumberOfClicksRequiredPropertyKey then 
                currNumberOfClicksRequiredOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._ButtonsPropertyKey then 
                currButtonsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ButtonsMask)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._CommandPropertyKey then 
                    prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml._NumberOfClicksRequiredPropertyKey then 
                    prevNumberOfClicksRequiredOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._ButtonsPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ClickGestureRecognizer>, Xaml._CreateClickGestureRecognizer, Xaml._UpdateClickGestureRecognizer, attribBuilder)

    /// Builds the attributes for a PinchGestureRecognizer in the view
    static member inline _BuildPinchGestureRecognizer(attribCount: int, ?isPinching: bool, ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 

        let attribCount = match isPinching with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match pinchUpdated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match isPinching with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsPinchingPropertyKey, box ((v))) 
        match pinchUpdated with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PinchUpdatedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoPinchGestureRecognizer : ViewElement option = None with get, set

    static member val _CreatePinchGestureRecognizer = fun () -> 
            box (new Xamarin.Forms.PinchGestureRecognizer())

    static member val _UpdatePinchGestureRecognizer = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.PinchGestureRecognizer)
        let mutable prevIsPinchingOpt = ValueNone
        let mutable currIsPinchingOpt = ValueNone
        let mutable prevPinchUpdatedOpt = ValueNone
        let mutable currPinchUpdatedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._IsPinchingPropertyKey then 
                currIsPinchingOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._PinchUpdatedPropertyKey then 
                currPinchUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._IsPinchingPropertyKey then 
                    prevIsPinchingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._PinchUpdatedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.PinchGestureRecognizer>, Xaml._CreatePinchGestureRecognizer, Xaml._UpdatePinchGestureRecognizer, attribBuilder)

    /// Builds the attributes for a ActivityIndicator in the view
    static member inline _BuildActivityIndicator(attribCount: int, ?color: Xamarin.Forms.Color, ?isRunning: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isRunning with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match color with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ColorPropertyKey, box ((v))) 
        match isRunning with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsRunningPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoActivityIndicator : ViewElement option = None with get, set

    static member val _CreateActivityIndicator = fun () -> 
            box (new Xamarin.Forms.ActivityIndicator())

    static member val _UpdateActivityIndicator = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ActivityIndicator)
        let mutable prevColorOpt = ValueNone
        let mutable currColorOpt = ValueNone
        let mutable prevIsRunningOpt = ValueNone
        let mutable currIsRunningOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ColorPropertyKey then 
                currColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._IsRunningPropertyKey then 
                currIsRunningOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ColorPropertyKey then 
                    prevColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._IsRunningPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ActivityIndicator>, Xaml._CreateActivityIndicator, Xaml._UpdateActivityIndicator, attribBuilder)

    /// Builds the attributes for a BoxView in the view
    static member inline _BuildBoxView(attribCount: int, ?color: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match color with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match color with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ColorPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoBoxView : ViewElement option = None with get, set

    static member val _CreateBoxView = fun () -> 
            box (new Xamarin.Forms.BoxView())

    static member val _UpdateBoxView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.BoxView)
        let mutable prevColorOpt = ValueNone
        let mutable currColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ColorPropertyKey then 
                currColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ColorPropertyKey then 
                    prevColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevColorOpt, currColorOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Color <-  currValue
        | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
        | ValueNone, ValueNone -> ()

    /// Describes a BoxView in the view
    static member inline BoxView(?color: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildBoxView(0, ?color=color, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        new ViewElement(typeof<Xamarin.Forms.BoxView>, Xaml._CreateBoxView, Xaml._UpdateBoxView, attribBuilder)

    /// Builds the attributes for a ProgressBar in the view
    static member inline _BuildProgressBar(attribCount: int, ?progress: double, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match progress with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match progress with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ProgressPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoProgressBar : ViewElement option = None with get, set

    static member val _CreateProgressBar = fun () -> 
            box (new Xamarin.Forms.ProgressBar())

    static member val _UpdateProgressBar = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ProgressBar)
        let mutable prevProgressOpt = ValueNone
        let mutable currProgressOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ProgressPropertyKey then 
                currProgressOpt <- ValueSome (kvp.Value :?> double)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ProgressPropertyKey then 
                    prevProgressOpt <- ValueSome (kvp.Value :?> double)
        match prevProgressOpt, currProgressOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Progress <-  currValue
        | ValueSome _, ValueNone -> target.Progress <- 0.0
        | ValueNone, ValueNone -> ()

    /// Describes a ProgressBar in the view
    static member inline ProgressBar(?progress: double, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildProgressBar(0, ?progress=progress, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        new ViewElement(typeof<Xamarin.Forms.ProgressBar>, Xaml._CreateProgressBar, Xaml._UpdateProgressBar, attribBuilder)

    /// Builds the attributes for a Layout in the view
    static member inline _BuildLayout(attribCount: int, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match isClippedToBounds with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match padding with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match isClippedToBounds with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsClippedToBoundsPropertyKey, box ((v))) 
        match padding with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PaddingPropertyKey, box (makeThickness(v))) 
        attribBuilder

    static member val _ProtoLayout : ViewElement option = None with get, set

    static member val _CreateLayout = fun () -> 
        failwith "can't create Xamarin.Forms.Layout"

    static member val _UpdateLayout = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Layout)
        let mutable prevIsClippedToBoundsOpt = ValueNone
        let mutable currIsClippedToBoundsOpt = ValueNone
        let mutable prevPaddingOpt = ValueNone
        let mutable currPaddingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._IsClippedToBoundsPropertyKey then 
                currIsClippedToBoundsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._PaddingPropertyKey then 
                currPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._IsClippedToBoundsPropertyKey then 
                    prevIsClippedToBoundsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._PaddingPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Layout>, Xaml._CreateLayout, Xaml._UpdateLayout, attribBuilder)

    /// Builds the attributes for a ScrollView in the view
    static member inline _BuildScrollView(attribCount: int, ?content: ViewElement, ?orientation: Xamarin.Forms.ScrollOrientation, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match orientation with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match content with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ContentPropertyKey, box ((v))) 
        match orientation with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ScrollOrientationPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoScrollView : ViewElement option = None with get, set

    static member val _CreateScrollView = fun () -> 
            box (new Xamarin.Forms.ScrollView())

    static member val _UpdateScrollView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ScrollView)
        let mutable prevContentOpt = ValueNone
        let mutable currContentOpt = ValueNone
        let mutable prevScrollOrientationOpt = ValueNone
        let mutable currScrollOrientationOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ContentPropertyKey then 
                currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = Xaml._ScrollOrientationPropertyKey then 
                currScrollOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollOrientation)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ContentPropertyKey then 
                    prevContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml._ScrollOrientationPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ScrollView>, Xaml._CreateScrollView, Xaml._UpdateScrollView, attribBuilder)

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
        match cancelButtonColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._CancelButtonColorPropertyKey, box ((v))) 
        match fontFamily with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontFamilyPropertyKey, box ((v))) 
        match fontAttributes with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontAttributesPropertyKey, box ((v))) 
        match fontSize with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontSizePropertyKey, box (makeFontSize(v))) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HorizontalTextAlignmentPropertyKey, box ((v))) 
        match placeholder with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PlaceholderPropertyKey, box ((v))) 
        match placeholderColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PlaceholderColorPropertyKey, box ((v))) 
        match searchCommand with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._SearchBarCommandPropertyKey, box ((v))) 
        match canExecute with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._SearchBarCanExecutePropertyKey, box ((v))) 
        match text with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextPropertyKey, box ((v))) 
        match textColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextColorPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoSearchBar : ViewElement option = None with get, set

    static member val _CreateSearchBar = fun () -> 
            box (new Xamarin.Forms.SearchBar())

    static member val _UpdateSearchBar = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.SearchBar)
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
            if kvp.Key = Xaml._CancelButtonColorPropertyKey then 
                currCancelButtonColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._FontFamilyPropertyKey then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesPropertyKey then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._FontSizePropertyKey then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._HorizontalTextAlignmentPropertyKey then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = Xaml._PlaceholderPropertyKey then 
                currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._PlaceholderColorPropertyKey then 
                currPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._SearchBarCommandPropertyKey then 
                currSearchBarCommandOpt <- ValueSome (kvp.Value :?> string -> unit)
            if kvp.Key = Xaml._SearchBarCanExecutePropertyKey then 
                currSearchBarCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._TextPropertyKey then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextColorPropertyKey then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._CancelButtonColorPropertyKey then 
                    prevCancelButtonColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._FontFamilyPropertyKey then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesPropertyKey then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._FontSizePropertyKey then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._HorizontalTextAlignmentPropertyKey then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml._PlaceholderPropertyKey then 
                    prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._PlaceholderColorPropertyKey then 
                    prevPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._SearchBarCommandPropertyKey then 
                    prevSearchBarCommandOpt <- ValueSome (kvp.Value :?> string -> unit)
                if kvp.Key = Xaml._SearchBarCanExecutePropertyKey then 
                    prevSearchBarCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._TextPropertyKey then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextColorPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.SearchBar>, Xaml._CreateSearchBar, Xaml._UpdateSearchBar, attribBuilder)

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
        match text with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextPropertyKey, box ((v))) 
        match command with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ButtonCommandPropertyKey, box ((v))) 
        match canExecute with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ButtonCanExecutePropertyKey, box ((v))) 
        match borderColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._BorderColorPropertyKey, box ((v))) 
        match borderWidth with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._BorderWidthPropertyKey, box ((v))) 
        match commandParameter with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._CommandParameterPropertyKey, box ((v))) 
        match contentLayout with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ContentLayoutPropertyKey, box ((v))) 
        match cornerRadius with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ButtonCornerRadiusPropertyKey, box ((v))) 
        match fontFamily with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontFamilyPropertyKey, box ((v))) 
        match fontAttributes with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontAttributesPropertyKey, box ((v))) 
        match fontSize with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontSizePropertyKey, box (makeFontSize(v))) 
        match image with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ButtonImageSourcePropertyKey, box ((v))) 
        match textColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextColorPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoButton : ViewElement option = None with get, set

    static member val _CreateButton = fun () -> 
            box (new Xamarin.Forms.Button())

    static member val _UpdateButton = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Button)
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
            if kvp.Key = Xaml._TextPropertyKey then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._ButtonCommandPropertyKey then 
                currButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
            if kvp.Key = Xaml._ButtonCanExecutePropertyKey then 
                currButtonCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._BorderColorPropertyKey then 
                currBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._BorderWidthPropertyKey then 
                currBorderWidthOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._CommandParameterPropertyKey then 
                currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._ContentLayoutPropertyKey then 
                currContentLayoutOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Button.ButtonContentLayout)
            if kvp.Key = Xaml._ButtonCornerRadiusPropertyKey then 
                currButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._FontFamilyPropertyKey then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesPropertyKey then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._FontSizePropertyKey then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ButtonImageSourcePropertyKey then 
                currButtonImageSourceOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextColorPropertyKey then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextPropertyKey then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._ButtonCommandPropertyKey then 
                    prevButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = Xaml._ButtonCanExecutePropertyKey then 
                    prevButtonCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._BorderColorPropertyKey then 
                    prevBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._BorderWidthPropertyKey then 
                    prevBorderWidthOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._CommandParameterPropertyKey then 
                    prevCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._ContentLayoutPropertyKey then 
                    prevContentLayoutOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Button.ButtonContentLayout)
                if kvp.Key = Xaml._ButtonCornerRadiusPropertyKey then 
                    prevButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._FontFamilyPropertyKey then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesPropertyKey then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._FontSizePropertyKey then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ButtonImageSourcePropertyKey then 
                    prevButtonImageSourceOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextColorPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Button>, Xaml._CreateButton, Xaml._UpdateButton, attribBuilder)

    /// Builds the attributes for a Slider in the view
    static member inline _BuildSlider(attribCount: int, ?minimum: double, ?maximum: double, ?value: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match minimum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match maximum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match value with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match valueChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match minimum with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MinimumPropertyKey, box ((v))) 
        match maximum with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MaximumPropertyKey, box ((v))) 
        match value with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ValuePropertyKey, box ((v))) 
        match valueChanged with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ValueChangedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoSlider : ViewElement option = None with get, set

    static member val _CreateSlider = fun () -> 
            box (new Xamarin.Forms.Slider())

    static member val _UpdateSlider = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Slider)
        let mutable prevMinimumOpt = ValueNone
        let mutable currMinimumOpt = ValueNone
        let mutable prevMaximumOpt = ValueNone
        let mutable currMaximumOpt = ValueNone
        let mutable prevValueOpt = ValueNone
        let mutable currValueOpt = ValueNone
        let mutable prevValueChangedOpt = ValueNone
        let mutable currValueChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._MinimumPropertyKey then 
                currMinimumOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._MaximumPropertyKey then 
                currMaximumOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ValuePropertyKey then 
                currValueOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ValueChangedPropertyKey then 
                currValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._MinimumPropertyKey then 
                    prevMinimumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._MaximumPropertyKey then 
                    prevMaximumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ValuePropertyKey then 
                    prevValueOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ValueChangedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Slider>, Xaml._CreateSlider, Xaml._UpdateSlider, attribBuilder)

    /// Builds the attributes for a Stepper in the view
    static member inline _BuildStepper(attribCount: int, ?minimum: double, ?maximum: double, ?value: double, ?increment: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match minimum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match maximum with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match value with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match increment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match valueChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match minimum with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MinimumPropertyKey, box ((v))) 
        match maximum with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MaximumPropertyKey, box ((v))) 
        match value with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ValuePropertyKey, box ((v))) 
        match increment with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IncrementPropertyKey, box ((v))) 
        match valueChanged with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ValueChangedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoStepper : ViewElement option = None with get, set

    static member val _CreateStepper = fun () -> 
            box (new Xamarin.Forms.Stepper())

    static member val _UpdateStepper = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Stepper)
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
            if kvp.Key = Xaml._MinimumPropertyKey then 
                currMinimumOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._MaximumPropertyKey then 
                currMaximumOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ValuePropertyKey then 
                currValueOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._IncrementPropertyKey then 
                currIncrementOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ValueChangedPropertyKey then 
                currValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._MinimumPropertyKey then 
                    prevMinimumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._MaximumPropertyKey then 
                    prevMaximumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ValuePropertyKey then 
                    prevValueOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._IncrementPropertyKey then 
                    prevIncrementOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ValueChangedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Stepper>, Xaml._CreateStepper, Xaml._UpdateStepper, attribBuilder)

    /// Builds the attributes for a Switch in the view
    static member inline _BuildSwitch(attribCount: int, ?isToggled: bool, ?toggled: Xamarin.Forms.ToggledEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match isToggled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match toggled with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match isToggled with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsToggledPropertyKey, box ((v))) 
        match toggled with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ToggledPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoSwitch : ViewElement option = None with get, set

    static member val _CreateSwitch = fun () -> 
            box (new Xamarin.Forms.Switch())

    static member val _UpdateSwitch = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Switch)
        let mutable prevIsToggledOpt = ValueNone
        let mutable currIsToggledOpt = ValueNone
        let mutable prevToggledOpt = ValueNone
        let mutable currToggledOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._IsToggledPropertyKey then 
                currIsToggledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._ToggledPropertyKey then 
                currToggledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._IsToggledPropertyKey then 
                    prevIsToggledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._ToggledPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Switch>, Xaml._CreateSwitch, Xaml._UpdateSwitch, attribBuilder)

    /// Builds the attributes for a Cell in the view
    static member inline _BuildCell(attribCount: int, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match height with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isEnabled with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match height with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HeightPropertyKey, box ((v))) 
        match isEnabled with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsEnabledPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoCell : ViewElement option = None with get, set

    static member val _CreateCell = fun () -> 
        failwith "can't create Xamarin.Forms.Cell"

    static member val _UpdateCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Cell)
        let mutable prevHeightOpt = ValueNone
        let mutable currHeightOpt = ValueNone
        let mutable prevIsEnabledOpt = ValueNone
        let mutable currIsEnabledOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._HeightPropertyKey then 
                currHeightOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._IsEnabledPropertyKey then 
                currIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._HeightPropertyKey then 
                    prevHeightOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._IsEnabledPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Cell>, Xaml._CreateCell, Xaml._UpdateCell, attribBuilder)

    /// Builds the attributes for a SwitchCell in the view
    static member inline _BuildSwitchCell(attribCount: int, ?on: bool, ?text: string, ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match on with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match onChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        match on with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._OnPropertyKey, box ((v))) 
        match text with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextPropertyKey, box ((v))) 
        match onChanged with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._OnChangedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoSwitchCell : ViewElement option = None with get, set

    static member val _CreateSwitchCell = fun () -> 
            box (new Xamarin.Forms.SwitchCell())

    static member val _UpdateSwitchCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoCell.IsNone then Xaml._ProtoCell <- Some (Xaml.Cell())); Xaml._ProtoCell.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.SwitchCell)
        let mutable prevOnOpt = ValueNone
        let mutable currOnOpt = ValueNone
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevOnChangedOpt = ValueNone
        let mutable currOnChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._OnPropertyKey then 
                currOnOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._TextPropertyKey then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._OnChangedPropertyKey then 
                currOnChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._OnPropertyKey then 
                    prevOnOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._TextPropertyKey then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._OnChangedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.SwitchCell>, Xaml._CreateSwitchCell, Xaml._UpdateSwitchCell, attribBuilder)

    /// Builds the attributes for a TableView in the view
    static member inline _BuildTableView(attribCount: int, ?intent: Xamarin.Forms.TableIntent, ?hasUnevenRows: bool, ?rowHeight: int, ?items: (string * ViewElement list) list, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match intent with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasUnevenRows with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rowHeight with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match items with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match intent with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IntentPropertyKey, box ((v))) 
        match hasUnevenRows with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HasUnevenRowsPropertyKey, box ((v))) 
        match rowHeight with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RowHeightPropertyKey, box ((v))) 
        match items with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TableRootPropertyKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(v))) 
        attribBuilder

    static member val _ProtoTableView : ViewElement option = None with get, set

    static member val _CreateTableView = fun () -> 
            box (new Xamarin.Forms.TableView())

    static member val _UpdateTableView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.TableView)
        let mutable prevIntentOpt = ValueNone
        let mutable currIntentOpt = ValueNone
        let mutable prevHasUnevenRowsOpt = ValueNone
        let mutable currHasUnevenRowsOpt = ValueNone
        let mutable prevRowHeightOpt = ValueNone
        let mutable currRowHeightOpt = ValueNone
        let mutable prevTableRootOpt = ValueNone
        let mutable currTableRootOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._IntentPropertyKey then 
                currIntentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TableIntent)
            if kvp.Key = Xaml._HasUnevenRowsPropertyKey then 
                currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._RowHeightPropertyKey then 
                currRowHeightOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._TableRootPropertyKey then 
                currTableRootOpt <- ValueSome (kvp.Value :?> (string * ViewElement[])[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._IntentPropertyKey then 
                    prevIntentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TableIntent)
                if kvp.Key = Xaml._HasUnevenRowsPropertyKey then 
                    prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._RowHeightPropertyKey then 
                    prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._TableRootPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.TableView>, Xaml._CreateTableView, Xaml._UpdateTableView, attribBuilder)

    /// Builds the attributes for a RowDefinition in the view
    static member inline _BuildRowDefinition(attribCount: int, ?height: obj) = 

        let attribCount = match height with Some _ -> attribCount + 1 | None -> attribCount
        let attribBuilder = new AttributesBuilder(attribCount)
        match height with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RowDefinitionHeightPropertyKey, box (makeGridLength(v))) 
        attribBuilder

    static member val _ProtoRowDefinition : ViewElement option = None with get, set

    static member val _CreateRowDefinition = fun () -> 
            box (new Xamarin.Forms.RowDefinition())

    static member val _UpdateRowDefinition = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let target = (targetObj :?> Xamarin.Forms.RowDefinition)
        let mutable prevRowDefinitionHeightOpt = ValueNone
        let mutable currRowDefinitionHeightOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._RowDefinitionHeightPropertyKey then 
                currRowDefinitionHeightOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._RowDefinitionHeightPropertyKey then 
                    prevRowDefinitionHeightOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevRowDefinitionHeightOpt, currRowDefinitionHeightOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Height <-  currValue
        | ValueSome _, ValueNone -> target.Height <- Xamarin.Forms.GridLength.Auto
        | ValueNone, ValueNone -> ()

    /// Describes a RowDefinition in the view
    static member inline RowDefinition(?height: obj) = 

        let attribBuilder = Xaml._BuildRowDefinition(0, ?height=height)

        new ViewElement(typeof<Xamarin.Forms.RowDefinition>, Xaml._CreateRowDefinition, Xaml._UpdateRowDefinition, attribBuilder)

    /// Builds the attributes for a ColumnDefinition in the view
    static member inline _BuildColumnDefinition(attribCount: int, ?width: obj) = 

        let attribCount = match width with Some _ -> attribCount + 1 | None -> attribCount
        let attribBuilder = new AttributesBuilder(attribCount)
        match width with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ColumnDefinitionWidthPropertyKey, box (makeGridLength(v))) 
        attribBuilder

    static member val _ProtoColumnDefinition : ViewElement option = None with get, set

    static member val _CreateColumnDefinition = fun () -> 
            box (new Xamarin.Forms.ColumnDefinition())

    static member val _UpdateColumnDefinition = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let target = (targetObj :?> Xamarin.Forms.ColumnDefinition)
        let mutable prevColumnDefinitionWidthOpt = ValueNone
        let mutable currColumnDefinitionWidthOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ColumnDefinitionWidthPropertyKey then 
                currColumnDefinitionWidthOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ColumnDefinitionWidthPropertyKey then 
                    prevColumnDefinitionWidthOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
        match prevColumnDefinitionWidthOpt, currColumnDefinitionWidthOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Width <-  currValue
        | ValueSome _, ValueNone -> target.Width <- Xamarin.Forms.GridLength.Auto
        | ValueNone, ValueNone -> ()

    /// Describes a ColumnDefinition in the view
    static member inline ColumnDefinition(?width: obj) = 

        let attribBuilder = Xaml._BuildColumnDefinition(0, ?width=width)

        new ViewElement(typeof<Xamarin.Forms.ColumnDefinition>, Xaml._CreateColumnDefinition, Xaml._UpdateColumnDefinition, attribBuilder)

    /// Builds the attributes for a Grid in the view
    static member inline _BuildGrid(attribCount: int, ?rowdefs: obj list, ?coldefs: obj list, ?rowSpacing: double, ?columnSpacing: double, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match rowdefs with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match coldefs with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match rowSpacing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match columnSpacing with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match rowdefs with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._GridRowDefinitionsPropertyKey, box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(v))) 
        match coldefs with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._GridColumnDefinitionsPropertyKey, box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(v))) 
        match rowSpacing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RowSpacingPropertyKey, box ((v))) 
        match columnSpacing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ColumnSpacingPropertyKey, box ((v))) 
        match children with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ChildrenPropertyKey, box (Array.ofList(v))) 
        attribBuilder

    static member val _ProtoGrid : ViewElement option = None with get, set

    static member val _CreateGrid = fun () -> 
            box (new Xamarin.Forms.Grid())

    static member val _UpdateGrid = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Grid)
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
            if kvp.Key = Xaml._GridRowDefinitionsPropertyKey then 
                currGridRowDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._GridColumnDefinitionsPropertyKey then 
                currGridColumnDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._RowSpacingPropertyKey then 
                currRowSpacingOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ColumnSpacingPropertyKey then 
                currColumnSpacingOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._ChildrenPropertyKey then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._GridRowDefinitionsPropertyKey then 
                    prevGridRowDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._GridColumnDefinitionsPropertyKey then 
                    prevGridColumnDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._RowSpacingPropertyKey then 
                    prevRowSpacingOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ColumnSpacingPropertyKey then 
                    prevColumnSpacingOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._ChildrenPropertyKey then 
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
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml._GridRowPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml._GridRowPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetRow(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRow(targetChild, 0) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml._GridRowSpanPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml._GridRowSpanPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetRowSpan(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRowSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml._GridColumnPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml._GridColumnPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.Grid.SetColumn(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumn(targetChild, 0) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml._GridColumnSpanPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml._GridColumnSpanPropertyKey)
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

        new ViewElement(typeof<Xamarin.Forms.Grid>, Xaml._CreateGrid, Xaml._UpdateGrid, attribBuilder)

    /// Builds the attributes for a AbsoluteLayout in the view
    static member inline _BuildAbsoluteLayout(attribCount: int, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match children with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ChildrenPropertyKey, box (Array.ofList(v))) 
        attribBuilder

    static member val _ProtoAbsoluteLayout : ViewElement option = None with get, set

    static member val _CreateAbsoluteLayout = fun () -> 
            box (new Xamarin.Forms.AbsoluteLayout())

    static member val _UpdateAbsoluteLayout = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.AbsoluteLayout)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ChildrenPropertyKey then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ChildrenPropertyKey then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Rectangle>(Xaml._LayoutBoundsPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Rectangle>(Xaml._LayoutBoundsPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, Xamarin.Forms.Rectangle.Zero) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.AbsoluteLayoutFlags>(Xaml._LayoutFlagsPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.AbsoluteLayoutFlags>(Xaml._LayoutFlagsPropertyKey)
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

        new ViewElement(typeof<Xamarin.Forms.AbsoluteLayout>, Xaml._CreateAbsoluteLayout, Xaml._UpdateAbsoluteLayout, attribBuilder)

    /// Builds the attributes for a RelativeLayout in the view
    static member inline _BuildRelativeLayout(attribCount: int, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match children with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ChildrenPropertyKey, box (Array.ofList(v))) 
        attribBuilder

    static member val _ProtoRelativeLayout : ViewElement option = None with get, set

    static member val _CreateRelativeLayout = fun () -> 
            box (new Xamarin.Forms.RelativeLayout())

    static member val _UpdateRelativeLayout = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.RelativeLayout)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ChildrenPropertyKey then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ChildrenPropertyKey then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.BoundsConstraint>(Xaml._BoundsConstraintPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.BoundsConstraint>(Xaml._BoundsConstraintPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._HeightConstraintPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._HeightConstraintPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._WidthConstraintPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._WidthConstraintPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._XConstraintPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._XConstraintPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._YConstraintPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml._YConstraintPropertyKey)
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

        new ViewElement(typeof<Xamarin.Forms.RelativeLayout>, Xaml._CreateRelativeLayout, Xaml._UpdateRelativeLayout, attribBuilder)

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
        match alignContent with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._AlignContentPropertyKey, box ((v))) 
        match alignItems with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._AlignItemsPropertyKey, box ((v))) 
        match direction with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._DirectionPropertyKey, box ((v))) 
        match position with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PositionPropertyKey, box ((v))) 
        match wrap with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._WrapPropertyKey, box ((v))) 
        match justifyContent with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._JustifyContentPropertyKey, box ((v))) 
        match children with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ChildrenPropertyKey, box (Array.ofList(v))) 
        attribBuilder

    static member val _ProtoFlexLayout : ViewElement option = None with get, set

    static member val _CreateFlexLayout = fun () -> 
            box (new Xamarin.Forms.FlexLayout())

    static member val _UpdateFlexLayout = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.FlexLayout)
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
            if kvp.Key = Xaml._AlignContentPropertyKey then 
                currAlignContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignContent)
            if kvp.Key = Xaml._AlignItemsPropertyKey then 
                currAlignItemsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignItems)
            if kvp.Key = Xaml._DirectionPropertyKey then 
                currDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexDirection)
            if kvp.Key = Xaml._PositionPropertyKey then 
                currPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexPosition)
            if kvp.Key = Xaml._WrapPropertyKey then 
                currWrapOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexWrap)
            if kvp.Key = Xaml._JustifyContentPropertyKey then 
                currJustifyContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexJustify)
            if kvp.Key = Xaml._ChildrenPropertyKey then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._AlignContentPropertyKey then 
                    prevAlignContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignContent)
                if kvp.Key = Xaml._AlignItemsPropertyKey then 
                    prevAlignItemsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignItems)
                if kvp.Key = Xaml._DirectionPropertyKey then 
                    prevDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexDirection)
                if kvp.Key = Xaml._PositionPropertyKey then 
                    prevPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexPosition)
                if kvp.Key = Xaml._WrapPropertyKey then 
                    prevWrapOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexWrap)
                if kvp.Key = Xaml._JustifyContentPropertyKey then 
                    prevJustifyContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexJustify)
                if kvp.Key = Xaml._ChildrenPropertyKey then 
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
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignSelf>(Xaml._FlexAlignSelfPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignSelf>(Xaml._FlexAlignSelfPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetAlignSelf(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetAlignSelf(targetChild, Unchecked.defaultof<Xamarin.Forms.FlexAlignSelf>) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml._FlexOrderPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml._FlexOrderPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetOrder(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetOrder(targetChild, 0) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.FlexBasis>(Xaml._FlexBasisPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.FlexBasis>(Xaml._FlexBasisPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetBasis(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetBasis(targetChild, Unchecked.defaultof<Xamarin.Forms.FlexBasis>) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<single>(Xaml._FlexGrowPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<single>(Xaml._FlexGrowPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                | _, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetGrow(targetChild, currChildValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetGrow(targetChild, 0.0f) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<single>(Xaml._FlexShrinkPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<single>(Xaml._FlexShrinkPropertyKey)
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

        new ViewElement(typeof<Xamarin.Forms.FlexLayout>, Xaml._CreateFlexLayout, Xaml._UpdateFlexLayout, attribBuilder)

    /// Builds the attributes for a TemplatedView in the view
    static member inline _BuildTemplatedView(attribCount: int, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 


        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        attribBuilder

    static member val _ProtoTemplatedView : ViewElement option = None with get, set

    static member val _CreateTemplatedView = fun () -> 
            box (new Xamarin.Forms.TemplatedView())

    static member val _UpdateTemplatedView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        ignore prevOpt
        ignore curr
        ignore targetObj

    /// Describes a TemplatedView in the view
    static member inline TemplatedView(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildTemplatedView(0, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        new ViewElement(typeof<Xamarin.Forms.TemplatedView>, Xaml._CreateTemplatedView, Xaml._UpdateTemplatedView, attribBuilder)

    /// Builds the attributes for a ContentView in the view
    static member inline _BuildContentView(attribCount: int, ?content: ViewElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildTemplatedView(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match content with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ContentPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoContentView : ViewElement option = None with get, set

    static member val _CreateContentView = fun () -> 
            box (new Xamarin.Forms.ContentView())

    static member val _UpdateContentView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoTemplatedView.IsNone then Xaml._ProtoTemplatedView <- Some (Xaml.TemplatedView())); Xaml._ProtoTemplatedView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ContentView)
        let mutable prevContentOpt = ValueNone
        let mutable currContentOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ContentPropertyKey then 
                currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ContentPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ContentView>, Xaml._CreateContentView, Xaml._UpdateContentView, attribBuilder)

    /// Builds the attributes for a DatePicker in the view
    static member inline _BuildDatePicker(attribCount: int, ?date: System.DateTime, ?format: string, ?minimumDate: System.DateTime, ?maximumDate: System.DateTime, ?dateSelected: Xamarin.Forms.DateChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match date with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match format with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match minimumDate with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match maximumDate with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match dateSelected with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match date with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._DatePropertyKey, box ((v))) 
        match format with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FormatPropertyKey, box ((v))) 
        match minimumDate with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MinimumDatePropertyKey, box ((v))) 
        match maximumDate with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MaximumDatePropertyKey, box ((v))) 
        match dateSelected with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._DateSelectedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoDatePicker : ViewElement option = None with get, set

    static member val _CreateDatePicker = fun () -> 
            box (new Xamarin.Forms.DatePicker())

    static member val _UpdateDatePicker = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.DatePicker)
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
            if kvp.Key = Xaml._DatePropertyKey then 
                currDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
            if kvp.Key = Xaml._FormatPropertyKey then 
                currFormatOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._MinimumDatePropertyKey then 
                currMinimumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
            if kvp.Key = Xaml._MaximumDatePropertyKey then 
                currMaximumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
            if kvp.Key = Xaml._DateSelectedPropertyKey then 
                currDateSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._DatePropertyKey then 
                    prevDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = Xaml._FormatPropertyKey then 
                    prevFormatOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._MinimumDatePropertyKey then 
                    prevMinimumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = Xaml._MaximumDatePropertyKey then 
                    prevMaximumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = Xaml._DateSelectedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.DatePicker>, Xaml._CreateDatePicker, Xaml._UpdateDatePicker, attribBuilder)

    /// Builds the attributes for a Picker in the view
    static member inline _BuildPicker(attribCount: int, ?itemsSource: seq<'T>, ?selectedIndex: int, ?title: string, ?textColor: Xamarin.Forms.Color, ?selectedIndexChanged: (int * 'T option) -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match itemsSource with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectedIndex with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match title with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectedIndexChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match itemsSource with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PickerItemsSourcePropertyKey, box (seqToIListUntyped(v))) 
        match selectedIndex with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._SelectedIndexPropertyKey, box ((v))) 
        match title with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TitlePropertyKey, box ((v))) 
        match textColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextColorPropertyKey, box ((v))) 
        match selectedIndexChanged with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._SelectedIndexChangedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(v))) 
        attribBuilder

    static member val _ProtoPicker : ViewElement option = None with get, set

    static member val _CreatePicker = fun () -> 
            box (new Xamarin.Forms.Picker())

    static member val _UpdatePicker = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Picker)
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
            if kvp.Key = Xaml._PickerItemsSourcePropertyKey then 
                currPickerItemsSourceOpt <- ValueSome (kvp.Value :?> System.Collections.IList)
            if kvp.Key = Xaml._SelectedIndexPropertyKey then 
                currSelectedIndexOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._TitlePropertyKey then 
                currTitleOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextColorPropertyKey then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._SelectedIndexChangedPropertyKey then 
                currSelectedIndexChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._PickerItemsSourcePropertyKey then 
                    prevPickerItemsSourceOpt <- ValueSome (kvp.Value :?> System.Collections.IList)
                if kvp.Key = Xaml._SelectedIndexPropertyKey then 
                    prevSelectedIndexOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._TitlePropertyKey then 
                    prevTitleOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextColorPropertyKey then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._SelectedIndexChangedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Picker>, Xaml._CreatePicker, Xaml._UpdatePicker, attribBuilder)

    /// Builds the attributes for a Frame in the view
    static member inline _BuildFrame(attribCount: int, ?borderColor: Xamarin.Forms.Color, ?cornerRadius: double, ?hasShadow: bool, ?content: ViewElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match borderColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match cornerRadius with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match hasShadow with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildContentView(attribCount, ?content=content, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match borderColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._BorderColorPropertyKey, box ((v))) 
        match cornerRadius with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FrameCornerRadiusPropertyKey, box (single(v))) 
        match hasShadow with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HasShadowPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoFrame : ViewElement option = None with get, set

    static member val _CreateFrame = fun () -> 
            box (new Xamarin.Forms.Frame())

    static member val _UpdateFrame = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoContentView.IsNone then Xaml._ProtoContentView <- Some (Xaml.ContentView())); Xaml._ProtoContentView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Frame)
        let mutable prevBorderColorOpt = ValueNone
        let mutable currBorderColorOpt = ValueNone
        let mutable prevFrameCornerRadiusOpt = ValueNone
        let mutable currFrameCornerRadiusOpt = ValueNone
        let mutable prevHasShadowOpt = ValueNone
        let mutable currHasShadowOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._BorderColorPropertyKey then 
                currBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._FrameCornerRadiusPropertyKey then 
                currFrameCornerRadiusOpt <- ValueSome (kvp.Value :?> single)
            if kvp.Key = Xaml._HasShadowPropertyKey then 
                currHasShadowOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._BorderColorPropertyKey then 
                    prevBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._FrameCornerRadiusPropertyKey then 
                    prevFrameCornerRadiusOpt <- ValueSome (kvp.Value :?> single)
                if kvp.Key = Xaml._HasShadowPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Frame>, Xaml._CreateFrame, Xaml._UpdateFrame, attribBuilder)

    /// Builds the attributes for a Image in the view
    static member inline _BuildImage(attribCount: int, ?source: string, ?aspect: Xamarin.Forms.Aspect, ?isOpaque: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match source with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match aspect with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isOpaque with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match source with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ImageSourcePropertyKey, box ((v))) 
        match aspect with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._AspectPropertyKey, box ((v))) 
        match isOpaque with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsOpaquePropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoImage : ViewElement option = None with get, set

    static member val _CreateImage = fun () -> 
            box (new Xamarin.Forms.Image())

    static member val _UpdateImage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Image)
        let mutable prevImageSourceOpt = ValueNone
        let mutable currImageSourceOpt = ValueNone
        let mutable prevAspectOpt = ValueNone
        let mutable currAspectOpt = ValueNone
        let mutable prevIsOpaqueOpt = ValueNone
        let mutable currIsOpaqueOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ImageSourcePropertyKey then 
                currImageSourceOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._AspectPropertyKey then 
                currAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
            if kvp.Key = Xaml._IsOpaquePropertyKey then 
                currIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ImageSourcePropertyKey then 
                    prevImageSourceOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._AspectPropertyKey then 
                    prevAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
                if kvp.Key = Xaml._IsOpaquePropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Image>, Xaml._CreateImage, Xaml._UpdateImage, attribBuilder)

    /// Builds the attributes for a InputView in the view
    static member inline _BuildInputView(attribCount: int, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match keyboard with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match keyboard with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._KeyboardPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoInputView : ViewElement option = None with get, set

    static member val _CreateInputView = fun () -> 
        failwith "can't create Xamarin.Forms.InputView"

    static member val _UpdateInputView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.InputView)
        let mutable prevKeyboardOpt = ValueNone
        let mutable currKeyboardOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._KeyboardPropertyKey then 
                currKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._KeyboardPropertyKey then 
                    prevKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
        match prevKeyboardOpt, currKeyboardOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.Keyboard <-  currValue
        | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
        | ValueNone, ValueNone -> ()

    /// Describes a InputView in the view
    static member inline InputView(?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildInputView(0, ?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        new ViewElement(typeof<Xamarin.Forms.InputView>, Xaml._CreateInputView, Xaml._UpdateInputView, attribBuilder)

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
        match text with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextPropertyKey, box ((v))) 
        match fontSize with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontSizePropertyKey, box (makeFontSize(v))) 
        match fontFamily with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontFamilyPropertyKey, box ((v))) 
        match fontAttributes with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontAttributesPropertyKey, box ((v))) 
        match textColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextColorPropertyKey, box ((v))) 
        match completed with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._EditorCompletedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(v))) 
        match textChanged with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextChangedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoEditor : ViewElement option = None with get, set

    static member val _CreateEditor = fun () -> 
            box (new Xamarin.Forms.Editor())

    static member val _UpdateEditor = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoInputView.IsNone then Xaml._ProtoInputView <- Some (Xaml.InputView())); Xaml._ProtoInputView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Editor)
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
            if kvp.Key = Xaml._TextPropertyKey then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontSizePropertyKey then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._FontFamilyPropertyKey then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesPropertyKey then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._TextColorPropertyKey then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._EditorCompletedPropertyKey then 
                currEditorCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = Xaml._TextChangedPropertyKey then 
                currTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextPropertyKey then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontSizePropertyKey then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._FontFamilyPropertyKey then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesPropertyKey then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._TextColorPropertyKey then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._EditorCompletedPropertyKey then 
                    prevEditorCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml._TextChangedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Editor>, Xaml._CreateEditor, Xaml._UpdateEditor, attribBuilder)

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
        match text with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextPropertyKey, box ((v))) 
        match placeholder with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PlaceholderPropertyKey, box ((v))) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HorizontalTextAlignmentPropertyKey, box ((v))) 
        match fontSize with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontSizePropertyKey, box (makeFontSize(v))) 
        match fontFamily with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontFamilyPropertyKey, box ((v))) 
        match fontAttributes with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontAttributesPropertyKey, box ((v))) 
        match textColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextColorPropertyKey, box ((v))) 
        match placeholderColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PlaceholderColorPropertyKey, box ((v))) 
        match isPassword with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsPasswordPropertyKey, box ((v))) 
        match completed with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._EntryCompletedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(v))) 
        match textChanged with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextChangedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoEntry : ViewElement option = None with get, set

    static member val _CreateEntry = fun () -> 
            box (new Xamarin.Forms.Entry())

    static member val _UpdateEntry = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoInputView.IsNone then Xaml._ProtoInputView <- Some (Xaml.InputView())); Xaml._ProtoInputView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Entry)
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
            if kvp.Key = Xaml._TextPropertyKey then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._PlaceholderPropertyKey then 
                currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._HorizontalTextAlignmentPropertyKey then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = Xaml._FontSizePropertyKey then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._FontFamilyPropertyKey then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesPropertyKey then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._TextColorPropertyKey then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._PlaceholderColorPropertyKey then 
                currPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._IsPasswordPropertyKey then 
                currIsPasswordOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._EntryCompletedPropertyKey then 
                currEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = Xaml._TextChangedPropertyKey then 
                currTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextPropertyKey then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._PlaceholderPropertyKey then 
                    prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._HorizontalTextAlignmentPropertyKey then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml._FontSizePropertyKey then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._FontFamilyPropertyKey then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesPropertyKey then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._TextColorPropertyKey then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._PlaceholderColorPropertyKey then 
                    prevPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._IsPasswordPropertyKey then 
                    prevIsPasswordOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._EntryCompletedPropertyKey then 
                    prevEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml._TextChangedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Entry>, Xaml._CreateEntry, Xaml._UpdateEntry, attribBuilder)

    /// Builds the attributes for a EntryCell in the view
    static member inline _BuildEntryCell(attribCount: int, ?label: string, ?text: string, ?keyboard: Xamarin.Forms.Keyboard, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?completed: string -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match label with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match keyboard with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match placeholder with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match horizontalTextAlignment with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match completed with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        match label with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._LabelPropertyKey, box ((v))) 
        match text with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextPropertyKey, box ((v))) 
        match keyboard with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._KeyboardPropertyKey, box ((v))) 
        match placeholder with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PlaceholderPropertyKey, box ((v))) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HorizontalTextAlignmentPropertyKey, box ((v))) 
        match completed with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._EntryCompletedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.EntryCell).Text))(v))) 
        attribBuilder

    static member val _ProtoEntryCell : ViewElement option = None with get, set

    static member val _CreateEntryCell = fun () -> 
            box (new Xamarin.Forms.EntryCell())

    static member val _UpdateEntryCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoCell.IsNone then Xaml._ProtoCell <- Some (Xaml.Cell())); Xaml._ProtoCell.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.EntryCell)
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
            if kvp.Key = Xaml._LabelPropertyKey then 
                currLabelOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextPropertyKey then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._KeyboardPropertyKey then 
                currKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
            if kvp.Key = Xaml._PlaceholderPropertyKey then 
                currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._HorizontalTextAlignmentPropertyKey then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = Xaml._EntryCompletedPropertyKey then 
                currEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._LabelPropertyKey then 
                    prevLabelOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextPropertyKey then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._KeyboardPropertyKey then 
                    prevKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
                if kvp.Key = Xaml._PlaceholderPropertyKey then 
                    prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._HorizontalTextAlignmentPropertyKey then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml._EntryCompletedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.EntryCell>, Xaml._CreateEntryCell, Xaml._UpdateEntryCell, attribBuilder)

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
        match text with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextPropertyKey, box ((v))) 
        match horizontalTextAlignment with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HorizontalTextAlignmentPropertyKey, box ((v))) 
        match verticalTextAlignment with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._VerticalTextAlignmentPropertyKey, box ((v))) 
        match fontSize with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontSizePropertyKey, box (makeFontSize(v))) 
        match fontFamily with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontFamilyPropertyKey, box ((v))) 
        match fontAttributes with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontAttributesPropertyKey, box ((v))) 
        match textColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextColorPropertyKey, box ((v))) 
        match formattedText with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FormattedTextPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoLabel : ViewElement option = None with get, set

    static member val _CreateLabel = fun () -> 
            box (new Xamarin.Forms.Label())

    static member val _UpdateLabel = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Label)
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
            if kvp.Key = Xaml._TextPropertyKey then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._HorizontalTextAlignmentPropertyKey then 
                currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = Xaml._VerticalTextAlignmentPropertyKey then 
                currVerticalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
            if kvp.Key = Xaml._FontSizePropertyKey then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._FontFamilyPropertyKey then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesPropertyKey then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._TextColorPropertyKey then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._FormattedTextPropertyKey then 
                currFormattedTextOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextPropertyKey then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._HorizontalTextAlignmentPropertyKey then 
                    prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml._VerticalTextAlignmentPropertyKey then 
                    prevVerticalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml._FontSizePropertyKey then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._FontFamilyPropertyKey then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesPropertyKey then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._TextColorPropertyKey then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._FormattedTextPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Label>, Xaml._CreateLabel, Xaml._UpdateLabel, attribBuilder)

    /// Builds the attributes for a StackLayout in the view
    static member inline _BuildStackLayout(attribCount: int, ?children: ViewElement list, ?orientation: Xamarin.Forms.StackOrientation, ?spacing: double, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match orientation with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match spacing with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildLayout(attribCount, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match children with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ChildrenPropertyKey, box (Array.ofList(v))) 
        match orientation with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._StackOrientationPropertyKey, box ((v))) 
        match spacing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._SpacingPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoStackLayout : ViewElement option = None with get, set

    static member val _CreateStackLayout = fun () -> 
            box (new Xamarin.Forms.StackLayout())

    static member val _UpdateStackLayout = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoLayout.IsNone then Xaml._ProtoLayout <- Some (Xaml.Layout())); Xaml._ProtoLayout.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.StackLayout)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        let mutable prevStackOrientationOpt = ValueNone
        let mutable currStackOrientationOpt = ValueNone
        let mutable prevSpacingOpt = ValueNone
        let mutable currSpacingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ChildrenPropertyKey then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._StackOrientationPropertyKey then 
                currStackOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StackOrientation)
            if kvp.Key = Xaml._SpacingPropertyKey then 
                currSpacingOpt <- ValueSome (kvp.Value :?> double)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ChildrenPropertyKey then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._StackOrientationPropertyKey then 
                    prevStackOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StackOrientation)
                if kvp.Key = Xaml._SpacingPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.StackLayout>, Xaml._CreateStackLayout, Xaml._UpdateStackLayout, attribBuilder)

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
        match fontFamily with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontFamilyPropertyKey, box ((v))) 
        match fontAttributes with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontAttributesPropertyKey, box ((v))) 
        match fontSize with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FontSizePropertyKey, box (makeFontSize(v))) 
        match backgroundColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._BackgroundColorPropertyKey, box ((v))) 
        match foregroundColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ForegroundColorPropertyKey, box ((v))) 
        match text with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextPropertyKey, box ((v))) 
        match propertyChanged with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PropertyChangedPropertyKey, box ((fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoSpan : ViewElement option = None with get, set

    static member val _CreateSpan = fun () -> 
            box (new Xamarin.Forms.Span())

    static member val _UpdateSpan = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let target = (targetObj :?> Xamarin.Forms.Span)
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
            if kvp.Key = Xaml._FontFamilyPropertyKey then 
                currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._FontAttributesPropertyKey then 
                currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
            if kvp.Key = Xaml._FontSizePropertyKey then 
                currFontSizeOpt <- ValueSome (kvp.Value :?> double)
            if kvp.Key = Xaml._BackgroundColorPropertyKey then 
                currBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._ForegroundColorPropertyKey then 
                currForegroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._TextPropertyKey then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._PropertyChangedPropertyKey then 
                currPropertyChangedOpt <- ValueSome (kvp.Value :?> System.ComponentModel.PropertyChangedEventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._FontFamilyPropertyKey then 
                    prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._FontAttributesPropertyKey then 
                    prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml._FontSizePropertyKey then 
                    prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml._BackgroundColorPropertyKey then 
                    prevBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._ForegroundColorPropertyKey then 
                    prevForegroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._TextPropertyKey then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._PropertyChangedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.Span>, Xaml._CreateSpan, Xaml._UpdateSpan, attribBuilder)

    /// Builds the attributes for a FormattedString in the view
    static member inline _BuildFormattedString(attribCount: int, ?spans: ViewElement[]) = 

        let attribCount = match spans with Some _ -> attribCount + 1 | None -> attribCount
        let attribBuilder = new AttributesBuilder(attribCount)
        match spans with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._SpansPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoFormattedString : ViewElement option = None with get, set

    static member val _CreateFormattedString = fun () -> 
            box (new Xamarin.Forms.FormattedString())

    static member val _UpdateFormattedString = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let target = (targetObj :?> Xamarin.Forms.FormattedString)
        let mutable prevSpansOpt = ValueNone
        let mutable currSpansOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._SpansPropertyKey then 
                currSpansOpt <- ValueSome (kvp.Value :?> ViewElement[])
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._SpansPropertyKey then 
                    prevSpansOpt <- ValueSome (kvp.Value :?> ViewElement[])
        updateCollectionGeneric prevSpansOpt currSpansOpt target.Spans
            (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.Span)
            (fun _ _ _ -> ())
            canReuseChild
            updateChild

    /// Describes a FormattedString in the view
    static member inline FormattedString(?spans: ViewElement[]) = 

        let attribBuilder = Xaml._BuildFormattedString(0, ?spans=spans)

        new ViewElement(typeof<Xamarin.Forms.FormattedString>, Xaml._CreateFormattedString, Xaml._UpdateFormattedString, attribBuilder)

    /// Builds the attributes for a TimePicker in the view
    static member inline _BuildTimePicker(attribCount: int, ?time: System.TimeSpan, ?format: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match time with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match format with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match textColor with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match time with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TimePropertyKey, box ((v))) 
        match format with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FormatPropertyKey, box ((v))) 
        match textColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextColorPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoTimePicker : ViewElement option = None with get, set

    static member val _CreateTimePicker = fun () -> 
            box (new Xamarin.Forms.TimePicker())

    static member val _UpdateTimePicker = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.TimePicker)
        let mutable prevTimeOpt = ValueNone
        let mutable currTimeOpt = ValueNone
        let mutable prevFormatOpt = ValueNone
        let mutable currFormatOpt = ValueNone
        let mutable prevTextColorOpt = ValueNone
        let mutable currTextColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._TimePropertyKey then 
                currTimeOpt <- ValueSome (kvp.Value :?> System.TimeSpan)
            if kvp.Key = Xaml._FormatPropertyKey then 
                currFormatOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextColorPropertyKey then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TimePropertyKey then 
                    prevTimeOpt <- ValueSome (kvp.Value :?> System.TimeSpan)
                if kvp.Key = Xaml._FormatPropertyKey then 
                    prevFormatOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextColorPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.TimePicker>, Xaml._CreateTimePicker, Xaml._UpdateTimePicker, attribBuilder)

    /// Builds the attributes for a WebView in the view
    static member inline _BuildWebView(attribCount: int, ?source: Xamarin.Forms.WebViewSource, ?navigated: Xamarin.Forms.WebNavigatedEventArgs -> unit, ?navigating: Xamarin.Forms.WebNavigatingEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match source with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match navigated with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match navigating with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildView(attribCount, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match source with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._WebSourcePropertyKey, box ((v))) 
        match navigated with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._NavigatedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(v))) 
        match navigating with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._NavigatingPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoWebView : ViewElement option = None with get, set

    static member val _CreateWebView = fun () -> 
            box (new Xamarin.Forms.WebView())

    static member val _UpdateWebView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.WebView)
        let mutable prevWebSourceOpt = ValueNone
        let mutable currWebSourceOpt = ValueNone
        let mutable prevNavigatedOpt = ValueNone
        let mutable currNavigatedOpt = ValueNone
        let mutable prevNavigatingOpt = ValueNone
        let mutable currNavigatingOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._WebSourcePropertyKey then 
                currWebSourceOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.WebViewSource)
            if kvp.Key = Xaml._NavigatedPropertyKey then 
                currNavigatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>)
            if kvp.Key = Xaml._NavigatingPropertyKey then 
                currNavigatingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._WebSourcePropertyKey then 
                    prevWebSourceOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.WebViewSource)
                if kvp.Key = Xaml._NavigatedPropertyKey then 
                    prevNavigatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>)
                if kvp.Key = Xaml._NavigatingPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.WebView>, Xaml._CreateWebView, Xaml._UpdateWebView, attribBuilder)

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
        match title with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TitlePropertyKey, box ((v))) 
        match backgroundImage with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._BackgroundImagePropertyKey, box ((v))) 
        match icon with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IconPropertyKey, box ((v))) 
        match isBusy with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsBusyPropertyKey, box ((v))) 
        match padding with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PaddingPropertyKey, box (makeThickness(v))) 
        match toolbarItems with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ToolbarItemsPropertyKey, box (Array.ofList(v))) 
        match useSafeArea with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._UseSafeAreaPropertyKey, box ((v))) 
        match appearing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._Page_AppearingPropertyKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(v))) 
        match disappearing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._Page_DisappearingPropertyKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(v))) 
        match layoutChanged with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._Page_LayoutChangedPropertyKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(v))) 
        attribBuilder

    static member val _ProtoPage : ViewElement option = None with get, set

    static member val _CreatePage = fun () -> 
            box (new Xamarin.Forms.Page())

    static member val _UpdatePage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoVisualElement.IsNone then Xaml._ProtoVisualElement <- Some (Xaml.VisualElement())); Xaml._ProtoVisualElement.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.Page)
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
            if kvp.Key = Xaml._TitlePropertyKey then 
                currTitleOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._BackgroundImagePropertyKey then 
                currBackgroundImageOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._IconPropertyKey then 
                currIconOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._IsBusyPropertyKey then 
                currIsBusyOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._PaddingPropertyKey then 
                currPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
            if kvp.Key = Xaml._ToolbarItemsPropertyKey then 
                currToolbarItemsOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._UseSafeAreaPropertyKey then 
                currUseSafeAreaOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._Page_AppearingPropertyKey then 
                currPage_AppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = Xaml._Page_DisappearingPropertyKey then 
                currPage_DisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            if kvp.Key = Xaml._Page_LayoutChangedPropertyKey then 
                currPage_LayoutChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TitlePropertyKey then 
                    prevTitleOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._BackgroundImagePropertyKey then 
                    prevBackgroundImageOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._IconPropertyKey then 
                    prevIconOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._IsBusyPropertyKey then 
                    prevIsBusyOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._PaddingPropertyKey then 
                    prevPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                if kvp.Key = Xaml._ToolbarItemsPropertyKey then 
                    prevToolbarItemsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._UseSafeAreaPropertyKey then 
                    prevUseSafeAreaOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._Page_AppearingPropertyKey then 
                    prevPage_AppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml._Page_DisappearingPropertyKey then 
                    prevPage_DisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml._Page_LayoutChangedPropertyKey then 
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
        (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((target :> Xamarin.Forms.Page).On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevUseSafeAreaOpt currUseSafeAreaOpt target
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

        new ViewElement(typeof<Xamarin.Forms.Page>, Xaml._CreatePage, Xaml._UpdatePage, attribBuilder)

    /// Builds the attributes for a CarouselPage in the view
    static member inline _BuildCarouselPage(attribCount: int, ?children: ViewElement list, ?selectedItem: System.Object, ?currentPage: ViewElement, ?currentPageChanged: 'T option -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match selectedItem with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match currentPage with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match currentPageChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match children with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ChildrenPropertyKey, box (Array.ofList(v))) 
        match selectedItem with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._CarouselPage_SelectedItemPropertyKey, box ((v))) 
        match currentPage with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._CurrentPagePropertyKey, box ((v))) 
        match currentPageChanged with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._CurrentPageChangedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(v))) 
        attribBuilder

    static member val _ProtoCarouselPage : ViewElement option = None with get, set

    static member val _CreateCarouselPage = fun () -> 
            box (new Xamarin.Forms.CarouselPage())

    static member val _UpdateCarouselPage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoPage.IsNone then Xaml._ProtoPage <- Some (Xaml.Page())); Xaml._ProtoPage.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.CarouselPage)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        let mutable prevCarouselPage_SelectedItemOpt = ValueNone
        let mutable currCarouselPage_SelectedItemOpt = ValueNone
        let mutable prevCurrentPageOpt = ValueNone
        let mutable currCurrentPageOpt = ValueNone
        let mutable prevCurrentPageChangedOpt = ValueNone
        let mutable currCurrentPageChangedOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ChildrenPropertyKey then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._CarouselPage_SelectedItemPropertyKey then 
                currCarouselPage_SelectedItemOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._CurrentPagePropertyKey then 
                currCurrentPageOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = Xaml._CurrentPageChangedPropertyKey then 
                currCurrentPageChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ChildrenPropertyKey then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._CarouselPage_SelectedItemPropertyKey then 
                    prevCarouselPage_SelectedItemOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._CurrentPagePropertyKey then 
                    prevCurrentPageOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml._CurrentPageChangedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.CarouselPage>, Xaml._CreateCarouselPage, Xaml._UpdateCarouselPage, attribBuilder)

    /// Builds the attributes for a NavigationPage in the view
    static member inline _BuildNavigationPage(attribCount: int, ?pages: ViewElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?popped: Xamarin.Forms.NavigationEventArgs -> unit, ?poppedToRoot: Xamarin.Forms.NavigationEventArgs -> unit, ?pushed: Xamarin.Forms.NavigationEventArgs -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match pages with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barBackgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barTextColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match popped with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match poppedToRoot with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match pushed with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match pages with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PagesPropertyKey, box (Array.ofList(v))) 
        match barBackgroundColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._BarBackgroundColorPropertyKey, box ((v))) 
        match barTextColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._BarTextColorPropertyKey, box ((v))) 
        match popped with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PoppedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v))) 
        match poppedToRoot with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PoppedToRootPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v))) 
        match pushed with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PushedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoNavigationPage : ViewElement option = None with get, set

    static member val _CreateNavigationPage = fun () -> 
            box (new Xamarin.Forms.NavigationPage())

    static member val _UpdateNavigationPage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoPage.IsNone then Xaml._ProtoPage <- Some (Xaml.Page())); Xaml._ProtoPage.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.NavigationPage)
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
            if kvp.Key = Xaml._PagesPropertyKey then 
                currPagesOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._BarBackgroundColorPropertyKey then 
                currBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._BarTextColorPropertyKey then 
                currBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._PoppedPropertyKey then 
                currPoppedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
            if kvp.Key = Xaml._PoppedToRootPropertyKey then 
                currPoppedToRootOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
            if kvp.Key = Xaml._PushedPropertyKey then 
                currPushedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._PagesPropertyKey then 
                    prevPagesOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._BarBackgroundColorPropertyKey then 
                    prevBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._BarTextColorPropertyKey then 
                    prevBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._PoppedPropertyKey then 
                    prevPoppedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
                if kvp.Key = Xaml._PoppedToRootPropertyKey then 
                    prevPoppedToRootOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
                if kvp.Key = Xaml._PushedPropertyKey then 
                    prevPushedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
        updateNavigationPages prevPagesOpt currPagesOpt target
            (fun prevChildOpt newChild targetChild -> 
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<string>(Xaml._BackButtonTitlePropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<string>(Xaml._BackButtonTitlePropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, null) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<bool>(Xaml._HasBackButtonPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<bool>(Xaml._HasBackButtonPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, true) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<bool>(Xaml._HasNavigationBarPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<bool>(Xaml._HasNavigationBarPropertyKey)
                match prevChildValueOpt, childValueOpt with
                | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                | _, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, currValue)
                | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, true) // TODO: not always perfect, should set back to original default?
                | _ -> ()
                // Adjust the attached properties
                let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<string>(Xaml._TitleIconPropertyKey)
                let childValueOpt = newChild.TryGetAttributeKeyed<string>(Xaml._TitleIconPropertyKey)
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

        new ViewElement(typeof<Xamarin.Forms.NavigationPage>, Xaml._CreateNavigationPage, Xaml._UpdateNavigationPage, attribBuilder)

    /// Builds the attributes for a TabbedPage in the view
    static member inline _BuildTabbedPage(attribCount: int, ?children: ViewElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match children with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barBackgroundColor with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match barTextColor with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match children with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ChildrenPropertyKey, box (Array.ofList(v))) 
        match barBackgroundColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._BarBackgroundColorPropertyKey, box ((v))) 
        match barTextColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._BarTextColorPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoTabbedPage : ViewElement option = None with get, set

    static member val _CreateTabbedPage = fun () -> 
            box (new Xamarin.Forms.TabbedPage())

    static member val _UpdateTabbedPage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoPage.IsNone then Xaml._ProtoPage <- Some (Xaml.Page())); Xaml._ProtoPage.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.TabbedPage)
        let mutable prevChildrenOpt = ValueNone
        let mutable currChildrenOpt = ValueNone
        let mutable prevBarBackgroundColorOpt = ValueNone
        let mutable currBarBackgroundColorOpt = ValueNone
        let mutable prevBarTextColorOpt = ValueNone
        let mutable currBarTextColorOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ChildrenPropertyKey then 
                currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            if kvp.Key = Xaml._BarBackgroundColorPropertyKey then 
                currBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._BarTextColorPropertyKey then 
                currBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ChildrenPropertyKey then 
                    prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml._BarBackgroundColorPropertyKey then 
                    prevBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._BarTextColorPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.TabbedPage>, Xaml._CreateTabbedPage, Xaml._UpdateTabbedPage, attribBuilder)

    /// Builds the attributes for a ContentPage in the view
    static member inline _BuildContentPage(attribCount: int, ?content: ViewElement, ?onSizeAllocated: (double * double) -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match content with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match onSizeAllocated with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match content with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ContentPropertyKey, box ((v))) 
        match onSizeAllocated with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._OnSizeAllocatedCallbackPropertyKey, box ((fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(v))) 
        attribBuilder

    static member val _ProtoContentPage : ViewElement option = None with get, set

    static member val _CreateContentPage = fun () -> 
            box (new Elmish.XamarinForms.DynamicViews.CustomContentPage())

    static member val _UpdateContentPage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoPage.IsNone then Xaml._ProtoPage <- Some (Xaml.Page())); Xaml._ProtoPage.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ContentPage)
        let mutable prevContentOpt = ValueNone
        let mutable currContentOpt = ValueNone
        let mutable prevOnSizeAllocatedCallbackOpt = ValueNone
        let mutable currOnSizeAllocatedCallbackOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ContentPropertyKey then 
                currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = Xaml._OnSizeAllocatedCallbackPropertyKey then 
                currOnSizeAllocatedCallbackOpt <- ValueSome (kvp.Value :?> FSharp.Control.Handler<(double * double)>)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ContentPropertyKey then 
                    prevContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml._OnSizeAllocatedCallbackPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ContentPage>, Xaml._CreateContentPage, Xaml._UpdateContentPage, attribBuilder)

    /// Builds the attributes for a MasterDetailPage in the view
    static member inline _BuildMasterDetailPage(attribCount: int, ?master: ViewElement, ?detail: ViewElement, ?isGestureEnabled: bool, ?isPresented: bool, ?masterBehavior: Xamarin.Forms.MasterBehavior, ?isPresentedChanged: bool -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let attribCount = match master with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match detail with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isGestureEnabled with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isPresented with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match masterBehavior with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match isPresentedChanged with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildPage(attribCount, ?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)
        match master with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MasterPropertyKey, box ((v))) 
        match detail with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._DetailPropertyKey, box ((v))) 
        match isGestureEnabled with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsGestureEnabledPropertyKey, box ((v))) 
        match isPresented with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsPresentedPropertyKey, box ((v))) 
        match masterBehavior with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._MasterBehaviorPropertyKey, box ((v))) 
        match isPresentedChanged with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsPresentedChangedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(v))) 
        attribBuilder

    static member val _ProtoMasterDetailPage : ViewElement option = None with get, set

    static member val _CreateMasterDetailPage = fun () -> 
            box (new Xamarin.Forms.MasterDetailPage())

    static member val _UpdateMasterDetailPage = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoPage.IsNone then Xaml._ProtoPage <- Some (Xaml.Page())); Xaml._ProtoPage.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.MasterDetailPage)
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
            if kvp.Key = Xaml._MasterPropertyKey then 
                currMasterOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = Xaml._DetailPropertyKey then 
                currDetailOpt <- ValueSome (kvp.Value :?> ViewElement)
            if kvp.Key = Xaml._IsGestureEnabledPropertyKey then 
                currIsGestureEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsPresentedPropertyKey then 
                currIsPresentedOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._MasterBehaviorPropertyKey then 
                currMasterBehaviorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.MasterBehavior)
            if kvp.Key = Xaml._IsPresentedChangedPropertyKey then 
                currIsPresentedChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._MasterPropertyKey then 
                    prevMasterOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml._DetailPropertyKey then 
                    prevDetailOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml._IsGestureEnabledPropertyKey then 
                    prevIsGestureEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsPresentedPropertyKey then 
                    prevIsPresentedOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._MasterBehaviorPropertyKey then 
                    prevMasterBehaviorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.MasterBehavior)
                if kvp.Key = Xaml._IsPresentedChangedPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.MasterDetailPage>, Xaml._CreateMasterDetailPage, Xaml._UpdateMasterDetailPage, attribBuilder)

    /// Builds the attributes for a MenuItem in the view
    static member inline _BuildMenuItem(attribCount: int, ?text: string, ?command: unit -> unit, ?commandParameter: System.Object, ?icon: string, ?classId: string, ?styleId: string) = 

        let attribCount = match text with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match command with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match commandParameter with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match icon with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildElement(attribCount, ?classId=classId, ?styleId=styleId)
        match text with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextPropertyKey, box ((v))) 
        match command with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._CommandPropertyKey, box (makeCommand(v))) 
        match commandParameter with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._CommandParameterPropertyKey, box ((v))) 
        match icon with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IconPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoMenuItem : ViewElement option = None with get, set

    static member val _CreateMenuItem = fun () -> 
            box (new Xamarin.Forms.MenuItem())

    static member val _UpdateMenuItem = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoElement.IsNone then Xaml._ProtoElement <- Some (Xaml.Element())); Xaml._ProtoElement.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.MenuItem)
        let mutable prevTextOpt = ValueNone
        let mutable currTextOpt = ValueNone
        let mutable prevCommandOpt = ValueNone
        let mutable currCommandOpt = ValueNone
        let mutable prevCommandParameterOpt = ValueNone
        let mutable currCommandParameterOpt = ValueNone
        let mutable prevIconOpt = ValueNone
        let mutable currIconOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._TextPropertyKey then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._CommandPropertyKey then 
                currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = Xaml._CommandParameterPropertyKey then 
                currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._IconPropertyKey then 
                currIconOpt <- ValueSome (kvp.Value :?> string)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextPropertyKey then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._CommandPropertyKey then 
                    prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml._CommandParameterPropertyKey then 
                    prevCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._IconPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.MenuItem>, Xaml._CreateMenuItem, Xaml._UpdateMenuItem, attribBuilder)

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
        match text with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextPropertyKey, box ((v))) 
        match detail with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextDetailPropertyKey, box ((v))) 
        match textColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextColorPropertyKey, box ((v))) 
        match detailColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextDetailColorPropertyKey, box ((v))) 
        match command with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextCellCommandPropertyKey, box ((v))) 
        match canExecute with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._TextCellCanExecutePropertyKey, box ((v))) 
        match commandParameter with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._CommandParameterPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoTextCell : ViewElement option = None with get, set

    static member val _CreateTextCell = fun () -> 
            box (new Xamarin.Forms.TextCell())

    static member val _UpdateTextCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoCell.IsNone then Xaml._ProtoCell <- Some (Xaml.Cell())); Xaml._ProtoCell.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.TextCell)
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
            if kvp.Key = Xaml._TextPropertyKey then 
                currTextOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextDetailPropertyKey then 
                currTextDetailOpt <- ValueSome (kvp.Value :?> string)
            if kvp.Key = Xaml._TextColorPropertyKey then 
                currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._TextDetailColorPropertyKey then 
                currTextDetailColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._TextCellCommandPropertyKey then 
                currTextCellCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
            if kvp.Key = Xaml._TextCellCanExecutePropertyKey then 
                currTextCellCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._CommandParameterPropertyKey then 
                currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._TextPropertyKey then 
                    prevTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextDetailPropertyKey then 
                    prevTextDetailOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml._TextColorPropertyKey then 
                    prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._TextDetailColorPropertyKey then 
                    prevTextDetailColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._TextCellCommandPropertyKey then 
                    prevTextCellCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = Xaml._TextCellCanExecutePropertyKey then 
                    prevTextCellCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._CommandParameterPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.TextCell>, Xaml._CreateTextCell, Xaml._UpdateTextCell, attribBuilder)

    /// Builds the attributes for a ToolbarItem in the view
    static member inline _BuildToolbarItem(attribCount: int, ?order: Xamarin.Forms.ToolbarItemOrder, ?priority: int, ?text: string, ?command: unit -> unit, ?commandParameter: System.Object, ?icon: string, ?classId: string, ?styleId: string) = 

        let attribCount = match order with Some _ -> attribCount + 1 | None -> attribCount
        let attribCount = match priority with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildMenuItem(attribCount, ?text=text, ?command=command, ?commandParameter=commandParameter, ?icon=icon, ?classId=classId, ?styleId=styleId)
        match order with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._OrderPropertyKey, box ((v))) 
        match priority with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._PriorityPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoToolbarItem : ViewElement option = None with get, set

    static member val _CreateToolbarItem = fun () -> 
            box (new Xamarin.Forms.ToolbarItem())

    static member val _UpdateToolbarItem = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoMenuItem.IsNone then Xaml._ProtoMenuItem <- Some (Xaml.MenuItem())); Xaml._ProtoMenuItem.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ToolbarItem)
        let mutable prevOrderOpt = ValueNone
        let mutable currOrderOpt = ValueNone
        let mutable prevPriorityOpt = ValueNone
        let mutable currPriorityOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._OrderPropertyKey then 
                currOrderOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ToolbarItemOrder)
            if kvp.Key = Xaml._PriorityPropertyKey then 
                currPriorityOpt <- ValueSome (kvp.Value :?> int)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._OrderPropertyKey then 
                    prevOrderOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ToolbarItemOrder)
                if kvp.Key = Xaml._PriorityPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ToolbarItem>, Xaml._CreateToolbarItem, Xaml._UpdateToolbarItem, attribBuilder)

    /// Builds the attributes for a ImageCell in the view
    static member inline _BuildImageCell(attribCount: int, ?imageSource: string, ?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match imageSource with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildTextCell(attribCount, ?text=text, ?detail=detail, ?textColor=textColor, ?detailColor=detailColor, ?command=command, ?canExecute=canExecute, ?commandParameter=commandParameter, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        match imageSource with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ImageSourcePropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoImageCell : ViewElement option = None with get, set

    static member val _CreateImageCell = fun () -> 
            box (new Xamarin.Forms.ImageCell())

    static member val _UpdateImageCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoTextCell.IsNone then Xaml._ProtoTextCell <- Some (Xaml.TextCell())); Xaml._ProtoTextCell.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ImageCell)
        let mutable prevImageSourceOpt = ValueNone
        let mutable currImageSourceOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ImageSourcePropertyKey then 
                currImageSourceOpt <- ValueSome (kvp.Value :?> string)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ImageSourcePropertyKey then 
                    prevImageSourceOpt <- ValueSome (kvp.Value :?> string)
        match prevImageSourceOpt, currImageSourceOpt with
        | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
        | _, ValueSome currValue -> target.ImageSource <- makeImageSource  currValue
        | ValueSome _, ValueNone -> target.ImageSource <- null
        | ValueNone, ValueNone -> ()

    /// Describes a ImageCell in the view
    static member inline ImageCell(?imageSource: string, ?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribBuilder = Xaml._BuildImageCell(0, ?imageSource=imageSource, ?text=text, ?detail=detail, ?textColor=textColor, ?detailColor=detailColor, ?command=command, ?canExecute=canExecute, ?commandParameter=commandParameter, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        new ViewElement(typeof<Xamarin.Forms.ImageCell>, Xaml._CreateImageCell, Xaml._UpdateImageCell, attribBuilder)

    /// Builds the attributes for a ViewCell in the view
    static member inline _BuildViewCell(attribCount: int, ?view: ViewElement, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let attribCount = match view with Some _ -> attribCount + 1 | None -> attribCount

        let attribBuilder = Xaml._BuildCell(attribCount, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)
        match view with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ViewPropertyKey, box ((v))) 
        attribBuilder

    static member val _ProtoViewCell : ViewElement option = None with get, set

    static member val _CreateViewCell = fun () -> 
            box (new Xamarin.Forms.ViewCell())

    static member val _UpdateViewCell = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoCell.IsNone then Xaml._ProtoCell <- Some (Xaml.Cell())); Xaml._ProtoCell.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ViewCell)
        let mutable prevViewOpt = ValueNone
        let mutable currViewOpt = ValueNone
        for kvp in curr.AttributesKeyed do
            if kvp.Key = Xaml._ViewPropertyKey then 
                currViewOpt <- ValueSome (kvp.Value :?> ViewElement)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ViewPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ViewCell>, Xaml._CreateViewCell, Xaml._UpdateViewCell, attribBuilder)

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
        match items with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListViewItemsPropertyKey, box ((v))) 
        match footer with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FooterPropertyKey, box ((v))) 
        match hasUnevenRows with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HasUnevenRowsPropertyKey, box ((v))) 
        match header with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HeaderPropertyKey, box ((v))) 
        match headerTemplate with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HeaderTemplatePropertyKey, box ((v))) 
        match isGroupingEnabled with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsGroupingEnabledPropertyKey, box ((v))) 
        match isPullToRefreshEnabled with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsPullToRefreshEnabledPropertyKey, box ((v))) 
        match isRefreshing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsRefreshingPropertyKey, box ((v))) 
        match refreshCommand with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RefreshCommandPropertyKey, box (makeCommand(v))) 
        match rowHeight with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RowHeightPropertyKey, box ((v))) 
        match selectedItem with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListView_SelectedItemPropertyKey, box ((v))) 
        match separatorVisibility with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListView_SeparatorVisibilityPropertyKey, box ((v))) 
        match separatorColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListView_SeparatorColorPropertyKey, box ((v))) 
        match itemAppearing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListView_ItemAppearingPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v))) 
        match itemDisappearing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListView_ItemDisappearingPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v))) 
        match itemSelected with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListView_ItemSelectedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(v))) 
        match itemTapped with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListView_ItemTappedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v))) 
        match refreshing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListView_RefreshingPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f ()))(v))) 
        attribBuilder

    static member val _ProtoListView : ViewElement option = None with get, set

    static member val _CreateListView = fun () -> 
            box (new Elmish.XamarinForms.DynamicViews.CustomListView())

    static member val _UpdateListView = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ListView)
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
            if kvp.Key = Xaml._ListViewItemsPropertyKey then 
                currListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
            if kvp.Key = Xaml._FooterPropertyKey then 
                currFooterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._HasUnevenRowsPropertyKey then 
                currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._HeaderPropertyKey then 
                currHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._HeaderTemplatePropertyKey then 
                currHeaderTemplateOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.DataTemplate)
            if kvp.Key = Xaml._IsGroupingEnabledPropertyKey then 
                currIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsPullToRefreshEnabledPropertyKey then 
                currIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsRefreshingPropertyKey then 
                currIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._RefreshCommandPropertyKey then 
                currRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = Xaml._RowHeightPropertyKey then 
                currRowHeightOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._ListView_SelectedItemPropertyKey then 
                currListView_SelectedItemOpt <- ValueSome (kvp.Value :?> int option)
            if kvp.Key = Xaml._ListView_SeparatorVisibilityPropertyKey then 
                currListView_SeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
            if kvp.Key = Xaml._ListView_SeparatorColorPropertyKey then 
                currListView_SeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._ListView_ItemAppearingPropertyKey then 
                currListView_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = Xaml._ListView_ItemDisappearingPropertyKey then 
                currListView_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = Xaml._ListView_ItemSelectedPropertyKey then 
                currListView_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
            if kvp.Key = Xaml._ListView_ItemTappedPropertyKey then 
                currListView_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
            if kvp.Key = Xaml._ListView_RefreshingPropertyKey then 
                currListView_RefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ListViewItemsPropertyKey then 
                    prevListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
                if kvp.Key = Xaml._FooterPropertyKey then 
                    prevFooterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._HasUnevenRowsPropertyKey then 
                    prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._HeaderPropertyKey then 
                    prevHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._HeaderTemplatePropertyKey then 
                    prevHeaderTemplateOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.DataTemplate)
                if kvp.Key = Xaml._IsGroupingEnabledPropertyKey then 
                    prevIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsPullToRefreshEnabledPropertyKey then 
                    prevIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsRefreshingPropertyKey then 
                    prevIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._RefreshCommandPropertyKey then 
                    prevRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml._RowHeightPropertyKey then 
                    prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._ListView_SelectedItemPropertyKey then 
                    prevListView_SelectedItemOpt <- ValueSome (kvp.Value :?> int option)
                if kvp.Key = Xaml._ListView_SeparatorVisibilityPropertyKey then 
                    prevListView_SeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
                if kvp.Key = Xaml._ListView_SeparatorColorPropertyKey then 
                    prevListView_SeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._ListView_ItemAppearingPropertyKey then 
                    prevListView_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml._ListView_ItemDisappearingPropertyKey then 
                    prevListView_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml._ListView_ItemSelectedPropertyKey then 
                    prevListView_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                if kvp.Key = Xaml._ListView_ItemTappedPropertyKey then 
                    prevListView_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
                if kvp.Key = Xaml._ListView_RefreshingPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ListView>, Xaml._CreateListView, Xaml._UpdateListView, attribBuilder)

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
        match items with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListViewGrouped_ItemsSourcePropertyKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(v))) 
        match footer with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._FooterPropertyKey, box ((v))) 
        match hasUnevenRows with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HasUnevenRowsPropertyKey, box ((v))) 
        match header with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._HeaderPropertyKey, box ((v))) 
        match isGroupingEnabled with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsGroupingEnabledPropertyKey, box ((v))) 
        match isPullToRefreshEnabled with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsPullToRefreshEnabledPropertyKey, box ((v))) 
        match isRefreshing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._IsRefreshingPropertyKey, box ((v))) 
        match refreshCommand with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RefreshCommandPropertyKey, box (makeCommand(v))) 
        match rowHeight with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RowHeightPropertyKey, box ((v))) 
        match selectedItem with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListViewGrouped_SelectedItemPropertyKey, box ((v))) 
        match separatorVisibility with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._SeparatorVisibilityPropertyKey, box ((v))) 
        match separatorColor with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._SeparatorColorPropertyKey, box ((v))) 
        match itemAppearing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListViewGrouped_ItemAppearingPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v))) 
        match itemDisappearing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListViewGrouped_ItemDisappearingPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v))) 
        match itemSelected with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListViewGrouped_ItemSelectedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(v))) 
        match itemTapped with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._ListViewGrouped_ItemTappedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v))) 
        match refreshing with None -> () | Some v -> attribBuilder.AddKeyed(Xaml._RefreshingPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f ()))(v))) 
        attribBuilder

    static member val _ProtoListViewGrouped : ViewElement option = None with get, set

    static member val _CreateListViewGrouped = fun () -> 
            box (new Elmish.XamarinForms.DynamicViews.CustomGroupListView())

    static member val _UpdateListViewGrouped = fun (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) -> 
        let baseElement = (if Xaml._ProtoView.IsNone then Xaml._ProtoView <- Some (Xaml.View())); Xaml._ProtoView.Value
        baseElement.UpdateMethod prevOpt curr targetObj
        let target = (targetObj :?> Xamarin.Forms.ListView)
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
            if kvp.Key = Xaml._ListViewGrouped_ItemsSourcePropertyKey then 
                currListViewGrouped_ItemsSourceOpt <- ValueSome (kvp.Value :?> (ViewElement * ViewElement[])[])
            if kvp.Key = Xaml._FooterPropertyKey then 
                currFooterOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._HasUnevenRowsPropertyKey then 
                currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._HeaderPropertyKey then 
                currHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
            if kvp.Key = Xaml._IsGroupingEnabledPropertyKey then 
                currIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsPullToRefreshEnabledPropertyKey then 
                currIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._IsRefreshingPropertyKey then 
                currIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
            if kvp.Key = Xaml._RefreshCommandPropertyKey then 
                currRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
            if kvp.Key = Xaml._RowHeightPropertyKey then 
                currRowHeightOpt <- ValueSome (kvp.Value :?> int)
            if kvp.Key = Xaml._ListViewGrouped_SelectedItemPropertyKey then 
                currListViewGrouped_SelectedItemOpt <- ValueSome (kvp.Value :?> (int * int) option)
            if kvp.Key = Xaml._SeparatorVisibilityPropertyKey then 
                currSeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
            if kvp.Key = Xaml._SeparatorColorPropertyKey then 
                currSeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            if kvp.Key = Xaml._ListViewGrouped_ItemAppearingPropertyKey then 
                currListViewGrouped_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = Xaml._ListViewGrouped_ItemDisappearingPropertyKey then 
                currListViewGrouped_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
            if kvp.Key = Xaml._ListViewGrouped_ItemSelectedPropertyKey then 
                currListViewGrouped_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
            if kvp.Key = Xaml._ListViewGrouped_ItemTappedPropertyKey then 
                currListViewGrouped_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
            if kvp.Key = Xaml._RefreshingPropertyKey then 
                currRefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
        match prevOpt with
        | ValueNone -> ()
        | ValueSome prev ->
            for kvp in prev.AttributesKeyed do
                if kvp.Key = Xaml._ListViewGrouped_ItemsSourcePropertyKey then 
                    prevListViewGrouped_ItemsSourceOpt <- ValueSome (kvp.Value :?> (ViewElement * ViewElement[])[])
                if kvp.Key = Xaml._FooterPropertyKey then 
                    prevFooterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._HasUnevenRowsPropertyKey then 
                    prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._HeaderPropertyKey then 
                    prevHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml._IsGroupingEnabledPropertyKey then 
                    prevIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsPullToRefreshEnabledPropertyKey then 
                    prevIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._IsRefreshingPropertyKey then 
                    prevIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml._RefreshCommandPropertyKey then 
                    prevRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml._RowHeightPropertyKey then 
                    prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml._ListViewGrouped_SelectedItemPropertyKey then 
                    prevListViewGrouped_SelectedItemOpt <- ValueSome (kvp.Value :?> (int * int) option)
                if kvp.Key = Xaml._SeparatorVisibilityPropertyKey then 
                    prevSeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
                if kvp.Key = Xaml._SeparatorColorPropertyKey then 
                    prevSeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml._ListViewGrouped_ItemAppearingPropertyKey then 
                    prevListViewGrouped_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml._ListViewGrouped_ItemDisappearingPropertyKey then 
                    prevListViewGrouped_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml._ListViewGrouped_ItemSelectedPropertyKey then 
                    prevListViewGrouped_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                if kvp.Key = Xaml._ListViewGrouped_ItemTappedPropertyKey then 
                    prevListViewGrouped_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
                if kvp.Key = Xaml._RefreshingPropertyKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ListView>, Xaml._CreateListViewGrouped, Xaml._UpdateListViewGrouped, attribBuilder)

[<AutoOpen>]
module ViewElementExtensions = 

    type ViewElement with

        /// Adjusts the ClassId property in the visual element
        member x.ClassId(value: string) = x.WithAttributeKeyed(Xaml._ClassIdPropertyKey, box ((value)))

        /// Adjusts the StyleId property in the visual element
        member x.StyleId(value: string) = x.WithAttributeKeyed(Xaml._StyleIdPropertyKey, box ((value)))

        /// Adjusts the AnchorX property in the visual element
        member x.AnchorX(value: double) = x.WithAttributeKeyed(Xaml._AnchorXPropertyKey, box ((value)))

        /// Adjusts the AnchorY property in the visual element
        member x.AnchorY(value: double) = x.WithAttributeKeyed(Xaml._AnchorYPropertyKey, box ((value)))

        /// Adjusts the BackgroundColor property in the visual element
        member x.BackgroundColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._BackgroundColorPropertyKey, box ((value)))

        /// Adjusts the HeightRequest property in the visual element
        member x.HeightRequest(value: double) = x.WithAttributeKeyed(Xaml._HeightRequestPropertyKey, box ((value)))

        /// Adjusts the InputTransparent property in the visual element
        member x.InputTransparent(value: bool) = x.WithAttributeKeyed(Xaml._InputTransparentPropertyKey, box ((value)))

        /// Adjusts the IsEnabled property in the visual element
        member x.IsEnabled(value: bool) = x.WithAttributeKeyed(Xaml._IsEnabledPropertyKey, box ((value)))

        /// Adjusts the IsVisible property in the visual element
        member x.IsVisible(value: bool) = x.WithAttributeKeyed(Xaml._IsVisiblePropertyKey, box ((value)))

        /// Adjusts the MinimumHeightRequest property in the visual element
        member x.MinimumHeightRequest(value: double) = x.WithAttributeKeyed(Xaml._MinimumHeightRequestPropertyKey, box ((value)))

        /// Adjusts the MinimumWidthRequest property in the visual element
        member x.MinimumWidthRequest(value: double) = x.WithAttributeKeyed(Xaml._MinimumWidthRequestPropertyKey, box ((value)))

        /// Adjusts the Opacity property in the visual element
        member x.Opacity(value: double) = x.WithAttributeKeyed(Xaml._OpacityPropertyKey, box ((value)))

        /// Adjusts the Rotation property in the visual element
        member x.Rotation(value: double) = x.WithAttributeKeyed(Xaml._RotationPropertyKey, box ((value)))

        /// Adjusts the RotationX property in the visual element
        member x.RotationX(value: double) = x.WithAttributeKeyed(Xaml._RotationXPropertyKey, box ((value)))

        /// Adjusts the RotationY property in the visual element
        member x.RotationY(value: double) = x.WithAttributeKeyed(Xaml._RotationYPropertyKey, box ((value)))

        /// Adjusts the Scale property in the visual element
        member x.Scale(value: double) = x.WithAttributeKeyed(Xaml._ScalePropertyKey, box ((value)))

        /// Adjusts the Style property in the visual element
        member x.Style(value: Xamarin.Forms.Style) = x.WithAttributeKeyed(Xaml._StylePropertyKey, box ((value)))

        /// Adjusts the TranslationX property in the visual element
        member x.TranslationX(value: double) = x.WithAttributeKeyed(Xaml._TranslationXPropertyKey, box ((value)))

        /// Adjusts the TranslationY property in the visual element
        member x.TranslationY(value: double) = x.WithAttributeKeyed(Xaml._TranslationYPropertyKey, box ((value)))

        /// Adjusts the WidthRequest property in the visual element
        member x.WidthRequest(value: double) = x.WithAttributeKeyed(Xaml._WidthRequestPropertyKey, box ((value)))

        /// Adjusts the Resources property in the visual element
        member x.Resources(value: (string * obj) list) = x.WithAttributeKeyed(Xaml._ResourcesPropertyKey, box ((value)))

        /// Adjusts the Styles property in the visual element
        member x.Styles(value: Xamarin.Forms.Style list) = x.WithAttributeKeyed(Xaml._StylesPropertyKey, box ((value)))

        /// Adjusts the StyleSheets property in the visual element
        member x.StyleSheets(value: Xamarin.Forms.StyleSheets.StyleSheet list) = x.WithAttributeKeyed(Xaml._StyleSheetsPropertyKey, box ((value)))

        /// Adjusts the HorizontalOptions property in the visual element
        member x.HorizontalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttributeKeyed(Xaml._HorizontalOptionsPropertyKey, box ((value)))

        /// Adjusts the VerticalOptions property in the visual element
        member x.VerticalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttributeKeyed(Xaml._VerticalOptionsPropertyKey, box ((value)))

        /// Adjusts the Margin property in the visual element
        member x.Margin(value: obj) = x.WithAttributeKeyed(Xaml._MarginPropertyKey, box (makeThickness(value)))

        /// Adjusts the GestureRecognizers property in the visual element
        member x.GestureRecognizers(value: ViewElement list) = x.WithAttributeKeyed(Xaml._GestureRecognizersPropertyKey, box (Array.ofList(value)))

        /// Adjusts the TouchPoints property in the visual element
        member x.TouchPoints(value: int) = x.WithAttributeKeyed(Xaml._TouchPointsPropertyKey, box ((value)))

        /// Adjusts the PanUpdated property in the visual element
        member x.PanUpdated(value: Xamarin.Forms.PanUpdatedEventArgs -> unit) = x.WithAttributeKeyed(Xaml._PanUpdatedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Command property in the visual element
        member x.Command(value: unit -> unit) = x.WithAttributeKeyed(Xaml._CommandPropertyKey, box (makeCommand(value)))

        /// Adjusts the NumberOfTapsRequired property in the visual element
        member x.NumberOfTapsRequired(value: int) = x.WithAttributeKeyed(Xaml._NumberOfTapsRequiredPropertyKey, box ((value)))

        /// Adjusts the NumberOfClicksRequired property in the visual element
        member x.NumberOfClicksRequired(value: int) = x.WithAttributeKeyed(Xaml._NumberOfClicksRequiredPropertyKey, box ((value)))

        /// Adjusts the Buttons property in the visual element
        member x.Buttons(value: Xamarin.Forms.ButtonsMask) = x.WithAttributeKeyed(Xaml._ButtonsPropertyKey, box ((value)))

        /// Adjusts the IsPinching property in the visual element
        member x.IsPinching(value: bool) = x.WithAttributeKeyed(Xaml._IsPinchingPropertyKey, box ((value)))

        /// Adjusts the PinchUpdated property in the visual element
        member x.PinchUpdated(value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) = x.WithAttributeKeyed(Xaml._PinchUpdatedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Color property in the visual element
        member x.Color(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._ColorPropertyKey, box ((value)))

        /// Adjusts the IsRunning property in the visual element
        member x.IsRunning(value: bool) = x.WithAttributeKeyed(Xaml._IsRunningPropertyKey, box ((value)))

        /// Adjusts the Progress property in the visual element
        member x.Progress(value: double) = x.WithAttributeKeyed(Xaml._ProgressPropertyKey, box ((value)))

        /// Adjusts the IsClippedToBounds property in the visual element
        member x.IsClippedToBounds(value: bool) = x.WithAttributeKeyed(Xaml._IsClippedToBoundsPropertyKey, box ((value)))

        /// Adjusts the Padding property in the visual element
        member x.Padding(value: obj) = x.WithAttributeKeyed(Xaml._PaddingPropertyKey, box (makeThickness(value)))

        /// Adjusts the Content property in the visual element
        member x.Content(value: ViewElement) = x.WithAttributeKeyed(Xaml._ContentPropertyKey, box ((value)))

        /// Adjusts the ScrollOrientation property in the visual element
        member x.ScrollOrientation(value: Xamarin.Forms.ScrollOrientation) = x.WithAttributeKeyed(Xaml._ScrollOrientationPropertyKey, box ((value)))

        /// Adjusts the CancelButtonColor property in the visual element
        member x.CancelButtonColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._CancelButtonColorPropertyKey, box ((value)))

        /// Adjusts the FontFamily property in the visual element
        member x.FontFamily(value: string) = x.WithAttributeKeyed(Xaml._FontFamilyPropertyKey, box ((value)))

        /// Adjusts the FontAttributes property in the visual element
        member x.FontAttributes(value: Xamarin.Forms.FontAttributes) = x.WithAttributeKeyed(Xaml._FontAttributesPropertyKey, box ((value)))

        /// Adjusts the FontSize property in the visual element
        member x.FontSize(value: obj) = x.WithAttributeKeyed(Xaml._FontSizePropertyKey, box (makeFontSize(value)))

        /// Adjusts the HorizontalTextAlignment property in the visual element
        member x.HorizontalTextAlignment(value: Xamarin.Forms.TextAlignment) = x.WithAttributeKeyed(Xaml._HorizontalTextAlignmentPropertyKey, box ((value)))

        /// Adjusts the Placeholder property in the visual element
        member x.Placeholder(value: string) = x.WithAttributeKeyed(Xaml._PlaceholderPropertyKey, box ((value)))

        /// Adjusts the PlaceholderColor property in the visual element
        member x.PlaceholderColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._PlaceholderColorPropertyKey, box ((value)))

        /// Adjusts the SearchBarCommand property in the visual element
        member x.SearchBarCommand(value: string -> unit) = x.WithAttributeKeyed(Xaml._SearchBarCommandPropertyKey, box ((value)))

        /// Adjusts the SearchBarCanExecute property in the visual element
        member x.SearchBarCanExecute(value: bool) = x.WithAttributeKeyed(Xaml._SearchBarCanExecutePropertyKey, box ((value)))

        /// Adjusts the Text property in the visual element
        member x.Text(value: string) = x.WithAttributeKeyed(Xaml._TextPropertyKey, box ((value)))

        /// Adjusts the TextColor property in the visual element
        member x.TextColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._TextColorPropertyKey, box ((value)))

        /// Adjusts the ButtonCommand property in the visual element
        member x.ButtonCommand(value: unit -> unit) = x.WithAttributeKeyed(Xaml._ButtonCommandPropertyKey, box ((value)))

        /// Adjusts the ButtonCanExecute property in the visual element
        member x.ButtonCanExecute(value: bool) = x.WithAttributeKeyed(Xaml._ButtonCanExecutePropertyKey, box ((value)))

        /// Adjusts the BorderColor property in the visual element
        member x.BorderColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._BorderColorPropertyKey, box ((value)))

        /// Adjusts the BorderWidth property in the visual element
        member x.BorderWidth(value: double) = x.WithAttributeKeyed(Xaml._BorderWidthPropertyKey, box ((value)))

        /// Adjusts the CommandParameter property in the visual element
        member x.CommandParameter(value: System.Object) = x.WithAttributeKeyed(Xaml._CommandParameterPropertyKey, box ((value)))

        /// Adjusts the ContentLayout property in the visual element
        member x.ContentLayout(value: Xamarin.Forms.Button.ButtonContentLayout) = x.WithAttributeKeyed(Xaml._ContentLayoutPropertyKey, box ((value)))

        /// Adjusts the ButtonCornerRadius property in the visual element
        member x.ButtonCornerRadius(value: int) = x.WithAttributeKeyed(Xaml._ButtonCornerRadiusPropertyKey, box ((value)))

        /// Adjusts the ButtonImageSource property in the visual element
        member x.ButtonImageSource(value: string) = x.WithAttributeKeyed(Xaml._ButtonImageSourcePropertyKey, box ((value)))

        /// Adjusts the Minimum property in the visual element
        member x.Minimum(value: double) = x.WithAttributeKeyed(Xaml._MinimumPropertyKey, box ((value)))

        /// Adjusts the Maximum property in the visual element
        member x.Maximum(value: double) = x.WithAttributeKeyed(Xaml._MaximumPropertyKey, box ((value)))

        /// Adjusts the Value property in the visual element
        member x.Value(value: double) = x.WithAttributeKeyed(Xaml._ValuePropertyKey, box ((value)))

        /// Adjusts the ValueChanged property in the visual element
        member x.ValueChanged(value: Xamarin.Forms.ValueChangedEventArgs -> unit) = x.WithAttributeKeyed(Xaml._ValueChangedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Increment property in the visual element
        member x.Increment(value: double) = x.WithAttributeKeyed(Xaml._IncrementPropertyKey, box ((value)))

        /// Adjusts the IsToggled property in the visual element
        member x.IsToggled(value: bool) = x.WithAttributeKeyed(Xaml._IsToggledPropertyKey, box ((value)))

        /// Adjusts the Toggled property in the visual element
        member x.Toggled(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttributeKeyed(Xaml._ToggledPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Height property in the visual element
        member x.Height(value: double) = x.WithAttributeKeyed(Xaml._HeightPropertyKey, box ((value)))

        /// Adjusts the On property in the visual element
        member x.On(value: bool) = x.WithAttributeKeyed(Xaml._OnPropertyKey, box ((value)))

        /// Adjusts the OnChanged property in the visual element
        member x.OnChanged(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttributeKeyed(Xaml._OnChangedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Intent property in the visual element
        member x.Intent(value: Xamarin.Forms.TableIntent) = x.WithAttributeKeyed(Xaml._IntentPropertyKey, box ((value)))

        /// Adjusts the HasUnevenRows property in the visual element
        member x.HasUnevenRows(value: bool) = x.WithAttributeKeyed(Xaml._HasUnevenRowsPropertyKey, box ((value)))

        /// Adjusts the RowHeight property in the visual element
        member x.RowHeight(value: int) = x.WithAttributeKeyed(Xaml._RowHeightPropertyKey, box ((value)))

        /// Adjusts the TableRoot property in the visual element
        member x.TableRoot(value: (string * ViewElement list) list) = x.WithAttributeKeyed(Xaml._TableRootPropertyKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(value)))

        /// Adjusts the RowDefinitionHeight property in the visual element
        member x.RowDefinitionHeight(value: obj) = x.WithAttributeKeyed(Xaml._RowDefinitionHeightPropertyKey, box (makeGridLength(value)))

        /// Adjusts the ColumnDefinitionWidth property in the visual element
        member x.ColumnDefinitionWidth(value: obj) = x.WithAttributeKeyed(Xaml._ColumnDefinitionWidthPropertyKey, box (makeGridLength(value)))

        /// Adjusts the GridRowDefinitions property in the visual element
        member x.GridRowDefinitions(value: obj list) = x.WithAttributeKeyed(Xaml._GridRowDefinitionsPropertyKey, box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(value)))

        /// Adjusts the GridColumnDefinitions property in the visual element
        member x.GridColumnDefinitions(value: obj list) = x.WithAttributeKeyed(Xaml._GridColumnDefinitionsPropertyKey, box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(value)))

        /// Adjusts the RowSpacing property in the visual element
        member x.RowSpacing(value: double) = x.WithAttributeKeyed(Xaml._RowSpacingPropertyKey, box ((value)))

        /// Adjusts the ColumnSpacing property in the visual element
        member x.ColumnSpacing(value: double) = x.WithAttributeKeyed(Xaml._ColumnSpacingPropertyKey, box ((value)))

        /// Adjusts the Children property in the visual element
        member x.Children(value: ViewElement list) = x.WithAttributeKeyed(Xaml._ChildrenPropertyKey, box (Array.ofList(value)))

        /// Adjusts the GridRow property in the visual element
        member x.GridRow(value: int) = x.WithAttributeKeyed(Xaml._GridRowPropertyKey, box ((value)))

        /// Adjusts the GridRowSpan property in the visual element
        member x.GridRowSpan(value: int) = x.WithAttributeKeyed(Xaml._GridRowSpanPropertyKey, box ((value)))

        /// Adjusts the GridColumn property in the visual element
        member x.GridColumn(value: int) = x.WithAttributeKeyed(Xaml._GridColumnPropertyKey, box ((value)))

        /// Adjusts the GridColumnSpan property in the visual element
        member x.GridColumnSpan(value: int) = x.WithAttributeKeyed(Xaml._GridColumnSpanPropertyKey, box ((value)))

        /// Adjusts the LayoutBounds property in the visual element
        member x.LayoutBounds(value: Xamarin.Forms.Rectangle) = x.WithAttributeKeyed(Xaml._LayoutBoundsPropertyKey, box ((value)))

        /// Adjusts the LayoutFlags property in the visual element
        member x.LayoutFlags(value: Xamarin.Forms.AbsoluteLayoutFlags) = x.WithAttributeKeyed(Xaml._LayoutFlagsPropertyKey, box ((value)))

        /// Adjusts the BoundsConstraint property in the visual element
        member x.BoundsConstraint(value: Xamarin.Forms.BoundsConstraint) = x.WithAttributeKeyed(Xaml._BoundsConstraintPropertyKey, box ((value)))

        /// Adjusts the HeightConstraint property in the visual element
        member x.HeightConstraint(value: Xamarin.Forms.Constraint) = x.WithAttributeKeyed(Xaml._HeightConstraintPropertyKey, box ((value)))

        /// Adjusts the WidthConstraint property in the visual element
        member x.WidthConstraint(value: Xamarin.Forms.Constraint) = x.WithAttributeKeyed(Xaml._WidthConstraintPropertyKey, box ((value)))

        /// Adjusts the XConstraint property in the visual element
        member x.XConstraint(value: Xamarin.Forms.Constraint) = x.WithAttributeKeyed(Xaml._XConstraintPropertyKey, box ((value)))

        /// Adjusts the YConstraint property in the visual element
        member x.YConstraint(value: Xamarin.Forms.Constraint) = x.WithAttributeKeyed(Xaml._YConstraintPropertyKey, box ((value)))

        /// Adjusts the AlignContent property in the visual element
        member x.AlignContent(value: Xamarin.Forms.FlexAlignContent) = x.WithAttributeKeyed(Xaml._AlignContentPropertyKey, box ((value)))

        /// Adjusts the AlignItems property in the visual element
        member x.AlignItems(value: Xamarin.Forms.FlexAlignItems) = x.WithAttributeKeyed(Xaml._AlignItemsPropertyKey, box ((value)))

        /// Adjusts the Direction property in the visual element
        member x.Direction(value: Xamarin.Forms.FlexDirection) = x.WithAttributeKeyed(Xaml._DirectionPropertyKey, box ((value)))

        /// Adjusts the Position property in the visual element
        member x.Position(value: Xamarin.Forms.FlexPosition) = x.WithAttributeKeyed(Xaml._PositionPropertyKey, box ((value)))

        /// Adjusts the Wrap property in the visual element
        member x.Wrap(value: Xamarin.Forms.FlexWrap) = x.WithAttributeKeyed(Xaml._WrapPropertyKey, box ((value)))

        /// Adjusts the JustifyContent property in the visual element
        member x.JustifyContent(value: Xamarin.Forms.FlexJustify) = x.WithAttributeKeyed(Xaml._JustifyContentPropertyKey, box ((value)))

        /// Adjusts the FlexAlignSelf property in the visual element
        member x.FlexAlignSelf(value: Xamarin.Forms.FlexAlignSelf) = x.WithAttributeKeyed(Xaml._FlexAlignSelfPropertyKey, box ((value)))

        /// Adjusts the FlexOrder property in the visual element
        member x.FlexOrder(value: int) = x.WithAttributeKeyed(Xaml._FlexOrderPropertyKey, box ((value)))

        /// Adjusts the FlexBasis property in the visual element
        member x.FlexBasis(value: Xamarin.Forms.FlexBasis) = x.WithAttributeKeyed(Xaml._FlexBasisPropertyKey, box ((value)))

        /// Adjusts the FlexGrow property in the visual element
        member x.FlexGrow(value: double) = x.WithAttributeKeyed(Xaml._FlexGrowPropertyKey, box (single(value)))

        /// Adjusts the FlexShrink property in the visual element
        member x.FlexShrink(value: double) = x.WithAttributeKeyed(Xaml._FlexShrinkPropertyKey, box (single(value)))

        /// Adjusts the Date property in the visual element
        member x.Date(value: System.DateTime) = x.WithAttributeKeyed(Xaml._DatePropertyKey, box ((value)))

        /// Adjusts the Format property in the visual element
        member x.Format(value: string) = x.WithAttributeKeyed(Xaml._FormatPropertyKey, box ((value)))

        /// Adjusts the MinimumDate property in the visual element
        member x.MinimumDate(value: System.DateTime) = x.WithAttributeKeyed(Xaml._MinimumDatePropertyKey, box ((value)))

        /// Adjusts the MaximumDate property in the visual element
        member x.MaximumDate(value: System.DateTime) = x.WithAttributeKeyed(Xaml._MaximumDatePropertyKey, box ((value)))

        /// Adjusts the DateSelected property in the visual element
        member x.DateSelected(value: Xamarin.Forms.DateChangedEventArgs -> unit) = x.WithAttributeKeyed(Xaml._DateSelectedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the PickerItemsSource property in the visual element
        member x.PickerItemsSource(value: seq<'T>) = x.WithAttributeKeyed(Xaml._PickerItemsSourcePropertyKey, box (seqToIListUntyped(value)))

        /// Adjusts the SelectedIndex property in the visual element
        member x.SelectedIndex(value: int) = x.WithAttributeKeyed(Xaml._SelectedIndexPropertyKey, box ((value)))

        /// Adjusts the Title property in the visual element
        member x.Title(value: string) = x.WithAttributeKeyed(Xaml._TitlePropertyKey, box ((value)))

        /// Adjusts the SelectedIndexChanged property in the visual element
        member x.SelectedIndexChanged(value: (int * 'T option) -> unit) = x.WithAttributeKeyed(Xaml._SelectedIndexChangedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(value)))

        /// Adjusts the FrameCornerRadius property in the visual element
        member x.FrameCornerRadius(value: double) = x.WithAttributeKeyed(Xaml._FrameCornerRadiusPropertyKey, box (single(value)))

        /// Adjusts the HasShadow property in the visual element
        member x.HasShadow(value: bool) = x.WithAttributeKeyed(Xaml._HasShadowPropertyKey, box ((value)))

        /// Adjusts the ImageSource property in the visual element
        member x.ImageSource(value: string) = x.WithAttributeKeyed(Xaml._ImageSourcePropertyKey, box ((value)))

        /// Adjusts the Aspect property in the visual element
        member x.Aspect(value: Xamarin.Forms.Aspect) = x.WithAttributeKeyed(Xaml._AspectPropertyKey, box ((value)))

        /// Adjusts the IsOpaque property in the visual element
        member x.IsOpaque(value: bool) = x.WithAttributeKeyed(Xaml._IsOpaquePropertyKey, box ((value)))

        /// Adjusts the Keyboard property in the visual element
        member x.Keyboard(value: Xamarin.Forms.Keyboard) = x.WithAttributeKeyed(Xaml._KeyboardPropertyKey, box ((value)))

        /// Adjusts the EditorCompleted property in the visual element
        member x.EditorCompleted(value: string -> unit) = x.WithAttributeKeyed(Xaml._EditorCompletedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(value)))

        /// Adjusts the TextChanged property in the visual element
        member x.TextChanged(value: Xamarin.Forms.TextChangedEventArgs -> unit) = x.WithAttributeKeyed(Xaml._TextChangedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the IsPassword property in the visual element
        member x.IsPassword(value: bool) = x.WithAttributeKeyed(Xaml._IsPasswordPropertyKey, box ((value)))

        /// Adjusts the EntryCompleted property in the visual element
        member x.EntryCompleted(value: string -> unit) = x.WithAttributeKeyed(Xaml._EntryCompletedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(value)))

        /// Adjusts the Label property in the visual element
        member x.Label(value: string) = x.WithAttributeKeyed(Xaml._LabelPropertyKey, box ((value)))

        /// Adjusts the VerticalTextAlignment property in the visual element
        member x.VerticalTextAlignment(value: Xamarin.Forms.TextAlignment) = x.WithAttributeKeyed(Xaml._VerticalTextAlignmentPropertyKey, box ((value)))

        /// Adjusts the FormattedText property in the visual element
        member x.FormattedText(value: ViewElement) = x.WithAttributeKeyed(Xaml._FormattedTextPropertyKey, box ((value)))

        /// Adjusts the StackOrientation property in the visual element
        member x.StackOrientation(value: Xamarin.Forms.StackOrientation) = x.WithAttributeKeyed(Xaml._StackOrientationPropertyKey, box ((value)))

        /// Adjusts the Spacing property in the visual element
        member x.Spacing(value: double) = x.WithAttributeKeyed(Xaml._SpacingPropertyKey, box ((value)))

        /// Adjusts the ForegroundColor property in the visual element
        member x.ForegroundColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._ForegroundColorPropertyKey, box ((value)))

        /// Adjusts the PropertyChanged property in the visual element
        member x.PropertyChanged(value: System.ComponentModel.PropertyChangedEventArgs -> unit) = x.WithAttributeKeyed(Xaml._PropertyChangedPropertyKey, box ((fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Spans property in the visual element
        member x.Spans(value: ViewElement[]) = x.WithAttributeKeyed(Xaml._SpansPropertyKey, box ((value)))

        /// Adjusts the Time property in the visual element
        member x.Time(value: System.TimeSpan) = x.WithAttributeKeyed(Xaml._TimePropertyKey, box ((value)))

        /// Adjusts the WebSource property in the visual element
        member x.WebSource(value: Xamarin.Forms.WebViewSource) = x.WithAttributeKeyed(Xaml._WebSourcePropertyKey, box ((value)))

        /// Adjusts the Navigated property in the visual element
        member x.Navigated(value: Xamarin.Forms.WebNavigatedEventArgs -> unit) = x.WithAttributeKeyed(Xaml._NavigatedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Navigating property in the visual element
        member x.Navigating(value: Xamarin.Forms.WebNavigatingEventArgs -> unit) = x.WithAttributeKeyed(Xaml._NavigatingPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the BackgroundImage property in the visual element
        member x.BackgroundImage(value: string) = x.WithAttributeKeyed(Xaml._BackgroundImagePropertyKey, box ((value)))

        /// Adjusts the Icon property in the visual element
        member x.Icon(value: string) = x.WithAttributeKeyed(Xaml._IconPropertyKey, box ((value)))

        /// Adjusts the IsBusy property in the visual element
        member x.IsBusy(value: bool) = x.WithAttributeKeyed(Xaml._IsBusyPropertyKey, box ((value)))

        /// Adjusts the ToolbarItems property in the visual element
        member x.ToolbarItems(value: ViewElement list) = x.WithAttributeKeyed(Xaml._ToolbarItemsPropertyKey, box (Array.ofList(value)))

        /// Adjusts the UseSafeArea property in the visual element
        member x.UseSafeArea(value: bool) = x.WithAttributeKeyed(Xaml._UseSafeAreaPropertyKey, box ((value)))

        /// Adjusts the Page_Appearing property in the visual element
        member x.Page_Appearing(value: unit -> unit) = x.WithAttributeKeyed(Xaml._Page_AppearingPropertyKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(value)))

        /// Adjusts the Page_Disappearing property in the visual element
        member x.Page_Disappearing(value: unit -> unit) = x.WithAttributeKeyed(Xaml._Page_DisappearingPropertyKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(value)))

        /// Adjusts the Page_LayoutChanged property in the visual element
        member x.Page_LayoutChanged(value: unit -> unit) = x.WithAttributeKeyed(Xaml._Page_LayoutChangedPropertyKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(value)))

        /// Adjusts the CarouselPage_SelectedItem property in the visual element
        member x.CarouselPage_SelectedItem(value: System.Object) = x.WithAttributeKeyed(Xaml._CarouselPage_SelectedItemPropertyKey, box ((value)))

        /// Adjusts the CurrentPage property in the visual element
        member x.CurrentPage(value: ViewElement) = x.WithAttributeKeyed(Xaml._CurrentPagePropertyKey, box ((value)))

        /// Adjusts the CurrentPageChanged property in the visual element
        member x.CurrentPageChanged(value: 'T option -> unit) = x.WithAttributeKeyed(Xaml._CurrentPageChangedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(value)))

        /// Adjusts the Pages property in the visual element
        member x.Pages(value: ViewElement list) = x.WithAttributeKeyed(Xaml._PagesPropertyKey, box (Array.ofList(value)))

        /// Adjusts the BackButtonTitle property in the visual element
        member x.BackButtonTitle(value: string) = x.WithAttributeKeyed(Xaml._BackButtonTitlePropertyKey, box ((value)))

        /// Adjusts the HasBackButton property in the visual element
        member x.HasBackButton(value: bool) = x.WithAttributeKeyed(Xaml._HasBackButtonPropertyKey, box ((value)))

        /// Adjusts the HasNavigationBar property in the visual element
        member x.HasNavigationBar(value: bool) = x.WithAttributeKeyed(Xaml._HasNavigationBarPropertyKey, box ((value)))

        /// Adjusts the TitleIcon property in the visual element
        member x.TitleIcon(value: string) = x.WithAttributeKeyed(Xaml._TitleIconPropertyKey, box ((value)))

        /// Adjusts the BarBackgroundColor property in the visual element
        member x.BarBackgroundColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._BarBackgroundColorPropertyKey, box ((value)))

        /// Adjusts the BarTextColor property in the visual element
        member x.BarTextColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._BarTextColorPropertyKey, box ((value)))

        /// Adjusts the Popped property in the visual element
        member x.Popped(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttributeKeyed(Xaml._PoppedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value)))

        /// Adjusts the PoppedToRoot property in the visual element
        member x.PoppedToRoot(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttributeKeyed(Xaml._PoppedToRootPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value)))

        /// Adjusts the Pushed property in the visual element
        member x.Pushed(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttributeKeyed(Xaml._PushedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value)))

        /// Adjusts the OnSizeAllocatedCallback property in the visual element
        member x.OnSizeAllocatedCallback(value: (double * double) -> unit) = x.WithAttributeKeyed(Xaml._OnSizeAllocatedCallbackPropertyKey, box ((fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(value)))

        /// Adjusts the Master property in the visual element
        member x.Master(value: ViewElement) = x.WithAttributeKeyed(Xaml._MasterPropertyKey, box ((value)))

        /// Adjusts the Detail property in the visual element
        member x.Detail(value: ViewElement) = x.WithAttributeKeyed(Xaml._DetailPropertyKey, box ((value)))

        /// Adjusts the IsGestureEnabled property in the visual element
        member x.IsGestureEnabled(value: bool) = x.WithAttributeKeyed(Xaml._IsGestureEnabledPropertyKey, box ((value)))

        /// Adjusts the IsPresented property in the visual element
        member x.IsPresented(value: bool) = x.WithAttributeKeyed(Xaml._IsPresentedPropertyKey, box ((value)))

        /// Adjusts the MasterBehavior property in the visual element
        member x.MasterBehavior(value: Xamarin.Forms.MasterBehavior) = x.WithAttributeKeyed(Xaml._MasterBehaviorPropertyKey, box ((value)))

        /// Adjusts the IsPresentedChanged property in the visual element
        member x.IsPresentedChanged(value: bool -> unit) = x.WithAttributeKeyed(Xaml._IsPresentedChangedPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(value)))

        /// Adjusts the TextDetail property in the visual element
        member x.TextDetail(value: string) = x.WithAttributeKeyed(Xaml._TextDetailPropertyKey, box ((value)))

        /// Adjusts the TextDetailColor property in the visual element
        member x.TextDetailColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._TextDetailColorPropertyKey, box ((value)))

        /// Adjusts the TextCellCommand property in the visual element
        member x.TextCellCommand(value: unit -> unit) = x.WithAttributeKeyed(Xaml._TextCellCommandPropertyKey, box ((value)))

        /// Adjusts the TextCellCanExecute property in the visual element
        member x.TextCellCanExecute(value: bool) = x.WithAttributeKeyed(Xaml._TextCellCanExecutePropertyKey, box ((value)))

        /// Adjusts the Order property in the visual element
        member x.Order(value: Xamarin.Forms.ToolbarItemOrder) = x.WithAttributeKeyed(Xaml._OrderPropertyKey, box ((value)))

        /// Adjusts the Priority property in the visual element
        member x.Priority(value: int) = x.WithAttributeKeyed(Xaml._PriorityPropertyKey, box ((value)))

        /// Adjusts the View property in the visual element
        member x.View(value: ViewElement) = x.WithAttributeKeyed(Xaml._ViewPropertyKey, box ((value)))

        /// Adjusts the ListViewItems property in the visual element
        member x.ListViewItems(value: seq<ViewElement>) = x.WithAttributeKeyed(Xaml._ListViewItemsPropertyKey, box ((value)))

        /// Adjusts the Footer property in the visual element
        member x.Footer(value: System.Object) = x.WithAttributeKeyed(Xaml._FooterPropertyKey, box ((value)))

        /// Adjusts the Header property in the visual element
        member x.Header(value: System.Object) = x.WithAttributeKeyed(Xaml._HeaderPropertyKey, box ((value)))

        /// Adjusts the HeaderTemplate property in the visual element
        member x.HeaderTemplate(value: Xamarin.Forms.DataTemplate) = x.WithAttributeKeyed(Xaml._HeaderTemplatePropertyKey, box ((value)))

        /// Adjusts the IsGroupingEnabled property in the visual element
        member x.IsGroupingEnabled(value: bool) = x.WithAttributeKeyed(Xaml._IsGroupingEnabledPropertyKey, box ((value)))

        /// Adjusts the IsPullToRefreshEnabled property in the visual element
        member x.IsPullToRefreshEnabled(value: bool) = x.WithAttributeKeyed(Xaml._IsPullToRefreshEnabledPropertyKey, box ((value)))

        /// Adjusts the IsRefreshing property in the visual element
        member x.IsRefreshing(value: bool) = x.WithAttributeKeyed(Xaml._IsRefreshingPropertyKey, box ((value)))

        /// Adjusts the RefreshCommand property in the visual element
        member x.RefreshCommand(value: unit -> unit) = x.WithAttributeKeyed(Xaml._RefreshCommandPropertyKey, box (makeCommand(value)))

        /// Adjusts the ListView_SelectedItem property in the visual element
        member x.ListView_SelectedItem(value: int option) = x.WithAttributeKeyed(Xaml._ListView_SelectedItemPropertyKey, box ((value)))

        /// Adjusts the ListView_SeparatorVisibility property in the visual element
        member x.ListView_SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttributeKeyed(Xaml._ListView_SeparatorVisibilityPropertyKey, box ((value)))

        /// Adjusts the ListView_SeparatorColor property in the visual element
        member x.ListView_SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._ListView_SeparatorColorPropertyKey, box ((value)))

        /// Adjusts the ListView_ItemAppearing property in the visual element
        member x.ListView_ItemAppearing(value: int -> unit) = x.WithAttributeKeyed(Xaml._ListView_ItemAppearingPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_ItemDisappearing property in the visual element
        member x.ListView_ItemDisappearing(value: int -> unit) = x.WithAttributeKeyed(Xaml._ListView_ItemDisappearingPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_ItemSelected property in the visual element
        member x.ListView_ItemSelected(value: int option -> unit) = x.WithAttributeKeyed(Xaml._ListView_ItemSelectedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(value)))

        /// Adjusts the ListView_ItemTapped property in the visual element
        member x.ListView_ItemTapped(value: int -> unit) = x.WithAttributeKeyed(Xaml._ListView_ItemTappedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_Refreshing property in the visual element
        member x.ListView_Refreshing(value: unit -> unit) = x.WithAttributeKeyed(Xaml._ListView_RefreshingPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f ()))(value)))

        /// Adjusts the ListViewGrouped_ItemsSource property in the visual element
        member x.ListViewGrouped_ItemsSource(value: (ViewElement * ViewElement list) list) = x.WithAttributeKeyed(Xaml._ListViewGrouped_ItemsSourcePropertyKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(value)))

        /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
        member x.ListViewGrouped_SelectedItem(value: (int * int) option) = x.WithAttributeKeyed(Xaml._ListViewGrouped_SelectedItemPropertyKey, box ((value)))

        /// Adjusts the SeparatorVisibility property in the visual element
        member x.SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttributeKeyed(Xaml._SeparatorVisibilityPropertyKey, box ((value)))

        /// Adjusts the SeparatorColor property in the visual element
        member x.SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml._SeparatorColorPropertyKey, box ((value)))

        /// Adjusts the ListViewGrouped_ItemAppearing property in the visual element
        member x.ListViewGrouped_ItemAppearing(value: int * int -> unit) = x.WithAttributeKeyed(Xaml._ListViewGrouped_ItemAppearingPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListViewGrouped_ItemDisappearing property in the visual element
        member x.ListViewGrouped_ItemDisappearing(value: int * int -> unit) = x.WithAttributeKeyed(Xaml._ListViewGrouped_ItemDisappearingPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
        member x.ListViewGrouped_ItemSelected(value: (int * int) option -> unit) = x.WithAttributeKeyed(Xaml._ListViewGrouped_ItemSelectedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(value)))

        /// Adjusts the ListViewGrouped_ItemTapped property in the visual element
        member x.ListViewGrouped_ItemTapped(value: int * int -> unit) = x.WithAttributeKeyed(Xaml._ListViewGrouped_ItemTappedPropertyKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the Refreshing property in the visual element
        member x.Refreshing(value: unit -> unit) = x.WithAttributeKeyed(Xaml._RefreshingPropertyKey, box ((fun f -> System.EventHandler(fun sender args -> f ()))(value)))


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
