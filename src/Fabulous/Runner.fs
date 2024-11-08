namespace Fabulous

open System
open System.Collections.Concurrent

// Runners are responsible for the Model-Update part of MVU.
// Runner is created for the component itself. No point in reusing a runner for another component

/// Create a new Runner handling the update loop for the component
type Runner<'arg, 'model, 'msg>(getState: unit -> 'model, setState: 'model -> unit, program: Program<'arg, 'model, 'msg>) =
    let mutable _activeSubs = Sub.Internal.empty
    let mutable _reentering = false
    let mutable _stopped = false
    let queue = ConcurrentQueue<'msg>()

    let onError (message, exn) =
        let ex = Exception(message, exn)

        if not(program.ExceptionHandler ex) then
            raise ex

    let processMsgs dispatch msg =
        let mutable lastMsg = ValueSome msg

        while not _stopped && lastMsg.IsSome do
            let model = getState()
            let newModel, cmd = program.Update(lastMsg.Value, model)
            let subs = program.Subscribe(newModel)

            printfn $"Updating model. Was %A{model}, Is %A{newModel}"

            setState newModel

            _activeSubs <- Sub.Internal.diff _activeSubs subs |> Sub.Internal.Fx.change onError dispatch

            Cmd.exec (fun ex -> onError("Error updating", ex)) dispatch cmd

            lastMsg <-
                match queue.TryDequeue() with
                | false, _ -> ValueNone
                | true, msg -> ValueSome msg

    let rec dispatch msg =
        try
            if _stopped then
                () // Message arrived after Runner got disposed, simply discard it
            else if _reentering then
                queue.Enqueue(msg)
            else
                _reentering <- true
                processMsgs dispatch msg
                _reentering <- false
        with ex ->
            _reentering <- false

            if not(program.ExceptionHandler ex) then
                reraise()

    let start arg =
        try
            _reentering <- true

            let model, cmd = program.Init(arg)
            setState model

            // Start the subscriptions
            let subs = program.Subscribe(model)
            _activeSubs <- Sub.Internal.diff _activeSubs subs |> Sub.Internal.Fx.change onError dispatch

            // Execute the commands
            Cmd.exec (fun ex -> onError("Error initializing", ex)) dispatch cmd

            _reentering <- false
        with ex ->
            _reentering <- false

            if not(program.ExceptionHandler(ex)) then
                reraise()

    let stop () =
        try
            _stopped <- true
            queue.Clear()
            Sub.Internal.Fx.stop onError _activeSubs
            _activeSubs <- Sub.Internal.empty
        with ex ->
            _reentering <- false

            if not(program.ExceptionHandler(ex)) then
                reraise()

    /// Start the Runner loop
    member _.Start(arg) = start arg

    /// Dispatch a message to the Runner loop
    member _.Dispatch(msg) = dispatch msg

    interface IDisposable with
        member _.Dispose() = stop()
