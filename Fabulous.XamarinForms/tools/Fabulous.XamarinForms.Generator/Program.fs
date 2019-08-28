namespace Fabulous.XamarinForms.Generator

open System.Diagnostics
open CommandLine
open Fabulous.CodeGen
open Fabulous.CodeGen.Models
    
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
        
    let logger =
        { traceInformation = Trace.TraceInformation
          traceWarning = Trace.TraceWarning
          traceError = Trace.TraceError }
        
    let configuration =
        { baseTypeName = "Xamarin.Forms.Element"
          propertyBaseType = "Xamarin.Forms.BindableProperty" }

    [<EntryPoint>]
    let main args =
        use consoleOutput = System.Console.OpenStandardOutput()
        use traceListener = new TextWriterTraceListener(consoleOutput)
        Trace.Listeners.Add(traceListener) |> ignore
        
        match tryReadOptions args with
        | None ->
            logger.traceError "Missing required arguments"
            1
        | Some options ->
            let success =
                Program.mkProgram
                    Reflection.loadAllAssemblies
                    Reflection.tryGetProperty
                    configuration
                    logger
                |> Program.withDebug options.Debug
                |> Program.withIsTypeResolvable XFConverters.isTypeResolvable
                |> Program.withConvertTypeName XFConverters.convertTypeName
                |> Program.withConvertEventType XFConverters.convertEventType
                |> Program.withTryGetStringRepresentationOfDefaultValue XFConverters.tryGetStringRepresentationOfDefaultValue
                |> Program.run options.MappingFile options.OutputFile
                
            // Exit code
            if success then 0 else 1