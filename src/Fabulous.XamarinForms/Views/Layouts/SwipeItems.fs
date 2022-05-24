namespace Fabulous.XamarinForms

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ISwipeItems =
    inherit IElement

module SwipeItems =

    let WidgetKey = Widgets.register<SwipeItems>()

    let SwipeItems =
        Attributes.defineListWidgetCollection
            "SwipeItems_SwipeItems"
            ViewNode.get
            (fun target -> (target :?> SwipeItems) :> IList<_>)

    let SwipeMode =
        Attributes.defineBindableEnum<SwipeMode> Xamarin.Forms.SwipeItems.ModeProperty

    let SwipeBehaviorOnInvoked =
        Attributes.defineBindableEnum<SwipeBehaviorOnInvoked> Xamarin.Forms.SwipeItems.SwipeBehaviorOnInvokedProperty

[<AutoOpen>]
module SwipeItemsBuilders =

    type Fabulous.XamarinForms.View with
        static member inline SwipeItems<'msg>() =
            CollectionBuilder<'msg, ISwipeItems, ISwipeItem>(SwipeItems.WidgetKey, SwipeItems.SwipeItems)

[<Extension>]
type SwipeItemsModifiers() =
    [<Extension>]
    static member inline swipeMode(this: WidgetBuilder<'msg, #ISwipeItems>, value: SwipeMode) =
        this.AddScalar(SwipeItems.SwipeMode.WithValue(value))

    [<Extension>]
    static member inline swipeBehaviorOnInvoked
        (
            this: WidgetBuilder<'msg, #ISwipeItems>,
            value: SwipeBehaviorOnInvoked
        ) =
        this.AddScalar(SwipeItems.SwipeBehaviorOnInvoked.WithValue(value))

    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ISwipeItems>, value: ViewRef<SwipeItems>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
