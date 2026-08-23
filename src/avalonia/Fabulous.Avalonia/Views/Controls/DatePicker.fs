namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabDatePicker =
    inherit IFabTemplatedControl

module DatePicker =
    let WidgetKey = Widgets.register<DatePicker>()

    let DayVisible =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.DayVisibleProperty

    let MonthVisible =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MonthVisibleProperty

    let YearVisible =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.YearVisibleProperty

    let DayFormat =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.DayFormatProperty

    let MonthFormat =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MonthFormatProperty

    let YearFormat =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.YearFormatProperty

    let MinYear =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MinYearProperty

    let MaxYear =
        Attributes.defineAvaloniaPropertyWithEquality DatePicker.MaxYearProperty

type DatePickerModifiers =
    /// <summary>Sets the DayVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DayVisible value.</param>
    [<Extension>]
    static member inline dayVisible(this: WidgetBuilder<'msg, #IFabDatePicker>, value: bool) =
        this.AddScalar(DatePicker.DayVisible.WithValue(value))

    /// <summary>Sets the MonthVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MonthVisible value.</param>
    [<Extension>]
    static member inline monthVisible(this: WidgetBuilder<'msg, #IFabDatePicker>, value: bool) =
        this.AddScalar(DatePicker.MonthVisible.WithValue(value))

    /// <summary>Sets the YearVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The YearVisible value.</param>
    [<Extension>]
    static member inline yearVisible(this: WidgetBuilder<'msg, #IFabDatePicker>, value: bool) =
        this.AddScalar(DatePicker.YearVisible.WithValue(value))

    /// <summary>Sets the DayFormat property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DayFormat value.</param>
    [<Extension>]
    static member inline dayFormat(this: WidgetBuilder<'msg, #IFabDatePicker>, value: string) =
        this.AddScalar(DatePicker.DayFormat.WithValue(value))

    /// <summary>Sets the MonthFormat property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MonthFormat value.</param>
    [<Extension>]
    static member inline monthFormat(this: WidgetBuilder<'msg, #IFabDatePicker>, value: string) =
        this.AddScalar(DatePicker.MonthFormat.WithValue(value))

    /// <summary>Sets the YearFormat property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The YearFormat value.</param>
    [<Extension>]
    static member inline yearFormat(this: WidgetBuilder<'msg, #IFabDatePicker>, value: string) =
        this.AddScalar(DatePicker.YearFormat.WithValue(value))

    /// <summary>Sets the MinYear property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinYear value.</param>
    [<Extension>]
    static member inline minYear(this: WidgetBuilder<'msg, #IFabDatePicker>, value: DateTimeOffset) =
        this.AddScalar(DatePicker.MinYear.WithValue(value))

    /// <summary>Sets the MaxYear property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxYear value.</param>
    [<Extension>]
    static member inline maxYear(this: WidgetBuilder<'msg, #IFabDatePicker>, value: DateTimeOffset) =
        this.AddScalar(DatePicker.MaxYear.WithValue(value))

    /// <summary>Link a ViewRef to access the direct DatePicker control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDatePicker>, value: ViewRef<DatePicker>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
