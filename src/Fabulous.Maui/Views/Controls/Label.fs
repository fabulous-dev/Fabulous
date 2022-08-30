namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers
open Fabulous

module Label =
    let LineHeight = Attributes.defineMauiScalarWithEquality<float> "LineHeight"
    let TextDecorations = Attributes.defineMauiScalarWithEquality<TextDecorations> "TextDecorations"
    
    module Defaults =
        let [<Literal>] LineHeight = 1.
        let [<Literal>] TextDecorations = Microsoft.Maui.TextDecorations.None
        // Label has a vertical text alignment set to Start
        let [<Literal>] VerticalTextAlignment = TextAlignment.Start
    
type FabLabel(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabLabel>()
    static member WidgetKey = _widgetKey
    
    new() = FabLabel(LabelHandlerEx())
    
    interface IPadding with
        member this.Padding = this.GetScalar(Padding.Padding, Padding.Defaults.createDefaultPadding())
    
    interface IText with
        member this.Text = this.GetScalar(Text.Text, Text.Defaults.Text)
        
    interface ITextAlignment with
        member this.HorizontalTextAlignment = this.GetScalar(TextAlignment.HorizontalTextAlignment, TextAlignment.Defaults.HorizontalTextAlignment)
        member this.VerticalTextAlignment = this.GetScalar(TextAlignment.VerticalTextAlignment, Label.Defaults.VerticalTextAlignment)
        
    interface ITextStyle with
        member this.CharacterSpacing = this.GetScalar(TextStyle.CharacterSpacing, TextStyle.Defaults.CharacterSpacing)
        member this.Font = this.GetScalar(TextStyle.Font, TextStyle.Defaults.createDefaultFont())
        member this.TextColor = this.GetScalar(TextStyle.TextColor, TextStyle.Defaults.TextColor)
    
    interface ILabel with
        member this.LineHeight = this.GetScalar(Label.LineHeight, Label.Defaults.LineHeight)
        member this.TextDecorations = this.GetScalar(Label.TextDecorations, Label.Defaults.TextDecorations)
    
[<AutoOpen>]
module LabelBuilders =
    type Fabulous.Maui.View with
        static member inline Label<'msg>(text: string) =
            WidgetBuilder<'msg, ILabel>(FabLabel.WidgetKey, Text.Text.WithValue(text))

[<Extension>]
type LabelModifiers =
    [<Extension>]
    static member inline lineHeight(this: WidgetBuilder<'msg, #ILabel>, value: float) =
        this.AddScalar(Label.LineHeight.WithValue(value))
        
    [<Extension>]
    static member inline textDecorations(this: WidgetBuilder<'msg, #ILabel>, value: TextDecorations) =
        this.AddScalar(Label.TextDecorations.WithValue(value))