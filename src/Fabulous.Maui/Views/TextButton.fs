namespace Fabulous.Maui

open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers
open Fabulous

module TextButton =
    type FabulousTextButton(handler: IButtonHandler) =
        inherit Button.FabulousButton(handler)
        
        new() = FabulousTextButton(ButtonHandler())
        
        interface ITextButton with
            member this.CharacterSpacing = this.GetScalar(TextStyle.CharacterSpacing, 0)
            member this.Font = this.GetScalar(TextStyle.Font, Microsoft.Maui.Font.Default)
            member this.Text = this.GetScalar(Text.Text, "")
            member this.TextColor = this.GetScalar(TextStyle.TextColor, Colors.Black)

    let WidgetKey = Widgets.register<FabulousTextButton>()
    
[<AutoOpen>]
module TextButtonBuilders =
    type Fabulous.Maui.View with
        static member inline TextButton<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, ITextButton>(
                TextButton.WidgetKey,
                Text.Text.WithValue(text),
                Button.Clicked.WithValue(fun () -> box onClicked)
            )