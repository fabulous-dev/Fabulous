namespace Fabulous.Maui

open System.Collections.Generic
open System.Runtime.CompilerServices
open Fabulous.StackAllocatedCollections
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers
open Fabulous

type FabulousStackLayout() =
    inherit Node(LayoutHandler())
    
    let mutable _isVertical = false
    let mutable _frame = Rect.Zero
    let mutable _desiredSize = Size.Zero
    let _children = List<IView>()
    
    member this.Children = _children
    
    member this.SetIsVertical(value: bool) =
        _isVertical <- value

    interface IStackLayout with
        member this.Add(item) = failwith "todo"
        member this.Arrange(bounds) = failwith "todo"
        member this.Clear() = failwith "todo"
        member this.Contains(item) = failwith "todo"
        member this.CopyTo(array, arrayIndex) = failwith "todo"
        member this.CrossPlatformArrange(bounds) = failwith "todo"
        member this.CrossPlatformMeasure(widthConstraint, heightConstraint) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
        member this.Focus() = failwith "todo"
        member this.GetEnumerator(): System.Collections.Generic.IEnumerator<IView> = failwith "todo"
        member this.GetEnumerator(): System.Collections.IEnumerator = failwith "todo"
        member this.IndexOf(item) = failwith "todo"
        member this.Insert(index, item) = failwith "todo"
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.Measure(widthConstraint, heightConstraint) = failwith "todo"
        member this.Remove(item) = failwith "todo"
        member this.RemoveAt(index) = failwith "todo"
        member this.Unfocus() = failwith "todo"
        member this.AnchorX = 0.5
        member this.AnchorY = 0.5
        member this.AutomationId = null
        member this.Background = null
        member this.Clip = null
        member this.ClipsToBounds = false
        member this.Count = _children.Count
        member this.DesiredSize = failwith "todo"
        member this.FlowDirection = FlowDirection.MatchParent
        member this.Frame = _frame
        member this.Frame with set value = _frame <- value
        member this.Height = -1.
        member this.HorizontalLayoutAlignment = failwith "todo"
        member this.IgnoreSafeArea = false
        member this.InputTransparent = true
        member this.IsEnabled = failwith "todo"
        member this.IsFocused = failwith "todo"
        member this.IsReadOnly = failwith "todo"
        member this.Item with get index = _children[index]
        member this.Item with set index value = _children[index] <- value
        member this.Margin = Thickness()
        member this.MaximumHeight = failwith "todo"
        member this.MaximumWidth = failwith "todo"
        member this.MinimumHeight = failwith "todo"
        member this.MinimumWidth = failwith "todo"
        member this.Opacity = 1.
        member this.Padding = Thickness()
        member this.Parent = this.Parent
        member this.Rotation = 0.
        member this.RotationX = 0.
        member this.RotationY = 0.
        member this.Scale = 1.
        member this.ScaleX = 1.
        member this.ScaleY = 1.
        member this.Semantics = null
        member this.Shadow = null
        member this.Spacing = failwith "todo"
        member this.TranslationX = 0.
        member this.TranslationY = 0.
        member this.VerticalLayoutAlignment = failwith "todo"
        member this.Visibility = Visibility.Visible
        member this.Width = -1.
        member this.ZIndex = failwith "todo"
        member this.IsFocused with set value = failwith "todo"
        
        member this.Handler
            with get () : IElementHandler = this.Handler
            and set value = this.Handler <- value
            
        member this.Handler
            with get () = this.Handler :?> IViewHandler
            and set (value: IViewHandler) = this.Handler <- value

module StackLayout =
    let VerticalWidgetKey = Widgets.registerWithAdditionalSetup<FabulousStackLayout>(fun target _ -> target.SetIsVertical(true))
    let HorizontalWidgetKey = Widgets.registerWithAdditionalSetup<FabulousStackLayout>(fun target _ -> target.SetIsVertical(false))
    
    let Children =
        Attributes.defineListWidgetCollection
            "StackLayout_Children"
            ViewNode.get
            (fun target -> (target :?> FabulousStackLayout).Children)
            
    
[<AutoOpen>]
module StackLayoutBuilders =
    type Fabulous.Maui.View with
        static member inline VStack<'msg>() =
            CollectionBuilder<'msg, IStackLayout, IView>(
                StackLayout.VerticalWidgetKey,
                StackLayout.Children
            )
            
        static member inline HStack<'msg>() =
            CollectionBuilder<'msg, IStackLayout, IView>(
                StackLayout.HorizontalWidgetKey,
                StackLayout.Children
            )
            
[<Extension>]
type StackLayoutCollectionExtensions =
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IView>
        (
            _: CollectionBuilder<'msg, IStackLayout, IView>,
            x: WidgetBuilder<'msg, 'itemType>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>
        
    [<Extension>]
    static member inline Yield<'msg, 'itemType when 'itemType :> IView>
        (
            _: CollectionBuilder<'msg, IStackLayout, IView>,
            x: WidgetBuilder<'msg, Memo.Memoized<'itemType>>
        ) =
        { Widgets = MutStackArray1.One(x.Compile()) } : Content<'msg>