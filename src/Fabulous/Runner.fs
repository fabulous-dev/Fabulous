namespace Fabulous

open System.Collections.Concurrent

// Runners are responsible for the Model-Update part of MVU.
// Runner is created for the component itself. No point in reusing a runner for another component

/// Create a new Runner handling the update loop for the component
type Runner<'arg, 'model, 'msg>(getState: unit -> 'model, setState: 'model -> unit, program: Program<'arg, 'model, 'msg>) =
    let mutable _reentering = false
    let queue = ConcurrentQueue<'msg>()

    let rec dispatch msg =
        try
            if _reentering then
                queue.Enqueue(msg)
            else
                _reentering <- true

                let mutable lastMsg = ValueSome msg

                while lastMsg.IsSome do
                    let model = getState()
                    let newModel, cmd = program.Update(lastMsg.Value, model)
                    setState newModel

                    for sub in cmd do
                        sub dispatch

                    lastMsg <-
                        match queue.TryDequeue() with
                        | false, _ -> ValueNone
                        | true, msg -> ValueSome msg

                _reentering <- false
        with ex ->
            _reentering <- false

            if not(program.ExceptionHandler ex) then
                reraise()

    let start arg =
        try
            let model, cmd = program.Init(arg)
            setState model

            let subs = program.Subscribe(model)

            for sub in subs do
                sub dispatch

            for sub in cmd do
                sub dispatch
        with ex ->
            if not(program.ExceptionHandler(ex)) then
                reraise()

    /// Start the Runner loop
    member _.Start(arg) = start arg

    /// Dispatch a message to the Runner loop
    member _.Dispatch(msg) = dispatch msg
