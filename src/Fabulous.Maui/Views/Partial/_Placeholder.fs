namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics

module Placeholder =
    let Placeholder = Attributes.defineMauiScalarWithEquality<string> "Placeholder"
    let PlaceholderColor = Attributes.defineMauiScalarWithEquality<Color> "PlaceholderColor"

    module Defaults =
        let [<Literal>] Placeholder: string = null
        let [<Literal>] PlaceholderColor: Color = null

[<Extension>]
type PlaceholderModifiers =
    [<Extension>]
    static member inline placeholder(this: WidgetBuilder<'msg, #IPlaceholder>, value: string) =
        this.AddScalar(Placeholder.Placeholder.WithValue(value))