namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui

module Padding =
    let Padding = Attributes.defineMauiScalarWithEquality<Thickness> "Padding"

[<Extension>]
type PaddingModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IPadding>, value: Thickness) =
        this.AddScalar(Padding.Padding.WithValue(value))