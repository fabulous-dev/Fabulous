namespace Fabulous

type IRunner =
    abstract Key: int
    abstract Start: obj voption -> unit
    abstract Pause: unit -> unit
    abstract Stop: unit -> unit

type IDispatcher<'msg> =
    abstract Dispatch: 'msg -> unit

module Dispatchers =
    open System.Collections.Generic
    
    let private _store = Dictionary<int, obj>()

    let get<'msg> (key: int) : IDispatcher<'msg> = unbox _store.[key]
    let set<'msg> (key: int) (dispatcher: IDispatcher<'msg>) = _store.Add(key, box dispatcher)
    let delete (key: int) = _store.Remove(key) |> ignore

type Runner<'arg, 'model, 'msg> (key: int, program: IProgram<'arg, 'model, 'msg>) =
    static let mutable _runnersCount = 0
    let mutable _isRunning = false

    static member Create(program: IProgram<'arg, 'model, 'msg>) =
        let key = _runnersCount + 1
        let runner = Runner(key, program) :> IRunner
        _runnersCount <- _runnersCount
        runner

    interface IRunner with
        member _.Key = key

        member this.Start(argOpt) =
            match argOpt with
            | ValueNone -> ()
            | ValueSome arg ->
                let model = program.Init(unbox arg)
                let viewElement = program.View(model)
                StateStore.set key model viewElement

            Dispatchers.set key this
            _isRunning <- true

        member _.Pause() =
            _isRunning <- false
            Dispatchers.delete key

        member _.Stop() =
            _isRunning <- false
            Dispatchers.delete key
            StateStore.delete key

    interface IDispatcher<'msg> with
        member _.Dispatch(msg) =
            if not _isRunning then
                () // drop message if runner is paused or stopped
            else
                let model, _ = StateStore.get key
                let newModel = program.Update(msg, unbox model)
                let newView = program.View(newModel)
                StateStore.set key newModel newView

module Program =
    let mkSimple init update view =
        { new IProgram<'arg, 'model, 'msg> with
            member _.Init(arg) = init arg
            member _.Update(msg, model) = update msg model
            member _.View(model) = view model }