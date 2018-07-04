// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.

namespace TicTacToe

open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Xamarin.Forms

/// Represents a player and a player's move
type Player = 
    | X 
    | O 
    member p.Swap = match p with X -> O | O -> X

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
    | SetVisualBoardSize of double

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
      
      /// The model occasionally includes things related to the view.  In this case,
      /// we track the desired visual size of the board, to ensure a square, in response to
      /// updates telling us the overall allocated size.
      VisualBoardSize: double option
    }

/// The model, update and view content of the app. This is placed in an 
/// independent model to facilitate unit testing.
module App = 
    open System.Windows.Input
    open System.Runtime.CompilerServices

    let positions = 
        [ for x in 0 .. 2 do 
            for y in 0 .. 2 do 
               yield (x, y) ]

    let initialBoard = 
        Map.ofList [ for p in positions -> p, Empty ]

    let init () = 
        { NextUp = X
          Board = initialBoard
          VisualBoardSize = None }

    /// Check if there are any more moves available in the game
    let anyMoreMoves m = m.Board |> Map.exists (fun _ c -> c = Empty)
    
    let lines =
        [
            // rows
            for row in 0 .. 2 do yield [(row,0); (row,1); (row,2)]
            // columns
            for col in 0 .. 2 do yield [(0,col); (1,col); (2,col)]
            // diagonals
            yield [(0,0); (1,1); (2,2)]
            yield [(0,2); (1,1); (2,0)]
        ]

    /// Determine if a line is a winning line.
    let getLine (board: Board) line =
        line |> List.map (fun p -> board.[p])

    /// Determine if a line is a winning line.
    let getLineWinner line =
        if line |> List.forall (function Full X -> true | _ -> false) then Some X
        elif line |> List.forall (function Full O -> true | _ -> false) then Some O
        else None

    /// Determine the game result, if any.
    let getGameResult model =
        match lines |> Seq.tryPick (getLine model.Board >> getLineWinner) with
        | Some p -> Win p
        | _ -> 
           if anyMoreMoves model then StillPlaying
           else Draw

    /// Get a message to show the current game result
    let getMessage model = 
        match getGameResult model with 
        | StillPlaying -> sprintf "%O's turn" model.NextUp
        | Win p -> sprintf "%O wins!" p
        | Draw -> "It is a draw!"

    /// The 'update' function to update the model
    let update gameOver msg model =
        let newModel = 
            match msg with
            | Play pos -> 
                { model with Board = model.Board.Add(pos, Full model.NextUp)
                             NextUp = model.NextUp.Swap }
            | Restart -> 
                { model with NextUp = X; Board = initialBoard }
            | SetVisualBoardSize size -> 
                { model with VisualBoardSize = Some size }

        // Make an announcement in the middle of the game. 
        let result = getGameResult newModel
        if result <> StillPlaying then 
            gameOver (getMessage newModel)

        // Return the new model.
        newModel

    /// A helper used in the 'view' function to get the name 
    /// of the Xaml resource for the image for a player
    let imageForPos cell =
        match cell with
        // Revert this once https://github.com/fsprojects/Elmish.XamarinForms/pull/51 is reverted
        | Full X -> "icon"
        | Full O -> "Nought"
        | Empty -> ""

    /// A helper to get the suffix used in the Xaml for a position on the board.
    let uiText (row,col) = sprintf "%d%d" row col

    /// A condition used in the 'view' function to check if we can play in a cell.
    /// The visual contents of a cell depends on this condition.
    let canPlay model cell = (cell = Empty) && (getGameResult model = StillPlaying)

    /// The dynamic 'view' function giving the updated content for the view
    let view model dispatch =
      Xaml.NavigationPage(barBackgroundColor = Color.LightBlue, 
        barTextColor = Color.Black,
        pages=
          [Xaml.ContentPage(
            Xaml.Grid(rowdefs=[ "*"; "auto"; "auto" ],
              children=[
                Xaml.Grid(rowdefs=[ "*"; 5.0; "*"; 5.0; "*" ], coldefs=[ "*"; 5.0; "*"; 5.0; "*" ],
                    children=[
                        yield Xaml.BoxView(Color.Black).GridRow(1).GridColumnSpan(5)
                        yield Xaml.BoxView(Color.Black).GridRow(3).GridColumnSpan(5)
                        yield Xaml.BoxView(Color.Black).GridColumn(1).GridRowSpan(5)
                        yield Xaml.BoxView(Color.Black).GridColumn(3).GridRowSpan(5)

                        for ((row,col) as pos) in positions ->
                            let item = 
                                if canPlay model model.Board.[pos] then 
                                    Xaml.Button(command=(fun () -> dispatch (Play pos)), backgroundColor=Color.LightBlue)
                                else
                                    Xaml.Image(source=imageForPos model.Board.[pos], margin=10.0)
                            item.GridRow(row*2).GridColumn(col*2) ],

                    rowSpacing=0.0,
                    columnSpacing=0.0,
                    horizontalOptions=LayoutOptions.Center,
                    verticalOptions=LayoutOptions.Center,
                    ?widthRequest = model.VisualBoardSize,
                    ?heightRequest = model.VisualBoardSize).GridRow(0)

                Xaml.Label(text=getMessage model, margin=10.0, textColor=Color.Black, horizontalTextAlignment=TextAlignment.Center, fontSize="Large").GridRow(1)
                Xaml.Button(command=(fun () -> dispatch Restart), text="Restart game", backgroundColor=Color.LightBlue, textColor=Color.Black, fontSize="Large").GridRow(2)
              ]),

             // This requests a square board based on the width we get allocated on the device 
             onSizeAllocated=(fun (width, height) ->
               if model.VisualBoardSize.IsNone then 
                   let sz = min width height - 80.0
                   dispatch (SetVisualBoardSize sz)))])

/// Stitch the model, update and view content into a single app.
type App() as app =
    inherit Application()

    // Display a modal message giving the game result. This is doing a UI
    // action in the model update, which is ok for modal messages. We factor
    // this dependency out to allow unit testing of the 'update' function. 
    let gameOver msg =
        Application.Current.MainPage.DisplayAlert("Game over", msg, "OK") |> ignore

    let runner = 
        Program.mkSimple App.init (App.update gameOver) App.view
#if DEBUG
        |> Program.withConsoleTrace
#endif
        |> Program.runWithDynamicView app
        
