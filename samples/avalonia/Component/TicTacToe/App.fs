namespace TicTacToe

open System
open Avalonia.Controls
open Avalonia.Media
open Avalonia.Styling
open Fabulous
open Fabulous.Avalonia
open Avalonia.Themes.Fluent

open type Fabulous.Avalonia.View
open type Fabulous.Context

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
    let positions =
        [ for x in 0..2 do
              for y in 0..2 do
                  yield (x, y) ]

    let initialBoard = Map.ofList [ for p in positions -> p, Empty ]

    let anyMoreMoves board =
        board |> Map.exists(fun _ c -> c = Empty)

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

    let getGameResult board =
        match lines |> Seq.tryPick(getLine board >> getLineWinner) with
        | Some p -> Win p
        | _ -> if anyMoreMoves board then StillPlaying else Draw

    let getMessage board name =
        match getGameResult board with
        | StillPlaying -> $"%s{name}'s turn"
        | Win p -> $"%s{p.Name} wins!"
        | Draw -> "It is a draw!"

    let uiText (row, col) = $"%d{row}%d{col}"

    let canPlay board cell =
        (cell = Empty) && (getGameResult board = StillPlaying)

    let content () =
        Component("ContentPage") {
            let! board = State(initialBoard)
            let! nextUp = State(X)
            let! theme = Environment(EnvironmentKeys.Theme)
            let! gameScore = State((0, 0))
            let! visualBoardSize = State(0.)

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
                TextBlock(getMessage board.Current nextUp.Current.Name)
                    .textAlignment(TextAlignment.Center)
                    .fontSize(32.)
                    .margin(16., 50., 16., 16.)

                (Grid(coldefs = [ Star; Pixel(5.); Star; Pixel(5.); Star ], rowdefs = [ Star; Pixel(5.); Star; Pixel(5.); Star ]) {

                    Rectangle().fill(borderBrush).gridRow(1).gridColumnSpan(5)

                    Rectangle().fill(borderBrush).gridRow(3).gridColumnSpan(5)

                    Rectangle().fill(borderBrush).gridColumn(1).gridRowSpan(5)

                    Rectangle().fill(borderBrush).gridColumn(3).gridRowSpan(5)

                    for row, col as pos in positions do
                        if canPlay board.Current board.Current[pos] then
                            TextBlock("")
                                .gridRow(row * 2)
                                .gridColumn(col * 2)
                                .fontSize(70.)
                                .background(SolidColorBrush(Colors.Transparent))
                                .onTapped(fun _ ->
                                    board.Set(board.Current.Add(pos, Full nextUp.Current))
                                    nextUp.Set(nextUp.Current.Swap)
                                    let result = getGameResult board.Current
                                    let x, y = gameScore.Current

                                    match result with
                                    | Win p -> (if p = X then (x + 1, y) else (x, y + 1)) |> gameScore.Set
                                    | _ -> ())
                        else
                            match board.Current[pos] with
                            | Empty -> ()
                            | Full X ->
                                Border(
                                    TextBlock("X")
                                        .fontSize(visualBoardSize.Current / 3.)
                                        .center()
                                )
                                    .gridRow(row * 2)
                                    .gridColumn(col * 2)
                                    .background(background)
                            | Full O ->
                                Border(
                                    TextBlock("O")
                                        .fontSize(visualBoardSize.Current / 3.)
                                        .center()
                                )
                                    .gridRow(row * 2)
                                    .gridColumn(col * 2)
                                    .background(background)
                })
                    .size(visualBoardSize.Current, visualBoardSize.Current)
                    .gridRow(1)

                Button(
                    "Restart game",
                    fun _ ->
                        board.Set(initialBoard)
                        nextUp.Set(X)
                        gameScore.Set(0, 0)
                )
                    .foreground(SolidColorBrush(Colors.Black))
                    .background(SolidColorBrush(Colors.LightBlue))
                    .fontSize(32.)
                    .centerHorizontal()
                    .margin(16., 16., 16., 50.)
                    .gridRow(2)
            })
                .onLoaded(fun _ ->

                    let app = FabApplication.Current
#if MOBILE
                    let desiredSize = app.MainView.Bounds

                    let size =
                        Math.Min(desiredSize.Width, desiredSize.Height)
                        / app.MainView.DesiredSize.AspectRatio

                    visualBoardSize.Set(size)
#else
                    let desiredSize = app.MainWindow.Screens.Primary

                    let size =
                        Math.Min(float desiredSize.Bounds.Width, float desiredSize.Bounds.Height)
                        / desiredSize.Scaling

                    visualBoardSize.Set(size)
#endif
                )
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
