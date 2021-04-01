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

    let inline trace (traceFn: TraceLevel -> string -> unit) (targetTraceLevel: TraceLevel) (traceLevel: TraceLevel) (str: string) =
        if (int targetTraceLevel) >= (int traceLevel) then
            traceFn targetTraceLevel str

    let inline traceDebug traceFn traceLevel str = trace traceFn TraceLevel.Debug traceLevel str
    let inline traceInfo traceFn traceLevel str = trace traceFn TraceLevel.Info traceLevel str
    let inline traceError traceFn traceLevel str = trace traceFn TraceLevel.Error traceLevel str