namespace Fabulous.Maui

open System.Collections.Generic
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Layouts

module Layout =
    /// TODO: Override Padding to invalidate layout when it is changed.
    
    let Children = Attributes.defineMauiWidgetCollectionLayout "StackLayout_Children"
    let ClipsToBounds = Attributes.defineMauiScalarWithEquality<bool> "ClipsToBounds"
    let IgnoreSafeArea = Attributes.defineMauiScalarWithEquality<bool> "IgnoreSafeArea"
    
    module Defaults =
        let [<Literal>] ClipsToBounds = false
        let [<Literal>] IgnoreSafeArea = false
    
type FabLayout(handler, layoutManagerFn: ILayout -> ILayoutManager) =
    inherit FabView(handler)
    
    let _children = List<IView>()
    let mutable _layoutManager: ILayoutManager = null
    
    member this.Children = List(this.GetWidgetCollection(Layout.Children) |> Seq.map unbox<IView>)
    member this.LayoutManager =
        if _layoutManager = null then
            _layoutManager <- layoutManagerFn(this)
        
        _layoutManager

    interface ILayout with
        member this.Measure(widthConstraint, heightConstraint) =
            let padding = this.GetScalar(Padding.Padding, Thickness.Zero)
            // TODO: Need to find a way to call the base implementation of a member when overriding it in a subclass via interfaces
            let desiredSize = this.ComputeDesiredSize(widthConstraint - padding.HorizontalThickness, heightConstraint - padding.VerticalThickness)
            let desiredSize = Size(desiredSize.Width + padding.HorizontalThickness, desiredSize.Height + padding.VerticalThickness)
            this.DesiredSize <- desiredSize
            desiredSize
            
        member this.Add(item) = this.Children.Add(item)
        member this.Clear() = this.Children.Clear()
        member this.Contains(item) = this.Children.Contains(item)
        member this.CopyTo(array, arrayIndex) = this.Children.CopyTo(array, arrayIndex)
        member this.InvalidateMeasure() =
            handler.Invoke("InvalidateMeasure")
            
            for child in this.Children do
                child.InvalidateMeasure()
            
        member this.CrossPlatformArrange(bounds) = this.LayoutManager.ArrangeChildren(bounds)
        member this.CrossPlatformMeasure(widthConstraint, heightConstraint) = this.LayoutManager.Measure(widthConstraint, heightConstraint)
        member this.GetEnumerator(): System.Collections.Generic.IEnumerator<IView> = this.Children.GetEnumerator()
        member this.GetEnumerator(): System.Collections.IEnumerator = this.Children.GetEnumerator()
        member this.IndexOf(item) = this.Children.IndexOf(item)
        member this.Insert(index, item) = this.Children.Insert(index, item)
        member this.Remove(item) = this.Children.Remove(item)
        member this.RemoveAt(index) = this.Children.RemoveAt(index)
        member this.ClipsToBounds = this.GetScalar(Layout.ClipsToBounds, Layout.Defaults.ClipsToBounds)
        member this.Count = this.Children.Count
        member this.IgnoreSafeArea = this.GetScalar(Layout.IgnoreSafeArea, Layout.Defaults.IgnoreSafeArea)
        member this.IsReadOnly = true
        member this.Item
            with get index = this.Children[index]
            and set index v = this.Children[index] <- v
        member this.Padding = this.GetScalar(Padding.Padding, Padding.Defaults.createDefaultPadding())