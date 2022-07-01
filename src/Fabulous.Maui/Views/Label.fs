namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers
open Fabulous

type FabulousLabel() =
    inherit Node(LabelHandler())
    
    let mutable _frame = Rect.Zero
    let mutable _desiredSize = Size.Zero
    
    member val Text = "" with get, set
    member val TextColor = Colors.Black with get, set
    
    interface ILabel with        
        member this.Arrange(bounds) =
            _frame <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeFrame(this, bounds)
            let viewHandler = this.Handler :?> IViewHandler
            if viewHandler <> null then viewHandler.PlatformArrange(_frame)
            _frame.Size
            
        member this.Focus() = failwith "todo"
        member this.InvalidateArrange() = failwith "todo"
        member this.InvalidateMeasure() = failwith "todo"
        member this.Measure(widthConstraint, heightConstraint) =
            _desiredSize <- Microsoft.Maui.Layouts.LayoutExtensions.ComputeDesiredSize(this, widthConstraint, heightConstraint)
            _desiredSize
            
        member this.Unfocus() = failwith "todo"
        member this.AnchorX = 0.5
        member this.AnchorY = 0.5
        member this.AutomationId = null
        member this.Background = SolidPaint(Colors.White)
        member this.CharacterSpacing = 1.
        member this.Clip = null
        member this.DesiredSize = failwith "todo"
        member this.FlowDirection = FlowDirection.MatchParent
        member this.Font = Microsoft.Maui.Font.Default
        member this.Frame = _frame
        member this.Height = -1
        member this.HorizontalLayoutAlignment = failwith "todo"
        member this.HorizontalTextAlignment = TextAlignment.Start
        member this.InputTransparent = true
        member this.IsEnabled = failwith "todo"
        member this.IsFocused = failwith "todo"
        member this.LineHeight = 1.
        member this.Margin = failwith "todo"
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
        member this.Text = this.Text
        member this.TextColor = this.TextColor
        member this.TextDecorations = TextDecorations.None
        member this.TranslationX = 0.
        member this.TranslationY = 0.
        member this.VerticalLayoutAlignment = failwith "todo"
        member this.VerticalTextAlignment = failwith "todo"
        member this.Visibility = Visibility.Visible
        member this.Width = -1
        member this.ZIndex = failwith "todo"
        member this.Frame with set value = failwith "todo"
        member this.IsFocused with set value = failwith "todo"
        
        member this.Handler
            with get () : IElementHandler = this.Handler
            and set value = this.Handler <- value
            
        member this.Handler
            with get () = this.Handler :?> IViewHandler
            and set (value: IViewHandler) = this.Handler <- value
        
module FabulousLabel =
    let WidgetKey = Widgets.register<FabulousLabel>()
    
    let Text =
        Attributes.defineSimpleScalarWithEquality<string>
            "Text"
            (fun _ newValue node ->
                let target = node.Target :?> FabulousLabel
                match newValue with
                | ValueNone -> target.Text <- ""
                | ValueSome value -> target.Text <- value
                let res = (target :> ILabel).Handler
                res.UpdateValue("Text"))
            
    let TextColor =
        Attributes.defineSimpleScalarWithEquality<Color>
            "TextColor"
            (fun _ newValue node ->
                let target = node.Target :?> FabulousLabel
                match newValue with
                | ValueNone -> target.TextColor <- null
                | ValueSome value -> target.TextColor <- value
                let res = (target :> ILabel).Handler
                res.UpdateValue("TextColor"))
             
[<AutoOpen>]
module LabelBuilders =
    type Fabulous.Maui.View with
        static member inline Label<'msg>(text: string) =
            WidgetBuilder<'msg, ILabel>(FabulousLabel.WidgetKey, FabulousLabel.Text.WithValue(text))
  
[<Extension>]
type LabelModifiers =
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ILabel>, value: Color) =
        this.AddScalar(FabulousLabel.TextColor.WithValue(value))
