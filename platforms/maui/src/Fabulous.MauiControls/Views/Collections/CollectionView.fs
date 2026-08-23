namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabCollectionView =
    inherit IFabItemsView

module CollectionView =
    let WidgetKey = Widgets.register<CollectionView>()

    let Footer = Attributes.defineBindableWidget CollectionView.FooterProperty

    let GroupedItemsSource =
        Attributes.defineSimpleScalar<GroupedWidgetItems>
            "CollectionView_GroupedItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let collectionView = node.Target :?> CollectionView

                match newValueOpt with
                | ValueNone ->
                    collectionView.IsGrouped <- false
                    collectionView.ClearValue(CollectionView.ItemsSourceProperty)
                    collectionView.ClearValue(CollectionView.GroupHeaderTemplateProperty)
                    collectionView.ClearValue(CollectionView.GroupFooterTemplateProperty)
                    collectionView.ClearValue(CollectionView.ItemTemplateProperty)

                | ValueSome value ->
                    collectionView.IsGrouped <- true

                    collectionView.SetValue(CollectionView.ItemTemplateProperty, WidgetDataTemplateSelector(node, unbox >> value.ItemTemplate))

                    collectionView.SetValue(CollectionView.GroupHeaderTemplateProperty, WidgetDataTemplateSelector(node, unbox >> value.HeaderTemplate))

                    if value.FooterTemplate.IsSome then
                        collectionView.SetValue(
                            CollectionView.GroupFooterTemplateProperty,
                            WidgetDataTemplateSelector(node, unbox >> value.FooterTemplate.Value)
                        )

                    collectionView.SetValue(CollectionView.ItemsSourceProperty, value.OriginalItems))

    let Header = Attributes.defineBindableWidget CollectionView.HeaderProperty

    let ItemSizingStrategy =
        Attributes.defineBindableEnum<ItemSizingStrategy> CollectionView.ItemSizingStrategyProperty

    let SelectionChanged =
        Attributes.Mvu.defineEvent<SelectionChangedEventArgs> "CollectionView_SelectionChanged" (fun target -> (target :?> CollectionView).SelectionChanged)

    let SelectionMode =
        Attributes.defineBindableEnum<SelectionMode> CollectionView.SelectionModeProperty

[<AutoOpen>]
module CollectionViewBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a CollectionView widget with a list of items</summary>
        /// <param name="items">The items list</param>
        static member inline CollectionView<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabView>(items: seq<'itemData>) =
            WidgetHelpers.buildItems<'msg, IFabCollectionView, 'itemData, 'itemMarker> CollectionView.WidgetKey ItemsView.ItemsSource items

        /// <summary>Create a CollectionView widget with a list of grouped items</summary>
        /// <param name="items">The grouped items list</param>
        static member inline GroupedCollectionView<'msg, 'groupData, 'groupMarker, 'itemData, 'itemMarker
            when 'msg: equality and 'itemMarker :> IFabView and 'groupMarker :> IFabView and 'groupData :> System.Collections.Generic.IEnumerable<'itemData>>
            (items: seq<'groupData>)
            =
            WidgetHelpers.buildGroupItems<'msg, IFabCollectionView, 'groupData, 'itemData, 'groupMarker, 'itemMarker>
                CollectionView.WidgetKey
                CollectionView.GroupedItemsSource
                items

[<Extension>]
type CollectionViewModifiers =
    /// <summary>Set the footer</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The footer widget</param>
    [<Extension>]
    static member inline footer(this: WidgetBuilder<'msg, #IFabCollectionView>, content: WidgetBuilder<'msg, #IFabView>) =
        this.AddWidget(CollectionView.Footer.WithValue(content.Compile()))

    /// <summary>Set the header</summary>
    /// <param name="this">Current widget</param>
    /// <param name="content">The header widget</param>
    [<Extension>]
    static member inline header(this: WidgetBuilder<'msg, #IFabCollectionView>, content: WidgetBuilder<'msg, #IFabView>) =
        this.AddWidget(CollectionView.Header.WithValue(content.Compile()))

    /// <summary>Set the item sizing strategy</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The item sizing strategy</param>
    [<Extension>]
    static member inline itemSizingStrategy(this: WidgetBuilder<'msg, #IFabCollectionView>, value: ItemSizingStrategy) =
        this.AddScalar(CollectionView.ItemSizingStrategy.WithValue(value))

    /// <summary>Listen for the SelectionChanged event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onSelectionChanged(this: WidgetBuilder<'msg, #IFabCollectionView>, fn: SelectionChangedEventArgs -> 'msg) =
        this.AddScalar(CollectionView.SelectionChanged.WithValue(fun args -> fn args |> box))

    /// <summary>Set the selection mode</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The selection mode</param>
    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #IFabCollectionView>, value: SelectionMode) =
        this.AddScalar(CollectionView.SelectionMode.WithValue(value))

    /// <summary>Link a ViewRef to access the direct CollectionView control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCollectionView>, value: ViewRef<CollectionView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
