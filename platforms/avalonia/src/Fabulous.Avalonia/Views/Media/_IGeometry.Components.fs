namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentGeometry =
    let Changed =
        Attributes.Component.defineEventNoArg "Geometry_Changed" (fun target -> (target :?> Geometry).Changed)

type ComponentGeometryModifiers =
    /// <summary>Listens to the Geometry Changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the geometry changes.</param>
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<'msg, #IFabGeometry>, msg: unit -> unit) =
        this.AddScalar(ComponentGeometry.Changed.WithValue(msg))
