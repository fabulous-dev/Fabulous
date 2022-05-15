namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ICollectionView =
    inherit IItemsView

module CollectionView =
    let WidgetKey = Widgets.register<CollectionView>()

    let GroupedItemsSource<'groupData, 'itemData> =
        Attributes.defineScalarWithConverter<GroupedWidgetItems<'groupData, 'itemData>, GroupedWidgetItems<'groupData, 'itemData>, GroupedWidgetItems<'groupData, 'itemData>>
            "CollectionView_GroupedItemsSource"
            id
            id
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

                    collectionView.SetValue(
                        CollectionView.ItemTemplateProperty,
                        WidgetDataTemplateSelector(node, unbox >> value.ItemTemplate)
                    )

                    collectionView.SetValue(
                        CollectionView.GroupHeaderTemplateProperty,
                        WidgetDataTemplateSelector(node, unbox >> value.HeaderTemplate)
                    )

                    if value.FooterTemplate.IsSome then
                        collectionView.SetValue(
                            CollectionView.GroupFooterTemplateProperty,
                            WidgetDataTemplateSelector(node, unbox >> value.FooterTemplate.Value)
                        )

                    collectionView.SetValue(CollectionView.ItemsSourceProperty, value.OriginalItems))

    let SelectionMode =
        Attributes.defineBindableEnum<SelectionMode> CollectionView.SelectionModeProperty

    let Header =
        Attributes.defineBindableWidget CollectionView.HeaderProperty

    let Footer =
        Attributes.defineBindableWidget CollectionView.FooterProperty

    let ItemSizingStrategy =
        Attributes.defineBindableEnum<ItemSizingStrategy> CollectionView.ItemSizingStrategyProperty

    let SelectionChanged =
        Attributes.defineEvent<SelectionChangedEventArgs>
            "CollectionView_SelectionChanged"
            (fun target -> (target :?> CollectionView).SelectionChanged)

[<AutoOpen>]
module CollectionViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline CollectionView<'msg, 'itemData, 'itemMarker when 'itemMarker :> IView>
            (items: seq<'itemData>)
            =
            WidgetHelpers.buildItems<'msg, ICollectionView, 'itemData, 'itemMarker>
                CollectionView.WidgetKey
                ItemsView.ItemsSource
                items

        static member inline GroupedCollectionView<'msg, 'groupData, 'groupMarker, 'itemData, 'itemMarker when 'itemMarker :> IView and 'groupMarker :> IView and 'groupData :> System.Collections.Generic.IEnumerable<'itemData>>
            (items: seq<'groupData>)
            =
            WidgetHelpers.buildGroupItems<'msg, ICollectionView, 'groupData, 'itemData, 'groupMarker, 'itemMarker>
                CollectionView.WidgetKey
                CollectionView.GroupedItemsSource
                items

[<Extension>]
type CollectionViewModifiers =

    [<Extension>]
    static member inline selectionMode(this: WidgetBuilder<'msg, #ICollectionView>, value: SelectionMode) =
        this.AddScalar(CollectionView.SelectionMode.WithValue(value))

    [<Extension>]
    static member inline onSelectionChanged
        (
            this: WidgetBuilder<'msg, #ICollectionView>,
            onSelectionChanged: SelectionChangedEventArgs -> 'msg
        ) =
        this.AddScalar(CollectionView.SelectionChanged.WithValue(fun args -> onSelectionChanged args |> box))

    [<Extension>]
    static member inline header<'msg, 'marker, 'contentMarker when 'marker :> ICollectionView and 'contentMarker :> IView>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(CollectionView.Header.WithValue(content.Compile()))

    [<Extension>]
    static member inline footer<'msg, 'marker, 'contentMarker when 'marker :> ICollectionView and 'contentMarker :> IView>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(CollectionView.Footer.WithValue(content.Compile()))

    [<Extension>]
    static member inline itemSizingStrategy(this: WidgetBuilder<'msg, #ICollectionView>, value: ItemSizingStrategy) =
        this.AddScalar(CollectionView.ItemSizingStrategy.WithValue(value))

    /// <summary>Link a ViewRef to access the direct CollectionView control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ICollectionView>, value: ViewRef<CollectionView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
