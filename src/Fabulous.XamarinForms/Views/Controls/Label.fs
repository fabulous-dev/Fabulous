namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type ILabel =
    inherit IView

module Label =
    let WidgetKey = Widgets.register<Label>()

    let CharacterSpacing =
        Attributes.defineBindable<float> Label.CharacterSpacingProperty

    let FontAttributes =
        Attributes.defineBindable<Xamarin.Forms.FontAttributes> Label.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindable<string> Label.FontFamilyProperty

    let FontSize =
        Attributes.defineBindable<float> Label.FontSizeProperty

    let HorizontalTextAlignment =
        Attributes.defineBindable<TextAlignment> Label.HorizontalTextAlignmentProperty

    let LineBreakMode =
        Attributes.defineBindable<Xamarin.Forms.LineBreakMode> Label.LineBreakModeProperty

    let LineHeight =
        Attributes.defineBindable<float> Label.LineHeightProperty

    let MaxLines =
        Attributes.defineBindable<int> Label.MaxLinesProperty

    let Padding =
        Attributes.defineBindable<Thickness> Label.PaddingProperty

    let TextColor =
        Attributes.defineAppThemeBindable<Color> Label.TextColorProperty

    let TextDecorations =
        Attributes.defineBindable<TextDecorations> Label.TextDecorationsProperty

    let Text =
        Attributes.defineBindable<string> Label.TextProperty

    let TextTransform =
        Attributes.defineBindable<TextTransform> Label.TextTransformProperty

    let TextType =
        Attributes.defineBindable<TextType> Label.TextTypeProperty

    let VerticalTextAlignment =
        Attributes.defineBindable<TextAlignment> Label.VerticalTextAlignmentProperty


[<AutoOpen>]
module LabelBuilders =
    type Fabulous.XamarinForms.View with
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
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes,
            ?fontFamily: string
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontSize.WithValue(Device.GetNamedSize(v, typeof<Label>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Label.FontFamily.WithValue(v))

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
    static member inline textColor(this: WidgetBuilder<'msg, #ILabel>, light: Color, ?dark: Color) =
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

    /// <summary>Link a ViewRef to access the direct Label control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ILabel>, value: ViewRef<Label>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
