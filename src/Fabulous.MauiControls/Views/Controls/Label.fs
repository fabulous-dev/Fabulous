namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type ILabel =
    inherit Fabulous.Maui.IView

module Label =
    let WidgetKey = Widgets.register<Label>()

    let CharacterSpacing =
        Attributes.defineBindableFloat Label.CharacterSpacingProperty

    let FontAttributes =
        Attributes.defineBindableEnum<Microsoft.Maui.Controls.FontAttributes> Label.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Label.FontFamilyProperty

    let FontSize =
        Attributes.defineBindableFloat Label.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Label.HorizontalTextAlignmentProperty

    let LineBreakMode =
        Attributes.defineBindableEnum<Microsoft.Maui.LineBreakMode> Label.LineBreakModeProperty

    let LineHeight =
        Attributes.defineBindableFloat Label.LineHeightProperty

    let MaxLines =
        Attributes.defineBindableInt Label.MaxLinesProperty

    let Padding =
        Attributes.defineBindableWithEquality<Thickness> Label.PaddingProperty

    let TextColor =
        Attributes.defineBindableAppThemeColor Label.TextColorProperty

    let TextDecorations =
        Attributes.defineBindableEnum<TextDecorations> Label.TextDecorationsProperty

    let Text =
        Attributes.defineBindableWithEquality<string> Label.TextProperty

    let TextTransform =
        Attributes.defineBindableEnum<TextTransform> Label.TextTransformProperty

    let TextType =
        Attributes.defineBindableEnum<TextType> Label.TextTypeProperty

    let VerticalTextAlignment =
        Attributes.defineBindableEnum<TextAlignment> Label.VerticalTextAlignmentProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Label.FontAutoScalingEnabledProperty


[<AutoOpen>]
module LabelBuilders =
    type Fabulous.Maui.View with
        static member inline Label<'msg>(text: string) =
            WidgetBuilder<'msg, ILabel>(Label.WidgetKey, Label.Text.WithValue(text))

[<Extension>]
type LabelModifiers =

    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #ILabel>, value: float) =
        this.AddScalar(Label.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #ILabel>,
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

    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #ILabel>, value: TextAlignment) =
        this.AddScalar(Label.HorizontalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline lineBreakMode(this: WidgetBuilder<'msg, #ILabel>, value: LineBreakMode) =
        this.AddScalar(Label.LineBreakMode.WithValue(value))

    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #ILabel>, value: float) =
        this.AddScalar(Label.LineHeight.WithValue(value))

    [<Extension>]
    static member inline maxLines(this: WidgetBuilder<'msg, #ILabel>, value: int) =
        this.AddScalar(Label.MaxLines.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #ILabel>, value: Thickness) =
        this.AddScalar(Label.Padding.WithValue(value))

    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #ILabel>, value: float) =
        LabelModifiers.padding(this, Thickness(value))

    [<Extension>]
    static member inline padding
        (
            this: WidgetBuilder<'msg, #ILabel>,
            left: float,
            top: float,
            right: float,
            bottom: float
        ) =
        LabelModifiers.padding(this, Thickness(left, top, right, bottom))

    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ILabel>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(Label.TextColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<'msg, #ILabel>, value: TextDecorations) =
        this.AddScalar(Label.TextDecorations.WithValue(value))

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #ILabel>, value: TextTransform) =
        this.AddScalar(Label.TextTransform.WithValue(value))

    [<Extension>]
    static member inline textType(this: WidgetBuilder<'msg, #ILabel>, value: TextType) =
        this.AddScalar(Label.TextType.WithValue(value))

    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #ILabel>, value: TextAlignment) =
        this.AddScalar(Label.VerticalTextAlignment.WithValue(value))

    [<Extension>]
    static member inline centerTextHorizontal(this: WidgetBuilder<'msg, #ILabel>) =
        this.AddScalar(Label.HorizontalTextAlignment.WithValue(TextAlignment.Center))

    [<Extension>]
    static member inline centerTextVertical(this: WidgetBuilder<'msg, #ILabel>) =
        this.AddScalar(Label.VerticalTextAlignment.WithValue(TextAlignment.Center))

    [<Extension>]
    static member inline centerText(this: WidgetBuilder<'msg, #ILabel>) =
        this.centerTextHorizontal().centerTextVertical()

    /// <summary>Link a ViewRef to access the direct Label control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ILabel>, value: ViewRef<Label>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
