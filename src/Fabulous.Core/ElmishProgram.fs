// Copyright 2018 Elmish and Fabulous contributors. See LICENSE.md for license.
namespace Fabulous.Core

open Fabulous.Core

[<AutoOpen>]
module Values =
    let NoCmd<'a> : Cmd<'a> = Cmd.none

/// Program type captures various aspects of program behavior
type Program<'model, 'msg, 'view> = 
    { init : unit -> 'model * Cmd<'msg>
      update : 'msg -> 'model -> 'model * Cmd<'msg>
      subscribe : 'model -> Cmd<'msg>
      view : 'view
      debug : bool
      onError : (string * exn) -> unit }

/// We store the current dispatch function for the running Elmish program as a 
/// static-global thunk because we want old view elements stored in the `dependsOn` global table
/// to be recyclable on resumption (when a new ProgramRunner gets created).
type ProgramDispatch<'msg>()  = 
    static let mutable dispatchImpl = (fun (_msg: 'msg) -> failwith "do not call dispatch during initialization" : unit)

    static let dispatch = 
        id (fun msg -> 
            dispatchImpl msg)

    static member DispatchViaThunk = dispatch 
    static member SetDispatchThunk v = dispatchImpl <- v