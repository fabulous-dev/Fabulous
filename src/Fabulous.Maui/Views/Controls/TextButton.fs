namespace Fabulous.Maui

open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers
open Fabulous

type FabTextButton(handler: IButtonHandler) =
    inherit FabButton(handler)
    
    static let _widgetKey = Widgets.register<FabTextButton>()
    static member WidgetKey = _widgetKey
    
    new() = FabTextButton(ButtonHandler())
    
    interface IText with
        member this.Text = this.GetScalar(Text.Text, Text.Defaults.Text)
        
    interface ITextStyle with
        member this.CharacterSpacing = this.GetScalar(TextStyle.CharacterSpacing, TextStyle.Defaults.CharacterSpacing)
        member this.Font = this.GetScalar(TextStyle.Font, TextStyle.Defaults.createDefaultFont())
        member this.TextColor = this.GetScalar(TextStyle.TextColor, TextStyle.Defaults.TextColor)
    
    interface ITextButton
    
[<AutoOpen>]
module TextButtonBuilders =
    type Fabulous.Maui.View with
        static member inline TextButton<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, ITextButton>(
                FabTextButton.WidgetKey,
                Text.Text.WithValue(text),
                Button.Clicked.WithValue(fun () -> box onClicked)
            )