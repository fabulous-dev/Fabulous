namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui.Controls

type IFabElement =
    interface
    end

module Element =
    let AutomationId =
        Attributes.defineBindableWithEquality<string> Element.AutomationIdProperty

[<Extension>]
type ElementModifiers =
    /// <summary>Sets a value that allows the automation framework to find and interact with this element</summary>
    /// <param name="this">Current widget</param>
    /// <param name="value">A value that the automation framework can use to find and interact with this element.</param>
    [<Extension>]
    static member inline automationId(this: WidgetBuilder<'msg, #IFabElement>, value: string) =
        this.AddScalar(Element.AutomationId.WithValue(value))

    /// <summary>Listen to the widget being mounted</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch on trigger</param>
    [<Extension>]
    static member inline onMounted(this: WidgetBuilder<'msg, #IFabElement>, msg: 'msg) =
        this.AddScalar(Lifecycle.Mounted.WithValue(msg))

    /// <summary>Listen to the widget being unmounted</summary>
    /// <param name="this">Current widget</param>
    /// <param name="msg">Message to dispatch on trigger</param>
    [<Extension>]
    static member inline onUnmounted(this: WidgetBuilder<'msg, #IFabElement>, msg: 'msg) =
        this.AddScalar(Lifecycle.Unmounted.WithValue(msg))
