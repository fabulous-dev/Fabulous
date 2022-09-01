namespace Fabulous.Maui

open Microsoft.Maui.Controls.Shapes

type ITransform =
    inherit IElement

module Transform =

    let Value =
        Attributes.defineBindableWithEquality<Matrix> Transform.ValueProperty
