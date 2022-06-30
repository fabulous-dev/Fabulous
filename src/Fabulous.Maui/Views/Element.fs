namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Platform

type IElement = interface end

type FabulousLabel() =
    inherit Node()
    
    member val Text = "" with get, set
    
    interface Microsoft.Maui.ILabel with
        member this.Text = this.Text
        member this.Arrange(bounds) = failwith "todo"
        member this.Focus() = failwith "todo"
        member this.InvalidateArrange() = ViewExtensions.InvalidateMeasure(this, this)
        member this.InvalidateMeasure() = failwith "todo"
        member this.Measure(widthConstraint, heightConstraint) = failwith "todo"
        member this.Unfocus() = failwith "todo"
        member this.AnchorX = failwith "todo"
        member this.AnchorY = failwith "todo"
        member this.AutomationId = failwith "todo"
        member this.Background = failwith "todo"
        member this.CharacterSpacing = failwith "todo"
        member this.Clip = failwith "todo"
        member this.DesiredSize = failwith "todo"
        member this.FlowDirection = failwith "todo"
        member this.Font = failwith "todo"
        member this.Frame = failwith "todo"
        member this.Handler : IViewHandler = failwith "todo"
        member this.Handler : IElementHandler = failwith "todo"
        member this.Height = failwith "todo"
        member this.HorizontalLayoutAlignment = failwith "todo"
        member this.HorizontalTextAlignment = failwith "todo"
        member this.InputTransparent = failwith "todo"
        member this.IsEnabled = failwith "todo"
        member this.IsFocused = failwith "todo"
        member this.LineHeight = failwith "todo"
        member this.Margin = failwith "todo"
        member this.MaximumHeight = failwith "todo"
        member this.MaximumWidth = failwith "todo"
        member this.MinimumHeight = failwith "todo"
        member this.MinimumWidth = failwith "todo"
        member this.Opacity = failwith "todo"
        member this.Padding = failwith "todo"
        member this.Parent = failwith "todo"
        member this.Rotation = failwith "todo"
        member this.RotationX = failwith "todo"
        member this.RotationY = failwith "todo"
        member this.Scale = failwith "todo"
        member this.ScaleX = failwith "todo"
        member this.ScaleY = failwith "todo"
        member this.Semantics = failwith "todo"
        member this.Shadow = failwith "todo"
        member this.TextColor = failwith "todo"
        member this.TextDecorations = failwith "todo"
        member this.TranslationX = failwith "todo"
        member this.TranslationY = failwith "todo"
        member this.VerticalLayoutAlignment = failwith "todo"
        member this.VerticalTextAlignment = failwith "todo"
        member this.Visibility = failwith "todo"
        member this.Width = failwith "todo"
        member this.ZIndex = failwith "todo"
        member this.Frame with set value = failwith "todo"
        member this.Handler with set (value: IViewHandler) = failwith "todo"
        member this.Handler with set (value: IElementHandler) = failwith "todo"
        member this.IsFocused with set value = failwith "todo"
        
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
                let res = (target :> Microsoft.Maui.ILabel).Handler
                res.UpdateValue("Text"))
             
[<AutoOpen>]
module LabelBuilders =
    type Fabulous.Maui.View with
        static member inline Label<'msg>(text: string) =
            WidgetBuilder<'msg, ILabel>(FabulousLabel.WidgetKey, FabulousLabel.Text.WithValue(text))
  
[<Extension>]
type LabelModifiers =
    [<Extension>]
    static member  inline text(this: WidgetBuilder<'msg, #ILabel>, text: string) =
        this.AddScalar(FabulousLabel.Text.WithValue(text))
