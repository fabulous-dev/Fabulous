namespace Fabulous.XamarinForms

open System
open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ICarouselView =
    inherit IItemsView

module CarouselView =
    let WidgetKey = Widgets.register<CarouselView>()

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

    let IndicatorView =
        Attributes.defineScalarWithConverter<ViewRef<IndicatorView>, _, _>
            "CarouselView_IndicatorView"
            id
            id
            ScalarAttributeComparers.equalityCompare
            (fun _ newValueOpt node ->
                let handler =
                    match node.TryGetHandler<EventHandler<IndicatorView>>(ViewRefAttributes.ViewRef.Name) with
                    | ValueSome handler -> handler
                    | ValueNone ->
                        let newHandler =
                            EventHandler<IndicatorView>
                                (fun _ indicatorView -> (node.Target :?> CarouselView).IndicatorView <- indicatorView)

                        newHandler

                match newValueOpt with
                | ValueNone -> node.SetHandler(ViewRefAttributes.ViewRef.Name, ValueNone)
                | ValueSome curr ->
                    curr.Attached.AddHandler(handler)
                    node.SetHandler(ViewRefAttributes.ViewRef.Name, ValueSome handler))

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
        CarouselViewModifiers.peekAreaInsets(this, Thickness(value))

    [<Extension>]
    static member inline peekAreaInsets
        (
            this: WidgetBuilder<'msg, #ICarouselView>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        CarouselViewModifiers.peekAreaInsets(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline indicatorView(this: WidgetBuilder<'msg, #ICarouselView>, value: ViewRef<IndicatorView>) =
        this.AddScalar(CarouselView.IndicatorView.WithValue(value))

    /// <summary>Link a ViewRef to access the direct CarouselView control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ICarouselView>, value: ViewRef<CarouselView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
