
// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.XamarinForms.Tests

open Fabulous
open NUnit.Framework
open FsUnit

module ViewElementTests =
    type FakeControl() = class end

    let getFakeControlViewElement attribs =
        let create () = FakeControl()
        let update _ _ _ = ()
        let updateAttachedProperties _ _ _ _ = ()
        ViewElement.Create(create, update, updateAttachedProperties, attribs)

    [<Test>]
    let ``Given a ViewElement with a ViewRef, ViewRef.Value should return the element after ViewElement.Create``() =
        let viewRef = ViewRef<FakeControl>()
        let attribs = AttributesBuilder(1)
        attribs.Add(ViewElement.RefAttribKey, viewRef.Unbox)
        let viewElement = getFakeControlViewElement attribs

        let target = viewElement.Create()

        viewRef.Value |> should equal target

    [<Test>]
    let ``Given 2 ViewElements using the same ViewRef, ViewRef.Value should return the new element after ViewElement.Update``() =
        let viewRef = ViewRef<FakeControl>()

        let prevAttribs = AttributesBuilder(1)
        prevAttribs.Add(ViewElement.RefAttribKey, viewRef.Unbox)
        let prev = getFakeControlViewElement prevAttribs
        let _oldTarget = prev.Create()

        let currAttribs = AttributesBuilder(1)
        currAttribs.Add(ViewElement.RefAttribKey, viewRef.Unbox)
        let curr = getFakeControlViewElement currAttribs

        let newTarget = FakeControl()

        curr.UpdateInherited(ValueSome prev, curr, newTarget)

        viewRef.Value |> should equal newTarget

    [<Test>]
    let ``Given 2 ViewElements using different ViewRef, the old ViewRef.TryValue should return None and the new ViewRef.Value should return the new element after ViewElement.Update``() =
        let prevViewRef = ViewRef<FakeControl>()
        let prevAttribs = AttributesBuilder(1)
        prevAttribs.Add(ViewElement.RefAttribKey, prevViewRef.Unbox)
        let prev = getFakeControlViewElement prevAttribs
        let _oldTarget = prev.Create()

        let currViewRef = ViewRef<FakeControl>()
        let currAttribs = AttributesBuilder(1)
        currAttribs.Add(ViewElement.RefAttribKey, currViewRef.Unbox)
        let curr = getFakeControlViewElement currAttribs

        let newTarget = FakeControl()

        curr.UpdateInherited(ValueSome prev, curr, newTarget)

        prevViewRef.TryValue |> should equal None
        currViewRef.Value |> should equal newTarget

    [<Test>]
    let ``Given 2 ViewElements using the same ViewRef, ViewRef should not trigger the Detach event after ViewElement.Update``() =
        let mutable hasDetached = false
        let viewRef = ViewRef<FakeControl>()
        viewRef.Detached.Add(fun _ -> hasDetached <- true)

        let prevAttribs = AttributesBuilder(1)
        prevAttribs.Add(ViewElement.RefAttribKey, viewRef.Unbox)
        let prev = getFakeControlViewElement prevAttribs
        let _oldTarget = prev.Create()

        let currAttribs = AttributesBuilder(1)
        currAttribs.Add(ViewElement.RefAttribKey, viewRef.Unbox)
        let curr = getFakeControlViewElement currAttribs

        let newTarget = FakeControl()

        curr.UpdateInherited(ValueSome prev, curr, newTarget)

        hasDetached |> should equal false

    [<Test>]
    let ``Given 2 ViewElements using different ViewRef, the old ViewRef should trigger the Detach event after ViewElement.Update``() =
        let mutable hasPrevDetached = false
        let prevViewRef = ViewRef<FakeControl>()
        prevViewRef.Detached.Add(fun _ -> hasPrevDetached <- true)

        let prevAttribs = AttributesBuilder(1)
        prevAttribs.Add(ViewElement.RefAttribKey, prevViewRef.Unbox)
        let prev = getFakeControlViewElement prevAttribs
        let _oldTarget = prev.Create()

        let currViewRef = ViewRef<FakeControl>()
        let currAttribs = AttributesBuilder(1)
        currAttribs.Add(ViewElement.RefAttribKey, currViewRef.Unbox)
        let curr = getFakeControlViewElement currAttribs

        let newTarget = FakeControl()

        curr.UpdateInherited(ValueSome prev, curr, newTarget)

        hasPrevDetached |> should equal true