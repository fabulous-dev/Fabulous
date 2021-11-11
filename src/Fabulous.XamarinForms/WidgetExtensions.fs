namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous.XamarinForms.Attributes
open Fabulous.XamarinForms.Widgets

[<Extension>]
type AdditionalViewExtensions =
    [<Extension>]
    static member inline centerHorizontally(this: #IViewWidgetBuilder<_>) =
        this.AddAttribute(View.HorizontalOptions.WithValue(Xamarin.Forms.LayoutOptions.Center))
    [<Extension>]
    static member inline centerVertically(this: #IViewWidgetBuilder<_>) =
        this.AddAttribute(View.VerticalOptions.WithValue(Xamarin.Forms.LayoutOptions.Center))
    [<Extension>]
    static member inline center(this: #IViewWidgetBuilder<_>) =
        this.AddAttributes([|
            View.HorizontalOptions.WithValue(Xamarin.Forms.LayoutOptions.Center)
            View.VerticalOptions.WithValue(Xamarin.Forms.LayoutOptions.Center)
        |])
    [<Extension>]
    static member inline centerAndExpand(this: #IViewWidgetBuilder<_>) =
        this.AddAttributes([|
            View.HorizontalOptions.WithValue(Xamarin.Forms.LayoutOptions.CenterAndExpand)
            View.VerticalOptions.WithValue(Xamarin.Forms.LayoutOptions.CenterAndExpand)
        |])

    [<Extension>]
    static member inline centerTextHorizontally(this: LabelWidgetBuilder<_>) =
        this.AddAttribute(Label.HorizontalTextAlignment.WithValue(Xamarin.Forms.TextAlignment.Center))

    [<Extension>]
    static member inline padding(this: #ILayoutWidgetBuilder<_>, value: float) =
        this.AddAttribute(Layout.Padding.WithValue(Xamarin.Forms.Thickness(value)))