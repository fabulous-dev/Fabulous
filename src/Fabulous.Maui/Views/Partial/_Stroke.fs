namespace Fabulous.Maui

open Microsoft.Maui.Graphics

module Stroke =
    let Stroke = Attributes.defineMauiScalarWithEquality<Paint> "Stroke"
    let StrokeThickness = Attributes.defineMauiScalarWithEquality<float> "StrokeThickness"
    let StrokeLineCap = Attributes.defineMauiScalarWithEquality<LineCap> "StrokeLineCap"
    let StrokeLineJoin = Attributes.defineMauiScalarWithEquality<LineJoin> "StrokeLineJoin"
    let StrokeDashPattern = Attributes.defineMauiScalarWithEquality<float32[]> "StrokeDashPattern"
    let StrokeDashOffset = Attributes.defineMauiScalarWithEquality<float32> "StrokeDashOffset"
    let StrokeMiterLimit = Attributes.defineMauiScalarWithEquality<float32> "StrokeMiterLimit"
    
    module Defaults =
        let [<Literal>] Stroke = null
        let [<Literal>] StrokeThickness = 1.
        let [<Literal>] StrokeLineCap = LineCap.Butt
        let [<Literal>] StrokeLineJoin = LineJoin.Miter
        let [<Literal>] StrokeDashPattern: float32[] = null
        let [<Literal>] StrokeDashOffset = 0.f
        let [<Literal>] StrokeMiterLimit = 10.f