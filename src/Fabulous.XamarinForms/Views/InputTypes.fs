namespace Fabulous.XamarinForms

open Fabulous.XamarinForms

[<AutoOpen>]
module InputTypes =

    module DoubleConverter =
        type Value =
            | String of string
            | DoubleList of float list

        let fromString str = String str
        let fromList doubles = DoubleList doubles
