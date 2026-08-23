namespace Fabulous.Avalonia

open System.ComponentModel
open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous

module MvuPopupFlyoutBase =
    let Opening =
        Attributes.Mvu.defineEventNoArg "PopupFlyoutBase_Opening" (fun target -> (target :?> PopupFlyoutBase).Opening)

    let Closing =
        Attributes.Mvu.defineEvent "PopupFlyoutBase_Closing" (fun target -> (target :?> PopupFlyoutBase).Closing)

type MvuPopupFlyoutBaseModifiers =
    /// <summary>Listens to the PopupFlyoutBase Opening event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PopupFlyoutBase is opening.</param>
    [<Extension>]
    static member inline onOpening(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, fn: 'msg) =
        this.AddScalar(MvuPopupFlyoutBase.Opening.WithValue(MsgValue fn))

    /// <summary>Listens to the PopupFlyoutBase Closing event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the PopupFlyoutBase is closing.</param>
    [<Extension>]
    static member inline onClosing(this: WidgetBuilder<'msg, #IFabPopupFlyoutBase>, fn: CancelEventArgs -> 'msg) =
        this.AddScalar(MvuPopupFlyoutBase.Closing.WithValue(fn))
