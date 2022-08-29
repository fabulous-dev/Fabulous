namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.ApplicationModel
open Microsoft.Maui.Handlers

module Application =
    let Windows = Attributes.defineMauiWidgetCollection "Windows"
    
    let ThemeChanged = Attributes.defineMauiEvent<AppTheme> "ThemeChanged"
    
type FabApplication(handler: IElementHandler) =
    inherit FabElement(handler)
    
    static let _widgetKey = Widgets.register<FabApplication>()
    static member WidgetKey = _widgetKey
    
    new() = FabApplication(ApplicationHandler())
    
    member this.Windows = this.GetWidgetCollection(Application.Windows)
    
    interface IApplication with
        member this.CloseWindow(window) = this.Windows.Remove(window) |> ignore
        member this.CreateWindow(activationState) = this.Windows[0] :?> IWindow
        member this.OpenWindow(window) = this.Windows.Add(window)
        member this.ThemeChanged() = this.InvokeEvent(Application.ThemeChanged, AppInfo.RequestedTheme)
        member this.Windows = List(Seq.map unbox<IWindow> this.Windows)
    
[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.Maui.View with
        static member inline Application<'msg>() =
            CollectionBuilder<'msg, IApplication, IWindow>(
                FabApplication.WidgetKey,
                Application.Windows
            )
            
[<Extension>]
type ApplicationModifiers =
    [<Extension>]
    static member themeChanged(this: WidgetBuilder<'msg, #IApplication>, fn: AppTheme -> 'msg) =
        this.AddScalar(Application.ThemeChanged.WithValue(fun t -> fn t |> box))

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