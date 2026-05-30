namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabSkewTransform =
    inherit IFabTransform

module SkewTransform =
    let WidgetKey = Widgets.register<SkewTransform>()

    let AnglesXY =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "SkewTransform_Angles" (fun _ newValueOpt node ->
            let line = node.Target :?> SkewTransform

            match newValueOpt with
            | ValueNone ->
                line.AngleX <- 0.
                line.AngleY <- 0.
            | ValueSome(x, y) ->
                line.AngleX <- x
                line.AngleY <- y)

    let CenterX = Attributes.defineBindableFloat ScaleTransform.CenterXProperty

    let CenterY = Attributes.defineBindableFloat ScaleTransform.CenterYProperty

[<AutoOpen>]
module SkewTransformBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a SkewTransform widget with a scale and a center point</summary>
        /// <param name="angleX">The X component of the angle</param>
        /// <param name="angleY">The Y component of the angle</param>
        /// <param name="centerX">The X position of the center</param>
        /// <param name="centerY">The Y position of the center</param>
        static member inline SkewTransform<'msg when 'msg: equality>(angleX: float, angleY: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IFabSkewTransform>(
                SkewTransform.WidgetKey,
                SkewTransform.AnglesXY.WithValue(struct (angleX, angleY)),
                SkewTransform.CenterX.WithValue(centerX),
                SkewTransform.CenterY.WithValue(centerY)
            )

[<Extension>]
type SkewTransformModifiers =
    /// <summary>Link a ViewRef to access the direct SkewTransform control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabSkewTransform>, value: ViewRef<SkewTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
