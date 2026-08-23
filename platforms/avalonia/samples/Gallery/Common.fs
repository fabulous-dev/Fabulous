namespace Gallery


open Fabulous
open type Fabulous.Avalonia.View

module Cmd =
    let perform fn : Cmd<'msg> = [ (fun _ -> fn()) ]

    let performAsync asyncUnit =
        Cmd.ofMsgOption(
            Async.Start asyncUnit
            None
        )

open System

module String =
    let NotNullOrEmpty = String.IsNullOrEmpty >> not
    let NotNullOrWhiteSpace = String.IsNullOrWhiteSpace >> not

    let StripChar chars str =
        Seq.fold
            (fun (str: string) chr ->
                str
                    .Replace(chr |> Char.ToUpper |> string, "")
                    .Replace(chr |> Char.ToLower |> string, ""))
            str
            chars

[<AutoOpen>]
module Task =
    open System.Collections.Generic

    type IAsyncEnumerable<'T> with

        member this.AsTask() =
            task {
                let mutable nxt = true
                let output = ResizeArray()
                let enumerator = this.GetAsyncEnumerator()

                while nxt do
                    let! next = enumerator.MoveNextAsync()
                    nxt <- next

                    if nxt then
                        output.Add enumerator.Current

                return output.ToArray()
            }
