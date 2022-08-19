namespace Fabulous.Maui

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Handlers
open Microsoft.Maui.Layouts

module ContentView =
    let Content = Attributes.defineMauiWidget "Content" (fun target -> (target :?> IContentView).Content)
    
    type FabulousContentView(handler: IViewHandler) =
        inherit View'.FabulousView(handler)

        new() = FabulousContentView(ContentViewHandler())
        
        interface IContentView with
            member this.CrossPlatformArrange(bounds) = this.ArrangeContent(bounds); bounds.Size
            member this.CrossPlatformMeasure(widthConstraint, heightConstraint) = this.MeasureContent(widthConstraint, heightConstraint)
            member this.Content = this.GetWidget(Content)
            member this.Padding = this.GetScalar(Padding.Padding, Thickness.Zero)
            member this.PresentedContent = this.GetWidget(Content)
            
    let WidgetKey = Widgets.register<FabulousContentView>()
    
[<AutoOpen>]
module ContentViewBuilders =
    type Fabulous.Maui.View with
        static member inline ContentView(content: WidgetBuilder<'msg, #IView>) =
            WidgetBuilder<'msg, IContentView>(
                ContentView.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [| ContentView.Content.WithValue(content.Compile()) |],
                    ValueNone
                )
            )