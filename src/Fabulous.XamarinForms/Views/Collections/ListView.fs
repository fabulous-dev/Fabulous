namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IListView =
    inherit IItemsViewOfCell

module ListView =

    let WidgetKey = Widgets.register<FabulousListView>()

    let GroupedItemsSource<'groupData, 'itemData> =
        Attributes.defineScalarWithConverter<GroupedWidgetItems<'groupData, 'itemData>, GroupedWidgetItems<'groupData, 'itemData>, GroupedWidgetItems<'groupData, 'itemData>>
            "ListView_GroupedItemsSource"
            id
            id
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let listView = node.Target :?> ListView

                match newValueOpt with
                | ValueNone ->
                    listView.IsGroupingEnabled <- false
                    listView.ClearValue(ListView.ItemsSourceProperty)
                    listView.ClearValue(ListView.GroupHeaderTemplateProperty)
                    listView.ClearValue(ListView.ItemTemplateProperty)

                | ValueSome value ->
                    listView.IsGroupingEnabled <- true

                    listView.SetValue(ListView.ItemsSourceProperty, value.OriginalItems)

                    listView.SetValue(
                        ListView.ItemTemplateProperty,
                        WidgetDataTemplateSelector(node, unbox >> value.ItemTemplate)
                    )

                    listView.SetValue(
                        ListView.GroupHeaderTemplateProperty,
                        WidgetDataTemplateSelector(node, unbox >> value.HeaderTemplate)
                    ))

    let Header =
        Attributes.defineBindableWidget ListView.HeaderProperty

    let Footer =
        Attributes.defineBindableWidget ListView.FooterProperty

    let RowHeight =
        Attributes.defineBindableInt ListView.RowHeightProperty

    let SelectionMode =
        Attributes.defineBindableEnum<ListViewSelectionMode> ListView.SelectionModeProperty

    let IsPullToRefreshEnabled =
        Attributes.defineBindableBool ListView.IsPullToRefreshEnabledProperty

    let IsRefreshing =
        Attributes.defineBindableBool ListView.IsRefreshingProperty

    let HasUnevenRows =
        Attributes.defineBindableBool ListView.HasUnevenRowsProperty

    let SeparatorVisibility =
        Attributes.defineBindableEnum<SeparatorVisibility> ListView.SeparatorVisibilityProperty

    let SeparatorColor =
        Attributes.defineAppThemeBindable<Color> ListView.SeparatorColorProperty

    let RefreshControlColor =
        Attributes.defineAppThemeBindable<Color> ListView.RefreshControlColorProperty

    let HorizontalScrollBarVisibility =
        Attributes.defineBindableEnum<ScrollBarVisibility> ListView.HorizontalScrollBarVisibilityProperty

    let VerticalScrollBarVisibility =
        Attributes.defineBindableEnum<ScrollBarVisibility> ListView.VerticalScrollBarVisibilityProperty

    let ItemAppearing =
        Attributes.defineEvent<ItemVisibilityEventArgs>
            "ListView_ItemAppearing"
            (fun target -> (target :?> ListView).ItemAppearing)

    let ItemDisappearing =
        Attributes.defineEvent<ItemVisibilityEventArgs>
            "ListView_ItemDisappearing"
            (fun target -> (target :?> ListView).ItemDisappearing)

    let ItemSelected =
        Attributes.defineEvent<SelectedItemChangedEventArgs>
            "ListView_ItemSelected"
            (fun target -> (target :?> ListView).ItemSelected)

    let ItemTapped =
        Attributes.defineEvent<ItemTappedEventArgs>
            "ListView_ItemTapped"
            (fun target -> (target :?> ListView).ItemTapped)

    let Refreshing =
        Attributes.defineEventNoArg "ListView_Refreshing" (fun target -> (target :?> ListView).Refreshing)

    let Scrolled =
        Attributes.defineEvent<ScrolledEventArgs> "ListView_Scrolled" (fun target -> (target :?> ListView).Scrolled)

    let ScrollToRequested =
        Attributes.defineEvent<ScrollToRequestedEventArgs>
            "ListView_ScrollToRequested"
            (fun target -> (target :?> ListView).ScrollToRequested)

[<AutoOpen>]
module ListViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ListView<'msg, 'itemData, 'itemMarker when 'itemMarker :> ICell>(items: seq<'itemData>) =
            WidgetHelpers.buildItems<'msg, IListView, 'itemData, 'itemMarker>
                ListView.WidgetKey
                ItemsViewOfCell.ItemsSource
                items

        static member inline GroupedListView<'msg, 'groupData, 'groupMarker, 'itemData, 'itemMarker when 'itemMarker :> ICell and 'groupMarker :> ICell and 'groupData :> System.Collections.Generic.IEnumerable<'itemData>>
            (items: seq<'groupData>)
            =
            WidgetHelpers.buildGroupItemsNoFooter<'msg, IListView, 'groupData, 'itemData, 'groupMarker, 'itemMarker>
                ListView.WidgetKey
                ListView.GroupedItemsSource
                items

[<Extension>]
type ListViewModifiers =

    [<Extension>]
    static member inline header<'msg, 'marker, 'contentMarker when 'marker :> IListView and 'contentMarker :> IView>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(ListView.Header.WithValue(content.Compile()))

    [<Extension>]
    static member inline footer<'msg, 'marker, 'contentMarker when 'marker :> IListView and 'contentMarker :> IView>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(ListView.Footer.WithValue(content.Compile()))

    [<Extension>]
    static member inline hasUnevenRows(this: WidgetBuilder<'msg, #IListView>, value: bool) =
        this.AddScalar(ListView.HasUnevenRows.WithValue(value))

    [<Extension>]
    static member inline horizontalScrollBarVisibility
        (
            this: WidgetBuilder<'msg, #IListView>,
            value: ScrollBarVisibility
        ) =
        this.AddScalar(ListView.HorizontalScrollBarVisibility.WithValue(value))

    [<Extension>]
    static member inline verticalScrollBarVisibility
        (
            this: WidgetBuilder<'msg, #IListView>,
            value: ScrollBarVisibility
        ) =
        this.AddScalar(ListView.VerticalScrollBarVisibility.WithValue(value))

    [<Extension>]
    static member inline isPullToRefreshEnabled(this: WidgetBuilder<'msg, #IListView>, value: bool) =
        this.AddScalar(ListView.IsPullToRefreshEnabled.WithValue(value))

    [<Extension>]
    static member inline isRefreshing(this: WidgetBuilder<'msg, #IListView>, value: bool) =
        this.AddScalar(ListView.IsRefreshing.WithValue(value))

    [<Extension>]
    static member inline refreshControlColor(this: WidgetBuilder<'msg, #IListView>, light: Color, ?dark: Color) =
        this.AddScalar(ListView.RefreshControlColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline separatorColor(this: WidgetBuilder<'msg, #IListView>, light: Color, ?dark: Color) =
        this.AddScalar(ListView.SeparatorColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline separatorVisibility(this: WidgetBuilder<'msg, #IListView>, value: SeparatorVisibility) =
        this.AddScalar(ListView.SeparatorVisibility.WithValue(value))

    [<Extension>]
    static member inline rowHeight(this: WidgetBuilder<'msg, #IListView>, value: int) =
        this.AddScalar(ListView.RowHeight.WithValue(value))

    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IListView>, value: ListViewSelectionMode) =
        this.AddScalar(ListView.SelectionMode.WithValue(value))

    [<Extension>]
    static member inline onItemAppearing
        (
            this: WidgetBuilder<'msg, #IListView>,
            onItemAppearing: ItemVisibilityEventArgs -> 'msg
        ) =
        this.AddScalar(ListView.ItemAppearing.WithValue(fun args -> onItemAppearing args |> box))

    [<Extension>]
    static member inline onItemDisappearing
        (
            this: WidgetBuilder<'msg, #IListView>,
            onItemDisappearing: ItemVisibilityEventArgs -> 'msg
        ) =
        this.AddScalar(ListView.ItemDisappearing.WithValue(fun args -> onItemDisappearing args |> box))

    [<Extension>]
    static member inline onItemTapped(this: WidgetBuilder<'msg, #IListView>, onItemTapped: int -> 'msg) =
        this.AddScalar(ListView.ItemTapped.WithValue(fun args -> onItemTapped args.ItemIndex |> box))

    [<Extension>]
    static member inline onItemSelected
        (
            this: WidgetBuilder<'msg, #IListView>,
            onItemSelected: SelectedItemChangedEventArgs -> 'msg
        ) =
        this.AddScalar(ListView.ItemSelected.WithValue(fun args -> onItemSelected args |> box))

    [<Extension>]
    static member inline onRefreshing(this: WidgetBuilder<'msg, #IListView>, onRefreshing: 'msg) =
        this.AddScalar(ListView.Refreshing.WithValue(onRefreshing))

    [<Extension>]
    static member inline onScrolled(this: WidgetBuilder<'msg, #IListView>, onScrolled: ScrolledEventArgs -> 'msg) =
        this.AddScalar(ListView.Scrolled.WithValue(fun args -> onScrolled args |> box))

    [<Extension>]
    static member inline onScrollToRequested
        (
            this: WidgetBuilder<'msg, #IListView>,
            onScrollToRequested: ScrollToRequestedEventArgs -> 'msg
        ) =
        this.AddScalar(ListView.ScrollToRequested.WithValue(fun args -> onScrollToRequested args |> box))

    /// <summary>Link a ViewRef to access the direct ListView control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IListView>, value: ViewRef<ListView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
