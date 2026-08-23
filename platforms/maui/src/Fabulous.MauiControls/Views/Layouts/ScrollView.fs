namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

// TODO: Create a single attribute for both ScrollPosition and Scrolled to avoid issues with programmatic changes

[<Struct>]
type ScrollToData = { X: float; Y: float }

type IFabScrollView =
    inherit IFabLayout

module ScrollView =
    let WidgetKey = Widgets.register<ScrollView>()

    let Content =
        Attributes.definePropertyWidget "ScrollView_Content" (fun target -> (target :?> ScrollView).Content :> obj) (fun target value ->
            (target :?> ScrollView).Content <- value)

    let HorizontalScrollBarVisibility =
        Attributes.defineBindableEnum<ScrollBarVisibility> ScrollView.HorizontalScrollBarVisibilityProperty

    let Orientation =
        Attributes.defineBindableEnum<ScrollOrientation> ScrollView.OrientationProperty

    let Scrolled =
        Attributes.Mvu.defineEvent<ScrolledEventArgs> "ScrollView_Scrolled" (fun target -> (target :?> ScrollView).Scrolled)

    let ScrollPosition =
        Attributes.defineSimpleScalarWithEquality<ScrollToData> "ScrollView_ScrollPosition" (fun _ newValueOpt node ->
            let view = node.Target :?> ScrollView

            match newValueOpt with
            | ValueNone -> view.ScrollToAsync(0., 0., false) |> ignore
            | ValueSome data -> view.ScrollToAsync(data.X, data.Y, false) |> ignore)

    let VerticalScrollBarVisibility =
        Attributes.defineBindableEnum<ScrollBarVisibility> ScrollView.VerticalScrollBarVisibilityProperty

module ScrollViewAnimations =
    let ScrollTo =
        Attributes.defineSimpleScalarWithEquality<ScrollToData> "ScrollView_ScrollTo" (fun _ newValueOpt node ->
            let view = node.Target :?> ScrollView

            match newValueOpt with
            | ValueNone -> view.ScrollToAsync(0., 0., true) |> ignore
            | ValueSome data -> view.ScrollToAsync(data.X, data.Y, true) |> ignore)

[<AutoOpen>]
module ScrollViewBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a ScrollView widget with a content</summary>
        /// <param name="content">The content of the ScrollView</param>
        static member inline ScrollView<'msg, 'marker when 'msg: equality and 'marker :> IFabView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IFabScrollView> ScrollView.WidgetKey [| ScrollView.Content.WithValue(content.Compile()) |]

[<Extension>]
type ScrollViewModifiers =
    /// <summary>Set the horizontal scrollbar visibility</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The horizontal scrollbar visibility</param>
    [<Extension>]
    static member inline horizontalScrollBarVisibility(this: WidgetBuilder<'msg, #IFabScrollView>, value: ScrollBarVisibility) =
        this.AddScalar(ScrollView.HorizontalScrollBarVisibility.WithValue(value))

    /// <summary>Set the supported scrolling directions of the ScrollView</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The scrolling direction</param>
    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IFabScrollView>, value: ScrollOrientation) =
        this.AddScalar(ScrollView.Orientation.WithValue(value))

    /// <summary>Set the scroll position</summary>
    /// <param name="this">Current widget</param>
    /// <param name="x">The X position of scroll</param>
    /// <param name="y">The Y position of scroll</param>
    [<Extension>]
    static member inline scrollPosition(this: WidgetBuilder<'msg, #IFabScrollView>, x: float, y: float) =
        this.AddScalar(ScrollView.ScrollPosition.WithValue({ X = x; Y = y }))

    /// <summary>Set the vertical scrollbar visibility</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The horizontal scrollbar visibility</param>
    [<Extension>]
    static member inline verticalScrollBarVisibility(this: WidgetBuilder<'msg, #IFabScrollView>, value: ScrollBarVisibility) =
        this.AddScalar(ScrollView.VerticalScrollBarVisibility.WithValue(value))

    /// <summary>Listen for the Scrolled event</summary>
    /// <param name="this">Current widget</param>
    /// <param name="fn">Message to dispatch</param>
    [<Extension>]
    static member inline onScrolled(this: WidgetBuilder<'msg, #IFabScrollView>, fn: ScrolledEventArgs -> 'msg) =
        this.AddScalar(ScrollView.Scrolled.WithValue(fun args -> fn args |> box))

    /// <summary>Link a ViewRef to access the direct ScrollView control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabScrollView>, value: ViewRef<ScrollView>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type ScrollViewAnimationModifiers =
    /// <summary>Animate the scroll position</summary>
    /// <param name="this">Current widget</param>
    /// <param name="x">The X position of the finished scroll</param>
    /// <param name="y">The Y position of the finished scroll</param>
    [<Extension>]
    static member inline scrollTo(this: WidgetBuilder<'msg, #IFabScrollView>, x: float, y: float) =
        this.AddScalar(ScrollViewAnimations.ScrollTo.WithValue({ X = x; Y = y }))
