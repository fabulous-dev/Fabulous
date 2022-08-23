namespace Fabulous.Maui

module Text =
    let Text = Attributes.defineMauiScalar2<string> "Text"
    
    let TextChanged = Attributes.defineMauiEvent<string> "TextChanged"
    
    module Defaults =
        let [<Literal>] Text: string = null