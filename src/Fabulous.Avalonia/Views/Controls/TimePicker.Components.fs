namespace Fabulous.Avalonia

open System
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentTimePicker =
    let SelectedTimeChanged =
        Attributes.Component.defineAvaloniaPropertyWithChangedEvent
            "TimePicker_SelectedTimeChanged"
            TimePicker.SelectedTimeProperty
            Nullable
            Nullable.op_Explicit

[<AutoOpen>]
module ComponentTimePickerBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TimePicker widget.</summary>
        /// <param name="time">The initial time.</param>
        /// <param name="fn">Raised when the selected time changes.</param>
        static member TimePicker(time: TimeSpan, fn: TimeSpan -> unit) =
            WidgetBuilder<'msg, IFabTimePicker>(TimePicker.WidgetKey, ComponentTimePicker.SelectedTimeChanged.WithValue(ComponentValueEventData.create time fn))
