namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Primitives

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
    
    type FabulousView(handler) =
        inherit Element.FabulousElement(handler)
        
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
                _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
                let viewHandler = this.Handler :?> IViewHandler
                if viewHandler <> null then viewHandler.PlatformArrange(_frame)
                _frame.Size
                
            member this.Focus() =
                _isFocus <- true
                this.InvokeEvent(Focused)
                true
                
            member this.Unfocus() =
                _isFocus <- false
                this.InvokeEvent(Unfocused)
                
            member this.InvalidateArrange() = failwith "todo"
            member this.InvalidateMeasure() = failwith "todo"
            member this.Measure(widthConstraint, heightConstraint) =
                _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
                _desiredSize
            member this.AnchorX = this.GetScalar(AnchorX, 0.5)
            member this.AnchorY = this.GetScalar(AnchorY, 0.5)
            member this.AutomationId = this.GetScalar(AutomationId, null)
            member this.Background = this.GetScalar(Background, SolidPaint(Colors.White))
            member this.Clip = null
            member this.DesiredSize = _desiredSize
            member this.FlowDirection = this.GetScalar(FlowDirection, Microsoft.Maui.FlowDirection.MatchParent)
            member this.Frame
                with get() = _frame
                and set v = _frame <- v
            member this.Height = this.GetScalar(Height, -1.)
            member this.HorizontalLayoutAlignment = this.GetScalar(HorizontalLayoutAlignment, LayoutAlignment.Start)
            member this.InputTransparent = this.GetScalar(InputTransparent, false)
            member this.IsEnabled = this.GetScalar(IsEnabled, true)
            member this.IsFocused
                with get() = this.GetScalar(IsFocused, false)
                and set v =
                    if v then
                        _isFocus <- true
                        this.InvokeEvent(Focused)
                    else
                        _isFocus <- false
                        this.InvokeEvent(Unfocused)
            member this.Margin = this.GetScalar(Margin, Thickness.Zero)
            member this.MaximumHeight = this.GetScalar(MaximumHeight, -1)
            member this.MaximumWidth = this.GetScalar(MaximumWidth, -1)
            member this.MinimumHeight = this.GetScalar(MinimumHeight, 0)
            member this.MinimumWidth = this.GetScalar(MinimumWidth, 0)
            member this.Opacity = this.GetScalar(Opacity, 1.)
            member this.Rotation = this.GetScalar(Rotation, 0.)
            member this.RotationX = this.GetScalar(RotationX, 0.)
            member this.RotationY = this.GetScalar(RotationY, 0.)
            member this.Scale = this.GetScalar(Scale, 1.)
            member this.ScaleX = this.GetScalar(ScaleX, 1.)
            member this.ScaleY = this.GetScalar(ScaleY, 1.)
            member this.Semantics = this.GetScalar(Semantics, null)
            member this.Shadow = null
            member this.TranslationX = this.GetScalar(TranslationX, 0.)
            member this.TranslationY = this.GetScalar(TranslationY, 0.)
            member this.VerticalLayoutAlignment = this.GetScalar(VerticalLayoutAlignment, LayoutAlignment.Start)
            member this.Visibility = this.GetScalar(Visibility, Microsoft.Maui.Visibility.Visible)
            member this.Width = this.GetScalar(Width, -1)
            member this.ZIndex = this.GetScalar(ZIndex, -1)
            

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