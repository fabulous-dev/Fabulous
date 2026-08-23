namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia
open Avalonia.Media
open Fabulous

type IFabMatrixTransform =
    inherit IFabTransform

module MatrixTransform =

    let WidgetKey = Widgets.register<MatrixTransform>()

    let Matrix =
        Attributes.defineAvaloniaPropertyWithEquality MatrixTransform.MatrixProperty

[<AutoOpen>]
module MatrixTransformBuilders =
    type Fabulous.Avalonia.View with

        /// <summary>Creates a MatrixTransform widget.</summary>
        /// <param name="matrix">The Matrix to apply.</param>
        static member MatrixTransform(matrix: Matrix) =
            WidgetBuilder<'msg, IFabMatrixTransform>(MatrixTransform.WidgetKey, MatrixTransform.Matrix.WithValue(matrix))

type MatrixTransformModifiers =
    /// <summary>Link a ViewRef to access the direct MatrixTransform control instance.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control.</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMatrixTransform>, value: ViewRef<MatrixTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
