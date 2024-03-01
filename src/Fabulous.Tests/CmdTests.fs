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
