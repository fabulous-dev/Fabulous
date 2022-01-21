namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IView =
    inherit IVisualElement

module XFView =
    let HorizontalOptions =
        Attributes.defineBindable<LayoutOptions> View.HorizontalOptionsProperty

    let VerticalOptions =
        Attributes.defineBindable<LayoutOptions> View.VerticalOptionsProperty

    let Margin =
        Attributes.defineBindable<Thickness> View.MarginProperty

    let GestureRecognizers =
        Attributes.defineWidgetCollection<IGestureRecognizer>
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
    static member inline center(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Center
            | Some true -> LayoutOptions.CenterAndExpand

        this
            .AddScalar(XFView.HorizontalOptions.WithValue(options))
            .AddScalar(XFView.VerticalOptions.WithValue(options))


    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Center
            | Some true -> LayoutOptions.CenterAndExpand

        this.AddScalar(XFView.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Center
            | Some true -> LayoutOptions.CenterAndExpand

        this.AddScalar(XFView.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline alignStartHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Start
            | Some true -> LayoutOptions.StartAndExpand

        this.AddScalar(XFView.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline alignStartVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Start
            | Some true -> LayoutOptions.StartAndExpand

        this.AddScalar(XFView.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline alignEndHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.End
            | Some true -> LayoutOptions.EndAndExpand

        this.AddScalar(XFView.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline alignEndVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.End
            | Some true -> LayoutOptions.EndAndExpand

        this.AddScalar(XFView.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline fillHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Fill
            | Some true -> LayoutOptions.FillAndExpand

        this.AddScalar(XFView.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline fillVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Fill
            | Some true -> LayoutOptions.FillAndExpand

        this.AddScalar(XFView.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, value: Thickness) =
        this.AddScalar(XFView.Margin.WithValue(value))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(XFView.Margin.WithValue(Thickness(value)))

    [<Extension>]
    static member inline margin
        (
            this: WidgetBuilder<'msg, #IView>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        this.AddScalar(XFView.Margin.WithValue(Thickness(left, top, right, bottom)))

    [<Extension>]
    static member inline gestureRecognizers<'msg, 'marker when 'marker :> IView>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, Fabulous.XamarinForms.IGestureRecognizer>
            XFView.GestureRecognizers
            this

    [<Extension>]
    static member inline size(this: WidgetBuilder<'msg, #IView>, ?width: float, ?height: float) =
        match width, height with
        | None, None -> this
        | Some w, None -> this.AddScalar(VisualElement.Width.WithValue(w))
        | None, Some h -> this.AddScalar(VisualElement.Height.WithValue(h))
        | Some w, Some h ->
            this
                .AddScalar(VisualElement.Width.WithValue(w))
                .AddScalar(VisualElement.Height.WithValue(h))
