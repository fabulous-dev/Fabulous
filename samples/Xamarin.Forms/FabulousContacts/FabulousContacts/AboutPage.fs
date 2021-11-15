namespace FabulousContacts

open System
open Fabulous
open Fabulous.XamarinForms
open FabulousContacts.Controls
open FabulousContacts.Style
open Xamarin.Forms
open Xamarin.Essentials
open type Fabulous.XamarinForms.View

module AboutPage =
    let fabulousContactsRepositoryUrl = "https://github.com/TimLariviere/FabulousContacts"
    let fsharpOrgUrl = "https://fsharp.org"
    let fabulousXamarinFormsUrl = "https://github.com/fsprojects/Fabulous/tree/master/Fabulous.XamarinForms"
    let freepikUrl = "https://www.flaticon.com/authors/freepik"
    let xamarinEssentialsUrl = "https://github.com/xamarin/Essentials"
    let authorBlogUrl = "https://timothelariviere.com"
    let authorGitHubUrl = "https://github.com/TimLariviere"
    let authorGitHubHandle = "TimLariviere"
    let authorTwitterUrl = "https://twitter.com/Tim_Lariviere"
    let authorTwitterHandle = "@Tim_Lariviere"
    let authorSlackUrl = "https://fsharp.org/guides/slack/"
    let authorSlackHandle = "@Timothé Larivière"
        
    let aboutFabulousContacts openBrowser =
        VerticalStackLayout([
            Label(Strings.AboutPage_AboutFabulousContacts_NameAndVersion)
                .font(attributes = FontAttributes.Bold)
                .centerHorizontally()
            
            Label(Strings.AboutPage_AboutFabulousContacts_DescriptionTitle)
                .font(attributes = FontAttributes.Bold)
                .margin(Thickness(0., 20., 0., 0.))
            
            Label(Strings.AboutPage_AboutFabulousContacts_Description)
            
            UnderlinedLabel(fabulousContactsRepositoryUrl)
                .gestureRecognizers([ TapGestureRecognizer(openBrowser fabulousContactsRepositoryUrl) ])
        ])
        
    let aboutFSharp openBrowser =
        HorizontalStackLayout(
            spacing = 30.,
            children = [
                Label(Strings.AboutPage_AboutFSharp_MadeWith)
            
                VerticalStackLayout([
                    FileImage("fsharp.png", Aspect.AspectFit)
                        .size(height = 50., width = 50.)

                    Label(Strings.AboutPage_AboutFSharp_FSharp)
                        .centerTextHorizontally()
                ]).gestureRecognizers([ TapGestureRecognizer(openBrowser fsharpOrgUrl) ])
            
                VerticalStackLayout([
                    FileImage("xamarin.png", Aspect.AspectFit)
                        .size(height = 50., width = 50.)

                    Label(Strings.AboutPage_AboutFSharp_FabulousXamarinForms)
                        .centerTextHorizontally()
                ]).gestureRecognizers([ TapGestureRecognizer(openBrowser fabulousXamarinFormsUrl) ])
            ]
        )

    let credits openBrowser =
        VerticalStackLayout([
            Label(Strings.AboutPage_Credits_Title)
                .font(attributes = FontAttributes.Bold)
                .margin(Thickness(0., 20., 0., 0.))
            
            UnderlinedLabel(Strings.AboutPage_Credits_Freepik)
                .gestureRecognizers([ TapGestureRecognizer(openBrowser freepikUrl) ])
            
            UnderlinedLabel(Strings.AboutPage_Credits_XamarinEssentials)
                .gestureRecognizers([ TapGestureRecognizer(openBrowser xamarinEssentialsUrl) ])
        ])
        
    let aboutAuthor openBrowser =
        VerticalStackLayout([
            Label(Strings.AboutPage_AboutAuthor_Title)
                .font(attributes = FontAttributes.Bold)
                .margin(Thickness(0., 20., 0., 0.))
            
            Label(Strings.AboutPage_AboutAuthor_AuthorName)
            
            HorizontalStackLayout(
                spacing = 15.,
                children = [
                    FileImage("blog.png", Aspect.AspectFit)
                        .size(height = 35., width = 35.)
                
                    UnderlinedLabel(authorBlogUrl)
                        .centerVertically()
                ]
            )
                .gestureRecognizers([ TapGestureRecognizer(openBrowser authorBlogUrl) ])
            
            Label(Strings.AboutPage_AboutAuthor_ReachOut)
                .margin(Thickness (0., 10., 0., 0.))
                        
            HorizontalStackLayout(
                spacing = 15.,
                children = [
                    FileImage("github.png", Aspect.AspectFit)
                        .size(height = 35., width = 35.)
                
                    UnderlinedLabel(authorGitHubHandle)
                        .centerVertically()
                ]
            ).gestureRecognizers([ TapGestureRecognizer(openBrowser authorGitHubUrl) ])
            
            HorizontalStackLayout(
                spacing = 15.,
                children = [
                    VerticalStackLayout([
                        FileImage("twitter.png", Aspect.AspectFit)
                            .size(height = 50., width = 50.)
                    
                        Label(authorTwitterHandle)
                            .centerTextHorizontally()
                    ]).gestureRecognizers([ TapGestureRecognizer(openBrowser authorTwitterUrl) ])
                
                    VerticalStackLayout([
                        FileImage("slack.png", Aspect.AspectFit)
                            .size(height = 50., width = 50.)
                    
                        Label(authorSlackHandle)
                            .centerTextHorizontally()
                    ])
                        .gestureRecognizers([ TapGestureRecognizer(openBrowser authorSlackUrl) ])
                ]
            )
                .centerHorizontally()
                .margin(Thickness(0., 10., 0., 0.))
        ]
    )

    type Msg =
        | OpenBrowser of string

    let init () = ()

    let update msg model =
        match msg with
        | OpenBrowser url -> Browser.OpenAsync(Uri url) |> ignore; ()
        
    let view model =
        ContentPage(
            ScrollView(
                VerticalStackLayout(
                    children = [
                        VerticalStackLayout([
                            FileImage("icon.png", Aspect.AspectFit)
                        ])
                            .backgroundColor(accentColor)
                            .size(height = 100., width = 100.)
                            .centerHorizontally()
                            .paddingLayout(15.)

                        aboutFabulousContacts OpenBrowser
                        aboutFSharp OpenBrowser
                        credits OpenBrowser
                        aboutAuthor OpenBrowser
                    ]
                )
                    .paddingLayout(Thickness(20., 10., 20., 20.))
            )
        )
