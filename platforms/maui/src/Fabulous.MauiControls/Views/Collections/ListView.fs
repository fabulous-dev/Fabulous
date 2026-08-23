namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabListView =
    inherit IFabItemsViewOfCell

/// Force ListView to recycle rows because DataTemplateSelector disables it by default
type FabListView() =
    inherit ListView(ListViewCachingStrategy.RecycleElement)

module ListView =
    let WidgetKey = Widgets.register<FabListView>()

    let Footer = Attributes.defineBindableWidget ListView.FooterProperty

    let GroupedItemsSource =
        Attributes.defineSimpleScalar<GroupedWidgetItems>
            "ListView_GroupedItemsSource"
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

                    listView.SetValue(ListView.ItemTemplateProperty, WidgetDataTemplateSelector(node, unbox >> value.ItemTemplate))

                    listView.SetValue(ListView.GroupHeaderTemplateProperty, WidgetDataTemplateSelector(node, unbox >> value.HeaderTemplate)))

    let HasUnevenRows = Attributes.defineBindableBool ListView.HasUnevenRowsProperty

    let Header = Attributes.defineBindableWidget ListView.HeaderProperty

    let HorizontalScrollBarVisibility =
        Attributes.defineBindableEnum<ScrollBarVisibility> ListView.HorizontalScrollBarVisibilityProperty

    let IsPullToRefreshEnabled =
        Attributes.defineBindableBool ListView.IsPullToRefreshEnabledProperty

    let IsRefreshing = Attributes.defineBindableBool ListView.IsRefreshingProperty

    let ItemAppearing =
        Attributes.Mvu.defineEvent<ItemVisibilityEventArgs> "ListView_ItemAppearing" (fun target -> (target :?> ListView).ItemAppearing)

    let ItemDisappearing =
        Attributes.Mvu.defineEvent<ItemVisibilityEventArgs> "ListView_ItemDisappearing" (fun target -> (target :?> ListView).ItemDisappearing)

    let ItemSelected =
        Attributes.Mvu.defineEvent<SelectedItemChangedEventArgs> "ListView_ItemSelected" (fun target -> (target :?> ListView).ItemSelected)

    let ItemTapped =
        Attributes.Mvu.defineEvent<ItemTappedEventArgs> "ListView_ItemTapped" (fun target -> (target :?> ListView).ItemTapped)

    let RefreshControlColor =
        Attributes.defineBindableColor ListView.RefreshControlColorProperty

    let Refreshing =
        Attributes.Mvu.defineEventNoArg "ListView_Refreshing" (fun target -> (target :?> ListView).Refreshing)

    let RowHeight = Attributes.defineBindableInt ListView.RowHeightProperty

    let SelectionMode =
        Attributes.defineBindableEnum<ListViewSelectionMode> ListView.SelectionModeProperty

    let SeparatorColor = Attributes.defineBindableColor ListView.SeparatorColorProperty

    let SeparatorVisibility =
        Attributes.defineBindableEnum<SeparatorVisibility> ListView.SeparatorVisibilityProperty

    let Scrolled =
        Attributes.Mvu.defineEvent<ScrolledEventArgs> "ListView_Scrolled" (fun target -> (target :?> ListView).Scrolled)

    let ScrollToRequested =
        Attributes.Mvu.defineEvent<ScrollToRequestedEventArgs> "ListView_ScrollToRequested" (fun target -> (target :?> ListView).ScrollToRequested)

    let VerticalScrollBarVisibility =
        Attributes.defineBindableEnum<ScrollBarVisibility> ListView.VerticalScrollBarVisibilityProperty

[<AutoOpen>]
module ListViewBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a ListView with a list of items</summary>
        /// <param name="items">The items list</param>
        static member inline ListView<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabCell>(items: seq<'itemData>) =
            WidgetHelpers.buildItems<'msg, IFabListView, 'itemData, 'itemMarker> ListView.WidgetKey ItemsViewOfCell.ItemsSource items

        /// <summary>Create a ListView with a list of grouped items</summary>
        /// <param name="items">The grouped items list</param>
        static member inline GroupedListView<'msg, 'groupData, 'groupMarker, 'itemData, 'itemMarker
            when 'msg: equality and 'itemMarker :> IFabCell and 'groupMarker :> IFabCell and 'groupData :> System.Collections.Generic.IEnumerable<'itemData>>
            (items: seq<'groupData>)
            =
            WidgetHelpers.buildGroupItemsNoFooter<'msg, IFabListView, 'groupData, 'itemData, 'groupMarker, 'itemMarker>
                ListView.WidgetKey
                ListView.GroupedItemsSource
                items

[<Extension>]
type ListViewModifiers =
    /// <summary>Set the footer widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The footer widget</param>
    [<Extension>]
    static member inline footer(this: WidgetBuilder<'msg, #IFabListView>, content: WidgetBuilder<'msg, #IFabView>) =
        this.AddWidget(ListView.Footer.WithValue(content.Compile()))

    /// <summary>Set whether the list has uneven rows</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the list has uneven rows</param>
    [<Extension>]
    static member inline hasUnevenRows(this: WidgetBuilder<'msg, #IFabListView>, value: bool) =
        this.AddScalar(ListView.HasUnevenRows.WithValue(value))

    /// <summary>Set the header widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The header widget</param>
    [<Extension>]
    static member inline header(this: WidgetBuilder<'msg, #IFabListView>, content: WidgetBuilder<'msg, #IFabView>) =
        this.AddWidget(ListView.Header.WithValue(content.Compile()))

    /// <summary>Set the horizontal scroll bar visibility</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The horizontal scroll bar visibility</param>
    [<Extension>]
    static member inline horizontalScrollBarVisibility(this: WidgetBuilder<'msg, #IFabListView>, value: ScrollBarVisibility) =
        this.AddScalar(ListView.HorizontalScrollBarVisibility.WithValue(value))

    /// <summary>Set whether pull to refresh is enabled</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether pull to refresh is enabled</param>
    [<Extension>]
    static member inline isPullToRefreshEnabled(this: WidgetBuilder<'msg, #IFabListView>, value: bool) =
        this.AddScalar(ListView.IsPullToRefreshEnabled.WithValue(value))

    /// <summary>Set whether the list is refreshing</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The value indicating whether the list is refreshing</param>
    [<Extension>]
    static member inline isRefreshing(this: WidgetBuilder<'msg, #IFabListView>, value: bool) =
        this.AddScalar(ListView.IsRefreshing.WithValue(value))

    /// <summary>Listen for the ItemAppearing event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onItemAppearing(this: WidgetBuilder<'msg, #IFabListView>, fn: ItemVisibilityEventArgs -> 'msg) =
        this.AddScalar(ListView.ItemAppearing.WithValue(fun args -> fn args |> box))

    /// <summary>Listen for the ItemDisappearing event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onItemDisappearing(this: WidgetBuilder<'msg, #IFabListView>, fn: ItemVisibilityEventArgs -> 'msg) =
        this.AddScalar(ListView.ItemDisappearing.WithValue(fun args -> fn args |> box))

    /// <summary>Listen for the ItemTapped event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onItemTapped(this: WidgetBuilder<'msg, #IFabListView>, fn: int -> 'msg) =
        this.AddScalar(ListView.ItemTapped.WithValue(fun args -> fn args.ItemIndex |> box))

    /// <summary>Listen for the ItemSelected event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onItemSelected(this: WidgetBuilder<'msg, #IFabListView>, fn: int -> 'msg) =
        this.AddScalar(ListView.ItemSelected.WithValue(fun args -> fn args.SelectedItemIndex |> box))

    /// <summary>Listen for the Refreshing event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch</param>
    [<Extension>]
    static member inline onRefreshing(this: WidgetBuilder<'msg, #IFabListView>, msg: 'msg) =
        this.AddScalar(ListView.Refreshing.WithValue(MsgValue(msg)))

    /// <summary>Listen for the Scrolled event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onScrolled(this: WidgetBuilder<'msg, #IFabListView>, fn: ScrolledEventArgs -> 'msg) =
        this.AddScalar(ListView.Scrolled.WithValue(fun args -> fn args |> box))

    /// <summary>Listen for the ScrollToRequested event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onScrollToRequested(this: WidgetBuilder<'msg, #IFabListView>, fn: ScrollToRequestedEventArgs -> 'msg) =
        this.AddScalar(ListView.ScrollToRequested.WithValue(fun args -> fn args |> box))

    /// <summary>Set the refresh control color</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The refresh control color</param>
    [<Extension>]
    static member inline refreshControlColor(this: WidgetBuilder<'msg, #IFabListView>, value: Color) =
        this.AddScalar(ListView.RefreshControlColor.WithValue(value))

    /// <summary>Set the row height</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The row height</param>
    [<Extension>]
    static member inline rowHeight(this: WidgetBuilder<'msg, #IFabListView>, value: int) =
        this.AddScalar(ListView.RowHeight.WithValue(value))

    /// <summary>Set the separator color</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The separator color</param>
    [<Extension>]
    static member inline separatorColor(this: WidgetBuilder<'msg, #IFabListView>, value: Color) =
        this.AddScalar(ListView.SeparatorColor.WithValue(value))

    /// <summary>Set the separator visibility</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The separator visibility</param>
    [<Extension>]
    static member inline separatorVisibility(this: WidgetBuilder<'msg, #IFabListView>, value: SeparatorVisibility) =
        this.AddScalar(ListView.SeparatorVisibility.WithValue(value))

    /// <summary>Set the selection mode</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The selection mode</param>
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IFabListView>, value: ListViewSelectionMode) =
        this.AddScalar(ListView.SelectionMode.WithValue(value))

    /// <summary>Set the vertical scroll bar visibility</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The vertical scroll bar visibility</param>
    [<Extension>]
    static member inline verticalScrollBarVisibility(this: WidgetBuilder<'msg, #IFabListView>, value: ScrollBarVisibility) =
        this.AddScalar(ListView.VerticalScrollBarVisibility.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ListView control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabListView>, value: ViewRef<ListView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
