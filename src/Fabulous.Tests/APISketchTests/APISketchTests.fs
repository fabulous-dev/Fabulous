namespace Fabulous.Tests.APISketchTests

open Fabulous.StackAllocatedCollections
open Fabulous.Tests.APISketchTests.Platform
open NUnit.Framework

open Platform
open TestUI_Widgets
open Fabulous

open type View

[<AutoOpen>]
module Helpers =
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
                |> Array.fold (fun res child -> res |> Option.orElse(findOptional child id)) None

            | _ -> None

    let find<'a when 'a :> TestViewElement> (root: TestViewElement) (id: string) : 'a =
        findOptional root id |> Option.defaultWith(fun () -> failwith "not found") :?> 'a


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
        Label(model.text).textColor(model.color).automationId("label")

    let init () = { text = "hi"; color = "red" }

    [<Test>]
    let SketchAPI () =
        let program = StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program

        let el = instance.Start()

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
        Button(model.count.ToString(), Increment).automationId("btn")

    let init () = { count = 0 }

    [<Test>]
    let SketchAPI () =
        let program = StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program
        let tree = instance.Start()

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
        | AddNew(id, text) -> (id, text) :: model
        | ChangeText(id, text) ->
            model
            |> List.map(fun (id_, text_) -> if id = id_ then (id, text) else (id_, text_))

    let view model =
        (Stack() { yield! model |> List.map(fun (id, text) -> Label(text).automationId(id.ToString())) })
            .automationId("stack")


    let init () = []

    [<Test>]
    let Test () =
        let program = StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program

        let tree = instance.Start()

        let stack = find<TestStack> tree "stack" :> IContainer

        Assert.AreEqual(stack.Children.Count, 0)

        // add first
        instance.ProcessMessage(AddNew(1, "yo"))
        Assert.AreEqual(1, stack.Children.Count)

        let label = stack.Children.[0] :?> TestLabel :> IText

        Assert.AreEqual(label.Text, "yo")

        // add second in front
        instance.ProcessMessage(AddNew(2, "yo2"))
        Assert.AreEqual(2, stack.Children.Count)

        let label = stack.Children.[0] :?> TestLabel :> IText

        Assert.AreEqual(label.Text, "yo2")

        // modify the initial one
        instance.ProcessMessage(ChangeText(1, "just 1"))

        let label = stack.Children.[1] :?> TestLabel :> IText

        Assert.AreEqual(label.Text, "just 1")

        // delete the one in front
        instance.ProcessMessage(Delete 2)
        Assert.AreEqual(stack.Children.Count, 1)

        let label = stack.Children.[0] :?> TestLabel :> IText

        Assert.AreEqual(label.Text, "just 1")



module ComputationExpressionTest =
    type Msg = | Inc

    type Model = int

    let update msg model =
        match msg with
        | Inc -> model + 1

    [<Test>]
    let JustValue () =
        let view _ =
            // requires implemented "Yield"
            Stack() { Button("inc", Inc).automationId("inc") }

        let instance = StatefulWidget.mkSimpleView (fun () -> 0) update view |> Run.Instance

        let tree = instance.Start()

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


        let instance = StatefulWidget.mkSimpleView (fun () -> 0) update view |> Run.Instance

        let tree = instance.Start()

        let stack = find<TestStack> tree "stack" :> IContainer

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
                    [ for i in 0..model -> i.ToString() ]
                    |> List.map(fun i -> Label(i).automationId(i))
            }

        let instance =
            StatefulWidget.mkSimpleView (fun () -> count) update view |> Run.Instance

        let tree = instance.Start()

        for i in 0..count do
            let label = find<TestLabel> tree (i.ToString()) :> IText

            Assert.AreEqual(label.Text, i.ToString())


    [<Test>]
    let ForExpression () =

        let count = 4

        let view model =
            Stack() {
                // requires implemented "For"
                for i in 0..model -> Label(i.ToString()).automationId(i.ToString())
            }

        let instance =
            StatefulWidget.mkSimpleView (fun () -> count) update view |> Run.Instance

        let tree = instance.Start()

        for i in 0..count do
            let label = find<TestLabel> tree (i.ToString()) :> IText

            Assert.AreEqual(label.Text, i.ToString())

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
            View.map mapMsg (Button("+1", AddOne).automationId("add").textColor("red"))

            Label(model.ToString()).automationId("label").textColor("blue")

            View.map mapMsg (Button("-2", RemoveTwo).automationId("remove"))
        }


    let init () = 0

    [<Test>]
    let SketchAPI () =
        let program = StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program
        let tree = instance.Start()

        let addBtn = find<TestButton> tree "add"

        let removeBtn = find<TestButton> tree "remove"

        let label = find<TestLabel> tree "label" :> IText

        Assert.AreEqual("0", label.Text)

        addBtn.Press()
        Assert.AreEqual("1", label.Text)

        removeBtn.Press()
        Assert.AreEqual("-1", label.Text)

module MultipleMapViewTests =
    type ParentMsg = Add of int

    type ChildMsg =
        | AddOne
        | RemoveTwo
        | Subtract of int

    type ChildChildMsg = | RemoveFour

    type Model = int

    let update msg model =
        match msg with
        | Add value -> model + value

    let mapChildMsg childMsg =
        match childMsg with
        | AddOne -> Add 1
        | RemoveTwo -> Add -2
        | Subtract n -> Add(-1 * n)

    let mapChildChildMsg childChildMsg =
        match childChildMsg with
        | RemoveFour -> Subtract 4

    let view model =
        Stack() {
            View.map mapChildMsg (Button("+1", AddOne).automationId("add").textColor("red"))

            Label(model.ToString()).automationId("label").textColor("blue")

            View.map mapChildMsg (Button("-2", RemoveTwo).automationId("remove"))
            View.map mapChildMsg (View.map mapChildChildMsg (Button("-4", RemoveFour).automationId("remove4")))
        }


    let init () = 0

    [<Test>]
    let SketchAPI () =
        let program = StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program
        let tree = instance.Start()

        let addBtn = find<TestButton> tree "add"

        let removeBtn = find<TestButton> tree "remove"

        let remove4Btn = find<TestButton> tree "remove4"

        let label = find<TestLabel> tree "label" :> IText

        Assert.AreEqual("0", label.Text)

        addBtn.Press()
        Assert.AreEqual("1", label.Text)

        removeBtn.Press()
        Assert.AreEqual("-1", label.Text)

        remove4Btn.Press()
        Assert.AreEqual("-5", label.Text)

module MemoTests =
    module BasicCase =
        type Model =
            { notMemoized: string
              memoTrigger: int }

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
                Label<Msg>(model.notMemoized).automationId("not_memo")

                View.lazy'
                    (fun i ->
                        renderCount <- renderCount + 1
                        Label(string i).automationId("memo"))
                    model.memoTrigger
            }

        [<Test>]
        let Test () =

            let init () =
                { notMemoized = "initial"
                  memoTrigger = 0 }

            let program = StatefulWidget.mkSimpleView init update view

            let instance = Run.Instance program
            let tree = instance.Start()

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
                | Btn -> View.lazy' (fun i -> Button(string i, Change).automationId("btn")) model
                | Lbl -> View.lazy' (fun i -> Label(string i).automationId("label")) model
            })
                .automationId("stack")

        [<Test>]
        let Test () =

            let init () = Btn

            let program = StatefulWidget.mkSimpleView init update view

            let instance = Run.Instance program
            let tree = instance.Start()

            let stack = find<TestStack> tree "stack" :> IContainer

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
                | Label1 -> View.lazy' (fun _ -> Label("one").record(true).textColor("blue").automationId("label")) model
                | Label2 -> View.lazy' (fun _ -> Label("two").record(true).textColor("blue").automationId("label")) (string model)
            }

        [<Test>]
        let Test () =

            let init () = Label1

            let program = StatefulWidget.mkSimpleView init update view

            let instance = Run.Instance program
            let tree = instance.Start()

            let label = find<TestLabel> tree "label"
            Assert.AreEqual([ TextSet "one"; ColorSet "blue" ], label.changeList)

            instance.ProcessMessage(Change)

            let labelAgain = find<TestLabel> tree "label"

            // same instance
            Assert.AreSame(label, labelAgain)

            // just changes text but kept the same color
            Assert.AreEqual([ TextSet "one"; ColorSet "blue"; TextSet "two" ], label.changeList)



module SmallScalars =
    type Msg = Inc of uint64

    type Model = { value: uint64 }

    let update msg model =
        match msg with
        | Inc value -> { model with value = model.value + value }

    let view model =
        InlineNumericBag(model.value, model.value + 1UL, float(model.value + 2UL))
            .automationId("numbers")

    let init () = { value = 0UL }

    [<Test>]
    let UpdatesCorrectly () =
        let program = StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program

        let el = instance.Start()

        let numbers = find<TestNumericBag> el "numbers"

        Assert.AreEqual(numbers.valueOne, 0UL)
        Assert.AreEqual(numbers.valueTwo, 1UL)
        Assert.AreEqual(numbers.valueThree, 2.)
        instance.ProcessMessage(Inc 4UL)

        Assert.AreEqual(numbers.valueOne, 4UL)
        Assert.AreEqual(numbers.valueTwo, 5UL)
        Assert.AreEqual(numbers.valueThree, 6.)


/// https://github.com/TimLariviere/Fabulous-new/issues/99
module Issue99 =
    type Msg = Toggle

    let init () = false

    let update msg model =
        match msg with
        | Toggle -> not model

    let view model =
        Stack() {
            Button("Button1", Toggle).automationId("button1")

            if model then
                Label("Label1")
                Button("Button2", Toggle)
        }

    [<Test>]
    let Test () =
        let program = StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program
        let tree = instance.Start()

        let button1Start = find<TestButton> tree "button1"

        instance.ProcessMessage(Toggle)

        let button1Toggled = find<TestButton> tree "button1"

        instance.ProcessMessage(Toggle)

        let button1Untoggled = find<TestButton> tree "button1"

        Assert.AreSame(button1Start, button1Toggled)
        Assert.AreSame(button1Start, button1Untoggled)

/// https://github.com/TimLariviere/Fabulous-new/issues/104
module Issue104 =
    type Msg = Toggle

    let init () = false

    let update msg model =
        match msg with
        | Toggle -> not model

    let Attr1 =
        Attributes.defineSimpleScalarWithEquality<string> "Attr1" (fun _ _ _ -> ())

    let Attr2 =
        Attributes.defineSimpleScalarWithEquality<string> "Attr2" (fun _ _ _ -> ())

    let Attr3 =
        Attributes.defineSimpleScalarWithEquality<string> "Attr3" (fun _ _ _ -> ())

    let Attr4 =
        Attributes.defineSimpleScalarWithEquality<string> "Attr4" (fun _ _ _ -> ())

    let Attr5 =
        Attributes.defineSimpleScalarWithEquality<string> "Attr5" (fun _ _ _ -> ())

    let ControlWidgetKey = Widgets.register<TestButton>()

    let Control<'msg> () =
        WidgetBuilder<'msg, TestButtonMarker>(ControlWidgetKey, AttributesBundle(StackList.StackList.empty(), ValueNone, ValueNone))

    [<System.Runtime.CompilerServices.Extension>]
    type WidgetExtensions() =
        [<System.Runtime.CompilerServices.Extension>]
        static member inline attr1<'msg, 'marker when 'marker :> IMarker>(this: WidgetBuilder<'msg, 'marker>, value: string) =
            this.AddScalar(Attr1.WithValue(value))

        [<System.Runtime.CompilerServices.Extension>]
        static member inline attr2<'msg, 'marker when 'marker :> IMarker>(this: WidgetBuilder<'msg, 'marker>, value: string) =
            this.AddScalar(Attr2.WithValue(value))

        [<System.Runtime.CompilerServices.Extension>]
        static member inline attr3<'msg, 'marker when 'marker :> IMarker>(this: WidgetBuilder<'msg, 'marker>, value: string) =
            this.AddScalar(Attr3.WithValue(value))

        [<System.Runtime.CompilerServices.Extension>]
        static member inline attr4<'msg, 'marker when 'marker :> IMarker>(this: WidgetBuilder<'msg, 'marker>, value: string) =
            this.AddScalar(Attr4.WithValue(value))

        [<System.Runtime.CompilerServices.Extension>]
        static member inline attr5<'msg, 'marker when 'marker :> IMarker>(this: WidgetBuilder<'msg, 'marker>, value: string) =
            this.AddScalar(Attr5.WithValue(value))

    let view model =
        Stack() {
            if not model then
                Control().attr4("test").attr5("test")
            else
                Control().attr1("test").attr2("test").attr3("test")
        }

    [<Test>]
    let Test () =
        let program = StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program
        let _ = instance.Start()

        instance.ProcessMessage(Toggle)

module Attributes =

    type MyEnum =
        | One = 1
        | MinusOne = -1

    let MyEnumAttr = Attributes.defineEnum<MyEnum> "hey" (fun _ _ _ -> ())

    [<Test>]
    let IntEnumCodecForSmallScalars () =
        let one = MyEnumAttr.WithValue(MyEnum.One)

        let minusOne = MyEnumAttr.WithValue(MyEnum.MinusOne)

        Assert.AreEqual(MyEnum.One, SmallScalars.IntEnum.decode<MyEnum> one.NumericValue)
        Assert.AreEqual(MyEnum.MinusOne, SmallScalars.IntEnum.decode<MyEnum> minusOne.NumericValue)



    /// In WidgetBuilders we can easily have duplicate attributes
    /// like Label("aha!").color("red").color("blue")
    /// Diffing algorithm already uses stable sort for diffing attributes
    /// Thus we need to leverage that fact
    ///
    /// In particular we might have a bug in this context
    /// prev:  Label("aha!").color("red").color("blue")
    /// next:  Label("aha!").color("red")
    ///
    /// After the diffing the resulting color should be "red", but previously
    /// it was interpreted as "removed color property" instead
    [<Test>]
    let WithDuplicateAttributesLastOneWins () =
        let view addColor =
            Stack() {
                let label = Label("text").textColor("red").automationId("text")

                if addColor then label.textColor("blue") else label
            }

        let init () = true
        let update (_: unit) addColor = not addColor


        let program = StatefulWidget.mkSimpleView init update view

        let instance = Run.Instance program
        let tree = instance.Start()

        let label = find<TestLabel> tree "text" :> IText

        Assert.AreEqual(label.TextColor, "blue")

        instance.ProcessMessage(())

        Assert.AreEqual(label.TextColor, "red")

module ViewHelpers =
    type ChildMsg = | ChildClick

    type ParentMsg =
        | ParentClick
        | ParentTap
        | ChildMessage of ChildMsg

    type GrandParentMsg =
        | GrandParentClick
        | GrandParentTap
        | ParentMessage of ParentMsg

    [<Test>]
    let ``Widget converted with View.map dispatches the right message type`` () =
        let mutable expectedMsg = Unchecked.defaultof<ParentMsg>

        let childView = Button("Child button", ChildClick).automationId("childButton")

        let parentView model =
            Stack() {
                Button("Parent button", ParentClick).automationId("parentButton")

                (View.map ChildMessage childView).tap(ParentTap)
            }

        let init () = true

        let update msg model =
            Assert.AreEqual(expectedMsg, msg)
            not model

        let program = StatefulWidget.mkSimpleView init update parentView

        let instance = Run.Instance program
        let tree = instance.Start()

        let childButton = find<TestButton> tree "childButton"
        let parentButton = find<TestButton> tree "parentButton"

        expectedMsg <- ParentClick
        parentButton.Press()

        expectedMsg <- ChildMessage ChildClick
        childButton.Press()

    [<Test>]
    let ``Adding property modifiers to widget converted with View.map is valid`` () =
        let childView = Button("Child button", ChildClick).automationId("childButton")

        let parentView model =
            Stack() { (View.map ChildMessage childView).textColor("blue") }

        let init () = true
        let update _msg model = not model

        let program = StatefulWidget.mkSimpleView init update parentView

        let instance = Run.Instance program
        let tree = instance.Start()

        let childButton = find<TestButton> tree "childButton" :> IText

        Assert.AreEqual(childButton.TextColor, "blue")

    [<Test>]
    let ``Adding event modifiers to widget converted with View.map still dispatches the right message type`` () =
        let mutable expectedMsg = Unchecked.defaultof<ParentMsg>

        let childView = Button("Child button", ChildClick).automationId("childButton")

        let parentView model =
            Stack() { (View.map ChildMessage childView).tap(ParentTap) }

        let init () = true

        let update msg model =
            Assert.AreEqual(expectedMsg, msg)
            not model

        let program = StatefulWidget.mkSimpleView init update parentView

        let instance = Run.Instance program
        let tree = instance.Start()

        let childButton = find<TestButton> tree "childButton"

        expectedMsg <- ParentTap
        childButton.Tap()

    [<Test>]
    let ``Several layers of View.map produce the right result`` () =
        let mutable expectedMsg = Unchecked.defaultof<GrandParentMsg>

        let childView = Button("Child button", ChildClick).automationId("childButton")

        let parentView =
            Stack() {
                Button("Parent button", ParentClick).automationId("parentButton")

                (View.map ChildMessage childView).tap(ParentTap)
            }

        let grandParentView model =
            Stack() {
                Button("Grand Parent button", GrandParentClick)
                    .automationId("grandParentButton")

                (View.map ParentMessage parentView)
                    .automationId("parentStack")
                    .tapContainer(GrandParentTap)
            }


        let init () = true

        let update msg model =
            Assert.AreEqual(expectedMsg, msg)
            not model

        let program = StatefulWidget.mkSimpleView init update grandParentView

        let instance = Run.Instance program
        let tree = instance.Start()

        let childButton = find<TestButton> tree "childButton"
        let parentButton = find<TestButton> tree "parentButton"

        let grandParentButton = find<TestButton> tree "grandParentButton"

        let parentStack = find<TestStack> tree "parentStack"

        expectedMsg <- ParentMessage(ChildMessage ChildClick)
        childButton.Press()

        expectedMsg <- ParentMessage ParentTap
        childButton.Tap()

        expectedMsg <- ParentMessage ParentClick
        parentButton.Press()

        expectedMsg <- GrandParentClick
        grandParentButton.Press()

        expectedMsg <- GrandParentTap
        parentStack.Tap()

    [<Test>]
    let ``Cascading View.map produce the right result`` () =
        let mutable expectedMsg = Unchecked.defaultof<GrandParentMsg>

        let childView = Button("Child button", ChildClick).automationId("childButton")

        let parentView = (View.map ChildMessage childView).tap(ParentTap)

        let grandParentView model =
            (View.map ParentMessage parentView).tap2(GrandParentTap)

        let init () = true

        let update msg model =
            Assert.AreEqual(expectedMsg, msg)
            not model

        let program = StatefulWidget.mkSimpleView init update grandParentView

        let instance = Run.Instance program
        let tree = instance.Start()

        let childButton = find<TestButton> tree "childButton"

        expectedMsg <- ParentMessage(ChildMessage ChildClick)
        childButton.Press()

        expectedMsg <- ParentMessage ParentTap
        childButton.Tap()

        expectedMsg <- GrandParentTap
        childButton.Tap2()
