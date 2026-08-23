namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module ComponentExperimentalAcrylicMaterial =
    let Invalidated =
        Attributes.Component.defineEventNoArg "ExperimentalAcrylicMaterial_Invalidated" (fun target -> (target :?> ExperimentalAcrylicMaterial).Invalidated)

type ComponentExperimentalAcrylicMaterialModifiers =
    /// <summary>Listens the ExperimentalAcrylicMaterial Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ExperimentalAcrylicMaterial is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, fn: unit -> unit) =
        this.AddScalar(ComponentExperimentalAcrylicMaterial.Invalidated.WithValue(fn))
