namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentEffect =
    let Invalidated =
        Attributes.Component.defineEventNoArg "Effect_Invalidated" (fun target -> (target :?> Effect).Invalidated)

type ComponentEffectModifiers =
    /// <summary>Listens the Effect Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the Effect is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabEffect>, msg: unit -> unit) =
        this.AddScalar(ComponentEffect.Invalidated.WithValue(msg))
