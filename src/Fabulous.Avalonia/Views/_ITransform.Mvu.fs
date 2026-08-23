namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous

module MvuTransform =

    let Changed =
        Attributes.Mvu.defineEventNoArg "Transform_Changed" (fun target -> (target :?> Transform).Changed)

type MvuTransformModifiers =
    /// <summary>Listens to the Transform changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Transform changes.</param>
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<'msg, #IFabTransform>, fn: 'msg) =
        this.AddScalar(MvuTransform.Changed.WithValue(MsgValue fn))
