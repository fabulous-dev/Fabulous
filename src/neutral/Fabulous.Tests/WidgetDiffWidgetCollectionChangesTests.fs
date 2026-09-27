namespace Fabulous.Tests

open Fabulous
open NUnit.Framework

/// Plain-data projection of a WidgetCollectionItemChange, since the type is a
/// byref-like struct (Insert/Replace/Update/Remove carrying Widget values) that cannot
/// be stored in collections or captured by closures. Only the shape and index matter
/// for these tests, not the diff content of Update.
type private WidgetCollectionItemChangeKind =
    | InsertKind of index: int
    | ReplaceKind of index: int
    | UpdateKind of index: int
    | RemoveKind of index: int

/// Plain-data projection of a WidgetCollectionChange, mirroring the WidgetChangeKind
/// pattern used for WidgetChange in WidgetDiffWidgetChangesTests.fs.
type private WidgetCollectionChangeKind =
    | AddedKind of key: WidgetCollectionAttributeKey
    | RemovedKind of key: WidgetCollectionAttributeKey
    | UpdatedKind of key: WidgetCollectionAttributeKey * itemChanges: WidgetCollectionItemChangeKind list

[<TestFixture>]
type ``WidgetDiff WidgetCollectionChanges tests``() =

    // Two independent widget-collection-valued attributes (e.g. representing two
    // different "children" properties) so we can build multi-attribute widgets and
    // exercise the sorted merge-diff logic in WidgetDiff.WidgetCollectionChangesEnumerator.
    static let attrA =
        Attributes.defineWidgetCollection "AttrA" (fun _ _ (_: IViewNode) -> ()) (fun _ _ (_: IViewNode) -> ())

    static let attrB =
        Attributes.defineWidgetCollection "AttrB" (fun _ _ (_: IViewNode) -> ()) (fun _ _ (_: IViewNode) -> ())

    // Marker widget key used only to distinguish widget "identity" in tests; no widget
    // definition needs to be registered for it since these tests never call ApplyDiff /
    // CreateView, only enumerate the produced WidgetCollectionChange / WidgetCollectionItemChange values.
    let makeWidget (key: WidgetKey) : Widget =
        { Key = key
#if DEBUG
          DebugName = "TestWidget"
#endif
          ScalarAttributes = [||]
          WidgetAttributes = [||]
          WidgetCollectionAttributes = [||]
          EnvironmentAttributes = [||] }

    let makeSlice (widgets: Widget[]) : ArraySlice<Widget> = (uint16 widgets.Length, widgets)

    let alwaysReuse (_: Widget) (_: Widget) = true
    let neverReuse (_: Widget) (_: Widget) = false
    let noCompareScalars (_: ScalarAttributeKey) (_: obj) (_: obj) = ScalarAttributeComparison.Different

    let toItemChanges (canReuseView: Widget -> Widget -> bool) (prev: Widget[]) (next: Widget[]) : WidgetCollectionItemChangeKind list =
        let changes =
            WidgetCollectionItemChanges(makeSlice prev, makeSlice next, canReuseView, noCompareScalars)

        let result = ResizeArray()
        let mutable enumerator = changes.GetEnumerator()

        while enumerator.MoveNext() do
            let kind =
                match enumerator.Current with
                | WidgetCollectionItemChange.Insert(index, _) -> InsertKind index
                | WidgetCollectionItemChange.Replace(index, _, _) -> ReplaceKind index
                | WidgetCollectionItemChange.Update(index, _) -> UpdateKind index
                | WidgetCollectionItemChange.Remove(index, _) -> RemoveKind index

            result.Add(kind)

        result |> List.ofSeq

    let toChanges
        (canReuseView: Widget -> Widget -> bool)
        (prev: WidgetCollectionAttribute[])
        (next: WidgetCollectionAttribute[])
        : WidgetCollectionChangeKind list =
        let changes = WidgetCollectionChanges(prev, next, canReuseView, noCompareScalars)
        let result = ResizeArray()
        let mutable enumerator = changes.GetEnumerator()

        while enumerator.MoveNext() do
            let kind =
                match enumerator.Current with
                | WidgetCollectionChange.Added attr -> AddedKind attr.Key
                | WidgetCollectionChange.Removed attr -> RemovedKind attr.Key
                | WidgetCollectionChange.Updated(attr, _, diff) ->
                    let mutable itemEnumerator = diff.GetEnumerator()
                    let itemChanges = ResizeArray()

                    while itemEnumerator.MoveNext() do
                        let itemKind =
                            match itemEnumerator.Current with
                            | WidgetCollectionItemChange.Insert(index, _) -> InsertKind index
                            | WidgetCollectionItemChange.Replace(index, _, _) -> ReplaceKind index
                            | WidgetCollectionItemChange.Update(index, _) -> UpdateKind index
                            | WidgetCollectionItemChange.Remove(index, _) -> RemoveKind index

                        itemChanges.Add(itemKind)

                    UpdatedKind(attr.Key, itemChanges |> List.ofSeq)

            result.Add(kind)

        result |> List.ofSeq

    // WidgetCollectionChanges (attribute-level diffing)

    [<Test>]
    member _.``WidgetCollectionChanges - Empty prev and next produce no changes``() =
        let changes = toChanges alwaysReuse [||] [||]
        Assert.AreEqual(0, changes.Length)

    [<Test>]
    member _.``WidgetCollectionChanges - All attributes are Added when prev is empty``() =
        let next = [| attrA.WithValue(makeSlice [| makeWidget 1 |]) |]
        let changes = toChanges alwaysReuse [||] next

        Assert.AreEqual([ AddedKind attrA.Key ], changes)

    [<Test>]
    member _.``WidgetCollectionChanges - All attributes are Removed when next is empty``() =
        let prev = [| attrA.WithValue(makeSlice [| makeWidget 1 |]) |]
        let changes = toChanges alwaysReuse prev [||]

        Assert.AreEqual([ RemovedKind attrA.Key ], changes)

    [<Test>]
    member _.``WidgetCollectionChanges - Same key with identical single item still emits an Update item change (per-index diffing is unconditional)``() =
        let widget = makeWidget 1
        let prev = [| attrA.WithValue(makeSlice [| widget |]) |]
        let next = [| attrA.WithValue(makeSlice [| widget |]) |]
        let changes = toChanges alwaysReuse prev next

        // Unlike WidgetChanges (which compares widget identity before diffing), the
        // collection's item-level enumerator diffs every overlapping index
        // unconditionally when canReuseView is true, regardless of whether the widget
        // reference/value actually differs.
        Assert.AreEqual([ UpdatedKind(attrA.Key, [ UpdateKind 0 ]) ], changes)

    [<Test>]
    member _.``WidgetCollectionChanges - Same key with a new item appended produces Update then Insert item changes``() =
        let prev = [| attrA.WithValue(makeSlice [| makeWidget 1 |]) |]
        let next = [| attrA.WithValue(makeSlice [| makeWidget 1; makeWidget 2 |]) |]
        let changes = toChanges alwaysReuse prev next

        Assert.AreEqual([ UpdatedKind(attrA.Key, [ UpdateKind 0; InsertKind 1 ]) ], changes)

    [<Test>]
    member _.``WidgetCollectionChanges - Diffing two disjoint attribute sets produces one Removed and one Added``() =
        let prev = [| attrA.WithValue(makeSlice [| makeWidget 1 |]) |]
        let next = [| attrB.WithValue(makeSlice [| makeWidget 1 |]) |]
        let changes = toChanges alwaysReuse prev next

        Assert.AreEqual(2, changes.Length)
        Assert.True(changes |> List.contains(RemovedKind attrA.Key))
        Assert.True(changes |> List.contains(AddedKind attrB.Key))

    // WidgetCollectionItemChanges (item-level diffing within a single collection attribute)

    [<Test>]
    member _.``WidgetCollectionItemChanges - Empty prev and next produce no item changes``() =
        let changes = toItemChanges alwaysReuse [||] [||]
        Assert.AreEqual(0, changes.Length)

    [<Test>]
    member _.``WidgetCollectionItemChanges - All items are Insert when prev is empty``() =
        let next = [| makeWidget 1; makeWidget 2 |]
        let changes = toItemChanges alwaysReuse [||] next

        Assert.AreEqual([ InsertKind 0; InsertKind 1 ], changes)

    [<Test>]
    member _.``WidgetCollectionItemChanges - All items are Remove (from the tail) when next is empty``() =
        let prev = [| makeWidget 1; makeWidget 2 |]
        let changes = toItemChanges alwaysReuse prev [||]

        // Removal walks the tail backwards, so the highest index is produced first.
        Assert.AreEqual([ RemoveKind 1; RemoveKind 0 ], changes)

    [<Test>]
    member _.``WidgetCollectionItemChanges - Same-length collections with canReuseView true produce Update for every index``() =
        let prev = [| makeWidget 1; makeWidget 2 |]
        let next = [| makeWidget 3; makeWidget 4 |]
        let changes = toItemChanges alwaysReuse prev next

        Assert.AreEqual([ UpdateKind 0; UpdateKind 1 ], changes)

    [<Test>]
    member _.``WidgetCollectionItemChanges - Same-length collections with canReuseView false produce Replace for every index``() =
        let prev = [| makeWidget 1; makeWidget 2 |]
        let next = [| makeWidget 3; makeWidget 4 |]
        let changes = toItemChanges neverReuse prev next

        Assert.AreEqual([ ReplaceKind 0; ReplaceKind 1 ], changes)

    [<Test>]
    member _.``WidgetCollectionItemChanges - A longer next produces Insert for the extra trailing items``() =
        let prev = [| makeWidget 1 |]
        let next = [| makeWidget 2; makeWidget 3 |]
        let changes = toItemChanges alwaysReuse prev next

        Assert.AreEqual([ UpdateKind 0; InsertKind 1 ], changes)

    [<Test>]
    member _.``WidgetCollectionItemChanges - A shorter next produces Remove for the extra trailing prev items``() =
        let prev = [| makeWidget 1; makeWidget 2; makeWidget 3 |]
        let next = [| makeWidget 4 |]
        let changes = toItemChanges alwaysReuse prev next

        // The two tail items beyond next's length are removed first (highest index
        // first), then the remaining overlapping index is diffed.
        Assert.AreEqual([ RemoveKind 2; RemoveKind 1; UpdateKind 0 ], changes)
