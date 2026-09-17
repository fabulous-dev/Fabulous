namespace Fabulous.Tests

open Fabulous
open NUnit.Framework

/// Plain-data projection of a WidgetChange, since WidgetChange is a (non-byref-like, but
/// still not equatable/comparable) struct DU whose cases carry a Widget (a struct with a
/// DebugName-conditional field layout under #if DEBUG). Projecting to plain data keeps the
/// assertions independent of DEBUG/RELEASE build configuration.
type private WidgetChangeKind =
    | AddedKind of key: WidgetAttributeKey
    | RemovedKind of key: WidgetAttributeKey
    | UpdatedKind of key: WidgetAttributeKey
    | ReplacedByKind of oldKey: WidgetAttributeKey * newKey: WidgetAttributeKey

[<TestFixture>]
type ``WidgetDiff WidgetChanges tests``() =

    // Two independent widget-valued attributes so we can build multi-attribute widgets
    // and exercise the sorted merge-diff logic in WidgetDiff.WidgetChangesEnumerator.
    static let attrA = Attributes.defineWidget "AttrA" (fun _ _ -> ()) (fun _ _ _ -> ())

    static let attrB = Attributes.defineWidget "AttrB" (fun _ _ -> ()) (fun _ _ _ -> ())

    // Marker widget key used only to distinguish widget "identity" in tests; no widget
    // definition needs to be registered for it since these tests never call ApplyDiff /
    // CreateView, only enumerate the produced WidgetChange values.
    let makeWidget (key: WidgetKey) : Widget =
        { Key = key
#if DEBUG
          DebugName = "TestWidget"
#endif
          ScalarAttributes = [||]
          WidgetAttributes = [||]
          WidgetCollectionAttributes = [||]
          EnvironmentAttributes = [||] }

    let alwaysReuse (_: Widget) (_: Widget) = true
    let neverReuse (_: Widget) (_: Widget) = false
    let noCompareScalars (_: ScalarAttributeKey) (_: obj) (_: obj) = ScalarAttributeComparison.Different

    let toChanges (canReuseView: Widget -> Widget -> bool) (prev: WidgetAttribute[]) (next: WidgetAttribute[]) =
        let changes = WidgetChanges(prev, next, canReuseView, noCompareScalars)
        let result = ResizeArray()
        let mutable enumerator = changes.GetEnumerator()

        while enumerator.MoveNext() do
            let kind =
                match enumerator.Current with
                | WidgetChange.Added attr -> AddedKind attr.Key
                | WidgetChange.Removed attr -> RemovedKind attr.Key
                | WidgetChange.Updated(attr, _) -> UpdatedKind attr.Key
                | WidgetChange.ReplacedBy(oldAttr, newAttr) -> ReplacedByKind(oldAttr.Key, newAttr.Key)

            result.Add(kind)

        result |> List.ofSeq

    [<Test>]
    member _.``Empty prev and next produce no changes``() =
        let changes = toChanges alwaysReuse [||] [||]
        Assert.AreEqual(0, changes.Length)

    [<Test>]
    member _.``All attributes are Added when prev is empty``() =
        let next = [| attrA.WithValue(makeWidget 1) |]
        let changes = toChanges alwaysReuse [||] next

        Assert.AreEqual([ AddedKind attrA.Key ], changes)

    [<Test>]
    member _.``All attributes are Removed when next is empty``() =
        let prev = [| attrA.WithValue(makeWidget 1) |]
        let changes = toChanges alwaysReuse prev [||]

        Assert.AreEqual([ RemovedKind attrA.Key ], changes)

    [<Test>]
    member _.``Same key with identical widget produces no change``() =
        let widget = makeWidget 1
        let prev = [| attrA.WithValue(widget) |]
        let next = [| attrA.WithValue(widget) |]
        let changes = toChanges alwaysReuse prev next

        Assert.AreEqual(0, changes.Length)

    [<Test>]
    member _.``Same key with different widget and canReuseView true produces Updated``() =
        let prev = [| attrA.WithValue(makeWidget 1) |]
        let next = [| attrA.WithValue(makeWidget 2) |]
        let changes = toChanges alwaysReuse prev next

        Assert.AreEqual([ UpdatedKind attrA.Key ], changes)

    [<Test>]
    member _.``Same key with different widget and canReuseView false produces ReplacedBy``() =
        let prev = [| attrA.WithValue(makeWidget 1) |]
        let next = [| attrA.WithValue(makeWidget 2) |]
        let changes = toChanges neverReuse prev next

        Assert.AreEqual([ ReplacedByKind(attrA.Key, attrA.Key) ], changes)

    [<Test>]
    member _.``Diffing two disjoint attribute sets produces one Removed and one Added``() =
        let prev = [| attrA.WithValue(makeWidget 1) |]
        let next = [| attrB.WithValue(makeWidget 1) |]
        let changes = toChanges alwaysReuse prev next

        Assert.AreEqual(2, changes.Length)
        Assert.True(changes |> List.contains(RemovedKind attrA.Key))
        Assert.True(changes |> List.contains(AddedKind attrB.Key))
