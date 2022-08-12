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
    
    type FabulousWindow(handler) =
        inherit Element.FabulousElement(handler)
        
        new() = FabulousWindow(WindowHandler())

        interface IWindow with
            member this.Activated() = this.InvokeEvent(Activated)
            member this.AddOverlay(overlay) = failwith "todo"
            member this.BackButtonClicked() = this.InvokeEvent(BackButtonClicked); true
            member this.Backgrounding(state) = failwith "todo"
            member this.Created() = this.InvokeEvent(Created)
            member this.Deactivated() = this.InvokeEvent(Deactivated)
            member this.Destroying() = this.InvokeEvent(Destroying)
            member this.DisplayDensityChanged(displayDensity) = failwith "todo"
            member this.RemoveOverlay(overlay) = failwith "todo"
            member this.RequestDisplayDensity() = failwith "todo"
            member this.Resumed() = this.InvokeEvent(Resumed)
            member this.Stopped() = this.InvokeEvent(Stopped)
            member this.Content = this.GetWidget(Content)
            member this.FlowDirection = this.GetScalar(FlowDirection, Microsoft.Maui.FlowDirection.MatchParent)
            member this.Overlays = failwith "todo"
            member this.Title = this.GetScalar(TitledElement.Title, "")
            member this.VisualDiagnosticsOverlay = this.GetScalar(VisualDiagnosticsOverlay, null)

    let WidgetKey = Widgets.register<FabulousWindow>()
    
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