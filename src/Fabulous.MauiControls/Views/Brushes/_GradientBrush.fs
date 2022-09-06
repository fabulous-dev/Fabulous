namespace Fabulous.Maui

open System.Collections.Generic
open Microsoft.Maui.Controls

open Fabulous

type IGradientBrush =
    inherit IBrush


module GradientBrush =

    let Children =
        Attributes.defineListWidgetCollection
            "GradientBrush_GradientStops"
            (fun target -> (target :?> GradientBrush).GradientStops :> IList<_>)
