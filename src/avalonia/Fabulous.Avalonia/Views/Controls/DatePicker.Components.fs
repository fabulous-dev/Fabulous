namespace Fabulous.Avalonia

open System
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentDatePicker =
    let SelectedDateChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent
            "DatePicker_SelectedDateChanged"
            DatePicker.SelectedDateProperty
            Nullable
            Nullable.op_Explicit

[<AutoOpen>]
module ComponentDatePickerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DatePicker widget.</summary>
        /// <param name="date">The initial date.</param>
        /// <param name="fn">Raised when the selected date changes.</param>
        static member DatePicker(date: DateTimeOffset, fn: DateTimeOffset -> unit) =
            WidgetBuilder<'msg, IFabDatePicker>(DatePicker.WidgetKey, ComponentDatePicker.SelectedDateChanged.WithValue(ComponentValueEventData.create date fn))
