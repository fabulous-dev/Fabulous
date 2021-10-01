namespace Fabulous

open Fabulous.Widgets

type ViewAdapter<'model, 'view when 'view :> IWidget> (key: RunnerKey, view: 'model * Attribute[] -> 'view) =
    member x.CreateView() =
        let state = unbox (States.getState key)
        let widget = view (state, [||])
        widget.CreateView()

module ViewAdapter =
    let createForRunner (runner: Runner<_, _, _, _>) =
        ViewAdapter<_, _>(runner.Key, runner.Widget.View)