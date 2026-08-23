namespace Fabulous.Avalonia

open Avalonia.Animation

type IFabAnimatable =
    inherit IFabElement

module Animatable =
    let Transitions =
        Attributes.defineAvaloniaListWidgetCollection "Animatable_Transitions" (fun target ->
            let target = (target :?> Animatable)

            if target.Transitions = null then
                let newColl = Transitions()
                target.Transitions <- newColl
                newColl
            else
                target.Transitions)
