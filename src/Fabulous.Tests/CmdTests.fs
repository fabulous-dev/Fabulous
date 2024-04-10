namespace Fabulous.Tests

open Fabulous
open NUnit.Framework

type CmdTestsMsg =
    | NewValue of int
    | NewValues of int list

module CmdTestsHelper =
    let execute dispatch (cmd: Cmd<'msg>) =
        for sub in cmd do
            sub dispatch

[<TestFixture>]
type ``Cmd tests``() =
    [<Test>]
    member _.``Cmd.debounce only dispatches the last messages within the timeout``() =
        async {
            let mutable messageCount = 0
            let mutable actualValue = None

            let dispatch msg =
                messageCount <- messageCount + 1
                actualValue <- Some msg

            let triggerCmd = Cmd.debounce 100 NewValue

            triggerCmd 1 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 50
            triggerCmd 2 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 75
            triggerCmd 3 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 125

            Assert.AreEqual(1, messageCount)
            Assert.AreEqual(Some(NewValue 3), actualValue)

            triggerCmd 4 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 75
            triggerCmd 5 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 125

            Assert.AreEqual(2, messageCount)
            Assert.AreEqual(Some(NewValue 5), actualValue)
        }

    [<Test>]
    member _.``Cmd.throttle issues message at specified intervals``() =
        async {
            let mutable messageCount = 0
            let mutable actualValue = None

            let dispatch msg =
                messageCount <- messageCount + 1
                actualValue <- Some msg

            let throttleCmd = Cmd.throttle 100 NewValue

            throttleCmd 1 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 50
            throttleCmd 2 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 75
            throttleCmd 3 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 125

            Assert.AreEqual(2, messageCount)
            Assert.AreEqual(Some(NewValue 3), actualValue)

            throttleCmd 4 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 75
            throttleCmd 5 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 125

            Assert.AreEqual(3, messageCount)
            Assert.AreEqual(Some(NewValue 4), actualValue)
        }

    [<Test>]
    member _.``Cmd.throttle issues only one message per interval``() =
        async {
            let mutable messageCount = 0
            let mutable actualValue = None

            let dispatch msg =
                messageCount <- messageCount + 1
                actualValue <- Some msg

            let throttleCmd = Cmd.throttle 100 NewValue

            throttleCmd 1 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 20
            throttleCmd 2 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 35
            throttleCmd 3 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 125

            // Only the first message should have been dispatched
            Assert.AreEqual(1, messageCount)
            Assert.AreEqual(Some(NewValue 1), actualValue)
        }

    [<Test>]
    member _.``Cmd.bufferedThrottle dispatches the first and most recent message within the specified interval``() =
        async {
            let mutable messageCount = 0
            let mutable actualValue = None

            let dispatch msg =
                messageCount <- messageCount + 1
                actualValue <- Some msg

            let throttleCmd = Cmd.bufferedThrottle 100 NewValue

            throttleCmd 1 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 20
            throttleCmd 2 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 10
            throttleCmd 3 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 20
            throttleCmd 4 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 125

            // Only the first and most recent message should be dispatched
            Assert.AreEqual(2, messageCount)
            Assert.AreEqual(Some(NewValue 4), actualValue)
        }

    [<Test>]
    member _.``Cmd.bufferedThrottle dispatches the most recent message even if delayed``() =
        async {
            let mutable actualValue = None
            let mutable messageCount = 0

            let dispatch msg =
                messageCount <- messageCount + 1
                actualValue <- Some msg

            let throttleCmd = Cmd.bufferedThrottle 100 NewValue

            throttleCmd 1 |> CmdTestsHelper.execute dispatch
            throttleCmd 2 |> CmdTestsHelper.execute dispatch

            // Only the first message should have been dispatched
            Assert.AreEqual(1, messageCount)
            Assert.AreEqual(Some(NewValue 1), actualValue)

            do! Async.Sleep 200 // Wait longer than the throttle interval

            // the second message should have been dispatched delayed
            Assert.AreEqual(2, messageCount)
            Assert.AreEqual(Some(NewValue 2), actualValue)
        }

    [<Test>]
    member _.``Dispatch.batchThrottled dispatches all undispatched values on interval expiry``() =
        async {
            let mutable messageCount = 0
            let mutable dispatched = [] // records dispatched messages latest first

            let dispatch msg =
                messageCount <- messageCount + 1
                dispatched <- msg :: dispatched

            let batchedThrottleCmd, _ = dispatch.batchThrottled(100, NewValues)

            batchedThrottleCmd 1
            batchedThrottleCmd 2
            batchedThrottleCmd 3
            batchedThrottleCmd 4

            do! Async.Sleep 200 // Wait longer than the throttle interval

            // All three values should have been dispatched
            Assert.AreEqual(2, messageCount)
            Assert.AreEqual([ NewValues [ 2; 3; 4 ]; NewValues [ 1 ] ], dispatched)
        }

    [<Test>]
    member _.``Dispatch.batchThrottled dispatches messages immediately if interval not expired``() =
        async {
            let mutable messageCount = 0
            let mutable dispatched = [] // records dispatched messages latest first

            let dispatch msg =
                messageCount <- messageCount + 1
                dispatched <- msg :: dispatched

            let batchedThrottleCmd, _ = dispatch.batchThrottled(100, NewValues)

            batchedThrottleCmd 1
            batchedThrottleCmd 2

            // Only the first value should have been dispatched immediately
            Assert.AreEqual(1, messageCount)
            Assert.AreEqual([ NewValues[1] ], dispatched)

            (*  Wait for longer than twice the throttle interval,
                giving second value time to dispatch and elapsing time until next dispatch *)
            do! Async.Sleep 210

            batchedThrottleCmd 3
            batchedThrottleCmd 4

            // Second value should have dispatched delayed, third immediately
            Assert.AreEqual(3, messageCount)
            Assert.AreEqual([ NewValues[3]; NewValues[2]; NewValues[1] ], dispatched)

            do! Async.Sleep 110 // Wait longer than the throttle interval

            // All values should have been dispatched eventually
            Assert.AreEqual(4, messageCount)
            Assert.AreEqual([ NewValues[4]; NewValues[3]; NewValues[2]; NewValues[1] ], dispatched)
        }

    [<Test>]
    member _.``Dispatch.batchThrottled factory can be awaited for completion``() =
        async {
            let mutable messageCount = 0
            let mutable dispatched = [] // records dispatched messages latest first

            let dispatch msg =
                messageCount <- messageCount + 1
                dispatched <- msg :: dispatched

            let createCmd, awaitNextDispatch = dispatch.batchThrottled(100, NewValues)

            createCmd 1
            createCmd 2

            // Only the first value should have been dispatched immediately
            Assert.AreEqual(1, messageCount)
            Assert.AreEqual([ NewValues[1] ], dispatched)

            do! awaitNextDispatch None // only waits until next dispatch

            // All values should have been dispatched after waiting
            Assert.AreEqual(2, messageCount)
            Assert.AreEqual([ NewValues[2]; NewValues[1] ], dispatched)
        }
