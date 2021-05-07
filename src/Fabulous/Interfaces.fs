// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

open System

/// Represents a level of details in the trace outputs
type TraceLevel =
    /// Print out all traces 
    | Debug = 0
    
    /// Print out errors and informational traces
    | Info = 1
    
    /// Print out only errors
    | Error = 2
    
    /// No trace
    | None = 3

type ProgramDefinition =
    { canReuseView: IViewElement -> IViewElement -> bool
      dispatch: obj -> unit
      trace: TraceLevel -> string -> unit
      traceLevel: TraceLevel }

/// Represents a visual element
and IViewElement =
    /// Create the target control from this ViewElement
    abstract Create: ProgramDefinition * obj voption -> obj
    /// Update an existing control by applying the diff between a previous ViewElement and this one
    abstract Update: ProgramDefinition * IViewElement voption * obj -> unit
    /// Signal the ViewElement that its associated control is no longer available
    abstract Unmount: obj -> unit
    /// Try get the key of this ViewElement
    abstract TryKey: string voption with get
    /// Target type of the control that will be created by this ViewElement
    abstract TargetType: Type with get

type RunnerDefinition<'arg, 'msg, 'model, 'externalMsg> =
    { init: 'arg -> 'model * Cmd<'msg> * ('externalMsg list)
      update: 'msg -> 'model -> 'model * Cmd<'msg> * ('externalMsg list)
      view: 'model -> Dispatch<'msg> -> IViewElement
      subscribe: 'model -> Dispatch<'msg> -> IDisposable
      canReuseView: IViewElement -> IViewElement -> bool
      syncDispatch: Dispatch<'msg> -> Dispatch<'msg>
      syncAction: (unit -> unit) -> (unit -> unit)
      traceLevel: TraceLevel
      trace: TraceLevel -> string -> unit
      onError: string -> Exception -> unit }

/// Responsible for running the MVU loop
type IRunner<'arg, 'msg, 'model, 'externalMsg> =
    /// Argument used to start the runner
    abstract Arg: 'arg
    /// Start the runner using the given definition
    abstract Start: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg> * 'arg -> unit
    /// Restart the runner using a different definition
    abstract Restart: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg> * 'arg -> unit
    /// Stop the runner and dispose its subscriptions
    abstract Stop: unit -> unit
    /// Create a view with the current runner state and attach it
    abstract CreateView: parentViewOpt: obj voption -> obj
    /// Attach an existing view to the runner and update it with the current state
    abstract AttachView: existingView: obj * existingViewPrevModelOpt: IViewElement voption -> unit
    /// Detach the currently attached view from the runner
    abstract DetachView: unit -> unit
    /// Dispatch a message to the MVU loop of this runner
    abstract Dispatch: 'msg -> unit

module internal ProgramTracing =
    let private trace<'traceArgs> targetTraceLevel (definition: ProgramDefinition) (args: 'traceArgs) msgFn =
        if definition.traceLevel <= targetTraceLevel then
            definition.trace targetTraceLevel (msgFn args)
    
    let traceDebug<'traceArgs> = trace<'traceArgs> TraceLevel.Debug
    let traceInfo<'traceArgs> = trace<'traceArgs> TraceLevel.Info
    let traceError<'traceArgs> = trace<'traceArgs> TraceLevel.Error

module internal RunnerTracing =
    let private trace<'arg, 'msg, 'model, 'externalMsg, 'traceArgs> targetTraceLevel (definition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>) runnerId (args: 'traceArgs) (msgFn: 'traceArgs -> string) =
        if definition.traceLevel <= targetTraceLevel then
            let msg = msgFn args
            let traceMsg = String.Format("[Runner{0}] {1}", runnerId, msg)
            definition.trace targetTraceLevel traceMsg
        
    let traceDebug<'arg, 'msg, 'model, 'externalMsg, 'traceArgs> = trace<'arg, 'msg, 'model, 'externalMsg, 'traceArgs> TraceLevel.Debug
    let traceInfo<'arg, 'msg, 'model, 'externalMsg, 'traceArgs> = trace<'arg, 'msg, 'model, 'externalMsg, 'traceArgs> TraceLevel.Info
    let traceError<'arg, 'msg, 'model, 'externalMsg, 'traceArgs> = trace<'arg, 'msg, 'model, 'externalMsg, 'traceArgs> TraceLevel.Error