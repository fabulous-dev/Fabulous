namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Fabulous
open Avalonia.Controls
open Fabulous.Avalonia

module ComponentTrayIcon =
    let Clicked =
        Attributes.Component.defineEventNoArg "TrayIcon_Clicked" (fun target -> (target :?> TrayIcon).Clicked)

type ComponentTrayIconModifiers =
    /// <summary>Listens to the TrayIcon Clicked event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Clicked event fires.</param>
    [<Extension>]
    static member inline onClicked(this: WidgetBuilder<'msg, #IFabTrayIcon>, msg: unit -> unit) =
        this.AddScalar(ComponentTrayIcon.Clicked.WithValue(msg))
