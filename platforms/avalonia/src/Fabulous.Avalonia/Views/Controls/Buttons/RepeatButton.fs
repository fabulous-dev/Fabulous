namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabRepeatButton =
    inherit IFabButton

module RepeatButton =
    let WidgetKey = Widgets.register<RepeatButton>()

    let Delay = Attributes.defineAvaloniaPropertyWithEquality RepeatButton.DelayProperty

    let Interval =
        Attributes.defineAvaloniaPropertyWithEquality RepeatButton.IntervalProperty

type RepeatButtonModifiers =
    /// <summary>Sets the Delay property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Delay value.</param>
    [<Extension>]
    static member inline delay(this: WidgetBuilder<'msg, #IFabRepeatButton>, value: int) =
        this.AddScalar(RepeatButton.Delay.WithValue(value))

    /// <summary>Sets the Interval property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Interval value.</param>
    [<Extension>]
    static member inline interval(this: WidgetBuilder<'msg, #IFabRepeatButton>, value: int) =
        this.AddScalar(RepeatButton.Interval.WithValue(value))

    /// <summary>Link a ViewRef to access the direct RepeatButton control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRepeatButton>, value: ViewRef<RepeatButton>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
