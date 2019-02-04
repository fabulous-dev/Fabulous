// Copyright 2018 Elmish and Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Core

/// Dispatch - feed new message into the processing loop
type Dispatch<'msg> = 'msg voption -> unit

/// Subscription - return immediately, but may schedule dispatch of a message at any time
type Sub<'msg> = Dispatch<'msg> -> unit

/// Cmd - container for subscriptions that may produce messages
type Cmd<'msg> = Sub<'msg> list

/// Cmd module for creating and manipulating commands
[<RequireQualifiedAccess>]
module Cmd =
    /// None - no commands, also known as `[]`
    let none : Cmd<'msg> =
        []

    /// Command to issue a specific message
    let ofMsg (msg:'msg) : Cmd<'msg> =
        [fun dispatch -> dispatch (ValueSome msg) ]

    /// Command to issue a specific message, only when Option.IsSome = true
    let ofMsgOption (msg:'msg option) : Cmd<'msg> =
        [ fun dispatch ->
             match msg with
             | None -> dispatch ValueNone
             | Some msg -> dispatch (ValueSome msg) ]

    /// When emitting the message, map to another type
    let map (f: 'a -> 'msg) (cmd: Cmd<'a>) : Cmd<'msg> =
        cmd |> List.map (fun g ->
            let fOpt value =
                match value with
                | ValueNone -> ValueNone
                | ValueSome x -> ValueSome (f x)

            (fun dispatch -> fOpt >> dispatch) >> g
        )

    /// Aggregate multiple commands
    let batch (cmds: #seq<Cmd<'msg>>) : Cmd<'msg> =
        cmds |> List.concat

    /// Command to call the subscriber
    let ofSub (sub: Sub<'msg>) : Cmd<'msg> =
        [sub]

    let dispatch d (cmd: Cmd<_>) = for sub in cmd do sub d

    /// Command to issue a message at the end of an asynchronous task
    let ofAsyncMsg (p: Async<'msg>) : Cmd<'msg> =
        [ fun dispatch -> async { let! msg = p in dispatch (ValueSome msg) } |> Async.StartImmediate ]

    /// Command to issue a message at the end of an asynchronous task, only when Option.IsSome = true
    let ofAsyncMsgOption (p: Async<'msg option>) : Cmd<'msg> =
        [ fun dispatch -> async { 
            let! msg = p
            match msg with
            | None -> dispatch ValueNone
            | Some msg -> dispatch (ValueSome msg) } |> Async.StartImmediate ]

    /// Module containing functions dedicated to testing Cmds.
    module Testing =

        /// Immediately executes a Cmd and wait for it to dispatch one or more messages, with a given timeout
        let rec executeUntil (millisecondsTimeout: int) (cmd: Cmd<'msg>) : 'msg list =
            let internalDispatch (r: Ref<'msg voption option>) (autoResetEvent: System.Threading.AutoResetEvent) msg =
                r.Value <- Some msg
                autoResetEvent.Set() |> ignore

            [ for sub in cmd do
                let result = ref None
                use autoResetEvent = new System.Threading.AutoResetEvent(false)
                sub (internalDispatch result autoResetEvent)
                match autoResetEvent.WaitOne(millisecondsTimeout) with
                | false -> ()
                | true ->
                    match result.Value.Value with
                    | ValueNone -> ()
                    | ValueSome msg -> yield msg ]

        /// Immediately executes a Cmd and indefinitely wait for it to dispatch a message
        let execute cmd = executeUntil -1 cmd
 
    //let ofAsyncMsgs p : Cmd<_> =
    //    [ fun dispatch -> p |> AsyncSeq.iter dispatch |> Async.StartImmediate ]
 
    //type CmdBuilder() = 
    //    inherit AsyncSeq.AsyncSeqBuilder()
    //    member x.Run(p: AsyncSeq<_>) = ofAsyncMsgs p
 
//[<AutoOpen>]
//module CommandBuilder = 
//    let cmd = Cmd.CmdBuilder()

