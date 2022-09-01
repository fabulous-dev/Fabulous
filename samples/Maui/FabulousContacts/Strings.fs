namespace FabulousContacts

[<RequireQualifiedAccess>]
module Strings =
    let Common_NotSpecified = "Not specified"
    let Common_About = "About"
    let Common_OK = "OK"
    let Common_Yes = "Yes"
    let Common_No = "No"
    let Common_Cancel = "Cancel"
    let Common_Error = "An error has occurred"
    let MapPage_MapLoadFailed = "Can't load map"
    let MapPage_Title = "Map"
    let MapPage_Loading = "Loading map..."
    let MainPage_Loading = "Loading..."
    let MainPage_NoContact = "No contact"
    let MainPage_Title = "FabulousContacts"
    let MainPage_TabAllTitle = "All"
    let MainPage_TabFavoritesTitle = "Favorites"

    let DetailPage_CapabilityNotSupported capability =
        $"%s{capability} is not supported on this device"

    let DetailPage_DialNumberFailed = "Can't dial number"
    let DetailPage_ComposeSmsFailed = "Can't send SMS"
    let DetailPage_ComposeEmailFailed = "Can't send email"
    let DetailPage_Toolbar_EditContact = "Edit"
    let EditPage_DeleteContact firstName lastName = $"Delete %s{firstName} %s{lastName}"

    let EditPage_DeleteContactConfirmation =
        "This action is definitive. Are you sure?"

    let EditPage_InvalidContactTitle = "Invalid contact"
    let EditPage_InvalidContactDescription = "Please fill all mandatory fields"
    let EditPage_Title_NewContact = "New Contact"
    let EditPage_Title_EditContactWithNoName = "Add Name"
    let EditPage_Toolbar_SaveContact = "Save"
    let EditPage_FirstNameField_Label = "First name"
    let EditPage_LastNameField_Label = "Last name"
    let EditPage_MarkAsFavoriteField_Label = "Mark as Favorite"
    let EditPage_EmailField_Label = "Email (optional)"
    let EditPage_EmailField_Placeholder = "Email"
    let EditPage_PhoneField_Label = "Phone (optional)"
    let EditPage_PhoneField_Placeholder = "Phone"
    let EditPage_AddressField_Label = "Address"
    let EditPage_DeleteButtonText = "Delete"
    let EditPage_PictureContextMenu_Remove = "Remove"
    let EditPage_PictureContextMenu_TakePicture = "Take a picture"
    let EditPage_PictureContextMenu_ChooseFromGallery = "Choose from the gallery"
    let AboutPage_AboutFabulousContacts_NameAndVersion = "FabulousContacts v1.0"
    let AboutPage_AboutFabulousContacts_DescriptionTitle = "Description"

    let AboutPage_AboutFabulousContacts_Description =
        "FabulousContacts is an open-source sample Contacts app"

    let AboutPage_AboutFSharp_MadeWith = "Made with"
    let AboutPage_AboutFSharp_FSharp = "F#"
    let AboutPage_AboutFSharp_FabulousXamarinForms = "Fabulous for Xamarin.Forms"
    let AboutPage_Credits_Title = "Credits"
    let AboutPage_Credits_Freepik = "Some icons by Freepik"
    let AboutPage_Credits_XamarinEssentials = "Xamarin.Essentials"
    let AboutPage_AboutAuthor_Title = "Author"
    let AboutPage_AboutAuthor_AuthorName = "Timothé Larivière"

    let AboutPage_AboutAuthor_ReachOut =
        "If you want to know more about this app or just want to reach me:"