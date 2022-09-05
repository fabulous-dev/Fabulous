namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Controls

type ISpan =
    inherit Fabulous.Maui.IElement

module Span =
    let WidgetKey = Widgets.register<Span>()

    let BackgroundColor =
        Attributes.defineBindableAppThemeColor Span.BackgroundColorProperty

    let CharacterSpacing =
        Attributes.defineBindableFloat Span.CharacterSpacingProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> Span.FontAttributesProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Span.FontFamilyProperty

    let FontSize =
        Attributes.defineBindableFloat Span.FontSizeProperty

    let LineHeight =
        Attributes.defineBindableFloat Span.LineHeightProperty

    let Style =
        Attributes.defineBindableWithEquality<Style> Span.StyleProperty

    let TextColor =
        Attributes.defineBindableAppThemeColor Span.TextColorProperty

    let TextDecorations =
        Attributes.defineBindableEnum<TextDecorations> Span.TextDecorationsProperty

    let TextTransform =
        Attributes.defineBindableEnum<TextTransform> Span.TextTransformProperty

    let Text =
        Attributes.defineBindableWithEquality<string> Span.TextProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Span.FontAutoScalingEnabledProperty

    let GestureRecognizers =
        Attributes.defineListWidgetCollection<IGestureRecognizer>
            "Span_GestureRecognizers"
            (fun target -> (target :?> Span).GestureRecognizers)

[<AutoOpen>]
module SpanBuilders =
    type Fabulous.Maui.View with
        static member inline Span<'msg>(text: string) =
            WidgetBuilder<'msg, ISpan>(Span.WidgetKey, Span.Text.WithValue(text))

[<Extension>]
type SpanModifiers =

    [<Extension>]
    static member inline backgroundColor(this: WidgetBuilder<'msg, #ISpan>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(Span.BackgroundColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #ISpan>, value: float) =
        this.AddScalar(Span.CharacterSpacing.WithValue(value))

    [<Extension>]
    static member inline font
        (
            this: WidgetBuilder<'msg, #ISpan>,
            ?size: double,
            ?attributes: FontAttributes,
            ?fontFamily: string,
            ?autoScalingEnabled: bool
        ) =

        let mutable res = this

        match size with
        | None -> ()
        | Some v -> res <- res.AddScalar(Span.FontSize.WithValue(v))

        match attributes with
        | None -> ()
        | Some v -> res <- res.AddScalar(Span.FontAttributes.WithValue(v))

        match fontFamily with
        | None -> ()
        | Some v -> res <- res.AddScalar(Span.FontFamily.WithValue(v))

        match autoScalingEnabled with
        | None -> ()
        | Some v -> res <- res.AddScalar(Span.FontAutoScalingEnabled.WithValue(v))

        res

    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #ISpan>, value: float) =
        this.AddScalar(Span.LineHeight.WithValue(value))

    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #ISpan>, value: Style) =
        this.AddScalar(Span.Style.WithValue(value))

    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ISpan>, light: FabColor, ?dark: FabColor) =
        this.AddScalar(Span.TextColor.WithValue(AppTheme.create light dark))

    [<Extension>]
    static member inline textDecorations(this: WidgetBuilder<'msg, #ISpan>, value: TextDecorations) =
        this.AddScalar(Span.TextDecorations.WithValue(value))

    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #ISpan>, value: TextTransform) =
        this.AddScalar(Span.TextTransform.WithValue(value))

    [<Extension>]
    static member inline gestureRecognizers<'msg, 'marker when 'marker :> ISpan>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, Fabulous.Maui.IGestureRecognizer>
            Span.GestureRecognizers
            this

    /// <summary>Link a ViewRef to access the direct Span control instance</summary>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, ISpan>, value: ViewRef<Span>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
