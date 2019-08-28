namespace Fabulous.CodeGen

open System.IO
open System.Reflection
open Fabulous.CodeGen.AssemblyReader
open Fabulous.CodeGen.AssemblyReader.Models
open Fabulous.CodeGen.Models
open Fabulous.CodeGen.Helpers
open Fabulous.CodeGen.Binder
open Fabulous.CodeGen.Binder.Models
open Fabulous.CodeGen.Generator

type MainWorkflowConfiguration =
    { loadBindings: string -> WorkflowResult<Bindings>
      readAssemblies: Configuration -> ReadAssembliesConfiguration -> string array -> WorkflowResult<AssemblyType array>
      bind: AssemblyType array -> Bindings -> WorkflowResult<BoundModel>
      optimize: BoundModel -> WorkflowResult<BoundModel>
      expand: AssemblyType array -> BoundModel -> WorkflowResult<BoundModel>
      generateCode: BoundModel -> WorkflowResult<string> }
    
and ReadAssembliesConfiguration =
    { loadAllAssembliesByReflection: seq<string> -> Assembly array
      tryGetAttachedPropertyByReflection: Assembly array -> string * string -> Models.ReflectionAttachedProperty option
      isTypeResolvable: string -> bool
      convertTypeName: string -> string
      convertEventType: string option -> string
      tryGetStringRepresentationOfDefaultValue: obj -> string option }

and Program =
    { debug: bool
      configuration: Configuration
      mainWorkflow: MainWorkflowConfiguration
      readAssembliesConfiguration: ReadAssembliesConfiguration }
    
module private Functions =
    let readBindingsFile path =
        let bindings =
            path |> File.ReadAllText |> Json.deserialize<Bindings>
        Ok (bindings, [], [])
    
    let readAssemblies configuration readAssembliesConfiguration assemblies =
        let cecilAssemblies = AssemblyResolver.loadAllAssemblies assemblies
        let assemblies = readAssembliesConfiguration.loadAllAssembliesByReflection assemblies
        
        let allTypes = Resolver.getAllTypesFromAssemblies cecilAssemblies
        let allTypesDerivingFromBaseType = Resolver.getAllTypesDerivingFromBaseType readAssembliesConfiguration.isTypeResolvable allTypes configuration.baseTypeName
        
        let tryGetProperty = readAssembliesConfiguration.tryGetAttachedPropertyByReflection assemblies
        
        let data =
            allTypesDerivingFromBaseType
            |> Array.map
                   (Extractor.readType
                        readAssembliesConfiguration.convertTypeName
                        readAssembliesConfiguration.convertEventType
                        readAssembliesConfiguration.tryGetStringRepresentationOfDefaultValue
                        tryGetProperty
                        configuration.propertyBaseType
                        configuration.baseTypeName)
        
        Ok (data, [], [])
    
    let runProgram program bindingsFile outputFile =        
        let readAssemblies (bindings: Bindings) =
            program.mainWorkflow.readAssemblies program.configuration program.readAssembliesConfiguration bindings.Assemblies
            |> WorkflowResult.debug program.debug "reader-data.json"
            |> WorkflowResult.map (fun x -> (x, bindings))
            
        let bind (readerData, bindings) =
            program.mainWorkflow.bind readerData bindings
            |> WorkflowResult.debug program.debug "bindings.json"
            |> WorkflowResult.map (fun x -> (x, readerData))
            
        let optimize (boundModel, readerData) =
            program.mainWorkflow.optimize boundModel
            |> WorkflowResult.debug program.debug "optimized-bindings.json"
            |> WorkflowResult.map (fun x -> (x, readerData))
            
        let expand (boundModel, readerData) =
            program.mainWorkflow.expand readerData boundModel
            |> WorkflowResult.debug program.debug "expanded-bindings.json"
            
        let generateCode boundModel =
            program.mainWorkflow.generateCode boundModel
            
        let write outputFile generatedCode =
            File.write generatedCode outputFile
        
        program.mainWorkflow.loadBindings bindingsFile
        |> WorkflowResult.bind readAssemblies
        |> WorkflowResult.bind bind
        |> WorkflowResult.bind optimize
        |> WorkflowResult.bind expand
        |> WorkflowResult.bind generateCode
        |> WorkflowResult.tie (write outputFile)
        |> WorkflowResult.toProgramResult
    
module Program =
    let mkProgram loadAllAssembliesByReflection tryGetAttachedPropertyByReflection configuration =
        { debug = false
          configuration = configuration
          mainWorkflow =
              { loadBindings = Functions.readBindingsFile
                readAssemblies = Functions.readAssemblies
                bind = Binder.bind
                optimize = Optimizer.optimize
                expand = Expander.expand
                generateCode = CodeGenerator.generateCode }
          readAssembliesConfiguration =
              { loadAllAssembliesByReflection = loadAllAssembliesByReflection
                tryGetAttachedPropertyByReflection = tryGetAttachedPropertyByReflection
                isTypeResolvable = (fun _ -> true)
                convertTypeName = Converters.convertTypeName
                convertEventType = Converters.convertEventType
                tryGetStringRepresentationOfDefaultValue = Converters.tryGetStringRepresentationOfDefaultValue } }
        
    let withDebug debug program =
        { program with debug = debug }
        
    let withReadBindingsFile func program =
        { program with mainWorkflow = { program.mainWorkflow with loadBindings = func } }
        
    let withIsTypeResolvable func program =
        { program with readAssembliesConfiguration = { program.readAssembliesConfiguration with isTypeResolvable = func } }
        
    let withConvertTypeName func program =
        { program with readAssembliesConfiguration = { program.readAssembliesConfiguration with convertTypeName = func } }
        
    let withConvertEventType func program =
        { program with readAssembliesConfiguration = { program.readAssembliesConfiguration with convertEventType = func } }
        
    let withTryGetStringRepresentationOfDefaultValue func program =
        { program with readAssembliesConfiguration = { program.readAssembliesConfiguration with tryGetStringRepresentationOfDefaultValue = func } }
    
    let run bindingsFile outputFile program =
        Functions.runProgram program bindingsFile outputFile
