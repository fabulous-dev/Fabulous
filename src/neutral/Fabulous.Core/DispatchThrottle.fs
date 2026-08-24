namespace Fabulous

open System
open System.Collections.Generic
open System.Threading
open System.Threading.Tasks

/// Schedules one-shot callbacks for throttled dispatchers.
type IDispatchThrottleScheduler =
    abstract Schedule: delay: TimeSpan * callback: (unit -> unit) -> IDisposable

type internal TimerDispatchThrottleScheduler() =
    interface IDispatchThrottleScheduler with
        member _.Schedule(delay, callback) =
            new Timer(TimerCallback(fun _ -> callback()), null, delay, Timeout.InfiniteTimeSpan)

type internal DispatchThrottleMode =
    | Leading
    | Latest
    | Batch

/// A thread-safe, lifecycle-owning dispatcher that limits how often values are forwarded.
type DispatchThrottle<'value>
    internal (scheduler: IDispatchThrottleScheduler, interval: TimeSpan, mode: DispatchThrottleMode, emit: IReadOnlyList<'value> -> unit, onError: exn -> unit)
    =

    let syncRoot = obj()
    let pending = ResizeArray<'value>()
    let mutable timer: IDisposable = null
    let mutable timerGeneration = 0L
    let mutable disposed = false

    do
        if interval <= TimeSpan.Zero then
            invalidArg (nameof interval) "The throttle interval must be greater than zero."

    let reportError ex =
        try
            onError ex
        with _ ->
            ()

    let takePending () =
        let values = pending.ToArray()
        pending.Clear()
        values :> IReadOnlyList<'value>

    let rec schedule () =
        timerGeneration <- timerGeneration + 1L
        let scheduledGeneration = timerGeneration

        timer <-
            scheduler.Schedule(
                interval,
                fun () ->
                    let values =
                        lock syncRoot (fun () ->
                            if disposed || scheduledGeneration <> timerGeneration then
                                None
                            elif pending.Count = 0 then
                                timer <- null
                                None
                            else
                                let values = takePending()
                                schedule()
                                Some values)

                    match values with
                    | Some values ->
                        try
                            emit values
                        with ex ->
                            reportError ex
                    | None -> ()
            )

    /// Offers a value to the throttle. This member is safe to call concurrently.
    member _.Dispatch(value: 'value) =
        let values =
            lock syncRoot (fun () ->
                if disposed then
                    raise(ObjectDisposedException(nameof DispatchThrottle))

                if isNull timer then
                    schedule()
                    Some([| value |] :> IReadOnlyList<'value>)
                else
                    match mode with
                    | Leading -> None
                    | Latest ->
                        pending.Clear()
                        pending.Add(value)
                        None
                    | Batch ->
                        pending.Add(value)
                        None)

        values |> Option.iter emit

    /// Immediately forwards pending values and resets the throttle interval.
    member _.FlushAsync() =
        let values =
            lock syncRoot (fun () ->
                if disposed then
                    raise(ObjectDisposedException(nameof DispatchThrottle))

                if not(isNull timer) then
                    timer.Dispose()
                    timer <- null
                    timerGeneration <- timerGeneration + 1L

                if pending.Count = 0 then None else Some(takePending()))

        match values with
        | None -> Task.CompletedTask
        | Some values ->
            try
                emit values
                Task.CompletedTask
            with ex ->
                Task.FromException(ex)

    /// Cancels the timer and drops pending values. Call FlushAsync first to preserve them.
    member _.Dispose() =
        lock syncRoot (fun () ->
            if not disposed then
                disposed <- true
                pending.Clear()

                if not(isNull timer) then
                    timer.Dispose()
                    timer <- null
                    timerGeneration <- timerGeneration + 1L)

    interface IDisposable with
        member this.Dispose() = this.Dispose()

/// Thread-safe throttled dispatch factories.
[<RequireQualifiedAccess>]
module Dispatch =
    let private create scheduler interval mode emit onError =
        new DispatchThrottle<_>(scheduler, interval, mode, emit, onError)

    /// Dispatches the first value immediately and drops values received during the interval.
    let throttleWith scheduler interval map dispatch onError =
        create scheduler interval Leading (fun values -> values[0] |> map |> dispatch) onError

    /// Dispatches the first value immediately, then the latest pending value at each interval.
    let throttleLatestWith scheduler interval map dispatch onError =
        create scheduler interval Latest (fun values -> values[values.Count - 1] |> map |> dispatch) onError

    /// Dispatches the first value immediately, then all pending values as a batch at each interval.
    let batchThrottledWith scheduler interval map dispatch onError =
        create scheduler interval Batch (fun values -> values |> Seq.toList |> map |> dispatch) onError

    /// Dispatches the first value immediately and drops values received during the interval.
    let throttle interval map dispatch =
        throttleWith (TimerDispatchThrottleScheduler()) interval map dispatch ignore

    /// Dispatches the first value immediately, then the latest pending value at each interval.
    let throttleLatest interval map dispatch =
        throttleLatestWith (TimerDispatchThrottleScheduler()) interval map dispatch ignore

    /// Dispatches the first value immediately, then all pending values as a batch at each interval.
    let batchThrottled interval map dispatch =
        batchThrottledWith (TimerDispatchThrottleScheduler()) interval map dispatch ignore
