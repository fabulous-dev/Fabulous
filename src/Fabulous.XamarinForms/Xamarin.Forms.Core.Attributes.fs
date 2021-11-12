namespace Fabulous.XamarinForms.Attributes

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open System.Collections.Generic

module Application =
    let MainPage = XamarinFormsAttributes.defineWidget "Application_MainPage" (fun target -> (target :?> Xamarin.Forms.Application).MainPage) (fun target value -> (target :?> Xamarin.Forms.Application).MainPage <- unbox value)

module Page =
    let BackgroundImageSource = XamarinFormsAttributes.defineBindable<ImageSource> Xamarin.Forms.Page.BackgroundImageSourceProperty
    let IconImageSource = XamarinFormsAttributes.defineBindable<ImageSource> Xamarin.Forms.Page.IconImageSourceProperty
    let IsBusy = XamarinFormsAttributes.defineBindable<bool> Xamarin.Forms.Page.IsBusyProperty
    let Padding = XamarinFormsAttributes.defineBindable<Thickness> Xamarin.Forms.Page.PaddingProperty
    let Title = XamarinFormsAttributes.defineBindable<string> Xamarin.Forms.Page.TitleProperty

module ContentPage =
    let Content = XamarinFormsAttributes.defineBindableWidget Xamarin.Forms.ContentPage.ContentProperty

module Layout =
    let Padding = XamarinFormsAttributes.defineBindable<Thickness> Xamarin.Forms.Layout.PaddingProperty

module LayoutOfView =
    let Children = XamarinFormsAttributes.defineWidgetCollection "LayoutOfWidget_Children"

module StackLayout =
    let Orientation = XamarinFormsAttributes.defineBindable<StackOrientation> Xamarin.Forms.StackLayout.OrientationProperty
    let Spacing = XamarinFormsAttributes.defineBindable<float> Xamarin.Forms.StackLayout.SpacingProperty

module Element =
    let AutomationId = XamarinFormsAttributes.defineBindable<string> Xamarin.Forms.Element.AutomationIdProperty

module VisualElement =
    let IsEnabled = XamarinFormsAttributes.defineBindable<bool> Xamarin.Forms.VisualElement.IsEnabledProperty
    let Opacity = XamarinFormsAttributes.defineBindable<float> Xamarin.Forms.VisualElement.OpacityProperty

module View =
    let HorizontalOptions = XamarinFormsAttributes.defineBindable<LayoutOptions> Xamarin.Forms.View.HorizontalOptionsProperty
    let VerticalOptions = XamarinFormsAttributes.defineBindable<LayoutOptions> Xamarin.Forms.View.VerticalOptionsProperty
    let Margin = XamarinFormsAttributes.defineBindable<Thickness> Xamarin.Forms.View.MarginProperty

module Label =
    let Text = XamarinFormsAttributes.defineBindable<string> Xamarin.Forms.Label.TextProperty
    let HorizontalTextAlignment = XamarinFormsAttributes.defineBindable<TextAlignment> Xamarin.Forms.Label.HorizontalTextAlignmentProperty
    let VerticalTextAlignment = XamarinFormsAttributes.defineBindable<TextAlignment> Xamarin.Forms.Label.VerticalTextAlignmentProperty
    let FontSize = XamarinFormsAttributes.defineBindable<double> Xamarin.Forms.Label.FontSizeProperty
    let Padding = XamarinFormsAttributes.defineBindable<Thickness> Xamarin.Forms.Label.PaddingProperty

module Button =
    let Text = XamarinFormsAttributes.defineBindable<string> Xamarin.Forms.Button.TextProperty
    let Clicked = XamarinFormsAttributes.defineEventNoArg "Button_Clicked" (fun target -> (target :?> Xamarin.Forms.Button).Clicked)

module Switch =
    let IsToggled = XamarinFormsAttributes.defineBindable<bool> Xamarin.Forms.Switch.IsToggledProperty
    let Toggled = XamarinFormsAttributes.defineEvent<ToggledEventArgs> "Switch_Toggled" (fun target -> (target :?> Xamarin.Forms.Switch).Toggled)

module Slider =
    let MinimumMaximum = XamarinFormsAttributes.define<float * float> "Slider_MinimumMaximum" (fun () -> (0., 1.)) (fun struct (newValueOpt, target) ->
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
    let Value = XamarinFormsAttributes.defineBindable<float> Xamarin.Forms.Slider.ValueProperty
    let ValueChanged = XamarinFormsAttributes.defineEvent<ValueChangedEventArgs> "Slider_ValueChanged" (fun target -> (target :?> Xamarin.Forms.Slider).ValueChanged)

module ActivityIndicator =
    let IsRunning = XamarinFormsAttributes.defineBindable<bool> Xamarin.Forms.ActivityIndicator.IsRunningProperty

module ContentView =
    let Content = XamarinFormsAttributes.defineBindableWidget Xamarin.Forms.ContentView.ContentProperty

module RefreshView =
    let IsRefreshing = XamarinFormsAttributes.defineBindable<bool> Xamarin.Forms.RefreshView.IsRefreshingProperty
    let Refreshing = XamarinFormsAttributes.defineEventNoArg "RefreshView_Refreshing" (fun target -> (target :?> Xamarin.Forms.RefreshView).Refreshing)

module ScrollView =
    let Content = XamarinFormsAttributes.defineWidget "ScrollView_Content" (fun target -> (target :?> Xamarin.Forms.ScrollView).Content) (fun target value -> (target :?> Xamarin.Forms.ScrollView).Content <- unbox value)

module Image =
    let Source = XamarinFormsAttributes.defineBindable<ImageSource> Xamarin.Forms.Image.SourceProperty
    let Aspect = XamarinFormsAttributes.defineBindable<Aspect> Xamarin.Forms.Image.AspectProperty

module Grid =
    let ColumnDefinitions = XamarinFormsAttributes.defineCollection<Dimension> "Grid_ColumnDefinitions" (fun struct (newValueOpt, target) ->
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
    let RowDefinitions = XamarinFormsAttributes.defineCollection<Dimension> "Grid_RowDefinitions" (fun struct (newValueOpt, target) ->
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
    let Column = XamarinFormsAttributes.defineBindable<int> Xamarin.Forms.Grid.ColumnProperty
    let Row = XamarinFormsAttributes.defineBindable<int> Xamarin.Forms.Grid.RowProperty