namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type IItemsViewOfCell =
    inherit IItemsView

module ItemsViewOfCell =
    let ItemsSource<'T> =
        Attributes.defineBindableWithComparer<WidgetItems<'T>, WidgetItems<'T>, System.Collections.Generic.IEnumerable<Widget>>
            Xamarin.Forms.ItemsView<Cell>.ItemsSourceProperty
            id
            (fun modelValue ->
                seq {
                    for x in modelValue.OriginalItems do
                        modelValue.Template x
                })
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)

    let GroupedItemsSource<'T> =
        Attributes.defineBindableWithComparer<GroupedWidgetItems<'T>, GroupedWidgetItems<'T>, System.Collections.Generic.IEnumerable<GroupItem>>
            Xamarin.Forms.ItemsView<Cell>.ItemsSourceProperty
            id
            (fun modelValue ->
                seq {
                    for x in modelValue.OriginalItems do
                        modelValue.Template x
                })
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
