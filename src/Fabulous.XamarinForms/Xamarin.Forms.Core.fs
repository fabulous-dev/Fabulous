namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList
open Fabulous.XamarinForms
open Fabulous.XamarinForms.XFAttributes
open System.Runtime.CompilerServices
open System
open System.IO
open Microsoft.FSharp.Core

type IContentPage =
    inherit IPage

type IStackLayout =
    inherit ILayout

type IGrid =
    inherit ILayout

type ILabel =
    inherit IView

type IButton =
    inherit IView

type ISwitch =
    inherit IView

type ISlider =
    inherit IView

type IActivityIndicator =
    inherit IView

type IContentView =
    inherit ILayout

type IRefreshView =
    inherit IView

type IScrollView =
    inherit IView

type IImage =
    inherit IView

type IBoxView =
    inherit IView

type INavigationPage =
    inherit IPage

type IEntry =
    inherit IView

type ITapGestureRecognizer =
    inherit IGestureRecognizer

type ISearchBar =
    inherit IView

type IEditor =
    inherit IView

type IViewCell =
    inherit ICell

type IImageButton =
    inherit IView

type ITabbedPage =
    inherit IPage

type IDatePicker =
    inherit IView

type ITimePicker =
    inherit IView

type IStepper =
    inherit IView
    
type IListView =
    inherit IView

type ITextCell =
    inherit ICell

module ViewKeys =
    let Application =
        Widgets.register<Xamarin.Forms.Application>()

    let ContentPage = Widgets.register<FabulousContentPage>()

    let StackLayout =
        Widgets.register<Xamarin.Forms.StackLayout>()

    let Grid = Widgets.register<Xamarin.Forms.Grid>()
    let Label = Widgets.register<Xamarin.Forms.Label>()
    let Button = Widgets.register<Xamarin.Forms.Button>()
    let Switch = Widgets.register<Xamarin.Forms.Switch>()
    let Slider = Widgets.register<Xamarin.Forms.Slider>()

    let ActivityIndicator =
        Widgets.register<Xamarin.Forms.ActivityIndicator>()

    let ContentView =
        Widgets.register<Xamarin.Forms.ContentView>()

    let RefreshView =
        Widgets.register<Xamarin.Forms.RefreshView>()

    let ScrollView =
        Widgets.register<Xamarin.Forms.ScrollView>()

    let Image = Widgets.register<Xamarin.Forms.Image>()

    let BoxView =
        Widgets.register<Xamarin.Forms.BoxView>()

    let NavigationPage =
        Widgets.register<Xamarin.Forms.NavigationPage>()

    let Entry = Widgets.register<Xamarin.Forms.Entry>()

    let TapGestureRecognizer =
        Widgets.register<Xamarin.Forms.TapGestureRecognizer>()

    let SearchBar =
        Widgets.register<Xamarin.Forms.SearchBar>()

    let ToolbarItem =
        Widgets.register<Xamarin.Forms.ToolbarItem>()

    let Editor = Widgets.register<Xamarin.Forms.Editor>()

    let ViewCell =
        Widgets.register<Xamarin.Forms.ViewCell>()

    let ImageButton =
        Widgets.register<Xamarin.Forms.ImageButton>()

    let TabbedPage =
        Widgets.register<Xamarin.Forms.TabbedPage>()

    let DatePicker =
        Widgets.register<Xamarin.Forms.DatePicker>()

    let TimePicker = Widgets.register<FabulousTimePicker>()
    let Stepper = Widgets.register<Xamarin.Forms.Stepper>()
    let TextCell = Widgets.register<Xamarin.Forms.TextCell>()
    let ListView = Widgets.registerWithAdditionalSetup<FabulousListView>(fun target node ->
        target.ItemTemplate <- WidgetDataTemplateSelector(node)
    )

[<AbstractClass; Sealed>]
type ViewBuilders private () =
    static member inline Application<'msg, 'marker when 'marker :> IPage>(mainPage: WidgetBuilder<'msg, 'marker>) =
        ViewHelpers.buildWidgets<'msg, IApplication>
            ViewKeys.Application
            [|
                Application.MainPage.WithValue(mainPage.Compile())
            |]

    static member inline ContentPage<'msg, 'marker when 'marker :> IView>
        (
            title: string,
            content: WidgetBuilder<'msg, 'marker>
        ) =
        WidgetBuilder<'msg, IContentPage>(
            ViewKeys.ContentPage,
            AttributesBundle(
                StackList.one(Page.Title.WithValue(title)),
                ValueSome [| ContentPage.Content.WithValue(content.Compile()) |],
                ValueNone
            )
        )

    static member inline StackLayout<'msg>(orientation: Xamarin.Forms.StackOrientation, ?spacing: float) =
        match spacing with
        | None ->
            CollectionBuilder<'msg, IStackLayout, IView>(
                ViewKeys.StackLayout,
                LayoutOfView.Children,
                StackLayout.Orientation.WithValue(orientation)
            )

        | Some v ->
            CollectionBuilder<'msg, IStackLayout, IView>(
                ViewKeys.StackLayout,
                LayoutOfView.Children,
                StackLayout.Orientation.WithValue(orientation),
                StackLayout.Spacing.WithValue(v)
            )


    static member inline Grid<'msg>(coldefs: seq<Dimension>, rowdefs: seq<Dimension>) =
        CollectionBuilder<'msg, IGrid, IView>(
            ViewKeys.Grid,
            LayoutOfView.Children,
            Grid.ColumnDefinitions.WithValue(coldefs),
            Grid.RowDefinitions.WithValue(rowdefs)
        )

    static member inline Label<'msg>(text: string) =
        WidgetBuilder<'msg, ILabel>(ViewKeys.Label, Label.Text.WithValue(text))


    static member inline Button<'msg>(text: string, onClicked: 'msg) =
        WidgetBuilder<'msg, IButton>(ViewKeys.Button, Button.Text.WithValue(text), Button.Clicked.WithValue(onClicked))

    static member inline Switch<'msg>(isToggled: bool, onToggled: bool -> 'msg) =
        WidgetBuilder<'msg, ISwitch>(
            ViewKeys.Switch,
            Switch.IsToggled.WithValue(isToggled),
            Switch.Toggled.WithValue(fun args -> onToggled args.Value |> box)
        )

    static member inline Slider<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
        WidgetBuilder<'msg, ISlider>(
            ViewKeys.Slider,
            Slider.Value.WithValue(value),
            Slider.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box),
            Slider.MinimumMaximum.WithValue(min, max)
        )

    static member inline ActivityIndicator<'msg>(isRunning: bool) =
        WidgetBuilder<'msg, IActivityIndicator>(
            ViewKeys.ActivityIndicator,
            ActivityIndicator.IsRunning.WithValue(isRunning)
        )

    static member inline ContentView<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
        ViewHelpers.buildWidgets<'msg, IContentView>
            ViewKeys.ContentView
            [|
                ContentView.Content.WithValue(content.Compile())
            |]

    static member inline RefreshView<'msg, 'marker when 'marker :> IView>
        (
            isRefreshing: bool,
            onRefreshing: 'msg,
            content: WidgetBuilder<'msg, 'marker>
        ) =
        WidgetBuilder<'msg, IRefreshView>(
            ViewKeys.RefreshView,

            AttributesBundle(
                StackList.two(
                    RefreshView.IsRefreshing.WithValue(isRefreshing),
                    RefreshView.Refreshing.WithValue(onRefreshing)
                ),
                ValueSome [| ContentView.Content.WithValue(content.Compile()) |],
                ValueNone
            )
        )

    static member inline ScrollView<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
        ViewHelpers.buildWidgets<'msg, IScrollView>
            ViewKeys.ScrollView
            [|
                ScrollView.Content.WithValue(content.Compile())
            |]

    static member inline SourceImage<'msg>(imageSource: Xamarin.Forms.ImageSource, aspect: Xamarin.Forms.Aspect) =
        WidgetBuilder<'msg, IImage>(ViewKeys.Image, Image.Source.WithValue(imageSource), Image.Aspect.WithValue(aspect))

    static member inline FileImage<'msg>(path: string, aspect: Xamarin.Forms.Aspect) =
        ViewBuilders.SourceImage<'msg>(Xamarin.Forms.ImageSource.FromFile(path), aspect)

    static member inline WebImage<'msg>(uri: Uri, aspect: Xamarin.Forms.Aspect) =
        ViewBuilders.SourceImage<'msg>(Xamarin.Forms.ImageSource.FromUri(uri), aspect)

    static member inline StreamImage<'msg>(stream: Stream, aspect: Xamarin.Forms.Aspect) =
        ViewBuilders.SourceImage<'msg>(Xamarin.Forms.ImageSource.FromStream(fun () -> stream), aspect)

    static member inline BoxView<'msg>(color: Xamarin.Forms.Color) =
        WidgetBuilder<'msg, IBoxView>(ViewKeys.BoxView, BoxView.Color.WithValue(color))

    static member inline NavigationPage<'msg>() =
        CollectionBuilder<'msg, INavigationPage, IPage>(ViewKeys.NavigationPage, NavigationPage.Pages)

    static member inline Entry<'msg>(text: string, onTextChanged: string -> 'msg) =
        WidgetBuilder<'msg, IEntry>(
            ViewKeys.Entry,
            Entry.Text.WithValue(text),
            Entry.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box)
        )

    static member inline TapGestureRecognizer<'msg>(onTapped: 'msg) =
        WidgetBuilder<'msg, IGestureRecognizer>(
            ViewKeys.TapGestureRecognizer,
            TapGestureRecognizer.Tapped.WithValue(onTapped)
        )

    static member inline SearchBar<'msg>(text: string, onTextChanged: string -> 'msg, onSearchButtonPressed: 'msg) =
        WidgetBuilder<'msg, ISearchBar>(
            ViewKeys.SearchBar,
            SearchBar.Text.WithValue(text),
            InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box),
            SearchBar.SearchButtonPressed.WithValue(onSearchButtonPressed)
        )

    static member inline ToolbarItem<'msg>(text: string, onClicked: 'msg) =
        WidgetBuilder<'msg, IToolbarItem>(
            ViewKeys.ToolbarItem,
            MenuItem.Text.WithValue(text),
            MenuItem.Clicked.WithValue(onClicked)
        )

    static member inline Editor<'msg>(text: string, onTextChanged: string -> 'msg) =
        WidgetBuilder<'msg, IEditor>(
            ViewKeys.Editor,
            Editor.Text.WithValue(text),
            InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box)
        )

    static member inline ViewCell<'msg, 'marker when 'marker :> IView>(view: WidgetBuilder<'msg, 'marker>) =
        ViewHelpers.buildWidgets<'msg, IViewCell>
            ViewKeys.ViewCell
            [|
                ViewCell.View.WithValue(view.Compile())
            |]

    static member inline SourceImageButton<'msg>
        (
            source: Xamarin.Forms.ImageSource,
            onClicked: 'msg,
            aspect: Xamarin.Forms.Aspect
        ) =
        WidgetBuilder<'msg, IImageButton>(
            ViewKeys.ImageButton,
            ImageButton.Source.WithValue(source),
            ImageButton.Clicked.WithValue(onClicked),
            ImageButton.Aspect.WithValue(aspect)
        )

    static member inline FileImageButton<'msg>(path: string, onClicked, aspect) =
        ViewBuilders.SourceImageButton<'msg>(Xamarin.Forms.ImageSource.FromFile(path), onClicked, aspect)

    static member inline WebImageButton<'msg>(uri: Uri, onClicked, aspect) =
        ViewBuilders.SourceImageButton<'msg>(Xamarin.Forms.ImageSource.FromUri(uri), onClicked, aspect)

    static member inline StreamImageButton<'msg>(stream: Stream, onClicked, aspect) =
        ViewBuilders.SourceImageButton<'msg>(Xamarin.Forms.ImageSource.FromStream(fun () -> stream), onClicked, aspect)

    static member inline TabbedPage<'msg>(title: string) =
        CollectionBuilder<'msg, ITabbedPage, IPage>(
            ViewKeys.TabbedPage,
            MultiPageOfPage.Children,
            Page.Title.WithValue(title)
        )

    static member inline DatePicker<'msg>(date: DateTime, onDateSelected: DateTime -> 'msg) =
        WidgetBuilder<'msg, IDatePicker>(
            ViewKeys.DatePicker,
            DatePicker.Date.WithValue(date),
            DatePicker.DateSelected.WithValue(fun args -> onDateSelected args.NewDate |> box)
        )

    static member inline TimePicker<'msg>(time: TimeSpan, onTimeSelected: TimeSpan -> 'msg) =
        WidgetBuilder<'msg, ITimePicker>(
            ViewKeys.TimePicker,
            TimePicker.Time.WithValue(time),
            TimePicker.TimeSelected.WithValue(fun args -> onTimeSelected args.NewTime |> box)
        )

    static member inline Stepper<'msg>(min: float, max: float, value: float, onValueChanged: float -> 'msg) =
        WidgetBuilder<'msg, IStepper>(
            ViewKeys.Stepper,
            Stepper.Value.WithValue(value),
            Stepper.ValueChanged.WithValue(fun args -> onValueChanged args.NewValue |> box),
            Stepper.MinimumMaximum.WithValue((min, max))
        )

    static member inline ListView<'msg, 'itemData, 'itemMarker when 'itemMarker :> ICell>(items: seq<'itemData>) =
        ViewHelpers.buildItem<'msg, IListView, 'itemData, 'itemMarker> ViewKeys.ListView ItemsViewOfCell.ItemsSource items
            
    static member inline TextCell<'msg>(text: string) =
        ViewHelpers.buildScalars<'msg, ITextCell> ViewKeys.TextCell
            [| TextCell.Text.WithValue(text) |]
    
[<AbstractClass; Sealed>]
type View private () =
    static member inline Application<'msg, 'marker when 'marker :> IPage>(mainPage) =
        ViewBuilders.Application<'msg, 'marker>(mainPage)

    static member inline ContentPage<'msg, 'marker when 'marker :> IView>(title, content) =
        ViewBuilders.ContentPage<'msg, 'marker>(title, content)

    static member inline HorizontalStackLayout<'msg>(?spacing) =
        ViewBuilders.StackLayout<'msg>(Xamarin.Forms.StackOrientation.Horizontal, ?spacing = spacing)

    static member inline VerticalStackLayout<'msg>(?spacing) =
        ViewBuilders.StackLayout<'msg>(Xamarin.Forms.StackOrientation.Vertical, ?spacing = spacing)

    static member inline Grid<'msg>() =
        ViewBuilders.Grid<'msg>([ Star ], [ Star ])

    static member inline Grid<'msg>(coldefs, rowdefs) =
        ViewBuilders.Grid<'msg>(coldefs, rowdefs)

    static member inline Label<'msg>(text) = ViewBuilders.Label<'msg>(text)

    static member inline Button<'msg>(text, onClicked) =
        ViewBuilders.Button<'msg>(text, onClicked)

    static member inline Switch<'msg>(isToggled, onToggled) =
        ViewBuilders.Switch<'msg>(isToggled, onToggled)

    static member inline Slider<'msg>(min, max, value, onValueChanged) =
        ViewBuilders.Slider<'msg>(min, max, value, onValueChanged)

    static member inline ActivityIndicator<'msg>(isRunning) =
        ViewBuilders.ActivityIndicator<'msg>(isRunning)

    static member inline ContentView<'msg, 'marker when 'marker :> IView>(content) =
        ViewBuilders.ContentView<'msg, 'marker>(content)

    static member inline RefreshView<'msg, 'marker when 'marker :> IView>(isRefreshing, onRefreshing, content) =
        ViewBuilders.RefreshView<'msg, 'marker>(isRefreshing, onRefreshing, content)

    static member inline ScrollView<'msg, 'marker when 'marker :> IView>(content) =
        ViewBuilders.ScrollView<'msg, 'marker>(content)

    static member inline Image<'msg>(imageSource, aspect) =
        ViewBuilders.SourceImage<'msg>(imageSource, aspect)

    static member inline Image<'msg>(path, aspect) =
        ViewBuilders.FileImage<'msg>(path, aspect)

    static member inline Image<'msg>(uri, aspect) =
        ViewBuilders.WebImage<'msg>(uri, aspect)

    static member inline Image<'msg>(stream, aspect) =
        ViewBuilders.StreamImage<'msg>(stream, aspect)

    static member inline BoxView<'msg>(color) = ViewBuilders.BoxView<'msg>(color)
    static member inline NavigationPage<'msg>() = ViewBuilders.NavigationPage<'msg>()

    static member inline Entry<'msg>(text, onTextChanged) =
        ViewBuilders.Entry<'msg>(text, onTextChanged)

    static member inline TapGestureRecognizer<'msg>(onTapped) =
        ViewBuilders.TapGestureRecognizer<'msg>(onTapped)

    static member inline SearchBar<'msg>(text, onTextChanged, onSearchButtonPressed) =
        ViewBuilders.SearchBar<'msg>(text, onTextChanged, onSearchButtonPressed)

    static member inline ToolbarItem<'msg>(text, onClicked) =
        ViewBuilders.ToolbarItem<'msg>(text, onClicked)

    static member inline Editor<'msg>(text, onTextChanged) =
        ViewBuilders.Editor<'msg>(text, onTextChanged)

    static member inline ViewCell<'msg, 'marker when 'marker :> IView>(content) =
        ViewBuilders.ViewCell<'msg, 'marker>(content)

    static member inline ImageButton<'msg>(imageSource, onClicked, aspect) =
        ViewBuilders.SourceImageButton<'msg>(imageSource, onClicked, aspect)

    static member inline ImageButton<'msg>(path, onClicked, aspect) =
        ViewBuilders.FileImageButton<'msg>(path, onClicked, aspect)

    static member inline ImageButton<'msg>(uri, onClicked, aspect) =
        ViewBuilders.WebImageButton<'msg>(uri, onClicked, aspect)

    static member inline ImageButton<'msg>(stream, onClicked, aspect) =
        ViewBuilders.StreamImageButton<'msg>(stream, onClicked, aspect)

    static member inline TabbedPage<'msg>(title) = ViewBuilders.TabbedPage<'msg>(title)

    static member inline DatePicker<'msg>(date, onDateSelected) =
        ViewBuilders.DatePicker<'msg>(date, onDateSelected)

    static member inline TimePicker<'msg>(time, onTimeSelected) =
        ViewBuilders.TimePicker<'msg>(time, onTimeSelected)

    static member inline Stepper<'msg>(min, max, value, onValueChanged) =
        ViewBuilders.Stepper<'msg>(min, max, value, onValueChanged)
        
    static member inline ListView<'msg, 'itemData, 'itemMarker when 'itemMarker :> ICell>(items) = ViewBuilders.ListView<'msg, 'itemData, 'itemMarker>(items)
    static member inline TextCell<'msg>(text) = ViewBuilders.TextCell<'msg>(text)

[<Extension; AbstractClass; Sealed>]
type ViewExtensions private () =
    [<Extension>]
    static member inline userAppTheme(this: WidgetBuilder<'msg, #IApplication>, value: Xamarin.Forms.OSAppTheme) =
        this.AddScalar(Application.UserAppTheme.WithValue(value))

    [<Extension>]
    static member inline resources(this: WidgetBuilder<'msg, #IApplication>, value: Xamarin.Forms.ResourceDictionary) =
        this.AddScalar(Application.Resources.WithValue(value))

    [<Extension>]
    static member inline onRequestedThemeChanged
        (
            this: WidgetBuilder<'msg, #IApplication>,
            fn: Xamarin.Forms.AppThemeChangedEventArgs -> 'msg
        ) =
        this.AddScalar(Application.RequestedThemeChanged.WithValue(fn >> box))

    [<Extension>]
    static member inline onModalPopped
        (
            this: WidgetBuilder<'msg, #IApplication>,
            fn: Xamarin.Forms.ModalPoppedEventArgs -> 'msg
        ) =
        this.AddScalar(Application.ModalPopped.WithValue(fn >> box))

    [<Extension>]
    static member inline onModalPopping
        (
            this: WidgetBuilder<'msg, #IApplication>,
            fn: Xamarin.Forms.ModalPoppingEventArgs -> 'msg
        ) =
        this.AddScalar(Application.ModalPopping.WithValue(fn >> box))

    [<Extension>]
    static member inline onModalPushed
        (
            this: WidgetBuilder<'msg, #IApplication>,
            fn: Xamarin.Forms.ModalPushedEventArgs -> 'msg
        ) =
        this.AddScalar(Application.ModalPushed.WithValue(fn >> box))

    [<Extension>]
    static member inline onModalPushing
        (
            this: WidgetBuilder<'msg, #IApplication>,
            fn: Xamarin.Forms.ModalPushingEventArgs -> 'msg
        ) =
        this.AddScalar(Application.ModalPushing.WithValue(fn >> box))

    [<Extension>]
    static member inline automationId(this: WidgetBuilder<'msg, #IView>, value: string) =
        this.AddScalar(Element.AutomationId.WithValue(value))

    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IView>, value: bool) =
        this.AddScalar(VisualElement.IsEnabled.WithValue(value))

    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(VisualElement.Opacity.WithValue(value))

    [<Extension>]
    static member inline backgroundColor(this: WidgetBuilder<'msg, #IView>, value: Xamarin.Forms.Color) =
        this.AddScalar(VisualElement.BackgroundColor.WithValue(value))

    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IView>, value: bool) =
        this.AddScalar(VisualElement.IsVisible.WithValue(value))

    [<Extension>]
    static member inline horizontalOptions(this: WidgetBuilder<'msg, #IView>, value: Xamarin.Forms.LayoutOptions) =
        this.AddScalar(View.HorizontalOptions.WithValue(value))

    [<Extension>]
    static member inline verticalOptions(this: WidgetBuilder<'msg, #IView>, value: Xamarin.Forms.LayoutOptions) =
        this.AddScalar(View.VerticalOptions.WithValue(value))

    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, value: Xamarin.Forms.Thickness) =
        this.AddScalar(View.Margin.WithValue(value))

    [<Extension>]
    static member inline gestureRecognizers<'msg, 'marker when 'marker :> IView>(this: WidgetBuilder<'msg, 'marker>) =
        ViewHelpers.buildAttributeCollection<'msg, 'marker, IGestureRecognizer> View.GestureRecognizers this

    [<Extension>]
    static member inline horizontalTextAlignment
        (
            this: WidgetBuilder<'msg, #ILabel>,
            value: Xamarin.Forms.TextAlignment
        ) =
        this.AddScalar(Label.HorizontalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #ILabel>, value: Xamarin.Forms.TextAlignment) =
        this.AddScalar(Label.VerticalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #ILabel>, value: double) =
        this.AddScalar(Label.FontSize.WithValue(value))

    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ILabel>, value: Xamarin.Forms.Color) =
        this.AddScalar(Label.TextColor.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IView>, value: Xamarin.Forms.Thickness) =
        this.AddScalar(Label.Padding.WithValue(value))

    [<Extension>]
    static member inline textColor
        (
            this: WidgetBuilder<'msg, IButton>,
            light: Xamarin.Forms.Color,
            ?dark: Xamarin.Forms.Color
        ) =
        this.AddScalar(
            Button.TextColor.WithValue(
                {
                    Light = light
                    Dark =
                        match dark with
                        | None -> ValueNone
                        | Some v -> ValueSome v
                }
            )
        )

    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, IButton>, value: double) =
        this.AddScalar(Button.FontSize.WithValue(value))

    [<Extension>]
    static member inline paddingLayout(this: WidgetBuilder<'msg, #ILayout>, value: Xamarin.Forms.Thickness) =
        this.AddScalar(Layout.Padding.WithValue(value))

    [<Extension>]
    static member inline gridColumn(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(Grid.Column.WithValue(value))

    [<Extension>]
    static member inline gridRow(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(Grid.Row.WithValue(value))

    [<Extension>]
    static member inline columnSpacing(this: WidgetBuilder<'msg, #IGrid>, value: float) =
        this.AddScalar(Grid.ColumnSpacing.WithValue(value))

    [<Extension>]
    static member inline rowSpacing(this: WidgetBuilder<'msg, #IGrid>, value: float) =
        this.AddScalar(Grid.RowSpacing.WithValue(value))

    [<Extension>]
    static member inline gridColumnSpan(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(Grid.ColumnSpan.WithValue(value))

    [<Extension>]
    static member inline gridRowSpan(this: WidgetBuilder<'msg, #IView>, value: int) =
        this.AddScalar(Grid.RowSpan.WithValue(value))

    [<Extension>]
    static member inline onSizeAllocated(this: WidgetBuilder<'msg, #IContentPage>, fn: SizeAllocatedEventArgs -> 'msg) =
        this.AddScalar(ContentPage.SizeAllocated.WithValue(fn >> box))

    [<Extension>]
    static member inline barBackgroundColor(this: WidgetBuilder<'msg, #INavigationPage>, value: Xamarin.Forms.Color) =
        this.AddScalar(NavigationPage.BarBackgroundColor.WithValue(value))

    [<Extension>]
    static member inline popped(this: WidgetBuilder<'msg, #INavigationPage>, value: 'msg) =
        this.AddScalar(NavigationPage.Popped.WithValue(fun _ -> box value))

    [<Extension>]
    static member inline barTextColor(this: WidgetBuilder<'msg, #INavigationPage>, value: Xamarin.Forms.Color) =
        this.AddScalar(NavigationPage.BarTextColor.WithValue(value))

    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(VisualElement.Height.WithValue(value))

    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(VisualElement.Width.WithValue(value))

    [<Extension>]
    static member inline placeholder(this: WidgetBuilder<'msg, #IEntry>, value: string) =
        this.AddScalar(Entry.Placeholder.WithValue(value))

    [<Extension>]
    static member inline keyboard(this: WidgetBuilder<'msg, #IEntry>, value: Xamarin.Forms.Keyboard) =
        this.AddScalar(Entry.Keyboard.WithValue(value))

    [<Extension>]
    static member inline title(this: WidgetBuilder<'msg, #IPage>, value: string) =
        this.AddScalar(Page.Title.WithValue(value))

    [<Extension>]
    static member inline fileIcon(this: WidgetBuilder<'msg, #IPage>, value: string) =
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
    static member inline cancelButtonColor(this: WidgetBuilder<'msg, #ISearchBar>, value: Xamarin.Forms.Color) =
        this.AddScalar(SearchBar.CancelButtonColor.WithValue(value))

    [<Extension>]
    static member inline toolbarItems<'msg, 'marker when 'marker :> IPage>(this: WidgetBuilder<'msg, 'marker>) =
        ViewHelpers.buildAttributeCollection<'msg, 'marker, IToolbarItem> Page.ToolbarItems this

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

    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, IDatePicker>, value: float) =
        this.AddScalar(DatePicker.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline fontAttributes(this: WidgetBuilder<'msg, IDatePicker>, value: Xamarin.Forms.FontAttributes) =
        this.AddScalar(DatePicker.FontAttributes.WithValue(value))

    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, IDatePicker>, value: string) =
        this.AddScalar(DatePicker.FontFamily.WithValue(value))

    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, IDatePicker>, value: float) =
        this.AddScalar(DatePicker.FontSize.WithValue(value))

    [<Extension>]
    static member inline format(this: WidgetBuilder<'msg, IDatePicker>, value: string) =
        this.AddScalar(DatePicker.Format.WithValue(value))

    [<Extension>]
    static member inline minimumDate(this: WidgetBuilder<'msg, IDatePicker>, value: DateTime) =
        this.AddScalar(DatePicker.MinimumDate.WithValue(value))

    [<Extension>]
    static member inline maximumDate(this: WidgetBuilder<'msg, IDatePicker>, value: DateTime) =
        this.AddScalar(DatePicker.MaximumDate.WithValue(value))

    [<Extension>]
    static member inline textColor
        (
            this: WidgetBuilder<'msg, IDatePicker>,
            light: Xamarin.Forms.Color,
            ?dark: Xamarin.Forms.Color
        ) =
        this.AddScalar(
            DatePicker.TextColor.WithValue(
                {
                    Light = light
                    Dark =
                        match dark with
                        | None -> ValueNone
                        | Some v -> ValueSome v
                }
            )
        )

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, IDatePicker>, value: Xamarin.Forms.TextTransform) =
        this.AddScalar(DatePicker.TextTransform.WithValue(value))

    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #ITimePicker>, value: float) =
        this.AddScalar(TimePicker.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline fontAttributes(this: WidgetBuilder<'msg, #ITimePicker>, value: Xamarin.Forms.FontAttributes) =
        this.AddScalar(TimePicker.FontAttributes.WithValue(value))

    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #ITimePicker>, value: string) =
        this.AddScalar(TimePicker.FontFamily.WithValue(value))

    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, #ITimePicker>, value: float) =
        this.AddScalar(TimePicker.FontSize.WithValue(value))

    [<Extension>]
    static member inline format(this: WidgetBuilder<'msg, #ITimePicker>, value: string) =
        this.AddScalar(TimePicker.Format.WithValue(value))

    [<Extension>]
    static member inline textColor
        (
            this: WidgetBuilder<'msg, #ITimePicker>,
            light: Xamarin.Forms.Color,
            ?dark: Xamarin.Forms.Color
        ) =
        this.AddScalar(
            TimePicker.TextColor.WithValue(
                {
                    Light = light
                    Dark =
                        match dark with
                        | None -> ValueNone
                        | Some v -> ValueSome v
                }
            )
        )

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #ITimePicker>, value: Xamarin.Forms.TextTransform) =
        this.AddScalar(TimePicker.TextTransform.WithValue(value))

    [<Extension>]
    static member inline increment(this: WidgetBuilder<'msg, #IStepper>, value: float) =
        this.AddScalar(Stepper.Increment.WithValue(value))

    [<Extension>]
    static member inline rowHeight(this: WidgetBuilder<'msg, #IListView>, value: int) =
        this.AddScalar(ListView.RowHeight.WithValue(value))
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IListView>, value: Xamarin.Forms.ListViewSelectionMode) =
        this.AddScalar(ListView.SelectionMode.WithValue(value))
    [<Extension>]
    static member inline itemTapped(this: WidgetBuilder<'msg, #IListView>, fn: int -> 'msg) =
        this.AddScalar(ListView.ItemTapped.WithValue(fun args -> fn args.ItemIndex |> box))