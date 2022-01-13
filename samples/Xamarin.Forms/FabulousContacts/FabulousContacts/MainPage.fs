namespace FabulousContacts

open Fabulous
open Fabulous.XamarinForms
open FabulousContacts.Components
open FabulousContacts.Models
open FabulousContacts.Repository
open Xamarin.Forms.PlatformConfiguration
open Xamarin.Forms.PlatformConfiguration.AndroidSpecific

open type Fabulous.XamarinForms.View

module MainPage =
    // Declarations
    type Msg =
        | TabAllContactsMsg of ContactsListPage.Msg
        | TabFavContactsMsg of ContactsListPage.Msg
        | TabMapMsg of MapPage.Msg
        | ContactsLoaded of Contact list
        | ContactAdded of Contact
        | ContactUpdated of Contact
        | ContactDeleted of Contact
        | NoContactAboutTapped
        | NoContactAddNewContactTapped

    type ExternalMsg =
        | NoOp
        | NavigateToAbout
        | NavigateToNewContact
        | NavigateToDetail of Contact

    type Model =
        { Contacts: Contact list option
          TabAllContactsModel: ContactsListPage.Model
          TabFavContactsModel: ContactsListPage.Model
          TabMapModel: MapPage.Model }

    // Functions
    let loadAsync dbPath =
        async {
            let! contacts = loadAllContacts dbPath
            return ContactsLoaded contacts
        }

    // Lifecycle
    let init dbPath () =
        let modelAllContacts, msgAllContacts = ContactsListPage.init ()
        let modelFavContacts, msgFavContacts = ContactsListPage.init ()
        let modelMap, msgMap = MapPage.init ()

        let m =
            { Contacts = None
              TabAllContactsModel = modelAllContacts
              TabFavContactsModel = modelFavContacts
              TabMapModel = modelMap }

        let batchCmd =
            Cmd.batch [ Cmd.ofAsyncMsg (loadAsync dbPath)
                        Cmd.map TabAllContactsMsg msgAllContacts
                        Cmd.map TabFavContactsMsg msgFavContacts
                        Cmd.map TabMapMsg msgMap ]

        m, batchCmd

    let update msg model =
        let updateContactsList msg mapMsgFunc model =
            let m, cmd, externalMsg = ContactsListPage.update msg model

            let cmd2, externalMsg2 =
                match externalMsg with
                | ContactsListPage.ExternalMsg.NoOp -> Cmd.none, ExternalMsg.NoOp
                | ContactsListPage.ExternalMsg.NavigateToAbout -> Cmd.none, ExternalMsg.NavigateToAbout
                | ContactsListPage.ExternalMsg.NavigateToNewContact -> Cmd.none, ExternalMsg.NavigateToNewContact
                | ContactsListPage.ExternalMsg.NavigateToDetail contact ->
                    Cmd.none, (ExternalMsg.NavigateToDetail contact)

            m,
            Cmd.batch [ Cmd.map mapMsgFunc cmd
                        cmd2 ],
            externalMsg2

        let updateContacts model contacts =
            let allMsg =
                ContactsListPage.Msg.ContactsLoaded contacts

            let favMsg =
                ContactsListPage.Msg.ContactsLoaded(contacts |> List.filter (fun c -> c.IsFavorite))

            let mapMsg = MapPage.Msg.LoadPins contacts

            let batchCmd =
                Cmd.batch [ Cmd.ofMsg (TabAllContactsMsg allMsg)
                            Cmd.ofMsg (TabFavContactsMsg favMsg)
                            Cmd.ofMsg (TabMapMsg mapMsg) ]

            let m = { model with Contacts = Some contacts }
            m, batchCmd, ExternalMsg.NoOp

        match msg with
        | TabAllContactsMsg msg ->
            let m, cmd, externalMsg =
                updateContactsList msg TabAllContactsMsg model.TabAllContactsModel

            { model with TabAllContactsModel = m }, cmd, externalMsg

        | TabFavContactsMsg msg ->
            let m, cmd, externalMsg =
                updateContactsList msg TabFavContactsMsg model.TabFavContactsModel

            { model with TabFavContactsModel = m }, cmd, externalMsg

        | TabMapMsg msg ->
            let m, cmd = MapPage.update msg model.TabMapModel
            { model with TabMapModel = m }, (Cmd.map TabMapMsg cmd), ExternalMsg.NoOp

        | ContactsLoaded contacts -> updateContacts model contacts

        | ContactAdded contact ->
            let newContacts = contact :: model.Contacts.Value
            updateContacts model newContacts

        | ContactUpdated contact ->
            let newContacts =
                model.Contacts.Value
                |> List.map (fun c -> if c.Id = contact.Id then contact else c)

            updateContacts model newContacts

        | ContactDeleted contact ->
            let newContacts =
                model.Contacts.Value
                |> List.filter (fun c -> c <> contact)

            updateContacts model newContacts

        | NoContactAboutTapped -> model, Cmd.none, ExternalMsg.NavigateToAbout

        | NoContactAddNewContactTapped -> model, Cmd.none, ExternalMsg.NavigateToNewContact

    let loadingView title =
        TabbedPage(title) { ContentPage("Loading", VerticalStackLayout() { centralLabel Strings.MainPage_Loading }) }

    let emptyView title =
        TabbedPage(title) {
            ContentPage(
                "Empty",
                VerticalStackLayout() { centralLabel Strings.MainPage_NoContact }
            )
                .toolbarItems () {
                ToolbarItem(Strings.Common_About, NoContactAboutTapped)
                ToolbarItem("+", NoContactAddNewContactTapped)
            }
        }

    let regularView title model =
        let tabAllContacts =
            (ContactsListPage.view Strings.MainPage_TabAllTitle model.TabAllContactsModel)
                .fileIcon ("alltab.png")

        let tabFavContacts =
            (ContactsListPage.view Strings.MainPage_TabFavoritesTitle model.TabFavContactsModel)
                .fileIcon ("favoritetab.png")

        let tabMap = MapPage.view model.TabMapModel

        (TabbedPage(title) {
            View.map TabAllContactsMsg tabAllContacts
            View.map TabAllContactsMsg tabFavContacts
            View.map TabMapMsg tabMap
         })
            .androidToolbarPlacement (ToolbarPlacement.Bottom)

    let view model =
        let title = Strings.MainPage_Title

        match model.Contacts with
        | None -> loadingView title
        | Some [] -> emptyView title
        | Some _ -> regularView title model
