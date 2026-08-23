namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous

type IFabCalendar =
    inherit IFabTemplatedControl

module Calendar =
    let WidgetKey = Widgets.register<Calendar>()

    let FirstDayOfWeek =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.FirstDayOfWeekProperty

    let IsTodayHighlighted =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.IsTodayHighlightedProperty

    let HeaderBackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget Calendar.HeaderBackgroundProperty

    let HeaderBackground =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.HeaderBackgroundProperty

    let DisplayMode =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.DisplayModeProperty

    let SelectionMode =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.SelectionModeProperty

    let DisplayDate =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.DisplayDateProperty

    let DisplayDateStart =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.DisplayDateStartProperty

    let DisplayDateEnd =
        Attributes.defineAvaloniaPropertyWithEquality Calendar.DisplayDateEndProperty

type CalendarModifiers =
    /// <summary>Sets the FirstDayOfWeek property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FirstDayOfWeek value.</param>
    [<Extension>]
    static member inline firstDayOfWeek(this: WidgetBuilder<'msg, #IFabCalendar>, value: DayOfWeek) =
        this.AddScalar(Calendar.FirstDayOfWeek.WithValue(value))

    /// <summary>Sets the IsTodayHighlighted property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsTodayHighlighted value.</param>
    [<Extension>]
    static member inline isTodayHighlighted(this: WidgetBuilder<'msg, #IFabCalendar>, value: bool) =
        this.AddScalar(Calendar.IsTodayHighlighted.WithValue(value))

    /// <summary>Sets the HeaderBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HeaderBackground value.</param>
    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Calendar.HeaderBackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the HeaderBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HeaderBackground value.</param>
    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, value: IBrush) =
        this.AddScalar(Calendar.HeaderBackground.WithValue(value))

    /// <summary>Sets the HeaderBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HeaderBackground value.</param>
    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, value: Color) =
        CalendarModifiers.headerBackground(this, View.SolidColorBrush(value))

    /// <summary>Sets the HeaderBackground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HeaderBackground value.</param>
    [<Extension>]
    static member inline headerBackground(this: WidgetBuilder<'msg, #IFabCalendar>, value: string) =
        CalendarModifiers.headerBackground(this, View.SolidColorBrush(value))

    /// <summary>Sets the DisplayMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayMode value.</param>
    [<Extension>]
    static member inline displayMode(this: WidgetBuilder<'msg, #IFabCalendar>, value: CalendarMode) =
        this.AddScalar(Calendar.DisplayMode.WithValue(value))

    /// <summary>Sets the DisplayDate property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayDate value.</param>
    [<Extension>]
    static member inline displayDate(this: WidgetBuilder<'msg, #IFabCalendar>, value: DateTime) =
        this.AddScalar(Calendar.DisplayDate.WithValue(value))

    /// <summary>Sets the DisplayDateStart property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayDateStart value.</param>
    [<Extension>]
    static member inline displayDateStart(this: WidgetBuilder<'msg, #IFabCalendar>, value: DateTime) =
        this.AddScalar(Calendar.DisplayDateStart.WithValue(value))

    /// <summary>Sets the DisplayDateEnd property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The DisplayDateEnd value.</param>
    [<Extension>]
    static member inline displayDateEnd(this: WidgetBuilder<'msg, #IFabCalendar>, value: DateTime) =
        this.AddScalar(Calendar.DisplayDateEnd.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Calendar control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCalendar>, value: ViewRef<Calendar>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
