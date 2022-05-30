namespace TicTacToe

open Xamarin.Forms
open Fabulous
open Fabulous.XamarinForms

open type Fabulous.XamarinForms.View

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
    | Play of Pos
    | Restart
    | VisualBoardSizeChanged of SizeAllocatedEventArgs

/// Represents the state of the game board
type Board = Map<Pos, GameCell>

/// Represents the elements of a possibly-winning row
type Row = GameCell list

/// Represents the state of the game
type Model =
    {
      /// Who is next to play
      NextUp: Player

      /// The state of play on the board
      Board: Board

      /// The state of play on the board
      GameScore: int * int

      /// The model occasionally includes things related to the view.  In this case,
      /// we track the desired visual size of the board, to ensure a square, in response to
      /// updates telling us the overall allocated size.
      VisualBoardSize: double option }

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
        { NextUp = X
          Board = initialBoard
          GameScore = (0, 0)
          VisualBoardSize = None }

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
    let update gameOver msg model =
        match msg with
        | Play pos ->
            let newModel =
                { model with
                      Board = model.Board.Add(pos, Full model.NextUp)
                      NextUp = model.NextUp.Swap }

            // Make an announcement in the middle of the game.
            let result = getGameResult newModel

            if result <> StillPlaying then
                gameOver(getMessage newModel)

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
        | VisualBoardSizeChanged args ->
            let size = min args.Width args.Height - 80.

            { model with
                  VisualBoardSize = Some size }

    /// A helper used in the 'view' function to get the name
    /// of the Xaml resource for the image for a player
    let imageForPos cell =
        match cell with
        | Full X ->
            match Device.RuntimePlatform with
            | Device.macOS -> "Cross"
            | _ -> "Cross.png"
        | Full O ->
            match Device.RuntimePlatform with
            | Device.macOS -> "Nought"
            | _ -> "Nought.png"
        | Empty -> ""

    /// A helper to get the suffix used in the Xaml for a position on the board.
    let uiText (row, col) = sprintf "%d%d" row col

    /// A condition used in the 'view' function to check if we can play in a cell.
    /// The visual contents of a cell depends on this condition.
    let canPlay model cell =
        (cell = Empty)
        && (getGameResult model = StillPlaying)

    module private Colors =
        let black = Color.Black.ToFabColor()
        let lightBlue = Color.LightBlue.ToFabColor()

    /// The dynamic 'view' function giving the updated content for the view
    let view model =
        Application(
            (NavigationPage() {
                let contentPage =
                    ContentPage(
                        "TicTacToe",
                        Grid(coldefs = [ Star ], rowdefs = [ Star; Auto; Auto ]) {
                            (Grid(coldefs = [ Star
                                              Absolute 5.0
                                              Star
                                              Absolute 5.0
                                              Star ],
                                  rowdefs = [ Star
                                              Absolute 5.0
                                              Star
                                              Absolute 5.0
                                              Star ]) {
                                BoxView(Colors.black).gridRow(1).gridColumnSpan(5)
                                BoxView(Colors.black).gridRow(3).gridColumnSpan(5)
                                BoxView(Colors.black).gridColumn(1).gridRowSpan(5)
                                BoxView(Colors.black).gridColumn(3).gridRowSpan(5)

                                for row, col as pos in positions do
                                    if canPlay model model.Board.[pos] then
                                        Button("", Play pos)
                                            .backgroundColor(Colors.lightBlue)
                                            .gridRow(row * 2)
                                            .gridColumn(col * 2)
                                    else
                                        Image(Aspect.AspectFit, imageForPos model.Board.[pos])
                                            .center()
                                            .margin(10.)
                                            .gridRow(row * 2)
                                            .gridColumn(col * 2)
                             })
                                .rowSpacing(0.)
                                .columnSpacing(0.)
                                .center()
                                .size(?width = model.VisualBoardSize, ?height = model.VisualBoardSize)
                                .gridRow(0)

                            Label(getMessage model)
                                .textColor(Colors.black)
                                .font(namedSize = NamedSize.Large)
                                .center()
                                .margin(10.)
                                .gridRow(1)

                            Button("Restart game", Restart)
                                .textColor(Colors.black)
                                .backgroundColor(Colors.lightBlue)
                                .font(namedSize = NamedSize.Large)
                                .gridRow(2)
                        }
                    )

                match model.VisualBoardSize with
                | None -> contentPage.onSizeAllocated(VisualBoardSizeChanged)
                | Some _ -> contentPage
             })
                .barBackgroundColor(Colors.lightBlue)
                .barTextColor(Colors.black)
        )

    // Display a modal message giving the game result. This is doing a UI
    // action in the model update, which is ok for modal messages. We factor
    // this dependency out to allow unit testing of the 'update' function.

    let gameOver msg =
        Application.Current.Dispatcher.BeginInvokeOnMainThread
            (fun () ->
                Application.Current.MainPage.DisplayAlert("Game over", msg, "OK")
                |> ignore)

    let program =
        Program.stateful init (update gameOver) view
