namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabToolbarItem =
    inherit IFabMenuItem

module ToolbarItem =
    let WidgetKey = Widgets.register<ToolbarItem>()

    let Order =
        Attributes.defineEnum<ToolbarItemOrder> "ToolbarItem_Order" (fun _ newValueOpt node ->
            let toolbarItem = node.Target :?> ToolbarItem

            match newValueOpt with
            | ValueNone -> toolbarItem.Order <- ToolbarItemOrder.Default
            | ValueSome order -> toolbarItem.Order <- order)

    let Priority =
        Attributes.defineInt "ToolbarItem_Priority" (fun _ newValueOpt node ->
            let toolbarItem = node.Target :?> ToolbarItem

            match newValueOpt with
            | ValueNone -> toolbarItem.Priority <- 0
            | ValueSome priority -> toolbarItem.Priority <- priority)

[<AutoOpen>]
module ToolbarItemBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a ToolbarItem widget with a text and a Click callback</summary>
        /// <param name="text">The text</param>
        /// <param name="onClicked">The click callback</param>
        static member inline ToolbarItem<'msg when 'msg: equality>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabToolbarItem>(ToolbarItem.WidgetKey, MenuItem.Text.WithValue(text), MenuItem.Clicked.WithValue(MsgValue(onClicked)))

[<Extension>]
type ToolbarItemModifiers =
    /// <summary>Set a value that indicates on which of the primary, secondary, or default toolbar surfaces to display</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The order value</param>
    [<Extension>]
    static member inline order(this: WidgetBuilder<'msg, #IFabToolbarItem>, value: ToolbarItemOrder) =
        this.AddScalar(ToolbarItem.Order.WithValue(value))

    /// <summary>Set the priority of this ToolbarItem element</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The priority value</param>
    [<Extension>]
    static member inline priority(this: WidgetBuilder<'msg, #IFabToolbarItem>, value: int) =
        this.AddScalar(ToolbarItem.Priority.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ToolbarItem control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabToolbarItem>, value: ViewRef<ToolbarItem>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
