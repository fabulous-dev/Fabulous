namespace Fabulous.Maui

open Microsoft.Maui
open Microsoft.Maui.Graphics

module Rectangle =
    ()

type FabShape() =
    inherit Node()
    abstract GetPath: unit -> PathF
    
    interface IShape with
        member this.PathForBounds(_bounds: Rect) =
            this.GetPath()

type FabRectangle() =
    inherit FabShape()
    
    override this.GetPath() =
        let rect = this :?> IShape
        let path = PathF()

        let x = this.StrokeThickness / 2
        let y = this.StrokeThickness / 2
        let w = (float)(Width - StrokeThickness);
        let h = (float)(Height - StrokeThickness);
        let cornerRadius = (float)Math.Max(RadiusX, RadiusY)

        // TODO: Create specific Path taking into account RadiusX and RadiusY
        path.AppendRoundedRectangle(x, y, w, h, cornerRadius)

        path