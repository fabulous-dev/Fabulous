namespace Fabulous.Tests

open Fabulous
open NUnit.Framework

/// Plain-data projection of a ScalarChange, since ScalarChange is a byref-like struct
/// that cannot be stored in collections or captured by closures.
type private ScalarChangeKind =
    | AddedKind of key: ScalarAttributeKey
    | RemovedKind of key: ScalarAttributeKey
    | UpdatedKind of key: ScalarAttributeKey * oldValue: uint64 * newValue: uint64

[<TestFixture>]
type ``WidgetDiff ScalarChanges tests``() =

    // Two independent int-backed attributes so we can build multi-attribute widgets
    // and exercise the sorted merge-diff logic in WidgetDiff.ScalarChangesEnumerator.
    static let attrA = Attributes.defineInt "AttrA" (fun _ _ (_: IViewNode) -> ())

    static let attrB = Attributes.defineInt "AttrB" (fun _ _ (_: IViewNode) -> ())

    let compareScalars (_: ScalarAttributeKey) (_: obj) (_: obj) = ScalarAttributeComparison.Different

    let toChanges (prev: ScalarAttribute[]) (next: ScalarAttribute[]) =
        let changes = ScalarChanges(prev, next, compareScalars)
        let result = ResizeArray()
        let mutable enumerator = changes.GetEnumerator()

        while enumerator.MoveNext() do
            let kind =
                match enumerator.Current with
                | ScalarChange.Added attr -> AddedKind attr.Key
                | ScalarChange.Removed attr -> RemovedKind attr.Key
                | ScalarChange.Updated(oldAttr, newAttr) -> UpdatedKind(oldAttr.Key, oldAttr.NumericValue, newAttr.NumericValue)

            result.Add(kind)

        result |> List.ofSeq

    [<Test>]
    member _.``Empty prev and next produce no changes``() =
        let changes = toChanges [||] [||]
        Assert.AreEqual(0, changes.Length)

    [<Test>]
    member _.``All attributes are Added when prev is empty``() =
        let next = [| attrA.WithValue(1) |]
        let changes = toChanges [||] next

        Assert.AreEqual([ AddedKind attrA.Key ], changes)

    [<Test>]
    member _.``All attributes are Removed when next is empty``() =
        let prev = [| attrA.WithValue(1) |]
        let changes = toChanges prev [||]

        Assert.AreEqual([ RemovedKind attrA.Key ], changes)

    [<Test>]
    member _.``Same key with different numeric value produces Updated``() =
        let prev = [| attrA.WithValue(1) |]
        let next = [| attrA.WithValue(2) |]
        let changes = toChanges prev next

        Assert.AreEqual([ UpdatedKind(attrA.Key, 1UL, 2UL) ], changes)

    [<Test>]
    member _.``Same key with identical numeric value produces no change``() =
        let prev = [| attrA.WithValue(1) |]
        let next = [| attrA.WithValue(1) |]
        let changes = toChanges prev next

        Assert.AreEqual(0, changes.Length)

    [<Test>]
    member _.``Diffing two disjoint attribute sets produces one Removed and one Added``() =
        let prev = [| attrA.WithValue(1) |]
        let next = [| attrB.WithValue(1) |]
        let changes = toChanges prev next

        Assert.AreEqual(2, changes.Length)
        Assert.True(changes |> List.contains(RemovedKind attrA.Key))
        Assert.True(changes |> List.contains(AddedKind attrB.Key))

    [<Test>]
    member _.``Repeated attribute with same key keeps only the latest value (SkipRepeatingScalars)``() =
        // prev:  AttrA(1).AttrA(2)  -> only "2" should count
        // next:  AttrA(2)           -> identical to the latest prev value, no change expected
        let prev = [| attrA.WithValue(1); attrA.WithValue(2) |]
        let next = [| attrA.WithValue(2) |]
        let changes = toChanges prev next

        Assert.AreEqual(0, changes.Length)
