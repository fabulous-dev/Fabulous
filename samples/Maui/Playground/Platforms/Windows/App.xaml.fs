// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CounterApp.WinUI

open Microsoft.UI.Xaml
open Microsoft.Maui
open Microsoft.Maui.Controls.Xaml

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
type App() =
    inherit MauiWinUIApplication()

    do this.LoadFromXaml(typeof<App>) |> ignore

    override this.CreateMauiApp() = MauiProgram.CreateMauiApp()
