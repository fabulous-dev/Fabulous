namespace Fabulous.Tests

open System
open System.Collections.Generic
open System.Threading.Tasks
open Fabulous
open NUnit.Framework

type CmdTestsMsg =
    | NewValue of int
    | NewValues of int list

type private ScheduledCallback(callback: unit -> unit) =
    let mutable cancelled = false

    member _.Cancelled = cancelled
    member _.Invoke() = callback()

    interface IDisposable with
        member _.Dispose() = cancelled <- true

type private TestDispatchThrottleScheduler() =
    let callbacks = Queue<ScheduledCallback>()

    member _.RunNext() =
        let mutable callback = callbacks.Dequeue()

        while callback.Cancelled do
            callback <- callbacks.Dequeue()

        callback.Invoke()

    member _.RunNextIncludingCancelled() = callbacks.Dequeue().Invoke()

    interface IDispatchThrottleScheduler with
        member _.Schedule(_, callback) =
            let scheduled = ScheduledCallback(callback)
            callbacks.Enqueue(scheduled)
            scheduled

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

            actualValue <- None

            triggerCmd 4 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 75
            triggerCmd 5 |> CmdTestsHelper.execute dispatch
            do! Async.Sleep 125

            Assert.AreEqual(Some(NewValue 5), actualValue)
        }

[<TestFixture>]
type ``Dispatch throttle tests``() =
    let interval = TimeSpan.FromSeconds(1.0)

    [<Test>]
    member _.``Leading throttle drops intermediate values``() =
        let scheduler = TestDispatchThrottleScheduler()
        let messages = ResizeArray()
        use throttle = Dispatch.throttleWith scheduler interval NewValue messages.Add raise

        throttle.Dispatch(1)
        throttle.Dispatch(2)
        scheduler.RunNext()
        throttle.Dispatch(3)

        Assert.That(messages, Is.EqualTo([ NewValue 1; NewValue 3 ]))

    [<Test>]
    member _.``Latest throttle guarantees the final value``() =
        let scheduler = TestDispatchThrottleScheduler()
        let messages = ResizeArray()

        use throttle =
            Dispatch.throttleLatestWith scheduler interval NewValue messages.Add raise

        throttle.Dispatch(1)
        throttle.Dispatch(2)
        throttle.Dispatch(3)
        scheduler.RunNext()
        scheduler.RunNext()

        Assert.That(messages, Is.EqualTo([ NewValue 1; NewValue 3 ]))

    [<Test>]
    member _.``Batch throttle forwards every pending value``() =
        let scheduler = TestDispatchThrottleScheduler()
        let messages = ResizeArray()

        use throttle =
            Dispatch.batchThrottledWith scheduler interval NewValues messages.Add raise

        throttle.Dispatch(1)
        throttle.Dispatch(2)
        throttle.Dispatch(3)
        scheduler.RunNext()

        Assert.That(messages, Is.EqualTo([ NewValues [ 1 ]; NewValues [ 2; 3 ] ]))

    [<Test>]
    member _.``Flush forwards pending values and ignores stale callbacks``() =
        task {
            let scheduler = TestDispatchThrottleScheduler()
            let messages = ResizeArray()

            use throttle =
                Dispatch.throttleLatestWith scheduler interval NewValue messages.Add raise

            throttle.Dispatch(1)
            throttle.Dispatch(2)
            do! throttle.FlushAsync()
            throttle.Dispatch(3)
            throttle.Dispatch(4)
            scheduler.RunNextIncludingCancelled()

            Assert.That(messages, Is.EqualTo([ NewValue 1; NewValue 2; NewValue 3 ]))

            scheduler.RunNext()
            Assert.That(messages, Is.EqualTo([ NewValue 1; NewValue 2; NewValue 3; NewValue 4 ]))
        }

    [<Test>]
    member _.``Dispose drops pending values and rejects producers``() =
        let scheduler = TestDispatchThrottleScheduler()
        let messages = ResizeArray()

        let throttle =
            Dispatch.throttleLatestWith scheduler interval NewValue messages.Add raise

        throttle.Dispatch(1)
        throttle.Dispatch(2)
        throttle.Dispose()
        scheduler.RunNextIncludingCancelled()

        Assert.That(messages, Is.EqualTo([ NewValue 1 ]))
        Assert.Throws<ObjectDisposedException>(fun () -> throttle.Dispatch(3)) |> ignore

    [<Test>]
    member _.``Timer dispatch exceptions are reported``() =
        let scheduler = TestDispatchThrottleScheduler()
        let errors = ResizeArray<exn>()

        use throttle =
            Dispatch.throttleLatestWith
                scheduler
                interval
                NewValue
                (fun message ->
                    match message with
                    | NewValue 2 -> failwith "dispatch failed"
                    | _ -> ())
                errors.Add

        throttle.Dispatch(1)
        throttle.Dispatch(2)
        scheduler.RunNext()

        Assert.That(errors, Has.Count.EqualTo(1))
        Assert.That(errors[0].Message, Is.EqualTo("dispatch failed"))

    [<Test>]
    member _.``Concurrent producers preserve every batched value``() =
        task {
            let scheduler = TestDispatchThrottleScheduler()
            let batches = ResizeArray<int list>()
            use throttle = Dispatch.batchThrottledWith scheduler interval id batches.Add raise

            do!
                Parallel.ForAsync(
                    0,
                    100,
                    fun value _ ->
                        throttle.Dispatch(value)
                        ValueTask.CompletedTask
                )

            do! throttle.FlushAsync()

            Assert.That(batches |> Seq.collect id |> Seq.sort, Is.EqualTo([ 0..99 ]))
        }
