namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics

type IFabSpan =
    inherit IFabElement

module Span =
    let WidgetKey = Widgets.register<Span>()

    let BackgroundColor = Attributes.defineBindableColor Span.BackgroundColorProperty

    let CharacterSpacing = Attributes.defineBindableFloat Span.CharacterSpacingProperty

    let FontAttributes =
        Attributes.defineBindableEnum<FontAttributes> Span.FontAttributesProperty

    let FontAutoScalingEnabled =
        Attributes.defineBindableBool Span.FontAutoScalingEnabledProperty

    let FontFamily =
        Attributes.defineBindableWithEquality<string> Span.FontFamilyProperty

    let FontSize = Attributes.defineBindableFloat Span.FontSizeProperty

    let GestureRecognizers =
        Attributes.defineListWidgetCollection<IGestureRecognizer> "Span_GestureRecognizers" (fun target -> (target :?> Span).GestureRecognizers)

    let LineHeight = Attributes.defineBindableFloat Span.LineHeightProperty

    let TextColor = Attributes.defineBindableColor Span.TextColorProperty

    let Text = Attributes.defineBindableWithEquality<string> Span.TextProperty

    let TextDecorations =
        Attributes.defineBindableEnum<TextDecorations> Span.TextDecorationsProperty

    let TextTransform =
        Attributes.defineBindableEnum<TextTransform> Span.TextTransformProperty

[<AutoOpen>]
module SpanBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a Span widget with a text</summary>
        /// <param name="text">The text value</param>
        static member inline Span<'msg when 'msg: equality>(text: string) =
            WidgetBuilder<'msg, IFabSpan>(Span.WidgetKey, Span.Text.WithValue(text))

[<Extension>]
type SpanModifiers =
    /// <summary>Set the background color</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The background color</param>
    [<Extension>]
    static member inline backgroundColor(this: WidgetBuilder<'msg, #IFabSpan>, value: Color) =
        this.AddScalar(Span.BackgroundColor.WithValue(value))

    /// <summary>Set the character spacing</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The character spacing</param>
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #IFabSpan>, value: float) =
        this.AddScalar(Span.CharacterSpacing.WithValue(value))

    /// <summary>Set the font</summary>
    /// <param name="this">Current widget</param>
    /// <param name="size">The font size</param>
    /// <param name="attributes">The font attributes</param>
    /// <param name="fontFamily">The font family</param>
    /// <param name="autoScalingEnabled">The value indicating whether auto-scaling is enabled</param>
    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #IFabSpan>, ?size: float, ?attributes: FontAttributes, ?fontFamily: string, ?autoScalingEnabled: bool) =

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

    /// <summary>Set the gesture recognizers</summary>
    /// <param name="this">Current widget</param>
    [<Extension>]
    static member inline gestureRecognizers<'msg, 'marker when 'msg: equality and 'marker :> IFabSpan>(this: WidgetBuilder<'msg, 'marker>) =
        WidgetHelpers.buildAttributeCollection<'msg, 'marker, IFabGestureRecognizer> Span.GestureRecognizers this

    /// <summary>Set the line height</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The line height</param>
    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #IFabSpan>, value: float) =
        this.AddScalar(Span.LineHeight.WithValue(value))

    /// <summary>Set the color of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The color of the text</param>
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #IFabSpan>, value: Color) =
        this.AddScalar(Span.TextColor.WithValue(value))

    /// <summary>Set the decorations of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The decorations of the text</param>
    [<Extension>]
    static member inline textDecorations(this: WidgetBuilder<'msg, #IFabSpan>, value: TextDecorations) =
        this.AddScalar(Span.TextDecorations.WithValue(value))

    /// <summary>Set the transformation of the text</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The transformation of the text</param>
    [<Extension>]
    static member inline textTransform(this: WidgetBuilder<'msg, #IFabSpan>, value: TextTransform) =
        this.AddScalar(Span.TextTransform.WithValue(value))

    /// <summary>Link a ViewRef to access the direct Span control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSpan>, value: ViewRef<Span>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))

[<Extension>]
type SpanYieldExtensions =
    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabSpan, IFabGestureRecognizer>,
            x: WidgetBuilder<'msg, #IFabGestureRecognizer>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: AttributeCollectionBuilder<'msg, #IFabSpan, IFabGestureRecognizer>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabGestureRecognizer>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

[<Extension>]
type SpanAttachedCollectionModifiers =
    /// <summary>Set the gesture recognizer associated with this widget</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The gesture recognizer</param>
    [<Extension>]
    static member gestureRecognizer(this: WidgetBuilder<'msg, #IFabSpan>, value: WidgetBuilder<'msg, #IFabGestureRecognizer>) =
        this.gestureRecognizers() { value }
