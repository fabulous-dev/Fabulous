namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabBrush =
    inherit IFabAnimatable

module Brush =

    let Opacity = Attributes.defineAvaloniaPropertyWithEquality Brush.OpacityProperty

    let Transform = Attributes.defineAvaloniaPropertyWidget Brush.TransformProperty

    let TransformOrigin =
        Attributes.defineAvaloniaPropertyWithEquality Brush.TransformOriginProperty

type BrushModifiers =

    /// <summary>Sets the Opacity property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Opacity value.</param>
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabBrush>, value: float) =
        this.AddScalar(Brush.Opacity.WithValue(value))

    /// <summary>Sets the Transform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Transform value.</param>
    [<Extension>]
    static member inline transform(this: WidgetBuilder<'msg, #IFabBrush>, value: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(Brush.Transform.WithValue(value.Compile()))

    /// <summary>Sets the TransformOrigin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The TransformOrigin value.</param>
    [<Extension>]
    static member inline transformOrigin(this: WidgetBuilder<'msg, #IFabBrush>, value: RelativePoint) =
        this.AddScalar(Brush.TransformOrigin.WithValue(value))
