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
    
    interface ITextButton with
        member this.CharacterSpacing = this.GetScalar(TextStyle.CharacterSpacing, 0)
        member this.Font = this.GetScalar(TextStyle.Font, Microsoft.Maui.Font.Default)
        member this.Text = this.GetScalar(Text.Text, "")
        member this.TextColor = this.GetScalar(TextStyle.TextColor, null)
    
[<AutoOpen>]
module TextButtonBuilders =
    type Fabulous.Maui.View with
        static member inline TextButton<'msg>(text: string, onClicked: 'msg) =
            WidgetBuilder<'msg, ITextButton>(
                FabTextButton.WidgetKey,
                Text.Text.WithValue(text),
                Button.Clicked.WithValue(fun () -> box onClicked)
            )