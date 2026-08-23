namespace GitHubClient

open System.Diagnostics
open Avalonia.Markup.Xaml.Styling
open Fabulous
open Fabulous.Avalonia
open System.Net
open System
open System.Net.Http

open System.Text.Json

open type Fabulous.Avalonia.View

module Models =
    type RemoteData<'T> =
        | NotAsked
        | Loading
        | Content of 'T
        | Failure of string

    type User =
        { login: string
          avatar_url: string
          name: string option
          location: string option
          bio: string option
          public_repos: int
          public_gists: int
          html_url: string
          following: int
          followers: int
          created_at: DateTime }

open Models

module URlConstants =

    [<Literal>]
    let githubBaseUrl = "https://api.github.com/users/"

module GitHubService =
    let private fetchWitHeader (urlString: string) =
        let client = new HttpClient()
        client.DefaultRequestHeaders.Add("User-Agent", "F# App")
        client.DefaultRequestHeaders.Add("Accept", "application/vnd.github.v3+json")
        client.GetAsync(urlString)

    let getUserInfo (userName: string) =
        let urlString = $"{URlConstants.githubBaseUrl}%s{userName}"

        task {
            use! response = fetchWitHeader urlString
            response.EnsureSuccessStatusCode |> ignore

            let! followers = response.Content.ReadAsStringAsync()
            let deserialized = JsonSerializer.Deserialize<User>(followers)

            return
                match response.StatusCode with
                | HttpStatusCode.OK -> Ok deserialized
                | _ -> Error "User not found!"
        }

module App =
    type Msg =
        | UserNameChanged of string
        | SearchClicked
        | UserInfoLoaded of User
        | UserInfoNotFound of string
        | LoadingProgress of float

    type Model =
        { UserName: string
          UserInfo: RemoteData<User> }

    let init () =
        { UserName = ""
          UserInfo = RemoteData.NotAsked },
        Cmd.none

    let getUserInfo userName =
        task {
            let! response = GitHubService.getUserInfo userName

            match response with
            | Ok user -> return UserInfoLoaded user
            | Error error -> return UserInfoNotFound error
        }

    let update msg model =
        match msg with
        | UserNameChanged userName -> { model with UserName = userName }, Cmd.none

        | SearchClicked -> { model with UserInfo = Loading }, Cmd.OfTask.msg(getUserInfo model.UserName)

        | UserInfoLoaded user -> { model with UserInfo = Content(user) }, Cmd.none

        | UserInfoNotFound _ ->
            { model with
                UserInfo = Failure("User not found!") },
            Cmd.none

        | LoadingProgress _ -> model, Cmd.none

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

    let content () =
        Component("GitHubClient") {
            let! model = Context.Mvu program

            Grid() {
                VStack() {
                    match model.UserInfo with
                    | NotAsked -> ()
                    | Loading -> ProgressBar(0., 1., 0.5, LoadingProgress)
                    | Content user ->
                        (VStack() {
                            AsyncImage(user.avatar_url)
                                .placeholderSource("avares://GitHubClient/Assets/github-icon.png")
                                .size(100., 100.)

                            TextBlock(user.login)

                            if user.name.IsSome then
                                TextBlock(user.name.Value)

                            if user.location.IsSome then
                                TextBlock(user.location.Value)

                                if user.bio.IsSome then
                                    TextBlock(user.bio.Value)

                                TextBlock($"Public repos: {user.public_repos}")

                                TextBlock($"Public gists: {user.public_gists}")

                                TextBlock($"Followers: {user.followers}")

                                TextBlock($"Following: {user.following}")

                                TextBlock($"Created at: {user.created_at}")

                                TextBlock($"Profile: {user.html_url}")
                        })
                            .centerHorizontal()
                    | Failure s -> TextBlock(s)

                    TextBox(model.UserName, UserNameChanged)

                    Button("Search", SearchClicked).centerHorizontal()
                }
            }
            |> _.centerVertical()
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication() { Window(content()) }
#endif
    let create () =
        let theme () =
            StyleInclude(baseUri = null, Source = Uri("avares://GitHubClient/App.xaml"))

        FabulousAppBuilder.Configure(theme, view)
