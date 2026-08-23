namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabDropShadowEffectBase =
    inherit IFabEffect

module DropShadowEffectBase =
    let BlurRadius =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowEffectBase.BlurRadiusProperty

    let Color =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowEffectBase.ColorProperty

    let Opacity =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowEffectBase.OpacityProperty

type DropShadowEffectBaseModifiers =
    /// <summary>Sets the BlurRadius property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The BlurRadius value.</param>
    [<Extension>]
    static member inline blurRadius(this: WidgetBuilder<'msg, #IFabDropShadowEffectBase>, value: float) =
        this.AddScalar(DropShadowEffectBase.BlurRadius.WithValue(value))

    /// <summary>Sets the Color property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Color value.</param>
    [<Extension>]
    static member inline color(this: WidgetBuilder<'msg, #IFabDropShadowEffectBase>, value: Color) =
        this.AddScalar(DropShadowEffectBase.Color.WithValue(value))

    /// <summary>Sets the Opacity property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Opacity value.</param>
    [<Extension>]
    static member inline opacity(this: WidgetBuilder<'msg, #IFabDropShadowEffectBase>, value: float) =
        this.AddScalar(DropShadowEffectBase.Opacity.WithValue(value))
