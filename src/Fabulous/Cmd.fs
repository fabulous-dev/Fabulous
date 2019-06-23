namespace Fabulous

open Elmish

module Cmd =
    module OfAsync =
        let performBind<'arg, 'result, 'msg> (task: 'arg -> Async<'result>) (arg: 'arg) (ofSuccess: 'result -> 'msg option) =
            let bind dispatch =
                async {
                    let! r = task arg |> Async.Catch
                    match r with
                    | Choice1Of2 x ->
                        match (ofSuccess x) with
                        | None -> ()
                        | Some msg -> dispatch msg
                    | _ -> ()
                }
            [bind >> Async.StartImmediate]

