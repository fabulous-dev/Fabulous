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
    
module Text =
    type TextWriter with
        member this.printf fmt = fprintf this fmt
        member this.printfn fmt = fprintfn this fmt
        
    let removeText textToRemove (originalStr: string) =
        originalStr.Replace(textToRemove, "")
        
    let getValueOrDefault overwrittenValue defaultValue =
        match overwrittenValue with
        | None -> defaultValue
        | Some value when System.String.IsNullOrWhiteSpace value -> defaultValue
        | Some value -> value

    let toLowerPascalCase (str : string) =
        match str with
        | null -> null
        | "" -> ""
        | x when x.Length = 1 -> x.ToLowerInvariant()
        | x -> string (System.Char.ToLowerInvariant(x.[0])) + x.Substring(1)
        