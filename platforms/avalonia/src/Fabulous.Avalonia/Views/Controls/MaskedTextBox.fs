namespace Fabulous.Avalonia

open System.Globalization
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabMaskedTextBox =
    inherit IFabTextBox

module MaskedTextBox =
    let WidgetKey = Widgets.register<MaskedTextBox>()

    let AsciiOnly =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.AsciiOnlyProperty

    let Culture =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.CultureProperty

    let HidePromptOnLeave =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.HidePromptOnLeaveProperty

    let Mask = Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.MaskProperty

    let PasswordChar =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.PasswordCharProperty

    let PromptChar =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.PromptCharProperty

    let ResetOnPrompt =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.ResetOnPromptProperty

    let ResetOnSpace =
        Attributes.defineAvaloniaPropertyWithEquality MaskedTextBox.ResetOnSpaceProperty


type MaskedTextBoxModifiers =
    /// <summary>Sets the AsciiOnly property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AsciiOnly value.</param>
    [<Extension>]
    static member inline asciiOnly(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, value: bool) =
        this.AddScalar(MaskedTextBox.AsciiOnly.WithValue(value))

    /// <summary>Sets the Culture property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Culture value.</param>
    [<Extension>]
    static member inline culture(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, value: CultureInfo) =
        this.AddScalar(MaskedTextBox.Culture.WithValue(value))

    /// <summary>Sets the HidePromptOnLeave property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HidePromptOnLeave value.</param>
    [<Extension>]
    static member inline hidePromptOnLeave(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, value: bool) =
        this.AddScalar(MaskedTextBox.HidePromptOnLeave.WithValue(value))

    /// <summary>Sets the PasswordChar property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PasswordChar value.</param>
    [<Extension>]
    static member inline passwordChar(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, value: char) =
        this.AddScalar(MaskedTextBox.PasswordChar.WithValue(value))

    /// <summary>Sets the PromptChar property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PromptChar value.</param>
    [<Extension>]
    static member inline promptChar(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, value: char) =
        this.AddScalar(MaskedTextBox.PromptChar.WithValue(value))

    /// <summary>Sets the ResetOnPrompt property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ResetOnPrompt value.</param>
    [<Extension>]
    static member inline resetOnPrompt(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, value: bool) =
        this.AddScalar(MaskedTextBox.ResetOnPrompt.WithValue(value))

    /// <summary>Sets the ResetOnSpace property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ResetOnSpace value.</param>
    [<Extension>]
    static member inline resetOnSpace(this: WidgetBuilder<'msg, #IFabMaskedTextBox>, value: bool) =
        this.AddScalar(MaskedTextBox.ResetOnSpace.WithValue(value))

    /// <summary>Link a ViewRef to access the direct MaskedTextBox control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMaskedTextBox>, value: ViewRef<MaskedTextBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
