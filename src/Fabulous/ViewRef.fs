namespace Fabulous

open System

/// A reference to be able to access the underlying control of a Widget
type ViewRef<'T when 'T: not struct>() as this =
    let attached = Event<EventHandler<'T>, 'T>()
    let detached = Event<EventHandler, EventArgs>()

    let onAttached target = attached.Trigger(this, unbox target)
    let onDetached () = detached.Trigger(this, EventArgs())

    let handle = ViewRef(onAttached, onDetached)

    /// Event triggered when the view is attached
    [<CLIEvent>]
    member _.Attached = attached.Publish

    /// Event triggered when the view is detached
    [<CLIEvent>]
    member _.Detached = detached.Publish

    /// The underlying control.
    /// This property might throw an exception if the control is not attached to the ViewRef
    member _.Value: 'T =
        match handle.TryValue with
        | Some res -> unbox res
        | None -> failwith "view reference target has been collected or was not set"

    /// The underlying control. If the control is not attached to the ViewRef, None will be returned
    member _.TryValue: 'T option =
        match handle.TryValue with
        | Some res -> Some(unbox res)
        | None -> None

    /// The untyped ViewRef
    member _.Unbox = handle

module ViewRefAttributes =
    let ViewRef =
        Attributes.defineSimpleScalarWithEquality<ViewRef>
            "Fabulous_ViewRef"
            (fun oldValueOpt newValueOpt node ->
                match oldValueOpt with
                | ValueNone -> ()
                | ValueSome viewRef -> viewRef.Unset()

                match newValueOpt with
                | ValueNone -> ()
                | ValueSome viewRef -> viewRef.Set(node.Target))
