namespace Fabulous.Maui

module Range =
    let Minimum = Attributes.defineMauiScalarWithEquality<float> "Minimum"
    let Maximum = Attributes.defineMauiScalarWithEquality<float> "Maximum"
    let Value = Attributes.defineMauiScalarWithEquality<float> "Value"
    let ValueChanged = Attributes.defineMauiEvent<float> "ValueChanged"
    
    module Defaults =
        let [<Literal>] Minimum = 0.
        let [<Literal>] Maximum = 1.
        let [<Literal>] Value = 0.

