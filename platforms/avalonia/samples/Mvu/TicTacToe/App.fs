namespace TicTacToe

open System
open System.Diagnostics
open Avalonia.Controls
open Avalonia.Interactivity
open Avalonia.Media
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View

type Player =
    | X
    | O

    member p.Swap =
        match p with
        | X -> O
        | O -> X

    member p.Name =
        match p with
        | X -> "X"
        | O -> "O"

type GameCell =
    | Empty
    | Full of Player

    member x.CanPlay = (x = Empty)

type GameResult =
    | StillPlaying
    | Win of Player
    | Draw

type Pos = int * int

type Board = Map<Pos, GameCell>

type Row = GameCell list


module App =
    let theme = FluentTheme()

    type Msg =
        | Play of Pos
        | Restart
        | Loaded of RoutedEventArgs

    type Model =
        { NextUp: Player
          Board: Board
          VisualBoardSize: double
          GameScore: int * int }

    let positions =
        [ for x in 0..2 do
              for y in 0..2 do
                  yield (x, y) ]

    let initialBoard = Map.ofList [ for p in positions -> p, Empty ]

    let init () =

        { NextUp = X
          Board = initialBoard
          VisualBoardSize = 0.
          GameScore = (0, 0) },
        Cmd.none

    let anyMoreMoves m =
        m.Board |> Map.exists(fun _ c -> c = Empty)

    let lines =
        [
          // rows
          for row in 0..2 do
              yield [ (row, 0); (row, 1); (row, 2) ]
          // columns
          for col in 0..2 do
              yield [ (0, col); (1, col); (2, col) ]
          // diagonals
          yield [ (0, 0); (1, 1); (2, 2) ]
          yield [ (0, 2); (1, 1); (2, 0) ] ]

    let getLine (board: Board) line = line |> List.map(fun p -> board[p])

    let getLineWinner line =
        if
            line
            |> List.forall (function
                | Full X -> true
                | _ -> false)
        then
            Some X
        elif
            line
            |> List.forall (function
                | Full O -> true
                | _ -> false)
        then
            Some O
        else
            None

    let getGameResult model =
        match lines |> Seq.tryPick(getLine model.Board >> getLineWinner) with
        | Some p -> Win p
        | _ -> if anyMoreMoves model then StillPlaying else Draw

    let getMessage model =
        match getGameResult model with
        | StillPlaying -> $"%s{model.NextUp.Name}'s turn"
        | Win p -> $"%s{p.Name} wins!"
        | Draw -> "It is a draw!"

    let update msg model =
        match msg with
        | Loaded _ ->
            let app = FabApplication.Current
#if MOBILE
            let desiredSize = app.MainView.Bounds

            let size =
                Math.Min(desiredSize.Width, desiredSize.Height)
                / app.MainView.DesiredSize.AspectRatio

            { model with VisualBoardSize = size }, Cmd.none
#else
            let desiredSize = app.MainWindow.Screens.Primary

            let size =
                Math.Min(float desiredSize.Bounds.Width, float desiredSize.Bounds.Height)
                / desiredSize.Scaling

            { model with
                VisualBoardSize = size - 40. },
            Cmd.none
#endif
        | Play pos ->
            let newModel =
                { model with
                    Board = model.Board.Add(pos, Full model.NextUp)
                    NextUp = model.NextUp.Swap }

            // Make an announcement in the middle of the game.
            let result = getGameResult newModel

            let newModel2 =
                let x, y = newModel.GameScore

                match result with
                | Win p ->
                    { newModel with
                        GameScore = (if p = X then (x + 1, y) else (x, y + 1)) }
                | _ -> newModel

            newModel2, Cmd.none
        | Restart ->
            { model with
                NextUp = X
                Board = initialBoard
                GameScore = (0, 0) },
            Cmd.none

    let uiText (row, col) = $"%d{row}%d{col}"

    let canPlay model cell =
        (cell = Empty) && (getGameResult model = StillPlaying)

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
        Component("ContentPage") {
            let! model = Context.Mvu program
            let! theme = Context.Environment(EnvironmentKeys.Theme)

            let borderBrush =
                if theme = ThemeVariant.Light then
                    SolidColorBrush(Colors.Black)
                elif theme = ThemeVariant.Dark then
                    SolidColorBrush(Colors.White)
                else
                    SolidColorBrush(Colors.Black)

            let background =
                if theme = ThemeVariant.Light then
                    SolidColorBrush(Colors.White)
                elif theme = ThemeVariant.Dark then
                    SolidColorBrush(Colors.Black)
                else
                    SolidColorBrush(Colors.White)

            (Grid(coldefs = [ Star ], rowdefs = [ Auto; Star; Auto ]) {
                TextBlock(getMessage model)
                    .textAlignment(TextAlignment.Center)
                    .fontSize(32.)
                    .margin(16., 50., 16., 16.)

                (Grid(coldefs = [ Star; Pixel(5.); Star; Pixel(5.); Star ], rowdefs = [ Star; Pixel(5.); Star; Pixel(5.); Star ]) {

                    Rectangle().fill(borderBrush).gridRow(1).gridColumnSpan(5)

                    Rectangle().fill(borderBrush).gridRow(3).gridColumnSpan(5)

                    Rectangle().fill(borderBrush).gridColumn(1).gridRowSpan(5)

                    Rectangle().fill(borderBrush).gridColumn(3).gridRowSpan(5)

                    for row, col as pos in positions do
                        if canPlay model model.Board[pos] then
                            TextBlock("")
                                .gridRow(row * 2)
                                .gridColumn(col * 2)
                                .fontSize(70.)
                                .background(SolidColorBrush(Colors.Transparent))
                                .onTapped(fun _ -> Play pos)
                        else
                            match model.Board[pos] with
                            | Empty -> ()
                            | Full X ->
                                Border(TextBlock("X").fontSize(model.VisualBoardSize / 3.).center())
                                    .gridRow(row * 2)
                                    .gridColumn(col * 2)
                                    .background(background)
                            | Full O ->
                                Border(TextBlock("O").fontSize(model.VisualBoardSize / 3.).center())
                                    .gridRow(row * 2)
                                    .gridColumn(col * 2)
                                    .background(background)
                })
                    .size(model.VisualBoardSize, model.VisualBoardSize)
                    .gridRow(1)

                Button("Restart game", Restart)
                    .foreground(SolidColorBrush(Colors.Black))
                    .background(SolidColorBrush(Colors.LightBlue))
                    .fontSize(32.)
                    .centerHorizontal()
                    .margin(16., 16., 16., 50.)
                    .gridRow(2)
            })
                .onLoaded(Loaded)
        }

    let view () =
#if MOBILE
        SingleViewApplication(content())
#else
        DesktopApplication() {
            Window(content())
                .sizeToContent(SizeToContent.WidthAndHeight)
        }
#endif
    let create () =
        FabulousAppBuilder.Configure(FluentTheme, view)
