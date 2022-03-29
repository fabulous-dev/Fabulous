namespace Fabulous.XamarinForms

open System.Runtime.CompilerServices
open Fabulous
open Xamarin.Forms

type IElement =
    interface
    end

module Element =
    let AutomationId =
        Attributes.defineBindable<string> Element.AutomationIdProperty

[<Extension>]
type ElementModifiers =
    /// Sets a value that allows the automation framework to find and interact with this element.
    [<Extension>]
    static member inline automationId(this: WidgetBuilder<'msg, #IElement>, value: string) =
        this.AddScalar(Element.AutomationId.WithValue(value))

    [<Extension>]
    static member inline onMounted(this: WidgetBuilder<'msg, #IElement>, value: 'msg) =
        this.AddScalar(Lifecycle.Mounted.WithValue(value))

    [<Extension>]
    static member inline onUnmounted(this: WidgetBuilder<'msg, #IElement>, value: 'msg) =
        this.AddScalar(Lifecycle.Unmounted.WithValue(value))
