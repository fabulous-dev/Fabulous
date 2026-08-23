namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuCalendarDatePicker =
    let SelectedDateChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent
            "CalendarDatePicker_SelectedDateChanged"
            CalendarDatePicker.SelectedDateProperty
            Option.toNullable
            Option.ofNullable

    let DateValidationError =
        Attributes.Mvu.defineEvent "CalendarDatePicker_DateValidationError" (fun target -> (target :?> CalendarDatePicker).DateValidationError)

    let CalendarClosed =
        Attributes.Mvu.defineEventNoArg "CalendarDatePicker_CalendarClosed" (fun target -> (target :?> CalendarDatePicker).CalendarClosed)

    let CalendarOpened =
        Attributes.Mvu.defineEventNoArg "CalendarDatePicker_CalendarOpened" (fun target -> (target :?> CalendarDatePicker).CalendarOpened)

[<AutoOpen>]
module MvuCalendarDatePickerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a CalendarDatePicker widget.</summary>
        /// <param name="date">The selected date.</param>
        /// <param name="fn">Raised when the selected date changes.</param>
        static member CalendarDatePicker(date: DateTime option, fn: DateTime option -> 'msg) =
            WidgetBuilder<'msg, IFabCalendarDatePicker>(
                CalendarDatePicker.WidgetKey,
                MvuCalendarDatePicker.SelectedDateChanged.WithValue(ValueEventData.create date fn)
            )

type MvuCalendarDatePickerModifiers =
    /// <summary>Listens to the CalendarDatePicker DateValidationError event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DatePicker detects a format error.</param>
    [<Extension>]
    static member inline onDateValidationError(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, fn: CalendarDatePickerDateValidationErrorEventArgs -> 'msg) =
        this.AddScalar(MvuCalendarDatePicker.DateValidationError.WithValue(fn))

    /// <summary>Listens to the CalendarDatePicker CalendarClosed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DatePicker closes its calendar.</param>
    [<Extension>]
    static member inline onCalendarClosed(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, fn: 'msg) =
        this.AddScalar(MvuCalendarDatePicker.CalendarClosed.WithValue(MsgValue fn))

    /// <summary>Listens to the CalendarDatePicker CalendarOpened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DatePicker opens its calendar.</param>
    [<Extension>]
    static member inline onCalendarOpened(this: WidgetBuilder<'msg, #IFabCalendarDatePicker>, fn: 'msg) =
        this.AddScalar(MvuCalendarDatePicker.CalendarOpened.WithValue(MsgValue fn))
