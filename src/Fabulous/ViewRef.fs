namespace Fabulous

open System

type RemovableEvent<'T> () = 
    let handlers = ResizeArray<Handler<'T>>()
    
    member x.Trigger(sender, v) =
        let handlers = handlers.ToArray() // copy to avoid concurrent modification
        for h in handlers do h.Invoke(sender, v)
        
    member x.Clear() =
        handlers.Clear()
        
    member x.Publish = 
        { new IEvent<'T> with
            member x.AddHandler(h) = handlers.Add(h)
            member x.RemoveHandler(h) = handlers.Remove(h) |> ignore
            member x.Subscribe(h) =
                let h = Handler<_>(fun _ -> h.OnNext)
                handlers.Add(h)
                { new IDisposable with
                    member x.Dispose() = handlers.Remove(h) |> ignore } }

/// A reference to be able to access the underlying control of a Widget
type ViewRef<'T when 'T: not struct>() as this =
    let attached = RemovableEvent<'T>()
    let detached = RemovableEvent<unit>()

    let onAttached target = attached.Trigger(this, unbox target)
    let onDetached () = detached.Trigger(this, ())

    let handle = ViewRef(onAttached, onDetached)

    /// Event triggered when the view is attached
    [<CLIEvent>]
    member _.Attached = attached.Publish

    /// Event triggered when the view is detached
    [<CLIEvent>]
    member _.Detached = detached.Publish
    
    /// Remove all handlers
    member _.ClearListeners() =
        attached.Clear()
        detached.Clear()

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
