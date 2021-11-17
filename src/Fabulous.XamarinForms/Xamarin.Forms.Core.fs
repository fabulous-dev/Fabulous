namespace Fabulous.XamarinForms

open Fabulous
open Fabulous.XamarinForms
open Fabulous.XamarinForms.XFAttributes
open Fabulous.XamarinForms.Widgets
open System.Runtime.CompilerServices
open System.IO

module ViewHelpers =
    let inline compileSeq (items: seq<#IWidgetBuilder<'msg>>) =
        items
        |> Seq.map (fun item -> item.Compile())
        |> Seq.toArray
        
module WidgetKeys =
    let ApplicationKey = Widgets.register<Xamarin.Forms.Application>()
    let ToolbarItemKey = Widgets.register<Xamarin.Forms.ToolbarItem>()
    let ContentPageKey = Widgets.register<Fabulous.XamarinForms.FabulousContentPage>()
    let StackLayoutKey = Widgets.register<Xamarin.Forms.StackLayout>()
    let GridKey = Widgets.register<Xamarin.Forms.Grid>()
    let LabelKey = Widgets.register<Xamarin.Forms.Label>()
    let ButtonKey = Widgets.register<Xamarin.Forms.Button>()
    let SwitchKey = Widgets.register<Xamarin.Forms.Switch>()
    let SliderKey = Widgets.register<Xamarin.Forms.Slider>()
    let ActivityIndicatorKey = Widgets.register<Xamarin.Forms.ActivityIndicator>()
    let ContentViewKey = Widgets.register<Xamarin.Forms.ContentView>()
    let RefreshViewKey = Widgets.register<Xamarin.Forms.RefreshView>()
    let ScrollViewKey = Widgets.register<Xamarin.Forms.ScrollView>()
    let ImageKey = Widgets.register<Xamarin.Forms.Image>()
    let BoxViewKey = Widgets.register<Xamarin.Forms.BoxView>()
    let NavigationPageKey = Widgets.register<Xamarin.Forms.NavigationPage>()
    let EntryKey = Widgets.register<Xamarin.Forms.Entry>()
    let TapGestureRecognizerKey = Widgets.register<Xamarin.Forms.TapGestureRecognizer>()
    let SearchBarKey = Widgets.register<Xamarin.Forms.SearchBar>()
    let EditorKey = Widgets.register<Xamarin.Forms.Editor>()
    let ViewCellKey = Widgets.register<Xamarin.Forms.ViewCell>()
    let ImageButtonKey = Widgets.register<Xamarin.Forms.ImageButton>()

type [<Struct>] Application<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }

    static member inline Create(mainPage: IPageWidgetBuilder<'msg>) =
        Application<'msg>(
            [||],
            [| Application.MainPage.WithValue(mainPage.Compile()) |],
            [||]
        )

    interface IApplicationWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.ApplicationKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }

type [<Struct>] ContentPage<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]
    
    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
    
    static member inline Create(content: IViewWidgetBuilder<'msg>) =
        ContentPage<'msg>(
            [||],
            [| ContentPage.Content.WithValue(content.Compile()) |],
            [||]
        )
    
    interface IPageWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.ContentPageKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
    
type [<Struct>] StackLayout<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
          
    static member inline Create(orientation: Xamarin.Forms.StackOrientation, children: seq<IViewWidgetBuilder<'msg>>, ?spacing: float) =
        StackLayout<'msg>(
            [|
                StackLayout.Orientation.WithValue(orientation)
                match spacing with None -> () | Some v -> StackLayout.Spacing.WithValue(v)
            |],
            [||],
            [|
                LayoutOfView.Children.WithValue(ViewHelpers.compileSeq children)
            |]
        )

    static member inline CreateVertical(children: seq<IViewWidgetBuilder<'msg>>, ?spacing: float) =
        StackLayout<'msg>.Create(Xamarin.Forms.StackOrientation.Vertical, children, ?spacing = spacing)
        
    static member inline CreateHorizontal(children: seq<IViewWidgetBuilder<'msg>>, ?spacing: float) =
        StackLayout<'msg>.Create(Xamarin.Forms.StackOrientation.Horizontal, children, ?spacing = spacing)

    interface ILayoutWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.StackLayoutKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] Grid<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
                        
    static member inline Create(children: seq<IViewWidgetBuilder<'msg>>, ?coldefs: seq<Dimension>, ?rowdefs: seq<Dimension>) =
        Grid<'msg>(
            [|
                match coldefs with None -> () | Some v -> Grid.ColumnDefinitions.WithValue(v)
                match rowdefs with None -> () | Some v -> Grid.RowDefinitions.WithValue(v)
            |],
            [||],
            [| LayoutOfView.Children.WithValue(ViewHelpers.compileSeq children) |]
        )
              
    interface ILayoutWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.GridKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }

type ILabelWidgetBuilder<'msg> = inherit IViewWidgetBuilder<'msg>
type [<Struct>] Label<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }

    static member inline Create(text: string) =
        Label<'msg>([| Label.Text.WithValue(text) |], [||], [||])

    interface ILabelWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.LabelKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }

type [<Struct>] Button<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }

    static member inline Create(text: string, onClicked: 'msg) =
        Button<'msg>(
            [|
                Button.Text.WithValue(text)
                Button.Clicked.WithValue(onClicked)
            |],
            [||],
            [||]
        )

    interface IViewWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.ButtonKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }

type [<Struct>] Switch<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }

    static member inline Create(isToggled: bool, onToggled: bool -> 'msg) =
        Switch<'msg>(
            [|
                Switch.IsToggled.WithValue(isToggled)
                Switch.Toggled.WithValue(fun args -> onToggled args.Value |> box)
            |],
            [||],
            [||]
        )
        
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.SwitchKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] Slider<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
              
    static member inline Create(value: float, onValueChanged: float -> 'msg, ?min: float, ?max: float) =
        Slider<'msg>(
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
        member x.Compile() =
            { Key = WidgetKeys.SliderKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] ActivityIndicator<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
              
    static member inline Create(isRunning: bool) =
        ActivityIndicator<'msg>(
            [| ActivityIndicator.IsRunning.WithValue(isRunning) |],
            [||],
            [||]
        )
                      
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.ActivityIndicatorKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] ContentView<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
              
    static member inline Create(content: IViewWidgetBuilder<'msg>) =
        ContentView<'msg>(
            [||],
            [| ContentView.Content.WithValue(content.Compile()) |],
            [||]
        )
                      
    interface ILayoutWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.ContentViewKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] RefreshView<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
              
    static member inline Create(isRefreshing: bool, onRefreshing: 'msg, content: IViewWidgetBuilder<'msg>) =
        RefreshView<'msg>(
            [|
                RefreshView.IsRefreshing.WithValue(isRefreshing)
                RefreshView.Refreshing.WithValue(onRefreshing)
            |],
            [| ContentView.Content.WithValue(content.Compile()) |],
            [||]
        )
                      
    interface ILayoutWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.RefreshViewKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] ScrollView<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
              
    static member inline Create(content: IViewWidgetBuilder<'msg>) =
        ScrollView<'msg>(
            [||],
            [| ScrollView.Content.WithValue(content.Compile()) |],
            [||]
        )
                      
    interface ILayoutWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.ScrollViewKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] Image<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }

    static member inline Create(imageSource: Xamarin.Forms.ImageSource, aspect: Xamarin.Forms.Aspect) =
        Image<'msg>(
            [|
                Image.Source.WithValue(imageSource)
                Image.Aspect.WithValue(aspect)
            |],
            [||],
            [||]
        )

    static member inline Create(path: string, aspect: Xamarin.Forms.Aspect) =
        Image<'msg>.Create(Xamarin.Forms.ImageSource.FromFile(path), aspect)
        
    static member inline Create(uri: System.Uri, aspect: Xamarin.Forms.Aspect) =
        Image<'msg>.Create(Xamarin.Forms.ImageSource.FromUri(uri), aspect)
        
    static member inline Create(stream: Stream, aspect: Xamarin.Forms.Aspect) =
        Image<'msg>.Create(Xamarin.Forms.ImageSource.FromStream(fun () -> stream), aspect)
                      
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.ImageKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] BoxView<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
              
    static member inline Create(color: Xamarin.Forms.Color) =
        BoxView<'msg>(
            [|
                BoxView.Color.WithValue(color)
            |],
            [||],
            [||]
        )
                      
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.BoxViewKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] NavigationPage<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
              
    static member inline Create(pages: seq<IPageWidgetBuilder<'msg>>) =
        NavigationPage<'msg>(
            [||],
            [||],
            [| NavigationPage.Pages.WithValue(ViewHelpers.compileSeq pages) |]
        )
                      
    interface IPageWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.NavigationPageKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }

type IEntryWidgetBuilder<'msg> = inherit IViewWidgetBuilder<'msg>
type [<Struct>] Entry<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
                            
    static member inline Create(text: string, onTextChanged: string -> 'msg) =
        Entry<'msg>(
            [| Entry.Text.WithValue(text)
               Entry.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box) |],
            [||],
            [||]
        )
                                    
    interface IEntryWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.EntryKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }

type [<Struct>] TapGestureRecognizer<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
              
    static member inline Create(onTapped: 'msg) =
        TapGestureRecognizer<'msg>(
            [| TapGestureRecognizer.Tapped.WithValue(onTapped) |],
            [||],
            [||]
        )
                      
    interface IGestureRecognizerWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.TapGestureRecognizerKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] SearchBar<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetColls) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetColls }
                            
    static member inline Create(text: string, onTextChanged: string -> 'msg, onSearchButtonPressed: 'msg) =
        SearchBar<'msg>(
            [| SearchBar.Text.WithValue(text)
               InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box)
               SearchBar.SearchButtonPressed.WithValue(onSearchButtonPressed) |],
            [||],
            [||]
        )
                                    
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.SearchBarKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }

type [<Struct>] ToolbarItem<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]

    new (scalars, widgets, widgetCollections) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetCollections }
                            
    static member inline Create(text: string, onClicked: 'msg) =
        ToolbarItem<'msg>(
            [| MenuItem.Text.WithValue(text)
               MenuItem.Clicked.WithValue(onClicked) |],
            [||],
            [||]
        )
                                    
    interface IToolbarItemWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.ToolbarItemKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] Editor<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]
              
    new (scalars, widgets, widgetCollections) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetCollections }
                                          
    static member inline Create(text: string, onTextChanged: string -> 'msg) =
        Editor<'msg>(
            [| Editor.Text.WithValue(text)
               InputView.TextChanged.WithValue(fun args -> onTextChanged args.NewTextValue |> box) |],
            [||],
            [||]
        )
                                                  
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.EditorKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] ViewCell<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]
              
    new (scalars, widgets, widgetCollections) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetCollections }
                                          
    static member inline Create(view: #IViewWidgetBuilder<'msg>) =
        ViewCell<'msg>(
            [||],
            [| ViewCell.View.WithValue(view.Compile()) |],
            [||]
        )
                                                  
    interface ICellWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.ViewCellKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }
              
type [<Struct>] ImageButton<'msg> =
    val public ScalarAttributes: ScalarAttribute[]
    val public WidgetAttributes: WidgetAttribute[]
    val public WidgetCollectionAttributes: WidgetCollectionAttribute[]
              
    new (scalars, widgets, widgetCollections) =
        { ScalarAttributes = scalars
          WidgetAttributes = widgets
          WidgetCollectionAttributes = widgetCollections }
                                          
    static member inline Create(source: Xamarin.Forms.ImageSource, onClicked: 'msg, aspect: Xamarin.Forms.Aspect) =
        ImageButton<'msg>(
            [| ImageButton.Source.WithValue(source)
               ImageButton.Clicked.WithValue(onClicked)
               ImageButton.Aspect.WithValue(aspect) |],
            [||],
            [||]
        )

    static member inline Create(path: string, onClicked, aspect) =
        ImageButton<'msg>.Create(Xamarin.Forms.ImageSource.FromFile(path), onClicked, aspect)
                                                  
    interface IViewWidgetBuilder<'msg> with
        member x.Compile() =
            { Key = WidgetKeys.ImageButtonKey
              ScalarAttributes = x.ScalarAttributes
              WidgetAttributes = x.WidgetAttributes
              WidgetCollectionAttributes = x.WidgetCollectionAttributes }

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
    static member inline textColor(this: Button<_>, value: Xamarin.Forms.Color) =
        this.AddScalarAttribute(Button.TextColor.WithValue(value))
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

[<AbstractClass; Sealed>]
type View private () =
    static member inline Application<'msg>(mainPage) = Application<'msg>.Create(mainPage)
    static member inline ContentPage<'msg>(content) = ContentPage<'msg>.Create(content)
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
    static member inline FileImage<'msg>(path: string, aspect) = Image<'msg>.Create(path, aspect)
    static member inline WebImage<'msg>(uri: System.Uri, aspect) = Image<'msg>.Create(uri, aspect)
    static member inline StreamImage<'msg>(stream: Stream, aspect) = Image<'msg>.Create(stream, aspect)
    static member inline BoxView<'msg>(color) = BoxView<'msg>.Create(color)
    static member inline NavigationPage<'msg>(pages) = NavigationPage<'msg>.Create(pages)
    static member inline Entry<'msg>(text, onTextChanged) = Entry<'msg>.Create(text, onTextChanged)
    static member inline TapGestureRecognizer<'msg>(onTapped) = TapGestureRecognizer<'msg>.Create(onTapped)
    static member inline SearchBar<'msg>(text, onTextChanged, onSearchButtonPressed) = SearchBar<'msg>.Create(text, onTextChanged, onSearchButtonPressed)
    static member inline ToolbarItem<'msg>(text, onClicked) = ToolbarItem<'msg>.Create(text, onClicked)
    static member inline Editor<'msg>(text, onTextChanged) = Editor<'msg>.Create(text, onTextChanged)
    static member inline ViewCell<'msg>(view) = ViewCell<'msg>.Create(view)
    static member inline ImageButton<'msg>(path: string, onClicked, aspect) = ImageButton<'msg>.Create(path, onClicked, aspect)
            