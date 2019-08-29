namespace Fabulous.CodeGen.AssemblyReader

open System.Reflection
open Fabulous.CodeGen
open Fabulous.CodeGen.AssemblyReader.Models
open Mono.Cecil

module Reader =
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
                | :? GenericInstanceType as git -> git.FullName |> Text.removeText "`1"
                | _ -> "System.EventHandler"
            
            { Name = edef.Name
              Type = convertEventType eventArgsType
              EventHandlerType = eventHandlerType }    
        )
        
    let readAttachedPropertiesFromType
            (convertTypeName: string -> string)
            (tryGetStringRepresentationOfDefaultValue: obj -> string option)
            (tryGetProperty: string * string -> ReflectionAttachedProperty option)
            (propertyBaseType: string)
            (``type``: TypeDefinition) =
       
        Resolver.getAllAttachedPropertiesForType propertyBaseType ``type``
        |> Array.map (fun fdef ->
            match tryGetProperty (``type``.FullName, fdef.Name) with
            | None -> None
            | Some data ->
                let attachedPropertyType = convertTypeName data.Type
                let defaultValue = 
                    tryGetStringRepresentationOfDefaultValue data.DefaultValue
                    |> Option.defaultValue (sprintf "Unchecked.defaultof<%s>" attachedPropertyType)

                Some
                    ({ Name = data.Name
                       Type = attachedPropertyType
                       DefaultValue = defaultValue } : AssemblyTypeAttachedProperty)
        )
        |> Array.choose id

    let readPropertiesFromType
            (convertTypeName: string -> string)
            (tryGetStringRepresentationOfDefaultValue: obj -> string option)
            (tryGetProperty: string * string -> ReflectionAttachedProperty option)
            (propertyBaseType: string)
            (``type``: TypeDefinition) =

        let getDefaultValueAsString typeName (value: obj) =
            tryGetStringRepresentationOfDefaultValue value
            |> Option.defaultValue (sprintf "Unchecked.defaultof<%s>" typeName)

        let propertiesWithBindingFields =
            Resolver.getAllPropertiesWithBindingFieldForType propertyBaseType ``type``
            |> Array.map (fun tdef ->
                match tryGetProperty (``type``.FullName, tdef.Name) with
                | None -> None
                | Some data ->
                    let propertyType = convertTypeName data.Type

                    Some
                        ({ Name = data.Name
                           Type = propertyType
                           CollectionElementType = Resolver.getElementTypeForType ``type``
                           DefaultValue = getDefaultValueAsString propertyType data.DefaultValue } : AssemblyTypeProperty)
            )
            |> Array.choose id

        let listPropertiesWithNoSetter =
            Resolver.getAllListPropertiesWithNoSetterForType ``type``
            |> Array.map (fun pdef ->
                let propertyType = convertTypeName pdef.PropertyType.FullName

                { Name = pdef.Name
                  Type = propertyType
                  CollectionElementType = Resolver.getElementTypeForType ``type``
                  DefaultValue = getDefaultValueAsString propertyType null } : AssemblyTypeProperty
            )

        Array.concat [ propertiesWithBindingFields; listPropertiesWithNoSetter ]

    let readType
            (convertTypeName: string -> string)
            (convertEventType: string option -> string)
            (tryGetStringRepresentationOfDefaultValue: obj -> string option)
            (tryGetProperty: string * string -> ReflectionAttachedProperty option)
            (propertyBaseType: string)
            (baseTypeName: string)
            (tdef: TypeDefinition) =
        let ctor =
            tdef.Methods
             |> Seq.filter (fun x -> x.IsConstructor && x.IsPublic)
             |> Seq.sortBy (fun x -> x.Parameters.Count)
             |> Seq.tryHead
        
        { Name = tdef.FullName
          CanBeInstantiated = not tdef.IsAbstract && ctor.IsSome && ctor.Value.Parameters.Count = 0
          InheritanceHierarchy = Resolver.getHierarchyForType baseTypeName tdef 
          Events = readEventsFromType convertEventType tdef
          AttachedProperties = readAttachedPropertiesFromType convertTypeName tryGetStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef
          Properties = readPropertiesFromType convertTypeName tryGetStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef }
        
    let readAssemblies
        (loadAllAssembliesByReflection: seq<string> -> Assembly array)
        (tryGetAttachedPropertyByReflection: Assembly array -> string * string -> Models.ReflectionAttachedProperty option)
        (isTypeResolvable: string -> bool)
        (convertTypeName: string -> string)
        (convertEventType: string option -> string)
        (tryGetStringRepresentationOfDefaultValue: obj -> string option)
        (propertyBaseType: string)
        (baseTypeName: string)
        assemblies : WorkflowResult<AssemblyType array> =
        
        let cecilAssemblies = AssemblyResolver.loadAllAssemblies assemblies
        let assemblies = loadAllAssembliesByReflection assemblies
        
        let allTypes = Resolver.getAllTypesFromAssemblies cecilAssemblies
        let allTypesDerivingFromBaseType = Resolver.getAllTypesDerivingFromBaseType isTypeResolvable allTypes baseTypeName
        
        let tryGetProperty = tryGetAttachedPropertyByReflection assemblies
        
        let data =
            allTypesDerivingFromBaseType
            |> Array.map
                   (readType
                        convertTypeName
                        convertEventType
                        tryGetStringRepresentationOfDefaultValue
                        tryGetProperty
                        propertyBaseType
                        baseTypeName)
        
        WorkflowResult.ok data

