namespace Fabulous.Maui.MediaElement

open Fabulous
open Microsoft.Maui.Controls

module Attributes =

    let inline defineProperty<'T when 'T: equality> name (defaultValue: 'T) ([<InlineIfLambda>] setter: obj -> 'T -> unit) =
        Attributes.defineSimpleScalarWithEquality<'T> name (fun _ newValueOpt node ->
            let target = node.Target :?> BindableObject

            match newValueOpt with
            | ValueNone -> setter target defaultValue
            | ValueSome v -> setter target v)
