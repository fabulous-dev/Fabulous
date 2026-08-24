namespace HelloComponent

open Fabulous
open Fabulous.Maui
open Microsoft.Maui.Hosting

open type Fabulous.Maui.View

module App =
    let view () =
        Component("HelloComponent") { Application(ContentPage(Label("Hello Component").center())) }

    let createMauiApp () =
        MauiApp.CreateBuilder().UseFabulousApp(view).Build()
