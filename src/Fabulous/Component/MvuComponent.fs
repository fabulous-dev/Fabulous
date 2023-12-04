namespace Fabulous

open Fabulous.Runners
open Fabulous.ScalarAttributeDefinitions

type Init<'msg, 'model> = unit -> 'model * Cmd<'msg>
type Update<'msg, 'model> = 'msg -> 'model -> 'model * Cmd<'msg>

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

type MvuComponent(treeContext: ViewTreeContext, data: MvuComponentData, context: ComponentContext) as this =
    let mutable _body = data.Body
    let mutable _arg = data.Arg

    let mutable _runner =
        Runner<obj, obj, obj>(0, this.GetModel, this.SetModel, data.Program)

    let mutable _context = context
    let mutable _widget = Unchecked.defaultof<Widget>
    let mutable _view = null
    let mutable _contextSubscription = null

    interface IMvuComponent with
        member this.SetData(data: MvuComponentData) =
            _body <- data.Body
            _arg <- data.Arg
            // TODO: We should probably reset the runner here
            this.Render()

        member this.Dispose() =
            if _contextSubscription <> null then
                _contextSubscription.Dispose()
                _contextSubscription <- null

    member private this.GetModel(key: StateKey) =
        match _context.TryGetValue(key) with
        | ValueSome model -> model
        | ValueNone ->
            let initialModel, cmd = _runner.Program.Init _arg
            _context.SetValueInternal(0, initialModel)

            for sub in cmd do
                _runner.Dispatch(sub)

            initialModel

    member private this.SetModel (key: StateKey) (model: obj) = _context.SetValue(key, model)

    member this.Dispatch(msg: obj) = _runner.Dispatch(msg)

    member this.AttachView(view) =
        let widget = _body.Invoke(this.GetModel(0))
        _widget <- widget

        // Replace the global dispatch with the one from the MvuComponent
        // so the child widgets can dispatch implicitly
        let treeContext =
            { treeContext with
                Dispatch = this.Dispatch }

        // Create the actual view
        let widgetDef = WidgetDefinitionStore.get widget.Key
        let node = widgetDef.AttachView(widget, treeContext, ValueNone, view)
        _view <- view

        _contextSubscription <- _context.RenderNeeded.Subscribe(this.Render)

        node

    member this.CreateView() =
        let widget = _body.Invoke(this.GetModel(0))
        _widget <- widget

        // Replace the global dispatch with the one from the MvuComponent
        // so the child widgets can dispatch implicitly
        let treeContext =
            { treeContext with
                Dispatch = this.Dispatch }

        // Create the actual view
        let widgetDef = WidgetDefinitionStore.get widget.Key
        let struct (node, view) = widgetDef.CreateView(widget, treeContext, ValueNone)
        _view <- view

        _contextSubscription <- _context.RenderNeeded.Subscribe(this.Render)

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
            let comp = Component.getAttachedComponent(node.Target) :?> IMvuComponent

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
                fun (widget, treeContext, _parentNode, view) ->
                    let data =
                        match widget.ScalarAttributes with
                        | ValueNone -> failwith "MvuComponent widget must have an associated MvuComponentData"
                        | ValueSome attrs ->
                            match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = Data.Key) attrs with
                            | None -> failwith "MvuComponent widget must have an associated MvuComponentData"
                            | Some attr -> attr.Value :?> MvuComponentData

                    let comp = new MvuComponent(treeContext, data, ComponentContext(1))
                    let node = comp.AttachView(view)
                    node
              CreateView =
                (fun (widget, treeContext, _parentNode) ->
                    let data =
                        match widget.ScalarAttributes with
                        | ValueNone -> failwith "MvuComponent widget must have an associated MvuComponentData"
                        | ValueSome attrs ->
                            match Array.tryFind (fun (attr: ScalarAttribute) -> attr.Key = Data.Key) attrs with
                            | None -> failwith "MvuComponent widget must have an associated MvuComponentData"
                            | Some attr -> attr.Value :?> MvuComponentData

                    let comp = new MvuComponent(treeContext, data, ComponentContext(1))
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
type MvuComponentBuilder<'arg, 'msg, 'model, 'marker> =
    val public Program: Program<obj, obj, obj>
    val public Arg: obj

    new(program: Program<'arg, 'model, 'msg>, arg: 'arg) =
        let program: Program<obj, obj, obj> =
            { Init = fun arg -> let model, cmd = program.Init(unbox arg) in (box model, Cmd.map box cmd)
              Update = fun (msg, model) -> let model, cmd = program.Update(unbox msg, unbox model) in (box model, Cmd.map box cmd)
              Subscribe = fun model -> Cmd.map box (program.Subscribe(unbox model))
              Logger = program.Logger
              ExceptionHandler = program.ExceptionHandler }

        { Program = program; Arg = arg }

    member inline this.Bind(_value: MvuStateRequest, [<InlineIfLambda>] continuation: 'model -> MvuComponentBodyStep<'msg, 'model, 'marker>) =
        MvuComponentBodyStep(fun model -> (continuation model).Invoke(model))

    member inline this.Yield(widget: WidgetBuilder<'msg, 'marker>) =
        MvuComponentBodyStep(fun model -> widget)

    member inline this.Combine
        (
            [<InlineIfLambda>] a: MvuComponentBodyStep<'msg, 'model, 'marker>,
            [<InlineIfLambda>] _b: MvuComponentBodyStep<'msg, 'model, 'marker>
        ) =
        MvuComponentBodyStep(fun model ->
            // We only want one child, so we ignore the second one
            a.Invoke(model))

    member inline this.Delay([<InlineIfLambda>] fn: unit -> MvuComponentBodyStep<'msg, 'model, 'marker>) =
        MvuComponentBodyStep(fun model -> fn().Invoke(model))

    member this.Run(result: MvuComponentBodyStep<'msg, 'model, 'marker>) =
        let body =
            MvuComponentBody(fun model -> result.Invoke(unbox<'model> model).Compile())

        let data =
            { Program = this.Program
              Arg = this.Arg
              Body = body }

        WidgetBuilder<unit, 'marker>(MvuComponent.WidgetKey, MvuComponent.Data.WithValue(data))
