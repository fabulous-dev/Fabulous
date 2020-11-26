// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

open System
open Fabulous.Tracing

type ProgramDefinition =
    { canReuseView: IViewElement -> IViewElement -> bool
      dispatch: obj -> unit
      trace: TraceLevel -> string -> unit
      traceLevel: TraceLevel }

and IViewElement =
    abstract Create: ProgramDefinition -> obj
    abstract Update: ProgramDefinition * IViewElement voption * obj -> unit
    abstract TryKey: string voption with get
    abstract TargetType: Type with get

type RunnerDefinition<'arg, 'msg, 'model, 'externalMsg> =
    { init: 'arg -> 'model * Cmd<'msg> * ('externalMsg list)
      update: 'msg -> 'model -> 'model * Cmd<'msg> * ('externalMsg list)
      view: 'model -> Dispatch<'msg> -> IViewElement
      subscribe: 'model -> Cmd<'msg>
      canReuseView: IViewElement -> IViewElement -> bool
      syncDispatch: Dispatch<'msg> -> Dispatch<'msg>
      syncAction: (unit -> unit) -> (unit -> unit)
      traceLevel: TraceLevel
      trace: TraceLevel -> string -> unit
      onError: string -> Exception -> unit }

type IRunner<'arg, 'msg, 'model, 'externalMsg> =
    abstract Start: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg> * 'arg * obj option -> obj
    abstract ChangeDefinition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg> -> unit
    abstract Dispatch: 'msg -> unit

module ProgramTracing =
    let inline traceDebug (definition: ProgramDefinition) = traceDebug definition.trace definition.traceLevel
    let inline traceInfo (definition: ProgramDefinition) = traceInfo definition.trace definition.traceLevel
    let inline traceError (definition: ProgramDefinition) = traceError definition.trace definition.traceLevel

module RunnerTracing =
    let inline traceDebug (definition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>) = traceDebug definition.trace definition.traceLevel
    let inline traceInfo (definition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>) = traceInfo definition.trace definition.traceLevel
    let inline traceError (definition: RunnerDefinition<'arg, 'msg, 'model, 'externalMsg>) = traceError definition.trace definition.traceLevel