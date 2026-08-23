namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabCompositeTransform =
    inherit IFabTransform

module CompositeTransform =
    let WidgetKey = Widgets.register<CompositeTransform>()

    let CenterXY =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "CompositeTransform_CenterXY" (fun _ newValueOpt node ->
            let line = node.Target :?> CompositeTransform

            match newValueOpt with
            | ValueNone ->
                line.CenterX <- 0.
                line.CenterY <- 0.
            | ValueSome(x, y) ->
                line.CenterX <- x
                line.CenterY <- y)

    let Rotation = Attributes.defineBindableFloat CompositeTransform.RotationProperty

    let ScaleXY =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "CompositeTransform_ScaleXY" (fun _ newValueOpt node ->
            let line = node.Target :?> CompositeTransform

            match newValueOpt with
            | ValueNone ->
                line.ScaleX <- 0.
                line.ScaleY <- 0.
            | ValueSome(x, y) ->
                line.ScaleX <- x
                line.ScaleY <- y)

    let SkewXY =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "CompositeTransform_SkewXY" (fun _ newValueOpt node ->
            let line = node.Target :?> CompositeTransform

            match newValueOpt with
            | ValueNone ->
                line.SkewX <- 0.
                line.SkewY <- 0.
            | ValueSome(x, y) ->
                line.SkewX <- x
                line.SkewY <- y)

    let TranslateXY =
        Attributes.defineSimpleScalarWithEquality<struct (float * float)> "CompositeTransform_TranslateXY" (fun _ newValueOpt node ->
            let line = node.Target :?> CompositeTransform

            match newValueOpt with
            | ValueNone ->
                line.TranslateX <- 0.
                line.TranslateY <- 0.
            | ValueSome(x, y) ->
                line.TranslateX <- x
                line.TranslateY <- y)

[<AutoOpen>]
module CompositeTransformBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a CompositeTransform widget with a center, a scale, and a skew</summary>
        /// <param name="centerX">The X component of the center</param>
        /// <param name="centerY">The Y component of the center</param>
        /// <param name="scaleX">The X component of the scale</param>
        /// <param name="scaleY">The Y component of the scale</param>
        /// <param name="skewX">The X component of the skew</param>
        /// <param name="skewY">The Y component of the skew</param>
        static member inline CompositeTransform<'msg when 'msg: equality>(centerX: float, centerY: float, scaleX: float, scaleY: float, skewX: float, skewY: float) =
            WidgetBuilder<'msg, IFabCompositeTransform>(
                CompositeTransform.WidgetKey,
                CompositeTransform.CenterXY.WithValue(struct (centerX, centerY)),
                CompositeTransform.ScaleXY.WithValue(struct (scaleX, scaleY)),
                CompositeTransform.SkewXY.WithValue(struct (skewX, skewY))
            )

[<Extension>]
type CompositeTransformModifiers =
    /// <summary>Set the translation value</summary>
    /// <param name="this">Current widget</param>
    /// <param name="x">The X component of the translation</param>
    /// <param name="y">The Y component of the translation</param>
    [<Extension>]
    static member inline translate(this: WidgetBuilder<'msg, #IFabCompositeTransform>, x: float, y: float) =
        this.AddScalar(CompositeTransform.TranslateXY.WithValue(struct (x, y)))

    /// <summary>Set the rotation value</summary>
    /// <param name="this">Current widget</param>
    /// <param name="angle">The rotation angle value</param>
    [<Extension>]
    static member inline rotation(this: WidgetBuilder<'msg, #IFabCompositeTransform>, angle: float) =
        this.AddScalar(CompositeTransform.Rotation.WithValue(angle))

    /// <summary>Link a ViewRef to access the direct CompositeTransform control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabCompositeTransform>, value: ViewRef<CompositeTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
