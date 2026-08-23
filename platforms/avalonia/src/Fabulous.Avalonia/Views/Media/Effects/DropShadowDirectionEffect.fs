namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabDropShadowDirectionEffect =
    inherit IFabDropShadowEffectBase

module DropShadowDirectionEffect =
    let WidgetKey = Widgets.register<DropShadowDirectionEffect>()

    let ShadowDepth =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowDirectionEffect.ShadowDepthProperty

    let Direction =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowDirectionEffect.DirectionProperty

[<AutoOpen>]
module DropShadowDirectionEffectBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DropShadowDirectionEffect widget.</summary>
        static member DropShadowDirectionEffect() =
            WidgetBuilder<'msg, IFabDropShadowDirectionEffect>(DropShadowDirectionEffect.WidgetKey)

        /// <summary>Creates a DropShadowDirectionEffect widget.</summary>
        /// <param name="shadowDepth">The depth of the shadow.</param>
        /// <param name="direction">The direction of the shadow.</param>
        static member DropShadowDirectionEffect(shadowDepth: float, direction: float) =
            WidgetBuilder<'msg, IFabDropShadowDirectionEffect>(
                DropShadowDirectionEffect.WidgetKey,
                DropShadowDirectionEffect.ShadowDepth.WithValue(shadowDepth),
                DropShadowDirectionEffect.Direction.WithValue(direction)
            )

type DropShadowDirectionEffectModifiers =

    /// <summary>Link a ViewRef to access the direct DropShadowDirectionEffect control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDropShadowDirectionEffect>, value: ViewRef<DropShadowDirectionEffect>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
