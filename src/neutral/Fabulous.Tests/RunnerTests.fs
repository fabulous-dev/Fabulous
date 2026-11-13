module Fabulous.Tests.RunnerTests

open Fabulous
open NUnit.Framework

type Msg =
    | FromInit
    | FromSubStart
    | Followup
    | Later

// Subscription whose start function dispatches immediately (while the runner is still starting)
let private dispatchingSub (dispatch: Dispatch<Msg>) =
    dispatch FromSubStart

    { new System.IDisposable with
        member _.Dispose() = () }

// Model = messages received so far, newest first
let private create initCmd update subscribe =
    let program =
        Program.statefulWithCmd (fun () -> [], initCmd) update
        |> Program.withSubscription subscribe

    let state: Msg list ref = ref []

    let runner =
        new Runner<unit, Msg list, Msg>((fun () -> state.Value), (fun m -> state.Value <- m), program)

    runner, state

// Return an array: NUnit prints arrays readably, and an empty one can be typed
let private history (state: Msg list ref) = state.Value |> List.rev |> Array.ofList

let private recordOnly (msg: Msg) (model: Msg list) = msg :: model, Cmd.none

[<Test>]
let ``Message from init command is processed before Start returns`` () =
    let runner, state = create (Cmd.ofMsg FromInit) recordOnly (fun _ -> [])

    runner.Start(())

    Assert.That(history state, Is.EqualTo [| FromInit |])

[<Test>]
let ``Messages from init and subscription start are processed in order before Start returns`` () =
    let runner, state =
        create (Cmd.ofMsg FromInit) recordOnly (fun _ -> [ ([ "sub" ], dispatchingSub) ])

    runner.Start(())

    // Subscriptions start before the init command runs
    Assert.That(history state, Is.EqualTo [| FromSubStart; FromInit |])

    runner.Dispatch(Later)

    Assert.That(history state, Is.EqualTo [| FromSubStart; FromInit; Later |])

[<Test>]
let ``Follow-up message issued while draining is also processed before Start returns`` () =
    let update msg model =
        match msg with
        | FromInit -> msg :: model, Cmd.ofMsg Followup
        | _ -> msg :: model, Cmd.none

    let runner, state =
        create (Cmd.ofMsg FromInit) update (fun _ -> [ ([ "sub" ], dispatchingSub) ])

    runner.Start(())

    Assert.That(history state, Is.EqualTo [| FromSubStart; FromInit; Followup |])

[<Test>]
let ``Start without any dispatch leaves the model untouched`` () =
    let runner, state = create Cmd.none recordOnly (fun _ -> [])

    runner.Start(())

    Assert.That(history state, Is.EqualTo(Array.empty<Msg>))

    runner.Dispatch(Later)

    Assert.That(history state, Is.EqualTo [| Later |])
