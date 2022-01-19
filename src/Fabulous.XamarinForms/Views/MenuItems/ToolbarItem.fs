namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IToolbarItem =
    inherit IMenuItem

module ToolbarItem =
    let WidgetKey = Widgets.register<ToolbarItem> ()

    let Order =
        Attributes.define<ToolbarItemOrder>
            "ToolbarItem_Order"
            (fun newValueOpt node ->
                let toolbarItem = node.Target :?> ToolbarItem

                match newValueOpt with
                | ValueNone -> toolbarItem.Order <- ToolbarItemOrder.Default
                | ValueSome order -> toolbarItem.Order <- order)

[<AutoOpen>]
module ToolbarItemBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ToolbarItem<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IToolbarItem>(
                ToolbarItem.WidgetKey,
                MenuItem.Text.WithValue(text),
                MenuItem.Clicked.WithValue(onClicked)
            )

[<Extension>]
type ToolbarItemModifiers =
    [<Extension>]
    static member inline order(this: WidgetBuilder<'msg, #IToolbarItem>, value: ToolbarItemOrder) =
        this.AddScalar(ToolbarItem.Order.WithValue(value))
