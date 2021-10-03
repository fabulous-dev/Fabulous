namespace Fabulous.Reconciler

open Fabulous
open Fabulous.Controls

module Diff =
    let attributedDiff (previous: IControlWidget) (current: IControlWidget) =
        if previous.TargetType <> current.TargetType then
            WidgetDiff.ReplacedBy (current :> IWidget)
        else
            WidgetDiff.ReplacedBy (current :> IWidget)

    let diff (previousOpt: IWidget voption) (current: IWidget) =
        match previousOpt with
        | ValueNone -> WidgetDiff.ReplacedBy current
        | ValueSome previous ->
            match struct (previous, current) with
            | (:? IControlWidget as previousControl), (:? IControlWidget as currentControl) -> attributedDiff previousControl currentControl
            | _ -> failwith "Not implemented"