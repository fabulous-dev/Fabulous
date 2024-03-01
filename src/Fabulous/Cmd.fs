namespace Fabulous

open System.Threading
open System.Threading.Tasks

/// <summary>
/// A function that feeds a new Message into the processing loop.
/// <seealso href="https://elmish.github.io/elmish/#dispatch-loop" />
/// </summary>
type Dispatch<'msg> = 'msg -> unit

/// <summary>
/// A function that returns immediately, but may schedule dispatch of one or multiple Messages at any time
/// via its access to a Dispatch function.
/// This is an abstraction over raw Messages passed along to the MVU processing loop
/// necessary to deal with real-world scenarios in which Effect functions may take a while to complete.
/// This models an Elm "side-effect" like in
/// <seealso href="https://elmish.github.io/elmish/#tasks-and-side-effects" />
/// or
/// <seealso href="https://elmprogramming.com/side-effects.html" />
/// </summary>
type Effect<'msg> = Dispatch<'msg> -> unit

/// <summary>
/// A list of Effects that may dispatch Messages;
/// the carriers of instructions you issue from the init and update functions.
/// See
/// <seealso href="https://elmish.github.io/elmish/#commands" />
/// </summary>
type Cmd<'msg> = Effect<'msg> list

/// A module for creating and manipulating Commands
/// with a Command being a list of Message-dispatching Effects you issue from the init and update functions
/// and an Effect being a function with access to a Dispatch function receiving a Message.
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

    /// No command; an empty list of Message-dispatching Effects equivalent to `[]`.
    /// For when you don't want to issue a Command.
    let none: Cmd<'msg> = []

    /// <summary>
    /// Converts a Command of type 'a into a Command of type 'msg.
    /// This is useful for emitting Commands of a uniform type,
    /// like when receiving child messages in a parent-child composition scenario. See
    /// <seealso href="https://elmish.github.io/elmish/docs/parent-child.html" />
    /// </summary>
    let map (f: 'a -> 'msg) (cmd: Cmd<'a>) : Cmd<'msg> =
        cmd |> List.map(fun g -> (fun dispatch -> f >> dispatch) >> g)

    /// <summary>
    /// Concatenates the Effects of multiple Commands into one list.
    /// Use for emitting multiple Commands at the same time from the init or update function.
    /// E.g. in an parent-child composition scenario:
    /// <seealso href="https://elmish.github.io/elmish/docs/parent-child.html" />
    /// </summary>
    let batch (cmds: Cmd<'msg> list) : Cmd<'msg> = List.concat cmds

    /// <summary>
    /// Returns a command to call a custom Effect function with access to a Dispatch function.
    /// Use for example to dispatch status updates or yield partial results from long-running background tasks.
    /// </summary>
    let ofEffect (effect: Effect<'msg>) : Cmd<'msg> = [ effect ]

    /// Command to issue a specific message.
    /// Wraps the message into the Command structure returned from the update and init functions.
    let ofMsg (msg: 'msg) : Cmd<'msg> = [ fun dispatch -> dispatch msg ]

    /// Command to issue the message from the message option if Option.IsSome
    let ofMsgOption (msg: 'msg option) : Cmd<'msg> =
        [ fun dispatch ->
              match msg with
              | None -> ()
              | Some msg -> dispatch msg ]

    /// Creates Commands from the return values and/or exceptions of simple functions,
    /// wrapping the call in a try/with statement. Use this to deal with code that may throw exceptions.
    module OfFunc =
        /// Creates a Command to evaluate a simple function and map either the return value or exception to a message
        let either (task: 'a -> _) (arg: 'a) (ofSuccess: _ -> 'msg) (ofError: _ -> 'msg) : Cmd<'msg> =
            let bind dispatch =
                try
                    task arg |> (ofSuccess >> dispatch)
                with x ->
                    x |> (ofError >> dispatch)

            [ bind ]

        /// Creates a Command to evaluate a simple function and map the return value to a message
        /// discarding any possible error
        let perform (task: 'a -> _) (arg: 'a) (ofSuccess: _ -> 'msg) : Cmd<'msg> =
            let bind dispatch =
                try
                    task arg |> (ofSuccess >> dispatch)
                with x ->
                    ()

            [ bind ]

        /// Creates a Command to evaluate a simple function returning unit
        /// and map the error (in case of exception) to a message
        let attempt (task: 'a -> unit) (arg: 'a) (ofError: _ -> 'msg) : Cmd<'msg> =
            let bind dispatch =
                try
                    task arg
                with x ->
                    x |> (ofError >> dispatch)

            [ bind ]

    /// Internal module for building Commands from the return values or exceptions of Async functions
    /// using Async.Catch like an async try/with statement.
    /// You'll probably want to use either of the modules OfAsync or OfAsyncImmediate instead of this.
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
        /// discarding any possible error
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

    /// For building Commands from Async functions queued to be run in the background, started on a thread pool thread using Async.Start.
    /// Suitable for long-running or CPU-bound computations where you want to free up the UI thread to remain responsive to do other work.
    /// See https://learn.microsoft.com/en-us/dotnet/fsharp/tutorials/async#asyncstart
    /// and https://www.microsoft.com/en-us/research/wp-content/uploads/2016/02/async-padl-revised-v2.pdf page 5.
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

        /// Command that will evaluate an async block and map the success 'msg
        let inline msg (task: Async<'msg>) =
            OfAsyncWith.perform Async.Start (fun () -> task) () id

        /// Command that will evaluate an async block and map the success 'msg Option.Value if Option.IsSome
        let inline msgOption (task: Async<'msg option>) =
            OfAsyncWith.performOption Async.Start (fun () -> task) () id

    /// For building Commands from Async functions started immediately on the current operating system thread
    /// using Async.StartImmediate. This is helpful if you need to update something on the calling thread during the computation.
    /// For example if an asynchronous computation must update a UI (such as updating a progress bar).
    /// See https://learn.microsoft.com/en-us/dotnet/fsharp/tutorials/async#asyncstartimmediate
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

    /// <summary>
    /// For building Commands from executing ("hot") .NET Tasks using Async.AwaitTask.
    /// <seealso href="https://learn.microsoft.com/en-us/dotnet/fsharp/tutorials/async#core-concepts" />
    /// </summary>
    module OfTask =
        /// Command to map both the success and possible error result of a Task
        let inline either (task: 'a -> Task<_>) (arg: 'a) (ofSuccess: _ -> 'msg) (ofError: _ -> 'msg) : Cmd<'msg> =
            OfAsync.either (task >> Async.AwaitTask) arg ofSuccess ofError

        /// Command to map the success result of a Task
        let inline perform (task: 'a -> Task<_>) (arg: 'a) (ofSuccess: _ -> 'msg) : Cmd<'msg> =
            OfAsync.perform (task >> Async.AwaitTask) arg ofSuccess

        /// Command to map the error of a Task without a success result
        let inline attempt (task: 'a -> #Task) (arg: 'a) (ofError: _ -> 'msg) : Cmd<'msg> =
            OfAsync.attempt (task >> Async.AwaitTask) arg ofError

        /// Command to map the success 'msg returned from a Task
        let inline msg (task: Task<'msg>) = OfAsync.msg(task |> Async.AwaitTask)

        /// Command to map the success 'msg Option.Value returned from a Task if Option.IsSome
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
