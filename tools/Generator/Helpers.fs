// Copyright 2018 Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Generator

open System.IO

module Helpers =
    type TextWriter with
        member this.printf fmt = fprintf this fmt
        member this.printfn fmt = fprintfn this fmt

    let (|NotNullOrWhitespace|_|) (str : string) =
        if System.String.IsNullOrWhiteSpace str then None
        else Some str

    let getValueOrDefault defaultValue value =
        if System.String.IsNullOrWhiteSpace value then defaultValue
        else value

    let toLowerPascalCase (str : string) =
        match str with
        | null -> null
        | "" -> ""
        | x when x.Length = 1 -> x.ToLowerInvariant()
        | x -> string (System.Char.ToLowerInvariant(x.[0])) + x.Substring(1)

    let getResultErrors lst =
        lst
        |> List.filter (fun x ->
               match x with
               | Error _ -> true
               | Ok _ -> false)
        |> List.map (fun x ->
               match x with
               | Error e -> e
               | Ok _ -> failwith "InvalidOperation")

    let getResultOks lst =
        lst
        |> List.filter (fun x ->
               match x with
               | Ok _ -> true
               | Error _ -> false)
        |> List.map (fun x ->
               match x with
               | Ok r -> r
               | Error _ -> failwith "InvalidOperation")

    let tryFindType (types : string []) name =
        types |> Array.tryFind (fun x -> x = name)
