namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabBlurEffect =
    inherit IFabEffect

module BlurEffect =
    let WidgetKey = Widgets.register<BlurEffect>()

    let Radius = Attributes.defineAvaloniaPropertyWithEquality BlurEffect.RadiusProperty

[<AutoOpen>]
module BlurEffectBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a BlurEffect widget.</summary>
        static member BlurEffect() =
            WidgetBuilder<'msg, IFabBlurEffect>(BlurEffect.WidgetKey)

        /// <summary>Creates a BlurEffect widget.</summary>
        /// <param name="radius">The radius of the blur effect.</param>
        static member BlurEffect(radius: float) =
            WidgetBuilder<'msg, IFabBlurEffect>(BlurEffect.WidgetKey, BlurEffect.Radius.WithValue(radius))

type BlurEffectModifiers =

    /// <summary>Link a ViewRef to access the direct BlurEffect control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabBlurEffect>, value: ViewRef<BlurEffect>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
