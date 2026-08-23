namespace Fabulous.Avalonia

open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia


module MvuNumericUpDown =
    let ValueChanged =
        Attributes.Mvu.defineAvaloniaPropertyWithChangedEvent "NumericUpDown_ValueChanged" NumericUpDown.ValueProperty Option.toNullable Option.ofNullable

[<AutoOpen>]
module MvuNumericUpDownBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a NumericUpDown widget.</summary>
        /// <param name="value">The value of the NumericUpDown.</param>
        /// <param name="fn">Raised when the NumericUpDown value changes.</param>
        static member NumericUpDown(value: float option, fn: float option -> 'msg) =
            WidgetBuilder<'msg, IFabNumericUpDown>(
                NumericUpDown.WidgetKey,
                MvuNumericUpDown.ValueChanged.WithValue(
                    let value =
                        match value with
                        | Some v -> Some(decimal v)
                        | None -> None

                    ValueEventData.create value (Option.map float >> fn)
                )
            )

        /// <summary>Creates a NumericUpDown widget.</summary>
        /// <param name="min">The minimum value of the NumericUpDown.</param>
        /// <param name="max">The maximum value of the NumericUpDown.</param>
        /// <param name="value">The value of the NumericUpDown.</param>
        /// <param name="fn">Raised when the NumericUpDown value changes.</param>
        static member NumericUpDown(min: float, max: float, value: float option, fn: float option -> 'msg) =
            WidgetBuilder<'msg, IFabNumericUpDown>(
                NumericUpDown.WidgetKey,
                NumericUpDown.MinimumMaximum.WithValue(struct (decimal min, decimal max)),
                MvuNumericUpDown.ValueChanged.WithValue(
                    let value =
                        match value with
                        | Some v -> Some(decimal v)
                        | None -> None

                    ValueEventData.create value (Option.map float >> fn)
                )
            )
