namespace Fabulous.Tests

open System
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
    member _.``StackArray3.combine merges a Few and a Many array in either order``() =
        let few = StackArray3.two(1, 2)
        let many = StackArray3.many [| 3; 4; 5; 6 |]

        let combined1 = StackArray3.combine few many
        Assert.AreEqual([| 1; 2; 3; 4; 5; 6 |], StackArray3.toArray &combined1)

        let combined2 = StackArray3.combine many few
        Assert.AreEqual([| 3; 4; 5; 6; 1; 2 |], StackArray3.toArray &combined2)
