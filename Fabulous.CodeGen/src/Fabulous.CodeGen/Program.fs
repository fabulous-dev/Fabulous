// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen

open System.IO
open System.Reflection
open Fabulous.CodeGen
open Fabulous.CodeGen.AssemblyReader
open Fabulous.CodeGen.AssemblyReader.Models
open Fabulous.CodeGen.Binder
open Fabulous.CodeGen.Binder.Models
open Fabulous.CodeGen.Generator
open Fabulous.CodeGen.Models
open Fabulous.CodeGen.Generator.Models

type Configuration =
    { /// The base type full name from which all UI controls inherit from (e.g. Xamarin.Forms.Element)
      baseTypeName: string
      
      /// The type full name of the object used for properties declared with a bindable/dependency property (e.g. Xamarin.Forms.BindableProperty)
      propertyBaseType: string }
    
type ReadAssembliesConfiguration =
    { loadAllAssembliesByReflection: seq<string> -> Assembly array
      tryGetAttachedPropertyByReflection: Assembly array -> string * string -> Models.ReflectionAttachedProperty option
      isTypeResolvable: string -> bool
      convertTypeName: string -> string
      tryGetStringRepresentationOfDefaultValue: obj -> string option }
    
type GeneratorConfiguration =
    { prepareData: BoundModel -> GeneratorData
      generateForAttributes: GeneratorData -> string
      generateForBuilders: GeneratorData -> string }
    
type WorkflowConfiguration =
    { loadMappings: string -> WorkflowResult<Mapping * Mapping array option>
      readAssemblies: Configuration -> ReadAssembliesConfiguration -> string array -> WorkflowResult<AssemblyType array>
      bind: AssemblyType array -> (Mapping * Mapping array option) -> WorkflowResult<BoundModel>
      optimize: BoundModel -> WorkflowResult<BoundModel>
      expand: AssemblyType array -> BoundModel -> WorkflowResult<BoundModel>
      generateCode: GeneratorConfiguration -> BoundModel -> WorkflowResult<string * string> }

type Program =
    { Debug: bool
      Configuration: Configuration
      Workflow: WorkflowConfiguration
      ReadAssembliesConfiguration: ReadAssembliesConfiguration
      GeneratorConfiguration: GeneratorConfiguration }
    
module private Functions =
    let readMappingFile path =
        let _knownPaths = System.Collections.Generic.List<string>()
        
        let rec read path =
            if _knownPaths.Contains(path) then
                None
            else
                _knownPaths.Add(path)
                
                let mainMapping = path |> File.ReadAllText |> Json.deserialize<Mapping>
                let baseMappings =
                     mainMapping.BaseMappingFiles
                     |> Option.map (fun paths ->
                         paths
                         |> Array.map read
                         |> Array.choose (Option.map (fun (m, b) -> match b with None -> [|m|] | Some bs -> Array.append [|m|] bs))
                         |> Array.collect id
                     )
                
                Some (mainMapping, baseMappings)
        
        match read path with
        | None -> WorkflowResult.error ["Invalid mapping file path"]
        | Some res -> WorkflowResult.ok res
    
    let readAssemblies configuration readAssembliesConfiguration assemblies =
        Reader.readAssemblies
            readAssembliesConfiguration.loadAllAssembliesByReflection
            readAssembliesConfiguration.tryGetAttachedPropertyByReflection
            readAssembliesConfiguration.isTypeResolvable
            readAssembliesConfiguration.convertTypeName
            readAssembliesConfiguration.tryGetStringRepresentationOfDefaultValue
            configuration.propertyBaseType
            configuration.baseTypeName
            assemblies
    
    let generateCode configuration bindings =
        CodeGenerator.generateCode
            configuration.prepareData
            configuration.generateForAttributes
            configuration.generateForBuilders
            bindings
    
    let runProgram program mappingFile attributesOutputFile buildersOutputFile =        
        let readAssemblies (mapping: Mapping, baseMappings) =
            program.Workflow.readAssemblies program.Configuration program.ReadAssembliesConfiguration mapping.Assemblies
            |> WorkflowResult.debug program.Debug "1-assembly-types.json"
            |> WorkflowResult.map (fun x -> (x, (mapping, baseMappings)))
            
        let bind (assemblyTypes, mapping) =
            program.Workflow.bind assemblyTypes mapping
            |> WorkflowResult.debug program.Debug "2-bound-model.json"
            |> WorkflowResult.map (fun x -> (x, assemblyTypes))
            
        let optimize (boundModel, readerData) =
            program.Workflow.optimize boundModel
            |> WorkflowResult.debug program.Debug "3-optimized-bound-model.json"
            |> WorkflowResult.map (fun x -> (x, readerData))
            
        let expand (boundModel, readerData) =
            program.Workflow.expand readerData boundModel
            |> WorkflowResult.debug program.Debug "4-expanded-bound-model.json"
            
        let generateCode boundModel =
            program.Workflow.generateCode program.GeneratorConfiguration boundModel
            
        let write attributesOutputFile buildersOutputFile (attributesGeneratedCode, buildersGeneratedCode) =
            File.WriteAllText(attributesOutputFile, attributesGeneratedCode)
            File.WriteAllText(buildersOutputFile, buildersGeneratedCode)
        
        program.Workflow.loadMappings mappingFile
        |> WorkflowResult.bind readAssemblies
        |> WorkflowResult.bind bind
        |> WorkflowResult.bind optimize
        |> WorkflowResult.bind expand
        |> WorkflowResult.bind generateCode
        |> WorkflowResult.tie (write attributesOutputFile buildersOutputFile)
        |> WorkflowResult.toProgramResult
    
module Program =
    let mkProgram loadAllAssembliesByReflection tryGetAttachedPropertyByReflection configuration =
        { Debug = false
          Configuration = configuration
          Workflow =
              { loadMappings = Functions.readMappingFile
                readAssemblies = Functions.readAssemblies
                bind = Binder.bind
                optimize = Optimizer.optimize
                expand = Expander.expand
                generateCode = Functions.generateCode }
          ReadAssembliesConfiguration =
              { loadAllAssembliesByReflection = loadAllAssembliesByReflection
                tryGetAttachedPropertyByReflection = tryGetAttachedPropertyByReflection
                isTypeResolvable = (fun _ -> true)
                convertTypeName = Converters.convertTypeName
                tryGetStringRepresentationOfDefaultValue = Converters.tryGetStringRepresentationOfDefaultValue }
          GeneratorConfiguration =
              { prepareData = Preparer.prepareData
                generateForAttributes = CodeGenerator.generateCodeForAttributes
                generateForBuilders = CodeGenerator.generateCodeForBuilders } }
        
    let withDebug debug program =
        { program with Debug = debug }
        
    let withWorkflow func program =
        { program with Workflow = func program.Workflow }
        
    let withReadAssembliesConfiguration func program =
        { program with ReadAssembliesConfiguration = func program.ReadAssembliesConfiguration }
        
    let withGeneratorConfiguration func program =
        { program with GeneratorConfiguration = func program.GeneratorConfiguration }
    
    let run bindingsFile attributesOutputFile buildersOutputFile program =
        Functions.runProgram program bindingsFile attributesOutputFile buildersOutputFile
