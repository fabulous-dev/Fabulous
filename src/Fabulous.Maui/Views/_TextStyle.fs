namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Graphics
open Fabulous

module TextStyle =
    let CharacterSpacing = Attributes.defineMauiScalarWithEquality<float> "CharacterSpacing"
    let Font = Attributes.defineMauiScalarWithEquality<Microsoft.Maui.Font> "Font"
    let TextColor = Attributes.defineMauiScalarWithEquality<Color> "TextColor"
    
[<Extension>]
type TextStyleModifiers =
    [<Extension>]
    static member inline characterSpacing(this: WidgetBuilder<'msg, #ITextStyle>, value: float) =
        this.AddScalar(TextStyle.CharacterSpacing.WithValue(value))
        
    [<Extension>]
    static member inline font(this: WidgetBuilder<'msg, #ITextStyle>, value: Microsoft.Maui.Font) =
        this.AddScalar(TextStyle.Font.WithValue(value))
        
    [<Extension>]
    static member inline textColor(this: WidgetBuilder<'msg, #ITextStyle>, value: Color) =
        this.AddScalar(TextStyle.TextColor.WithValue(value))