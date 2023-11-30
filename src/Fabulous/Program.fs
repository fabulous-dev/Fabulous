namespace Fabulous

open System
open System.Diagnostics

module ProgramHelpers =
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
    module ForComponent =
        let inline define (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) =
            { Environment =
                { Initialize = fun _ -> ()
                  Subscribe = fun _ -> null }
              Init = init
              Update = (fun (msg, model) -> update msg model)
              Subscribe = fun _ -> Cmd.none
              Logger = ProgramHelpers.defaultLogger()
              ExceptionHandler = ProgramHelpers.defaultExceptionHandler }

        /// Create a program using an MVU loop
        let stateful (init: 'arg -> 'model) (update: 'msg -> 'model -> 'model) =
            define (fun arg -> init arg, Cmd.none) (fun msg model -> update msg model, Cmd.none)

        /// Create a program using an MVU loop
        let statefulWithCmd (init: 'arg -> 'model * Cmd<'msg>) (update: 'msg -> 'model -> 'model * Cmd<'msg>) = define init update

        /// Create a program using an MVU loop. Add support for CmdMsg
        let statefulWithCmdMsg (init: 'arg -> 'model * 'cmdMsg list) (update: 'msg -> 'model -> 'model * 'cmdMsg list) (mapCmd: 'cmdMsg -> Cmd<'msg>) =
            let mapCmds cmdMsgs = cmdMsgs |> List.map mapCmd |> Cmd.batch
            define (fun arg -> let m, c = init arg in m, mapCmds c) (fun msg model -> let m, c = update msg model in m, mapCmds c)

        /// Subscribe to external source of events.
        /// The subscription is called once - with the initial model, but can dispatch new messages at any time.
        let withSubscription (subscribe: 'model -> Cmd<'msg>) (program: Program<'arg, 'model, 'msg>) =
            let sub model =
                Cmd.batch [ program.Subscribe model; subscribe model ]

            { program with Subscribe = sub }

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

        /// Configure how the unhandled exceptions happening during the execution of a Fabulous app with be handled
        let withExceptionHandler (handler: exn -> bool) (program: Program<'arg, 'model, 'msg>) =
            { program with
                ExceptionHandler = handler }
