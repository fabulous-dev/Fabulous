namespace Fabulous

open System
open System.Collections.Generic
open Fabulous

type Program<'arg, 'model, 'msg> =
    { Init: 'arg -> 'model * Cmd<'msg>
      Update: 'msg * 'model -> 'model * Cmd<'msg>
      View: 'model -> Widget
      CanReuseView: Widget -> Widget -> bool }

type IRunner =
    interface
    end

type IViewAdapter =
    inherit IDisposable
    abstract CreateView: unit -> obj
    abstract Attach: obj -> unit
    abstract Detach: bool -> unit

module RunnerStore =
    let private _runners = Dictionary<StateKey, IRunner>()

    let get key = _runners.[key]
    let set key value = _runners.[key] <- value
    let remove key = _runners.Remove(key) |> ignore

module ViewAdapterStore =
    let private _viewAdapters =
        Dictionary<ViewAdapterKey, IViewAdapter>()

    let mutable private _nextKey = 0

    let get key = _viewAdapters.[key]
    let set key value = _viewAdapters.[key] <- value

    let remove key =
        match _viewAdapters.TryGetValue(key) with
        | false, _ -> ()
        | true, value ->
            value.Dispose()
            _viewAdapters.Remove(key) |> ignore

    let getNextKey () : ViewAdapterKey =
        let key = _nextKey
        _nextKey <- _nextKey + 1
        key

/// Runners are responsible for the Model-Update part of MVU.
/// They read from and update StateStore.
module Runners =
    // Runner is created for the component itself. No point in reusing a runner for another component
    type Runner<'arg, 'model, 'msg>(key: StateKey, program: Program<'arg, 'model, 'msg>) =

        let rec processMsg msg =
            let model = unbox (StateStore.get key)
            let newModel, cmd = program.Update(msg, model)
            StateStore.set key newModel

            for sub in cmd do
                sub processMsg

        let start arg =
            let model, cmd = program.Init(arg)
            StateStore.set key model

            for sub in cmd do
                sub processMsg

        interface IRunner

        member _.Key = key
        member _.Program = program

        member _.Dispatch(msg) = processMsg msg


        member _.Start(arg) = start arg
        member _.Pause() = ()
        member _.Restart() = ()
        member _.Stop() = ()

    let create<'arg, 'model, 'msg> (program: Program<'arg, 'model, 'msg>) =
        let key = StateStore.getNextKey ()
        let runner = Runner(key, program)
        RunnerStore.set key runner
        runner

/// ViewAdapters are responsible for the View part of MVU.
/// They listen for a specific StateKey in StateStore. Upon change, they call the component's View function,
/// calculate the diff and apply it to the actual UI control
module ViewAdapters =
    open Runners

    type ViewAdapter<'model, 'msg>
        (
            key: ViewAdapterKey,
            stateKey: StateKey,
            view: 'model -> Widget,
            canReuseView: Widget -> Widget -> bool,
            dispatch: 'msg -> unit,
            getViewNode: obj -> IViewNode
        ) as this =

        let mutable _widget: Widget = Unchecked.defaultof<Widget>
        let mutable _root = Unchecked.defaultof<obj>
        let mutable _allowDispatch = false

        let _stateSubscription =
            StateStore.StateChanged.Subscribe(this.OnStateChanged)

        member private _.Dispatch(msg) =
            if _allowDispatch then
                dispatch (unbox msg)

        member this.CreateView() =
            let state = unbox (StateStore.get stateKey)
            let widget = view state
            _widget <- widget

            let treeContext =
                { CanReuseView = canReuseView
                  GetViewNode = getViewNode
                  Dispatch = this.Dispatch }

            let definition = WidgetDefinitionStore.get widget.Key

            let struct (_node, root) =
                definition.CreateView(widget, treeContext, ValueNone)

            _root <- root
            _allowDispatch <- true

            _root

        member _.OnStateChanged(args) =
            if args.Key = stateKey then
                _allowDispatch <- false
                let state = unbox args.NewState

                let prevWidget = _widget
                let currentWidget = view state
                _widget <- currentWidget

                let node = getViewNode _root

                Reconciler.update canReuseView (ValueSome prevWidget) currentWidget node
                _allowDispatch <- true

        member _.Dispose() = _stateSubscription.Dispose()

        interface IViewAdapter with
            member x.Dispose() = x.Dispose()
            member x.CreateView() = x.CreateView()
            member _.Attach(node) = ()
            member _.Detach(shouldDestroyNode) = ()

    let create<'arg, 'model, 'msg> (getViewNode: obj -> IViewNode) (runner: Runner<'arg, 'model, 'msg>) =
        let key = ViewAdapterStore.getNextKey ()

        let viewAdapter =
            new ViewAdapter<'model, 'msg>(
                key,
                runner.Key,
                runner.Program.View,
                runner.Program.CanReuseView,
                runner.Dispatch,
                getViewNode
            )

        ViewAdapterStore.set key viewAdapter
        viewAdapter
