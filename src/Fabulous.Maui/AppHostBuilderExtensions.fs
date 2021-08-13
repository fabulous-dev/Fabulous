namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Hosting
open Microsoft.Extensions.DependencyInjection
open Fabulous

[<Extension>]
type AppHostBuilderExtensions () =
    [<Extension>]
    static member UseFabulousApp<'model, 'msg, 'view when 'view :> IWidget and 'view :> IApplicationWidget>(this: IAppHostBuilder, app: StatefulApplication<unit, 'model, 'msg, 'view>) =
        this.ConfigureServices(fun (collection: IServiceCollection) ->
            collection.AddSingleton<IApplication>(fun (x: IServiceProvider) ->
                let runner = Runners.createRunner app
                let adapter = ViewAdapter.createForRunner runner
                runner.Start()
                adapter.CreateView() |> unbox
            ) |> ignore
        )

    [<Extension>]
    static member UseFabulousAppWithArgs<'arg, 'model, 'msg, 'view when 'view :> IWidget and 'view :> IApplicationWidget>(this: IAppHostBuilder, app: StatefulApplication<'arg, 'model, 'msg, 'view>, arg: 'arg) =
        this.ConfigureServices(fun (collection: IServiceCollection) ->
            collection.AddSingleton<IApplication>(fun (x: IServiceProvider) ->
                let runner = Runners.createRunner app
                let adapter = ViewAdapter.createForRunner runner
                runner.Start arg
                adapter.CreateView() |> unbox
            ) |> ignore
        )
