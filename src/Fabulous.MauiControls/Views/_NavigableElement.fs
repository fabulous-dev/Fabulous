namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type INavigableElement =
    inherit Fabulous.Maui.IElement

module NavigableElement =
    let Style =
        Attributes.defineBindableWithEquality<Style> NavigableElement.StyleProperty

[<Extension>]
type NavigableElementModifiers =

    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #INavigableElement>, style: Style) =
        this.AddScalar(NavigableElement.Style.WithValue(style))
