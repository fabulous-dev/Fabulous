namespace Fabulous

module StateStore =
    open System.Collections.Generic

    let private _store = Dictionary<int, obj>()

    let StateUpdated = new Event<_>()

    let get (key: int) : obj * IViewElement =
        unbox _store.[key]

    let set (key: int) (model: obj) (viewElement: IViewElement) =
        _store.Add(key, box (model, viewElement))
        StateUpdated.Trigger(key)

    let delete (key: int) =
        _store.Remove(key) |> ignore
        StateUpdated.Trigger(key)