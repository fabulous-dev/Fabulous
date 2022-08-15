namespace Fabulous.Maui

open System.Collections.Generic
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Layouts

module Layout =
    /// TODO: Override Padding to invalidate layout when it is changed.
    
    let Children = Attributes.defineMauiWidgetCollection "StackLayout_Children"
    let ClipsToBounds = Attributes.defineMauiScalarWithEquality<bool> "ClipsToBounds"
    let IgnoreSafeArea = Attributes.defineMauiScalarWithEquality<bool> "IgnoreSafeArea"
    let IsReadOnly = Attributes.defineMauiScalarWithEquality<bool> "IsReadOnly"
    
    type FabulousLayout(handler, layoutManagerFn: ILayout -> ILayoutManager) =
        inherit View'.FabulousView(handler)
        
        let _children = List<IView>()
        let mutable _layoutManager: ILayoutManager = null
        let mutable _hasDoneLayout: bool = false
        
        member this.Children = List(this.GetWidgetCollection(Children) |> Seq.map unbox<IView>)
        member this.LayoutManager =
            if _layoutManager = null then
                _layoutManager <- layoutManagerFn(this)
            
            _layoutManager
            
//         member this.UpdateChildrenLayout() =
//             _hasDoneLayout <- true
//             
//             let children = this.Children
//
//             //if (!ShouldLayoutChildren())
//             //    return;
//
//             let oldBounds = Array.init children.Count (fun _ -> Rect.Zero)
//             for index = 0 to oldBounds.Length do
// 				let c = children[index]
// 				oldBounds[index] = c.Bounds;
//
// 			double width = Width;
// 			double height = Height;
//
// 			double x = Padding.Left;
// 			double y = Padding.Top;
// 			double w = Math.Max(0, width - Padding.HorizontalThickness);
// 			double h = Math.Max(0, height - Padding.VerticalThickness);
//
// 			var isHeadless = CompressedLayout.GetIsHeadless(this);
// 			var headlessOffset = CompressedLayout.GetHeadlessOffset(this);
// 			for (var i = 0; i < LogicalChildrenInternal.Count; i++)
// 				CompressedLayout.SetHeadlessOffset((VisualElement)LogicalChildrenInternal[i], isHeadless ? new Point(headlessOffset.X + Bounds.X, headlessOffset.Y + Bounds.Y) : new Point());
//
// 			_lastLayoutSize = new Size(width, height);
//
// 			LayoutChildren(x, y, w, h);
//
// 			for (var i = 0; i < oldBounds.Length; i++)
// 			{
// 				Rect oldBound = oldBounds[i];
// 				Rect newBound = ((VisualElement)LogicalChildrenInternal[i]).Bounds;
// 				if (oldBound != newBound)
// 				{
// 					LayoutChanged?.Invoke(this, EventArgs.Empty);
// 					return;
// 				}
// 			}

        interface ILayout with
            member this.Measure(widthConstraint, heightConstraint) =
                let padding = this.GetScalar(Padding.Padding, Thickness.Zero)
                let size = (this :> IView).Measure(widthConstraint - padding.HorizontalThickness, heightConstraint - padding.VerticalThickness)
                Size(size.Width + padding.HorizontalThickness, size.Height + padding.VerticalThickness)
                
            member this.Add(item) = this.Children.Add(item)
            member this.Clear() = this.Children.Clear()
            member this.Contains(item) = this.Children.Contains(item)
            member this.CopyTo(array, arrayIndex) = this.Children.CopyTo(array, arrayIndex)
            member this.CrossPlatformArrange(bounds) = this.LayoutManager.ArrangeChildren(bounds)
            member this.CrossPlatformMeasure(widthConstraint, heightConstraint) = this.LayoutManager.Measure(widthConstraint, heightConstraint)
            member this.GetEnumerator(): System.Collections.Generic.IEnumerator<IView> = this.Children.GetEnumerator()
            member this.GetEnumerator(): System.Collections.IEnumerator = this.Children.GetEnumerator()
            member this.IndexOf(item) = this.Children.IndexOf(item)
            member this.Insert(index, item) = this.Children.Insert(index, item)
            member this.Remove(item) = this.Children.Remove(item)
            member this.RemoveAt(index) = this.Children.RemoveAt(index)
            member this.ClipsToBounds = this.GetScalar(ClipsToBounds, false)
            member this.Count = this.Children.Count
            member this.IgnoreSafeArea = this.GetScalar(IgnoreSafeArea, false)
            member this.IsReadOnly = this.GetScalar(IsReadOnly, false)
            member this.Item
                with get index = this.Children[index]
                and set index v = this.Children[index] <- v
            member this.Padding = this.GetScalar(Padding.Padding, Thickness.Zero)