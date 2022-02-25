namespace Fabulous

open System

type ViewRef<'T when 'T: not struct>() =
    let attached = Event<EventHandler<'T>, 'T>()
    let detached = Event<EventHandler, EventArgs>()

    let onAttached sender target = attached.Trigger(sender, unbox target)
    let onDetached sender () = detached.Trigger(sender, EventArgs())

    let handle = ViewRef(onAttached, onDetached)

    [<CLIEvent>]
    member _.Attached = attached.Publish

    [<CLIEvent>]
    member _.Detached = detached.Publish

    member _.Value: 'T =
        match handle.TryValue with
        | Some res -> unbox res
        | None -> failwith "view reference target has been collected or was not set"

    member _.TryValue: 'T option =
        match handle.TryValue with
        | Some res -> Some(unbox res)
        | None -> None

    member _.Unbox = handle

module ViewRefAttributes =
    let ViewRef =
        Attributes.defineScalarWithConverter<ViewRef, _, _>
            "Fabulous_ViewRef"
            id
            id
            ScalarAttributeComparers.equalityCompare
            (fun newValueOpt node ->
                match node.Reference with
                | ValueNone -> ()
                | ValueSome viewRef ->
                    viewRef.Unset()
                    node.Reference <- ValueNone

                match newValueOpt with
                | ValueNone -> ()
                | ValueSome viewRef ->
                    node.Reference <- ValueSome viewRef
                    viewRef.Set(node.Target))
