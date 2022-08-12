namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui
open Microsoft.Maui.Graphics

module ButtonStroke =
    let CornerRadius = Attributes.defineMauiScalarWithEquality<int> "CornerRadius"
    let StrokeColor = Attributes.defineMauiScalarWithEquality<Color> "StrokeColor"
    let StrokeThickness = Attributes.defineMauiScalarWithEquality<float> "StrokeThickness"

[<Extension>]
type ButtonStrokeModifiers =
    [<Extension>]
    static member inline cornerRadius(this: WidgetBuilder<'msg, #IButtonStroke>, value: int) =
        this.AddScalar(ButtonStroke.CornerRadius.WithValue(value))
        
    [<Extension>]
    static member inline strokeColor(this: WidgetBuilder<'msg, #IButtonStroke>, value: Color) =
        this.AddScalar(ButtonStroke.StrokeColor.WithValue(value))
        
    [<Extension>]
    static member inline strokeThickness(this: WidgetBuilder<'msg, #IButtonStroke>, value: float) =
        this.AddScalar(ButtonStroke.StrokeThickness.WithValue(value))