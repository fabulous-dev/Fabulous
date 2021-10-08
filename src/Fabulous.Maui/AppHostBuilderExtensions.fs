namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Extensions.DependencyInjection.Extensions
open Fabulous

[<Extension>]
type AppHostBuilderExtensions () =
    [<Extension>]
    static member UseFabulousApp<'model, 'msg, 'view when 'view :> IApplicationWidget<'msg>>(this: MauiAppBuilder, app: StatefulApplication<unit, 'model, 'msg, 'view>) =
        this.Services.TryAddSingleton<IApplication>(fun (x: IServiceProvider) ->
            let runner = Runners.create app
            runner.Start()
            let adapter = ViewAdapters.create runner
            adapter.CreateView() |> unbox
        )
        this

    [<Extension>]
    static member UseFabulousAppWithArgs<'arg, 'model, 'msg, 'view when 'view :> IApplicationWidget<'msg>>(this: MauiAppBuilder, app: StatefulApplication<'arg, 'model, 'msg, 'view>, arg: 'arg) =
        this.Services.TryAddSingleton<IApplication>(fun (x: IServiceProvider) ->
            let runner = Runners.create app
            runner.Start(arg)
            let adapter = ViewAdapters.create runner
            adapter.CreateView() |> unbox
        )
        this
