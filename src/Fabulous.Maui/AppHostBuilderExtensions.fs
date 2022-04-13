namespace Fabulous.Maui

open Fabulous
open System.Runtime.CompilerServices
open Microsoft.Maui
open Microsoft.Maui.Hosting
open Microsoft.Extensions.DependencyInjection.Extensions
open System

[<Extension>]
type AppHostBuilderExtensions =
    [<Extension>]
    static member UseFabulousApp<'model, 'msg>(this: MauiAppBuilder, program: Program<unit, 'model, 'msg>): MauiAppBuilder =
        this.Services.TryAddSingleton<IApplication>(fun (_serviceProvider: IServiceProvider) ->
            Program.createApplication program ()
        )
        AppHostBuilderExtensions.SetupDefaults()
        this

    [<Extension>]
    static member UseFabulousApp<'arg, 'model, 'msg>(this: MauiAppBuilder, program: Program<'arg, 'model, 'msg>, arg: 'arg): MauiAppBuilder =
        this.Services.TryAddSingleton<IApplication>(fun (_serviceProvider: IServiceProvider) ->
            Program.createApplication program arg
        )
        AppHostBuilderExtensions.SetupDefaults()
        this
    
    [<Extension>]
    static member SetupDefaults() =
        ()