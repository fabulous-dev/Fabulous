namespace Elmish.XamarinForms

open Elmish

[<RequireQualifiedAccess>]
module Cmd = 

    let ofAsyncCallback (task: 'a -> ('b -> unit) -> Async<_>) 
                (arg: 'a) 
                (callback: 'b -> 'msg)
                (ofSuccess: _ -> 'msg) 
                (ofError: _ -> 'msg) : Cmd<'msg> =
        let bind dispatch =
            async {
                let cb = callback >> dispatch
                let! r = task arg cb |> Async.Catch
                dispatch (match r with
                            | Choice1Of2 x -> ofSuccess x
                            | Choice2Of2 x -> ofError x)
            }
        [bind >> Async.StartImmediate]

    let dispatch d (cmd: Cmd<_>) = for sub in cmd do sub d

