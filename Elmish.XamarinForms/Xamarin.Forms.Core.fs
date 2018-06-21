namespace Elmish.XamarinForms.DynamicViews 

#nowarn "67" // cast always holds

type Xaml() =
    static member val internal ClassIdKey = XamlElement.GetKey("ClassId")
    static member val internal StyleIdKey = XamlElement.GetKey("StyleId")
    static member val internal AnchorXKey = XamlElement.GetKey("AnchorX")
    static member val internal AnchorYKey = XamlElement.GetKey("AnchorY")
    static member val internal BackgroundColorKey = XamlElement.GetKey("BackgroundColor")
    static member val internal HeightRequestKey = XamlElement.GetKey("HeightRequest")
    static member val internal InputTransparentKey = XamlElement.GetKey("InputTransparent")
    static member val internal IsEnabledKey = XamlElement.GetKey("IsEnabled")
    static member val internal IsVisibleKey = XamlElement.GetKey("IsVisible")
    static member val internal MinimumHeightRequestKey = XamlElement.GetKey("MinimumHeightRequest")
    static member val internal MinimumWidthRequestKey = XamlElement.GetKey("MinimumWidthRequest")
    static member val internal OpacityKey = XamlElement.GetKey("Opacity")
    static member val internal RotationKey = XamlElement.GetKey("Rotation")
    static member val internal RotationXKey = XamlElement.GetKey("RotationX")
    static member val internal RotationYKey = XamlElement.GetKey("RotationY")
    static member val internal ScaleKey = XamlElement.GetKey("Scale")
    static member val internal StyleKey = XamlElement.GetKey("Style")
    static member val internal TranslationXKey = XamlElement.GetKey("TranslationX")
    static member val internal TranslationYKey = XamlElement.GetKey("TranslationY")
    static member val internal WidthRequestKey = XamlElement.GetKey("WidthRequest")
    static member val internal ResourcesKey = XamlElement.GetKey("Resources")
    static member val internal StylesKey = XamlElement.GetKey("Styles")
    static member val internal StyleSheetsKey = XamlElement.GetKey("StyleSheets")
    static member val internal HorizontalOptionsKey = XamlElement.GetKey("HorizontalOptions")
    static member val internal VerticalOptionsKey = XamlElement.GetKey("VerticalOptions")
    static member val internal MarginKey = XamlElement.GetKey("Margin")
    static member val internal GestureRecognizersKey = XamlElement.GetKey("GestureRecognizers")
    static member val internal TouchPointsKey = XamlElement.GetKey("TouchPoints")
    static member val internal PanUpdatedKey = XamlElement.GetKey("PanUpdated")
    static member val internal CommandKey = XamlElement.GetKey("Command")
    static member val internal NumberOfTapsRequiredKey = XamlElement.GetKey("NumberOfTapsRequired")
    static member val internal NumberOfClicksRequiredKey = XamlElement.GetKey("NumberOfClicksRequired")
    static member val internal ButtonsKey = XamlElement.GetKey("Buttons")
    static member val internal IsPinchingKey = XamlElement.GetKey("IsPinching")
    static member val internal PinchUpdatedKey = XamlElement.GetKey("PinchUpdated")
    static member val internal ColorKey = XamlElement.GetKey("Color")
    static member val internal IsRunningKey = XamlElement.GetKey("IsRunning")
    static member val internal ProgressKey = XamlElement.GetKey("Progress")
    static member val internal ContentKey = XamlElement.GetKey("Content")
    static member val internal ScrollOrientationKey = XamlElement.GetKey("ScrollOrientation")
    static member val internal CancelButtonColorKey = XamlElement.GetKey("CancelButtonColor")
    static member val internal FontFamilyKey = XamlElement.GetKey("FontFamily")
    static member val internal FontAttributesKey = XamlElement.GetKey("FontAttributes")
    static member val internal FontSizeKey = XamlElement.GetKey("FontSize")
    static member val internal HorizontalTextAlignmentKey = XamlElement.GetKey("HorizontalTextAlignment")
    static member val internal PlaceholderKey = XamlElement.GetKey("Placeholder")
    static member val internal PlaceholderColorKey = XamlElement.GetKey("PlaceholderColor")
    static member val internal SearchBarCommandKey = XamlElement.GetKey("SearchBarCommand")
    static member val internal SearchBarCanExecuteKey = XamlElement.GetKey("SearchBarCanExecute")
    static member val internal TextKey = XamlElement.GetKey("Text")
    static member val internal TextColorKey = XamlElement.GetKey("TextColor")
    static member val internal ButtonCommandKey = XamlElement.GetKey("ButtonCommand")
    static member val internal ButtonCanExecuteKey = XamlElement.GetKey("ButtonCanExecute")
    static member val internal BorderColorKey = XamlElement.GetKey("BorderColor")
    static member val internal BorderWidthKey = XamlElement.GetKey("BorderWidth")
    static member val internal CommandParameterKey = XamlElement.GetKey("CommandParameter")
    static member val internal ContentLayoutKey = XamlElement.GetKey("ContentLayout")
    static member val internal ButtonCornerRadiusKey = XamlElement.GetKey("ButtonCornerRadius")
    static member val internal ButtonImageSourceKey = XamlElement.GetKey("ButtonImageSource")
    static member val internal MinimumKey = XamlElement.GetKey("Minimum")
    static member val internal MaximumKey = XamlElement.GetKey("Maximum")
    static member val internal ValueKey = XamlElement.GetKey("Value")
    static member val internal ValueChangedKey = XamlElement.GetKey("ValueChanged")
    static member val internal IncrementKey = XamlElement.GetKey("Increment")
    static member val internal IsToggledKey = XamlElement.GetKey("IsToggled")
    static member val internal ToggledKey = XamlElement.GetKey("Toggled")
    static member val internal OnKey = XamlElement.GetKey("On")
    static member val internal OnChangedKey = XamlElement.GetKey("OnChanged")
    static member val internal IntentKey = XamlElement.GetKey("Intent")
    static member val internal HasUnevenRowsKey = XamlElement.GetKey("HasUnevenRows")
    static member val internal RowHeightKey = XamlElement.GetKey("RowHeight")
    static member val internal TableRootKey = XamlElement.GetKey("TableRoot")
    static member val internal GridRowDefinitionsKey = XamlElement.GetKey("GridRowDefinitions")
    static member val internal GridColumnDefinitionsKey = XamlElement.GetKey("GridColumnDefinitions")
    static member val internal RowSpacingKey = XamlElement.GetKey("RowSpacing")
    static member val internal ColumnSpacingKey = XamlElement.GetKey("ColumnSpacing")
    static member val internal ChildrenKey = XamlElement.GetKey("Children")
    static member val internal GridRowKey = XamlElement.GetKey("GridRow")
    static member val internal GridRowSpanKey = XamlElement.GetKey("GridRowSpan")
    static member val internal GridColumnKey = XamlElement.GetKey("GridColumn")
    static member val internal GridColumnSpanKey = XamlElement.GetKey("GridColumnSpan")
    static member val internal LayoutBoundsKey = XamlElement.GetKey("LayoutBounds")
    static member val internal LayoutFlagsKey = XamlElement.GetKey("LayoutFlags")
    static member val internal BoundsConstraintKey = XamlElement.GetKey("BoundsConstraint")
    static member val internal HeightConstraintKey = XamlElement.GetKey("HeightConstraint")
    static member val internal WidthConstraintKey = XamlElement.GetKey("WidthConstraint")
    static member val internal XConstraintKey = XamlElement.GetKey("XConstraint")
    static member val internal YConstraintKey = XamlElement.GetKey("YConstraint")
    static member val internal AlignContentKey = XamlElement.GetKey("AlignContent")
    static member val internal AlignItemsKey = XamlElement.GetKey("AlignItems")
    static member val internal DirectionKey = XamlElement.GetKey("Direction")
    static member val internal PositionKey = XamlElement.GetKey("Position")
    static member val internal WrapKey = XamlElement.GetKey("Wrap")
    static member val internal JustifyContentKey = XamlElement.GetKey("JustifyContent")
    static member val internal FlexAlignSelfKey = XamlElement.GetKey("FlexAlignSelf")
    static member val internal FlexOrderKey = XamlElement.GetKey("FlexOrder")
    static member val internal FlexBasisKey = XamlElement.GetKey("FlexBasis")
    static member val internal FlexGrowKey = XamlElement.GetKey("FlexGrow")
    static member val internal FlexShrinkKey = XamlElement.GetKey("FlexShrink")
    static member val internal RowDefinitionHeightKey = XamlElement.GetKey("RowDefinitionHeight")
    static member val internal ColumnDefinitionWidthKey = XamlElement.GetKey("ColumnDefinitionWidth")
    static member val internal DateKey = XamlElement.GetKey("Date")
    static member val internal FormatKey = XamlElement.GetKey("Format")
    static member val internal MinimumDateKey = XamlElement.GetKey("MinimumDate")
    static member val internal MaximumDateKey = XamlElement.GetKey("MaximumDate")
    static member val internal DateSelectedKey = XamlElement.GetKey("DateSelected")
    static member val internal PickerItemsSourceKey = XamlElement.GetKey("PickerItemsSource")
    static member val internal SelectedIndexKey = XamlElement.GetKey("SelectedIndex")
    static member val internal TitleKey = XamlElement.GetKey("Title")
    static member val internal SelectedIndexChangedKey = XamlElement.GetKey("SelectedIndexChanged")
    static member val internal FrameCornerRadiusKey = XamlElement.GetKey("FrameCornerRadius")
    static member val internal HasShadowKey = XamlElement.GetKey("HasShadow")
    static member val internal ImageSourceKey = XamlElement.GetKey("ImageSource")
    static member val internal AspectKey = XamlElement.GetKey("Aspect")
    static member val internal IsOpaqueKey = XamlElement.GetKey("IsOpaque")
    static member val internal KeyboardKey = XamlElement.GetKey("Keyboard")
    static member val internal EditorCompletedKey = XamlElement.GetKey("EditorCompleted")
    static member val internal TextChangedKey = XamlElement.GetKey("TextChanged")
    static member val internal IsPasswordKey = XamlElement.GetKey("IsPassword")
    static member val internal EntryCompletedKey = XamlElement.GetKey("EntryCompleted")
    static member val internal LabelKey = XamlElement.GetKey("Label")
    static member val internal VerticalTextAlignmentKey = XamlElement.GetKey("VerticalTextAlignment")
    static member val internal FormattedTextKey = XamlElement.GetKey("FormattedText")
    static member val internal IsClippedToBoundsKey = XamlElement.GetKey("IsClippedToBounds")
    static member val internal PaddingKey = XamlElement.GetKey("Padding")
    static member val internal StackOrientationKey = XamlElement.GetKey("StackOrientation")
    static member val internal SpacingKey = XamlElement.GetKey("Spacing")
    static member val internal ForegroundColorKey = XamlElement.GetKey("ForegroundColor")
    static member val internal PropertyChangedKey = XamlElement.GetKey("PropertyChanged")
    static member val internal SpansKey = XamlElement.GetKey("Spans")
    static member val internal TimeKey = XamlElement.GetKey("Time")
    static member val internal WebSourceKey = XamlElement.GetKey("WebSource")
    static member val internal NavigatedKey = XamlElement.GetKey("Navigated")
    static member val internal NavigatingKey = XamlElement.GetKey("Navigating")
    static member val internal BackgroundImageKey = XamlElement.GetKey("BackgroundImage")
    static member val internal IconKey = XamlElement.GetKey("Icon")
    static member val internal IsBusyKey = XamlElement.GetKey("IsBusy")
    static member val internal ToolbarItemsKey = XamlElement.GetKey("ToolbarItems")
    static member val internal UseSafeAreaKey = XamlElement.GetKey("UseSafeArea")
    static member val internal Page_AppearingKey = XamlElement.GetKey("Page_Appearing")
    static member val internal Page_DisappearingKey = XamlElement.GetKey("Page_Disappearing")
    static member val internal Page_LayoutChangedKey = XamlElement.GetKey("Page_LayoutChanged")
    static member val internal CarouselPage_SelectedItemKey = XamlElement.GetKey("CarouselPage_SelectedItem")
    static member val internal CurrentPageKey = XamlElement.GetKey("CurrentPage")
    static member val internal CurrentPageChangedKey = XamlElement.GetKey("CurrentPageChanged")
    static member val internal PagesKey = XamlElement.GetKey("Pages")
    static member val internal BackButtonTitleKey = XamlElement.GetKey("BackButtonTitle")
    static member val internal HasBackButtonKey = XamlElement.GetKey("HasBackButton")
    static member val internal HasNavigationBarKey = XamlElement.GetKey("HasNavigationBar")
    static member val internal TitleIconKey = XamlElement.GetKey("TitleIcon")
    static member val internal BarBackgroundColorKey = XamlElement.GetKey("BarBackgroundColor")
    static member val internal BarTextColorKey = XamlElement.GetKey("BarTextColor")
    static member val internal PoppedKey = XamlElement.GetKey("Popped")
    static member val internal PoppedToRootKey = XamlElement.GetKey("PoppedToRoot")
    static member val internal PushedKey = XamlElement.GetKey("Pushed")
    static member val internal OnSizeAllocatedCallbackKey = XamlElement.GetKey("OnSizeAllocatedCallback")
    static member val internal MasterKey = XamlElement.GetKey("Master")
    static member val internal DetailKey = XamlElement.GetKey("Detail")
    static member val internal IsGestureEnabledKey = XamlElement.GetKey("IsGestureEnabled")
    static member val internal IsPresentedKey = XamlElement.GetKey("IsPresented")
    static member val internal MasterBehaviorKey = XamlElement.GetKey("MasterBehavior")
    static member val internal IsPresentedChangedKey = XamlElement.GetKey("IsPresentedChanged")
    static member val internal HeightKey = XamlElement.GetKey("Height")
    static member val internal TextDetailKey = XamlElement.GetKey("TextDetail")
    static member val internal TextDetailColorKey = XamlElement.GetKey("TextDetailColor")
    static member val internal TextCellCommandKey = XamlElement.GetKey("TextCellCommand")
    static member val internal TextCellCanExecuteKey = XamlElement.GetKey("TextCellCanExecute")
    static member val internal OrderKey = XamlElement.GetKey("Order")
    static member val internal PriorityKey = XamlElement.GetKey("Priority")
    static member val internal ViewKey = XamlElement.GetKey("View")
    static member val internal ListViewItemsKey = XamlElement.GetKey("ListViewItems")
    static member val internal FooterKey = XamlElement.GetKey("Footer")
    static member val internal HeaderKey = XamlElement.GetKey("Header")
    static member val internal HeaderTemplateKey = XamlElement.GetKey("HeaderTemplate")
    static member val internal IsGroupingEnabledKey = XamlElement.GetKey("IsGroupingEnabled")
    static member val internal IsPullToRefreshEnabledKey = XamlElement.GetKey("IsPullToRefreshEnabled")
    static member val internal IsRefreshingKey = XamlElement.GetKey("IsRefreshing")
    static member val internal RefreshCommandKey = XamlElement.GetKey("RefreshCommand")
    static member val internal ListView_SelectedItemKey = XamlElement.GetKey("ListView_SelectedItem")
    static member val internal ListView_SeparatorVisibilityKey = XamlElement.GetKey("ListView_SeparatorVisibility")
    static member val internal ListView_SeparatorColorKey = XamlElement.GetKey("ListView_SeparatorColor")
    static member val internal ListView_ItemAppearingKey = XamlElement.GetKey("ListView_ItemAppearing")
    static member val internal ListView_ItemDisappearingKey = XamlElement.GetKey("ListView_ItemDisappearing")
    static member val internal ListView_ItemSelectedKey = XamlElement.GetKey("ListView_ItemSelected")
    static member val internal ListView_ItemTappedKey = XamlElement.GetKey("ListView_ItemTapped")
    static member val internal ListView_RefreshingKey = XamlElement.GetKey("ListView_Refreshing")
    static member val internal ListViewGrouped_ItemsSourceKey = XamlElement.GetKey("ListViewGrouped_ItemsSource")
    static member val internal ListViewGrouped_SelectedItemKey = XamlElement.GetKey("ListViewGrouped_SelectedItem")
    static member val internal SeparatorVisibilityKey = XamlElement.GetKey("SeparatorVisibility")
    static member val internal SeparatorColorKey = XamlElement.GetKey("SeparatorColor")
    static member val internal ListViewGrouped_ItemAppearingKey = XamlElement.GetKey("ListViewGrouped_ItemAppearing")
    static member val internal ListViewGrouped_ItemDisappearingKey = XamlElement.GetKey("ListViewGrouped_ItemDisappearing")
    static member val internal ListViewGrouped_ItemSelectedKey = XamlElement.GetKey("ListViewGrouped_ItemSelected")
    static member val internal ListViewGrouped_ItemTappedKey = XamlElement.GetKey("ListViewGrouped_ItemTapped")
    static member val internal RefreshingKey = XamlElement.GetKey("Refreshing")

    /// Describes a Element in the view
    static member internal Element(?classId: string, ?styleId: string) = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            match classId with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ClassIdKey, box ((v)))) 
            match styleId with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.StyleIdKey, box ((v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Element"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.Element)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.ClassIdKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.ClassIdKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ClassId <-  value
            | ValueSome _, ValueNone -> target.ClassId <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.StyleIdKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.StyleIdKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.StyleId <-  value
            | ValueSome _, ValueNone -> target.StyleId <- null
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Element>, create, update, attribs)

    /// Describes a VisualElement in the view
    static member internal VisualElement(?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match anchorX with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.AnchorXKey, box ((v)))) 
            match anchorY with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.AnchorYKey, box ((v)))) 
            match backgroundColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BackgroundColorKey, box ((v)))) 
            match heightRequest with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HeightRequestKey, box ((v)))) 
            match inputTransparent with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.InputTransparentKey, box ((v)))) 
            match isEnabled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsEnabledKey, box ((v)))) 
            match isVisible with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsVisibleKey, box ((v)))) 
            match minimumHeightRequest with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MinimumHeightRequestKey, box ((v)))) 
            match minimumWidthRequest with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MinimumWidthRequestKey, box ((v)))) 
            match opacity with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.OpacityKey, box ((v)))) 
            match rotation with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RotationKey, box ((v)))) 
            match rotationX with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RotationXKey, box ((v)))) 
            match rotationY with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RotationYKey, box ((v)))) 
            match scale with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ScaleKey, box ((v)))) 
            match style with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.StyleKey, box ((v)))) 
            match translationX with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TranslationXKey, box ((v)))) 
            match translationY with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TranslationYKey, box ((v)))) 
            match widthRequest with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.WidthRequestKey, box ((v)))) 
            match resources with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ResourcesKey, box ((v)))) 
            match styles with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.StylesKey, box ((v)))) 
            match styleSheets with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.StyleSheetsKey, box ((v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.VisualElement"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.VisualElement)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.AnchorXKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.AnchorXKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.AnchorX <-  value
            | ValueSome _, ValueNone -> target.AnchorX <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.AnchorYKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.AnchorYKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.AnchorY <-  value
            | ValueSome _, ValueNone -> target.AnchorY <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BackgroundColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BackgroundColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.HeightRequestKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.HeightRequestKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HeightRequest <-  value
            | ValueSome _, ValueNone -> target.HeightRequest <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.InputTransparentKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.InputTransparentKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.InputTransparent <-  value
            | ValueSome _, ValueNone -> target.InputTransparent <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsEnabledKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsEnabledKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsEnabled <-  value
            | ValueSome _, ValueNone -> target.IsEnabled <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsVisibleKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsVisibleKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsVisible <-  value
            | ValueSome _, ValueNone -> target.IsVisible <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.MinimumHeightRequestKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.MinimumHeightRequestKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.MinimumHeightRequest <-  value
            | ValueSome _, ValueNone -> target.MinimumHeightRequest <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.MinimumWidthRequestKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.MinimumWidthRequestKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.MinimumWidthRequest <-  value
            | ValueSome _, ValueNone -> target.MinimumWidthRequest <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.OpacityKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.OpacityKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Opacity <-  value
            | ValueSome _, ValueNone -> target.Opacity <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.RotationKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.RotationKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Rotation <-  value
            | ValueSome _, ValueNone -> target.Rotation <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.RotationXKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.RotationXKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RotationX <-  value
            | ValueSome _, ValueNone -> target.RotationX <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.RotationYKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.RotationYKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RotationY <-  value
            | ValueSome _, ValueNone -> target.RotationY <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.ScaleKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.ScaleKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Scale <-  value
            | ValueSome _, ValueNone -> target.Scale <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Style>(Xaml.StyleKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Style>(Xaml.StyleKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Style <-  value
            | ValueSome _, ValueNone -> target.Style <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.TranslationXKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.TranslationXKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TranslationX <-  value
            | ValueSome _, ValueNone -> target.TranslationX <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.TranslationYKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.TranslationYKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TranslationY <-  value
            | ValueSome _, ValueNone -> target.TranslationY <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.WidthRequestKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.WidthRequestKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.WidthRequest <-  value
            | ValueSome _, ValueNone -> target.WidthRequest <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<(string * obj) list>(Xaml.ResourcesKey)
            let valueOpt = source.TryGetAttributeKeyed<(string * obj) list>(Xaml.ResourcesKey)
            updateResources prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Style list>(Xaml.StylesKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Style list>(Xaml.StylesKey)
            updateStyles prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.StyleSheets.StyleSheet list>(Xaml.StyleSheetsKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.StyleSheets.StyleSheet list>(Xaml.StyleSheetsKey)
            updateStyleSheets prevValueOpt valueOpt target

        new XamlElement(typeof<Xamarin.Forms.VisualElement>, create, update, attribs)

    /// Describes a View in the view
    static member internal View(?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.VisualElement(?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match horizontalOptions with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HorizontalOptionsKey, box ((v)))) 
            match verticalOptions with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.VerticalOptionsKey, box ((v)))) 
            match margin with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MarginKey, box (makeThickness(v)))) 
            match gestureRecognizers with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.GestureRecognizersKey, box (Array.ofList(v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.View"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.View)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.LayoutOptions>(Xaml.HorizontalOptionsKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.LayoutOptions>(Xaml.HorizontalOptionsKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HorizontalOptions <-  value
            | ValueSome _, ValueNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.LayoutOptions>(Xaml.VerticalOptionsKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.LayoutOptions>(Xaml.VerticalOptionsKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.VerticalOptions <-  value
            | ValueSome _, ValueNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Thickness>(Xaml.MarginKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Thickness>(Xaml.MarginKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Margin <-  value
            | ValueSome _, ValueNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.GestureRecognizersKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.GestureRecognizersKey)
            updateIList prevValueOpt valueOpt target.GestureRecognizers
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.IGestureRecognizer)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild

        new XamlElement(typeof<Xamarin.Forms.View>, create, update, attribs)

    /// Describes a IGestureRecognizer in the view
    static member internal IGestureRecognizer() = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.IGestureRecognizer"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            ()

        new XamlElement(typeof<Xamarin.Forms.IGestureRecognizer>, create, update, attribs)

    /// Describes a PanGestureRecognizer in the view
    static member PanGestureRecognizer(?touchPoints: int, ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match touchPoints with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TouchPointsKey, box ((v)))) 
            match panUpdated with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PanUpdatedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.PanGestureRecognizer())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.PanGestureRecognizer)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<int>(Xaml.TouchPointsKey)
            let valueOpt = source.TryGetAttributeKeyed<int>(Xaml.TouchPointsKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TouchPoints <-  value
            | ValueSome _, ValueNone -> target.TouchPoints <- 1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>>(Xaml.PanUpdatedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>>(Xaml.PanUpdatedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.PanUpdated.RemoveHandler(prevValue); target.PanUpdated.AddHandler(value)
            | ValueNone, ValueSome value -> target.PanUpdated.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.PanUpdated.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.PanGestureRecognizer>, create, update, attribs)

    /// Describes a TapGestureRecognizer in the view
    static member TapGestureRecognizer(?command: unit -> unit, ?numberOfTapsRequired: int, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match command with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CommandKey, box (makeCommand(v)))) 
            match numberOfTapsRequired with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.NumberOfTapsRequiredKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.TapGestureRecognizer())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.TapGestureRecognizer)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Windows.Input.ICommand>(Xaml.CommandKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Windows.Input.ICommand>(Xaml.CommandKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Command <-  value
            | ValueSome _, ValueNone -> target.Command <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<int>(Xaml.NumberOfTapsRequiredKey)
            let valueOpt = source.TryGetAttributeKeyed<int>(Xaml.NumberOfTapsRequiredKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.NumberOfTapsRequired <-  value
            | ValueSome _, ValueNone -> target.NumberOfTapsRequired <- 1
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.TapGestureRecognizer>, create, update, attribs)

    /// Describes a ClickGestureRecognizer in the view
    static member ClickGestureRecognizer(?command: unit -> unit, ?numberOfClicksRequired: int, ?buttons: Xamarin.Forms.ButtonsMask, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match command with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CommandKey, box (makeCommand(v)))) 
            match numberOfClicksRequired with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.NumberOfClicksRequiredKey, box ((v)))) 
            match buttons with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ButtonsKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ClickGestureRecognizer())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ClickGestureRecognizer)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Windows.Input.ICommand>(Xaml.CommandKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Windows.Input.ICommand>(Xaml.CommandKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Command <-  value
            | ValueSome _, ValueNone -> target.Command <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<int>(Xaml.NumberOfClicksRequiredKey)
            let valueOpt = source.TryGetAttributeKeyed<int>(Xaml.NumberOfClicksRequiredKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.NumberOfClicksRequired <-  value
            | ValueSome _, ValueNone -> target.NumberOfClicksRequired <- 1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.ButtonsMask>(Xaml.ButtonsKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.ButtonsMask>(Xaml.ButtonsKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Buttons <-  value
            | ValueSome _, ValueNone -> target.Buttons <- Xamarin.Forms.ButtonsMask.Primary
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ClickGestureRecognizer>, create, update, attribs)

    /// Describes a PinchGestureRecognizer in the view
    static member PinchGestureRecognizer(?isPinching: bool, ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match isPinching with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsPinchingKey, box ((v)))) 
            match pinchUpdated with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PinchUpdatedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.PinchGestureRecognizer())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.PinchGestureRecognizer)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsPinchingKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsPinchingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsPinching <-  value
            | ValueSome _, ValueNone -> target.IsPinching <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>>(Xaml.PinchUpdatedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>>(Xaml.PinchUpdatedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.PinchUpdated.RemoveHandler(prevValue); target.PinchUpdated.AddHandler(value)
            | ValueNone, ValueSome value -> target.PinchUpdated.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.PinchUpdated.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.PinchGestureRecognizer>, create, update, attribs)

    /// Describes a ActivityIndicator in the view
    static member ActivityIndicator(?color: Xamarin.Forms.Color, ?isRunning: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match color with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ColorKey, box ((v)))) 
            match isRunning with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsRunningKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ActivityIndicator())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ActivityIndicator)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.ColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.ColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Color <-  value
            | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsRunningKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsRunningKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsRunning <-  value
            | ValueSome _, ValueNone -> target.IsRunning <- false
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ActivityIndicator>, create, update, attribs)

    /// Describes a BoxView in the view
    static member BoxView(?color: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match color with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ColorKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.BoxView())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.BoxView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.ColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.ColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Color <-  value
            | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.BoxView>, create, update, attribs)

    /// Describes a ProgressBar in the view
    static member ProgressBar(?progress: double, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match progress with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ProgressKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ProgressBar())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ProgressBar)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.ProgressKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.ProgressKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Progress <-  value
            | ValueSome _, ValueNone -> target.Progress <- 0.0
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ProgressBar>, create, update, attribs)

    /// Describes a ScrollView in the view
    static member ScrollView(?content: XamlElement, ?orientation: Xamarin.Forms.ScrollOrientation, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match content with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ContentKey, box ((v)))) 
            match orientation with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ScrollOrientationKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ScrollView())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ScrollView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement>(Xaml.ContentKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement>(Xaml.ContentKey)
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | _, ValueSome newChild ->
                target.Content <- (newChild.Create() :?> Xamarin.Forms.View)
            | ValueSome _, ValueNone ->
                target.Content <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.ScrollOrientation>(Xaml.ScrollOrientationKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.ScrollOrientation>(Xaml.ScrollOrientationKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Orientation <-  value
            | ValueSome _, ValueNone -> target.Orientation <- Unchecked.defaultof<Xamarin.Forms.ScrollOrientation>
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ScrollView>, create, update, attribs)

    /// Describes a SearchBar in the view
    static member SearchBar(?cancelButtonColor: Xamarin.Forms.Color, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?placeholder: string, ?placeholderColor: Xamarin.Forms.Color, ?searchCommand: unit -> unit, ?canExecute: bool, ?text: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match cancelButtonColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CancelButtonColorKey, box ((v)))) 
            match fontFamily with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontFamilyKey, box ((v)))) 
            match fontAttributes with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontAttributesKey, box ((v)))) 
            match fontSize with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontSizeKey, box (makeFontSize(v)))) 
            match horizontalTextAlignment with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HorizontalTextAlignmentKey, box ((v)))) 
            match placeholder with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PlaceholderKey, box ((v)))) 
            match placeholderColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PlaceholderColorKey, box ((v)))) 
            match searchCommand with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SearchBarCommandKey, box ((v)))) 
            match canExecute with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SearchBarCanExecuteKey, box ((v)))) 
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match textColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextColorKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.SearchBar())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.SearchBar)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.CancelButtonColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.CancelButtonColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.CancelButtonColor <-  value
            | ValueSome _, ValueNone -> target.CancelButtonColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.TextAlignment>(Xaml.HorizontalTextAlignmentKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.TextAlignment>(Xaml.HorizontalTextAlignmentKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.PlaceholderKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.PlaceholderKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Placeholder <-  value
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.PlaceholderColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.PlaceholderColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.PlaceholderColor <-  value
            | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<unit -> unit>(Xaml.SearchBarCommandKey)
            let valueOpt = source.TryGetAttributeKeyed<unit -> unit>(Xaml.SearchBarCommandKey)
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.SearchBarCanExecuteKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.SearchBarCanExecuteKey)
            updateCommand (match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<_>(Xaml.SearchBarCommandKey)) prevValueOpt (source.TryGetAttributeKeyed<_>(Xaml.SearchBarCommandKey)) valueOpt (fun cmd -> target.SearchCommand <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.SearchBar>, create, update, attribs)

    /// Describes a Button in the view
    static member Button(?text: string, ?command: unit -> unit, ?canExecute: bool, ?borderColor: Xamarin.Forms.Color, ?borderWidth: double, ?commandParameter: System.Object, ?contentLayout: Xamarin.Forms.Button.ButtonContentLayout, ?cornerRadius: int, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?image: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match command with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ButtonCommandKey, box ((v)))) 
            match canExecute with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ButtonCanExecuteKey, box ((v)))) 
            match borderColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BorderColorKey, box ((v)))) 
            match borderWidth with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BorderWidthKey, box ((v)))) 
            match commandParameter with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CommandParameterKey, box ((v)))) 
            match contentLayout with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ContentLayoutKey, box ((v)))) 
            match cornerRadius with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ButtonCornerRadiusKey, box ((v)))) 
            match fontFamily with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontFamilyKey, box ((v)))) 
            match fontAttributes with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontAttributesKey, box ((v)))) 
            match fontSize with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontSizeKey, box (makeFontSize(v)))) 
            match image with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ButtonImageSourceKey, box ((v)))) 
            match textColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextColorKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Button())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Button)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<unit -> unit>(Xaml.ButtonCommandKey)
            let valueOpt = source.TryGetAttributeKeyed<unit -> unit>(Xaml.ButtonCommandKey)
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.ButtonCanExecuteKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.ButtonCanExecuteKey)
            updateCommand (match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<_>(Xaml.ButtonCommandKey)) prevValueOpt (source.TryGetAttributeKeyed<_>(Xaml.ButtonCommandKey)) valueOpt (fun cmd -> target.Command <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BorderColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BorderColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BorderColor <-  value
            | ValueSome _, ValueNone -> target.BorderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.BorderWidthKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.BorderWidthKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BorderWidth <-  value
            | ValueSome _, ValueNone -> target.BorderWidth <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Object>(Xaml.CommandParameterKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Object>(Xaml.CommandParameterKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.CommandParameter <-  value
            | ValueSome _, ValueNone -> target.CommandParameter <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Button.ButtonContentLayout>(Xaml.ContentLayoutKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Button.ButtonContentLayout>(Xaml.ContentLayoutKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ContentLayout <-  value
            | ValueSome _, ValueNone -> target.ContentLayout <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<int>(Xaml.ButtonCornerRadiusKey)
            let valueOpt = source.TryGetAttributeKeyed<int>(Xaml.ButtonCornerRadiusKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.CornerRadius <-  value
            | ValueSome _, ValueNone -> target.CornerRadius <- 0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.ButtonImageSourceKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.ButtonImageSourceKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Image <- makeFileImageSource  value
            | ValueSome _, ValueNone -> target.Image <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Button>, create, update, attribs)

    /// Describes a Slider in the view
    static member Slider(?minimum: double, ?maximum: double, ?value: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match minimum with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MinimumKey, box ((v)))) 
            match maximum with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MaximumKey, box ((v)))) 
            match value with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ValueKey, box ((v)))) 
            match valueChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ValueChangedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Slider())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Slider)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.MinimumKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.MinimumKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Minimum <-  value
            | ValueSome _, ValueNone -> target.Minimum <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.MaximumKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.MaximumKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Maximum <-  value
            | ValueSome _, ValueNone -> target.Maximum <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.ValueKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.ValueKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Value <-  value
            | ValueSome _, ValueNone -> target.Value <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>>(Xaml.ValueChangedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>>(Xaml.ValueChangedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ValueChanged.RemoveHandler(prevValue); target.ValueChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.ValueChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ValueChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Slider>, create, update, attribs)

    /// Describes a Stepper in the view
    static member Stepper(?minimum: double, ?maximum: double, ?value: double, ?increment: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match minimum with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MinimumKey, box ((v)))) 
            match maximum with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MaximumKey, box ((v)))) 
            match value with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ValueKey, box ((v)))) 
            match increment with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IncrementKey, box ((v)))) 
            match valueChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ValueChangedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Stepper())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Stepper)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.MinimumKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.MinimumKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Minimum <-  value
            | ValueSome _, ValueNone -> target.Minimum <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.MaximumKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.MaximumKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Maximum <-  value
            | ValueSome _, ValueNone -> target.Maximum <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.ValueKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.ValueKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Value <-  value
            | ValueSome _, ValueNone -> target.Value <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.IncrementKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.IncrementKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Increment <-  value
            | ValueSome _, ValueNone -> target.Increment <- 1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>>(Xaml.ValueChangedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>>(Xaml.ValueChangedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ValueChanged.RemoveHandler(prevValue); target.ValueChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.ValueChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ValueChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Stepper>, create, update, attribs)

    /// Describes a Switch in the view
    static member Switch(?isToggled: bool, ?toggled: Xamarin.Forms.ToggledEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match isToggled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsToggledKey, box ((v)))) 
            match toggled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ToggledKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Switch())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Switch)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsToggledKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsToggledKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsToggled <-  value
            | ValueSome _, ValueNone -> target.IsToggled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>(Xaml.ToggledKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>(Xaml.ToggledKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Toggled.RemoveHandler(prevValue); target.Toggled.AddHandler(value)
            | ValueNone, ValueSome value -> target.Toggled.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Toggled.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Switch>, create, update, attribs)

    /// Describes a SwitchCell in the view
    static member SwitchCell(?on: bool, ?text: string, ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match on with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.OnKey, box ((v)))) 
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match onChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.OnChangedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.SwitchCell())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.SwitchCell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.OnKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.OnKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.On <-  value
            | ValueSome _, ValueNone -> target.On <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>(Xaml.OnChangedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ToggledEventArgs>>(Xaml.OnChangedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.OnChanged.RemoveHandler(prevValue); target.OnChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.OnChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.OnChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.SwitchCell>, create, update, attribs)

    /// Describes a TableView in the view
    static member TableView(?intent: Xamarin.Forms.TableIntent, ?hasUnevenRows: bool, ?rowHeight: int, ?items: (string * XamlElement list) list, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match intent with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IntentKey, box ((v)))) 
            match hasUnevenRows with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HasUnevenRowsKey, box ((v)))) 
            match rowHeight with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RowHeightKey, box ((v)))) 
            match items with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TableRootKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.TableView())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.TableView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.TableIntent>(Xaml.IntentKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.TableIntent>(Xaml.IntentKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Intent <-  value
            | ValueSome _, ValueNone -> target.Intent <- Unchecked.defaultof<Xamarin.Forms.TableIntent>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.HasUnevenRowsKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.HasUnevenRowsKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HasUnevenRows <-  value
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<int>(Xaml.RowHeightKey)
            let valueOpt = source.TryGetAttributeKeyed<int>(Xaml.RowHeightKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RowHeight <-  value
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<(string * XamlElement[])[]>(Xaml.TableRootKey)
            let valueOpt = source.TryGetAttributeKeyed<(string * XamlElement[])[]>(Xaml.TableRootKey)
            updateTableViewItems prevValueOpt valueOpt target

        new XamlElement(typeof<Xamarin.Forms.TableView>, create, update, attribs)

    /// Describes a Grid in the view
    static member Grid(?rowdefs: obj list, ?coldefs: obj list, ?rowSpacing: double, ?columnSpacing: double, ?children: XamlElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match rowdefs with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.GridRowDefinitionsKey, box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(v)))) 
            match coldefs with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.GridColumnDefinitionsKey, box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(v)))) 
            match rowSpacing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RowSpacingKey, box ((v)))) 
            match columnSpacing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ColumnSpacingKey, box ((v)))) 
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Grid())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Grid)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.GridRowDefinitionsKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.GridRowDefinitionsKey)
            updateIList prevValueOpt valueOpt target.RowDefinitions
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.RowDefinition)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.GridColumnDefinitionsKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.GridColumnDefinitionsKey)
            updateIList prevValueOpt valueOpt target.ColumnDefinitions
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.ColumnDefinition)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.RowSpacingKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.RowSpacingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RowSpacing <-  value
            | ValueSome _, ValueNone -> target.RowSpacing <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.ColumnSpacingKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.ColumnSpacingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ColumnSpacing <-  value
            | ValueSome _, ValueNone -> target.ColumnSpacing <- 0.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml.GridRowKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml.GridRowKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetRow(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRow(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml.GridRowSpanKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml.GridRowSpanKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetRowSpan(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRowSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml.GridColumnKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml.GridColumnKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetColumn(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumn(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml.GridColumnSpanKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml.GridColumnSpanKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild

        new XamlElement(typeof<Xamarin.Forms.Grid>, create, update, attribs)

    /// Describes a AbsoluteLayout in the view
    static member AbsoluteLayout(?children: XamlElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.AbsoluteLayout())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.AbsoluteLayout)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Rectangle>(Xaml.LayoutBoundsKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Rectangle>(Xaml.LayoutBoundsKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, Xamarin.Forms.Rectangle.Zero) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.AbsoluteLayoutFlags>(Xaml.LayoutFlagsKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.AbsoluteLayoutFlags>(Xaml.LayoutFlagsKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, Xamarin.Forms.AbsoluteLayoutFlags.None) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild

        new XamlElement(typeof<Xamarin.Forms.AbsoluteLayout>, create, update, attribs)

    /// Describes a RelativeLayout in the view
    static member RelativeLayout(?children: XamlElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.RelativeLayout())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.RelativeLayout)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.BoundsConstraint>(Xaml.BoundsConstraintKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.BoundsConstraint>(Xaml.BoundsConstraintKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.HeightConstraintKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.HeightConstraintKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.WidthConstraintKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.WidthConstraintKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.XConstraintKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.XConstraintKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.YConstraintKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.YConstraintKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild

        new XamlElement(typeof<Xamarin.Forms.RelativeLayout>, create, update, attribs)

    /// Describes a FlexLayout in the view
    static member FlexLayout(?alignContent: Xamarin.Forms.FlexAlignContent, ?alignItems: Xamarin.Forms.FlexAlignItems, ?direction: Xamarin.Forms.FlexDirection, ?position: Xamarin.Forms.FlexPosition, ?wrap: Xamarin.Forms.FlexWrap, ?justifyContent: Xamarin.Forms.FlexJustify, ?children: XamlElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match alignContent with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.AlignContentKey, box ((v)))) 
            match alignItems with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.AlignItemsKey, box ((v)))) 
            match direction with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.DirectionKey, box ((v)))) 
            match position with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PositionKey, box ((v)))) 
            match wrap with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.WrapKey, box ((v)))) 
            match justifyContent with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.JustifyContentKey, box ((v)))) 
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.FlexLayout())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.FlexLayout)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignContent>(Xaml.AlignContentKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignContent>(Xaml.AlignContentKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.AlignContent <-  value
            | ValueSome _, ValueNone -> target.AlignContent <- Unchecked.defaultof<Xamarin.Forms.FlexAlignContent>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignItems>(Xaml.AlignItemsKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignItems>(Xaml.AlignItemsKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.AlignItems <-  value
            | ValueSome _, ValueNone -> target.AlignItems <- Unchecked.defaultof<Xamarin.Forms.FlexAlignItems>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FlexDirection>(Xaml.DirectionKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FlexDirection>(Xaml.DirectionKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Direction <-  value
            | ValueSome _, ValueNone -> target.Direction <- Unchecked.defaultof<Xamarin.Forms.FlexDirection>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FlexPosition>(Xaml.PositionKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FlexPosition>(Xaml.PositionKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Position <-  value
            | ValueSome _, ValueNone -> target.Position <- Unchecked.defaultof<Xamarin.Forms.FlexPosition>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FlexWrap>(Xaml.WrapKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FlexWrap>(Xaml.WrapKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Wrap <-  value
            | ValueSome _, ValueNone -> target.Wrap <- Unchecked.defaultof<Xamarin.Forms.FlexWrap>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FlexJustify>(Xaml.JustifyContentKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FlexJustify>(Xaml.JustifyContentKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.JustifyContent <-  value
            | ValueSome _, ValueNone -> target.JustifyContent <- Unchecked.defaultof<Xamarin.Forms.FlexJustify>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignSelf>(Xaml.FlexAlignSelfKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignSelf>(Xaml.FlexAlignSelfKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.FlexLayout.SetAlignSelf(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetAlignSelf(targetChild, Unchecked.defaultof<Xamarin.Forms.FlexAlignSelf>) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml.FlexOrderKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml.FlexOrderKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.FlexLayout.SetOrder(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetOrder(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.FlexBasis>(Xaml.FlexBasisKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.FlexBasis>(Xaml.FlexBasisKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.FlexLayout.SetBasis(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetBasis(targetChild, Unchecked.defaultof<Xamarin.Forms.FlexBasis>) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<single>(Xaml.FlexGrowKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<single>(Xaml.FlexGrowKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.FlexLayout.SetGrow(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetGrow(targetChild, 0.0f) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<single>(Xaml.FlexShrinkKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<single>(Xaml.FlexShrinkKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.FlexLayout.SetShrink(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetShrink(targetChild, 1.0f) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild

        new XamlElement(typeof<Xamarin.Forms.FlexLayout>, create, update, attribs)

    /// Describes a RowDefinition in the view
    static member RowDefinition(?height: obj) = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            match height with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RowDefinitionHeightKey, box (makeGridLength(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.RowDefinition())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.RowDefinition)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.GridLength>(Xaml.RowDefinitionHeightKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.GridLength>(Xaml.RowDefinitionHeightKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Height <-  value
            | ValueSome _, ValueNone -> target.Height <- Xamarin.Forms.GridLength.Auto
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.RowDefinition>, create, update, attribs)

    /// Describes a ColumnDefinition in the view
    static member ColumnDefinition(?width: obj) = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            match width with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ColumnDefinitionWidthKey, box (makeGridLength(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ColumnDefinition())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.ColumnDefinition)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.GridLength>(Xaml.ColumnDefinitionWidthKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.GridLength>(Xaml.ColumnDefinitionWidthKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Width <-  value
            | ValueSome _, ValueNone -> target.Width <- Xamarin.Forms.GridLength.Auto
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ColumnDefinition>, create, update, attribs)

    /// Describes a ContentView in the view
    static member ContentView(?content: XamlElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.TemplatedView(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match content with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ContentKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ContentView())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ContentView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement>(Xaml.ContentKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement>(Xaml.ContentKey)
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | _, ValueSome newChild ->
                target.Content <- (newChild.Create() :?> Xamarin.Forms.View)
            | ValueSome _, ValueNone ->
                target.Content <- null
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ContentView>, create, update, attribs)

    /// Describes a TemplatedView in the view
    static member TemplatedView(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
          |]

        let create () =
            box (new Xamarin.Forms.TemplatedView())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            ()

        new XamlElement(typeof<Xamarin.Forms.TemplatedView>, create, update, attribs)

    /// Describes a DatePicker in the view
    static member DatePicker(?date: System.DateTime, ?format: string, ?minimumDate: System.DateTime, ?maximumDate: System.DateTime, ?dateSelected: Xamarin.Forms.DateChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match date with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.DateKey, box ((v)))) 
            match format with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FormatKey, box ((v)))) 
            match minimumDate with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MinimumDateKey, box ((v)))) 
            match maximumDate with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MaximumDateKey, box ((v)))) 
            match dateSelected with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.DateSelectedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.DatePicker())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.DatePicker)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.DateTime>(Xaml.DateKey)
            let valueOpt = source.TryGetAttributeKeyed<System.DateTime>(Xaml.DateKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Date <-  value
            | ValueSome _, ValueNone -> target.Date <- Unchecked.defaultof<System.DateTime>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.FormatKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.FormatKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Format <-  value
            | ValueSome _, ValueNone -> target.Format <- "d"
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.DateTime>(Xaml.MinimumDateKey)
            let valueOpt = source.TryGetAttributeKeyed<System.DateTime>(Xaml.MinimumDateKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.MinimumDate <-  value
            | ValueSome _, ValueNone -> target.MinimumDate <- new System.DateTime(1900, 1, 1)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.DateTime>(Xaml.MaximumDateKey)
            let valueOpt = source.TryGetAttributeKeyed<System.DateTime>(Xaml.MaximumDateKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.MaximumDate <-  value
            | ValueSome _, ValueNone -> target.MaximumDate <- new System.DateTime(2100, 12, 31)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.DateChangedEventArgs>>(Xaml.DateSelectedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.DateChangedEventArgs>>(Xaml.DateSelectedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.DateSelected.RemoveHandler(prevValue); target.DateSelected.AddHandler(value)
            | ValueNone, ValueSome value -> target.DateSelected.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.DateSelected.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.DatePicker>, create, update, attribs)

    /// Describes a Picker in the view
    static member Picker(?itemsSource: seq<'T>, ?selectedIndex: int, ?title: string, ?textColor: Xamarin.Forms.Color, ?selectedIndexChanged: (int * 'T option) -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match itemsSource with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PickerItemsSourceKey, box (seqToIList(v)))) 
            match selectedIndex with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SelectedIndexKey, box ((v)))) 
            match title with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TitleKey, box ((v)))) 
            match textColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextColorKey, box ((v)))) 
            match selectedIndexChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SelectedIndexChangedKey, box ((fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Picker())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Picker)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Collections.IList>(Xaml.PickerItemsSourceKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Collections.IList>(Xaml.PickerItemsSourceKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ItemsSource <-  value
            | ValueSome _, ValueNone -> target.ItemsSource <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<int>(Xaml.SelectedIndexKey)
            let valueOpt = source.TryGetAttributeKeyed<int>(Xaml.SelectedIndexKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SelectedIndex <-  value
            | ValueSome _, ValueNone -> target.SelectedIndex <- 0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TitleKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TitleKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Title <-  value
            | ValueSome _, ValueNone -> target.Title <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.SelectedIndexChangedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.SelectedIndexChangedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.SelectedIndexChanged.RemoveHandler(prevValue); target.SelectedIndexChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.SelectedIndexChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.SelectedIndexChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Picker>, create, update, attribs)

    /// Describes a Frame in the view
    static member Frame(?borderColor: Xamarin.Forms.Color, ?cornerRadius: double, ?hasShadow: bool, ?content: XamlElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.ContentView(?content=content, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match borderColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BorderColorKey, box ((v)))) 
            match cornerRadius with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FrameCornerRadiusKey, box (single(v)))) 
            match hasShadow with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HasShadowKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Frame())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Frame)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BorderColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BorderColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BorderColor <-  value
            | ValueSome _, ValueNone -> target.BorderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<single>(Xaml.FrameCornerRadiusKey)
            let valueOpt = source.TryGetAttributeKeyed<single>(Xaml.FrameCornerRadiusKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.CornerRadius <-  value
            | ValueSome _, ValueNone -> target.CornerRadius <- -1.0f
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.HasShadowKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.HasShadowKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HasShadow <-  value
            | ValueSome _, ValueNone -> target.HasShadow <- true
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Frame>, create, update, attribs)

    /// Describes a Image in the view
    static member Image(?source: string, ?aspect: Xamarin.Forms.Aspect, ?isOpaque: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match source with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ImageSourceKey, box ((v)))) 
            match aspect with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.AspectKey, box ((v)))) 
            match isOpaque with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsOpaqueKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Image())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Image)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.ImageSourceKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.ImageSourceKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Source <- makeImageSource  value
            | ValueSome _, ValueNone -> target.Source <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Aspect>(Xaml.AspectKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Aspect>(Xaml.AspectKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Aspect <-  value
            | ValueSome _, ValueNone -> target.Aspect <- Xamarin.Forms.Aspect.AspectFit
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsOpaqueKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsOpaqueKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsOpaque <-  value
            | ValueSome _, ValueNone -> target.IsOpaque <- true
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Image>, create, update, attribs)

    /// Describes a InputView in the view
    static member internal InputView(?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match keyboard with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.KeyboardKey, box ((v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.InputView"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.InputView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Keyboard>(Xaml.KeyboardKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Keyboard>(Xaml.KeyboardKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Keyboard <-  value
            | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.InputView>, create, update, attribs)

    /// Describes a Editor in the view
    static member Editor(?text: string, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.InputView(?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match fontSize with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontSizeKey, box (makeFontSize(v)))) 
            match fontFamily with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontFamilyKey, box ((v)))) 
            match fontAttributes with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontAttributesKey, box ((v)))) 
            match textColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextColorKey, box ((v)))) 
            match completed with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.EditorCompletedKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(v)))) 
            match textChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextChangedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Editor())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Editor)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.EditorCompletedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.EditorCompletedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | ValueNone, ValueSome value -> target.Completed.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.TextChangedEventArgs>>(Xaml.TextChangedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.TextChangedEventArgs>>(Xaml.TextChangedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.TextChanged.RemoveHandler(prevValue); target.TextChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.TextChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.TextChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Editor>, create, update, attribs)

    /// Describes a Entry in the view
    static member Entry(?text: string, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?placeholderColor: Xamarin.Forms.Color, ?isPassword: bool, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.InputView(?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match placeholder with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PlaceholderKey, box ((v)))) 
            match horizontalTextAlignment with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HorizontalTextAlignmentKey, box ((v)))) 
            match fontSize with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontSizeKey, box (makeFontSize(v)))) 
            match fontFamily with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontFamilyKey, box ((v)))) 
            match fontAttributes with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontAttributesKey, box ((v)))) 
            match textColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextColorKey, box ((v)))) 
            match placeholderColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PlaceholderColorKey, box ((v)))) 
            match isPassword with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsPasswordKey, box ((v)))) 
            match completed with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.EntryCompletedKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(v)))) 
            match textChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextChangedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Entry())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Entry)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.PlaceholderKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.PlaceholderKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Placeholder <-  value
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.TextAlignment>(Xaml.HorizontalTextAlignmentKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.TextAlignment>(Xaml.HorizontalTextAlignmentKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.PlaceholderColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.PlaceholderColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.PlaceholderColor <-  value
            | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsPasswordKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsPasswordKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsPassword <-  value
            | ValueSome _, ValueNone -> target.IsPassword <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.EntryCompletedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.EntryCompletedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | ValueNone, ValueSome value -> target.Completed.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.TextChangedEventArgs>>(Xaml.TextChangedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.TextChangedEventArgs>>(Xaml.TextChangedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.TextChanged.RemoveHandler(prevValue); target.TextChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.TextChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.TextChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Entry>, create, update, attribs)

    /// Describes a EntryCell in the view
    static member EntryCell(?label: string, ?text: string, ?keyboard: Xamarin.Forms.Keyboard, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?completed: string -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match label with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.LabelKey, box ((v)))) 
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match keyboard with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.KeyboardKey, box ((v)))) 
            match placeholder with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PlaceholderKey, box ((v)))) 
            match horizontalTextAlignment with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HorizontalTextAlignmentKey, box ((v)))) 
            match completed with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.EntryCompletedKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.EntryCell).Text))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.EntryCell())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.EntryCell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.LabelKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.LabelKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Label <-  value
            | ValueSome _, ValueNone -> target.Label <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Keyboard>(Xaml.KeyboardKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Keyboard>(Xaml.KeyboardKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Keyboard <-  value
            | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.PlaceholderKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.PlaceholderKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Placeholder <-  value
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.TextAlignment>(Xaml.HorizontalTextAlignmentKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.TextAlignment>(Xaml.HorizontalTextAlignmentKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.EntryCompletedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.EntryCompletedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(value)
            | ValueNone, ValueSome value -> target.Completed.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.EntryCell>, create, update, attribs)

    /// Describes a Label in the view
    static member Label(?text: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?verticalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?formattedText: XamlElement, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match horizontalTextAlignment with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HorizontalTextAlignmentKey, box ((v)))) 
            match verticalTextAlignment with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.VerticalTextAlignmentKey, box ((v)))) 
            match fontSize with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontSizeKey, box (makeFontSize(v)))) 
            match fontFamily with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontFamilyKey, box ((v)))) 
            match fontAttributes with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontAttributesKey, box ((v)))) 
            match textColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextColorKey, box ((v)))) 
            match formattedText with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FormattedTextKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Label())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Label)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.TextAlignment>(Xaml.HorizontalTextAlignmentKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.TextAlignment>(Xaml.HorizontalTextAlignmentKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HorizontalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.TextAlignment>(Xaml.VerticalTextAlignmentKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.TextAlignment>(Xaml.VerticalTextAlignmentKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.VerticalTextAlignment <-  value
            | ValueSome _, ValueNone -> target.VerticalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement>(Xaml.FormattedTextKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement>(Xaml.FormattedTextKey)
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.FormattedText)
            | _, ValueSome newChild ->
                target.FormattedText <- (newChild.Create() :?> Xamarin.Forms.FormattedString)
            | ValueSome _, ValueNone ->
                target.FormattedText <- null
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Label>, create, update, attribs)

    /// Describes a Layout in the view
    static member internal Layout(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match isClippedToBounds with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsClippedToBoundsKey, box ((v)))) 
            match padding with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PaddingKey, box (makeThickness(v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Layout"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Layout)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsClippedToBoundsKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsClippedToBoundsKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsClippedToBounds <-  value
            | ValueSome _, ValueNone -> target.IsClippedToBounds <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Thickness>(Xaml.PaddingKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Thickness>(Xaml.PaddingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Padding <-  value
            | ValueSome _, ValueNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Layout>, create, update, attribs)

    /// Describes a StackLayout in the view
    static member StackLayout(?children: XamlElement list, ?orientation: Xamarin.Forms.StackOrientation, ?spacing: double, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
            match orientation with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.StackOrientationKey, box ((v)))) 
            match spacing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SpacingKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.StackLayout())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.StackLayout)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.StackOrientation>(Xaml.StackOrientationKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.StackOrientation>(Xaml.StackOrientationKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Orientation <-  value
            | ValueSome _, ValueNone -> target.Orientation <- Xamarin.Forms.StackOrientation.Vertical
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.SpacingKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.SpacingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Spacing <-  value
            | ValueSome _, ValueNone -> target.Spacing <- 6.0
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.StackLayout>, create, update, attribs)

    /// Describes a Span in the view
    static member Span(?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?backgroundColor: Xamarin.Forms.Color, ?foregroundColor: Xamarin.Forms.Color, ?text: string, ?propertyChanged: System.ComponentModel.PropertyChangedEventArgs -> unit) = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            match fontFamily with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontFamilyKey, box ((v)))) 
            match fontAttributes with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontAttributesKey, box ((v)))) 
            match fontSize with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FontSizeKey, box (makeFontSize(v)))) 
            match backgroundColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BackgroundColorKey, box ((v)))) 
            match foregroundColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ForegroundColorKey, box ((v)))) 
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match propertyChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PropertyChangedKey, box ((fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Span())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.Span)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.FontFamilyKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontFamily <-  value
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.FontAttributes>(Xaml.FontAttributesKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontAttributes <-  value
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.FontSizeKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.FontSize <-  value
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BackgroundColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BackgroundColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.ForegroundColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.ForegroundColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ForegroundColor <-  value
            | ValueSome _, ValueNone -> target.ForegroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.ComponentModel.PropertyChangedEventHandler>(Xaml.PropertyChangedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.ComponentModel.PropertyChangedEventHandler>(Xaml.PropertyChangedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.PropertyChanged.RemoveHandler(prevValue); target.PropertyChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.PropertyChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.PropertyChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Span>, create, update, attribs)

    /// Describes a FormattedString in the view
    static member FormattedString(?spans: XamlElement[]) = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            match spans with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SpansKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.FormattedString())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.FormattedString)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.SpansKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.SpansKey)
            updateIList prevValueOpt valueOpt target.Spans
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.Span)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild

        new XamlElement(typeof<Xamarin.Forms.FormattedString>, create, update, attribs)

    /// Describes a TimePicker in the view
    static member TimePicker(?time: System.TimeSpan, ?format: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match time with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TimeKey, box ((v)))) 
            match format with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FormatKey, box ((v)))) 
            match textColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextColorKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.TimePicker())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.TimePicker)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.TimeSpan>(Xaml.TimeKey)
            let valueOpt = source.TryGetAttributeKeyed<System.TimeSpan>(Xaml.TimeKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Time <-  value
            | ValueSome _, ValueNone -> target.Time <- new System.TimeSpan()
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.FormatKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.FormatKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Format <-  value
            | ValueSome _, ValueNone -> target.Format <- "t"
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.TimePicker>, create, update, attribs)

    /// Describes a WebView in the view
    static member WebView(?source: Xamarin.Forms.WebViewSource, ?navigated: Xamarin.Forms.WebNavigatedEventArgs -> unit, ?navigating: Xamarin.Forms.WebNavigatingEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match source with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.WebSourceKey, box ((v)))) 
            match navigated with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.NavigatedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(v)))) 
            match navigating with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.NavigatingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.WebView())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.WebView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.WebViewSource>(Xaml.WebSourceKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.WebViewSource>(Xaml.WebSourceKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Source <-  value
            | ValueSome _, ValueNone -> target.Source <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>>(Xaml.NavigatedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>>(Xaml.NavigatedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Navigated.RemoveHandler(prevValue); target.Navigated.AddHandler(value)
            | ValueNone, ValueSome value -> target.Navigated.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Navigated.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>>(Xaml.NavigatingKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>>(Xaml.NavigatingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Navigating.RemoveHandler(prevValue); target.Navigating.AddHandler(value)
            | ValueNone, ValueSome value -> target.Navigating.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Navigating.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.WebView>, create, update, attribs)

    /// Describes a Page in the view
    static member Page(?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: XamlElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.VisualElement(?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match title with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TitleKey, box ((v)))) 
            match backgroundImage with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BackgroundImageKey, box ((v)))) 
            match icon with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IconKey, box ((v)))) 
            match isBusy with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsBusyKey, box ((v)))) 
            match padding with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PaddingKey, box (makeThickness(v)))) 
            match toolbarItems with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ToolbarItemsKey, box (Array.ofList(v)))) 
            match useSafeArea with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.UseSafeAreaKey, box ((v)))) 
            match appearing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.Page_AppearingKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(v)))) 
            match disappearing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.Page_DisappearingKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(v)))) 
            match layoutChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.Page_LayoutChangedKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Page())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Page)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TitleKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TitleKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Title <-  value
            | ValueSome _, ValueNone -> target.Title <- ""
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.BackgroundImageKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.BackgroundImageKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BackgroundImage <-  value
            | ValueSome _, ValueNone -> target.BackgroundImage <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.IconKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.IconKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Icon <- makeFileImageSource  value
            | ValueSome _, ValueNone -> target.Icon <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsBusyKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsBusyKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsBusy <-  value
            | ValueSome _, ValueNone -> target.IsBusy <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Thickness>(Xaml.PaddingKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Thickness>(Xaml.PaddingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Padding <-  value
            | ValueSome _, ValueNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.ToolbarItemsKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.ToolbarItemsKey)
            updateIList prevValueOpt valueOpt target.ToolbarItems
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.ToolbarItem)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.UseSafeAreaKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.UseSafeAreaKey)
            (fun _ _ target -> Xamarin.Forms.PlatformConfiguration.iOSSpecific.Page.SetUseSafeArea((target :> Xamarin.Forms.Page).On<Xamarin.Forms.PlatformConfiguration.iOS>(), true) |> ignore) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.Page_AppearingKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.Page_AppearingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Appearing.RemoveHandler(prevValue); target.Appearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.Appearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Appearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.Page_DisappearingKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.Page_DisappearingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Disappearing.RemoveHandler(prevValue); target.Disappearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.Disappearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Disappearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.Page_LayoutChangedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.Page_LayoutChangedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.LayoutChanged.RemoveHandler(prevValue); target.LayoutChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.LayoutChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.LayoutChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Page>, create, update, attribs)

    /// Describes a CarouselPage in the view
    static member CarouselPage(?children: XamlElement list, ?selectedItem: System.Object, ?currentPage: XamlElement, ?currentPageChanged: 'T option -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: XamlElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Page(?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
            match selectedItem with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CarouselPage_SelectedItemKey, box ((v)))) 
            match currentPage with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CurrentPageKey, box ((v)))) 
            match currentPageChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CurrentPageChangedKey, box ((fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.CarouselPage())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.CarouselPage)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.ContentPage)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Object>(Xaml.CarouselPage_SelectedItemKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Object>(Xaml.CarouselPage_SelectedItemKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SelectedItem <-  value
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement>(Xaml.CurrentPageKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement>(Xaml.CurrentPageKey)
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.CurrentPage)
            | _, ValueSome newChild ->
                target.CurrentPage <- (newChild.Create() :?> Xamarin.Forms.ContentPage)
            | ValueSome _, ValueNone ->
                target.CurrentPage <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.CurrentPageChangedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.CurrentPageChangedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.CurrentPageChanged.RemoveHandler(prevValue); target.CurrentPageChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.CurrentPageChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.CurrentPageChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.CarouselPage>, create, update, attribs)

    /// Describes a NavigationPage in the view
    static member NavigationPage(?pages: XamlElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?popped: Xamarin.Forms.NavigationEventArgs -> unit, ?poppedToRoot: Xamarin.Forms.NavigationEventArgs -> unit, ?pushed: Xamarin.Forms.NavigationEventArgs -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: XamlElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Page(?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match pages with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PagesKey, box (Array.ofList(v)))) 
            match barBackgroundColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BarBackgroundColorKey, box ((v)))) 
            match barTextColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BarTextColorKey, box ((v)))) 
            match popped with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PoppedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v)))) 
            match poppedToRoot with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PoppedToRootKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v)))) 
            match pushed with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PushedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.NavigationPage())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.NavigationPage)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.PagesKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.PagesKey)
            updateNavigationPages prevValueOpt valueOpt target
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<string>(Xaml.BackButtonTitleKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<string>(Xaml.BackButtonTitleKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<bool>(Xaml.HasBackButtonKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<bool>(Xaml.HasBackButtonKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, true) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<bool>(Xaml.HasNavigationBarKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<bool>(Xaml.HasNavigationBarKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, true) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<string>(Xaml.TitleIconKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<string>(Xaml.TitleIconKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prev, ValueSome v when prev = v -> ()
                    | prevOpt, ValueSome value -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, makeFileImageSource value)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BarBackgroundColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BarBackgroundColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BarBackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BarTextColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BarTextColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BarTextColor <-  value
            | ValueSome _, ValueNone -> target.BarTextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(Xaml.PoppedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(Xaml.PoppedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Popped.RemoveHandler(prevValue); target.Popped.AddHandler(value)
            | ValueNone, ValueSome value -> target.Popped.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Popped.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(Xaml.PoppedToRootKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(Xaml.PoppedToRootKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.PoppedToRoot.RemoveHandler(prevValue); target.PoppedToRoot.AddHandler(value)
            | ValueNone, ValueSome value -> target.PoppedToRoot.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.PoppedToRoot.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(Xaml.PushedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.NavigationEventArgs>>(Xaml.PushedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Pushed.RemoveHandler(prevValue); target.Pushed.AddHandler(value)
            | ValueNone, ValueSome value -> target.Pushed.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Pushed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.NavigationPage>, create, update, attribs)

    /// Describes a TabbedPage in the view
    static member TabbedPage(?children: XamlElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: XamlElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Page(?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
            match barBackgroundColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BarBackgroundColorKey, box ((v)))) 
            match barTextColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BarTextColorKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.TabbedPage())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.TabbedPage)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement[]>(Xaml.ChildrenKey)
            updateIList prevValueOpt valueOpt target.Children
                (fun (x:XamlElement) -> x.Create() :?> Xamarin.Forms.Page)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BarBackgroundColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BarBackgroundColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BarBackgroundColor <-  value
            | ValueSome _, ValueNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BarTextColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.BarTextColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.BarTextColor <-  value
            | ValueSome _, ValueNone -> target.BarTextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.TabbedPage>, create, update, attribs)

    /// Describes a ContentPage in the view
    static member ContentPage(?content: XamlElement, ?onSizeAllocated: (double * double) -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: XamlElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Page(?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match content with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ContentKey, box ((v)))) 
            match onSizeAllocated with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.OnSizeAllocatedCallbackKey, box ((fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomContentPage())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ContentPage)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement>(Xaml.ContentKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement>(Xaml.ContentKey)
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Content)
            | _, ValueSome newChild ->
                target.Content <- (newChild.Create() :?> Xamarin.Forms.View)
            | ValueSome _, ValueNone ->
                target.Content <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<FSharp.Control.Handler<(double * double)>>(Xaml.OnSizeAllocatedCallbackKey)
            let valueOpt = source.TryGetAttributeKeyed<FSharp.Control.Handler<(double * double)>>(Xaml.OnSizeAllocatedCallbackKey)
            updateOnSizeAllocated prevValueOpt valueOpt target

        new XamlElement(typeof<Xamarin.Forms.ContentPage>, create, update, attribs)

    /// Describes a MasterDetailPage in the view
    static member MasterDetailPage(?master: XamlElement, ?detail: XamlElement, ?isGestureEnabled: bool, ?isPresented: bool, ?masterBehavior: Xamarin.Forms.MasterBehavior, ?isPresentedChanged: bool -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: XamlElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Page(?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match master with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MasterKey, box ((v)))) 
            match detail with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.DetailKey, box ((v)))) 
            match isGestureEnabled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsGestureEnabledKey, box ((v)))) 
            match isPresented with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsPresentedKey, box ((v)))) 
            match masterBehavior with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MasterBehaviorKey, box ((v)))) 
            match isPresentedChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsPresentedChangedKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.MasterDetailPage())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.MasterDetailPage)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement>(Xaml.MasterKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement>(Xaml.MasterKey)
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Master)
            | _, ValueSome newChild ->
                target.Master <- (newChild.Create() :?> Xamarin.Forms.Page)
            | ValueSome _, ValueNone ->
                target.Master <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement>(Xaml.DetailKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement>(Xaml.DetailKey)
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.Detail)
            | _, ValueSome newChild ->
                target.Detail <- (newChild.Create() :?> Xamarin.Forms.Page)
            | ValueSome _, ValueNone ->
                target.Detail <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsGestureEnabledKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsGestureEnabledKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsGestureEnabled <-  value
            | ValueSome _, ValueNone -> target.IsGestureEnabled <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsPresentedKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsPresentedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsPresented <-  value
            | ValueSome _, ValueNone -> target.IsPresented <- true
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.MasterBehavior>(Xaml.MasterBehaviorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.MasterBehavior>(Xaml.MasterBehaviorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.MasterBehavior <-  value
            | ValueSome _, ValueNone -> target.MasterBehavior <- Xamarin.Forms.MasterBehavior.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.IsPresentedChangedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.IsPresentedChangedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.IsPresentedChanged.RemoveHandler(prevValue); target.IsPresentedChanged.AddHandler(value)
            | ValueNone, ValueSome value -> target.IsPresentedChanged.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.IsPresentedChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.MasterDetailPage>, create, update, attribs)

    /// Describes a Cell in the view
    static member internal Cell(?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match height with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HeightKey, box ((v)))) 
            match isEnabled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsEnabledKey, box ((v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Cell"

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.Cell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<double>(Xaml.HeightKey)
            let valueOpt = source.TryGetAttributeKeyed<double>(Xaml.HeightKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Height <-  value
            | ValueSome _, ValueNone -> target.Height <- -1.0
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsEnabledKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsEnabledKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsEnabled <-  value
            | ValueSome _, ValueNone -> target.IsEnabled <- true
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.Cell>, create, update, attribs)

    /// Describes a MenuItem in the view
    static member MenuItem(?text: string, ?command: unit -> unit, ?commandParameter: System.Object, ?icon: string, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match command with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CommandKey, box (makeCommand(v)))) 
            match commandParameter with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CommandParameterKey, box ((v)))) 
            match icon with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IconKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.MenuItem())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.MenuItem)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Windows.Input.ICommand>(Xaml.CommandKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Windows.Input.ICommand>(Xaml.CommandKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Command <-  value
            | ValueSome _, ValueNone -> target.Command <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Object>(Xaml.CommandParameterKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Object>(Xaml.CommandParameterKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.CommandParameter <-  value
            | ValueSome _, ValueNone -> target.CommandParameter <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.IconKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.IconKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Icon <- makeFileImageSource  value
            | ValueSome _, ValueNone -> target.Icon <- null
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.MenuItem>, create, update, attribs)

    /// Describes a TextCell in the view
    static member TextCell(?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match detail with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextDetailKey, box ((v)))) 
            match textColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextColorKey, box ((v)))) 
            match detailColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextDetailColorKey, box ((v)))) 
            match command with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextCellCommandKey, box ((v)))) 
            match canExecute with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextCellCanExecuteKey, box ((v)))) 
            match commandParameter with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CommandParameterKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.TextCell())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.TextCell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Text <-  value
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.TextDetailKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.TextDetailKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Detail <-  value
            | ValueSome _, ValueNone -> target.Detail <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.TextColor <-  value
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextDetailColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.TextDetailColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.DetailColor <-  value
            | ValueSome _, ValueNone -> target.DetailColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<unit -> unit>(Xaml.TextCellCommandKey)
            let valueOpt = source.TryGetAttributeKeyed<unit -> unit>(Xaml.TextCellCommandKey)
            (fun _ _ _ -> ()) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.TextCellCanExecuteKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.TextCellCanExecuteKey)
            updateCommand (match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<_>(Xaml.TextCellCommandKey)) prevValueOpt (source.TryGetAttributeKeyed<_>(Xaml.TextCellCommandKey)) valueOpt (fun cmd -> target.Command <- cmd) prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Object>(Xaml.CommandParameterKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Object>(Xaml.CommandParameterKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.CommandParameter <-  value
            | ValueSome _, ValueNone -> target.CommandParameter <- null
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.TextCell>, create, update, attribs)

    /// Describes a ToolbarItem in the view
    static member ToolbarItem(?order: Xamarin.Forms.ToolbarItemOrder, ?priority: int, ?text: string, ?command: unit -> unit, ?commandParameter: System.Object, ?icon: string, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.MenuItem(?text=text, ?command=command, ?commandParameter=commandParameter, ?icon=icon, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match order with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.OrderKey, box ((v)))) 
            match priority with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PriorityKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ToolbarItem())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ToolbarItem)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.ToolbarItemOrder>(Xaml.OrderKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.ToolbarItemOrder>(Xaml.OrderKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Order <-  value
            | ValueSome _, ValueNone -> target.Order <- Xamarin.Forms.ToolbarItemOrder.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<int>(Xaml.PriorityKey)
            let valueOpt = source.TryGetAttributeKeyed<int>(Xaml.PriorityKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Priority <-  value
            | ValueSome _, ValueNone -> target.Priority <- 0
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ToolbarItem>, create, update, attribs)

    /// Describes a ImageCell in the view
    static member ImageCell(?imageSource: string, ?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.TextCell(?text=text, ?detail=detail, ?textColor=textColor, ?detailColor=detailColor, ?command=command, ?canExecute=canExecute, ?commandParameter=commandParameter, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match imageSource with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ImageSourceKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ImageCell())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ImageCell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<string>(Xaml.ImageSourceKey)
            let valueOpt = source.TryGetAttributeKeyed<string>(Xaml.ImageSourceKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.ImageSource <- makeImageSource  value
            | ValueSome _, ValueNone -> target.ImageSource <- null
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ImageCell>, create, update, attribs)

    /// Describes a ViewCell in the view
    static member ViewCell(?view: XamlElement, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match view with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ViewKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ViewCell())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ViewCell)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<XamlElement>(Xaml.ViewKey)
            let valueOpt = source.TryGetAttributeKeyed<XamlElement>(Xaml.ViewKey)
            match prevValueOpt, valueOpt with
            // For structured objects, dependsOn on reference equality
            | ValueSome prevChild, ValueSome newChild when identical prevChild newChild -> ()
            | ValueSome prevChild, ValueSome newChild when canReuseChild prevChild newChild ->
                newChild.UpdateIncremental(prevChild, target.View)
            | _, ValueSome newChild ->
                target.View <- (newChild.Create() :?> Xamarin.Forms.View)
            | ValueSome _, ValueNone ->
                target.View <- null
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ViewCell>, create, update, attribs)

    /// Describes a ListView in the view
    static member ListView(?items: seq<XamlElement>, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?headerTemplate: Xamarin.Forms.DataTemplate, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: int option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: int -> unit, ?itemDisappearing: int -> unit, ?itemSelected: int option -> unit, ?itemTapped: int -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match items with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListViewItemsKey, box ((v)))) 
            match footer with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FooterKey, box ((v)))) 
            match hasUnevenRows with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HasUnevenRowsKey, box ((v)))) 
            match header with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HeaderKey, box ((v)))) 
            match headerTemplate with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HeaderTemplateKey, box ((v)))) 
            match isGroupingEnabled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsGroupingEnabledKey, box ((v)))) 
            match isPullToRefreshEnabled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsPullToRefreshEnabledKey, box ((v)))) 
            match isRefreshing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsRefreshingKey, box ((v)))) 
            match refreshCommand with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RefreshCommandKey, box (makeCommand(v)))) 
            match rowHeight with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RowHeightKey, box ((v)))) 
            match selectedItem with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListView_SelectedItemKey, box ((v)))) 
            match separatorVisibility with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListView_SeparatorVisibilityKey, box ((v)))) 
            match separatorColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListView_SeparatorColorKey, box ((v)))) 
            match itemAppearing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListView_ItemAppearingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v)))) 
            match itemDisappearing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListView_ItemDisappearingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v)))) 
            match itemSelected with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListView_ItemSelectedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(v)))) 
            match itemTapped with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListView_ItemTappedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(v)))) 
            match refreshing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListView_RefreshingKey, box ((fun f -> System.EventHandler(fun sender args -> f ()))(v)))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomListView())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ListView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<seq<XamlElement>>(Xaml.ListViewItemsKey)
            let valueOpt = source.TryGetAttributeKeyed<seq<XamlElement>>(Xaml.ListViewItemsKey)
            updateListViewItems prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Object>(Xaml.FooterKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Object>(Xaml.FooterKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Footer <-  value
            | ValueSome _, ValueNone -> target.Footer <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.HasUnevenRowsKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.HasUnevenRowsKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HasUnevenRows <-  value
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Object>(Xaml.HeaderKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Object>(Xaml.HeaderKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Header <-  value
            | ValueSome _, ValueNone -> target.Header <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.DataTemplate>(Xaml.HeaderTemplateKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.DataTemplate>(Xaml.HeaderTemplateKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HeaderTemplate <-  value
            | ValueSome _, ValueNone -> target.HeaderTemplate <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsGroupingEnabledKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsGroupingEnabledKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsGroupingEnabled <-  value
            | ValueSome _, ValueNone -> target.IsGroupingEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsPullToRefreshEnabledKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsPullToRefreshEnabledKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsPullToRefreshEnabled <-  value
            | ValueSome _, ValueNone -> target.IsPullToRefreshEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsRefreshingKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsRefreshingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsRefreshing <-  value
            | ValueSome _, ValueNone -> target.IsRefreshing <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Windows.Input.ICommand>(Xaml.RefreshCommandKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Windows.Input.ICommand>(Xaml.RefreshCommandKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RefreshCommand <-  value
            | ValueSome _, ValueNone -> target.RefreshCommand <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<int>(Xaml.RowHeightKey)
            let valueOpt = source.TryGetAttributeKeyed<int>(Xaml.RowHeightKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RowHeight <-  value
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<int option>(Xaml.ListView_SelectedItemKey)
            let valueOpt = source.TryGetAttributeKeyed<int option>(Xaml.ListView_SelectedItemKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SelectedItem <- (function None -> null | Some i -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListElementData<XamlElement>> in if i >= 0 && i < items.Count then items.[i] else null)  value
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.SeparatorVisibility>(Xaml.ListView_SeparatorVisibilityKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.SeparatorVisibility>(Xaml.ListView_SeparatorVisibilityKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SeparatorVisibility <-  value
            | ValueSome _, ValueNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.ListView_SeparatorColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.ListView_SeparatorColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SeparatorColor <-  value
            | ValueSome _, ValueNone -> target.SeparatorColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(Xaml.ListView_ItemAppearingKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(Xaml.ListView_ItemAppearingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemAppearing.RemoveHandler(prevValue); target.ItemAppearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemAppearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemAppearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(Xaml.ListView_ItemDisappearingKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(Xaml.ListView_ItemDisappearingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemDisappearing.RemoveHandler(prevValue); target.ItemDisappearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemDisappearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemDisappearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>(Xaml.ListView_ItemSelectedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>(Xaml.ListView_ItemSelectedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemSelected.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemSelected.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>(Xaml.ListView_ItemTappedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>(Xaml.ListView_ItemTappedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemTapped.RemoveHandler(prevValue); target.ItemTapped.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemTapped.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemTapped.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.ListView_RefreshingKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.ListView_RefreshingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Refreshing.RemoveHandler(prevValue); target.Refreshing.AddHandler(value)
            | ValueNone, ValueSome value -> target.Refreshing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Refreshing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ListView>, create, update, attribs)

    /// Describes a ListViewGrouped in the view
    static member ListViewGrouped(?items: (XamlElement * XamlElement list) list, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: (int * int) option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: int * int -> unit, ?itemDisappearing: int * int -> unit, ?itemSelected: (int * int) option -> unit, ?itemTapped: int * int -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: XamlElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : XamlElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match items with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListViewGrouped_ItemsSourceKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(v)))) 
            match footer with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FooterKey, box ((v)))) 
            match hasUnevenRows with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HasUnevenRowsKey, box ((v)))) 
            match header with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HeaderKey, box ((v)))) 
            match isGroupingEnabled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsGroupingEnabledKey, box ((v)))) 
            match isPullToRefreshEnabled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsPullToRefreshEnabledKey, box ((v)))) 
            match isRefreshing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsRefreshingKey, box ((v)))) 
            match refreshCommand with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RefreshCommandKey, box (makeCommand(v)))) 
            match rowHeight with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RowHeightKey, box ((v)))) 
            match selectedItem with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListViewGrouped_SelectedItemKey, box ((v)))) 
            match separatorVisibility with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SeparatorVisibilityKey, box ((v)))) 
            match separatorColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SeparatorColorKey, box ((v)))) 
            match itemAppearing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListViewGrouped_ItemAppearingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v)))) 
            match itemDisappearing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListViewGrouped_ItemDisappearingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v)))) 
            match itemSelected with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListViewGrouped_ItemSelectedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(v)))) 
            match itemTapped with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ListViewGrouped_ItemTappedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(v)))) 
            match refreshing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RefreshingKey, box ((fun f -> System.EventHandler(fun sender args -> f ()))(v)))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomGroupListView())

        let update (prevOpt: XamlElement voption) (source: XamlElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt source targetObj
            let target = (targetObj :?> Xamarin.Forms.ListView)
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<(XamlElement * XamlElement[])[]>(Xaml.ListViewGrouped_ItemsSourceKey)
            let valueOpt = source.TryGetAttributeKeyed<(XamlElement * XamlElement[])[]>(Xaml.ListViewGrouped_ItemsSourceKey)
            updateListViewGroupedItems prevValueOpt valueOpt target
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Object>(Xaml.FooterKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Object>(Xaml.FooterKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Footer <-  value
            | ValueSome _, ValueNone -> target.Footer <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.HasUnevenRowsKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.HasUnevenRowsKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.HasUnevenRows <-  value
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Object>(Xaml.HeaderKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Object>(Xaml.HeaderKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.Header <-  value
            | ValueSome _, ValueNone -> target.Header <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsGroupingEnabledKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsGroupingEnabledKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsGroupingEnabled <-  value
            | ValueSome _, ValueNone -> target.IsGroupingEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsPullToRefreshEnabledKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsPullToRefreshEnabledKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsPullToRefreshEnabled <-  value
            | ValueSome _, ValueNone -> target.IsPullToRefreshEnabled <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<bool>(Xaml.IsRefreshingKey)
            let valueOpt = source.TryGetAttributeKeyed<bool>(Xaml.IsRefreshingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.IsRefreshing <-  value
            | ValueSome _, ValueNone -> target.IsRefreshing <- false
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.Windows.Input.ICommand>(Xaml.RefreshCommandKey)
            let valueOpt = source.TryGetAttributeKeyed<System.Windows.Input.ICommand>(Xaml.RefreshCommandKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RefreshCommand <-  value
            | ValueSome _, ValueNone -> target.RefreshCommand <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<int>(Xaml.RowHeightKey)
            let valueOpt = source.TryGetAttributeKeyed<int>(Xaml.RowHeightKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.RowHeight <-  value
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<(int * int) option>(Xaml.ListViewGrouped_SelectedItemKey)
            let valueOpt = source.TryGetAttributeKeyed<(int * int) option>(Xaml.ListViewGrouped_SelectedItemKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SelectedItem <- (function None -> null | Some (i,j) -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListGroupData<XamlElement>> in (if i >= 0 && i < items.Count then (let items2 = items.[i] in if j >= 0 && j < items2.Count then items2.[j] else null) else null))  value
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.SeparatorVisibility>(Xaml.SeparatorVisibilityKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.SeparatorVisibility>(Xaml.SeparatorVisibilityKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SeparatorVisibility <-  value
            | ValueSome _, ValueNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.SeparatorColorKey)
            let valueOpt = source.TryGetAttributeKeyed<Xamarin.Forms.Color>(Xaml.SeparatorColorKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when prevValue = value -> ()
            | prevOpt, ValueSome value -> target.SeparatorColor <-  value
            | ValueSome _, ValueNone -> target.SeparatorColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(Xaml.ListViewGrouped_ItemAppearingKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(Xaml.ListViewGrouped_ItemAppearingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemAppearing.RemoveHandler(prevValue); target.ItemAppearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemAppearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemAppearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(Xaml.ListViewGrouped_ItemDisappearingKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>>(Xaml.ListViewGrouped_ItemDisappearingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemDisappearing.RemoveHandler(prevValue); target.ItemDisappearing.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemDisappearing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemDisappearing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>(Xaml.ListViewGrouped_ItemSelectedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>>(Xaml.ListViewGrouped_ItemSelectedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemSelected.RemoveHandler(prevValue); target.ItemSelected.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemSelected.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemSelected.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>(Xaml.ListViewGrouped_ItemTappedKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>>(Xaml.ListViewGrouped_ItemTappedKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.ItemTapped.RemoveHandler(prevValue); target.ItemTapped.AddHandler(value)
            | ValueNone, ValueSome value -> target.ItemTapped.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.ItemTapped.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()
            let prevValueOpt = match prevOpt with ValueNone -> ValueNone | ValueSome prev -> prev.TryGetAttributeKeyed<System.EventHandler>(Xaml.RefreshingKey)
            let valueOpt = source.TryGetAttributeKeyed<System.EventHandler>(Xaml.RefreshingKey)
            match prevValueOpt, valueOpt with
            | ValueSome prevValue, ValueSome value when identical prevValue value -> ()
            | ValueSome prevValue, ValueSome value -> target.Refreshing.RemoveHandler(prevValue); target.Refreshing.AddHandler(value)
            | ValueNone, ValueSome value -> target.Refreshing.AddHandler(value)
            | ValueSome prevValue, ValueNone -> target.Refreshing.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new XamlElement(typeof<Xamarin.Forms.ListView>, create, update, attribs)

[<AutoOpen>]
module XamlElementExtensions = 

    type XamlElement with

        /// Adjusts the ClassId property in the visual element
        member x.ClassId(value: string) = x.WithAttributeKeyed(Xaml.ClassIdKey, box ((value)))

        /// Adjusts the StyleId property in the visual element
        member x.StyleId(value: string) = x.WithAttributeKeyed(Xaml.StyleIdKey, box ((value)))

        /// Adjusts the AnchorX property in the visual element
        member x.AnchorX(value: double) = x.WithAttributeKeyed(Xaml.AnchorXKey, box ((value)))

        /// Adjusts the AnchorY property in the visual element
        member x.AnchorY(value: double) = x.WithAttributeKeyed(Xaml.AnchorYKey, box ((value)))

        /// Adjusts the BackgroundColor property in the visual element
        member x.BackgroundColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.BackgroundColorKey, box ((value)))

        /// Adjusts the HeightRequest property in the visual element
        member x.HeightRequest(value: double) = x.WithAttributeKeyed(Xaml.HeightRequestKey, box ((value)))

        /// Adjusts the InputTransparent property in the visual element
        member x.InputTransparent(value: bool) = x.WithAttributeKeyed(Xaml.InputTransparentKey, box ((value)))

        /// Adjusts the IsEnabled property in the visual element
        member x.IsEnabled(value: bool) = x.WithAttributeKeyed(Xaml.IsEnabledKey, box ((value)))

        /// Adjusts the IsVisible property in the visual element
        member x.IsVisible(value: bool) = x.WithAttributeKeyed(Xaml.IsVisibleKey, box ((value)))

        /// Adjusts the MinimumHeightRequest property in the visual element
        member x.MinimumHeightRequest(value: double) = x.WithAttributeKeyed(Xaml.MinimumHeightRequestKey, box ((value)))

        /// Adjusts the MinimumWidthRequest property in the visual element
        member x.MinimumWidthRequest(value: double) = x.WithAttributeKeyed(Xaml.MinimumWidthRequestKey, box ((value)))

        /// Adjusts the Opacity property in the visual element
        member x.Opacity(value: double) = x.WithAttributeKeyed(Xaml.OpacityKey, box ((value)))

        /// Adjusts the Rotation property in the visual element
        member x.Rotation(value: double) = x.WithAttributeKeyed(Xaml.RotationKey, box ((value)))

        /// Adjusts the RotationX property in the visual element
        member x.RotationX(value: double) = x.WithAttributeKeyed(Xaml.RotationXKey, box ((value)))

        /// Adjusts the RotationY property in the visual element
        member x.RotationY(value: double) = x.WithAttributeKeyed(Xaml.RotationYKey, box ((value)))

        /// Adjusts the Scale property in the visual element
        member x.Scale(value: double) = x.WithAttributeKeyed(Xaml.ScaleKey, box ((value)))

        /// Adjusts the Style property in the visual element
        member x.Style(value: Xamarin.Forms.Style) = x.WithAttributeKeyed(Xaml.StyleKey, box ((value)))

        /// Adjusts the TranslationX property in the visual element
        member x.TranslationX(value: double) = x.WithAttributeKeyed(Xaml.TranslationXKey, box ((value)))

        /// Adjusts the TranslationY property in the visual element
        member x.TranslationY(value: double) = x.WithAttributeKeyed(Xaml.TranslationYKey, box ((value)))

        /// Adjusts the WidthRequest property in the visual element
        member x.WidthRequest(value: double) = x.WithAttributeKeyed(Xaml.WidthRequestKey, box ((value)))

        /// Adjusts the Resources property in the visual element
        member x.Resources(value: (string * obj) list) = x.WithAttributeKeyed(Xaml.ResourcesKey, box ((value)))

        /// Adjusts the Styles property in the visual element
        member x.Styles(value: Xamarin.Forms.Style list) = x.WithAttributeKeyed(Xaml.StylesKey, box ((value)))

        /// Adjusts the StyleSheets property in the visual element
        member x.StyleSheets(value: Xamarin.Forms.StyleSheets.StyleSheet list) = x.WithAttributeKeyed(Xaml.StyleSheetsKey, box ((value)))

        /// Adjusts the HorizontalOptions property in the visual element
        member x.HorizontalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttributeKeyed(Xaml.HorizontalOptionsKey, box ((value)))

        /// Adjusts the VerticalOptions property in the visual element
        member x.VerticalOptions(value: Xamarin.Forms.LayoutOptions) = x.WithAttributeKeyed(Xaml.VerticalOptionsKey, box ((value)))

        /// Adjusts the Margin property in the visual element
        member x.Margin(value: obj) = x.WithAttributeKeyed(Xaml.MarginKey, box (makeThickness(value)))

        /// Adjusts the GestureRecognizers property in the visual element
        member x.GestureRecognizers(value: XamlElement list) = x.WithAttributeKeyed(Xaml.GestureRecognizersKey, box (Array.ofList(value)))

        /// Adjusts the TouchPoints property in the visual element
        member x.TouchPoints(value: int) = x.WithAttributeKeyed(Xaml.TouchPointsKey, box ((value)))

        /// Adjusts the PanUpdated property in the visual element
        member x.PanUpdated(value: Xamarin.Forms.PanUpdatedEventArgs -> unit) = x.WithAttributeKeyed(Xaml.PanUpdatedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Command property in the visual element
        member x.Command(value: unit -> unit) = x.WithAttributeKeyed(Xaml.CommandKey, box (makeCommand(value)))

        /// Adjusts the NumberOfTapsRequired property in the visual element
        member x.NumberOfTapsRequired(value: int) = x.WithAttributeKeyed(Xaml.NumberOfTapsRequiredKey, box ((value)))

        /// Adjusts the NumberOfClicksRequired property in the visual element
        member x.NumberOfClicksRequired(value: int) = x.WithAttributeKeyed(Xaml.NumberOfClicksRequiredKey, box ((value)))

        /// Adjusts the Buttons property in the visual element
        member x.Buttons(value: Xamarin.Forms.ButtonsMask) = x.WithAttributeKeyed(Xaml.ButtonsKey, box ((value)))

        /// Adjusts the IsPinching property in the visual element
        member x.IsPinching(value: bool) = x.WithAttributeKeyed(Xaml.IsPinchingKey, box ((value)))

        /// Adjusts the PinchUpdated property in the visual element
        member x.PinchUpdated(value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) = x.WithAttributeKeyed(Xaml.PinchUpdatedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Color property in the visual element
        member x.Color(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.ColorKey, box ((value)))

        /// Adjusts the IsRunning property in the visual element
        member x.IsRunning(value: bool) = x.WithAttributeKeyed(Xaml.IsRunningKey, box ((value)))

        /// Adjusts the Progress property in the visual element
        member x.Progress(value: double) = x.WithAttributeKeyed(Xaml.ProgressKey, box ((value)))

        /// Adjusts the Content property in the visual element
        member x.Content(value: XamlElement) = x.WithAttributeKeyed(Xaml.ContentKey, box ((value)))

        /// Adjusts the ScrollOrientation property in the visual element
        member x.ScrollOrientation(value: Xamarin.Forms.ScrollOrientation) = x.WithAttributeKeyed(Xaml.ScrollOrientationKey, box ((value)))

        /// Adjusts the CancelButtonColor property in the visual element
        member x.CancelButtonColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.CancelButtonColorKey, box ((value)))

        /// Adjusts the FontFamily property in the visual element
        member x.FontFamily(value: string) = x.WithAttributeKeyed(Xaml.FontFamilyKey, box ((value)))

        /// Adjusts the FontAttributes property in the visual element
        member x.FontAttributes(value: Xamarin.Forms.FontAttributes) = x.WithAttributeKeyed(Xaml.FontAttributesKey, box ((value)))

        /// Adjusts the FontSize property in the visual element
        member x.FontSize(value: obj) = x.WithAttributeKeyed(Xaml.FontSizeKey, box (makeFontSize(value)))

        /// Adjusts the HorizontalTextAlignment property in the visual element
        member x.HorizontalTextAlignment(value: Xamarin.Forms.TextAlignment) = x.WithAttributeKeyed(Xaml.HorizontalTextAlignmentKey, box ((value)))

        /// Adjusts the Placeholder property in the visual element
        member x.Placeholder(value: string) = x.WithAttributeKeyed(Xaml.PlaceholderKey, box ((value)))

        /// Adjusts the PlaceholderColor property in the visual element
        member x.PlaceholderColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.PlaceholderColorKey, box ((value)))

        /// Adjusts the SearchBarCommand property in the visual element
        member x.SearchBarCommand(value: unit -> unit) = x.WithAttributeKeyed(Xaml.SearchBarCommandKey, box ((value)))

        /// Adjusts the SearchBarCanExecute property in the visual element
        member x.SearchBarCanExecute(value: bool) = x.WithAttributeKeyed(Xaml.SearchBarCanExecuteKey, box ((value)))

        /// Adjusts the Text property in the visual element
        member x.Text(value: string) = x.WithAttributeKeyed(Xaml.TextKey, box ((value)))

        /// Adjusts the TextColor property in the visual element
        member x.TextColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.TextColorKey, box ((value)))

        /// Adjusts the ButtonCommand property in the visual element
        member x.ButtonCommand(value: unit -> unit) = x.WithAttributeKeyed(Xaml.ButtonCommandKey, box ((value)))

        /// Adjusts the ButtonCanExecute property in the visual element
        member x.ButtonCanExecute(value: bool) = x.WithAttributeKeyed(Xaml.ButtonCanExecuteKey, box ((value)))

        /// Adjusts the BorderColor property in the visual element
        member x.BorderColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.BorderColorKey, box ((value)))

        /// Adjusts the BorderWidth property in the visual element
        member x.BorderWidth(value: double) = x.WithAttributeKeyed(Xaml.BorderWidthKey, box ((value)))

        /// Adjusts the CommandParameter property in the visual element
        member x.CommandParameter(value: System.Object) = x.WithAttributeKeyed(Xaml.CommandParameterKey, box ((value)))

        /// Adjusts the ContentLayout property in the visual element
        member x.ContentLayout(value: Xamarin.Forms.Button.ButtonContentLayout) = x.WithAttributeKeyed(Xaml.ContentLayoutKey, box ((value)))

        /// Adjusts the ButtonCornerRadius property in the visual element
        member x.ButtonCornerRadius(value: int) = x.WithAttributeKeyed(Xaml.ButtonCornerRadiusKey, box ((value)))

        /// Adjusts the ButtonImageSource property in the visual element
        member x.ButtonImageSource(value: string) = x.WithAttributeKeyed(Xaml.ButtonImageSourceKey, box ((value)))

        /// Adjusts the Minimum property in the visual element
        member x.Minimum(value: double) = x.WithAttributeKeyed(Xaml.MinimumKey, box ((value)))

        /// Adjusts the Maximum property in the visual element
        member x.Maximum(value: double) = x.WithAttributeKeyed(Xaml.MaximumKey, box ((value)))

        /// Adjusts the Value property in the visual element
        member x.Value(value: double) = x.WithAttributeKeyed(Xaml.ValueKey, box ((value)))

        /// Adjusts the ValueChanged property in the visual element
        member x.ValueChanged(value: Xamarin.Forms.ValueChangedEventArgs -> unit) = x.WithAttributeKeyed(Xaml.ValueChangedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Increment property in the visual element
        member x.Increment(value: double) = x.WithAttributeKeyed(Xaml.IncrementKey, box ((value)))

        /// Adjusts the IsToggled property in the visual element
        member x.IsToggled(value: bool) = x.WithAttributeKeyed(Xaml.IsToggledKey, box ((value)))

        /// Adjusts the Toggled property in the visual element
        member x.Toggled(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttributeKeyed(Xaml.ToggledKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the On property in the visual element
        member x.On(value: bool) = x.WithAttributeKeyed(Xaml.OnKey, box ((value)))

        /// Adjusts the OnChanged property in the visual element
        member x.OnChanged(value: Xamarin.Forms.ToggledEventArgs -> unit) = x.WithAttributeKeyed(Xaml.OnChangedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Intent property in the visual element
        member x.Intent(value: Xamarin.Forms.TableIntent) = x.WithAttributeKeyed(Xaml.IntentKey, box ((value)))

        /// Adjusts the HasUnevenRows property in the visual element
        member x.HasUnevenRows(value: bool) = x.WithAttributeKeyed(Xaml.HasUnevenRowsKey, box ((value)))

        /// Adjusts the RowHeight property in the visual element
        member x.RowHeight(value: int) = x.WithAttributeKeyed(Xaml.RowHeightKey, box ((value)))

        /// Adjusts the TableRoot property in the visual element
        member x.TableRoot(value: (string * XamlElement list) list) = x.WithAttributeKeyed(Xaml.TableRootKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(value)))

        /// Adjusts the GridRowDefinitions property in the visual element
        member x.GridRowDefinitions(value: obj list) = x.WithAttributeKeyed(Xaml.GridRowDefinitionsKey, box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(value)))

        /// Adjusts the GridColumnDefinitions property in the visual element
        member x.GridColumnDefinitions(value: obj list) = x.WithAttributeKeyed(Xaml.GridColumnDefinitionsKey, box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(value)))

        /// Adjusts the RowSpacing property in the visual element
        member x.RowSpacing(value: double) = x.WithAttributeKeyed(Xaml.RowSpacingKey, box ((value)))

        /// Adjusts the ColumnSpacing property in the visual element
        member x.ColumnSpacing(value: double) = x.WithAttributeKeyed(Xaml.ColumnSpacingKey, box ((value)))

        /// Adjusts the Children property in the visual element
        member x.Children(value: XamlElement list) = x.WithAttributeKeyed(Xaml.ChildrenKey, box (Array.ofList(value)))

        /// Adjusts the GridRow property in the visual element
        member x.GridRow(value: int) = x.WithAttributeKeyed(Xaml.GridRowKey, box ((value)))

        /// Adjusts the GridRowSpan property in the visual element
        member x.GridRowSpan(value: int) = x.WithAttributeKeyed(Xaml.GridRowSpanKey, box ((value)))

        /// Adjusts the GridColumn property in the visual element
        member x.GridColumn(value: int) = x.WithAttributeKeyed(Xaml.GridColumnKey, box ((value)))

        /// Adjusts the GridColumnSpan property in the visual element
        member x.GridColumnSpan(value: int) = x.WithAttributeKeyed(Xaml.GridColumnSpanKey, box ((value)))

        /// Adjusts the LayoutBounds property in the visual element
        member x.LayoutBounds(value: Xamarin.Forms.Rectangle) = x.WithAttributeKeyed(Xaml.LayoutBoundsKey, box ((value)))

        /// Adjusts the LayoutFlags property in the visual element
        member x.LayoutFlags(value: Xamarin.Forms.AbsoluteLayoutFlags) = x.WithAttributeKeyed(Xaml.LayoutFlagsKey, box ((value)))

        /// Adjusts the BoundsConstraint property in the visual element
        member x.BoundsConstraint(value: Xamarin.Forms.BoundsConstraint) = x.WithAttributeKeyed(Xaml.BoundsConstraintKey, box ((value)))

        /// Adjusts the HeightConstraint property in the visual element
        member x.HeightConstraint(value: Xamarin.Forms.Constraint) = x.WithAttributeKeyed(Xaml.HeightConstraintKey, box ((value)))

        /// Adjusts the WidthConstraint property in the visual element
        member x.WidthConstraint(value: Xamarin.Forms.Constraint) = x.WithAttributeKeyed(Xaml.WidthConstraintKey, box ((value)))

        /// Adjusts the XConstraint property in the visual element
        member x.XConstraint(value: Xamarin.Forms.Constraint) = x.WithAttributeKeyed(Xaml.XConstraintKey, box ((value)))

        /// Adjusts the YConstraint property in the visual element
        member x.YConstraint(value: Xamarin.Forms.Constraint) = x.WithAttributeKeyed(Xaml.YConstraintKey, box ((value)))

        /// Adjusts the AlignContent property in the visual element
        member x.AlignContent(value: Xamarin.Forms.FlexAlignContent) = x.WithAttributeKeyed(Xaml.AlignContentKey, box ((value)))

        /// Adjusts the AlignItems property in the visual element
        member x.AlignItems(value: Xamarin.Forms.FlexAlignItems) = x.WithAttributeKeyed(Xaml.AlignItemsKey, box ((value)))

        /// Adjusts the Direction property in the visual element
        member x.Direction(value: Xamarin.Forms.FlexDirection) = x.WithAttributeKeyed(Xaml.DirectionKey, box ((value)))

        /// Adjusts the Position property in the visual element
        member x.Position(value: Xamarin.Forms.FlexPosition) = x.WithAttributeKeyed(Xaml.PositionKey, box ((value)))

        /// Adjusts the Wrap property in the visual element
        member x.Wrap(value: Xamarin.Forms.FlexWrap) = x.WithAttributeKeyed(Xaml.WrapKey, box ((value)))

        /// Adjusts the JustifyContent property in the visual element
        member x.JustifyContent(value: Xamarin.Forms.FlexJustify) = x.WithAttributeKeyed(Xaml.JustifyContentKey, box ((value)))

        /// Adjusts the FlexAlignSelf property in the visual element
        member x.FlexAlignSelf(value: Xamarin.Forms.FlexAlignSelf) = x.WithAttributeKeyed(Xaml.FlexAlignSelfKey, box ((value)))

        /// Adjusts the FlexOrder property in the visual element
        member x.FlexOrder(value: int) = x.WithAttributeKeyed(Xaml.FlexOrderKey, box ((value)))

        /// Adjusts the FlexBasis property in the visual element
        member x.FlexBasis(value: Xamarin.Forms.FlexBasis) = x.WithAttributeKeyed(Xaml.FlexBasisKey, box ((value)))

        /// Adjusts the FlexGrow property in the visual element
        member x.FlexGrow(value: double) = x.WithAttributeKeyed(Xaml.FlexGrowKey, box (single(value)))

        /// Adjusts the FlexShrink property in the visual element
        member x.FlexShrink(value: double) = x.WithAttributeKeyed(Xaml.FlexShrinkKey, box (single(value)))

        /// Adjusts the RowDefinitionHeight property in the visual element
        member x.RowDefinitionHeight(value: obj) = x.WithAttributeKeyed(Xaml.RowDefinitionHeightKey, box (makeGridLength(value)))

        /// Adjusts the ColumnDefinitionWidth property in the visual element
        member x.ColumnDefinitionWidth(value: obj) = x.WithAttributeKeyed(Xaml.ColumnDefinitionWidthKey, box (makeGridLength(value)))

        /// Adjusts the Date property in the visual element
        member x.Date(value: System.DateTime) = x.WithAttributeKeyed(Xaml.DateKey, box ((value)))

        /// Adjusts the Format property in the visual element
        member x.Format(value: string) = x.WithAttributeKeyed(Xaml.FormatKey, box ((value)))

        /// Adjusts the MinimumDate property in the visual element
        member x.MinimumDate(value: System.DateTime) = x.WithAttributeKeyed(Xaml.MinimumDateKey, box ((value)))

        /// Adjusts the MaximumDate property in the visual element
        member x.MaximumDate(value: System.DateTime) = x.WithAttributeKeyed(Xaml.MaximumDateKey, box ((value)))

        /// Adjusts the DateSelected property in the visual element
        member x.DateSelected(value: Xamarin.Forms.DateChangedEventArgs -> unit) = x.WithAttributeKeyed(Xaml.DateSelectedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the PickerItemsSource property in the visual element
        member x.PickerItemsSource(value: seq<'T>) = x.WithAttributeKeyed(Xaml.PickerItemsSourceKey, box (seqToIList(value)))

        /// Adjusts the SelectedIndex property in the visual element
        member x.SelectedIndex(value: int) = x.WithAttributeKeyed(Xaml.SelectedIndexKey, box ((value)))

        /// Adjusts the Title property in the visual element
        member x.Title(value: string) = x.WithAttributeKeyed(Xaml.TitleKey, box ((value)))

        /// Adjusts the SelectedIndexChanged property in the visual element
        member x.SelectedIndexChanged(value: (int * 'T option) -> unit) = x.WithAttributeKeyed(Xaml.SelectedIndexChangedKey, box ((fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(value)))

        /// Adjusts the FrameCornerRadius property in the visual element
        member x.FrameCornerRadius(value: double) = x.WithAttributeKeyed(Xaml.FrameCornerRadiusKey, box (single(value)))

        /// Adjusts the HasShadow property in the visual element
        member x.HasShadow(value: bool) = x.WithAttributeKeyed(Xaml.HasShadowKey, box ((value)))

        /// Adjusts the ImageSource property in the visual element
        member x.ImageSource(value: string) = x.WithAttributeKeyed(Xaml.ImageSourceKey, box ((value)))

        /// Adjusts the Aspect property in the visual element
        member x.Aspect(value: Xamarin.Forms.Aspect) = x.WithAttributeKeyed(Xaml.AspectKey, box ((value)))

        /// Adjusts the IsOpaque property in the visual element
        member x.IsOpaque(value: bool) = x.WithAttributeKeyed(Xaml.IsOpaqueKey, box ((value)))

        /// Adjusts the Keyboard property in the visual element
        member x.Keyboard(value: Xamarin.Forms.Keyboard) = x.WithAttributeKeyed(Xaml.KeyboardKey, box ((value)))

        /// Adjusts the EditorCompleted property in the visual element
        member x.EditorCompleted(value: string -> unit) = x.WithAttributeKeyed(Xaml.EditorCompletedKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Editor).Text))(value)))

        /// Adjusts the TextChanged property in the visual element
        member x.TextChanged(value: Xamarin.Forms.TextChangedEventArgs -> unit) = x.WithAttributeKeyed(Xaml.TextChangedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the IsPassword property in the visual element
        member x.IsPassword(value: bool) = x.WithAttributeKeyed(Xaml.IsPasswordKey, box ((value)))

        /// Adjusts the EntryCompleted property in the visual element
        member x.EntryCompleted(value: string -> unit) = x.WithAttributeKeyed(Xaml.EntryCompletedKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.Entry).Text))(value)))

        /// Adjusts the Label property in the visual element
        member x.Label(value: string) = x.WithAttributeKeyed(Xaml.LabelKey, box ((value)))

        /// Adjusts the VerticalTextAlignment property in the visual element
        member x.VerticalTextAlignment(value: Xamarin.Forms.TextAlignment) = x.WithAttributeKeyed(Xaml.VerticalTextAlignmentKey, box ((value)))

        /// Adjusts the FormattedText property in the visual element
        member x.FormattedText(value: XamlElement) = x.WithAttributeKeyed(Xaml.FormattedTextKey, box ((value)))

        /// Adjusts the IsClippedToBounds property in the visual element
        member x.IsClippedToBounds(value: bool) = x.WithAttributeKeyed(Xaml.IsClippedToBoundsKey, box ((value)))

        /// Adjusts the Padding property in the visual element
        member x.Padding(value: obj) = x.WithAttributeKeyed(Xaml.PaddingKey, box (makeThickness(value)))

        /// Adjusts the StackOrientation property in the visual element
        member x.StackOrientation(value: Xamarin.Forms.StackOrientation) = x.WithAttributeKeyed(Xaml.StackOrientationKey, box ((value)))

        /// Adjusts the Spacing property in the visual element
        member x.Spacing(value: double) = x.WithAttributeKeyed(Xaml.SpacingKey, box ((value)))

        /// Adjusts the ForegroundColor property in the visual element
        member x.ForegroundColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.ForegroundColorKey, box ((value)))

        /// Adjusts the PropertyChanged property in the visual element
        member x.PropertyChanged(value: System.ComponentModel.PropertyChangedEventArgs -> unit) = x.WithAttributeKeyed(Xaml.PropertyChangedKey, box ((fun f -> System.EventHandler<System.ComponentModel.PropertyChangedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Spans property in the visual element
        member x.Spans(value: XamlElement[]) = x.WithAttributeKeyed(Xaml.SpansKey, box ((value)))

        /// Adjusts the Time property in the visual element
        member x.Time(value: System.TimeSpan) = x.WithAttributeKeyed(Xaml.TimeKey, box ((value)))

        /// Adjusts the WebSource property in the visual element
        member x.WebSource(value: Xamarin.Forms.WebViewSource) = x.WithAttributeKeyed(Xaml.WebSourceKey, box ((value)))

        /// Adjusts the Navigated property in the visual element
        member x.Navigated(value: Xamarin.Forms.WebNavigatedEventArgs -> unit) = x.WithAttributeKeyed(Xaml.NavigatedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the Navigating property in the visual element
        member x.Navigating(value: Xamarin.Forms.WebNavigatingEventArgs -> unit) = x.WithAttributeKeyed(Xaml.NavigatingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(value)))

        /// Adjusts the BackgroundImage property in the visual element
        member x.BackgroundImage(value: string) = x.WithAttributeKeyed(Xaml.BackgroundImageKey, box ((value)))

        /// Adjusts the Icon property in the visual element
        member x.Icon(value: string) = x.WithAttributeKeyed(Xaml.IconKey, box ((value)))

        /// Adjusts the IsBusy property in the visual element
        member x.IsBusy(value: bool) = x.WithAttributeKeyed(Xaml.IsBusyKey, box ((value)))

        /// Adjusts the ToolbarItems property in the visual element
        member x.ToolbarItems(value: XamlElement list) = x.WithAttributeKeyed(Xaml.ToolbarItemsKey, box (Array.ofList(value)))

        /// Adjusts the UseSafeArea property in the visual element
        member x.UseSafeArea(value: bool) = x.WithAttributeKeyed(Xaml.UseSafeAreaKey, box ((value)))

        /// Adjusts the Page_Appearing property in the visual element
        member x.Page_Appearing(value: unit -> unit) = x.WithAttributeKeyed(Xaml.Page_AppearingKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(value)))

        /// Adjusts the Page_Disappearing property in the visual element
        member x.Page_Disappearing(value: unit -> unit) = x.WithAttributeKeyed(Xaml.Page_DisappearingKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(value)))

        /// Adjusts the Page_LayoutChanged property in the visual element
        member x.Page_LayoutChanged(value: unit -> unit) = x.WithAttributeKeyed(Xaml.Page_LayoutChangedKey, box ((fun f -> System.EventHandler(fun _sender _args -> f ()))(value)))

        /// Adjusts the CarouselPage_SelectedItem property in the visual element
        member x.CarouselPage_SelectedItem(value: System.Object) = x.WithAttributeKeyed(Xaml.CarouselPage_SelectedItemKey, box ((value)))

        /// Adjusts the CurrentPage property in the visual element
        member x.CurrentPage(value: XamlElement) = x.WithAttributeKeyed(Xaml.CurrentPageKey, box ((value)))

        /// Adjusts the CurrentPageChanged property in the visual element
        member x.CurrentPageChanged(value: 'T option -> unit) = x.WithAttributeKeyed(Xaml.CurrentPageChangedKey, box ((fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(value)))

        /// Adjusts the Pages property in the visual element
        member x.Pages(value: XamlElement list) = x.WithAttributeKeyed(Xaml.PagesKey, box (Array.ofList(value)))

        /// Adjusts the BackButtonTitle property in the visual element
        member x.BackButtonTitle(value: string) = x.WithAttributeKeyed(Xaml.BackButtonTitleKey, box ((value)))

        /// Adjusts the HasBackButton property in the visual element
        member x.HasBackButton(value: bool) = x.WithAttributeKeyed(Xaml.HasBackButtonKey, box ((value)))

        /// Adjusts the HasNavigationBar property in the visual element
        member x.HasNavigationBar(value: bool) = x.WithAttributeKeyed(Xaml.HasNavigationBarKey, box ((value)))

        /// Adjusts the TitleIcon property in the visual element
        member x.TitleIcon(value: string) = x.WithAttributeKeyed(Xaml.TitleIconKey, box ((value)))

        /// Adjusts the BarBackgroundColor property in the visual element
        member x.BarBackgroundColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.BarBackgroundColorKey, box ((value)))

        /// Adjusts the BarTextColor property in the visual element
        member x.BarTextColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.BarTextColorKey, box ((value)))

        /// Adjusts the Popped property in the visual element
        member x.Popped(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttributeKeyed(Xaml.PoppedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value)))

        /// Adjusts the PoppedToRoot property in the visual element
        member x.PoppedToRoot(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttributeKeyed(Xaml.PoppedToRootKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value)))

        /// Adjusts the Pushed property in the visual element
        member x.Pushed(value: Xamarin.Forms.NavigationEventArgs -> unit) = x.WithAttributeKeyed(Xaml.PushedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.NavigationEventArgs>(fun sender args -> f args))(value)))

        /// Adjusts the OnSizeAllocatedCallback property in the visual element
        member x.OnSizeAllocatedCallback(value: (double * double) -> unit) = x.WithAttributeKeyed(Xaml.OnSizeAllocatedCallbackKey, box ((fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(value)))

        /// Adjusts the Master property in the visual element
        member x.Master(value: XamlElement) = x.WithAttributeKeyed(Xaml.MasterKey, box ((value)))

        /// Adjusts the Detail property in the visual element
        member x.Detail(value: XamlElement) = x.WithAttributeKeyed(Xaml.DetailKey, box ((value)))

        /// Adjusts the IsGestureEnabled property in the visual element
        member x.IsGestureEnabled(value: bool) = x.WithAttributeKeyed(Xaml.IsGestureEnabledKey, box ((value)))

        /// Adjusts the IsPresented property in the visual element
        member x.IsPresented(value: bool) = x.WithAttributeKeyed(Xaml.IsPresentedKey, box ((value)))

        /// Adjusts the MasterBehavior property in the visual element
        member x.MasterBehavior(value: Xamarin.Forms.MasterBehavior) = x.WithAttributeKeyed(Xaml.MasterBehaviorKey, box ((value)))

        /// Adjusts the IsPresentedChanged property in the visual element
        member x.IsPresentedChanged(value: bool -> unit) = x.WithAttributeKeyed(Xaml.IsPresentedChangedKey, box ((fun f -> System.EventHandler(fun sender args -> f (sender :?> Xamarin.Forms.MasterDetailPage).IsPresented))(value)))

        /// Adjusts the Height property in the visual element
        member x.Height(value: double) = x.WithAttributeKeyed(Xaml.HeightKey, box ((value)))

        /// Adjusts the TextDetail property in the visual element
        member x.TextDetail(value: string) = x.WithAttributeKeyed(Xaml.TextDetailKey, box ((value)))

        /// Adjusts the TextDetailColor property in the visual element
        member x.TextDetailColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.TextDetailColorKey, box ((value)))

        /// Adjusts the TextCellCommand property in the visual element
        member x.TextCellCommand(value: unit -> unit) = x.WithAttributeKeyed(Xaml.TextCellCommandKey, box ((value)))

        /// Adjusts the TextCellCanExecute property in the visual element
        member x.TextCellCanExecute(value: bool) = x.WithAttributeKeyed(Xaml.TextCellCanExecuteKey, box ((value)))

        /// Adjusts the Order property in the visual element
        member x.Order(value: Xamarin.Forms.ToolbarItemOrder) = x.WithAttributeKeyed(Xaml.OrderKey, box ((value)))

        /// Adjusts the Priority property in the visual element
        member x.Priority(value: int) = x.WithAttributeKeyed(Xaml.PriorityKey, box ((value)))

        /// Adjusts the View property in the visual element
        member x.View(value: XamlElement) = x.WithAttributeKeyed(Xaml.ViewKey, box ((value)))

        /// Adjusts the ListViewItems property in the visual element
        member x.ListViewItems(value: seq<XamlElement>) = x.WithAttributeKeyed(Xaml.ListViewItemsKey, box ((value)))

        /// Adjusts the Footer property in the visual element
        member x.Footer(value: System.Object) = x.WithAttributeKeyed(Xaml.FooterKey, box ((value)))

        /// Adjusts the Header property in the visual element
        member x.Header(value: System.Object) = x.WithAttributeKeyed(Xaml.HeaderKey, box ((value)))

        /// Adjusts the HeaderTemplate property in the visual element
        member x.HeaderTemplate(value: Xamarin.Forms.DataTemplate) = x.WithAttributeKeyed(Xaml.HeaderTemplateKey, box ((value)))

        /// Adjusts the IsGroupingEnabled property in the visual element
        member x.IsGroupingEnabled(value: bool) = x.WithAttributeKeyed(Xaml.IsGroupingEnabledKey, box ((value)))

        /// Adjusts the IsPullToRefreshEnabled property in the visual element
        member x.IsPullToRefreshEnabled(value: bool) = x.WithAttributeKeyed(Xaml.IsPullToRefreshEnabledKey, box ((value)))

        /// Adjusts the IsRefreshing property in the visual element
        member x.IsRefreshing(value: bool) = x.WithAttributeKeyed(Xaml.IsRefreshingKey, box ((value)))

        /// Adjusts the RefreshCommand property in the visual element
        member x.RefreshCommand(value: unit -> unit) = x.WithAttributeKeyed(Xaml.RefreshCommandKey, box (makeCommand(value)))

        /// Adjusts the ListView_SelectedItem property in the visual element
        member x.ListView_SelectedItem(value: int option) = x.WithAttributeKeyed(Xaml.ListView_SelectedItemKey, box ((value)))

        /// Adjusts the ListView_SeparatorVisibility property in the visual element
        member x.ListView_SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttributeKeyed(Xaml.ListView_SeparatorVisibilityKey, box ((value)))

        /// Adjusts the ListView_SeparatorColor property in the visual element
        member x.ListView_SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.ListView_SeparatorColorKey, box ((value)))

        /// Adjusts the ListView_ItemAppearing property in the visual element
        member x.ListView_ItemAppearing(value: int -> unit) = x.WithAttributeKeyed(Xaml.ListView_ItemAppearingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_ItemDisappearing property in the visual element
        member x.ListView_ItemDisappearing(value: int -> unit) = x.WithAttributeKeyed(Xaml.ListView_ItemDisappearingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_ItemSelected property in the visual element
        member x.ListView_ItemSelected(value: int option -> unit) = x.WithAttributeKeyed(Xaml.ListView_ItemSelectedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.SelectedItem)))(value)))

        /// Adjusts the ListView_ItemTapped property in the visual element
        member x.ListView_ItemTapped(value: int -> unit) = x.WithAttributeKeyed(Xaml.ListView_ItemTappedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListView_Refreshing property in the visual element
        member x.ListView_Refreshing(value: unit -> unit) = x.WithAttributeKeyed(Xaml.ListView_RefreshingKey, box ((fun f -> System.EventHandler(fun sender args -> f ()))(value)))

        /// Adjusts the ListViewGrouped_ItemsSource property in the visual element
        member x.ListViewGrouped_ItemsSource(value: (XamlElement * XamlElement list) list) = x.WithAttributeKeyed(Xaml.ListViewGrouped_ItemsSourceKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(value)))

        /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
        member x.ListViewGrouped_SelectedItem(value: (int * int) option) = x.WithAttributeKeyed(Xaml.ListViewGrouped_SelectedItemKey, box ((value)))

        /// Adjusts the SeparatorVisibility property in the visual element
        member x.SeparatorVisibility(value: Xamarin.Forms.SeparatorVisibility) = x.WithAttributeKeyed(Xaml.SeparatorVisibilityKey, box ((value)))

        /// Adjusts the SeparatorColor property in the visual element
        member x.SeparatorColor(value: Xamarin.Forms.Color) = x.WithAttributeKeyed(Xaml.SeparatorColorKey, box ((value)))

        /// Adjusts the ListViewGrouped_ItemAppearing property in the visual element
        member x.ListViewGrouped_ItemAppearing(value: int * int -> unit) = x.WithAttributeKeyed(Xaml.ListViewGrouped_ItemAppearingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListViewGrouped_ItemDisappearing property in the visual element
        member x.ListViewGrouped_ItemDisappearing(value: int * int -> unit) = x.WithAttributeKeyed(Xaml.ListViewGrouped_ItemDisappearingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
        member x.ListViewGrouped_ItemSelected(value: (int * int) option -> unit) = x.WithAttributeKeyed(Xaml.ListViewGrouped_ItemSelectedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.SelectedItem)))(value)))

        /// Adjusts the ListViewGrouped_ItemTapped property in the visual element
        member x.ListViewGrouped_ItemTapped(value: int * int -> unit) = x.WithAttributeKeyed(Xaml.ListViewGrouped_ItemTappedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>(fun sender args -> f (tryFindGroupedListViewItem sender args.Item).Value))(value)))

        /// Adjusts the Refreshing property in the visual element
        member x.Refreshing(value: unit -> unit) = x.WithAttributeKeyed(Xaml.RefreshingKey, box ((fun f -> System.EventHandler(fun sender args -> f ()))(value)))


    /// Adjusts the ClassId property in the visual element
    let classId (value: string) (x: XamlElement) = x.ClassId(value)

    /// Adjusts the StyleId property in the visual element
    let styleId (value: string) (x: XamlElement) = x.StyleId(value)

    /// Adjusts the AnchorX property in the visual element
    let anchorX (value: double) (x: XamlElement) = x.AnchorX(value)

    /// Adjusts the AnchorY property in the visual element
    let anchorY (value: double) (x: XamlElement) = x.AnchorY(value)

    /// Adjusts the BackgroundColor property in the visual element
    let backgroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BackgroundColor(value)

    /// Adjusts the HeightRequest property in the visual element
    let heightRequest (value: double) (x: XamlElement) = x.HeightRequest(value)

    /// Adjusts the InputTransparent property in the visual element
    let inputTransparent (value: bool) (x: XamlElement) = x.InputTransparent(value)

    /// Adjusts the IsEnabled property in the visual element
    let isEnabled (value: bool) (x: XamlElement) = x.IsEnabled(value)

    /// Adjusts the IsVisible property in the visual element
    let isVisible (value: bool) (x: XamlElement) = x.IsVisible(value)

    /// Adjusts the MinimumHeightRequest property in the visual element
    let minimumHeightRequest (value: double) (x: XamlElement) = x.MinimumHeightRequest(value)

    /// Adjusts the MinimumWidthRequest property in the visual element
    let minimumWidthRequest (value: double) (x: XamlElement) = x.MinimumWidthRequest(value)

    /// Adjusts the Opacity property in the visual element
    let opacity (value: double) (x: XamlElement) = x.Opacity(value)

    /// Adjusts the Rotation property in the visual element
    let rotation (value: double) (x: XamlElement) = x.Rotation(value)

    /// Adjusts the RotationX property in the visual element
    let rotationX (value: double) (x: XamlElement) = x.RotationX(value)

    /// Adjusts the RotationY property in the visual element
    let rotationY (value: double) (x: XamlElement) = x.RotationY(value)

    /// Adjusts the Scale property in the visual element
    let scale (value: double) (x: XamlElement) = x.Scale(value)

    /// Adjusts the Style property in the visual element
    let style (value: Xamarin.Forms.Style) (x: XamlElement) = x.Style(value)

    /// Adjusts the TranslationX property in the visual element
    let translationX (value: double) (x: XamlElement) = x.TranslationX(value)

    /// Adjusts the TranslationY property in the visual element
    let translationY (value: double) (x: XamlElement) = x.TranslationY(value)

    /// Adjusts the WidthRequest property in the visual element
    let widthRequest (value: double) (x: XamlElement) = x.WidthRequest(value)

    /// Adjusts the Resources property in the visual element
    let resources (value: (string * obj) list) (x: XamlElement) = x.Resources(value)

    /// Adjusts the Styles property in the visual element
    let styles (value: Xamarin.Forms.Style list) (x: XamlElement) = x.Styles(value)

    /// Adjusts the StyleSheets property in the visual element
    let styleSheets (value: Xamarin.Forms.StyleSheets.StyleSheet list) (x: XamlElement) = x.StyleSheets(value)

    /// Adjusts the HorizontalOptions property in the visual element
    let horizontalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.HorizontalOptions(value)

    /// Adjusts the VerticalOptions property in the visual element
    let verticalOptions (value: Xamarin.Forms.LayoutOptions) (x: XamlElement) = x.VerticalOptions(value)

    /// Adjusts the Margin property in the visual element
    let margin (value: obj) (x: XamlElement) = x.Margin(value)

    /// Adjusts the GestureRecognizers property in the visual element
    let gestureRecognizers (value: XamlElement list) (x: XamlElement) = x.GestureRecognizers(value)

    /// Adjusts the TouchPoints property in the visual element
    let touchPoints (value: int) (x: XamlElement) = x.TouchPoints(value)

    /// Adjusts the PanUpdated property in the visual element
    let panUpdated (value: Xamarin.Forms.PanUpdatedEventArgs -> unit) (x: XamlElement) = x.PanUpdated(value)

    /// Adjusts the Command property in the visual element
    let command (value: unit -> unit) (x: XamlElement) = x.Command(value)

    /// Adjusts the NumberOfTapsRequired property in the visual element
    let numberOfTapsRequired (value: int) (x: XamlElement) = x.NumberOfTapsRequired(value)

    /// Adjusts the NumberOfClicksRequired property in the visual element
    let numberOfClicksRequired (value: int) (x: XamlElement) = x.NumberOfClicksRequired(value)

    /// Adjusts the Buttons property in the visual element
    let buttons (value: Xamarin.Forms.ButtonsMask) (x: XamlElement) = x.Buttons(value)

    /// Adjusts the IsPinching property in the visual element
    let isPinching (value: bool) (x: XamlElement) = x.IsPinching(value)

    /// Adjusts the PinchUpdated property in the visual element
    let pinchUpdated (value: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit) (x: XamlElement) = x.PinchUpdated(value)

    /// Adjusts the Color property in the visual element
    let color (value: Xamarin.Forms.Color) (x: XamlElement) = x.Color(value)

    /// Adjusts the IsRunning property in the visual element
    let isRunning (value: bool) (x: XamlElement) = x.IsRunning(value)

    /// Adjusts the Progress property in the visual element
    let progress (value: double) (x: XamlElement) = x.Progress(value)

    /// Adjusts the Content property in the visual element
    let content (value: XamlElement) (x: XamlElement) = x.Content(value)

    /// Adjusts the ScrollOrientation property in the visual element
    let scrollOrientation (value: Xamarin.Forms.ScrollOrientation) (x: XamlElement) = x.ScrollOrientation(value)

    /// Adjusts the CancelButtonColor property in the visual element
    let cancelButtonColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.CancelButtonColor(value)

    /// Adjusts the FontFamily property in the visual element
    let fontFamily (value: string) (x: XamlElement) = x.FontFamily(value)

    /// Adjusts the FontAttributes property in the visual element
    let fontAttributes (value: Xamarin.Forms.FontAttributes) (x: XamlElement) = x.FontAttributes(value)

    /// Adjusts the FontSize property in the visual element
    let fontSize (value: obj) (x: XamlElement) = x.FontSize(value)

    /// Adjusts the HorizontalTextAlignment property in the visual element
    let horizontalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.HorizontalTextAlignment(value)

    /// Adjusts the Placeholder property in the visual element
    let placeholder (value: string) (x: XamlElement) = x.Placeholder(value)

    /// Adjusts the PlaceholderColor property in the visual element
    let placeholderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.PlaceholderColor(value)

    /// Adjusts the SearchBarCommand property in the visual element
    let searchBarCommand (value: unit -> unit) (x: XamlElement) = x.SearchBarCommand(value)

    /// Adjusts the SearchBarCanExecute property in the visual element
    let searchBarCanExecute (value: bool) (x: XamlElement) = x.SearchBarCanExecute(value)

    /// Adjusts the Text property in the visual element
    let text (value: string) (x: XamlElement) = x.Text(value)

    /// Adjusts the TextColor property in the visual element
    let textColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.TextColor(value)

    /// Adjusts the ButtonCommand property in the visual element
    let buttonCommand (value: unit -> unit) (x: XamlElement) = x.ButtonCommand(value)

    /// Adjusts the ButtonCanExecute property in the visual element
    let buttonCanExecute (value: bool) (x: XamlElement) = x.ButtonCanExecute(value)

    /// Adjusts the BorderColor property in the visual element
    let borderColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BorderColor(value)

    /// Adjusts the BorderWidth property in the visual element
    let borderWidth (value: double) (x: XamlElement) = x.BorderWidth(value)

    /// Adjusts the CommandParameter property in the visual element
    let commandParameter (value: System.Object) (x: XamlElement) = x.CommandParameter(value)

    /// Adjusts the ContentLayout property in the visual element
    let contentLayout (value: Xamarin.Forms.Button.ButtonContentLayout) (x: XamlElement) = x.ContentLayout(value)

    /// Adjusts the ButtonCornerRadius property in the visual element
    let buttonCornerRadius (value: int) (x: XamlElement) = x.ButtonCornerRadius(value)

    /// Adjusts the ButtonImageSource property in the visual element
    let buttonImageSource (value: string) (x: XamlElement) = x.ButtonImageSource(value)

    /// Adjusts the Minimum property in the visual element
    let minimum (value: double) (x: XamlElement) = x.Minimum(value)

    /// Adjusts the Maximum property in the visual element
    let maximum (value: double) (x: XamlElement) = x.Maximum(value)

    /// Adjusts the Value property in the visual element
    let value (value: double) (x: XamlElement) = x.Value(value)

    /// Adjusts the ValueChanged property in the visual element
    let valueChanged (value: Xamarin.Forms.ValueChangedEventArgs -> unit) (x: XamlElement) = x.ValueChanged(value)

    /// Adjusts the Increment property in the visual element
    let increment (value: double) (x: XamlElement) = x.Increment(value)

    /// Adjusts the IsToggled property in the visual element
    let isToggled (value: bool) (x: XamlElement) = x.IsToggled(value)

    /// Adjusts the Toggled property in the visual element
    let toggled (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: XamlElement) = x.Toggled(value)

    /// Adjusts the On property in the visual element
    let on (value: bool) (x: XamlElement) = x.On(value)

    /// Adjusts the OnChanged property in the visual element
    let onChanged (value: Xamarin.Forms.ToggledEventArgs -> unit) (x: XamlElement) = x.OnChanged(value)

    /// Adjusts the Intent property in the visual element
    let intent (value: Xamarin.Forms.TableIntent) (x: XamlElement) = x.Intent(value)

    /// Adjusts the HasUnevenRows property in the visual element
    let hasUnevenRows (value: bool) (x: XamlElement) = x.HasUnevenRows(value)

    /// Adjusts the RowHeight property in the visual element
    let rowHeight (value: int) (x: XamlElement) = x.RowHeight(value)

    /// Adjusts the TableRoot property in the visual element
    let tableRoot (value: (string * XamlElement list) list) (x: XamlElement) = x.TableRoot(value)

    /// Adjusts the GridRowDefinitions property in the visual element
    let gridRowDefinitions (value: obj list) (x: XamlElement) = x.GridRowDefinitions(value)

    /// Adjusts the GridColumnDefinitions property in the visual element
    let gridColumnDefinitions (value: obj list) (x: XamlElement) = x.GridColumnDefinitions(value)

    /// Adjusts the RowSpacing property in the visual element
    let rowSpacing (value: double) (x: XamlElement) = x.RowSpacing(value)

    /// Adjusts the ColumnSpacing property in the visual element
    let columnSpacing (value: double) (x: XamlElement) = x.ColumnSpacing(value)

    /// Adjusts the Children property in the visual element
    let children (value: XamlElement list) (x: XamlElement) = x.Children(value)

    /// Adjusts the GridRow property in the visual element
    let gridRow (value: int) (x: XamlElement) = x.GridRow(value)

    /// Adjusts the GridRowSpan property in the visual element
    let gridRowSpan (value: int) (x: XamlElement) = x.GridRowSpan(value)

    /// Adjusts the GridColumn property in the visual element
    let gridColumn (value: int) (x: XamlElement) = x.GridColumn(value)

    /// Adjusts the GridColumnSpan property in the visual element
    let gridColumnSpan (value: int) (x: XamlElement) = x.GridColumnSpan(value)

    /// Adjusts the LayoutBounds property in the visual element
    let layoutBounds (value: Xamarin.Forms.Rectangle) (x: XamlElement) = x.LayoutBounds(value)

    /// Adjusts the LayoutFlags property in the visual element
    let layoutFlags (value: Xamarin.Forms.AbsoluteLayoutFlags) (x: XamlElement) = x.LayoutFlags(value)

    /// Adjusts the BoundsConstraint property in the visual element
    let boundsConstraint (value: Xamarin.Forms.BoundsConstraint) (x: XamlElement) = x.BoundsConstraint(value)

    /// Adjusts the HeightConstraint property in the visual element
    let heightConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.HeightConstraint(value)

    /// Adjusts the WidthConstraint property in the visual element
    let widthConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.WidthConstraint(value)

    /// Adjusts the XConstraint property in the visual element
    let xConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.XConstraint(value)

    /// Adjusts the YConstraint property in the visual element
    let yConstraint (value: Xamarin.Forms.Constraint) (x: XamlElement) = x.YConstraint(value)

    /// Adjusts the AlignContent property in the visual element
    let alignContent (value: Xamarin.Forms.FlexAlignContent) (x: XamlElement) = x.AlignContent(value)

    /// Adjusts the AlignItems property in the visual element
    let alignItems (value: Xamarin.Forms.FlexAlignItems) (x: XamlElement) = x.AlignItems(value)

    /// Adjusts the Direction property in the visual element
    let direction (value: Xamarin.Forms.FlexDirection) (x: XamlElement) = x.Direction(value)

    /// Adjusts the Position property in the visual element
    let position (value: Xamarin.Forms.FlexPosition) (x: XamlElement) = x.Position(value)

    /// Adjusts the Wrap property in the visual element
    let wrap (value: Xamarin.Forms.FlexWrap) (x: XamlElement) = x.Wrap(value)

    /// Adjusts the JustifyContent property in the visual element
    let justifyContent (value: Xamarin.Forms.FlexJustify) (x: XamlElement) = x.JustifyContent(value)

    /// Adjusts the FlexAlignSelf property in the visual element
    let flexAlignSelf (value: Xamarin.Forms.FlexAlignSelf) (x: XamlElement) = x.FlexAlignSelf(value)

    /// Adjusts the FlexOrder property in the visual element
    let flexOrder (value: int) (x: XamlElement) = x.FlexOrder(value)

    /// Adjusts the FlexBasis property in the visual element
    let flexBasis (value: Xamarin.Forms.FlexBasis) (x: XamlElement) = x.FlexBasis(value)

    /// Adjusts the FlexGrow property in the visual element
    let flexGrow (value: double) (x: XamlElement) = x.FlexGrow(value)

    /// Adjusts the FlexShrink property in the visual element
    let flexShrink (value: double) (x: XamlElement) = x.FlexShrink(value)

    /// Adjusts the RowDefinitionHeight property in the visual element
    let rowDefinitionHeight (value: obj) (x: XamlElement) = x.RowDefinitionHeight(value)

    /// Adjusts the ColumnDefinitionWidth property in the visual element
    let columnDefinitionWidth (value: obj) (x: XamlElement) = x.ColumnDefinitionWidth(value)

    /// Adjusts the Date property in the visual element
    let date (value: System.DateTime) (x: XamlElement) = x.Date(value)

    /// Adjusts the Format property in the visual element
    let format (value: string) (x: XamlElement) = x.Format(value)

    /// Adjusts the MinimumDate property in the visual element
    let minimumDate (value: System.DateTime) (x: XamlElement) = x.MinimumDate(value)

    /// Adjusts the MaximumDate property in the visual element
    let maximumDate (value: System.DateTime) (x: XamlElement) = x.MaximumDate(value)

    /// Adjusts the DateSelected property in the visual element
    let dateSelected (value: Xamarin.Forms.DateChangedEventArgs -> unit) (x: XamlElement) = x.DateSelected(value)

    /// Adjusts the PickerItemsSource property in the visual element
    let pickerItemsSource (value: seq<'T>) (x: XamlElement) = x.PickerItemsSource(value)

    /// Adjusts the SelectedIndex property in the visual element
    let selectedIndex (value: int) (x: XamlElement) = x.SelectedIndex(value)

    /// Adjusts the Title property in the visual element
    let title (value: string) (x: XamlElement) = x.Title(value)

    /// Adjusts the SelectedIndexChanged property in the visual element
    let selectedIndexChanged (value: (int * 'T option) -> unit) (x: XamlElement) = x.SelectedIndexChanged(value)

    /// Adjusts the FrameCornerRadius property in the visual element
    let frameCornerRadius (value: double) (x: XamlElement) = x.FrameCornerRadius(value)

    /// Adjusts the HasShadow property in the visual element
    let hasShadow (value: bool) (x: XamlElement) = x.HasShadow(value)

    /// Adjusts the ImageSource property in the visual element
    let imageSource (value: string) (x: XamlElement) = x.ImageSource(value)

    /// Adjusts the Aspect property in the visual element
    let aspect (value: Xamarin.Forms.Aspect) (x: XamlElement) = x.Aspect(value)

    /// Adjusts the IsOpaque property in the visual element
    let isOpaque (value: bool) (x: XamlElement) = x.IsOpaque(value)

    /// Adjusts the Keyboard property in the visual element
    let keyboard (value: Xamarin.Forms.Keyboard) (x: XamlElement) = x.Keyboard(value)

    /// Adjusts the EditorCompleted property in the visual element
    let editorCompleted (value: string -> unit) (x: XamlElement) = x.EditorCompleted(value)

    /// Adjusts the TextChanged property in the visual element
    let textChanged (value: Xamarin.Forms.TextChangedEventArgs -> unit) (x: XamlElement) = x.TextChanged(value)

    /// Adjusts the IsPassword property in the visual element
    let isPassword (value: bool) (x: XamlElement) = x.IsPassword(value)

    /// Adjusts the EntryCompleted property in the visual element
    let entryCompleted (value: string -> unit) (x: XamlElement) = x.EntryCompleted(value)

    /// Adjusts the Label property in the visual element
    let label (value: string) (x: XamlElement) = x.Label(value)

    /// Adjusts the VerticalTextAlignment property in the visual element
    let verticalTextAlignment (value: Xamarin.Forms.TextAlignment) (x: XamlElement) = x.VerticalTextAlignment(value)

    /// Adjusts the FormattedText property in the visual element
    let formattedText (value: XamlElement) (x: XamlElement) = x.FormattedText(value)

    /// Adjusts the IsClippedToBounds property in the visual element
    let isClippedToBounds (value: bool) (x: XamlElement) = x.IsClippedToBounds(value)

    /// Adjusts the Padding property in the visual element
    let padding (value: obj) (x: XamlElement) = x.Padding(value)

    /// Adjusts the StackOrientation property in the visual element
    let stackOrientation (value: Xamarin.Forms.StackOrientation) (x: XamlElement) = x.StackOrientation(value)

    /// Adjusts the Spacing property in the visual element
    let spacing (value: double) (x: XamlElement) = x.Spacing(value)

    /// Adjusts the ForegroundColor property in the visual element
    let foregroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.ForegroundColor(value)

    /// Adjusts the PropertyChanged property in the visual element
    let propertyChanged (value: System.ComponentModel.PropertyChangedEventArgs -> unit) (x: XamlElement) = x.PropertyChanged(value)

    /// Adjusts the Spans property in the visual element
    let spans (value: XamlElement[]) (x: XamlElement) = x.Spans(value)

    /// Adjusts the Time property in the visual element
    let time (value: System.TimeSpan) (x: XamlElement) = x.Time(value)

    /// Adjusts the WebSource property in the visual element
    let webSource (value: Xamarin.Forms.WebViewSource) (x: XamlElement) = x.WebSource(value)

    /// Adjusts the Navigated property in the visual element
    let navigated (value: Xamarin.Forms.WebNavigatedEventArgs -> unit) (x: XamlElement) = x.Navigated(value)

    /// Adjusts the Navigating property in the visual element
    let navigating (value: Xamarin.Forms.WebNavigatingEventArgs -> unit) (x: XamlElement) = x.Navigating(value)

    /// Adjusts the BackgroundImage property in the visual element
    let backgroundImage (value: string) (x: XamlElement) = x.BackgroundImage(value)

    /// Adjusts the Icon property in the visual element
    let icon (value: string) (x: XamlElement) = x.Icon(value)

    /// Adjusts the IsBusy property in the visual element
    let isBusy (value: bool) (x: XamlElement) = x.IsBusy(value)

    /// Adjusts the ToolbarItems property in the visual element
    let toolbarItems (value: XamlElement list) (x: XamlElement) = x.ToolbarItems(value)

    /// Adjusts the UseSafeArea property in the visual element
    let useSafeArea (value: bool) (x: XamlElement) = x.UseSafeArea(value)

    /// Adjusts the Page_Appearing property in the visual element
    let page_Appearing (value: unit -> unit) (x: XamlElement) = x.Page_Appearing(value)

    /// Adjusts the Page_Disappearing property in the visual element
    let page_Disappearing (value: unit -> unit) (x: XamlElement) = x.Page_Disappearing(value)

    /// Adjusts the Page_LayoutChanged property in the visual element
    let page_LayoutChanged (value: unit -> unit) (x: XamlElement) = x.Page_LayoutChanged(value)

    /// Adjusts the CarouselPage_SelectedItem property in the visual element
    let carouselPage_SelectedItem (value: System.Object) (x: XamlElement) = x.CarouselPage_SelectedItem(value)

    /// Adjusts the CurrentPage property in the visual element
    let currentPage (value: XamlElement) (x: XamlElement) = x.CurrentPage(value)

    /// Adjusts the CurrentPageChanged property in the visual element
    let currentPageChanged (value: 'T option -> unit) (x: XamlElement) = x.CurrentPageChanged(value)

    /// Adjusts the Pages property in the visual element
    let pages (value: XamlElement list) (x: XamlElement) = x.Pages(value)

    /// Adjusts the BackButtonTitle property in the visual element
    let backButtonTitle (value: string) (x: XamlElement) = x.BackButtonTitle(value)

    /// Adjusts the HasBackButton property in the visual element
    let hasBackButton (value: bool) (x: XamlElement) = x.HasBackButton(value)

    /// Adjusts the HasNavigationBar property in the visual element
    let hasNavigationBar (value: bool) (x: XamlElement) = x.HasNavigationBar(value)

    /// Adjusts the TitleIcon property in the visual element
    let titleIcon (value: string) (x: XamlElement) = x.TitleIcon(value)

    /// Adjusts the BarBackgroundColor property in the visual element
    let barBackgroundColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BarBackgroundColor(value)

    /// Adjusts the BarTextColor property in the visual element
    let barTextColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.BarTextColor(value)

    /// Adjusts the Popped property in the visual element
    let popped (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.Popped(value)

    /// Adjusts the PoppedToRoot property in the visual element
    let poppedToRoot (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.PoppedToRoot(value)

    /// Adjusts the Pushed property in the visual element
    let pushed (value: Xamarin.Forms.NavigationEventArgs -> unit) (x: XamlElement) = x.Pushed(value)

    /// Adjusts the OnSizeAllocatedCallback property in the visual element
    let onSizeAllocatedCallback (value: (double * double) -> unit) (x: XamlElement) = x.OnSizeAllocatedCallback(value)

    /// Adjusts the Master property in the visual element
    let master (value: XamlElement) (x: XamlElement) = x.Master(value)

    /// Adjusts the Detail property in the visual element
    let detail (value: XamlElement) (x: XamlElement) = x.Detail(value)

    /// Adjusts the IsGestureEnabled property in the visual element
    let isGestureEnabled (value: bool) (x: XamlElement) = x.IsGestureEnabled(value)

    /// Adjusts the IsPresented property in the visual element
    let isPresented (value: bool) (x: XamlElement) = x.IsPresented(value)

    /// Adjusts the MasterBehavior property in the visual element
    let masterBehavior (value: Xamarin.Forms.MasterBehavior) (x: XamlElement) = x.MasterBehavior(value)

    /// Adjusts the IsPresentedChanged property in the visual element
    let isPresentedChanged (value: bool -> unit) (x: XamlElement) = x.IsPresentedChanged(value)

    /// Adjusts the Height property in the visual element
    let height (value: double) (x: XamlElement) = x.Height(value)

    /// Adjusts the TextDetail property in the visual element
    let textDetail (value: string) (x: XamlElement) = x.TextDetail(value)

    /// Adjusts the TextDetailColor property in the visual element
    let textDetailColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.TextDetailColor(value)

    /// Adjusts the TextCellCommand property in the visual element
    let textCellCommand (value: unit -> unit) (x: XamlElement) = x.TextCellCommand(value)

    /// Adjusts the TextCellCanExecute property in the visual element
    let textCellCanExecute (value: bool) (x: XamlElement) = x.TextCellCanExecute(value)

    /// Adjusts the Order property in the visual element
    let order (value: Xamarin.Forms.ToolbarItemOrder) (x: XamlElement) = x.Order(value)

    /// Adjusts the Priority property in the visual element
    let priority (value: int) (x: XamlElement) = x.Priority(value)

    /// Adjusts the View property in the visual element
    let view (value: XamlElement) (x: XamlElement) = x.View(value)

    /// Adjusts the ListViewItems property in the visual element
    let listViewItems (value: seq<XamlElement>) (x: XamlElement) = x.ListViewItems(value)

    /// Adjusts the Footer property in the visual element
    let footer (value: System.Object) (x: XamlElement) = x.Footer(value)

    /// Adjusts the Header property in the visual element
    let header (value: System.Object) (x: XamlElement) = x.Header(value)

    /// Adjusts the HeaderTemplate property in the visual element
    let headerTemplate (value: Xamarin.Forms.DataTemplate) (x: XamlElement) = x.HeaderTemplate(value)

    /// Adjusts the IsGroupingEnabled property in the visual element
    let isGroupingEnabled (value: bool) (x: XamlElement) = x.IsGroupingEnabled(value)

    /// Adjusts the IsPullToRefreshEnabled property in the visual element
    let isPullToRefreshEnabled (value: bool) (x: XamlElement) = x.IsPullToRefreshEnabled(value)

    /// Adjusts the IsRefreshing property in the visual element
    let isRefreshing (value: bool) (x: XamlElement) = x.IsRefreshing(value)

    /// Adjusts the RefreshCommand property in the visual element
    let refreshCommand (value: unit -> unit) (x: XamlElement) = x.RefreshCommand(value)

    /// Adjusts the ListView_SelectedItem property in the visual element
    let listView_SelectedItem (value: int option) (x: XamlElement) = x.ListView_SelectedItem(value)

    /// Adjusts the ListView_SeparatorVisibility property in the visual element
    let listView_SeparatorVisibility (value: Xamarin.Forms.SeparatorVisibility) (x: XamlElement) = x.ListView_SeparatorVisibility(value)

    /// Adjusts the ListView_SeparatorColor property in the visual element
    let listView_SeparatorColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.ListView_SeparatorColor(value)

    /// Adjusts the ListView_ItemAppearing property in the visual element
    let listView_ItemAppearing (value: int -> unit) (x: XamlElement) = x.ListView_ItemAppearing(value)

    /// Adjusts the ListView_ItemDisappearing property in the visual element
    let listView_ItemDisappearing (value: int -> unit) (x: XamlElement) = x.ListView_ItemDisappearing(value)

    /// Adjusts the ListView_ItemSelected property in the visual element
    let listView_ItemSelected (value: int option -> unit) (x: XamlElement) = x.ListView_ItemSelected(value)

    /// Adjusts the ListView_ItemTapped property in the visual element
    let listView_ItemTapped (value: int -> unit) (x: XamlElement) = x.ListView_ItemTapped(value)

    /// Adjusts the ListView_Refreshing property in the visual element
    let listView_Refreshing (value: unit -> unit) (x: XamlElement) = x.ListView_Refreshing(value)

    /// Adjusts the ListViewGrouped_ItemsSource property in the visual element
    let listViewGrouped_ItemsSource (value: (XamlElement * XamlElement list) list) (x: XamlElement) = x.ListViewGrouped_ItemsSource(value)

    /// Adjusts the ListViewGrouped_SelectedItem property in the visual element
    let listViewGrouped_SelectedItem (value: (int * int) option) (x: XamlElement) = x.ListViewGrouped_SelectedItem(value)

    /// Adjusts the SeparatorVisibility property in the visual element
    let separatorVisibility (value: Xamarin.Forms.SeparatorVisibility) (x: XamlElement) = x.SeparatorVisibility(value)

    /// Adjusts the SeparatorColor property in the visual element
    let separatorColor (value: Xamarin.Forms.Color) (x: XamlElement) = x.SeparatorColor(value)

    /// Adjusts the ListViewGrouped_ItemAppearing property in the visual element
    let listViewGrouped_ItemAppearing (value: int * int -> unit) (x: XamlElement) = x.ListViewGrouped_ItemAppearing(value)

    /// Adjusts the ListViewGrouped_ItemDisappearing property in the visual element
    let listViewGrouped_ItemDisappearing (value: int * int -> unit) (x: XamlElement) = x.ListViewGrouped_ItemDisappearing(value)

    /// Adjusts the ListViewGrouped_ItemSelected property in the visual element
    let listViewGrouped_ItemSelected (value: (int * int) option -> unit) (x: XamlElement) = x.ListViewGrouped_ItemSelected(value)

    /// Adjusts the ListViewGrouped_ItemTapped property in the visual element
    let listViewGrouped_ItemTapped (value: int * int -> unit) (x: XamlElement) = x.ListViewGrouped_ItemTapped(value)

    /// Adjusts the Refreshing property in the visual element
    let refreshing (value: unit -> unit) (x: XamlElement) = x.Refreshing(value)
