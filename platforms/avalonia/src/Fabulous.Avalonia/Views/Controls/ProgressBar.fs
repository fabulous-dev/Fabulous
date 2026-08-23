namespace Fabulous.Avalonia

open Avalonia.Controls
open Avalonia.Layout
open System.Runtime.CompilerServices

open Fabulous

type IFabProgressBar =
    inherit IFabRangeBase

module ProgressBar =
    let WidgetKey = Widgets.register<ProgressBar>()

    let IsIndeterminate =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.IsIndeterminateProperty

    let Orientation =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.OrientationProperty

    let Percentage =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.PercentageProperty

    let ProgressTextFormat =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.ProgressTextFormatProperty

    let ShowProgressText =
        Attributes.defineAvaloniaPropertyWithEquality ProgressBar.ShowProgressTextProperty

type ProgressBarModifiers =
    /// <summary>Sets the IsIndeterminate property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsIndeterminate value.</param>
    [<Extension>]
    static member inline isIndeterminate(this: WidgetBuilder<'msg, #IFabProgressBar>, value: bool) =
        this.AddScalar(ProgressBar.IsIndeterminate.WithValue(value))

    /// <summary>Sets the Orientation property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Orientation value.</param>
    [<Extension>]
    static member inline orientation(this: WidgetBuilder<'msg, #IFabProgressBar>, value: Orientation) =
        this.AddScalar(ProgressBar.Orientation.WithValue(value))

    /// <summary>Sets the Percentage property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Percentage value.</param>
    [<Extension>]
    static member inline percentage(this: WidgetBuilder<'msg, #IFabProgressBar>, value: float) =
        this.AddScalar(ProgressBar.Percentage.WithValue(value))

    /// <summary>Sets the ProgressTextFormat property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ProgressTextFormat value.</param>
    [<Extension>]
    static member inline progressTextFormat(this: WidgetBuilder<'msg, #IFabProgressBar>, value: string) =
        this.AddScalar(ProgressBar.ProgressTextFormat.WithValue(value))

    /// <summary>Sets the ShowProgressText property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ShowProgressText value.</param>
    [<Extension>]
    static member inline showProgressText(this: WidgetBuilder<'msg, #IFabProgressBar>, value: bool) =
        this.AddScalar(ProgressBar.ShowProgressText.WithValue(value))

    /// <summary>Link a ViewRef to access the direct ProgressBar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabProgressBar>, value: ViewRef<ProgressBar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
