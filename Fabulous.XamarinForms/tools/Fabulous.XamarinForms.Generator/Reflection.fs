// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.Generator

open System
open System.IO
open System.Runtime.Loader
open Fabulous.CodeGen
open Fabulous.CodeGen.AssemblyReader.Models
open Fabulous.XamarinForms.Generator.Helpers

module Reflection =    
    let loadAllAssemblies (paths: seq<string>) =
        let toFullPath p = Path.Combine(Environment.CurrentDirectory, p)
        
        paths
        |> Seq.map (toFullPath >> AssemblyLoadContext.Default.LoadFromAssemblyPath)
        |> Seq.toArray
    
    let tryGetPropertyInAssembly (assembly: System.Reflection.Assembly) (typeName, propertyName) =
        let toCleanTypeName propertyReturnType =
            propertyReturnType.ToString()
                              .Replace("[", "<")
                              .Replace("]", ">")
            |> Text.removeDotNetGenericNotation
        
        let typ = assembly.GetType(typeName)
        if typ = null then
            None
        else
            if typ.ContainsGenericParameters then
                None // Generic types are not supported
            else
                let propertyInfo = typ.GetField(propertyName + "Property", Reflection.BindingFlags.Public ||| Reflection.BindingFlags.NonPublic ||| Reflection.BindingFlags.Static)
                if propertyInfo = null then
                    None
                else
                    let property = propertyInfo.GetValue(null) :?> Xamarin.Forms.BindableProperty
                    if property = null then
                        None
                    else
                        Some
                            { Name = propertyName
                              Type = property.ReturnType |> toCleanTypeName
                              DefaultValue = None } // DefaultValue here is not relevant since we will call ClearValue instead to reset the property
                            
    let tryGetProperty (assemblies: System.Reflection.Assembly array) (typeName, propertyName) =
        assemblies
        |> Array.tryPick (fun asm -> tryGetPropertyInAssembly asm (typeName, propertyName))