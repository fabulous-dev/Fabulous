module Fabulous.Tests.Benchmarks

open BenchmarkDotNet.Attributes
open BenchmarkDotNet.Jobs

open BenchmarkDotNet.Running
open Tests.TestUI_Attributes.Attributes
open Tests.TestUI_Widgets

open type View


module NestedTreeCreation =
    [<Struct>]
    type Model = { depth: int }

    [<Struct>]
    type Msg = Depth of int

    let rec viewInner (depth: int) =
        //        printfn $"view on {depth}"

        Stack() {
            if (depth > 0) then viewInner(depth - 1)

            Label($"label1:{depth}")
                .textColor("red")
                .automationId($"label1:{depth}")

            Label($"label2:{depth}")
                .textColor("green")
                .automationId($"label2:{depth}")

            Button($"btn: {depth}", Depth depth)

            if (depth > 0) then viewInner(depth - 2)
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
//    [<Struct>]
    type Model = { depth: int; counter: int }

//    [<Struct>]
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
                .automationId($"label1:{depth}")

            Label($"label2:{counter} {depth}")
                .textColor("green")
                .automationId($"label2:{depth}")

            Button($"btn: {depth}", IncBy 2)

            if (depth > 0) then
                viewInner(depth - 1) counter

            if (depth > 0) then
                viewInner(depth - 2) counter
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
                StatefulWidget.mkSimpleView(fun () -> { depth = x.depth; counter = 0 }) update view

            let instance = Run.Instance program

            let _tree = (instance.Start())

            for i in 1 .. 100 do
                instance.ProcessMessage(IncBy i)


module DiffingSmallScalars =
    [<Struct>]
    type Model = { depth: int; counter: uint64 }

    [<Struct>]
    type Msg = IncBy of uint64

    let update msg model =
        match msg with
        | IncBy amount ->
            { model with
                  counter = model.counter + amount }

    let rec viewBoxedInner depth counter =
        // this is to emulate changing value only once per 5 updates
        let value = counter / 2UL
        Stack() {
            BoxedNumericBag(value, value, float value)
            BoxedNumericBag(value, value, float value)
            BoxedNumericBag(value, value, float value)
            
            if (depth > 0) then
                viewBoxedInner(depth - 1) counter

            if (depth > 0) then
                viewBoxedInner(depth - 2) counter
        }

    let rec viewInlineInner depth counter =
        // this is to emulate changing value only once per 5 updates
        let value = counter / 2UL
        Stack() {
            InlineNumericBag(value, value, float value)
            InlineNumericBag(value, value, float value)
            InlineNumericBag(value, value, float value)
            
            if (depth > 0) then
                viewInlineInner(depth - 1) counter

            if (depth > 0) then
                viewInlineInner(depth - 2) counter
        }
        
    let viewBoxed model = viewBoxedInner model.depth model.counter
    let viewInline model = viewInlineInner model.depth model.counter

    [<MemoryDiagnoser>]
    [<SimpleJob(RuntimeMoniker.Net60)>]
    type Benchmarks() =
        [<Params(15)>]
        member val depth = 0 with get, set

        [<Params(true, false)>]
        member val boxed = true with get, set
        
        [<Benchmark>]
        member x.ProcessIncrements() =
            let program =
                
                let view = if x.boxed then viewBoxed else viewInline
                
                StatefulWidget.mkSimpleView(fun () -> { depth = x.depth; counter = 0UL }) update view

            let instance = Run.Instance program

            let _tree = (instance.Start())

            for i in 1 .. 100 do
                instance.ProcessMessage(IncBy 1UL)



[<EntryPoint>]
let main argv =
//    BenchmarkRunner.Run<NestedTreeCreation.Benchmarks>()
//    |> ignore
//
//    BenchmarkRunner.Run<DiffingAttributes.Benchmarks>()
//    |> ignore
    
    printfn "Hello"
    
    BenchmarkRunner.Run<DiffingSmallScalars.Benchmarks>()
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
