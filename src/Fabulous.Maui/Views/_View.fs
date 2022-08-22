namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives
open Microsoft.Maui.Layouts

module View' =
    let AnchorX = Attributes.defineMauiScalarWithEquality<float> "AnchorX"
    let AnchorY = Attributes.defineMauiScalarWithEquality<float> "AnchorY"
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
    let Rotation = Attributes.defineMauiScalarWithEquality<float> "Rotation"
    let RotationX = Attributes.defineMauiScalarWithEquality<float> "RotationX"
    let RotationY = Attributes.defineMauiScalarWithEquality<float> "RotationY"
    let Scale = Attributes.defineMauiScalarWithEquality<float> "Scale"
    let ScaleX = Attributes.defineMauiScalarWithEquality<float> "ScaleX"
    let ScaleY = Attributes.defineMauiScalarWithEquality<float> "ScaleY"
    let Semantics = Attributes.defineMauiScalarWithEquality<Semantics> "Semantics"
    let TranslationX = Attributes.defineMauiScalarWithEquality<float> "TranslationX"
    let TranslationY = Attributes.defineMauiScalarWithEquality<float> "TranslationY"
    let VerticalLayoutAlignment = Attributes.defineMauiScalarWithEquality<LayoutAlignment> "VerticalLayoutAlignment"
    let Visibility = Attributes.defineMauiScalarWithEquality<Visibility> "Visibility"
    let Width = Attributes.defineMauiScalarWithEquality<float> "Width"
    let ZIndex = Attributes.defineMauiScalarWithEquality<int> "ZIndex"

    let Focused = Attributes.defineMauiEventNoArgs "Focused"
    let Unfocused = Attributes.defineMauiEventNoArgs "Unfocused"
    
type FabView(handler: IViewHandler) =
    inherit FabElement(handler)
    
    let mutable _frame = Rect.Zero
    let mutable _desiredSize = Size.Zero
    let mutable _isFocus = false
    
    member this.DesiredSize
        with get() = _desiredSize
        and set v = _desiredSize <- v

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
            
        member this.AnchorX = this.GetScalar(View'.AnchorX, 0.5)
        member this.AnchorY = this.GetScalar(View'.AnchorY, 0.5)
        member this.AutomationId = this.GetScalar(View'.AutomationId, null)
        member this.Background = this.GetScalar(View'.Background, null)
        member this.Clip = null
        member this.DesiredSize = _desiredSize
        member this.FlowDirection = this.GetScalar(View'.FlowDirection, FlowDirection.MatchParent)
        member this.Frame
            with get() = _frame
            and set v = _frame <- v
        member this.Height = this.GetScalar(View'.Height, Dimension.Unset)
        member this.HorizontalLayoutAlignment = this.GetScalar(View'.HorizontalLayoutAlignment, LayoutAlignment.Fill)
        member this.InputTransparent = this.GetScalar(View'.InputTransparent, false)
        member this.IsEnabled = this.GetScalar(View'.IsEnabled, true)
        member this.IsFocused
            with get() = this.GetScalar(View'.IsFocused, _isFocus)
            and set v =
                if v then
                    _isFocus <- true
                    this.InvokeEvent(View'.Focused)
                else
                    _isFocus <- false
                    this.InvokeEvent(View'.Unfocused)
        member this.Margin = this.GetScalar(View'.Margin, Thickness.Zero)
        member this.MaximumHeight = this.GetScalar(View'.MaximumHeight, Dimension.Maximum)
        member this.MaximumWidth = this.GetScalar(View'.MaximumWidth, Dimension.Maximum)
        member this.MinimumHeight = this.GetScalar(View'.MinimumHeight, Dimension.Unset)
        member this.MinimumWidth = this.GetScalar(View'.MinimumWidth, Dimension.Unset)
        member this.Opacity = this.GetScalar(View'.Opacity, 1.)
        member this.Rotation = this.GetScalar(View'.Rotation, 0.)
        member this.RotationX = this.GetScalar(View'.RotationX, 0.)
        member this.RotationY = this.GetScalar(View'.RotationY, 0.)
        member this.Scale = this.GetScalar(View'.Scale, 1.)
        member this.ScaleX = this.GetScalar(View'.ScaleX, 1.)
        member this.ScaleY = this.GetScalar(View'.ScaleY, 1.)
        member this.Semantics = this.GetScalar(View'.Semantics, null)
        member this.Shadow = null
        member this.TranslationX = this.GetScalar(View'.TranslationX, 0.)
        member this.TranslationY = this.GetScalar(View'.TranslationY, 0.)
        member this.VerticalLayoutAlignment = this.GetScalar(View'.VerticalLayoutAlignment, LayoutAlignment.Fill)
        member this.Visibility = this.GetScalar(View'.Visibility, Microsoft.Maui.Visibility.Visible)
        member this.Width = this.GetScalar(View'.Width, Dimension.Unset)
        member this.ZIndex = this.GetScalar(View'.ZIndex, -1)
            

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