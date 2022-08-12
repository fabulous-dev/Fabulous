namespace Fabulous.Maui

open System.Collections.Generic
open Microsoft.Maui

module Layout =
    let Children = Attributes.defineMauiWidgetCollection "StackLayout_Children"
    
    type FabulousLayout(handler) =
        inherit View'.FabulousView(handler)
        
        let _children = List<IView>()
        
        member this.Children = this.GetWidgetCollection(Children)

        interface ILayout with
            member this.Add(item) = failwith "todo"
            member this.Clear() = failwith "todo"
            member this.Contains(item) = failwith "todo"
            member this.CopyTo(array, arrayIndex) = failwith "todo"
            member this.CrossPlatformArrange(bounds) = failwith "todo"
            member this.CrossPlatformMeasure(widthConstraint, heightConstraint) =
                this.DesiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
                this.DesiredSize
            
            member this.GetEnumerator(): System.Collections.Generic.IEnumerator<IView> = failwith "todo"
            member this.GetEnumerator(): System.Collections.IEnumerator = failwith "todo"
            member this.IndexOf(item) = failwith "todo"
            member this.Insert(index, item) = failwith "todo"
            member this.Remove(item) = failwith "todo"
            member this.RemoveAt(index) = failwith "todo"
            member this.ClipsToBounds = failwith "todo"
            member this.Count = this.Children.Count
            member this.IgnoreSafeArea = failwith "todo"
            member this.IsReadOnly = failwith "todo"
            member this.Item
                with get index = this.Children[index] :?> IView
                and set index v = this.Children[index] <- v
            member this.Padding = this.GetScalar(Padding.Padding, Thickness.Zero)