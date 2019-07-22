namespace Fabulous.XamarinForms.Generator

open System.IO
open CommandLine
open Fabulous.CodeGen.AssemblyReader
open Fabulous.CodeGen.Models
    
module Entry =
    
    type Options = {
        [<Option('a', "assembly", Required = true, HelpText = "Assemblies to read")>] Assemblies: seq<string>
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
            let cecilAssemblies = AssemblyResolver.loadAllAssemblies options.Assemblies
            let assemblies = Reflection.loadAllAssemblies options.Assemblies
            
            let allTypes = Resolver.getAllTypesFromAssemblies cecilAssemblies
            let allTypesDerivingFromBaseType = Resolver.getAllTypesDerivingFromBaseType Converters.shouldIgnoreType allTypes baseTypeName
            
            let tryGetProperty = Reflection.tryGetProperty assemblies
            
            let bindings =
                allTypesDerivingFromBaseType
                |> Array.map (fun tdef ->
                    { Name = tdef.FullName
                      Events = Extraction.readEventsFromType tdef
                      AttachedProperties = Extraction.readAttachedPropertiesFromType Converters.convertTypeName Converters.getStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef
                      Properties = Extraction.readPropertiesFromType Converters.convertTypeName Converters.getStringRepresentationOfDefaultValue tryGetProperty propertyBaseType tdef }
                )

            let json = Newtonsoft.Json.JsonConvert.SerializeObject(bindings)
            File.WriteAllText ("bindings.json", json)
            
            0
            
            