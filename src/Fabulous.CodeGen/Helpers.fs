// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen

open System.IO
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

module Helpers =
    let removeText textToRemove (originalStr: string) =
        originalStr.Replace(textToRemove, "")
        
    type TextWriter with
        member this.printf fmt = fprintf this fmt
        member this.printfn fmt = fprintfn this fmt

    type Logger =
        { traceInformation: string -> unit
          traceWarning: string -> unit
          traceError: string -> unit }
        
    type Configuration =
        { baseTypeName: string
          propertyBaseType: string
          baseTargetTypeForAttachedProperties: string }
        
    type MaybeBuilder() =
        let mutable _logger: Logger option = None
        let mutable _containerType: string = ""
        let mutable _memberKind: string = ""
        let mutable _memberName: string = ""
        
        let log msg =
            match _logger with
            | None -> ()
            | Some logger -> logger.traceError msg
        
        [<CustomOperation("use_logger")>]
        member this.UseLogger (x, logger: Logger, containerType: string, memberKind: string, memberName: string) =
            _logger <- Some logger
            _containerType <- containerType
            _memberKind <- memberKind
            _memberName <- memberName
            x
            
        member this.Yield(x) =
            Some x
            
        member this.For(x, f) =
            this.Bind(("", x),f)
        
        member this.Bind(x, f) =
            match x with
            | (fieldName, None) -> log (sprintf "Missing value for field %s of %s %s on type %s" fieldName _memberKind _memberName _containerType); None
            | (_, Some a) -> f a

        member this.Return(x) = 
            Some x
       
    let maybe = new MaybeBuilder()
    
    type NullableBuilder() =
        member this.Bind(x, f) =
            match x with
            | null -> None
            | _ -> f x
            
        member this.Return(x) =
            x
            
        member this.Zero() =
            None
       
    let nullable = new NullableBuilder()
        
    let writeOutputIfDebug debug path data =
        if debug then Json.serialize data |> File.write path