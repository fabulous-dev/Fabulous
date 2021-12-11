module Fabulous.Tests.Run

open NUnit.Framework

open Tests.Platform
open Tests.TestUI_Widgets

open type View


//System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName

let rec findOptional (root: TestViewElement) (id: string) : TestViewElement option =
    if root.AutomationId = id then
        Some root
    else
        match root with
        | :? TestStack as stack ->
            let children = (stack :> IContainer).Children

            children
            |> Array.ofSeq
            |> Array.fold(fun res child -> res |> Option.orElse(findOptional child id)) None

        | _ -> None

let find<'a when 'a :> TestViewElement> (root: TestViewElement) (id: string) : 'a =
    findOptional root id
    |> Option.defaultWith(fun () -> failwith "not found")
    :?> 'a


module SimpleLabelTests =
    type Msg =
        | SetText of string
        | SetColor of string

    type Model = { text: string; color: string }

    let update msg model =
        match msg with
        | SetText text -> { model with text = text }
        | SetColor color -> { model with color = color }

    let view model =
        Label(model.text)
            .textColor(model.color)
            .automationId("label")

    let init () = { text = "hi"; color = "red" }

    [<Test>]
    let SketchAPI () =
        let program =
            StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program

        let el = (instance.Start())

        let label = find<TestLabel> el "label" :> IText

        Assert.AreEqual(label.Text, "hi")
        instance.ProcessMessage(SetText "yo")
        Assert.AreEqual(label.Text, "yo")

        Assert.AreEqual(label.TextColor, "red")
        instance.ProcessMessage(SetColor "blue")
        Assert.AreEqual(label.TextColor, "blue")


module ButtonTests =
    type Msg = | Increment

    type Model = { count: int }

    let update msg model =
        match msg with
        | Increment -> { model with count = model.count + 1 }


    let view model =
        Button(model.count.ToString(), Increment)
            .automationId("btn")

    let init () = { count = 0 }

    [<Test>]
    let SketchAPI () =
        let program =
            StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program
        let tree = (instance.Start())

        let btn = find<TestButton> tree "btn"
        let btnText = btn :> IText

        Assert.AreEqual(btnText.Text, "0")
        btn.Press()
        Assert.AreEqual(btnText.Text, "1")


module SimpleStackTests =
    type Msg =
        | Delete of id: int
        | AddNew of id: int * text: string
        | ChangeText of id: int * text: string

    type Model = (int * string) list

    let update msg model =
        match msg with
        | Delete id -> model |> List.filter(fun (id_, _) -> id_ <> id)
        | AddNew (id, text) -> (id, text) :: model
        | ChangeText (id, text) ->
            model
            |> List.map
                (fun (id_, text_) ->
                    if id = id_ then
                        (id, text)
                    else
                        (id_, text_))

    let view model =
        (Stack() {
            yield!
                model
                |> List.map(fun (id, text) -> (Label(text).automationId(id.ToString())))
         })
            .automationId("stack")


    let init () = []

    [<Test>]
    let SketchAPI () =
        let program =
            StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program

        let tree = (instance.Start())

        let stack =
            find<TestStack> tree "stack" :> IContainer

        Assert.AreEqual(stack.Children.Count, 0)

        // add first
        instance.ProcessMessage(AddNew(1, "yo"))
        Assert.AreEqual(stack.Children.Count, 1)

        let label =
            stack.Children.[0] :?> TestLabel :> IText

        Assert.AreEqual(label.Text, "yo")

        // add second in front
        instance.ProcessMessage(AddNew(2, "yo2"))
        Assert.AreEqual(stack.Children.Count, 2)

        let label =
            stack.Children.[0] :?> TestLabel :> IText

        Assert.AreEqual(label.Text, "yo2")

        // modify the initial one
        instance.ProcessMessage(ChangeText(1, "just 1"))

        let label =
            stack.Children.[1] :?> TestLabel :> IText

        Assert.AreEqual(label.Text, "just 1")

        // delete the one in front
        instance.ProcessMessage(Delete 2)
        Assert.AreEqual(stack.Children.Count, 1)

        let label =
            stack.Children.[0] :?> TestLabel :> IText

        Assert.AreEqual(label.Text, "just 1")


//module ReconcilerTests =
//    let a = Attributes.define<int> "A" (fun () -> 0)
//
//    let b =
//        Attributes.define<string> "B" (fun () -> "")
//
//    let c =
//        Attributes.define<bool> "C" (fun () -> true)
//
//    [<Test>]
//    let CompareAttributes () =
//        let prev = [| a.WithValue(1); b.WithValue("yo") |]
//
//        let next =
//            [|
//                c.WithValue(false)
//                b.WithValue("aha!")
//            |]
//
//        let res = compareAttributes prev next
//        Assert.AreEqual([], res, "this should fail for now, not a real test")
//        ()
//


module MapViewTests =
    type ParentMsg = Add of int

    type ChildMsg =
        | AddOne
        | RemoveTwo

    type Model = int

    let update msg model =
        match msg with
        | Add value -> model + value

    let mapMsg childMsg =
        match childMsg with
        | AddOne -> Add 1
        | RemoveTwo -> Add -2

    let view model =
        Stack() {
            Label(model.ToString())
                .automationId("label")
                .textColor("blue")

            View.map
                mapMsg
                (Button("+1", AddOne)
                    .automationId("add")
                    .textColor("red"))

            View.map mapMsg (Button("-2", RemoveTwo).automationId("remove"))
        }


    let init () = 0

    [<Test>]
    let SketchAPI () =
        let program =
            StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program
        let tree = (instance.Start())

        let addBtn = find<TestButton> tree "add"
        let removeBtn = find<TestButton> tree "remove"
        let label = find<TestLabel> tree "label" :> IText

        Assert.AreEqual("0", label.Text)

        addBtn.Press()
        Assert.AreEqual("1", label.Text)

        removeBtn.Press()
        Assert.AreEqual("-1", label.Text)
