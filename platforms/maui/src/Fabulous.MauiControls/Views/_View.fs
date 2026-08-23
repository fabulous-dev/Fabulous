namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.Controls

type IFabView =
    inherit IFabVisualElement

module View' =
    let GestureRecognizers =
        Attributes.defineListWidgetCollection<IGestureRecognizer> "View_GestureRecognizers" (fun target -> (target :?> View).GestureRecognizers)

    let HorizontalOptions =
        Attributes.defineSmallBindable<LayoutOptions> View.HorizontalOptionsProperty SmallScalars.LayoutOptions.decode

    let Margin = Attributes.defineBindableWithEquality<Thickness> View.MarginProperty

    let VerticalOptions =
        Attributes.defineSmallBindable<LayoutOptions> View.VerticalOptionsProperty SmallScalars.LayoutOptions.decode

[<Extension>]
type ViewModifiers =
    /// <summary>Set the gesture recognizers associated with this widget</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline gestureRecognizers<'msg, 'marker when 'msg: equality and 'marker :> IFabView>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IFabGestureRecognizer> View'.GestureRecognizers this

    /// <summary>Set the LayoutOptions that define how the widget gets laid in a layout cycle</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">A LayoutOptions which defines how to lay out the widget</param>
    [<Extension>]
    static member inline horizontalOptions(this: WidgetBuilder<'msg, #IFabView>, value: LayoutOptions) =
        this.AddScalar(View'.HorizontalOptions.WithValue(value))

    /// <summary>Set the LayoutOptions that define how the widget gets laid in a layout cycle</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">A LayoutOptions which defines how to lay out the widget</param>
    [<Extension>]
    static member inline verticalOptions(this: WidgetBuilder<'msg, #IFabView>, value: LayoutOptions) =
        this.AddScalar(View'.VerticalOptions.WithValue(value))

    /// <summary>Set the margin for the view</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The margin value</param>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabView>, value: Thickness) =
        this.AddScalar(View'.Margin.WithValue(value))

[<Extension>]
type ViewExtraModifiers =
    /// <summary>Align the widget at the horizontal end side</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline alignEndHorizontal(this: WidgetBuilder<'msg, #IFabView>) =
        this.horizontalOptions(LayoutOptions.End)

    /// <summary>Align the widget at the vertical end side</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline alignEndVertical(this: WidgetBuilder<'msg, #IFabView>) = this.verticalOptions(LayoutOptions.End)

    /// <summary>Align the widget at the horizontal start side</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline alignStartHorizontal(this: WidgetBuilder<'msg, #IFabView>) =
        this.horizontalOptions(LayoutOptions.Start)

    /// <summary>Align the widget at the vertical start side</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline alignStartVertical(this: WidgetBuilder<'msg, #IFabView>) =
        this.verticalOptions(LayoutOptions.Start)

    /// <summary>Center the widget horizontally</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabView>) =
        this.horizontalOptions(LayoutOptions.Center)

    /// <summary>Center the widget vertically</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IFabView>) =
        this.verticalOptions(LayoutOptions.Center)

    /// <summary>Center the widget horizontally and vertically</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabView>) =
        this.centerHorizontal().centerVertical()

    /// <summary>Fill the widget horizontally</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline fillHorizontal(this: WidgetBuilder<'msg, #IFabView>) =
        this.horizontalOptions(LayoutOptions.Fill)

    /// <summary>Fill the widget vertically</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline fillVertical(this: WidgetBuilder<'msg, #IFabView>) =
        this.verticalOptions(LayoutOptions.Fill)

    /// <summary>Set the margin for the view</summary>
    /// <param name="this">Current widget</param>
    /// <param name="uniformSize">The margin value uniformly applied to all sides</param>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabView>, uniformSize: float) = this.margin(Thickness(uniformSize))

    /// <summary>Set the margin for the view</summary>
    /// <param name="this">Current widget</param>
    /// <param name="left">The left margin value</param>
    /// <param name="top">The top margin value</param>
    /// <param name="right">The right margin value</param>
    /// <param name="bottom">The bottom margin value</param>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabView>, left: float, top: float, right: float, bottom: float) =
        this.margin(Thickness(left, top, right, bottom))

[<Extension>]
type ViewYieldExtensions =
    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabView, IFabGestureRecognizer>,
            x: WidgetBuilder<'msg, #IFabGestureRecognizer>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabView, IFabGestureRecognizer>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabGestureRecognizer>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

[<Extension>]
type ViewAttachedCollectionModifiers =
    /// <summary>Set the gesture recognizer associated with this widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The gesture recognizer</param>
    [<Extension>]
    static member gestureRecognizer(this: WidgetBuilder<'msg, #IFabView>, value: WidgetBuilder<'msg, #IFabGestureRecognizer>) =
        this.gestureRecognizers() { value }
