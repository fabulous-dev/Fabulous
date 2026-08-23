namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Avalonia.Media.Imaging
open Fabulous

module RenderOptions =

    let BitmapInterpolationMode =
        Attributes.definePropertyWithGetSet
            "RenderOptions_BitmapInterpolationMode"
            (fun target ->
                let target = target :?> Visual
                RenderOptions.GetBitmapInterpolationMode(target))
            (fun target value ->
                let target = target :?> Visual
                RenderOptions.SetBitmapInterpolationMode(target, value))

    let BitmapBlendingMode =
        Attributes.definePropertyWithGetSet
            "RenderOptions_BitmapBlendingMode"
            (fun target ->
                let target = target :?> Visual
                RenderOptions.GetBitmapBlendingMode(target))
            (fun target value ->
                let target = target :?> Visual
                RenderOptions.SetBitmapBlendingMode(target, value))

    let EdgeMode =
        Attributes.definePropertyWithGetSet
            "RenderOptions_EdgeMode"
            (fun target ->
                let target = target :?> Visual
                RenderOptions.GetEdgeMode(target))
            (fun target value ->
                let target = target :?> Visual
                RenderOptions.SetEdgeMode(target, value))

    let TextRenderingMode =
        Attributes.definePropertyWithGetSet
            "RenderOptions_TextRenderingMode"
            (fun target ->
                let target = target :?> Visual
                RenderOptions.GetTextRenderingMode(target))
            (fun target value ->
                let target = target :?> Visual
                RenderOptions.SetTextRenderingMode(target, value))

type RenderOptionsModifiers =
    /// <summary>Sets the BitmapInterpolationMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BitmapInterpolationMode value.</param>
    [<Extension>]
    static member inline bitmapInterpolationMode(this: WidgetBuilder<'msg, #IFabElement>, value: BitmapInterpolationMode) =
        this.AddScalar(RenderOptions.BitmapInterpolationMode.WithValue(value))

    /// <summary> Sets the BitmapBlendingMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BitmapBlendingMode value.</param>
    [<Extension>]
    static member inline bitmapBlendingMode(this: WidgetBuilder<'msg, #IFabElement>, value: BitmapBlendingMode) =
        this.AddScalar(RenderOptions.BitmapBlendingMode.WithValue(value))

    /// <summary>Sets the EdgeMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The EdgeMode value.</param>
    [<Extension>]
    static member inline edgeMode(this: WidgetBuilder<'msg, #IFabElement>, value: EdgeMode) =
        this.AddScalar(RenderOptions.EdgeMode.WithValue(value))

    /// <summary>Sets the TextRenderingMode property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TextRenderingMode value.</param>
    [<Extension>]
    static member inline textRenderingMode(this: WidgetBuilder<'msg, #IFabElement>, value: TextRenderingMode) =
        this.AddScalar(RenderOptions.TextRenderingMode.WithValue(value))
