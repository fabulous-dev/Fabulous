namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

module LayoutOfView =
    let Children =
        Attributes.defineWidgetCollection
            "LayoutOfWidget_Children"
            (fun target -> (target :?> Xamarin.Forms.Layout<View>).Children)
