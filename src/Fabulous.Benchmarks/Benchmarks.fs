module Fabulous.Tests.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs

open BenchmarkDotNet.Running
open Tests.TestUI_Widgets

open type View


module NestedTreeCreation =
    type Model = { depth: int }

    type Msg = Depth of int

    //    let cond d =
//        let r = d > 0
//
//        printfn $"cond %A{r}"
//        r


    let rec viewInner (depth: int) =
        //        printfn $"view on {depth}"

        Stack() {
            if (depth > 0) then
                viewInner (depth - 1)

            Label($"label1:{depth}")
                .textColor("red")
                .automationId ($"label1:{depth}")

            Label($"label2:{depth}")
                .textColor("green")
                .automationId ($"label2:{depth}")

            Button($"btn: {depth}", Depth depth)

            if (depth > 0) then
                viewInner (depth - 2)
        }

    let view d = viewInner d

    //    [<NativeMemoryProfiler>]
    [<MemoryDiagnoser>]
    [<SimpleJob(RuntimeMoniker.Net60)>]
    //    [<SimpleJob(RuntimeMoniker.Mono)>]
    //    [<SimpleJob(RuntimeMoniker.MonoAOTLLVM, warmupCount = 1)>]
    type Benchmarks() =
        [<Params(10, 20)>]
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
                  counter = model.counter + amount }

    let rec viewInner depth counter =
        Stack() {
            Label($"label1:{counter} {depth}")
                .textColor("red")
                .automationId ($"label1:{depth}")

            Label($"label2:{counter} {depth}")
                .textColor("green")
                .automationId ($"label2:{depth}")

            Button($"btn: {depth}", IncBy 2)

            if (depth > 0) then
                viewInner (depth - 1) counter

            if (depth > 0) then
                viewInner (depth - 2) counter
        }

    let view model = viewInner model.depth model.counter

    [<MemoryDiagnoser>]
    [<SimpleJob(RuntimeMoniker.Net60)>]
    type Benchmarks() =
        [<Params(10, 15)>]
        member val depth = 0 with get, set

        [<Benchmark>]
        member x.ProcessMessages() =
            let program =
                StatefulWidget.mkSimpleView (fun () -> { depth = x.depth; counter = 0 }) update view

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

//[<EntryPoint>]
//let mainProfile argv =
//
//    let b = NestedTreeCreation.Benchmarks()
//    b.depth <- 25
//
//    for _ in 0 .. 10 do
//        let widgets = b.CreateWidgets()
//        ()
//
//    0 // return an integer exit code

//[<EntryPoint>]
//let mainProfile argv =
//
//    let b = DiffingAttributes.Benchmarks()
//    b.depth <- 10
//
//    for _ in 0 .. 2 do
//        let widgets = b.ProcessMessages()
//        ()
//
//    0 // return an integer exit code
