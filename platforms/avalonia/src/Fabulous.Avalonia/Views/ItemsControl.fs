namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Data
open Fabulous

type IFabItemsControl =
    inherit IFabTemplatedControl

module ItemsControl =
    let WidgetKey = Widgets.register<ItemsControl>()

    let Items =
        Attributes.defineAvaloniaNonGenericListWidgetCollection "ItemsControl_Items" (fun target ->
            let target = target :?> ItemsControl

            if target.Items = null then
                let newColl = ItemCollection.Empty
                target.Items.Add newColl |> ignore
                newColl
            else
                target.Items)


    let ItemsSourceTemplate =
        Attributes.defineSimpleScalar<WidgetItems>
            "ItemsControl_ItemsSource"
            (fun a b -> ScalarAttributeComparers.equalityCompare a.OriginalItems b.OriginalItems)
            (fun _ newValueOpt node ->
                let itemsControl = node.Target :?> ItemsControl

                match newValueOpt with
                | ValueNone ->
                    itemsControl.ClearValue(ItemsControl.ItemTemplateProperty)
                    itemsControl.ClearValue(ItemsControl.ItemsSourceProperty)
                | ValueSome value ->
                    itemsControl.SetValue(ItemsControl.ItemTemplateProperty, WidgetDataTemplate(node, unbox >> value.Template))
                    |> ignore

                    itemsControl.SetValue(ItemsControl.ItemsSourceProperty, value.OriginalItems)
                    |> ignore)

    let ItemsSource =
        Attributes.defineAvaloniaPropertyWithEquality ItemsControl.ItemsSourceProperty

    let ItemsPanel =
        Attributes.defineSimpleScalar<Widget> "ItemsControl_ItemsPanel" ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let itemsControl = node.Target :?> ItemsControl

            match newValueOpt with
            | ValueNone -> itemsControl.ClearValue(ItemsControl.ItemsPanelProperty)
            | ValueSome value ->
                itemsControl.SetValue(ItemsControl.ItemsPanelProperty, WidgetItemsPanel(node, value))
                |> ignore)

    let DisplayMemberBinding =
        Attributes.defineAvaloniaPropertyWithEquality ItemsControl.DisplayMemberBindingProperty

[<AutoOpen>]
module ItemsControlBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates an ItemsControl widget.</summary>
        /// <param name="items">The items to display.</param>
        /// <param name="template">The template to use for each item.</param>
        static member ItemsControl<'msg, 'itemData, 'itemMarker when 'msg: equality and 'itemMarker :> IFabControl>
            (items: seq<'itemData>, template: 'itemData -> WidgetBuilder<'msg, 'itemMarker>)
            =
            WidgetHelpers.buildItems<'msg, IFabItemsControl, 'itemData, 'itemMarker> ItemsControl.WidgetKey ItemsControl.ItemsSourceTemplate items template

type ItemsControlModifiers =

    /// <summary>Sets the ItemsPanel property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ItemsPanel value.</param>
    [<Extension>]
    static member inline itemsPanel(this: WidgetBuilder<'msg, #IFabItemsControl>, value: WidgetBuilder<'msg, #IFabPanel>) =
        this.AddScalar(ItemsControl.ItemsPanel.WithValue(value.Compile()))

    /// <summary>Sets the DisplayMemberBinding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayMemberBinding value.</param>
    [<Extension>]
    static member inline displayMemberBinding(this: WidgetBuilder<'msg, #IFabItemsControl>, value: IBinding) =
        this.AddScalar(ItemsControl.DisplayMemberBinding.WithValue(value))
