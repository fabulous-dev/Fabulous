namespace Fabulous

open System

type ArraySlice<'v> = (struct (uint16 * 'v array))

module ArraySlice =
    let inline toSpan (a: ArraySlice<'v>) =
        let struct (size, arr) = a

        match size with
        | 0us -> Span.Empty
        | size -> Span(arr, 0, int size)

    let inline emptyWithNull () : ArraySlice<'v> = (0us, null) // note null in here

    let inline fromArrayOpt (arr: 'v [] option) : ArraySlice<'v> voption =
        match arr with
        | None -> ValueNone
        | Some arr -> ValueSome(uint16 arr.Length, arr)

    let inline fromArray (arr: 'v []) : ArraySlice<'v> voption =
        match arr.Length with
        | 0 -> ValueNone
        | size -> ValueSome(uint16 size, arr)

    let shiftByMut (slice: ArraySlice<'v> inref) (by: uint16) : 'v array =
        let struct (used, arr) = slice

        let used = int used
        let by = int by

        // noop if we don't have enough space
        if (used + by <= arr.Length) then
            for i = used + by - 1 downto int by do
                arr.[i] <- arr.[i - by]

        arr
