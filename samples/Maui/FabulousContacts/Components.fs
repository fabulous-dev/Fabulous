namespace FabulousContacts

open Fabulous
open Fabulous.Maui
//open FabulousContacts.Controls
open FabulousContacts.Helpers
open FabulousContacts.Style
open Microsoft.Maui
open Microsoft.Maui.Graphics

open type Fabulous.Maui.View
open System.IO

module Components =
    let centralLabel text =
        Label(text)
            .centerHorizontal()
            .centerVertical( (* expand = true*) )

    let formLabel text = Label(text).margin(0., 20., 0., 5.)

    let formEntry placeholder text keyboard isValid onTextChanged =
        Entry(text, onTextChanged)
            .placeholder(placeholder)
            .keyboard(keyboard)
    // .borderColor(
    //     if isValid then
    //         Color.Default.ToFabColor()
    //     else
    //         Color.Red.ToFabColor()
    // )

    let formEditor text textChanged = Editor(text, textChanged).height(100.)

    let destroyButton text onClicked =
        TextButton(text, onClicked)
            .background(SolidPaint(Colors.Red))
            .textColor(Colors.White)
            .margin(0., 20., 0., 0.)
            .alignEndVertical( (* expand = true *) )

    // let toolbarButton text onClicked =
    //     ToolbarItem(text, onClicked)
    //         .order(ToolbarItemOrder.Primary)

    let groupView name =
        (VStack() {
            Label(name)
                .textColor(accentTextColor)
                .fillVertical( (* expand = true *) )
                .centerTextVertical()
                .margin(20., 5.)
         })
            .background(SolidPaint(accentColor))

    let cellView picture name address isFavorite =
        (HStack(spacing = 10.) {
            (getImageValueOrDefault "addphoto.png" Aspect.AspectFit picture)
                .margin(15., 0., 0., 0.)
                .size(height = 50., width = 50.)

            (VStack(spacing = 5.) {
                Label(name)
                    .font(Microsoft.Maui.Font.Default.WithSize(18.))
                    .fillVertical( (* expand = true *) )
                    .centerTextVertical()

                Label(address)
                    .font(Microsoft.Maui.Font.Default.WithSize(12.))
                    .textColor(Colors.Gray)
             //.lineBreakMode(LineBreakMode.TailTruncation) // NOTE: not implemented in Maui
             })
                .fillHorizontal( (* expand = true *) )
                .margin(0., 5., 0., 5.)

            Image(Aspect.AspectFit, "star.png")
                .visibility(
                    if isFavorite then
                        Visibility.Visible
                    else
                        Visibility.Collapsed
                )
                .centerVertical()
                .margin(0., 0., 15., 0.)
                .size(height = 25., width = 25.)
         })
            .padding(5.)

    let detailActionButton (imagePath: string) onClicked =
        ImageButton(Aspect.AspectFit, imagePath, onClicked)
            .background(SolidPaint(accentColor))
            .height(35.)
            .fillHorizontal( (* expand = true *) )

    let detailFieldTitle text =
        Label(text)
            .font(Microsoft.Maui.Font.Default.WithWeight(FontWeight.Bold))
            .margin(0., 10., 0., 0.)

    let optionalLabel text =
        match text with
        | "" ->
            Label(Strings.Common_NotSpecified)
                .font(Microsoft.Maui.Font.Default.WithSlant(FontSlant.Italic))
        | _ -> Label(text)

    let favoriteField isFavorite markAsFavorite =
        (HStack() {
            Label(Strings.EditPage_MarkAsFavoriteField_Label)
                .centerVertical()

            Switch(isFavorite, markAsFavorite)
                .alignEndHorizontal( (* expand = true *) )
                .centerVertical()
         })
            .margin(0., 20., 0., 0.)

    let profilePictureButton (picture: byte [] option) updatePicture =
        match picture with
        | None ->
            AnyView(
                ImageButton(Aspect.AspectFit, "addphoto.png", updatePicture)
                    .background(SolidPaint(Colors.White))
                    .gridRowSpan(2)
            )

        | Some picture ->
            AnyView(
                Image(Aspect.AspectFill, new MemoryStream(picture))
                    .gridRowSpan(2)
            )
//.gestureRecognizers() { TapGestureRecognizer(updatePicture) }
