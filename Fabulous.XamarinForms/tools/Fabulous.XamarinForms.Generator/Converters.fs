namespace Fabulous.XamarinForms.Generator

open Mono.Cecil
open Fabulous.CodeGen.AssemblyReader

module Converters =
    let shouldIgnoreType (tdef: TypeDefinition) =
        match tdef.FullName with
        | "Xamarin.Forms.UriImageSource"
        | "Xamarin.Forms.ItemsView"
        | "Xamarin.Forms.ListItemsLayout" -> true
        | _ -> false
        
    let convertTypeName (typeName: string) =
        match typeName with
        | "Xamarin.Forms.Grid/IGridList`1<Xamarin.Forms.View>" -> "ViewElement list"
        | _ -> Converters.convertTypeName typeName
        
    let getStringRepresentationOfDefaultValue (defaultValue: obj) : string =
        match defaultValue with
        | :? string as str ->
            match str with
            | "[Color: A=-1, R=-1, G=-1, B=-1, Hue=-1, Saturation=-1, Luminosity=-1]"
            | "[Color: A=0, R=0, G=0, B=0, Hue=0, Saturation=0, Luminosity=0]" -> "Xamarin.Forms.Colors.Default"
            | _ -> str
        | :? System.TimeSpan as timeSpan when timeSpan = System.TimeSpan.Zero -> "System.TimeSpan.Zero"
        | _ -> Converters.getStringRepresentationOfDefaultValue defaultValue

