namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.Handlers
open Fabulous
open Microsoft.Maui.Layouts

module StackLayout =
    /// TODO: Need to InvalidateMeasure when changing Spacing
    let Spacing = Attributes.defineMauiScalar2<float> "Spacing"
    
type FabStackLayout(handler, layoutManagerFn: ILayout -> ILayoutManager) =
    inherit FabLayout(handler, layoutManagerFn)

    interface IStackLayout with
        member this.Spacing = this.GetScalar(StackLayout.Spacing, 0.)
        
type FabVerticalStackLayout(handler: IViewHandler) =
    inherit FabStackLayout(handler, fun layout -> VerticalStackLayoutManager(layout :?> IStackLayout))
    
    static let _widgetKey = Widgets.register<FabVerticalStackLayout>()
    static member WidgetKey = _widgetKey
    
    new() = FabVerticalStackLayout(LayoutHandler())
    
type FabHorizontalStackLayout(handler: IViewHandler) =
    inherit FabStackLayout(handler, fun layout -> HorizontalStackLayoutManager(layout :?> IStackLayout))
    
    static let _widgetKey = Widgets.register<FabHorizontalStackLayout>()
    static member WidgetKey = _widgetKey
    
    new() = FabHorizontalStackLayout(LayoutHandler())
    
[<AutoOpen>]
module StackLayoutBuilders =
    type Fabulous.Maui.View with
        static member inline VStack<'msg>(?spacing: float) =
            match spacing with
            | Some spacing ->
                CollectionBuilder<'msg, IStackLayout, IView>(
                    FabVerticalStackLayout.WidgetKey,
                    Layout.Children,
                    StackLayout.Spacing.WithValue(spacing)
                )
            | None ->
                CollectionBuilder<'msg, IStackLayout, IView>(
                    FabVerticalStackLayout.WidgetKey,
                    Layout.Children
                )
            
        static member inline HStack<'msg>(?spacing: float) =
            match spacing with
            | Some spacing ->
                CollectionBuilder<'msg, IStackLayout, IView>(
                    FabHorizontalStackLayout.WidgetKey,
                    Layout.Children,
                    StackLayout.Spacing.WithValue(spacing)
                )
            | None ->
                CollectionBuilder<'msg, IStackLayout, IView>(
                    FabHorizontalStackLayout.WidgetKey,
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