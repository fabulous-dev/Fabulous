namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives
open Microsoft.Maui.Layouts

module View' =
    let AutomationId = Attributes.defineMauiScalarWithEquality<string> "AutomationId"
    let Background = Attributes.defineMauiScalarWithEquality<Paint> "Background"
    let FlowDirection = Attributes.defineMauiScalarWithEquality<FlowDirection> "FlowDirection"
    let Height = Attributes.defineMauiScalarWithEquality<float> "Height"
    let HorizontalLayoutAlignment = Attributes.defineMauiScalarWithEquality<LayoutAlignment> "HorizontalLayoutAlignment"
    let InputTransparent = Attributes.defineMauiScalarWithEquality<bool> "InputTransparent"
    let IsEnabled = Attributes.defineMauiScalarWithEquality<bool> "IsEnabled"
    let IsFocused = Attributes.defineMauiScalarWithEquality<bool> "IsFocused"
    let Margin = Attributes.defineMauiScalarWithEquality<Thickness> "Margin"
    let MaximumHeight = Attributes.defineMauiScalarWithEquality<float> "MaximumHeight"
    let MaximumWidth = Attributes.defineMauiScalarWithEquality<float> "MaximumWidth"
    let MinimumHeight = Attributes.defineMauiScalarWithEquality<float> "MinimumHeight"
    let MinimumWidth = Attributes.defineMauiScalarWithEquality<float> "MinimumWidth"
    let Opacity = Attributes.defineMauiScalarWithEquality<float> "Opacity"
    let Semantics = Attributes.defineMauiScalarWithEquality<Semantics> "Semantics"
    let VerticalLayoutAlignment = Attributes.defineMauiScalarWithEquality<LayoutAlignment> "VerticalLayoutAlignment"
    let Visibility = Attributes.defineMauiScalarWithEquality<Visibility> "Visibility"
    let Width = Attributes.defineMauiScalarWithEquality<float> "Width"
    let ZIndex = Attributes.defineMauiScalarWithEquality<int> "ZIndex"

    let Focused = Attributes.defineMauiEventNoArgs "Focused"
    let Unfocused = Attributes.defineMauiEventNoArgs "Unfocused"
    
    module Defaults =
        let [<Literal>] AutomationId: string = null
        let [<Literal>] Background: Paint = null
        let [<Literal>] FlowDirection = Microsoft.Maui.FlowDirection.MatchParent
        let [<Literal>] Height = Dimension.Unset
        let [<Literal>] HorizontalLayoutAlignment = LayoutAlignment.Fill
        let [<Literal>] InputTransparent = false
        let [<Literal>] IsEnabled = true
        let [<Literal>] IsFocused = false
        let [<Literal>] MaximumHeight = Dimension.Maximum
        let [<Literal>] MaximumWidth = Dimension.Maximum
        let [<Literal>] MinimumHeight = Dimension.Unset
        let [<Literal>] MinimumWidth = Dimension.Unset
        let [<Literal>] Opacity = 1.
        let [<Literal>] Semantics: Microsoft.Maui.Semantics = null
        let [<Literal>] VerticalLayoutAlignment = LayoutAlignment.Fill
        let [<Literal>] Visibility = Microsoft.Maui.Visibility.Visible
        let [<Literal>] Width = Dimension.Unset
        let [<Literal>] ZIndex = -1
        let inline createDefaultMargin() = Thickness.Zero
    
type FabView(handler: IViewHandler) =
    inherit FabElement(handler)
    
    let mutable _frame = Rect.Zero
    let mutable _desiredSize = Size.Zero
    let mutable _isFocus = View'.Defaults.IsFocused
    
    member this.DesiredSize
        with get() = _desiredSize
        and set v = _desiredSize <- v
        
    interface ITransform with
        member this.AnchorX = this.GetScalar(Transform.AnchorX, Transform.Defaults.AnchorX)
        member this.AnchorY = this.GetScalar(Transform.AnchorY, Transform.Defaults.AnchorY)
        member this.Rotation = this.GetScalar(Transform.Rotation, Transform.Defaults.Rotation)
        member this.RotationX = this.GetScalar(Transform.RotationX, Transform.Defaults.RotationX)
        member this.RotationY = this.GetScalar(Transform.RotationY, Transform.Defaults.RotationY)
        member this.Scale = this.GetScalar(Transform.Scale, Transform.Defaults.Scale)
        member this.ScaleX = this.GetScalar(Transform.ScaleX, Transform.Defaults.ScaleX)
        member this.ScaleY = this.GetScalar(Transform.ScaleY, Transform.Defaults.ScaleY)
        member this.TranslationX = this.GetScalar(Transform.TranslationX, Transform.Defaults.TranslationX)
        member this.TranslationY = this.GetScalar(Transform.TranslationY, Transform.Defaults.TranslationY)

    interface IView with
        member this.Handler
            with get () = this.Handler :?> IViewHandler
            and set (value: IViewHandler) = this.Handler <- value
            
        member this.Arrange(bounds) =
            _frame <- this.ComputeFrame(bounds)
            (this.Handler :?> IViewHandler).PlatformArrange(_frame)
            _frame.Size
            
        member this.Focus() =
            _isFocus <- true
            this.InvokeEvent(View'.Focused)
            true
            
        member this.Unfocus() =
            _isFocus <- false
            this.InvokeEvent(View'.Unfocused)
            
        member this.InvalidateArrange() = ()
        member this.InvalidateMeasure() = handler.Invoke("InvalidateMeasure")
        member this.Measure(widthConstraint, heightConstraint) =
            _desiredSize <- this.ComputeDesiredSize(widthConstraint, heightConstraint)
            _desiredSize
            
        member this.AutomationId = this.GetScalar(View'.AutomationId, View'.Defaults.AutomationId)
        member this.Background = this.GetScalar(View'.Background, View'.Defaults.Background)
        member this.Clip = null
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = this.GetScalar(View'.FlowDirection, View'.Defaults.FlowDirection)
        member this.Frame
            with get() = _frame
            and set v = _frame <- v
        member this.Height = this.GetScalar(View'.Height, View'.Defaults.Height)
        member this.HorizontalLayoutAlignment = this.GetScalar(View'.HorizontalLayoutAlignment, View'.Defaults.HorizontalLayoutAlignment)
        member this.InputTransparent = this.GetScalar(View'.InputTransparent, View'.Defaults.InputTransparent)
        member this.IsEnabled = this.GetScalar(View'.IsEnabled, View'.Defaults.IsEnabled)
        member this.IsFocused
            with get() = this.GetScalar(View'.IsFocused, _isFocus)
            and set v =
                if v then
                    _isFocus <- true
                    this.InvokeEvent(View'.Focused)
                else
                    _isFocus <- false
                    this.InvokeEvent(View'.Unfocused)
        member this.Margin = this.GetScalar(View'.Margin, View'.Defaults.createDefaultMargin())
        member this.MaximumHeight = this.GetScalar(View'.MaximumHeight, View'.Defaults.MaximumHeight)
        member this.MaximumWidth = this.GetScalar(View'.MaximumWidth, View'.Defaults.MaximumWidth)
        member this.MinimumHeight = this.GetScalar(View'.MinimumHeight, View'.Defaults.MinimumHeight)
        member this.MinimumWidth = this.GetScalar(View'.MinimumWidth, View'.Defaults.MinimumWidth)
        member this.Opacity = this.GetScalar(View'.Opacity, View'.Defaults.Opacity)
        member this.Semantics = this.GetScalar(View'.Semantics, View'.Defaults.Semantics)
        member this.Shadow = null
        member this.VerticalLayoutAlignment = this.GetScalar(View'.VerticalLayoutAlignment, View'.Defaults.VerticalLayoutAlignment)
        member this.Visibility = this.GetScalar(View'.Visibility, View'.Defaults.Visibility)
        member this.Width = this.GetScalar(View'.Width, View'.Defaults.Width)
        member this.ZIndex = this.GetScalar(View'.ZIndex, View'.Defaults.ZIndex)

[<Extension>]
type ViewModifiers =
    [<Extension>]
    static member inline horizontalLayoutAlignment(this: WidgetBuilder<'msg, #IView>, value: LayoutAlignment) =
        this.AddScalar(View'.HorizontalLayoutAlignment.WithValue(value))
        
    [<Extension>]
    static member inline verticalLayoutAlignment(this: WidgetBuilder<'msg, #IView>, value: LayoutAlignment) =
        this.AddScalar(View'.VerticalLayoutAlignment.WithValue(value))
        
    [<Extension>]
    static member inline background(this: WidgetBuilder<'msg, #IView>, value: SolidPaint) =
        this.AddScalar(View'.Background.WithValue(value))
        
    [<Extension>]
    static member inline height(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(View'.Height.WithValue(value))
        
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, value: Thickness) =
        this.AddScalar(View'.Margin.WithValue(value))
        
    [<Extension>]
    static member inline width(this: WidgetBuilder<'msg, #IView>, value: float) =
        this.AddScalar(View'.Width.WithValue(value))
        
    [<Extension>]
    static member inline semantics(this: WidgetBuilder<'msg, #IView>, ?headingLevel: SemanticHeadingLevel, ?description: string, ?hint: string) =
        let value =
            Semantics(
                HeadingLevel = defaultArg headingLevel SemanticHeadingLevel.None,
                Description = defaultArg description null,
                Hint = defaultArg hint null
            )
        this.AddScalar(View'.Semantics.WithValue(value))
        
[<Extension>]
type ViewExtraModifiers =
    [<Extension>]
    static member inline centerVertical(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(View'.VerticalLayoutAlignment.WithValue(LayoutAlignment.Center))
        
    [<Extension>]
    static member inline centerHorizontal(this: WidgetBuilder<'msg, #IView>) =
        this.AddScalar(View'.HorizontalLayoutAlignment.WithValue(LayoutAlignment.Center))
        
    [<Extension>]
    static member inline center(this: WidgetBuilder<'msg, #IView>) =
        this
            .AddScalar(View'.VerticalLayoutAlignment.WithValue(LayoutAlignment.Center))
            .AddScalar(View'.HorizontalLayoutAlignment.WithValue(LayoutAlignment.Center))
            
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, left: float, top: float, right: float, bottom: float) =
        this.AddScalar(View'.Margin.WithValue(Thickness(left, top, right, bottom)))
            
    [<Extension>]
    static member inline margin(this: WidgetBuilder<'msg, #IView>, horizontalSize: float, verticalSize: float) =
        this.AddScalar(View'.Margin.WithValue(Thickness(horizontalSize, verticalSize)))
            
    [<Extension>]
    static member inline size(this: WidgetBuilder<'msg, #IView>, width: float, height: float) =
        this
            .AddScalar(View'.Width.WithValue(width))
            .AddScalar(View'.Height.WithValue(height))