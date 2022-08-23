namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Fabulous

module Transform =
    let AnchorX = Attributes.defineMauiScalarWithEquality<float> "AnchorX"
    let AnchorY = Attributes.defineMauiScalarWithEquality<float> "AnchorY"
    let Rotation = Attributes.defineMauiScalarWithEquality<float> "Rotation"
    let RotationX = Attributes.defineMauiScalarWithEquality<float> "RotationX"
    let RotationY = Attributes.defineMauiScalarWithEquality<float> "RotationY"
    let Scale = Attributes.defineMauiScalarWithEquality<float> "Scale"
    let ScaleX = Attributes.defineMauiScalarWithEquality<float> "ScaleX"
    let ScaleY = Attributes.defineMauiScalarWithEquality<float> "ScaleY"
    let TranslationX = Attributes.defineMauiScalarWithEquality<float> "TranslationX"
    let TranslationY = Attributes.defineMauiScalarWithEquality<float> "TranslationY"

    module Defaults =
        let [<Literal>] AnchorX = 0.5
        let [<Literal>] AnchorY = 0.5
        let [<Literal>] Rotation = 0.
        let [<Literal>] RotationX = 0.
        let [<Literal>] RotationY = 0.
        let [<Literal>] Scale = 1.
        let [<Literal>] ScaleX = 1.
        let [<Literal>] ScaleY = 1.
        let [<Literal>] TranslationX = 0.
        let [<Literal>] TranslationY = 0.
        
[<Extension>]
type TransformModifiers =
    [<Extension>]
    static member inline anchor(this: WidgetBuilder<'msg, #ITransform>, x: float, y: float) =
        this.AddScalar(Transform.AnchorX.WithValue(x))
            .AddScalar(Transform.AnchorY.WithValue(y))
            
    [<Extension>]
    static member inline rotate(this: WidgetBuilder<'msg, #ITransform>, value: float) =
        this.AddScalar(Transform.Rotation.WithValue(value))
            
    [<Extension>]
    static member inline rotate(this: WidgetBuilder<'msg, #ITransform>, x: float, y: float) =
        this.AddScalar(Transform.RotationX.WithValue(x))
            .AddScalar(Transform.RotationY.WithValue(y))
            
    [<Extension>]
    static member inline scale(this: WidgetBuilder<'msg, #ITransform>, value: float) =
        this.AddScalar(Transform.Scale.WithValue(value))
        
    [<Extension>]
    static member inline scale(this: WidgetBuilder<'msg, #ITransform>, x: float, y: float) =
        this.AddScalar(Transform.ScaleX.WithValue(x))
            .AddScalar(Transform.ScaleY.WithValue(y))
        
    [<Extension>]
    static member inline translate(this: WidgetBuilder<'msg, #ITransform>, x: float, y: float) =
        this.AddScalar(Transform.TranslationX.WithValue(x))
            .AddScalar(Transform.TranslationY.WithValue(y))