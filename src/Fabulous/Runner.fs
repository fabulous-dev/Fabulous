// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

type RunnerDispatch<'msg>()  =
    let mutable dispatchImpl = (fun (_msg: 'msg) -> failwith "do not call dispatch during initialization" : unit)
    member x.DispatchViaThunk = id (fun msg -> dispatchImpl msg)
    member x.SetDispatchThunk v = dispatchImpl <- v

/// Starts the dispatch loop for the page with the given program
type Runner<'arg, 'msg, 'model, 'externalMsg>() =
    let mutable runnerDefinition = Unchecked.defaultof<RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>>
    let mutable programDefinition = Unchecked.defaultof<ProgramDefinition>
    let mutable lastModel = Unchecked.defaultof<'model>
    let mutable lastViewData = Unchecked.defaultof<IViewElement>
    let mutable disposableSubscription: System.IDisposable = null
    let mutable rootView = null
    let dispatch = RunnerDispatch<'msg>()

    let rec processMsg msg =
        RunnerTracing.traceDebug runnerDefinition (sprintf "Processing message %0A..." msg)
        try
            let updatedModel, cmd, _ = runnerDefinition.update msg lastModel
            lastModel <- updatedModel

            updateView updatedModel

            for sub in cmd do
                try
                    sub dispatch.DispatchViaThunk
                with ex ->
                    runnerDefinition.onError "Error executing commands" ex

            RunnerTracing.traceDebug runnerDefinition (sprintf "Message %0A processed" msg)
        with ex ->
            runnerDefinition.onError (sprintf "Unable to process message %0A" msg) ex

    and updateView updatedModel =
        RunnerTracing.traceDebug runnerDefinition (sprintf "Updating view for model %0A..." updatedModel)

        let newPageElement = runnerDefinition.view updatedModel dispatch.DispatchViaThunk

        if runnerDefinition.canReuseView lastViewData newPageElement then
            newPageElement.Update(programDefinition, ValueSome lastViewData, rootView)
        else
            newPageElement.Update(programDefinition, ValueNone, rootView)

        lastViewData <- newPageElement

        RunnerTracing.traceDebug runnerDefinition (sprintf "View updated for model %0A" updatedModel)

    member x.Start(definition, rootOpt, parentOpt, arg) =
        RunnerTracing.traceDebug definition (sprintf "Starting runner for %0A..." rootOpt)

        dispatch.SetDispatchThunk(definition.syncDispatch processMsg)
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

        // Update the given root control, or create a new one
        let target =
            match rootOpt with
            | ValueNone ->
                initialView.Create(programDefinition, parentOpt)

            | ValueSome root ->
                initialView.Update(programDefinition, ValueNone, root)
                root

        rootView <- target
        
        disposableSubscription <- definition.subscribe initialModel dispatch.DispatchViaThunk

        for sub in cmd do
            try
                sub dispatch.DispatchViaThunk
            with ex ->
                definition.onError "Error executing commands" ex

        RunnerTracing.traceDebug definition (sprintf "Runner started for %0A" rootOpt)
        target
        
    member x.Stop() =
        // Dispose the subscriptions
        if disposableSubscription <> null then
            disposableSubscription.Dispose()
            disposableSubscription <- null
            
        // Unmount the root ViewElement
        lastViewData.Unmount(rootView)

    member x.Dispatch(msg) =
        dispatch.DispatchViaThunk(msg)

    interface IRunner<'arg, 'msg, 'model, 'externalMsg> with
        member x.Start(definition, rootOpt, parentOpt, arg) = x.Start(definition, rootOpt, parentOpt, arg)
        member x.Stop() = x.Stop()
        member x.Dispatch(msg) = x.Dispatch(msg)