namespace Fabulous

open Fabulous.ScalarAttributeDefinitions

type Init<'msg, 'model> = unit -> 'model * Cmd<'msg>
type Update<'msg, 'model> = 'msg -> 'model -> 'model * Cmd<'msg>

[<Struct; NoEquality; NoComparison>]
type MvuProgram(init: Init<obj, obj>, update: Update<obj, obj>) =
    member this.Init = init
    member this.Update = update
    
// This MvuComponent is a proxy widget just like Component
// but its specificity is to override the ViewTreeContext.Dispatch
// with its own mvu.Dispatch to allow implicit dispatching in its children just like with Fabulous 2 DSL
type MvuComponentBodyStep<'msg, 'model, 'marker> = delegate of 'model -> WidgetBuilder<'msg, 'marker>
type MvuComponentBody = delegate of obj -> Widget

[<Struct; NoEquality; NoComparison>]
type MvuComponentData =
    { MvuProgram: MvuProgram
      Body: MvuComponentBody }

type IMvuComponent =
    inherit IBaseComponent
    abstract member SetData: MvuComponentData -> unit

type MvuComponent(treeContext: ViewTreeContext, data: MvuComponentData, context: ComponentContext) =
    let mutable _data = data
    let mutable _context = context
    let mutable _widget = Unchecked.defaultof<Widget>
    let mutable _view = null
    let mutable _contextSubscription = null
    
    interface IMvuComponent with
        member this.SetData(body: MvuComponentData) =
            _data <- body
            this.Render()
        
        member this.Dispose() =
            if _contextSubscription <> null then
                _contextSubscription.Dispose()
                _contextSubscription <- null
                
    member this.Dispatch(msg: obj) =
        match _context.TryGetValue(0) with
        | ValueNone -> failwith "MvuComponent must have a model"
        | ValueSome model ->
            let newModel, _ = _data.MvuProgram.Update msg model
            _context.SetValue(0, newModel)
    
    member this.CreateView() =
        let model =
            match _context.TryGetValue(0) with
            | ValueSome model -> model
            | ValueNone ->
                let initialModel, _ = _data.MvuProgram.Init()
                _context.SetValueInternal(0, initialModel)
                initialModel
            
        let widget = _data.Body.Invoke(model)
        _widget <- widget
        
        // Replace the global dispatch with the one from the MvuComponent
        // so the child widgets can dispatch implicitly
        let treeContext = { treeContext with Dispatch = this.Dispatch }
        
        // Create the actual view
        let widgetDef = WidgetDefinitionStore.get widget.Key
        let struct (node, view) = widgetDef.CreateView(widget, treeContext, ValueNone)
        _view <- view
        
        _contextSubscription <- _context.RenderNeeded.Subscribe(this.Render)

        struct (node, view)
        
    member this.Render() =
        let model =
            match _context.TryGetValue(0) with
            | ValueNone -> failwith "MvuComponent must have a model"
            | ValueSome model -> model
        
        let prevWidget = _widget
        let widget = _data.Body.Invoke(model)
        _widget <- widget

        let viewNode = treeContext.GetViewNode _view

        Reconciler.update treeContext.CanReuseView (ValueSome prevWidget) widget viewNode
        
        
module MvuComponent =
    let Data: SimpleScalarAttributeDefinition<MvuComponentData> = Attributes.defineSimpleScalar "MvuComponent_Data" ScalarAttributeComparers.noCompare (fun _ currOpt node ->
        let comp = Component.getAttachedComponent(node.Target) :?> IMvuComponent
        match currOpt with
        | ValueNone -> failwith "MvuComponent widget must have an associated MvuComponentData"
        | ValueSome data -> comp.SetData data
    )
    
    let WidgetKey =
        let key = WidgetDefinitionStore.getNextKey()
        
        let definition =
            { Key = key
              Name = "MvuContext"
              TargetType = typeof<MvuComponent>
              AttachView = fun _ -> failwith "MvuComponent widget cannot be attached"
              CreateView = (fun (widget, treeContext, _parentNode) ->
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
type MvuComponentBuilder<'msg, 'model, 'marker> =
    val public Init: unit -> obj * Cmd<obj>
    val public Update: obj -> obj -> obj * Cmd<obj>
    
    new (init: Init<'msg, 'model>, update: Update<'msg, 'model>) =
        let init () =
            let model, cmd = init()
            box model, Cmd.map box cmd
            
        let update msg model =
            let model, cmd = update (unbox<'msg> msg) (unbox<'model> model)
            box model, Cmd.map box cmd
            
        { Init = init; Update = update }
    
    member inline this.Bind(_value: MvuStateRequest, [<InlineIfLambda>] continuation: 'model -> MvuComponentBodyStep<'msg, 'model, 'marker>) =
        MvuComponentBodyStep(fun model ->
            (continuation model).Invoke(model)
        )
    
    member inline this.Yield(widget: WidgetBuilder<'msg, 'marker>) =
        MvuComponentBodyStep(fun model -> widget)

    member inline this.Combine([<InlineIfLambda>] a: MvuComponentBodyStep<'msg, 'model, 'marker>, [<InlineIfLambda>] _b: MvuComponentBodyStep<'msg, 'model, 'marker>) =
        MvuComponentBodyStep(fun model ->
            // We only want one child, so we ignore the second one
            a.Invoke(model)
        )
        
    member inline this.Delay([<InlineIfLambda>] fn: unit -> MvuComponentBodyStep<'msg, 'model, 'marker>) =
        MvuComponentBodyStep(fun model -> fn().Invoke(model))
        
    member this.Run(result: MvuComponentBodyStep<'msg, 'model, 'marker>) =
        let body =
            MvuComponentBody(fun model ->
                result.Invoke(unbox<'model> model).Compile()
            )
            
        let data =
            { MvuProgram = MvuProgram(this.Init, this.Update)
              Body = body }
        
        WidgetBuilder<unit, 'marker>(
            MvuComponent.WidgetKey,
            MvuComponent.Data.WithValue(data)
        )