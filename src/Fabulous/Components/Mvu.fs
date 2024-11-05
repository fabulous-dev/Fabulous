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

                    let programObj: Program<obj, obj, obj> =
                        { Init = fun arg -> let model, cmd = program.Init(unbox arg) in (box model, Cmd.map box cmd)
                          Update = fun (msg, model) -> let model, cmd = program.Update(unbox msg, unbox model) in (box model, Cmd.map box cmd)
                          Subscribe = fun model -> Sub.map "mvu" box (program.Subscribe(unbox model))
                          Logger = program.Logger
                          ExceptionHandler = program.ExceptionHandler }

                    let runner =
                        context.LinkDisposable(
                            "runner",
                            fun () ->
                                let getModel () =
                                    match context.TryGetValue<ModelValue<'model>>(key) with
                                    | ValueNone -> failwith("Model not found in ComponentContext " + context.Id.ToString())
                                    | ValueSome(ModelValue model) -> box model

                                let setModel v =
                                    context.SetValue(key, ModelValue(unbox<'model> v))
                                    context.NeedsRender()

                                let runner = new Runner<obj, obj, obj>(getModel, setModel, programObj)
                                runner.Start(arg)
                                runner
                        )

                    // Redirect messages to runner
                    let treeContext =
                        { treeContext with
                            Dispatch = (runner :?> Runner<obj, obj, obj>).Dispatch }

                    let (ModelValue state) = context.TryGetValue(key).Value

                    treeContext, state

            (continuation state)
                .Invoke(envContext, treeContext, context, bindings + 1<binding>))
