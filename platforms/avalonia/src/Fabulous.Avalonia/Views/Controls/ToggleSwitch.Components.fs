namespace Fabulous.Avalonia

open Avalonia.Animation
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

[<AutoOpen>]
module ComponentToggleSwitchBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a ToggleSwitch widget.</summary>
        /// <param name="isChecked">Whether the ToggleSwitch is checked.</param>
        /// <param name="fn">Raised when the ToggleSwitch value changes.</param>
        static member ToggleSwitch(isChecked: bool, fn: bool -> unit) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleButton.IsThreeState.WithValue(false),
                ComponentToggleButton.CheckedChanged.WithValue(ComponentValueEventData.create isChecked fn)
            )

        /// <summary>Creates a ThreeStateToggleSwitch widget.</summary>
        /// <param name="isChecked">Whether the ToggleSwitch is checked.</param>
        /// <param name="fn">Raised when the ToggleSwitch value changes.</param>
        static member ThreeStateToggleSwitch(isChecked: bool option, fn: bool option -> unit) =
            WidgetBuilder<'msg, IFabToggleSwitch>(
                ToggleSwitch.WidgetKey,
                ToggleButton.IsThreeState.WithValue(true),
                ComponentToggleButton.ThreeStateCheckedChanged.WithValue(
                    ComponentValueEventData.createVOption (ThreeState.fromOption(isChecked)) (ThreeState.toOption >> fn)
                )
            )
