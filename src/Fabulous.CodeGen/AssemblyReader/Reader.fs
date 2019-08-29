namespace Fabulous.CodeGen.AssemblyReader

open System.Reflection
open Fabulous.CodeGen.Models
open Fabulous.CodeGen.Helpers
open Fabulous.CodeGen.AssemblyReader.Models

module Reader =
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
                       (Extractor.readType
                            convertTypeName
                            convertEventType
                            tryGetStringRepresentationOfDefaultValue
                            tryGetProperty
                            propertyBaseType
                            baseTypeName)
            
            WorkflowResult.ok data

