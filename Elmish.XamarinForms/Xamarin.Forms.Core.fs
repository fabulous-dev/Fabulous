namespace Elmish.XamarinForms.DynamicViews 

#nowarn "67" // cast always holds

type Xaml() =
    static member val internal ClassIdKey = ViewElement.GetKey("ClassId")
    static member val internal StyleIdKey = ViewElement.GetKey("StyleId")
    static member val internal AnchorXKey = ViewElement.GetKey("AnchorX")
    static member val internal AnchorYKey = ViewElement.GetKey("AnchorY")
    static member val internal BackgroundColorKey = ViewElement.GetKey("BackgroundColor")
    static member val internal HeightRequestKey = ViewElement.GetKey("HeightRequest")
    static member val internal InputTransparentKey = ViewElement.GetKey("InputTransparent")
    static member val internal IsEnabledKey = ViewElement.GetKey("IsEnabled")
    static member val internal IsVisibleKey = ViewElement.GetKey("IsVisible")
    static member val internal MinimumHeightRequestKey = ViewElement.GetKey("MinimumHeightRequest")
    static member val internal MinimumWidthRequestKey = ViewElement.GetKey("MinimumWidthRequest")
    static member val internal OpacityKey = ViewElement.GetKey("Opacity")
    static member val internal RotationKey = ViewElement.GetKey("Rotation")
    static member val internal RotationXKey = ViewElement.GetKey("RotationX")
    static member val internal RotationYKey = ViewElement.GetKey("RotationY")
    static member val internal ScaleKey = ViewElement.GetKey("Scale")
    static member val internal StyleKey = ViewElement.GetKey("Style")
    static member val internal TranslationXKey = ViewElement.GetKey("TranslationX")
    static member val internal TranslationYKey = ViewElement.GetKey("TranslationY")
    static member val internal WidthRequestKey = ViewElement.GetKey("WidthRequest")
    static member val internal ResourcesKey = ViewElement.GetKey("Resources")
    static member val internal StylesKey = ViewElement.GetKey("Styles")
    static member val internal StyleSheetsKey = ViewElement.GetKey("StyleSheets")
    static member val internal HorizontalOptionsKey = ViewElement.GetKey("HorizontalOptions")
    static member val internal VerticalOptionsKey = ViewElement.GetKey("VerticalOptions")
    static member val internal MarginKey = ViewElement.GetKey("Margin")
    static member val internal GestureRecognizersKey = ViewElement.GetKey("GestureRecognizers")
    static member val internal TouchPointsKey = ViewElement.GetKey("TouchPoints")
    static member val internal PanUpdatedKey = ViewElement.GetKey("PanUpdated")
    static member val internal CommandKey = ViewElement.GetKey("Command")
    static member val internal NumberOfTapsRequiredKey = ViewElement.GetKey("NumberOfTapsRequired")
    static member val internal NumberOfClicksRequiredKey = ViewElement.GetKey("NumberOfClicksRequired")
    static member val internal ButtonsKey = ViewElement.GetKey("Buttons")
    static member val internal IsPinchingKey = ViewElement.GetKey("IsPinching")
    static member val internal PinchUpdatedKey = ViewElement.GetKey("PinchUpdated")
    static member val internal ColorKey = ViewElement.GetKey("Color")
    static member val internal IsRunningKey = ViewElement.GetKey("IsRunning")
    static member val internal ProgressKey = ViewElement.GetKey("Progress")
    static member val internal ContentKey = ViewElement.GetKey("Content")
    static member val internal ScrollOrientationKey = ViewElement.GetKey("ScrollOrientation")
    static member val internal CancelButtonColorKey = ViewElement.GetKey("CancelButtonColor")
    static member val internal FontFamilyKey = ViewElement.GetKey("FontFamily")
    static member val internal FontAttributesKey = ViewElement.GetKey("FontAttributes")
    static member val internal FontSizeKey = ViewElement.GetKey("FontSize")
    static member val internal HorizontalTextAlignmentKey = ViewElement.GetKey("HorizontalTextAlignment")
    static member val internal PlaceholderKey = ViewElement.GetKey("Placeholder")
    static member val internal PlaceholderColorKey = ViewElement.GetKey("PlaceholderColor")
    static member val internal SearchBarCommandKey = ViewElement.GetKey("SearchBarCommand")
    static member val internal SearchBarCanExecuteKey = ViewElement.GetKey("SearchBarCanExecute")
    static member val internal TextKey = ViewElement.GetKey("Text")
    static member val internal TextColorKey = ViewElement.GetKey("TextColor")
    static member val internal ButtonCommandKey = ViewElement.GetKey("ButtonCommand")
    static member val internal ButtonCanExecuteKey = ViewElement.GetKey("ButtonCanExecute")
    static member val internal BorderColorKey = ViewElement.GetKey("BorderColor")
    static member val internal BorderWidthKey = ViewElement.GetKey("BorderWidth")
    static member val internal CommandParameterKey = ViewElement.GetKey("CommandParameter")
    static member val internal ContentLayoutKey = ViewElement.GetKey("ContentLayout")
    static member val internal ButtonCornerRadiusKey = ViewElement.GetKey("ButtonCornerRadius")
    static member val internal ButtonImageSourceKey = ViewElement.GetKey("ButtonImageSource")
    static member val internal MinimumKey = ViewElement.GetKey("Minimum")
    static member val internal MaximumKey = ViewElement.GetKey("Maximum")
    static member val internal ValueKey = ViewElement.GetKey("Value")
    static member val internal ValueChangedKey = ViewElement.GetKey("ValueChanged")
    static member val internal IncrementKey = ViewElement.GetKey("Increment")
    static member val internal IsToggledKey = ViewElement.GetKey("IsToggled")
    static member val internal ToggledKey = ViewElement.GetKey("Toggled")
    static member val internal OnKey = ViewElement.GetKey("On")
    static member val internal OnChangedKey = ViewElement.GetKey("OnChanged")
    static member val internal IntentKey = ViewElement.GetKey("Intent")
    static member val internal HasUnevenRowsKey = ViewElement.GetKey("HasUnevenRows")
    static member val internal RowHeightKey = ViewElement.GetKey("RowHeight")
    static member val internal TableRootKey = ViewElement.GetKey("TableRoot")
    static member val internal GridRowDefinitionsKey = ViewElement.GetKey("GridRowDefinitions")
    static member val internal GridColumnDefinitionsKey = ViewElement.GetKey("GridColumnDefinitions")
    static member val internal RowSpacingKey = ViewElement.GetKey("RowSpacing")
    static member val internal ColumnSpacingKey = ViewElement.GetKey("ColumnSpacing")
    static member val internal ChildrenKey = ViewElement.GetKey("Children")
    static member val internal GridRowKey = ViewElement.GetKey("GridRow")
    static member val internal GridRowSpanKey = ViewElement.GetKey("GridRowSpan")
    static member val internal GridColumnKey = ViewElement.GetKey("GridColumn")
    static member val internal GridColumnSpanKey = ViewElement.GetKey("GridColumnSpan")
    static member val internal LayoutBoundsKey = ViewElement.GetKey("LayoutBounds")
    static member val internal LayoutFlagsKey = ViewElement.GetKey("LayoutFlags")
    static member val internal BoundsConstraintKey = ViewElement.GetKey("BoundsConstraint")
    static member val internal HeightConstraintKey = ViewElement.GetKey("HeightConstraint")
    static member val internal WidthConstraintKey = ViewElement.GetKey("WidthConstraint")
    static member val internal XConstraintKey = ViewElement.GetKey("XConstraint")
    static member val internal YConstraintKey = ViewElement.GetKey("YConstraint")
    static member val internal AlignContentKey = ViewElement.GetKey("AlignContent")
    static member val internal AlignItemsKey = ViewElement.GetKey("AlignItems")
    static member val internal DirectionKey = ViewElement.GetKey("Direction")
    static member val internal PositionKey = ViewElement.GetKey("Position")
    static member val internal WrapKey = ViewElement.GetKey("Wrap")
    static member val internal JustifyContentKey = ViewElement.GetKey("JustifyContent")
    static member val internal FlexAlignSelfKey = ViewElement.GetKey("FlexAlignSelf")
    static member val internal FlexOrderKey = ViewElement.GetKey("FlexOrder")
    static member val internal FlexBasisKey = ViewElement.GetKey("FlexBasis")
    static member val internal FlexGrowKey = ViewElement.GetKey("FlexGrow")
    static member val internal FlexShrinkKey = ViewElement.GetKey("FlexShrink")
    static member val internal RowDefinitionHeightKey = ViewElement.GetKey("RowDefinitionHeight")
    static member val internal ColumnDefinitionWidthKey = ViewElement.GetKey("ColumnDefinitionWidth")
    static member val internal DateKey = ViewElement.GetKey("Date")
    static member val internal FormatKey = ViewElement.GetKey("Format")
    static member val internal MinimumDateKey = ViewElement.GetKey("MinimumDate")
    static member val internal MaximumDateKey = ViewElement.GetKey("MaximumDate")
    static member val internal DateSelectedKey = ViewElement.GetKey("DateSelected")
    static member val internal PickerItemsSourceKey = ViewElement.GetKey("PickerItemsSource")
    static member val internal SelectedIndexKey = ViewElement.GetKey("SelectedIndex")
    static member val internal TitleKey = ViewElement.GetKey("Title")
    static member val internal SelectedIndexChangedKey = ViewElement.GetKey("SelectedIndexChanged")
    static member val internal FrameCornerRadiusKey = ViewElement.GetKey("FrameCornerRadius")
    static member val internal HasShadowKey = ViewElement.GetKey("HasShadow")
    static member val internal ImageSourceKey = ViewElement.GetKey("ImageSource")
    static member val internal AspectKey = ViewElement.GetKey("Aspect")
    static member val internal IsOpaqueKey = ViewElement.GetKey("IsOpaque")
    static member val internal KeyboardKey = ViewElement.GetKey("Keyboard")
    static member val internal EditorCompletedKey = ViewElement.GetKey("EditorCompleted")
    static member val internal TextChangedKey = ViewElement.GetKey("TextChanged")
    static member val internal IsPasswordKey = ViewElement.GetKey("IsPassword")
    static member val internal EntryCompletedKey = ViewElement.GetKey("EntryCompleted")
    static member val internal LabelKey = ViewElement.GetKey("Label")
    static member val internal VerticalTextAlignmentKey = ViewElement.GetKey("VerticalTextAlignment")
    static member val internal FormattedTextKey = ViewElement.GetKey("FormattedText")
    static member val internal IsClippedToBoundsKey = ViewElement.GetKey("IsClippedToBounds")
    static member val internal PaddingKey = ViewElement.GetKey("Padding")
    static member val internal StackOrientationKey = ViewElement.GetKey("StackOrientation")
    static member val internal SpacingKey = ViewElement.GetKey("Spacing")
    static member val internal ForegroundColorKey = ViewElement.GetKey("ForegroundColor")
    static member val internal PropertyChangedKey = ViewElement.GetKey("PropertyChanged")
    static member val internal SpansKey = ViewElement.GetKey("Spans")
    static member val internal TimeKey = ViewElement.GetKey("Time")
    static member val internal WebSourceKey = ViewElement.GetKey("WebSource")
    static member val internal NavigatedKey = ViewElement.GetKey("Navigated")
    static member val internal NavigatingKey = ViewElement.GetKey("Navigating")
    static member val internal BackgroundImageKey = ViewElement.GetKey("BackgroundImage")
    static member val internal IconKey = ViewElement.GetKey("Icon")
    static member val internal IsBusyKey = ViewElement.GetKey("IsBusy")
    static member val internal ToolbarItemsKey = ViewElement.GetKey("ToolbarItems")
    static member val internal UseSafeAreaKey = ViewElement.GetKey("UseSafeArea")
    static member val internal Page_AppearingKey = ViewElement.GetKey("Page_Appearing")
    static member val internal Page_DisappearingKey = ViewElement.GetKey("Page_Disappearing")
    static member val internal Page_LayoutChangedKey = ViewElement.GetKey("Page_LayoutChanged")
    static member val internal CarouselPage_SelectedItemKey = ViewElement.GetKey("CarouselPage_SelectedItem")
    static member val internal CurrentPageKey = ViewElement.GetKey("CurrentPage")
    static member val internal CurrentPageChangedKey = ViewElement.GetKey("CurrentPageChanged")
    static member val internal PagesKey = ViewElement.GetKey("Pages")
    static member val internal BackButtonTitleKey = ViewElement.GetKey("BackButtonTitle")
    static member val internal HasBackButtonKey = ViewElement.GetKey("HasBackButton")
    static member val internal HasNavigationBarKey = ViewElement.GetKey("HasNavigationBar")
    static member val internal TitleIconKey = ViewElement.GetKey("TitleIcon")
    static member val internal BarBackgroundColorKey = ViewElement.GetKey("BarBackgroundColor")
    static member val internal BarTextColorKey = ViewElement.GetKey("BarTextColor")
    static member val internal PoppedKey = ViewElement.GetKey("Popped")
    static member val internal PoppedToRootKey = ViewElement.GetKey("PoppedToRoot")
    static member val internal PushedKey = ViewElement.GetKey("Pushed")
    static member val internal OnSizeAllocatedCallbackKey = ViewElement.GetKey("OnSizeAllocatedCallback")
    static member val internal MasterKey = ViewElement.GetKey("Master")
    static member val internal DetailKey = ViewElement.GetKey("Detail")
    static member val internal IsGestureEnabledKey = ViewElement.GetKey("IsGestureEnabled")
    static member val internal IsPresentedKey = ViewElement.GetKey("IsPresented")
    static member val internal MasterBehaviorKey = ViewElement.GetKey("MasterBehavior")
    static member val internal IsPresentedChangedKey = ViewElement.GetKey("IsPresentedChanged")
    static member val internal HeightKey = ViewElement.GetKey("Height")
    static member val internal TextDetailKey = ViewElement.GetKey("TextDetail")
    static member val internal TextDetailColorKey = ViewElement.GetKey("TextDetailColor")
    static member val internal TextCellCommandKey = ViewElement.GetKey("TextCellCommand")
    static member val internal TextCellCanExecuteKey = ViewElement.GetKey("TextCellCanExecute")
    static member val internal OrderKey = ViewElement.GetKey("Order")
    static member val internal PriorityKey = ViewElement.GetKey("Priority")
    static member val internal ViewKey = ViewElement.GetKey("View")
    static member val internal ListViewItemsKey = ViewElement.GetKey("ListViewItems")
    static member val internal FooterKey = ViewElement.GetKey("Footer")
    static member val internal HeaderKey = ViewElement.GetKey("Header")
    static member val internal HeaderTemplateKey = ViewElement.GetKey("HeaderTemplate")
    static member val internal IsGroupingEnabledKey = ViewElement.GetKey("IsGroupingEnabled")
    static member val internal IsPullToRefreshEnabledKey = ViewElement.GetKey("IsPullToRefreshEnabled")
    static member val internal IsRefreshingKey = ViewElement.GetKey("IsRefreshing")
    static member val internal RefreshCommandKey = ViewElement.GetKey("RefreshCommand")
    static member val internal ListView_SelectedItemKey = ViewElement.GetKey("ListView_SelectedItem")
    static member val internal ListView_SeparatorVisibilityKey = ViewElement.GetKey("ListView_SeparatorVisibility")
    static member val internal ListView_SeparatorColorKey = ViewElement.GetKey("ListView_SeparatorColor")
    static member val internal ListView_ItemAppearingKey = ViewElement.GetKey("ListView_ItemAppearing")
    static member val internal ListView_ItemDisappearingKey = ViewElement.GetKey("ListView_ItemDisappearing")
    static member val internal ListView_ItemSelectedKey = ViewElement.GetKey("ListView_ItemSelected")
    static member val internal ListView_ItemTappedKey = ViewElement.GetKey("ListView_ItemTapped")
    static member val internal ListView_RefreshingKey = ViewElement.GetKey("ListView_Refreshing")
    static member val internal ListViewGrouped_ItemsSourceKey = ViewElement.GetKey("ListViewGrouped_ItemsSource")
    static member val internal ListViewGrouped_SelectedItemKey = ViewElement.GetKey("ListViewGrouped_SelectedItem")
    static member val internal SeparatorVisibilityKey = ViewElement.GetKey("SeparatorVisibility")
    static member val internal SeparatorColorKey = ViewElement.GetKey("SeparatorColor")
    static member val internal ListViewGrouped_ItemAppearingKey = ViewElement.GetKey("ListViewGrouped_ItemAppearing")
    static member val internal ListViewGrouped_ItemDisappearingKey = ViewElement.GetKey("ListViewGrouped_ItemDisappearing")
    static member val internal ListViewGrouped_ItemSelectedKey = ViewElement.GetKey("ListViewGrouped_ItemSelected")
    static member val internal ListViewGrouped_ItemTappedKey = ViewElement.GetKey("ListViewGrouped_ItemTapped")
    static member val internal RefreshingKey = ViewElement.GetKey("Refreshing")

    /// Describes a Element in the view
    static member Element(?classId: string, ?styleId: string) = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            match classId with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ClassIdKey, box ((v)))) 
            match styleId with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.StyleIdKey, box ((v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Element"

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.Element)
            let mutable prevClassIdOpt = ValueNone
            let mutable currClassIdOpt = ValueNone
            let mutable prevStyleIdOpt = ValueNone
            let mutable currStyleIdOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ClassIdKey then 
                    currClassIdOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.StyleIdKey then 
                    currStyleIdOpt <- ValueSome (kvp.Value :?> string)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ClassIdKey then 
                        prevClassIdOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.StyleIdKey then 
                        prevStyleIdOpt <- ValueSome (kvp.Value :?> string)
            match prevClassIdOpt, currClassIdOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.ClassId <-  currValue
            | ValueSome _, ValueNone -> target.ClassId <- null
            | ValueNone, ValueNone -> ()
            match prevStyleIdOpt, currStyleIdOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.StyleId <-  currValue
            | ValueSome _, ValueNone -> target.StyleId <- null
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Element>, create, update, attribs)

    /// Describes a VisualElement in the view
    static member VisualElement(?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Element(?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.AnchorXKey then 
                    currAnchorXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.AnchorYKey then 
                    currAnchorYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.BackgroundColorKey then 
                    currBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.HeightRequestKey then 
                    currHeightRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.InputTransparentKey then 
                    currInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.IsEnabledKey then 
                    currIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.IsVisibleKey then 
                    currIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.MinimumHeightRequestKey then 
                    currMinimumHeightRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.MinimumWidthRequestKey then 
                    currMinimumWidthRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.OpacityKey then 
                    currOpacityOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.RotationKey then 
                    currRotationOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.RotationXKey then 
                    currRotationXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.RotationYKey then 
                    currRotationYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.ScaleKey then 
                    currScaleOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.StyleKey then 
                    currStyleOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style)
                if kvp.Key = Xaml.TranslationXKey then 
                    currTranslationXOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.TranslationYKey then 
                    currTranslationYOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.WidthRequestKey then 
                    currWidthRequestOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.ResourcesKey then 
                    currResourcesOpt <- ValueSome (kvp.Value :?> (string * obj) list)
                if kvp.Key = Xaml.StylesKey then 
                    currStylesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style list)
                if kvp.Key = Xaml.StyleSheetsKey then 
                    currStyleSheetsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StyleSheets.StyleSheet list)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.AnchorXKey then 
                        prevAnchorXOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.AnchorYKey then 
                        prevAnchorYOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.BackgroundColorKey then 
                        prevBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.HeightRequestKey then 
                        prevHeightRequestOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.InputTransparentKey then 
                        prevInputTransparentOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.IsEnabledKey then 
                        prevIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.IsVisibleKey then 
                        prevIsVisibleOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.MinimumHeightRequestKey then 
                        prevMinimumHeightRequestOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.MinimumWidthRequestKey then 
                        prevMinimumWidthRequestOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.OpacityKey then 
                        prevOpacityOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.RotationKey then 
                        prevRotationOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.RotationXKey then 
                        prevRotationXOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.RotationYKey then 
                        prevRotationYOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.ScaleKey then 
                        prevScaleOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.StyleKey then 
                        prevStyleOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style)
                    if kvp.Key = Xaml.TranslationXKey then 
                        prevTranslationXOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.TranslationYKey then 
                        prevTranslationYOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.WidthRequestKey then 
                        prevWidthRequestOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.ResourcesKey then 
                        prevResourcesOpt <- ValueSome (kvp.Value :?> (string * obj) list)
                    if kvp.Key = Xaml.StylesKey then 
                        prevStylesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Style list)
                    if kvp.Key = Xaml.StyleSheetsKey then 
                        prevStyleSheetsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StyleSheets.StyleSheet list)
            match prevAnchorXOpt, currAnchorXOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.AnchorX <-  currValue
            | ValueSome _, ValueNone -> target.AnchorX <- 0.0
            | ValueNone, ValueNone -> ()
            match prevAnchorYOpt, currAnchorYOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.AnchorY <-  currValue
            | ValueSome _, ValueNone -> target.AnchorY <- 0.0
            | ValueNone, ValueNone -> ()
            match prevBackgroundColorOpt, currBackgroundColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.BackgroundColor <-  currValue
            | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevHeightRequestOpt, currHeightRequestOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HeightRequest <-  currValue
            | ValueSome _, ValueNone -> target.HeightRequest <- -1.0
            | ValueNone, ValueNone -> ()
            match prevInputTransparentOpt, currInputTransparentOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.InputTransparent <-  currValue
            | ValueSome _, ValueNone -> target.InputTransparent <- false
            | ValueNone, ValueNone -> ()
            match prevIsEnabledOpt, currIsEnabledOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsEnabled <-  currValue
            | ValueSome _, ValueNone -> target.IsEnabled <- true
            | ValueNone, ValueNone -> ()
            match prevIsVisibleOpt, currIsVisibleOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsVisible <-  currValue
            | ValueSome _, ValueNone -> target.IsVisible <- true
            | ValueNone, ValueNone -> ()
            match prevMinimumHeightRequestOpt, currMinimumHeightRequestOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.MinimumHeightRequest <-  currValue
            | ValueSome _, ValueNone -> target.MinimumHeightRequest <- -1.0
            | ValueNone, ValueNone -> ()
            match prevMinimumWidthRequestOpt, currMinimumWidthRequestOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.MinimumWidthRequest <-  currValue
            | ValueSome _, ValueNone -> target.MinimumWidthRequest <- -1.0
            | ValueNone, ValueNone -> ()
            match prevOpacityOpt, currOpacityOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Opacity <-  currValue
            | ValueSome _, ValueNone -> target.Opacity <- 1.0
            | ValueNone, ValueNone -> ()
            match prevRotationOpt, currRotationOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Rotation <-  currValue
            | ValueSome _, ValueNone -> target.Rotation <- 0.0
            | ValueNone, ValueNone -> ()
            match prevRotationXOpt, currRotationXOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.RotationX <-  currValue
            | ValueSome _, ValueNone -> target.RotationX <- 0.0
            | ValueNone, ValueNone -> ()
            match prevRotationYOpt, currRotationYOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.RotationY <-  currValue
            | ValueSome _, ValueNone -> target.RotationY <- 0.0
            | ValueNone, ValueNone -> ()
            match prevScaleOpt, currScaleOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Scale <-  currValue
            | ValueSome _, ValueNone -> target.Scale <- 1.0
            | ValueNone, ValueNone -> ()
            match prevStyleOpt, currStyleOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Style <-  currValue
            | ValueSome _, ValueNone -> target.Style <- null
            | ValueNone, ValueNone -> ()
            match prevTranslationXOpt, currTranslationXOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TranslationX <-  currValue
            | ValueSome _, ValueNone -> target.TranslationX <- 0.0
            | ValueNone, ValueNone -> ()
            match prevTranslationYOpt, currTranslationYOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TranslationY <-  currValue
            | ValueSome _, ValueNone -> target.TranslationY <- 0.0
            | ValueNone, ValueNone -> ()
            match prevWidthRequestOpt, currWidthRequestOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.WidthRequest <-  currValue
            | ValueSome _, ValueNone -> target.WidthRequest <- -1.0
            | ValueNone, ValueNone -> ()
            updateResources prevResourcesOpt currResourcesOpt target
            updateStyles prevStylesOpt currStylesOpt target
            updateStyleSheets prevStyleSheetsOpt currStyleSheetsOpt target

        new ViewElement(typeof<Xamarin.Forms.VisualElement>, create, update, attribs)

    /// Describes a View in the view
    static member View(?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.VisualElement(?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match horizontalOptions with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HorizontalOptionsKey, box ((v)))) 
            match verticalOptions with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.VerticalOptionsKey, box ((v)))) 
            match margin with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MarginKey, box (makeThickness(v)))) 
            match gestureRecognizers with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.GestureRecognizersKey, box (Array.ofList(v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.View"

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.HorizontalOptionsKey then 
                    currHorizontalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                if kvp.Key = Xaml.VerticalOptionsKey then 
                    currVerticalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                if kvp.Key = Xaml.MarginKey then 
                    currMarginOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                if kvp.Key = Xaml.GestureRecognizersKey then 
                    currGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement[])
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.HorizontalOptionsKey then 
                        prevHorizontalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                    if kvp.Key = Xaml.VerticalOptionsKey then 
                        prevVerticalOptionsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.LayoutOptions)
                    if kvp.Key = Xaml.MarginKey then 
                        prevMarginOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                    if kvp.Key = Xaml.GestureRecognizersKey then 
                        prevGestureRecognizersOpt <- ValueSome (kvp.Value :?> ViewElement[])
            match prevHorizontalOptionsOpt, currHorizontalOptionsOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HorizontalOptions <-  currValue
            | ValueSome _, ValueNone -> target.HorizontalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | ValueNone, ValueNone -> ()
            match prevVerticalOptionsOpt, currVerticalOptionsOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.VerticalOptions <-  currValue
            | ValueSome _, ValueNone -> target.VerticalOptions <- Unchecked.defaultof<Xamarin.Forms.LayoutOptions>
            | ValueNone, ValueNone -> ()
            match prevMarginOpt, currMarginOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Margin <-  currValue
            | ValueSome _, ValueNone -> target.Margin <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | ValueNone, ValueNone -> ()
            updateCollectionGeneric prevGestureRecognizersOpt currGestureRecognizersOpt target.GestureRecognizers
                (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.IGestureRecognizer)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild

        new ViewElement(typeof<Xamarin.Forms.View>, create, update, attribs)

    /// Describes a IGestureRecognizer in the view
    static member IGestureRecognizer() = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.IGestureRecognizer"

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            ()

        new ViewElement(typeof<Xamarin.Forms.IGestureRecognizer>, create, update, attribs)

    /// Describes a PanGestureRecognizer in the view
    static member PanGestureRecognizer(?touchPoints: int, ?panUpdated: Xamarin.Forms.PanUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match touchPoints with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TouchPointsKey, box ((v)))) 
            match panUpdated with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PanUpdatedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.PanGestureRecognizer())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.PanGestureRecognizer)
            let mutable prevTouchPointsOpt = ValueNone
            let mutable currTouchPointsOpt = ValueNone
            let mutable prevPanUpdatedOpt = ValueNone
            let mutable currPanUpdatedOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.TouchPointsKey then 
                    currTouchPointsOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml.PanUpdatedKey then 
                    currPanUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.TouchPointsKey then 
                        prevTouchPointsOpt <- ValueSome (kvp.Value :?> int)
                    if kvp.Key = Xaml.PanUpdatedKey then 
                        prevPanUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PanUpdatedEventArgs>)
            match prevTouchPointsOpt, currTouchPointsOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TouchPoints <-  currValue
            | ValueSome _, ValueNone -> target.TouchPoints <- 1
            | ValueNone, ValueNone -> ()
            match prevPanUpdatedOpt, currPanUpdatedOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.PanUpdated.RemoveHandler(prevValue); target.PanUpdated.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.PanUpdated.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.PanUpdated.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.PanGestureRecognizer>, create, update, attribs)

    /// Describes a TapGestureRecognizer in the view
    static member TapGestureRecognizer(?command: unit -> unit, ?numberOfTapsRequired: int, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match command with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CommandKey, box (makeCommand(v)))) 
            match numberOfTapsRequired with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.NumberOfTapsRequiredKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.TapGestureRecognizer())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.TapGestureRecognizer)
            let mutable prevCommandOpt = ValueNone
            let mutable currCommandOpt = ValueNone
            let mutable prevNumberOfTapsRequiredOpt = ValueNone
            let mutable currNumberOfTapsRequiredOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.CommandKey then 
                    currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml.NumberOfTapsRequiredKey then 
                    currNumberOfTapsRequiredOpt <- ValueSome (kvp.Value :?> int)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.CommandKey then 
                        prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                    if kvp.Key = Xaml.NumberOfTapsRequiredKey then 
                        prevNumberOfTapsRequiredOpt <- ValueSome (kvp.Value :?> int)
            match prevCommandOpt, currCommandOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Command <-  currValue
            | ValueSome _, ValueNone -> target.Command <- null
            | ValueNone, ValueNone -> ()
            match prevNumberOfTapsRequiredOpt, currNumberOfTapsRequiredOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.NumberOfTapsRequired <-  currValue
            | ValueSome _, ValueNone -> target.NumberOfTapsRequired <- 1
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.TapGestureRecognizer>, create, update, attribs)

    /// Describes a ClickGestureRecognizer in the view
    static member ClickGestureRecognizer(?command: unit -> unit, ?numberOfClicksRequired: int, ?buttons: Xamarin.Forms.ButtonsMask, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match command with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CommandKey, box (makeCommand(v)))) 
            match numberOfClicksRequired with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.NumberOfClicksRequiredKey, box ((v)))) 
            match buttons with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ButtonsKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ClickGestureRecognizer())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.ClickGestureRecognizer)
            let mutable prevCommandOpt = ValueNone
            let mutable currCommandOpt = ValueNone
            let mutable prevNumberOfClicksRequiredOpt = ValueNone
            let mutable currNumberOfClicksRequiredOpt = ValueNone
            let mutable prevButtonsOpt = ValueNone
            let mutable currButtonsOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.CommandKey then 
                    currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml.NumberOfClicksRequiredKey then 
                    currNumberOfClicksRequiredOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml.ButtonsKey then 
                    currButtonsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ButtonsMask)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.CommandKey then 
                        prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                    if kvp.Key = Xaml.NumberOfClicksRequiredKey then 
                        prevNumberOfClicksRequiredOpt <- ValueSome (kvp.Value :?> int)
                    if kvp.Key = Xaml.ButtonsKey then 
                        prevButtonsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ButtonsMask)
            match prevCommandOpt, currCommandOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Command <-  currValue
            | ValueSome _, ValueNone -> target.Command <- null
            | ValueNone, ValueNone -> ()
            match prevNumberOfClicksRequiredOpt, currNumberOfClicksRequiredOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.NumberOfClicksRequired <-  currValue
            | ValueSome _, ValueNone -> target.NumberOfClicksRequired <- 1
            | ValueNone, ValueNone -> ()
            match prevButtonsOpt, currButtonsOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Buttons <-  currValue
            | ValueSome _, ValueNone -> target.Buttons <- Xamarin.Forms.ButtonsMask.Primary
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.ClickGestureRecognizer>, create, update, attribs)

    /// Describes a PinchGestureRecognizer in the view
    static member PinchGestureRecognizer(?isPinching: bool, ?pinchUpdated: Xamarin.Forms.PinchGestureUpdatedEventArgs -> unit, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match isPinching with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsPinchingKey, box ((v)))) 
            match pinchUpdated with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PinchUpdatedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.PinchGestureRecognizer())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.PinchGestureRecognizer)
            let mutable prevIsPinchingOpt = ValueNone
            let mutable currIsPinchingOpt = ValueNone
            let mutable prevPinchUpdatedOpt = ValueNone
            let mutable currPinchUpdatedOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.IsPinchingKey then 
                    currIsPinchingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.PinchUpdatedKey then 
                    currPinchUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.IsPinchingKey then 
                        prevIsPinchingOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.PinchUpdatedKey then 
                        prevPinchUpdatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.PinchGestureUpdatedEventArgs>)
            match prevIsPinchingOpt, currIsPinchingOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsPinching <-  currValue
            | ValueSome _, ValueNone -> target.IsPinching <- false
            | ValueNone, ValueNone -> ()
            match prevPinchUpdatedOpt, currPinchUpdatedOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.PinchUpdated.RemoveHandler(prevValue); target.PinchUpdated.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.PinchUpdated.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.PinchUpdated.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.PinchGestureRecognizer>, create, update, attribs)

    /// Describes a ActivityIndicator in the view
    static member ActivityIndicator(?color: Xamarin.Forms.Color, ?isRunning: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match color with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ColorKey, box ((v)))) 
            match isRunning with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsRunningKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ActivityIndicator())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.ActivityIndicator)
            let mutable prevColorOpt = ValueNone
            let mutable currColorOpt = ValueNone
            let mutable prevIsRunningOpt = ValueNone
            let mutable currIsRunningOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ColorKey then 
                    currColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.IsRunningKey then 
                    currIsRunningOpt <- ValueSome (kvp.Value :?> bool)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ColorKey then 
                        prevColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.IsRunningKey then 
                        prevIsRunningOpt <- ValueSome (kvp.Value :?> bool)
            match prevColorOpt, currColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Color <-  currValue
            | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevIsRunningOpt, currIsRunningOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsRunning <-  currValue
            | ValueSome _, ValueNone -> target.IsRunning <- false
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.ActivityIndicator>, create, update, attribs)

    /// Describes a BoxView in the view
    static member BoxView(?color: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match color with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ColorKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.BoxView())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.BoxView)
            let mutable prevColorOpt = ValueNone
            let mutable currColorOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ColorKey then 
                    currColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ColorKey then 
                        prevColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            match prevColorOpt, currColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Color <-  currValue
            | ValueSome _, ValueNone -> target.Color <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.BoxView>, create, update, attribs)

    /// Describes a ProgressBar in the view
    static member ProgressBar(?progress: double, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match progress with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ProgressKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ProgressBar())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.ProgressBar)
            let mutable prevProgressOpt = ValueNone
            let mutable currProgressOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ProgressKey then 
                    currProgressOpt <- ValueSome (kvp.Value :?> double)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ProgressKey then 
                        prevProgressOpt <- ValueSome (kvp.Value :?> double)
            match prevProgressOpt, currProgressOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Progress <-  currValue
            | ValueSome _, ValueNone -> target.Progress <- 0.0
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.ProgressBar>, create, update, attribs)

    /// Describes a ScrollView in the view
    static member ScrollView(?content: ViewElement, ?orientation: Xamarin.Forms.ScrollOrientation, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match content with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ContentKey, box ((v)))) 
            match orientation with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ScrollOrientationKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ScrollView())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.ScrollView)
            let mutable prevContentOpt = ValueNone
            let mutable currContentOpt = ValueNone
            let mutable prevScrollOrientationOpt = ValueNone
            let mutable currScrollOrientationOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ContentKey then 
                    currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml.ScrollOrientationKey then 
                    currScrollOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ScrollOrientation)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ContentKey then 
                        prevContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                    if kvp.Key = Xaml.ScrollOrientationKey then 
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
            | prevOpt, ValueSome currValue -> target.Orientation <-  currValue
            | ValueSome _, ValueNone -> target.Orientation <- Unchecked.defaultof<Xamarin.Forms.ScrollOrientation>
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.ScrollView>, create, update, attribs)

    /// Describes a SearchBar in the view
    static member SearchBar(?cancelButtonColor: Xamarin.Forms.Color, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?placeholder: string, ?placeholderColor: Xamarin.Forms.Color, ?searchCommand: string -> unit, ?canExecute: bool, ?text: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.CancelButtonColorKey then 
                    currCancelButtonColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.FontFamilyKey then 
                    currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.FontAttributesKey then 
                    currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml.FontSizeKey then 
                    currFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.HorizontalTextAlignmentKey then 
                    currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml.PlaceholderKey then 
                    currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.PlaceholderColorKey then 
                    currPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.SearchBarCommandKey then 
                    currSearchBarCommandOpt <- ValueSome (kvp.Value :?> string -> unit)
                if kvp.Key = Xaml.SearchBarCanExecuteKey then 
                    currSearchBarCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.TextKey then 
                    currTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.TextColorKey then 
                    currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.CancelButtonColorKey then 
                        prevCancelButtonColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.FontFamilyKey then 
                        prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.FontAttributesKey then 
                        prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                    if kvp.Key = Xaml.FontSizeKey then 
                        prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.HorizontalTextAlignmentKey then 
                        prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                    if kvp.Key = Xaml.PlaceholderKey then 
                        prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.PlaceholderColorKey then 
                        prevPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.SearchBarCommandKey then 
                        prevSearchBarCommandOpt <- ValueSome (kvp.Value :?> string -> unit)
                    if kvp.Key = Xaml.SearchBarCanExecuteKey then 
                        prevSearchBarCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.TextKey then 
                        prevTextOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.TextColorKey then 
                        prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            match prevCancelButtonColorOpt, currCancelButtonColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.CancelButtonColor <-  currValue
            | ValueSome _, ValueNone -> target.CancelButtonColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevFontFamilyOpt, currFontFamilyOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontFamily <-  currValue
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            match prevFontAttributesOpt, currFontAttributesOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontAttributes <-  currValue
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            match prevFontSizeOpt, currFontSizeOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontSize <-  currValue
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            match prevHorizontalTextAlignmentOpt, currHorizontalTextAlignmentOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HorizontalTextAlignment <-  currValue
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            match prevPlaceholderOpt, currPlaceholderOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Placeholder <-  currValue
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            match prevPlaceholderColorOpt, currPlaceholderColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.PlaceholderColor <-  currValue
            | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            (fun _ _ _ -> ()) prevSearchBarCommandOpt currSearchBarCommandOpt target
            updateCommand prevSearchBarCommandOpt currSearchBarCommandOpt (fun (target: Xamarin.Forms.SearchBar) -> target.Text) (fun (target: Xamarin.Forms.SearchBar) cmd -> target.SearchCommand <- cmd) prevSearchBarCanExecuteOpt currSearchBarCanExecuteOpt target
            match prevTextOpt, currTextOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Text <-  currValue
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            match prevTextColorOpt, currTextColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TextColor <-  currValue
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.SearchBar>, create, update, attribs)

    /// Describes a Button in the view
    static member Button(?text: string, ?command: unit -> unit, ?canExecute: bool, ?borderColor: Xamarin.Forms.Color, ?borderWidth: double, ?commandParameter: System.Object, ?contentLayout: Xamarin.Forms.Button.ButtonContentLayout, ?cornerRadius: int, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?fontSize: obj, ?image: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.TextKey then 
                    currTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.ButtonCommandKey then 
                    currButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = Xaml.ButtonCanExecuteKey then 
                    currButtonCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.BorderColorKey then 
                    currBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.BorderWidthKey then 
                    currBorderWidthOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.CommandParameterKey then 
                    currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml.ContentLayoutKey then 
                    currContentLayoutOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Button.ButtonContentLayout)
                if kvp.Key = Xaml.ButtonCornerRadiusKey then 
                    currButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml.FontFamilyKey then 
                    currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.FontAttributesKey then 
                    currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml.FontSizeKey then 
                    currFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.ButtonImageSourceKey then 
                    currButtonImageSourceOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.TextColorKey then 
                    currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.TextKey then 
                        prevTextOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.ButtonCommandKey then 
                        prevButtonCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                    if kvp.Key = Xaml.ButtonCanExecuteKey then 
                        prevButtonCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.BorderColorKey then 
                        prevBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.BorderWidthKey then 
                        prevBorderWidthOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.CommandParameterKey then 
                        prevCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
                    if kvp.Key = Xaml.ContentLayoutKey then 
                        prevContentLayoutOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Button.ButtonContentLayout)
                    if kvp.Key = Xaml.ButtonCornerRadiusKey then 
                        prevButtonCornerRadiusOpt <- ValueSome (kvp.Value :?> int)
                    if kvp.Key = Xaml.FontFamilyKey then 
                        prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.FontAttributesKey then 
                        prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                    if kvp.Key = Xaml.FontSizeKey then 
                        prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.ButtonImageSourceKey then 
                        prevButtonImageSourceOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.TextColorKey then 
                        prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            match prevTextOpt, currTextOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Text <-  currValue
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            (fun _ _ _ -> ()) prevButtonCommandOpt currButtonCommandOpt target
            updateCommand prevButtonCommandOpt currButtonCommandOpt (fun _target -> ()) (fun (target: Xamarin.Forms.Button) cmd -> target.Command <- cmd) prevButtonCanExecuteOpt currButtonCanExecuteOpt target
            match prevBorderColorOpt, currBorderColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.BorderColor <-  currValue
            | ValueSome _, ValueNone -> target.BorderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevBorderWidthOpt, currBorderWidthOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.BorderWidth <-  currValue
            | ValueSome _, ValueNone -> target.BorderWidth <- -1.0
            | ValueNone, ValueNone -> ()
            match prevCommandParameterOpt, currCommandParameterOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.CommandParameter <-  currValue
            | ValueSome _, ValueNone -> target.CommandParameter <- null
            | ValueNone, ValueNone -> ()
            match prevContentLayoutOpt, currContentLayoutOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.ContentLayout <-  currValue
            | ValueSome _, ValueNone -> target.ContentLayout <- null
            | ValueNone, ValueNone -> ()
            match prevButtonCornerRadiusOpt, currButtonCornerRadiusOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.CornerRadius <-  currValue
            | ValueSome _, ValueNone -> target.CornerRadius <- 0
            | ValueNone, ValueNone -> ()
            match prevFontFamilyOpt, currFontFamilyOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontFamily <-  currValue
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            match prevFontAttributesOpt, currFontAttributesOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontAttributes <-  currValue
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            match prevFontSizeOpt, currFontSizeOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontSize <-  currValue
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            match prevButtonImageSourceOpt, currButtonImageSourceOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Image <- makeFileImageSource  currValue
            | ValueSome _, ValueNone -> target.Image <- null
            | ValueNone, ValueNone -> ()
            match prevTextColorOpt, currTextColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TextColor <-  currValue
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Button>, create, update, attribs)

    /// Describes a Slider in the view
    static member Slider(?minimum: double, ?maximum: double, ?value: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match minimum with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MinimumKey, box ((v)))) 
            match maximum with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.MaximumKey, box ((v)))) 
            match value with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ValueKey, box ((v)))) 
            match valueChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ValueChangedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Slider())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.MinimumKey then 
                    currMinimumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.MaximumKey then 
                    currMaximumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.ValueKey then 
                    currValueOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.ValueChangedKey then 
                    currValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.MinimumKey then 
                        prevMinimumOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.MaximumKey then 
                        prevMaximumOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.ValueKey then 
                        prevValueOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.ValueChangedKey then 
                        prevValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
            match prevMinimumOpt, currMinimumOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Minimum <-  currValue
            | ValueSome _, ValueNone -> target.Minimum <- 0.0
            | ValueNone, ValueNone -> ()
            match prevMaximumOpt, currMaximumOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Maximum <-  currValue
            | ValueSome _, ValueNone -> target.Maximum <- 1.0
            | ValueNone, ValueNone -> ()
            match prevValueOpt, currValueOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Value <-  currValue
            | ValueSome _, ValueNone -> target.Value <- 0.0
            | ValueNone, ValueNone -> ()
            match prevValueChangedOpt, currValueChangedOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.ValueChanged.RemoveHandler(prevValue); target.ValueChanged.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.ValueChanged.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.ValueChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Slider>, create, update, attribs)

    /// Describes a Stepper in the view
    static member Stepper(?minimum: double, ?maximum: double, ?value: double, ?increment: double, ?valueChanged: Xamarin.Forms.ValueChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.MinimumKey then 
                    currMinimumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.MaximumKey then 
                    currMaximumOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.ValueKey then 
                    currValueOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.IncrementKey then 
                    currIncrementOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.ValueChangedKey then 
                    currValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.MinimumKey then 
                        prevMinimumOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.MaximumKey then 
                        prevMaximumOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.ValueKey then 
                        prevValueOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.IncrementKey then 
                        prevIncrementOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.ValueChangedKey then 
                        prevValueChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ValueChangedEventArgs>)
            match prevMinimumOpt, currMinimumOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Minimum <-  currValue
            | ValueSome _, ValueNone -> target.Minimum <- 0.0
            | ValueNone, ValueNone -> ()
            match prevMaximumOpt, currMaximumOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Maximum <-  currValue
            | ValueSome _, ValueNone -> target.Maximum <- 1.0
            | ValueNone, ValueNone -> ()
            match prevValueOpt, currValueOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Value <-  currValue
            | ValueSome _, ValueNone -> target.Value <- 0.0
            | ValueNone, ValueNone -> ()
            match prevIncrementOpt, currIncrementOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Increment <-  currValue
            | ValueSome _, ValueNone -> target.Increment <- 1.0
            | ValueNone, ValueNone -> ()
            match prevValueChangedOpt, currValueChangedOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.ValueChanged.RemoveHandler(prevValue); target.ValueChanged.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.ValueChanged.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.ValueChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Stepper>, create, update, attribs)

    /// Describes a Switch in the view
    static member Switch(?isToggled: bool, ?toggled: Xamarin.Forms.ToggledEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match isToggled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsToggledKey, box ((v)))) 
            match toggled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ToggledKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Switch())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.Switch)
            let mutable prevIsToggledOpt = ValueNone
            let mutable currIsToggledOpt = ValueNone
            let mutable prevToggledOpt = ValueNone
            let mutable currToggledOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.IsToggledKey then 
                    currIsToggledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.ToggledKey then 
                    currToggledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.IsToggledKey then 
                        prevIsToggledOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.ToggledKey then 
                        prevToggledOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
            match prevIsToggledOpt, currIsToggledOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsToggled <-  currValue
            | ValueSome _, ValueNone -> target.IsToggled <- false
            | ValueNone, ValueNone -> ()
            match prevToggledOpt, currToggledOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.Toggled.RemoveHandler(prevValue); target.Toggled.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.Toggled.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.Toggled.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Switch>, create, update, attribs)

    /// Describes a SwitchCell in the view
    static member SwitchCell(?on: bool, ?text: string, ?onChanged: Xamarin.Forms.ToggledEventArgs -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match on with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.OnKey, box ((v)))) 
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match onChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.OnChangedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.ToggledEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.SwitchCell())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.SwitchCell)
            let mutable prevOnOpt = ValueNone
            let mutable currOnOpt = ValueNone
            let mutable prevTextOpt = ValueNone
            let mutable currTextOpt = ValueNone
            let mutable prevOnChangedOpt = ValueNone
            let mutable currOnChangedOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.OnKey then 
                    currOnOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.TextKey then 
                    currTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.OnChangedKey then 
                    currOnChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.OnKey then 
                        prevOnOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.TextKey then 
                        prevTextOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.OnChangedKey then 
                        prevOnChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ToggledEventArgs>)
            match prevOnOpt, currOnOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.On <-  currValue
            | ValueSome _, ValueNone -> target.On <- false
            | ValueNone, ValueNone -> ()
            match prevTextOpt, currTextOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Text <-  currValue
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            match prevOnChangedOpt, currOnChangedOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.OnChanged.RemoveHandler(prevValue); target.OnChanged.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.OnChanged.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.OnChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.SwitchCell>, create, update, attribs)

    /// Describes a TableView in the view
    static member TableView(?intent: Xamarin.Forms.TableIntent, ?hasUnevenRows: bool, ?rowHeight: int, ?items: (string * ViewElement list) list, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match intent with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IntentKey, box ((v)))) 
            match hasUnevenRows with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HasUnevenRowsKey, box ((v)))) 
            match rowHeight with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RowHeightKey, box ((v)))) 
            match items with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TableRootKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.TableView())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.IntentKey then 
                    currIntentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TableIntent)
                if kvp.Key = Xaml.HasUnevenRowsKey then 
                    currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.RowHeightKey then 
                    currRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml.TableRootKey then 
                    currTableRootOpt <- ValueSome (kvp.Value :?> (string * ViewElement[])[])
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.IntentKey then 
                        prevIntentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TableIntent)
                    if kvp.Key = Xaml.HasUnevenRowsKey then 
                        prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.RowHeightKey then 
                        prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                    if kvp.Key = Xaml.TableRootKey then 
                        prevTableRootOpt <- ValueSome (kvp.Value :?> (string * ViewElement[])[])
            match prevIntentOpt, currIntentOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Intent <-  currValue
            | ValueSome _, ValueNone -> target.Intent <- Unchecked.defaultof<Xamarin.Forms.TableIntent>
            | ValueNone, ValueNone -> ()
            match prevHasUnevenRowsOpt, currHasUnevenRowsOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HasUnevenRows <-  currValue
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            match prevRowHeightOpt, currRowHeightOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.RowHeight <-  currValue
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            updateTableViewItems prevTableRootOpt currTableRootOpt target

        new ViewElement(typeof<Xamarin.Forms.TableView>, create, update, attribs)

    /// Describes a Grid in the view
    static member Grid(?rowdefs: obj list, ?coldefs: obj list, ?rowSpacing: double, ?columnSpacing: double, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.GridRowDefinitionsKey then 
                    currGridRowDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml.GridColumnDefinitionsKey then 
                    currGridColumnDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml.RowSpacingKey then 
                    currRowSpacingOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.ColumnSpacingKey then 
                    currColumnSpacingOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.ChildrenKey then 
                    currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.GridRowDefinitionsKey then 
                        prevGridRowDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                    if kvp.Key = Xaml.GridColumnDefinitionsKey then 
                        prevGridColumnDefinitionsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                    if kvp.Key = Xaml.RowSpacingKey then 
                        prevRowSpacingOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.ColumnSpacingKey then 
                        prevColumnSpacingOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.ChildrenKey then 
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
            | prevOpt, ValueSome currValue -> target.RowSpacing <-  currValue
            | ValueSome _, ValueNone -> target.RowSpacing <- 0.0
            | ValueNone, ValueNone -> ()
            match prevColumnSpacingOpt, currColumnSpacingOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.ColumnSpacing <-  currValue
            | ValueSome _, ValueNone -> target.ColumnSpacing <- 0.0
            | ValueNone, ValueNone -> ()
            updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
                (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml.GridRowKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml.GridRowKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.Grid.SetRow(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRow(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml.GridRowSpanKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml.GridRowSpanKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.Grid.SetRowSpan(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetRowSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml.GridColumnKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml.GridColumnKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.Grid.SetColumn(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumn(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml.GridColumnSpanKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml.GridColumnSpanKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.Grid.SetColumnSpan(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild

        new ViewElement(typeof<Xamarin.Forms.Grid>, create, update, attribs)

    /// Describes a AbsoluteLayout in the view
    static member AbsoluteLayout(?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.AbsoluteLayout())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.AbsoluteLayout)
            let mutable prevChildrenOpt = ValueNone
            let mutable currChildrenOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ChildrenKey then 
                    currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ChildrenKey then 
                        prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
                (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Rectangle>(Xaml.LayoutBoundsKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Rectangle>(Xaml.LayoutBoundsKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutBounds(targetChild, Xamarin.Forms.Rectangle.Zero) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.AbsoluteLayoutFlags>(Xaml.LayoutFlagsKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.AbsoluteLayoutFlags>(Xaml.LayoutFlagsKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.AbsoluteLayout.SetLayoutFlags(targetChild, Xamarin.Forms.AbsoluteLayoutFlags.None) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild

        new ViewElement(typeof<Xamarin.Forms.AbsoluteLayout>, create, update, attribs)

    /// Describes a RelativeLayout in the view
    static member RelativeLayout(?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.RelativeLayout())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.RelativeLayout)
            let mutable prevChildrenOpt = ValueNone
            let mutable currChildrenOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ChildrenKey then 
                    currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ChildrenKey then 
                        prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
                (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.BoundsConstraint>(Xaml.BoundsConstraintKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.BoundsConstraint>(Xaml.BoundsConstraintKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetBoundsConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.HeightConstraintKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.HeightConstraintKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetHeightConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.WidthConstraintKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.WidthConstraintKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetWidthConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.XConstraintKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.XConstraintKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetXConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.YConstraintKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.Constraint>(Xaml.YConstraintKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.RelativeLayout.SetYConstraint(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild

        new ViewElement(typeof<Xamarin.Forms.RelativeLayout>, create, update, attribs)

    /// Describes a FlexLayout in the view
    static member FlexLayout(?alignContent: Xamarin.Forms.FlexAlignContent, ?alignItems: Xamarin.Forms.FlexAlignItems, ?direction: Xamarin.Forms.FlexDirection, ?position: Xamarin.Forms.FlexPosition, ?wrap: Xamarin.Forms.FlexWrap, ?justifyContent: Xamarin.Forms.FlexJustify, ?children: ViewElement list, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.AlignContentKey then 
                    currAlignContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignContent)
                if kvp.Key = Xaml.AlignItemsKey then 
                    currAlignItemsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignItems)
                if kvp.Key = Xaml.DirectionKey then 
                    currDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexDirection)
                if kvp.Key = Xaml.PositionKey then 
                    currPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexPosition)
                if kvp.Key = Xaml.WrapKey then 
                    currWrapOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexWrap)
                if kvp.Key = Xaml.JustifyContentKey then 
                    currJustifyContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexJustify)
                if kvp.Key = Xaml.ChildrenKey then 
                    currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.AlignContentKey then 
                        prevAlignContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignContent)
                    if kvp.Key = Xaml.AlignItemsKey then 
                        prevAlignItemsOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexAlignItems)
                    if kvp.Key = Xaml.DirectionKey then 
                        prevDirectionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexDirection)
                    if kvp.Key = Xaml.PositionKey then 
                        prevPositionOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexPosition)
                    if kvp.Key = Xaml.WrapKey then 
                        prevWrapOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexWrap)
                    if kvp.Key = Xaml.JustifyContentKey then 
                        prevJustifyContentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FlexJustify)
                    if kvp.Key = Xaml.ChildrenKey then 
                        prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
            match prevAlignContentOpt, currAlignContentOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.AlignContent <-  currValue
            | ValueSome _, ValueNone -> target.AlignContent <- Unchecked.defaultof<Xamarin.Forms.FlexAlignContent>
            | ValueNone, ValueNone -> ()
            match prevAlignItemsOpt, currAlignItemsOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.AlignItems <-  currValue
            | ValueSome _, ValueNone -> target.AlignItems <- Unchecked.defaultof<Xamarin.Forms.FlexAlignItems>
            | ValueNone, ValueNone -> ()
            match prevDirectionOpt, currDirectionOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Direction <-  currValue
            | ValueSome _, ValueNone -> target.Direction <- Unchecked.defaultof<Xamarin.Forms.FlexDirection>
            | ValueNone, ValueNone -> ()
            match prevPositionOpt, currPositionOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Position <-  currValue
            | ValueSome _, ValueNone -> target.Position <- Unchecked.defaultof<Xamarin.Forms.FlexPosition>
            | ValueNone, ValueNone -> ()
            match prevWrapOpt, currWrapOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Wrap <-  currValue
            | ValueSome _, ValueNone -> target.Wrap <- Unchecked.defaultof<Xamarin.Forms.FlexWrap>
            | ValueNone, ValueNone -> ()
            match prevJustifyContentOpt, currJustifyContentOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.JustifyContent <-  currValue
            | ValueSome _, ValueNone -> target.JustifyContent <- Unchecked.defaultof<Xamarin.Forms.FlexJustify>
            | ValueNone, ValueNone -> ()
            updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
                (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignSelf>(Xaml.FlexAlignSelfKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.FlexAlignSelf>(Xaml.FlexAlignSelfKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetAlignSelf(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetAlignSelf(targetChild, Unchecked.defaultof<Xamarin.Forms.FlexAlignSelf>) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<int>(Xaml.FlexOrderKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<int>(Xaml.FlexOrderKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetOrder(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetOrder(targetChild, 0) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<Xamarin.Forms.FlexBasis>(Xaml.FlexBasisKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<Xamarin.Forms.FlexBasis>(Xaml.FlexBasisKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetBasis(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetBasis(targetChild, Unchecked.defaultof<Xamarin.Forms.FlexBasis>) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<single>(Xaml.FlexGrowKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<single>(Xaml.FlexGrowKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetGrow(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetGrow(targetChild, 0.0f) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<single>(Xaml.FlexShrinkKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<single>(Xaml.FlexShrinkKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currChildValue when prevChildValue = currChildValue -> ()
                    | prevOpt, ValueSome currChildValue -> Xamarin.Forms.FlexLayout.SetShrink(targetChild, currChildValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.FlexLayout.SetShrink(targetChild, 1.0f) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
                canReuseChild
                updateChild

        new ViewElement(typeof<Xamarin.Forms.FlexLayout>, create, update, attribs)

    /// Describes a RowDefinition in the view
    static member RowDefinition(?height: obj) = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            match height with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.RowDefinitionHeightKey, box (makeGridLength(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.RowDefinition())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.RowDefinition)
            let mutable prevRowDefinitionHeightOpt = ValueNone
            let mutable currRowDefinitionHeightOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.RowDefinitionHeightKey then 
                    currRowDefinitionHeightOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.RowDefinitionHeightKey then 
                        prevRowDefinitionHeightOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
            match prevRowDefinitionHeightOpt, currRowDefinitionHeightOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Height <-  currValue
            | ValueSome _, ValueNone -> target.Height <- Xamarin.Forms.GridLength.Auto
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.RowDefinition>, create, update, attribs)

    /// Describes a ColumnDefinition in the view
    static member ColumnDefinition(?width: obj) = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            match width with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ColumnDefinitionWidthKey, box (makeGridLength(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ColumnDefinition())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.ColumnDefinition)
            let mutable prevColumnDefinitionWidthOpt = ValueNone
            let mutable currColumnDefinitionWidthOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ColumnDefinitionWidthKey then 
                    currColumnDefinitionWidthOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ColumnDefinitionWidthKey then 
                        prevColumnDefinitionWidthOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.GridLength)
            match prevColumnDefinitionWidthOpt, currColumnDefinitionWidthOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Width <-  currValue
            | ValueSome _, ValueNone -> target.Width <- Xamarin.Forms.GridLength.Auto
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.ColumnDefinition>, create, update, attribs)

    /// Describes a ContentView in the view
    static member ContentView(?content: ViewElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.TemplatedView(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match content with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ContentKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ContentView())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.ContentView)
            let mutable prevContentOpt = ValueNone
            let mutable currContentOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ContentKey then 
                    currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ContentKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ContentView>, create, update, attribs)

    /// Describes a TemplatedView in the view
    static member TemplatedView(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
          |]

        let create () =
            box (new Xamarin.Forms.TemplatedView())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            ()

        new ViewElement(typeof<Xamarin.Forms.TemplatedView>, create, update, attribs)

    /// Describes a DatePicker in the view
    static member DatePicker(?date: System.DateTime, ?format: string, ?minimumDate: System.DateTime, ?maximumDate: System.DateTime, ?dateSelected: Xamarin.Forms.DateChangedEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.DateKey then 
                    currDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = Xaml.FormatKey then 
                    currFormatOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.MinimumDateKey then 
                    currMinimumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = Xaml.MaximumDateKey then 
                    currMaximumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                if kvp.Key = Xaml.DateSelectedKey then 
                    currDateSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.DateKey then 
                        prevDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                    if kvp.Key = Xaml.FormatKey then 
                        prevFormatOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.MinimumDateKey then 
                        prevMinimumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                    if kvp.Key = Xaml.MaximumDateKey then 
                        prevMaximumDateOpt <- ValueSome (kvp.Value :?> System.DateTime)
                    if kvp.Key = Xaml.DateSelectedKey then 
                        prevDateSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.DateChangedEventArgs>)
            match prevDateOpt, currDateOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Date <-  currValue
            | ValueSome _, ValueNone -> target.Date <- Unchecked.defaultof<System.DateTime>
            | ValueNone, ValueNone -> ()
            match prevFormatOpt, currFormatOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Format <-  currValue
            | ValueSome _, ValueNone -> target.Format <- "d"
            | ValueNone, ValueNone -> ()
            match prevMinimumDateOpt, currMinimumDateOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.MinimumDate <-  currValue
            | ValueSome _, ValueNone -> target.MinimumDate <- new System.DateTime(1900, 1, 1)
            | ValueNone, ValueNone -> ()
            match prevMaximumDateOpt, currMaximumDateOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.MaximumDate <-  currValue
            | ValueSome _, ValueNone -> target.MaximumDate <- new System.DateTime(2100, 12, 31)
            | ValueNone, ValueNone -> ()
            match prevDateSelectedOpt, currDateSelectedOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.DateSelected.RemoveHandler(prevValue); target.DateSelected.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.DateSelected.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.DateSelected.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.DatePicker>, create, update, attribs)

    /// Describes a Picker in the view
    static member Picker(?itemsSource: seq<'T>, ?selectedIndex: int, ?title: string, ?textColor: Xamarin.Forms.Color, ?selectedIndexChanged: (int * 'T option) -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match itemsSource with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PickerItemsSourceKey, box (seqToIListUntyped(v)))) 
            match selectedIndex with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SelectedIndexKey, box ((v)))) 
            match title with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TitleKey, box ((v)))) 
            match textColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextColorKey, box ((v)))) 
            match selectedIndexChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SelectedIndexChangedKey, box ((fun f -> System.EventHandler(fun sender args -> let picker = (sender :?> Xamarin.Forms.Picker) in f (picker.SelectedIndex, (picker.SelectedItem |> Option.ofObj |> Option.map unbox<'T>))))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Picker())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.PickerItemsSourceKey then 
                    currPickerItemsSourceOpt <- ValueSome (kvp.Value :?> System.Collections.IList)
                if kvp.Key = Xaml.SelectedIndexKey then 
                    currSelectedIndexOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml.TitleKey then 
                    currTitleOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.TextColorKey then 
                    currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.SelectedIndexChangedKey then 
                    currSelectedIndexChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.PickerItemsSourceKey then 
                        prevPickerItemsSourceOpt <- ValueSome (kvp.Value :?> System.Collections.IList)
                    if kvp.Key = Xaml.SelectedIndexKey then 
                        prevSelectedIndexOpt <- ValueSome (kvp.Value :?> int)
                    if kvp.Key = Xaml.TitleKey then 
                        prevTitleOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.TextColorKey then 
                        prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.SelectedIndexChangedKey then 
                        prevSelectedIndexChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            match prevPickerItemsSourceOpt, currPickerItemsSourceOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.ItemsSource <-  currValue
            | ValueSome _, ValueNone -> target.ItemsSource <- null
            | ValueNone, ValueNone -> ()
            match prevSelectedIndexOpt, currSelectedIndexOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.SelectedIndex <-  currValue
            | ValueSome _, ValueNone -> target.SelectedIndex <- 0
            | ValueNone, ValueNone -> ()
            match prevTitleOpt, currTitleOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Title <-  currValue
            | ValueSome _, ValueNone -> target.Title <- null
            | ValueNone, ValueNone -> ()
            match prevTextColorOpt, currTextColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TextColor <-  currValue
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevSelectedIndexChangedOpt, currSelectedIndexChangedOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.SelectedIndexChanged.RemoveHandler(prevValue); target.SelectedIndexChanged.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.SelectedIndexChanged.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.SelectedIndexChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Picker>, create, update, attribs)

    /// Describes a Frame in the view
    static member Frame(?borderColor: Xamarin.Forms.Color, ?cornerRadius: double, ?hasShadow: bool, ?content: ViewElement, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.ContentView(?content=content, ?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match borderColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BorderColorKey, box ((v)))) 
            match cornerRadius with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FrameCornerRadiusKey, box (single(v)))) 
            match hasShadow with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HasShadowKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Frame())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.Frame)
            let mutable prevBorderColorOpt = ValueNone
            let mutable currBorderColorOpt = ValueNone
            let mutable prevFrameCornerRadiusOpt = ValueNone
            let mutable currFrameCornerRadiusOpt = ValueNone
            let mutable prevHasShadowOpt = ValueNone
            let mutable currHasShadowOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.BorderColorKey then 
                    currBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.FrameCornerRadiusKey then 
                    currFrameCornerRadiusOpt <- ValueSome (kvp.Value :?> single)
                if kvp.Key = Xaml.HasShadowKey then 
                    currHasShadowOpt <- ValueSome (kvp.Value :?> bool)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.BorderColorKey then 
                        prevBorderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.FrameCornerRadiusKey then 
                        prevFrameCornerRadiusOpt <- ValueSome (kvp.Value :?> single)
                    if kvp.Key = Xaml.HasShadowKey then 
                        prevHasShadowOpt <- ValueSome (kvp.Value :?> bool)
            match prevBorderColorOpt, currBorderColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.BorderColor <-  currValue
            | ValueSome _, ValueNone -> target.BorderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevFrameCornerRadiusOpt, currFrameCornerRadiusOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.CornerRadius <-  currValue
            | ValueSome _, ValueNone -> target.CornerRadius <- -1.0f
            | ValueNone, ValueNone -> ()
            match prevHasShadowOpt, currHasShadowOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HasShadow <-  currValue
            | ValueSome _, ValueNone -> target.HasShadow <- true
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Frame>, create, update, attribs)

    /// Describes a Image in the view
    static member Image(?source: string, ?aspect: Xamarin.Forms.Aspect, ?isOpaque: bool, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match source with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ImageSourceKey, box ((v)))) 
            match aspect with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.AspectKey, box ((v)))) 
            match isOpaque with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsOpaqueKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.Image())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.Image)
            let mutable prevImageSourceOpt = ValueNone
            let mutable currImageSourceOpt = ValueNone
            let mutable prevAspectOpt = ValueNone
            let mutable currAspectOpt = ValueNone
            let mutable prevIsOpaqueOpt = ValueNone
            let mutable currIsOpaqueOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ImageSourceKey then 
                    currImageSourceOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.AspectKey then 
                    currAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
                if kvp.Key = Xaml.IsOpaqueKey then 
                    currIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ImageSourceKey then 
                        prevImageSourceOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.AspectKey then 
                        prevAspectOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Aspect)
                    if kvp.Key = Xaml.IsOpaqueKey then 
                        prevIsOpaqueOpt <- ValueSome (kvp.Value :?> bool)
            match prevImageSourceOpt, currImageSourceOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Source <- makeImageSource  currValue
            | ValueSome _, ValueNone -> target.Source <- null
            | ValueNone, ValueNone -> ()
            match prevAspectOpt, currAspectOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Aspect <-  currValue
            | ValueSome _, ValueNone -> target.Aspect <- Xamarin.Forms.Aspect.AspectFit
            | ValueNone, ValueNone -> ()
            match prevIsOpaqueOpt, currIsOpaqueOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsOpaque <-  currValue
            | ValueSome _, ValueNone -> target.IsOpaque <- true
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Image>, create, update, attribs)

    /// Describes a InputView in the view
    static member InputView(?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match keyboard with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.KeyboardKey, box ((v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.InputView"

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.InputView)
            let mutable prevKeyboardOpt = ValueNone
            let mutable currKeyboardOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.KeyboardKey then 
                    currKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.KeyboardKey then 
                        prevKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
            match prevKeyboardOpt, currKeyboardOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Keyboard <-  currValue
            | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.InputView>, create, update, attribs)

    /// Describes a Editor in the view
    static member Editor(?text: string, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.InputView(?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.TextKey then 
                    currTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.FontSizeKey then 
                    currFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.FontFamilyKey then 
                    currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.FontAttributesKey then 
                    currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml.TextColorKey then 
                    currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.EditorCompletedKey then 
                    currEditorCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml.TextChangedKey then 
                    currTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.TextKey then 
                        prevTextOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.FontSizeKey then 
                        prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.FontFamilyKey then 
                        prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.FontAttributesKey then 
                        prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                    if kvp.Key = Xaml.TextColorKey then 
                        prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.EditorCompletedKey then 
                        prevEditorCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                    if kvp.Key = Xaml.TextChangedKey then 
                        prevTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
            match prevTextOpt, currTextOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Text <-  currValue
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            match prevFontSizeOpt, currFontSizeOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontSize <-  currValue
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            match prevFontFamilyOpt, currFontFamilyOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontFamily <-  currValue
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            match prevFontAttributesOpt, currFontAttributesOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontAttributes <-  currValue
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            match prevTextColorOpt, currTextColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TextColor <-  currValue
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

        new ViewElement(typeof<Xamarin.Forms.Editor>, create, update, attribs)

    /// Describes a Entry in the view
    static member Entry(?text: string, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?placeholderColor: Xamarin.Forms.Color, ?isPassword: bool, ?completed: string -> unit, ?textChanged: Xamarin.Forms.TextChangedEventArgs -> unit, ?keyboard: Xamarin.Forms.Keyboard, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.InputView(?keyboard=keyboard, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.TextKey then 
                    currTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.PlaceholderKey then 
                    currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.HorizontalTextAlignmentKey then 
                    currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml.FontSizeKey then 
                    currFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.FontFamilyKey then 
                    currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.FontAttributesKey then 
                    currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml.TextColorKey then 
                    currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.PlaceholderColorKey then 
                    currPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.IsPasswordKey then 
                    currIsPasswordOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.EntryCompletedKey then 
                    currEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml.TextChangedKey then 
                    currTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.TextKey then 
                        prevTextOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.PlaceholderKey then 
                        prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.HorizontalTextAlignmentKey then 
                        prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                    if kvp.Key = Xaml.FontSizeKey then 
                        prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.FontFamilyKey then 
                        prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.FontAttributesKey then 
                        prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                    if kvp.Key = Xaml.TextColorKey then 
                        prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.PlaceholderColorKey then 
                        prevPlaceholderColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.IsPasswordKey then 
                        prevIsPasswordOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.EntryCompletedKey then 
                        prevEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                    if kvp.Key = Xaml.TextChangedKey then 
                        prevTextChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.TextChangedEventArgs>)
            match prevTextOpt, currTextOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Text <-  currValue
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            match prevPlaceholderOpt, currPlaceholderOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Placeholder <-  currValue
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            match prevHorizontalTextAlignmentOpt, currHorizontalTextAlignmentOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HorizontalTextAlignment <-  currValue
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            match prevFontSizeOpt, currFontSizeOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontSize <-  currValue
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            match prevFontFamilyOpt, currFontFamilyOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontFamily <-  currValue
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            match prevFontAttributesOpt, currFontAttributesOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontAttributes <-  currValue
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            match prevTextColorOpt, currTextColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TextColor <-  currValue
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevPlaceholderColorOpt, currPlaceholderColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.PlaceholderColor <-  currValue
            | ValueSome _, ValueNone -> target.PlaceholderColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevIsPasswordOpt, currIsPasswordOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsPassword <-  currValue
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

        new ViewElement(typeof<Xamarin.Forms.Entry>, create, update, attribs)

    /// Describes a EntryCell in the view
    static member EntryCell(?label: string, ?text: string, ?keyboard: Xamarin.Forms.Keyboard, ?placeholder: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?completed: string -> unit, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.LabelKey then 
                    currLabelOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.TextKey then 
                    currTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.KeyboardKey then 
                    currKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
                if kvp.Key = Xaml.PlaceholderKey then 
                    currPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.HorizontalTextAlignmentKey then 
                    currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml.EntryCompletedKey then 
                    currEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.LabelKey then 
                        prevLabelOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.TextKey then 
                        prevTextOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.KeyboardKey then 
                        prevKeyboardOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Keyboard)
                    if kvp.Key = Xaml.PlaceholderKey then 
                        prevPlaceholderOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.HorizontalTextAlignmentKey then 
                        prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                    if kvp.Key = Xaml.EntryCompletedKey then 
                        prevEntryCompletedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            match prevLabelOpt, currLabelOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Label <-  currValue
            | ValueSome _, ValueNone -> target.Label <- null
            | ValueNone, ValueNone -> ()
            match prevTextOpt, currTextOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Text <-  currValue
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            match prevKeyboardOpt, currKeyboardOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Keyboard <-  currValue
            | ValueSome _, ValueNone -> target.Keyboard <- Xamarin.Forms.Keyboard.Default
            | ValueNone, ValueNone -> ()
            match prevPlaceholderOpt, currPlaceholderOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Placeholder <-  currValue
            | ValueSome _, ValueNone -> target.Placeholder <- null
            | ValueNone, ValueNone -> ()
            match prevHorizontalTextAlignmentOpt, currHorizontalTextAlignmentOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HorizontalTextAlignment <-  currValue
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            match prevEntryCompletedOpt, currEntryCompletedOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.Completed.RemoveHandler(prevValue); target.Completed.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.Completed.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.Completed.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.EntryCell>, create, update, attribs)

    /// Describes a Label in the view
    static member Label(?text: string, ?horizontalTextAlignment: Xamarin.Forms.TextAlignment, ?verticalTextAlignment: Xamarin.Forms.TextAlignment, ?fontSize: obj, ?fontFamily: string, ?fontAttributes: Xamarin.Forms.FontAttributes, ?textColor: Xamarin.Forms.Color, ?formattedText: ViewElement, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.TextKey then 
                    currTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.HorizontalTextAlignmentKey then 
                    currHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml.VerticalTextAlignmentKey then 
                    currVerticalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                if kvp.Key = Xaml.FontSizeKey then 
                    currFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.FontFamilyKey then 
                    currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.FontAttributesKey then 
                    currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml.TextColorKey then 
                    currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.FormattedTextKey then 
                    currFormattedTextOpt <- ValueSome (kvp.Value :?> ViewElement)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.TextKey then 
                        prevTextOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.HorizontalTextAlignmentKey then 
                        prevHorizontalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                    if kvp.Key = Xaml.VerticalTextAlignmentKey then 
                        prevVerticalTextAlignmentOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.TextAlignment)
                    if kvp.Key = Xaml.FontSizeKey then 
                        prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.FontFamilyKey then 
                        prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.FontAttributesKey then 
                        prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                    if kvp.Key = Xaml.TextColorKey then 
                        prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.FormattedTextKey then 
                        prevFormattedTextOpt <- ValueSome (kvp.Value :?> ViewElement)
            match prevTextOpt, currTextOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Text <-  currValue
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            match prevHorizontalTextAlignmentOpt, currHorizontalTextAlignmentOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HorizontalTextAlignment <-  currValue
            | ValueSome _, ValueNone -> target.HorizontalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            match prevVerticalTextAlignmentOpt, currVerticalTextAlignmentOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.VerticalTextAlignment <-  currValue
            | ValueSome _, ValueNone -> target.VerticalTextAlignment <- Xamarin.Forms.TextAlignment.Start
            | ValueNone, ValueNone -> ()
            match prevFontSizeOpt, currFontSizeOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontSize <-  currValue
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            match prevFontFamilyOpt, currFontFamilyOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontFamily <-  currValue
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            match prevFontAttributesOpt, currFontAttributesOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontAttributes <-  currValue
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            match prevTextColorOpt, currTextColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TextColor <-  currValue
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

        new ViewElement(typeof<Xamarin.Forms.Label>, create, update, attribs)

    /// Describes a Layout in the view
    static member Layout(?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match isClippedToBounds with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsClippedToBoundsKey, box ((v)))) 
            match padding with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PaddingKey, box (makeThickness(v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Layout"

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.Layout)
            let mutable prevIsClippedToBoundsOpt = ValueNone
            let mutable currIsClippedToBoundsOpt = ValueNone
            let mutable prevPaddingOpt = ValueNone
            let mutable currPaddingOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.IsClippedToBoundsKey then 
                    currIsClippedToBoundsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.PaddingKey then 
                    currPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.IsClippedToBoundsKey then 
                        prevIsClippedToBoundsOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.PaddingKey then 
                        prevPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
            match prevIsClippedToBoundsOpt, currIsClippedToBoundsOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsClippedToBounds <-  currValue
            | ValueSome _, ValueNone -> target.IsClippedToBounds <- false
            | ValueNone, ValueNone -> ()
            match prevPaddingOpt, currPaddingOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Padding <-  currValue
            | ValueSome _, ValueNone -> target.Padding <- Unchecked.defaultof<Xamarin.Forms.Thickness>
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Layout>, create, update, attribs)

    /// Describes a StackLayout in the view
    static member StackLayout(?children: ViewElement list, ?orientation: Xamarin.Forms.StackOrientation, ?spacing: double, ?isClippedToBounds: bool, ?padding: obj, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Layout(?isClippedToBounds=isClippedToBounds, ?padding=padding, ?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
            match orientation with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.StackOrientationKey, box ((v)))) 
            match spacing with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SpacingKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.StackLayout())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.StackLayout)
            let mutable prevChildrenOpt = ValueNone
            let mutable currChildrenOpt = ValueNone
            let mutable prevStackOrientationOpt = ValueNone
            let mutable currStackOrientationOpt = ValueNone
            let mutable prevSpacingOpt = ValueNone
            let mutable currSpacingOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ChildrenKey then 
                    currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml.StackOrientationKey then 
                    currStackOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StackOrientation)
                if kvp.Key = Xaml.SpacingKey then 
                    currSpacingOpt <- ValueSome (kvp.Value :?> double)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ChildrenKey then 
                        prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                    if kvp.Key = Xaml.StackOrientationKey then 
                        prevStackOrientationOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.StackOrientation)
                    if kvp.Key = Xaml.SpacingKey then 
                        prevSpacingOpt <- ValueSome (kvp.Value :?> double)
            updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
                (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.View)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            match prevStackOrientationOpt, currStackOrientationOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Orientation <-  currValue
            | ValueSome _, ValueNone -> target.Orientation <- Xamarin.Forms.StackOrientation.Vertical
            | ValueNone, ValueNone -> ()
            match prevSpacingOpt, currSpacingOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Spacing <-  currValue
            | ValueSome _, ValueNone -> target.Spacing <- 6.0
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.StackLayout>, create, update, attribs)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.FontFamilyKey then 
                    currFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.FontAttributesKey then 
                    currFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                if kvp.Key = Xaml.FontSizeKey then 
                    currFontSizeOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.BackgroundColorKey then 
                    currBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.ForegroundColorKey then 
                    currForegroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.TextKey then 
                    currTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.PropertyChangedKey then 
                    currPropertyChangedOpt <- ValueSome (kvp.Value :?> System.ComponentModel.PropertyChangedEventHandler)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.FontFamilyKey then 
                        prevFontFamilyOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.FontAttributesKey then 
                        prevFontAttributesOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.FontAttributes)
                    if kvp.Key = Xaml.FontSizeKey then 
                        prevFontSizeOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.BackgroundColorKey then 
                        prevBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.ForegroundColorKey then 
                        prevForegroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.TextKey then 
                        prevTextOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.PropertyChangedKey then 
                        prevPropertyChangedOpt <- ValueSome (kvp.Value :?> System.ComponentModel.PropertyChangedEventHandler)
            match prevFontFamilyOpt, currFontFamilyOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontFamily <-  currValue
            | ValueSome _, ValueNone -> target.FontFamily <- null
            | ValueNone, ValueNone -> ()
            match prevFontAttributesOpt, currFontAttributesOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontAttributes <-  currValue
            | ValueSome _, ValueNone -> target.FontAttributes <- Xamarin.Forms.FontAttributes.None
            | ValueNone, ValueNone -> ()
            match prevFontSizeOpt, currFontSizeOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.FontSize <-  currValue
            | ValueSome _, ValueNone -> target.FontSize <- -1.0
            | ValueNone, ValueNone -> ()
            match prevBackgroundColorOpt, currBackgroundColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.BackgroundColor <-  currValue
            | ValueSome _, ValueNone -> target.BackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevForegroundColorOpt, currForegroundColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.ForegroundColor <-  currValue
            | ValueSome _, ValueNone -> target.ForegroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevTextOpt, currTextOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Text <-  currValue
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            match prevPropertyChangedOpt, currPropertyChangedOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.PropertyChanged.RemoveHandler(prevValue); target.PropertyChanged.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.PropertyChanged.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.PropertyChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Span>, create, update, attribs)

    /// Describes a FormattedString in the view
    static member FormattedString(?spans: ViewElement[]) = 

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            match spans with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.SpansKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.FormattedString())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            let target = (targetObj :?> Xamarin.Forms.FormattedString)
            let mutable prevSpansOpt = ValueNone
            let mutable currSpansOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.SpansKey then 
                    currSpansOpt <- ValueSome (kvp.Value :?> ViewElement[])
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.SpansKey then 
                        prevSpansOpt <- ValueSome (kvp.Value :?> ViewElement[])
            updateCollectionGeneric prevSpansOpt currSpansOpt target.Spans
                (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.Span)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild

        new ViewElement(typeof<Xamarin.Forms.FormattedString>, create, update, attribs)

    /// Describes a TimePicker in the view
    static member TimePicker(?time: System.TimeSpan, ?format: string, ?textColor: Xamarin.Forms.Color, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match time with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TimeKey, box ((v)))) 
            match format with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.FormatKey, box ((v)))) 
            match textColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextColorKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.TimePicker())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.TimePicker)
            let mutable prevTimeOpt = ValueNone
            let mutable currTimeOpt = ValueNone
            let mutable prevFormatOpt = ValueNone
            let mutable currFormatOpt = ValueNone
            let mutable prevTextColorOpt = ValueNone
            let mutable currTextColorOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.TimeKey then 
                    currTimeOpt <- ValueSome (kvp.Value :?> System.TimeSpan)
                if kvp.Key = Xaml.FormatKey then 
                    currFormatOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.TextColorKey then 
                    currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.TimeKey then 
                        prevTimeOpt <- ValueSome (kvp.Value :?> System.TimeSpan)
                    if kvp.Key = Xaml.FormatKey then 
                        prevFormatOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.TextColorKey then 
                        prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            match prevTimeOpt, currTimeOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Time <-  currValue
            | ValueSome _, ValueNone -> target.Time <- new System.TimeSpan()
            | ValueNone, ValueNone -> ()
            match prevFormatOpt, currFormatOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Format <-  currValue
            | ValueSome _, ValueNone -> target.Format <- "t"
            | ValueNone, ValueNone -> ()
            match prevTextColorOpt, currTextColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TextColor <-  currValue
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.TimePicker>, create, update, attribs)

    /// Describes a WebView in the view
    static member WebView(?source: Xamarin.Forms.WebViewSource, ?navigated: Xamarin.Forms.WebNavigatedEventArgs -> unit, ?navigating: Xamarin.Forms.WebNavigatingEventArgs -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match source with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.WebSourceKey, box ((v)))) 
            match navigated with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.NavigatedKey, box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>(fun _sender args -> f args))(v)))) 
            match navigating with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.NavigatingKey, box ((fun f -> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.WebView())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.WebView)
            let mutable prevWebSourceOpt = ValueNone
            let mutable currWebSourceOpt = ValueNone
            let mutable prevNavigatedOpt = ValueNone
            let mutable currNavigatedOpt = ValueNone
            let mutable prevNavigatingOpt = ValueNone
            let mutable currNavigatingOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.WebSourceKey then 
                    currWebSourceOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.WebViewSource)
                if kvp.Key = Xaml.NavigatedKey then 
                    currNavigatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>)
                if kvp.Key = Xaml.NavigatingKey then 
                    currNavigatingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.WebSourceKey then 
                        prevWebSourceOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.WebViewSource)
                    if kvp.Key = Xaml.NavigatedKey then 
                        prevNavigatedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatedEventArgs>)
                    if kvp.Key = Xaml.NavigatingKey then 
                        prevNavigatingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.WebNavigatingEventArgs>)
            match prevWebSourceOpt, currWebSourceOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Source <-  currValue
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

        new ViewElement(typeof<Xamarin.Forms.WebView>, create, update, attribs)

    /// Describes a Page in the view
    static member Page(?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.VisualElement(?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.TitleKey then 
                    currTitleOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.BackgroundImageKey then 
                    currBackgroundImageOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.IconKey then 
                    currIconOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.IsBusyKey then 
                    currIsBusyOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.PaddingKey then 
                    currPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                if kvp.Key = Xaml.ToolbarItemsKey then 
                    currToolbarItemsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml.UseSafeAreaKey then 
                    currUseSafeAreaOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.Page_AppearingKey then 
                    currPage_AppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml.Page_DisappearingKey then 
                    currPage_DisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                if kvp.Key = Xaml.Page_LayoutChangedKey then 
                    currPage_LayoutChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.TitleKey then 
                        prevTitleOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.BackgroundImageKey then 
                        prevBackgroundImageOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.IconKey then 
                        prevIconOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.IsBusyKey then 
                        prevIsBusyOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.PaddingKey then 
                        prevPaddingOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Thickness)
                    if kvp.Key = Xaml.ToolbarItemsKey then 
                        prevToolbarItemsOpt <- ValueSome (kvp.Value :?> ViewElement[])
                    if kvp.Key = Xaml.UseSafeAreaKey then 
                        prevUseSafeAreaOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.Page_AppearingKey then 
                        prevPage_AppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                    if kvp.Key = Xaml.Page_DisappearingKey then 
                        prevPage_DisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
                    if kvp.Key = Xaml.Page_LayoutChangedKey then 
                        prevPage_LayoutChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            match prevTitleOpt, currTitleOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Title <-  currValue
            | ValueSome _, ValueNone -> target.Title <- ""
            | ValueNone, ValueNone -> ()
            match prevBackgroundImageOpt, currBackgroundImageOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.BackgroundImage <-  currValue
            | ValueSome _, ValueNone -> target.BackgroundImage <- null
            | ValueNone, ValueNone -> ()
            match prevIconOpt, currIconOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Icon <- makeFileImageSource  currValue
            | ValueSome _, ValueNone -> target.Icon <- null
            | ValueNone, ValueNone -> ()
            match prevIsBusyOpt, currIsBusyOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsBusy <-  currValue
            | ValueSome _, ValueNone -> target.IsBusy <- false
            | ValueNone, ValueNone -> ()
            match prevPaddingOpt, currPaddingOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Padding <-  currValue
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

        new ViewElement(typeof<Xamarin.Forms.Page>, create, update, attribs)

    /// Describes a CarouselPage in the view
    static member CarouselPage(?children: ViewElement list, ?selectedItem: System.Object, ?currentPage: ViewElement, ?currentPageChanged: 'T option -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Page(?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
            match selectedItem with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CarouselPage_SelectedItemKey, box ((v)))) 
            match currentPage with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CurrentPageKey, box ((v)))) 
            match currentPageChanged with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CurrentPageChangedKey, box ((fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.CarouselPage())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.ChildrenKey then 
                    currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml.CarouselPage_SelectedItemKey then 
                    currCarouselPage_SelectedItemOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml.CurrentPageKey then 
                    currCurrentPageOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml.CurrentPageChangedKey then 
                    currCurrentPageChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ChildrenKey then 
                        prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                    if kvp.Key = Xaml.CarouselPage_SelectedItemKey then 
                        prevCarouselPage_SelectedItemOpt <- ValueSome (kvp.Value :?> System.Object)
                    if kvp.Key = Xaml.CurrentPageKey then 
                        prevCurrentPageOpt <- ValueSome (kvp.Value :?> ViewElement)
                    if kvp.Key = Xaml.CurrentPageChangedKey then 
                        prevCurrentPageChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
                (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.ContentPage)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            match prevCarouselPage_SelectedItemOpt, currCarouselPage_SelectedItemOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.SelectedItem <-  currValue
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

        new ViewElement(typeof<Xamarin.Forms.CarouselPage>, create, update, attribs)

    /// Describes a NavigationPage in the view
    static member NavigationPage(?pages: ViewElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?popped: Xamarin.Forms.NavigationEventArgs -> unit, ?poppedToRoot: Xamarin.Forms.NavigationEventArgs -> unit, ?pushed: Xamarin.Forms.NavigationEventArgs -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Page(?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.PagesKey then 
                    currPagesOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml.BarBackgroundColorKey then 
                    currBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.BarTextColorKey then 
                    currBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.PoppedKey then 
                    currPoppedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
                if kvp.Key = Xaml.PoppedToRootKey then 
                    currPoppedToRootOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
                if kvp.Key = Xaml.PushedKey then 
                    currPushedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.PagesKey then 
                        prevPagesOpt <- ValueSome (kvp.Value :?> ViewElement[])
                    if kvp.Key = Xaml.BarBackgroundColorKey then 
                        prevBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.BarTextColorKey then 
                        prevBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.PoppedKey then 
                        prevPoppedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
                    if kvp.Key = Xaml.PoppedToRootKey then 
                        prevPoppedToRootOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
                    if kvp.Key = Xaml.PushedKey then 
                        prevPushedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.NavigationEventArgs>)
            updateNavigationPages prevPagesOpt currPagesOpt target
                (fun prevChildOpt newChild targetChild -> 
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<string>(Xaml.BackButtonTitleKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<string>(Xaml.BackButtonTitleKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                    | prevOpt, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, currValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetBackButtonTitle(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<bool>(Xaml.HasBackButtonKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<bool>(Xaml.HasBackButtonKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                    | prevOpt, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, currValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasBackButton(targetChild, true) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<bool>(Xaml.HasNavigationBarKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<bool>(Xaml.HasNavigationBarKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                    | prevOpt, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, currValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetHasNavigationBar(targetChild, true) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    // Adjust the attached properties
                    let prevChildValueOpt = match prevChildOpt with ValueNone -> ValueNone | ValueSome prevChild -> prevChild.TryGetAttributeKeyed<string>(Xaml.TitleIconKey)
                    let childValueOpt = newChild.TryGetAttributeKeyed<string>(Xaml.TitleIconKey)
                    match prevChildValueOpt, childValueOpt with
                    | ValueSome prevChildValue, ValueSome currValue when prevChildValue = currValue -> ()
                    | prevOpt, ValueSome currValue -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, makeFileImageSource currValue)
                    | ValueSome _, ValueNone -> Xamarin.Forms.NavigationPage.SetTitleIcon(targetChild, null) // TODO: not always perfect, should set back to original default?
                    | _ -> ()
                    ())
            match prevBarBackgroundColorOpt, currBarBackgroundColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.BarBackgroundColor <-  currValue
            | ValueSome _, ValueNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevBarTextColorOpt, currBarTextColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.BarTextColor <-  currValue
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

        new ViewElement(typeof<Xamarin.Forms.NavigationPage>, create, update, attribs)

    /// Describes a TabbedPage in the view
    static member TabbedPage(?children: ViewElement list, ?barBackgroundColor: Xamarin.Forms.Color, ?barTextColor: Xamarin.Forms.Color, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Page(?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match children with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ChildrenKey, box (Array.ofList(v)))) 
            match barBackgroundColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BarBackgroundColorKey, box ((v)))) 
            match barTextColor with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.BarTextColorKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.TabbedPage())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.TabbedPage)
            let mutable prevChildrenOpt = ValueNone
            let mutable currChildrenOpt = ValueNone
            let mutable prevBarBackgroundColorOpt = ValueNone
            let mutable currBarBackgroundColorOpt = ValueNone
            let mutable prevBarTextColorOpt = ValueNone
            let mutable currBarTextColorOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ChildrenKey then 
                    currChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                if kvp.Key = Xaml.BarBackgroundColorKey then 
                    currBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.BarTextColorKey then 
                    currBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ChildrenKey then 
                        prevChildrenOpt <- ValueSome (kvp.Value :?> ViewElement[])
                    if kvp.Key = Xaml.BarBackgroundColorKey then 
                        prevBarBackgroundColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.BarTextColorKey then 
                        prevBarTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
            updateCollectionGeneric prevChildrenOpt currChildrenOpt target.Children
                (fun (x:ViewElement) -> x.Create() :?> Xamarin.Forms.Page)
                (fun _ _ _ -> ())
                canReuseChild
                updateChild
            match prevBarBackgroundColorOpt, currBarBackgroundColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.BarBackgroundColor <-  currValue
            | ValueSome _, ValueNone -> target.BarBackgroundColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevBarTextColorOpt, currBarTextColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.BarTextColor <-  currValue
            | ValueSome _, ValueNone -> target.BarTextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.TabbedPage>, create, update, attribs)

    /// Describes a ContentPage in the view
    static member ContentPage(?content: ViewElement, ?onSizeAllocated: (double * double) -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Page(?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match content with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ContentKey, box ((v)))) 
            match onSizeAllocated with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.OnSizeAllocatedCallbackKey, box ((fun f -> FSharp.Control.Handler<_>(fun _sender args -> f args))(v)))) 
          |]

        let create () =
            box (new Elmish.XamarinForms.DynamicViews.CustomContentPage())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.ContentPage)
            let mutable prevContentOpt = ValueNone
            let mutable currContentOpt = ValueNone
            let mutable prevOnSizeAllocatedCallbackOpt = ValueNone
            let mutable currOnSizeAllocatedCallbackOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ContentKey then 
                    currContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml.OnSizeAllocatedCallbackKey then 
                    currOnSizeAllocatedCallbackOpt <- ValueSome (kvp.Value :?> FSharp.Control.Handler<(double * double)>)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ContentKey then 
                        prevContentOpt <- ValueSome (kvp.Value :?> ViewElement)
                    if kvp.Key = Xaml.OnSizeAllocatedCallbackKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ContentPage>, create, update, attribs)

    /// Describes a MasterDetailPage in the view
    static member MasterDetailPage(?master: ViewElement, ?detail: ViewElement, ?isGestureEnabled: bool, ?isPresented: bool, ?masterBehavior: Xamarin.Forms.MasterBehavior, ?isPresentedChanged: bool -> unit, ?title: string, ?backgroundImage: string, ?icon: string, ?isBusy: bool, ?padding: obj, ?toolbarItems: ViewElement list, ?useSafeArea: bool, ?appearing: unit -> unit, ?disappearing: unit -> unit, ?layoutChanged: unit -> unit, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Page(?title=title, ?backgroundImage=backgroundImage, ?icon=icon, ?isBusy=isBusy, ?padding=padding, ?toolbarItems=toolbarItems, ?useSafeArea=useSafeArea, ?appearing=appearing, ?disappearing=disappearing, ?layoutChanged=layoutChanged, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.MasterKey then 
                    currMasterOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml.DetailKey then 
                    currDetailOpt <- ValueSome (kvp.Value :?> ViewElement)
                if kvp.Key = Xaml.IsGestureEnabledKey then 
                    currIsGestureEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.IsPresentedKey then 
                    currIsPresentedOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.MasterBehaviorKey then 
                    currMasterBehaviorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.MasterBehavior)
                if kvp.Key = Xaml.IsPresentedChangedKey then 
                    currIsPresentedChangedOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.MasterKey then 
                        prevMasterOpt <- ValueSome (kvp.Value :?> ViewElement)
                    if kvp.Key = Xaml.DetailKey then 
                        prevDetailOpt <- ValueSome (kvp.Value :?> ViewElement)
                    if kvp.Key = Xaml.IsGestureEnabledKey then 
                        prevIsGestureEnabledOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.IsPresentedKey then 
                        prevIsPresentedOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.MasterBehaviorKey then 
                        prevMasterBehaviorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.MasterBehavior)
                    if kvp.Key = Xaml.IsPresentedChangedKey then 
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
            | prevOpt, ValueSome currValue -> target.IsGestureEnabled <-  currValue
            | ValueSome _, ValueNone -> target.IsGestureEnabled <- true
            | ValueNone, ValueNone -> ()
            match prevIsPresentedOpt, currIsPresentedOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsPresented <-  currValue
            | ValueSome _, ValueNone -> target.IsPresented <- true
            | ValueNone, ValueNone -> ()
            match prevMasterBehaviorOpt, currMasterBehaviorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.MasterBehavior <-  currValue
            | ValueSome _, ValueNone -> target.MasterBehavior <- Xamarin.Forms.MasterBehavior.Default
            | ValueNone, ValueNone -> ()
            match prevIsPresentedChangedOpt, currIsPresentedChangedOpt with
            | ValueSome prevValue, ValueSome currValue when identical prevValue currValue -> ()
            | ValueSome prevValue, ValueSome currValue -> target.IsPresentedChanged.RemoveHandler(prevValue); target.IsPresentedChanged.AddHandler(currValue)
            | ValueNone, ValueSome currValue -> target.IsPresentedChanged.AddHandler(currValue)
            | ValueSome prevValue, ValueNone -> target.IsPresentedChanged.RemoveHandler(prevValue)
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.MasterDetailPage>, create, update, attribs)

    /// Describes a Cell in the view
    static member Cell(?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match height with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.HeightKey, box ((v)))) 
            match isEnabled with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IsEnabledKey, box ((v)))) 
          |]

        let create () =
            failwith "can't create Xamarin.Forms.Cell"

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.Cell)
            let mutable prevHeightOpt = ValueNone
            let mutable currHeightOpt = ValueNone
            let mutable prevIsEnabledOpt = ValueNone
            let mutable currIsEnabledOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.HeightKey then 
                    currHeightOpt <- ValueSome (kvp.Value :?> double)
                if kvp.Key = Xaml.IsEnabledKey then 
                    currIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.HeightKey then 
                        prevHeightOpt <- ValueSome (kvp.Value :?> double)
                    if kvp.Key = Xaml.IsEnabledKey then 
                        prevIsEnabledOpt <- ValueSome (kvp.Value :?> bool)
            match prevHeightOpt, currHeightOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Height <-  currValue
            | ValueSome _, ValueNone -> target.Height <- -1.0
            | ValueNone, ValueNone -> ()
            match prevIsEnabledOpt, currIsEnabledOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsEnabled <-  currValue
            | ValueSome _, ValueNone -> target.IsEnabled <- true
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.Cell>, create, update, attribs)

    /// Describes a MenuItem in the view
    static member MenuItem(?text: string, ?command: unit -> unit, ?commandParameter: System.Object, ?icon: string, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Element(?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match text with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.TextKey, box ((v)))) 
            match command with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CommandKey, box (makeCommand(v)))) 
            match commandParameter with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.CommandParameterKey, box ((v)))) 
            match icon with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.IconKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.MenuItem())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.TextKey then 
                    currTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.CommandKey then 
                    currCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml.CommandParameterKey then 
                    currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml.IconKey then 
                    currIconOpt <- ValueSome (kvp.Value :?> string)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.TextKey then 
                        prevTextOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.CommandKey then 
                        prevCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                    if kvp.Key = Xaml.CommandParameterKey then 
                        prevCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
                    if kvp.Key = Xaml.IconKey then 
                        prevIconOpt <- ValueSome (kvp.Value :?> string)
            match prevTextOpt, currTextOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Text <-  currValue
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            match prevCommandOpt, currCommandOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Command <-  currValue
            | ValueSome _, ValueNone -> target.Command <- null
            | ValueNone, ValueNone -> ()
            match prevCommandParameterOpt, currCommandParameterOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.CommandParameter <-  currValue
            | ValueSome _, ValueNone -> target.CommandParameter <- null
            | ValueNone, ValueNone -> ()
            match prevIconOpt, currIconOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Icon <- makeFileImageSource  currValue
            | ValueSome _, ValueNone -> target.Icon <- null
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.MenuItem>, create, update, attribs)

    /// Describes a TextCell in the view
    static member TextCell(?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.TextKey then 
                    currTextOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.TextDetailKey then 
                    currTextDetailOpt <- ValueSome (kvp.Value :?> string)
                if kvp.Key = Xaml.TextColorKey then 
                    currTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.TextDetailColorKey then 
                    currTextDetailColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.TextCellCommandKey then 
                    currTextCellCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                if kvp.Key = Xaml.TextCellCanExecuteKey then 
                    currTextCellCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.CommandParameterKey then 
                    currCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.TextKey then 
                        prevTextOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.TextDetailKey then 
                        prevTextDetailOpt <- ValueSome (kvp.Value :?> string)
                    if kvp.Key = Xaml.TextColorKey then 
                        prevTextColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.TextDetailColorKey then 
                        prevTextDetailColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.TextCellCommandKey then 
                        prevTextCellCommandOpt <- ValueSome (kvp.Value :?> unit -> unit)
                    if kvp.Key = Xaml.TextCellCanExecuteKey then 
                        prevTextCellCanExecuteOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.CommandParameterKey then 
                        prevCommandParameterOpt <- ValueSome (kvp.Value :?> System.Object)
            match prevTextOpt, currTextOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Text <-  currValue
            | ValueSome _, ValueNone -> target.Text <- null
            | ValueNone, ValueNone -> ()
            match prevTextDetailOpt, currTextDetailOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Detail <-  currValue
            | ValueSome _, ValueNone -> target.Detail <- null
            | ValueNone, ValueNone -> ()
            match prevTextColorOpt, currTextColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.TextColor <-  currValue
            | ValueSome _, ValueNone -> target.TextColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            match prevTextDetailColorOpt, currTextDetailColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.DetailColor <-  currValue
            | ValueSome _, ValueNone -> target.DetailColor <- Xamarin.Forms.Color.Default
            | ValueNone, ValueNone -> ()
            (fun _ _ _ -> ()) prevTextCellCommandOpt currTextCellCommandOpt target
            updateCommand prevTextCellCommandOpt currTextCellCommandOpt (fun _target -> ()) (fun (target: Xamarin.Forms.TextCell) cmd -> target.Command <- cmd) prevTextCellCanExecuteOpt currTextCellCanExecuteOpt target
            match prevCommandParameterOpt, currCommandParameterOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.CommandParameter <-  currValue
            | ValueSome _, ValueNone -> target.CommandParameter <- null
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.TextCell>, create, update, attribs)

    /// Describes a ToolbarItem in the view
    static member ToolbarItem(?order: Xamarin.Forms.ToolbarItemOrder, ?priority: int, ?text: string, ?command: unit -> unit, ?commandParameter: System.Object, ?icon: string, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.MenuItem(?text=text, ?command=command, ?commandParameter=commandParameter, ?icon=icon, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match order with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.OrderKey, box ((v)))) 
            match priority with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.PriorityKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ToolbarItem())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.ToolbarItem)
            let mutable prevOrderOpt = ValueNone
            let mutable currOrderOpt = ValueNone
            let mutable prevPriorityOpt = ValueNone
            let mutable currPriorityOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.OrderKey then 
                    currOrderOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ToolbarItemOrder)
                if kvp.Key = Xaml.PriorityKey then 
                    currPriorityOpt <- ValueSome (kvp.Value :?> int)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.OrderKey then 
                        prevOrderOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.ToolbarItemOrder)
                    if kvp.Key = Xaml.PriorityKey then 
                        prevPriorityOpt <- ValueSome (kvp.Value :?> int)
            match prevOrderOpt, currOrderOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Order <-  currValue
            | ValueSome _, ValueNone -> target.Order <- Xamarin.Forms.ToolbarItemOrder.Default
            | ValueNone, ValueNone -> ()
            match prevPriorityOpt, currPriorityOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Priority <-  currValue
            | ValueSome _, ValueNone -> target.Priority <- 0
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.ToolbarItem>, create, update, attribs)

    /// Describes a ImageCell in the view
    static member ImageCell(?imageSource: string, ?text: string, ?detail: string, ?textColor: Xamarin.Forms.Color, ?detailColor: Xamarin.Forms.Color, ?command: unit -> unit, ?canExecute: bool, ?commandParameter: System.Object, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.TextCell(?text=text, ?detail=detail, ?textColor=textColor, ?detailColor=detailColor, ?command=command, ?canExecute=canExecute, ?commandParameter=commandParameter, ?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match imageSource with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ImageSourceKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ImageCell())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.ImageCell)
            let mutable prevImageSourceOpt = ValueNone
            let mutable currImageSourceOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ImageSourceKey then 
                    currImageSourceOpt <- ValueSome (kvp.Value :?> string)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ImageSourceKey then 
                        prevImageSourceOpt <- ValueSome (kvp.Value :?> string)
            match prevImageSourceOpt, currImageSourceOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.ImageSource <- makeImageSource  currValue
            | ValueSome _, ValueNone -> target.ImageSource <- null
            | ValueNone, ValueNone -> ()

        new ViewElement(typeof<Xamarin.Forms.ImageCell>, create, update, attribs)

    /// Describes a ViewCell in the view
    static member ViewCell(?view: ViewElement, ?height: double, ?isEnabled: bool, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.Cell(?height=height, ?isEnabled=isEnabled, ?classId=classId, ?styleId=styleId)

        let attribs : System.Collections.Generic.KeyValuePair<int, obj>[] = [| 
            yield! baseElement.AttributesKeyed
            match view with None -> () | Some v -> yield (System.Collections.Generic.KeyValuePair(Xaml.ViewKey, box ((v)))) 
          |]

        let create () =
            box (new Xamarin.Forms.ViewCell())

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
            baseElement.UpdateMethod prevOpt curr targetObj
            let target = (targetObj :?> Xamarin.Forms.ViewCell)
            let mutable prevViewOpt = ValueNone
            let mutable currViewOpt = ValueNone
            for kvp in curr.AttributesKeyed do
                if kvp.Key = Xaml.ViewKey then 
                    currViewOpt <- ValueSome (kvp.Value :?> ViewElement)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ViewKey then 
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

        new ViewElement(typeof<Xamarin.Forms.ViewCell>, create, update, attribs)

    /// Describes a ListView in the view
    static member ListView(?items: seq<ViewElement>, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?headerTemplate: Xamarin.Forms.DataTemplate, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: int option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: int -> unit, ?itemDisappearing: int -> unit, ?itemSelected: int option -> unit, ?itemTapped: int -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.ListViewItemsKey then 
                    currListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
                if kvp.Key = Xaml.FooterKey then 
                    currFooterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml.HasUnevenRowsKey then 
                    currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.HeaderKey then 
                    currHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml.HeaderTemplateKey then 
                    currHeaderTemplateOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.DataTemplate)
                if kvp.Key = Xaml.IsGroupingEnabledKey then 
                    currIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.IsPullToRefreshEnabledKey then 
                    currIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.IsRefreshingKey then 
                    currIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.RefreshCommandKey then 
                    currRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml.RowHeightKey then 
                    currRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml.ListView_SelectedItemKey then 
                    currListView_SelectedItemOpt <- ValueSome (kvp.Value :?> int option)
                if kvp.Key = Xaml.ListView_SeparatorVisibilityKey then 
                    currListView_SeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
                if kvp.Key = Xaml.ListView_SeparatorColorKey then 
                    currListView_SeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.ListView_ItemAppearingKey then 
                    currListView_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml.ListView_ItemDisappearingKey then 
                    currListView_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml.ListView_ItemSelectedKey then 
                    currListView_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                if kvp.Key = Xaml.ListView_ItemTappedKey then 
                    currListView_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
                if kvp.Key = Xaml.ListView_RefreshingKey then 
                    currListView_RefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ListViewItemsKey then 
                        prevListViewItemsOpt <- ValueSome (kvp.Value :?> seq<ViewElement>)
                    if kvp.Key = Xaml.FooterKey then 
                        prevFooterOpt <- ValueSome (kvp.Value :?> System.Object)
                    if kvp.Key = Xaml.HasUnevenRowsKey then 
                        prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.HeaderKey then 
                        prevHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
                    if kvp.Key = Xaml.HeaderTemplateKey then 
                        prevHeaderTemplateOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.DataTemplate)
                    if kvp.Key = Xaml.IsGroupingEnabledKey then 
                        prevIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.IsPullToRefreshEnabledKey then 
                        prevIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.IsRefreshingKey then 
                        prevIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.RefreshCommandKey then 
                        prevRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                    if kvp.Key = Xaml.RowHeightKey then 
                        prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                    if kvp.Key = Xaml.ListView_SelectedItemKey then 
                        prevListView_SelectedItemOpt <- ValueSome (kvp.Value :?> int option)
                    if kvp.Key = Xaml.ListView_SeparatorVisibilityKey then 
                        prevListView_SeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
                    if kvp.Key = Xaml.ListView_SeparatorColorKey then 
                        prevListView_SeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.ListView_ItemAppearingKey then 
                        prevListView_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                    if kvp.Key = Xaml.ListView_ItemDisappearingKey then 
                        prevListView_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                    if kvp.Key = Xaml.ListView_ItemSelectedKey then 
                        prevListView_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                    if kvp.Key = Xaml.ListView_ItemTappedKey then 
                        prevListView_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
                    if kvp.Key = Xaml.ListView_RefreshingKey then 
                        prevListView_RefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            updateListViewItems prevListViewItemsOpt currListViewItemsOpt target
            match prevFooterOpt, currFooterOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Footer <-  currValue
            | ValueSome _, ValueNone -> target.Footer <- null
            | ValueNone, ValueNone -> ()
            match prevHasUnevenRowsOpt, currHasUnevenRowsOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HasUnevenRows <-  currValue
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            match prevHeaderOpt, currHeaderOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Header <-  currValue
            | ValueSome _, ValueNone -> target.Header <- null
            | ValueNone, ValueNone -> ()
            match prevHeaderTemplateOpt, currHeaderTemplateOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HeaderTemplate <-  currValue
            | ValueSome _, ValueNone -> target.HeaderTemplate <- null
            | ValueNone, ValueNone -> ()
            match prevIsGroupingEnabledOpt, currIsGroupingEnabledOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsGroupingEnabled <-  currValue
            | ValueSome _, ValueNone -> target.IsGroupingEnabled <- false
            | ValueNone, ValueNone -> ()
            match prevIsPullToRefreshEnabledOpt, currIsPullToRefreshEnabledOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsPullToRefreshEnabled <-  currValue
            | ValueSome _, ValueNone -> target.IsPullToRefreshEnabled <- false
            | ValueNone, ValueNone -> ()
            match prevIsRefreshingOpt, currIsRefreshingOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsRefreshing <-  currValue
            | ValueSome _, ValueNone -> target.IsRefreshing <- false
            | ValueNone, ValueNone -> ()
            match prevRefreshCommandOpt, currRefreshCommandOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.RefreshCommand <-  currValue
            | ValueSome _, ValueNone -> target.RefreshCommand <- null
            | ValueNone, ValueNone -> ()
            match prevRowHeightOpt, currRowHeightOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.RowHeight <-  currValue
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            match prevListView_SelectedItemOpt, currListView_SelectedItemOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.SelectedItem <- (function None -> null | Some i -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListElementData<ViewElement>> in if i >= 0 && i < items.Count then items.[i] else null)  currValue
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            match prevListView_SeparatorVisibilityOpt, currListView_SeparatorVisibilityOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.SeparatorVisibility <-  currValue
            | ValueSome _, ValueNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
            | ValueNone, ValueNone -> ()
            match prevListView_SeparatorColorOpt, currListView_SeparatorColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.SeparatorColor <-  currValue
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

        new ViewElement(typeof<Xamarin.Forms.ListView>, create, update, attribs)

    /// Describes a ListViewGrouped in the view
    static member ListViewGrouped(?items: (ViewElement * ViewElement list) list, ?footer: System.Object, ?hasUnevenRows: bool, ?header: System.Object, ?isGroupingEnabled: bool, ?isPullToRefreshEnabled: bool, ?isRefreshing: bool, ?refreshCommand: unit -> unit, ?rowHeight: int, ?selectedItem: (int * int) option, ?separatorVisibility: Xamarin.Forms.SeparatorVisibility, ?separatorColor: Xamarin.Forms.Color, ?itemAppearing: int * int -> unit, ?itemDisappearing: int * int -> unit, ?itemSelected: (int * int) option -> unit, ?itemTapped: int * int -> unit, ?refreshing: unit -> unit, ?horizontalOptions: Xamarin.Forms.LayoutOptions, ?verticalOptions: Xamarin.Forms.LayoutOptions, ?margin: obj, ?gestureRecognizers: ViewElement list, ?anchorX: double, ?anchorY: double, ?backgroundColor: Xamarin.Forms.Color, ?heightRequest: double, ?inputTransparent: bool, ?isEnabled: bool, ?isVisible: bool, ?minimumHeightRequest: double, ?minimumWidthRequest: double, ?opacity: double, ?rotation: double, ?rotationX: double, ?rotationY: double, ?scale: double, ?style: Xamarin.Forms.Style, ?translationX: double, ?translationY: double, ?widthRequest: double, ?resources: (string * obj) list, ?styles: Xamarin.Forms.Style list, ?styleSheets: Xamarin.Forms.StyleSheets.StyleSheet list, ?classId: string, ?styleId: string) = 

        let baseElement : ViewElement = Xaml.View(?horizontalOptions=horizontalOptions, ?verticalOptions=verticalOptions, ?margin=margin, ?gestureRecognizers=gestureRecognizers, ?anchorX=anchorX, ?anchorY=anchorY, ?backgroundColor=backgroundColor, ?heightRequest=heightRequest, ?inputTransparent=inputTransparent, ?isEnabled=isEnabled, ?isVisible=isVisible, ?minimumHeightRequest=minimumHeightRequest, ?minimumWidthRequest=minimumWidthRequest, ?opacity=opacity, ?rotation=rotation, ?rotationX=rotationX, ?rotationY=rotationY, ?scale=scale, ?style=style, ?translationX=translationX, ?translationY=translationY, ?widthRequest=widthRequest, ?resources=resources, ?styles=styles, ?styleSheets=styleSheets, ?classId=classId, ?styleId=styleId)

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

        let update (prevOpt: ViewElement voption) (curr: ViewElement) (targetObj:obj) = 
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
                if kvp.Key = Xaml.ListViewGrouped_ItemsSourceKey then 
                    currListViewGrouped_ItemsSourceOpt <- ValueSome (kvp.Value :?> (ViewElement * ViewElement[])[])
                if kvp.Key = Xaml.FooterKey then 
                    currFooterOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml.HasUnevenRowsKey then 
                    currHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.HeaderKey then 
                    currHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
                if kvp.Key = Xaml.IsGroupingEnabledKey then 
                    currIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.IsPullToRefreshEnabledKey then 
                    currIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.IsRefreshingKey then 
                    currIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
                if kvp.Key = Xaml.RefreshCommandKey then 
                    currRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                if kvp.Key = Xaml.RowHeightKey then 
                    currRowHeightOpt <- ValueSome (kvp.Value :?> int)
                if kvp.Key = Xaml.ListViewGrouped_SelectedItemKey then 
                    currListViewGrouped_SelectedItemOpt <- ValueSome (kvp.Value :?> (int * int) option)
                if kvp.Key = Xaml.SeparatorVisibilityKey then 
                    currSeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
                if kvp.Key = Xaml.SeparatorColorKey then 
                    currSeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                if kvp.Key = Xaml.ListViewGrouped_ItemAppearingKey then 
                    currListViewGrouped_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml.ListViewGrouped_ItemDisappearingKey then 
                    currListViewGrouped_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                if kvp.Key = Xaml.ListViewGrouped_ItemSelectedKey then 
                    currListViewGrouped_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                if kvp.Key = Xaml.ListViewGrouped_ItemTappedKey then 
                    currListViewGrouped_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
                if kvp.Key = Xaml.RefreshingKey then 
                    currRefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            match prevOpt with
            | ValueNone -> ()
            | ValueSome prev ->
                for kvp in prev.AttributesKeyed do
                    if kvp.Key = Xaml.ListViewGrouped_ItemsSourceKey then 
                        prevListViewGrouped_ItemsSourceOpt <- ValueSome (kvp.Value :?> (ViewElement * ViewElement[])[])
                    if kvp.Key = Xaml.FooterKey then 
                        prevFooterOpt <- ValueSome (kvp.Value :?> System.Object)
                    if kvp.Key = Xaml.HasUnevenRowsKey then 
                        prevHasUnevenRowsOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.HeaderKey then 
                        prevHeaderOpt <- ValueSome (kvp.Value :?> System.Object)
                    if kvp.Key = Xaml.IsGroupingEnabledKey then 
                        prevIsGroupingEnabledOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.IsPullToRefreshEnabledKey then 
                        prevIsPullToRefreshEnabledOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.IsRefreshingKey then 
                        prevIsRefreshingOpt <- ValueSome (kvp.Value :?> bool)
                    if kvp.Key = Xaml.RefreshCommandKey then 
                        prevRefreshCommandOpt <- ValueSome (kvp.Value :?> System.Windows.Input.ICommand)
                    if kvp.Key = Xaml.RowHeightKey then 
                        prevRowHeightOpt <- ValueSome (kvp.Value :?> int)
                    if kvp.Key = Xaml.ListViewGrouped_SelectedItemKey then 
                        prevListViewGrouped_SelectedItemOpt <- ValueSome (kvp.Value :?> (int * int) option)
                    if kvp.Key = Xaml.SeparatorVisibilityKey then 
                        prevSeparatorVisibilityOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.SeparatorVisibility)
                    if kvp.Key = Xaml.SeparatorColorKey then 
                        prevSeparatorColorOpt <- ValueSome (kvp.Value :?> Xamarin.Forms.Color)
                    if kvp.Key = Xaml.ListViewGrouped_ItemAppearingKey then 
                        prevListViewGrouped_ItemAppearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                    if kvp.Key = Xaml.ListViewGrouped_ItemDisappearingKey then 
                        prevListViewGrouped_ItemDisappearingOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemVisibilityEventArgs>)
                    if kvp.Key = Xaml.ListViewGrouped_ItemSelectedKey then 
                        prevListViewGrouped_ItemSelectedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.SelectedItemChangedEventArgs>)
                    if kvp.Key = Xaml.ListViewGrouped_ItemTappedKey then 
                        prevListViewGrouped_ItemTappedOpt <- ValueSome (kvp.Value :?> System.EventHandler<Xamarin.Forms.ItemTappedEventArgs>)
                    if kvp.Key = Xaml.RefreshingKey then 
                        prevRefreshingOpt <- ValueSome (kvp.Value :?> System.EventHandler)
            updateListViewGroupedItems prevListViewGrouped_ItemsSourceOpt currListViewGrouped_ItemsSourceOpt target
            match prevFooterOpt, currFooterOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Footer <-  currValue
            | ValueSome _, ValueNone -> target.Footer <- null
            | ValueNone, ValueNone -> ()
            match prevHasUnevenRowsOpt, currHasUnevenRowsOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.HasUnevenRows <-  currValue
            | ValueSome _, ValueNone -> target.HasUnevenRows <- false
            | ValueNone, ValueNone -> ()
            match prevHeaderOpt, currHeaderOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.Header <-  currValue
            | ValueSome _, ValueNone -> target.Header <- null
            | ValueNone, ValueNone -> ()
            match prevIsGroupingEnabledOpt, currIsGroupingEnabledOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsGroupingEnabled <-  currValue
            | ValueSome _, ValueNone -> target.IsGroupingEnabled <- false
            | ValueNone, ValueNone -> ()
            match prevIsPullToRefreshEnabledOpt, currIsPullToRefreshEnabledOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsPullToRefreshEnabled <-  currValue
            | ValueSome _, ValueNone -> target.IsPullToRefreshEnabled <- false
            | ValueNone, ValueNone -> ()
            match prevIsRefreshingOpt, currIsRefreshingOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.IsRefreshing <-  currValue
            | ValueSome _, ValueNone -> target.IsRefreshing <- false
            | ValueNone, ValueNone -> ()
            match prevRefreshCommandOpt, currRefreshCommandOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.RefreshCommand <-  currValue
            | ValueSome _, ValueNone -> target.RefreshCommand <- null
            | ValueNone, ValueNone -> ()
            match prevRowHeightOpt, currRowHeightOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.RowHeight <-  currValue
            | ValueSome _, ValueNone -> target.RowHeight <- -1
            | ValueNone, ValueNone -> ()
            match prevListViewGrouped_SelectedItemOpt, currListViewGrouped_SelectedItemOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.SelectedItem <- (function None -> null | Some (i,j) -> let items = target.ItemsSource :?> System.Collections.Generic.IList<ListGroupData<ViewElement>> in (if i >= 0 && i < items.Count then (let items2 = items.[i] in if j >= 0 && j < items2.Count then items2.[j] else null) else null))  currValue
            | ValueSome _, ValueNone -> target.SelectedItem <- null
            | ValueNone, ValueNone -> ()
            match prevSeparatorVisibilityOpt, currSeparatorVisibilityOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.SeparatorVisibility <-  currValue
            | ValueSome _, ValueNone -> target.SeparatorVisibility <- Xamarin.Forms.SeparatorVisibility.Default
            | ValueNone, ValueNone -> ()
            match prevSeparatorColorOpt, currSeparatorColorOpt with
            | ValueSome prevValue, ValueSome currValue when prevValue = currValue -> ()
            | prevOpt, ValueSome currValue -> target.SeparatorColor <-  currValue
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

        new ViewElement(typeof<Xamarin.Forms.ListView>, create, update, attribs)

[<AutoOpen>]
module ViewElementExtensions = 

    type ViewElement with

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
        member x.GestureRecognizers(value: ViewElement list) = x.WithAttributeKeyed(Xaml.GestureRecognizersKey, box (Array.ofList(value)))

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
        member x.Content(value: ViewElement) = x.WithAttributeKeyed(Xaml.ContentKey, box ((value)))

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
        member x.SearchBarCommand(value: string -> unit) = x.WithAttributeKeyed(Xaml.SearchBarCommandKey, box ((value)))

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
        member x.TableRoot(value: (string * ViewElement list) list) = x.WithAttributeKeyed(Xaml.TableRootKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (title, es) -> (title, Array.ofList es)))(value)))

        /// Adjusts the GridRowDefinitions property in the visual element
        member x.GridRowDefinitions(value: obj list) = x.WithAttributeKeyed(Xaml.GridRowDefinitionsKey, box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.RowDefinition(height=h)))(value)))

        /// Adjusts the GridColumnDefinitions property in the visual element
        member x.GridColumnDefinitions(value: obj list) = x.WithAttributeKeyed(Xaml.GridColumnDefinitionsKey, box ((fun es -> es |> Array.ofList |> Array.map (fun h -> Xaml.ColumnDefinition(width=h)))(value)))

        /// Adjusts the RowSpacing property in the visual element
        member x.RowSpacing(value: double) = x.WithAttributeKeyed(Xaml.RowSpacingKey, box ((value)))

        /// Adjusts the ColumnSpacing property in the visual element
        member x.ColumnSpacing(value: double) = x.WithAttributeKeyed(Xaml.ColumnSpacingKey, box ((value)))

        /// Adjusts the Children property in the visual element
        member x.Children(value: ViewElement list) = x.WithAttributeKeyed(Xaml.ChildrenKey, box (Array.ofList(value)))

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
        member x.PickerItemsSource(value: seq<'T>) = x.WithAttributeKeyed(Xaml.PickerItemsSourceKey, box (seqToIListUntyped(value)))

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
        member x.FormattedText(value: ViewElement) = x.WithAttributeKeyed(Xaml.FormattedTextKey, box ((value)))

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
        member x.Spans(value: ViewElement[]) = x.WithAttributeKeyed(Xaml.SpansKey, box ((value)))

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
        member x.ToolbarItems(value: ViewElement list) = x.WithAttributeKeyed(Xaml.ToolbarItemsKey, box (Array.ofList(value)))

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
        member x.CurrentPage(value: ViewElement) = x.WithAttributeKeyed(Xaml.CurrentPageKey, box ((value)))

        /// Adjusts the CurrentPageChanged property in the visual element
        member x.CurrentPageChanged(value: 'T option -> unit) = x.WithAttributeKeyed(Xaml.CurrentPageChangedKey, box ((fun f -> System.EventHandler(fun sender args -> f ((sender :?> Xamarin.Forms.CarouselPage).SelectedItem |> Option.ofObj |> Option.map unbox<'T>)))(value)))

        /// Adjusts the Pages property in the visual element
        member x.Pages(value: ViewElement list) = x.WithAttributeKeyed(Xaml.PagesKey, box (Array.ofList(value)))

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
        member x.Master(value: ViewElement) = x.WithAttributeKeyed(Xaml.MasterKey, box ((value)))

        /// Adjusts the Detail property in the visual element
        member x.Detail(value: ViewElement) = x.WithAttributeKeyed(Xaml.DetailKey, box ((value)))

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
        member x.View(value: ViewElement) = x.WithAttributeKeyed(Xaml.ViewKey, box ((value)))

        /// Adjusts the ListViewItems property in the visual element
        member x.ListViewItems(value: seq<ViewElement>) = x.WithAttributeKeyed(Xaml.ListViewItemsKey, box ((value)))

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
        member x.ListViewGrouped_ItemsSource(value: (ViewElement * ViewElement list) list) = x.WithAttributeKeyed(Xaml.ListViewGrouped_ItemsSourceKey, box ((fun es -> es |> Array.ofList |> Array.map (fun (e,l) -> (e, Array.ofList l)))(value)))

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

    /// Adjusts the RowDefinitionHeight property in the visual element
    let rowDefinitionHeight (value: obj) (x: ViewElement) = x.RowDefinitionHeight(value)

    /// Adjusts the ColumnDefinitionWidth property in the visual element
    let columnDefinitionWidth (value: obj) (x: ViewElement) = x.ColumnDefinitionWidth(value)

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

    /// Adjusts the IsClippedToBounds property in the visual element
    let isClippedToBounds (value: bool) (x: ViewElement) = x.IsClippedToBounds(value)

    /// Adjusts the Padding property in the visual element
    let padding (value: obj) (x: ViewElement) = x.Padding(value)

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

    /// Adjusts the Height property in the visual element
    let height (value: double) (x: ViewElement) = x.Height(value)

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
