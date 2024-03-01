namespace Fabulous

open System.Threading
open System.Threading.Tasks

/// Dispatch - feed new message into the processing loop
type Dispatch<'msg> = 'msg -> unit

/// Subscription - return immediately, but may schedule dispatch of a message at any time
type Effect<'msg> = Dispatch<'msg> -> unit

/// Cmd - container for effects that may produce messages
type Cmd<'msg> = Effect<'msg> list

/// Cmd module for creating and manipulating commands
[<RequireQualifiedAccess>]
module Cmd =
    /// Execute the commands using the supplied dispatcher
    let internal exec onError (dispatch: Dispatch<'msg>) (cmd: Cmd<'msg>) =
        cmd
        |> List.iter(fun call ->
            try
                call dispatch
            with ex ->
                onError ex)

    /// None - no commands, also known as `[]`
    let none: Cmd<'msg> = []

    /// When emitting the message, map to another type
    let map (f: 'a -> 'msg) (cmd: Cmd<'a>) : Cmd<'msg> =
        cmd |> List.map(fun g -> (fun dispatch -> f >> dispatch) >> g)

    /// Aggregate multiple commands
    let batch (cmds: Cmd<'msg> list) : Cmd<'msg> = List.concat cmds

    /// Command to call the effect
    let ofEffect (effect: Effect<'msg>) : Cmd<'msg> = [ effect ]

    /// Command to issue a specific message
    let ofMsg (msg: 'msg) : Cmd<'msg> = [ fun dispatch -> dispatch msg ]

    /// Command to issue a specific message, only when Option.IsSome = true
    let ofMsgOption (msg: 'msg option) : Cmd<'msg> =
        [ fun dispatch ->
              match msg with
              | None -> ()
              | Some msg -> dispatch msg ]

    module OfFunc =
        /// Command to evaluate a simple function and map the result
        /// into success or error (of exception)
        let either (task: 'a -> _) (arg: 'a) (ofSuccess: _ -> 'msg) (ofError: _ -> 'msg) : Cmd<'msg> =
            let bind dispatch =
                try
                    task arg |> (ofSuccess >> dispatch)
                with x ->
                    x |> (ofError >> dispatch)

            [ bind ]

        /// Command to evaluate a simple function and map the success to a message
        /// discarding any possible error
        let perform (task: 'a -> _) (arg: 'a) (ofSuccess: _ -> 'msg) : Cmd<'msg> =
            let bind dispatch =
                try
                    task arg |> (ofSuccess >> dispatch)
                with x ->
                    ()

            [ bind ]

        /// Command to evaluate a simple function and map the error (in case of exception)
        let attempt (task: 'a -> unit) (arg: 'a) (ofError: _ -> 'msg) : Cmd<'msg> =
            let bind dispatch =
                try
                    task arg
                with x ->
                    x |> (ofError >> dispatch)

            [ bind ]

    module OfAsyncWith =
        /// Command that will evaluate an async block and map the result
        /// into success or error (of exception)
        let either (start: Async<unit> -> unit) (task: 'a -> Async<_>) (arg: 'a) (ofSuccess: _ -> 'msg) (ofError: _ -> 'msg) : Cmd<'msg> =
            let bind dispatch =
                async {
                    let! r = task arg |> Async.Catch

                    dispatch(
                        match r with
                        | Choice1Of2 x -> ofSuccess x
                        | Choice2Of2 x -> ofError x
                    )
                }

            [ bind >> start ]

        /// Command that will evaluate an async block and map the success
        let perform (start: Async<unit> -> unit) (task: 'a -> Async<_>) (arg: 'a) (ofSuccess: _ -> 'msg) : Cmd<'msg> =
            let bind dispatch =
                async {
                    let! r = task arg |> Async.Catch

                    match r with
                    | Choice1Of2 x -> dispatch(ofSuccess x)
                    | _ -> ()
                }

            [ bind >> start ]

        /// Command that will evaluate an async block and map the error (of exception)
        let attempt (start: Async<unit> -> unit) (task: 'a -> Async<_>) (arg: 'a) (ofError: _ -> 'msg) : Cmd<'msg> =
            let bind dispatch =
                async {
                    let! r = task arg |> Async.Catch

                    match r with
                    | Choice2Of2 x -> dispatch(ofError x)
                    | _ -> ()
                }

            [ bind >> start ]

        /// Command that will evaluate an async block and map the success
        let performOption (start: Async<unit> -> unit) (task: 'a -> Async<_ option>) (arg: 'a) (ofSuccess: _ -> 'msg) : Cmd<'msg> =
            let bind dispatch =
                async {
                    let! r = task arg

                    match r with
                    | Some x -> dispatch(ofSuccess x)
                    | None -> ()
                }

            [ bind >> start ]

    module OfAsync =
        /// Command that will evaluate an async block and map the result
        /// into success or error (of exception)
        let inline either (task: 'a -> Async<_>) (arg: 'a) (ofSuccess: _ -> 'msg) (ofError: _ -> 'msg) : Cmd<'msg> =
            OfAsyncWith.either Async.Start task arg ofSuccess ofError

        /// Command that will evaluate an async block and map the success
        let inline perform (task: 'a -> Async<_>) (arg: 'a) (ofSuccess: _ -> 'msg) : Cmd<'msg> =
            OfAsyncWith.perform Async.Start task arg ofSuccess

        /// Command that will evaluate an async block and map the error (of exception)
        let inline attempt (task: 'a -> Async<_>) (arg: 'a) (ofError: _ -> 'msg) : Cmd<'msg> =
            OfAsyncWith.attempt Async.Start task arg ofError

        let inline msg (task: Async<'msg>) =
            OfAsyncWith.perform Async.Start (fun () -> task) () id

        let inline msgOption (task: Async<'msg option>) =
            OfAsyncWith.performOption Async.Start (fun () -> task) () id

    module OfAsyncImmediate =
        /// Command that will evaluate an async block and map the result
        /// into success or error (of exception)
        let inline either (task: 'a -> Async<_>) (arg: 'a) (ofSuccess: _ -> 'msg) (ofError: _ -> 'msg) : Cmd<'msg> =
            OfAsyncWith.either Async.StartImmediate task arg ofSuccess ofError

        /// Command that will evaluate an async block and map the success
        let inline perform (task: 'a -> Async<_>) (arg: 'a) (ofSuccess: _ -> 'msg) : Cmd<'msg> =
            OfAsyncWith.perform Async.StartImmediate task arg ofSuccess

        /// Command that will evaluate an async block and map the error (of exception)
        let inline attempt (task: 'a -> Async<_>) (arg: 'a) (ofError: _ -> 'msg) : Cmd<'msg> =
            OfAsyncWith.attempt Async.StartImmediate task arg ofError

    module OfTask =
        /// Command to call a task and map the results
        let inline either (task: 'a -> Task<_>) (arg: 'a) (ofSuccess: _ -> 'msg) (ofError: _ -> 'msg) : Cmd<'msg> =
            OfAsync.either (task >> Async.AwaitTask) arg ofSuccess ofError

        /// Command to call a task and map the success
        let inline perform (task: 'a -> Task<_>) (arg: 'a) (ofSuccess: _ -> 'msg) : Cmd<'msg> =
            OfAsync.perform (task >> Async.AwaitTask) arg ofSuccess

        /// Command to call a task and map the error
        let inline attempt (task: 'a -> #Task) (arg: 'a) (ofError: _ -> 'msg) : Cmd<'msg> =
            OfAsync.attempt (task >> Async.AwaitTask) arg ofError

        let inline msg (task: Task<'msg>) = OfAsync.msg(task |> Async.AwaitTask)

        let inline msgOption (task: Task<'msg option>) =
            OfAsync.msgOption(task |> Async.AwaitTask)

    /// <summary>Creates a factory for Commands that dispatch a message only
    /// if the factory produces no other Command within the specified timeout.
    /// Helps control how often a message is dispatched by delaying the dispatch after a period of inactivity.
    /// Useful for handling noisy inputs like keypresses or scrolling, and preventing too many actions in a short time, like rapid button clicks.
    /// Note that this creates an object with internal state and is intended to be used per Program or longer-running background process
    /// rather than once per message in the update function.</summary>
    /// <param name="timeout">The time to wait for the next Command from the factory in milliseconds.</param>
    /// <param name="fn">Maps a factory input value to a message for delayed dispatch.</param>
    /// <returns>A Command factory function that maps an input value to a "sleeper" Command which dispatches a delayed message (mapped from the value).
    /// This command is cancelled if the factory produces another Command within the specified timeout; otherwise it succeeds and the message is dispatched.</returns>
    let debounce (timeout: int) (fn: 'value -> 'msg) : 'value -> Cmd<'msg> =
        let funLock = obj() // ensures safe access to resources shared across different threads
        let mutable cts: CancellationTokenSource = null // if set, allows cancelling the last issued Command

        // return a factory function mapping input values to "sleeper" Commands with delayed dispatch
        fun (value: 'value) ->
            [ fun dispatch ->
                  lock funLock (fun () ->
                      // cancel the last sleeping Command issued earlier from this factory
                      if cts <> null then
                          cts.Cancel()
                          cts.Dispose()

                      // make cancellation available to the factory's next Command
                      cts <- new CancellationTokenSource()

                      // asynchronously wait for the specified time before dispatch
                      Async.Start(
                          async {
                              do! Async.Sleep(timeout)

                              lock funLock (fun () ->
                                  dispatch(fn value)

                                  // done; invalidate own cancellation token
                                  if cts <> null then
                                      cts.Dispose()
                                      cts <- null)
                          },
                          cts.Token
                      )) ]

    /// <summary>Creates a factory for Commands that dispatch a message only
    /// if the factory produced no other Command within the specified interval.
    /// This limits how often a message is dispatched by ensuring to only dispatch once within a certain time interval
    /// and dropping messages that are produces during the cooldown.
    /// Useful for limiting how often a progress message is shown or preventing too many updates to a UI element in a short time.
    /// Note that this creates an object with internal state and is intended to be used per Program or longer-running background process
    /// rather than once per message in the update function.</summary>
    /// <param name="interval">The minimum time interval between two consecutive Command executions in milliseconds.</param>
    /// <param name="fn">Maps a factory input value to a message for dispatch.</param>
    /// <returns>A Command factory function that maps an input value to a "throttled" Command which dispatches a message (mapped from the value)
    /// if the minimum time interval has elapsed since the last Command execution; otherwise, it does nothing.</returns>
    let throttle (interval: int) (fn: 'value -> 'msg) : 'value -> Cmd<'msg> =
        let mutable lastDispatch = System.DateTime.MinValue

        // return a factory function mapping input values to "throttled" Commands that only dispatch if enough time passed
        fun (value: 'value) ->
            [ fun dispatch ->
                  let now = System.DateTime.UtcNow

                  // If the interval has elapsed since the last execution, dispatch the message
                  if now - lastDispatch >= System.TimeSpan.FromMilliseconds(float interval) then
                      lastDispatch <- now
                      dispatch(fn value) ]

    /// <summary>
    /// Creates a Command factory that dispatches the most recent message in a given interval - even if delayed.
    /// This makes it similar to <see cref="throttle"/> in that it rate-limits the message dispatch
    /// and similar to <see cref="debounce"/> in that it guarantees the last message (within the interval or in total) is dispatched.
    /// Helpful for scenarios where you want to throttle, but cannot risk losing the last message to throttling
    /// - like the last progress update that completes a progress.
    /// Note that this function creates an object with internal state and is intended to be used per Program or longer-running background process
    /// rather than once per message in the update function.
    /// </summary>
    /// <param name="interval">The minimum time interval between two consecutive Command executions in milliseconds.</param>
    /// <param name="fn">A function that maps a factory input value to a message for dispatch.</param>
    /// <returns>
    /// A Command factory function that maps an input value to a Command which dispatches a message (mapped from the value), either immediately
    /// or after a delay respecting the interval, while cancelling older commands if the factory produces another Command before the interval has elapsed.
    /// </returns>
    let bufferedThrottle (interval: int) (fn: 'value -> 'msg) : 'value -> Cmd<'msg> =
        let rateLimit = System.TimeSpan.FromMilliseconds(float interval)
        let funLock = obj() // ensures safe access to resources shared across different threads
        let mutable lastDispatch = System.DateTime.MinValue
        let mutable cts: CancellationTokenSource = null // if set, allows cancelling the last issued Command

        // Return a factory function mapping input values to sleeper Commands with delayed dispatch of the most recent message
        fun (value: 'value) ->
            [ fun dispatch ->
                  lock funLock (fun () ->
                      let now = System.DateTime.UtcNow
                      let elapsedSinceLastDispatch = now - lastDispatch

                      // If the interval has elapsed since the last dispatch, dispatch immediately
                      if elapsedSinceLastDispatch >= rateLimit then
                          dispatch(fn value)
                          lastDispatch <- now
                      else // schedule the dispatch for when the interval is up
                          // cancel the last sleeper Command issued earlier from this factory
                          if cts <> null then
                              cts.Cancel()
                              cts.Dispose()

                          // make cancellation available to the factory's next Command
                          cts <- new CancellationTokenSource()

                          // asynchronously wait for the remaining time before dispatch
                          Async.Start(
                              async {
                                  do! Async.Sleep(rateLimit - elapsedSinceLastDispatch)

                                  lock funLock (fun () ->
                                      dispatch(fn value)
                                      lastDispatch <- System.DateTime.UtcNow

                                      // done; invalidate own cancellation token
                                      if cts <> null then
                                          cts.Dispose()
                                          cts <- null)
                              },
                              cts.Token
                          )) ]
