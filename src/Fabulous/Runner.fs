namespace Fabulous

open Fabulous.Widgets

type IRunner = interface end

// Runner is created for the widget itself. No point in reusing a runner for another widget
type Runner<'arg, 'model, 'msg, 'view when 'view :> IWidget>(key: RunnerKey, widget: IStatefulWidget<'arg, 'model, 'msg, 'view>) =
    
    let processMsg msg =
        let model = unbox (States.getState key)
        let newModel = widget.Update(msg, model)
        States.setState key newModel

    let start arg =
        let model = widget.Init(arg)
        States.setState key model
        
    interface IRunner
    
    member x.Key = key
    member x.Widget = widget
    member x.ViewTreeContext = { Dispatch = unbox >> processMsg }
    member x.Start(arg) = start arg
    member x.Pause() = ()
    member x.Restart() = ()
    member x.Stop() = ()

module Runners =
    let mutable private _runnersCreationCount = 0
    let mutable private _runners : Map<RunnerKey, IRunner> = Map.empty
    
    let createRunner widget =
        let newKey = RunnerKey _runnersCreationCount
        let runner = Runner<_,_,_,_>(newKey, widget)
        _runnersCreationCount <- _runnersCreationCount + 1
        _runners <- _runners.Add(newKey, runner)
        runner
        
    let removeRunner key =
        _runners <- _runners.Remove(key)