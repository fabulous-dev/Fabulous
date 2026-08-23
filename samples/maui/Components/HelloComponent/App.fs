namespace HelloComponent

open Fabulous.Maui
open Microsoft.Maui.Hosting

open type Fabulous.Maui.View

module App =
    let view () =
        Component() { Application(ContentPage() { Label("Hello Component").center() }) }

    let createMauiApp () =
        MauiApp.CreateBuilder().UseFabulousApp(view).Build()
