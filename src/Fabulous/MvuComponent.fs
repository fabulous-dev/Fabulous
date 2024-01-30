namespace Fabulous

open System.Runtime.CompilerServices

[<Struct; NoEquality; NoComparison>]
type MvuComponentData =
    { Body: ComponentBody
      Program: Program<obj, obj, obj>
      Arg: obj }

module MvuComponent =
    let WidgetKey =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = "MvuComponent"
              TargetType = typeof<Component>
              CreateView =
                fun (widget, treeContext, _) ->
                    match widget.ScalarAttributes with
                    | ValueNone -> failwith "Component widget must have a body"
                    | ValueSome attrs ->
                        let data =
                            match Array.tryHead attrs with
                            | Some attr -> attr.Value :?> MvuComponentData
                            | None -> failwith "Component widget must have a body"

                        let ctx = new ComponentContext(1)

                        let runner = new Runner<obj, obj, obj>((fun () -> ctx.TryGetValue(0).Value), (fun v -> ctx.SetValue(0, v)), data.Program)
                        ctx.LinkDisposable(runner)

                        runner.Start(data.Arg)

                        // Redirect messages to runner
                        let treeContext =
                            { treeContext with
                                Dispatch = runner.Dispatch }

                        let comp = new Component(treeContext, data.Body, ctx)                        
                        let struct (node, view) = comp.CreateView(ValueSome widget)

                        treeContext.SetComponent view comp

                        struct (node, view)
              AttachView =
                fun (widget, treeContext, _, view) ->
                    match widget.ScalarAttributes with
                    | ValueNone -> failwith "Component widget must have a body"
                    | ValueSome attrs ->
                        let data =
                            match Array.tryHead attrs with
                            | Some attr -> attr.Value :?> MvuComponentData
                            | None -> failwith "Component widget must have a body"

                        let ctx = new ComponentContext(1)

                        let runner = new Runner<obj, obj, obj>((fun () -> ctx.TryGetValue(0).Value), (fun v -> ctx.SetValue(0, v)), data.Program)
                        ctx.LinkDisposable(runner)

                        runner.Start(data.Arg)

                        // Redirect messages to runner
                        let treeContext =
                            { treeContext with
                                Dispatch = runner.Dispatch }

                        let comp = new Component(treeContext, data.Body, ctx)
                        let node = comp.AttachView(widget, view)

                        treeContext.SetComponent view comp

                        node }

        WidgetDefinitionStore.set key definition
        key

    let Data =
        Attributes.defineSimpleScalar<MvuComponentData> "MvuComponent_Data" ScalarAttributeComparers.noCompare (fun _ _ _ -> ())

/// Delegate used by the MvuComponentBuilder to compose a component body
/// It will be aggressively inlined by the compiler leaving no overhead, only a pure function that returns a WidgetBuilder
type MvuComponentBodyBuilder<'msg, 'marker> =
    delegate of bindings: int<binding> * context: ComponentContext -> struct (int<binding> * WidgetBuilder<'msg, 'marker>)

[<Struct>]
type MvuComponentBuilder<'arg, 'msg, 'model, 'marker, 'parentMsg> =
    val public Program: Program<obj, obj, obj>
    val public Arg: obj

    new(program: Program<'arg, 'model, 'msg>, arg: 'arg) =
        let program: Program<obj, obj, obj> =
            { Init = fun arg -> let model, cmd = program.Init(unbox arg) in (box model, Cmd.map box cmd)
              Update = fun (msg, model) -> let model, cmd = program.Update(unbox msg, unbox model) in (box model, Cmd.map box cmd)
              Subscribe = fun model -> Sub.map "mvu" box (program.Subscribe(unbox model))
              Logger = program.Logger
              ExceptionHandler = program.ExceptionHandler }

        { Program = program; Arg = arg }

    member inline this.Yield(widgetBuilder: WidgetBuilder<'msg, 'marker>) =
        MvuComponentBodyBuilder<'msg, 'marker>(fun bindings ctx -> struct (bindings, widgetBuilder))

    member inline this.Combine([<InlineIfLambda>] a: MvuComponentBodyBuilder<'msg, 'marker>, [<InlineIfLambda>] b: MvuComponentBodyBuilder<'msg, 'marker>) =
        MvuComponentBodyBuilder<'msg, 'marker>(fun bindings ctx ->
            let struct (bindingsA, _) = a.Invoke(bindings, ctx) // discard the previous widget in the chain but we still need to count the bindings
            let struct (bindingsB, resultB) = b.Invoke(bindings, ctx)

            // Calculate the total number of bindings between A and B
            let resultBindings = (bindingsA + bindingsB) - bindings

            struct (resultBindings, resultB))

    member inline this.Delay([<InlineIfLambda>] fn: unit -> MvuComponentBodyBuilder<'msg, 'marker>) =
        MvuComponentBodyBuilder<'msg, 'marker>(fun bindings ctx ->
            let sub = fn()
            sub.Invoke(bindings, ctx))

    member inline this.Run([<InlineIfLambda>] body: MvuComponentBodyBuilder<'msg, 'marker>) =
        let compiledBody =
            ComponentBody(fun ctx ->
                let struct (_, result) = body.Invoke(0<binding>, ctx)
                struct (ctx, result.Compile()))

        let data =
            { Program = this.Program
              Arg = this.Arg
              Body = compiledBody }

        WidgetBuilder<'parentMsg, 'marker>(MvuComponent.WidgetKey, MvuComponent.Data.WithValue(data))

type MvuStateRequest =
    struct
    end

type Mvu =
    static member inline State = MvuStateRequest()

[<Extension>]
type MvuContextExtensions =
    [<Extension>]
    static member inline Bind
        (
            _: MvuComponentBuilder<'arg, 'msg, 'model, 'marker, 'parentMsg>,
            _: MvuStateRequest,
            [<InlineIfLambda>] continuation: 'model -> MvuComponentBodyBuilder<'msg, 'marker>
        ) =
        MvuComponentBodyBuilder<'msg, 'marker>(fun bindings ctx ->
            let key = int bindings

            let value =
                match ctx.TryGetValue<'model>(key) with
                | ValueSome value -> value
                | ValueNone -> failwith $"[MvuComponent.Bind] Model not found in ComponentContext {ctx.Id}"

            (continuation value).Invoke((bindings + 1<binding>, ctx)))
