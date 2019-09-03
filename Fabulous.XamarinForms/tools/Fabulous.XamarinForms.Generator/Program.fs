namespace Fabulous.XamarinForms.Generator

open System.Diagnostics
open CommandLine
open Fabulous.CodeGen
    
module Program =
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
        
    let configuration =
        { baseTypeName = "Xamarin.Forms.BindableObject"
          propertyBaseType = "Xamarin.Forms.BindableProperty" }

    [<EntryPoint>]
    let main args =
        use consoleOutput = System.Console.OpenStandardOutput()
        use traceListener = new TextWriterTraceListener(consoleOutput)
        Trace.Listeners.Add(traceListener) |> ignore
        
        match tryReadOptions args with
        | None ->
            Trace.TraceError "Missing required arguments"
            1
        | Some options ->
            let result =
                Program.mkProgram
                    Reflection.loadAllAssemblies
                    Reflection.tryGetProperty
                    configuration
                |> Program.withDebug options.Debug
                |> Program.withIsTypeResolvable XFConverters.isTypeResolvable
                |> Program.withConvertTypeName XFConverters.convertTypeName
                |> Program.withConvertEventType XFConverters.convertEventType
                |> Program.withTryGetStringRepresentationOfDefaultValue XFConverters.tryGetStringRepresentationOfDefaultValue
                |> Program.run options.MappingFile options.OutputFile
                
            // Exit code
            match result with
            | Error messages ->
                messages |> List.iter Trace.TraceError
                1
                
            | Ok (informations, warnings) ->
                warnings |> List.iter Trace.TraceWarning
                informations |> List.iter Trace.TraceInformation
                0