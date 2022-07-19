namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type INavigableElement =
    inherit IElement

module NavigableElement =
    let Style =
        Attributes.defineBindableWithEquality<Xamarin.Forms.Style> NavigableElement.StyleProperty

    let StyleWidget =
        Attributes.defineBindableWidget NavigableElement.StyleProperty

[<Extension>]
type NavigableElementModifiers =

    [<Extension>]
    static member inline style(this: WidgetBuilder<'msg, #INavigableElement>, style: Style) =
        this.AddScalar(NavigableElement.Style.WithValue(style))
