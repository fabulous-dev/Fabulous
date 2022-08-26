namespace Fabulous.Maui.Shapes

open System
open Microsoft.Maui.FabCompat
open Microsoft.Maui.Graphics

type RectangleShape(view: IRectangle) =
    interface IShape with
        member this.PathForBounds(bounds) =
            let path = new PathF()

            let x = float32 (view.StrokeThickness / 2.)
            let y = float32 (view.StrokeThickness / 2.)
            let w = float32 (bounds.Width - view.StrokeThickness)
            let h = float32 (bounds.Height - view.StrokeThickness)
            let cornerRadius = float32 (Math.Max(view.RadiusX, view.RadiusY))

            path.AppendRoundedRectangle(x, y, w, h, cornerRadius)

            path
