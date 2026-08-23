namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Fabulous

type IFabElement = interface end

[<AbstractClass; Sealed>]
type View = class end

type ElementModifiers =
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
