namespace Fabulous

open System
open System.Diagnostics

/// Configuration of the Fabulous application
type Program<'arg, 'model, 'msg> =
    {
        /// Give the initial state for the application
        Init: 'arg -> 'model * Cmd<'msg>
        /// Update the application state based on a message
        Update: 'msg * 'model -> 'model * Cmd<'msg>
        /// Add a subscription that can dispatch messages
        Subscribe: 'model -> Sub<'msg>
        /// Configuration for logging all output messages from Fabulous
        Logger: Logger
        /// Exception handler for all uncaught exceptions happening in the MVU loop.
        /// Returns true if the exception was handled, false otherwise.
        ExceptionHandler: exn -> bool
    }

type Program<'arg, 'model, 'msg, 'marker> =
    {
        State: Program<'arg, 'model, 'msg>
        /// Render the application state
        View: 'model -> WidgetBuilder<'msg, 'marker>
        /// Indicates if a previous Widget's view can be reused
        CanReuseView: Widget -> Widget -> bool
        /// Runs the View function on the main thread
        SyncAction: (unit -> unit) -> unit
    }

module ProgramDefaults =
    let defaultLogger () =
        let log (level, message) =
            let traceLevel =
                match level with
                | LogLevel.Debug -> "Debug"
                | LogLevel.Info -> "Information"
                | LogLevel.Warn -> "Warning"
                | LogLevel.Error -> "Error"
                | _ -> "Error"

            Trace.WriteLine(message, traceLevel)

        { Log = log
          MinLogLevel = LogLevel.Error }

    let defaultExceptionHandler exn =
        Trace.WriteLine(String.Format("Unhandled exception: {0}", exn.ToString()), "Debug")
        false

module Program =
    let inline private define (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) =
        { Init = init
          Update = (fun (msg, model) -> update msg model)
          Subscribe = fun _ -> Sub.none
          Logger = ProgramDefaults.defaultLogger()
          ExceptionHandler = ProgramDefaults.defaultExceptionHandler }

    /// Create a program using an MVU loop
    let stateful (init: 'arg -> 'model) (update: 'msg -> 'model -> 'model) =
        define (fun arg -> init arg, Cmd.none) (fun msg model -> update msg model, Cmd.none)

    /// Create a program using an MVU loop
    let statefulWithCmd (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) = define init update

    /// Create a program using an MVU loop. Add support for CmdMsg
    let statefulWithCmdMsg (init: 'arg -> 'model * 'cmdMsg list) (update: 'msg -> 'model -> 'model * 'cmdMsg list) (mapCmd: 'cmdMsg -> Cmd<'msg>) =
        let mapCmds cmdMsgs = cmdMsgs |> List.map mapCmd |> Cmd.batch
        define (fun arg -> let m, c = init arg in m, mapCmds c) (fun msg model -> let m, c = update msg model in m, mapCmds c)

    /// Subscribe to external source of events, overrides existing subscription.
    /// Return the subscriptions that should be active based on the current model.
    /// Subscriptions will be started or stopped automatically to match.
    let withSubscription (subscribe: 'model -> Sub<'msg>) (program: Program<'arg, 'model, 'msg>) = { program with Subscribe = subscribe }

    /// Map existing subscription to external source of events.
    let mapSubscription map (program: Program<'arg, 'model, 'msg>) =
        { program with
            Subscribe = map program.Subscribe }

    /// Configure how the output messages from Fabulous will be handled
    let withLogger (logger: Logger) (program: Program<'arg, 'model, 'msg>) = { program with Logger = logger }

    /// Trace all the updates to the debug output
    let withTrace (trace: string * string -> unit) (program: Program<'arg, 'model, 'msg>) =
        let traceInit arg =
            try
                let initModel, cmd = program.Init(arg)
                trace("Initial model: {0}", $"%0A{initModel}")
                initModel, cmd
            with e ->
                trace("Error in init function: {0}", $"%0A{e}")
                reraise()

        let traceUpdate (msg, model) =
            trace("Message: {0}", $"%0A{msg}")

            try
                let newModel, cmd = program.Update(msg, model)
                trace("Updated model: {0}", $"%0A{newModel}")
                newModel, cmd
            with e ->
                trace("Error in model function: {0}", $"%0A{e}")
                reraise()

        { program with
            Init = traceInit
            Update = traceUpdate }

    /// <summary>
    /// Configures how unhandled exceptions happening in the MVU loop
    /// during the execution of a <paramref name="program" /> will be handled
    /// by setting its <see cref="Program.ExceptionHandler" />
    /// to the specified <paramref name="handler" />
    /// - which should return true if the exception was handled and the <paramref name="program" /> may continue
    /// and false otherwise, re-raising the error and terminating the <paramref name="program" />.
    /// </summary>
    let withExceptionHandler (handler: exn -> bool) (program: Program<'arg, 'model, 'msg>) =
        { program with
            ExceptionHandler = handler }
