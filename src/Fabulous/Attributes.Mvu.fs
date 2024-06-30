namespace Fabulous

open System
open System.Runtime.CompilerServices
open Fabulous
open Fabulous.ScalarAttributeDefinitions

type MsgValue = MsgValue of obj

[<Extension>]
type SimpleScalarAttributeDefinitionExtensions() =
    [<Extension>]
    static member inline WithValue(this: SimpleScalarAttributeDefinition<'args -> MsgValue>, value: 'args -> 'msg) =
        this.WithValue(value >> box >> MsgValue)

module MvuAttributes =

    /// Define an attribute for EventHandler
    let inline defineEventNoArg name ([<InlineIfLambda>] getEvent: obj -> IEvent<EventHandler, EventArgs>) : SimpleScalarAttributeDefinition<MsgValue> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: MsgValue voption) node ->
                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.RemoveHandler(name)
                    | ValueSome(MsgValue msg) ->
                        let event = getEvent node.Target
                        let handler = event.Subscribe(fun _ -> Dispatcher.dispatch node msg)
                        node.SetHandler(name, handler))
            )

            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }

    /// Define an attribute for EventHandler<'T>
    let inline defineEvent<'args>
        name
        ([<InlineIfLambda>] getEvent: obj -> IEvent<EventHandler<'args>, 'args>)
        : SimpleScalarAttributeDefinition<'args -> MsgValue> =
        let key =
            SimpleScalarAttributeDefinition.CreateAttributeData(
                ScalarAttributeComparers.noCompare,
                (fun _ (newValueOpt: ('args -> MsgValue) voption) (node: IViewNode) ->
                    match node.TryGetHandler(name) with
                    | ValueNone -> ()
                    | ValueSome handler -> handler.Dispose()

                    match newValueOpt with
                    | ValueNone -> node.RemoveHandler(name)
                    | ValueSome fn ->
                        let event = getEvent node.Target

                        let handler =
                            event.Subscribe(fun args ->
                                let (MsgValue r) = fn args
                                Dispatcher.dispatch node r)

                        node.SetHandler(name, handler))
            )
            |> AttributeDefinitionStore.registerScalar

        { Key = key; Name = name }
