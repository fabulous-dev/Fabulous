namespace FabulousContacts

open System
open Fabulous
open Fabulous.XamarinForms
open FabulousContacts.Components
open FabulousContacts.Helpers
open FabulousContacts.Models
open FabulousContacts.Repository
open Plugin.Media
open Xamarin.Forms
open Plugin.Permissions

open type Fabulous.XamarinForms.View

module EditPage =
    // Declarations
    type Msg =
        // Fields update
        | UpdateFirstName of string
        | UpdateLastName of string
        | UpdateEmail of string
        | UpdatePhone of string
        | UpdateAddress of string
        | UpdateIsFavorite of bool
        | UpdatePicture
        | SetPicture of byte array option

        // Actions
        | SaveContact
        | DeleteContact of Contact

        // Events
        | ContactAdded of Contact
        | ContactUpdated of Contact
        | ContactDeleted of Contact

    type ExternalMsg =
        | NoOp
        | GoBackAfterContactAdded of Contact
        | GoBackAfterContactUpdated of Contact
        | GoBackAfterContactDeleted of Contact

    type Model =
        { Contact: Contact option
          FirstName: string
          LastName: string
          Email: string
          Phone: string
          Address: string
          IsFavorite: bool
          Picture: byte array option
          IsFirstNameValid: bool
          IsLastNameValid: bool }

    // Functions
    let tryDeleteAsync dbPath (contact: Contact) =
        async {
            let! shouldDelete =
                let title =
                    Strings.EditPage_DeleteContact contact.FirstName contact.LastName

                displayAlertWithConfirm(
                    title,
                    Strings.EditPage_DeleteContactConfirmation,
                    Strings.Common_Yes,
                    Strings.Common_No
                )

            if shouldDelete then
                do! deleteContact dbPath contact
                return Some(ContactDeleted contact)
            else
                return None
        }

    let doAsync<'a when 'a: (new: unit -> 'a) and 'a :> BasePermission> action =
        async {
            let! permissionGranted = askPermissionAsync<'a>()

            if permissionGranted then
                let! pictureOpt = action()

                match pictureOpt with
                | None -> return None
                | Some picture ->
                    let! bytes = readBytesAsync picture
                    return Some bytes
            else
                return None
        }

    let tryUpdatePictureAsync (previousValue: _ option) =
        Device.InvokeOnMainThreadAsync(funcTask = fun() ->
            task {
                let canTakePicture =
                    CrossMedia.Current.IsCameraAvailable
                    && CrossMedia.Current.IsTakePhotoSupported

                let canPickPicture = CrossMedia.Current.IsPickPhotoSupported

                let hasPreviousPicture = previousValue.IsSome

                let! action =
                    displayActionSheet(
                        None,
                        Some Strings.Common_Cancel,
                        (if hasPreviousPicture then
                             Some Strings.EditPage_PictureContextMenu_Remove
                         else
                             None),
                        Some [| if canTakePicture then
                                    yield Strings.EditPage_PictureContextMenu_TakePicture
                                if canPickPicture then
                                    yield Strings.EditPage_PictureContextMenu_ChooseFromGallery |]
                    )

                let setPicture value = Some(SetPicture value)

                match action with
                | s when s = Strings.EditPage_PictureContextMenu_Remove -> return setPicture None
                | s when s = Strings.EditPage_PictureContextMenu_TakePicture ->
                    let! bytes = doAsync<CameraPermission> takePictureAsync
                    return setPicture bytes
                | s when s = Strings.EditPage_PictureContextMenu_ChooseFromGallery ->
                    let! bytes = doAsync<PhotosPermission> pickPictureAsync
                    return setPicture bytes
                | _ -> return None
            }
        ) |> Async.AwaitTask

    let sayContactNotValidAsync () =
        Device.InvokeOnMainThreadAsync(funcTask = fun() ->
            task {
                do! displayAlert(
                    Strings.EditPage_InvalidContactTitle,
                    Strings.EditPage_InvalidContactDescription,
                    Strings.Common_OK
                )
            }
        ) |> Async.AwaitTask

    let createOrUpdateAsync dbPath contact =
        async {
            match contact.Id with
            | 0 ->
                let! insertedContact = insertContact dbPath contact
                return ContactAdded insertedContact
            | _ ->
                let! updatedContact = updateContact dbPath contact
                return ContactUpdated updatedContact
        }

    let trySaveAsync model dbPath =
        async {
            if not model.IsFirstNameValid
               || not model.IsLastNameValid then
                do!
                    Device.InvokeOnMainThreadAsync(funcTask = fun() ->
                        task {
                            do! sayContactNotValidAsync()
                        }
                    ) |> Async.AwaitTask
                
                return None
            else
                let id =
                    (match model.Contact with
                     | None -> 0
                     | Some c -> c.Id)

                let newContact =
                    { Id = id
                      FirstName = model.FirstName
                      LastName = model.LastName
                      Email = model.Email
                      Phone = model.Phone
                      Address = model.Address
                      IsFavorite = model.IsFavorite
                      Picture = model.Picture }

                let! msg = createOrUpdateAsync dbPath newContact
                return Some msg
        }

    // Validations
    let validateFirstName = not << String.IsNullOrWhiteSpace
    let validateLastName = not << String.IsNullOrWhiteSpace

    // Lifecycle
    let init (contact: Contact option) =
        let model =
            match contact with
            | Some c ->
                { Contact = Some c
                  FirstName = c.FirstName
                  LastName = c.LastName
                  Email = c.Email
                  Phone = c.Phone
                  Address = c.Address
                  IsFavorite = c.IsFavorite
                  Picture = c.Picture
                  IsFirstNameValid = true
                  IsLastNameValid = true }
            | None ->
                { Contact = None
                  FirstName = ""
                  LastName = ""
                  Email = ""
                  Phone = ""
                  Address = ""
                  IsFavorite = false
                  Picture = None
                  IsFirstNameValid = false
                  IsLastNameValid = false }

        model, Cmd.none

    let update dbPath msg (model: Model) =
        match msg with
        | UpdateFirstName v ->
            let m =
                { model with
                      FirstName = v
                      IsFirstNameValid = (validateFirstName v) }

            m, Cmd.none, ExternalMsg.NoOp

        | UpdateLastName v ->
            let m =
                { model with
                      LastName = v
                      IsLastNameValid = (validateLastName v) }

            m, Cmd.none, ExternalMsg.NoOp

        | UpdateEmail email -> { model with Email = email }, Cmd.none, ExternalMsg.NoOp

        | UpdatePhone phone -> { model with Phone = phone }, Cmd.none, ExternalMsg.NoOp

        | UpdateAddress address -> { model with Address = address }, Cmd.none, ExternalMsg.NoOp

        | UpdateIsFavorite isFavorite -> { model with IsFavorite = isFavorite }, Cmd.none, ExternalMsg.NoOp

        | UpdatePicture ->
            let cmd =
                Cmd.ofAsyncMsgOption(tryUpdatePictureAsync model.Picture)

            model, cmd, ExternalMsg.NoOp

        | SetPicture picture -> { model with Picture = picture }, Cmd.none, ExternalMsg.NoOp

        | SaveContact ->
            let cmd =
                Cmd.ofAsyncMsgOption(trySaveAsync model dbPath)

            model, cmd, ExternalMsg.NoOp

        | DeleteContact contact ->
            let cmd =
                Cmd.ofAsyncMsgOption(tryDeleteAsync dbPath contact)

            model, cmd, ExternalMsg.NoOp

        | ContactAdded contact -> model, Cmd.none, ExternalMsg.GoBackAfterContactAdded contact

        | ContactUpdated contact -> model, Cmd.none, ExternalMsg.GoBackAfterContactUpdated contact

        | ContactDeleted contact -> model, Cmd.none, ExternalMsg.GoBackAfterContactDeleted contact

    let view model =
        let title =
            let fullName =
                $"%s{model.FirstName} %s{model.LastName}".Trim()

            match model.Contact, fullName.Trim() with
            | None, "" -> Strings.EditPage_Title_NewContact
            | _, "" -> Strings.EditPage_Title_EditContactWithNoName
            | _, _ -> fullName

        ContentPage(
            title,
            ScrollView(
                (VStack() {
                    (Grid(coldefs = [ Absolute 100.; Star ], rowdefs = [ Absolute 50.; Absolute 50. ]) {
                        profilePictureButton model.Picture UpdatePicture

                        (formEntry
                            Strings.EditPage_FirstNameField_Label
                            model.FirstName
                            Keyboard.Text
                            model.IsFirstNameValid
                            UpdateFirstName)
                            .centerVertical()
                            .gridColumn(1)

                        (formEntry
                            Strings.EditPage_LastNameField_Label
                            model.LastName
                            Keyboard.Text
                            model.IsLastNameValid
                            UpdateLastName)
                            .centerVertical()
                            .gridColumn(1)
                            .gridRow(1)
                     })
                        .columnSpacing(10.)
                        .rowSpacing(0.)

                    favoriteField model.IsFavorite UpdateIsFavorite
                    formLabel Strings.EditPage_EmailField_Label
                    formEntry Strings.EditPage_EmailField_Placeholder model.Email Keyboard.Email true UpdateEmail
                    formLabel Strings.EditPage_PhoneField_Label
                    formEntry Strings.EditPage_PhoneField_Placeholder model.Phone Keyboard.Telephone true UpdatePhone
                    formLabel Strings.EditPage_AddressField_Label
                    formEditor model.Address UpdateAddress

                    match model.Contact with
                    | None -> ()
                    | Some x when x.Id = 0 -> ()
                    | Some contact -> destroyButton Strings.EditPage_DeleteButtonText (DeleteContact contact)
                 })
                    .padding(Thickness(20.))
            )
        )
            .toolbarItems() { toolbarButton Strings.EditPage_Toolbar_SaveContact SaveContact }
