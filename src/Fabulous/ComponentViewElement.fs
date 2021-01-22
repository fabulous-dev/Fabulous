namespace Fabulous

type IComponentHandler<'arg, 'msg, 'model, 'externalMsg> =
    abstract CreateRunner: 'arg -> IRunner<'arg, 'msg, 'model, 'externalMsg>
    abstract GetRunnerForTarget: obj -> IRunner<'arg, 'msg, 'model, 'externalMsg> voption
    abstract SetRunnerForTarget: IRunner<'arg, 'msg, 'model, 'externalMsg> voption * obj -> unit

type IComponentViewElement =
    inherit IViewElement

type ComponentViewElement<'arg, 'msg, 'model, 'state, 'externalMsg>
    (
        handler: IComponentHandler<'arg, 'msg, 'model, 'externalMsg>,
        runnerDefinition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>,
        keyOpt: string voption,
        arg: 'arg,
        state: (('state -> 'msg) * 'state) voption,
        externalMsg: ('externalMsg -> unit) voption
    ) =

    let withExternalMsgsIfNeeded (runnerDefinition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>) =
        match externalMsg with
        | ValueNone -> runnerDefinition
        | ValueSome onExternalMsg ->
            let init arg =
                let initModel,cmd,externalMsgs = runnerDefinition.init arg
                externalMsgs |> List.iter onExternalMsg
                initModel,cmd,externalMsgs

            let update msg model =
                let newModel,cmd,externalMsgs = runnerDefinition.update msg model
                externalMsgs |> List.iter onExternalMsg
                newModel,cmd,externalMsgs

            { runnerDefinition with
                init = init
                update = update }

    let dispatchStateChangedIfNeeded (runner: IRunner<'arg, 'msg, 'model, 'externalMsg>) =
        match state with
        | ValueNone -> ()
        | ValueSome (onStateChanged, state) ->
            let msg = onStateChanged state
            runner.Dispatch(msg)

    member x.TargetType = runnerDefinition.GetType()
    
    member x.RunnerDefinition = runnerDefinition

    interface IComponentViewElement with
        member x.Create(definition, parentOpt) =
            let runnerDefinition = withExternalMsgsIfNeeded runnerDefinition
            let runner = handler.CreateRunner(arg)
            let target = runner.Start(runnerDefinition, ValueNone, parentOpt)
            dispatchStateChangedIfNeeded runner
            handler.SetRunnerForTarget(ValueSome runner, target)
            target

        member x.Update(definition, prevOpt, target) =
            match handler.GetRunnerForTarget(target) with
            | ValueNone -> failwith "Can't reuse a control without an associated runner"
            | ValueSome runner ->
                // Only change the definition when it's actually a different runner definition
                match prevOpt with
                | ValueSome (:? ComponentViewElement<'arg, 'msg, 'model, 'state, 'externalMsg> as prev) when System.Object.ReferenceEquals(prev.RunnerDefinition, runnerDefinition) -> ()
                | _ ->
                    let runnerDefinition = withExternalMsgsIfNeeded runnerDefinition
                    runner.Stop()
                    runner.Start(runnerDefinition, ValueSome (box target), ValueNone) |> ignore
                    
                dispatchStateChangedIfNeeded runner
                
        member x.Unmount(target) =
            match handler.GetRunnerForTarget(target) with
            | ValueNone -> ()
            | ValueSome runner ->
                runner.Stop()
                handler.SetRunnerForTarget(ValueNone, target)

        member x.TryKey = keyOpt
        member x.TargetType = x.TargetType