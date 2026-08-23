namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabScaleTransform =
    inherit IFabTransform

module ScaleTransform =
    let WidgetKey = Widgets.register<ScaleTransform>()

    let CenterX = Attributes.defineBindableFloat ScaleTransform.CenterXProperty

    let CenterY = Attributes.defineBindableFloat ScaleTransform.CenterYProperty

    let ScaleXY =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "ScaleTransform_Scale" (fun _ newValueOpt node ->
            let line = node.Target :?> ScaleTransform

            match newValueOpt with
            | ValueNone ->
                line.ScaleX <- 0.
                line.ScaleY <- 0.
            | ValueSome(x, y) ->
                line.ScaleX <- x
                line.ScaleY <- y)

[<AutoOpen>]
module ScaleTransformBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a ScaleTransform widget with a scale and a center point</summary>
        /// <param name="scaleX">The X component of the scale</param>
        /// <param name="scaleY">The Y component of the scale</param>
        /// <param name="centerX">The X position of the center</param>
        /// <param name="centerY">The Y position of the center</param>
        static member inline ScaleTransform<'msg when 'msg: equality>(scaleX: float, scaleY: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IFabScaleTransform>(
                ScaleTransform.WidgetKey,
                ScaleTransform.ScaleXY.WithValue(struct (scaleX, scaleY)),
                ScaleTransform.CenterX.WithValue(centerX),
                ScaleTransform.CenterY.WithValue(centerY)
            )

[<Extension>]
type ScaleTransformModifiers =
    /// <summary>Link a ViewRef to access the direct ScaleTransform control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabScaleTransform>, value: ViewRef<ScaleTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
