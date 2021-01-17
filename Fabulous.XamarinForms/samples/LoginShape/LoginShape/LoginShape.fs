// Copyright 2018-2019 Fabulous contributors. See LICENSE.md for license.
namespace LoginShape

open System
open Fabulous
open Fabulous.XamarinForms
open Xamarin.Forms

module App =
    let appColor appTheme dark light =
        match appTheme with
        | OSAppTheme.Dark -> Color.FromHex(dark)
        | _ -> Color.FromHex(light)

    let labelTextColor appTheme =
        match appTheme with
        | OSAppTheme.Dark -> Color.FromHex("#eeeeee")
        | _ -> Color.FromHex("#222222")

    let entryTextColor appTheme =
        match appTheme with
        | OSAppTheme.Dark -> Color.FromHex("#eeeeee")
        | _ -> Color.FromHex("#222222")

    let entryBackgroundColor appTheme =
        match appTheme with
        | OSAppTheme.Dark -> Color.FromHex("#1d1d1d")
        | _ -> Color.FromHex("#F1F1F1")

    let pathFillColor appTheme =
        match appTheme with
        | OSAppTheme.Dark -> Color.FromHex("#333333")
        | _ -> Color.FromHex("#FFFFFF")

    type Model =
        { CurrentAppTheme: OSAppTheme }

    type Msg =
        | SetRequestedAppTheme of OSAppTheme

    let init () = { CurrentAppTheme = Application.Current.RequestedTheme }

    let update msg model =
        match msg with
        | SetRequestedAppTheme appTheme -> { model with CurrentAppTheme = appTheme }

    let view (model: Model) dispatch =
        View.ContentPage(
            backgroundColor = appColor model.CurrentAppTheme "#222222" "#f1f1f1",
            content =
                View.Grid(
                    coldefs = [ Star; Absolute 279.; Star ],
                    rowdefs = [ Star; Absolute 350.; Star ],
                    children = [
                        View.Image(
                            horizontalOptions = LayoutOptions.Center,
                            verticalOptions = LayoutOptions.End,
                            width = 150.,
                            height = 150.,
                            margin = Thickness(0., 0., 0., 8.),
                            source = Image.fromPath "https://devblogs.microsoft.com/xamarin/wp-content/uploads/sites/44/2019/03/Screen-Shot-2017-01-03-at-3.35.53-PM-150x150.png",
                            clip = View.EllipseGeometry(
                                center = Point(75., 75.),
                                radiusX = 75.,
                                radiusY = 75.
                            )
                        ).Column(1)

                        View.Grid(
                            rowdefs = [ Absolute 34.; Absolute 40.; Absolute 16.; Absolute 44.; Absolute 20.; Absolute 44.; Star ],
                            coldefs = [ Absolute 22.; Star; Star; Absolute 22. ],
                            children = [
                                View.Path(
                                    horizontalOptions = LayoutOptions.Fill,
                                    verticalOptions = LayoutOptions.Fill,
                                    fill = View.SolidColorBrush(pathFillColor model.CurrentAppTheme),
                                    data = Content.fromString "M251,0 C266.463973,-2.84068575e-15 279,12.536027 279,28 L279,276 C279,291.463973 266.463973,304 251,304 L214.607,304 L214.629319,304.009394 L202.570739,304.356889 C196.091582,304.5436 190.154631,308.020457 186.821897,313.579883 L186.821897,313.579883 L183.402481,319.283905 C177.100406,337.175023 160.04792,350 140,350 C119.890172,350 102.794306,337.095694 96.5412691,319.115947 L96.5273695,319.126964 L92.8752676,313.28194 C89.5084023,307.893423 83.6708508,304.544546 77.3197008,304.358047 L65.133,304 L28,304 C12.536027,304 1.8937905e-15,291.463973 0,276 L0,28 C-1.8937905e-15,12.536027 12.536027,2.84068575e-15 28,0 L251,0 Z"
                                ).RowSpan(7).ColumnSpan(4)

                                View.Label(
                                    horizontalTextAlignment = TextAlignment.Center,
                                    fontFamily = "DINBold",
                                    text = "LOGIN",
                                    fontSize = FontSize.fromValue 22.,
                                    textColor = labelTextColor model.CurrentAppTheme
                                ).Row(1).Column(1)

                                View.Label(
                                    fontFamily = "DINBold",
                                    horizontalTextAlignment = TextAlignment.Center,
                                    text = "REGISTER",
                                    opacity = 0.2,
                                    fontSize = FontSize.fromValue 22.,
                                    textColor = labelTextColor model.CurrentAppTheme
                                ).Row(1).Column(2)

                                View.Label(
                                    text = "Username",
                                    fontSize = FontSize.fromValue 16.,
                                    textColor = labelTextColor model.CurrentAppTheme
                                ).Row(2).Column(1).ColumnSpan(2)

                                View.Entry(
                                    placeholder = "Enter username",
                                    text = "daortin@microsoft.com",
                                    textColor = entryTextColor model.CurrentAppTheme,
                                    backgroundColor = entryBackgroundColor model.CurrentAppTheme
                                ).Row(3).Column(1).ColumnSpan(2)

                                View.Label(
                                    margin = Thickness(0., 4., 0., 0.),
                                    text = "Password",
                                    fontSize = FontSize.fromValue 16.,
                                    textColor = labelTextColor model.CurrentAppTheme
                                ).Row(4).Column(1).ColumnSpan(2)

                                View.Entry(
                                    placeholder = "Enter password",
                                    textColor = entryTextColor model.CurrentAppTheme,
                                    backgroundColor = entryBackgroundColor model.CurrentAppTheme
                                ).Row(5).Column(1).ColumnSpan(2)

                                View.Grid(
                                    coldefs = [ Absolute 64. ],
                                    rowdefs = [ Absolute 64. ],
                                    horizontalOptions = LayoutOptions.Center,
                                    verticalOptions = LayoutOptions.End,
                                    margin = Thickness(0., 0., 0., 13.),
                                    children = [
                                        View.Ellipse(
                                            fill = View.SolidColorBrush(Color.FromHex("#222222")),
                                            width = 64.,
                                            height = 64.
                                        )

                                        View.Path(
                                            fill = View.SolidColorBrush(Color.White),
                                            verticalOptions = LayoutOptions.Center,
                                            horizontalOptions = LayoutOptions.Center,
                                            rotation = 90.,
                                            data = Content.fromString "M15.6099294,11.0552456 L12.3765961,7.82357897 C12.2574176,7.70409826 12.0779382,7.66830385 11.9220434,7.73292537 C11.7661485,7.7975469 11.6646275,7.94982156 11.6649294,8.11857897 L11.6649294,21.2502456 C11.6649294,22.4008389 10.7321893,23.333579 9.58159609,23.333579 C8.43100286,23.333579 7.49826276,22.4008389 7.49826276,21.2502456 L7.49826276,8.11857897 C7.49789351,7.95055217 7.39663523,7.79918973 7.24146862,7.73471909 C7.08630201,7.67024846 6.90759527,7.70528741 6.78826276,7.82357897 L3.55492943,11.0552456 C2.74169013,11.8684849 1.42316875,11.8684849 0.609929471,11.0552456 C-0.203309806,10.2420063 -0.203309826,8.92348493 0.609929427,8.11024563 L8.10992943,0.610245632 C8.50036143,0.219527336 9.03007272,0 9.58242943,0 C10.1347861,0 10.6644974,0.219527336 11.0549294,0.610245632 L18.5549294,8.11024563 C19.3681687,8.92348493 19.3681687,10.2420063 18.5549294,11.0552456 C17.7416901,11.8684849 16.4231687,11.8684849 15.6099294,11.0552456 L15.6099294,11.0552456 Z"
                                        )
                                    ]
                                ).Column(1).ColumnSpan(2).Row(6)
                            ]
                        ).Column(1).Row(1)
                    ]
                )
        )

    // Note, this declaration is needed if you enable LiveUpdate
    let program = XamarinFormsProgram.mkSimple init update view

type App () as app =
    inherit Application ()

    let runner =
        App.program
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> XamarinFormsProgram.run app

    let onRequestedThemeChanged = EventHandler<AppThemeChangedEventArgs>(fun _ args ->
        runner.Dispatch (App.Msg.SetRequestedAppTheme args.RequestedTheme)
    )

    override this.OnStart() =
        Application.Current.RequestedThemeChanged.AddHandler(onRequestedThemeChanged)
