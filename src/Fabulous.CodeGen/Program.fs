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
      loadAllAssembliesByReflection: seq<string> -> Assembly array
      tryGetAttachedPropertyByReflection: Assembly array -> string * string -> Models.ReflectionAttachedProperty option
      readBindingsFile: string -> Bindings
      isTypeResolvable: string -> bool
      convertTypeName: string -> string
      convertEventType: string option -> string
      tryGetStringRepresentationOfDefaultValue: obj -> string option }
    
module private Functions =
    let readBindingsFile path =
        path |> File.ReadAllText |> Json.deserialize<Bindings>
    
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
        readerData |> Text.writeOutputIfDebug program.debug "reader-data.json"
        
        let bindings = Binder.bind program.logger readerData overwriteData
        bindings |> Text.writeOutputIfDebug program.debug "bindings.json"
        
        let optimizedBindings = Optimizer.optimize bindings
        optimizedBindings |> Text.writeOutputIfDebug program.debug "optimized-bindings.json"
        
        let expandedBindings = Expander.expand readerData optimizedBindings
        expandedBindings |> Text.writeOutputIfDebug program.debug "expanded-bindings.json"
        
        CodeGenerator.generateCode expandedBindings
        |> File.write outputFile
    
module Program =
    let mkProgram loadAllAssembliesByReflection tryGetAttachedPropertyByReflection configuration logger =
        { debug = false
          configuration = configuration
          logger = logger
          loadAllAssembliesByReflection = loadAllAssembliesByReflection
          tryGetAttachedPropertyByReflection = tryGetAttachedPropertyByReflection
          readBindingsFile = Functions.readBindingsFile
          isTypeResolvable = (fun _ -> true)
          convertTypeName = Converters.convertTypeName
          convertEventType = Converters.convertEventType
          tryGetStringRepresentationOfDefaultValue = Converters.tryGetStringRepresentationOfDefaultValue }
        
    let withDebug debug program =
        { program with debug = debug }
        
    let withReadBindingsFile func program =
        { program with readBindingsFile = func }
        
    let withIsTypeResolvable func program =
        { program with isTypeResolvable = func }
        
    let withConvertTypeName func program =
        { program with convertTypeName = func }
        
    let withConvertEventType func program =
        { program with convertEventType = func }
        
    let withTryGetStringRepresentationOfDefaultValue func program =
        { program with tryGetStringRepresentationOfDefaultValue = func }
    
    let run bindingsFile outputFile program =
        Functions.runProgram program bindingsFile outputFile
        true // TODO: true if successful (no error)
