// Copyright Fabulous contributors. See LICENSE.md for license.
namespace Fabulous

module Tracing =
    type TraceLevel =
        | Debug = 0
        | Info = 1
        | Error = 2
        | None = 3

    let inline trace (traceFn: TraceLevel -> string -> unit) (targetTraceLevel: TraceLevel) (traceLevel: TraceLevel) (str: string) =
        if (int targetTraceLevel) >= (int traceLevel) then
            traceFn targetTraceLevel str

    let inline traceDebug traceFn traceLevel str = trace traceFn TraceLevel.Debug traceLevel str
    let inline traceInfo traceFn traceLevel str = trace traceFn TraceLevel.Info traceLevel str
    let inline traceError traceFn traceLevel str = trace traceFn TraceLevel.Error traceLevel str