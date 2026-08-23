namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Documents
open Avalonia.Media
open Fabulous

type IFabTextElement =
    inherit IFabStyledElement

module TextElement =
    let BackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget TextElement.BackgroundProperty

    let Background =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.BackgroundProperty

    let FontFamily =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontFamilyProperty

    let FontSize =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontSizeProperty

    let FontStyle =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontStyleProperty

    let FontWeight =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontWeightProperty

    let FontStretch =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.FontStretchProperty

    let ForegroundWidget =
        Attributes.defineAvaloniaPropertyWidget TextElement.ForegroundProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWithEquality TextElement.ForegroundProperty

type TextElementModifiers =
    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BackgroundWidget value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextElement>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextElement.BackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextElement>, value: IBrush) =
        this.AddScalar(TextElement.Background.WithValue(value))

    /// <summary>Sets the FontFamily property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontFamily value.</param>
    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #IFabTextElement>, value: FontFamily) =
        this.AddScalar(TextElement.FontFamily.WithValue(value))

    /// <summary>Sets the FontSize property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontSize value.</param>
    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, #IFabTextElement>, value: float) =
        this.AddScalar(TextElement.FontSize.WithValue(value))

    /// <summary>Sets the FontStyle property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontStyle value.</param>
    [<Extension>]
    static member inline fontStyle(this: WidgetBuilder<'msg, #IFabTextElement>, value: FontStyle) =
        this.AddScalar(TextElement.FontStyle.WithValue(value))

    /// <summary>Sets the FontWeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontWeight value.</param>
    [<Extension>]
    static member inline fontWeight(this: WidgetBuilder<'msg, #IFabTextElement>, value: FontWeight) =
        this.AddScalar(TextElement.FontWeight.WithValue(value))

    /// <summary>Sets the FontStretch property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontStretch value.</param>
    [<Extension>]
    static member inline fontStretch(this: WidgetBuilder<'msg, #IFabTextElement>, value: FontStretch) =
        this.AddScalar(TextElement.FontStretch.WithValue(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextElement>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TextElement.ForegroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextElement>, value: IBrush) =
        this.AddScalar(TextElement.Foreground.WithValue(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextElement>, value: Color) =
        TextElementModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTextElement>, value: string) =
        TextElementModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextElement>, value: Color) =
        TextElementModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTextElement>, value: string) =
        TextElementModifiers.foreground(this, View.SolidColorBrush(value))
