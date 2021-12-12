namespace FabulousContacts

open Xamarin.Forms
open Fabulous
open Fabulous.XamarinForms
open type Fabulous.XamarinForms.View
open FabulousContacts.Models

module App =
    type Msg =
        | MainPageMsg of MainPage.Msg
        | DetailPageMsg of DetailPage.Msg
        | EditPageMsg of EditPage.Msg
        | AboutPageMsg of AboutPage.Msg
        | GoToDetail of Contact
        | GoToEdit of Contact option
        | GoToAbout
        | UpdateWhenContactAdded of Contact
        | UpdateWhenContactUpdated of Contact
        | UpdateWhenContactDeleted of Contact
        | NavigationPopped

    type Model = 
        { MainPageModel: MainPage.Model
          DetailPageModel: DetailPage.Model option
          EditPageModel: EditPage.Model option
          AboutPageModel: unit option

          // Workaround Cmd limitation -- Can not pop a page in page stack and send Cmd at the same time
          // Otherwise it would pop pages 2 times in NavigationPage
          WorkaroundNavPageBug: bool
          WorkaroundNavPageBugPendingCmd: Cmd<Msg> }

    let init dbPath () = 
        let mainModel, mainMsg = MainPage.init dbPath ()
        let initialModel =
            { MainPageModel = mainModel
              DetailPageModel = None
              EditPageModel = None
              AboutPageModel = None
              WorkaroundNavPageBug = false
              WorkaroundNavPageBugPendingCmd = Cmd.none }
        initialModel, (Cmd.map MainPageMsg mainMsg)

    let handleMainExternalMsg externalMsg =
        match externalMsg with
        | MainPage.ExternalMsg.NoOp                     -> Cmd.none
        | MainPage.ExternalMsg.NavigateToAbout          -> Cmd.ofMsg GoToAbout
        | MainPage.ExternalMsg.NavigateToNewContact     -> Cmd.ofMsg (GoToEdit None)
        | MainPage.ExternalMsg.NavigateToDetail contact -> Cmd.ofMsg (GoToDetail contact)

    let handleDetailPageExternalMsg externalMsg =
        match externalMsg with
        | DetailPage.ExternalMsg.NoOp                   -> Cmd.none
        | DetailPage.ExternalMsg.EditContact contact    -> Cmd.ofMsg (GoToEdit (Some contact))

    let handleEditPageExternalMsg externalMsg =
        match externalMsg with
        | EditPage.ExternalMsg.NoOp                              -> Cmd.none
        | EditPage.ExternalMsg.GoBackAfterContactAdded contact   -> Cmd.ofMsg (UpdateWhenContactAdded contact)
        | EditPage.ExternalMsg.GoBackAfterContactUpdated contact -> Cmd.ofMsg (UpdateWhenContactUpdated contact)
        | EditPage.ExternalMsg.GoBackAfterContactDeleted contact -> Cmd.ofMsg (UpdateWhenContactDeleted contact)

    let navigationMapper (model : Model) =
        let aboutModel = model.AboutPageModel
        let detailModel = model.DetailPageModel
        let editModel = model.EditPageModel
        match aboutModel, detailModel, editModel with
        | None, None, None -> model
        | Some _, None, None -> { model with AboutPageModel = None }
        | _, Some _, None -> { model with DetailPageModel = None }
        | _, _, Some _ -> { model with EditPageModel = None }

    let update dbPath msg model =
        match msg with
        | MainPageMsg msg ->
            let m, cmd, externalMsg = MainPage.update msg model.MainPageModel
            let cmd2 = handleMainExternalMsg externalMsg
            let batchCmd = Cmd.batch [ (Cmd.map MainPageMsg cmd); cmd2 ]
            { model with MainPageModel = m }, batchCmd

        | DetailPageMsg msg ->
            let m, cmd, externalMsg = DetailPage.update msg model.DetailPageModel.Value
            let cmd2 = handleDetailPageExternalMsg externalMsg
            let batchCmd = Cmd.batch [ (Cmd.map DetailPageMsg cmd); cmd2 ]
            { model with DetailPageModel = Some m }, batchCmd

        | EditPageMsg msg ->
            let m, cmd, externalMsg = EditPage.update dbPath msg model.EditPageModel.Value
            let cmd2 = handleEditPageExternalMsg externalMsg
            let batchCmd = Cmd.batch [ (Cmd.map EditPageMsg cmd); cmd2 ]
            { model with EditPageModel = Some m }, batchCmd
            
        | AboutPageMsg msg ->
            let m = AboutPage.update msg model.AboutPageModel.Value
            { model with AboutPageModel = Some m }, Cmd.none

        | NavigationPopped ->
            match model.WorkaroundNavPageBug with
            | true ->
                // Do not pop pages if already done manually
                let newModel =
                    { model with
                        WorkaroundNavPageBug = false
                        WorkaroundNavPageBugPendingCmd = Cmd.none }
                newModel, model.WorkaroundNavPageBugPendingCmd
            | false ->
                navigationMapper model, Cmd.none

        | GoToAbout ->
            { model with AboutPageModel = Some () }, Cmd.none

        | GoToDetail contact ->
            let m, cmd = DetailPage.init contact
            { model with DetailPageModel = Some m }, (Cmd.map DetailPageMsg cmd)

        | GoToEdit contact ->
            let m, cmd = EditPage.init contact
            { model with EditPageModel = Some m }, (Cmd.map EditPageMsg cmd)

        | UpdateWhenContactAdded contact ->
            let mainMsg = Cmd.ofMsg (MainPageMsg (MainPage.Msg.ContactAdded contact))
            { model with EditPageModel = None }, mainMsg

        | UpdateWhenContactUpdated contact ->
            let pendingCmds =
                Cmd.batch
                    [ Cmd.ofMsg (MainPageMsg (MainPage.Msg.ContactUpdated contact))
                      Cmd.ofMsg (DetailPageMsg (DetailPage.Msg.ContactUpdated contact)) ]
            let m =
                { model with
                    EditPageModel = None
                    WorkaroundNavPageBug = true
                    WorkaroundNavPageBugPendingCmd = pendingCmds }
            m, Cmd.none

        | UpdateWhenContactDeleted contact ->
            let mainMsg = Cmd.ofMsg (MainPageMsg (MainPage.Msg.ContactDeleted contact))
            let m = { model with DetailPageModel = None; EditPageModel = None }
            m, mainMsg

    let view (model: Model) =
        let mainPage = MainPage.view model.MainPageModel

        let detailPage =
            model.DetailPageModel
            |> Option.map DetailPage.view

        let editPage =
            model.EditPageModel
            |> Option.map EditPage.view
            
        let aboutPage =
            model.AboutPageModel
            |> Option.map AboutPage.view

        Application(
            (NavigationPage() {
                View.map MainPageMsg mainPage

                match aboutPage with
                | None -> ()
                | Some about -> View.map AboutPageMsg about

                match detailPage with
                | None -> ()
                | Some detail -> View.map DetailPageMsg detail
            
                match editPage with
                | None -> ()
                | Some edit -> View.map EditPageMsg edit
            })
                .barTextColor(Style.accentTextColor)
                .barBackgroundColor(Style.accentColor)
                .popped(NavigationPopped)
        )

    let program dbPath = Program.statefulApplicationWithCmd (init dbPath) (update dbPath) view