namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics

module ShapeView =
    let Aspect = Attributes.defineMauiScalarWithEquality<PathAspect> "Aspect"
    let Fill = Attributes.defineMauiScalarWithEquality<Paint> "Fill"
    
    module Defaults =
        let [<Literal>] Aspect = PathAspect.None
        let [<Literal>] Fill: Paint = null
    
type FabShapeView(handler: IViewHandler, shapeFn: IShapeView -> IShape) =
    inherit FabView(handler)
    
    let mutable _shape = null
        
    member this.Shape =
        if _shape = null then
            _shape <- shapeFn(this)
        
        _shape
    
    interface IStroke with
        member this.Stroke = this.GetScalar(Stroke.Stroke, Stroke.Defaults.Stroke)
        member this.StrokeDashOffset = this.GetScalar(Stroke.StrokeDashOffset, Stroke.Defaults.StrokeDashOffset)
        member this.StrokeDashPattern = this.GetScalar(Stroke.StrokeDashPattern, Stroke.Defaults.StrokeDashPattern)
        member this.StrokeLineCap = this.GetScalar(Stroke.StrokeLineCap, Stroke.Defaults.StrokeLineCap)
        member this.StrokeLineJoin = this.GetScalar(Stroke.StrokeLineJoin, Stroke.Defaults.StrokeLineJoin)
        member this.StrokeMiterLimit = this.GetScalar(Stroke.StrokeMiterLimit, Stroke.Defaults.StrokeMiterLimit)
        member this.StrokeThickness = this.GetScalar(Stroke.StrokeThickness, Stroke.Defaults.StrokeThickness)
    
    interface IShapeView with
        member this.Aspect = this.GetScalar(ShapeView.Aspect, ShapeView.Defaults.Aspect)
        member this.Fill = this.GetScalar(ShapeView.Fill, ShapeView.Defaults.Fill)
        member this.Shape = this.Shape