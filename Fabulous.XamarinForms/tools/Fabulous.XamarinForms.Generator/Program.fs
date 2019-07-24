namespace Fabulous.XamarinForms.Generator

open System.IO
open CommandLine
open Fabulous.CodeGen.AssemblyReader
open Fabulous.CodeGen.Models
open Fabulous.CodeGen.Generator
open Newtonsoft.Json

module Entry =
    
    type Options = {
        [<Option('b', "Bindings file", Required = true, HelpText = "Bindings file")>] BindingsFile: string
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
            let bindings =
                File.ReadAllText options.BindingsFile
                |> JsonConvert.DeserializeObject<Bindings>
            
            let cecilAssemblies = AssemblyResolver.loadAllAssemblies bindings.Assemblies
            let assemblies = Reflection.loadAllAssemblies bindings.Assemblies
            
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

            let json = CodeGenerator.generateCode bindings.OutputNamespace
            File.WriteAllText(options.OutputFile, json)
            0