namespace AllControls.Samples.UseCases

open Xamarin.Forms
open Fabulous.XamarinForms
open AllControls.Helpers

module AppTheming =
    let pageBackgroundColor = AppThemeColor(Default = Color.White, Dark = Color.DarkGray)
    let pageForegroundColor = AppThemeColor(Default = Color.Black, Dark = Color.White)
    
    type Msg =
        | SetRequestedAppTheme of OSAppTheme
        
    type Model =
        { CurrentAppTheme: OSAppTheme }
    
    let init () =
        { CurrentAppTheme = Application.Current.RequestedTheme }
    
    let update msg model =
        match msg with
        | SetRequestedAppTheme newTheme ->
            { model with CurrentAppTheme = newTheme }
        
    let appThemeView model =        
        View.NonScrollingContentPage(
            title = "AppTheme sample",
            backgroundColor = pageBackgroundColor.Value,
            content =
                View.Label(
                    text = sprintf "Current App Theme is %A" model.CurrentAppTheme
                )
        ) 
    
    let view model _ =
        match Device.RuntimePlatform with
        | Device.iOS | Device.Android | Device.UWP ->
            appThemeView model

        | _ -> 
            View.ContentPage(
                View.StackLayout [
                    View.Label(text = "Your Platform does not support AppTheming")
                ]
            )
