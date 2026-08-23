namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous

type IFabWindowBase =
    inherit IFabTopLevel

module WindowBase =

    let Topmost =
        Attributes.defineAvaloniaPropertyWithEquality WindowBase.TopmostProperty

type WindowBaseModifiers =
    /// <summary>Sets the Topmost property.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="value">The Topmost value.</param>
    [<Extension>]
    static member inline topmost(this: WidgetBuilder<'msg, #IFabWindowBase>, value: bool) =
        this.AddScalar(WindowBase.Topmost.WithValue(value))
