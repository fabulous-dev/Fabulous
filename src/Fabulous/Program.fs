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

    /// <summary>
    /// Creates a simple stateful, side-effect-free Program using an MVU loop.
    /// The init function takes an input 'arg and returns a 'model representing the initial state,
    /// the update function receives a 'msg and a 'model and returns an updated 'model.
    /// See the upper diagram in <seealso href="https://elmprogramming.com/elm-architecture-conclusion.html" />
    /// </summary>
    let stateful (init: 'arg -> 'model) (update: 'msg -> 'model -> 'model) =
        define (fun arg -> init arg, Cmd.none) (fun msg model -> update msg model, Cmd.none)

    /// <summary>
    /// Creates a stateful Program using an MVU loop that supports side-effects
    /// - by both the init and update functions returning not only a 'model,
    /// but an additional Cmd{'msg} alongside it.
    /// This is an abstraction of a list of Effect{'msg} functions that return immediatly,
    /// but may dispatch zero or many additional messages when given a Dispatch{'msg} function.
    /// The Cmd{'msg} is fed into the MVU loop for processing of the side-effects by supplying them with a dispatch.
    /// Note that the Cmd{'msg} may not only wrap (async) side-effects,
    /// but also simple messages (using Cmd.ofMsg) or even be an empty list (using Cmd.none) .
    /// See the lower diagram in <seealso href="https://elmprogramming.com/elm-architecture-conclusion.html" />
    /// </summary>
    let statefulWithCmd (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) = define init update

    /// <summary>
    /// Creates a Program using an MVU loop supporting isolated side-effects.
    /// This is similar to statefulWithCmd, but instead of directly returning a Cmd{'msg}
    /// (which may wrap a side-effect like a network or DB call),
    /// the init and update functions return a simple 'cmdMsg list - making them pure and easy to test.
    /// This will require you to add an additional discriminated union type for 'cmdMsg to your Program
    /// with a case representing each side-effect.
    /// An additional mapCmd function maps a 'cmdMsg back to the intended side-effect.
    /// </summary>
    let statefulWithCmdMsg (init: 'arg -> 'model * 'cmdMsg list) (update: 'msg -> 'model -> 'model * 'cmdMsg list) (mapCmd: 'cmdMsg -> Cmd<'msg>) =
        let mapCmds cmdMsgs = cmdMsgs |> List.map mapCmd |> Cmd.batch
        define (fun arg -> let m, c = init arg in m, mapCmds c) (fun msg model -> let m, c = update msg model in m, mapCmds c)

    /// <summary>
    /// Subscribe the program to an external source of events represented by the subscribe function, overriding existing subscriptions.
    /// The subscribe function should return the subscriptions that should be active based on the supplied model.
    /// Subscriptions will be started or stopped accordingly.
    /// See also
    /// <seealso href="https://docs.fabulous.dev/basics/application-state/commands#triggering-commands-from-external-events" />
    /// <seealso href="https://elmprogramming.com/subscriptions.html" />
    /// <seealso href="https://elmish.github.io/elmish/docs/subscriptionv3.html" />
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
    /// during the execution of a <paramref name="program" /> will be handled
    /// by setting its <see cref="Program.ExceptionHandler" />
    /// to the specified <paramref name="handler" />
    /// - which should return true if the exception was handled and false otherwise.
    /// </summary>
    let withExceptionHandler (handler: exn -> bool) (program: Program<'arg, 'model, 'msg>) =
        { program with
            ExceptionHandler = handler }
