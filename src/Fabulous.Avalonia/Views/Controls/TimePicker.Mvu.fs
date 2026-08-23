namespace Fabulous.Avalonia

open System
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuTimePicker =
    let SelectedTimeChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent "TimePicker_SelectedTimeChanged" TimePicker.SelectedTimeProperty Nullable Nullable.op_Explicit

[<AutoOpen>]
module MvuTimePickerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TimePicker widget.</summary>
        /// <param name="time">The initial time.</param>
        /// <param name="fn">Raised when the selected time changes.</param>
        static member TimePicker(time: TimeSpan, fn: TimeSpan -> 'msg) =
            WidgetBuilder<'msg, IFabTimePicker>(TimePicker.WidgetKey, MvuTimePicker.SelectedTimeChanged.WithValue(ValueEventData.create time fn))
