namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Extensions.DependencyInjection.Extensions;
open Fabulous

[<Extension>]
type AppHostBuilderExtensions () =
    [<Extension>]
    static member UseFabulousApp<'model, 'msg, 'view when 'view :> IWidget and 'view :> IApplicationWidget>(this: MauiAppBuilder, app: StatefulApplication<unit, 'model, 'msg, 'view>) =
        this.Services.TryAddSingleton<IApplication>(fun (x: IServiceProvider) ->
            let runner = Runners.createRunner app
            let adapter = ViewAdapter.createForRunner runner
            runner.Start()
            adapter.CreateView() |> unbox
        )
        this

    [<Extension>]
    static member UseFabulousAppWithArgs<'arg, 'model, 'msg, 'view when 'view :> IWidget and 'view :> IApplicationWidget>(this: MauiAppBuilder, app: StatefulApplication<'arg, 'model, 'msg, 'view>, arg: 'arg) =
        this.Services.TryAddSingleton<IApplication>(fun (x: IServiceProvider) ->
            let runner = Runners.createRunner app
            let adapter = ViewAdapter.createForRunner runner
            runner.Start arg
            adapter.CreateView() |> unbox
        )
        this
