namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabSwitch =
    inherit IFabView

module Switch =
    let WidgetKey = Widgets.register<Switch>()

    let ColorOn = Attributes.defineBindableColor Switch.OnColorProperty

    let ThumbColor = Attributes.defineBindableColor Switch.ThumbColorProperty

    let IsToggledWithEvent =
        Attributes.defineBindableWithEvent "Switch_Toggled" Switch.IsToggledProperty (fun target -> (target :?> Switch).Toggled)

[<AutoOpen>]
module SwitchBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Switch widget with a toggle state and listen for toggle state changes</summary>
        /// <param name="isToggled">The toggle state</param>
        /// <param name="onToggled">Message to dispatch</param>
        static member inline Switch<'msg when 'msg: equality>(isToggled: bool, onToggled: bool -> 'msg) =
            WidgetBuilder<'msg, IFabSwitch>(
                Switch.WidgetKey,
                Switch.IsToggledWithEvent.WithValue(ValueEventData.create isToggled (fun (args: ToggledEventArgs) -> onToggled args.Value))
            )

[<Extension>]
type SwitchModifiers =
    /// <summary>Set the color of the on state</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the on state</param>
    [<Extension>]
    static member inline colorOn(this: WidgetBuilder<'msg, #IFabSwitch>, value: Color) =
        this.AddScalar(Switch.ColorOn.WithValue(value))

    /// <summary>Set the color of the thumb</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the thumb</param>
    [<Extension>]
    static member inline thumbColor(this: WidgetBuilder<'msg, #IFabSwitch>, value: Color) =
        this.AddScalar(Switch.ThumbColor.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Switch control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSwitch>, value: ViewRef<Switch>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
