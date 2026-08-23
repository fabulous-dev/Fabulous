namespace Fabulous.Avalonia

open System.Runtime.CompilerServices
open Avalonia.Controls
open Fabulous
open Fabulous.Avalonia

module ComponentThemeVariantScope =
    let ActualThemeVariantChanged =
        Attributes.Component.defineEventNoArg "TopLevel_ThemeVariantChanged" (fun target -> (target :?> ThemeVariantScope).ActualThemeVariantChanged)

type ComponentThemeVariantScopeModifiers =

    /// <summary>Listens the ThemeVariantScope ThemeVariantChanged event.</summary>
    /// <param name="this">Current widget.</param>
    /// <param name="fn">Raised when the ThemeVariantChanged event is raised.</param>
    [<Extension>]
    static member inline onActualThemeVariantChanged(this: WidgetBuilder<'msg, #IFabThemeVariantScope>, fn: unit -> unit) =
        this.AddScalar(ComponentThemeVariantScope.ActualThemeVariantChanged.WithValue(fn))
