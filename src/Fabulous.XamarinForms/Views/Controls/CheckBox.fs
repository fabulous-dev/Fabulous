namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ICheckBox =
    inherit IView

module CheckBox =

    let WidgetKey = Widgets.register<CheckBox>()

    let Color =
        Attributes.defineAppThemeBindable<Color> CheckBox.ColorProperty

    let IsCheckedWithEvent =
        Attributes.defineBindableWithEvent
            "CheckBox_CheckedChanged"
            CheckBox.IsCheckedProperty
            (fun target -> (target :?> CheckBox).CheckedChanged)

[<AutoOpen>]
module CheckBoxBuilders =
    type Fabulous.XamarinForms.View with
        static member inline CheckBox<'msg>(isChecked: bool, onCheckedChanged: bool -> 'msg) =
            WidgetBuilder<'msg, ICheckBox>(
                CheckBox.WidgetKey,
                CheckBox.IsCheckedWithEvent.WithValue(
                    ValueEventData.create isChecked (fun args -> onCheckedChanged args.Value |> box)
                )
            )

[<Extension>]
type CheckBoxModifiers =
    /// <summary>Set the color of the checkBox.</summary>
    /// <param name="light">The color of the checkBox in the light theme.</param>
    /// <param name="dark">The color of the checkBox in the dark theme.</param>
    [<Extension>]
    static member inline color(this: WidgetBuilder<'msg, #ICheckBox>, light: Color, ?dark: Color) =
        this.AddScalar(CheckBox.Color.WithValue(AppTheme.create light dark))

    /// <summary>Link a ViewRef to access the direct CheckBox control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ICheckBox>, value: ViewRef<CheckBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
