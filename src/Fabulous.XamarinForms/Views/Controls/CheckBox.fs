namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ICheckBox =
    inherit IView

module CheckBox =

    let WidgetKey = Widgets.register<CheckBox> ()

    let IsChecked =
        Attributes.defineBindable<bool> CheckBox.IsCheckedProperty

    let Color =
        Attributes.defineAppThemeBindable<Color> CheckBox.ColorProperty

    let CheckedChanged =
        Attributes.defineEvent<CheckedChangedEventArgs>
            "CheckBox_CheckedChanged"
            (fun target -> (target :?> CheckBox).CheckedChanged)

[<AutoOpen>]
module CheckBoxBuilders =
    type Fabulous.XamarinForms.View with
        static member inline CheckBox<'msg>(isChecked: bool, onCheckedChanged: bool -> 'msg) =
            WidgetBuilder<'msg, ICheckBox>(
                CheckBox.WidgetKey,
                CheckBox.IsChecked.WithValue(isChecked),
                CheckBox.CheckedChanged.WithValue(fun args -> onCheckedChanged args.Value |> box)
            )

[<Extension>]
type CheckBoxModifiers =
    /// <summary>Set the color of the checkBox.</summary>
    /// <param name="light">The color of the checkBox in the light theme.</param>
    /// <param name="dark">The color of the checkBox in the dark theme.</param>
    [<Extension>]
    static member inline color(this: WidgetBuilder<'msg, #ICheckBox>, light: Color, ?dark: Color) =
        this.AddScalar(CheckBox.Color.WithValue(AppTheme.create light dark))
