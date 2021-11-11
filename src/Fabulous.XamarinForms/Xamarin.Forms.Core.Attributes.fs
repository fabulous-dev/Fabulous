namespace Fabulous.XamarinForms.Attributes

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms
open System.Collections.Generic

module Application =
    let MainPage = XamarinFormsAttributes.define<Widget> "Application_MainPage" (fun () -> Unchecked.defaultof<_>) (fun struct (newValueOpt, target) ->
        let app = target :?> Xamarin.Forms.Application
        match newValueOpt with
        | ValueNone -> app.MainPage <- null
        | ValueSome widget when app.MainPage = null ->
            let viewNode = ViewNode.getViewNode target :?> ViewNode
            let widgetDefinition = WidgetDefinitionStore.get widget.Key
            let view = widgetDefinition.CreateView (widget, viewNode.Context)
            app.MainPage <- unbox view
        | ValueSome widget ->
            Reconciler.update ViewNode.getViewNode app.MainPage widget.Attributes
    )

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

module View =
    let HorizontalOptions = XamarinFormsAttributes.defineBindable<LayoutOptions> Xamarin.Forms.View.HorizontalOptionsProperty
    let VerticalOptions = XamarinFormsAttributes.defineBindable<LayoutOptions> Xamarin.Forms.View.VerticalOptionsProperty

module Label =
    let Text = XamarinFormsAttributes.defineBindable<string> Xamarin.Forms.Label.TextProperty
    let HorizontalTextAlignment = XamarinFormsAttributes.defineBindable<TextAlignment> Xamarin.Forms.Label.HorizontalTextAlignmentProperty
    let VerticalTextAlignment = XamarinFormsAttributes.defineBindable<TextAlignment> Xamarin.Forms.Label.VerticalTextAlignmentProperty

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