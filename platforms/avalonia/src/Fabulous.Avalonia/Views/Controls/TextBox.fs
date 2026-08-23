namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Avalonia.Media
open Fabulous
open Avalonia.Layout

type IFabTextBox =
    inherit IFabTemplatedControl

module TextBox =
    let WidgetKey = Widgets.register<TextBox>()

    let TextAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.TextAlignmentProperty

    let TextWrapping =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.TextWrappingProperty

    let HorizontalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.HorizontalContentAlignmentProperty

    let VerticalContentAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.VerticalContentAlignmentProperty

    let AcceptsReturn =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.AcceptsReturnProperty

    let AcceptsTab =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.AcceptsTabProperty

    let IsReadOnly =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.IsReadOnlyProperty

    let IsUndoEnabled =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.IsUndoEnabledProperty

    let UndoLimit =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.UndoLimitProperty

    let LetterSpacing =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.LetterSpacingProperty

    let LineHeight =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.LineHeightProperty

    let MaxLength =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.MaxLengthProperty

    let MaxLines =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.MaxLinesProperty

    let PasswordChar =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.PasswordCharProperty

    let RevealPassword =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.RevealPasswordProperty

    let SelectionStart =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.SelectionStartProperty

    let SelectionEnd =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.SelectionEndProperty

    let Watermark =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.WatermarkProperty

    let UseFloatingWatermark =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.UseFloatingWatermarkProperty

    let CaretIndex =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.CaretIndexProperty

    let NewLine = Attributes.defineAvaloniaPropertyWithEquality TextBox.NewLineProperty

    let CaretBrushWidget =
        Attributes.defineAvaloniaPropertyWidget TextBox.CaretBrushProperty

    let CaretBrush =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.CaretBrushProperty

    let SelectionBrushWidget =
        Attributes.defineAvaloniaPropertyWidget TextBox.SelectionBrushProperty

    let SelectionBrush =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.SelectionBrushProperty

    let InnerLeftContentWidget =
        Attributes.defineAvaloniaPropertyWidget TextBox.InnerLeftContentProperty

    let InnerRightContentWidget =
        Attributes.defineAvaloniaPropertyWidget TextBox.InnerRightContentProperty

    let SelectionForegroundBrushWidget =
        Attributes.defineAvaloniaPropertyWidget TextBox.SelectionForegroundBrushProperty

    let SelectionForegroundBrush =
        Attributes.defineAvaloniaPropertyWithEquality TextBox.SelectionForegroundBrushProperty

type TextBoxModifiers =

    /// <summary>Sets the TextAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextAlignment value.</param>
    [<Extension>]
    static member inline textAlignment(this: WidgetBuilder<'msg, #IFabTextBox>, value: TextAlignment) =
        this.AddScalar(TextBox.TextAlignment.WithValue(value))

    /// <summary>Sets the TextWrapping property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextWrapping value.</param>
    [<Extension>]
    static member inline textWrapping(this: WidgetBuilder<'msg, #IFabTextBox>, value: TextWrapping) =
        this.AddScalar(TextBox.TextWrapping.WithValue(value))

    /// <summary>Sets the HorizontalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalContentAlignment value.</param>
    [<Extension>]
    static member inline horizontalContentAlignment(this: WidgetBuilder<'msg, #IFabTextBox>, value: HorizontalAlignment) =
        this.AddScalar(TextBox.HorizontalContentAlignment.WithValue(value))

    /// <summary>Sets the VerticalContentAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalContentAlignment value.</param>
    [<Extension>]
    static member inline verticalContentAlignment(this: WidgetBuilder<'msg, #IFabTextBox>, value: VerticalAlignment) =
        this.AddScalar(TextBox.VerticalContentAlignment.WithValue(value))

    /// <summary>Sets the AcceptsReturn property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AcceptsReturn value.</param>
    [<Extension>]
    static member acceptsReturn(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.AcceptsReturn.WithValue(value))

    /// <summary>Sets the AcceptsTab property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The AcceptsTab value.</param>
    [<Extension>]
    static member acceptsTab(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.AcceptsTab.WithValue(value))

    /// <summary>Sets the IsReadOnly property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsReadOnly value.</param>
    [<Extension>]
    static member inline isReadOnly(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.IsReadOnly.WithValue(value))

    /// <summary>Sets the IsUndoEnabled property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsUndoEnabled value.</param>
    [<Extension>]
    static member inline isUndoEnabled(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.IsUndoEnabled.WithValue(value))

    /// <summary>Sets the UndoLimit property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The UndoLimit value.</param>
    [<Extension>]
    static member inline undoLimit(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.UndoLimit.WithValue(value))

    /// <summary>Sets the LetterSpacing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LetterSpacing value.</param>
    [<Extension>]
    static member inline letterSpacing(this: WidgetBuilder<'msg, #IFabTextBox>, value: float) =
        this.AddScalar(TextBox.LetterSpacing.WithValue(value))

    /// <summary>Sets the LineHeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LineHeight value.</param>
    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #IFabTextBox>, value: float) =
        this.AddScalar(TextBox.LineHeight.WithValue(value))

    /// <summary>Sets the MaxLength property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxLength value.</param>
    [<Extension>]
    static member inline maxLength(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.MaxLength.WithValue(value))

    /// <summary>Sets the MinLines property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinLines value.</param>
    [<Extension>]
    static member inline maxLines(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.MaxLines.WithValue(value))

    /// <summary>Sets the PasswordChar property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The PasswordChar value.</param>
    [<Extension>]
    static member inline passwordChar(this: WidgetBuilder<'msg, #IFabTextBox>, value: char) =
        this.AddScalar(TextBox.PasswordChar.WithValue(value))

    /// <summary>Sets the RevealedPassword property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RevealedPassword value.</param>
    [<Extension>]
    static member inline revealPassword(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.RevealPassword.WithValue(value))

    /// <summary>Sets the SelectionStart property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionStart value.</param>
    [<Extension>]
    static member inline selectionStart(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.SelectionStart.WithValue(value))

    /// <summary>Sets the SelectionEnd property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionEnd value.</param>
    [<Extension>]
    static member inline selectionEnd(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.SelectionEnd.WithValue(value))

    /// <summary>Sets the Watermark property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Watermark value.</param>
    [<Extension>]
    static member inline watermark(this: WidgetBuilder<'msg, #IFabTextBox>, value: string) =
        this.AddScalar(TextBox.Watermark.WithValue(value))

    /// <summary>Sets the UseFloatingWatermark property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The UseFloatingWatermark value.</param>
    [<Extension>]
    static member inline useFloatingWatermark(this: WidgetBuilder<'msg, #IFabTextBox>, value: bool) =
        this.AddScalar(TextBox.UseFloatingWatermark.WithValue(value))

    /// <summary>Sets the CaretIndex property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CaretIndex value.</param>
    [<Extension>]
    static member inline caretIndex(this: WidgetBuilder<'msg, #IFabTextBox>, value: int) =
        this.AddScalar(TextBox.CaretIndex.WithValue(value))

    /// <summary>Sets the NewLine property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The NewLine value.</param>
    [<Extension>]
    static member inline newLine(this: WidgetBuilder<'msg, #IFabTextBox>, value: string) =
        this.AddScalar(TextBox.NewLine.WithValue(value))

    /// <summary>Sets the CaretBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CaretBrush value.</param>
    [<Extension>]
    static member inline caretBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextBox.CaretBrushWidget.WithValue(value.Compile()))

    /// <summary>Sets the CaretBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CaretBrush value.</param>
    [<Extension>]
    static member inline caretBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: IBrush) =
        this.AddScalar(TextBox.CaretBrush.WithValue(value))

    /// <summary>Sets the InnerLeftContent property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The InnerLeftContent value.</param>
    [<Extension>]
    static member inline innerLeftContent(this: WidgetBuilder<'msg, #IFabTextBox>, value: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(TextBox.InnerLeftContentWidget.WithValue(value.Compile()))

    /// <summary>Sets the InnerRightContent property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The InnerRightContent value.</param>
    [<Extension>]
    static member inline innerRightContent(this: WidgetBuilder<'msg, #IFabTextBox>, value: WidgetBuilder<'msg, #IFabControl>) =
        this.AddWidget(TextBox.InnerRightContentWidget.WithValue(value.Compile()))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextBox.SelectionBrushWidget.WithValue(value.Compile()))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: IBrush) =
        this.AddScalar(TextBox.SelectionBrush.WithValue(value))

    /// <summary>Sets the SelectionForegroundBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionForegroundBrush value.</param>
    [<Extension>]
    static member inline selectionForegroundBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextBox.SelectionForegroundBrushWidget.WithValue(value.Compile()))

    /// <summary>Sets the SelectionForegroundBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionForegroundBrush value.</param>
    [<Extension>]
    static member inline selectionForegroundBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: IBrush) =
        this.AddScalar(TextBox.SelectionForegroundBrush.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TextBox control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTextBox>, value: ViewRef<TextBox>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

type TextBoxExtraModifiers =
    /// <summary>Sets the TextAlignment to center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline centerText(this: WidgetBuilder<'msg, #IFabTextBox>) =
        this.AddScalar(TextBox.TextAlignment.WithValue(TextAlignment.Center))

    /// <summary>Sets the CaretBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CaretBrush value.</param>
    [<Extension>]
    static member inline caretBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: Color) =
        TextBoxModifiers.caretBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the CaretBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CaretBrush value.</param>
    [<Extension>]
    static member inline caretBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: string) =
        TextBoxModifiers.caretBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: Color) =
        TextBoxModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionBrush value.</param>
    [<Extension>]
    static member inline selectionBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: string) =
        TextBoxModifiers.selectionBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionForegroundBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionForegroundBrush value.</param>
    [<Extension>]
    static member inline selectionForegroundBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: Color) =
        TextBoxModifiers.selectionForegroundBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the SelectionForegroundBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The SelectionForegroundBrush value.</param>
    [<Extension>]
    static member inline selectionForegroundBrush(this: WidgetBuilder<'msg, #IFabTextBox>, value: string) =
        TextBoxModifiers.selectionForegroundBrush(this, View.SolidColorBrush(value))
