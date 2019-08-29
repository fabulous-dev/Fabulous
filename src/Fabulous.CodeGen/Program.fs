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
      convertEventType: string option -> string
      tryGetStringRepresentationOfDefaultValue: obj -> string option }
    
type WorkflowConfiguration =
    { loadBindings: string -> WorkflowResult<Bindings>
      readAssemblies: Configuration -> ReadAssembliesConfiguration -> string array -> WorkflowResult<AssemblyType array>
      bind: AssemblyType array -> Bindings -> WorkflowResult<BoundModel>
      optimize: BoundModel -> WorkflowResult<BoundModel>
      expand: AssemblyType array -> BoundModel -> WorkflowResult<BoundModel>
      generateCode: BoundModel -> WorkflowResult<string> }

type Program =
    { debug: bool
      configuration: Configuration
      workflow: WorkflowConfiguration
      readAssembliesConfiguration: ReadAssembliesConfiguration }
    
module private Functions =
    let readBindingsFile path =
        let bindings =
            path |> File.ReadAllText |> Json.deserialize<Bindings>
        WorkflowResult.ok bindings
    
    let readAssemblies configuration readAssembliesConfiguration assemblies =
        Reader.readAssemblies
            readAssembliesConfiguration.loadAllAssembliesByReflection
            readAssembliesConfiguration.tryGetAttachedPropertyByReflection
            readAssembliesConfiguration.isTypeResolvable
            readAssembliesConfiguration.convertTypeName
            readAssembliesConfiguration.convertEventType
            readAssembliesConfiguration.tryGetStringRepresentationOfDefaultValue
            configuration.propertyBaseType
            configuration.baseTypeName
            assemblies
    
    let runProgram program bindingsFile outputFile =        
        let readAssemblies (bindings: Bindings) =
            program.workflow.readAssemblies program.configuration program.readAssembliesConfiguration bindings.Assemblies
            |> WorkflowResult.debug program.debug "reader-data.json"
            |> WorkflowResult.map (fun x -> (x, bindings))
            
        let bind (readerData, bindings) =
            program.workflow.bind readerData bindings
            |> WorkflowResult.debug program.debug "bindings.json"
            |> WorkflowResult.map (fun x -> (x, readerData))
            
        let optimize (boundModel, readerData) =
            program.workflow.optimize boundModel
            |> WorkflowResult.debug program.debug "optimized-bindings.json"
            |> WorkflowResult.map (fun x -> (x, readerData))
            
        let expand (boundModel, readerData) =
            program.workflow.expand readerData boundModel
            |> WorkflowResult.debug program.debug "expanded-bindings.json"
            
        let generateCode boundModel =
            program.workflow.generateCode boundModel
            
        let write outputFile generatedCode =
            File.write generatedCode outputFile
        
        program.workflow.loadBindings bindingsFile
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
          workflow =
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
        { program with workflow = { program.workflow with loadBindings = func } }
        
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
