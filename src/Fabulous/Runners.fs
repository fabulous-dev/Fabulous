namespace Fabulous

/// Runners are responsible for the Model-Update part of MVU.
/// They read from and update StateStore.
module Runners =
    // Runner is created for the component itself. No point in reusing a runner for another component
    type Runner<'arg, 'model, 'msg>(key: StateKey, program: Program<'arg, 'model, 'msg>) =

        let processMsg msg =
            let model = unbox(StateStore.get key)
            let newModel = program.Update(msg, model)
            StateStore.set key newModel

        let start arg =
            let model = program.Init(arg)
            StateStore.set key model

        interface IRunner

        member _.Key = key
        member _.Program = program
        member _.ViewTreeContext = { Dispatch = unbox >> processMsg; Ancestors = [] }
        member _.Start(arg) = start arg
        member _.Pause() = ()
        member _.Restart() = ()
        member _.Stop() = ()

    let create<'arg, 'model, 'msg> (program: Program<'arg, 'model, 'msg>) =
        let key = StateStore.getNextKey()
        let runner = Runner(key, program)
        RunnerStore.set key runner
        runner

/// ViewAdapters are responsible for the View part of MVU.
/// They listen for a specific StateKey in StateStore. Upon change, they call the component's View function,
/// calculate the diff and apply it to the actual UI control
module ViewAdapters =
    open Runners

    type ViewAdapter<'model>(key: ViewAdapterKey, stateKey: StateKey, view: 'model -> Widget, context: ViewTreeContext, getViewNode: obj -> IViewNode) as this =

        let mutable _root = Unchecked.defaultof<obj>

        let _stateSubscription =
            StateStore.StateChanged.Subscribe(this.OnStateChanged)

        member _.CreateView() =
            let state = unbox(StateStore.get stateKey)
            let widget = view state

            let definition = WidgetDefinitionStore.get widget.Key
            _root <- definition.CreateView(widget, context)
            _root

        member _.OnStateChanged(args) =
            if args.Key = stateKey then
                let state = unbox args.NewState
                // let previousWidget = _widget
                let currentWidget = view state

                // TODO handle the case when Type of the widget changes
                Reconciler.update getViewNode _root currentWidget.Attributes

        member _.Dispose() = _stateSubscription.Dispose()

        interface IViewAdapter with
            member x.Dispose() = x.Dispose()
            member x.CreateView() = x.CreateView()
            member _.Attach(node) = ()
            member _.Detach(shouldDestroyNode) = ()

    let create<'arg, 'model, 'msg> (runner: Runner<'arg, 'model, 'msg>) getViewNode =
        let key = ViewAdapterStore.getNextKey()

        let viewAdapter =
            new ViewAdapter<'model>(key, runner.Key, runner.Program.View, runner.ViewTreeContext, getViewNode)

        ViewAdapterStore.set key viewAdapter
        viewAdapter
