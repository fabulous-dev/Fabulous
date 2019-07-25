namespace Fabulous.XamarinForms.Generator

open System.IO
open CommandLine
open Fabulous.CodeGen.AssemblyReader
open Fabulous.CodeGen.Binder
open Fabulous.CodeGen.Models
open Fabulous.CodeGen.Generator
open Newtonsoft.Json

module Entry =
    
    type Options = {
        [<Option('m', "Mapping file", Required = true, HelpText = "Mapping file")>] MappingFile: string
        [<Option('o', "Output file", Required = true, HelpText = "Output file")>] OutputFile: string
    }
    
    let baseTypeName = "Xamarin.Forms.Element"
    let propertyBaseType = "Xamarin.Forms.BindableProperty"
    
    let tryReadOptions args =
        let options = CommandLine.Parser.Default.ParseArguments<Options>(args)
        match options with
        | :? Parsed<Options> as parsedOptions -> Some (parsedOptions.Value)
        | _ -> None
    
    [<EntryPoint>]
    let main args =
        match tryReadOptions args with
        | None -> 1 // Exit because no argument
        | Some options ->
            let settings = JsonSerializerSettings()
            settings.Formatting <- Formatting.Indented
            settings.Converters.Add(Microsoft.FSharpLu.Json.CompactUnionJsonConverter())
            
            let overwriteDataStr = File.ReadAllText options.MappingFile
            let overwriteData = JsonConvert.DeserializeObject<OverwriteData>(overwriteDataStr, settings)
            
            let cecilAssemblies = AssemblyResolver.loadAllAssemblies overwriteData.Assemblies
            let assemblies = Reflection.loadAllAssemblies overwriteData.Assemblies
            
            let allTypes = Resolver.getAllTypesFromAssemblies cecilAssemblies
            let allTypesDerivingFromBaseType = Resolver.getAllTypesDerivingFromBaseType XFConverters.shouldIgnoreType allTypes baseTypeName
            
            let tryGetProperty = Reflection.tryGetProperty assemblies
            
            let data =
                allTypesDerivingFromBaseType
                |> Array.map (fun tdef ->
                    { Name = tdef.FullName
                      Events = Extraction.readEventsFromType tdef
                      AttachedProperties = Extraction.readAttachedPropertiesFromType XFConverters.convertTypeName XFConverters.getStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef
                      Properties = Extraction.readPropertiesFromType XFConverters.convertTypeName XFConverters.getStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef }
                )
                
            let bindings = Binder.bind data overwriteData
            
            let json = JsonConvert.SerializeObject(bindings, settings)

            //let json = CodeGenerator.generateCode overwriteData.OutputNamespace
            File.WriteAllText(options.OutputFile, json)
            0