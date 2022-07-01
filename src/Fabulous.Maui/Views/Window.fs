namespace Fabulous.Maui

open Microsoft.Maui
open Microsoft.Maui.Handlers
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

type FabulousWindow() =
    inherit Node(WindowHandler())

    let mutable _content = Unchecked.defaultof<_>
    member this.Content
        with get () = _content
        and set value = _content <- value

    interface IWindow with
        member this.Activated() = ()
        member this.AddOverlay(overlay) = failwith "todo"
        member this.BackButtonClicked() = failwith "todo"
        member this.Backgrounding(state) = failwith "todo"
        member this.Created() = ()
        member this.Deactivated() = ()
        member this.Destroying() = failwith "todo"
        member this.DisplayDensityChanged(displayDensity) = failwith "todo"
        member this.RemoveOverlay(overlay) = failwith "todo"
        member this.RequestDisplayDensity() = failwith "todo"
        member this.Resumed() = ()
        member this.Stopped() = ()
        member this.Content = _content
        member this.FlowDirection = failwith "todo"
        member this.Overlays = failwith "todo"
        member this.Parent = this.Parent
        member this.Title = failwith "todo"
        member this.VisualDiagnosticsOverlay = null
        member this.Handler
            with get () = this.Handler
            and set value = this.Handler <- value

module Window =
    let WidgetKey = Widgets.register<FabulousWindow>()
    
    let Content =
        Attributes.definePropertyWidget
            "Window_Content"
            ViewNode.get
            (fun target value -> (target :?> FabulousWindow).Content <- value)
    
[<AutoOpen>]
module WindowBuilders =
    type Fabulous.Maui.View with
        static member inline Window<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetBuilder<'msg, IWindow>(
                Window.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| Window.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )