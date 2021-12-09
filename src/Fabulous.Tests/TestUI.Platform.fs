module Tests.Platform

open System.Collections.Generic

type TestViewElement() =
    member val AutomationId: string = "" with get, set
    member val PropertyBag = Dictionary<string, obj>()

type IText =
    abstract member Text : string with get, set
    abstract member TextColor : string with get, set

type IContainer =
    abstract member Children : ResizeArray<TestViewElement>

type ButtonHandler = unit -> unit

type IButton =
    abstract AddPressListener : ButtonHandler -> int
    abstract RemovePressListener : int -> unit

type TestLabel() =
    inherit TestViewElement()

    interface IText with
        member val Text = "" with get, set
        member val TextColor = "" with get, set

type TestStack() =
    inherit TestViewElement()

    interface IContainer with
        member val Children = ResizeArray<TestViewElement>()


type TestButton() =
    inherit TestViewElement()
    let mutable counter: int = 1
    let handlers = Dictionary<int, ButtonHandler>()

    member _.Press() =
        for handler in Array.ofSeq(handlers.Values) do
            handler()

    interface IText with
        member val Text = "" with get, set
        member val TextColor = "" with get, set

    interface IButton with
        member this.AddPressListener(handler) =
            handlers.Add(counter, handler)
            counter <- counter + 1
            counter - 1

        member this.RemovePressListener(id) = handlers.Remove(id) |> ignore
