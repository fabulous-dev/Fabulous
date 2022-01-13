namespace FabulousContacts

open Fabulous
open Fabulous.XamarinForms
open FabulousContacts.Controls
open FabulousContacts.Helpers
open FabulousContacts.Style
open Xamarin.Forms

open type Fabulous.XamarinForms.View
open System.IO

module Components =
    let centralLabel text =
        Label(text)
            .centerHorizontal()
            .centerVertical (expand = true)

    let formLabel text =
        View
            .Label(text)
            .margin (Thickness(0., 20., 0., 5.))

    let formEntry placeholder text keyboard isValid onTextChanged =
        BorderedEntry(text, onTextChanged)
            .placeholder(placeholder)
            .keyboard(keyboard)
            .borderColor (
                if isValid then
                    Color.Default
                else
                    Color.Red
            )

    let formEditor text textChanged =
        Editor(text, textChanged).size (height = 100.)

    let destroyButton text onClicked =
        Button(text, onClicked)
            .backgroundColor(Color.Red)
            .textColor(Color.White)
            .margin(0., 20., 0., 0.)
            .alignEndVertical (expand = true)

    let toolbarButton text onClicked =
        ToolbarItem(text, onClicked)
            .order (ToolbarItemOrder.Primary)

    let groupView name =
        ViewCell(
            (VerticalStackLayout() {
                Label(name)
                    .textColor(accentTextColor)
                    .verticalOptions(LayoutOptions.FillAndExpand)
                    .verticalTextAlignment(TextAlignment.Center)
                    .margin (Thickness(20., 5.))
             })
                .backgroundColor (accentColor)
        )

    let cellView picture name address isFavorite =
        ViewCell(
            (HorizontalStackLayout(spacing = 10.) {
                (getImageValueOrDefault "addphoto.png" Aspect.AspectFit picture)
                    .margin(15., 0., 0., 0.)
                    .size (height = 50., width = 50.)

                (VerticalStackLayout(spacing = 5.) {
                    Label(name)
                        .font(18.)
                        .fillVertical(expand = true)
                        .centerTextVertical ()

                    Label(address)
                        .font(12.)
                        .textColor(Color.Gray)
                        .lineBreakMode (LineBreakMode.TailTruncation)
                 })
                    .fillHorizontal(expand = true)
                    .margin (0., 5., 0., 5.)

                Image("star.png", Aspect.AspectFit)
                    .isVisible(isFavorite)
                    .centerVertical()
                    .margin(0., 0., 15., 0.)
                    .size (height = 25., width = 25.)
             })
                .paddingLayout (Thickness 5.)
        )

    let detailActionButton (imagePath: string) onClicked =
        ImageButton(imagePath, onClicked, Aspect.AspectFit)
            .backgroundColor(accentColor)
            .size(height = 35.)
            .fillHorizontal (expand = true)

    let detailFieldTitle text =
        Label(text)
            .font(attributes = FontAttributes.Bold)
            .margin (0., 10., 0., 0.)

    let optionalLabel text =
        match text with
        | "" ->
            Label(Strings.Common_NotSpecified)
                .font (attributes = FontAttributes.Italic)
        | _ -> Label(text)

    let favoriteField isFavorite markAsFavorite =
        (HorizontalStackLayout() {
            Label(Strings.EditPage_MarkAsFavoriteField_Label)
                .centerVertical ()

            Switch(isFavorite, markAsFavorite)
                .alignEndHorizontal(expand = true)
                .centerVertical ()
         })
            .margin (0., 20., 0., 0.)

    let profilePictureButton (picture: byte [] option) updatePicture =
        match picture with
        | None ->
            ContentView(ImageButton("addphoto.png", updatePicture, Aspect.AspectFit))
                .backgroundColor(Color.White)
                .gridRowSpan (2)

        | Some picture ->
            ContentView(
                Image(new MemoryStream(picture), Aspect.AspectFill)
            )
                .gridRowSpan(
                2
            )
                .gestureRecognizers () { TapGestureRecognizer(updatePicture) }
