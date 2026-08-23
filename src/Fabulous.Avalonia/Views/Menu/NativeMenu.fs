namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabNativeMenu =
    inherit IFabNativeMenuItemBase

module NativeMenu =
    let WidgetKey = Widgets.register<NativeMenu>()

    let Items =
        Attributes.defineAvaloniaListWidgetCollection "NativeMenu_Items" (fun target -> (target :?> NativeMenu).Items)

[<AutoOpen>]
module NativeMenuBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a NativeMenu widget</summary>
        static member NativeMenu() =
            CollectionBuilder<'msg, IFabNativeMenu, IFabNativeMenuItem>(NativeMenu.WidgetKey, NativeMenu.Items)

module NativeMenuAttached =
    let NativeMenu = Attributes.defineAvaloniaPropertyWidget NativeMenu.MenuProperty

    let IsNativeMenuExported =
        Attributes.defineAvaloniaPropertyWithEquality Avalonia.Controls.NativeMenu.IsNativeMenuExportedProperty

type NativeMenuModifiers =

    /// <summary>Link a ViewRef to access the direct NativeMenu control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabNativeMenu>, value: ViewRef<NativeMenu>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type NativeMenuAttachedModifiers =
    /// <summary>Sets the IsNativeMenuExported property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsNativeMenuExported value.</param>
    [<Extension>]
    static member inline isNativeMenuExported(this: WidgetBuilder<'msg, #IFabTopLevel>, value: bool) =
        this.AddScalar(NativeMenuAttached.IsNativeMenuExported.WithValue(value))

    /// <summary>Sets the Menu property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Menu value.</param>
    [<Extension>]
    static member inline menu(this: WidgetBuilder<'msg, #IFabNativeMenuItem>, value: WidgetBuilder<'msg, #IFabNativeMenu>) =
        this.AddWidget(NativeMenuItem.Menu.WithValue(value.Compile()))

type WindowMenuAttachedModifiers =
    /// <summary>Sets the NativeMenu property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The NativeMenu value.</param>
    [<Extension>]
    static member inline menu(this: WidgetBuilder<'msg, #IFabWindow>, value: WidgetBuilder<'msg, #IFabNativeMenu>) =
        this.AddWidget(NativeMenuAttached.NativeMenu.WithValue(value.Compile()))

type NativeViewYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabNativeMenu, IFabNativeMenuItem>, x: WidgetBuilder<'msg, #IFabNativeMenuItem>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (_: CollectionBuilder<'msg, #IFabNativeMenu, IFabNativeMenuItem>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabNativeMenuItem>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
