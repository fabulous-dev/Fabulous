namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module MvuGeometry =
    let Changed =
        Attributes.Mvu.defineEventNoArg "Geometry_Changed" (fun target -> (target :?> Geometry).Changed)

type MvuGeometryModifiers =
    /// <summary>Listens to the Geometry Changed event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="msg">Raised when the geometry changes.</param>
    [<Extension>]
    static member inline onChanged(this: WidgetBuilder<'msg, #IFabGeometry>, msg: 'msg) =
        this.AddScalar(MvuGeometry.Changed.WithValue(MsgValue msg))
