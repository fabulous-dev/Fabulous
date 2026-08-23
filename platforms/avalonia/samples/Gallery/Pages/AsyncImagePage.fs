namespace Gallery

open System
open System.Diagnostics
open Avalonia.Animation
open Avalonia.Interactivity
open Avalonia.Labs.Controls
open Avalonia.Layout
open Fabulous

open Fabulous.Avalonia
open type Fabulous.Avalonia.View


module AsyncImagePage =

    type Model = { IsOpen: bool; Error: string option }

    type Msg =
        | Opened of RoutedEventArgs
        | Failed of AsyncImage.AsyncImageFailedEventArgs

    let private configureCaching () =
        let cache = Avalonia.Labs.Controls.Cache.CacheOptions()
        // will be used as the base cache folder. images caches are stored in the nested folder "ImageCache"
        cache.BaseCachePath <- System.IO.Path.Combine(Environment.CurrentDirectory, "cache")
        Avalonia.Labs.Controls.Cache.CacheOptions.SetDefault(cache)

    let init () =
        { IsOpen = false; Error = None }, Cmd.ofEffect(fun _ -> configureCaching())

    let update msg model =
        match msg with
        | Opened args -> { model with IsOpen = args.Handled }, Cmd.none
        | Failed args ->
            let error = args.ErrorMessage

            { model with
                IsOpen = false
                Error = Some error },
            Cmd.none

    let program =
        Program.statefulWithCmd init update
        |> Program.withTrace(fun (format, args) -> Debug.WriteLine(format, box args))
        |> Program.withExceptionHandler(fun ex ->
#if DEBUG
            printfn $"Exception: %s{ex.ToString()}"
            false
#else
            true
#endif
        )

    let view () =
        Component("AsyncImagePage") {
            let! model = Context.Mvu program

            VStack() {

                TextBlock("AsyncImage is a control that allows you to load images asynchronously.")
                    .center()
                    .margin(10.0)

                TextBlock("It supports placeholders, image transitions, and caching.")
                    .center()
                    .margin(10.0)

                HWrap() {
                    AsyncImage(ImageSource.fromString("avares://Gallery/Assets/Icons/fsharp-icon.png"))
                    |> _.width(80.0)
                    |> _.height(80.0)
                    |> _.margin(5.0)

                    AsyncImage("https://github.githubassets.com/images/modules/logos_page/GitHub-Mark.png")
                    |> _.placeholderSource("avares://Gallery/Assets/Icons/fsharp-icon.png")
                    |> _.imageTransition(Rotate3DTransition(TimeSpan.FromSeconds(2.), PageSlide.SlideAxis.Horizontal))
                    |> _.onOpened(Opened)
                    |> _.onFailed(Failed)
                    |> _.width(80.0)
                    |> _.height(80.0)
                    |> _.margin(5.0)

                    AsyncImage("https://img-prod-cms-rt-microsoft-com.akamaized.net/cms/api/am/imageFileData/RWCZER")
                    |> _.placeholderSource("avares://Gallery/Assets/Icons/fsharp-icon.png")
                    |> _.isCacheEnabled(true)
                    |> _.width(80.0)
                    |> _.height(80.0)
                    |> _.margin(5.0)

                    AsyncImage("https://cdn.cms-twdigitalassets.com/content/dam/about-twitter/en/brand-toolkit/brand-download-img-1.jpg.twimg.2560.jpg")
                    |> _.placeholderSource("avares://Gallery/Assets/Icons/fsharp-icon.png")
                    |> _.isCacheEnabled(true)
                    |> _.width(80.0)
                    |> _.height(80.0)
                    |> _.margin(5.0)

                }
                |> _.verticalAlignment(VerticalAlignment.Stretch)
                |> _.horizontalAlignment(HorizontalAlignment.Center)
            }
        }
