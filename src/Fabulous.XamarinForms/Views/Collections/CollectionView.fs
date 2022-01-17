namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ICollectionView =
    inherit IItemsView

module CollectionView =
    let WidgetKey =
        Widgets.registerWithAdditionalSetup<CollectionView>
            (fun target node -> target.ItemTemplate <- SimpleWidgetDataTemplateSelector(node))
            
    let GroupedWidgetKey =
        Widgets.registerWithAdditionalSetup<CollectionView>
            (fun target node ->
                target.ItemTemplate <- SimpleWidgetDataTemplateSelector(node)
                target.GroupHeaderTemplate <- GroupedWidgetDataTemplateSelector(node, Header)
                target.GroupFooterTemplate <- GroupedWidgetDataTemplateSelector(node, Footer)
                target.IsGrouped <- true)

    let RemainingItemsThreshold =
        Attributes.defineBindable<int> CollectionView.RemainingItemsThresholdProperty

    let RemainingItemsThresholdReached =
        Attributes.defineEventNoArg
            "CollectionView_RemainingItemsThresholdReached"
            (fun target ->
                (target :?> CollectionView)
                    .RemainingItemsThresholdReached)

[<AutoOpen>]
module CollectionViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline CollectionView<'msg, 'itemData, 'itemMarker when 'itemMarker :> IView>(items: seq<'itemData>) =
            WidgetHelpers.buildItems<'msg, ICollectionView, 'itemData, 'itemMarker>
                CollectionView.WidgetKey
                ItemsView.ItemsSource
                items

        static member inline GroupedCollectionView<'msg, 'groupData, 'groupMarker, 'itemData, 'itemMarker when 'itemMarker :> IView and 'groupMarker :> IView and 'groupData :> System.Collections.Generic.IEnumerable<'itemData>>
            (items: seq<'groupData>)
            =
            WidgetHelpers.buildGroupItems<'msg, ICollectionView, 'groupData, 'itemData, 'groupMarker, 'itemMarker>
                CollectionView.GroupedWidgetKey
                ItemsView.GroupedItemsSource
                items
            
[<Extension>]
type CollectionViewModifiers =
    [<Extension>]
    static member inline remainingItemsThreshold(this: WidgetBuilder<'msg, #ICollectionView>, value: int, onThresholdReached: 'msg) =
        this
            .AddScalar(CollectionView.RemainingItemsThreshold.WithValue(value))
            .AddScalar(CollectionView.RemainingItemsThresholdReached.WithValue(onThresholdReached))