namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabCheckBox =
    inherit IFabView

module CheckBox =
    let WidgetKey = Widgets.register<CheckBox>()

    let Color = Attributes.defineBindableColor CheckBox.ColorProperty

    let IsCheckedWithEvent =
        Attributes.defineBindableWithEvent "CheckBox_CheckedChanged" CheckBox.IsCheckedProperty (fun target -> (target :?> CheckBox).CheckedChanged)

[<AutoOpen>]
module CheckBoxBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a CheckBox widget with a state and listen for state changes</summary>
        /// <param name="isChecked">The state of the checkbox</param>
        /// <param name="onCheckedChanged">Message to dispatch</param>
        static member inline CheckBox<'msg when 'msg: equality>(isChecked: bool, onCheckedChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabCheckBox>(
                CheckBox.WidgetKey,
                CheckBox.IsCheckedWithEvent.WithValue(ValueEventData.create isChecked (fun (args: CheckedChangedEventArgs) -> onCheckedChanged args.Value))
            )

[<Extension>]
type CheckBoxModifiers =
    /// <summary>Set the color of the check box</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the check box</param>
    [<Extension>]
    static member inline color(this: WidgetBuilder<'msg, #IFabCheckBox>, value: Color) =
        this.AddScalar(CheckBox.Color.WithValue(value))

    /// <summary>Link a ViewRef to access the direct CheckBox control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCheckBox>, value: ViewRef<CheckBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
