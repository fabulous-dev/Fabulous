namespace Fabulous.XamarinForms.XFAttributes

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open System.Collections.Generic

module Application =
    let MainPage = Attributes.defineWidget "Application_MainPage" (fun target -> (target :?> Xamarin.Forms.Application).MainPage) (fun target value -> (target :?> Xamarin.Forms.Application).MainPage <- unbox value)

module Page =
    let BackgroundImageSource = Attributes.defineBindable<ImageSource> Xamarin.Forms.Page.BackgroundImageSourceProperty
    let IconImageSource = Attributes.defineBindable<ImageSource> Xamarin.Forms.Page.IconImageSourceProperty
    let IsBusy = Attributes.defineBindable<bool> Xamarin.Forms.Page.IsBusyProperty
    let Padding = Attributes.defineBindable<Thickness> Xamarin.Forms.Page.PaddingProperty
    let Title = Attributes.defineBindable<string> Xamarin.Forms.Page.TitleProperty

module ContentPage =
    let Content = Attributes.defineBindableWidget Xamarin.Forms.ContentPage.ContentProperty
    let SizeAllocated = Attributes.defineEvent<SizeAllocatedEventArgs> "ContentPage_SizeAllocated" (fun target -> (target :?> FabulousContentPage).SizeAllocated)

module Layout =
    let Padding = Attributes.defineBindable<Thickness> Xamarin.Forms.Layout.PaddingProperty

module LayoutOfView =
    let Children = Attributes.defineWidgetCollection "LayoutOfWidget_Children" (fun target -> (target :?> Xamarin.Forms.Layout<Xamarin.Forms.View>).Children)

module StackLayout =
    let Orientation = Attributes.defineBindable<StackOrientation> Xamarin.Forms.StackLayout.OrientationProperty
    let Spacing = Attributes.defineBindable<float> Xamarin.Forms.StackLayout.SpacingProperty

module Element =
    let AutomationId = Attributes.defineBindable<string> Xamarin.Forms.Element.AutomationIdProperty

module VisualElement =
    let IsEnabled = Attributes.defineBindable<bool> Xamarin.Forms.VisualElement.IsEnabledProperty
    let Opacity = Attributes.defineBindable<float> Xamarin.Forms.VisualElement.OpacityProperty
    let BackgroundColor = Attributes.defineBindable<Color> Xamarin.Forms.VisualElement.BackgroundColorProperty
    let Height = Attributes.defineBindable<float> Xamarin.Forms.VisualElement.HeightRequestProperty
    let Width = Attributes.defineBindable<float> Xamarin.Forms.VisualElement.WidthRequestProperty

module View =
    let HorizontalOptions = Attributes.defineBindable<LayoutOptions> Xamarin.Forms.View.HorizontalOptionsProperty
    let VerticalOptions = Attributes.defineBindable<LayoutOptions> Xamarin.Forms.View.VerticalOptionsProperty
    let Margin = Attributes.defineBindable<Thickness> Xamarin.Forms.View.MarginProperty

module Label =
    let Text = Attributes.defineBindable<string> Xamarin.Forms.Label.TextProperty
    let HorizontalTextAlignment = Attributes.defineBindable<TextAlignment> Xamarin.Forms.Label.HorizontalTextAlignmentProperty
    let VerticalTextAlignment = Attributes.defineBindable<TextAlignment> Xamarin.Forms.Label.VerticalTextAlignmentProperty
    let FontSize = Attributes.defineBindable<double> Xamarin.Forms.Label.FontSizeProperty
    let Padding = Attributes.defineBindable<Thickness> Xamarin.Forms.Label.PaddingProperty
    let TextColor = Attributes.defineBindable<Color> Xamarin.Forms.Label.TextColorProperty

module Button =
    let Text = Attributes.defineBindable<string> Xamarin.Forms.Button.TextProperty
    let Clicked = Attributes.defineEventNoArg "Button_Clicked" (fun target -> (target :?> Xamarin.Forms.Button).Clicked)
    let TextColor = Attributes.defineBindable<Color> Xamarin.Forms.Button.TextColorProperty
    let FontSize = Attributes.defineBindable<double> Xamarin.Forms.Button.FontSizeProperty

module Switch =
    let IsToggled = Attributes.defineBindable<bool> Xamarin.Forms.Switch.IsToggledProperty
    let Toggled = Attributes.defineEvent<ToggledEventArgs> "Switch_Toggled" (fun target -> (target :?> Xamarin.Forms.Switch).Toggled)

module Slider =
    let MinimumMaximum = Attributes.define<float * float> "Slider_MinimumMaximum" (fun () -> (0., 1.)) ViewUpdaters.updateSliderMinMax
    let Value = Attributes.defineBindable<float> Xamarin.Forms.Slider.ValueProperty
    let ValueChanged = Attributes.defineEvent<ValueChangedEventArgs> "Slider_ValueChanged" (fun target -> (target :?> Xamarin.Forms.Slider).ValueChanged)

module ActivityIndicator =
    let IsRunning = Attributes.defineBindable<bool> Xamarin.Forms.ActivityIndicator.IsRunningProperty

module ContentView =
    let Content = Attributes.defineBindableWidget Xamarin.Forms.ContentView.ContentProperty

module RefreshView =
    let IsRefreshing = Attributes.defineBindable<bool> Xamarin.Forms.RefreshView.IsRefreshingProperty
    let Refreshing = Attributes.defineEventNoArg "RefreshView_Refreshing" (fun target -> (target :?> Xamarin.Forms.RefreshView).Refreshing)

module ScrollView =
    let Content = Attributes.defineWidget "ScrollView_Content" (fun target -> (target :?> Xamarin.Forms.ScrollView).Content) (fun target value -> (target :?> Xamarin.Forms.ScrollView).Content <- unbox value)

module Image =
    let Source = Attributes.defineBindable<ImageSource> Xamarin.Forms.Image.SourceProperty
    let Aspect = Attributes.defineBindable<Aspect> Xamarin.Forms.Image.AspectProperty

module Grid =
    let ColumnDefinitions = Attributes.defineScalarWithConverter<seq<Dimension>, Dimension array> "Grid_ColumnDefinitions" (fun _ -> Array.empty) Array.ofSeq AttributeComparers.equalityCompare ViewUpdaters.updateGridColumnDefinitions
    let RowDefinitions = Attributes.defineScalarWithConverter<seq<Dimension>, Dimension array> "Grid_RowDefinitions" (fun _ -> Array.empty) Array.ofSeq AttributeComparers.equalityCompare ViewUpdaters.updateGridRowDefinitions
    let Column = Attributes.defineBindable<int> Xamarin.Forms.Grid.ColumnProperty
    let Row = Attributes.defineBindable<int> Xamarin.Forms.Grid.RowProperty
    let ColumnSpacing = Attributes.defineBindable<float> Xamarin.Forms.Grid.ColumnSpacingProperty
    let RowSpacing = Attributes.defineBindable<float> Xamarin.Forms.Grid.RowSpacingProperty
    let ColumnSpan = Attributes.defineBindable<int> Xamarin.Forms.Grid.ColumnSpanProperty
    let RowSpan = Attributes.defineBindable<int> Xamarin.Forms.Grid.RowSpanProperty

module BoxView =
    let Color = Attributes.defineBindable<Color> Xamarin.Forms.BoxView.ColorProperty

module NavigationPage =
    let Pages = Attributes.defineWidgetCollectionWithConverter "NavigationPage_Pages" ViewUpdaters.applyDiffNavigationPagePages ViewUpdaters.updateNavigationPagePages
    let BarBackgroundColor = Attributes.defineBindable<Color> Xamarin.Forms.NavigationPage.BarBackgroundColorProperty
    let BarTextColor = Attributes.defineBindable<Color> Xamarin.Forms.NavigationPage.BarTextColorProperty