namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui.Controls

type ILayoutOfView =
    inherit Fabulous.Maui.ILayout

module LayoutOfView =
    let Children =
        Attributes.defineListWidgetCollection
            "LayoutOfWidget_Children"
            (fun target -> (target :?> Microsoft.Maui.Controls.Layout).Children)
