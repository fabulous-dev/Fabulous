namespace Fabulous.Avalonia.Components

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentContextMenu =
    let Opening =
        Attributes.Component.defineEventHandler "ContextMenu_Opening" (fun target -> (target :?> ContextMenu).Opening)

    let Closing =
        Attributes.Component.defineEventHandler "ContextMenu_Closing" (fun target -> (target :?> ContextMenu).Closing)

type ComponentContextMenuModifiers =
    /// <summary>Listens to the ContextMenu Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Opening event fires.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabContextMenu>, fn: CancelEventArgs -> unit) =
        this.AddScalar(ComponentContextMenu.Opening.WithValue(fn))

    /// <summary>Listens to the ContextMenu Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Closing event fires.</param>
    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<'msg, #IFabContextMenu>, fn: CancelEventArgs -> unit) =
        this.AddScalar(ComponentContextMenu.Closing.WithValue(fn))
