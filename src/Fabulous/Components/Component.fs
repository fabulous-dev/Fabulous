namespace Fabulous

open System

/// This measure type is used to count the number of bindings in a component while building the computation expression
[<Measure>]
type binding

type ComponentBody =
    delegate of EnvironmentContext * ViewTreeContext * ComponentContext -> struct (EnvironmentContext * ViewTreeContext * ComponentContext * Widget)

[<Struct; NoEquality; NoComparison>]
type ComponentData = { Key: string; Body: ComponentBody }

type Component
    (componentDataKey: ScalarAttributeKey, envContext: EnvironmentContext, treeContext: ViewTreeContext, context: ComponentContext, body: ComponentBody) =
    let mutable _envContext = envContext
    let mutable _treeContext = treeContext
    let mutable _context = context
    let mutable _body = body
    let mutable _widget = Unchecked.defaultof<_>
    let mutable _view = null
    let mutable _contextSubscription: IDisposable = null

    let mutable _isReadyForRenderRequest = false
    let mutable _pendingRenderRequested = false

    member private this.MergeAttributes(rootWidget: Widget, componentWidgetOpt: Widget voption) =
        match componentWidgetOpt with
        | ValueNone ->
            struct (rootWidget.ScalarAttributes, rootWidget.WidgetAttributes, rootWidget.WidgetCollectionAttributes, rootWidget.EnvironmentAttributes)

        | ValueSome componentWidget ->
            let componentScalars =
                match componentWidget.ScalarAttributes with
                | ValueNone -> ValueNone
                | ValueSome attrs ->
                    let filteredAttrs =
                        attrs |> Array.filter(fun scalarAttr -> scalarAttr.Key <> componentDataKey)

                    ValueSome(filteredAttrs) // skip the component data

            let scalars =
                match struct (rootWidget.ScalarAttributes, componentScalars) with
                | ValueNone, ValueNone -> ValueNone
                | ValueSome attrs, ValueNone
                | ValueNone, ValueSome attrs -> ValueSome attrs
                | ValueSome widgetAttrs, ValueSome componentAttrs -> ValueSome(Array.append componentAttrs widgetAttrs)

            let widgets =
                match struct (rootWidget.WidgetAttributes, componentWidget.WidgetAttributes) with
                | ValueNone, ValueNone -> ValueNone
                | ValueSome attrs, ValueNone
                | ValueNone, ValueSome attrs -> ValueSome attrs
                | ValueSome widgetAttrs, ValueSome componentAttrs -> ValueSome(Array.append componentAttrs widgetAttrs)

            let widgetColls =
                match struct (rootWidget.WidgetCollectionAttributes, componentWidget.WidgetCollectionAttributes) with
                | ValueNone, ValueNone -> ValueNone
                | ValueSome attrs, ValueNone
                | ValueNone, ValueSome attrs -> ValueSome attrs
                | ValueSome widgetAttrs, ValueSome componentAttrs -> ValueSome(Array.append componentAttrs widgetAttrs)

            let environments =
                match struct (rootWidget.EnvironmentAttributes, componentWidget.EnvironmentAttributes) with
                | ValueNone, ValueNone -> ValueNone
                | ValueSome attrs, ValueNone
                | ValueNone, ValueSome attrs -> ValueSome attrs
                | ValueSome widgetAttrs, ValueSome componentAttrs -> ValueSome(Array.append componentAttrs widgetAttrs)

            struct (scalars, widgets, widgetColls, environments)

    member this.CreateView(componentWidget: Widget voption) =
        _isReadyForRenderRequest <- false
        _contextSubscription <- _context.RenderNeeded.Subscribe(this.Render)

        let struct (envContext, treeContext, context, rootWidget) =
            _body.Invoke(_envContext, _treeContext, _context)

        _widget <- rootWidget
        _envContext <- envContext
        _treeContext <- treeContext
        _context <- context

        let struct (scalars, widgets, widgetColls, environments) =
            this.MergeAttributes(rootWidget, componentWidget)

        let rootWidget: Widget =
            { Key = rootWidget.Key
#if DEBUG
              DebugName = rootWidget.DebugName
#endif
              ScalarAttributes = scalars
              WidgetAttributes = widgets
              WidgetCollectionAttributes = widgetColls
              EnvironmentAttributes = environments }

        // Create the actual view
        let widgetDef = WidgetDefinitionStore.get rootWidget.Key

        let struct (node, view) =
            widgetDef.CreateView(rootWidget, envContext, treeContext, ValueNone)

        _view <- view
        _isReadyForRenderRequest <- true

        // ComponentContext.SetNeedsRender has been called before the view is created
        // We need to re-render the component now because the state has changed before we were ready
        if _pendingRenderRequested then
            _pendingRenderRequested <- false
            this.Render()

        struct (node, view)

    member this.AttachView(componentWidget: Widget, view: obj) =
        _isReadyForRenderRequest <- false
        _contextSubscription <- _context.RenderNeeded.Subscribe(this.Render)

        let struct (envContext, treeContext, context, rootWidget) =
            _body.Invoke(_envContext, _treeContext, _context)

        _widget <- rootWidget
        _envContext <- envContext
        _treeContext <- treeContext
        _context <- context

        let struct (scalars, widgets, widgetColls, environments) =
            this.MergeAttributes(rootWidget, ValueSome componentWidget)

        let rootWidget: Widget =
            { Key = rootWidget.Key
#if DEBUG
              DebugName = rootWidget.DebugName
#endif
              ScalarAttributes = scalars
              WidgetAttributes = widgets
              WidgetCollectionAttributes = widgetColls
              EnvironmentAttributes = environments }

        // Attach the widget to the existing view
        let widgetDef = WidgetDefinitionStore.get rootWidget.Key

        let node =
            widgetDef.AttachView(rootWidget, envContext, treeContext, ValueNone, view)

        _view <- view
        _isReadyForRenderRequest <- true

        // ComponentContext.SetNeedsRender has been called before the view is created
        // We need to re-render the component now because the state has changed before we were ready
        if _pendingRenderRequested then
            _pendingRenderRequested <- false
            this.Render()

        node

    member private this.RenderInternal() =
        if isNull _body then
            () // Component has been disposed
        else
            let prevRootWidget = _widget
            let prevContext = _context

            let struct (envContext, treeContext, context, currRootWidget) =
                _body.Invoke(_envContext, _treeContext, _context)

            _widget <- currRootWidget
            _envContext <- envContext
            _treeContext <- treeContext

            if prevContext <> context then
                _contextSubscription.Dispose()
                prevContext.Dispose()
                _contextSubscription <- context.RenderNeeded.Subscribe(this.Render)
                _context <- context

            let viewNode = treeContext.GetViewNode _view

            Reconciler.update treeContext.CanReuseView (ValueSome prevRootWidget) currRootWidget viewNode

    member this.Dispose() =
        if not(isNull _contextSubscription) then
            _contextSubscription.Dispose()

        if not(isNull _context) then
            _context.Dispose()

        _body <- null
        _widget <- Unchecked.defaultof<_>
        _view <- null
        _envContext <- Unchecked.defaultof<_>
        _treeContext <- Unchecked.defaultof<_>
        _contextSubscription <- null
        _context <- null

    interface IDisposable with
        member this.Dispose() = this.Dispose()

    member this.Render() =
        if isNull _body then
            () // Component has been disposed
        else if not _isReadyForRenderRequest then
            _pendingRenderRequested <- true
        else
            treeContext.SyncAction(this.RenderInternal)
