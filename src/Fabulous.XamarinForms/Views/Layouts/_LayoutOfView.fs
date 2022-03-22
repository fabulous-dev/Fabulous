namespace Fabulous.XamarinForms

open Fabulous
open Xamarin.Forms

type ILayoutOfView =
    inherit Fabulous.XamarinForms.ILayout

module LayoutOfView =
    let Children =
        Attributes.defineWidgetCollection
            "LayoutOfWidget_Children"
            ViewNode.get
            (fun target -> (target :?> Xamarin.Forms.Layout<View>).Children)
