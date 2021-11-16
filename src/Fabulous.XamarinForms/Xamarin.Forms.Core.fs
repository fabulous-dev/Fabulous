namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms.XFAttributes
open Fabulous.XamarinForms.Widgets
open System.Runtime.CompilerServices

module ViewHelpers =
    let inline compileSeq (items: seq<#IWidgetBuilder<'msg>>) =
        items
        |> Seq.map (fun item -> item.Compile())
        |> Seq.toArray

type [<Struct>] ApplicationWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Application>()

    static member inline Create(mainPage: #IPageWidgetBuilder<'msg>) =
        ApplicationWidgetBuilder<'msg>(
            [||],
            [| Application.MainPage.WithValue(mainPage.Compile()) |],
            [||]
        )

    interface IApplicationWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }

type [<Struct>] ContentPageWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Fabulous.XamarinForms.FabulousContentPage>()

    static member inline Create(content: IViewWidgetBuilder<'msg>) =
        ContentPageWidgetBuilder<'msg>(
            [||],
            [| ContentPage.Content.WithValue(content.Compile()) |],
            [||]
        )

    interface IPageWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }

type [<Struct>] StackLayoutWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.StackLayout>()

    static member inline Create(orientation: Xamarin.Forms.StackOrientation, children: seq<#IViewWidgetBuilder<'msg>>, ?spacing: float) =
        StackLayoutWidgetBuilder<'msg>(
            [|
                StackLayout.Orientation.WithValue(orientation)
                match spacing with None -> () | Some v -> StackLayout.Spacing.WithValue(v)
            |],
            [||],
            [|
                LayoutOfView.Children.WithValue(ViewHelpers.compileSeq children)
            |]
        )

    interface ILayoutWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }
              
type [<Struct>] GridWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Grid>()
              
    static member inline Create(children: seq<#IViewWidgetBuilder<'msg>>, ?coldefs: seq<Dimension>, ?rowdefs: seq<Dimension>) =
        GridWidgetBuilder<'msg>(
            [|
                match coldefs with None -> () | Some v -> Grid.ColumnDefinitions.WithValue(v)
                match rowdefs with None -> () | Some v -> Grid.RowDefinitions.WithValue(v)
            |],
            [||],
            [| LayoutOfView.Children.WithValue(ViewHelpers.compileSeq children) |]
        )
              
    interface ILayoutWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }

type [<Struct>] LabelWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Label>()

    static member inline Create(text: string) =
        LabelWidgetBuilder<'msg>(
            [| Label.Text.WithValue(text) |],
            [||],
            [||]
        )

    interface IViewWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }

type [<Struct>] ButtonWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Button>()

    static member inline Create(text: string, onClicked: 'msg) =
        ButtonWidgetBuilder<'msg>(
            [|
                Button.Text.WithValue(text)
                Button.Clicked.WithValue(onClicked)
            |],
            [||],
            [||]
        )

    interface IViewWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }

type [<Struct>] SwitchWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Switch>()

    static member inline Create(isToggled: bool, onToggled: bool -> 'msg) =
        SwitchWidgetBuilder<'msg>(
            [|
                Switch.IsToggled.WithValue(isToggled)
                Switch.Toggled.WithValue(fun args -> onToggled args.Value |> box)
            |],
            [||],
            [||]
        )
        
    interface IViewWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }
              
type [<Struct>] SliderWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Slider>()
              
    static member inline Create(value: float, onValueChanged: float -> 'msg, ?min: float, ?max: float) =
        SliderWidgetBuilder<'msg>(
            [|
                Slider.Value.WithValue(value)
                Slider.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box)

                match struct (min, max) with
                | (None, None) -> ()
                | (Some minV, Some maxV) -> Slider.MinimumMaximum.WithValue(minV, maxV)
                | _ -> failwith "Both min and max are required"
            |],
            [||],
            [||]
        )
                      
    interface IViewWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }
              
type [<Struct>] ActivityIndicatorWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.ActivityIndicator>()
              
    static member inline Create(isRunning: bool) =
        ActivityIndicatorWidgetBuilder<'msg>(
            [| ActivityIndicator.IsRunning.WithValue(isRunning) |],
            [||],
            [||]
        )
                      
    interface IViewWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }
              
type [<Struct>] ContentViewWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.ContentView>()
              
    static member inline Create(content: IViewWidgetBuilder<'msg>) =
        ContentViewWidgetBuilder<'msg>(
            [||],
            [| ContentView.Content.WithValue(content.Compile()) |],
            [||]
        )
                      
    interface ILayoutWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }
              
type [<Struct>] RefreshViewWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.RefreshView>()
              
    static member inline Create(isRefreshing: bool, onRefreshing: 'msg, content: #IViewWidgetBuilder<'msg>) =
        RefreshViewWidgetBuilder<'msg>(
            [|
                RefreshView.IsRefreshing.WithValue(isRefreshing)
                RefreshView.Refreshing.WithValue(onRefreshing)
            |],
            [| ContentView.Content.WithValue(content.Compile()) |],
            [||]
        )
                      
    interface ILayoutWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }
              
type [<Struct>] ScrollViewWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.ScrollView>()
              
    static member inline Create(content: #IViewWidgetBuilder<'msg>) =
        ScrollViewWidgetBuilder<'msg>(
            [||],
            [| ScrollView.Content.WithValue(content.Compile()) |],
            [||]
        )
                      
    interface ILayoutWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }
              
type [<Struct>] ImageWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.Image>()
              
    static member inline CreateFromFile(path: string, aspect: Xamarin.Forms.Aspect) =
        ImageWidgetBuilder<'msg>(
            [|
                Image.Source.WithValue(Xamarin.Forms.ImageSource.FromFile(path))
                Image.Aspect.WithValue(aspect)
            |],
            [||],
            [||]
        )
        
    static member inline CreateFromUrl(url: string, aspect: Xamarin.Forms.Aspect) =
        ImageWidgetBuilder<'msg>(
            [|
                Image.Source.WithValue(Xamarin.Forms.ImageSource.FromUri(System.Uri(url)))
                Image.Aspect.WithValue(aspect)
            |],
            [||],
            [||]
        )
                      
    interface IViewWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }
              
type [<Struct>] BoxViewWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.BoxView>()
              
    static member inline Create(color: Xamarin.Forms.Color) =
        BoxViewWidgetBuilder<'msg>(
            [|
                BoxView.Color.WithValue(color)
            |],
            [||],
            [||]
        )
                      
    interface IViewWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }
              
type [<Struct>] NavigationPageWidgetBuilder<'msg> (scalarAttributes: ScalarAttribute[], widgetAttributes: WidgetAttribute[], widgetCollectionAttributes: WidgetCollectionAttribute[]) =
    static let key = Widgets.register<Xamarin.Forms.NavigationPage>()
              
    static member inline Create(pages: seq<IPageWidgetBuilder<'msg>>) =
        NavigationPageWidgetBuilder<'msg>(
            [||],
            [||],
            [| NavigationPage.Pages.WithValue(ViewHelpers.compileSeq pages) |]
        )
                      
    interface IPageWidgetBuilder<'msg> with
        member _.ScalarAttributes = scalarAttributes
        member _.WidgetAttributes = widgetAttributes
        member _.WidgetCollectionAttributes = widgetCollectionAttributes
        member _.Compile() =
            { Key = key
              ScalarAttributes = scalarAttributes
              WidgetAttributes = widgetAttributes
              WidgetCollectionAttributes = widgetCollectionAttributes }

[<Extension>]
type ViewExtensions () =
    [<Extension>]
    static member inline automationId(this: #IViewWidgetBuilder<_>, value: string) =
        this.AddScalarAttribute(Element.AutomationId.WithValue(value))
    [<Extension>]
    static member inline isEnabled(this: #IViewWidgetBuilder<_>, value: bool) =
        this.AddScalarAttribute(VisualElement.IsEnabled.WithValue(value))
    [<Extension>]
    static member inline opacity(this: #IViewWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(VisualElement.Opacity.WithValue(value))
    [<Extension>]
    static member inline backgroundColor(this: #IViewWidgetBuilder<_>, value: Xamarin.Forms.Color) =
        this.AddScalarAttribute(VisualElement.BackgroundColor.WithValue(value))
    [<Extension>]
    static member inline horizontalOptions(this: #IViewWidgetBuilder<_>, value: Xamarin.Forms.LayoutOptions) =
        this.AddScalarAttribute(View.HorizontalOptions.WithValue(value))
    [<Extension>]
    static member inline verticalOptions(this: #IViewWidgetBuilder<_>, value: Xamarin.Forms.LayoutOptions) =
        this.AddScalarAttribute(View.VerticalOptions.WithValue(value))
    [<Extension>]
    static member inline margin(this: #IViewWidgetBuilder<_>, value: Xamarin.Forms.Thickness) =
        this.AddScalarAttribute(View.Margin.WithValue(value))
    [<Extension>]
    static member inline horizontalTextAlignment(this: LabelWidgetBuilder<_>, value: Xamarin.Forms.TextAlignment) =
        this.AddScalarAttribute(Label.HorizontalTextAlignment.WithValue(value))
    [<Extension>]
    static member inline verticalTextAlignment(this: LabelWidgetBuilder<_>, value: Xamarin.Forms.TextAlignment) =
        this.AddScalarAttribute(Label.VerticalTextAlignment.WithValue(value))
    [<Extension>]
    static member inline font(this: LabelWidgetBuilder<_>, value: double) =
        this.AddScalarAttribute(Label.FontSize.WithValue(value))
    [<Extension>]
    static member inline textColor(this: LabelWidgetBuilder<_>, value: Xamarin.Forms.Color) =
        this.AddScalarAttribute(Label.TextColor.WithValue(value))
    [<Extension>]
    static member inline padding(this: LabelWidgetBuilder<_>, value: Xamarin.Forms.Thickness) =
        this.AddScalarAttribute(Label.Padding.WithValue(value))
    [<Extension>]
    static member inline textColor(this: ButtonWidgetBuilder<_>, value: Xamarin.Forms.Color) =
        this.AddScalarAttribute(Button.TextColor.WithValue(value))
    [<Extension>]
    static member inline font(this: ButtonWidgetBuilder<_>, value: double) =
        this.AddScalarAttribute(Button.FontSize.WithValue(value))
    [<Extension>]
    static member inline padding(this: #ILayoutWidgetBuilder<_>, value: Xamarin.Forms.Thickness) =
        this.AddScalarAttribute(Layout.Padding.WithValue(value))
    [<Extension>]
    static member inline gridColumn(this: #IViewWidgetBuilder<_>, value: int) =
        this.AddScalarAttribute(Grid.Column.WithValue(value))
    [<Extension>]
    static member inline gridRow(this: #IViewWidgetBuilder<_>, value: int) =
        this.AddScalarAttribute(Grid.Row.WithValue(value))
    [<Extension>]
    static member inline columnSpacing(this: GridWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(Grid.ColumnSpacing.WithValue(value))
    [<Extension>]
    static member inline rowSpacing(this: GridWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(Grid.RowSpacing.WithValue(value))
    [<Extension>]
    static member inline gridColumnSpan(this: #IViewWidgetBuilder<_>, value: int) =
        this.AddScalarAttribute(Grid.ColumnSpan.WithValue(value))
    [<Extension>]
    static member inline gridRowSpan(this: #IViewWidgetBuilder<_>, value: int) =
        this.AddScalarAttribute(Grid.RowSpan.WithValue(value))
    [<Extension>]
    static member inline onSizeAllocated(this: ContentPageWidgetBuilder<'msg>, fn: SizeAllocatedEventArgs -> 'msg) =
        this.AddScalarAttribute(ContentPage.SizeAllocated.WithValue(fn >> box))
    [<Extension>]
    static member inline barBackgroundColor(this: NavigationPageWidgetBuilder<_>, value: Xamarin.Forms.Color) =
        this.AddScalarAttribute(NavigationPage.BarBackgroundColor.WithValue(value))
    [<Extension>]
    static member inline barTextColor(this: NavigationPageWidgetBuilder<_>, value: Xamarin.Forms.Color) =
        this.AddScalarAttribute(NavigationPage.BarTextColor.WithValue(value))
    [<Extension>]
    static member inline height(this: #IViewWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(VisualElement.Height.WithValue(value))
    [<Extension>]
    static member inline width(this: #IViewWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(VisualElement.Width.WithValue(value))


[<AbstractClass; Sealed>]
type View private () =
    static member inline Application<'msg>(mainPage) = ApplicationWidgetBuilder<'msg>.Create(mainPage)
    static member inline ContentPage<'msg>(content) = ContentPageWidgetBuilder<'msg>.Create(content)
    static member inline VerticalStackLayout<'msg>(children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Vertical, children)
    static member inline VerticalStackLayout<'msg>(spacing: float, children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Vertical, children, spacing = spacing)
    static member inline HorizontalStackLayout<'msg>(children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Horizontal, children)
    static member inline HorizontalStackLayout<'msg>(spacing: float, children) = StackLayoutWidgetBuilder<'msg>.Create(Xamarin.Forms.StackOrientation.Horizontal, children, spacing = spacing)
    static member inline Label<'msg>(text) = LabelWidgetBuilder<'msg>.Create(text)
    static member inline Button<'msg>(text, onClicked) = ButtonWidgetBuilder<'msg>.Create(text, onClicked)
    static member inline Switch<'msg>(isToggled, onToggled) = SwitchWidgetBuilder<'msg>.Create(isToggled, onToggled)
    static member inline Slider<'msg>(value, onValueChanged) = SliderWidgetBuilder<'msg>.Create(value, onValueChanged)
    static member inline Slider<'msg>(min, max, value, onValueChanged) = SliderWidgetBuilder<'msg>.Create(value, onValueChanged, min = min, max = max)
    static member inline Grid<'msg>(children) = GridWidgetBuilder<'msg>.Create(children)
    static member inline Grid<'msg>(coldefs, rowdefs, children) = GridWidgetBuilder<'msg>.Create(children, coldefs = coldefs, rowdefs = rowdefs)
    static member inline ActivityIndicator<'msg>(isRunning) = ActivityIndicatorWidgetBuilder<'msg>.Create(isRunning)
    static member inline ContentView<'msg>(content) = ContentViewWidgetBuilder<'msg>.Create(content)
    static member inline RefreshView<'msg>(isRefreshing, onRefreshing, content) = RefreshViewWidgetBuilder<'msg>.Create(isRefreshing, onRefreshing, content)
    static member inline ScrollView<'msg>(content) = ScrollViewWidgetBuilder<'msg>.Create(content)
    static member inline FileImage<'msg>(path, aspect) = ImageWidgetBuilder<'msg>.CreateFromFile(path, aspect)
    static member inline WebImage<'msg>(url, aspect) = ImageWidgetBuilder<'msg>.CreateFromUrl(url, aspect)
    static member inline BoxView<'msg>(color) = BoxViewWidgetBuilder<'msg>.Create(color)
    static member inline NavigationPage<'msg>(pages) = NavigationPageWidgetBuilder<'msg>.Create(pages)
    