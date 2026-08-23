namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Layout
open Fabulous

type IFabLayoutable =
    inherit IFabVisual

module Layoutable =
    let Width = Attributes.defineAvaloniaPropertyWithEquality Layoutable.WidthProperty

    let Height = Attributes.defineAvaloniaPropertyWithEquality Layoutable.HeightProperty

    let MinWidth =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MinWidthProperty

    let MinHeight =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MinHeightProperty

    let MaxWidth =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MaxWidthProperty

    let MaxHeight =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.MaxHeightProperty

    let Margin = Attributes.defineAvaloniaPropertyWithEquality Layoutable.MarginProperty

    let HorizontalAlignment =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.HorizontalAlignmentProperty

    let VerticalAlignment =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.VerticalAlignmentProperty

    let UseLayoutRounding =
        Attributes.defineAvaloniaPropertyWithEquality Layoutable.UseLayoutRoundingProperty

type LayoutableModifiers =
    /// <summary>Sets the Width property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Width value.</param>
    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.Width.WithValue(value))

    /// <summary>Sets the Height property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Height value.</param>
    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.Height.WithValue(value))

    /// <summary>Sets the MinWidth property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinWidth value.</param>
    [<Extension>]
    static member inline minWidth(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MinWidth.WithValue(value))

    /// <summary>Sets the MinHeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MinHeight value.</param>
    [<Extension>]
    static member inline minHeight(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MinHeight.WithValue(value))

    /// <summary>Sets the MaxWidth property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxWidth value.</param>
    [<Extension>]
    static member inline maxWidth(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MaxWidth.WithValue(value))

    /// <summary>Sets the MaxHeight property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The MaxHeight value.</param>
    [<Extension>]
    static member inline maxHeight(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) =
        this.AddScalar(Layoutable.MaxHeight.WithValue(value))

    /// <summary>Sets the Margin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Margin value.</param>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, value: Thickness) =
        this.AddScalar(Layoutable.Margin.WithValue(value))

    /// <summary>Sets the HorizontalAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The HorizontalAlignment value.</param>
    [<Extension>]
    static member inline horizontalAlignment(this: WidgetBuilder<'msg, #IFabLayoutable>, value: HorizontalAlignment) =
        this.AddScalar(Layoutable.HorizontalAlignment.WithValue(value))

    /// <summary>Sets the VerticalAlignment property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The VerticalAlignment value.</param>
    [<Extension>]
    static member inline verticalAlignment(this: WidgetBuilder<'msg, #IFabLayoutable>, value: VerticalAlignment) =
        this.AddScalar(Layoutable.VerticalAlignment.WithValue(value))

    /// <summary>Sets the UseLayoutRounding property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The UseLayoutRounding value.</param>
    [<Extension>]
    static member inline useLayoutRounding(this: WidgetBuilder<'msg, #IFabLayoutable>, value: bool) =
        this.AddScalar(Layoutable.UseLayoutRounding.WithValue(value))

type LayoutableExtraModifiers =
    /// <summary>Sets the HorizontalAlignment property to Center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.horizontalAlignment(HorizontalAlignment.Center)

    /// <summary>Sets the VerticalAlignment property to Center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.verticalAlignment(VerticalAlignment.Center)

    /// <summary>Sets the HorizontalAlignment and VerticalAlignment properties to Center.</summary>
    /// <param name="this">Current widget.</param>
    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IFabLayoutable>) =
        this.centerHorizontal().centerVertical()

    /// <summary>Sets the Margin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Margin value.</param>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, value: float) = this.margin(Thickness(value))

    /// <summary>Sets the Margin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="horizontal">The horizontal Margin value.</param>
    /// <param name="vertical">The vertical Margin value.</param>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, horizontal: float, vertical: float) =
        this.margin(Thickness(horizontal, vertical))

    /// <summary>Sets the Margin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="left">The left Margin value.</param>
    /// <param name="top">The top Margin value.</param>
    /// <param name="right">The right Margin value.</param>
    /// <param name="bottom">The bottom Margin value.</param>
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IFabLayoutable>, left: float, top: float, right: float, bottom: float) =
        this.margin(Thickness(left, top, right, bottom))

    /// <summary>Sets the Width and Height properties.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="width">The Width value.</param>
    /// <param name="height">The Height value.</param>
    [<Extension>]
    static member inline size(this: WidgetBuilder<'msg, #IFabLayoutable>, width: float, height: float) = this.width(width).height(height)
