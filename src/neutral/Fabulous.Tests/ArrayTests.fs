namespace Fabulous.Tests

open System
open System.Collections.Generic
open Fabulous.StackAllocatedCollections
open NUnit.Framework

[<TestFixture>]
type ``Array tests``() =
    [<Test>]
    member _.``MutStackArray1.combineMut reuses array B if can fit all data``() =
        let arrB = Array.zeroCreate 7

        let a = MutStackArray1.Many((2us, Array.zeroCreate 4))
        let b = MutStackArray1.Many((5us, arrB))
        let c = MutStackArray1.combineMut(&a, b)
        let cOpt = MutStackArray1.toArraySlice &c
        let struct (usedC, arrC) = cOpt.Value

        // We should have the same number of used items
        Assert.AreEqual(7us, usedC)

        // Reference should be equal to arrB since the array was reused
        Assert.True(Object.ReferenceEquals(arrC, arrB))

    [<Test>]
    member _.``StackArray3.sortInPlace sorts all permutations of 3 elements correctly``() =
        let permutations =
            [ (1, 2, 3); (1, 3, 2); (2, 1, 3); (2, 3, 1); (3, 1, 2); (3, 2, 1) ]

        for (a, b, c) in permutations do
            let mutable arr = StackArray3.three(a, b, c)
            let sorted = StackArray3.sortInPlace id &arr
            Assert.AreEqual([| 1; 2; 3 |], StackArray3.toArray &sorted)

    [<Test>]
    member _.``StackArray3.add grows through Few sizes and switches to Many past 3 elements``() =
        let empty = StackArray3.empty()
        Assert.AreEqual(0, StackArray3.length &empty)

        let one = StackArray3.add(&empty, 1)
        Assert.AreEqual([| 1 |], StackArray3.toArray &one)

        let two = StackArray3.add(&one, 2)
        Assert.AreEqual([| 1; 2 |], StackArray3.toArray &two)

        let three = StackArray3.add(&two, 3)
        Assert.AreEqual([| 1; 2; 3 |], StackArray3.toArray &three)

        // Adding a 4th element must switch the representation from Few to Many
        let four = StackArray3.add(&three, 4)
        Assert.AreEqual([| 1; 2; 3; 4 |], StackArray3.toArray &four)

        match four with
        | Many _ -> ()
        | Few _ -> Assert.Fail("Expected StackArray3 to switch to the Many representation after adding a 4th element")

        let five = StackArray3.add(&four, 5)
        Assert.AreEqual([| 1; 2; 3; 4; 5 |], StackArray3.toArray &five)

    [<Test>]
    member _.``StackArray3.get returns the element at each valid index for Few and Many``() =
        let mutable few = StackArray3.three(10, 20, 30)
        Assert.AreEqual(10, StackArray3.get &few 0)
        Assert.AreEqual(20, StackArray3.get &few 1)
        Assert.AreEqual(30, StackArray3.get &few 2)

        let mutable many = StackArray3.many [| 10; 20; 30; 40 |]
        Assert.AreEqual(10, StackArray3.get &many 0)
        Assert.AreEqual(40, StackArray3.get &many 3)

    [<Test>]
    member _.``StackArray3.get throws IndexOutOfRangeException when index exceeds the Few size``() =
        let mutable few = StackArray3.two(1, 2)

        Assert.Throws<IndexOutOfRangeException>(fun () -> StackArray3.get &few 2 |> ignore)
        |> ignore

    [<Test>]
    member _.``StackArray3.find locates a matching element in Few and Many representations``() =
        let mutable few = StackArray3.three(1, 2, 3)
        Assert.AreEqual(2, StackArray3.find (fun v -> v = 2) &few)

        let mutable many = StackArray3.many [| 1; 2; 3; 4 |]
        Assert.AreEqual(4, StackArray3.find (fun v -> v = 4) &many)

    [<Test>]
    member _.``StackArray3.find throws KeyNotFoundException when no element matches in Few``() =
        let mutable few = StackArray3.three(1, 2, 3)

        Assert.Throws<KeyNotFoundException>(fun () -> StackArray3.find (fun v -> v = 99) &few |> ignore)
        |> ignore

    [<Test>]
    member _.``StackArray3.combine merges two Few arrays for every size combination``() =
        let cases =
            [ (StackArray3.empty(), StackArray3.one 1, [| 1 |])
              (StackArray3.one 1, StackArray3.empty(), [| 1 |])
              (StackArray3.one 1, StackArray3.one 2, [| 1; 2 |])
              (StackArray3.one 1, StackArray3.two(2, 3), [| 1; 2; 3 |])
              (StackArray3.two(1, 2), StackArray3.one 3, [| 1; 2; 3 |])
              (StackArray3.one 1, StackArray3.three(2, 3, 4), [| 1; 2; 3; 4 |])
              (StackArray3.three(1, 2, 3), StackArray3.one 4, [| 1; 2; 3; 4 |])
              (StackArray3.two(1, 2), StackArray3.two(3, 4), [| 1; 2; 3; 4 |])
              (StackArray3.three(1, 2, 3), StackArray3.two(4, 5), [| 1; 2; 3; 4; 5 |])
              (StackArray3.two(1, 2), StackArray3.three(3, 4, 5), [| 1; 2; 3; 4; 5 |])
              (StackArray3.three(1, 2, 3), StackArray3.three(4, 5, 6), [| 1; 2; 3; 4; 5; 6 |]) ]

        for (a, b, expected) in cases do
            let combined = StackArray3.combine a b
            Assert.AreEqual(expected, StackArray3.toArray &combined)

    [<Test>]
    member _.``StackArray3.combine merges a Few and a Many array in either order``() =
        let few = StackArray3.two(1, 2)
        let many = StackArray3.many [| 3; 4; 5 |]

        let combinedFewFirst = StackArray3.combine few many
        Assert.AreEqual([| 1; 2; 3; 4; 5 |], StackArray3.toArray &combinedFewFirst)

        let combinedManyFirst = StackArray3.combine many few
        Assert.AreEqual([| 3; 4; 5; 1; 2 |], StackArray3.toArray &combinedManyFirst)

    [<Test>]
    member _.``StackArray3.combine merges two Many arrays``() =
        let a = StackArray3.many [| 1; 2 |]
        let b = StackArray3.many [| 3; 4 |]

        let combined = StackArray3.combine a b
        Assert.AreEqual([| 1; 2; 3; 4 |], StackArray3.toArray &combined)
