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
    member _.``Cmd.debounce only dispatch the last message``() =
        async {
            let mutable actualValue = None
            let dispatch msg =
                if actualValue.IsNone then
                    actualValue <- Some msg
            
            let triggerCmd = Cmd.debounce 100 NewValue
            
            triggerCmd 1 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 50
            triggerCmd 2 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 75
            triggerCmd 3 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 125
            
            Assert.AreEqual(Some(NewValue 3), actualValue)
        }