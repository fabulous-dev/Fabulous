namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

module ComponentPopup =
    let Closed =
        Attributes.Component.defineEvent "Popup_Closed" (fun target -> (target :?> Popup).Closed)

    let Opened =
        Attributes.Component.defineEventNoArg "Popup_Opened" (fun target -> (target :?> Popup).Opened)

type ComponentPopupModifiers =
    /// <summary>Listens to the Popup Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Popup is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabPopup>, msg: unit -> unit) =
        this.AddScalar(ComponentPopup.Closed.WithValue(fun _ -> msg()))

    /// <summary>Listens to the Popup Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Popup is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabPopup>, msg: unit -> unit) =
        this.AddScalar(ComponentPopup.Opened.WithValue(msg))
