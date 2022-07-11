namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type ILayoutOfView =
    inherit Fabulous.XamarinForms.ILayout

module LayoutOfView =
    let Children =
        Attributes.defineListWidgetCollection
            "LayoutOfWidget_Children"
            (fun target -> (target :?> Xamarin.Forms.Layout<View>).Children)
