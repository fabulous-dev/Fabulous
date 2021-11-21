namespace Fabulous.XamarinForms

open System
open Fabulous

module ViewNode =
    let ViewNodeProperty = Xamarin.Forms.BindableProperty.Create("ViewNode", typeof<ViewNode>, typeof<Xamarin.Forms.View>, null)

    let getViewNode (target: obj) =
        (target :?> Xamarin.Forms.BindableObject).GetValue(ViewNodeProperty) :?> IViewNode