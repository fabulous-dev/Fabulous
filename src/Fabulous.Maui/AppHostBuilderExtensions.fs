namespace Fabulous.Maui

open Fabulous
open System.Runtime.CompilerServices
open Microsoft.Maui.Hosting
open Microsoft.Extensions.DependencyInjection.Extensions
open System

[<Extension>]
type AppHostBuilderExtensions =
    [<Extension>]
    static member UseFabulousApp<'model, 'msg, 'marker when 'marker :> Fabulous.Maui.IApplication>(this: MauiAppBuilder, program: Program<unit, 'model, 'msg, 'marker>): MauiAppBuilder =
        this.Services.TryAddSingleton<Microsoft.Maui.IApplication>(fun (_serviceProvider: IServiceProvider) ->
            (Program.startApplication program) :> Microsoft.Maui.IApplication
        )
        AppHostBuilderExtensions.SetupDefaults()
        this

    [<Extension>]
    static member UseFabulousApp<'arg, 'model, 'msg, 'marker when 'marker :> Fabulous.Maui.IApplication>(this: MauiAppBuilder, program: Program<'arg, 'model, 'msg, 'marker>, arg: 'arg): MauiAppBuilder =
        this.Services.TryAddSingleton<Microsoft.Maui.IApplication>(fun (_serviceProvider: IServiceProvider) ->
            (Program.startApplicationWithArgs arg program) :> Microsoft.Maui.IApplication
        )
        AppHostBuilderExtensions.SetupDefaults()
        this
    
    [<Extension>]
    static member SetupDefaults() =
        ()