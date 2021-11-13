namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous.XamarinForms.XFAttributes
open Fabulous.XamarinForms.Widgets
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration
open Xamarin.Forms.PlatformConfiguration.iOSSpecific

module AdditionalAttributes =
    module iOS =
        let UseSafeArea = Attributes.define<bool> "Page_UseSafeArea" (fun () -> true) (fun struct (newValueOpt, target) ->
            let page = target :?> Xamarin.Forms.Page
            let value = 
                match newValueOpt with
                | ValueNone -> false
                | ValueSome v -> v

            page.On<iOS>().SetUseSafeArea(value) |> ignore
        )

[<Extension>]
type AdditionalViewExtensions =
    [<Extension>]
    static member inline centerHorizontally(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Center | Some true -> LayoutOptions.CenterAndExpand
        this.AddAttribute(View.HorizontalOptions.WithValue(LayoutOptions.Center))

    [<Extension>]
    static member inline centerVertically(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Center | Some true -> LayoutOptions.CenterAndExpand
        this.AddAttribute(View.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline center(this: #IViewWidgetBuilder<_>) =
        this.AddAttributes([|
            View.HorizontalOptions.WithValue(LayoutOptions.Center)
            View.VerticalOptions.WithValue(LayoutOptions.Center)
        |])

    [<Extension>]
    static member inline centerAndExpand(this: #IViewWidgetBuilder<_>) =
        this.AddAttributes([|
            View.HorizontalOptions.WithValue(LayoutOptions.CenterAndExpand)
            View.VerticalOptions.WithValue(LayoutOptions.CenterAndExpand)
        |])

    [<Extension>]
    static member inline centerTextHorizontally(this: LabelWidgetBuilder<_>) =
        this.AddAttribute(Label.HorizontalTextAlignment.WithValue(TextAlignment.Center))
        
    [<Extension>]
    static member inline font(this: LabelWidgetBuilder<_>, value: Xamarin.Forms.NamedSize) =
        this.AddAttribute(Label.FontSize.WithValue(Device.GetNamedSize(value, typeof<Xamarin.Forms.Label>)))
        
    [<Extension>]
    static member inline font(this: ButtonWidgetBuilder<_>, value: Xamarin.Forms.NamedSize) =
        this.AddAttribute(Button.FontSize.WithValue(Device.GetNamedSize(value, typeof<Xamarin.Forms.Button>)))

    [<Extension>]
    static member inline padding(this: #ILayoutWidgetBuilder<_>, value: float) =
        this.AddAttribute(Layout.Padding.WithValue(Thickness(value)))

    [<Extension>]
    static member inline ignoreSafeArea(this: #IPageWidgetBuilder<_>) =
        this.AddAttribute(AdditionalAttributes.iOS.UseSafeArea.WithValue(false))
        
    [<Extension>]
    static member inline margin(this: #IViewWidgetBuilder<_>, value: float) =
        this.AddAttribute(View.Margin.WithValue(Thickness(value)))
        
    [<Extension>]
    static member inline size(this: #IViewWidgetBuilder<_>, ?width: float, ?height: float) =
        this.AddAttributes([|
            match width with None -> () | Some v -> VisualElement.Width.WithValue(v)
            match height with None -> () | Some v -> VisualElement.Height.WithValue(v)
        |])
