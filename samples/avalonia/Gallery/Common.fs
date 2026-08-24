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
        Seq.fold (fun (str: string) chr -> str.Replace(chr |> Char.ToUpper |> string, "").Replace(chr |> Char.ToLower |> string, "")) str chars

[<AutoOpen>]
module AsyncEnumerable =
    open System.Buffers
    open System.Collections.Generic
    open System.IO
    open Avalonia.Platform.Storage

    let asyncEnumerableToArray (source: IAsyncEnumerable<'T>) =
        task {
            let mutable nxt = true
            let output = ResizeArray()
            let enumerator = source.GetAsyncEnumerator()

            while nxt do
                let! next = enumerator.MoveNextAsync()
                nxt <- next

                if nxt then
                    output.Add enumerator.Current

            return output.ToArray()
        }

    let readTextFromStorageFile (file: IStorageFile) (length: int) =
        task {
            use! stream = file.OpenReadAsync()
            use reader = new StreamReader(stream)
            let buffer = ArrayPool<char>.Shared.Rent(length)

            try
                let! charsRead = reader.ReadAsync(buffer, 0, length)
                return new string(buffer, 0, charsRead)
            finally
                ArrayPool<char>.Shared.Return(buffer)
        }
