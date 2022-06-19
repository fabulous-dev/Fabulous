namespace Fabulous

open System
open System.Runtime.CompilerServices

[<Struct>]
type LogLevel =
    | Debug = 0
    | Info = 1
    | Warn = 2
    | Error = 3
    | Fatal = 4

[<Struct>]
type Logger =
    { Log: LogLevel * string -> unit
      MinLogLevel: LogLevel }

[<Extension>]
type LoggerExtensions =
    static member inline Log(this: Logger, level: LogLevel, format: string, [<ParamArray>] args: obj []) =
        if level >= this.MinLogLevel then
            this.Log(level, String.Format(format, args))

    [<Extension>]
    static member inline Debug(this: Logger, format: string, [<ParamArray>] args: obj []) =
        LoggerExtensions.Log(this, LogLevel.Debug, format, args)

    [<Extension>]
    static member inline Info(this: Logger, format: string, [<ParamArray>] args: obj []) =
        LoggerExtensions.Log(this, LogLevel.Info, format, args)

    [<Extension>]
    static member inline Warn(this: Logger, format: string, [<ParamArray>] args: obj []) =
        LoggerExtensions.Log(this, LogLevel.Warn, format, args)

    [<Extension>]
    static member inline Error(this: Logger, format: string, [<ParamArray>] args: obj []) =
        LoggerExtensions.Log(this, LogLevel.Error, format, args)

    [<Extension>]
    static member inline Fatal(this: Logger, ex: exn) =
        LoggerExtensions.Log(this, LogLevel.Fatal, "{0}", ex.ToString())
