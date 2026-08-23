namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuCalendar =
    let SelectedDateChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent "Calendar_SelectedDateChanged" Calendar.SelectedDateProperty Option.toNullable Option.ofNullable

    let DisplayDateChanged =
        Attributes.Mvu.defineEvent "Calendar_DisplayDateChanged" (fun target -> (target :?> Calendar).DisplayDateChanged)

    let DisplayModeChanged =
        Attributes.Mvu.defineEvent "Calendar_DisplayModeChanged" (fun target -> (target :?> Calendar).DisplayModeChanged)

[<AutoOpen>]
module MvuCalendarBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a Calendar widget.</summary>
        /// <param name="date">The date to display.</param>
        /// <param name="fn">Raised when the date changes.</param>
        static member Calendar(date: DateTime option, fn: DateTime option -> 'msg) =
            WidgetBuilder<'msg, IFabCalendar>(
                Calendar.WidgetKey,
                Calendar.SelectionMode.WithValue(CalendarSelectionMode.SingleDate),
                MvuCalendar.SelectedDateChanged.WithValue(ValueEventData.create date fn)
            )

        /// <summary>Creates a Calendar widget.</summary>
        /// <param name="date">The date to display.</param>
        /// <param name="fn">Raised when the date changes.</param>
        /// <param name="mode">The selection mode.</param>
        static member Calendar(date: DateTime option, fn: DateTime option -> 'msg, mode: CalendarSelectionMode) =
            WidgetBuilder<'msg, IFabCalendar>(
                Calendar.WidgetKey,
                Calendar.SelectionMode.WithValue(mode),
                MvuCalendar.SelectedDateChanged.WithValue(ValueEventData.create date fn)
            )

type MvuCalendarModifiers =
    /// <summary>Listens to the Calendar DisplayDateChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DisplayDateChanged event is fired.</param>
    [<Extension>]
    static member inline onDisplayDateChanged(this: WidgetBuilder<'msg, #IFabCalendar>, fn: CalendarDateChangedEventArgs -> 'msg) =
        this.AddScalar(MvuCalendar.DisplayDateChanged.WithValue(fn))

    /// <summary>Listens to the Calendar DisplayModeChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the DisplayModeChanged event is fired.</param>
    [<Extension>]
    static member inline onDisplayModeChanged(this: WidgetBuilder<'msg, #IFabCalendar>, fn: CalendarModeChangedEventArgs -> 'msg) =
        this.AddScalar(MvuCalendar.DisplayModeChanged.WithValue(fn))
