namespace Fabulous.Maui

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers

module ShapeView =
    let Aspect = Attributes.defineMauiScalarWithEquality<PathAspect> "Aspect"
    let Fill = Attributes.defineMauiScalarWithEquality<Paint> "Fill"
    let Shape = Attributes.defineMauiWidget "Shape" (fun t -> (t :?> IShapeView).Aspect)
    
    module Defaults =
        let [<Literal>] Aspect = PathAspect.None
        let [<Literal>] Fill: Paint = null
    
type FabShapeView(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabShapeView>()
    static member WidgetKey = _widgetKey
    
    new() = FabShapeView(ShapeViewHandler())
    
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
        member this.Shape = this.GetWidget(ShapeView.Shape)
        
[<AutoOpen>]
module ShapeViewBuilders =
    type Fabulous.Maui.View with
        static member inline ShapeView<'msg, 'marker when 'marker :> IShape>(shape: WidgetBuilder<'msg, 'marker>) =
            WidgetBuilder<'msg, IShapeView>(
                FabShapeView.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| ShapeView.Shape.WithValue(shape.Compile()) |],
                    ValueNone
                )
            )