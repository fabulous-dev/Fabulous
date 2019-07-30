namespace Fabulous.XamarinForms.Generator

open System.Diagnostics
open System.Diagnostics
open System.IO
open CommandLine
open Fabulous.CodeGen.AssemblyReader
open Fabulous.CodeGen.Binder
open Fabulous.CodeGen.Generator
open Fabulous.CodeGen.Helpers
open Fabulous.CodeGen.Models
open Newtonsoft.Json

module Json =
    let jsonSettings =
        let settings = JsonSerializerSettings()
        settings.Formatting <- Formatting.Indented
        settings.Converters.Add(Microsoft.FSharpLu.Json.CompactUnionJsonConverter())
        settings
        
    let serialize obj = JsonConvert.SerializeObject(obj, jsonSettings)
    let deserialize<'a> str = JsonConvert.DeserializeObject<'a>(str, jsonSettings)
    
module File =
    let write path content = File.WriteAllText(path, content)
    
module Entry =
    
    let baseTypeName = "Xamarin.Forms.Element"
    let propertyBaseType = "Xamarin.Forms.BindableProperty"
    
    type Options = {
        [<Option('m', "Mapping file", Required = true, HelpText = "Mapping file")>] MappingFile: string
        [<Option('o', "Output file", Required = true, HelpText = "Output file")>] OutputFile: string
        [<Option('d', "Debug", Required = false, HelpText = "Debug")>] Debug: bool
    }
    
    let tryReadOptions args =
        let options = CommandLine.Parser.Default.ParseArguments<Options>(args)
        match options with
        | :? Parsed<Options> as parsedOptions -> Some (parsedOptions.Value)
        | _ -> None
        
    let getReaderData assemblies =
        let cecilAssemblies = AssemblyResolver.loadAllAssemblies assemblies
        let assemblies = Reflection.loadAllAssemblies assemblies
        
        let allTypes = Resolver.getAllTypesFromAssemblies cecilAssemblies
        let allTypesDerivingFromBaseType = Resolver.getAllTypesDerivingFromBaseType XFConverters.shouldIgnoreType allTypes baseTypeName
        
        let tryGetProperty = Reflection.tryGetProperty assemblies
        
        allTypesDerivingFromBaseType
        |> Array.map (fun tdef ->
            { Name = tdef.FullName
              Events = Extraction.readEventsFromType tdef
              AttachedProperties = Extraction.readAttachedPropertiesFromType XFConverters.convertTypeName XFConverters.getStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef
              Properties = Extraction.readPropertiesFromType XFConverters.convertTypeName XFConverters.getStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef }
        )
        
    let writeOutputIfDebug debug path data =
        if debug then Json.serialize data |> File.write path
        
    let logger =
        { traceInformation = Trace.TraceInformation
          traceWarning = Trace.TraceWarning
          traceError = Trace.TraceError }

    [<EntryPoint>]
    let main args =
        use consoleOutput = System.Console.OpenStandardOutput()
        use traceListener = new TextWriterTraceListener(consoleOutput)
        Trace.Listeners.Add(traceListener) |> ignore
        
        match tryReadOptions args with
        | None -> 1 // Exit because no argument
        | Some options ->
            let overwriteData = options.MappingFile |> File.ReadAllText |> Json.deserialize<OverwriteData>
            
            let readerData = getReaderData overwriteData.Assemblies
            readerData |> writeOutputIfDebug options.Debug "reader-data.json"
            
            let bindings = Binder.bind logger readerData overwriteData
            bindings |> writeOutputIfDebug options.Debug "bindings.json"
            
            let optimizedBindings = Optimizer.optimizeKnownTypes bindings
            optimizedBindings |> writeOutputIfDebug options.Debug "optimized-bindings.json"
            
            CodeGenerator.generateCode optimizedBindings
            |> File.write options.OutputFile
            
            0