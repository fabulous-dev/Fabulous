namespace Fabulous

open System
open Fabulous

module Test =
    let canReuse previousWidget currentWidget =
        false

type ViewAdapter<'model, 'view when 'view :> IWidget>(key: RunnerKey, view: 'model -> 'view, context: ViewTreeContext) as this =

    let mutable _widget = Unchecked.defaultof<'view>
    let mutable _view = Unchecked.defaultof<IViewNode>

    let _stateSubscription = States.updated.Subscribe(this.OnStateChanged)

    member x.CreateView() =
        let state = unbox (States.getState key)
        _widget <- view state
        _view <- _widget.CreateView(context)

        let diff = Reconciler.Diff.diff ValueNone _widget
        _view.ApplyDiff(diff)

        _view

    member x.OnStateChanged(runnerKey, value) =
        if key = runnerKey then
            let state = unbox value
            let previousWidget = _widget :> IWidget
            let currentWidget = view state

            let diff = Reconciler.Diff.diff (ValueSome previousWidget) currentWidget
            printfn "%A" diff
            _view.ApplyDiff(diff)

            _widget <- currentWidget

    interface IDisposable with
        member x.Dispose() =
            _stateSubscription.Dispose()

module ViewAdapter =
    let createForRunner (runner: Runner<_, _, _, _>) =
        new ViewAdapter<_, _>(runner.Key, runner.Widget.View, runner.ViewTreeContext)