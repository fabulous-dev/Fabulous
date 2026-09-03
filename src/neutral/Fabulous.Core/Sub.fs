namespace Fabulous

open System
open System.Collections.Generic

/// SubId - Subscription ID, alias for string list
type SubId = string list

/// Subscribe - Starts a subscription, returns IDisposable to stop it
type Subscribe<'msg> = Dispatch<'msg> -> IDisposable

/// Subscription - Generates new messages when running
type Sub<'msg> = (SubId * Subscribe<'msg>) list

module Sub =

    /// None - no subscriptions, also known as `[]`
    let none: Sub<'msg> = []

    /// Aggregate multiple subscriptions
    let batch (subs: Sub<'msg> list) : Sub<'msg> = List.concat subs

    /// When emitting the message, map to another type.
    /// To avoid ID conflicts with other components, scope SubIds with a prefix.
    let map (idPrefix: string) (f: 'a -> 'msg) (sub: Sub<'a>) : Sub<'msg> =
        sub
        |> List.map(fun (subId, subscribe) -> idPrefix :: subId, (fun dispatch -> subscribe(f >> dispatch)))

    module Internal =

        module SubId =

            let toString (subId: SubId) = String.Join("/", subId)

        module Fx =

            let warnDupe onError subId =
                let ex = exn "Duplicate SubId"
                onError("Duplicate SubId: " + SubId.toString subId, ex)

            let tryStop onError (subId, sub: IDisposable) =
                try
                    sub.Dispose()
                with ex ->
                    onError("Error stopping subscription: " + SubId.toString subId, ex)

            let tryStart onError dispatch (subId, start) : (SubId * IDisposable) option =
                try
                    Some(subId, start dispatch)
                with ex ->
                    onError("Error starting subscription: " + SubId.toString subId, ex)
                    None

            let stop onError subs = subs |> List.iter(tryStop onError)

            let change onError dispatch (dupes, toStop, toKeep, toStart) =
                dupes |> List.iter(warnDupe onError)
                toStop |> List.iter(tryStop onError)
                let started = toStart |> List.choose(tryStart onError dispatch)
                List.append toKeep started

        module NewSubs =

            /// Computes duplicates, the set of unique subscription keys, and the deduplicated
            /// subscriptions list, in a single pass. Uses a mutable HashSet instead of an
            /// immutable Set to avoid O(log n) tree-node allocations per insertion.
            let calculate (subs: Sub<'msg>) =
                let newKeys = HashSet<SubId>()
                let mutable dupes = []
                let mutable newSubs = []

                for subId, start in List.rev subs do
                    if not(newKeys.Add(subId)) then
                        dupes <- subId :: dupes
                    else
                        newSubs <- (subId, start) :: newSubs

                dupes, newKeys, newSubs

        let empty = List.empty<SubId * IDisposable>

        let diff (activeSubs: (SubId * IDisposable) list) (sub: Sub<'msg>) =
            let keys = HashSet<SubId>(activeSubs |> List.map fst)
            let dupes, newKeys, newSubs = NewSubs.calculate sub

            if keys.SetEquals(newKeys) then
                dupes, [], activeSubs, []
            else
                let toKeep, toStop = activeSubs |> List.partition(fun (k, _) -> newKeys.Contains(k))

                let toStart = newSubs |> List.filter(fun (k, _) -> not(keys.Contains(k)))
                dupes, toStop, toKeep, toStart
