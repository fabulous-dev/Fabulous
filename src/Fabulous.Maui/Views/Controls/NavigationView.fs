namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.Handlers

module NavigationView =
    let NavigationStack = Attributes.defineMauiWidgetCollectionNavigation "NavigationStack" 
    
type FabNavigationView(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabNavigationView>()
    static member WidgetKey = _widgetKey
    
    new() = FabNavigationView(NavigationViewHandler())
    
    interface IStackNavigation with
        member this.NavigationFinished(newStack) = ()
        member this.RequestNavigation(eventArgs) = this.Handler.Invoke("RequestNavigation", eventArgs)
        
    interface IStackNavigationView
    
[<AutoOpen>]
module NavigationViewBuilders =
    type Fabulous.Maui.View with
        static member inline NavigationView() =
            CollectionBuilder<'msg, IStackNavigationView, IView>(
                FabNavigationView.WidgetKey,
                NavigationView.NavigationStack
            )
            
[<Extension>]
type NavigationViewCollectionExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IView>
        (
            _: CollectionBuilder<'msg, IStackNavigationView, IView>,
            x: WidgetBuilder<'msg, 'itemType>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>
        
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IView>
        (
            _: CollectionBuilder<'msg, IStackNavigationView, IView>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>