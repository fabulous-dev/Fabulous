namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

module NavigableElement =
    let Style =
        Attributes.defineBindable<Xamarin.Forms.Style> NavigableElement.StyleProperty