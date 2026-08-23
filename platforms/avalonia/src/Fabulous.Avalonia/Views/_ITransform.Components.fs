namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentTransform =

    let Changed =
        Attributes.Component.defineEventNoArg "Transform_Changed" (fun target -> (target :?> Transform).Changed)

type ComponentTransformModifiers =
    /// <summary>Listens to the Transform changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the Transform changes.</param>
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<'msg, #IFabTransform>, fn: unit -> unit) =
        this.AddScalar(ComponentTransform.Changed.WithValue(fn))
