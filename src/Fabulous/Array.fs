(* Dev notes:

This file contains array implementations optimized for stack-based values.
This reduce the number of allocations on the heap required, reducing the GC pressure. *)

namespace Fabulous

open System
open System.Collections.Generic
open System.Runtime.CompilerServices

#nowarn "9"

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

module Array =
    let inline appendOne (v: 'v) (arr: 'v array) =
        let res = Array.zeroCreate(arr.Length + 1)
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


module StackAllocatedCollections =
    module StackList =
        type private Items<'v> = (struct ('v * 'v * 'v))

        module private Items =
            let inline one<'v> (v: 'v) =
                Items(v, Unchecked.defaultof<'v>, Unchecked.defaultof<'v>)

            let inline two<'v> (v1: 'v, v2: 'v) = Items(v1, v2, Unchecked.defaultof<'v>)

        /// reference type that holds the chain of tuples that come before Data
        /// this is basically List
        [<NoComparison; NoEquality>]
        type private Part<'v> =
            | Empty
            | Filled of struct (Items<'v> * Part<'v>)

        [<Struct; NoComparison; NoEquality>]
        type StackList<'v> =
            struct
                val private size: uint16
                val private items: Items<'v>
                val private before: Part<'v>

                private new(size, items, before) =
                    { size = size
                      items = items
                      before = before }

                static member empty() =
                    StackList(0us, Unchecked.defaultof<Items<'v>>, Empty)

                static member one(v: 'v) = StackList(1us, Items.one v, Empty)

                static member two(v1: 'v, v2: 'v) =
                    StackList(2us, Items.two(v1, v2), Empty)

                static member three(v1: 'v, v2: 'v, v3: 'v) =
                    StackList(3us, Items(v1, v2, v3), Empty)

                static member length(data: StackList<'v> inref) = data.size

                static member toArray(data: StackList<'v> inref) : 'v array =
                    if data.size = 0us then
                        Array.empty
                    else
                        let size = int data.size
                        let arr = Array.zeroCreate size
                        let struct (v0, v1, v2) = data.items

                        let used =
                            match data.size % 3us with
                            | 0us -> // copy 3 items
                                arr.[size - 1] <- v2
                                arr.[size - 2] <- v1
                                arr.[size - 3] <- v0
                                3
                            | 1us ->
                                // copy 1 item
                                arr.[size - 1] <- v0
                                1
                            | 2us ->
                                // copy 2 item
                                arr.[size - 1] <- v1
                                arr.[size - 2] <- v0
                                2
                            | _ -> 0

                        let mutable i = size - used - 1
                        let mutable leftToCopy = data.before

                        while i >= 2 do
                            match leftToCopy with
                            | Empty -> i <- -1
                            | Filled ((v0, v1, v2), before) ->
                                arr.[i] <- v2
                                arr.[i - 1] <- v1
                                arr.[i - 2] <- v0
                                i <- i - 3
                                leftToCopy <- before

                        arr

                static member add(data: StackList<'v> inref, v: 'v) =
                    let length = data.size
                    let struct (v0, v1, _) = data.items

                    match length with
                    | 0us -> StackList.one v
                    | 1us -> StackList.two(v0, v)
                    | 2us -> StackList.three(v0, v1, v)
                    | size ->
                        match size % 3us with
                        | 0us -> StackList(size + 1us, Items.one v, Filled(data.items, data.before))

                        // still filling up the stack allocated part
                        // 1 item filled
                        | 1us -> StackList(size + 1us, Items.two(v0, v), data.before)

                        // 2 items filled
                        | _ -> StackList(size + 1us, Items(v0, v1, v), data.before)

                static member tryFind<'v>(data: StackList<'v> inref, predicate: 'v -> bool) : 'v voption =
                    let tryFindInItems (items: Items<'v>) (size: uint16) predicate : 'v voption =
                        let struct (v0, v1, v2) = items
                        let constrainedSize = size % 3us

                        match constrainedSize with
                        | i when i >= 1us && predicate v0 -> ValueSome v0
                        | i when i >= 2us && predicate v1 -> ValueSome v1
                        | i when i >= 3us && predicate v2 -> ValueSome v2
                        | _ -> ValueNone

                    let rec tryFindInPart (part: Part<'v>) (predicate: 'v -> bool) : 'v voption =
                        match part with
                        | Empty -> ValueNone
                        | Filled (items, before) ->
                            let struct (v0, v1, v2) = items

                            if predicate v0 then ValueSome v0
                            elif predicate v1 then ValueSome v1
                            elif predicate v2 then ValueSome v2
                            else tryFindInPart before predicate

                    match tryFindInItems data.items data.size predicate with
                    | ValueSome v -> ValueSome v
                    | ValueNone -> tryFindInPart data.before predicate

                /// Try replacing an existing value inside a StackList.
                /// Returns true if the value was replaced, false if it was not found.
                static member replace(data: StackList<'v> inref, predicate: 'v -> bool, v: 'v) =
                    let tryReplaceInItems (items: Items<'v>) (size: uint16) predicate v : struct (bool * Items<'v>) =
                        let struct (v0, v1, v2) = items
                        let constrainedSize = size % 3us

                        match constrainedSize with
                        | 1us when predicate v0 -> struct (true, Items.one v)
                        | 2us when predicate v0 -> struct (true, Items.two(v, v1))
                        | 2us when predicate v1 -> struct (true, Items.two(v0, v))
                        | 3us when predicate v0 -> struct (true, Items(v, v1, v2))
                        | 3us when predicate v1 -> struct (true, Items(v0, v, v2))
                        | 3us when predicate v2 -> struct (true, Items(v0, v1, v))
                        | _ -> struct (false, items)

                    let rec tryReplaceInPart (part: Part<'v>) predicate v : struct (bool * Part<'v>) =
                        match part with
                        | Empty -> struct (false, Empty)
                        | Filled (items, before) ->
                            let struct (v0, v1, v2) = items

                            if predicate v0 then
                                struct (true, Filled(Items(v, v1, v2), before))
                            elif predicate v1 then
                                struct (true, Filled(Items(v0, v, v2), before))
                            elif predicate v2 then
                                struct (true, Filled(Items(v0, v1, v), before))
                            else
                                match tryReplaceInPart before predicate v with
                                | struct (true, newBefore) -> struct (true, Filled(items, newBefore))
                                | struct (false, _) -> struct (false, part)

                    match tryReplaceInItems data.items data.size predicate v with
                    | struct (true, newItems) -> StackList(data.size, newItems, data.before)
                    | struct (false, _) ->
                        match tryReplaceInPart data.before predicate v with
                        | struct (true, newBefore) -> StackList(data.size, data.items, newBefore)
                        | struct (false, _) -> data
            end




    type Size =
        | Zero = 0uy
        | One = 1uy
        | Two = 2uy
        | Three = 3uy


    [<Struct; NoComparison; NoEquality>]
    type StackArray3<'v> =
        | Few of data: struct (Size * 'v * 'v * 'v)
        | Many of arr: 'v array

    module StackArray3 =

        let inline empty () : StackArray3<'v> =
            Few(Size.Zero, Unchecked.defaultof<'v>, Unchecked.defaultof<'v>, Unchecked.defaultof<'v>)

        let inline one (v0: 'v) : StackArray3<'v> =
            Few(Size.One, v0, Unchecked.defaultof<'v>, Unchecked.defaultof<'v>)

        let inline two (v0: 'v, v1: 'v) : StackArray3<'v> =
            Few(Size.Two, v0, v1, Unchecked.defaultof<'v>)

        let inline three (v0: 'v, v1: 'v, v2: 'v) : StackArray3<'v> = Few(Size.Three, v0, v1, v2)

        let inline many (arr: 'v array) : StackArray3<'v> = Many arr

        let add (arr: StackArray3<'v> inref, v: 'v) : StackArray3<'v> =
            match arr with
            | Few (struct (size, v0, v1, v2)) ->
                match size with
                | Size.Zero -> one v
                | Size.One -> two(v0, v)
                | Size.Two -> three(v0, v1, v)
                | Size.Three -> many [| v0; v1; v2; v |]
                | _ -> empty() // should never happen but don't want to throw there
            | Many arr -> many(Array.appendOne v arr)


        let inline length (arr: StackArray3<'v> inref) : int =
            match arr with
            | Few (struct (size, _, _, _)) -> int size
            | Many arr -> arr.Length


        let get (arr: StackArray3<'v> inref) (index: int) : 'v =
            match arr with
            | Few (struct (size, v0, v1, v2)) ->
                if (index >= int size) then
                    IndexOutOfRangeException() |> raise
                else
                    match index with
                    | 0 -> v0
                    | 1 -> v1
                    | _ -> v2

            | Many arr -> arr.[index]


        let find (test: 'v -> bool) (arr: StackArray3<'v> inref) : 'v =
            match arr with
            | Few (struct (size, v0, v1, v2)) ->
                match (size, test v0, test v1, test v2) with
                | Size.One, true, _, _
                | Size.Two, true, _, _
                | Size.Three, true, _, _ -> v0
                | Size.Two, false, true, _
                | Size.Three, false, true, _ -> v1
                | Size.Three, false, false, true -> v2
                | _ -> KeyNotFoundException() |> raise
            | Many arr -> Array.find test arr


        /// Note that you should always use the result,
        /// In Few mode it creates a new stack allocated array
        /// In Many case it sorts the Many variant inline for optimization reasons
        let rec inline sortInPlace<'T, 'V when 'V: comparison>
            ([<InlineIfLambda>] getKey: 'T -> 'V)
            (arr: StackArray3<'T> inref)
            : StackArray3<'T> =
            match arr with
            | Few (struct (size, v0, v1, v2)) ->
                match size with
                | Size.Zero
                | Size.One -> arr
                | Size.Two ->
                    if (getKey v0 > getKey v1) then
                        two(v1, v0)
                    else
                        arr
                | Size.Three ->
                    match (getKey v0, getKey v1, getKey v1) with
                    // abc acb bac bca cba cab

                    //  a, c, b
                    | a, b, c when a <= c && c <= b -> three(v0, v2, v1)

                    //  b, a, c
                    | a, b, c when b <= a && a <= c -> three(v1, v0, v2)

                    //  b, c, a
                    | a, b, c when b <= c && c <= a -> three(v1, v2, v0)

                    //  c, b, a
                    | a, b, c when c <= b && b <= a -> three(v2, v1, v0)

                    //  c, a, b
                    | a, b, c when c <= a && a <= b -> three(v2, v0, v1)

                    // a, b, c left, thus already sorted
                    | _ -> arr


                | _ -> empty() // should never happen but don't want to throw there
            | Many arr -> many(Array.sortInPlace getKey arr)


        let inline private arr0 () = [||]
        let inline private arr1 (v: 'v) = [| v |]
        let inline private arr2 (v0: 'v, v1: 'v) = [| v0; v1 |]
        let inline private arr3 (v0: 'v, v1: 'v, v2: 'v) = [| v0; v1; v2 |]

        let toArray (arr: StackArray3<'v> inref) : 'v array =
            match arr with
            | Few (struct (size, v0, v1, v2)) ->
                match size with
                | Size.Zero -> Array.empty
                | Size.One -> arr1 v0
                | Size.Two -> arr2(v0, v1)
                | _ -> arr3(v0, v1, v2)
            | Many arr -> arr


        let combine (a: StackArray3<'v>) (b: StackArray3<'v>) : StackArray3<'v> =
            match (a, b) with
            | Few (struct (asize, a0, a1, a2)), Few (struct (bsize, b0, b1, b2)) ->
                match (asize, bsize) with
                | Size.Zero, _ -> b
                | _, Size.Zero -> a
                | Size.One, Size.One -> two(a0, b0)
                | Size.One, Size.Two -> three(a0, b0, b1)
                | Size.Two, Size.One -> three(a0, a1, b0)
                // now many cases
                | Size.One, Size.Three -> many [| a0; b0; b1; b2 |]
                | Size.Three, Size.One -> many [| a0; a1; a2; b0 |]
                | Size.Two, Size.Two -> many [| a0; a1; b0; b1 |]
                | Size.Three, Size.Two -> many [| a0; a1; a2; b0; b1 |]
                | Size.Two, Size.Three -> many [| a0; a1; b0; b1; b2 |]
                | Size.Three, Size.Three -> many [| a0; a1; a2; b0; b1; b2 |]
                | _ -> a // this should never happen because we exhausted all the other cases
            | Few _, Many arr2 -> many(Array.append(toArray &a) arr2) // TODO optimize
            | Many arr1, Few _ -> many(Array.append arr1 (toArray &b)) // TODO optimize
            | Many arr1, Many arr2 -> many(Array.append arr1 arr2)






    module MutStackArray1 =
        [<Struct; NoComparison; NoEquality>]
        type T<'v> =
            | Empty
            | One of one: 'v
            | Many of ArraySlice<'v>

        let inline private grow size = max((size * 3) / 2) size + 1

        let addMut (arr: T<'v> inref, value: 'v) : T<'v> =
            match arr with
            | Empty -> One value
            | One v ->
                Many
                    struct (2us,
                            [| v
                               value
                               Unchecked.defaultof<'v>
                               Unchecked.defaultof<'v> |])
            | Many struct (count, mutArr) ->
                if mutArr.Length > (int count) then
                    // we can fit it in
                    mutArr.[int count] <- value
                    Many(count + 1us, mutArr)
                else
                    // in this branch we reached the capacity of the array, thus needs to grow
                    let countInt = int count

                    let res =
                        // count is at least 2
                        // thus it is either going to grow at least by 1
                        // note that the growth rate is slower than ResizeArray
                        Array.zeroCreate(grow mutArr.Length)

                    Array.blit mutArr 0 res 0 mutArr.Length
                    res.[countInt] <- value
                    Many(count + 1us, res)

        let inline toArray (arr: T<'v> inref) : 'v array =
            match arr with
            | Empty -> Array.empty
            | One v -> [| v |]
            | Many (struct (count, arr)) -> Array.take(int count) arr

        let inline fromArray (arr: 'v array) : T<'v> =
            match arr.Length with
            | 0 -> Empty
            | 1 -> One arr.[0]
            | size -> Many(uint16 size, arr)

        let inline toArraySlice (arr: T<'v> inref) : ArraySlice<'v> voption =
            match arr with
            | Empty -> ValueNone
            | One v -> ValueSome(1us, [| v |])
            | Many slice -> ValueSome slice

        let inline length (arr: T<'v> inref) : int =
            match arr with
            | Empty -> 0
            | One _ -> 1
            | Many (struct (count, _)) -> int count

        let combineMut (a: T<'v> inref, b: T<'v>) : T<'v> =
            match b with
            | Empty -> a
            | One bv -> addMut(&a, bv)
            | Many sliceB ->
                match a with
                | Empty -> b
                | One av ->
                    let struct (used, arr) = sliceB

                    if arr.Length >= (int used) + 1 then
                        // it means that arr can fit one more element
                        let arr = ArraySlice.shiftByMut &sliceB 1us
                        arr.[0] <- av
                        Many(used + 1us, arr)
                    else
                        // we need to allocate a new one more
                        // Note very scientific formula of growth
                        let newArr = Array.zeroCreate(grow arr.Length)

                        Array.blit arr 0 newArr 1 (int used)
                        newArr.[0] <- av
                        Many(used + 1us, newArr)

                | Many sliceA ->
                    let struct (usedA, arrA) = sliceA
                    let struct (usedB, arrB) = sliceB

                    let newSize = usedA + usedB
                    let usedA = int usedA
                    let usedB = int usedB

                    if arrA.Length >= usedB + usedA then
                        // a can fit both
                        Array.blit arrB 0 arrA usedA usedB
                        Many(newSize, arrA)
                    elif arrB.Length >= usedB + usedA then
                        // b can fit both
                        let arr =
                            ArraySlice.shiftByMut &sliceB (uint16 usedA)

                        Array.blit arrA 0 arr 0 usedA
                        Many(newSize, arrA)
                    else
                        // None of them can fit the result
                        // thus allocate a new one
                        let newArr = Array.zeroCreate(grow(usedA + usedB))

                        Array.blit arrA 0 newArr 0 usedA
                        Array.blit arrB 0 newArr usedA usedB

                        Many(newSize, newArr)


    //        match (a, b) with
    //        | Empty, _ -> b
    //        | _, Empty -> a
    //        | _, One bv -> addMut(&a, bv)
    //        | One av, Many slice ->
    //            let struct (used, arr) = slice
    //
    //            if arr.Length >= (int used) + 1 then
    //                // it means that arr can fit one more element
    //                let arr = ArraySlice.shiftByMut &slice 1us
    //                arr.[0] <- av
    //                Many(used + 1us, arr)
    //            else
    //                // we need to allocate a new one more
    //                // Note very scientific formula of growth
    //                let newArr = Array.zeroCreate(grow(arr.Length + 1))
    //
    //                Array.blit arr 0 newArr 1 (int used)
    //                newArr.[0] <- av
    //                Many(used + 1us, newArr)
    //
    //        | Many sliceA, Many sliceB ->
    //            let struct (usedA, arrA) = sliceA
    //            let struct (usedB, arrB) = sliceB
    //
    //            let newSize = usedA + usedB
    //            let usedA = int usedA
    //            let usedB = int usedB
    //
    //            if arrA.Length >= usedB + usedA then
    //                // a can fit both
    //                Array.blit arrB 0 arrA usedA usedB
    //                Many(newSize, arrA)
    //            elif arrB.Length >= usedB + usedA then
    //                // b can fit both
    //                let arr =
    //                    ArraySlice.shiftByMut &sliceB (uint16 usedA)
    //
    //                Array.blit arrA 0 arr 0 usedA
    //                Many(newSize, arrA)
    //            else
    //                // None of them can fit the result
    //                // thus allocate a new one
    //                let newArr = Array.zeroCreate(grow(usedA + usedB))
    //
    //                Array.blit arrA 0 newArr 0 usedA
    //                Array.blit arrB 0 newArr usedA usedB
    //
    //                Many(newSize, newArr)


    open FSharp.NativeInterop

    let inline stackalloc<'a when 'a: unmanaged> (length: int) : Span<'a> =
        let p =
            NativePtr.stackalloc<'a> length
            |> NativePtr.toVoidPtr

        Span<'a>(p, length)

    //let t = stackalloc<uint16>(3)



    [<IsByRefLike>]
    type DiffBuilder =
        struct
            val ops: Span<uint16>
            val mutable cursor: int
            val mutable rest: uint16 array

            new(span: Span<uint16>, cursor) =
                { ops = span // stackalloc<uint16>(capacity)
                  cursor = cursor
                  rest = null }
        end



    module DiffBuilder =
        // 2 bytes
        type OpType =
            | Add // 1
            | Remove // 2
            | Change // 3

        // 00 is omitted on purpose for debuggability

        module OpCode =
            [<Literal>]
            let AddCode = 1us

            [<Literal>]
            let RemoveCode = 2us

            [<Literal>]
            let ChangeCode = 3us


        [<Struct>]
        type Op =
            | Added of added: uint16
            | Removed of removed: uint16
            | Changed of changed: uint16


        let inline create () = DiffBuilder(stackalloc<uint16> 8, 0)

        // reserve 2bits for op
        let valueMask = UInt16.MaxValue >>> 2

        // two left bits for op
        let opMask = UInt16.MaxValue ^^^ valueMask

        // TODO handle growth
        let addOpMut (builder: DiffBuilder byref) (op: OpType) (index: uint16) =
            let op =
                match op with
                | Add -> OpCode.AddCode
                | Remove -> OpCode.RemoveCode
                | Change -> OpCode.ChangeCode

            let encodedValue = ((uint16 op <<< 14) &&& opMask)
            let encodedValue = encodedValue ||| (index &&& valueMask)

            builder.ops.[builder.cursor] <- encodedValue
            builder.cursor <- builder.cursor + 1


        let inline lenght (builder: DiffBuilder byref) = builder.cursor

        let inline private decode (encodedValue: uint16) : Op =
            let op = encodedValue >>> 14

            let value = encodedValue &&& valueMask

            match op with
            | OpCode.AddCode -> Added(value)
            | OpCode.RemoveCode -> Removed(value)
            | OpCode.ChangeCode -> Changed(value)
            | _ -> IndexOutOfRangeException() |> raise

        let inline toArray (builder: DiffBuilder byref) (map: Op -> 't) : 't array =
            let len = lenght &builder
            let res = Array.zeroCreate<'t> len

            for i = 0 to len - 1 do
                res.[i] <- map(decode builder.ops.[i])

            res
