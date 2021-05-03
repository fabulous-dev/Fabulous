// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

open System

type RunnerDispatch<'msg>()  =
    let mutable dispatchImpl = (fun (_msg: 'msg) -> failwith "do not call dispatch during initialization" : unit)
    member x.DispatchViaThunk = id (fun msg -> dispatchImpl msg)
    member x.SetDispatchThunk v = dispatchImpl <- v

/// Starts the dispatch loop for the page with the given program
type Runner<'arg, 'msg, 'model, 'externalMsg>() as this =
    let runnerId = String.Format("<{0}, {1}, {2}, {3}>(...)@{4}", typeof<'arg>.Name, typeof<'msg>.Name, typeof<'model>.Name, typeof<'externalMsg>.Name, this.GetHashCode())
    
    let mutable runnerDefinition = Unchecked.defaultof<RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>>
    let mutable programDefinition = Unchecked.defaultof<ProgramDefinition>
    let mutable lastModel = Unchecked.defaultof<'model>
    let mutable lastViewData = Unchecked.defaultof<IViewElement>
    let mutable disposableSubscription: IDisposable = null
    let mutable rootView = null
    let mutable lastArg = Unchecked.defaultof<'arg>
    let dispatch = RunnerDispatch<'msg>()
    
    let debug msgFn args =
        RunnerTracing.traceDebug runnerDefinition runnerId args msgFn

    let rec processMsg msg =
        let traceStart (msg: 'msg) = String.Format("Processing message {0}...", msg)
        let traceEnd (msg: 'msg) = String.Format("Message {0} processed", msg)
        
        debug traceStart msg
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

            debug traceEnd msg
        with ex ->
            runnerDefinition.onError (String.Format("Unable to process message {0}", msg)) ex

    and updateView updatedModel =
        let traceStart (updatedModel: 'model) = String.Format("Updating view for model {0}...", updatedModel)
        let traceEnd (updatedModel: 'model) = String.Format("View updated for model {0}", updatedModel)
        
        debug traceStart updatedModel
        
        let newPageElement = runnerDefinition.view updatedModel dispatch.DispatchViaThunk

        if runnerDefinition.canReuseView lastViewData newPageElement then
            newPageElement.Update(programDefinition, ValueSome lastViewData, rootView)
        else
            newPageElement.Update(programDefinition, ValueNone, rootView)

        lastViewData <- newPageElement

        debug traceEnd updatedModel
    
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
        let prevViewData = lastViewData
        stop()
        start definition arg
        if rootView <> null then lastViewData.Update(programDefinition, ValueSome prevViewData, rootView)
        
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
            let trace () = "Starting runner"
            
            RunnerTracing.traceDebug definition runnerId () trace
            start definition arg
        
        member x.Restart(definition, arg) =
            let trace (lastArg, arg) = String.Format("Restarting runner. Old arg was {0}, new is {1}", lastArg, arg)
            
            RunnerTracing.traceDebug definition runnerId (lastArg, arg) trace
            restart definition arg
        
        member x.Stop() =
            let trace () = "Stopping runner"
            
            debug trace ()
            stop()
        
        member x.CreateView(parentViewOpt) =
            let trace () = "Creating view for runner"
            
            debug trace ()
            createView parentViewOpt
        
        member x.AttachView(existingView, existingViewPrevModelOpt) =
            let trace () = "Attaching view to runner"
            
            debug trace ()
            attachView existingView existingViewPrevModelOpt
        
        member x.DetachView() =
            let trace () = "Detaching view from runner"
            
            debug trace ()
            detachView()
        
        member x.Dispatch(msg) = dispatch.DispatchViaThunk(msg)