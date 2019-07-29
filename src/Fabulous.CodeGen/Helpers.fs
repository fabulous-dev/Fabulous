// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.CodeGen

open System.IO

module Helpers =
    let removeText textToRemove (originalStr: string) =
        originalStr.Replace(textToRemove, "")

    let toOption value =
        match value with
        | null -> None
        | _ -> Some value
        
    type TextWriter with
        member this.printf fmt = fprintf this fmt
        member this.printfn fmt = fprintfn this fmt

    type Logger =
        { traceInformation: string -> unit
          traceWarning: string -> unit
          traceError: string -> unit }
        
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
