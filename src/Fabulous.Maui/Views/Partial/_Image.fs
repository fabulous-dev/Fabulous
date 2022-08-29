namespace Fabulous.Maui

open Fabulous
open Microsoft.Maui

module ImagePart =
    let Aspect = Attributes.defineMauiScalarWithEquality<Aspect> "Aspect"
    let IsOpaque = Attributes.defineMauiScalarWithEquality<bool> "IsOpaque"

    module Defaults =
        let [<Literal>] Aspect = Microsoft.Maui.Aspect.AspectFit
        let [<Literal>] IsOpaque = false