namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IView =
    inherit Fabulous.Maui.IVisualElement

module XFView =
    let HorizontalOptions =
        Attributes.defineSmallBindable<LayoutOptions> View.HorizontalOptionsProperty SmallScalars.LayoutOptions.decode

    let VerticalOptions =
        Attributes.defineSmallBindable<LayoutOptions> View.VerticalOptionsProperty SmallScalars.LayoutOptions.decode

    let Margin =
        Attributes.defineBindableWithEquality<Thickness> View.MarginProperty

    let GestureRecognizers =
        Attributes.defineListWidgetCollection<IGestureRecognizer>
            "View_GestureRecognizers"
            (fun target -> (target :?> View).GestureRecognizers)

[<Extension>]
type ViewModifiers =
    [<Extension>]
    static member inline horizontalOptions(this: WidgetBuilder<'msg, #IView>, value: LayoutOptions) =
        this.AddScalar(XFView.HorizontalOptions.WithValue(value))

    [<Extension>]
    static member inline verticalOptions(this: WidgetBuilder<'msg, #IView>, value: LayoutOptions) =
        this.AddScalar(XFView.VerticalOptions.WithValue(value))

    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IView>) =
        this
            .AddScalar(XFView.HorizontalOptions.WithValue(LayoutOptions.Center))
            .AddScalar(XFView.VerticalOptions.WithValue(LayoutOptions.Center))

    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(XFView.HorizontalOptions.WithValue(LayoutOptions.Center))

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(XFView.VerticalOptions.WithValue(LayoutOptions.Center))

    [<Extension>]
    static member inline alignStartHorizontal(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(XFView.HorizontalOptions.WithValue(LayoutOptions.Start))

    [<Extension>]
    static member inline alignStartVertical(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(XFView.VerticalOptions.WithValue(LayoutOptions.Start))

    [<Extension>]
    static member inline alignEndHorizontal(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(XFView.HorizontalOptions.WithValue(LayoutOptions.End))

    [<Extension>]
    static member inline alignEndVertical(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(XFView.VerticalOptions.WithValue(LayoutOptions.End))

    [<Extension>]
    static member inline fillHorizontal(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(XFView.HorizontalOptions.WithValue(LayoutOptions.Fill))

    [<Extension>]
    static member inline fillVertical(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(XFView.VerticalOptions.WithValue(LayoutOptions.Fill))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, value: Thickness) =
        this.AddScalar(XFView.Margin.WithValue(value))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, value: float) =
        ViewModifiers.margin(this, Thickness(value))

    [<Extension>]
    static member inline margin
        (
            this: WidgetBuilder<'msg, #IView>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        ViewModifiers.margin(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline gestureRecognizers<'msg, 'marker when 'marker :> IView>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, Fabulous.Maui.IGestureRecognizer>
            XFView.GestureRecognizers
            this
