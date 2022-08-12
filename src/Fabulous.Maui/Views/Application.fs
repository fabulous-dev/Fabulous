namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.Maui.Window
open Fabulous.StackAllocatedCollections
open Microsoft.Maui

module Application =
    let Windows = Attributes.defineMauiWidgetCollection "Windows"
    
    let ThemeChanged = Attributes.defineMauiEventNoArgs "ThemeChanged"
    
    type FabulousApplication() =
        inherit Element.FabulousElement(Microsoft.Maui.Handlers.ApplicationHandler())
        
        member this.Windows = this.GetWidgetCollection(Windows)
        
        interface IApplication with
            member this.CloseWindow(window) = this.Windows.Remove(window) |> ignore
            member this.CreateWindow(activationState) = this.Windows[0] :?> IWindow
            member this.OpenWindow(window) = this.Windows.Add(window)
            member this.ThemeChanged() = this.InvokeEvent(ThemeChanged)
            member this.Windows = List(Seq.map unbox<IWindow> this.Windows)
        
    let WidgetKey = Widgets.register<FabulousApplication>()
    
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