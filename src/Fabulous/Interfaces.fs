// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

open System
open Fabulous.Tracing

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
    /// Start the runner using the given definition
    abstract Start: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg> * obj voption * obj voption -> obj
    /// Stop the runner and dispose its subscriptions
    abstract Stop: unit -> unit
    /// Dispatch a message to the MVU loop of this runner
    abstract Dispatch: 'msg -> unit

module internal ProgramTracing =
    let inline traceDebug (definition: ProgramDefinition) = traceDebug definition.trace definition.traceLevel
    let inline traceInfo (definition: ProgramDefinition) = traceInfo definition.trace definition.traceLevel
    let inline traceError (definition: ProgramDefinition) = traceError definition.trace definition.traceLevel

module internal RunnerTracing =
    let inline traceDebug (definition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>) = traceDebug definition.trace definition.traceLevel
    let inline traceInfo (definition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>) = traceInfo definition.trace definition.traceLevel
    let inline traceError (definition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>) = traceError definition.trace definition.traceLevel