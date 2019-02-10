// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Generator

open System
open System.IO
open Mono.Cecil
open Newtonsoft.Json
open Fabulous.Generator.Models
open Fabulous.Generator.AssemblyResolver
open Fabulous.Generator.Resolvers
open Fabulous.Generator.CodeGenerator

module Generator =
    [<EntryPoint>]
    let Main(args : string []) =
        try
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
