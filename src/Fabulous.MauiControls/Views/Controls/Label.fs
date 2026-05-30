namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabLabel =
    inherit IFabView

module Label =
    let WidgetKey = Widgets.register<Label>()

    let CharacterSpacing = Attributes.defineBindableFloat Label.CharacterSpacingProperty

    let FontAttributes =
        Attributes.defineBindableEnum<Microsoft.Maui.Controls.FontAttributes> Label.FontAttributesProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Label.FontAutoScalingEnabledProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Label.FontFamilyProperty

    let FontSize = Attributes.defineBindableFloat Label.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Label.HorizontalTextAlignmentProperty

    let LineBreakMode =
        Attributes.defineBindableEnum<Microsoft.Maui.LineBreakMode> Label.LineBreakModeProperty

    let LineHeight = Attributes.defineBindableFloat Label.LineHeightProperty

    let MaxLines = Attributes.defineBindableInt Label.MaxLinesProperty

    let Padding = Attributes.defineBindableWithEquality<Thickness> Label.PaddingProperty

    let TextColor = Attributes.defineBindableColor Label.TextColorProperty

    let TextDecorations =
        Attributes.defineBindableEnum<TextDecorations> Label.TextDecorationsProperty

    let Text = Attributes.defineBindableWithEquality<string> Label.TextProperty

    let TextTransform =
        Attributes.defineBindableEnum<TextTransform> Label.TextTransformProperty

    let TextType = Attributes.defineBindableEnum<TextType> Label.TextTypeProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Label.VerticalTextAlignmentProperty

[<AutoOpen>]
module LabelBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Label widget with a text</summary>
        /// <param name="text">The text value</param>
        static member inline Label<'msg when 'msg: equality>(text: string) =
            WidgetBuilder<'msg, IFabLabel>(Label.WidgetKey, Label.Text.WithValue(text))

[<Extension>]
type LabelModifiers =
    /// <summary>Set the character spacing</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The character spacing</param>
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IFabLabel>, value: float) =
        this.AddScalar(Label.CharacterSpacing.WithValue(value))

    /// <summary>Set the font</summary>
    /// <param name="this">Current widget</param>
    /// <param name="size">The font size</param>
    /// <param name="attributes">The font attributes</param>
    /// <param name="fontFamily">The font family</param>
    /// <param name="autoScalingEnabled">The value indicating whether auto-scaling is enabled</param>
    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #IFabLabel>,
            ?size: float,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?autoScalingEnabled: bool
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontSize.WithValue(v))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontFamily.WithValue(v))

        match autoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontAutoScalingEnabled.WithValue(v))

        res

    /// <summary>Set the horizontal alignment of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The horizontal alignment of the text</param>
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #IFabLabel>, value: TextAlignment) =
        this.AddScalar(Label.HorizontalTextAlignment.WithValue(value))

    /// <summary>Set the line break mode</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The line break mode</param>
    [<Extension>]
    static member inline lineBreakMode(this: WidgetBuilder<'msg, #IFabLabel>, value: LineBreakMode) =
        this.AddScalar(Label.LineBreakMode.WithValue(value))

    /// <summary>Set the line height</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The line height</param>
    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #IFabLabel>, value: float) =
        this.AddScalar(Label.LineHeight.WithValue(value))

    /// <summary>Set the maximum number of lines</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The maximum number of lines</param>
    [<Extension>]
    static member inline maxLines(this: WidgetBuilder<'msg, #IFabLabel>, value: int) =
        this.AddScalar(Label.MaxLines.WithValue(value))

    /// <summary>Set the padding inside the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The padding inside the text</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabLabel>, value: Thickness) =
        this.AddScalar(Label.Padding.WithValue(value))

    /// <summary>Set the color of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the text</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IFabLabel>, value: Color) =
        this.AddScalar(Label.TextColor.WithValue(value))

    /// <summary>Set the decorations of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The decorations of the text</param>
    [<Extension>]
    static member inline textDecorations(this: WidgetBuilder<'msg, #IFabLabel>, value: TextDecorations) =
        this.AddScalar(Label.TextDecorations.WithValue(value))

    /// <summary>Set the transformation of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The transformation of the text</param>
    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IFabLabel>, value: TextTransform) =
        this.AddScalar(Label.TextTransform.WithValue(value))

    /// <summary>Set the type of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The type of the text</param>
    [<Extension>]
    static member inline textType(this: WidgetBuilder<'msg, #IFabLabel>, value: TextType) =
        this.AddScalar(Label.TextType.WithValue(value))

    /// <summary>Set the vertical alignment of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The vertical alignment of the text</param>
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #IFabLabel>, value: TextAlignment) =
        this.AddScalar(Label.VerticalTextAlignment.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Label control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabLabel>, value: ViewRef<Label>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type LabelExtraModifiers =
    /// <summary>Align the text at the horizontal start side</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline alignStartTextHorizontal(this: WidgetBuilder<'msg, #IFabLabel>) =
        this.horizontalTextAlignment(TextAlignment.Start)

    /// <summary>Align the text at the vertical start side</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline alignStartTextVertical(this: WidgetBuilder<'msg, #IFabLabel>) =
        this.verticalTextAlignment(TextAlignment.Start)

    /// <summary>Align the text at both horizontal and vertical start sides</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline alignStartText(this: WidgetBuilder<'msg, #IFabLabel>) =
        this.alignStartTextHorizontal().alignStartTextVertical()

    /// <summary>Center the text horizontally</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline centerTextHorizontal(this: WidgetBuilder<'msg, #IFabLabel>) =
        this.horizontalTextAlignment(TextAlignment.Center)

    /// <summary>Center the text vertically</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline centerTextVertical(this: WidgetBuilder<'msg, #IFabLabel>) =
        this.verticalTextAlignment(TextAlignment.Center)

    /// <summary>Center the text both horizontal and vertical</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline centerText(this: WidgetBuilder<'msg, #IFabLabel>) =
        this.centerTextHorizontal().centerTextVertical()

    /// <summary>Align the text at the horizontal end side</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline alignEndTextHorizontal(this: WidgetBuilder<'msg, #IFabLabel>) =
        this.horizontalTextAlignment(TextAlignment.End)

    /// <summary>Align the text at the vertical end side</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline alignEndTextVertical(this: WidgetBuilder<'msg, #IFabLabel>) =
        this.verticalTextAlignment(TextAlignment.End)

    /// <summary>Align the text at both horizontal and vertical end sides</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline alignEndText(this: WidgetBuilder<'msg, #IFabLabel>) =
        this.alignEndTextHorizontal().alignEndTextVertical()

    /// <summary>Set the padding inside the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="uniformSize">The padding inside the text</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabLabel>, uniformSize: float) = this.padding(Thickness(uniformSize))

    /// <summary>Set the padding inside the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="left">The left component of the padding inside the text</param>
    /// <param name="top">The left component of the padding inside the text</param>
    /// <param name="right">The left component of the padding inside the text</param>
    /// <param name="bottom">The left component of the padding inside the text</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabLabel>, left: float, top: float, right: float, bottom: float) =
        this.padding(Thickness(left, top, right, bottom))
