module Fabulous.Tests.Run

open NUnit.Framework

open Tests.Platform
open Tests.TestUI_Widgets
open Fabulous

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



module ComputationExpressionTest =
    type Msg = | Inc

    type Model = int

    let update msg model =
        match msg with
        | Inc -> model + 1

    [<Test>]
    let JustValue () =
        let view model =
            // requires implemented "Yield"
            Stack() { Button("inc", Inc).automationId("inc") }

        let instance =
            StatefulWidget.mkSimpleView(fun () -> 0) update view
            |> Run.Instance

        let tree = (instance.Start())

        let btn = find<TestButton> tree "inc" :> IText

        Assert.AreEqual(btn.Text, "inc")


    [<Test>]
    let Condition () =
        let view model =
            // requires implemented "Zero"
            (Stack() {
                if (model % 2 = 0) then
                    Label("label").automationId("label")
                else
                    Button("btn", Inc).automationId("btn")
             })
                .automationId("stack")


        let instance =
            StatefulWidget.mkSimpleView(fun () -> 0) update view
            |> Run.Instance

        let tree = (instance.Start())

        let stack =
            find<TestStack> tree "stack" :> IContainer

        Assert.AreEqual(1, stack.Children.Count)

        // we start with zero, thus label should be present
        let label = find<TestLabel> tree "label" :> IText

        Assert.AreEqual(label.Text, "label")

        instance.ProcessMessage(Inc)

        // still one child
        Assert.AreEqual(1, stack.Children.Count)

        // but now Button should be present
        let btn = find<TestButton> tree "btn" :> IText

        Assert.AreEqual(btn.Text, "btn")

    [<Test>]
    let YieldCollection () =

        let count = 4

        let view model =
            Stack() {
                // requires implemented "YieldFrom"
                yield!
                    [ for i in 0 .. model -> i.ToString() ]
                    |> List.map(fun i -> Label(i).automationId(i))
            }

        let instance =
            StatefulWidget.mkSimpleView(fun () -> count) update view
            |> Run.Instance

        let tree = (instance.Start())

        for i in 0 .. count do
            let label =
                find<TestLabel> tree (i.ToString()) :> IText

            Assert.AreEqual(label.Text, i.ToString())


    [<Test>]
    let ForExpression () =

        let count = 4

        let view model =
            Stack() {
                // requires implemented "For"
                for i in 0 .. model -> Label(i.ToString()).automationId(i.ToString())
            }

        let instance =
            StatefulWidget.mkSimpleView(fun () -> count) update view
            |> Run.Instance

        let tree = (instance.Start())

        for i in 0 .. count do
            let label =
                find<TestLabel> tree (i.ToString()) :> IText

            Assert.AreEqual(label.Text, i.ToString())






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
            View.map
                mapMsg
                (Button("+1", AddOne)
                    .automationId("add")
                    .textColor("red"))

            Label(model.ToString())
                .automationId("label")
                .textColor("blue")

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


module MemoTests =
    module BasicCase =
        type Model =
            {
                notMemoized: string
                memoTrigger: int
            }

        type Msg =
            | SetNotMemoPart of string
            | SetMemoPart of int

        let update msg model =
            match msg with
            | SetMemoPart i -> { model with memoTrigger = i }
            | SetNotMemoPart s -> { model with notMemoized = s }

        let mutable renderCount = 0

        let view model =
            Stack() {
                Label<Msg>(model.notMemoized)
                    .automationId("not_memo")

                View.memo
                    model.memoTrigger
                    (fun i ->
                        renderCount <- renderCount + 1
                        Label(string i).automationId("memo"))
            }

        [<Test>]
        let Test () =

            let init () =
                {
                    notMemoized = "initial"
                    memoTrigger = 0
                }

            let program =
                StatefulWidget.mkSimpleView init update view

            let instance = Run.Instance program
            let tree = (instance.Start())

            // executed just once to construct the tree
            Assert.AreEqual(1, renderCount)

            let notMemoLabel = find<TestLabel> tree "not_memo" :> IText
            let memoLabel = find<TestLabel> tree "memo" :> IText

            Assert.AreEqual("0", memoLabel.Text)

            instance.ProcessMessage(SetNotMemoPart "hey")
            Assert.AreEqual("hey", notMemoLabel.Text)

            // hasn't been rerendered
            Assert.AreEqual(1, renderCount)

            instance.ProcessMessage(SetMemoPart 99)

            // rerendered because of memo key changed
            Assert.AreEqual(2, renderCount)
            Assert.AreEqual("99", memoLabel.Text)

    module MemoizedWidgetTypeChange =
        type Model =
            | Btn
            | Lbl

        type Msg = Change

        let update msg model =
            match msg with
            | Change ->
                match model with
                | Btn -> Lbl
                | Lbl -> Btn

        let view model =
            (Stack() {
                match model with
                | Btn -> View.memo model (fun i -> Button(string i, Change).automationId("btn"))
                | Lbl -> View.memo model (fun i -> Label(string i).automationId("label"))
             })
                .automationId("stack")

        [<Test>]
        let Test () =

            let init () = Btn

            let program =
                StatefulWidget.mkSimpleView init update view

            let instance = Run.Instance program
            let tree = (instance.Start())

            let stack =
                find<TestStack> tree "stack" :> IContainer

            Assert.AreEqual(1, stack.Children.Count)


            let btn = find<TestButton> tree "btn"
            btn.Press()

            // still one child
            Assert.AreEqual(1, stack.Children.Count)

            // but it is label now
            let label = find<TestLabel> tree "label" :> IText
            Assert.AreEqual(string Lbl, label.Text)

    module ViewNodeInstanceCanBeReused =
        type Model =
            | Label1
            | Label2

        type Msg = Change

        let update msg model =
            match msg with
            | Change ->
                match model with
                | Label1 -> Label2
                | Label2 -> Label1

        let view model =
            Stack() {
                match model with
                | Label1 ->
                    View.memo
                        model
                        (fun i ->
                            Label("one")
                                .textColor("blue")
                                .automationId("label"))
                | Label2 ->
                    View.memo
                        model
                        (fun i ->
                            Label("two")
                                .textColor("blue")
                                .automationId("label"))
            }

        [<Test>]
        let Test () =

            let init () = Label1

            let program =
                StatefulWidget.mkSimpleView init update view

            let instance = Run.Instance program
            let tree = (instance.Start())

            let label = find<TestLabel> tree "label"
            Assert.AreEqual([ TextSet "one"; ColorSet "blue" ], label.changeList)

            instance.ProcessMessage(Change)

            let labelAgain = find<TestLabel> tree "label"

            // same instance
            Assert.AreSame(label, labelAgain)

            // just changes text but kept the same color
            Assert.AreEqual(
                [
                    TextSet "one"
                    ColorSet "blue"
                    TextSet "one"
                ],
                label.changeList
            )
