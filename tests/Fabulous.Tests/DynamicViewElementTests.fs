// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Tests

open Fabulous
open NUnit.Framework
open FsUnit

module DynamicViewElementTests =
    type FakeControl() = class end

    let getFakeControlViewElement attribs =
        let create _ _ = FakeControl()
        let update _ _ _ _ = ()
        let updateAttachedProperties _ _ _ _ _ = ()
        let unmount _ _ _ = ()
        let handler = Registrar.Register("FakeControl", create, update, updateAttachedProperties, unmount)
        DynamicViewElement.Create(handler, attribs)

    let definition =
        { canReuseView = fun _ _ -> true
          dispatch = ignore
          trace = fun _ _ -> ()
          traceLevel = TraceLevel.None }

    [<Test>]
    let ``Given a DynamicViewElement with a ViewRef, ViewRef.Value should return the element after DynamicViewElement.Create``() =
        let viewRef = ViewRef<FakeControl>()
        let attribs = AttributesBuilder()
        attribs.Add(DynamicViewElement.RefAttribKey, viewRef.Unbox)
        let viewElement = getFakeControlViewElement attribs

        let target = viewElement.Create(definition, ValueNone)

        viewRef.Value |> should equal target

    [<Test>]
    let ``Given 2 DynamicViewElements using the same ViewRef, ViewRef.Value should return the new element after DynamicViewElement.Update``() =
        let viewRef = ViewRef<FakeControl>()

        let prevAttribs = AttributesBuilder()
        prevAttribs.Add(DynamicViewElement.RefAttribKey, viewRef.Unbox)
        let prev = getFakeControlViewElement prevAttribs
        let _oldTarget = prev.Create(definition, ValueNone)

        let currAttribs = AttributesBuilder()
        currAttribs.Add(DynamicViewElement.RefAttribKey, viewRef.Unbox)
        let curr = getFakeControlViewElement currAttribs

        let newTarget = FakeControl()

        curr.Update(definition, ValueSome prev, newTarget)

        viewRef.Value |> should equal newTarget

    [<Test>]
    let ``Given 2 DynamicViewElements using different ViewRef, the old ViewRef.TryValue should return None and the new ViewRef.Value should return the new element after DynamicViewElement.Update``() =
        let prevViewRef = ViewRef<FakeControl>()
        let prevAttribs = AttributesBuilder()
        prevAttribs.Add(DynamicViewElement.RefAttribKey, prevViewRef.Unbox)
        let prev = getFakeControlViewElement prevAttribs
        let _oldTarget = prev.Create(definition, ValueNone)

        let currViewRef = ViewRef<FakeControl>()
        let currAttribs = AttributesBuilder()
        currAttribs.Add(DynamicViewElement.RefAttribKey, currViewRef.Unbox)
        let curr = getFakeControlViewElement currAttribs

        let newTarget = FakeControl()

        curr.Update(definition, ValueSome prev, newTarget)

        prevViewRef.TryValue |> should equal None
        currViewRef.Value |> should equal newTarget

    [<Test>]
    let ``Given 2 DynamicViewElements using the same ViewRef, ViewRef should not trigger the Detach event after DynamicViewElement.Update``() =
        let mutable hasDetached = false
        let viewRef = ViewRef<FakeControl>()
        viewRef.Detached.Add(fun _ -> hasDetached <- true)

        let prevAttribs = AttributesBuilder()
        prevAttribs.Add(DynamicViewElement.RefAttribKey, viewRef.Unbox)
        let prev = getFakeControlViewElement prevAttribs
        let _oldTarget = prev.Create(definition, ValueNone)

        let currAttribs = AttributesBuilder()
        currAttribs.Add(DynamicViewElement.RefAttribKey, viewRef.Unbox)
        let curr = getFakeControlViewElement currAttribs

        let newTarget = FakeControl()

        curr.Update(definition, ValueSome prev, newTarget)

        hasDetached |> should equal false

    [<Test>]
    let ``Given 2 DynamicViewElements using different ViewRef, the old ViewRef should trigger the Detach event after DynamicViewElement.Update``() =
        let mutable hasPrevDetached = false
        let prevViewRef = ViewRef<FakeControl>()
        prevViewRef.Detached.Add(fun _ -> hasPrevDetached <- true)

        let prevAttribs = AttributesBuilder()
        prevAttribs.Add(DynamicViewElement.RefAttribKey, prevViewRef.Unbox)
        let prev = getFakeControlViewElement prevAttribs
        let _oldTarget = prev.Create(definition, ValueNone)

        let currViewRef = ViewRef<FakeControl>()
        let currAttribs = AttributesBuilder()
        currAttribs.Add(DynamicViewElement.RefAttribKey, currViewRef.Unbox)
        let curr = getFakeControlViewElement currAttribs

        let newTarget = FakeControl()

        curr.Update(definition, ValueSome prev, newTarget)

        hasPrevDetached |> should equal true