namespace Fabulous

open System

type ArraySlice<'v> = (struct (uint16 * 'v array))

module ArraySlice =
    let inline toSpan (a: ArraySlice<'v>) =
        let struct (size, arr) = a
        Span(arr, 0, int size)

    let inline fromArrayOpt (arr: 'v [] option) : ArraySlice<'v> voption =
        match arr with
        | None -> ValueNone
        | Some arr -> ValueSome(uint16 arr.Length, arr)

    let inline fromArray (arr: 'v []) : ArraySlice<'v> voption =
        match arr.Length with
        | 0 -> ValueNone
        | size -> ValueSome(uint16 size, arr)
