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

module LayoutOfView =
    let Children = XamarinFormsAttributes.defineWidgetCollection "LayoutOfWidget_Children" (fun struct (newValueOpt, target) ->
        let layout = target :?> Xamarin.Forms.Layout<Xamarin.Forms.View>
        match newValueOpt with
        | ValueNone -> layout.Children.Clear()
        | ValueSome v ->
            layout.Children.Clear()
            for child in v do
                let viewNode = ViewNode.getViewNode target :?> ViewNode
                let widgetDefinition = WidgetDefinitionStore.get child.Key
                let view = widgetDefinition.CreateView (child, viewNode.Context)
                layout.Children.Add(unbox view)
    )

module StackLayout =
    let Orientation = XamarinFormsAttributes.defineBindable<StackOrientation> Xamarin.Forms.StackLayout.OrientationProperty
    let Spacing = XamarinFormsAttributes.defineBindable<float> Xamarin.Forms.StackLayout.SpacingProperty

module View =
    let HorizontalOptions = XamarinFormsAttributes.defineBindable<LayoutOptions> Xamarin.Forms.View.HorizontalOptionsProperty
    let VerticalOptions = XamarinFormsAttributes.defineBindable<LayoutOptions> Xamarin.Forms.View.VerticalOptionsProperty

module Label =
    let Text = XamarinFormsAttributes.defineBindable<string> Xamarin.Forms.Label.TextProperty

module Button =
    let Text = XamarinFormsAttributes.defineBindable<string> Xamarin.Forms.Button.TextProperty
    let Clicked = XamarinFormsAttributes.defineEventNoArg "Button_Clicked" (fun target -> (target :?> Xamarin.Forms.Button).Clicked)