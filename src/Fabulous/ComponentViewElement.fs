namespace Fabulous

type IComponentHandler<'arg, 'msg, 'model, 'externalMsg> =
    abstract CreateRunner: unit -> IRunner<'arg, 'msg, 'model, 'externalMsg>
    abstract GetRunnerForTarget: obj -> IRunner<'arg, 'msg, 'model, 'externalMsg> voption
    abstract SetRunnerForTarget: IRunner<'arg, 'msg, 'model, 'externalMsg> * obj -> unit

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

    interface IComponentViewElement with
        member x.Create(definition) =
            let runnerDefinition = withExternalMsgsIfNeeded runnerDefinition
            let runner = handler.CreateRunner()
            let target = runner.Start(runnerDefinition, arg, None)
            dispatchStateChangedIfNeeded runner
            handler.SetRunnerForTarget(runner, target)
            target

        member x.Update(definition, _, target) =
            match handler.GetRunnerForTarget(target) with
            | ValueNone -> failwith "Can't reuse a control without an associated runner"
            | ValueSome runner ->
                let runnerDefinition = withExternalMsgsIfNeeded runnerDefinition
                runner.ChangeDefinition(runnerDefinition)
                dispatchStateChangedIfNeeded runner

        member x.TryKey = keyOpt
        member x.TargetType = x.TargetType