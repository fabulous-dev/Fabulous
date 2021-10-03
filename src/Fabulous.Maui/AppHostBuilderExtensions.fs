namespace Fabulous.Maui

open System
open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Extensions.DependencyInjection.Extensions
open Fabulous
open Fabulous
open Fabulous.Maui.Widgets        

[<Extension>]
type AppHostBuilderExtensions () =
    [<Extension>]
    static member UseFabulousApp<'model, 'msg, 'view when 'view :> IApplicationWidget<'msg>>(this: MauiAppBuilder, app: StatefulApplication<unit, 'model, 'msg, 'view>) =
        this.Services.TryAddSingleton<IApplication>(fun (x: IServiceProvider) ->
            let runner = Runners.createRunner app
            runner.Start()
            let adapter = ViewAdapter.createForRunner runner
            adapter.CreateView() |> unbox
        )
        this

    [<Extension>]
    static member UseFabulousAppWithArgs<'arg, 'model, 'msg, 'view when 'view :> IApplicationWidget<'msg>>(this: MauiAppBuilder, app: StatefulApplication<'arg, 'model, 'msg, 'view>, arg: 'arg) =
        this.Services.TryAddSingleton<IApplication>(fun (x: IServiceProvider) ->
            let runner = Runners.createRunner app
            runner.Start arg
            let adapter = ViewAdapter.createForRunner runner
            adapter.CreateView() |> unbox
        )
        this
