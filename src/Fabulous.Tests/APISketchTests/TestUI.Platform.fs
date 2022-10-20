namespace Fabulous.Tests.APISketchTests

module Platform =

    open System.Collections.Generic


    type TestViewElement() =
        member val AutomationId: string = "" with get, set
        member val PropertyBag = Dictionary<string, obj>()

    type IText =
        abstract member Text: string with get, set
        abstract member TextColor: string with get, set

    type ContainerHandler = unit -> unit

    type IContainer =
        abstract member Children: List<TestViewElement>
        abstract AddTapListener: ContainerHandler -> int
        abstract RemoveTapListener: int -> unit

    type ButtonHandler = unit -> unit

    type IButton =
        abstract AddPressListener: ButtonHandler -> int
        abstract RemovePressListener: int -> unit
        abstract AddTapListener: ButtonHandler -> int
        abstract RemoveTapListener: int -> unit
        abstract AddTap2Listener: ButtonHandler -> int
        abstract RemoveTap2Listener: int -> unit

    type LabelChangeList =
        | TextSet of string
        | ColorSet of string


    type TestLabel() =
        inherit TestViewElement()

        let mutable text = ""
        let mutable textColor = ""
        member val record = false with get, set

        member val changeList = [] with get, set

        interface IText with
            member x.Text
                with get () = text
                and set (value) =
                    if x.record then
                        x.changeList <- List.append x.changeList [ TextSet value ]

                    text <- value

            member x.TextColor
                with get () = textColor
                and set (value) =
                    if x.record then
                        x.changeList <- List.append x.changeList [ ColorSet value ]

                    textColor <- value

    type TestStack() =
        inherit TestViewElement()
        let mutable tapCounter: int = 1
        let tapHandlers = Dictionary<int, ContainerHandler>()

        member _.Tap() =
            for handler in Array.ofSeq(tapHandlers.Values) do
                handler()

        interface IContainer with
            member val Children = List<TestViewElement>()

            member this.AddTapListener(handler) =
                tapHandlers.Add(tapCounter, handler)
                tapCounter <- tapCounter + 1
                tapCounter - 1

            member this.RemoveTapListener(id) = tapHandlers.Remove(id) |> ignore

    type TestButton() =
        inherit TestViewElement()
        let mutable pressCounter: int = 1
        let mutable tapCounter: int = 1
        let mutable tap2Counter: int = 1
        let pressHandlers = Dictionary<int, ButtonHandler>()
        let tapHandlers = Dictionary<int, ButtonHandler>()
        let tap2Handlers = Dictionary<int, ButtonHandler>()

        member _.Press() =
            for handler in Array.ofSeq(pressHandlers.Values) do
                handler()

        member _.Tap() =
            for handler in Array.ofSeq(tapHandlers.Values) do
                handler()

        member _.Tap2() =
            for handler in Array.ofSeq(tap2Handlers.Values) do
                handler()

        interface IText with
            member val Text = "" with get, set
            member val TextColor = "" with get, set

        interface IButton with
            member this.AddPressListener(handler) =
                pressHandlers.Add(pressCounter, handler)
                pressCounter <- pressCounter + 1
                pressCounter - 1

            member this.RemovePressListener(id) = pressHandlers.Remove(id) |> ignore

            member this.AddTapListener(handler) =
                tapHandlers.Add(tapCounter, handler)
                tapCounter <- tapCounter + 1
                tapCounter - 1

            member this.RemoveTapListener(id) = tapHandlers.Remove(id) |> ignore

            member this.AddTap2Listener(handler) =
                tap2Handlers.Add(tap2Counter, handler)
                tap2Counter <- tap2Counter + 1
                tap2Counter - 1

            member this.RemoveTap2Listener(id) = tap2Handlers.Remove(id) |> ignore


    type TestNumericBag() =
        inherit TestViewElement()
        member val valueOne = 0UL with get, set
        member val valueTwo = 0UL with get, set
        member val valueThree = 0.0 with get, set
