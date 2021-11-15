namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms.XFAttributes
open Fabulous.XamarinForms.Widgets
open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration
open Xamarin.Forms.PlatformConfiguration.iOSSpecific

module AdditionalAttributes =
    module iOS =
        let UseSafeArea = Attributes.define<bool> "Page_UseSafeArea" (fun () -> true) (fun (newValueOpt, target) ->
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
        this.AddScalarAttribute(View.HorizontalOptions.WithValue(LayoutOptions.Center))

    [<Extension>]
    static member inline centerVertically(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Center | Some true -> LayoutOptions.CenterAndExpand
        this.AddScalarAttribute(View.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline center(this: #IViewWidgetBuilder<_>) =
        this.AddScalarAttributes([|
            View.HorizontalOptions.WithValue(LayoutOptions.Center)
            View.VerticalOptions.WithValue(LayoutOptions.Center)
        |])

    [<Extension>]
    static member inline centerAndExpand(this: #IViewWidgetBuilder<_>) =
        this.AddScalarAttributes([|
            View.HorizontalOptions.WithValue(LayoutOptions.CenterAndExpand)
            View.VerticalOptions.WithValue(LayoutOptions.CenterAndExpand)
        |])

    [<Extension>]
    static member inline centerTextHorizontally(this: LabelWidgetBuilder<_>) =
        this.AddScalarAttribute(Label.HorizontalTextAlignment.WithValue(TextAlignment.Center))
        
    [<Extension>]
    static member inline font(this: LabelWidgetBuilder<_>, ?namedSize: Xamarin.Forms.NamedSize, ?attributes: FontAttributes) =
        this.AddScalarAttributes([|
            match namedSize with None -> () | Some v -> Label.FontSize.WithValue(Device.GetNamedSize(v, typeof<Xamarin.Forms.Label>))
            match attributes with None -> () | Some v -> Label.FontAttributes.WithValue(v)
        |])
        
    [<Extension>]
    static member inline font(this: ButtonWidgetBuilder<_>, value: Xamarin.Forms.NamedSize) =
        this.AddScalarAttribute(Button.FontSize.WithValue(Device.GetNamedSize(value, typeof<Xamarin.Forms.Button>)))

    [<Extension>]
    static member inline paddingLayout(this: #ILayoutWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(Layout.Padding.WithValue(Thickness(value)))

    [<Extension>]
    static member inline ignoreSafeArea(this: #IPageWidgetBuilder<_>) =
        this.AddScalarAttribute(AdditionalAttributes.iOS.UseSafeArea.WithValue(false))
        
    [<Extension>]
    static member inline margin(this: #IViewWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(View.Margin.WithValue(Thickness(value)))
        
    [<Extension>]
    static member inline size(this: #IViewWidgetBuilder<_>, ?width: float, ?height: float) =
        this.AddScalarAttributes([|
            match width with None -> () | Some v -> VisualElement.Width.WithValue(v)
            match height with None -> () | Some v -> VisualElement.Height.WithValue(v)
        |])
