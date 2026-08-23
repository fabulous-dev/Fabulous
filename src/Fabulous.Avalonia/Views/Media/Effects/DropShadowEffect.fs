namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabDropShadowEffect =
    inherit IFabDropShadowEffectBase

module DropShadowEffect =
    let WidgetKey = Widgets.register<DropShadowEffect>()

    let OffsetX =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowEffect.OffsetXProperty

    let OffsetY =
        Attributes.defineAvaloniaPropertyWithEquality DropShadowEffect.OffsetYProperty

[<AutoOpen>]
module DropShadowEffectBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a DropShadowEffect widget.</summary>
        static member DropShadowEffect() =
            WidgetBuilder<'msg, IFabDropShadowEffect>(DropShadowEffect.WidgetKey)

        /// <summary>Creates a DropShadowEffect widget.</summary>
        /// <param name="offsetX">The X offset of the shadow.</param>
        /// <param name="offsetY">The Y offset of the shadow.</param>
        static member DropShadowEffect(offsetX: float, offsetY: float) =
            WidgetBuilder<'msg, IFabDropShadowEffect>(
                DropShadowEffect.WidgetKey,
                DropShadowEffect.OffsetX.WithValue(offsetX),
                DropShadowEffect.OffsetY.WithValue(offsetY)
            )

type DropShadowEffectModifiers =

    /// <summary>Link a ViewRef to access the direct DropShadowEffect control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabDropShadowEffect>, value: ViewRef<DropShadowEffect>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
