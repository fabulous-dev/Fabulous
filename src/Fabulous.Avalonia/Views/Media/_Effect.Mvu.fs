namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module MvuEffect =
    let Invalidated =
        Attributes.Mvu.defineEventNoArg "Effect_Invalidated" (fun target -> (target :?> Effect).Invalidated)

type MvuEffectModifiers =
    /// <summary>Listens the Effect Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Effect is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabEffect>, msg: 'smg) =
        this.AddScalar(MvuEffect.Invalidated.WithValue(MsgValue msg))
