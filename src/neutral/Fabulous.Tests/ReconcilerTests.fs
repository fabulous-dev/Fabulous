namespace Fabulous.Tests

open Fabulous
open NUnit.Framework

/// A minimal fake IViewNode that just records the ApplyDiff calls it receives,
/// so tests can assert on what Reconciler.update forwards to the node without
/// depending on the real ViewNode/platform rendering pipeline.
type private FakeViewNode(target: obj) =
    let mutable memoizedWidget: Widget option = None
    let mutable appliedDiffCount = 0
    // last WidgetDiff cannot be stored (it's a byref-like struct), so instead we record
    // a plain-data projection of what was observed when ApplyDiff was called.
    let mutable lastScalarChangeCount = -1

    member _.AppliedDiffCount = appliedDiffCount
    member _.LastScalarChangeCount = lastScalarChangeCount

    interface IViewNode with
        member _.Target = target

        member _.TreeContext =
            { CanReuseView = fun _ _ -> true
              GetViewNode = fun _ -> failwith "not used"
              Logger =
                { Log = (fun (_: LogLevel * string) -> ())
                  MinLogLevel = LogLevel.Error }
              Dispatch = fun _ -> ()
              SyncAction = fun action -> action()
              GetComponent = fun _ -> failwith "not used"
              SetComponent = fun _ _ -> () }

        member _.EnvironmentContext = null

        member _.MemoizedWidget
            with get () = memoizedWidget
            and set value = memoizedWidget <- value

        member _.Parent = None
        member _.IsDisconnected = false

        member _.MapMsg
            with get () = None
            and set _ = ()

        member _.TryGetHandler(_) = ValueNone
        member _.SetHandler(_, _) = ()
        member _.RemoveHandler(_) = ()

        member _.ApplyDiff(diff: WidgetDiff inref) =
            appliedDiffCount <- appliedDiffCount + 1

            let mutable count = 0
            let mutable enumerator = diff.ScalarChanges.GetEnumerator()

            while enumerator.MoveNext() do
                count <- count + 1

            lastScalarChangeCount <- count

        member _.Dispose() = ()

[<TestFixture>]
type ``Reconciler tests``() =
    // A single scalar attribute used to build simple widgets carrying one value each.
    static let scalarAttr =
        Attributes.defineSimpleScalar<int>
            "ReconcilerTests_Value"
            (fun a b ->
                if a = b then
                    ScalarAttributeComparison.Identical
                else
                    ScalarAttributeComparison.Different)
            (fun _ _ (_: IViewNode) -> ())

    let makeWidget (key: WidgetKey) (value: int) : Widget =
        { Key = key
#if DEBUG
          DebugName = "TestWidget"
#endif
          ScalarAttributes = [| scalarAttr.WithValue(value) |]
          WidgetAttributes = [||]
          WidgetCollectionAttributes = [||]
          EnvironmentAttributes = [||] }

    let makeEmptyWidget (key: WidgetKey) : Widget =
        { Key = key
#if DEBUG
          DebugName = "TestWidget"
#endif
          ScalarAttributes = [||]
          WidgetAttributes = [||]
          WidgetCollectionAttributes = [||]
          EnvironmentAttributes = [||] }

    [<Test>]
    member _.``update forwards a diff to the node's ApplyDiff exactly once``() =
        let node = new FakeViewNode(obj())
        let prev = makeWidget 1 1
        let next = makeWidget 1 2

        Reconciler.update (fun _ _ -> true) (ValueSome prev) next (node :> IViewNode)

        Assert.AreEqual(1, node.AppliedDiffCount)

    [<Test>]
    member _.``update reports no scalar changes when the attribute value is unchanged``() =
        let node = new FakeViewNode(obj())
        let prev = makeWidget 1 42
        let next = makeWidget 1 42

        Reconciler.update (fun _ _ -> true) (ValueSome prev) next (node :> IViewNode)

        Assert.AreEqual(0, node.LastScalarChangeCount)

    [<Test>]
    member _.``update reports a scalar change when the attribute value differs``() =
        let node = new FakeViewNode(obj())
        let prev = makeWidget 1 1
        let next = makeWidget 1 2

        Reconciler.update (fun _ _ -> true) (ValueSome prev) next (node :> IViewNode)

        Assert.AreEqual(1, node.LastScalarChangeCount)

    [<Test>]
    member _.``update treats a missing previous widget as all-Added scalar changes``() =
        let node = new FakeViewNode(obj())
        let next = makeWidget 1 7

        Reconciler.update (fun _ _ -> true) ValueNone next (node :> IViewNode)

        Assert.AreEqual(1, node.AppliedDiffCount)
        Assert.AreEqual(1, node.LastScalarChangeCount)

    [<Test>]
    member _.``update with two widgets carrying no attributes produces an empty diff``() =
        let node = new FakeViewNode(obj())
        let prev = makeEmptyWidget 1
        let next = makeEmptyWidget 1

        Reconciler.update (fun _ _ -> true) (ValueSome prev) next (node :> IViewNode)

        Assert.AreEqual(1, node.AppliedDiffCount)
        Assert.AreEqual(0, node.LastScalarChangeCount)
