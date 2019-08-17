namespace Fabulous.CodeGen

open Models
open System.IO
open System.Reflection
open Fabulous.CodeGen.AssemblyReader
open Fabulous.CodeGen.Helpers
open Fabulous.CodeGen.Binder
open Fabulous.CodeGen.Generator

type Program =
    { debug: bool
      configuration: Configuration
      logger: Logger
      readBindingsFile: string -> OverwriteData
      loadAllAssembliesByReflection: seq<string> -> Assembly[]
      tryGetAttachedPropertyByReflection: Assembly[] -> string * string -> Models.ReflectionAttachedProperty option
      isTypeResolvable: string -> bool
      convertTypeName: string -> string
      convertEventType: string option -> string
      tryGetStringRepresentationOfDefaultValue: obj -> string option }
    
module private Functions =
    let readBindingsFile path =
        path |> File.ReadAllText |> Json.deserialize<OverwriteData>
    
    let getReaderData program assemblies =
        let cecilAssemblies = AssemblyResolver.loadAllAssemblies assemblies
        let assemblies = program.loadAllAssembliesByReflection assemblies
        
        let allTypes = Resolver.getAllTypesFromAssemblies cecilAssemblies
        let allTypesDerivingFromBaseType = Resolver.getAllTypesDerivingFromBaseType program.isTypeResolvable allTypes program.configuration.baseTypeName
        
        let tryGetProperty = program.tryGetAttachedPropertyByReflection assemblies
        
        allTypesDerivingFromBaseType
        |> Array.map (Extractor.readType program.convertTypeName program.convertEventType program.tryGetStringRepresentationOfDefaultValue tryGetProperty program.configuration.propertyBaseType program.configuration.baseTypeName)
    
    let runProgram program bindingsFile outputFile =
        let overwriteData = program.readBindingsFile bindingsFile
        
        let readerData = getReaderData program overwriteData.Assemblies
        readerData |> writeOutputIfDebug program.debug "reader-data.json"
        
        let bindings = Binder.bind program.logger program.configuration.baseTargetTypeForAttachedProperties readerData overwriteData
        bindings |> writeOutputIfDebug program.debug "bindings.json"
        
        let optimizedBindings = Optimizer.optimize bindings
        optimizedBindings |> writeOutputIfDebug program.debug "optimized-bindings.json"
        
        let expandedBindings = Expander.expand readerData optimizedBindings
        expandedBindings |> writeOutputIfDebug program.debug "expanded-bindings.json"
        
        CodeGenerator.generateCode expandedBindings
        |> File.write outputFile
    
module Program =
    let mkProgram loadAllAssembliesByReflection tryGetAttachedPropertyByReflection configuration logger =
        { debug = false
          configuration = configuration
          logger = logger
          readBindingsFile = Functions.readBindingsFile
          loadAllAssembliesByReflection = loadAllAssembliesByReflection
          tryGetAttachedPropertyByReflection = tryGetAttachedPropertyByReflection
          isTypeResolvable = (fun _ -> true)
          convertTypeName = Converters.convertTypeName
          convertEventType = Converters.convertEventType
          tryGetStringRepresentationOfDefaultValue = Converters.tryGetStringRepresentationOfDefaultValue }
        
    let withDebug debug program =
        { program with debug = debug }
        
    let withIsTypeResolvable func program =
        { program with isTypeResolvable = func }
    
    let run bindingsFile outputFile program =
        Functions.runProgram program bindingsFile outputFile
