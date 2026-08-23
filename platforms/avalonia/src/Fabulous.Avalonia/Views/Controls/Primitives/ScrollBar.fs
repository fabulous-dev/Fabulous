namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Avalonia.Layout
open Fabulous

type IFabScrollBar =
    inherit IFabRangeBase

module ScrollBar =
    let WidgetKey = Widgets.register<ScrollBar>()

    let ViewportSize =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.ViewportSizeProperty

    let Visibility =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.VisibilityProperty

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.OrientationProperty

    let AllowAutoHide =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.AllowAutoHideProperty

    let HideDelay =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.HideDelayProperty

    let ShowDelay =
        Attributes.defineAvaloniaPropertyWithEquality ScrollBar.ShowDelayProperty


type ScrollBarModifiers =

    /// <summary>Sets the ViewportSize property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewportSize value.</param>
    [<Extension>]
    static member inline viewportSize(this: WidgetBuilder<'msg, #IFabScrollBar>, value: float) =
        this.AddScalar(ScrollBar.ViewportSize.WithValue(value))

    /// <summary>Sets the Visibility property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Visibility value.</param>
    [<Extension>]
    static member inline visibility(this: WidgetBuilder<'msg, #IFabScrollBar>, value: ScrollBarVisibility) =
        this.AddScalar(ScrollBar.Visibility.WithValue(value))

    /// <summary>Sets the Orientation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Orientation value.</param>
    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IFabScrollBar>, value: Orientation) =
        this.AddScalar(ScrollBar.Orientation.WithValue(value))

    /// <summary>Sets the AllowAutoHide property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AllowAutoHide value.</param>
    [<Extension>]
    static member inline allowAutoHide(this: WidgetBuilder<'msg, #IFabScrollBar>, value: bool) =
        this.AddScalar(ScrollBar.AllowAutoHide.WithValue(value))

    /// <summary>Sets the HideDelay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HideDelay value.</param>
    [<Extension>]
    static member inline hideDelay(this: WidgetBuilder<'msg, #IFabScrollBar>, value: TimeSpan) =
        this.AddScalar(ScrollBar.HideDelay.WithValue(value))

    /// <summary>Sets the ShowDelay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowDelay value.</param>
    [<Extension>]
    static member inline showDelay(this: WidgetBuilder<'msg, #IFabScrollBar>, value: TimeSpan) =
        this.AddScalar(ScrollBar.ShowDelay.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ScrollBar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabScrollBar>, value: ViewRef<ScrollBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
