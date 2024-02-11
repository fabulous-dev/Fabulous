namespace Fabulous

open System
open System.Diagnostics

(*TODO Is either of these a program in the Elm sense? If so, where's the view in this one?
Or are these rather abstractions of or pre-cursors to an Elm Program?
AFAIU in the Elm architecture a "program" manages the application's (or component's) state, actions, and view rendering.
Please help me as a MVU/Elm newbie understand these types. *)
//TODO what's the 'arg?
/// Configuration of the Fabulous application
type Program<'arg, 'model, 'msg> =
    {
        /// Returns the initial model/state of the application and an intial Command
        Init: 'arg -> 'model * Cmd<'msg>
        /// Returns a new model/application state
        /// updated from a message applied to the current model
        /// and optionally another Command
        Update: 'msg * 'model -> 'model * Cmd<'msg>
        /// Add a subscription that can dispatch messages
        Subscribe: 'model -> Sub<'msg>
        /// Configuration for logging all output messages from Fabulous
        Logger: Logger
        /// Exception handler for all uncaught exceptions happening in the MVU loop.
        /// Returns true if the exception was handled, false otherwise.
        ExceptionHandler: exn -> bool
    }

//TODO how is this different to the above? What's a 'marker? what's the 'arg?
type Program<'arg, 'model, 'msg, 'marker> =
    {
        State: Program<'arg, 'model, 'msg>
        /// Renders the model/application state
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

/// <summary>
/// A module for building and configuring Elm programs using an MVU loop.
/// See also
/// <seealso href="https://docs.fabulous.dev/advanced/composing-larger-applications/splitting-into-independent-mvu-states" />
/// <seealso href="https://docs.fabulous.dev/basics/mvu" />
/// </summary>
module Program =
    let inline private define (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) =
        { Init = init
          Update = (fun (msg, model) -> update msg model)
          Subscribe = fun _ -> Sub.none
          Logger = ProgramDefaults.defaultLogger()
          ExceptionHandler = ProgramDefaults.defaultExceptionHandler }

    //TODO when would I use this one? How does it compare to the other stateful* builders?
    //TODO what's expected for 'arg?
    /// Create a program using an MVU loop
    let stateful (init: 'arg -> 'model) (update: 'msg -> 'model -> 'model) =
        define (fun arg -> init arg, Cmd.none) (fun msg model -> update msg model, Cmd.none)

    //TODO when would I use this one? How does it compare to the other stateful* builders?
    //TODO please explain the concept Cmd<'msg>
    //TODO what's expected for 'arg?
    /// Create a program using an MVU loop
    let statefulWithCmd (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) = define init update

    //TODO when would I use this one? How does it compare to the other stateful* builders?
    //TODO please explain the concept CmdMsg vs. Cmd<'msg>
    //TODO what's expected for 'arg?
    /// <summary>
    /// Create a program using an MVU loop supporting CmdMsg.
    /// See also
    /// <seealso href="https://elmprogramming.com/elm-architecture-conclusion.html" />
    /// ?
    /// </summary>
    let statefulWithCmdMsg (init: 'arg -> 'model * 'cmdMsg list) (update: 'msg -> 'model -> 'model * 'cmdMsg list) (mapCmd: 'cmdMsg -> Cmd<'msg>) =
        let mapCmds cmdMsgs = cmdMsgs |> List.map mapCmd |> Cmd.batch
        define (fun arg -> let m, c = init arg in m, mapCmds c) (fun msg model -> let m, c = update msg model in m, mapCmds c)

    (*TODO Subscriptions will be started or stopped automatically to match.
        - I don't understand what that means. What (other?) Subscriptions - or - to match what?*)
    /// <summary>
    /// Subscribe to external source of events, overrides existing subscription.
    /// Return the subscriptions that should be active based on the current model.
    /// Subscriptions will be started or stopped automatically to match.
    /// See also
    /// <seealso href="https://elmprogramming.com/subscriptions.html" />
    /// ?
    /// </summary>
    let withSubscription (subscribe: 'model -> Sub<'msg>) (program: Program<'arg, 'model, 'msg>) = { program with Subscribe = subscribe }

    //TODO In what scenario would I want to use this?
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
    /// during the execution of a <paramref name="program" /> with be handled
    /// by setting its <see cref="Program.ExceptionHandler" />
    /// to the specified <paramref name="handler" />
    /// - which should return true if the exception was handled and false otherwise.
    /// </summary>
    let withExceptionHandler (handler: exn -> bool) (program: Program<'arg, 'model, 'msg>) =
        { program with
            ExceptionHandler = handler }
