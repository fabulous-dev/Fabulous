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

module Button =
    let Text = Attributes.defineBindable<string> Xamarin.Forms.Button.TextProperty
    let Clicked = Attributes.defineEventNoArg "Button_Clicked" (fun target -> (target :?> Xamarin.Forms.Button).Clicked)

module Switch =
    let IsToggled = Attributes.defineBindable<bool> Xamarin.Forms.Switch.IsToggledProperty
    let Toggled = Attributes.defineEvent<ToggledEventArgs> "Switch_Toggled" (fun target -> (target :?> Xamarin.Forms.Switch).Toggled)

module Slider =
    let MinimumMaximum = Attributes.define<float * float> "Slider_MinimumMaximum" (fun () -> (0., 1.)) (fun struct (newValueOpt, target) ->
        let slider = target :?> Xamarin.Forms.Slider
        match newValueOpt with
        | ValueNone ->
            slider.ClearValue(Xamarin.Forms.Slider.MinimumProperty)
            slider.ClearValue(Xamarin.Forms.Slider.MaximumProperty)
        | ValueSome (min, max) ->
            let currMax = slider.GetValue(Xamarin.Forms.Slider.MaximumProperty) :?> float
            if min > currMax then
                slider.SetValue(Xamarin.Forms.Slider.MaximumProperty, max)
                slider.SetValue(Xamarin.Forms.Slider.MinimumProperty, min)
            else
                slider.SetValue(Xamarin.Forms.Slider.MinimumProperty, min)
                slider.SetValue(Xamarin.Forms.Slider.MaximumProperty, max)
    )
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
    let ColumnDefinitions = Attributes.defineCollection<Dimension> "Grid_ColumnDefinitions" Helpers.canReuse (fun struct (newValueOpt, target) ->
        let grid = target :?> Xamarin.Forms.Grid
        match newValueOpt with
        | ValueNone -> grid.ColumnDefinitions.Clear()
        | ValueSome coll ->
            grid.ColumnDefinitions.Clear()

            coll
            |> Array.iter (fun c ->
                let gridLength =
                    match c with
                    | Auto -> Xamarin.Forms.GridLength.Auto
                    | Star -> Xamarin.Forms.GridLength.Star
                    | Stars x -> Xamarin.Forms.GridLength(x, Xamarin.Forms.GridUnitType.Star)
                    | Absolute x -> Xamarin.Forms.GridLength(x, Xamarin.Forms.GridUnitType.Absolute)

                grid.ColumnDefinitions.Add(Xamarin.Forms.ColumnDefinition(Width = gridLength))
            )
    )
    let RowDefinitions = Attributes.defineCollection<Dimension> "Grid_RowDefinitions" Helpers.canReuse (fun struct (newValueOpt, target) ->
        let grid = target :?> Xamarin.Forms.Grid
        match newValueOpt with
        | ValueNone -> grid.RowDefinitions.Clear()
        | ValueSome coll ->
            grid.RowDefinitions.Clear()

            coll
            |> Array.iter (fun c ->
                let gridLength =
                    match c with
                    | Auto -> Xamarin.Forms.GridLength.Auto
                    | Star -> Xamarin.Forms.GridLength.Star
                    | Stars x -> Xamarin.Forms.GridLength(x, Xamarin.Forms.GridUnitType.Star)
                    | Absolute x -> Xamarin.Forms.GridLength(x, Xamarin.Forms.GridUnitType.Absolute)

                grid.RowDefinitions.Add(Xamarin.Forms.RowDefinition(Height = gridLength))
            )
    )
    let Column = Attributes.defineBindable<int> Xamarin.Forms.Grid.ColumnProperty
    let Row = Attributes.defineBindable<int> Xamarin.Forms.Grid.RowProperty