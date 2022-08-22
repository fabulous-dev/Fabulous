namespace Fabulous.Maui

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