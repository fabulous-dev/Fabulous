namespace Fabulous.XamarinForms.Generator

open System
open System.IO
open System.Runtime.Loader
open Fabulous.CodeGen.Helpers
open Fabulous.CodeGen.AssemblyReader.Models

module Reflection =    
    let loadAllAssemblies (paths: seq<string>) =
        let toFullPath p = Path.Combine(Environment.CurrentDirectory, p)
        
        paths
        |> Seq.map (toFullPath >> AssemblyLoadContext.Default.LoadFromAssemblyPath)
        |> Seq.toArray
    
    let tryGetPropertyInAssembly (assembly: System.Reflection.Assembly) (typeName, propertyName) =
        nullable {
            let! ``type`` = assembly.GetType(typeName)
            match ``type``.ContainsGenericParameters with
            | true -> return None // Generic types are not supported
            | false ->
                let! propertyInfo = ``type``.GetField(propertyName)
                let! property = propertyInfo.GetValue(null)
                let propertyType = property.GetType()
                return
                    Some
                        { Name = propertyType.GetProperty("PropertyName").GetValue(property) :?> string
                          Type = (propertyType.GetProperty("ReturnType").GetValue(property) :?> Type).FullName
                          DefaultValue = propertyType.GetProperty("DefaultValue").GetValue(property) }
        }
                        
                            
    let tryGetProperty (assemblies: System.Reflection.Assembly array) (typeName, propertyName) =
        assemblies
        |> Array.tryPick (fun asm -> tryGetPropertyInAssembly asm (typeName, propertyName))