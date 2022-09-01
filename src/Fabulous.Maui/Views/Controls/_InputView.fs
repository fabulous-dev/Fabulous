namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type IInputView =
    inherit IView

module InputView =

    let CharacterSpacing =
        Attributes.defineBindableFloat InputView.CharacterSpacingProperty

    let IsReadOnly =
        Attributes.defineBindableBool InputView.IsReadOnlyProperty

    let IsSpellCheckEnabled =
        Attributes.defineBindableBool InputView.IsSpellCheckEnabledProperty

    let MaxLength =
        Attributes.defineBindableInt InputView.MaxLengthProperty

    let Placeholder =
        Attributes.defineBindableWithEquality<string> InputView.PlaceholderProperty

    let PlaceholderColor =
        Attributes.defineBindableAppThemeColor InputView.PlaceholderColorProperty

    let TextColor =
        Attributes.defineBindableAppThemeColor InputView.TextColorProperty

    let Keyboard =
        Attributes.defineBindableWithEquality<Keyboard> InputView.KeyboardProperty

    let TextTransform =
        Attributes.defineBindableEnum<TextTransform> InputView.TextTransformProperty

    let TextWithEvent =
        Attributes.defineBindableWithEvent<string, TextChangedEventArgs>
            "InputView_TextChanged"
            InputView.TextProperty
            (fun target -> (target :?> InputView).TextChanged)

[<Extension>]
type InputViewModifiers =
    /// <summary>Sets a value that indicates the number of device-independent units that should be in between characters in the text displayed by the Entry. Applies to Text and Placeholder.</summary>
    /// <param name="The number of device-independent units that should be in between characters in the text.</param>
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IInputView>, value: float) =
        this.AddScalar(InputView.CharacterSpacing.WithValue(value))

    /// <summary>Sets a value that indicates whether user should be prevented from modifying the text. Default is false.</summary>
    /// <param name="If true, user cannot modify text. Else, false.</param>
    [<Extension>]
    static member inline isReadOnly(this: WidgetBuilder<'msg, #IInputView>, value: bool) =
        this.AddScalar(InputView.IsReadOnly.WithValue(value))

    /// <summary>Sets a value that controls whether spell checking is enabled.</summary>
    /// <param name="If true, spell checking is enabled. Else, false.</param>
    [<Extension>]
    static member inline isSpellCheckEnabled(this: WidgetBuilder<'msg, #IInputView>, value: bool) =
        this.AddScalar(InputView.IsSpellCheckEnabled.WithValue(value))

    /// <summary>Sets the text that is displayed when the control is empty.</summary>
    /// <param name ="value">The text that is displayed when the control is empty.</param>
    [<Extension>]
    static member inline placeholder(this: WidgetBuilder<'msg, #IInputView>, value: string) =
        this.AddScalar(InputView.Placeholder.WithValue(value))

    /// <summary>Sets the color of the placeholder text.</summary>
    /// <param name="light">The color of the placeholder text in the light theme.</param>
    /// <param name="dark">The color of the placeholder text in the dark theme.</param>
    [<Extension>]
    static member inline placeholderColor(this: WidgetBuilder<'msg, #IInputView>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(InputView.PlaceholderColor.WithValue(AppTheme.create light dark))

    /// <summary>Sets the color of the text.</summary>
    /// <param name="light">The color of the text in the light theme.</param>
    /// <param name="dark">The color of the text in the dark theme.</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IInputView>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(InputView.TextColor.WithValue(AppTheme.create light dark))

    /// <summary>Sets the Keyboard that is displayed by the control.</summary>
    /// <param name="value">The Keyboard that is displayed by the control.</param>
    [<Extension>]
    static member inline keyboard(this: WidgetBuilder<'msg, #IInputView>, value: Keyboard) =
        this.AddScalar(InputView.Keyboard.WithValue(value))

    /// <summary>Sets the maximum allowed length of input.</summary>
    /// <param name="value">An integer in the interval [0,int.MaxValue]. The default value is Int.MaxValue.</param>
    [<Extension>]
    static member inline maxLength(this: WidgetBuilder<'msg, #IInputView>, value: int) =
        this.AddScalar(InputView.MaxLength.WithValue(value))

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IInputView>, value: TextTransform) =
        this.AddScalar(InputView.TextTransform.WithValue(value))
