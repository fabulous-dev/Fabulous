namespace Fabulous.Avalonia

open Avalonia.Animation
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

[<AutoOpen>]
module MvuToggleSwitchBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ToggleSwitch widget.</summary>
        /// <param name="isChecked">Whether the ToggleSwitch is checked.</param>
        /// <param name="fn">Raised when the ToggleSwitch value changes.</param>
        static member ToggleSwitch(isChecked: bool, fn: bool -> 'msg) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleButton.IsThreeState.WithValue(false),
                MvuToggleButton.CheckedChanged.WithValue(ValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ThreeStateToggleSwitch widget.</summary>
        /// <param name="isChecked">Whether the ToggleSwitch is checked.</param>
        /// <param name="fn">Raised when the ToggleSwitch value changes.</param>
        static member ThreeStateToggleSwitch(isChecked: bool option, fn: bool option -> 'msg) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                MvuToggleButton.ThreeStateCheckedChanged.WithValue(ValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn))
            )
