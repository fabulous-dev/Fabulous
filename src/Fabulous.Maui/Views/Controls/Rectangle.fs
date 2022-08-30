namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.FSharp.Core
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers
open Microsoft.Maui.Shapes
    
module Rectangle =
    let RadiusX = Attributes.defineMauiScalarWithEquality<float> "RadiusX"
    let RadiusY = Attributes.defineMauiScalarWithEquality<float> "RadiusY"
    
    module Defaults =
        let RadiusX = 0.
        let RadiusY = 0.
    
type FabRectangle(handler: IViewHandler) =
    inherit FabShapeView(handler, fun shapeView -> RectangleShape(shapeView :?> IRectangle))
    
    static let _widgetKey = Widgets.register<FabRectangle>()
    static member WidgetKey = _widgetKey
    
    new() = FabRectangle(RectangleHandler())
    
    interface IRectangle with
        member this.RadiusX = this.GetScalar(Rectangle.RadiusX, Rectangle.Defaults.RadiusX)
        member this.RadiusY = this.GetScalar(Rectangle.RadiusY, Rectangle.Defaults.RadiusY)
        
[<AutoOpen>]
module RectangleBuilders =
    type Fabulous.Maui.View with
        static member inline Rectangle<'msg>(fill: Paint) =
            WidgetBuilder<'msg, IRectangle>(
                FabRectangle.WidgetKey,
                ShapeView.Fill.WithValue(fill)
            )
            
[<Extension>]
type RectangleModifiers =
    [<Extension>]
    static member radius<'msg>(view: WidgetBuilder<'msg, IRectangle>, x: float, y: float) =
        view
            .AddScalar(Rectangle.RadiusX.WithValue(x))
            .AddScalar(Rectangle.RadiusY.WithValue(y))