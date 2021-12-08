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
        let UseSafeArea = Attributes.define<bool> "Page_UseSafeArea" (fun (newValueOpt, target) ->
            let page = target :?> Xamarin.Forms.Page
            let value = 
                match newValueOpt with
                | ValueNone -> false
                | ValueSome v -> v

            page.On<iOS>().SetUseSafeArea(value) |> ignore
        )

    module Android =
        let ToolbarPlacement = Attributes.define<ToolbarPlacement> "TabbedPage_ToolbarPlacement" (fun (newValueOpt, target) ->
            let tabbedPage = target :?> Xamarin.Forms.TabbedPage
            let value =
                match newValueOpt with
                | ValueNone -> ToolbarPlacement.Default
                | ValueSome v -> v
            tabbedPage.On<Android>().SetToolbarPlacement(value) |> ignore
        )

[<Extension>]
type AdditionalViewExtensions =
    [<Extension>]
    static member inline center(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Center | Some true -> LayoutOptions.CenterAndExpand
        this.AddScalarAttributes([|
            View.HorizontalOptions.WithValue(options)
            View.VerticalOptions.WithValue(options)
        |])

    [<Extension>]
    static member inline centerHorizontal(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Center | Some true -> LayoutOptions.CenterAndExpand
        this.AddScalarAttribute(View.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline centerVertical(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Center | Some true -> LayoutOptions.CenterAndExpand
        this.AddScalarAttribute(View.VerticalOptions.WithValue(options))
        
    [<Extension>]
    static member inline alignStartHorizontal(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Start | Some true -> LayoutOptions.StartAndExpand
        this.AddScalarAttribute(View.HorizontalOptions.WithValue(options))
        
    [<Extension>]
    static member inline alignStartVertical(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Start | Some true -> LayoutOptions.StartAndExpand
        this.AddScalarAttribute(View.VerticalOptions.WithValue(options))
        
    [<Extension>]
    static member inline alignEndHorizontal(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.End | Some true -> LayoutOptions.EndAndExpand
        this.AddScalarAttribute(View.HorizontalOptions.WithValue(options))
        
    [<Extension>]
    static member inline alignEndVertical(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.End | Some true -> LayoutOptions.EndAndExpand
        this.AddScalarAttribute(View.VerticalOptions.WithValue(options))
        
    [<Extension>]
    static member inline fillHorizontal(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Fill | Some true -> LayoutOptions.FillAndExpand
        this.AddScalarAttribute(View.HorizontalOptions.WithValue(options))
        
    [<Extension>]
    static member inline fillVertical(this: #IViewWidgetBuilder<_>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Fill | Some true -> LayoutOptions.FillAndExpand
        this.AddScalarAttribute(View.VerticalOptions.WithValue(options))

    [<Extension>]
    static member inline centerTextHorizontal(this: Label<_>) =
        this.AddScalarAttribute(Label.HorizontalTextAlignment.WithValue(TextAlignment.Center))

    [<Extension>]
    static member inline style(this: #IViewWidgetBuilder<'msg>, style: Style) =
        this.AddScalarAttribute(NavigableElement.Style.WithValue(style))

    [<Extension>]
    static member inline centerTextVertical(this: Label<_>) =
        this.AddScalarAttribute(Label.VerticalTextAlignment.WithValue(TextAlignment.Center))
        
    [<Extension>]
    static member inline font(this: Label<_>, ?size: double, ?namedSize: NamedSize, ?attributes: FontAttributes) =
        this.AddScalarAttributes([|
            match size with None -> () | Some v -> Label.FontSize.WithValue(v)
            match namedSize with None -> () | Some v -> Label.FontSize.WithValue(Device.GetNamedSize(v, typeof<Label>))
            match attributes with None -> () | Some v -> Label.FontAttributes.WithValue(v)
        |])

    [<Extension>]
    static member inline font(this: DatePicker<_>, ?size: double, ?namedSize: NamedSize, ?attributes: FontAttributes) =
        this.AddScalarAttributes([|
            match size with None -> () | Some v -> DatePicker.FontSize.WithValue(v)
            match namedSize with None -> () | Some v -> DatePicker.FontSize.WithValue(Device.GetNamedSize(v, typeof<DatePicker>))
            match attributes with None -> () | Some v -> DatePicker.FontAttributes.WithValue(v)
        |])

    [<Extension>]
    static member inline font(this: TimePicker<_>, ?size: double, ?namedSize: NamedSize, ?attributes: FontAttributes) =
        this.AddScalarAttributes([|
            match size with None -> () | Some v -> TimePicker.FontSize.WithValue(v)
            match namedSize with None -> () | Some v -> TimePicker.FontSize.WithValue(Device.GetNamedSize(v, typeof<TimePicker>))
            match attributes with None -> () | Some v -> TimePicker.FontAttributes.WithValue(v)
        |])
        
    [<Extension>]
    static member inline font(this: Button<_>, value: NamedSize) =
        this.AddScalarAttribute(Button.FontSize.WithValue(Device.GetNamedSize(value, typeof<Xamarin.Forms.Button>)))

    [<Extension>]
    static member inline font(this: DatePicker<_>, value: NamedSize) =
        this.AddScalarAttribute(DatePicker.FontSize.WithValue(Device.GetNamedSize(value, typeof<Xamarin.Forms.DatePicker>)))

    [<Extension>]
    static member inline font(this: TimePicker<_>, value: NamedSize) =
        this.AddScalarAttribute(TimePicker.FontSize.WithValue(Device.GetNamedSize(value, typeof<Xamarin.Forms.TimePicker>)))

    [<Extension>]
    static member inline paddingLayout(this: #ILayoutWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(Layout.Padding.WithValue(Thickness(value)))

    [<Extension>]
    static member inline cascadeInputTransparent(this: #ILayoutWidgetBuilder<_>, value: bool) =
        this.AddScalarAttribute(Layout.CascadeInputTransparent.WithValue(value))

    [<Extension>]
    static member inline isClippedToBounds(this: #ILayoutWidgetBuilder<_>, value: bool) =
        this.AddScalarAttribute(Layout.IsClippedToBounds.WithValue(value))

    [<Extension>]
    static member inline onLayoutChanged(this: #ILayoutWidgetBuilder<'msg>, value: 'msg) =
        this.AddScalarAttribute(Layout.LayoutChanged.WithValue(value))

    [<Extension>]
    static member inline ignoreSafeArea(this: #IPageWidgetBuilder<_>) =
        this.AddScalarAttribute(AdditionalAttributes.iOS.UseSafeArea.WithValue(false))
        
    [<Extension>]
    static member inline androidToolbarPlacement(this: TabbedPage<_>, value: ToolbarPlacement) =
        this.AddScalarAttribute(AdditionalAttributes.Android.ToolbarPlacement.WithValue(value))
        
    [<Extension>]
    static member inline margin(this: #IViewWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(View.Margin.WithValue(Thickness(value)))
        
    [<Extension>]
    static member inline size(this: #IViewWidgetBuilder<_>, ?width: float, ?height: float) =
        this.AddScalarAttributes([|
            match width with None -> () | Some v -> VisualElement.Width.WithValue(v)
            match height with None -> () | Some v -> VisualElement.Height.WithValue(v)
        |])
    
    [<Extension>]
    static member inline padding(this: #ILabelWidgetBuilder<_>, left: float, top: float, right: float, bottom: float) =
        this.AddScalarAttribute(Label.Padding.WithValue(Thickness(left, top, right, bottom)))
        
    [<Extension>]
    static member inline margin(this: #IViewWidgetBuilder<_>, left: float, top: float, right: float, bottom: float) =
        this.AddScalarAttribute(View.Margin.WithValue(Thickness(left, top, right, bottom)))

    [<Extension>]
    static member inline paddingLayout(this: #ILayoutWidgetBuilder<_>, left: float, top: float, right: float, bottom: float) =
        this.AddScalarAttribute(Layout.Padding.WithValue(Thickness(left, top, right, bottom)))
