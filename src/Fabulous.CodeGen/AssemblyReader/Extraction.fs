namespace Fabulous.CodeGen.AssemblyReader

open Fabulous.CodeGen.AssemblyReader.Resolver
open Fabulous.CodeGen.Models
open Fabulous.CodeGen.Helpers
open Mono.Cecil

module Extraction =
    type ReflectedAttachedPropertyReaderData =
        { Name: string
          Type: string
          DefaultValue: obj }

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
                  | _ -> null }    
        )
        
    let readAttachedPropertiesFromType
            (convertTypeName: string -> string)
            (getStringRepresentationOfDefaultValue: obj -> string)
            (tryGetProperty: string * string -> ReflectedAttachedPropertyReaderData option)
            (propertyBaseType: string)
            (``type``: TypeDefinition) =
       
        getAllAttachedPropertiesForType propertyBaseType``type``
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

        getAllPropertiesForType propertyBaseType ``type``
        |> Array.map (fun fdef ->
            match tryGetProperty (``type``.FullName, fdef.Name) with
            | None -> None
            | Some data ->
                let propertyType = convertTypeName data.Type
                Some
                    ({ Name = data.Name
                       Type = propertyType
                       DefaultValue = getStringRepresentationOfDefaultValue data.DefaultValue } : PropertyReaderData)
        )
        |> Array.choose id
