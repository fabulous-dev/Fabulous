namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Media
open Fabulous
open Fabulous.Avalonia

module MvuExperimentalAcrylicMaterial =
    let Invalidated =
        Attributes.Mvu.defineEventNoArg "ExperimentalAcrylicMaterial_Invalidated" (fun target -> (target :?> ExperimentalAcrylicMaterial).Invalidated)

type MvuExperimentalAcrylicMaterialModifiers =
    /// <summary>Listens the ExperimentalAcrylicMaterial Invalidated event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ExperimentalAcrylicMaterial is invalidated.</param>
    [<Extension>]
    static member inline onInvalidated(this: WidgetBuilder<'msg, #IFabExperimentalAcrylicMaterial>, fn: 'msg) =
        this.AddScalar(MvuExperimentalAcrylicMaterial.Invalidated.WithValue(MsgValue fn))
