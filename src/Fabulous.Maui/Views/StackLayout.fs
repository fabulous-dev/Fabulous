namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers
open Fabulous

module StackLayout =
    type FabulousStackLayout(handler) =
        inherit Layout.FabulousLayout(handler)

        new() = FabulousStackLayout(LayoutHandler())

        interface IStackLayout with
            member this.CopyTo(array, arrayIndex) = failwith "todo"
            member this.Focus() = failwith "todo"
            member this.Clip = null
            member this.ClipsToBounds = false
            member this.IgnoreSafeArea = false
            member this.IsReadOnly = failwith "todo"
            member this.Spacing = 0.

    let VerticalWidgetKey = Widgets.register<FabulousStackLayout>()
    let HorizontalWidgetKey = Widgets.register<FabulousStackLayout>()
            
    
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