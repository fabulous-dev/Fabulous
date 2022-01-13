namespace Fabulous.XamarinForms

open Xamarin.Forms
open Xamarin.Forms.PlatformConfiguration
open Xamarin.Forms.PlatformConfiguration.iOSSpecific
open Xamarin.Forms.PlatformConfiguration.AndroidSpecific
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.XFAttributes

module AdditionalAttributes =
    module iOS =
        let UseSafeArea =
            Attributes.define<bool>
                "Page_UseSafeArea"
                (fun (newValueOpt, node) ->
                    let page = node.Target :?> Xamarin.Forms.Page

                    let value =
                        match newValueOpt with
                        | ValueNone -> false
                        | ValueSome v -> v

                    page.On<iOS>().SetUseSafeArea(value) |> ignore)

    module Android =
        let ToolbarPlacement =
            Attributes.define<ToolbarPlacement>
                "TabbedPage_ToolbarPlacement"
                (fun (newValueOpt, node) ->
                    let tabbedPage = node.Target :?> Xamarin.Forms.TabbedPage

                    let value =
                        match newValueOpt with
                        | ValueNone -> ToolbarPlacement.Default
                        | ValueSome v -> v

                    tabbedPage
                        .On<Android>()
                        .SetToolbarPlacement(value)
                    |> ignore)

[<Extension>]
type AdditionalViewExtensions =
    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Center
            | Some true -> LayoutOptions.CenterAndExpand

        this
            .AddScalar(View.HorizontalOptions.WithValue(options))
            .AddScalar(View.VerticalOptions.WithValue(options))


    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Center
            | Some true -> LayoutOptions.CenterAndExpand

        this.AddScalar(View.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Center
            | Some true -> LayoutOptions.CenterAndExpand

        this.AddScalar(View.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline alignStartHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Start
            | Some true -> LayoutOptions.StartAndExpand

        this.AddScalar(View.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline alignStartVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Start
            | Some true -> LayoutOptions.StartAndExpand

        this.AddScalar(View.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline alignEndHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.End
            | Some true -> LayoutOptions.EndAndExpand

        this.AddScalar(View.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline alignEndVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.End
            | Some true -> LayoutOptions.EndAndExpand

        this.AddScalar(View.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline fillHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Fill
            | Some true -> LayoutOptions.FillAndExpand

        this.AddScalar(View.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline fillVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options =
            match expand with
            | None
            | Some false -> LayoutOptions.Fill
            | Some true -> LayoutOptions.FillAndExpand

        this.AddScalar(View.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline centerTextHorizontal(this: WidgetBuilder<_, #ILabel>) =
        this.AddScalar(Label.HorizontalTextAlignment.WithValue(TextAlignment.Center))

    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #IView>, style: Style) =
        this.AddScalar(NavigableElement.Style.WithValue(style))

    [<Extension>]
    static member inline centerTextVertical(this: WidgetBuilder<_, #ILabel>) =
        this.AddScalar(Label.VerticalTextAlignment.WithValue(TextAlignment.Center))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, ILabel>,
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontSize.WithValue(Device.GetNamedSize(v, typeof<Label>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontAttributes.WithValue(v))

        res

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, IDatePicker>,
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(DatePicker.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(DatePicker.FontSize.WithValue(Device.GetNamedSize(v, typeof<DatePicker>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(DatePicker.FontAttributes.WithValue(v))

        res



    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, ITimePicker>,
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontSize.WithValue(Device.GetNamedSize(v, typeof<TimePicker>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(TimePicker.FontAttributes.WithValue(v))

        res


    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, IButton>, value: NamedSize) =
        this.AddScalar(Button.FontSize.WithValue(Device.GetNamedSize(value, typeof<Xamarin.Forms.Button>)))

    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, IDatePicker>, value: NamedSize) =
        this.AddScalar(DatePicker.FontSize.WithValue(Device.GetNamedSize(value, typeof<Xamarin.Forms.DatePicker>)))

    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, ITimePicker>, value: NamedSize) =
        this.AddScalar(TimePicker.FontSize.WithValue(Device.GetNamedSize(value, typeof<Xamarin.Forms.TimePicker>)))

    [<Extension>]
    static member inline paddingLayout(this: WidgetBuilder<'msg, #ILayout>, value: float) =
        this.AddScalar(Layout.Padding.WithValue(Thickness(value)))

    [<Extension>]
    static member inline cascadeInputTransparent(this: WidgetBuilder<_, #ILayout>, value: bool) =
        this.AddScalar(Layout.CascadeInputTransparent.WithValue(value))

    [<Extension>]
    static member inline isClippedToBounds(this: WidgetBuilder<_, #ILayout>, value: bool) =
        this.AddScalar(Layout.IsClippedToBounds.WithValue(value))

    [<Extension>]
    static member inline onLayoutChanged(this: WidgetBuilder<'msg, #ILayout>, value: 'msg) =
        this.AddScalar(Layout.LayoutChanged.WithValue(value))

    [<Extension>]
    static member inline ignoreSafeArea(this: WidgetBuilder<_, #IPage>) =
        this.AddScalar(AdditionalAttributes.iOS.UseSafeArea.WithValue(false))

    [<Extension>]
    static member inline androidToolbarPlacement(this: WidgetBuilder<_, #ITabbedPage>, value: ToolbarPlacement) =
        this.AddScalar(AdditionalAttributes.Android.ToolbarPlacement.WithValue(value))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(View.Margin.WithValue(Thickness(value)))

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

    [<Extension>]
    static member inline padding(this: WidgetBuilder<_, #IView>, left: float, top: float, right: float, bottom: float) =
        this.AddScalar(Label.Padding.WithValue(Thickness(left, top, right, bottom)))

    [<Extension>]
    static member inline margin
        (
            this: WidgetBuilder<'msg, #IView>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        this.AddScalar(View.Margin.WithValue(Thickness(left, top, right, bottom)))

    [<Extension>]
    static member inline paddingLayout
        (
            this: WidgetBuilder<_, #ILayout>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        this.AddScalar(Layout.Padding.WithValue(Thickness(left, top, right, bottom)))
