namespace Fabulous.Maui

open Microsoft.Maui
open Microsoft.Maui.Handlers
open Fabulous
open Fabulous.StackAllocatedCollections.StackList

module Window =
    let Content = Attributes.defineMauiWidget "Content" (fun target -> (target :?> IWindow).Content)
    let FlowDirection = Attributes.defineMauiScalarWithEquality<FlowDirection> "FlowDirection"
    let VisualDiagnosticsOverlay = Attributes.defineMauiScalarWithEquality<IVisualDiagnosticsOverlay> "VisualDiagnosticsOverlay"

    let Activated = Attributes.defineMauiEventNoArgs "Activated"
    let BackButtonClicked = Attributes.defineMauiEventNoArgs "BackButtonClicked"
    let Created = Attributes.defineMauiEventNoArgs "Created"
    let Deactivated = Attributes.defineMauiEventNoArgs "Deactivated"
    let Destroyed = Attributes.defineMauiEventNoArgs "Destroyed"
    let Destroying = Attributes.defineMauiEventNoArgs "Destroying"
    let Resumed = Attributes.defineMauiEventNoArgs "Resumed"
    let Stopped = Attributes.defineMauiEventNoArgs "Stopped"
    
    module Defaults =
        let [<Literal>] FlowDirection = Microsoft.Maui.FlowDirection.MatchParent
        let [<Literal>] VisualDiagnosticsOverlay: VisualDiagnosticsOverlay = null
    
type FabWindow(handler) =
    inherit FabElement(handler)
    
    static let _widgetKey = Widgets.register<FabWindow>()
    static member WidgetKey = _widgetKey
    
    new() = FabWindow(WindowHandler())
    
    interface ITitledElement with
        member this.Title = this.GetScalar(TitledElement.Title, TitledElement.Defaults.Title)

    interface IWindow with
        member this.Activated() = this.InvokeEvent(Window.Activated)
        member this.AddOverlay(overlay) = failwith "todo"
        member this.BackButtonClicked() = this.InvokeEvent(Window.BackButtonClicked); true
        member this.Backgrounding(state) = failwith "todo"
        member this.Created() = this.InvokeEvent(Window.Created)
        member this.Deactivated() = this.InvokeEvent(Window.Deactivated)
        member this.Destroying() = this.InvokeEvent(Window.Destroying)
        member this.DisplayDensityChanged(displayDensity) = () // TODO: Figure out what to do with this
        member this.RemoveOverlay(overlay) = failwith "todo"
        member this.RequestDisplayDensity() = failwith "todo"
        member this.Resumed() = this.InvokeEvent(Window.Resumed)
        member this.Stopped() = this.InvokeEvent(Window.Stopped)
        member this.Content = this.GetWidget(Window.Content)
        member this.FlowDirection = this.GetScalar(Window.FlowDirection, Window.Defaults.FlowDirection)
        member this.Overlays = failwith "todo"
        member this.VisualDiagnosticsOverlay = this.GetScalar(Window.VisualDiagnosticsOverlay, Window.Defaults.VisualDiagnosticsOverlay)
    
[<AutoOpen>]
module WindowBuilders =
    type Fabulous.Maui.View with
        static member inline Window<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetBuilder<'msg, IWindow>(
                FabWindow.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| Window.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )