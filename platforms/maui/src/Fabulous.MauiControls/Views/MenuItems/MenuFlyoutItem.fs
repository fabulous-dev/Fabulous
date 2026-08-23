namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui.Controls

type IFabMenuFlyoutItem =
    inherit IFabMenuItem

module MenuFlyoutItem =
    let WidgetKey = Widgets.register<MenuFlyoutItem>()

    let KeyboardAccelerators =
        Attributes.defineListWidgetCollection<KeyboardAccelerator> "KeyboardAccelerators" (fun target -> (target :?> MenuFlyoutItem).KeyboardAccelerators)

[<AutoOpen>]
module MenuFlyoutItemBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a MenuItem widget with a text and a Click callback</summary>
        /// <param name="text">The text</param>
        /// <param name="onClicked">The click callback</param>
        static member inline MenuFlyoutItem<'msg when 'msg: equality>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, IFabMenuFlyoutItem>(MenuItem.WidgetKey, MenuItem.Text.WithValue(text), MenuItem.Clicked.WithValue(MsgValue(onClicked)))

[<Extension>]
type MenuFlyoutItemModifiers =
    /// <summary>Set the keyboard accelerators of this widget</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline keyboardAccelerators<'msg, 'marker when 'msg: equality and 'marker :> IFabMenuFlyoutItem>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IFabKeyboardAccelerator> MenuFlyoutItem.KeyboardAccelerators this

[<Extension>]
type MenuFlyoutItemYieldExtensions =
    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabMenuFlyoutItem, IFabKeyboardAccelerator>,
            x: WidgetBuilder<'msg, #IFabKeyboardAccelerator>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabMenuFlyoutItem, IFabKeyboardAccelerator>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabKeyboardAccelerator>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
