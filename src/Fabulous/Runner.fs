// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

type RunnerDispatch<'msg>()  =
    let mutable dispatchImpl = (fun (_msg: 'msg) -> failwith "do not call dispatch during initialization" : unit)
    member x.DispatchViaThunk = id (fun msg -> dispatchImpl msg)
    member x.SetDispatchThunk v = dispatchImpl <- v

/// Starts the dispatch loop for the page with the given program
type Runner<'arg, 'msg, 'model, 'externalMsg>() =
    let mutable runnerId = ""
    let mutable runnerDefinition = Unchecked.defaultof<RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>>
    let mutable programDefinition = Unchecked.defaultof<ProgramDefinition>
    let mutable lastModel = Unchecked.defaultof<'model>
    let mutable lastViewData = Unchecked.defaultof<IViewElement>
    let mutable disposableSubscription: System.IDisposable = null
    let mutable rootView = null
    let mutable lastArg = Unchecked.defaultof<'arg>
    let dispatch = RunnerDispatch<'msg>()

    let rec processMsg msg =
        RunnerTracing.traceDebug runnerDefinition runnerId (sprintf "Processing message %0A..." msg)
        try
            let updatedModel, cmd, _ = runnerDefinition.update msg lastModel
            lastModel <- updatedModel

            if rootView <> null then
                updateView updatedModel

            for sub in cmd do
                try
                    sub dispatch.DispatchViaThunk
                with ex ->
                    runnerDefinition.onError "Error executing commands" ex

            RunnerTracing.traceDebug runnerDefinition runnerId (sprintf "Message %0A processed" msg)
        with ex ->
            runnerDefinition.onError (sprintf "Unable to process message %0A" msg) ex

    and updateView updatedModel =
        RunnerTracing.traceDebug runnerDefinition runnerId (sprintf "Updating view for model %0A..." updatedModel)

        let newPageElement = runnerDefinition.view updatedModel dispatch.DispatchViaThunk

        if runnerDefinition.canReuseView lastViewData newPageElement then
            newPageElement.Update(programDefinition, ValueSome lastViewData, rootView)
        else
            newPageElement.Update(programDefinition, ValueNone, rootView)

        lastViewData <- newPageElement

        RunnerTracing.traceDebug runnerDefinition runnerId (sprintf "View updated for model %0A" updatedModel)
    
    let start definition arg =
        dispatch.SetDispatchThunk(definition.syncDispatch processMsg)
        lastArg <- arg
        runnerDefinition <- definition
        programDefinition <-
            { canReuseView = definition.canReuseView
              dispatch = (unbox >> dispatch.DispatchViaThunk)
              trace = definition.trace
              traceLevel = definition.traceLevel }

        let initialModel, cmd, _ = definition.init arg
        lastModel <- initialModel

        let initialView = definition.view initialModel dispatch.DispatchViaThunk
        lastViewData <- initialView
        
        disposableSubscription <- definition.subscribe initialModel dispatch.DispatchViaThunk

        for sub in cmd do
            try
                sub dispatch.DispatchViaThunk
            with ex ->
                definition.onError "Error executing commands" ex

    let stop () =
        // Dispose the subscriptions
        if disposableSubscription <> null then
            disposableSubscription.Dispose()
            disposableSubscription <- null
            
    let restart definition arg =
        stop()
        start definition arg
        
    let createView parentViewOpt =
        rootView <- lastViewData.Create(programDefinition, parentViewOpt)
        rootView
        
    let attachView existingView existingViewPrevModelOpt =
        lastViewData.Update(programDefinition, existingViewPrevModelOpt, existingView)
        rootView <- existingView
        
    let detachView () =
        lastViewData.Unmount(rootView)
        rootView <- null
    

    interface IRunner<'arg, 'msg, 'model, 'externalMsg> with
        member x.Arg = lastArg
        
        member x.Start(definition, arg) =
            runnerId <- sprintf "<%s, %s, %s, %s> (Arg = %0A)" typeof<'arg>.Name typeof<'msg>.Name typeof<'model>.Name typeof<'externalMsg>.Name arg
            RunnerTracing.traceDebug definition runnerId "Starting runner"
            start definition arg
        
        member x.Restart(definition, arg) =
            runnerId <- sprintf "<%s, %s, %s, %s> (Arg = %0A)" typeof<'arg>.Name typeof<'msg>.Name typeof<'model>.Name typeof<'externalMsg>.Name arg
            RunnerTracing.traceDebug definition runnerId (sprintf "Restarting runner. Old arg was %0A, new is %O" lastArg arg)
            restart definition arg
        
        member x.Stop() =
            RunnerTracing.traceDebug runnerDefinition runnerId "Stopping runner"
            stop()
        
        member x.CreateView(parentViewOpt) =
            RunnerTracing.traceDebug runnerDefinition runnerId "Creating view for runner"
            createView parentViewOpt
        
        member x.AttachView(existingView, existingViewPrevModelOpt) =
            RunnerTracing.traceDebug runnerDefinition runnerId "Attaching view to runner"
            attachView existingView existingViewPrevModelOpt
        
        member x.DetachView() =
            RunnerTracing.traceDebug runnerDefinition runnerId "Detaching view from runner"
            detachView()
        
        member x.Dispatch(msg) = dispatch.DispatchViaThunk(msg)