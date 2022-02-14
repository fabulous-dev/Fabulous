namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type ISwitchCell =
    inherit ICell

module SwitchCell =
    let WidgetKey = Widgets.register<SwitchCell> ()

    let On =
        Attributes.defineBindable<bool> SwitchCell.OnProperty

    let Text =
        Attributes.defineBindable<string> SwitchCell.TextProperty

    let OnChanged =
        Attributes.defineEvent<ToggledEventArgs>
            "SwitchCell_OnChanged"
            (fun target -> (target :?> SwitchCell).OnChanged)

    let OnColor =
        Attributes.defineAppThemeBindable<Color> SwitchCell.OnColorProperty

[<AutoOpen>]
module SwitchCellBuilders =
    type Fabulous.XamarinForms.View with
        static member inline SwitchCell<'msg>(text: string, value: bool, onChanged: bool -> 'msg) =
            WidgetBuilder<'msg, ISwitchCell>(
                SwitchCell.WidgetKey,
                SwitchCell.On.WithValue(value),
                SwitchCell.Text.WithValue(text),
                SwitchCell.OnChanged.WithValue(fun args -> onChanged args.Value |> box)
            )

[<Extension>]
type SwitchCellModifiers =
    /// <summary>Set the color of the on state</summary>
    /// <param name="light">The color of the on state in the light theme.</param>
    /// <param name="dark">The color of the on state in the dark theme.</param>
    [<Extension>]
    static member inline colorOn(this: WidgetBuilder<'msg, #ISwitchCell>, light: Color, ?dark: Color) =
        this.AddScalar(SwitchCell.OnColor.WithValue(AppTheme.create light dark))
