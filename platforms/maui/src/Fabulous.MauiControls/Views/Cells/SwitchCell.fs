namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabSwitchCell =
    inherit IFabCell

module SwitchCell =
    let WidgetKey = Widgets.register<SwitchCell>()

    let OnColor = Attributes.defineBindableColor SwitchCell.OnColorProperty

    let OnWithEvent =
        Attributes.defineBindableWithEvent "SwitchCell_OnChanged" SwitchCell.OnProperty (fun target -> (target :?> SwitchCell).OnChanged)

    let Text = Attributes.defineBindableWithEquality SwitchCell.TextProperty

[<AutoOpen>]
module SwitchCellBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a SwitchCell with a text, a toggle state, and listen to toggle state changes</summary>
        /// <param name="text">The text value</param>
        /// <param name="value">The toggle state value</param>
        /// <param name="onChanged">Change callback</param>
        static member inline SwitchCell<'msg when 'msg: equality>(text: string, value: bool, onChanged: bool -> 'msg) =
            WidgetBuilder<'msg, IFabSwitchCell>(
                SwitchCell.WidgetKey,
                SwitchCell.OnWithEvent.WithValue(ValueEventData.create value (fun (args: ToggledEventArgs) -> onChanged args.Value)),
                SwitchCell.Text.WithValue(text)
            )

[<Extension>]
type SwitchCellModifiers =
    /// <summary>Set the color of the on state</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the on state in the light theme.</param>
    [<Extension>]
    static member inline colorOn(this: WidgetBuilder<'msg, #IFabSwitchCell>, value: Color) =
        this.AddScalar(SwitchCell.OnColor.WithValue(value))

    /// <summary>Link a ViewRef to access the direct SwitchCell control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSwitchCell>, value: ViewRef<SwitchCell>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
