namespace Fabulous.XamarinForms

open Xamarin.Forms.Shapes

type ITransform =
    inherit IElement

module Transform =

    let Value =
        Attributes.defineBindableWithEquality<Matrix> Transform.ValueProperty
