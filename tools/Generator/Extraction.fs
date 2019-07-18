namespace Fabulous.Generator

open Resolver
open Models
open Helpers
open Reflection
open Mono.Cecil

module Extraction =
    let convertKnownType typeName =
        match typeName with
        | "System.Int32" -> "int"
        | "System.Double" -> "float"
        | "System.String" -> "string"
        | "System.Boolean" -> "bool"
        | "System.UInt32" -> "uint32"
        | "System.Object" -> "object"
        | "Xamarin.Forms.Grid/IGridList`1<Xamarin.Forms.View>" -> "ViewElement list"
        | _ -> typeName
        
    let convertKnownDefaultValue defaultValue =
        match defaultValue with
        | "[Color: A=-1, R=-1, G=-1, B=-1, Hue=-1, Saturation=-1, Luminosity=-1]"
        | "[Color: A=0, R=0, G=0, B=0, Hue=0, Saturation=0, Luminosity=0]" -> "Xamarin.Forms.Colors.Default"
        | _ -> defaultValue
    
    let readEventsFromType (``type``: TypeDefinition) =
        getAllEventsForType ``type``
        |> Array.map (fun edef ->
            { Name = edef.Name
              Type =
                  match edef.EventType with
                  | :? GenericInstanceType as git -> git.FullName |> removeText "`1"
                  | _ -> "System.EventHandler"
              EventArgsType =
                  match edef.EventType with
                  | :? GenericInstanceType as git -> git.GenericArguments.[0].FullName
                  | _ -> "unit" }    
        )
        
    let readAttachedPropertiesFromType (assemblies: System.Reflection.Assembly array) propertyBaseType (``type``: TypeDefinition) =        
        getAllAttachedPropertiesForType propertyBaseType``type``
        |> Array.map (fun fdef ->
            assemblies
            |> Array.tryPick (fun asm -> tryGetProperty asm ``type``.FullName fdef.Name)
            |> Option.map (fun data ->
                { Name = data.Name
                  Type = convertKnownType data.Type
                  DefaultValue = convertKnownDefaultValue data.DefaultValue } : AttachedPropertyBinding
            )
        )
        |> Array.choose id

    let readPropertiesFromType (assemblies: System.Reflection.Assembly array) propertyBaseType (``type``: TypeDefinition) =
        getAllPropertiesForType propertyBaseType``type``
        |> Array.map (fun fdef ->
            assemblies
            |> Array.tryPick (fun asm -> tryGetProperty asm ``type``.FullName fdef.Name)
            |> Option.map (fun data ->
                let propertyType = convertKnownType data.Type
                { Name = data.Name
                  Type = propertyType
                  DefaultValue = convertKnownDefaultValue data.DefaultValue } : PropertyBinding
            )
        )
        |> Array.choose id
