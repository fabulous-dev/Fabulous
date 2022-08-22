namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Microsoft.Maui.Handlers
open Fabulous

#if __IOS__
// Workaround for https://github.com/dotnet/maui/issues/5835#issuecomment-1221263083
type CustomLabelHandler() =
    inherit LabelHandler()
    
    override this.CreatePlatformView() =
        let label = base.CreatePlatformView()
        label.Lines <- nativeint 0
        label
        
type LabelHandler = CustomLabelHandler
#endif

module Label =
    let LineHeight = Attributes.defineMauiScalarWithEquality<float> "LineHeight"
    let TextDecorations = Attributes.defineMauiScalarWithEquality<TextDecorations> "TextDecorations"
    
type FabLabel(handler: IViewHandler) =
    inherit FabView(handler)
    
    static let _widgetKey = Widgets.register<FabLabel>()
    static member WidgetKey = _widgetKey
    
    new() = FabLabel(LabelHandler())
    
    interface ILabel with
        member this.CharacterSpacing = this.GetScalar(TextStyle.CharacterSpacing, 1.)
        member this.Font = this.GetScalar(TextStyle.Font, Microsoft.Maui.Font.Default)
        member this.HorizontalTextAlignment = this.GetScalar(TextAlignment.HorizontalTextAlignment, TextAlignment.Start)
        member this.LineHeight = this.GetScalar(Label.LineHeight, 1.)
        member this.Padding = this.GetScalar(Padding.Padding, Thickness.Zero)
        member this.Text = this.GetScalar(Text.Text, "")
        member this.TextColor = this.GetScalar(TextStyle.TextColor, null)
        member this.TextDecorations = this.GetScalar(Label.TextDecorations, TextDecorations.None)
        member this.VerticalTextAlignment = this.GetScalar(TextAlignment.VerticalTextAlignment, TextAlignment.Start)
    
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