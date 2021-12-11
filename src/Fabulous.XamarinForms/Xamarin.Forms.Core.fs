namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.XFAttributes
open System.Runtime.CompilerServices
open System.IO
open Microsoft.FSharp.Core

module ViewHelpers =
    let inline compileSeq (items: seq<WidgetBuilder<'msg, #IMarker>>) =
        items
        |> Seq.map (fun item -> item.Compile())
        |> Seq.toArray
        
    let inline buildScalars<'msg, 'marker> (key: WidgetKey) (attrs: ScalarAttribute[]) =
        WidgetBuilder<'msg, 'marker>(key, struct (attrs, [||], [||]))
        
    let inline buildWidgets<'msg, 'marker> (key: WidgetKey) (attrs: WidgetAttribute[]) =
        WidgetBuilder<'msg, 'marker>(key, struct ([||], attrs, [||]))
        
    let inline build<'msg, 'marker> (key: WidgetKey) (scalars: ScalarAttribute[]) (widgets: WidgetAttribute[]) (widgetColls: WidgetCollectionAttribute[]) =
        WidgetBuilder<'msg, 'marker>(key, struct (scalars, widgets, widgetColls))
        
    let inline buildCollectionNoScalar<'msg, 'marker, 'item> (key: WidgetKey) (collectionAttributeDefinition: WidgetCollectionAttributeDefinition) =
        CollectionBuilder<'msg, 'marker, 'item>(key, ValueNone, collectionAttributeDefinition)
        
    let inline buildCollection<'msg, 'marker, 'item> (key: WidgetKey) (collectionAttributeDefinition: WidgetCollectionAttributeDefinition) (scalars: ScalarAttribute[]) =
        CollectionBuilder<'msg, 'marker, 'item>(key, ValueSome scalars, collectionAttributeDefinition)
        
module ViewKeys =
    let Application = Widgets.register<Xamarin.Forms.Application>()
    let ContentPage = Widgets.register<FabulousContentPage>()
    let StackLayout = Widgets.register<Xamarin.Forms.StackLayout>()
    let Grid = Widgets.register<Xamarin.Forms.Grid>()
    let Label = Widgets.register<Xamarin.Forms.Label>()
    let Button = Widgets.register<Xamarin.Forms.Button>()
    let Switch = Widgets.register<Xamarin.Forms.Switch>()
    let Slider = Widgets.register<Xamarin.Forms.Slider>()
    let ActivityIndicator = Widgets.register<Xamarin.Forms.ActivityIndicator>()
    let ContentView = Widgets.register<Xamarin.Forms.ContentView>()
    let RefreshView = Widgets.register<Xamarin.Forms.RefreshView>()
    let ScrollView = Widgets.register<Xamarin.Forms.ScrollView>()
    let Image = Widgets.register<Xamarin.Forms.Image>()
    let BoxView = Widgets.register<Xamarin.Forms.BoxView>()
    let NavigationPage = Widgets.register<Xamarin.Forms.NavigationPage>()
    let Entry = Widgets.register<Xamarin.Forms.Entry>()
    let TapGestureRecognizer = Widgets.register<Xamarin.Forms.TapGestureRecognizer>()
    let SearchBar = Widgets.register<Xamarin.Forms.SearchBar>()
    let ToolbarItem = Widgets.register<Xamarin.Forms.ToolbarItem>()
    let Editor = Widgets.register<Xamarin.Forms.Editor>()
    let ViewCell = Widgets.register<Xamarin.Forms.ViewCell>()
    let ImageButton = Widgets.register<Xamarin.Forms.ImageButton>()
    let TabbedPage = Widgets.register<Xamarin.Forms.TabbedPage>()
    
type IContentPage = inherit IPage
type IStackLayout = inherit ILayout
type IGrid = inherit ILayout
type ILabel = inherit IView
type IButton = inherit IView
type ISwitch = inherit IView
type ISlider = inherit IView
type IActivityIndicator = inherit IView
type IContentView = inherit ILayout
type IRefreshView = inherit IView
type IScrollView = inherit IView
type IImage = inherit IView
type IBoxView = inherit IView
type INavigationPage = inherit IPage
type IEntry = inherit IView
type ITapGestureRecognizer = inherit IGestureRecognizer
type ISearchBar = inherit IView
type IEditor = inherit IView
type IViewCell = inherit ICell
type IImageButton = inherit IView
type ITabbedPage = inherit IPage
    
open ViewHelpers

[<AbstractClass; Sealed>]
type ViewBuilders private () =
    static member inline Application<'msg, 'marker when 'marker :> IPage>(mainPage: WidgetBuilder<'msg, 'marker>) =
        buildWidgets<'msg, IApplication> ViewKeys.Application
            [| Application.MainPage.WithValue(mainPage.Compile()) |]
            
    static member inline ContentPage<'msg, 'marker when 'marker :> IView>(title: string, content: WidgetBuilder<'msg, 'marker>) =
        build<'msg, IContentPage> ViewKeys.ContentPage
            [| Page.Title.WithValue(title) |]
            [| ContentPage.Content.WithValue(content.Compile()) |]
            [||]
            
    static member inline StackLayout<'msg>(orientation: Xamarin.Forms.StackOrientation, ?spacing: float) =
        buildCollection<'msg, IStackLayout, IView> ViewKeys.StackLayout LayoutOfView.Children
            [| StackLayout.Orientation.WithValue(orientation)
               match spacing with None -> () | Some v -> StackLayout.Spacing.WithValue(v) |]
            
    static member inline Grid<'msg>(coldefs: seq<Dimension>, rowdefs: seq<Dimension>) =
        buildCollection<'msg, IGrid, IView> ViewKeys.Grid LayoutOfView.Children
            [| Grid.ColumnDefinitions.WithValue(coldefs)
               Grid.RowDefinitions.WithValue(rowdefs) |]
            
    static member inline Label<'msg>(text: string) =
        buildScalars<'msg, ILabel> ViewKeys.Label
            [| Label.Text.WithValue(text) |]
            
    static member inline Button<'msg>(text: string, onClicked: 'msg) =
        buildScalars<'msg, IButton> ViewKeys.Button
            [| Button.Text.WithValue(text)
               Button.Clicked.WithValue(onClicked) |]
            
    static member inline Switch<'msg>(isToggled: bool, onToggled: bool -> 'msg) =
        buildScalars<'msg, ISwitch> ViewKeys.Switch
            [| Switch.IsToggled.WithValue(isToggled)
               Switch.Toggled.WithValue(fun args -> onToggled args.Value |> box) |]
            
    static member inline Slider<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
        buildScalars<'msg, ISlider> ViewKeys.Slider
            [| Slider.Value.WithValue(value)
               Slider.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box)
               Slider.MinimumMaximum.WithValue(min, max) |]
            
    static member inline ActivityIndicator<'msg>(isRunning: bool) =
        buildScalars<'msg, IActivityIndicator> ViewKeys.ActivityIndicator
            [| ActivityIndicator.IsRunning.WithValue(isRunning) |]
            
    static member inline ContentView<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
        buildWidgets<'msg, IContentView> ViewKeys.ContentView
            [| ContentView.Content.WithValue(content.Compile()) |]
    
    static member inline RefreshView<'msg, 'marker when 'marker :> IView>(isRefreshing: bool, onRefreshing: 'msg, content: WidgetBuilder<'msg, 'marker>) =
        build<'msg, IRefreshView> ViewKeys.RefreshView
            [| RefreshView.IsRefreshing.WithValue(isRefreshing)
               RefreshView.Refreshing.WithValue(onRefreshing) |]
            [| ContentView.Content.WithValue(content.Compile()) |]
            [||]
            
    static member inline ScrollView<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
        buildWidgets<'msg, IScrollView> ViewKeys.ScrollView
            [| ScrollView.Content.WithValue(content.Compile()) |]
            
    static member inline SourceImage<'msg>(imageSource: Xamarin.Forms.ImageSource, aspect: Xamarin.Forms.Aspect) =
        buildScalars<'msg, IImage> ViewKeys.Image
            [| Image.Source.WithValue(imageSource)
               Image.Aspect.WithValue(aspect) |]
            
    static member inline FileImage<'msg>(path: string, aspect: Xamarin.Forms.Aspect) =
        ViewBuilders.SourceImage<'msg>(Xamarin.Forms.ImageSource.FromFile(path), aspect)
        
    static member inline WebImage<'msg>(uri: System.Uri, aspect: Xamarin.Forms.Aspect) =
        ViewBuilders.SourceImage<'msg>(Xamarin.Forms.ImageSource.FromUri(uri), aspect)
        
    static member inline StreamImage<'msg>(stream: Stream, aspect: Xamarin.Forms.Aspect) =
        ViewBuilders.SourceImage<'msg>(Xamarin.Forms.ImageSource.FromStream(fun () -> stream), aspect)
        
    static member inline BoxView<'msg>(color: Xamarin.Forms.Color) =
        buildScalars<'msg, IView> ViewKeys.BoxView 
            [| BoxView.Color.WithValue(color) |]
              
    static member inline NavigationPage<'msg>() =
        buildCollectionNoScalar<'msg, INavigationPage, IPage> ViewKeys.NavigationPage NavigationPage.Pages
    
    static member inline Entry<'msg>(text: string, onTextChanged: string -> 'msg) =
        buildScalars<'msg, IEntry> ViewKeys.Entry
            [| Entry.Text.WithValue(text)
               Entry.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box) |]
                                    
    static member inline TapGestureRecognizer<'msg>(onTapped: 'msg) =
        buildScalars<'msg, IGestureRecognizer> ViewKeys.TapGestureRecognizer
            [| TapGestureRecognizer.Tapped.WithValue(onTapped) |]
                      
    static member inline SearchBar<'msg>(text: string, onTextChanged: string -> 'msg, onSearchButtonPressed: 'msg) =
        buildScalars<'msg, ISearchBar> ViewKeys.SearchBar
            [| SearchBar.Text.WithValue(text)
               InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box)
               SearchBar.SearchButtonPressed.WithValue(onSearchButtonPressed) |]
                                    
    static member inline ToolbarItem<'msg>(text: string, onClicked: 'msg) =
        buildScalars<'msg, IToolbarItem> ViewKeys.ToolbarItem
            [| MenuItem.Text.WithValue(text)
               MenuItem.Clicked.WithValue(onClicked) |]
                                    
    static member inline Editor<'msg>(text: string, onTextChanged: string -> 'msg) =
        buildScalars<'msg, IEditor> ViewKeys.Editor
            [| Editor.Text.WithValue(text)
               InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box) |]
                                                  
    static member inline ViewCell<'msg, 'marker when 'marker :> IView>(view: WidgetBuilder<'msg, 'marker>) =
        buildWidgets<'msg, IViewCell> ViewKeys.ViewCell
            [| ViewCell.View.WithValue(view.Compile()) |]
                                                  
    static member inline SourceImageButton<'msg>(source: Xamarin.Forms.ImageSource, onClicked: 'msg, aspect: Xamarin.Forms.Aspect) =
        buildScalars<'msg, IImageButton> ViewKeys.ImageButton
            [| ImageButton.Source.WithValue(source)
               ImageButton.Clicked.WithValue(onClicked)
               ImageButton.Aspect.WithValue(aspect) |]

    static member inline FileImageButton<'msg>(path: string, onClicked, aspect) =
        ViewBuilders.SourceImageButton<'msg>(Xamarin.Forms.ImageSource.FromFile(path), onClicked, aspect)
        
    static member inline WebImageButton<'msg>(uri: System.Uri, onClicked, aspect) =
        ViewBuilders.SourceImageButton<'msg>(Xamarin.Forms.ImageSource.FromUri(uri), onClicked, aspect)
        
    static member inline StreamImageButton<'msg>(stream: Stream, onClicked, aspect) =
        ViewBuilders.SourceImageButton<'msg>(Xamarin.Forms.ImageSource.FromStream(fun () -> stream), onClicked, aspect)
                                                  
    static member inline TabbedPage<'msg>(title: string) =
        buildCollection<'msg, ITabbedPage, IPage> ViewKeys.TabbedPage MultiPageOfPage.Children
            [| Page.Title.WithValue(title) |]
    
[<AbstractClass; Sealed>]
type View private () =    
    static member inline Application<'msg, 'marker when 'marker :> IPage>(mainPage) = ViewBuilders.Application<'msg, 'marker>(mainPage)
    static member inline ContentPage<'msg, 'marker when 'marker :> IView>(title, content) = ViewBuilders.ContentPage<'msg, 'marker>(title, content)
    static member inline HorizontalStackLayout<'msg>(?spacing) = ViewBuilders.StackLayout<'msg>(Xamarin.Forms.StackOrientation.Horizontal, ?spacing = spacing)
    static member inline VerticalStackLayout<'msg>(?spacing) = ViewBuilders.StackLayout<'msg>(Xamarin.Forms.StackOrientation.Vertical, ?spacing = spacing)
    static member inline Grid<'msg>() = ViewBuilders.Grid<'msg>([Star], [Star])
    static member inline Grid<'msg>(coldefs, rowdefs) = ViewBuilders.Grid<'msg>(coldefs, rowdefs)
    static member inline Label<'msg>(text) = ViewBuilders.Label<'msg>(text)
    static member inline Button<'msg>(text, onClicked) = ViewBuilders.Button<'msg>(text, onClicked)
    static member inline Switch<'msg>(isToggled, onToggled) = ViewBuilders.Switch<'msg>(isToggled, onToggled)
    static member inline Slider<'msg>(min, max, value, onValueChanged) = ViewBuilders.Slider<'msg>(min, max, value, onValueChanged)
    static member inline ActivityIndicator<'msg>(isRunning) = ViewBuilders.ActivityIndicator<'msg>(isRunning)
    static member inline ContentView<'msg, 'marker when 'marker :> IView>(content) = ViewBuilders.ContentView<'msg, 'marker>(content)
    static member inline RefreshView<'msg, 'marker when 'marker :> IView>(isRefreshing, onRefreshing, content) = ViewBuilders.RefreshView<'msg, 'marker>(isRefreshing, onRefreshing, content)
    static member inline ScrollView<'msg, 'marker when 'marker :> IView>(content) = ViewBuilders.ScrollView<'msg, 'marker>(content)
    static member inline Image<'msg>(imageSource, aspect) = ViewBuilders.SourceImage<'msg>(imageSource, aspect)
    static member inline Image<'msg>(path, aspect) = ViewBuilders.FileImage<'msg>(path, aspect)
    static member inline Image<'msg>(uri, aspect) = ViewBuilders.WebImage<'msg>(uri, aspect)
    static member inline Image<'msg>(stream, aspect) = ViewBuilders.StreamImage<'msg>(stream, aspect)
    static member inline BoxView<'msg>(color) = ViewBuilders.BoxView<'msg>(color)
    static member inline NavigationPage<'msg>() = ViewBuilders.NavigationPage<'msg>()
    static member inline Entry<'msg>(text, onTextChanged) = ViewBuilders.Entry<'msg>(text, onTextChanged)
    static member inline TapGestureRecognizer<'msg>(onTapped) = ViewBuilders.TapGestureRecognizer<'msg>(onTapped)
    static member inline SearchBar<'msg>(text, onTextChanged, onSearchButtonPressed) = ViewBuilders.SearchBar<'msg>(text, onTextChanged, onSearchButtonPressed)
    static member inline ToolbarItem<'msg>(text, onClicked) = ViewBuilders.ToolbarItem<'msg>(text, onClicked)
    static member inline Editor<'msg>(text, onTextChanged) = ViewBuilders.Editor<'msg>(text, onTextChanged)
    static member inline ViewCell<'msg, 'marker when 'marker :> IView>(content) = ViewBuilders.ViewCell<'msg, 'marker>(content)
    static member inline ImageButton<'msg>(imageSource, onClicked, aspect) = ViewBuilders.SourceImageButton<'msg>(imageSource, onClicked, aspect)
    static member inline ImageButton<'msg>(path, onClicked, aspect) = ViewBuilders.FileImageButton<'msg>(path, onClicked, aspect)
    static member inline ImageButton<'msg>(uri, onClicked, aspect) = ViewBuilders.WebImageButton<'msg>(uri, onClicked, aspect)
    static member inline ImageButton<'msg>(stream, onClicked, aspect) = ViewBuilders.StreamImageButton<'msg>(stream, onClicked, aspect)
    static member inline TabbedPage<'msg>(title) = ViewBuilders.TabbedPage<'msg>(title)
    
[<Extension>]
type CollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IPage>(_: CollectionBuilder<'msg, 'marker, IPage>, x: WidgetBuilder<'msg, 'itemType>) : Content<'msg> =
        { Widgets = [ x.Compile() ] }
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'itemType :> IView>(_: CollectionBuilder<'msg, 'marker, IView>, x: WidgetBuilder<'msg, 'itemType>) : Content<'msg> =
        { Widgets = [ x.Compile() ] }
        

[<Extension; AbstractClass; Sealed>]
type ViewExtensions private () =
    [<Extension>]
    static member inline userAppTheme(this: WidgetBuilder<_, #IApplication>, value: Xamarin.Forms.OSAppTheme) =
        this.AddScalar(Application.UserAppTheme.WithValue(value))
    [<Extension>]
    static member inline resources(this: WidgetBuilder<_, #IApplication>, value: Xamarin.Forms.ResourceDictionary) =
        this.AddScalar(Application.Resources.WithValue(value))
    [<Extension>]
    static member inline onRequestedThemeChanged(this: WidgetBuilder<_, #IApplication>, fn: Xamarin.Forms.AppThemeChangedEventArgs -> 'msg) =
        this.AddScalar(Application.RequestedThemeChanged.WithValue(fn >> box))
    [<Extension>]
    static member inline onModalPopped(this: WidgetBuilder<_, #IApplication>, fn: Xamarin.Forms.ModalPoppedEventArgs -> 'msg) =
        this.AddScalar(Application.ModalPopped.WithValue(fn >> box))
    [<Extension>]
    static member inline onModalPopping(this: WidgetBuilder<_, #IApplication>, fn: Xamarin.Forms.ModalPoppingEventArgs -> 'msg) =
        this.AddScalar(Application.ModalPopping.WithValue(fn >> box))
    [<Extension>]
    static member inline onModalPushed(this: WidgetBuilder<_, #IApplication>, fn: Xamarin.Forms.ModalPushedEventArgs -> 'msg) =
        this.AddScalar(Application.ModalPushed.WithValue(fn >> box))
    [<Extension>]
    static member inline onModalPushing(this: WidgetBuilder<_, #IApplication>, fn: Xamarin.Forms.ModalPushingEventArgs -> 'msg) =
        this.AddScalar(Application.ModalPushing.WithValue(fn >> box))
    [<Extension>]
    static member inline automationId(this: WidgetBuilder<_, #IView>, value: string) =
        this.AddScalar(Element.AutomationId.WithValue(value))
    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<_, #IView>, value: bool) =
        this.AddScalar(VisualElement.IsEnabled.WithValue(value))
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<_, #IView>, value: float) =
        this.AddScalar(VisualElement.Opacity.WithValue(value))
    [<Extension>]
    static member inline backgroundColor(this: WidgetBuilder<_, #IView>, value: Xamarin.Forms.Color) =
        this.AddScalar(VisualElement.BackgroundColor.WithValue(value))
    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<_, #IView>, value: bool) =
        this.AddScalar(VisualElement.IsVisible.WithValue(value))
    [<Extension>]
    static member inline horizontalOptions(this: WidgetBuilder<_, #IView>, value: Xamarin.Forms.LayoutOptions) =
        this.AddScalar(View.HorizontalOptions.WithValue(value))
    [<Extension>]
    static member inline verticalOptions(this: WidgetBuilder<_, #IView>, value: Xamarin.Forms.LayoutOptions) =
        this.AddScalar(View.VerticalOptions.WithValue(value))
    [<Extension>]
    static member inline margin(this: WidgetBuilder<_, #IView>, value: Xamarin.Forms.Thickness) =
        this.AddScalar(View.Margin.WithValue(value))
    [<Extension>]
    static member inline gestureRecognizers(this: WidgetBuilder<_, #IView>, value: seq<WidgetBuilder<'msg, #IGestureRecognizer>>) =
        this.AddWidgetCollection(View.GestureRecognizers.WithValue(compileSeq value))
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<_, #ILabel>, value: Xamarin.Forms.TextAlignment) =
        this.AddScalar(Label.HorizontalTextAlignment.WithValue(value))
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<_, #ILabel>, value: Xamarin.Forms.TextAlignment) =
        this.AddScalar(Label.VerticalTextAlignment.WithValue(value))
    [<Extension>]
    static member inline font(this: WidgetBuilder<_, #ILabel>, value: double) =
        this.AddScalar(Label.FontSize.WithValue(value))
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<_, #ILabel>, value: Xamarin.Forms.Color) =
        this.AddScalar(Label.TextColor.WithValue(value))
    [<Extension>]
    static member inline padding(this: WidgetBuilder<_, #IView>, value: Xamarin.Forms.Thickness) =
        this.AddScalar(Label.Padding.WithValue(value))
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<_, #IButton>, light: Xamarin.Forms.Color, ?dark: Xamarin.Forms.Color) =
        this.AddScalar(Button.TextColor.WithValue({ Light = light; Dark = match dark with None -> ValueNone | Some v -> ValueSome v }))
    [<Extension>]
    static member inline font<'marker when 'marker :> IButton>(this: WidgetBuilder<_, 'marker>, value: double) =
        this.AddScalar(Button.FontSize.WithValue(value))
    [<Extension>]
    static member inline paddingLayout(this: WidgetBuilder<_, #ILayout>, value: Xamarin.Forms.Thickness) =
        this.AddScalar(Layout.Padding.WithValue(value))
    [<Extension>]
    static member inline gridColumn(this: WidgetBuilder<_, #IView>, value: int) =
        this.AddScalar(Grid.Column.WithValue(value))
    [<Extension>]
    static member inline gridRow(this: WidgetBuilder<_, #IView>, value: int) =
        this.AddScalar(Grid.Row.WithValue(value))
    [<Extension>]
    static member inline columnSpacing(this: WidgetBuilder<_, #IGrid>, value: float) =
        this.AddScalar(Grid.ColumnSpacing.WithValue(value))
    [<Extension>]
    static member inline rowSpacing(this: WidgetBuilder<_, #IGrid>, value: float) =
        this.AddScalar(Grid.RowSpacing.WithValue(value))
    [<Extension>]
    static member inline gridColumnSpan(this: WidgetBuilder<_, #IView>, value: int) =
        this.AddScalar(Grid.ColumnSpan.WithValue(value))
    [<Extension>]
    static member inline gridRowSpan(this: WidgetBuilder<_, #IView>, value: int) =
        this.AddScalar(Grid.RowSpan.WithValue(value))
    [<Extension>]
    static member inline onSizeAllocated(this: WidgetBuilder<'msg, #IContentPage>, fn: SizeAllocatedEventArgs -> 'msg) =
        this.AddScalar(ContentPage.SizeAllocated.WithValue(fn >> box))
    [<Extension>]
    static member inline barBackgroundColor(this: WidgetBuilder<_, #INavigationPage>, value: Xamarin.Forms.Color) =
        this.AddScalar(NavigationPage.BarBackgroundColor.WithValue(value))
    [<Extension>]
    static member inline popped(this: WidgetBuilder<'msg, #INavigationPage>, value: 'msg) =
        this.AddScalar(NavigationPage.Popped.WithValue(fun _ -> box value))
    [<Extension>]
    static member inline barTextColor(this: WidgetBuilder<_, #INavigationPage>, value: Xamarin.Forms.Color) =
        this.AddScalar(NavigationPage.BarTextColor.WithValue(value))
    [<Extension>]
    static member inline height(this: WidgetBuilder<_, #IView>, value: float) =
        this.AddScalar(VisualElement.Height.WithValue(value))
    [<Extension>]
    static member inline width(this: WidgetBuilder<_, #IView>, value: float) =
        this.AddScalar(VisualElement.Width.WithValue(value))
    [<Extension>]
    static member inline placeholder(this: WidgetBuilder<_, #IEntry>, value: string) =
        this.AddScalar(Entry.Placeholder.WithValue(value))
    [<Extension>]
    static member inline keyboard(this: WidgetBuilder<_, #IEntry>, value: Xamarin.Forms.Keyboard) =
        this.AddScalar(Entry.Keyboard.WithValue(value))
    [<Extension>]
    static member inline title(this: WidgetBuilder<_, #IPage>, value: string) =
        this.AddScalar(Page.Title.WithValue(value))
    [<Extension>]
    static member inline fileIcon(this: WidgetBuilder<_, #IPage>, value: string) =
        this.AddScalar(Page.IconImageSource.WithValue(Xamarin.Forms.ImageSource.FromFile(value)))
    [<Extension>]
    static member inline onAppearing(this: WidgetBuilder<'msg, #IPage>, value: 'msg) =
        this.AddScalar(Page.Appearing.WithValue(value))
    [<Extension>]
    static member inline onDisappearing(this: WidgetBuilder<'msg, #IPage>, value: 'msg) =
        this.AddScalar(Page.Disappearing.WithValue(value))
    [<Extension>]
    static member inline onLayoutChanged(this: WidgetBuilder<'msg, #IPage>, value: 'msg) =
        this.AddScalar(Page.LayoutChanged.WithValue(value))
    [<Extension>]
    static member inline cancelButtonColor(this: WidgetBuilder<_, #ISearchBar>, value: Xamarin.Forms.Color) =
        this.AddScalar(SearchBar.CancelButtonColor.WithValue(value))
    [<Extension>]
    static member inline toolbarItems(this: WidgetBuilder<'msg, #IPage>, value: seq<WidgetBuilder<'msg, #IToolbarItem>>) =
        this.AddWidgetCollection(Page.ToolbarItems.WithValue(compileSeq value))
    [<Extension>]
    static member inline order(this: WidgetBuilder<'msg, #IToolbarItem>, value: Xamarin.Forms.ToolbarItemOrder) =
        this.AddScalar(ToolbarItem.Order.WithValue(value))
    [<Extension>]
    static member inline lineBreakMode(this: WidgetBuilder<'msg, #ILabel>, value: Xamarin.Forms.LineBreakMode) =
        this.AddScalar(Label.LineBreakMode.WithValue(value))
    [<Extension>]
    static member inline hasNavigationBar(this: WidgetBuilder<'msg, #IPage>, value: bool) =
        this.AddScalar(NavigationPage.HasNavigationBar.WithValue(value))
    [<Extension>]
    static member inline hasBackButton(this: WidgetBuilder<'msg, #IPage>, value: bool) =
        this.AddScalar(NavigationPage.HasBackButton.WithValue(value))
        