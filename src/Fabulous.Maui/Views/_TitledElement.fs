namespace Fabulous.Maui

module TitledElement =
    let Title = Attributes.defineMauiScalarWithEquality<string> "Title"

    module Defaults =
        let [<Literal>] Title: string = null
