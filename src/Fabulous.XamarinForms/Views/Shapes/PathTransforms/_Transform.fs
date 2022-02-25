namespace Fabulous.XamarinForms

open Fabulous.XamarinForms
open Xamarin.Forms.Shapes

type ITransform =
    inherit IElement

module Transform =

    let Value =
        Attributes.defineBindable<Matrix> Transform.ValueProperty
