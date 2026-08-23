namespace HelloMediaElement

open System
open Fabulous
open Fabulous.Maui
open Fabulous.Maui.MediaElement
open Microsoft.Maui

open type Fabulous.Maui.View

module App =
    type Model = { LastEvent: string }

    type Msg =
        | MediaEnded
        | MediaOpened
        | PauseVideoRequested
        | PositionChanged of System.TimeSpan
        | SeekTo5MinsRequested
        | SeekTo5MinsCompleted
        | StartVideoRequested
        | VideoPaused
        | VideoStarted

    let init () = { LastEvent = "No events yet" }, []

    let controller = MediaElementController()

    let pauseVideoCmd () =
        async {
            do controller.Pause()
            return VideoPaused
        }
        |> Cmd.ofAsyncMsg

    let startVideoCmd () =
        async {
            do controller.Play()
            return VideoStarted
        }
        |> Cmd.ofAsyncMsg

    let seekTo3MinsCmd () =
        async {
            do controller.SeekTo(TimeSpan.FromMinutes(5))
            return SeekTo5MinsCompleted
        }
        |> Cmd.ofAsyncMsg

    let update msg model =
        match msg with
        | MediaEnded -> { model with LastEvent = "Media Ended" }, Cmd.none
        | MediaOpened ->
            { model with
                LastEvent = "Media Opened" },
            Cmd.none
        | PauseVideoRequested -> model, pauseVideoCmd()
        | PositionChanged t ->
            { model with
                LastEvent = "Position Changed to " + t.ToString("c") },
            Cmd.none
        | SeekTo5MinsRequested -> model, seekTo3MinsCmd()
        | SeekTo5MinsCompleted ->
            { model with
                LastEvent = "Seek To 5 mins Completed" },
            Cmd.none
        | StartVideoRequested -> model, startVideoCmd()
        | VideoPaused -> model, Cmd.none
        | VideoStarted -> model, Cmd.none

    let view model =
        Application(
            ContentPage(
                ScrollView(
                    (VStack(spacing = 25.) {

                        Label(".NET MAUI Media Element")
                            .semantics(SemanticHeadingLevel.Level1)
                            .font(size = 24.)
                            .centerTextHorizontal()

                        Label("Powered by Fabulous")
                            .semantics(SemanticHeadingLevel.Level2)
                            .font(size = 18.)
                            .centerTextHorizontal()

                        MediaElement()
                            .source("https://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4")
                            .height(300)
                            .width(400)
                            .shouldAutoPlay(true)
                            .onMediaOpened(MediaOpened)
                            .onMediaEnded(MediaEnded)
                            .onPositionChanged(fun x -> PositionChanged(x.Position))
                            .controller(controller)


                        Label("Latest Event: " + model.LastEvent)
                            .font(size = 14.)
                            .centerTextHorizontal()

                        Button("Start video", StartVideoRequested)
                        Button("Pause video", PauseVideoRequested)
                        Button("Seek to 5 mins", SeekTo5MinsRequested)
                    })
                        .padding(Thickness(30., 0., 30., 0.))
                        .centerVertical()
                )
            )
        )

    let program = Program.statefulWithCmd init update view
