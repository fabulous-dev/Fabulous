namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type IFabSkewTransform =
    inherit IFabTransform

module SkewTransform =

    let WidgetKey = Widgets.register<SkewTransform>()

    let AngleX =
        Attributes.defineAvaloniaPropertyWithEquality SkewTransform.AngleXProperty

    let AngleY =
        Attributes.defineAvaloniaPropertyWithEquality SkewTransform.AngleYProperty

[<AutoOpen>]
module SkewTransformBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a SkewTransform widget.</summary>
        /// <param name="angleX">The AngleX to apply.</param>
        /// <param name="angleY">The AngleY to apply.</param>
        static member SkewTransform(angleX: float, angleY: float) =
            WidgetBuilder<'msg, IFabSkewTransform>(SkewTransform.WidgetKey, SkewTransform.AngleX.WithValue(angleX), SkewTransform.AngleY.WithValue(angleY))

        /// <summary>Creates a SkewTransform widget.</summary>
        /// <param name="angleX">The AngleX to apply.</param>
        static member SkewTransform(angleX: float) =
            WidgetBuilder<'msg, IFabSkewTransform>(SkewTransform.WidgetKey, SkewTransform.AngleX.WithValue(angleX))

        /// <summary>Creates a SkewTransform widget.</summary>
        static member SkewTransform() =
            WidgetBuilder<'msg, IFabSkewTransform>(SkewTransform.WidgetKey)

type SkewTransformTransformModifiers =
    /// <summary>Link a ViewRef to access the direct SkewTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSkewTransform>, value: ViewRef<SkewTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
