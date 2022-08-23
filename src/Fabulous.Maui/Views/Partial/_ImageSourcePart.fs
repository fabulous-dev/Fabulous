namespace Fabulous.Maui

open Microsoft.Maui

module ImageSourcePart =
    let Source = Attributes.defineMauiScalarWithEquality<IImageSource> "Source"

    module Defaults =
        let [<Literal>] Source: IImageSource = null
