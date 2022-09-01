namespace Fabulous.Maui

open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Controls
open Fabulous

module Semantics =
    let Description = Attributes.defineBindableWithEquality<string> SemanticProperties.DescriptionProperty
    let Hint = Attributes.defineBindableWithEquality<string> SemanticProperties.HintProperty
    let HeadingLevel = Attributes.defineBindableWithEquality<SemanticHeadingLevel> SemanticProperties.HeadingLevelProperty

[<Extension>]
type SemanticsModifiers =
    [<Extension>]
    static member inline semantics(this: WidgetBuilder<'msg, #Fabulous.Maui.IView>, ?headingLevel: SemanticHeadingLevel, ?description: string, ?hint: string) =
        let this =
            match headingLevel with
            | None -> this
            | Some v -> this.AddScalar(Semantics.HeadingLevel.WithValue(v))
        
        let this =
            match description with
            | None -> this
            | Some v -> this.AddScalar(Semantics.Description.WithValue(v))
            
        let this =
            match hint with
            | None -> this
            | Some v -> this.AddScalar(Semantics.Hint.WithValue(v))
            
        this