namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous.StackAllocatedCollections
open Microsoft.Maui.Controls

open Fabulous

type IFabGradientBrush =
    inherit IFabBrush

module GradientBrush =
    let Children =
        Attributes.defineListWidgetCollection "GradientBrush_GradientStops" (fun target -> (target :?> GradientBrush).GradientStops :> IList<_>)

[<Extension>]
type GradientBrushYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabGradientBrush, IFabGradientStop>, x: WidgetBuilder<'msg, #IFabGradientStop>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield
        (
            _: CollectionBuilder<'msg, #IFabGradientBrush, IFabGradientStop>,
            x: WidgetBuilder<'msg, Memo.Memoized<#IFabGradientStop>>
        ) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
