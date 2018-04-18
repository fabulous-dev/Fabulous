// Copyright 2018 Elmish.XamarinForms contributors. See LICENSE.md for license.

/// NOTE NOTE NOTE - this version of this sample uses "dynamic" view updates which currently 
/// results in flickering on each update of the UI.  Thus this is not yet appropriate for anything but a sample.
namespace TicTacToe

open Elmish
open Elmish.XamarinForms
open Elmish.XamarinForms.DynamicViews
open Elmish.XamarinForms.DynamicViews.SimplerHelpers
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

/// Represents the state of the game board
type Board = Map<Pos, GameCell>

/// Represents the elements of a possibly-winning row
type Row = GameCell list

/// Represents the state of the game
type Model =
    { 
      NextUp: Player
      Board: Board
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
          Board = initialBoard }

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
                init()

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
        | Full X -> "Cross"
        | Full O -> "Nought"
        | Empty -> ""

    /// A helper to get the suffix used in the Xaml for a position on the board.
    let uiText (row,col) = sprintf "%d%d" row col

    /// A condition used in the 'view' function to check if we can play in a cell.
    /// The visual contents of a cell depends on this condition.
    let canPlay model cell = (cell = Empty) && (getGameResult model = StillPlaying)

    /// The dynamic 'view' function giving the updated content for the view
    let view model dispatch =
        rows 
            [ rowdef "*"; rowdef "auto"; rowdef "auto" ]
            [ grid 
                [ rowdef "*"; rowdef 5.0; rowdef "*"; rowdef 5.0; rowdef "*" ]
                [ coldef "*"; coldef 5.0; coldef "*"; coldef 5.0; coldef "*" ]
                [ yield rectangle Color.Black |> gridRow 1 5
                  yield rectangle Color.Black |> gridRow 3 5
                  yield rectangle Color.Black |> gridCol 1 5
                  yield rectangle Color.Black |> gridCol 3 5
                  for ((row,col) as pos) in positions do 
                      let item = 
                          if canPlay model model.Board.[pos] then 
                              button |> command (fun () -> dispatch (Play pos)) 
                          else
                              image |> imageSource (imageForPos model.Board.[pos]) 
                      let item = item |> margin 5.0
                      yield item |> gridLoc (row*2) (col*2) ]

                |> rowSpacing 0.0
                |> columnSpacing 0.0
                |> horizontalOptions LayoutOptions.Center
                |> verticalOptions LayoutOptions.Center

              label 
                |> text (getMessage model) 
                |> margin 10.0
                |> textColor Color.Black
                |> horizontalTextAlignment TextAlignment.Center
                |> fontSize "Large"

              button 
                |> command (fun () -> dispatch Restart)
                |> text "Restart game"
                |> backgroundColor Color.LightBlue
                |> textColor Color.Black  
                |> fontSize "Large"]

    /// A function which patches the tree generated by 'view' once the overall size has been allocated,
    /// filling in any adjust height/size requests.
    let viewAllocatedSizeFixup (content: View) (width, height) =
        let board = (content :?> Grid).Children.[0]
        board.HeightRequest <- (width - 80.)
        board.WidthRequest <- (width - 80.)
       

/// Stitch the model, update and view content into a single app.
type App() =
    inherit Application()

    // Display a modal message giving the game result. This is doing a UI
    // action in the model update, which is ok for modal messages. We factor
    // this dependency out to allow unit testing of the 'update' function. 
    let gameOver msg =
        Application.Current.MainPage.DisplayAlert("Game over", msg, "OK") |> ignore

    let page = 
        Program.mkSimple 
            App.init 
            (App.update gameOver) 
            (fun _ _ -> HelperPage(App.viewAllocatedSizeFixup), [], App.view) 
        |> Program.withConsoleTrace
        |> Program.runDynamicView
        
    let mainPage = NavigationPage(page, BarBackgroundColor = Color.LightBlue, BarTextColor = Color.Black)
    do base.MainPage <- mainPage

















module Alternatives = 
    open App
    
    /// The second possible style for the dynamic 'view' function. This does the same thing as the above
    /// and can be more suitable to those used to Xaml.
    let view2 model dispatch =
        Xaml.Grid(
            rowDefinitions=[| Xaml.RowDefinition(gridLength "*"); 
                              Xaml.RowDefinition(gridLength "auto"); 
                              Xaml.RowDefinition(gridLength "auto") |],
            children=[|
                Xaml.Grid(
                    rowDefinitions=[| Xaml.RowDefinition(gridLength "*"); 
                                      Xaml.RowDefinition(gridLength 5.0); 
                                      Xaml.RowDefinition(gridLength "*"); 
                                      Xaml.RowDefinition(gridLength 5.0); 
                                      Xaml.RowDefinition(gridLength "*") |],
                    columnDefinitions=[| Xaml.ColumnDefinition(gridLength "*"); 
                                         Xaml.ColumnDefinition(gridLength 5.0); 
                                         Xaml.ColumnDefinition(gridLength "*"); 
                                         Xaml.ColumnDefinition(gridLength 5.0); 
                                         Xaml.ColumnDefinition(gridLength "*") |],
                    children=[|
                        yield Xaml.Grid(backgroundColor=Color.Black).WithGridRow(1)
                        yield Xaml.Grid(backgroundColor=Color.Black).WithGridRow(3)
                        yield Xaml.Grid(backgroundColor=Color.Black).WithGridColumn(1)
                        yield Xaml.Grid(backgroundColor=Color.Black).WithGridColumn(3)
                        for ((row,col) as pos) in positions do 
                            let item = 
                                if canPlay model model.Board.[pos] then 
                                    Xaml.Button(command=convCommand (fun () -> dispatch (Play pos)))
                                else
                                    Xaml.Image(imageSource=convImageSource (imageForPos model.Board.[pos])) 
                            let item = item.WithMargin(convThickness 5.0)
                            let item = item.WithGridRow(row*2).WithGridColumn(col*2) 
                            yield item |],
                    rowSpacing= gridLength 0.0,
                    columnSpacing= gridLength 0.0,
                    horizontalOptions=LayoutOptions.Center,
                    verticalOptions=LayoutOptions.Center)

                Xaml.Label(text=getMessage model, margin=convThickness 10.0, textColor=Color.Black, horizontalTextAlignment=TextAlignment.Center, fontSize=convFontSize "Large")
                Xaml.Button(command=convCommand (fun () -> dispatch Restart), text="Restart game", backgroundColor=Color.LightBlue, textColor=Color.Black, fontSize=convFontSize "Large")
              |])


(*
    /// The third possible style for the dynamic 'view' function (requires inserting auto-conversion into generated model)
    let view3 model dispatch =
        Xaml.Grid(
            rowDefinitions=[| rowdef "*"; rowdef "auto"; rowdef "auto" |],
            children=[|
                Xaml.Grid(
                    rowDefinitions=[| rowdef "*"; rowdef 5.0; rowdef "*"; rowdef 5.0; rowdef "*" |],
                    columnDefinitions=[| coldef "*"; coldef 5.0; coldef "*"; coldef 5.0; coldef "*" |],
                    children=[|
                        yield Xaml.Grid(backgroundColor=Color.Black).WithGridRow(1)
                        yield Xaml.Grid(backgroundColor=Color.Black).WithGridRow(3)
                        yield Xaml.Grid(backgroundColor=Color.Black).WithGridColumn(1)
                        yield Xaml.Grid(backgroundColor=Color.Black).WithGridColumn(3)
                        for ((row,col) as pos) in positions do 
                            let item = 
                                if canPlay model model.Board.[pos] then 
                                    Xaml.Button(command=(fun () -> dispatch (Play pos)))
                                else
                                    Xaml.Image(imageSource=imageForPos model.Board.[pos]) 
                            let item = item.WithMargin(5.0)
                            let item = item.WithGridRow(row*2).WithGridColumn(col*2) 
                            yield item |],
                    rowSpacing=0.0,
                    columnSpacing=0.0,
                    horizontalOptions=LayoutOptions.Center,
                    verticalOptions=LayoutOptions.Center)

                Xaml.Label(text=getMessage model, margin=10.0, textColor=Color.Black, horizontalTextAlignment=TextAlignment.Center, fontSize=convFontSize "Large")
                Xaml.Button(command=(fun () -> dispatch Restart), text="Restart game", backgroundColor=Color.LightBlue, textColor=Color.Black, fontSize=convFontSize "Large")
              |])
*)

