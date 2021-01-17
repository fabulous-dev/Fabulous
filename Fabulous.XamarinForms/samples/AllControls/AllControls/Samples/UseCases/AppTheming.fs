namespace AllControls.Samples.UseCases

open Xamarin.Forms
open Fabulous.XamarinForms
open AllControls.Helpers

module AppTheming =
    let pageBackgroundColor appTheme =
        match appTheme with
        | OSAppTheme.Dark -> Color.DarkGray
        | _ -> Color.White
        
    let pageForegroundColor appTheme =
        match appTheme with
        | OSAppTheme.Dark -> Color.White
        | _ -> Color.Black
    
    type Msg =
        | SetRequestedAppTheme of OSAppTheme
        | ToggleAppTheme
        
    type Model =
        { CurrentAppTheme: OSAppTheme }
    
    let init () =
        { CurrentAppTheme = Application.Current.RequestedTheme }
    
    let update msg model =
        match msg with
        | SetRequestedAppTheme newTheme ->
            { model with CurrentAppTheme = newTheme }
        | ToggleAppTheme ->
            let newTheme =
                match model.CurrentAppTheme with
                | OSAppTheme.Dark -> OSAppTheme.Light
                | _ -> OSAppTheme.Dark
            Application.Current.UserAppTheme <- newTheme
            { model with CurrentAppTheme = newTheme }
        
    let appThemeView model dispatch =        
        View.NonScrollingContentPage(
            title = "AppTheme sample",
            backgroundColor = pageBackgroundColor model.CurrentAppTheme,
            content =
                View.StackLayout(
                    spacing = 10.,
                    children = [
                        View.Label(
                            textColor = pageForegroundColor model.CurrentAppTheme,
                            text = sprintf "Current App Theme is %A" model.CurrentAppTheme
                        )
                        View.Button(
                            text = "Toggle App Theme",
                            command = fun _ -> dispatch ToggleAppTheme
                        )
                ])
        ) 
    
    let view model dispatch =
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android | Device.UWP ->
            appThemeView model dispatch

        | _ -> 
            View.ContentPage(
                View.StackLayout [
                    View.Label(text = "Your Platform does not support AppTheming")
                ]
            )
