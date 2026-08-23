namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls.Primitives
open Fabulous
open Fabulous.Avalonia

module MvuFlyoutBase =
    let Opened =
        Attributes.Mvu.defineEventNoArg "FlyoutBase_Opened" (fun target -> (target :?> FlyoutBase).Opened)

    let Closed =
        Attributes.Mvu.defineEventNoArg "FlyoutBase_Closed" (fun target -> (target :?> FlyoutBase).Closed)

type MvuFlyoutBaseModifiers =
    /// <summary>Listens to the FlyoutBase Opened event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the FlyoutBase is opened.</param>
    [<Extension>]
    static member inline onOpened(this: WidgetBuilder<'msg, #IFabFlyoutBase>, msg: 'msg) =
        this.AddScalar(MvuFlyoutBase.Opened.WithValue(MsgValue msg))

    /// <summary>Listens to the FlyoutBase Closed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the FlyoutBase is closed.</param>
    [<Extension>]
    static member inline onClosed(this: WidgetBuilder<'msg, #IFabFlyoutBase>, msg: 'msg) =
        this.AddScalar(MvuFlyoutBase.Closed.WithValue(MsgValue msg))
