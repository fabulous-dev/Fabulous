namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IItemsViewOfCell =
    inherit IView

module ItemsViewOfCell =
    let ItemsSource<'T> =
        Attributes.defineSimpleScalar<WidgetItems<'T>>
            "ItemsViewOfCell_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsView = node.Target :?> ItemsView<Cell>

                match newValueOpt with
                | ValueNone ->
                    itemsView.ClearValue(ItemsView<Cell>.ItemTemplateProperty)
                    itemsView.ClearValue(ItemsView<Cell>.ItemsSourceProperty)
                | ValueSome value ->
                    itemsView.SetValue(
                        ItemsView<Cell>.ItemTemplateProperty,
                        WidgetDataTemplateSelector(node, unbox >> value.Template)
                    )

                    itemsView.SetValue(ItemsView<Cell>.ItemsSourceProperty, value.OriginalItems))
