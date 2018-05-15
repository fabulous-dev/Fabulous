// Copyright 2018 Elmish and Elmish.XamarinForms contributors. See LICENSE.md for license.
namespace Elmish.XamarinForms

open System
open System.Diagnostics
open FSharp.Control

/// Dispatch - feed new message into the processing loop
type Dispatch<'msg> = 'msg -> unit

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
        [fun dispatch -> dispatch msg]

    /// When emitting the message, map to another type
    let map (f: 'a -> 'msg) (cmd: Cmd<'a>) : Cmd<'msg> =
        cmd |> List.map (fun g -> (fun dispatch -> f >> dispatch) >> g)

    /// Aggregate multiple commands
    let batch (cmds: #seq<Cmd<'msg>>) : Cmd<'msg> =
        cmds |> List.concat

    /// Command to call the subscriber
    let ofSub (sub: Sub<'msg>) : Cmd<'msg> =
        [sub]

    let dispatch d (cmd: Cmd<_>) = for sub in cmd do sub d

    let ofAsyncMsg (p: Async<'msg>) : Cmd<'msg> =
        [ fun dispatch -> async { let! msg = p in dispatch msg } |> Async.StartImmediate ]
 
    //let ofAsyncMsgs p : Cmd<_> =
    //    [ fun dispatch -> p |> AsyncSeq.iter dispatch |> Async.StartImmediate ]
 
    //type CmdBuilder() = 
    //    inherit AsyncSeq.AsyncSeqBuilder()
    //    member x.Run(p: AsyncSeq<_>) = ofAsyncMsgs p
 
//[<AutoOpen>]
//module CommandBuilder = 
//    let cmd = Cmd.CmdBuilder()

