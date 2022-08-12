namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui

module TextAlignment =
    let HorizontalTextAlignment = Attributes.defineMauiScalarWithEquality<TextAlignment> "HorizontalTextAlignment"
    let VerticalTextAlignment = Attributes.defineMauiScalarWithEquality<TextAlignment> "VerticalTextAlignment"

[<Extension>]
type TextAlignmentModifiers =
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #ITextAlignment>, value: TextAlignment) =
        this.AddScalar(TextAlignment.HorizontalTextAlignment.WithValue(value))
        
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #ITextAlignment>, value: TextAlignment) =
        this.AddScalar(TextAlignment.VerticalTextAlignment.WithValue(value))