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
        Attributes.defineBindableBool CarouselView.IsBounceEnabledProperty

    let IsDragging =
        Attributes.defineBindableBool CarouselView.IsDraggingProperty

    let IsScrollAnimated =
        Attributes.defineBindableBool CarouselView.IsScrollAnimatedProperty

    let IsSwipeEnabled =
        Attributes.defineBindableBool CarouselView.IsSwipeEnabledProperty

    let Loop =
        Attributes.defineBindableBool CarouselView.LoopProperty

    let PeekAreaInsets =
        Attributes.defineBindableWithEquality<Thickness> CarouselView.PeekAreaInsetsProperty

    let IndicatorView =
        Attributes.defineSimpleScalarWithEquality<ViewRef<IndicatorView>>
            "CarouselView_IndicatorView"
            (fun oldValueOpt newValueOpt node ->
                let handlerOpt =
                    node.TryGetHandler<EventHandler<IndicatorView>>(ViewRefAttributes.ViewRef.Name)

                // Clean up previous handler
                if handlerOpt.IsSome then
                    match struct (oldValueOpt, newValueOpt) with
                    | struct (ValueSome prev, _) -> prev.Attached.RemoveHandler(handlerOpt.Value)

                    | struct (ValueNone, ValueSome curr) ->
                        // Despite not having a previous value, we might still be reusing the same ViewRef
                        // So we still need to clean up
                        curr.Attached.RemoveHandler(handlerOpt.Value)

                    | struct (ValueNone, ValueNone) -> ()

                    node.SetHandler(ViewRefAttributes.ViewRef.Name, ValueNone)

                let handler =
                    match handlerOpt with
                    | ValueSome handler -> handler
                    | ValueNone ->
                        let newHandler =
                            EventHandler<IndicatorView>
                                (fun viewRef indicatorView ->
                                    let carouselView = node.Target :?> CarouselView

                                    if carouselView <> null then
                                        carouselView.IndicatorView <- indicatorView
                                    else
                                        // CarouselView has been disposed, clean up the handler
                                        let handler =
                                            node
                                                .TryGetHandler<EventHandler<IndicatorView>>(
                                                    ViewRefAttributes.ViewRef.Name
                                                )
                                                .Value

                                        (viewRef :?> ViewRef<IndicatorView>)
                                            .Attached.RemoveHandler(handler))

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
