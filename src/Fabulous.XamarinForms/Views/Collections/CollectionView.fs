namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ICollectionView =
    inherit IItemsView

module CollectionView =
    let WidgetKey = Widgets.register<CollectionView> ()

    let GroupedItemsSource<'groupData, 'itemData> =
        Attributes.defineScalarWithConverter<GroupedWidgetItems<'groupData, 'itemData>, GroupedWidgetItems<'groupData, 'itemData>, GroupedWidgetItems<'groupData, 'itemData>>
            "CollectionView_GroupedItemsSource"
            id
            id
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun newValueOpt node ->
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
    /// <summary>Link a ViewRef to access the direct CollectionView control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ICollectionView>, value: ViewRef<CollectionView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
