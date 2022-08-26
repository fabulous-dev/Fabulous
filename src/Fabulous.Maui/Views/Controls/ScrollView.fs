namespace Fabulous.Maui

open Fabulous
open Fabulous.StackAllocatedCollections.StackList
open Microsoft.Maui
open Microsoft.Maui.Handlers
open Microsoft.Maui.Layouts

module ScrollView =
    let HorizontalScrollBarVisibility = Attributes.defineMauiScalarWithEquality<ScrollBarVisibility> "HorizontalScrollBarVisibility"
    let Orientation = Attributes.defineMauiScalarWithEquality<ScrollOrientation> "Orientation"
    let VerticalScrollBarVisibility = Attributes.defineMauiScalarWithEquality<ScrollBarVisibility> "VerticalScrollBarVisibility"
    
    module Defaults =
        let [<Literal>] HorizontalScrollBarVisibility = ScrollBarVisibility.Default
        let [<Literal>] Orientation = ScrollOrientation.Vertical
        let [<Literal>] VerticalScrollBarVisibility = ScrollBarVisibility.Default
    
type FabScrollView(handler: IViewHandler) =
    inherit FabContentView(handler)
    
    let mutable _horizontalOffset = 0.
    let mutable _verticalOffset = 0.
    
    static let _widgetKey = Widgets.register<FabScrollView>()
    static member WidgetKey = _widgetKey
   
    new() = FabScrollView(ScrollViewHandler())

    interface IScrollView with            
        member this.CrossPlatformMeasure(widthConstraint, heightConstraint) =
            let mutable overrideWidthConstraint = widthConstraint
            let mutable overrideHeightConstraint = heightConstraint
            
            match (this :> IScrollView).Orientation with            
            | ScrollOrientation.Horizontal ->
                overrideWidthConstraint <- System.Double.PositiveInfinity
            
            | ScrollOrientation.Neither
            | ScrollOrientation.Both ->
                overrideWidthConstraint <- System.Double.PositiveInfinity
                overrideHeightConstraint <- System.Double.PositiveInfinity                    
            
            | _ ->
                overrideHeightConstraint <- System.Double.PositiveInfinity

            let content = this.GetWidget<IView>(ContentView.Content)
            let y = content.Measure(overrideWidthConstraint, overrideHeightConstraint)
            content.DesiredSize
            
        member this.CrossPlatformArrange(bounds) =
            let content = this.GetWidget<IView>(ContentView.Content)
            let padding = this.GetScalar(Padding.Padding, Thickness.Zero)
            let updatedBounds =
                Graphics.Rect(
                    bounds.X,
                    bounds.Y,
                    System.Math.Max(bounds.Width, content.DesiredSize.Width + padding.HorizontalThickness),
                    System.Math.Max(bounds.Height, content.DesiredSize.Height + padding.VerticalThickness)
                )
            this.ArrangeContent(updatedBounds)
            updatedBounds.Size
            
        member this.RequestScrollTo(horizontalOffset, verticalOffset, instant) = failwith "todo"
        member this.ScrollFinished() = failwith "todo"
        member this.ContentSize = failwith "todo"
        member this.HorizontalOffset
            with get () = _horizontalOffset
            and set v = _horizontalOffset <- v
        member this.HorizontalScrollBarVisibility = this.GetScalar(ScrollView.HorizontalScrollBarVisibility, ScrollView.Defaults.HorizontalScrollBarVisibility)
        member this.Orientation = this.GetScalar(ScrollView.Orientation, ScrollView.Defaults.Orientation)
        member this.VerticalOffset
            with get () = _verticalOffset
            and set v = _verticalOffset <- v
        member this.VerticalScrollBarVisibility = this.GetScalar(ScrollView.VerticalScrollBarVisibility, ScrollView.Defaults.VerticalScrollBarVisibility)
            
[<AutoOpen>]
module ScrollViewBuilders =
    type Fabulous.Maui.View with
        static member inline ScrollView<'msg, 'marker when 'marker :> IView>(content: WidgetBuilder<'msg, 'marker>) =
            WidgetBuilder<'msg, IScrollView>(
                FabScrollView.WidgetKey,
                AttributesBundle(
                    StackList.empty(),
                    ValueSome [|
                        ContentView.Content.WithValue(content.Compile())
                    |],
                    ValueNone
                )
            )