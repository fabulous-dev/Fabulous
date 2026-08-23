namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabInputView =
    inherit IFabView

module InputView =
    let CharacterSpacing =
        Attributes.defineBindableFloat InputView.CharacterSpacingProperty

    let IsReadOnly = Attributes.defineBindableBool InputView.IsReadOnlyProperty

    let IsSpellCheckEnabled =
        Attributes.defineBindableBool InputView.IsSpellCheckEnabledProperty

    let Keyboard =
        Attributes.defineBindableWithEquality<Keyboard> InputView.KeyboardProperty

    let MaxLength = Attributes.defineBindableInt InputView.MaxLengthProperty

    let Placeholder =
        Attributes.defineBindableWithEquality<string> InputView.PlaceholderProperty

    let PlaceholderColor =
        Attributes.defineBindableColor InputView.PlaceholderColorProperty

    let TextColor = Attributes.defineBindableColor InputView.TextColorProperty

    let TextTransform =
        Attributes.defineBindableEnum<TextTransform> InputView.TextTransformProperty

    let TextWithEvent =
        Attributes.defineBindableWithEvent<string, TextChangedEventArgs> "InputView_TextChanged" InputView.TextProperty (fun target ->
            (target :?> InputView).TextChanged)

[<Extension>]
type InputViewModifiers =
    /// <summary>Set the character spacing</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The character spacing</param>
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IFabInputView>, value: float) =
        this.AddScalar(InputView.CharacterSpacing.WithValue(value))

    /// <summary>Set whether user should be prevented from modifying the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">If true, user cannot modify text. Else, false</param>
    [<Extension>]
    static member inline isReadOnly(this: WidgetBuilder<'msg, #IFabInputView>, value: bool) =
        this.AddScalar(InputView.IsReadOnly.WithValue(value))

    /// <summary>Set a value that controls whether spell checking is enabled</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">If true, spell checking is enabled. Else, false</param>
    [<Extension>]
    static member inline isSpellCheckEnabled(this: WidgetBuilder<'msg, #IFabInputView>, value: bool) =
        this.AddScalar(InputView.IsSpellCheckEnabled.WithValue(value))

    /// <summary>Set the keyboard that is displayed by the widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The keyboard that is displayed</param>
    [<Extension>]
    static member inline keyboard(this: WidgetBuilder<'msg, #IFabInputView>, value: Keyboard) =
        this.AddScalar(InputView.Keyboard.WithValue(value))

    /// <summary>Set the maximum allowed length of input</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">An integer in the interval [0,int.MaxValue]</param>
    [<Extension>]
    static member inline maxLength(this: WidgetBuilder<'msg, #IFabInputView>, value: int) =
        this.AddScalar(InputView.MaxLength.WithValue(value))

    /// <summary>Set the text that is displayed when the control is empty</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The text that is displayed when the control is empty.</param>
    [<Extension>]
    static member inline placeholder(this: WidgetBuilder<'msg, #IFabInputView>, value: string) =
        this.AddScalar(InputView.Placeholder.WithValue(value))

    /// <summary>Set the color of the placeholder text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the placeholder text</param>
    [<Extension>]
    static member inline placeholderColor(this: WidgetBuilder<'msg, #IFabInputView>, value: Color) =
        this.AddScalar(InputView.PlaceholderColor.WithValue(value))

    /// <summary>Sets the color of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the text</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IFabInputView>, value: Color) =
        this.AddScalar(InputView.TextColor.WithValue(value))

    /// <summary>Sets the transformation of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The transformation of the text</param>
    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IFabInputView>, value: TextTransform) =
        this.AddScalar(InputView.TextTransform.WithValue(value))
