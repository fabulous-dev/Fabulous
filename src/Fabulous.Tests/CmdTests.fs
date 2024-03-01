namespace Fabulous.Tests

open Fabulous
open NUnit.Framework

type CmdTestsMsg = NewValue of int

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
