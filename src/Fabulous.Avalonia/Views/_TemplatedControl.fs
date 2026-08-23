namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Controls.Primitives
open Avalonia.Media
open Fabulous

type IFabTemplatedControl =
    inherit IFabControl

module TemplatedControl =
    let BackgroundWidget =
        Attributes.defineAvaloniaPropertyWidget TemplatedControl.BackgroundProperty

    let Background =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.BackgroundProperty

    let BorderBrushWidget =
        Attributes.defineAvaloniaPropertyWidget TemplatedControl.BorderBrushProperty

    let BorderBrush =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.BorderBrushProperty

    let BorderThickness =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.BorderThicknessProperty

    let CornerRadius =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.CornerRadiusProperty

    let FontFamily =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.FontFamilyProperty

    let FontSize =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.FontSizeProperty

    let FontStyle =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.FontStyleProperty

    let FontWeight =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.FontWeightProperty

    let FontStretch =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.FontStretchProperty

    let ForegroundWidget =
        Attributes.defineAvaloniaPropertyWidget TemplatedControl.ForegroundProperty

    let Foreground =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.ForegroundProperty

    let Padding =
        Attributes.defineAvaloniaPropertyWithEquality TemplatedControl.PaddingProperty

    let Template =
        Attributes.defineSimpleScalar<Widget> "TemplatedControl_Template" ScalarAttributeComparers.equalityCompare (fun _ newValueOpt node ->
            let templatedControl = node.Target :?> TemplatedControl

            match newValueOpt with
            | ValueNone -> templatedControl.ClearValue(TemplatedControl.TemplateProperty)
            | ValueSome value ->
                templatedControl.SetValue(TemplatedControl.TemplateProperty, WidgetControlTemplate(node, value))
                |> ignore)


type TemplatedControlModifiers =
    /// <summary>Sets the BackgroundWidget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BackgroundWidget value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TemplatedControl.BackgroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: IBrush) =
        this.AddScalar(TemplatedControl.Background.WithValue(value))

    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: IBrush) =
        this.AddScalar(TemplatedControl.BorderBrush.WithValue(value))

    /// <summary>Sets the BorderBrushWidget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrushWidget value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TemplatedControl.BorderBrushWidget.WithValue(value.Compile()))

    /// <summary>Sets the BorderThickness property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderThickness value.</param>
    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Thickness) =
        this.AddScalar(TemplatedControl.BorderThickness.WithValue(value))

    /// <summary>Sets the CornerRadius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CornerRadius value.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: CornerRadius) =
        this.AddScalar(TemplatedControl.CornerRadius.WithValue(value))

    /// <summary>Sets the CornerRadius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The CornerRadius value.</param>
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: float) =
        this.AddScalar(TemplatedControl.CornerRadius.WithValue(CornerRadius(value)))

    /// <summary>Sets the FontFamily property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontFamily value.</param>
    [<Extension>]
    static member inline fontFamily(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: FontFamily) =
        this.AddScalar(TemplatedControl.FontFamily.WithValue(value))

    /// <summary>Sets the FontSize property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontSize value.</param>
    [<Extension>]
    static member inline fontSize(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: float) =
        this.AddScalar(TemplatedControl.FontSize.WithValue(value))

    /// <summary>Sets the FontStyle property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontStyle value.</param>
    [<Extension>]
    static member inline fontStyle(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: FontStyle) =
        this.AddScalar(TemplatedControl.FontStyle.WithValue(value))

    /// <summary>Sets the FontWeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontWeight value.</param>
    [<Extension>]
    static member inline fontWeight(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: FontWeight) =
        this.AddScalar(TemplatedControl.FontWeight.WithValue(value))

    /// <summary>Sets the FontStretch property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FontStretch value.</param>
    [<Extension>]
    static member inline fontStretch(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: FontStretch) =
        this.AddScalar(TemplatedControl.FontStretch.WithValue(value))

    /// <summary>Sets the ForegroundWidget property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ForegroundWidget value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(TemplatedControl.ForegroundWidget.WithValue(value.Compile()))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: IBrush) =
        this.AddScalar(TemplatedControl.Foreground.WithValue(value))

    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Padding value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Thickness) =
        this.AddScalar(TemplatedControl.Padding.WithValue(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Color) =
        TemplatedControlModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the Background property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Background value.</param>
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: string) =
        TemplatedControlModifiers.background(this, View.SolidColorBrush(value))

    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Color) =
        TemplatedControlModifiers.borderBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the BorderBrush property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderBrush value.</param>
    [<Extension>]
    static member inline borderBrush(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: string) =
        TemplatedControlModifiers.borderBrush(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: Color) =
        TemplatedControlModifiers.foreground(this, View.SolidColorBrush(value))

    /// <summary>Sets the Foreground property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Foreground value.</param>
    [<Extension>]
    static member inline foreground(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: string) =
        TemplatedControlModifiers.foreground(this, View.SolidColorBrush(value))

type TemplatedControlExtraModifiers =
    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Padding value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: float) =
        TemplatedControlModifiers.padding(this, Thickness(value))

    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="horizontal">The horizontal Padding value.</param>
    /// <param name="vertical">The vertical Padding value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTemplatedControl>, horizontal: float, vertical: float) =
        TemplatedControlModifiers.padding(this, Thickness(horizontal, vertical))

    /// <summary>Sets the Padding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="left">The left Padding value.</param>
    /// <param name="top">The top Padding value.</param>
    /// <param name="right">The right Padding value.</param>
    /// <param name="bottom">The bottom Padding value.</param>
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IFabTemplatedControl>, left: float, top: float, right: float, bottom: float) =
        TemplatedControlModifiers.padding(this, Thickness(left, top, right, bottom))

    /// <summary>Sets the BorderThickness property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BorderThickness value.</param>
    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabTemplatedControl>, value: float) =
        TemplatedControlModifiers.borderThickness(this, Thickness(value))

    /// <summary>Sets the BorderThickness property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="horizontal">The horizontal BorderThickness value.</param>
    /// <param name="vertical">The vertical BorderThickness value.</param>
    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabTemplatedControl>, horizontal: float, vertical: float) =
        TemplatedControlModifiers.borderThickness(this, Thickness(horizontal, vertical))

    /// <summary>Sets the BorderThickness property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="left">The left BorderThickness value.</param>
    /// <param name="top">The top BorderThickness value.</param>
    /// <param name="right">The right BorderThickness value.</param>
    /// <param name="bottom">The bottom BorderThickness value.</param>
    [<Extension>]
    static member inline borderThickness(this: WidgetBuilder<'msg, #IFabTemplatedControl>, left: float, top: float, right: float, bottom: float) =
        TemplatedControlModifiers.borderThickness(this, Thickness(left, top, right, bottom))
