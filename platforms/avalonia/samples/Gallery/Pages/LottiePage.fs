namespace Gallery

open System
open System.Collections.ObjectModel
open System.Diagnostics
open Avalonia
open Avalonia.Controls
open Avalonia.Data
open Avalonia.Layout
open Avalonia.Media
open Avalonia.Platform
open Avalonia.Labs.Lottie
open Fabulous.Avalonia
open Fabulous

open type Fabulous.Avalonia.View

module LottiePage =
    [<AllowNullLiteral>]
    type AssetModel(name: string, path: string) =
        member val Name = name with get, set
        member val Path = path with get, set

        override x.ToString() = x.Name

    type Model =
        { Assets: ObservableCollection<AssetModel>
          SelectedAsset: AssetModel
          PlaybackRate: int
          IsPlaying: bool }

    type Msg =
        | Previous
        | Next
        | SelectionChanged of SelectionChangedEventArgs
        | SetPlaybackRate of int
        | TogglePlayPause of ViewRef<Lottie>

    let init () =
        let assets =
            AssetLoader.GetAssets(Uri("avares://Gallery/Assets"), Uri("avares://Gallery/"))
            |> Seq.filter(_.AbsolutePath.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
            |> Seq.map(fun x -> AssetModel(System.IO.Path.GetFileName(x.AbsoluteUri), x.AbsoluteUri))

        { Assets = ObservableCollection<AssetModel>(assets)
          SelectedAsset = assets |> Seq.head
          PlaybackRate = 1
          IsPlaying = true },
        Cmd.none

    let update (msg: Msg) model =
        match msg with
        | Previous ->
            let index = model.Assets.IndexOf(model.SelectedAsset)

            let selectedAsset =
                if model.SelectedAsset <> null then
                    if index = 0 then model.Assets[model.Assets.Count - 1]
                    elif index > 0 then model.Assets[index - 1]
                    else model.SelectedAsset
                else
                    model.SelectedAsset

            { model with
                SelectedAsset = selectedAsset },
            Cmd.none

        | Next ->
            let index = model.Assets.IndexOf(model.SelectedAsset)

            let selectedAsset =
                if model.SelectedAsset <> null then
                    if index = model.Assets.Count - 1 then
                        model.Assets[0]
                    elif index < model.Assets.Count - 1 then
                        model.Assets[index + 1]
                    else
                        model.SelectedAsset
                else
                    model.SelectedAsset

            { model with
                SelectedAsset = selectedAsset },
            Cmd.none

        | SelectionChanged args ->
            let control = args.Source :?> ComboBox
            let selectedAsset = control.SelectedItem :?> AssetModel

            { model with
                SelectedAsset = selectedAsset },
            Cmd.none

        | SetPlaybackRate rate -> { model with PlaybackRate = rate }, Cmd.none

        | TogglePlayPause lottieRef ->
            let cmd =
                Cmd.ofEffect(fun _ ->
                    match lottieRef.TryValue with
                    | None -> ()
                    | Some lottie -> if model.IsPlaying then lottie.Pause() else lottie.Resume())

            { model with
                IsPlaying = not model.IsPlaying },
            cmd

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
        Component("LottiePage") {
            let! model = Context.Mvu program
            let lottieRef = ViewRef<Lottie>()

            VStack(spacing = 15.) {
                TextBlock("Lottie Animation Demo")
                    .fontSize(24)
                    .fontWeight(FontWeight.Bold)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .margin(0, 0, 0, 10)

                ComboBox(model.Assets)
                    .margin(0, 0, 0, 20)
                    .selectedItem(model.SelectedAsset)
                    .horizontalAlignment(HorizontalAlignment.Center)
                    .onSelectionChanged(SelectionChanged)
                    .displayMemberBinding(Binding("Name"))
                    .width(300)

                Grid(coldefs = [ Auto; Star; Auto ], rowdefs = [ Star ]) {
                    Button(
                        Previous,
                        PathIcon(
                            "M2.75 20a1 1 0 1 0 2 0V4a1 1 0 1 0-2 0v16ZM20.75 19.053c0 1.424-1.612 2.252-2.77 1.422L7.51 12.968a1.75 1.75 0 0 1 .075-2.895l10.47-6.716c1.165-.748 2.695.089 2.695 1.473v14.223Z"
                        )
                            .width(32)
                            .height(32)
                            .foreground(Colors.Green)
                    )
                        .background(Colors.Transparent)
                        .gridColumn(0)
                        .verticalAlignment(VerticalAlignment.Center)

                    Border(
                        Lottie(model.SelectedAsset.Path)
                            .repeatCount(-1)
                            .playBackRate(model.PlaybackRate)
                            .autoPlay(true)
                            .margin(10)
                            .reference(lottieRef)
                    )
                        .gridColumn(1)
                        .margin(20)
                        .borderThickness(1)
                        .cornerRadius(4)
                        .borderBrush(SolidColorBrush(Colors.Gray))

                    Button(
                        Next,
                        PathIcon(
                            "M21 4a1 1 0 1 0-2 0v16a1 1 0 1 0 2 0V4ZM3 4.947c0-1.424 1.612-2.252 2.77-1.422l10.47 7.507a1.75 1.75 0 0 1-.075 2.895l-10.47 6.716C4.53 21.39 3 20.554 3 19.17V4.947Z"
                        )
                            .width(32)
                            .height(32)
                            .foreground(Colors.Green)
                    )
                        .gridColumn(2)
                        .background(Colors.Transparent)
                        .verticalAlignment(VerticalAlignment.Center)
                }

                HStack(spacing = 20) {
                    Border(
                        HStack(spacing = 10) {
                            TextBlock("Playback Rate:")
                                .verticalAlignment(VerticalAlignment.Center)

                            Button("-", SetPlaybackRate(Math.Max(1, model.PlaybackRate - 1)))
                                .width(30)
                                .height(30)

                            TextBlock(string model.PlaybackRate)
                                .width(30)
                                .horizontalAlignment(HorizontalAlignment.Center)
                                .verticalAlignment(VerticalAlignment.Center)

                            Button("+", SetPlaybackRate(model.PlaybackRate + 1))
                                .width(30)
                                .height(30)
                        }
                    )
                        .borderThickness(1)
                        .borderBrush(SolidColorBrush(Colors.Gray))
                        .cornerRadius(4)
                        .padding(10)

                    Button((if model.IsPlaying then "Pause" else "Play"), TogglePlayPause lottieRef)
                        .width(100)
                }

                TextBlock(
                    "The Lottie control supports animations with various playback options. Use the controls above to adjust playback rate and pause/play the animation."
                )
                    .textWrapping(TextWrapping.Wrap)
                    .margin(0, 20, 0, 0)
                    .maxWidth(500)
            }
            |> _.background(
                VisualBrush(
                    Canvas() {
                        Rectangle().width(10).height(10).fill(Colors.LightGray)

                        Rectangle()
                            .width(10)
                            .height(10)
                            .canvasTop(10)
                            .canvasLeft(10)
                            .fill(Colors.LightGray)
                    }
                    |> _.width(20)
                    |> _.height(20)
                    |> _.background(Colors.DarkGray)
                )
                    .destinationRect(Rect(0, 0, 20, 20))
            )
        }
