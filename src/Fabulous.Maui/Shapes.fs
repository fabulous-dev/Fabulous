namespace Fabulous.Maui

open Microsoft.Maui.FabCompat
open Microsoft.Maui.FabCompat.Shapes;
open Microsoft.Maui.Graphics

type RectangleShape(view: IRectangle) =
    interface IShape with
        member this.PathForBounds(bounds) =
            view.GetPathForBounds(bounds)

type EllipseShape(view: IEllipse) =
    interface IShape with
        member this.PathForBounds(bounds) =
            view.GetPathForBounds(bounds)
