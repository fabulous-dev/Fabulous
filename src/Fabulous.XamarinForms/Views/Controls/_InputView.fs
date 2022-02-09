namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IInputView =
    inherit IView

module InputView =

    let CharacterSpacing =
        Attributes.defineBindable<float> InputView.CharacterSpacingProperty

    let Placeholder =
        Attributes.defineBindable<string> InputView.PlaceholderProperty

    let PlaceholderColor =
        Attributes.defineAppThemeBindable<Color> InputView.PlaceholderColorProperty

    let TextColor =
        Attributes.defineAppThemeBindable<Color> InputView.TextColorProperty

    let Text =
        Attributes.defineBindable<string> InputView.TextProperty

    let Keyboard =
        Attributes.defineBindable<Keyboard> InputView.KeyboardProperty

    let TextChanged =
        Attributes.defineEvent<TextChangedEventArgs>
            "InputView_TextChanged"
            (fun target -> (target :?> InputView).TextChanged)

[<Extension>]
type InputViewModifiers =

    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IInputView>, value: float) =
        this.AddScalar(InputView.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline placeholder(this: WidgetBuilder<'msg, #IInputView>, value: string) =
        this.AddScalar(InputView.Placeholder.WithValue(value))

    [<Extension>]
    static member inline placeholderColor(this: WidgetBuilder<'msg, #IInputView>, light: Color, ?dark: Color) =
        this.AddScalar(InputView.PlaceholderColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IInputView>, light: Color, ?dark: Color) =
        this.AddScalar(InputView.TextColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline keyboard(this: WidgetBuilder<'msg, #IInputView>, value: Keyboard) =
        this.AddScalar(InputView.Keyboard.WithValue(value))
