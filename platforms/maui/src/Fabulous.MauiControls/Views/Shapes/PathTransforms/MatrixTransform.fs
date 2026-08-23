namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls.Shapes

type IFabMatrixTransform =
    inherit IFabTransform

// FIXME Should we expose some of the Matrix methods? ie Invert or RotateAt ...? as extension methods
// https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Maui.shapes.matrix
module MatrixTransform =
    let WidgetKey = Widgets.register<MatrixTransform>()

    let Matrix =
        Attributes.defineSimpleScalarWithEquality<struct (float * float * float * float * float * float)> "MatrixTransform_Matrix" (fun _ newValueOpt node ->
            let line = node.Target :?> MatrixTransform

            match newValueOpt with
            | ValueNone ->
                let matrix = Matrix(0., 0., 0., 0., 0., 0.)
                line.Matrix <- matrix
            | ValueSome(m11, m12, m21, m22, offsetX, offsetY) ->
                let matrix = Matrix(m11, m12, m21, m22, offsetX, offsetY)

                line.Matrix <- matrix)

[<AutoOpen>]
module MatrixTransformBuilders =
    type Fabulous.Maui.View with

        /// <summary>Create a MatrixTransform widget</summary>
        /// <param name="m11">The M11 component of the matrix transform</param>
        /// <param name="m12">The M12 component of the matrix transform</param>
        /// <param name="m21">The M21 component of the matrix transform</param>
        /// <param name="m22">The M22 component of the matrix transform</param>
        /// <param name="offsetX">The X component of the offset</param>
        /// <param name="offsetY">The Y component of the offset</param>
        static member inline MatrixTransform<'msg when 'msg: equality>(m11: float, m12: float, m21: float, m22: float, offsetX: float, offsetY: float) =
            WidgetBuilder<'msg, IFabMatrixTransform>(MatrixTransform.WidgetKey, MatrixTransform.Matrix.WithValue(struct (m11, m12, m21, m22, offsetX, offsetY)))

[<Extension>]
type MatrixTransformModifiers =
    /// <summary>Link a ViewRef to access the direct MatrixTransform control instance</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">The ViewRef instance that will receive access to the underlying control</param>
    [<Extension>]
    static member inline reference(this: WidgetBuilder<'msg, IFabMatrixTransform>, value: ViewRef<MatrixTransform>) =
        this.AddScalar(ViewRefAttributes.ViewRef.WithValue(value.Unbox))
