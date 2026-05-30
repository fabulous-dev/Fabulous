namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabSwipeItems =
    inherit IFabElement

module SwipeItems =
    let WidgetKey = Widgets.register<SwipeItems>()

    let SwipeBehaviorOnInvoked =
        Attributes.defineBindableEnum<SwipeBehaviorOnInvoked> SwipeItems.SwipeBehaviorOnInvokedProperty

    let SwipeItems =
        Attributes.defineListWidgetCollection "SwipeItems_SwipeItems" (fun target -> (target :?> SwipeItems) :> IList<_>)

    let SwipeMode =
        Attributes.defineBindableEnum<SwipeMode> Microsoft.Maui.Controls.SwipeItems.ModeProperty

[<AutoOpen>]
module SwipeItemsBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a SwipeItems widget</summary>
        static member inline SwipeItems<'msg when 'msg: equality>() =
            CollectionBuilder<'msg, IFabSwipeItems, IFabSwipeItem>(SwipeItems.WidgetKey, SwipeItems.SwipeItems)

[<Extension>]
type SwipeItemsModifiers =
    /// <summary>Set the swipe mode</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The swipe mode</param>
    [<Extension>]
    static member inline swipeMode(this: WidgetBuilder<'msg, #IFabSwipeItems>, value: SwipeMode) =
        this.AddScalar(SwipeItems.SwipeMode.WithValue(value))

    /// <summary>Set the swipe behavior when invoked</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The swipe behavior</param>
    [<Extension>]
    static member inline swipeBehaviorOnInvoked(this: WidgetBuilder<'msg, #IFabSwipeItems>, value: SwipeBehaviorOnInvoked) =
        this.AddScalar(SwipeItems.SwipeBehaviorOnInvoked.WithValue(value))

    /// <summary>Link a ViewRef to access the direct SwipeItems control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSwipeItems>, value: ViewRef<SwipeItems>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type SwipeItemsYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabSwipeItems, IFabSwipeItem>, x: WidgetBuilder<'msg, #IFabSwipeItem>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: CollectionBuilder<'msg, #IFabSwipeItems, IFabSwipeItem>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabSwipeItem>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
