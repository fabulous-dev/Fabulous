namespace Fabulous.Generator

open System.IO
open CommandLine
open Resolver
open Extraction
open Models

module Entry =
    
    type Options = {
        [<Option('a', "assembly", Required = true, HelpText = "Assemblies to read")>] Assemblies: seq<string>
        [<Option('b', "baseType", Required = true, HelpText = "Base type that all controls inherit from")>] BaseTypeName: string
        [<Option('p', "propertyBaseType", Required = true, HelpText = "Base type for all properties")>] PropertyBaseType: string
    }
    
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
            
            let allTypes = getAllTypesFromAssemblies cecilAssemblies
            let allTypesDerivingFromBaseType = getAllTypesDerivingFromBaseType allTypes options.BaseTypeName
            
            let bindings =
                allTypesDerivingFromBaseType
                |> Array.map (fun tdef ->
                    { Name = tdef.FullName
                      Events = readEventsFromType tdef
                      AttachedProperties = readAttachedPropertiesFromType assemblies options.PropertyBaseType tdef
                      Properties = readPropertiesFromType assemblies options.PropertyBaseType tdef }
                )

            let json = Newtonsoft.Json.JsonConvert.SerializeObject(bindings)
            File.WriteAllText ("bindings.json", json)
            
            0
            
            