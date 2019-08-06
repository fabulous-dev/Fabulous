namespace Fabulous.CodeGen.AssemblyReader

open Fabulous.CodeGen.AssemblyReader.Models
open Fabulous.CodeGen.Helpers
open Mono.Cecil

module Extractor =
    let readEventsFromType
            (convertEventType: string option -> string)
            (``type``: TypeDefinition) =
        Resolver.getAllEventsForType ``type``
        |> Array.map (fun edef ->
            let eventArgsType =
                  match edef.EventType with
                  | :? GenericInstanceType as git -> Some git.GenericArguments.[0].FullName
                  | _ -> None
                  
            let eventHandlerType =
                match edef.EventType with
                | :? GenericInstanceType as git -> git.FullName |> removeText "`1"
                | _ -> "System.EventHandler"
            
            { Name = edef.Name
              Type = convertEventType eventArgsType
              EventHandlerType = eventHandlerType }    
        )
        
    let readAttachedPropertiesFromType
            (convertTypeName: string -> string)
            (getStringRepresentationOfDefaultValue: obj -> string)
            (tryGetProperty: string * string -> ReflectionAttachedProperty option)
            (propertyBaseType: string)
            (``type``: TypeDefinition) =
       
        Resolver.getAllAttachedPropertiesForType propertyBaseType ``type``
        |> Array.map (fun fdef ->
            match tryGetProperty (``type``.FullName, fdef.Name) with
            | None -> None
            | Some data ->
                Some
                    ({ Name = data.Name
                       Type = convertTypeName data.Type
                       DefaultValue = getStringRepresentationOfDefaultValue data.DefaultValue } : ReaderAttachedProperty)
        )
        |> Array.choose id

    let readPropertiesFromType
            (convertTypeName: string -> string)
            (getStringRepresentationOfDefaultValue: obj -> string)
            (tryGetProperty: string * string -> ReflectionAttachedProperty option)
            (propertyBaseType: string)
            (``type``: TypeDefinition) =

        Resolver.getAllPropertiesForType propertyBaseType ``type``
        |> Array.map (fun fdef ->
            match tryGetProperty (``type``.FullName, fdef.Name) with
            | None -> None
            | Some data ->
                Some
                    ({ Name = data.Name
                       Type = convertTypeName data.Type
                       ElementType = Resolver.getElementTypeForType ``type``
                       DefaultValue = getStringRepresentationOfDefaultValue data.DefaultValue } : ReaderProperty)
        )
        |> Array.choose id

    let readType
            (convertTypeName: string -> string)
            (convertEventType: string option -> string)
            (getStringRepresentationOfDefaultValue: obj -> string)
            (tryGetProperty: string * string -> ReflectionAttachedProperty option)
            (propertyBaseType: string)
            (baseTypeName: string)
            (tdef: TypeDefinition) =
        { Name = tdef.FullName
          InheritanceHierarchy = Resolver.getHierarchyForType baseTypeName tdef 
          Events = readEventsFromType convertEventType tdef
          AttachedProperties = readAttachedPropertiesFromType convertTypeName getStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef
          Properties = readPropertiesFromType convertTypeName getStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef }