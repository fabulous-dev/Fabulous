namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

type ISpan =
    inherit IElement

module Span =
    let WidgetKey = Widgets.register<Span>()

    let BackgroundColor =
        Attributes.defineAppThemeBindable<Color> Span.BackgroundColorProperty

    let CharacterSpacing =
        Attributes.defineBindable<float> Span.CharacterSpacingProperty

    let FontAttributes =
        Attributes.defineBindable<FontAttributes> Span.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindable<string> Span.FontFamilyProperty

    let FontSize =
        Attributes.defineBindable<float> Span.FontSizeProperty

    let LineHeight =
        Attributes.defineBindable<float> Span.LineHeightProperty

    let Style =
        Attributes.defineBindable<Style> Span.StyleProperty

    let TextColor =
        Attributes.defineAppThemeBindable<Color> Span.TextColorProperty

    let TextDecorations =
        Attributes.defineBindable<TextDecorations> Span.TextDecorationsProperty

    let TextTransform =
        Attributes.defineBindable<TextTransform> Span.TextTransformProperty

    let Text =
        Attributes.defineBindable<string> Span.TextProperty

    let GestureRecognizers =
        Attributes.defineWidgetCollection<IGestureRecognizer>
            "Span_GestureRecognizers"
            ViewNode.get
            (fun target -> (target :?> Span).GestureRecognizers)

[<AutoOpen>]
module SpanBuilders =
    type Fabulous.XamarinForms.View with
        static member inline Span<'msg>(text: string) =
            WidgetBuilder<'msg, ISpan>(Span.WidgetKey, Span.Text.WithValue(text))

[<Extension>]
type SpanModifiers =

    [<Extension>]
    static member inline backgroundColor(this: WidgetBuilder<'msg, #ISpan>, light: Color, ?dark: Color) =
        this.AddScalar(Span.BackgroundColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #ISpan>, value: float) =
        this.AddScalar(Span.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #ISpan>,
            ?size: double,
            ?namedSize: NamedSize,
            ?attributes: FontAttributes,
            ?fontFamily: string
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Span.FontSize.WithValue(v))

        match namedSize with
        | None -> ()
        | Some v -> res <- res.AddScalar(Span.FontSize.WithValue(Device.GetNamedSize(v, typeof<Span>)))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Span.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Span.FontFamily.WithValue(v))

        res

    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #ISpan>, value: float) =
        this.AddScalar(Span.LineHeight.WithValue(value))

    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #ISpan>, value: Style) =
        this.AddScalar(Span.Style.WithValue(value))

    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ISpan>, light: Color, ?dark: Color) =
        this.AddScalar(Span.TextColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline textDecorations(this: WidgetBuilder<'msg, #ISpan>, value: TextDecorations) =
        this.AddScalar(Span.TextDecorations.WithValue(value))

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #ISpan>, value: TextTransform) =
        this.AddScalar(Span.TextTransform.WithValue(value))

    [<Extension>]
    static member inline gestureRecognizers<'msg, 'marker when 'marker :> ISpan>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, Fabulous.XamarinForms.IGestureRecognizer>
            Span.GestureRecognizers
            this

    /// <summary>Link a ViewRef to access the direct Span control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ISpan>, value: ViewRef<Span>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
