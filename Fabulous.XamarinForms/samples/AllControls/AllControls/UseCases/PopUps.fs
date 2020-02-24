namespace AllControls.UseCases

open AllControls.Helpers

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module PopUps =
    type Msg =
        | ShowPopup
        
    type CmdMsg = Nothing
    type Model = Nothing
    
    let mapToCmd _ = Cmd.none
    
    let init () = Nothing
    
    let update msg model =
        match msg with
        | ShowPopup ->
            Application.Current.MainPage.DisplayAlert("Clicked", "You clicked the button", "OK") |> ignore
            model, Cmd.none
            
    let view _ dispatch =
        dependsOn () (fun _ _ ->
            View.NonScrollingContentPage(
                title = "Pop-ups sample",
                content = View.StackLayout([
                    View.Button(
                       text = "Show popup",
                       command = fun () -> dispatch ShowPopup
                    )
                ])
            )
        )