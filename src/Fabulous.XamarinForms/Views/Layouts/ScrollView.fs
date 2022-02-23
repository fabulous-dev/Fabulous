namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IScrollView =
    inherit Fabulous.XamarinForms.ILayout

module ScrollView =
    let WidgetKey = Widgets.register<ScrollView> ()

    let Orientation =
        Attributes.defineBindable<ScrollOrientation> ScrollView.OrientationProperty

    let ScrollX =
        Attributes.defineBindable<float> ScrollView.ScrollXProperty

    let ScrollY =
        Attributes.defineBindable<float> ScrollView.ScrollYProperty

    let HorizontalScrollBarVisibility =
        Attributes.defineBindable<ScrollBarVisibility> ScrollView.HorizontalScrollBarVisibilityProperty

    let VerticalScrollBarVisibility =
        Attributes.defineBindable<ScrollBarVisibility> ScrollView.VerticalScrollBarVisibilityProperty

    let Content =
        Attributes.defineWidget
            "ScrollView_Content"
            (fun target -> ViewNode.get (target :?> ScrollView).Content)
            (fun target value -> (target :?> ScrollView).Content <- value)

    let Scrolled =
        Attributes.defineEvent<ScrolledEventArgs> "ScrollView_Scrolled" (fun target -> (target :?> ScrollView).Scrolled)

[<AutoOpen>]
module ScrollViewBuilders =
    type Fabulous.XamarinForms.View with
        static member inline ScrollView<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetHelpers.buildWidgets<'msg, IScrollView>
                ScrollView.WidgetKey
                [| ScrollView.Content.WithValue(content.Compile()) |]

[<Extension>]
type ScrollViewModifiers =

    /// <summary>Sets the scrolling direction of the ScrollView</summary>
    /// <param name="orientation">of type ScrollOrientation. The default value of this property is Vertical</param>
    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IScrollView>, value: ScrollOrientation) =
        this.AddScalar(ScrollView.Orientation.WithValue(value))

    /// <summary>Sets when the horizontal scroll bar is visible.</summary>
    /// <param name="value">of type ScrollBarVisibility.</param>
    [<Extension>]
    static member inline horizontalScrollBarVisibility
        (
            this: WidgetBuilder<'msg, #IScrollView>,
            value: ScrollBarVisibility
        ) =
        this.AddScalar(ScrollView.HorizontalScrollBarVisibility.WithValue(value))

    /// <summary>Sets when the vertical scroll bar is visible.</summary>
    /// <param name="value">of type ScrollBarVisibility.</param>
    [<Extension>]
    static member inline verticalScrollBarVisibility
        (
            this: WidgetBuilder<'msg, #IScrollView>,
            value: ScrollBarVisibility
        ) =
        this.AddScalar(ScrollView.VerticalScrollBarVisibility.WithValue(value))

    /// <summary>Sets the current X scroll position.</summary>
    /// <param name="value">of type float, The default value of this read-only property is 0.</param>
    [<Extension>]
    static member inline scrollX(this: WidgetBuilder<'msg, #IScrollView>, value: float) =
        this.AddScalar(ScrollView.ScrollX.WithValue(value))

    /// <summary>Sets the current Y scroll position.</summary>
    /// <param name="value">of type float, The default value of this read-only property is 0.</param>
    [<Extension>]
    static member inline scrollY(this: WidgetBuilder<'msg, #IScrollView>, value: float) =
        this.AddScalar(ScrollView.ScrollY.WithValue(value))

    /// <summary>Event that is fired when the scrollView is scrolled.</summary>
    /// <param name="onScrolled">Msg to dispatch when the scrollView is scrolled.</param>
    [<Extension>]
    static member inline onScrolled(this: WidgetBuilder<'msg, #IScrollView>, onScrolled: ScrolledEventArgs -> 'msg) =
        this.AddScalar(ScrollView.Scrolled.WithValue(fun args -> onScrolled args |> box))
