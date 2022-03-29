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
            (fun _ newValueOpt node ->
                let toolbarItem = node.Target :?> ToolbarItem

                match newValueOpt with
                | ValueNone -> toolbarItem.Order <- ToolbarItemOrder.Default
                | ValueSome order -> toolbarItem.Order <- order)

    let Priority =
        Attributes.define<int>
            "ToolbarItem_Priority"
            (fun _ newValueOpt node ->
                let toolbarItem = node.Target :?> ToolbarItem

                match newValueOpt with
                | ValueNone -> toolbarItem.Priority <- 0
                | ValueSome priority -> toolbarItem.Priority <- priority)

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

    [<Extension>]
    static member inline priority(this: WidgetBuilder<'msg, #IToolbarItem>, value: int) =
        this.AddScalar(ToolbarItem.Priority.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ToolbarItem control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IToolbarItem>, value: ViewRef<ToolbarItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
