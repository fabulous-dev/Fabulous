namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.Handlers
open Fabulous
open Microsoft.Maui.Layouts

module StackLayout =
    /// TODO: Need to InvalidateMeasure when changing Spacing
    let Spacing = Attributes.defineMauiScalarWithEquality<float> "Spacing"
    
    type FabulousStackLayout(handler, layoutManagerFn: ILayout -> ILayoutManager) =
        inherit Layout.FabulousLayout(handler, layoutManagerFn)

        interface IStackLayout with
            member this.Spacing = this.GetScalar(Spacing, 0.)
            
    type FabulousVerticalStackLayout() =
        inherit FabulousStackLayout(LayoutHandler(), fun layout -> VerticalStackLayoutManager(layout :?> IStackLayout))
        
    type FabulousHorizontalStackLayout() =
        inherit FabulousStackLayout(LayoutHandler(), fun layout -> HorizontalStackLayoutManager(layout :?> IStackLayout))

    let VerticalWidgetKey = Widgets.register<FabulousVerticalStackLayout>()
    let HorizontalWidgetKey = Widgets.register<FabulousHorizontalStackLayout>() 
    
[<AutoOpen>]
module StackLayoutBuilders =
    type Fabulous.Maui.View with
        static member inline VStack<'msg>() =
            CollectionBuilder<'msg, IStackLayout, IView>(
                StackLayout.VerticalWidgetKey,
                Layout.Children
            )
            
        static member inline HStack<'msg>() =
            CollectionBuilder<'msg, IStackLayout, IView>(
                StackLayout.HorizontalWidgetKey,
                Layout.Children
            )
            
[<Extension>]
type StackLayoutCollectionExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IView>
        (
            _: CollectionBuilder<'msg, IStackLayout, IView>,
            x: WidgetBuilder<'msg, 'itemType>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>
        
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IView>
        (
            _: CollectionBuilder<'msg, IStackLayout, IView>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>