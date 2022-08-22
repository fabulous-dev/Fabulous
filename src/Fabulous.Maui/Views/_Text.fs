namespace Fabulous.Maui

module Text =
    let Text = Attributes.defineMauiScalar2<string> "Text"
    
    module Defaults =
        let [<Literal>] Text: string = null