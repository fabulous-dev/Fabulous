namespace Fabulous.Maui

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Handlers
open Microsoft.Maui.Layouts

module ContentView =
    let Content = Attributes.defineMauiWidget "Content" (fun target -> (target :?> IContentView).Content)
    
type FabContentView(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabContentView>()
    static member WidgetKey = _widgetKey

    new() = FabContentView(ContentViewHandler())
    
    interface IPadding with
        member this.Padding = this.GetScalar(Padding.Padding, Padding.Defaults.createDefaultPadding())
    
    interface IContentView with
        member this.CrossPlatformArrange(bounds) =
            this.ArrangeContent(bounds)
            bounds.Size
            
        member this.CrossPlatformMeasure(widthConstraint, heightConstraint) =
            this.MeasureContent(widthConstraint, heightConstraint)
            
        member this.Content = this.GetWidget(ContentView.Content)
        member this.PresentedContent = this.GetWidget(ContentView.Content)

[<AutoOpen>]
module ContentViewBuilders =
    type Fabulous.Maui.View with
        static member inline ContentView(content: WidgetBuilder<'msg, #IView>) =
            WidgetBuilder<'msg, IContentView>(
                FabContentView.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| ContentView.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )