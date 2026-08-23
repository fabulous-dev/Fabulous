namespace Fabulous.Maui

open Fabulous
open System.Runtime.CompilerServices
open Microsoft.Maui.Hosting
open Microsoft.Maui.Controls.Hosting
open System

[<Extension>]
type AppHostBuilderExtensions =
    [<Extension>]
    static member inline private UseFabulousApp
        (
            this: MauiAppBuilder,
            canReuseView,
            logger,
            syncAction: (unit -> unit) -> unit,
            [<InlineIfLambda>] viewFn: unit -> Widget
        ) : MauiAppBuilder =
        this.UseMauiApp(fun (_serviceProvider: IServiceProvider) ->
            let widget = viewFn()

            let treeContext: ViewTreeContext =
                { CanReuseView = canReuseView
                  Logger = logger
                  Dispatch = ignore
                  SyncAction = syncAction
                  GetViewNode = ViewNode.get
                  GetComponent = Component.get
                  SetComponent = Component.set }

            let def = WidgetDefinitionStore.get widget.Key
            let envContext = new EnvironmentContext(logger)
            let struct (_, view) = def.CreateView(widget, envContext, treeContext, ValueNone)
            let app = view :?> Microsoft.Maui.Controls.Application
            Theme.ListenForChanges(app)
            app)

    [<Extension>]
    static member UseFabulousApp(this: MauiAppBuilder, program: Program<'arg, 'model, 'msg, #IFabApplication>, arg: 'arg) : MauiAppBuilder =
        this.UseFabulousApp(
            program.CanReuseView,
            program.State.Logger,
            program.SyncAction,
            fun () ->
                (View.Component("_") {
                    let! model = Context.Mvu(program.State, arg)
                    program.View model
                })
                    .Compile()
        )

    [<Extension>]
    static member UseFabulousApp(this: MauiAppBuilder, program: Program<unit, 'model, 'msg, #IFabApplication>) : MauiAppBuilder =
        this.UseFabulousApp(program, ())

    [<Extension>]
    static member UseFabulousApp
        (
            this: MauiAppBuilder,
            view: unit -> WidgetBuilder<unit, #IFabApplication>,
            ?canReuseView,
            ?logger,
            ?syncAction: (unit -> unit) -> unit
        ) : MauiAppBuilder =
        this.UseFabulousApp(
            (match canReuseView with
             | Some fn -> fn
             | None -> MauiViewHelpers.canReuseView),
            (match logger with
             | Some logger -> logger
             | None -> ProgramDefaults.defaultLogger()),
            (match syncAction with
             | Some synAction -> synAction
             | None -> MauiViewHelpers.defaultSyncAction),
            fun () -> (View.Component("_") { view() }).Compile()
        )
