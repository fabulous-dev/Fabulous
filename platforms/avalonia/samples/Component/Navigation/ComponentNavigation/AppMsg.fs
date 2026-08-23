namespace ComponentNavigation

/// With each component runs in an isolated context, so we need a way to communicate between them.
/// We define application-wide messages here, and a dispatcher to send and receive messages.
[<RequireQualifiedAccess>]
type AppMsg = | BackButtonPressed

type IAppMessageDispatcher =
    abstract Dispatched: IEvent<AppMsg>
    abstract member Dispatch: AppMsg -> unit

type AppMessageDispatcher() =
    let dispatched = Event<AppMsg>()

    interface IAppMessageDispatcher with
        member _.Dispatched = dispatched.Publish
        member _.Dispatch(msg) = dispatched.Trigger(msg)
