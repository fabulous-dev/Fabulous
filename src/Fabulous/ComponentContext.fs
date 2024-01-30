namespace Fabulous

open System
open System.ComponentModel

(*
ARCHITECTURE NOTES:

Conceptually, a ComponentContext is an array containing all the current values for each state inside the component.
Each state is associated with a index key that it can use to retrieve or update its value.

The ComponentContext is meant to be attached to a Component instance, and passed implicitly in the body of the component
where it will be accessible through let! bindings.

Given each state is assigned to a specific index and that Components will most likely have a fixed number of bindings,
we can leverage the inlining capabilities of the ComponentBuilder to create an array with the right size.
*)

/// <summary>
/// Holds the values for the various states of a component.
/// </summary>
[<AllowNullLiteral>]
type ComponentContext(initialSize: int) =
    static let mutable nextId = 0

    static let getNextId () =
        nextId <- nextId + 1
        nextId

    let id = getNextId()
    let mutable values = Array.zeroCreate initialSize
    let disposables = System.Collections.Generic.List<IDisposable>()

    let renderNeeded = Event<unit>()

    // We assume that most components will have few values, so initialize it with a small array
    new() = new ComponentContext(3)

    member this.Id = id

    member this.RenderNeeded = renderNeeded.Publish
    member this.NeedsRender() = renderNeeded.Trigger()

    member private this.ResizeIfNeeded(count: int) =
        // If the array is already big enough, we don't need to do anything
        // Otherwise, we create a new array and copy the values from the old one
        // It is assumed the component will have a stable amount of values, so this should not happen often
        if values.Length < count then
            let newLength = max (values.Length * 2) count
            let newArray = Array.zeroCreate newLength
            Array.blit values 0 newArray 0 values.Length
            values <- newArray

    member this.TryGetValue<'T>(key: int) =
        this.ResizeIfNeeded(key + 1)

        let value = values[key]

        if isNull value then
            ValueNone
        else
            ValueSome(unbox<'T> value)

    [<EditorBrowsable(EditorBrowsableState.Never)>]
    member this.SetValueInternal(key: int, value: 'T) = values[key] <- box value

    member this.SetValue(key: int, value: 'T) =
        this.SetValueInternal(key, value)
        this.NeedsRender()

    member this.LinkDisposable(disposable: IDisposable) = disposables.Add(disposable)

    member this.Dispose() =
        for disposable in disposables do
            disposable.Dispose()

        disposables.Clear()

        values <- Array.empty

    interface IDisposable with
        member this.Dispose() = this.Dispose()

[<AbstractClass; Sealed>]
type Context private () =
    class
    end
