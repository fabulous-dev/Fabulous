namespace FabulousContacts

open System
open System.Threading.Tasks
open Fabulous
open Fabulous.XamarinForms
open FabulousContacts.Controls
open FabulousContacts.Style
open Xamarin.Forms
open Xamarin.Essentials

open type Fabulous.XamarinForms.View

module AboutPage =
    let fabulousContactsRepositoryUrl =
        "https://github.com/TimLariviere/FabulousContacts"

    let fsharpOrgUrl = "https://fsharp.org"

    let fabulousXamarinFormsUrl =
        "https://github.com/fsprojects/Fabulous/tree/master/Fabulous.XamarinForms"

    let freepikUrl =
        "https://www.flaticon.com/authors/freepik"

    let xamarinEssentialsUrl = "https://github.com/xamarin/Essentials"
    let authorBlogUrl = "https://timothelariviere.com"
    let authorGitHubUrl = "https://github.com/TimLariviere"
    let authorGitHubHandle = "TimLariviere"
    let authorTwitterUrl = "https://twitter.com/Tim_Lariviere"
    let authorTwitterHandle = "@Tim_Lariviere"
    let authorSlackUrl = "https://fsharp.org/guides/slack/"
    let authorSlackHandle = "@Timothé Larivière"

    type Msg = OpenBrowser of string

    let openBrowserCmd url =
        async {
            do!
                Browser.OpenAsync(Uri url, BrowserLaunchMode.SystemPreferred)
                |> Async.AwaitTask
        }
        |> Helpers.executeOnMainThread

    let init () = ()

    let update msg model =
        match msg with
        | OpenBrowser url -> model, Cmd.performAsync(openBrowserCmd url)

    let aboutFabulousContacts (openBrowser: string -> Msg) =
        VStack() {
            Label(Strings.AboutPage_AboutFabulousContacts_NameAndVersion)
                .font(attributes = FontAttributes.Bold)
                .centerHorizontal()

            Label(Strings.AboutPage_AboutFabulousContacts_DescriptionTitle)
                .font(attributes = FontAttributes.Bold)
                .margin(Thickness(0., 20., 0., 0.))

            Label(Strings.AboutPage_AboutFabulousContacts_Description)

            UnderlinedLabel(
                fabulousContactsRepositoryUrl
            )
                .gestureRecognizers() { TapGestureRecognizer(openBrowser fabulousContactsRepositoryUrl) }
        }

    let aboutFSharp (openBrowser: string -> Msg) =
        HStack(spacing = 30.) {
            Label(Strings.AboutPage_AboutFSharp_MadeWith)

            (VStack() {
                Image(Aspect.AspectFit, "fsharp.png")
                    .size(height = 50., width = 50.)

                Label(Strings.AboutPage_AboutFSharp_FSharp)
                    .centerTextHorizontal()
             })
                .gestureRecognizers() { TapGestureRecognizer(openBrowser fsharpOrgUrl) }

            (VStack() {
                Image(Aspect.AspectFit, "xamarin.png")
                    .size(height = 50., width = 50.)

                Label(Strings.AboutPage_AboutFSharp_FabulousXamarinForms)
                    .centerTextHorizontal()
             })
                .gestureRecognizers() { TapGestureRecognizer(openBrowser fabulousXamarinFormsUrl) }
        }

    let credits (openBrowser: string -> Msg) =
        VStack() {
            Label(Strings.AboutPage_Credits_Title)
                .font(attributes = FontAttributes.Bold)
                .margin(Thickness(0., 20., 0., 0.))

            UnderlinedLabel(
                Strings.AboutPage_Credits_Freepik
            )
                .gestureRecognizers() { TapGestureRecognizer(openBrowser freepikUrl) }

            UnderlinedLabel(
                Strings.AboutPage_Credits_XamarinEssentials
            )
                .gestureRecognizers() { TapGestureRecognizer(openBrowser xamarinEssentialsUrl) }
        }

    let aboutAuthor (openBrowser: string -> Msg) =
        VStack() {
            Label(Strings.AboutPage_AboutAuthor_Title)
                .font(attributes = FontAttributes.Bold)
                .margin(Thickness(0., 20., 0., 0.))

            Label(Strings.AboutPage_AboutAuthor_AuthorName)

            (HStack(spacing = 15.) {
                Image(Aspect.AspectFit, "blog.png")
                    .size(height = 35., width = 35.)

                UnderlinedLabel(authorBlogUrl).centerVertical()
             })
                .gestureRecognizers() { TapGestureRecognizer(openBrowser authorBlogUrl) }

            Label(Strings.AboutPage_AboutAuthor_ReachOut)
                .margin(Thickness(0., 10., 0., 0.))

            (HStack(spacing = 15.) {
                Image(Aspect.AspectFit, "github.png")
                    .size(height = 35., width = 35.)

                UnderlinedLabel(authorGitHubHandle)
                    .centerVertical()
             })
                .gestureRecognizers() { TapGestureRecognizer(openBrowser authorGitHubUrl) }

            (HStack(spacing = 15.) {
                (VStack() {
                    Image(Aspect.AspectFit, "twitter.png")
                        .size(height = 50., width = 50.)

                    Label(authorTwitterHandle).centerTextHorizontal()
                 })
                    .gestureRecognizers() { TapGestureRecognizer(openBrowser authorTwitterUrl) }

                (VStack() {
                    Image(Aspect.AspectFit, "slack.png")
                        .size(height = 50., width = 50.)

                    Label(authorSlackHandle).centerTextHorizontal()
                 })
                    .gestureRecognizers() { TapGestureRecognizer(openBrowser authorSlackUrl) }
             })
                .centerHorizontal()
                .margin(Thickness(0., 10., 0., 0.))
        }

    let view () =
        ContentPage(
            "About FabulousContacts",
            ScrollView(
                (VStack() {
                    ContentView(Image(Aspect.AspectFit, "icon.png"))
                        .backgroundColor(accentColor)
                        .size(height = 100., width = 100.)
                        .centerHorizontal()
                        .padding(15.)

                    aboutFabulousContacts OpenBrowser
                    aboutFSharp OpenBrowser
                    credits OpenBrowser
                    aboutAuthor OpenBrowser
                 })
                    .padding(Thickness(20., 10., 20., 20.))
            )
        )
