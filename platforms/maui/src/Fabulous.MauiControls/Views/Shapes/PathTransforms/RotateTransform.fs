namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabRotateTransform =
    inherit IFabTransform

module RotateTransform =
    let WidgetKey = Widgets.register<RotateTransform>()

    let Angle = Attributes.defineBindableFloat RotateTransform.AngleProperty

    let CenterX = Attributes.defineBindableFloat RotateTransform.CenterXProperty

    let CenterY = Attributes.defineBindableFloat RotateTransform.CenterYProperty

[<AutoOpen>]
module RotateTransformBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a RotateTransform widget with an angle, and a center point</summary>
        /// <param name="angle">The angle value</param>
        /// <param name="centerX">The X position</param>
        /// <param name="centerY">The Y position</param>
        static member inline RotateTransform<'msg when 'msg: equality>(angle: float, centerX: float, centerY: float) =
            WidgetBuilder<'msg, IFabRotateTransform>(
                RotateTransform.WidgetKey,
                RotateTransform.Angle.WithValue(angle),
                RotateTransform.CenterX.WithValue(centerX),
                RotateTransform.CenterY.WithValue(centerY)
            )

[<Extension>]
type RotateTransformModifiers =
    /// <summary>Link a ViewRef to access the direct RotateTransform control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabRotateTransform>, value: ViewRef<RotateTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
