namespace Fabulous

open Microsoft.FSharp.Core

module Array =
    let inline appendOne (v: 'v) (arr: 'v array) =
        let res = Array.zeroCreate (arr.Length + 1)
        Array.blit arr 0 res 0 arr.Length
        res.[arr.Length] <- v
        res

    /// This is insertion sort that is O(n*n) but it performs better
    /// 1. if the array is partially sorted (second sort is cheap)
    /// 2. there are few elements, we expect to have only a handful of them per widget
    /// 3. stable, which is handy for duplicate attributes, e.g. we can choose which one to pick
    /// https://en.wikipedia.org/wiki/Insertion_sort
    let inline sortInPlace<'T, 'V when 'V: comparison> ([<InlineIfLambda>] getKey: 'T -> 'V) (attrs: 'T []) : 'T [] =
        let N = attrs.GetLength(0)

        for i in [ 1 .. N - 1 ] do
            for j = i downto 1 do
                let key = getKey attrs.[j]
                let prevKey = getKey attrs.[j - 1]

                if key < prevKey then
                    let temp = attrs.[j]
                    attrs.[j] <- attrs.[j - 1]
                    attrs.[j - 1] <- temp

        attrs
