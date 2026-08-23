namespace Fabulous.Avalonia

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module MvuContextMenu =
    let Opening =
        Attributes.Mvu.defineEventHandler "ContextMenu_Opening" (fun target -> (target :?> ContextMenu).Opening)

    let Closing =
        Attributes.Mvu.defineEventHandler "ContextMenu_Closing" (fun target -> (target :?> ContextMenu).Closing)

type MvuContextMenuModifiers =
    /// <summary>Listens to the ContextMenu Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Opening event fires.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabContextMenu>, fn: CancelEventArgs -> 'msg) =
        this.AddScalar(MvuContextMenu.Opening.WithValue(fn))

    /// <summary>Listens to the ContextMenu Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Closing event fires.</param>
    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<'msg, #IFabContextMenu>, fn: CancelEventArgs -> 'msg) =
        this.AddScalar(MvuContextMenu.Closing.WithValue(fn))
