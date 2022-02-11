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

    let RemainingItemsThreshold =
        Attributes.defineBindable<int> CarouselView.RemainingItemsThresholdProperty

    let HorizontalScrollBarVisibility =
        Attributes.defineBindable<ScrollBarVisibility> CarouselView.HorizontalScrollBarVisibilityProperty

    let IsBounceEnabled =
        Attributes.defineBindable<bool> CarouselView.IsBounceEnabledProperty

    let PeekAreaInsets =
        Attributes.defineBindable<Thickness> CarouselView.PeekAreaInsetsProperty

    let RemainingItemsThresholdReached =
        Attributes.defineEventNoArg
            "CarouselView_RemainingItemsThresholdReached"
            (fun target ->
                (target :?> CarouselView)
                    .RemainingItemsThresholdReached)


    let CurrentItem =
        Attributes.define<obj>
            "CarouselView_CurrentItem"
            (fun newValueOpt node ->
                let carouselView = node.Target :?> CarouselView

                match newValueOpt with
                | ValueNone -> carouselView.CurrentItem <- null
                | ValueSome currentItem -> carouselView.CurrentItem <- currentItem)

    let Loop =
        Attributes.defineBindable<bool> CarouselView.LoopProperty

    let PositionChanged =
        Attributes.defineEvent<PositionChangedEventArgs>
            "CarouselView_PositionChanged"
            (fun target -> (target :?> CarouselView).PositionChanged)

    let Position =
        Attributes.defineBindable<int> CarouselView.PositionProperty

[<AutoOpen>]
module CarouselViewViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline CarouselView<'msg, 'itemData, 'itemMarker when 'itemMarker :> IView>
            (items: seq<'itemData>)
            =
            WidgetHelpers.buildItems<'msg, ICarouselView, 'itemData, 'itemMarker>
                CarouselView.WidgetKey
                ItemsView.ItemsSource
                items

[<Extension>]
type CarouselViewModifiers =
    [<Extension>]
    static member inline remainingItemsThreshold
        (
            this: WidgetBuilder<'msg, #ICarouselView>,
            value: int,
            onThresholdReached: 'msg
        ) =
        this
            .AddScalar(CarouselView.RemainingItemsThreshold.WithValue(value))
            .AddScalar(CarouselView.RemainingItemsThresholdReached.WithValue(onThresholdReached))

    [<Extension>]
    static member inline horizontalScrollBarVisibility
        (
            this: WidgetBuilder<'msg, #ICarouselView>,
            value: ScrollBarVisibility
        ) =
        this.AddScalar(CarouselView.HorizontalScrollBarVisibility.WithValue(value))

    [<Extension>]
    static member inline isBounceEnabled(this: WidgetBuilder<'msg, #ICarouselView>, value: bool) =
        this.AddScalar(CarouselView.IsBounceEnabled.WithValue(value))

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
    static member inline onPositionChanged
        (
            this: WidgetBuilder<'msg, #ICarouselView>,
            onPositionChanged: int -> 'msg
        ) =
        this.AddScalar(
            CarouselView.PositionChanged.WithValue(fun args -> onPositionChanged args.CurrentPosition |> box)
        )

    [<Extension>]
    static member inline position(this: WidgetBuilder<'msg, #ICarouselView>, value: int) =
        this.AddScalar(CarouselView.Position.WithValue(value))
        
    [<Extension>]
    static member inline currentItem(this: WidgetBuilder<'msg, #ICarouselView>, value: int) =
        this.AddScalar(CarouselView.CurrentItem.WithValue(value))
