// Copyright 2018 Elmish and Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Core

/// Subscription - may schedule dispatch of a message at any time
type Sub<'msg> = unit -> Async<'msg voption>

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
        [ fun () -> msg |> ValueSome |> AsyncHelpers.returnAsync ]

    /// Command to issue a specific message, only when Option.IsSome = true
    let ofMsgOption (msg: 'msg option) : Cmd<'msg> =
        [ fun () -> msg |> OptionHelpers.convertToValueOption |> AsyncHelpers.returnAsync ]

    /// When emitting the message, map to another type
    let map (f: 'a -> 'msg) (cmd: Cmd<'a>) : Cmd<'msg> =
        cmd |> List.map (fun g -> g >> (f |> OptionHelpers.mapValueOption |> AsyncHelpers.applyAsync))

    /// Aggregate multiple commands
    let batch (cmds: #seq<Cmd<'msg>>) : Cmd<'msg> =
        cmds |> List.concat

    /// Command to call the subscriber
    let ofSub (sub: Sub<'msg>) : Cmd<'msg> =
        [sub]

    /// Command to issue a message at the end of an asynchronous task
    let ofAsyncMsg (p: Async<'msg>) : Cmd<'msg> =
        [ fun () -> p |> (AsyncHelpers.applyAsync ValueSome) ]

    /// Command to issue a message at the end of an asynchronous task, only when Option.IsSome = true
    let ofAsyncMsgOption (p: Async<'msg option>) : Cmd<'msg> =
        [ fun () -> p |> (AsyncHelpers.applyAsync OptionHelpers.convertToValueOption) ]