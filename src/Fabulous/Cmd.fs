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
        let inline either
            ([<InlineIfLambda>] task: 'a -> Task<_>)
            (arg: 'a)
            ([<InlineIfLambda>] ofSuccess: _ -> 'msg)
            ([<InlineIfLambda>] ofError: _ -> 'msg)
            : Cmd<'msg> =
            [ fun dispatch ->
                  backgroundTask {
                      try
                          let! r = task arg
                          ofSuccess r |> dispatch
                      with e ->
                          ofError e |> dispatch
                  }
                  |> ignore<Task<_>> ]

        /// Command to call a task and map the success
        let inline perform ([<InlineIfLambda>] task: 'a -> Task<_>) (arg: 'a) ([<InlineIfLambda>] ofSuccess: _ -> 'msg) : Cmd<'msg> =
            [ fun dispatch ->
                  backgroundTask {
                      try
                          let! r = task arg
                          ofSuccess r |> dispatch
                      with _ ->
                          ()
                  }
                  |> ignore<Task<_>> ]

        /// Command to call a task and map the error
        let inline attempt ([<InlineIfLambda>] task: 'a -> #Task) (arg: 'a) ([<InlineIfLambda>] ofError: _ -> 'msg) : Cmd<'msg> =
            [ fun dispatch ->
                  backgroundTask {
                      try
                          do! task arg
                      with e ->
                          ofError e |> dispatch
                  }
                  |> ignore<Task<_>> ]

        let inline msg (task: Task<'msg>) = perform (fun () -> task) () id

        let inline msgOption (task: Task<'msg option>) =
            [ fun dispatch ->
                  backgroundTask {
                      let! r = task

                      match r with
                      | Some x -> dispatch x
                      | None -> ()
                  }
                  |> ignore<Task<_>> ]

    /// Command to issue a message if no other message has been issued within the specified timeout
    let debounce (timeout: int) (fn: 'value -> 'msg) : 'value -> Cmd<'msg> =
        let funLock = obj()
        let mutable cts: CancellationTokenSource = null

        fun (value: 'value) ->
            [ fun dispatch ->
                  lock funLock (fun () ->
                      if not(isNull cts) then
                          cts.Cancel()
                          cts.Dispose()

                      cts <- new CancellationTokenSource()

                      Async.Start(
                          async {
                              do! Async.Sleep(timeout)

                              lock funLock (fun () ->
                                  dispatch(fn value)

                                  if not(isNull cts) then
                                      cts.Dispose()
                                      cts <- null)
                          },
                          cts.Token
                      )) ]
