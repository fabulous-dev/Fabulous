namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type ICarouselView =
    inherit IItemsView

module CarouselView =

    let WidgetKey =
        Widgets.registerWithAdditionalSetup<CarouselView>
            (fun target node -> target.ItemTemplate <- SimpleWidgetDataTemplateSelector(node))

    let IsBounceEnabled =
        Attributes.defineBindable<bool> CarouselView.IsBounceEnabledProperty

    let IsDragging =
        Attributes.defineBindable<bool> CarouselView.IsDraggingProperty

    let IsScrollAnimated =
        Attributes.defineBindable<bool> CarouselView.IsScrollAnimatedProperty

    let IsSwipeEnabled =
        Attributes.defineBindable<bool> CarouselView.IsSwipeEnabledProperty

    let Loop =
        Attributes.defineBindable<bool> CarouselView.LoopProperty

    let PeekAreaInsets =
        Attributes.defineBindable<Thickness> CarouselView.PeekAreaInsetsProperty

    let CurrentItem =
        Attributes.define<obj>
            "CarouselView_CurrentItem"
            (fun newValueOpt node ->
                let carouselView = node.Target :?> CarouselView

                match newValueOpt with
                | ValueNone -> carouselView.CurrentItem <- null
                | ValueSome currentItem -> carouselView.CurrentItem <- currentItem)

    let PositionChanged =
        Attributes.defineEvent<PositionChangedEventArgs>
            "CarouselView_PositionChanged"
            (fun target -> (target :?> CarouselView).PositionChanged)

    let Position =
        Attributes.defineBindable<int> CarouselView.PositionProperty

[<AutoOpen>]
module CarouselViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline CarouselView<'msg, 'itemData, 'itemMarker when 'itemMarker :> IView>
            (items: seq<'itemData>)
            =
            WidgetHelpers.buildItems<'msg, ICarouselView, 'itemData, 'itemMarker>
                CarouselView.WidgetKey
                ItemsView.ItemsSource
                items

        static member inline CarouselView<'msg, 'itemData, 'itemMarker when 'itemMarker :> IView>
            (
                items: seq<'itemData>,
                position: int,
                positionChanged: int -> 'msg
            ) =
            WidgetHelpers.buildItemsWithScalars<'msg, ICarouselView, 'itemData, 'itemMarker>
                CarouselView.WidgetKey
                (CarouselView.Position.WithValue(position))
                (CarouselView.PositionChanged.WithValue(fun e -> positionChanged e.CurrentPosition |> box))
                ItemsView.ItemsSource
                items

[<Extension>]
type CarouselViewModifiers =
    /// <summary>Sets the IsBounceEnabled property.</summary>
    /// <param name="value">true if Bounce is enabled; otherwise, false.</param>
    [<Extension>]
    static member inline isBounceEnabled(this: WidgetBuilder<'msg, #ICarouselView>, value: bool) =
        this.AddScalar(CarouselView.IsBounceEnabled.WithValue(value))

    /// <summary>Sets the IsDragging property.</summary>
    /// <param name="value">true if Dragging is enabled; otherwise, false.</param>
    [<Extension>]
    static member inline isDragging(this: WidgetBuilder<'msg, #ICarouselView>, value: bool) =
        this.AddScalar(CarouselView.IsDragging.WithValue(value))

    /// <summary>Sets the IsScrollAnimated property.</summary>
    /// <param name="value">true if scroll is animated; otherwise, false.</param>
    [<Extension>]
    static member inline isScrollAnimated(this: WidgetBuilder<'msg, #ICarouselView>, value: bool) =
        this.AddScalar(CarouselView.IsScrollAnimated.WithValue(value))

    /// <summary>Sets the IsSwipeEnabled property.</summary>
    /// <param name="value">true if Swipe is enabled; otherwise, false.</param>
    [<Extension>]
    static member inline isSwipeEnabled(this: WidgetBuilder<'msg, #ICarouselView>, value: bool) =
        this.AddScalar(CarouselView.IsSwipeEnabled.WithValue(value))

    /// <summary>Sets the Loop property.</summary>
    /// <param name="value">true if Loop is enabled; otherwise, false.</param>
    [<Extension>]
    static member inline loop(this: WidgetBuilder<'msg, #ICarouselView>, value: bool) =
        this.AddScalar(CarouselView.Loop.WithValue(value))

    [<Extension>]
    static member inline peekAreaInsets(this: WidgetBuilder<'msg, #ICarouselView>, value: Thickness) =
        this.AddScalar(CarouselView.PeekAreaInsets.WithValue(value))

    [<Extension>]
    static member inline peekAreaInsets(this: WidgetBuilder<'msg, #ICarouselView>, value: float) =
        CarouselViewModifiers.peekAreaInsets (this, Thickness(value))

    [<Extension>]
    static member inline peekAreaInsets
        (
            this: WidgetBuilder<'msg, #ICarouselView>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        CarouselViewModifiers.peekAreaInsets (this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline currentItem(this: WidgetBuilder<'msg, #ICarouselView>, value: obj) =
        this.AddScalar(CarouselView.CurrentItem.WithValue(value))
