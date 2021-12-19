module Fabulous.Tests.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Running
open BenchmarkDotNet.Jobs

open Tests.TestUI_Widgets

open type View


module NestedTreeCreation =
    type Model = { depth: int }

    type Msg = Depth of int

    let rec view (depth: int) =
        Stack() {
            Label($"label1:{depth}")
                .textColor("red")
                .automationId($"label1:{depth}")

            Label($"label2:{depth}")
                .textColor("green")
                .automationId($"label2:{depth}")

            Button($"btn: {depth}", Depth depth)

            if (depth > 0) then view(depth - 1)
        }

    [<SimpleJob(RuntimeMoniker.Net60)>]
    type Benchmarks() =
        [<Params(100, 1000)>]
        member val depth = 0 with get, set

        [<Benchmark>]
        member x.CreateWidgets() = view x.depth


module DiffingAttributes =
    type Model = { depth: int; counter: int }

    type Msg = IncBy of int

    let update msg model =
        match msg with
        | IncBy amount ->
            { model with
                counter = model.counter + amount
            }

    let rec viewInner depth counter =
        Stack() {
            Label($"label1:{counter} {depth}")
                .textColor("red")
                .automationId($"label1:{depth}")

            Label($"label2:{counter} {depth}")
                .textColor("green")
                .automationId($"label2:{depth}")

            Button($"btn: {depth}", IncBy 2)

            if (depth > 0) then
                viewInner(depth - 1) counter
        }

    let view model = viewInner model.depth model.counter

    [<SimpleJob(RuntimeMoniker.Net60)>]
    type Benchmarks() =
        [<Params(100, 1000)>]
        member val depth = 0 with get, set

        [<Benchmark>]
        member x.ProcessMessages() =
            let program =
                StatefulWidget.mkSimpleView(fun () -> { depth = x.depth; counter = 0 }) update view

            let instance = Run.Instance program

            let _tree = (instance.Start())

            for i in 1 .. 100 do
                instance.ProcessMessage(IncBy i)

[<EntryPoint>]
let main argv =
    BenchmarkRunner.Run<NestedTreeCreation.Benchmarks>()
    |> ignore

    BenchmarkRunner.Run<DiffingAttributes.Benchmarks>()
    |> ignore

    0 // return an integer exit code
