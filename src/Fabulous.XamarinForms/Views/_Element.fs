namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IElement = interface end

module Element =
    let AutomationId =
        Attributes.defineBindable<string> Element.AutomationIdProperty
    
[<Extension>]
type ElementModifiers =
    [<Extension>]
    static member inline automationId(this: WidgetBuilder<'msg, #IElement>, value: string) =
        this.AddScalar(Element.AutomationId.WithValue(value))