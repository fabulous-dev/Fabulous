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
        let UseSafeArea = Attributes.define<bool> "Page_UseSafeArea" (fun (newValueOpt, _context, target) ->
            let page = target :?> Xamarin.Forms.Page
            let value = 
                match newValueOpt with
                | ValueNone -> false
                | ValueSome v -> v

            page.On<iOS>().SetUseSafeArea(value) |> ignore
        )

    module Android =
        let ToolbarPlacement = Attributes.define<ToolbarPlacement> "TabbedPage_ToolbarPlacement" (fun (newValueOpt, _context, target) ->
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
    static member inline center(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Center | Some true -> LayoutOptions.CenterAndExpand
        this.AddScalars([|
            View.HorizontalOptions.WithValue(options)
            View.VerticalOptions.WithValue(options)
        |])

    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Center | Some true -> LayoutOptions.CenterAndExpand
        this.AddScalar(View.HorizontalOptions.WithValue(options))

    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Center | Some true -> LayoutOptions.CenterAndExpand
        this.AddScalar(View.VerticalOptions.WithValue(options))
        
    [<Extension>]
    static member inline alignStartHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Start | Some true -> LayoutOptions.StartAndExpand
        this.AddScalar(View.HorizontalOptions.WithValue(options))
        
    [<Extension>]
    static member inline alignStartVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Start | Some true -> LayoutOptions.StartAndExpand
        this.AddScalar(View.VerticalOptions.WithValue(options))
        
    [<Extension>]
    static member inline alignEndHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.End | Some true -> LayoutOptions.EndAndExpand
        this.AddScalar(View.HorizontalOptions.WithValue(options))
        
    [<Extension>]
    static member inline alignEndVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.End | Some true -> LayoutOptions.EndAndExpand
        this.AddScalar(View.VerticalOptions.WithValue(options))
        
    [<Extension>]
    static member inline fillHorizontal(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Fill | Some true -> LayoutOptions.FillAndExpand
        this.AddScalar(View.HorizontalOptions.WithValue(options))
        
    [<Extension>]
    static member inline fillVertical(this: WidgetBuilder<'msg, #IView>, ?expand: bool) =
        let options = match expand with None | Some false -> LayoutOptions.Fill | Some true -> LayoutOptions.FillAndExpand
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
    static member inline font(this: WidgetBuilder<_, #ILabel>, ?size: double, ?namedSize: NamedSize, ?attributes: FontAttributes) =
        this.AddScalars([|
            match size with None -> () | Some v -> Label.FontSize.WithValue(v)
            match namedSize with None -> () | Some v -> Label.FontSize.WithValue(Device.GetNamedSize(v, typeof<Label>))
            match attributes with None -> () | Some v -> Label.FontAttributes.WithValue(v)
        |])
        
    [<Extension>]
    static member inline font(this: WidgetBuilder<_, #IButton>, value: NamedSize) =
        this.AddScalar(Button.FontSize.WithValue(Device.GetNamedSize(value, typeof<Xamarin.Forms.Button>)))

    [<Extension>]
    static member inline paddingLayout(this: WidgetBuilder<_, #ILayout>, value: float) =
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
        this.AddScalars([|
            match width with None -> () | Some v -> VisualElement.Width.WithValue(v)
            match height with None -> () | Some v -> VisualElement.Height.WithValue(v)
        |])
    
    [<Extension>]
    static member inline padding(this: WidgetBuilder<_, #IView>, left: float, top: float, right: float, bottom: float) =
        this.AddScalar(Label.Padding.WithValue(Thickness(left, top, right, bottom)))
        
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, left: float, top: float, right: float, bottom: float) =
        this.AddScalar(View.Margin.WithValue(Thickness(left, top, right, bottom)))

    [<Extension>]
    static member inline paddingLayout(this: WidgetBuilder<_, #ILayout>, left: float, top: float, right: float, bottom: float) =
        this.AddScalar(Layout.Padding.WithValue(Thickness(left, top, right, bottom)))
