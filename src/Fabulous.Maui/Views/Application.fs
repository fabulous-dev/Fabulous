namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui

type FabulousApplication() =
    inherit Node(Microsoft.Maui.Handlers.ApplicationHandler())
    
    let _windows = List<IWindow>()
    member this.Windows = _windows
    
    interface IApplication with
        member this.CloseWindow(window) = failwith "todo"
        member this.CreateWindow(activationState) = _windows[0]
        member this.OpenWindow(window) = failwith "todo"
        member this.ThemeChanged() = failwith "todo"
        member this.Handler
            with get () = this.Handler
            and set value = this.Handler <- value
        member this.Parent = this.Parent
        member this.Windows = _windows :> IReadOnlyList<_>
        
module Application =
    let WidgetKey = Widgets.register<FabulousApplication>()
    
    let Windows =
        Attributes.defineListWidgetCollection
            "Application_Windows"
            ViewNode.get
            (fun target -> (target :?> FabulousApplication).Windows)
    
[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.Maui.View with
        static member inline Application<'msg>() =
            CollectionBuilder<'msg, IApplication, IWindow>(
                Application.WidgetKey,
                Application.Windows
            )

[<Extension>]
type ApplicationCollectionExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IWindow>
        (
            _: CollectionBuilder<'msg, IApplication, IWindow>,
            x: WidgetBuilder<'msg, 'itemType>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>
        
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IWindow>
        (
            _: CollectionBuilder<'msg, IApplication, IWindow>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>