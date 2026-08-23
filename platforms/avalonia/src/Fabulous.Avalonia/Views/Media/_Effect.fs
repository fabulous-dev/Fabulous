namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

type IFabEffect =
    inherit IFabAnimatable

type AttachedEffectModifiers =
    /// <summary>Sets the Effect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Effect value.</param>
    [<Extension>]
    static member inline effect(this: WidgetBuilder<'msg, #IFabVisual>, value: WidgetBuilder<'msg, #IFabEffect>) =
        this.AddWidget(Visual.EffectWidget.WithValue(value.Compile()))

    /// <summary>Sets the Effect property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Effect value.</param>
    [<Extension>]
    static member inline effect(this: WidgetBuilder<'msg, #IFabVisual>, value: string) =
        this.AddScalar(Visual.Effect.WithValue(Effect.Parse(value)))
