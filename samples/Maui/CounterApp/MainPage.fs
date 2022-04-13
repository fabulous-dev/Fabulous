namespace CounterApp

open Microsoft.Maui.Controls

type MainPage() as this =
    inherit ContentPage()
    
    do this.Content <-
        Label(
            Text = "Hello from MAUI, .NET 6.0 and F# 6.0!",
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.Center
        )