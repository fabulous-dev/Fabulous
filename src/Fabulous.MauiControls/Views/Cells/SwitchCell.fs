namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type ISwitchCell =
    inherit Fabulous.Maui.ICell

module SwitchCell =
    let WidgetKey = Widgets.register<SwitchCell>()

    let Text =
        Attributes.defineBindableWithEquality<string> SwitchCell.TextProperty

    let OnWithEvent =
        Attributes.defineBindableWithEvent
            "SwitchCell_OnChanged"
            SwitchCell.OnProperty
            (fun target -> (target :?> SwitchCell).OnChanged)

    let OnColor =
        Attributes.defineBindableAppThemeColor SwitchCell.OnColorProperty

[<AutoOpen>]
module SwitchCellBuilders =
    type Fabulous.Maui.View with
        static member inline SwitchCell<'msg>(text: string, value: bool, onChanged: bool -> 'msg) =
            WidgetBuilder<'msg, ISwitchCell>(
                SwitchCell.WidgetKey,
                SwitchCell.OnWithEvent.WithValue(ValueEventData.create value (fun args -> onChanged args.Value |> box)),
                SwitchCell.Text.WithValue(text)
            )

[<Extension>]
type SwitchCellModifiers =
    /// <summary>Set the color of the on state</summary>
    /// <param name="light">The color of the on state in the light theme.</param>
    /// <param name="dark">The color of the on state in the dark theme.</param>
    [<Extension>]
    static member inline colorOn(this: WidgetBuilder<'msg, #ISwitchCell>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(SwitchCell.OnColor.WithValue(AppTheme.create light dark))

    /// <summary>Link a ViewRef to access the direct SwitchCell control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ISwitchCell>, value: ViewRef<SwitchCell>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
