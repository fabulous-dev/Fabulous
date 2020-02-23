namespace AllControls

open Router

open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module App =
    type Msg =
        | PageMsg of PageMsg
        | NavigateToRequested of Pages
        | LowMemoryWarningReceived
        
    type CmdMsg =
        | RouterCmdMsg of RouterCmdMsg
    
    type Model =
        { State: PageModel }
        
    let displayMemoryWarningMessage() =
        Application.Current.MainPage.DisplayAlert("Low memory!", "Cleaning up data...", "OK") |> ignore
        
    let mapToCmd (cmdMsg: CmdMsg) =
        match cmdMsg with
        | RouterCmdMsg (NavigateTo page) -> Cmd.ofMsg (NavigateToRequested page)
                
    let init () : Model * CmdMsg list =
        { State = HomeModel (Home.init()) }, []
        
    let update msg model =
        match msg with
        | PageMsg pageMsg ->
            let newPageModel, appCmdMsgs = updateForPage pageMsg model.State
            { model with State = newPageModel }, (appCmdMsgs |> List.map RouterCmdMsg)
        | NavigateToRequested page ->
            { model with State = initForPage page }, []
        | LowMemoryWarningReceived ->
            displayMemoryWarningMessage()
            model, []
            
    let view model dispatch =
        View.NavigationPage(
            pages = [
                viewForPage model.State (PageMsg >> dispatch)
            ]
        )
    
type App () as app = 
    inherit Application ()
    do app.Resources.Add(Xamarin.Forms.StyleSheets.StyleSheet.FromAssemblyResource(System.Reflection.Assembly.GetExecutingAssembly(), "AllControls.styles.css"))
    
    let runner = 
        Program.mkProgramWithCmdMsg App.init App.update App.view App.mapToCmd
        |> Program.withConsoleTrace
        |> XamarinFormsProgram.run app

    member __.Program = runner