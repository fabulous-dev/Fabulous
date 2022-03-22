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
    static member inline willMount(this: WidgetBuilder<'msg, #IElement>, value: 'msg) =
        this.AddScalar(Lifecycle.WillMountAttribute.WithValue(value))

    [<Extension>]
    static member inline didMount(this: WidgetBuilder<'msg, #IElement>, value: 'msg) =
        this.AddScalar(Lifecycle.DidMountAttribute.WithValue(value))

    [<Extension>]
    static member inline willUnmount(this: WidgetBuilder<'msg, #IElement>, value: 'msg) =
        this.AddScalar(Lifecycle.WillUnmountAttribute.WithValue(value))

    [<Extension>]
    static member inline didUnmount(this: WidgetBuilder<'msg, #IElement>, value: 'msg) =
        this.AddScalar(Lifecycle.DidUnmountAttribute.WithValue(value))