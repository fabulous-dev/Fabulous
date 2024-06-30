namespace Fabulous

open System
open Fabulous
open Fabulous.ScalarAttributeDefinitions

module ComponentAttributes =
    /// Define an attribute for EventHandler
    let inline defineEventNoArg name ([<InlineIfLambda>] getEvent: obj -> IEvent<EventHandler, EventArgs>) : SimpleScalarAttributeDefinition<unit -> unit> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: (unit -> unit) voption) node ->
                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.RemoveHandler(name)
                    | ValueSome(fn) ->
                        let event = getEvent node.Target
                        node.SetHandler(name, event.Subscribe(fun _ -> fn())))
            )

            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    /// Define an attribute for EventHandler<'T>
    let inline defineEvent<'args>
        name
        ([<InlineIfLambda>] getEvent: obj -> IEvent<EventHandler<'args>, 'args>)
        : SimpleScalarAttributeDefinition<'args -> unit> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: ('args -> unit) voption) node ->
                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.RemoveHandler(name)
                    | ValueSome(fn) ->
                        let event = getEvent node.Target
                        node.SetHandler(name, event.Subscribe(fun args -> fn args)))
            )

            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }
