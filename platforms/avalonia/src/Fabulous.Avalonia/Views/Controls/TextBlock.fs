namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabTextBlock =
    inherit IFabControl

module TextBlock =
    let WidgetKey = Widgets.register<TextBlock>()

    let BackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget TextBlock.BackgroundProperty

    let Background =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.BackgroundProperty

    let Padding =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.PaddingProperty

    let FontFamily =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.FontFamilyProperty

    let FontSize =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.FontSizeProperty

    let FontStyle =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.FontStyleProperty

    let FontWeight =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.FontWeightProperty

    let FontStretch =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.FontStretchProperty

    let ForegroundWidget =
        Attributes.defineAvaloniaPropertyWidget TextBlock.ForegroundProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.ForegroundProperty

    let BaseLineOffset =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.BaselineOffsetProperty

    let LineHeight =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.LineHeightProperty

    let LetterSpacing =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.LetterSpacingProperty

    let MaxLines =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.MaxLinesProperty

    let Text = Attributes.defineAvaloniaPropertyWithEquality TextBlock.TextProperty

    let TextAlignment =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.TextAlignmentProperty

    let TextWrapping =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.TextWrappingProperty

    let TextTrimming =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.TextTrimmingProperty

    let LineSpacing =
        Attributes.defineAvaloniaPropertyWithEquality TextBlock.LineSpacingProperty

    let TextDecorations =
        Attributes.defineAvaloniaListWidgetCollection "TextBlock_TextDecorations" (fun target ->
            let target = target :?> TextBlock

            if target.TextDecorations = null then
                let newColl = TextDecorationCollection()
                target.TextDecorations <- newColl
                newColl
            else
                target.TextDecorations)

    let Inlines =
        Attributes.defineAvaloniaListWidgetCollection "TextBlock_Inlines" (fun target ->
            let target = target :?> TextBlock

            if target.Inlines = null then
                let newColl = InlineCollection()
                target.Inlines <- newColl
                newColl
            else
                target.Inlines)

[<AutoOpen>]
module ComponentTextBlockBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a TextBlock widget.</summary>
        /// <param name="text">The text to display.</param>
        static member inline TextBlock(text: string) =
            WidgetBuilder<'msg, IFabTextBlock>(TextBlock.WidgetKey, TextBlock.Text.WithValue(text))

        /// <summary>Creates a TextBlock widget.</summary>
        static member inline TextBlock() =
            CollectionBuilder<'msg, IFabTextBlock, IFabInline>(TextBlock.WidgetKey, TextBlock.Inlines)

type TextBlockModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextBlock>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextBlock.BackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextBlock>, value: IBrush) =
        this.AddScalar(TextBlock.Background.WithValue(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextBlock>, value: Color) =
        TextBlockModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextBlock>, value: string) =
        TextBlockModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Padding value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTextBlock>, value: Thickness) =
        this.AddScalar(TextBlock.Padding.WithValue(value))

    /// <summary>Sets the FontFamily property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontFamily value.</param>
    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #IFabTextBlock>, value: FontFamily) =
        this.AddScalar(TextBlock.FontFamily.WithValue(value))

    /// <summary>Sets the FontSize property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontSize value.</param>
    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        this.AddScalar(TextBlock.FontSize.WithValue(value))

    /// <summary>Sets the FontStyle property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontStyle value.</param>
    [<Extension>]
    static member inline fontStyle(this: WidgetBuilder<'msg, #IFabTextBlock>, value: FontStyle) =
        this.AddScalar(TextBlock.FontStyle.WithValue(value))

    /// <summary>Sets the FontWeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontWeight value.</param>
    [<Extension>]
    static member inline fontWeight(this: WidgetBuilder<'msg, #IFabTextBlock>, value: FontWeight) =
        this.AddScalar(TextBlock.FontWeight.WithValue(value))

    /// <summary>Sets the FontStretch property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontStretch value.</param>
    [<Extension>]
    static member inline fontStretch(this: WidgetBuilder<'msg, #IFabTextBlock>, value: FontStretch) =
        this.AddScalar(TextBlock.FontStretch.WithValue(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextBlock>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextBlock.ForegroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextBlock>, value: IBrush) =
        this.AddScalar(TextBlock.Foreground.WithValue(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextBlock>, value: Color) =
        TextBlockModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextBlock>, value: string) =
        TextBlockModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Sets the BaseLineOffset property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BaseLineOffset value.</param>
    [<Extension>]
    static member inline baselineOffset(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        this.AddScalar(TextBlock.BaseLineOffset.WithValue(value))

    /// <summary>Sets the LineHeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LineHeight value.</param>
    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        this.AddScalar(TextBlock.LineHeight.WithValue(value))

    /// <summary>Sets the LetterSpacing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LetterSpacing value.</param>
    [<Extension>]
    static member inline letterSpacing(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        this.AddScalar(TextBlock.LetterSpacing.WithValue(value))

    /// <summary>Sets the MaxLines property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxLines value.</param>
    [<Extension>]
    static member inline maxLines(this: WidgetBuilder<'msg, #IFabTextBlock>, value: int) =
        this.AddScalar(TextBlock.MaxLines.WithValue(value))

    /// <summary>Sets the TextAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextAlignment value.</param>
    [<Extension>]
    static member inline textAlignment(this: WidgetBuilder<'msg, #IFabTextBlock>, value: TextAlignment) =
        this.AddScalar(TextBlock.TextAlignment.WithValue(value))

    /// <summary>Sets the TextWrapping property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextWrapping value.</param>
    [<Extension>]
    static member inline textWrapping(this: WidgetBuilder<'msg, #IFabTextBlock>, value: TextWrapping) =
        this.AddScalar(TextBlock.TextWrapping.WithValue(value))

    /// <summary>Sets the TextTrimming property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextTrimming value.</param>
    [<Extension>]
    static member inline textTrimming(this: WidgetBuilder<'msg, #IFabTextBlock>, value: TextTrimming) =
        this.AddScalar(TextBlock.TextTrimming.WithValue(value))

    /// <summary>Sets the LineSpacing property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The LineSpacing value.</param>
    [<Extension>]
    static member inline lineSpacing(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        this.AddScalar(TextBlock.LineSpacing.WithValue(value))

    /// <summary>Link a ViewRef to access the direct TextBlock control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabTextBlock>, value: ViewRef<TextBlock>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))


type TextBlockExtraModifiers =
    /// <summary>Sets the TextAlignment property to center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline centerText(this: WidgetBuilder<'msg, #IFabTextBlock>) =
        this.AddScalar(TextBlock.TextAlignment.WithValue(TextAlignment.Center))

    /// <summary>Sets the Padding property uniformly.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Padding value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTextBlock>, value: float) =
        TextBlockModifiers.padding(this, Thickness(value))

    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="left">The left value.</param>
    /// <param name="top">The top value.</param>
    /// <param name="right">The right value.</param>
    /// <param name="bottom">The bottom value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTextBlock>, left: float, top: float, right: float, bottom: float) =
        TextBlockModifiers.padding(this, Thickness(left, top, right, bottom))

    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="horizontal">The horizontal value.</param>
    /// <param name="vertical">The vertical value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTextBlock>, horizontal: float, vertical) =
        TextBlockModifiers.padding(this, Thickness(horizontal, vertical))

type TextBlockCollectionBuilderExtensions =

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabTextDecoration>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabTextDecoration>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabInline>, x: WidgetBuilder<'msg, 'itemType>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield<'msg, 'marker, 'itemType when 'msg: equality and 'itemType :> IFabInline>
        (_: AttributeCollectionBuilder<'msg, 'marker, IFabInline>, x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>)
        : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

type InlineCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'msg: equality and 'marker :> IFabInline>(this: WidgetBuilder<'msg, 'marker>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>(this, Inline.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<'msg, #IFabInline>, value: WidgetBuilder<'msg, IFabTextDecoration>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>(this, Inline.TextDecorations) { value }

type TextBlockCollectionModifiers =
    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline textDecorations<'msg, 'marker when 'msg: equality and 'marker :> IFabTextBlock>(this: WidgetBuilder<'msg, 'marker>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>(this, TextBlock.TextDecorations)

    /// <summary>Sets the TextDecorations property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextDecoration value.</param>
    [<Extension>]
    static member inline textDecoration(this: WidgetBuilder<'msg, #IFabTextBlock>, value: WidgetBuilder<'msg, IFabTextDecoration>) =
        AttributeCollectionBuilder<'msg, 'marker, IFabTextDecoration>(this, TextBlock.TextDecorations) { value }
