namespace Fabulous.XamarinForms.XFAttributes

open Fabulous
open Fabulous.XamarinForms

module Application =
    let MainPage = Attributes.defineWidget ViewNode.getViewNode "Application_MainPage" (fun target -> (target :?> Xamarin.Forms.Application).MainPage) (fun target value -> (target :?> Xamarin.Forms.Application).MainPage <- unbox value)
    let Resources = Attributes.define<ResourceDictionary> "Application_Resources" (fun (newValueOpt, target) ->
        let application = target :?> Xamarin.Forms.Application
        let value =
            match newValueOpt with
            | ValueNone -> application.Resources
            | ValueSome v -> v
        application.Resources <- value)
    let UserAppTheme = Attributes.define<OSAppTheme> "Application_UserAppTheme" (fun (newValueOpt, target) ->
        let application = target :?> Xamarin.Forms.Application
        let value =
            match newValueOpt with
            | ValueNone -> OSAppTheme.Unspecified
            | ValueSome v -> v
        application.UserAppTheme <- value)
    let RequestedThemeChanged = Attributes.defineEvent<AppThemeChangedEventArgs> ViewNode.getViewNode "Application_RequestedThemeChanged" (fun target -> (target :?> Xamarin.Forms.Application).RequestedThemeChanged)
    let ModalPopped = Attributes.defineEvent<ModalPoppedEventArgs> ViewNode.getViewNode "Application_ModalPopped" (fun target -> (target :?> Xamarin.Forms.Application).ModalPopped)
    let ModalPopping = Attributes.defineEvent<ModalPoppingEventArgs> ViewNode.getViewNode "Application_ModalPopping" (fun target -> (target :?> Xamarin.Forms.Application).ModalPopping)
    let ModalPushed = Attributes.defineEvent<ModalPushedEventArgs> ViewNode.getViewNode "Application_ModalPushed" (fun target -> (target :?> Xamarin.Forms.Application).ModalPushed)
    let ModalPushing = Attributes.defineEvent<ModalPushingEventArgs> ViewNode.getViewNode "Application_ModalPushing" (fun target -> (target :?> Xamarin.Forms.Application).ModalPushing)

module Page =
    let BackgroundImageSource = Attributes.defineBindable<Xamarin.Forms.ImageSource> Xamarin.Forms.Page.BackgroundImageSourceProperty
    let IconImageSource = Attributes.defineBindable<Xamarin.Forms.ImageSource> Xamarin.Forms.Page.IconImageSourceProperty
    let IsBusy = Attributes.defineBindable<bool> Xamarin.Forms.Page.IsBusyProperty
    let Padding = Attributes.defineBindable<Xamarin.Forms.Thickness> Xamarin.Forms.Page.PaddingProperty
    let Title = Attributes.defineBindable<string> Xamarin.Forms.Page.TitleProperty
    let ToolbarItems = Attributes.defineWidgetCollection<Xamarin.Forms.ToolbarItem> ViewNode.getViewNode "Page_ToolbarItems" (fun target -> (target :?> Xamarin.Forms.Page).ToolbarItems)
    let Appearing = Attributes.defineEventNoArg ViewNode.getViewNode "Page_Appearing" (fun target -> (target :?> Xamarin.Forms.Page).Appearing)
    let Disappearing = Attributes.defineEventNoArg ViewNode.getViewNode "Page_Disappearing" (fun target -> (target :?> Xamarin.Forms.Page).Disappearing)
    let LayoutChanged = Attributes.defineEventNoArg ViewNode.getViewNode "Page_LayoutChanged" (fun target -> (target :?> Xamarin.Forms.Page).LayoutChanged)

module ContentPage =
    let Content = Attributes.defineBindableWidget Xamarin.Forms.ContentPage.ContentProperty
    let SizeAllocated = Attributes.defineEvent<SizeAllocatedEventArgs> ViewNode.getViewNode "ContentPage_SizeAllocated" (fun target -> (target :?> FabulousContentPage).SizeAllocated)

module Layout =
    let Padding = Attributes.defineBindable<Xamarin.Forms.Thickness> Xamarin.Forms.Layout.PaddingProperty
    let CascadeInputTransparent = Attributes.defineBindable<bool> Xamarin.Forms.Layout.CascadeInputTransparentProperty
    let IsClippedToBounds = Attributes.defineBindable<bool> Xamarin.Forms.Layout.IsClippedToBoundsProperty
    let LayoutChanged = Attributes.defineEventNoArg ViewNode.getViewNode "Layout_LayoutChanged" (fun target -> (target :?> Xamarin.Forms.Layout).LayoutChanged)

module LayoutOfView =
    let Children = Attributes.defineWidgetCollection ViewNode.getViewNode "LayoutOfWidget_Children" (fun target -> (target :?> Xamarin.Forms.Layout<Xamarin.Forms.View>).Children)

module StackLayout =
    let Orientation = Attributes.defineBindable<Xamarin.Forms.StackOrientation> Xamarin.Forms.StackLayout.OrientationProperty
    let Spacing = Attributes.defineBindable<float> Xamarin.Forms.StackLayout.SpacingProperty

module Element =
    let AutomationId = Attributes.defineBindable<string> Xamarin.Forms.Element.AutomationIdProperty

module VisualElement =
    let IsEnabled = Attributes.defineBindable<bool> Xamarin.Forms.VisualElement.IsEnabledProperty
    let Opacity = Attributes.defineBindable<float> Xamarin.Forms.VisualElement.OpacityProperty
    let BackgroundColor = Attributes.defineBindable<Xamarin.Forms.Color> Xamarin.Forms.VisualElement.BackgroundColorProperty
    let Height = Attributes.defineBindable<float> Xamarin.Forms.VisualElement.HeightRequestProperty
    let Width = Attributes.defineBindable<float> Xamarin.Forms.VisualElement.WidthRequestProperty
    let IsVisible = Attributes.defineBindable<bool> Xamarin.Forms.VisualElement.IsVisibleProperty

module NavigableElement =
    let Style = Attributes.defineBindable<Xamarin.Forms.Style> Xamarin.Forms.NavigableElement.StyleProperty

module View =
    let HorizontalOptions = Attributes.defineBindable<Xamarin.Forms.LayoutOptions> Xamarin.Forms.View.HorizontalOptionsProperty
    let VerticalOptions = Attributes.defineBindable<Xamarin.Forms.LayoutOptions> Xamarin.Forms.View.VerticalOptionsProperty
    let Margin = Attributes.defineBindable<Xamarin.Forms.Thickness> Xamarin.Forms.View.MarginProperty
    let GestureRecognizers = Attributes.defineWidgetCollection<Xamarin.Forms.IGestureRecognizer> ViewNode.getViewNode "View_GestureRecognizers" (fun target -> (target :?> Xamarin.Forms.View).GestureRecognizers)

module Label =
    let Text = Attributes.defineBindable<string> Xamarin.Forms.Label.TextProperty
    let HorizontalTextAlignment = Attributes.defineBindable<Xamarin.Forms.TextAlignment> Xamarin.Forms.Label.HorizontalTextAlignmentProperty
    let VerticalTextAlignment = Attributes.defineBindable<Xamarin.Forms.TextAlignment> Xamarin.Forms.Label.VerticalTextAlignmentProperty
    let FontSize = Attributes.defineBindable<double> Xamarin.Forms.Label.FontSizeProperty
    let Padding = Attributes.defineBindable<Xamarin.Forms.Thickness> Xamarin.Forms.Label.PaddingProperty
    let TextColor = Attributes.defineBindable<Xamarin.Forms.Color> Xamarin.Forms.Label.TextColorProperty
    let FontAttributes = Attributes.defineBindable<Xamarin.Forms.FontAttributes> Xamarin.Forms.Label.FontAttributesProperty
    let LineBreakMode = Attributes.defineBindable<Xamarin.Forms.LineBreakMode> Xamarin.Forms.Label.LineBreakModeProperty

module Button =
    let Text = Attributes.defineBindable<string> Xamarin.Forms.Button.TextProperty
    let Clicked = Attributes.defineEventNoArg ViewNode.getViewNode "Button_Clicked" (fun target -> (target :?> Xamarin.Forms.Button).Clicked)
    let TextColor = Attributes.defineAppThemeBindable<Xamarin.Forms.Color> Xamarin.Forms.Button.TextColorProperty
    let FontSize = Attributes.defineBindable<double> Xamarin.Forms.Button.FontSizeProperty
    
module ImageButton =
    let Source = Attributes.defineBindable<Xamarin.Forms.ImageSource> Xamarin.Forms.ImageButton.SourceProperty
    let Aspect = Attributes.defineBindable<Xamarin.Forms.Aspect> Xamarin.Forms.ImageButton.AspectProperty
    let Clicked = Attributes.defineEventNoArg ViewNode.getViewNode "ImageButton_Clicked" (fun target -> (target :?> Xamarin.Forms.ImageButton).Clicked)

module Switch =
    let IsToggled = Attributes.defineBindable<bool> Xamarin.Forms.Switch.IsToggledProperty
    let Toggled = Attributes.defineEvent<Xamarin.Forms.ToggledEventArgs> ViewNode.getViewNode "Switch_Toggled" (fun target -> (target :?> Xamarin.Forms.Switch).Toggled)

module Slider =
    let MinimumMaximum = Attributes.define<float * float> "Slider_MinimumMaximum" ViewUpdaters.updateSliderMinMax
    let Value = Attributes.defineBindable<float> Xamarin.Forms.Slider.ValueProperty
    let ValueChanged = Attributes.defineEvent<Xamarin.Forms.ValueChangedEventArgs> ViewNode.getViewNode "Slider_ValueChanged" (fun target -> (target :?> Xamarin.Forms.Slider).ValueChanged)

module ActivityIndicator =
    let IsRunning = Attributes.defineBindable<bool> Xamarin.Forms.ActivityIndicator.IsRunningProperty

module ContentView =
    let Content = Attributes.defineBindableWidget Xamarin.Forms.ContentView.ContentProperty

module RefreshView =
    let IsRefreshing = Attributes.defineBindable<bool> Xamarin.Forms.RefreshView.IsRefreshingProperty
    let Refreshing = Attributes.defineEventNoArg ViewNode.getViewNode "RefreshView_Refreshing" (fun target -> (target :?> Xamarin.Forms.RefreshView).Refreshing)

module ScrollView =
    let Content = Attributes.defineWidget ViewNode.getViewNode "ScrollView_Content" (fun target -> (target :?> Xamarin.Forms.ScrollView).Content) (fun target value -> (target :?> Xamarin.Forms.ScrollView).Content <- unbox value)

module Image =
    let Source = Attributes.defineBindable<Xamarin.Forms.ImageSource> Xamarin.Forms.Image.SourceProperty
    let Aspect = Attributes.defineBindable<Xamarin.Forms.Aspect> Xamarin.Forms.Image.AspectProperty

module Grid =
    let ColumnDefinitions = Attributes.defineScalarWithConverter<seq<Dimension>, Dimension array> "Grid_ColumnDefinitions" Array.ofSeq ScalarAttributeComparers.equalityCompare ViewUpdaters.updateGridColumnDefinitions
    let RowDefinitions = Attributes.defineScalarWithConverter<seq<Dimension>, Dimension array> "Grid_RowDefinitions" Array.ofSeq ScalarAttributeComparers.equalityCompare ViewUpdaters.updateGridRowDefinitions
    let Column = Attributes.defineBindable<int> Xamarin.Forms.Grid.ColumnProperty
    let Row = Attributes.defineBindable<int> Xamarin.Forms.Grid.RowProperty
    let ColumnSpacing = Attributes.defineBindable<float> Xamarin.Forms.Grid.ColumnSpacingProperty
    let RowSpacing = Attributes.defineBindable<float> Xamarin.Forms.Grid.RowSpacingProperty
    let ColumnSpan = Attributes.defineBindable<int> Xamarin.Forms.Grid.ColumnSpanProperty
    let RowSpan = Attributes.defineBindable<int> Xamarin.Forms.Grid.RowSpanProperty

module BoxView =
    let Color = Attributes.defineBindable<Xamarin.Forms.Color> Xamarin.Forms.BoxView.ColorProperty

module NavigationPage =
    let Pages = Attributes.defineWidgetCollectionWithConverter "NavigationPage_Pages" ViewUpdaters.applyDiffNavigationPagePages ViewUpdaters.updateNavigationPagePages
    let BarBackgroundColor = Attributes.defineBindable<Xamarin.Forms.Color> Xamarin.Forms.NavigationPage.BarBackgroundColorProperty
    let BarTextColor = Attributes.defineBindable<Xamarin.Forms.Color> Xamarin.Forms.NavigationPage.BarTextColorProperty
    let HasNavigationBar = Attributes.defineBindable<bool> Xamarin.Forms.NavigationPage.HasNavigationBarProperty
    let HasBackButton = Attributes.defineBindable<bool> Xamarin.Forms.NavigationPage.HasBackButtonProperty
    let Popped = Attributes.defineEvent<Xamarin.Forms.NavigationEventArgs> ViewNode.getViewNode "NavigationPage_Popped" (fun target -> (target :?> Xamarin.Forms.NavigationPage).Popped)

module Entry =
    let Text = Attributes.defineBindable<string> Xamarin.Forms.Entry.TextProperty
    let TextChanged = Attributes.defineEvent<Xamarin.Forms.TextChangedEventArgs> ViewNode.getViewNode "Entry_TextChanged" (fun target -> (target :?> Xamarin.Forms.Entry).TextChanged)
    let Placeholder = Attributes.defineBindable<string> Xamarin.Forms.Entry.PlaceholderProperty
    let Keyboard = Attributes.defineBindable<Xamarin.Forms.Keyboard> Xamarin.Forms.Entry.KeyboardProperty

module TapGestureRecognizer =
    let Tapped = Attributes.defineEventNoArg ViewNode.getViewNode "TapGestureRecognizer_Tapped" (fun target -> (target :?> Xamarin.Forms.TapGestureRecognizer).Tapped)

module SearchBar =
    let Text = Attributes.defineBindable<string> Xamarin.Forms.SearchBar.TextProperty
    let CancelButtonColor = Attributes.defineBindable<Xamarin.Forms.Color> Xamarin.Forms.SearchBar.CancelButtonColorProperty
    let SearchButtonPressed = Attributes.defineEventNoArg ViewNode.getViewNode "SearchBar_SearchButtonPressed" (fun target -> (target :?> Xamarin.Forms.SearchBar).SearchButtonPressed)

module InputView =
    let TextChanged = Attributes.defineEvent<Xamarin.Forms.TextChangedEventArgs> ViewNode.getViewNode "InputView_TextChanged" (fun target -> (target :?> Xamarin.Forms.InputView).TextChanged)

module MenuItem =
    let Text = Attributes.defineBindable<string> Xamarin.Forms.MenuItem.TextProperty
    let Clicked = Attributes.defineEventNoArg ViewNode.getViewNode "MenuItem_Clicked" (fun target -> (target :?> Xamarin.Forms.MenuItem).Clicked)

module ToolbarItem =
    let Order = Attributes.define<Xamarin.Forms.ToolbarItemOrder> "ToolbarItem_Order" (fun (newValueOpt, target) ->
        let toolbarItem = target :?> Xamarin.Forms.ToolbarItem
        match newValueOpt with
        | ValueNone -> toolbarItem.Order <- Xamarin.Forms.ToolbarItemOrder.Default
        | ValueSome order -> toolbarItem.Order <- order
    )

module Editor =
    let Text = Attributes.defineBindable<string> Xamarin.Forms.Editor.TextProperty

module ViewCell =
    let View = Attributes.defineWidget ViewNode.getViewNode "ViewCell_View" (fun target -> (target :?> Xamarin.Forms.ViewCell).View) (fun target value -> (target :?> Xamarin.Forms.ViewCell).View <- unbox value)

module MultiPageOfPage =
    let Children = Attributes.defineWidgetCollection ViewNode.getViewNode "MultiPageOfPage" (fun target -> (target :?> Xamarin.Forms.MultiPage<Xamarin.Forms.Page>).Children)
module DatePicker =
    let CharacterSpacing = Attributes.defineBindable<float> Xamarin.Forms.DatePicker.CharacterSpacingProperty
    let Date = Attributes.defineBindable<DateTime> Xamarin.Forms.DatePicker.DateProperty
    let FontAttributes = Attributes.defineBindable<FontAttributes> Xamarin.Forms.DatePicker.FontAttributesProperty
    let FontFamily = Attributes.defineBindable<string> Xamarin.Forms.DatePicker.FontFamilyProperty
    let FontSize = Attributes.defineBindable<float> Xamarin.Forms.DatePicker.FontSizeProperty
    let Format = Attributes.defineBindable<string> Xamarin.Forms.DatePicker.FormatProperty
    let MaximumDate = Attributes.defineBindable<DateTime> Xamarin.Forms.DatePicker.MaximumDateProperty
    let MinimumDate = Attributes.defineBindable<DateTime> Xamarin.Forms.DatePicker.MinimumDateProperty
    let TextColor = Attributes.defineAppThemeBindable<Xamarin.Forms.Color> Xamarin.Forms.DatePicker.TextColorProperty
    let TextTransform = Attributes.defineBindable<TextTransform> Xamarin.Forms.DatePicker.TextTransformProperty
    let DateSelected = Attributes.defineEvent<DateChangedEventArgs> ViewNode.getViewNode "DatePicker_DateSelected" (fun target -> (target :?> Xamarin.Forms.DatePicker).DateSelected)
