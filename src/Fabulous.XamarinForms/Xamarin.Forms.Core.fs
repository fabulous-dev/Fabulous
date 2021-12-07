namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.XFAttributes
open System.Runtime.CompilerServices
open System.IO
open Fabulous.Attributes
open Xamarin.Forms

module ViewHelpers =
    let inline compileSeq (items: seq<#IWidgetBuilder<'msg>>) =
        items
        |> Seq.map (fun item -> item.Compile())
        |> Seq.toArray
    
type ILabelWidgetBuilder<'msg> = inherit IViewWidgetBuilder<'msg>
type IEntryWidgetBuilder<'msg> = inherit IViewWidgetBuilder<'msg>

type [<Struct>] Application<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.Application>()
    member _.Builder = attrs

    static member inline Create(mainPage: IPageWidgetBuilder<'msg>) =
        Application<'msg>(
            AttributesBuilder(
                [||],
                [| Application.MainPage.WithValue(mainPage.Compile()) |],
                [||]
            )
        )

    interface IApplicationWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)

type [<Struct>] ContentPage<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<FabulousContentPage>()

    member _.Builder = attrs

    member _.MapMsg<'newMsg>(fn: 'msg -> 'newMsg) =
        let xFn = 
            match attrs.TryGetScalar(MapMsg.Key) with
            | None -> fun msg -> unbox msg |> fn |> box
            | Some attr -> fun msg -> msg |> (unbox<obj -> obj> attr.Value) |> unbox |> fn |> box

        let newAttrs = attrs.AddScalar(MapMsg.WithValue(xFn))
        ContentPage<'newMsg>(newAttrs)

    static member inline Create(title: string, content: IViewWidgetBuilder<'msg>) =
        ContentPage<'msg>(
            AttributesBuilder(
                [| Page.Title.WithValue(title) |],
                [| ContentPage.Content.WithValue(content.Compile()) |],
                [||]
            )
        )
    
    interface IPageWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
    
type [<Struct>] StackLayout<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.StackLayout>()
    member _.Builder = attrs
          
    static member inline Create(orientation: Xamarin.Forms.StackOrientation, children: seq<IViewWidgetBuilder<'msg>>, ?spacing: float) =
        StackLayout<'msg>(
            AttributesBuilder(
                [|
                    StackLayout.Orientation.WithValue(orientation)
                    match spacing with None -> () | Some v -> StackLayout.Spacing.WithValue(v)
                |],
                [||],
                [|
                    LayoutOfView.Children.WithValue(ViewHelpers.compileSeq children)
                |]
            )
        )

    static member inline CreateVertical(children: seq<IViewWidgetBuilder<'msg>>, ?spacing: float) =
        StackLayout<'msg>.Create(Xamarin.Forms.StackOrientation.Vertical, children, ?spacing = spacing)
        
    static member inline CreateHorizontal(children: seq<IViewWidgetBuilder<'msg>>, ?spacing: float) =
        StackLayout<'msg>.Create(Xamarin.Forms.StackOrientation.Horizontal, children, ?spacing = spacing)

    interface ILayoutWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] Grid<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.Grid>()
    member _.Builder = attrs
                        
    static member inline Create(children: seq<IViewWidgetBuilder<'msg>>, ?coldefs: seq<Dimension>, ?rowdefs: seq<Dimension>) =
        Grid<'msg>(
            AttributesBuilder(
                [|
                    match coldefs with None -> () | Some v -> Grid.ColumnDefinitions.WithValue(v)
                    match rowdefs with None -> () | Some v -> Grid.RowDefinitions.WithValue(v)
                |],
                [||],
                [| LayoutOfView.Children.WithValue(ViewHelpers.compileSeq children) |]
            )
        )
              
    interface ILayoutWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)


type [<Struct>] Label<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.Label>()
    member _.Builder = attrs

    static member inline Create(text: string) =
        Label<'msg>(AttributesBuilder([| Label.Text.WithValue(text) |], [||], [||]))

    interface ILabelWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)

type [<Struct>] Button<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.Button>()
    member _.Builder = attrs

    static member inline Create(text: string, onClicked: 'msg) =
        Button<'msg>(
            AttributesBuilder(
                [|
                    Button.Text.WithValue(text)
                    Button.Clicked.WithValue(onClicked)
                |],
                [||],
                [||]
            )
        )

    interface IViewWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)

type [<Struct>] Switch<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.Switch>()
    member _.Builder = attrs

    static member inline Create(isToggled: bool, onToggled: bool -> 'msg) =
        Switch<'msg>(
            AttributesBuilder(
                [|
                    Switch.IsToggled.WithValue(isToggled)
                    Switch.Toggled.WithValue(fun args -> onToggled args.Value |> box)
                |],
                [||],
                [||]
            )
        )
        
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] Slider<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.Slider>()
    member _.Builder = attrs
              
    static member inline Create(value: float, onValueChanged: float -> 'msg, ?min: float, ?max: float) =
        Slider<'msg>(
            AttributesBuilder(
                [|
                    Slider.Value.WithValue(value)
                    Slider.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box)

                    match struct (min, max) with
                    | None, None -> ()
                    | Some minV, Some maxV -> Slider.MinimumMaximum.WithValue(minV, maxV)
                    | _ -> failwith "Both min and max are required"
                |],
                [||],
                [||]
            )
        )
                      
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] ActivityIndicator<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.ActivityIndicator>()
    member _.Builder = attrs
              
    static member inline Create(isRunning: bool) =
        ActivityIndicator<'msg>(
            AttributesBuilder(
                [| ActivityIndicator.IsRunning.WithValue(isRunning) |],
                [||],
                [||]
            )
        )
                      
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] ContentView<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.ContentView>()
    member _.Builder = attrs
              
    static member inline Create(content: IViewWidgetBuilder<'msg>) =
        ContentView<'msg>(
            AttributesBuilder(
                [||],
                [| ContentView.Content.WithValue(content.Compile()) |],
                [||]
            )
        )
                      
    interface ILayoutWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] RefreshView<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.RefreshView>()
    member _.Builder = attrs
              
    static member inline Create(isRefreshing: bool, onRefreshing: 'msg, content: IViewWidgetBuilder<'msg>) =
        RefreshView<'msg>(
            AttributesBuilder(
                [|
                    RefreshView.IsRefreshing.WithValue(isRefreshing)
                    RefreshView.Refreshing.WithValue(onRefreshing)
                |],
                [| ContentView.Content.WithValue(content.Compile()) |],
                [||]
            )
        )
                      
    interface ILayoutWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] ScrollView<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.ScrollView>()
    member _.Builder = attrs
              
    static member inline Create(content: IViewWidgetBuilder<'msg>) =
        ScrollView<'msg>(
            AttributesBuilder(
                [||],
                [| ScrollView.Content.WithValue(content.Compile()) |],
                [||]
            )
        )
                      
    interface ILayoutWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] Image<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.Image>()
    member _.Builder = attrs

    static member inline Create(imageSource: Xamarin.Forms.ImageSource, aspect: Xamarin.Forms.Aspect) =
        Image<'msg>(
            AttributesBuilder(
                [|
                    Image.Source.WithValue(imageSource)
                    Image.Aspect.WithValue(aspect)
                |],
                [||],
                [||]
            )
        )

    static member inline Create(path: string, aspect: Xamarin.Forms.Aspect) =
        Image<'msg>.Create(Xamarin.Forms.ImageSource.FromFile(path), aspect)
        
    static member inline Create(uri: System.Uri, aspect: Xamarin.Forms.Aspect) =
        Image<'msg>.Create(Xamarin.Forms.ImageSource.FromUri(uri), aspect)
        
    static member inline Create(stream: Stream, aspect: Xamarin.Forms.Aspect) =
        Image<'msg>.Create(Xamarin.Forms.ImageSource.FromStream(fun () -> stream), aspect)
                      
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] BoxView<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.BoxView>()
    member _.Builder = attrs
              
    static member inline Create(color: Xamarin.Forms.Color) =
        BoxView<'msg>(
            AttributesBuilder(
                [|
                    BoxView.Color.WithValue(color)
                |],
                [||],
                [||]
            )
        )
                      
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] NavigationPage<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.NavigationPage>()
    member _.Builder = attrs
              
    static member inline Create(pages: seq<IPageWidgetBuilder<'msg>>) =
        NavigationPage<'msg>(
            AttributesBuilder(
                [||],
                [||],
                [| NavigationPage.Pages.WithValue(ViewHelpers.compileSeq pages) |]
            )
        )
                      
    interface IPageWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)

type [<Struct>] Entry<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.Entry>()
    member _.Builder = attrs
                            
    static member inline Create(text: string, onTextChanged: string -> 'msg) =
        Entry<'msg>(
            AttributesBuilder(
                [| Entry.Text.WithValue(text)
                   Entry.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box) |],
                [||],
                [||]
            )
        )
                                    
    interface IEntryWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)

type [<Struct>] TapGestureRecognizer<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.TapGestureRecognizer>()
    member _.Builder = attrs
              
    static member inline Create(onTapped: 'msg) =
        TapGestureRecognizer<'msg>(
            AttributesBuilder(
                [| TapGestureRecognizer.Tapped.WithValue(onTapped) |],
                [||],
                [||]
            )
        )
                      
    interface IGestureRecognizerWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] SearchBar<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.SearchBar>()
    member _.Builder = attrs
                            
    static member inline Create(text: string, onTextChanged: string -> 'msg, onSearchButtonPressed: 'msg) =
        SearchBar<'msg>(
            AttributesBuilder(
                [| SearchBar.Text.WithValue(text)
                   InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box)
                   SearchBar.SearchButtonPressed.WithValue(onSearchButtonPressed) |],
                [||],
                [||]
            )
        )
                                    
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)

type [<Struct>] ToolbarItem<'msg> (attrs: AttributesBuilder)=
    static let key = Widgets.register<Xamarin.Forms.ToolbarItem>()
    member _.Builder = attrs
                            
    static member inline Create(text: string, onClicked: 'msg) =
        ToolbarItem<'msg>(
            AttributesBuilder(
                [| MenuItem.Text.WithValue(text)
                   MenuItem.Clicked.WithValue(onClicked) |],
                [||],
                [||]
            )
        )
                                    
    interface IToolbarItemWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] Editor<'msg> (attrs: AttributesBuilder)=
    static let key = Widgets.register<Xamarin.Forms.Editor>()
    member _.Builder = attrs
                                          
    static member inline Create(text: string, onTextChanged: string -> 'msg) =
        Editor<'msg>(
            AttributesBuilder(
                [| Editor.Text.WithValue(text)
                   InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box) |],
                [||],
                [||]
            )
        )
                                                  
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] ViewCell<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.ViewCell>()
    member _.Builder = attrs
                                          
    static member inline Create(view: #IViewWidgetBuilder<'msg>) =
        ViewCell<'msg>(
            AttributesBuilder(
                [||],
                [| ViewCell.View.WithValue(view.Compile()) |],
                [||]
            )
        )
                                                  
    interface ICellWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] ImageButton<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.ImageButton>()
    member _.Builder = attrs
                                          
    static member inline Create(source: Xamarin.Forms.ImageSource, onClicked: 'msg, aspect: Xamarin.Forms.Aspect) =
        ImageButton<'msg>(
            AttributesBuilder(
                [| ImageButton.Source.WithValue(source)
                   ImageButton.Clicked.WithValue(onClicked)
                   ImageButton.Aspect.WithValue(aspect) |],
                [||],
                [||]
            )
        )

    static member inline Create(path: string, onClicked, aspect) =
        ImageButton<'msg>.Create(Xamarin.Forms.ImageSource.FromFile(path), onClicked, aspect)
                                                  
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)
              
type [<Struct>] TabbedPage<'msg> (attrs: AttributesBuilder) =
    static let key = Widgets.register<Xamarin.Forms.TabbedPage>()

    member _.Builder = attrs
    
    member _.MapMsg<'newMsg>(fn: 'msg -> 'newMsg) =
        let xFn = 
            match attrs.TryGetScalar(MapMsg.Key) with
            | None -> fun msg -> unbox msg |> fn |> box
            | Some attr -> fun msg -> msg |> (unbox<obj -> obj> attr.Value) |> unbox |> fn |> box
            
        let newAttrs = attrs.AddScalar(MapMsg.WithValue(xFn))
        TabbedPage<'newMsg>(newAttrs)
                                          
    static member inline Create(title: string, children: #seq<IPageWidgetBuilder<'msg>>) =
        TabbedPage<'msg>(
            AttributesBuilder(
                [| Page.Title.WithValue(title) |],
                [||],
                [| MultiPageOfPage.Children.WithValue(ViewHelpers.compileSeq children) |]
            )
        )
                                                  
    interface IPageWidgetBuilder<'msg> with
        member x.Compile() = attrs.Build(key)

[<Extension>]
type ViewExtensions () =

    [<Extension>]
    static member inline userAppTheme(this: #IApplicationWidgetBuilder<_>, value: OSAppTheme) =
        this.AddScalarAttribute(Application.UserAppTheme.WithValue(value))
    [<Extension>]
    static member inline resources(this: #IApplicationWidgetBuilder<_>, value: ResourceDictionary) =
        this.AddScalarAttribute(Application.Resources.WithValue(value))
    [<Extension>]
    static member inline onRequestedThemeChanged(this: #IApplicationWidgetBuilder<_>, fn: AppThemeChangedEventArgs -> 'msg) =
        this.AddScalarAttribute(Application.RequestedThemeChanged.WithValue(fn >> box))
    [<Extension>]
    static member inline onModalPopped(this: #IApplicationWidgetBuilder<_>, fn: ModalPoppedEventArgs -> 'msg) =
        this.AddScalarAttribute(Application.ModalPopped.WithValue(fn >> box))
    [<Extension>]
    static member inline onModalPopping(this: #IApplicationWidgetBuilder<_>, fn: ModalPoppingEventArgs -> 'msg) =
        this.AddScalarAttribute(Application.ModalPopping.WithValue(fn >> box))
    [<Extension>]
    static member inline onModalPushed(this: #IApplicationWidgetBuilder<_>, fn: ModalPushedEventArgs -> 'msg) =
        this.AddScalarAttribute(Application.ModalPushed.WithValue(fn >> box))
    [<Extension>]
    static member inline onModalPushing(this: #IApplicationWidgetBuilder<_>, fn: ModalPushingEventArgs -> 'msg) =
        this.AddScalarAttribute(Application.ModalPushing.WithValue(fn >> box))
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
    static member inline isVisible(this: #IViewWidgetBuilder<_>, value: bool) =
        this.AddScalarAttribute(VisualElement.IsVisible.WithValue(value))
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
    static member inline gestureRecognizers(this: #IViewWidgetBuilder<_>, value: #seq<IGestureRecognizerWidgetBuilder<'msg>>) =
        this.AddWidgetCollectionAttribute(View.GestureRecognizers.WithValue(ViewHelpers.compileSeq value))
    [<Extension>]
    static member inline horizontalTextAlignment(this: #ILabelWidgetBuilder<_>, value: Xamarin.Forms.TextAlignment) =
        this.AddScalarAttribute(Label.HorizontalTextAlignment.WithValue(value))
    [<Extension>]
    static member inline verticalTextAlignment(this: #ILabelWidgetBuilder<_>, value: Xamarin.Forms.TextAlignment) =
        this.AddScalarAttribute(Label.VerticalTextAlignment.WithValue(value))
    [<Extension>]
    static member inline font(this: #ILabelWidgetBuilder<_>, value: double) =
        this.AddScalarAttribute(Label.FontSize.WithValue(value))
    [<Extension>]
    static member inline textColor(this: #ILabelWidgetBuilder<_>, value: Xamarin.Forms.Color) =
        this.AddScalarAttribute(Label.TextColor.WithValue(value))
    [<Extension>]
    static member inline padding(this: #ILabelWidgetBuilder<_>, value: Xamarin.Forms.Thickness) =
        this.AddScalarAttribute(Label.Padding.WithValue(value))
    [<Extension>]
    static member inline textColor(this: Button<_>, light: Xamarin.Forms.Color, ?dark: Xamarin.Forms.Color) =
        this.AddScalarAttribute(Button.TextColor.WithValue({ Light = light; Dark = match dark with None -> ValueNone | Some v -> ValueSome v }))
    [<Extension>]
    static member inline font(this: Button<_>, value: double) =
        this.AddScalarAttribute(Button.FontSize.WithValue(value))
    [<Extension>]
    static member inline paddingLayout(this: #ILayoutWidgetBuilder<_>, value: Xamarin.Forms.Thickness) =
        this.AddScalarAttribute(Layout.Padding.WithValue(value))
    [<Extension>]
    static member inline gridColumn(this: #IViewWidgetBuilder<_>, value: int) =
        this.AddScalarAttribute(Grid.Column.WithValue(value))
    [<Extension>]
    static member inline gridRow(this: #IViewWidgetBuilder<_>, value: int) =
        this.AddScalarAttribute(Grid.Row.WithValue(value))
    [<Extension>]
    static member inline columnSpacing(this: Grid<_>, value: float) =
        this.AddScalarAttribute(Grid.ColumnSpacing.WithValue(value))
    [<Extension>]
    static member inline rowSpacing(this: Grid<_>, value: float) =
        this.AddScalarAttribute(Grid.RowSpacing.WithValue(value))
    [<Extension>]
    static member inline gridColumnSpan(this: #IViewWidgetBuilder<_>, value: int) =
        this.AddScalarAttribute(Grid.ColumnSpan.WithValue(value))
    [<Extension>]
    static member inline gridRowSpan(this: #IViewWidgetBuilder<_>, value: int) =
        this.AddScalarAttribute(Grid.RowSpan.WithValue(value))
    [<Extension>]
    static member inline onSizeAllocated(this: ContentPage<'msg>, fn: SizeAllocatedEventArgs -> 'msg) =
        this.AddScalarAttribute(ContentPage.SizeAllocated.WithValue(fn >> box))
    [<Extension>]
    static member inline barBackgroundColor(this: NavigationPage<_>, value: Xamarin.Forms.Color) =
        this.AddScalarAttribute(NavigationPage.BarBackgroundColor.WithValue(value))
    [<Extension>]
    static member inline barTextColor(this: NavigationPage<_>, value: Xamarin.Forms.Color) =
        this.AddScalarAttribute(NavigationPage.BarTextColor.WithValue(value))
    [<Extension>]
    static member inline height(this: #IViewWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(VisualElement.Height.WithValue(value))
    [<Extension>]
    static member inline width(this: #IViewWidgetBuilder<_>, value: float) =
        this.AddScalarAttribute(VisualElement.Width.WithValue(value))
    [<Extension>]
    static member inline placeholder(this: #IEntryWidgetBuilder<_>, value: string) =
        this.AddScalarAttribute(Entry.Placeholder.WithValue(value))
    [<Extension>]
    static member inline keyboard(this: #IEntryWidgetBuilder<_>, value: Xamarin.Forms.Keyboard) =
        this.AddScalarAttribute(Entry.Keyboard.WithValue(value))
    [<Extension>]
    static member inline title(this: #IPageWidgetBuilder<_>, value: string) =
        this.AddScalarAttribute(Page.Title.WithValue(value))
    [<Extension>]
    static member inline fileIcon(this: #IPageWidgetBuilder<_>, value: string) =
        this.AddScalarAttribute(Page.IconImageSource.WithValue(Xamarin.Forms.ImageSource.FromFile(value)))
    [<Extension>]
    static member inline onAppearing(this: #IPageWidgetBuilder<'msg>, value: 'msg) =
        this.AddScalarAttribute(Page.Appearing.WithValue(value))
    [<Extension>]
    static member inline onDisappearing(this: #IPageWidgetBuilder<'msg>, value: 'msg) =
        this.AddScalarAttribute(Page.Disappearing.WithValue(value))
    [<Extension>]
    static member inline onLayoutChanged(this: #IPageWidgetBuilder<'msg>, value: 'msg) =
        this.AddScalarAttribute(Page.LayoutChanged.WithValue(value))
    [<Extension>]
    static member inline cancelButtonColor(this: SearchBar<_>, value: Xamarin.Forms.Color) =
        this.AddScalarAttribute(SearchBar.CancelButtonColor.WithValue(value))
    [<Extension>]
    static member inline toolbarItems(this: #IPageWidgetBuilder<'msg>, value: #seq<IToolbarItemWidgetBuilder<'msg>>) =
        this.AddWidgetCollectionAttribute(Page.ToolbarItems.WithValue(ViewHelpers.compileSeq value))
    [<Extension>]
    static member inline order(this: ToolbarItem<'msg>, value: Xamarin.Forms.ToolbarItemOrder) =
        this.AddScalarAttribute(ToolbarItem.Order.WithValue(value))
    [<Extension>]
    static member inline lineBreakMode(this: Label<'msg>, value: Xamarin.Forms.LineBreakMode) =
        this.AddScalarAttribute(Label.LineBreakMode.WithValue(value))
    [<Extension>]
    static member inline popped(this: NavigationPage<'msg>, value: 'msg) =
        this.AddScalarAttribute(NavigationPage.Popped.WithValue(fun _ -> box value))

    [<Extension>]
    static member inline hasNavigationBar(this: #IPageWidgetBuilder<'msg>, value: bool) =
        this.AddScalarAttribute(NavigationPage.HasNavigationBar.WithValue(value))

    [<Extension>]
    static member inline hasBackButton(this: #IPageWidgetBuilder<'msg>, value: bool) =
        this.AddScalarAttribute(NavigationPage.HasBackButton.WithValue(value))

[<AbstractClass; Sealed>]
type View private () =
    static member inline Application<'msg>(mainPage) = Application<'msg>.Create(mainPage)
    static member inline ContentPage<'msg>(title, content) = ContentPage<'msg>.Create(title, content)
    static member inline VerticalStackLayout<'msg>(children) = StackLayout<'msg>.CreateVertical(children)
    static member inline VerticalStackLayout<'msg>(spacing: float, children) = StackLayout<'msg>.CreateVertical(children, spacing = spacing)
    static member inline HorizontalStackLayout<'msg>(children) = StackLayout<'msg>.CreateHorizontal(children)
    static member inline HorizontalStackLayout<'msg>(spacing: float, children) = StackLayout<'msg>.CreateHorizontal(children, spacing = spacing)
    static member inline Label<'msg>(text) = Label<'msg>.Create(text)
    static member inline Button<'msg>(text, onClicked) = Button<'msg>.Create(text, onClicked)
    static member inline Switch<'msg>(isToggled, onToggled) = Switch<'msg>.Create(isToggled, onToggled)
    static member inline Slider<'msg>(value, onValueChanged) = Slider<'msg>.Create(value, onValueChanged)
    static member inline Slider<'msg>(min, max, value, onValueChanged) = Slider<'msg>.Create(value, onValueChanged, min = min, max = max)
    static member inline Grid<'msg>(children) = Grid<'msg>.Create(children)
    static member inline Grid<'msg>(coldefs, rowdefs, children) = Grid<'msg>.Create(children, coldefs = coldefs, rowdefs = rowdefs)
    static member inline ActivityIndicator<'msg>(isRunning) = ActivityIndicator<'msg>.Create(isRunning)
    static member inline ContentView<'msg>(content) = ContentView<'msg>.Create(content)
    static member inline RefreshView<'msg>(isRefreshing, onRefreshing, content) = RefreshView<'msg>.Create(isRefreshing, onRefreshing, content)
    static member inline ScrollView<'msg>(content) = ScrollView<'msg>.Create(content)
    static member inline Image<'msg>(path: string, aspect) = Image<'msg>.Create(path, aspect)
    static member inline Image<'msg>(uri: System.Uri, aspect) = Image<'msg>.Create(uri, aspect)
    static member inline Image<'msg>(stream: Stream, aspect) = Image<'msg>.Create(stream, aspect)
    static member inline BoxView<'msg>(color) = BoxView<'msg>.Create(color)
    static member inline NavigationPage<'msg>(pages) = NavigationPage<'msg>.Create(pages)
    static member inline Entry<'msg>(text, onTextChanged) = Entry<'msg>.Create(text, onTextChanged)
    static member inline TapGestureRecognizer<'msg>(onTapped) = TapGestureRecognizer<'msg>.Create(onTapped)
    static member inline SearchBar<'msg>(text, onTextChanged, onSearchButtonPressed) = SearchBar<'msg>.Create(text, onTextChanged, onSearchButtonPressed)
    static member inline ToolbarItem<'msg>(text, onClicked) = ToolbarItem<'msg>.Create(text, onClicked)
    static member inline Editor<'msg>(text, onTextChanged) = Editor<'msg>.Create(text, onTextChanged)
    static member inline ViewCell<'msg>(view) = ViewCell<'msg>.Create(view)
    static member inline ImageButton<'msg>(path: string, onClicked, aspect) = ImageButton<'msg>.Create(path, onClicked, aspect)
    static member inline TabbedPage<'msg>(title, children) = TabbedPage<'msg>.Create(title, children)
