namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui

module TextAlignment =
    let HorizontalTextAlignment = Attributes.defineMauiScalarWithEquality<TextAlignment> "HorizontalTextAlignment"
    let VerticalTextAlignment = Attributes.defineMauiScalarWithEquality<TextAlignment> "VerticalTextAlignment"
    
    module Defaults =
        let [<Literal>] HorizontalTextAlignment = TextAlignment.Start
        let [<Literal>] VerticalTextAlignment = TextAlignment.Center

[<Extension>]
type TextAlignmentModifiers =
    [<Extension>]
    static member inline horizontalTextAlignment(this: WidgetBuilder<'msg, #ITextAlignment>, value: TextAlignment) =
        this.AddScalar(TextAlignment.HorizontalTextAlignment.WithValue(value))
        
    [<Extension>]
    static member inline verticalTextAlignment(this: WidgetBuilder<'msg, #ITextAlignment>, value: TextAlignment) =
        this.AddScalar(TextAlignment.VerticalTextAlignment.WithValue(value))
       
[<Extension>]
type TextAlignmentExtraModifiers =
    [<Extension>]
    static member inline centerTextVertical(this: WidgetBuilder<'msg, #ITextAlignment>) =
        this.AddScalar(TextAlignment.VerticalTextAlignment.WithValue(TextAlignment.Center))
        
    [<Extension>]
    static member inline centerTextHorizontal(this: WidgetBuilder<'msg, #ITextAlignment>) =
        this.AddScalar(TextAlignment.HorizontalTextAlignment.WithValue(TextAlignment.Center))