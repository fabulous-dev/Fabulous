namespace Fabulous

open Fabulous.Runners
open Fabulous.ScalarAttributeDefinitions

// This MvuComponent is a proxy widget just like Component
// but its specificity is to override the ViewTreeContext.Dispatch
// with its own mvu.Dispatch to allow implicit dispatching in its children just like with Fabulous 2 DSL
type MvuComponentBodyStep<'msg, 'model, 'marker> = delegate of 'model -> WidgetBuilder<'msg, 'marker>
type MvuComponentBody = delegate of obj -> Widget

[<Struct; NoEquality; NoComparison>]
type MvuComponentData =
    { Program: Program<obj, obj, obj>
      Arg: obj
      Body: MvuComponentBody }

type IMvuComponent =
    inherit IBaseComponent
    abstract member SetData: MvuComponentData -> unit

type MvuComponent(treeContext, envContext, context, data: MvuComponentData) as this =
    inherit BaseComponent(treeContext, envContext, context)

    let mutable _body = data.Body
    let mutable _arg = data.Arg

    let mutable _runner =
        Runner<obj, obj, obj>(0, this.GetModel, this.SetModel, data.Program)

    let mutable _widget = Unchecked.defaultof<Widget>
    let mutable _view = null

    interface IMvuComponent with
        member this.SetData(data: MvuComponentData) =
            _body <- data.Body
            _arg <- data.Arg
            _runner.Program <- data.Program
            this.Render()

    member private this.GetModel(key: StateKey) =
        match this.Context.TryGetValue(key) with
        | ValueSome model -> model
        | ValueNone -> failwith "Model not found"

    member private this.SetModel (key: StateKey) (model: obj) = this.Context.SetValue(key, model)

    member this.Dispatch(msg: obj) = _runner.Dispatch(msg)

    member this.AttachView(view) =
        _runner.Start(_arg)
        let widget = _body.Invoke(this.GetModel(0))
        _widget <- widget

        // Replace the global dispatch with the one from the MvuComponent
        // so the child widgets can dispatch implicitly
        let treeContext =
            { treeContext with
                Dispatch = this.Dispatch }

        // Create the actual view
        let widgetDef = WidgetDefinitionStore.get widget.Key
        let node = widgetDef.AttachView(widget, treeContext, this.EnvironmentContext, ValueNone, view)
        _view <- view
        
        BaseComponent.setAttachedComponent view this

        this.Context.AddDisposable("context", this.Context.RenderNeeded.Subscribe(this.Render))

        node

    member this.CreateView() =
        _runner.Start(_arg)

        let widget = _body.Invoke(this.GetModel(0))
        _widget <- widget

        // Replace the global dispatch with the one from the MvuComponent
        // so the child widgets can dispatch implicitly
        let treeContext =
            { treeContext with
                Dispatch = this.Dispatch }

        // Create the actual view
        let widgetDef = WidgetDefinitionStore.get widget.Key

        let struct (node, view) =
            widgetDef.CreateView(widget, treeContext, this.EnvironmentContext, ValueNone)

        _view <- view

        BaseComponent.setAttachedComponent view this

        this.Context.AddDisposable("context", this.Context.RenderNeeded.Subscribe(this.Render))

        struct (node, view)

    member this.Render() =
        let prevWidget = _widget
        let widget = _body.Invoke(this.GetModel(0))
        _widget <- widget

        let viewNode = treeContext.GetViewNode _view

        Reconciler.update treeContext.CanReuseView (ValueSome prevWidget) widget viewNode


module MvuComponent =
    let Data: SimpleScalarAttributeDefinition<MvuComponentData> =
        Attributes.defineSimpleScalar "MvuComponent_Data" ScalarAttributeComparers.noCompare (fun _ currOpt node ->
            let comp = BaseComponent.getAttachedComponent(node.Target) :?> IMvuComponent

            match currOpt with
            | ValueNone -> failwith "MvuComponent widget must have an associated MvuComponentData"
            | ValueSome data -> comp.SetData data)

    let WidgetKey =
        let key = WidgetDefinitionStore.getNextKey()

        let definition =
            { Key = key
              Name = "MvuContext"
              TargetType = typeof<MvuComponent>
              AttachView =
                fun (widget, treeContext, env, _parentNode, view) ->
                    let data =
                        match widget.ScalarAttributes with
                        | ValueNone -> failwith "MvuComponent widget must have an associated MvuComponentData"
                        | ValueSome attrs ->
                            match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = Data.Key) attrs with
                            | None -> failwith "MvuComponent widget must have an associated MvuComponentData"
                            | Some attr -> attr.Value :?> MvuComponentData

                    let comp = new MvuComponent(treeContext, env, new ComponentContext(1), data)
                    let node = comp.AttachView(view)
                    node
              CreateView =
                (fun (widget, treeContext, env, _parentNode) ->
                    let data =
                        match widget.ScalarAttributes with
                        | ValueNone -> failwith "MvuComponent widget must have an associated MvuComponentData"
                        | ValueSome attrs ->
                            match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = Data.Key) attrs with
                            | None -> failwith "MvuComponent widget must have an associated MvuComponentData"
                            | Some attr -> attr.Value :?> MvuComponentData

                    let env = new EnvironmentContext(env)

                    let comp = new MvuComponent(treeContext, env, new ComponentContext(1), data)
                    let struct (node, view) = comp.CreateView()
                    struct (node, view)) }

        WidgetDefinitionStore.set key definition

        key

[<Struct>]
type MvuStateRequest = | MvuStateRequest

type Mvu =
    static member inline State = MvuStateRequest

/// This is a builder that allows to build a MvuContext widget
/// It is almost identical to SingleChildBuilder, except the resulting WidgetBuilder will have a 'msg type of unit
/// because the MvuContext widget will handle its own dispatching internally
[<Struct>]
type MvuComponentBuilder<'msg, 'marker, 'cArg, 'cMsg, 'cModel> =
    val public Program: Program<obj, obj, obj>
    val public Arg: obj

    new(program: Program<'cArg, 'cModel, 'cMsg>, arg: 'cArg) =
        let program: Program<obj, obj, obj> =
            { Environment = program.Environment
              Init = fun arg -> let model, cmd = program.Init(unbox arg) in (box model, Cmd.map box cmd)
              Update = fun (msg, model) -> let model, cmd = program.Update(unbox msg, unbox model) in (box model, Cmd.map box cmd)
              Subscribe = fun model -> Cmd.map box (program.Subscribe(unbox model))
              Logger = program.Logger
              ExceptionHandler = program.ExceptionHandler }

        { Program = program; Arg = arg }

    member inline this.Bind(_value: MvuStateRequest, [<InlineIfLambda>] continuation: 'cModel -> MvuComponentBodyStep<'cMsg, 'cModel, 'cMarker>) =
        MvuComponentBodyStep(fun model -> (continuation model).Invoke(model))

    member inline this.Yield(widget: WidgetBuilder<'cMsg, 'marker>) =
        MvuComponentBodyStep(fun model -> widget)

    member inline this.Combine
        (
            [<InlineIfLambda>] a: MvuComponentBodyStep<'cMsg, 'cModel, 'marker>,
            [<InlineIfLambda>] _b: MvuComponentBodyStep<'cMsg, 'cModel, 'marker>
        ) =
        MvuComponentBodyStep(fun model ->
            // We only want one child, so we ignore the second one
            a.Invoke(model))

    member inline this.Delay([<InlineIfLambda>] fn: unit -> MvuComponentBodyStep<'cMsg, 'cModel, 'marker>) =
        MvuComponentBodyStep(fun model -> fn().Invoke(model))

    member this.Run(result: MvuComponentBodyStep<'cMsg, 'cModel, 'marker>) =
        let body =
            MvuComponentBody(fun model -> result.Invoke(unbox<'cModel> model).Compile())

        let data =
            { Program = this.Program
              Arg = this.Arg
              Body = body }

        WidgetBuilder<'msg, 'marker>(MvuComponent.WidgetKey, MvuComponent.Data.WithValue(data))
