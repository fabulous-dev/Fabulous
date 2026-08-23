namespace Fabulous.Avalonia

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

module ComponentPopupFlyoutBase =
    let Opening =
        Attributes.Component.defineEventNoArg "PopupFlyoutBase_Opening" (fun target -> (target :?> PopupFlyoutBase).Opening)

    let Closing =
        Attributes.Component.defineEvent "PopupFlyoutBase_Closing" (fun target -> (target :?> PopupFlyoutBase).Closing)

type ComponentPopupFlyoutBaseModifiers =
    /// <summary>Listens to the PopupFlyoutBase Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PopupFlyoutBase is opening.</param>
    [<Extension>]
    static member inline onOpening<'msg when 'msg: equality>(this: WidgetBuilder<'msg, IFabPopupFlyoutBase>, fn: unit -> unit) =
        this.AddScalar(ComponentPopupFlyoutBase.Opening.WithValue(fn))

    /// <summary>Listens to the PopupFlyoutBase Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PopupFlyoutBase is closing.</param>
    [<Extension>]
    static member inline onClosing<'msg when 'msg: equality>(this: WidgetBuilder<'msg, IFabPopupFlyoutBase>, fn: CancelEventArgs -> unit) =
        this.AddScalar(ComponentPopupFlyoutBase.Closing.WithValue(fn))
