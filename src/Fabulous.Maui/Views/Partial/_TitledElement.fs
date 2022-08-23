namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Fabulous

module TitledElement =
    let Title = Attributes.defineMauiScalarWithEquality<string> "Title"

    module Defaults =
        let [<Literal>] Title: string = null
        
[<Extension>]
type TitledElementModifiers =
    [<Extension>]
    static member inline title(this: WidgetBuilder<'msg, #ITitledElement>, value: string) =
        this.AddScalar(TitledElement.Title.WithValue(value))
