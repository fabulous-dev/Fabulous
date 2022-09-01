namespace Fabulous.Maui

open Fabulous
open System.Runtime.CompilerServices
open Microsoft.Maui.Handlers
open Microsoft.Maui.Hosting
open Microsoft.Extensions.DependencyInjection.Extensions
open System

#if ANDROID
open Microsoft.Maui.Controls.Handlers.Compatibility
open Microsoft.Maui.Controls.Compatibility.Platform.Android
#endif
#if WINDOWS
open ResourcesProvider = Microsoft.Maui.Controls.Compatibility.Platform.UWP.WindowsResourcesProvider
open Microsoft.Maui.Controls.Compatibility.Platform.UWP
#endif
#if IOS || MACCATALYST
open Microsoft.Maui.Controls.Compatibility.Platform.iOS
open Microsoft.Maui.Controls.Handlers.Compatibility
#endif
#if TIZEN
open Microsoft.Maui.Controls.Handlers.Compatibility
open Microsoft.Maui.Controls.Compatibility.Platform.Tizen
#endif

[<Extension>]
type AppHostBuilderExtensions =
    [<Extension>]
    static member UseFabulousApp<'model, 'msg, 'marker when 'marker :> Fabulous.Maui.IApplication>(this: MauiAppBuilder, program: Program<unit, 'model, 'msg, 'marker>): MauiAppBuilder =
        this.Services.TryAddSingleton<Microsoft.Maui.IApplication>(fun (_serviceProvider: IServiceProvider) ->
            (Program.startApplication program) :> Microsoft.Maui.IApplication
        )
        this.SetupDefaults()
        this

    [<Extension>]
    static member UseFabulousApp<'arg, 'model, 'msg, 'marker when 'marker :> Fabulous.Maui.IApplication>(this: MauiAppBuilder, program: Program<'arg, 'model, 'msg, 'marker>, arg: 'arg): MauiAppBuilder =
        this.Services.TryAddSingleton<Microsoft.Maui.IApplication>(fun (_serviceProvider: IServiceProvider) ->
            (Program.startApplicationWithArgs arg program) :> Microsoft.Maui.IApplication
        )
        this.SetupDefaults()
        this
    
    [<Extension>]
    static member SetupDefaults(this: MauiAppBuilder) =
        this.ConfigureMauiHandlers(fun handlersCollection ->
            handlersCollection
                .AddHandler<CustomApplication, ApplicationHandler>()
                .AddHandler<CustomFlyoutPage, FlyoutViewHandler>()
                .AddHandler<CustomNavigationPage, NavigationViewHandler>()
                .AddHandler<CustomPicker, PickerHandler>()
                //.AddHandler<CustomEntryCell, Microsoft.Maui.Controls.Handlers.Compatibility.EntryCellRenderer>()
                //.AddHandler<FabulousListView, Microsoft.Maui.Controls.Handlers.Compatibility.ListViewRenderer>()
                .AddHandler<FabulousTimePicker, TimePickerHandler>()
                //.AddHandler<FabulousContentPage, ContentPageHandler>()
            |> ignore
        ) |> ignore