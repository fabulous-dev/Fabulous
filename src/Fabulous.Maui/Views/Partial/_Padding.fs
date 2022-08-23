namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Fabulous
open Microsoft.Maui

module Padding =
    let Padding = Attributes.defineMauiScalarWithEquality<Thickness> "Padding"
    
    module Defaults =
        let inline createDefaultPadding () = Thickness.Zero

[<Extension>]
type PaddingModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IPadding>, value: Thickness) =
        this.AddScalar(Padding.Padding.WithValue(value))
        
[<Extension>]
type PaddingExtraModifiers =
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IPadding>, uniformSize: float) =
        this.AddScalar(Padding.Padding.WithValue(Thickness(uniformSize)))
        
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IPadding>, horizontalSize: float, verticalSize: float) =
        this.AddScalar(Padding.Padding.WithValue(Thickness(horizontalSize, verticalSize)))
        
    [<Extension>]
    static member inline padding(this: WidgetBuilder<'msg, #IPadding>, left: float, top: float, right: float, bottom: float) =
        this.AddScalar(Padding.Padding.WithValue(Thickness(left, top, right, bottom)))