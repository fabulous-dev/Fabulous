namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabVisual =
    inherit IFabStyledElement

module Visual =
    let ClipToBounds =
        Attributes.defineAvaloniaPropertyWithEquality Visual.ClipToBoundsProperty

    let ClipWidget = Attributes.defineAvaloniaPropertyWidget Visual.ClipProperty

    let Clip = Attributes.defineAvaloniaPropertyWithEquality Visual.ClipProperty

    let IsVisible =
        Attributes.defineAvaloniaPropertyWithEquality Visual.IsVisibleProperty

    let Opacity = Attributes.defineAvaloniaPropertyWithEquality Visual.OpacityProperty

    let OpacityMaskWidget =
        Attributes.defineAvaloniaPropertyWidget Visual.OpacityMaskProperty

    let OpacityMask =
        Attributes.defineAvaloniaPropertyWithEquality Visual.OpacityMaskProperty

    let RenderTransformWidget =
        Attributes.defineAvaloniaPropertyWidget Visual.RenderTransformProperty

    let RenderTransform =
        Attributes.defineAvaloniaPropertyWithEquality Visual.RenderTransformProperty

    let RenderTransformOrigin =
        Attributes.defineAvaloniaPropertyWithEquality Visual.RenderTransformOriginProperty

    let ZIndex = Attributes.defineAvaloniaPropertyWithEquality Visual.ZIndexProperty

    let FlowDirection =
        Attributes.defineAvaloniaPropertyWithEquality Visual.FlowDirectionProperty

    let EffectWidget = Attributes.defineAvaloniaPropertyWidget Visual.EffectProperty

    let Effect = Attributes.defineAvaloniaPropertyWithEquality Visual.EffectProperty

type VisualModifiers =
    /// <summary>Sets the ClipToBounds property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ClipToBounds value.</param>
    [<Extension>]
    static member inline clipToBounds(this: WidgetBuilder<'msg, #IFabVisual>, value: bool) =
        this.AddScalar(Visual.ClipToBounds.WithValue(value))

    /// <summary>Sets the Clip property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Clip value.</param>
    [<Extension>]
    static member inline clip(this: WidgetBuilder<'msg, #IFabVisual>, value: Geometry) =
        this.AddScalar(Visual.Clip.WithValue(value))

    /// <summary>Sets the IsVisible property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The IsVisible value.</param>
    [<Extension>]
    static member inline isVisible(this: WidgetBuilder<'msg, #IFabVisual>, value: bool) =
        this.AddScalar(Visual.IsVisible.WithValue(value))

    /// <summary>Sets the Opacity property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Opacity value.</param>
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabVisual>, value: double) =
        this.AddScalar(Visual.Opacity.WithValue(value))

    /// <summary>Sets the RenderTransform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RenderTransform value.</param>
    [<Extension>]
    static member inline renderTransform(this: WidgetBuilder<'msg, #IFabVisual>, value: ITransform) =
        this.AddScalar(Visual.RenderTransform.WithValue(value))

    /// <summary>Sets the RenderTransformOrigin property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RenderTransformOrigin value.</param>
    [<Extension>]
    static member inline renderTransformOrigin(this: WidgetBuilder<'msg, #IFabVisual>, value: RelativePoint) =
        this.AddScalar(Visual.RenderTransformOrigin.WithValue(value))

    /// <summary>Sets the ZIndex property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ZIndex value.</param>
    [<Extension>]
    static member inline zIndex(this: WidgetBuilder<'msg, #IFabVisual>, value: int) =
        this.AddScalar(Visual.ZIndex.WithValue(value))

    /// <summary>Sets the FlowDirection property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The FlowDirection value.</param>
    [<Extension>]
    static member inline flowDirection(this: WidgetBuilder<'msg, #IFabVisual>, value: FlowDirection) =
        this.AddScalar(Visual.FlowDirection.WithValue(value))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, value: WidgetBuilder<'msg, #IFabBrush>) =
        this.AddWidget(Visual.OpacityMaskWidget.WithValue(value.Compile()))

    /// <summary>Sets the OpacityMask property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The OpacityMask value.</param>
    [<Extension>]
    static member inline opacityMask(this: WidgetBuilder<'msg, #IFabVisual>, value: IBrush) =
        this.AddScalar(Visual.OpacityMask.WithValue(value))

    /// <summary>Sets the RenderTransform property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The RenderTransform value.</param>
    [<Extension>]
    static member inline renderTransform(this: WidgetBuilder<'msg, #IFabVisual>, value: WidgetBuilder<'msg, #IFabTransform>) =
        this.AddWidget(Visual.RenderTransformWidget.WithValue(value.Compile()))
