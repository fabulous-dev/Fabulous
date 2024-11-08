namespace Fabulous

open System.Runtime.CompilerServices

type ModelValue<'model> = private ModelValue of 'model

type MvuRequest<'arg, 'model, 'msg> = delegate of unit -> struct (Program<'arg, 'model, 'msg> * 'arg)

[<AutoOpen>]
module MvuBuilders =
    type Context with
        static member inline Mvu(program: Program<unit, 'model, 'msg>) =
            MvuRequest<unit, 'model, 'msg>(fun () -> program, ())

        static member inline Mvu(program: Program<'arg, 'model, 'msg>, arg: 'arg) =
            MvuRequest<'arg, 'model, 'msg>(fun () -> program, arg)

[<Extension>]
type MvuExtensions =
    [<Extension>]
    static member Bind
        (_: ComponentBuilder<'parentMsg, 'marker>, fn: MvuRequest<'arg, 'model, 'msg>, continuation: 'model -> ComponentBodyBuilder<'msg, 'marker>)
        =
        ComponentBodyBuilder<'msg, 'marker>(fun envContext treeContext context bindings ->
            let key = int bindings

            let struct (treeContext, state) =
                match context.TryGetValue(key) with
                | ValueSome(ModelValue state) -> treeContext, state
                | ValueNone ->
                    let struct (program, arg) = fn.Invoke()

                    let runner =
                        context.LinkDisposable(
                            "runner",
                            fun () ->
                                let getModel () =
                                    match context.TryGetValue<ModelValue<'model>>(key) with
                                    | ValueNone -> failwith("Model not found in ComponentContext " + context.Id.ToString())
                                    | ValueSome(ModelValue model) -> model

                                let setModel v = context.SetValue(key, ModelValue v)

                                new Runner<'arg, 'model, 'msg>(getModel, setModel, program)
                        )

                    // Redirect messages to runner
                    let treeContext =
                        { treeContext with
                            Dispatch = unbox >> runner.Dispatch }

                    runner.Start(arg)

                    let (ModelValue state) = context.TryGetValue(key).Value

                    treeContext, state

            (continuation state)
                .Invoke(envContext, treeContext, context, bindings + 1<binding>))
