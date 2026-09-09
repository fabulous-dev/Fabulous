namespace Fabulous.Tests

open Fabulous
open NUnit.Framework

/// Plain-data projection of an EnvironmentChange, since EnvironmentChange is a byref-like
/// struct that cannot be stored in collections or captured by closures.
type private EnvironmentChangeKind =
    | AddedKind of key: EnvironmentAttributeKey
    | RemovedKind of key: EnvironmentAttributeKey
    | UpdatedKind of key: EnvironmentAttributeKey * oldValue: obj * newValue: obj

[<TestFixture>]
type ``WidgetDiff EnvironmentChanges tests``() =

    // Two independent environment keys so we can build multi-attribute environment
    // sets and exercise the sorted merge-diff logic in WidgetDiff.EnvironmentChangesEnumerator.
    static let keyA = EnvironmentAttributeKey "EnvKeyA"
    static let keyB = EnvironmentAttributeKey "EnvKeyB"

    let makeAttr (key: EnvironmentAttributeKey) (value: obj) : EnvironmentAttribute =
        { Key = key
#if DEBUG
          DebugName = "EnvKey"
#endif
          Value = value }

    let toChanges (prev: EnvironmentAttribute[]) (next: EnvironmentAttribute[]) =
        let changes = EnvironmentChanges(prev, next)
        let result = ResizeArray()
        let mutable enumerator = changes.GetEnumerator()

        while enumerator.MoveNext() do
            let kind =
                match enumerator.Current with
                | EnvironmentChange.Added attr -> AddedKind attr.Key
                | EnvironmentChange.Removed attr -> RemovedKind attr.Key
                | EnvironmentChange.Updated(oldAttr, newAttr) -> UpdatedKind(oldAttr.Key, oldAttr.Value, newAttr.Value)

            result.Add(kind)

        result |> List.ofSeq

    [<Test>]
    member _.``Empty prev and next produce no changes``() =
        let changes = toChanges [||] [||]
        Assert.AreEqual(0, changes.Length)

    [<Test>]
    member _.``All attributes are Added when prev is empty``() =
        let next = [| makeAttr keyA (box 1) |]
        let changes = toChanges [||] next

        Assert.AreEqual([ AddedKind keyA ], changes)

    [<Test>]
    member _.``All attributes are Removed when next is empty``() =
        let prev = [| makeAttr keyA (box 1) |]
        let changes = toChanges prev [||]

        Assert.AreEqual([ RemovedKind keyA ], changes)

    [<Test>]
    member _.``Same key with different value produces Updated``() =
        let prev = [| makeAttr keyA (box 1) |]
        let next = [| makeAttr keyA (box 2) |]

        let changes = toChanges prev next

        Assert.AreEqual([ UpdatedKind(keyA, box 1, box 2) ], changes)

    [<Test>]
    member _.``Same key with identical value produces no change``() =
        let prev = [| makeAttr keyA (box 1) |]
        let next = [| makeAttr keyA (box 1) |]

        let changes = toChanges prev next

        Assert.AreEqual(List.empty<EnvironmentChangeKind>, changes)

    [<Test>]
    member _.``Diffing disjoint attribute sets produces one Removed and one Added``() =
        let prev = [| makeAttr keyA (box 1) |]
        let next = [| makeAttr keyB (box 1) |]

        let changes = toChanges prev next

        Assert.AreEqual([ RemovedKind keyA; AddedKind keyB ], changes)

    [<Test>]
    member _.``Repeated attribute with the same key keeps only the latest value``() =
        // Mirrors the SkipRepeatingScalars dedup behavior in WidgetDiff.fs: when the same
        // environment key is present multiple times (e.g. two nested `.environment` calls
        // setting the same key), only the last occurrence should be considered.
        let prev = [| makeAttr keyA (box 1); makeAttr keyA (box 2) |]
        let next = [| makeAttr keyA (box 2) |]

        let changes = toChanges prev next

        Assert.AreEqual(List.empty<EnvironmentChangeKind>, changes)
