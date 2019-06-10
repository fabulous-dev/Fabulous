namespace Fabimals.Views

open Fabulous.Core
open Fabulous.DynamicViews
open Xamarin.Forms
open System

module AboutStyles =
    let primaryColor = Color.FromHex("#96d1ff")
    let lightTextColor = Color.FromHex("#999999")

module About =
    type Msg =
        | ShowFabulous
        | ShowXamarinForms
        | ShowOriginalFabimalsSample
        
    type CmdMsg = GoToUrl of string

    let goToUrl url =
        Device.OpenUri(new Uri(url))
        Cmd.none

    let mapCommands cmdMsg =
        match cmdMsg with
        | GoToUrl url -> goToUrl url

    let update msg =
        match msg with
        | ShowFabulous -> [GoToUrl "https://fsprojects.github.io/Fabulous"]
        | ShowXamarinForms -> [GoToUrl "https://docs.microsoft.com/en-us/xamarin/xamarin-forms"]
        | ShowOriginalFabimalsSample -> [GoToUrl "https://github.com/xamarin/xamarin-forms-samples/blob/master/UserInterface/Fabimals"]

    let view dispatch =
        dependsOn () (fun _ () ->
            View.ContentPage(
                title="About",
                content=View.ScrollView(
                    View.Grid(
                        rowdefs=["auto"; "*"],
                        children=[
                            View.StackLayout(
                                backgroundColor=AboutStyles.primaryColor,
                                verticalOptions=LayoutOptions.FillAndExpand,
                                horizontalOptions=LayoutOptions.Fill,
                                children=[
                                    View.StackLayout(
                                        orientation=StackOrientation.Horizontal,
                                        horizontalOptions=LayoutOptions.Center,
                                        verticalOptions=LayoutOptions.Center,
                                        children=[
                                            View.ContentView(
                                                padding=Thickness(0., 40.),
                                                verticalOptions=LayoutOptions.Fill,
                                                content=View.Image(
                                                    source="xamarin_logo.png",
                                                    verticalOptions=LayoutOptions.Center,
                                                    heightRequest=64.
                                                )
                                            )
                                        ]
                                    )
                                ]
                            )
                            View.ScrollView(
                                View.StackLayout(
                                    orientation=StackOrientation.Vertical,
                                    padding=Thickness(16., 40.),
                                    spacing=10.,
                                    children=[
                                        View.Label(
                                            fontSize=22,
                                            formattedText=View.FormattedString([
                                                View.Span(
                                                    text="Fabulous Animals",
                                                    fontAttributes=FontAttributes.Bold,
                                                    fontSize=22
                                                )
                                                View.Span " "
                                                View.Span(
                                                    text="1.0",
                                                    foregroundColor=AboutStyles.lightTextColor
                                                )
                                            ])
                                        )
                                        View.Label(
                                            formattedText=View.FormattedString([
                                                View.Span "This app is written in F# with "
                                                View.Span(
                                                    text="Fabulous",
                                                    fontAttributes=FontAttributes.Bold,
                                                    textColor=Color.Blue,
                                                    textDecorations=TextDecorations.Underline
                                                ).GestureRecognizers([
                                                    View.TapGestureRecognizer(
                                                        command=(fun() -> dispatch ShowFabulous)
                                                    )
                                                ])
                                                View.Span "."
                                            ])
                                        )
                                        View.Label(
                                            formattedText=View.FormattedString([
                                                View.Span "It is a port of the "
                                                View.Span(
                                                    text="existing sample Fabimals",
                                                    fontAttributes=FontAttributes.Bold,
                                                    textColor=Color.Blue,
                                                    textDecorations=TextDecorations.Underline
                                                ).GestureRecognizers([
                                                    View.TapGestureRecognizer(
                                                        command=(fun() -> dispatch ShowOriginalFabimalsSample)
                                                    )
                                                ])
                                                View.Span ", written C#/XAML with "
                                                View.Span(
                                                    text="Xamarin.Forms",
                                                    fontAttributes=FontAttributes.Bold,
                                                    textColor=Color.Blue,
                                                    textDecorations=TextDecorations.Underline
                                                ).GestureRecognizers([
                                                    View.TapGestureRecognizer(
                                                        command=(fun() -> dispatch ShowXamarinForms)
                                                    )
                                                ])
                                                View.Span "."
                                            ])
                                        )
                                        View.Button(
                                            margin=Thickness(0., 10., 0., 0.),
                                            text="Learn more",
                                            command=(fun() -> dispatch ShowFabulous),
                                            backgroundColor=AboutStyles.primaryColor,
                                            textColor=Color.White
                                        )
                                    ]
                                )
                            ).GridRow(1)
                        ]
                    )
                )
            )
        )