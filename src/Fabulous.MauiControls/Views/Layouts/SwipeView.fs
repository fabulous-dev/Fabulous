namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type ISwipeView =
    inherit Fabulous.Maui.IContentView

module SwipeView =

    let WidgetKey = Widgets.register<SwipeView>()

    let LeftSwipeItems =
        Attributes.defineBindableWidget SwipeView.LeftItemsProperty

    let TopSwipeItems =
        Attributes.defineBindableWidget SwipeView.TopItemsProperty

    let RightSwipeItems =
        Attributes.defineBindableWidget SwipeView.RightItemsProperty

    let BottomSwipeItems =
        Attributes.defineBindableWidget SwipeView.BottomItemsProperty

    let SwipeThreshold =
        Attributes.defineBindableInt SwipeView.ThresholdProperty

    let SwipeStarted =
        Attributes.defineEvent<SwipeStartedEventArgs>
            "SwipeView_SwipeStarted"
            (fun target -> (target :?> SwipeView).SwipeStarted)

    let SwipeChanging =
        Attributes.defineEvent<SwipeChangingEventArgs>
            "SwipeView_SwipeChanging"
            (fun target -> (target :?> SwipeView).SwipeChanging)

    let SwipeEnded =
        Attributes.defineEvent<SwipeEndedEventArgs>
            "SwipeView_SwipeEnded"
            (fun target -> (target :?> SwipeView).SwipeEnded)

    let OpenRequested =
        Attributes.defineEvent<OpenRequestedEventArgs>
            "SwipeView_OpenRequested"
            (fun target -> (target :?> SwipeView).OpenRequested)

    let CloseRequested =
        Attributes.defineEvent<CloseRequestedEventArgs>
            "SwipeView_CloseRequested"
            (fun target -> (target :?> SwipeView).CloseRequested)

[<AutoOpen>]
module SwipeViewBuilders =

    type Fabulous.Maui.View with
        static member inline SwipeView<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, ISwipeView>
                SwipeView.WidgetKey
                [| ContentView.Content.WithValue(content.Compile()) |]

[<Extension>]
type SwipeViewModifiers() =

    [<Extension>]
    static member inline leftItems<'msg, 'marker, 'contentMarker when 'marker :> ISwipeView and 'contentMarker :> ISwipeItems>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(SwipeView.LeftSwipeItems.WithValue(content.Compile()))

    [<Extension>]
    static member inline topItems<'msg, 'marker, 'contentMarker when 'marker :> ISwipeView and 'contentMarker :> ISwipeItems>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(SwipeView.TopSwipeItems.WithValue(content.Compile()))

    [<Extension>]
    static member inline rightItems<'msg, 'marker, 'contentMarker when 'marker :> ISwipeView and 'contentMarker :> ISwipeItems>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(SwipeView.RightSwipeItems.WithValue(content.Compile()))

    [<Extension>]
    static member inline bottomItems<'msg, 'marker, 'contentMarker when 'marker :> ISwipeView and 'contentMarker :> ISwipeItems>
        (
            this: WidgetBuilder<'msg, 'marker>,
            content: WidgetBuilder<'msg, 'contentMarker>
        ) =
        this.AddWidget(SwipeView.BottomSwipeItems.WithValue(content.Compile()))

    [<Extension>]
    static member inline threshold(this: WidgetBuilder<'msg, #ISwipeView>, threshold: int) =
        this.AddScalar(SwipeView.SwipeThreshold.WithValue(threshold))

    [<Extension>]
    static member inline onSwipeStarted
        (
            this: WidgetBuilder<'msg, #ISwipeView>,
            onSwipeStarted: SwipeStartedEventArgs -> 'msg
        ) =
        this.AddScalar(SwipeView.SwipeStarted.WithValue(fun args -> onSwipeStarted args |> box))

    [<Extension>]
    static member inline onSwipeChanging
        (
            this: WidgetBuilder<'msg, #ISwipeView>,
            onSwipeChanging: SwipeChangingEventArgs -> 'msg
        ) =
        this.AddScalar(SwipeView.SwipeChanging.WithValue(fun args -> onSwipeChanging args |> box))

    [<Extension>]
    static member inline onSwipeEnded
        (
            this: WidgetBuilder<'msg, #ISwipeView>,
            onSwipeEnded: SwipeEndedEventArgs -> 'msg
        ) =
        this.AddScalar(SwipeView.SwipeEnded.WithValue(fun args -> onSwipeEnded args |> box))

    [<Extension>]
    static member inline onOpenRequested
        (
            this: WidgetBuilder<'msg, #ISwipeView>,
            onOpenRequested: OpenRequestedEventArgs -> 'msg
        ) =
        this.AddScalar(SwipeView.OpenRequested.WithValue(fun args -> onOpenRequested args |> box))

    [<Extension>]
    static member inline onCloseRequested
        (
            this: WidgetBuilder<'msg, #ISwipeView>,
            onCloseRequested: CloseRequestedEventArgs -> 'msg
        ) =
        this.AddScalar(SwipeView.CloseRequested.WithValue(fun args -> onCloseRequested args |> box))

    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ISwipeView>, value: ViewRef<SwipeView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
