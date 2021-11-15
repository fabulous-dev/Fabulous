module Test.Platform

open System.Collections.Generic

type Element() =
    member val AutomationId: string = "" with get, set

type IText =
    abstract member Text : string with get, set
    abstract member TextColor : string with get, set

type IContainer =
    abstract member Children : ResizeArray<Element>

type ButtonHandler = unit -> unit

type IButton =
    abstract AddPressListener : ButtonHandler -> int
    abstract RemovePressListener : int -> unit

type TestLabel() =
    inherit Element()

    interface IText with
        member val Text = "" with get, set
        member val TextColor = "" with get, set

type TestStack() =
    inherit Element()

    interface IContainer with
        member val Children = ResizeArray<Element>()


type TestButton() =
    inherit Element()
    let mutable counter: int = 1
    let handlers = Dictionary<int, ButtonHandler>()
    
    member _.Press() =
        for handler in handlers.Values do
            handler()

    interface IText with
        member val Text = "" with get, set
        member val TextColor = "" with get, set

    interface IButton with
        member this.AddPressListener(handler) =
            handlers.Add(counter, handler)
            counter <- counter + 1
            counter

        member this.RemovePressListener(id) = handlers.Remove(id) |> ignore
