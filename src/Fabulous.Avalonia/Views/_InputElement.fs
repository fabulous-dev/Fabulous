namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Input
open Fabulous

type IFabInputElement =
    inherit IFabInteractive

module InputElement =

    let Focusable =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.FocusableProperty

    let IsEnabled =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsEnabledProperty

    let Cursor =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.CursorProperty

    let IsHitTestVisible =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsHitTestVisibleProperty

    let IsTabStop =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.IsTabStopProperty

    let TabIndex =
        Attributes.defineAvaloniaPropertyWithEquality InputElement.TabIndexProperty

type InputElementModifiers =
    /// <summary>Sets the Focusable property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Focusable value.</param>
    [<Extension>]
    static member inline focusable(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.Focusable.WithValue(value))

    /// <summary>Sets the IsEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsEnabled value.</param>
    [<Extension>]
    static member inline isEnabled(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsEnabled.WithValue(value))

    /// <summary>Sets the Cursor property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Cursor value.</param>
    [<Extension>]
    static member inline cursor(this: WidgetBuilder<'msg, #IFabInputElement>, value: Cursor) =
        this.AddScalar(InputElement.Cursor.WithValue(value))

    /// <summary>Sets the IsHitTestVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsHitTestVisible value.</param>
    [<Extension>]
    static member inline isHitTestVisible(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsHitTestVisible.WithValue(value))

    /// <summary>Sets the IsTabStop property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsTabStop value.</param>
    [<Extension>]
    static member inline isTabStop(this: WidgetBuilder<'msg, #IFabInputElement>, value: bool) =
        this.AddScalar(InputElement.IsTabStop.WithValue(value))

    /// <summary>Sets the TabIndex property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TabIndex value.</param>
    [<Extension>]
    static member inline tabIndex(this: WidgetBuilder<'msg, #IFabInputElement>, value: int) =
        this.AddScalar(InputElement.TabIndex.WithValue(value))
