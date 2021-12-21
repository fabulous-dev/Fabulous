module Fabulous.StackAllocatedCollections

module Array =
    let inline appendOne (v: 'v) (arr: 'v array) =
        let res = Array.zeroCreate(arr.Length + 1)
        Array.blit arr 0 res 0 arr.Length
        res.[arr.Length] <- v
        res


//let a = Array.length [||]
//[<System.Runtime.CompilerServices.IsReadOnly>]
type StackArray3<'v> = (struct (int * 'v * 'v * 'v * 'v array))

//    struct
//        val count: int
//        val v0: 'v
//        val v1: 'v
//        val v2: 'v
//        val rest: 'v array
//
//        new(count: int, v0: 'v, v1: 'v, v2: 'v, rest: 'v array) =
//            {
//                count = count
//                v0 = v0
//                v1 = v1
//                v2 = v2
//                rest = rest
//            }
//    end


module StackArray3 =

    let inline empty () : StackArray3<'v> =
        //        let t = StackArray3 ()
//        t.count <- 2

        StackArray3(
            0,
            Unchecked.defaultof<'v>,
            Unchecked.defaultof<'v>,
            Unchecked.defaultof<'v>,
            Unchecked.defaultof<'v array>
        )

    // t

    let inline one (v0: 'v) : StackArray3<'v> =
        StackArray3(1, v0, Unchecked.defaultof<'v>, Unchecked.defaultof<'v>, Unchecked.defaultof<'v array>)

    let inline two (v0: 'v, v1: 'v) : StackArray3<'v> =
        StackArray3(2, v0, v1, Unchecked.defaultof<'v>, Unchecked.defaultof<'v array>)

    let inline three (v0: 'v, v1: 'v, v2: 'v) : StackArray3<'v> =
        StackArray3(3, v0, v1, v2, Unchecked.defaultof<'v array>)

    let inline many (v0: 'v, v1: 'v, v2: 'v, rest: 'v array) : StackArray3<'v> =
        StackArray3(3 + rest.Length, v0, v1, v2, rest)

    let inline add (arr: StackArray3<'v>, v: 'v) : StackArray3<'v> =
        let struct (count, v0, v1, v2, rest) = arr
        match count with
        | 0 -> one(v)
        | 1 -> two(v0, v)
        | 2 -> three(v0, v1, v)
        | 3 -> many(v0, v1, v2, [| v |])
        | _ -> many(v0, v1, v2, Array.appendOne v rest)

    let inline a0 () = [||]
    let inline a1 (v: 'v) = [| v |]
    let inline a2 (v0: 'v, v1: 'v) = [| v0; v1 |]
    let inline a3 (v0: 'v, v1: 'v, v2: 'v) = [| v0; v1; v2 |]

    let inline an (v0: 'v, v1: 'v, v2: 'v, rest: 'v array) =
        let a = Array.create<'v> (rest.Length + 3) v0
//        a[ 0 ] <- v0
        a[ 1 ] <- v1
        a[ 2 ] <- v2

        Array.blit rest 0 a 3 rest.Length
        //            Array.append [| arr.v0; arr.v1; arr.v2 |] arr.rest
        a

    let inline toArray (arr: StackArray3<'v> inref) : 'v array =
        let struct (count, v0, v1, v2, rest) = arr
        match count with
        | 0 -> a0()
        | 1 -> a1(v0)
        | 2 -> a2(v0, v1)
        | 3 -> a3(v0, v1, v2)
        | _ -> an(v0, v1, v2, rest)

    //    let toArray (arr: StackArray3<'v>) : 'v array =
//        match arr.count with
//        | 0 -> [||]
//        | 1 -> [| arr.v0 |]
//        | 2 -> [| arr.v0; arr.v1 |]
//        | 3 -> [| arr.v0; arr.v1; arr.v2 |]
//        | _ ->
//            let a = Array.zeroCreate<'v> arr.count
//            a[0] <- arr.v0
//            a[1] <- arr.v1
//            a[2] <- arr.v2
//
//            Array.blit arr.rest 0 a 3 arr.rest.Length
//            a

    let inline fromArray (arr: 'v array) : StackArray3<'v> =
       match arr.Length with
       | 0 -> empty()
       | 1 -> one(arr[0])
       | 2 -> two(arr[0], arr[1])
       | 3 -> three(arr[0], arr[1], arr[2])
       | _ -> many(arr[0], arr[1], arr[2], Array.skip 3 arr)

    let inline combine (a: StackArray3<'v> inref, b: StackArray3<'v> inref) : StackArray3<'v> =
        let struct (acount, av0, av1, av2, arest) = a
        let struct (bcount, bv0, bv1, bv2, brest) = b
        match (acount, bcount) with
        | 0, _ -> b
        | _, 0 -> a
        | _, 1 -> add(a, bv0)
        | 1, 2 -> three(av0, bv0, bv1)
        | 1, 3 -> many(av0, bv0, bv1, [| bv2 |])
        | 1, _ -> many(av0, bv0, bv1, Array.append [| bv2 |] brest) // TODO
        | 2, 2 -> many(av0, av1, bv0, [| bv1 |])
        | 2, 3 -> many(av0, av1, bv0, [| bv1; bv2 |])
        | 2, _ -> many(av0, av1, bv0, Array.append [| bv1; bv2 |] brest) // TODO
        | 3, 2 -> many(av0, av1, av2, [| bv0; bv1 |])
        | 3, _ -> many(av0, av1, av2, (toArray &b))
        | _ -> many(av0, av1, av2, Array.append arest (toArray &b)) // TODO
