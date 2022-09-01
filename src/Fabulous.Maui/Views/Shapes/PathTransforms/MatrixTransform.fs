namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls.Shapes

type IMatrixTransform =
    inherit ITransform

// FIXME Should we expose some of the Matrix methods? ie Invert or RotateAt ...? as extension methods
// https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Maui.shapes.matrix?view=xamarin-forms
module MatrixTransform =
    let WidgetKey = Widgets.register<MatrixTransform>()

    let Matrix =
        Attributes.defineSimpleScalarWithEquality<struct (float * float * float * float * float * float)>
            "MatrixTransform_Matrix"
            (fun _ newValueOpt node ->
                let line = node.Target :?> MatrixTransform

                match newValueOpt with
                | ValueNone ->
                    let matrix = Matrix(0., 0., 0., 0., 0., 0.)
                    line.Matrix <- matrix
                | ValueSome (m11, m12, m21, m22, offsetX, offsetY) ->
                    let matrix =
                        Matrix(m11, m12, m21, m22, offsetX, offsetY)

                    line.Matrix <- matrix)

[<AutoOpen>]
module MatrixTransformBuilders =

    type Fabulous.Maui.View with
        static member inline MatrixTransform<'msg>
            (
                m11: float,
                m12: float,
                m21: float,
                m22: float,
                offsetX: float,
                offsetY: float
            ) =
            WidgetBuilder<'msg, IMatrixTransform>(
                MatrixTransform.WidgetKey,
                MatrixTransform.Matrix.WithValue((m11, m12, m21, m22, offsetX, offsetY))
            )
