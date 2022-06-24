namespace Fabulous

open System
open System.Collections.Generic
open System.Runtime.ExceptionServices
open Fabulous

/// Configuration of the Fabulous application
type Program<'arg, 'model, 'msg, 'marker> =
    { /// Give the initial state for the application
      Init: 'arg -> 'model * Cmd<'msg>
      /// Update the application state based on a message
      Update: 'msg * 'model -> 'model * Cmd<'msg>
      /// Add a subscription that can dispatch messages
      Subscribe: 'model -> Cmd<'msg>
      /// Render the application state
      View: 'model -> WidgetBuilder<'msg, 'marker>
      /// Indicates if a previous Widget's view can be reused
      CanReuseView: Widget -> Widget -> bool
      /// Runs the View function on the main thread
      SyncAction: (unit -> unit) -> unit
      /// Configuration for logging all output messages from Fabulous
      Logger: Logger }

type IRunner =
    interface
    end

type IViewAdapter =
    inherit IDisposable
    /// Instantiates a new view using the current state associated with this ViewAdapter
    abstract CreateView: unit -> obj

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
    /// Create a new Runner handling the update loop for the component
    type Runner<'arg, 'model, 'msg, 'marker>(key: StateKey, program: Program<'arg, 'model, 'msg, 'marker>) =

        let mailbox =
            MailboxProcessor.Start
                (fun inbox ->
                    let rec processMsg () =
                        async {
                            let! msg = inbox.Receive()
                            let model = unbox(StateStore.get key)
                            let newModel, cmd = program.Update(msg, model)
                            StateStore.set key newModel

                            for sub in cmd do
                                sub inbox.Post

                            return! processMsg()
                        }

                    processMsg())

        do
            mailbox.Error.Add
                (fun ex ->
                    program.Logger.LogException(ex)
                    (ExceptionDispatchInfo.Capture ex).Throw())

        let start arg =
            try
                let model, cmd = program.Init(arg)
                StateStore.set key model

                let subs = program.Subscribe(model)

                for sub in subs do
                    sub mailbox.Post

                for sub in cmd do
                    sub mailbox.Post
            with
            | ex ->
                program.Logger.LogException(ex)
                reraise()

        interface IRunner

        member _.Key = key
        member _.Program = program

        /// Start the Runner loop
        member _.Start(arg) = start arg

        /// Dispatch a message to the Runner loop
        member _.Dispatch(msg) = mailbox.Post msg

    /// Create a new Runner for the component
    let create<'arg, 'model, 'msg, 'marker> (program: Program<'arg, 'model, 'msg, 'marker>) =
        let key = StateStore.getNextKey()
        let runner = Runner(key, program)
        RunnerStore.set key runner
        runner

/// ViewAdapters are responsible for the View part of MVU.
/// They listen for a specific StateKey in StateStore. Upon change, they call the component's View function,
/// calculate the diff and apply it to the actual UI control
module ViewAdapters =
    open Runners

    /// Create a new ViewAdapter handling view updates for the component
    type ViewAdapter<'model, 'msg, 'marker>
        (
            key: ViewAdapterKey,
            stateKey: StateKey,
            view: 'model -> WidgetBuilder<'msg, 'marker>,
            canReuseView: Widget -> Widget -> bool,
            syncAction: (unit -> unit) -> unit,
            logger: Logger,
            dispatch: 'msg -> unit,
            getViewNode: obj -> IViewNode
        ) as this =

        let mutable _widget: Widget = Unchecked.defaultof<Widget>
        let mutable _root = Unchecked.defaultof<obj>
        let mutable _allowDispatch = false

        let _stateSubscription =
            StateStore.StateChanged.Subscribe(this.OnStateChanged)

        member private _.Dispatch(msg) = dispatch(unbox msg)

        /// Instantiates a new view using the current state associated with this ViewAdapter
        member this.CreateView() =
            let state = unbox(StateStore.get stateKey)
            let widget = (view state).Compile()
            _widget <- widget

            let treeContext =
                { CanReuseView = canReuseView
                  GetViewNode = getViewNode
                  Logger = logger
                  Dispatch = this.Dispatch }

            let definition = WidgetDefinitionStore.get widget.Key

            let struct (_node, root) =
                definition.CreateView(widget, treeContext, ValueNone)

            _root <- root
            _allowDispatch <- true

            _root

        /// Listens for StateStore changes and updates the view if necessary
        member _.OnStateChanged(args) =
            try
                if args.Key = stateKey then
                    let state = unbox args.NewState

                    let prevWidget = _widget
                    let currentWidget = (view state).Compile()
                    _widget <- currentWidget

                    let node = getViewNode _root

                    syncAction
                        (fun () ->
                            try
                                Reconciler.update canReuseView (ValueSome prevWidget) currentWidget node
                            with
                            | ex ->
                                logger.LogException(ex)
                                reraise())
            with
            | ex ->
                logger.LogException(ex)
                reraise()

        /// Disposes the ViewAdapter
        member _.Dispose() = _stateSubscription.Dispose()

        interface IViewAdapter with
            member x.Dispose() = x.Dispose()
            member x.CreateView() = x.CreateView()

    /// Create a new ViewAdapter for the component
    let create<'arg, 'model, 'msg, 'marker>
        (getViewNode: obj -> IViewNode)
        (runner: Runner<'arg, 'model, 'msg, 'marker>)
        =
        let key = ViewAdapterStore.getNextKey()

        let viewAdapter =
            new ViewAdapter<'model, 'msg, 'marker>(
                key,
                runner.Key,
                runner.Program.View,
                runner.Program.CanReuseView,
                runner.Program.SyncAction,
                runner.Program.Logger,
                runner.Dispatch,
                getViewNode
            )

        ViewAdapterStore.set key viewAdapter
        viewAdapter
