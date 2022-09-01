namespace TicTacToe

open Microsoft.Maui
open Microsoft.Maui.Controls
open Microsoft.Maui.Graphics
open Microsoft.Maui.ApplicationModel
open Microsoft.Maui.Devices
open Fabulous
open Fabulous.Maui

open type Fabulous.Maui.View

/// Represents a player and a player's move
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

/// Represents the game state contents of a single cell
type GameCell =
    | Empty
    | Full of Player
    member x.CanPlay = (x = Empty)

/// Represents the result of a game
type GameResult =
    | StillPlaying
    | Win of Player
    | Draw

/// Represents a position on the board
type Pos = int * int

/// Represents an update to the game
type Msg =
    | ThemeChanged of AppTheme
    | Play of Pos
    | Restart
    | VisualBoardSizeChanged of size: float

/// Represents the state of the game board
type Board = Map<Pos, GameCell>

/// Represents the elements of a possibly-winning row
type Row = GameCell list

/// Represents the state of the game
type Model =
    {
      // The current theme: Light or Dark modes
      Theme: AppTheme
      
      /// Who is next to play
      NextUp: Player

      /// The state of play on the board
      Board: Board

      /// The state of play on the board
      GameScore: int * int

      /// The model occasionally includes things related to the view.  In this case,
      /// we track the desired visual size of the board, to ensure a square, in response to
      /// updates telling us the overall allocated size.
      VisualBoardSize: double }

/// The model, update and view content of the app. This is placed in an
/// independent model to facilitate unit testing.
module App =
    let positions =
        [ for x in 0 .. 2 do
              for y in 0 .. 2 do
                  yield (x, y) ]

    let initialBoard =
        Map.ofList [ for p in positions -> p, Empty ]

    let init () =
        let size = System.Math.Min(DeviceDisplay.MainDisplayInfo.Width, DeviceDisplay.MainDisplayInfo.Height) / DeviceDisplay.MainDisplayInfo.Density
        
        { Theme = AppInfo.RequestedTheme
          NextUp = X
          Board = initialBoard
          GameScore = (0, 0)
          VisualBoardSize = size - 40. }

    /// Check if there are any more moves available in the game
    let anyMoreMoves m =
        m.Board |> Map.exists(fun _ c -> c = Empty)

    let lines =
        [
          // rows
          for row in 0 .. 2 do
              yield [ (row, 0); (row, 1); (row, 2) ]
          // columns
          for col in 0 .. 2 do
              yield [ (0, col); (1, col); (2, col) ]
          // diagonals
          yield [ (0, 0); (1, 1); (2, 2) ]
          yield [ (0, 2); (1, 1); (2, 0) ] ]

    /// Determine if a line is a winning line.
    let getLine (board: Board) line = line |> List.map(fun p -> board.[p])

    /// Determine if a line is a winning line.
    let getLineWinner line =
        if line
           |> List.forall
               (function
               | Full X -> true
               | _ -> false) then
            Some X
        elif line
             |> List.forall
                 (function
                 | Full O -> true
                 | _ -> false) then
            Some O
        else
            None

    /// Determine the game result, if any.
    let getGameResult model =
        match
            lines
            |> Seq.tryPick(getLine model.Board >> getLineWinner)
            with
        | Some p -> Win p
        | _ ->
            if anyMoreMoves model then
                StillPlaying
            else
                Draw

    /// Get a message to show the current game result
    let getMessage model =
        match getGameResult model with
        | StillPlaying -> sprintf "%s's turn" model.NextUp.Name
        | Win p -> sprintf "%s wins!" p.Name
        | Draw -> "It is a draw!"

    /// The 'update' function to update the model
    let update msg model =
        match msg with
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

            // Return the new model.
            newModel2
        | Restart ->
            { model with
                  NextUp = X
                  Board = initialBoard
                  GameScore = (0, 0) }
        | VisualBoardSizeChanged size ->
            { model with
                VisualBoardSize = size - 40. }
        | ThemeChanged theme ->
            { model with
                Theme = theme }
    
    /// A helper to get the suffix used in the Xaml for a position on the board.
    let uiText (row, col) = sprintf "%d%d" row col

    /// A condition used in the 'view' function to check if we can play in a cell.
    /// The visual contents of a cell depends on this condition.
    let canPlay model cell =
        (cell = Empty)
        && (getGameResult model = StillPlaying)

    /// The dynamic 'view' function giving the updated content for the view
    let view model =        
        Application(
            ContentPage(
                "TicTacToe",
                Grid(coldefs = [ Star ], rowdefs = [ Star; Auto; Auto ]) {
                    (Grid(
                        coldefs = [
                            Star
                            Absolute 5.0
                            Star
                            Absolute 5.0
                            Star
                        ],
                        rowdefs = [
                            Star
                            Absolute 5.0
                            Star
                            Absolute 5.0
                            Star
                        ]) {
                    
                        let gridColor =
                            match model.Theme with
                            | AppTheme.Dark -> SolidColorBrush(Colors.White)
                            | _ -> SolidColorBrush(Colors.Black)
                            
                        Rectangle(5., gridColor).gridRow(1).gridColumnSpan(5)
                        Rectangle(5., gridColor).gridRow(3).gridColumnSpan(5)
                        Rectangle(5., gridColor).gridColumn(1).gridRowSpan(5)
                        Rectangle(5., gridColor).gridColumn(3).gridRowSpan(5)

                        for row, col as pos in positions do
                            if canPlay model model.Board.[pos] then
                                Button("", Play pos)
                                    .backgroundColor(Colors.LightBlue.ToFabColor())
                                    .gridRow(row * 2)
                                    .gridColumn(col * 2)
                            else
                                match model.Board.[pos] with
                                | Empty -> ()
                                | Full X ->
                                    Label("X")
                                        .font(size = model.VisualBoardSize / 3.)
                                        .centerText()
                                        .margin(10.)
                                        .gridRow(row * 2)
                                        .gridColumn(col * 2)
                                        
                                | Full O ->
                                    Label("O")
                                        .font(size = model.VisualBoardSize / 3.)
                                        .centerText()
                                        .margin(10.)
                                        .gridRow(row * 2)
                                        .gridColumn(col * 2)
                    })
                       .rowSpacing(0.)
                       .columnSpacing(0.)
                       .centerVertical()
                       .size(model.VisualBoardSize, model.VisualBoardSize)
                       .gridRow(0)

                    Label(getMessage model)
                        .font(size = 32.)
                        .center()
                        .margin(10.)
                        .gridRow(1)

                    Button("Restart game", Restart)
                        .textColor(Colors.Black.ToFabColor())
                        .backgroundColor(Colors.LightBlue.ToFabColor())
                        .font(size = 32.)
                        .gridRow(2)
                }
            )
        )

    let program =
        Program.stateful init update view
        |> Program.withSubscription (fun _ ->
            Cmd.ofSub (fun dispatch ->
                DeviceDisplay.MainDisplayInfoChanged.Add(fun args ->
                    let size = System.Math.Min(args.DisplayInfo.Width, args.DisplayInfo.Height) / DeviceDisplay.MainDisplayInfo.Density
                    dispatch (VisualBoardSizeChanged size)
                )
            )
        )