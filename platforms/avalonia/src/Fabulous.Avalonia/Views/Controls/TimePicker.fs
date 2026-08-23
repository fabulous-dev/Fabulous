namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabTimePicker =
    inherit IFabTemplatedControl

module TimePicker =
    let WidgetKey = Widgets.register<TimePicker>()

    let ClockIdentifier =
        Attributes.defineAvaloniaPropertyWithEquality TimePicker.ClockIdentifierProperty

    let MinuteIncrement =
        Attributes.defineAvaloniaPropertyWithEquality TimePicker.MinuteIncrementProperty

    let SecondIncrement =
        Attributes.defineAvaloniaPropertyWithEquality TimePicker.SecondIncrementProperty

    let UseSeconds =
        Attributes.defineAvaloniaPropertyWithEquality TimePicker.UseSecondsProperty

type TimePickerModifiers =

    /// <summary>Sets the ClockIdentifier property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClockIdentifier value.</param>
    [<Extension>]
    static member inline clockIdentifier(this: WidgetBuilder<'msg, #IFabTimePicker>, value: string) =
        this.AddScalar(TimePicker.ClockIdentifier.WithValue(value))

    /// <summary>Sets the MinuteIncrement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinuteIncrement value.</param>
    [<Extension>]
    static member inline minuteIncrement(this: WidgetBuilder<'msg, #IFabTimePicker>, value: int) =
        this.AddScalar(TimePicker.MinuteIncrement.WithValue(value))


    /// <summary>Sets the SecondIncrement property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SecondIncrement value.</param>
    [<Extension>]
    static member inline secondIncrement(this: WidgetBuilder<'msg, #IFabTimePicker>, value: int) =
        this.AddScalar(TimePicker.SecondIncrement.WithValue(value))

    /// <summary>Sets the UseSeconds property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The UseSeconds value.</param>
    [<Extension>]
    static member inline useSeconds(this: WidgetBuilder<'msg, #IFabTimePicker>, value: bool) =
        this.AddScalar(TimePicker.UseSeconds.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TimePicker control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTimePicker>, value: ViewRef<TimePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type TimePickerExtraModifiers =
    /// <summary>Sets the ClockIdentifier property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClockIdentifier value.</param>
    [<Extension>]
    static member inline use24HourClock(this: WidgetBuilder<'msg, #IFabTimePicker>, value: bool) =
        this.AddScalar(TimePicker.ClockIdentifier.WithValue(if value then "24HourClock" else "12HourClock"))
