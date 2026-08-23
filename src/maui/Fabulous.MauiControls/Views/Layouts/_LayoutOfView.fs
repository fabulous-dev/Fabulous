namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections

type IFabLayoutOfView =
    inherit IFabLayout

module LayoutOfView =
    let Children =
        Attributes.defineListWidgetCollection "LayoutOfWidget_Children" (fun target -> (target :?> Microsoft.Maui.Controls.Layout).Children)

[<Extension>]
type LayoutOfViewYieldExtensions =
    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabLayoutOfView, IFabView>, x: WidgetBuilder<'msg, #IFabView>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }

    [<Extension>]
    static member inline Yield(_: CollectionBuilder<'msg, #IFabLayoutOfView, IFabView>, x: WidgetBuilder<'msg, Memo.Memoized<#IFabView>>) : Content<'msg> =
        { Widgets = MutStackArray1.One(x.Compile()) }
