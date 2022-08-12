﻿namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers
open Fabulous

module Label =
    let rec LineHeight = Attributes.defineMauiScalarWithEquality<float> "LineHeight"
    let rec TextDecorations = Attributes.defineMauiScalarWithEquality<TextDecorations> "TextDecorations"
    
    type FabulousLabel(handler) =
        inherit View'.FabulousView(handler)
        
        new() = FabulousLabel(LabelHandler())
        
        interface ILabel with
            member this.CharacterSpacing = this.GetScalar(TextStyle.CharacterSpacing, 1.)
            member this.Font = this.GetScalar(TextStyle.Font, Microsoft.Maui.Font.Default)
            member this.HorizontalTextAlignment = this.GetScalar(TextAlignment.HorizontalTextAlignment, TextAlignment.Start)
            member this.LineHeight = this.GetScalar(LineHeight, 1.)
            member this.Padding = this.GetScalar(Padding.Padding, Thickness.Zero)
            member this.Text = this.GetScalar(Text.Text, "")
            member this.TextColor = this.GetScalar(TextStyle.TextColor, Colors.Black)
            member this.TextDecorations = this.GetScalar(TextDecorations, Microsoft.Maui.TextDecorations.None)
            member this.VerticalTextAlignment = this.GetScalar(TextAlignment.VerticalTextAlignment, TextAlignment.Start)
            
    let WidgetKey = Widgets.register<FabulousLabel>()
    
[<AutoOpen>]
module LabelBuilders =
    type Fabulous.Maui.View with
        static member inline Label<'msg>(text: string) =
            WidgetBuilder<'msg, ILabel>(Label.WidgetKey, Text.Text.WithValue(text))

[<Extension>]
type LabelModifiers =
    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #ILabel>, value: float) =
        this.AddScalar(Label.LineHeight.WithValue(value))
        
    [<Extension>]
    static member inline textDecorations(this: WidgetBuilder<'msg, #ILabel>, value: TextDecorations) =
        this.AddScalar(Label.TextDecorations.WithValue(value))