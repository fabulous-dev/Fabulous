namespace Fabulous.Tests

open System
open Fabulous
open NUnit.Framework

module SubTests =
    let private noopDispose =
        { new IDisposable with
            member _.Dispose() = () }

    [<Test>]
    let ``diff detects no changes when keys are identical`` () =
        let activeSubs = [ [ "a" ], noopDispose; [ "b" ], noopDispose ]

        let sub: Sub<int> =
            [ [ "a" ], (fun _ -> noopDispose); [ "b" ], (fun _ -> noopDispose) ]

        let dupes, toStop, toKeep, toStart = Sub.Internal.diff activeSubs sub

        Assert.That(dupes, Is.Empty)
        Assert.That(toStop, Is.Empty)
        Assert.That(toStart, Is.Empty)
        Assert.That(toKeep, Is.EqualTo(activeSubs))

    [<Test>]
    let ``diff detects subs to start and stop`` () =
        let activeSubs = [ [ "a" ], noopDispose; [ "b" ], noopDispose ]

        let sub: Sub<int> =
            [ [ "b" ], (fun _ -> noopDispose); [ "c" ], (fun _ -> noopDispose) ]

        let dupes, toStop, toKeep, toStart = Sub.Internal.diff activeSubs sub

        Assert.That(dupes, Is.Empty)
        Assert.That(toStop |> List.map fst, Is.EqualTo([ [ "a" ] ]))
        Assert.That(toKeep |> List.map fst, Is.EqualTo([ [ "b" ] ]))
        Assert.That(toStart |> List.map fst, Is.EqualTo([ [ "c" ] ]))

    [<Test>]
    let ``diff detects duplicate subIds and keeps only the last occurrence`` () =
        let activeSubs = []

        let sub: Sub<int> =
            [ [ "a" ], (fun _ -> noopDispose); [ "a" ], (fun _ -> noopDispose) ]

        let dupes, _, _, toStart = Sub.Internal.diff activeSubs sub

        Assert.That(dupes, Is.EqualTo([ [ "a" ] ]))
        Assert.That(toStart |> List.map fst, Is.EqualTo([ [ "a" ] ]))
