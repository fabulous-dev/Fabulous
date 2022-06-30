namespace Fabulous.Maui

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui

type FabulousApplication() =
    inherit Node()
    
    interface Microsoft.Maui.IApplication with
        member this.CloseWindow(window) = failwith "todo"
        member this.CreateWindow(activationState) = failwith "todo"
        member this.OpenWindow(window) = failwith "todo"
        member this.ThemeChanged() = failwith "todo"
        member this.Handler = failwith "todo"
        member this.Parent = failwith "todo"
        member this.Windows = failwith "todo"
        member this.Handler with set value = failwith "todo"
        
module Application =
    let WidgetKey = Widgets.register<FabulousApplication>()
    
[<AutoOpen>]
module ApplicationBuilders =
    type Fabulous.Maui.View with
        static member inline Application<'msg>() =
            WidgetBuilder<'msg, IApplication>(
                Application.WidgetKey,
                AttributesBundle(StackList.empty(), ValueNone, ValueNone)
            )
