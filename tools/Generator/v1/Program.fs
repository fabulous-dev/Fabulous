// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Generator

open System
open System.IO
open System.Runtime.Loader
open Newtonsoft.Json
open Fabulous.Generator.Modelsv1
open Fabulous.Generator.AssemblyResolver
open Fabulous.Generator.Resolvers
open Fabulous.Generator.CodeGenerator

module Generator =
    let rec filterTypesDerivingFromBaseType (allTypes: Mono.Cecil.TypeDefinition list) baseTypeName =
        allTypes |> List.filter (fun tdef -> tdef.BaseType <> null && tdef.BaseType.FullName = baseTypeName)
        
    and findAllDerivingTypes (allTypes: Mono.Cecil.TypeDefinition list) (typesToCheck: Mono.Cecil.TypeDefinition list) (matchingTypes: Mono.Cecil.TypeDefinition list) =
        match typesToCheck with
        | [] -> matchingTypes
        | tdef::remainingTypesToCheck ->
            let derivingTypes = getAllTypesDerivingFrom allTypes tdef.FullName
            let newMatchingTypes = List.concat [ derivingTypes; (tdef::matchingTypes) ]
            findAllDerivingTypes allTypes remainingTypesToCheck newMatchingTypes 
    
    and getAllTypesDerivingFrom (allTypes: Mono.Cecil.TypeDefinition list) baseTypeName =
        let typesToCheck = filterTypesDerivingFromBaseType allTypes baseTypeName
        findAllDerivingTypes allTypes typesToCheck []
    
    let test () =
        let getAssemblyDefinition = loadAssembly (new RegistrableResolver())
        let assemblies = [ "packages/neutral/Xamarin.Forms/lib/netstandard2.0/Xamarin.Forms.Core.dll"; "build_output/Fabulous.XamarinForms/Fabulous.XamarinForms.Core/Fabulous.XamarinForms.Core.dll" ]
        let allTypes =
            [ for assembly in assemblies do
                let loadedAssembly = getAssemblyDefinition assembly
                for ``module`` in loadedAssembly.Modules do
                    for ``type`` in ``module``.Types do
                        yield ``type`` ]
            
        let derivingTypes = getAllTypesDerivingFrom allTypes "Xamarin.Forms.Element"
        let tdef = allTypes |> List.find (fun tdef -> tdef.FullName = "Xamarin.Forms.VisualElement")
        let events = tdef.Events
        
        let asm = AssemblyLoadContext.Default.LoadFromAssemblyPath("/Git/GitHub/Fabulous/packages/neutral/Xamarin.Forms/lib/netstandard2.0/Xamarin.Forms.Core.dll")
        let bindableProperty = asm.GetType("Xamarin.Forms.Grid")
                                  .GetField("RowProperty", Reflection.BindingFlags.Static ||| Reflection.BindingFlags.Public)
                                  .GetValue(null)
        let bindableProperty2 = asm.GetType("Xamarin.Forms.Grid")
                                  .GetField("RowSpacingProperty", Reflection.BindingFlags.Static ||| Reflection.BindingFlags.Public)
                                  .GetValue(null)
        
        let propertyName = bindableProperty.GetType().GetProperty("PropertyName").GetValue(bindableProperty)
        let defaultValue = bindableProperty.GetType().GetProperty("DefaultValue").GetValue(bindableProperty)
                                  
        let y = sprintf "Default value of %A is (%s) %A" propertyName (defaultValue.GetType().FullName) defaultValue
        
        Console.WriteLine y
        
        let propertyName2 = bindableProperty2.GetType().GetProperty("PropertyName").GetValue(bindableProperty)
        let defaultValue2 = bindableProperty2.GetType().GetProperty("DefaultValue").GetValue(bindableProperty)
                                  
        let z = sprintf "Default value of %A is (%s) %A" propertyName2 (defaultValue2.GetType().FullName) defaultValue2
        
        Console.WriteLine y
        
        let x = events |> Seq.iter (fun edef -> printfn "- Name = %A" edef.EventType)
        ()
    
    //[<EntryPoint>]
    //let Main(args : string []) =
    //    test ()
    //    0
        (*try
            if (args.Length < 2) then
                Console.Error.WriteLine ("usage: generator <bindingsPath> <outputPath>")
                Environment.Exit(1)

            let bindingsPath = args.[0]
            let outputPath = args.[1]
            let bindings = JsonConvert.DeserializeObject<Bindings> (File.ReadAllText(bindingsPath))
            let getAssemblyDefinition = loadAssembly (new RegistrableResolver())

            let assemblyDefinitions =
                bindings.Assemblies
                |> Seq.map getAssemblyDefinition
                |> Seq.toList

            match resolveTypes assemblyDefinitions bindings.Types with
            | Error errors ->
                errors |> List.iter System.Console.WriteLine
                1
            | Ok resolutions ->
                let (memberResolutions, warnings) = resolveMembers bindings.Types resolutions
                match warnings with
                | [] -> ()
                | _ -> warnings |> List.iter System.Console.WriteLine

                let code = generateCode (bindings, resolutions, memberResolutions)
                File.WriteAllText(outputPath, code)
                0
        with ex ->
            System.Console.WriteLine(ex)
            1
*)
