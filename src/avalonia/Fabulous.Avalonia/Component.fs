namespace Fabulous.Avalonia

open System
open System.Runtime.CompilerServices
open Avalonia
open Fabulous
open Fabulous.ScalarAttributeDefinitions

module Component =
    let ComponentProperty =
        StyledProperty.RegisterAttached<Component, AvaloniaObject, obj>("Component")

    let get (target: obj) =
        (target :?> AvaloniaObject).GetValue(ComponentProperty)

    let set (comp: obj) (target: obj) =
        (target :?> AvaloniaObject)
            .SetValue(ComponentProperty, comp)
        |> ignore


[<AutoOpen>]
module ComponentBuilders =
    type Fabulous.Avalonia.View with

        static member Component<'msg, 'marker when 'msg: equality>(key: string) = ComponentBuilder<'msg, 'marker>(key)

module ComponentAttributes =
    [<Literal>]
    let private OnReceiveHandlerKey = "onReceive"

    [<Struct>]
    type OnReceiveValue =
        { Id: obj
          Subscribe: IViewNode -> IDisposable }

    let OnReceive: SimpleScalarAttributeDefinition<OnReceiveValue> =
        { Key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                (fun (a: OnReceiveValue) (b: OnReceiveValue) ->
                    if obj.ReferenceEquals(a.Id, b.Id) then
                        ScalarAttributeComparison.Identical
                    else
                        ScalarAttributeComparison.Different),
                (fun (_oldValueOpt: OnReceiveValue voption) (newValueOpt: OnReceiveValue voption) (node: IViewNode) ->
                    match newValueOpt with
                    | ValueNone ->
                        match node.TryGetHandler(OnReceiveHandlerKey) with
                        | ValueSome d ->
                            d.Dispose()
                            node.RemoveHandler(OnReceiveHandlerKey)
                        | ValueNone -> ()
                    | ValueSome value ->
                        let newDisp = value.Subscribe node

                        match node.TryGetHandler(OnReceiveHandlerKey) with
                        | ValueSome oldDisp -> oldDisp.Dispose()
                        | ValueNone -> ()

                        node.SetHandler(OnReceiveHandlerKey, newDisp))
            )
            |> AttributeDefinitionStore.registerScalar
          Name = OnReceiveHandlerKey }

[<AutoOpen>]
module internal ComponentModifiersHelpers =
    let inline addOrReplaceOnReceive<'msg, 'marker when 'msg: equality>
        (builder: WidgetBuilder<'msg, 'marker>)
        (identity: obj)
        ([<InlineIfLambda>] subscribe: IViewNode -> IDisposable)
        : WidgetBuilder<'msg, 'marker> =
        builder.AddOrReplaceScalar(
            ComponentAttributes.OnReceive.Key,
            (fun oldAttr ->
                let old = unbox<ComponentAttributes.OnReceiveValue> oldAttr.Value

                if obj.ReferenceEquals(old.Id, identity) then
                    oldAttr
                else
                    ComponentAttributes.OnReceive.WithValue(
                        { ComponentAttributes.OnReceiveValue.Id = identity
                          ComponentAttributes.OnReceiveValue.Subscribe = subscribe }
                    )),
            (fun () ->
                ComponentAttributes.OnReceive.WithValue(
                    { ComponentAttributes.OnReceiveValue.Id = identity
                      ComponentAttributes.OnReceiveValue.Subscribe = subscribe }
                ))
        )

type ComponentModifiers =
    /// <summary>Attaches an event handler to the widget</summary>
    /// <param name="this">The current widget builder</param>
    /// <param name="source">The event source</param>
    /// <param name="action">The event handler</param>
    /// <code lang="fsharp">
    /// Component("MyComponent") {
    ///     let! count = State(0)
    ///     let timer = ..
    ///
    ///     (VStack() {
    ///         TextBlock($"%d{count.Current}")
    ///     })
    ///     .onReceive(timer.Tick, fun _ -> count.Set(count.Current + 1))
    /// }
    /// </code>
    [<Extension>]
    static member inline onReceive(this: WidgetBuilder<'msg, 'marker>, source: IObservable<'T>, [<InlineIfLambda>] action: 'T -> unit) =
        let id = source :> obj

        let inline subscribe (node: IViewNode) : IDisposable =
            source.Subscribe(fun value -> node.TreeContext.SyncAction(fun () -> action value))

        addOrReplaceOnReceive this id subscribe

    /// <summary>Attaches an event handler to the widget</summary>
    /// <param name="this">The current widget builder</param>
    /// <param name="source">The event source</param>
    /// <param name="action">The event handler</param>
    /// <code lang="fsharp">
    /// Component("MyComponent") {
    ///     let! count = State(0)
    ///     let timer = ..
    ///
    ///     (VStack() {
    ///         TextBlock($"%d{count.Current}")
    ///     })
    ///     .onReceive(timer.Tick, fun _ -> count.Set(count.Current + 1))
    /// }
    /// </code>
    [<Extension>]
    static member inline onReceive(this: WidgetBuilder<'msg, 'marker>, source: IEvent<EventHandler<'T>, 'T>, [<InlineIfLambda>] action: 'T -> unit) =
        ComponentModifiers.onReceive(this, (source :> IObservable<'T>), action)

    /// <summary>Attaches an event handler to the widget</summary>
    /// <param name="this">The current widget builder</param>
    /// <param name="source">The event source</param>
    /// <param name="action">The event handler</param>
    /// <code lang="fsharp">
    /// Component("MyComponent") {
    ///     let! count = State(0)
    ///     let timer = ..
    ///
    ///     (VStack() {
    ///         TextBlock($"%d{count.Current}")
    ///     })
    ///     .onReceive(timer.Tick, fun _ -> count.Set(count.Current + 1))
    /// }
    /// </code>
    [<Extension>]
    static member inline onReceive(this: WidgetBuilder<'msg, 'marker>, source: Event<'T>, [<InlineIfLambda>] action: 'T -> unit) =
        ComponentModifiers.onReceive(this, (source.Publish :> IObservable<'T>), action)

    /// <summary>Attaches an event handler to the widget using a custom identity key to control resubscription</summary>
    /// <param name="this">The current widget builder</param>
    /// <param name="key">Stable identity key; when the same instance is provided across renders, the subscription is preserved</param>
    /// <param name="source">The event source</param>
    /// <param name="action">The event handler</param>
    [<Extension>]
    static member inline onReceive(this: WidgetBuilder<'msg, 'marker>, key: obj, source: IObservable<'T>, [<InlineIfLambda>] action: 'T -> unit) =
        let inline subscribe (node: IViewNode) : IDisposable =
            source.Subscribe(fun value -> node.TreeContext.SyncAction(fun () -> action value))

        addOrReplaceOnReceive this key subscribe
