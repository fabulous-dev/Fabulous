namespace Fabulous.CodeGen.AssemblyReader

open Fabulous.CodeGen.AssemblyReader.Models
open Fabulous.CodeGen.Helpers
open Mono.Cecil

module Extractor =
    let readEventsFromType (``type``: TypeDefinition) =
        Resolver.getAllEventsForType ``type``
        |> Array.map (fun edef ->
            { Name = edef.Name
              Type =
                  match edef.EventType with
                  | :? GenericInstanceType as git -> git.FullName |> removeText "`1"
                  | _ -> "System.EventHandler"
              EventArgsType =
                  match edef.EventType with
                  | :? GenericInstanceType as git -> git.GenericArguments.[0].FullName
                  | _ -> null }    
        )
        
    let readAttachedPropertiesFromType
            (convertTypeName: string -> string)
            (getStringRepresentationOfDefaultValue: obj -> string)
            (tryGetProperty: string * string -> ReflectedAttachedPropertyReaderData option)
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
                       DefaultValue = getStringRepresentationOfDefaultValue data.DefaultValue } : AttachedPropertyReaderData)
        )
        |> Array.choose id

    let readPropertiesFromType
            (convertTypeName: string -> string)
            (getStringRepresentationOfDefaultValue: obj -> string)
            (tryGetProperty: string * string -> ReflectedAttachedPropertyReaderData option)
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
                       DefaultValue = getStringRepresentationOfDefaultValue data.DefaultValue } : PropertyReaderData)
        )
        |> Array.choose id

    let readType
            (convertTypeName: string -> string)
            (getStringRepresentationOfDefaultValue: obj -> string)
            (tryGetProperty: string * string -> ReflectedAttachedPropertyReaderData option)
            (propertyBaseType: string)
            (baseTypeName: string)
            (tdef: TypeDefinition) =
        { Name = tdef.FullName
          InheritanceHierarchy = Resolver.getHierarchyForType baseTypeName tdef 
          Events = readEventsFromType tdef
          AttachedProperties = readAttachedPropertiesFromType convertTypeName getStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef
          Properties = readPropertiesFromType convertTypeName getStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef }