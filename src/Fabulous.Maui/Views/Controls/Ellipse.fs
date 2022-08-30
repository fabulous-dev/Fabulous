namespace Fabulous.Maui

open Fabulous
open Microsoft.FSharp.Core
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers
open Microsoft.Maui.Shapes
    
type FabEllipse(handler: IViewHandler) =
    inherit FabShapeView(handler, fun shapeView -> EllipseShape(shapeView :?> IEllipse))
    
    static let _widgetKey = Widgets.register<FabEllipse>()
    static member WidgetKey = _widgetKey
    
    new() = FabEllipse(ShapeViewHandler())
    
    interface IEllipse
        
[<AutoOpen>]
module EllipseBuilders =
    type Fabulous.Maui.View with
        static member inline Ellipse<'msg>(stroke: Paint, strokeThickness: float) =
            WidgetBuilder<'msg, IEllipse>(
                FabEllipse.WidgetKey,
                Stroke.Stroke.WithValue(stroke),
                Stroke.StrokeThickness.WithValue(strokeThickness)
            )