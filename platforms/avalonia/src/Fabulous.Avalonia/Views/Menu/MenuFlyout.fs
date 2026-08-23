namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabMenuFlyout =
    inherit IFabPopupFlyoutBase

module MenuFlyout =
    let WidgetKey = Widgets.register<MenuFlyout>()

    let Items =
        Attributes.defineAvaloniaNonGenericListWidgetCollection "MenuFlyout_Items" (fun target ->
            let target = target :?> MenuFlyout

            if target.Items = null then
                let newColl = ItemCollection.Empty
                target.Items.Add newColl |> ignore
                newColl
            else
                target.Items)

[<AutoOpen>]
module MenuFlyoutBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MenuFlyout widget.</summary>
        static member MenuFlyout() =
            CollectionBuilder<'msg, IFabMenuFlyout, IFabMenuItem>(MenuFlyout.WidgetKey, MenuFlyout.Items)

type MenuFlyoutModifiers =
    /// <summary>Link a ViewRef to access the direct MenuFlyout control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMenuFlyout>, value: ViewRef<MenuFlyout>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type MenuFlyoutCollectionBuilderExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMenuItem>
        (_: CollectionBuilder<'msg, 'marker, IFabMenuItem>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabMenuItem>
        (_: CollectionBuilder<'msg, 'marker, IFabMenuItem>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
