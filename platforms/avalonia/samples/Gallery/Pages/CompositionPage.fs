namespace Gallery

open Fabulous.Avalonia
open Controls

open Fabulous

open type Fabulous.Avalonia.View
open Fabulous.StackAllocatedCollections.StackList

type IFabMvuCompositionPage =
    inherit IFabControl

module CompositionPageControl =
    let WidgetKey = Widgets.register<CompositionPage>()

[<AutoOpen>]
module CompositionPageControlBuilders =

    type Fabulous.Avalonia.View with

        static member CompositionPageControl() =
            WidgetBuilder<'msg, IFabMvuCompositionPage>(CompositionPageControl.WidgetKey)

module CompositionPage =
    let view () = View.CompositionPageControl()
