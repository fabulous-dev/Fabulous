// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

module Tracing =
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

    let inline trace (targetTraceLevel: TraceLevel) (traceFn: TraceLevel -> string -> unit) (traceLevel: TraceLevel) (args: 'args) (msgFn: 'args -> string) =
        if targetTraceLevel >= traceLevel then
            traceFn targetTraceLevel (msgFn args)

    let inline traceDebug traceFn traceLevel args msgFn = trace TraceLevel.Debug traceFn traceLevel args msgFn
    let inline traceInfo traceFn traceLevel args msgFn = trace TraceLevel.Info traceFn traceLevel args msgFn
    let inline traceError traceFn traceLevel args msgFn = trace TraceLevel.Error traceFn traceLevel args msgFn