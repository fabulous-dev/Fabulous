namespace Fabulous

/// Runners are responsible for the Model-Update part of MVU.
/// They read from and update StateStore.
module Runners =
    // Runner is created for the component itself. No point in reusing a runner for another component
    type Runner<'arg, 'model, 'msg>(key: StateKey, statefulComponent: IStatefulComponent<'arg, 'model, 'msg>) =
    
        let processMsg msg =
            let model = unbox (StateStore.get key)
            let newModel = statefulComponent.Update(msg, model)
            StateStore.set key newModel

        let start arg =
            let model = statefulComponent.Init(arg)
            StateStore.set key model
        
        interface IRunner
    
        member _.Key = key
        member _.Component = statefulComponent
        member _.ViewTreeContext = { Dispatch = unbox >> processMsg }
        member _.Start(arg) = start arg
        member _.Pause() = ()
        member _.Restart() = ()
        member _.Stop() = ()

    let create<'arg, 'model, 'msg> (statefulComponent: IStatefulComponent<'arg, 'model, 'msg>) =
        let key = StateStore.getNextKey ()
        let runner = Runner(key, statefulComponent)
        RunnerStore.set key runner
        runner

/// ViewAdapters are responsible for the View part of MVU.
/// They listen for a specific StateKey in StateStore. Upon change, they call the component's View function,
/// calculate the diff and apply it to the actual UI control
module ViewAdapters =
    open Runners

    type ViewAdapter<'model>(key: ViewAdapterKey, stateKey: StateKey, view: 'model -> Widget, context: ViewTreeContext) as this =

        let mutable _widget = Unchecked.defaultof<Widget>
        let mutable _viewNode = Unchecked.defaultof<IViewNode>

        let _stateSubscription = StateStore.StateChanged.Subscribe(this.OnStateChanged)

        member _.CreateView() =
            let state = unbox (StateStore.get stateKey)
            let widget = view state
            let widgetDefinition = WidgetDefinitionStore.get widget.Key
            let viewNode = widgetDefinition.CreateView()

            let diff = Reconciler.diff ValueNone widget

            viewNode.SetContext(context)
            viewNode.ApplyDiff(diff)

            _widget <- widget
            _viewNode <- viewNode

            _viewNode

        member _.OnStateChanged(args) =
            if args.Key = stateKey then
                let state = unbox args.NewState
                let previousWidget = _widget
                let currentWidget = view state

                let diff = Reconciler.diff (ValueSome previousWidget) currentWidget
                _viewNode.ApplyDiff(diff)

                _widget <- currentWidget

        member _.Dispose() =
            _stateSubscription.Dispose()

        interface IViewAdapter with
            member x.Dispose() = x.Dispose()
            member x.CreateView() = x.CreateView()
            member _.Attach(node) = ()
            member _.Detach(shouldDestroyNode) = ()
            
    let create<'arg, 'model, 'msg> (runner: Runner<'arg, 'model, 'msg>) =
        let key = ViewAdapterStore.getNextKey ()
        let viewAdapter = new ViewAdapter<'model>(key, runner.Key, runner.Component.View, runner.ViewTreeContext)
        ViewAdapterStore.set key viewAdapter
        viewAdapter