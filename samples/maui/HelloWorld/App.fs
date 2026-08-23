namespace HelloWorld

open Fabulous.Maui

open type Fabulous.Maui.View
open Microsoft.Maui.Hosting

module App =
    let view () =
        Application(ContentPage(Label("Hello World").center()))

type MauiProgram =
    static member CreateMauiApp() =
        MauiApp.CreateBuilder().UseFabulousApp(App.view).Build()
