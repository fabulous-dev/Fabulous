namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

module MvuWindowBase =
    let Activated =
        Attributes.Mvu.defineEventNoArg "WindowBase_Activated" (fun target -> (target :?> WindowBase).Activated)

    let Deactivated =
        Attributes.Mvu.defineEventNoArg "WindowBase_Deactivated" (fun target -> (target :?> WindowBase).Deactivated)

    let PositionChanged =
        Attributes.Mvu.defineEvent "WindowBase_PositionChanged" (fun target -> (target :?> WindowBase).PositionChanged)

    let Resized =
        Attributes.Mvu.defineEvent "WindowBase_Resized" (fun target -> (target :?> WindowBase).Resized)

type MvuWindowBaseModifiers =
    /// <summary>Listens to the WindowBase Activated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is activated.</param>
    [<Extension>]
    static member inline onActivated(this: WidgetBuilder<'msg, #IFabWindowBase>, fn: 'msg) =
        this.AddScalar(MvuWindowBase.Activated.WithValue(MsgValue fn))

    /// <summary>Listens to the WindowBase Deactivated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is deactivated.</param>
    [<Extension>]
    static member inline onDeactivated(this: WidgetBuilder<'msg, #IFabWindowBase>, fn: 'msg) =
        this.AddScalar(MvuWindowBase.Deactivated.WithValue(MsgValue fn))

    /// <summary>Listens to the WindowBase PositionChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window position is changed.</param>
    [<Extension>]
    static member inline onPositionChanged(this: WidgetBuilder<'msg, #IFabWindowBase>, fn: PixelPointEventArgs -> 'msg) =
        this.AddScalar(MvuWindowBase.PositionChanged.WithValue(fn))

    /// <summary>Listens to the WindowBase Resized event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the window is resized.</param>
    [<Extension>]
    static member inline onResized(this: WidgetBuilder<'msg, #IFabWindowBase>, fn: WindowResizedEventArgs -> 'msg) =
        this.AddScalar(MvuWindowBase.Resized.WithValue(fn))
